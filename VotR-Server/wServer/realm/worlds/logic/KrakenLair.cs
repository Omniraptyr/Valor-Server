using System.Linq;
using common.resources;
using wServer.networking;

namespace wServer.realm.worlds.logic
{
    class KrakenLair : World
    {
        private Entity _tileControl;

        public KrakenLair(ProtoWorld proto, Client client = null) : base(proto) {
        }

        protected override void Init() {
            base.Init();

            if (IsLimbo) return;
            _tileControl = Enemies.Values.SingleOrDefault(e => e.ObjectType == 0x6171);

            if (_tileControl != null)
                _tileControl.TickStateManually = true;
        }

        public override void Tick(RealmTime time) {
            base.Tick(time);

            if (IsLimbo || Deleted || _tileControl == null)
                return;

            _tileControl.TickState(time);
        }
    }
}
