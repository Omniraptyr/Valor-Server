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
    class MarkRequestHandler : PacketHandlerBase<MarkRequest>
    {
        public override PacketId ID => PacketId.MARKREQUEST;

        protected override void HandlePacket(Client client, MarkRequest packet)
        {
            client.Manager.Logic.AddPendingAction(t => Handle(client.Player, t, packet));
        }

        public void MarkUpdate(Player player, int markId, int buyAmount)
        {
            if (player.MarksEnabled == false)
            {

                if (player.Onrane >= buyAmount)
                {
                    if(markId <= 11 && isNodeFull(player) == false)
                    {

                    
                        player.Client.Manager.Database.UpdateOnrane(player.Client.Account, -buyAmount);
                        player.Onrane = player.Client.Account.Onrane - buyAmount;
                        player.ForceUpdate(player.Client.Account.Onrane);

                        switch (markId)
                        {
                            case 1:
                                NodeSet(player, markId);
                                player.SendHelp("You have activated this mark/node!");
                                break;
                            case 2:
                                NodeSet(player, markId);
                                player.SendHelp("You have activated this mark/node!");
                                break;
                            case 3:
                                NodeSet(player, markId);
                                player.SendHelp("You have activated this mark/node!");
                                break;
                            case 4:
                                NodeSet(player, markId);
                                player.SendHelp("You have activated this mark/node!");
                                break;
                            case 5:
                                NodeSet(player, markId);
                                player.SendHelp("You have activated this mark/node!");
                                break;
                            case 6:
                                NodeSet(player, markId);
                                player.SendHelp("You have activated this mark/node!");
                                break;
                            case 7:
                                NodeSet(player, markId);
                                player.SendHelp("You have activated this mark/node!");
                                break;
                            case 8:
                                NodeSet(player, markId);
                                player.SendHelp("You have activated this mark/node!");
                                break;
                            case 9:
                                NodeSet(player, markId);
                                player.SendHelp("You have activated this mark/node!");
                                break;
                            case 10:
                                NodeSet(player, markId);
                                player.SendHelp("You have activated this mark/node!");
                                break;
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
                    }
                    else
                    {
                        player.SendError("Your node slots are full!");
                    }

                }
                else
                {
                    player.SendError("You do not have enough onrane or your node slots are full.");
                }
            }
            else
            {
                player.SendError("You do not have marks enabled on this character!");
            }
        }
        public void NodeSet(Player player, int markId)
        {
            if (player.Node1 == 0)
            {
                player.Node1 = markId;
                player.SendError("The next node slot has been activated.");
            }
            else if (player.Node2 == 0)
            {
                player.Node2 = markId;
                player.SendError("The next node slot has been activated.");
            }
            else if (player.Node3 == 0)
            {
                player.Node3 = markId;
                player.SendError("The next node slot has been activated.");
            }
            else if (player.Node4 == 0)
            {
                player.Node4 = markId;
                player.SendError("The next node slot has been activated.");
            }
            else
            {
                player.SendError("All of your node slots are full!");
            }

        }

        public bool isNodeFull(Player player)
        {
            if (player.Node1 == 0)
            {
                return false;
            }
            else if (player.Node2 == 0)
            {
                return false;
            }
            else if (player.Node3 == 0)
            {
                return false;
            }
            else if (player.Node4 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        void Handle(Player player, RealmTime time, MarkRequest packet)
        {

            switch (packet.MarkId)
            {
                case 1:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 2:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 3:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 4:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 5:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 6:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 7:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 8:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 9:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 10:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 11:
                    MarkUpdate(player, packet.MarkId, 15);
                    break;
                case 12:
                    MarkUpdate(player, packet.MarkId, 40);
                    break;
                case 13:
                    MarkUpdate(player, packet.MarkId, 40);
                    break;
                case 14:
                    MarkUpdate(player, packet.MarkId, 40);
                    break;
                case 15:
                    MarkUpdate(player, packet.MarkId, 40);
                    break;
                case 16:
                    MarkUpdate(player, packet.MarkId, 40);
                    break;
                case 17:
                    MarkUpdate(player, packet.MarkId, 40);
                    break;
                case 18:
                    MarkUpdate(player, packet.MarkId, 40);
                    break;
            }


        }
    }
}
