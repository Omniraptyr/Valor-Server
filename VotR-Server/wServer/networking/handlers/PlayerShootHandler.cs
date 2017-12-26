using common.resources;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
using wServer.realm;
using log4net;
using System;
using System.Collections.Generic;

namespace wServer.networking.handlers
{
    class PlayerShootHandler : PacketHandlerBase<PlayerShoot>
    {
        public override PacketId ID => PacketId.PLAYERSHOOT;
        private static readonly ILog CheatLog = LogManager.GetLogger("CheatLog");

        protected override void HandlePacket(Client client, PlayerShoot packet)
        {
            //client.Manager.Logic.AddPendingAction(t => Handle(client.Player, packet, t));
            Handle(client.Player, packet);
        }

        private int condHitReq = -1;

        private void Handle(Player player, PlayerShoot packet)
        {
            if (player?.Owner == null) return;

            Item item;
            if (!player.Manager.Resources.GameData.Items.TryGetValue(packet.ContainerType, out item))
            {
                player.DropNextRandom();
                return;
            }

            if (item == player.Inventory[1])
                return; // ability shoot handled by useitem

            // validate
            var result = player.ValidatePlayerShoot(item, packet.Time);
            if (result != PlayerShootStatus.OK)
            {
                CheatLog.Info($"PlayerShoot validation failure ({player.Name}:{player.AccountId}): {result}");
                player.DropNextRandom();
                return;
            }

            // create projectile and show other players
            var prjDesc = item.Projectiles[0]; //Assume only one

            foreach (var pair in prjDesc.CondChance) {
                if (condHitReq != -1) {
                    condHitReq--;
                    continue;
                }

                if (pair.Value <= 0 || pair.Key == default(ConditionEffect)) {
                    condHitReq = -1;
                    continue;
                }

                AlreadyZero:
                if (condHitReq == 0) {
                    var effList = new List<ConditionEffect>(prjDesc.Effects);
                    effList.Add(pair.Key);
                    prjDesc.Effects = effList.ToArray();
                    condHitReq = -1;
                    continue;
                }

                Random r = new Random();
                double chance = (100 / pair.Value) - 1; //required shots on avg
                condHitReq = (int)(Math.Truncate(chance) //non-integral part
                    + (r.NextDouble() < (chance - Math.Truncate(chance)) ? 1 : 0) //integral part as random since there's no decimals in shot measurement
                    + (Math.Sqrt(-2.0 * Math.Log(r.NextDouble())) *
                                Math.Sin(2.0 * Math.PI * r.NextDouble())) * (chance / 3)); //gaussian to account for discrepancies
                if (condHitReq == 0) goto AlreadyZero;
            }

            Projectile prj = player.PlayerShootProjectile(
                packet.BulletId, prjDesc, item.ObjectType,
                packet.Time, packet.StartingPos, packet.Angle);
            player.Owner.EnterWorld(prj);
            player.Owner.BroadcastPacketNearby(new AllyShoot()
            {
                OwnerId = player.Id,
                Angle = packet.Angle,
                ContainerType = packet.ContainerType,
                BulletId = packet.BulletId
            }, player, player, PacketPriority.Low);
            player.FameCounter.Shoot(prj);
        }
    }
}
