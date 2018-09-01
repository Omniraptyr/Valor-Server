using wServer.realm;

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
