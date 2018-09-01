using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    internal class Phantom : ISetPiece
    {
        public int Size
        {
            get { return 5; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            Entity phantom = Entity.Resolve(world.Manager, "Elemental Phantom");
            phantom.Move(pos.X + 2.5f, pos.Y + 2.5f);
            world.EnterWorld(phantom);
        }
    }
}