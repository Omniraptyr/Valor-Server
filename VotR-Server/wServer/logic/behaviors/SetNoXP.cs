using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.behaviors
{
    class SetNoXP : Behavior
    {
        //State storage: timer

        public SetNoXP()
        {
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            host.GivesNoXp = true;
        }
    }
}
