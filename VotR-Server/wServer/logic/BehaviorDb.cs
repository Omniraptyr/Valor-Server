using common.resources;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using wServer.logic.loot;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic
{
    public partial class BehaviorDb
    {

        public RealmManager Manager { get; }

        private static int _initializing;
        internal static BehaviorDb InitDb;
        internal static XmlData InitGameData => InitDb.Manager.Resources.GameData;

        public BehaviorDb(RealmManager manager) {
            Manager = manager;

            Definitions = new Dictionary<ushort, Tuple<State, Loot>>();

            if (Interlocked.Exchange(ref _initializing, 1) == 1) {
                throw new InvalidOperationException("Attempted to initialize multiple BehaviorDb at the same time.");
            }
            InitDb = this;

            var fields = GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(field => field.FieldType == typeof(_))
                .ToArray();
            for (var i = 0; i < fields.Length; i++) {
                var field = fields[i];
                ((_)field.GetValue(this))();
                field.SetValue(this, null);
            }

            InitDb = null;
            _initializing = 0;
        }

        public void ResolveBehavior(Entity entity) {
            if (Definitions.TryGetValue(entity.ObjectType, out var def))
                entity.SwitchTo(def.Item1);
        }

        private delegate ctor _();

        private struct ctor
        {
            public ctor Init(string objType, State rootState, params ILootDef[] defs) {
                var d = new Dictionary<string, State>();
                rootState.Resolve(d);
                rootState.ResolveChildren(d);
                var dat = InitDb.Manager.Resources.GameData;
                if (defs.Length > 0) {
                    var loot = new Loot(defs);
                    rootState.Death += (sender, e) => loot.Handle((Enemy)e.Host, e.Time);
                    if (dat.IdToObjectType.ContainsKey(objType))
                        InitDb.Definitions.Add(dat.IdToObjectType[objType], new Tuple<State, Loot>(rootState, loot));
                } else {
                    if (dat.IdToObjectType.ContainsKey(objType))
                        InitDb.Definitions.Add(dat.IdToObjectType[objType], new Tuple<State, Loot>(rootState, null));
                }
                return this;
            }
        }

        private static ctor Behav() {
            return new ctor();
        }

        public Dictionary<ushort, Tuple<State, Loot>> Definitions { get; }
    }
}