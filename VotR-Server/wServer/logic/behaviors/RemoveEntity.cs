using System.Linq;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.behaviors
{
    public class RemoveEntity : Behavior
    {
        private readonly float dist;
        private readonly string children;

        public RemoveEntity(double dist, string children)
        {
            this.dist = (float)dist;
            this.children = children;
        }

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            Entity[] ens = host.GetNearestEntities(dist, null).ToArray();
            foreach (Entity e in ens)
                if (e.ObjectType == host.Manager.Resources.GameData.IdToObjectType[children])
                    host.Owner.LeaveWorld(e);
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
        }
    }
}