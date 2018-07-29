using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common.resources;
using StackExchange.Redis;
using wServer.networking.packets;
using wServer.networking.packets.outgoing;
using wServer.networking.packets.outgoing.pets;
using wServer.realm.worlds;
using wServer.realm.worlds.logic;

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
