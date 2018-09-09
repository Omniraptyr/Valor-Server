using common.resources;
using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    internal class Gargoyle : ISetPiece
    {
        public int Size { get { return 35; } }

        public void RenderSetPiece(World world, IntPoint pos) {
            var proto = world.Manager.Resources.Worlds["Gargoyle"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}