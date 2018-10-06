using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
using wServer.realm.worlds;
using System;
using Player = wServer.realm.entities.Player;

namespace wServer.networking.handlers
{
    internal class AlertNoticeHandler : PacketHandlerBase<AlertNotice>
    {
        public override PacketId ID => PacketId.ALERTNOTICE;
        private static readonly string[] AlertAreas 
            = { "KrakenLair", "TheHollows", "HiddenTempleBoss", "FrozenIsland" };

        protected override void HandlePacket(Client client, AlertNotice packet) {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player));
        }

        private static void Handle(Player player) {
            var cli = player.Client;
            if (cli.Account.RaidToken < 1) {
                player.SendError("You do not have an Alert to launch.");
                return;
            }

            if (cli.Account.Credits < 1000) {
                player.SendError("You do not have the required amount of gold to launch an Alert.");
                return;
            }

            var rnd = new Random();

            cli.Manager.Database.UpdateAlertToken(cli.Account, -1);
            player.AlertToken--;
            player.ForceUpdate(player.AlertToken);

            player.SendHelp("Launching Alert... Good luck!");
            var alertArea = player.Owner.Manager.Resources.Worlds[AlertAreas[rnd.Next(AlertAreas.Length)]];

            DynamicWorld.TryGetWorld(alertArea, player.Client, out var world);
            world = player.Owner.Manager.AddWorld(world ?? new World(alertArea));

            player.Owner.Timers.Add(new WorldTimer(8000, (w, t) => {
                player.Client.Reconnect(new Reconnect {
                    Host = "",
                    Port = 2050,
                    GameId = world.Id,
                    Name = world.SBName,
                    IsFromArena = false
                });
            }));
        }
    }
}
