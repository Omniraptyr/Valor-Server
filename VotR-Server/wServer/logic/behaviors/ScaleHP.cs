using System;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.behaviors
{
    internal class ScaleHP : Behavior
    {
        private readonly int _amount;
        private int _cachedMaxHp = -1;
        private int _lastPlayerNum = -1;

        public ScaleHP(int amount) {
            //_amount = amount;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state) {
            /*var cool = (int?)state ?? -1;

            if (cool <= 0) {
                if (_lastPlayerNum == host.Owner.Players.Count) return;

                var playerNum = host.Owner.Players.Count - _lastPlayerNum;        
                var enemy = host as Enemy;
                var hpPerc = enemy.HP / enemy.MaximumHP;

                if (_cachedMaxHp == -1)
                    _cachedMaxHp = enemy.MaximumHP;

                enemy.MaximumHP = _cachedMaxHp + _amount * Math.Max(playerNum - 1, 0);
                enemy.HP = enemy.MaximumHP * hpPerc;

                enemy.HP = Math.Min(enemy.MaximumHP, enemy.HP);

                cool = 5000;
                _lastPlayerNum = playerNum;
            } else cool -= time.ElapsedMsDelta;

            state = cool;*/
        }
    }
}
