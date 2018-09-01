using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    internal class Crystal : ISetPiece
    {
        public int Size
        {
            get { return 5; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            Entity c = Entity.Resolve(world.Manager, "Mysterious Crystal");
            c.Move(pos.X + 20.5f, pos.Y + 20.5f);
            world.EnterWorld(c);
        }
    }
}