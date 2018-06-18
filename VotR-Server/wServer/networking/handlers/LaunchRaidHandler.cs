using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
namespace wServer.networking.handlers
{
    class LaunchRaidHandler : PacketHandlerBase<LaunchRaid>
    {
        public override PacketId ID => PacketId.LAUNCH_RAID;

        protected override void HandlePacket(Client client, LaunchRaid packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet));
        }

        void Handle(Player player, RealmTime time, LaunchRaid packet)
        {
            
            var Manager = player.Manager;
            var gameData = Manager.Resources.GameData;
            
            

            var acc = player.Client.Account;
                if (player.Manager._isRaidLaunched == false)
                {
                    if (packet.Ultra == false)
                    {
                        if (player.startRaid1(player) == false)
                        {
                            if (player.Credits >= 6000)
                            {
                                player.Client.Manager.Database.UpdateCredit(player.Client.Account, -6000);
                                player.Credits = player.Client.Account.Credits - 6000;
                                player.ForceUpdate(player.Credits);
                                player.Manager.Chat.RaidAnnounce("The Zol Awakening Raid has been launched!");
                            ushort objType;
                            

                            Manager._isRaidLaunched = true;
                            
                            if (!gameData.IdToObjectType.TryGetValue("Aldragine's Hideout Portal", out objType) ||
                                    !gameData.Portals.ContainsKey(objType))
                                    return;
                            var timeoutTime = gameData.Portals[objType].Timeout;
                            var entity = Entity.Resolve(Manager, objType);
                                entity.Move(16, 64);
                                player.Owner.EnterWorld(entity);

                                (entity as Portal).PlayerOpened = true;
                                (entity as Portal).Opener = player.Name;

                                player.Owner.Timers.Add(new WorldTimer(timeoutTime * 1000, (world, t) => world.LeaveWorld(entity)));
                                player.Owner.Timers.Add(new WorldTimer(60000, (w, t) =>
                                {
                                    Manager._isRaidLaunched = false;
                                }));
                                player.Owner.BroadcastPacket(new Notification
                                {
                                    Color = new ARGB(0xFF00FF00),
                                    ObjectId = player.Id,
                                    Message = player.Name + " has launched the Zol Awakening Raid!"
                                }, null, PacketPriority.Low);
                            }
                        else
                        {
                            player.SendError("You need at least 6000 gold to launch this raid.");
                        }
                        }
                        else
                        {
                            player.SendError("You don't have the token for this Raid.");
                        }
                    }
                    else
                    {
                    if (player.startRaid1(player) == false)
                    {
                        if (player.Credits >= 7500)
                        {
                            player.Client.Manager.Database.UpdateCredit(player.Client.Account, -7500);
                            player.Credits = player.Client.Account.Credits - 7500;
                            player.ForceUpdate(player.Credits);
                            player.Manager.Chat.RaidAnnounce("The Ultra Zol Awakening Raid has been launched!");

                            Manager._isRaidLaunched = true;
                            ushort objType;
                            if (!gameData.IdToObjectType.TryGetValue("Ultra Aldragine's Hideout Portal", out objType) ||
                                !gameData.Portals.ContainsKey(objType))
                                return;
                            var entity = Entity.Resolve(Manager, objType);

                            entity.Move(8, 38);
                            player.Owner.EnterWorld(entity);

                            (entity as Portal).PlayerOpened = true;
                            (entity as Portal).Opener = player.Name;
                            var timeoutTime = gameData.Portals[objType].Timeout;
                            player.Owner.Timers.Add(new WorldTimer(timeoutTime * 1000, (world, t) => world.LeaveWorld(entity)));
                            player.Owner.Timers.Add(new WorldTimer(60000, (w, t) =>
                            {
                                Manager._isRaidLaunched = false;
                            }));
                            player.Owner.BroadcastPacket(new Notification
                            {
                                Color = new ARGB(0xFF00FF00),
                                ObjectId = player.Id,
                                Message = player.Name + " has launched the Ultra Zol Awakening Raid!"
                            }, null, PacketPriority.Low);
                        }
                        else
                        {
                            player.SendError("You need at least 7500 gold to launch the ultra version of this raid.");
                        }
                    }
                    else
                    {
                        player.SendError("You don't have the token for this Raid.");
                    }
                }
                }
                else
                {
                    player.SendError("A raid has already been launched earlier.");
                }
        }
    }


}
    

