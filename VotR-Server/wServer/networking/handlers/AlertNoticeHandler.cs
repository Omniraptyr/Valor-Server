using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
using wServer.realm.worlds;
using System;
namespace wServer.networking.handlers
{
    internal class AlertNoticehandler : PacketHandlerBase<AlertNotice>
    {
        public override PacketId ID => PacketId.ALERTNOTICE;
        private static readonly string[] AlertAreas = { "KrakenLair", "TheHollows", "HiddenTempleBoss", "FrozenIsland" };

        protected override void HandlePacket(Client client, AlertNotice packet) {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet));
        }

        private static void Handle(Player player, RealmTime time, AlertNotice packet) {
            var cli = player.Client;
            if (cli.Account.RaidToken >= 1) {
                if (cli.Account.Credits >= 1000) {
                    var rnd = new Random();

                    cli.Manager.Database.UpdateAlertToken(cli.Account, -1);
                    player.AlertToken--;
                    player.ForceUpdate(player.AlertToken);

                    player.SendHelp("Launching alert... Good luck!");
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
                } else {
                    player.SendError("You do not have the required amount of gold in order to launch an alert.");
                }
            } else {
                player.SendError("You do not have an alert to launch.");
            }
        }
    }
}
