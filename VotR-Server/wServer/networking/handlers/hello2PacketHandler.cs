using System.Linq;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.realm;
using wServer.realm.entities;
using common.resources;
using System;
namespace wServer.networking.handlers
{
    class Hello2PacketHandler : PacketHandlerBase<Hello2Packet>
    {
        public override PacketId ID => PacketId.HELLO2PACKET;


        protected override void HandlePacket(Client client, Hello2Packet packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client, t, packet.ObjectId, packet.BulletId));
        }

        private void Handle(Client client, RealmTime time, int objectId, byte bulletId)
        {
            Player player = client.Player;
            var db = client.Player.Owner.Manager.Database;

            if (player?.Owner == null)
                return;

                var entity = player.Owner.GetEntity(objectId);

                player.verifyDamage1 = ((IProjectileOwner)entity).Projectiles[bulletId].Damage;
                if(player.verifyDamage1 != player.verifyDamage2)
                {
                    if(player.Striked == false)
                    {
                        player.Client.Account.Striked = true;
                        player.Client.Disconnect();
                    }
                    else
                    {
                    foreach (var w in player.Manager.Worlds.Values)
                        foreach (var p in w.Players.Values)
                            p.SendHelp(player.Name + " has been exiled.");

                    // ban
                    db.Ban(player.Client.Account.AccountId, "godmoding");
                    db.BanIp(player.Client.Account.IP, "godmoding");
                    
                    player.Client.Disconnect();
                    }

                }
                var prj = entity != null ?
                    ((IProjectileOwner)entity).Projectiles[bulletId] :
                    player.Owner.Projectiles
                        .Where(p => p.Value.ProjectileOwner.Self.Id == objectId)
                        .SingleOrDefault(p => p.Value.ProjectileId == bulletId).Value;

             
            }

        }
}