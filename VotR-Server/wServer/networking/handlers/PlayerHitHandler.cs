using System.Linq;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.realm;
using wServer.realm.entities;
using common.resources;
using System;
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
            Player player = client.Player;
            if (client.Player.Owner.PvP != true)
            {
                if (timer == null)
                {
                    timer = new Timer(60000);
                    timer.Elapsed += (o, e) => {
                        inproperHits = 0;
                    };
                    timer.AutoReset = true;
                    timer.Enabled = true;
                }

                

                if (player?.Owner == null)
                    return;

                var entity = player.Owner.GetEntity(objectId);

                if (entity == null)
                    inproperHits++;


                var prj = entity != null ?
                    ((IProjectileOwner)entity).Projectiles[bulletId] :
                    player.Owner.Projectiles
                        .Where(p => p.Value.ProjectileOwner.Self.Id == objectId)
                        .SingleOrDefault(p => p.Value.ProjectileId == bulletId).Value;

                //player.enemyprj = prj;

                player.verifyDamage2 = ((IProjectileOwner)entity).Projectiles[bulletId].Damage;

                if (player.CheckDRage() == true)
                {
                    //Drannol Rage Passive
                    player.ApplyConditionEffect(ConditionEffectIndex.GraspofZol, 2000 + (player.Surge * 20));
                }
                Random rnd = new Random();
                int chance = rnd.Next(1, 6);
                if (player.CheckFRage() == true && chance == 1)
                {
                    //Titan's Wrath
                    player.HP += prj.ProjDesc.MinDamage / 2;
                }
                if (prj == null)
                    inproperHits++;

                if (inproperHits > 100)
                    Log.Error(player.Name + " has reached 100 inproper hits, maybe hacking?");

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