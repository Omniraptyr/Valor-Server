#region

using common.resources;
using System.Collections.Generic;
using wServer.networking.packets;
using wServer.networking.packets.outgoing;
using wServer.networking.packets.outgoing.pets;
using wServer.realm.entities;

#endregion

namespace wServer.realm.entities
{
    class Torii : StaticObject {

        private readonly int duration;
        private readonly int lifetime;
        private readonly uint effColor;
        private readonly bool targetPlayers;
        private readonly float radius;
        private readonly Player player;
        private readonly ConditionEffectIndex effect;
        private readonly ushort objType;
        private int reqTime = 500;

        public Torii(Player player, float radius, int lifetime, bool targetPlayers
            , int duration, ConditionEffectIndex effect, uint effColor, ushort objType)
            : base(player.Manager, 0x0711, lifetime * 1000, true, true, false)
        {
            this.player = player;
            this.radius = radius;
            this.lifetime = lifetime;
            this.duration = duration;
            this.effect = effect;
            this.targetPlayers = targetPlayers;
            this.effColor = effColor;
            this.objType = objType;
        }

        public override void Tick(RealmTime time)
        {
            if (reqTime <= 0) {
                List<Player> players = new List<Player>();
                List<Enemy> enemies = new List<Enemy>();
                Owner.BroadcastPacket(new ShowEffect() {
                    EffectType = EffectType.Trap,
                    Color = new ARGB(effColor),
                    TargetObjectId = Id,
                    Pos1 = new Position { X = radius }
                }, null);
                this.AOE(radius, targetPlayers, entity => {
                    if (entity.ObjectType == objType) return;
                    if (targetPlayers) {
                        players.Add(entity as Player);
                        entity.ApplyConditionEffect(new ConditionEffect {
                            Effect = effect,
                            DurationMS = duration
                        });
                    } else {
                        if(entity.ObjectType != 0x638f)
                        {
                            enemies.Add(entity as Enemy);
                            entity.ApplyConditionEffect(new ConditionEffect
                            {
                                Effect = effect,
                                DurationMS = duration
                            });
                        }
                    }
                });
                if (players.Count > 0) {
                    foreach (Player player in players)
                        Owner.BroadcastPacket(new ShowEffect() {
                            EffectType = EffectType.Trail,
                            Color = new ARGB(effColor),
                            TargetObjectId = Id,
                            Pos1 = new Position { X = player.X, Y = player.Y }
                        }, null, PacketPriority.Low);
                }
                if (enemies.Count > 0) {
                    foreach (Enemy enemy in enemies)
                        if(enemy.ObjectType != 0x22c8 || enemy.ObjectType != 0x22cb || enemy.ObjectType != 0x22cc || enemy.ObjectType != 0x638f || enemy.ObjectType != 0x6392 || enemy.ObjectType != 0x6393 || enemy.ObjectType != 0x6394 || enemy.ObjectType != 0x6395 || enemy.ObjectType != 0x6396 || enemy.ObjectType != 0x6397 || enemy.ObjectType != 0x6398 || enemy.ObjectType != 0x6399)
                        {
                            Owner.BroadcastPacket(new ShowEffect()
                            {
                                EffectType = EffectType.Trail,
                                Color = new ARGB(effColor),
                                TargetObjectId = Id,
                                Pos1 = new Position { X = enemy.X, Y = enemy.Y }
                            }, null, PacketPriority.Low);
                        }
                }
                reqTime = 500;
            };
            reqTime -= time.ElapsedMsDelta;
            base.Tick(time);
        }
    }
}