using System;

namespace wServer.realm.entities
{
    partial class Player
    {

       public void CheckEnemyProjectile(Projectile projectile)
        {
            if (projectile.GetPosition(90000).X >= X && projectile.GetPosition(90000).Y >= Y)
            {
                Console.WriteLine("Hmm?");
            }
        }
    }

}
