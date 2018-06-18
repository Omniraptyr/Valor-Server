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
        private int lastPlayerNum = -1;
        private int cool = 5000;

        public ScaleHP(int _amount) {
            amount = _amount;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state) {
            int cool = (int?)state ?? -1;

            if (cool <= 0) {
                int playerNum = host.Owner.Players.Count;
                if (lastPlayerNum == playerNum) return;

                if (cachedMaxHP == 0) cachedMaxHP = (host as Enemy).MaximumHP;

                (host as Enemy).MaximumHP = cachedMaxHP + amount * Math.Max(playerNum - 1, 0);

                if (lastPlayerNum == -1) 
                    (host as Enemy).HP += amount * Math.Max(playerNum - 1, 0);
                else 
                    (host as Enemy).HP += amount * Math.Max(playerNum - 1, 0) 
                        * ((host as Enemy).HP / (host as Enemy).MaximumHP);
             
                (host as Enemy).HP = Math.Min((host as Enemy).MaximumHP, (host as Enemy).HP);

                cool = 5000;
                lastPlayerNum = playerNum;
            } else cool -= time.ElapsedMsDelta;

            state = cool;
        }
    }
}
