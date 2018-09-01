using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    internal class LuckyEnt : ISetPiece
    {
        public int Size
        {
            get { return 5; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            Entity ent = Entity.Resolve(world.Manager, "Lucky Ent God");
            ent.Move(pos.X + 2.5f, pos.Y + 2.5f);
            world.EnterWorld(ent);
        }
    }
}