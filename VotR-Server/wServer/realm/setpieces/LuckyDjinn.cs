using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    internal class LuckyDjinn : ISetPiece
    {
        public int Size
        {
            get { return 5; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            Entity djinn = Entity.Resolve(world.Manager, "Lucky Djinn");
            djinn.Move(pos.X + 2.5f, pos.Y + 2.5f);
            world.EnterWorld(djinn);
        }
    }
}