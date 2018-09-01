using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    internal class Cheesehead : ISetPiece
    {
        public int Size
        {
            get { return 5; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            Entity cheese = Entity.Resolve(world.Manager, "The Cheesehead");
            cheese.Move(pos.X + 2.5f, pos.Y + 2.5f);
            world.EnterWorld(cheese);
        }
    }
}