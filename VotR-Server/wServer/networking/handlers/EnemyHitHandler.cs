using common.resources;
using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;

namespace wServer.networking.handlers
{
    internal class EnemyHitHandler : PacketHandlerBase<EnemyHit>
    {
        public override PacketId ID => PacketId.ENEMYHIT;

        protected override void HandlePacket(Client client, EnemyHit packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet));
        }

        private static void Handle(Player player, RealmTime time, EnemyHit pkt)
        {
            var entity = player?.Owner?.GetEntity(pkt.TargetId);
            if (entity?.Owner == null)
                return;

            if (player.Client.IsLagging || player.HasConditionEffect(ConditionEffects.Hidden))
                return;

            var prj = (player as IProjectileOwner).Projectiles[pkt.BulletId];

            if (prj == null)
            {
                return;
            }

            prj.ForceHit(entity, time);

            if (pkt.Killed)
                player.ClientKilledEntity.Enqueue(entity);
        }
    }
}
