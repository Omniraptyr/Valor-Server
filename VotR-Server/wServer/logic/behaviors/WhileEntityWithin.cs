using wServer.realm;

namespace wServer.logic.behaviors
{
    class WhileEntityWithin : Behavior
    {

        Behavior child;
        string entityName;
        double range;
        public WhileEntityWithin(Behavior child, string entityName, double range)
        {
            this.child = child;
            this.entityName = entityName;
            this.range = range;
        }

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
             child.OnStateEntry(host, time);
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            if(host.GetNearestEntityByName(range, entityName) != null)
               child.Tick(host, time);
        }
    }
}
