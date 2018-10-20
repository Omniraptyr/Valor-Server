using System.Linq;
using common.resources;
using wServer.networking.packets.outgoing;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.behaviors
{
    internal class TalismanAttack : Behavior
    {
        private readonly int _damage;
        private readonly int _duration;
        private readonly ConditionEffectIndex _effect;

        public TalismanAttack(int damage, ConditionEffectIndex effect, int duration = 0) {
            _damage = damage;
            _duration = duration;
            _effect = effect;
        }

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state) {
            state = 0;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state) {
            var cool = (int)state;
            if (cool <= 0) {
                var entities = host.GetNearestEntities(6);
                var en = entities.OfType<Enemy>().FirstOrDefault();

                if (en != null & en.ObjectDesc.Enemy) {
                    en.Owner.BroadcastPacket(new ShowEffect {
                        EffectType = EffectType.Trail,
                        TargetObjectId = host.Id,
                        Pos1 = new Position { X = en.X, Y = en.Y },
                        Color = new ARGB(0x3E3A78)
                    }, null);
                    en.Damage(host.GetPlayerOwner(), time, _damage, true);
                    en.ApplyConditionEffect(new ConditionEffect {
                        Effect = _effect,
                        DurationMS = _duration
                    });
                }
                cool = 600;
            } else
                cool -= time.ElapsedMsDelta;

            state = cool;
        }
    }
}