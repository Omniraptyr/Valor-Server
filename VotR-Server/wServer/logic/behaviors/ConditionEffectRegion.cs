using System;
using System.Linq;
using common.resources;
using wServer.realm;

namespace wServer.logic.behaviors
{
    class ConditionEffectRegion : Behavior
    {
        private readonly ConditionEffectIndex effect;
        private readonly int _range;
        private readonly int _duration;

        public ConditionEffectRegion(ConditionEffectIndex effect, int range = 2, int duration = -1)
        {
            _range = range;
            this.effect = effect;
            _duration = duration;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            if (host.Owner == null) return;

            if (host.HasConditionEffect(ConditionEffects.Paused)) 
                return;

            var hx = (int) host.X;
            var hy = (int) host.Y;

            var players = host.Owner.Players.Values
                .Where(p => Math.Abs(hx - (int) p.X) < _range && Math.Abs(hy - (int) p.Y) < _range);

            foreach (var player in players)
            {
                    player.ApplyConditionEffect(new ConditionEffect()
                    {
                        Effect = effect,
                        DurationMS = _duration
                    });
            }
        }
    }
}
