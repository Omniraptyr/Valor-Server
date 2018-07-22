using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
namespace wServer.networking.handlers
{
    class QoLActionHandler : PacketHandlerBase<QoLAction>
    {
        public override PacketId ID => PacketId.QOLACTION;

        protected override void HandlePacket(Client client, QoLAction packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet));
        }

        void Handle(Player player, RealmTime time, QoLAction packet)
        {
            switch (packet.ActionId)
            {
                case 1:
                    if(player.SorStorage >= 30)
                    {
                        //take fragments
                        var acc = player.Client.Account;
                        player.Client.Manager.Database.UpdateSorStorage(acc, -30);
                        player.SorStorage -= 30;
                        player.ForceUpdate(player.SorStorage);
                        //update vault with crystal
                        player.SendHelp("You now have " + player.SorStorage + " sor fragments left. A Sor Crystal has been sent to your vault!");
                        player.Client.Manager.Database.AddGift(acc, 0x49e5);
                    }
                    else
                    {
                        player.SendError("You can't construct a Sor Crystal with less than 30 fragments.");
                    }
                    break;
                case 2:
                    if(player.Fame >= 1 && player.Credits >= 1000)
                    {
                        var acc = player.Client.Account;
                        player.Client.Manager.Database.UpdateCredit(acc, -1000);
                        player.Credits -= 1000;
                        player.ForceUpdate(player.Credits);
                        
                        player.Client.Manager.Database.UpdateFame(acc, player.Fame);
                        player.CurrentFame += player.Fame;
                        player.ForceUpdate(player.CurrentFame);

                        player.Fame -= player.Fame;
                    }
                    else
                    {
                        player.SendError("Error!");
                    }
                    break;
            }
        }
    }
}
