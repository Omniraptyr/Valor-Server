using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
using wServer.realm.worlds;
using wServer.realm.worlds.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using wServer.networking.packets.outgoing;
using common.resources;
namespace wServer.networking.handlers
{
    class AlertNoticehandler : PacketHandlerBase<AlertNotice>
    {
        public override PacketId ID => PacketId.ALERTNOTICE;

        protected override void HandlePacket(Client client, AlertNotice packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet));
        }

        void Handle(Player player, RealmTime time, AlertNotice packet)
        {

            var plr = player.Client.Player;
            var acnt = player.Client.Account;


            if (player.Client.Account.RaidToken == 1)
            {
                if(player.Client.Account.Credits >= 1000)
                {
                    Random rnd = new Random();
                    int drop3 = rnd.Next(1, 5);

                    player.Client.Manager.Database.UpdateAlertToken(player.Client.Account, -1);

                    player.SendHelp("Launching alert...good luck!");
                    World world;
                    ProtoWorld choosin = player.Owner.Manager.Resources.Worlds["KrakenLair"];

                    switch (drop3)
                    {
                        case 1:
                            choosin = player.Owner.Manager.Resources.Worlds["TheHollows"];
                            break;
                        case 2:
                            choosin = player.Owner.Manager.Resources.Worlds["HiddenTempleBoss"];
                            break;
                        case 3:
                            choosin = player.Owner.Manager.Resources.Worlds["KrakenLair"];
                            break;
                        case 4:
                            choosin = player.Owner.Manager.Resources.Worlds["FrozenIsland"];
                            break;
                    }
         
                    if (choosin.id < 0)
                        world = player.Owner.Manager.GetWorld(choosin.id);
                    else
                    {
                        DynamicWorld.TryGetWorld(choosin, player.Client, out world);
                        world = player.Owner.Manager.AddWorld(world ?? new World(choosin));
                    }


                    player.Owner.Timers.Add(new WorldTimer(8000, (world_, t) =>
                    {
                        player.Client.Reconnect(new Reconnect()
                        {
                            Host = "",
                            Port = 2050,
                            GameId = world.Id,
                            Name = world.SBName,
                            IsFromArena = false
                        });

                    }));



                }
                else
                {
                    player.SendError("You do not have the amount of gold to enter an alert.");
                }
            }
            else
            {
                player.SendError("You do not have an alert to launch.");
            }
        }
    }
}
