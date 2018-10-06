using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using Player = wServer.realm.entities.Player;

namespace wServer.networking.handlers
{
    class UnboxRequestHandler : PacketHandlerBase<UnboxRequest>
    {
        public override PacketId ID => PacketId.UNBOXREQUEST;

        protected override void HandlePacket(Client client, UnboxRequest packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet));
        }

        void Handle(Player player, RealmTime time, UnboxRequest packet)
        {
            var acc = player.Client.Account;
            switch (packet.lootboxType)
            {
                case 1:
                    if(player.BronzeLootbox >= 1)
                    {
                        player.Client.Manager.Database.UpdateBronzeLootbox(acc, -1);
                        player.BronzeLootbox -= 1;
                        player.ForceUpdate(player.BronzeLootbox);
                        player.Unbox(1);
                    }
                    else
                    {
                        player.SendError("You do not have any lootboxes to open!");
                    }
                    break;
                case 2:
                    if (player.SilverLoootbox >= 1)
                    {
                        player.Client.Manager.Database.UpdateSilverLootbox(acc, -1);
                        player.SilverLoootbox -= 1;
                        player.ForceUpdate(player.SilverLoootbox);
                        player.Unbox(2);
                    }
                    else
                    {
                        player.SendError("You do not have any lootboxes to open!");
                    }
                    break;
                case 3:
                    if (player.GoldLootbox >= 1)
                    {
                        player.Client.Manager.Database.UpdateGoldLootbox(acc, -1);
                        player.GoldLootbox -= 1;
                        player.ForceUpdate(player.GoldLootbox);
                        player.Unbox(3);
                    }
                    else
                    {
                        player.SendError("You do not have any lootboxes to open!");
                    }
                    break;
                case 4:
                    if (player.EliteLootbox >= 1 && player.Onrane >= 5)
                    {
                        player.Client.Manager.Database.UpdateEliteLootbox(acc, -1);
                        player.Client.Manager.Database.UpdateOnrane(acc, -5);
                        player.EliteLootbox -= 1;
                        player.Onrane = player.Client.Account.Onrane - 5;
                        player.ForceUpdate(player.Onrane);
                        player.ForceUpdate(player.EliteLootbox);
                        player.Unbox(4);
                    }
                    else
                    {
                        player.SendError("You do not have any lootboxes to open or you don't have the sufficient amount of onrane!");
                    }
                    break;
                case 5:
                    if (player.Kantos >= 600)
                    {
                        player.Client.Manager.Database.UpdateKantos(acc, -600);
                        player.Kantos = player.Client.Account.Kantos - 600;
                        player.ForceUpdate(player.Kantos);
                        player.Unbox(5);
                    }
                    else
                    {
                        player.SendError("You do not have the sufficient amount of Kantos to open this box.");
                    }
                    break;
            }
        }
    }
}
