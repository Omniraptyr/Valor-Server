using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    internal class TestChicken : ISetPiece
    {
        public int Size
        {
            get { return 5; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            Entity egg = Entity.Resolve(world.Manager, "Test Egg");
            egg.Move(pos.X + 2.5f, pos.Y + 2.5f);
            world.EnterWorld(egg);
        }
    }
}