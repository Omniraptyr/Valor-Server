using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using Player = wServer.realm.entities.Player;

namespace wServer.networking.handlers
{
    internal class TeleportHandler : PacketHandlerBase<Teleport>
    {
        public override PacketId ID => PacketId.TELEPORT;

        protected override void HandlePacket(Client client, Teleport packet) {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet.ObjectId));
        }

        private static void Handle(Player player, RealmTime time, int objId) {
            if (player?.Owner == null)
                return;

            player.Teleport(time, objId);
        }
    }
}
