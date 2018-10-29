using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
using wServer.realm.worlds;

namespace wServer.networking.handlers
{
    internal class EscapeHandler : PacketHandlerBase<Escape>
    {
        public override PacketId ID => PacketId.ESCAPE;

        protected override void HandlePacket(Client client, Escape packet)
        {
            //client.Manager.Logic.AddPendingAction(t => Handle(client, packet));
            Handle(client, packet);
        }

        private static void Handle(Client client, Escape packet)
        {
            if (client.Player?.Owner == null)
                return;

            var map = client.Player.Owner;
            if (map.Id == World.Nexus)
            {
                //client.Player.SendInfo("Already in Nexus!");
                client.Disconnect();
                return;
            }

            client.Reconnect(new Reconnect()
            {
                Host = "",
                Port = 2050,
                GameId = World.Nexus,
                Name = "Nexus",
                IsFromArena = false
            });
        }
    }
}
