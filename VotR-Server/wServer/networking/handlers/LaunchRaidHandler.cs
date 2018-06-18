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
            if (player.Credits >= 6000)
            {
                player.Client.Manager.Database.UpdateCredit(player.Client.Account, -6000);
                player.Credits = player.Client.Account.Credits - 6000;
                player.ForceUpdate(player.Credits);

                var acc = player.Client.Account;
                if (player.Manager._isRaidLaunched == false)
                {
                    if (packet.Ultra == false)
                    {
                        if (player.startRaid1(player) == false)
                        {
                            var Manager = player.Manager;
                            player.Manager.Chat.RaidAnnounce("The Zol Awakening Raid has been launched!");
                            var gameData = Manager.Resources.GameData;

                            ushort objType;

                            Manager._isRaidLaunched = true;

                            if (!gameData.IdToObjectType.TryGetValue("Aldragine's Hideout Portal", out objType) ||
                                !gameData.Portals.ContainsKey(objType))
                                return;

                            var entity = Entity.Resolve(Manager, objType);
                            var timeoutTime = gameData.Portals[objType].Timeout;

                            entity.Move(8, 38);
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
                            player.SendError("You don't have the token for this Raid.");
                        }
                    }
                    else
                    {
                        player.SendError("The Ultra Zol Awakening raid is not yet implemented.");
                    }
                }
                else
                {
                    player.SendError("A raid has already been launched earlier.");
                }
            }
            else{
                player.SendError("You do not have at least 6000 gold to launch this raid.");
            }
        }
    }


}
    

