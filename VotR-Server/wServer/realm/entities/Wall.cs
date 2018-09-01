using System.Xml.Linq;

namespace wServer.realm.entities
{
    public class Wall : StaticObject
    {
        public Wall(RealmManager manager, ushort objType, XElement node)
            : base(manager, objType, GetHP(node), true, false, true)
        {
        }
    }
}