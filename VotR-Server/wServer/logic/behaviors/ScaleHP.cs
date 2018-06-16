using System;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.behaviors
{
    internal class ScaleHP : Behavior
    {
        //State storage: none

        private readonly int amount;
        private int cachedMaxHP;
        private int cool = 5000;

        public ScaleHP(int _amount) {
            amount = _amount;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state) {
            int cool = (int?)state ?? -1;

            if (cool <= 0) {
                if (cachedMaxHP == 0) cachedMaxHP = (host as Enemy).MaximumHP;
                 
                (host as Enemy).MaximumHP = cachedMaxHP + amount * Math.Max(host.Owner.Players.Count - 1, 0);
                (host as Enemy).HP += Math.Min((host as Enemy).MaximumHP, amount * Math.Max(host.Owner.Players.Count - 1, 0));
                cool = 5000;
            } else cool -= time.ElapsedMsDelta;

            state = cool;
        }
    }
}
