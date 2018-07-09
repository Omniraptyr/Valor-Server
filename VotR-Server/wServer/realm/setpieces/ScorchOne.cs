using common.resources;
using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    internal class ScorchOne : ISetPiece
    {
        public int Size
        {
            get { return 1; }
        }

        private byte[,] SetPiece
        {
            get
            {
                return new byte[,]
                {
                    {1},
                };
            }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            XmlData dat = world.Manager.Resources.GameData;

            IntPoint p = new IntPoint
            {
                X = pos.X - (Size / 2),
                Y = pos.Y - (Size / 2)
            };

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (SetPiece[y, x] == 1)
                    {
                        var tile = world.Map[x + p.X, y + p.Y].Clone();
                        tile.TileId = dat.IdToTileType["Scorch"];
                        tile.ObjType = 0;
                        world.Map[x + p.X, y + p.Y] = tile;
                    }
                }
            }
        }
    }
}