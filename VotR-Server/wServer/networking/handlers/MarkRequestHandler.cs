using wServer.realm;
using wServer.realm.entities;
using wServer.networking.packets;
using wServer.networking.packets.incoming;

namespace wServer.networking.handlers
{
    internal class MarkRequestHandler : PacketHandlerBase<MarkRequest>
    {
        public override PacketId ID => PacketId.MARKREQUEST;

        protected override void HandlePacket(Client client, MarkRequest packet) {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet));
        }

        public void MarkUpdate(Player player, int markId, int buyAmount) {
            if (buyAmount != 15 || buyAmount != 40) {
                player.SendError("Inproper purchase cost.");
                return;
            }

            if (player.MarksEnabled) {
                if (player.Onrane >= buyAmount) {
                    player.Client.Manager.Database.UpdateOnrane(player.Client.Account, -buyAmount);
                    player.Onrane = player.Client.Account.Onrane - buyAmount;
                    player.ForceUpdate(player.Client.Account.Onrane);

                    switch (markId) {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            NodeSet(player, markId);
                            player.SendHelp("You have activated this mark/node!");
                            break;
                        case 12:
                            player.Mark = 1;
                            player.SendHelp("You have activated this mark/node!");
                            break;
                        case 13:
                            player.Mark = 2;
                            player.SendHelp("You have activated this mark/node!");
                            break;
                        case 14:
                            player.Mark = 3;
                            player.SendHelp("You have activated this mark/node!");
                            break;
                        case 15:
                            player.Mark = 4;
                            player.SendHelp("You have activated this mark/node!");
                            break;
                        case 16:
                            player.Mark = 5;
                            player.SendHelp("You have activated this mark/node!");
                            break;
                        case 17:
                            player.Mark = 6;
                            player.SendHelp("You have activated this mark/node!");
                            break;
                        case 18:
                            player.Mark = 12;
                            player.SendHelp("You have activated this mark/node!");
                            break;
                    }
                } else {
                    player.SendError("You do not have enough onrane.");
                }
            } else {
                player.SendError("You do not have marks enabled on this character!");
            }
        }
        public void NodeSet(Player player, int markId) {
            if (player.Node1 == 0) {
                player.Node1 = markId;
                player.SendError("The next node slot has been activated.");
            } else if (player.Node2 == 0) {
                player.Node2 = markId;
                player.SendError("The next node slot has been activated.");
            } else if (player.Node3 == 0) {
                player.Node3 = markId;
                player.SendError("The next node slot has been activated.");
            } else if (player.Node4 == 0) {
                player.Node4 = markId;
                player.SendError("The next node slot has been activated.");
            } else {
                player.SendError("All of your node slots are full!");
            }
        }

        private void Handle(Player player, RealmTime time, MarkRequest packet) {
            switch (packet.MarkId) {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    MarkUpdate(player, packet.MarkId, 40);
                    break;
            }
        }
    }
}
