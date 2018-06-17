using System;
using System.Linq;
using wServer.realm;
using wServer.realm.entities;
using common.resources;
namespace wServer.logic.behaviors
{
    class ReplaceTile : Behavior
    {
        private readonly string _objName;
        private readonly string _replacedObjName;
        private readonly int _range;

        public ReplaceTile(string objName, string replacedObjName, int range)
        {
            _objName = objName;
            _range = range;
            _replacedObjName = replacedObjName;
        }

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            //var objType = GetObjType(_objName);
            XmlData dat = host.Manager.Resources.GameData;
            var tileId = dat.IdToTileType[_objName];
            var replacedTileId = dat.IdToTileType[_replacedObjName];

            var map = host.Owner.Map;

            var w = map.Width;
            var h = map.Height;

            for (var y = 0; y < h; y++)
                for (var x = 0; x < w; x++)
                {
                    var tile = map[x, y];

                    if (tile.TileId != tileId || tile.TileId == replacedTileId)
                        continue;

                    var dx = Math.Abs(x - (int)host.X);
                    var dy = Math.Abs(y - (int)host.Y);

                    if (dx > _range || dy > _range)
                        continue;

                    if (tile.ObjDesc?.BlocksSight == true)
                    {
                        if (host.Owner.Blocking == 3)
                            Sight.UpdateRegion(map, x, y);

                        foreach (var plr in host.Owner.Players.Values
                            .Where(p => MathsUtils.DistSqr(p.X, p.Y, x, y) < Player.RadiusSqr))
                            plr.Sight.UpdateCount++;
                    }

                    tile.TileId = replacedTileId;
                    if (tile.ObjId == 0)
                        tile.ObjId = host.Owner.GetNextEntityId();
                    tile.UpdateCount++;
                    map[x, y] = tile;
                }
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state) { }
    }
}
