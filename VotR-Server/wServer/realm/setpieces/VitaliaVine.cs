using common.resources;

using wServer.realm.worlds;



namespace wServer.realm.setpieces

{

    internal class VitaliaVine : ISetPiece

    {

        public int Size

        {

            get { return 5; }

        }



        private byte[,] SetPiece

        {

            get

            {

                return new byte[,]

                {

                    {1, 1, 1, 1, 1},

                    {1, 1, 1, 1, 1},

                    {1, 1, 1, 1, 1},

                    {1, 1, 1, 1, 1},

                    {1, 1, 1, 1, 1}

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

                        Entity vine = Entity.Resolve(world.Manager, "Vitalia Vine2");

                        vine.Move(pos.X + x + 0.5f, pos.Y + y + 0.5f);

                        world.EnterWorld(vine);

                    }

                }

            }

        }

    }

}