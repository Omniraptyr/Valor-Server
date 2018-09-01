using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;

namespace wServer.networking.handlers
{
    class SorForgeRequestHandler : PacketHandlerBase<SorForgeRequest>
    {
        public override PacketId ID => PacketId.SORFORGEREQUEST;

        protected override void HandlePacket(Client client, SorForgeRequest packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet));
        }

        void Handle(Player player, RealmTime time, SorForgeRequest packet)
        {
        if(player.Onrane >= 20)
            {
                player.ascendSorCrystal(player);
            }
            else
            {
                player.SendInfo("You do not have enough onrane in order to ascend your Sor Crystal!");
            }
        }
    }
}
