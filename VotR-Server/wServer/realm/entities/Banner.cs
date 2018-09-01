#region

using common.resources;
using System.Collections.Generic;
using wServer.networking.packets;
using wServer.networking.packets.outgoing;

#endregion

namespace wServer.realm.entities
{
    class Banner : StaticObject
    {
        private readonly float radius;
        private int lifetime;
        private readonly int duration;
        private int p;
        private int p2;
        private Player player;
        private int t;

        public Banner(Player player, float radius, int lifetime, int duration)
            : base(player.Manager, 0x0711, lifetime * 1000, true, true, false)
        {
            this.player = player;
            this.radius = radius;
            this.lifetime = lifetime;
            this.duration = duration;
        }

        public override void Tick(RealmTime time)
        {
            if (t / 500 == p2)
            {
                Owner.BroadcastPacket(new ShowEffect()
                {
                    EffectType = EffectType.Trap,
                    Color = new ARGB(0x0000ff),
                    TargetObjectId = Id,
                    Pos1 = new Position { X = radius }
                }, null);
                p2++;
                //Stuff
            }
            if (t / 2000 == p)
            {
                List<Packet> pkts = new List<Packet>();
                List<Player> players = new List<Player>();
                this.AOE(radius, true, player =>
                {
                    players.Add(player as Player);
                    player.ApplyConditionEffect(new ConditionEffect
                    {
                        Effect = ConditionEffectIndex.Empowered,
                        DurationMS = duration
                    });
                });

                Owner.BroadcastPackets(pkts, null);
                p++;
            }
            t += time.ElapsedMsDelta;
            base.Tick(time);
        }
    }
}