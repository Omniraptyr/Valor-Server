using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets.outgoing;

namespace wServer.logic.behaviors
{
    public class EnemyAOE : Behavior
    {
        //State storage: nothing

        private readonly float radius;
        private readonly bool players;
        private readonly int minDamage;
        private readonly int maxDamage;
        private readonly bool noDef;
        private readonly ARGB color;

        public EnemyAOE(double radius, bool players, int minDamage, int maxDamage, bool noDef, uint color)
        {
            this.radius = (float)radius;
            this.players = players;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.noDef = noDef;
            this.color = new ARGB(color);
        }

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            var pos = new Position
            {
                X = host.X,
                Y = host.Y
            };

            var damage = Random.Next(minDamage, maxDamage);

            host.Owner.AOE(pos, radius, players, enemy =>
            {
                if (!players)
                {
                    host.Owner.BroadcastPacketNearby(new Aoe()
                    {
                        Pos = pos,
                        Radius = radius,
                        Damage = (ushort)damage,
                        Duration = 0,
                        Effect = 0,
                        OrigType = host.ObjectType
                    }, host, null, PacketPriority.Low);
                    host.Owner.AOE(pos, radius, true, p =>
                    {
                        (p as IPlayer).Damage(damage, host);
                    });
                }
                else
                {
                }
            });
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
        }
    }
}