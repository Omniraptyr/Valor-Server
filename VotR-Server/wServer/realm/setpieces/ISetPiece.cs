using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
    interface ISetPiece
    {
        int Size { get; }
        void RenderSetPiece(World world, IntPoint pos);
    }
}
