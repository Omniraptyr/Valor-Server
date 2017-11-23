using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class SorGiant : ISetPiece
    {
        public int Size { get { return 65; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["SorGiant"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
