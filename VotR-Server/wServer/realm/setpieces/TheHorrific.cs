using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    class TheHorrific : ISetPiece
    {
        public int Size { get { return 65; } }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            var proto = world.Manager.Resources.Worlds["TheHorrific"];
            SetPieces.RenderFromProto(world, pos, proto);
        }
    }
}
