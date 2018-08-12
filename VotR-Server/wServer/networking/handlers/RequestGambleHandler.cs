using wServer.networking.packets;
using wServer.networking.packets.incoming;

namespace wServer.networking.handlers
{
    class RequestGambleHandler : PacketHandlerBase<RequestGamble>
    {
        public override PacketId ID => PacketId.REQUESTGAMBLE;

        protected override void HandlePacket(Client client, RequestGamble packet)
        {
            //client.Manager.Logic.AddPendingAction(t => Handle(client, packet));
            Handle(client, packet);
        }

        private void Handle(Client client, RequestGamble packet)
        {
            if (client.Player == null || IsTest(client))
                return;

            client.Player.RequestGamble(packet.Name, client.Player.betAmount);
        }
    }
}
