using System;
using System.Collections.Generic;
using System.Linq;
using common.resources;
using Mono.Game;
using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;

namespace wServer.networking.handlers
{
    internal class InvSwapHandler : PacketHandlerBase<InvSwap>
    {
        private static readonly Random Rand = new Random();
        public Inventory Inv => null;
        public override PacketId ID => PacketId.INVSWAP;

        protected override void HandlePacket(Client client, InvSwap packet)
        {
            Handle(
                client.Player,
                client.Player.Owner.GetEntity(packet.SlotObj1.ObjectId),
                client.Player.Owner.GetEntity(packet.SlotObj2.ObjectId),
                packet.SlotObj1.SlotId, packet.SlotObj2.SlotId);
        }
        
        private void Handle(
            Player player,
            Entity a, Entity b,
            int slotA, int slotB)
        {

            if (player?.Owner == null)
                return;

            if (slotA != slotB
                && slotB != 255 && slotB != 254 
                && slotA != 255 && slotA != 254 
                && slotA < 12 && slotB < 12 
                         || player.HasBackpack && slotA < 20 && slotB < 20) {
                Player playerA = null, playerB = null;
                if (a is Player plrA) playerA = plrA;
                if (b is Player plrB) playerB = plrB;

                if (slotA >= 0 && slotA < 4) {
                    playerA?.OnUnequip(playerA.Inventory[slotA]);
                    if (playerB?.Inventory[slotB] != null)
                        playerB.OnEquip(playerB.Inventory[slotB]);
                } else if (slotB >= 0 && slotB < 4) {
                    playerA?.OnEquip(playerA.Inventory[slotA]);
                    if (playerB?.Inventory[slotB] != null)
                        playerB.OnUnequip(playerB.Inventory[slotB]);
                }
            }

            if (!ValidateEntities(player, a, b) || player.tradeTarget != null)
            {
                a.ForceUpdate(slotA);
                b.ForceUpdate(slotB);
                player.Client.SendPacket(new InvResult() { Result = 1 });
                return;
            }

            var conA = (IContainer) a;
            var conB = (IContainer) b;
            
            // check if stacking operation
            if (b == player)
                foreach (var stack in player.Stacks)
                    if (stack.Slot == slotB)
                    {
                        var stackTrans = conA.Inventory.CreateTransaction();
                        var item = stack.Put(stackTrans[slotA]);
                        if (item == null) // success
                        {
                            // if a stackable item ends up in a gift chest it becomes infinite if not removed
                            if (a is GiftChest && stackTrans[slotA] != null)
                            {
                                var trans = player.Manager.Database.Conn.CreateTransaction();
                                player.Manager.Database.RemoveGift(player.Client.Account, stackTrans[slotA].ObjectType, trans);
                                trans.Execute();
                            }
                            
                            stackTrans[slotA] = null;
                            Inventory.Execute(stackTrans);
                            player.Client.SendPacket(new InvResult() { Result = 0 });
                            return;
                        }
                    }

            // not stacking operation, continue on with normal swap
            
            // validate slot types
            if (!ValidateSlotSwap(player, conA, conB, slotA, slotB))
            {
                a.ForceUpdate(slotA);
                b.ForceUpdate(slotB);
                player.Client.SendPacket(new InvResult() { Result = 1 });
                return;
            }

            // setup swap
            var queue = new Queue<Action>();
            var conATrans = conA.Inventory.CreateTransaction();
            var conBTrans = conB.Inventory.CreateTransaction();
            var itemA = conATrans[slotA];
            var itemB = conBTrans[slotB];
            conBTrans[slotB] = itemA;
            conATrans[slotA] = itemB;
            // validate that soulbound items are not placed in public bags (includes any swaped item from admins)
            if (!ValidateItemSwap(player, a, itemB) 
                && (player.Elite == 0 || IsSoleContainerOwner(player, a as Container)))
            {
                queue.Enqueue(() => DropInSoulboundBag(player, itemB));
                conATrans[slotA] = null;
            }
            if (!ValidateItemSwap(player, b, itemA) 
                && (player.Elite == 0 || IsSoleContainerOwner(player, b as Container)))
            {
                queue.Enqueue(() => DropInSoulboundBag(player, itemA));
                conBTrans[slotB] = null;
            }

            // swap items
            if (Inventory.Execute(conATrans, conBTrans))
            {
                // remove gift if from gift chest
                var db = player.Manager.Database;
                var trans = db.Conn.CreateTransaction();
                if (a is GiftChest && itemA != null)
                    db.RemoveGift(player.Client.Account, itemA.ObjectType, trans);
                if (b is GiftChest && itemB != null)
                    db.RemoveGift(player.Client.Account, itemB.ObjectType, trans);
                if (trans.Execute())
                {
                    while (queue.Count > 0)
                        queue.Dequeue()();

                    player.Client.SendPacket(new InvResult() { Result = 0 });
                    return;
                }
            }
            a.ForceUpdate(slotA);
            b.ForceUpdate(slotB);
            player.Client.SendPacket(new InvResult() { Result = 1 });
        }


        bool ValidateEntities(Player p, Entity a, Entity b)
        { // returns false if bad input
            if (a == null || b == null)
                return false;

            if ((a as IContainer) == null ||
                (b as IContainer) == null)
                return false;

            if (a is Player && a != p ||
                b is Player && b != p)
                return false;

            if (a is Container contA &&
                contA.BagOwners.Length > 0 &&
                !contA.BagOwners.Contains(p.AccountId))
                return false;


            if (b is Container contB &&
                contB.BagOwners.Length > 0 &&
                !contB.BagOwners.Contains(p.AccountId))
                return false;

            if (a is OneWayContainer && b != p ||
                b is OneWayContainer && a != p)
                return false;

            var aPos = new Vector2(a.X, a.Y);
            var bPos = new Vector2(b.X, b.Y);
            if (Vector2.DistanceSquared(aPos, bPos) > 1)
                return false;

            return true;
        }

        private bool ValidateSlotSwap(Player player, IContainer conA, IContainer conB, int slotA, int slotB)
        {
            return
                (slotA < 12 && slotB < 12 || player.HasBackpack) &&
                conB.AuditItem(conA.Inventory[slotA], slotB) &&
                conA.AuditItem(conB.Inventory[slotB], slotA);
        }

        private bool ValidateItemSwap(Player player, Entity c, Item item)
        {
            return c == player ||
                   item == null ||
                   !item.Soulbound && !player.Client.Account.Admin ||
                   IsSoleContainerOwner(player, c as IContainer);
        }

        private static bool IsSoleContainerOwner(Player player, IContainer con)
        {
            int[] owners = null;
            if (con is Container container)
                owners = container.BagOwners;

            return owners != null && owners.Length == 1 && owners.Contains(player.AccountId);
        }

        private static void DropInSoulboundBag(Player player, Item item)
        {
            var container = new Container(player.Manager, 0x0503, 1000 * 60, true)
            {
                BagOwners = new[] {player.AccountId},
                Inventory = {[0] = item}
            };
            container.Move(player.X + (float)((Rand.NextDouble() * 2 - 1) * 0.5),
                           player.Y + (float)((Rand.NextDouble() * 2 - 1) * 0.5));
            container.SetDefaultSize(75);
            player.Owner.EnterWorld(container);
        }
    }
}
