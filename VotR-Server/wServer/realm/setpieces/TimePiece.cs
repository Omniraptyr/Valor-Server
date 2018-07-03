using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class TimePiece : ISetPiece
    {
        public int Size { get { return 100; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["TimePiece"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
