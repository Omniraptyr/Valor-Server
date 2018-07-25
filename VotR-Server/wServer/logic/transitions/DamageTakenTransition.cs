using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.transitions
{
    public class DamageTakenTransition : Transition
    {
        //State storage: none

        private int damage;
        private bool wipeProgress;

        public DamageTakenTransition(int damage, string targetState, bool wipeProgress = false)
            : base(targetState)
        {
            this.damage = damage;
            this.wipeProgress = wipeProgress;
        }

        protected override bool TickCore(Entity host, RealmTime time, ref object state)
        {
            int damageSoFar = 0;

            if(wipeProgress == true)
            {
                damageSoFar = 0;
            }

            foreach (var i in (host as Enemy).DamageCounter.GetPlayerData())
                damageSoFar += i.Item2;

            if (damageSoFar >= damage)
                return true;
            return false;
        }
    }
}