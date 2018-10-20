using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
namespace wServer.networking.handlers
{
    internal class LaunchRaidHandler : PacketHandlerBase<LaunchRaid>
    {
        public override PacketId ID => PacketId.LAUNCH_RAID;
        private const int ZolId = 1;
        private const int TitanId = 2;

        protected override void HandlePacket(Client client, LaunchRaid packet) {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, packet));
        }

        public void LaunchRaid(Player player, bool ultra, int raidId) {
            var manager = player.Manager;
            var gameData = manager.Resources.GameData;
            string raidName, portalName;
            switch (raidId) {
                case ZolId:
                    raidName = "The Zol Awakening";
                    portalName = "Aldragine's Hideout Portal";
                    break;
                case TitanId:
                    raidName = "Calling of the Titan";
                    portalName = "Bastille of Drannol Portal";
                    break;
                default:
                    player.SendError("Invalid raid ID.");
                    return;
            }

            if (!player.TryUseItem(raidName + " (Token)")) {
                player.SendError("You need to have the respective token in your inventory in order to launch it.");
                return;
            }

            player.Manager.Chat.Announce($"A raid has been launched: '{raidName}" + (ultra ? " (Ultra)" : "") + "'");

            manager.RaidRecentlyLaunched = true;
            if (!gameData.IdToObjectType.TryGetValue((ultra ? "Ultra " : "") + portalName, out var objType) ||
                !gameData.Portals.ContainsKey(objType))
                return;
            var entity = Entity.Resolve(manager, objType);

            entity.Move(149.5f, 114.5f);
            player.Owner.EnterWorld(entity);
            ((Portal)entity).PlayerOpened = true;
            ((Portal)entity).Opener = player.Name;

            var timeoutTime = gameData.Portals[objType].Timeout;
            player.Owner.Timers.Add(new WorldTimer(timeoutTime * 1000, (world, t) => world.LeaveWorld(entity)));
            player.Owner.Timers.Add(new WorldTimer(60000, (w, t) => {
                manager.RaidRecentlyLaunched = false;
            }));

            player.Owner.BroadcastPacket(new Notification {
                Color = new ARGB(0xFF00FF00),
                ObjectId = player.Id,
                Message = player.Name + " has launched the " + (ultra ? "Ultra " : "") + raidName + " Raid!"
            }, null, PacketPriority.Low);

            player.Owner.Opener = player.Name;
        }

        private void Handle(Player player, LaunchRaid packet) {
            if (player.Manager.RaidRecentlyLaunched) {
                player.SendError("A raid has already been launched recently.");
                return;
            }

            if (player.Stars < 15) {
                player.SendError("You need 15 stars to launch a raid.");
                return;
            }

            LaunchRaid(player, packet.Ultra, packet.RaidId);
        }
    }
}