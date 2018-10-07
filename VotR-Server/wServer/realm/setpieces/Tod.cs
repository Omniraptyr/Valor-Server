using common.resources;
using wServer.realm.worlds;
using System;

namespace wServer.realm.setpieces
{
    internal class Tod : ISetPiece
    {
        private static readonly string[] Ground = { "Tod Floor", "Tod Brick" };
        private static readonly string[] Trap = { "TLava Spawner" };

        private readonly Random rand = new Random();

        private static byte[,] SetPiece //[Y, X]
        {
            get
            {
                return new byte[,]
                {
                    {1, 1, 1, 5, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 ,5, 1, 1, 1},
                    {1, 3, 5, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 3, 1},
                    {1, 5, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 1},
                    {1, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1},
                    {1, 5, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 4, 0, 0, 1, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 0, 0, 4, 1},
                    {1, 5, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 4, 1},
                    {1, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1},
                    {1, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 1},
                    {1, 3, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 3, 1},
                    {1, 1, 1, 4, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 1, 1, 1}
                };
            }
        }

        public int Size
        {
            get { return 27; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            XmlData dat = world.Manager.Resources.GameData;
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (SetPiece[y, x] == 0)
                    {
                        var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.TileId = dat.IdToTileType[Ground[0]];
                        world.Map[x + pos.X, y + pos.Y] = tile;
                    }

                    else if (SetPiece[y, x] == 1)
                    {
                        var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.TileId = dat.IdToTileType[Ground[1]];
                        world.Map[x + pos.X, y + pos.Y] = tile;
                    }
                    else if (SetPiece[y, x] == 2)
                    {
                        var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.TileId = dat.IdToTileType[Ground[0]];
                        tile.ObjType = 0;
                        world.Map[x + pos.X, y + pos.Y] = tile;

                        Entity tlava = Entity.Resolve(world.Manager, "TLava Spawner");
                        tlava.Move(pos.X + x + 0.5f, pos.Y + y + 0.5f);
                        world.EnterWorld(tlava);
                    }
                    else if (SetPiece[y, x] == 3)
                    {
                        var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.TileId = dat.IdToTileType[Ground[1]];
                        tile.ObjType = 0;
                        world.Map[x + pos.X, y + pos.Y] = tile;

                        Entity tlava = Entity.Resolve(world.Manager, "TLava Spawner");
                        tlava.Move(pos.X + x + 0.5f, pos.Y + y + 0.5f);
                        world.EnterWorld(tlava);
                    }
                    else if (SetPiece[y, x] == 4)
                    {
                        var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.TileId = dat.IdToTileType[Ground[0]];
                        tile.ObjType = 0;
                        world.Map[x + pos.X, y + pos.Y] = tile;

                        Entity TodSpike = Entity.Resolve(world.Manager, "Tod Spike");
                        TodSpike.Move(pos.X + x + 0.5f, pos.Y + y + 0.5f);
                        world.EnterWorld(TodSpike);

                    }
                    else if (SetPiece[y, x] == 5)
                    {
                        var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.TileId = dat.IdToTileType[Ground[1]];
                        tile.ObjType = 0;
                        world.Map[x + pos.X, y + pos.Y] = tile;

                        Entity TodSpike = Entity.Resolve(world.Manager, "Tod Spike");
                        TodSpike.Move(pos.X + x + 0.5f, pos.Y + y + 0.5f);
                        world.EnterWorld(TodSpike);

                    }
                    else if (SetPiece[y, x] == 9)
                    {
                        var tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.TileId = dat.IdToTileType[Ground[0]];
                        tile.ObjType = 0;
                        world.Map[x + pos.X, y + pos.Y] = tile;

                        Entity Tod = Entity.Resolve(world.Manager, "Tod");
                        Tod.Move(pos.X + x + 0.5f, pos.Y + y + 0.5f);
                        world.EnterWorld(Tod);
                    }

                }
            }
        }
    }
}