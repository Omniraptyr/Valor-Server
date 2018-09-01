using wServer.realm.worlds;

namespace wServer.realm.setpieces
{
	internal class Yazanahar : ISetPiece
	{
		public int Size
		{
			get { return 5; }
		}

		public void RenderSetPiece(World world, IntPoint pos)
		{
			Entity yaz = Entity.Resolve(world.Manager, "Yazanahar");
			yaz.Move(pos.X + 2.5f, pos.Y + 2.5f);
			world.EnterWorld(yaz);
		}
	}
}