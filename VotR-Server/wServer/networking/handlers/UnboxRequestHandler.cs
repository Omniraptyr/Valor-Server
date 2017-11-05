using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
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
            ushort[] items = new ushort[50];
            switch (packet.lootboxType)
            {
                case 1:
                    player.Unbox(1);
                    break;
                case 2:
                    player.Unbox(2);
                    break;
                case 3:
                    player.Unbox(3);
                    break;
                case 4:
                    player.Unbox(4);
                    break;
                case 5:
                    player.Unbox(5);
                    break;
            }
        }
    }
}
