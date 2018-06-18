using System.Linq;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.networking.handlers
{
    class PlayerHitHandler : PacketHandlerBase<PlayerHit>
    {
        public override PacketId ID => PacketId.PLAYERHIT;
        private Timer timer = null;
        private int inproperHits;

        protected override void HandlePacket(Client client, PlayerHit packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client, t, packet.ObjectId, packet.BulletId));
        }

        private void Handle(Client client, RealmTime time, int objectId, byte bulletId)
        {
            if (timer == null) {
                timer = new Timer(60000);
                timer.Elapsed += (o, e) => {
                    inproperHits = 0;
                };
                timer.AutoReset = true;
                timer.Enabled = true;
            }

            Player player = client.Player;

            if (player?.Owner == null)
                return;

            var entity = player.Owner.GetEntity(objectId);

            if (entity == null)
                inproperHits++;

            var prj = entity != null ?
                ((IProjectileOwner) entity).Projectiles[bulletId] :
                player.Owner.Projectiles
                    .Where(p => p.Value.ProjectileOwner.Self.Id == objectId)
                    .SingleOrDefault(p => p.Value.ProjectileId == bulletId).Value;

            if (prj == null)
                inproperHits++;

            if (inproperHits > 20)
                client.Disconnect();
           
            prj?.ForceHit(player, time);
        }
    }
}
