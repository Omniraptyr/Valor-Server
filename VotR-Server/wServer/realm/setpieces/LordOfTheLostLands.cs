using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    internal class LordOfTheLostLands : ISetPiece
    {
        public int Size
        {
            get { return 5; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            Entity lord = Entity.Resolve(world.Manager, "Lord of the Lost Lands");
            lord.Move(pos.X + 2.5f, pos.Y + 2.5f);
            world.EnterWorld(lord);
        }
    }
}