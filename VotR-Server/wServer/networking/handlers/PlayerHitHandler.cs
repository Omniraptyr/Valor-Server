using System.Linq;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.realm;
using wServer.realm.entities;
using common.resources;
using System;
namespace wServer.networking.handlers
{
    internal class PlayerHitHandler : PacketHandlerBase<PlayerHit>
    {
        public override PacketId ID => PacketId.PLAYERHIT;

        protected override void HandlePacket(Client client, PlayerHit packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client, t, packet.ObjectId, packet.BulletId));
        }

        private void Handle(Client client, RealmTime time, int objectId, byte bulletId)
        {
            var player = client.Player;
            if (client.Player.Owner.PvP != true)
            {
                if (player?.Owner == null)
                    return;

                var entity = player.Owner.GetEntity(objectId);

                var prj = entity != null ?
                    ((IProjectileOwner)entity).Projectiles[bulletId] :
                    player.Owner.Projectiles
                        .Where(p => p.Value.ProjectileOwner.Self.Id == objectId)
                        .SingleOrDefault(p => p.Value.ProjectileId == bulletId).Value;

                if (entity != null)
                    player.verifyDamage2 = ((IProjectileOwner)entity).Projectiles[bulletId].Damage;

                if (player.CheckDRage())
                {
                    //Drannol Rage Passive
                    player.ApplyConditionEffect(ConditionEffectIndex.GraspofZol, 2000 + (player.Surge * 20));
                }

                if (player.CheckAnguish())
                {
                    //Drannol Rage Passive 2
                    ((Enemy)entity).Damage(player, time, player.verifyDamage2 / 2, false);
                }

                if (player.CheckFRage() && new Random().Next(1, 6) == 1)
                {
                    //Titan's Wrath
                    player.HP += prj.ProjDesc.MinDamage / 2;
                }

                prj?.ForceHit(player, time);
            }
            else
            {
                if (player?.Owner == null)
                    return;

                var entity = player?.Owner?.GetEntity(objectId);

                var prj = entity != null ? (player as IProjectileOwner).Projectiles[bulletId] : player.Owner.Projectiles
                        .Where(p => p.Value.ProjectileOwner.Self.Id == objectId)
                        .SingleOrDefault(p => p.Value.ProjectileId == bulletId).Value;

                prj?.ForceHit(entity, time);
            }

        }
    }
}