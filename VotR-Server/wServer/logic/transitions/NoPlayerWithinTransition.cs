using wServer.realm;

namespace wServer.logic.transitions
{
    class NoPlayerWithinTransition : Transition
    {
        //State storage: none

        double dist;

        public NoPlayerWithinTransition(double dist, string targetState)
            : base(targetState)
        {
            this.dist = dist;
        }

        protected override bool TickCore(Entity host, RealmTime time, ref object state)
        {
            return host.GetNearestEntity(dist, null) == null;
        }
    }
}
