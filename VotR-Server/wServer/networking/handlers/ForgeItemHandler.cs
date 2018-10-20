using wServer.networking.packets;
using wServer.networking.packets.incoming;
using System;
using System.Linq;

namespace wServer.networking.handlers
{
    internal class ForgeItemHandler : PacketHandlerBase<ForgeItem>
    {
        public override PacketId ID => PacketId.FORGEITEM;

        protected override void HandlePacket(Client client, ForgeItem packet) {
            Handle(client, packet);
        }

        private const ushort
            Shine = 0x64c7,
            LSor = 0x49e6,
            CosmicShard = 0x68fa,
            FuryShard = 0x68fb,
            ZolShard = 0x68fc,
            StoneShard = 0x61b4,
            AncientShard = 0x611f,
            NecroSword = 0x47c4,
            Nemesis = 0x47bd,
            HunterNeck = 0x1628,
            PredNeck = 0x61b7,
            WarpedWorlds = 0x1463,
            Dreamweaver = 0x61c5,
            EmpWhip = 0x61d8,
            AbbyWhip = 0x61d7;

        private readonly ushort[] _cosmicList = { 0x69cd, 0x47cb, 0x46d8, 0x42c5, 0x42c7, 0x54d9, 0x46d5, 0x64aa,
                0x48fa, 0x69d1, 0x69d4, 0x42fa, 0x69d6, 0x69dc, 0x1644, 0x69db, 0x42fc,
                0x46d7, 0x54b6, 0x53de, 0x48fd, 0x69da, 0x69e8, 0x169f, 0x47f5, 0x47f8,
                0x47f3, 0x5839, 0x69e3, 0x69e4, 0x1399, 0x49e4, 0x45d3, 0x69e1, 0x1571,
                0x49b2, 0x69d8, 0x42f4, 0x42b7, 0x47be, 0x46f2, 0x1483, 0x511a, 0x179c,
                0x56b8, 0x56b9, 0x69e6, 0x45ef, 0x42f6, 0x69e9, 0x521c, 0x69ec, 0x69de,
                0x69ed, 0x45d1 };
        private readonly ushort[] _furyList = { 0x1485, 0x49f6, 0x1398, 0x61b6, 0x61cf, 0x45d1, 0x61d2,
                0x61d5, 0x61db, 0x61da, 0x52df, 0x63d1, 0x1633, 0x57b9, 0x69c4,
                0x69c3, 0x47ca, 0x61cd, 0x47d8 };
        private readonly ushort[] _zolList = { 0x585b, 0x49e3, 0x61b5, 0x5437, 0x42f8, 0x1688, 0x42f3,
                0x6202, 0x6163, 0x542b, 0x61dc };
        private readonly ushort[] _stoneList = { 0x61b2, 0x56c5, 0x56c4, 0x61d3 };
        private readonly ushort[] _ancientList = { 0x1636, 0x55f6, 0x6120, 0x69c9, 0x43a6, 0x69e5 };
        private readonly ushort[] _rerollExclude = { Shine, LSor, CosmicShard, FuryShard, ZolShard,
                StoneShard, AncientShard, Nemesis, Dreamweaver, PredNeck, AbbyWhip };

        private void Handle(Client client, ForgeItem packet) {
            var rnd = new Random();
            ushort itemValue = 0x0;

            if (client.Player.Inventory[packet.SorSlot.SlotId].ObjectType != packet.SorSlot.ObjectType
                || client.Player.Inventory[packet.ShardSlot.SlotId].ObjectType != packet.ShardSlot.ObjectType)
                return;

            switch (packet.SorSlot.ObjectType) {
                case LSor: {
                        switch (packet.ShardSlot.ObjectType) {
                            case CosmicShard:
                                itemValue = _cosmicList[rnd.Next(_cosmicList.Length)];
                                break;
                            case FuryShard:
                                itemValue = _furyList[rnd.Next(_furyList.Length)];
                                break;
                            case ZolShard:
                                itemValue = _zolList[rnd.Next(_zolList.Length)];
                                break;
                            case StoneShard:
                                itemValue = _stoneList[rnd.Next(_stoneList.Length)];
                                break;
                            case AncientShard:
                                itemValue = _ancientList[rnd.Next(_ancientList.Length)];
                                break;
                            case NecroSword:
                                itemValue = Nemesis;
                                break;
                            case HunterNeck:
                                itemValue = PredNeck;
                                break;
                            case WarpedWorlds:
                                itemValue = Dreamweaver;
                                break;
                            case EmpWhip:
                                itemValue = AbbyWhip;
                                break;
                            default:
                                client.Player.SendError("You can not forge anything with these items.");
                                itemValue = 0x0;
                                break;
                        }

                        if (itemValue == 0x0) return;
                        var item = client.Player.Manager.Resources.GameData.Items[itemValue];
                        var itemStr = string.IsNullOrEmpty(item.DisplayId)
                            ? item.ObjectId
                            : item.DisplayId;

                        client.Player.SendError("You have forged an item: '" + itemStr + "'");
                        client.Player.Inventory[packet.SorSlot.SlotId] = item;
                        client.Player.Inventory[packet.ShardSlot.SlotId] = null;

                        var guildId = client.Account.GuildId;
                        if (guildId > 0) {
                            foreach (var w in client.Manager.Worlds.Values) {
                                foreach (var p in w.Players.Values) {
                                    if (p.Client.Account.GuildId == guildId && p != client.Player) {
                                        p.SendGuildAnnounce("<" + client.Player.Name + "> has forged an item: '"
                                                                                        + itemStr + "'");
                                    }
                                }
                            }

                            foreach (var i in client.Player.Owner.Players.Values) {
                                if (i.Client.Account.GuildId != guildId) {
                                    i.SendInfo("<" + client.Player.Name + "> has forged an item: '" + itemStr + "'");
                                }
                            }
                        }
                        break;
                    }

                case Shine: {
                        var allLegendaries = _cosmicList
                                             .Concat(_furyList)
                                             .Concat(_zolList)
                                             .Concat(_stoneList)
                                             .Concat(_ancientList)
                                             .ToArray();
                        if (client.Manager.Resources.GameData.Items[(ushort)packet.ShardSlot.ObjectType].Legendary
                            && !_rerollExclude.Contains((ushort)packet.ShardSlot.ObjectType)) {
                            if (client.Account.Elite != 1) {
                                if (client.Player.Credits >= 75000) {
                                    client.Player.Manager.Database.UpdateCredit(client.Account, -75000);
                                    client.Player.Credits -= -75000;
                                    client.Player.ForceUpdate(client.Player.Credits);

                                    itemValue = allLegendaries[rnd.Next(allLegendaries.Length)];
                                } else {
                                    client.Player.SendError("You need 75k Gold in order to reroll with a Shine.");
                                }
                            } else {
                                if (client.Player.Onrane >= 30) {
                                    client.Player.Manager.Database.UpdateOnrane(client.Account, -30);
                                    client.Player.Onrane -= 30;
                                    client.Player.ForceUpdate(client.Player.Onrane);

                                    itemValue = allLegendaries[rnd.Next(allLegendaries.Length)];
                                } else {
                                    client.Player.SendError("You need 30 Onrane in order to reroll with a Shine.");
                                }
                            }
                        }

                        if (itemValue == 0x0) return;
                        var item = client.Player.Manager.Resources.GameData.Items[itemValue];
                        var itemStr = string.IsNullOrEmpty(item.DisplayId)
                            ? item.ObjectId
                            : item.DisplayId;

                        client.Player.SendError("You have rerolled into the item '" + itemStr + "'");
                        client.Player.Inventory[packet.SorSlot.SlotId] = item;
                        client.Player.Inventory[packet.ShardSlot.SlotId] = null;

                        var guildId = client.Account.GuildId;
                        if (guildId > 0) {
                            foreach (var w in client.Manager.Worlds.Values) {
                                foreach (var p in w.Players.Values) {
                                    if (p.Client.Account.GuildId == guildId && p != client.Player) {
                                        p.SendGuildAnnounce("<" + client.Player.Name + "> has rerolled into an item: '"
                                                            + itemStr + "'");
                                    }
                                }
                            }

                            foreach (var i in client.Player.Owner.Players.Values) {
                                if (i.Client.Account.GuildId != guildId) {
                                    i.SendInfo("<" + client.Player.Name + "> has rerolled into an item: '"
                                               + itemStr + "'");
                                }
                            }
                        }
                        break;
                    }

                default:
                    switch (packet.SorSlot.ObjectType * packet.ShardSlot.ObjectType) {
                        //greaters
                        case 0xae9 * 0xae9: itemValue = 0x236E; break; //life
                        case 0xaea * 0xaea: itemValue = 0x236F; break; //mana
                        case 0xa1f * 0xa1f: itemValue = 0x2368; break; //atk
                        case 0xa20 * 0xa20: itemValue = 0x2369; break; //def
                        case 0xa21 * 0xa21: itemValue = 0x236A; break; //spd
                        case 0xa34 * 0xa34: itemValue = 0x236B; break; //vit
                        case 0xa35 * 0xa35: itemValue = 0x236C; break; //wis
                        case 0xa4c * 0xa4c: itemValue = 0x236D; break; //dex
                        case 0x5822 * 0x5822: itemValue = 0x61C9; break; //mgt
                        case 0x5823 * 0x5823: itemValue = 0x61cb; break; //luc
                        case 0x68fd * 0x68fd: itemValue = 0x61ca; break; //res
                        case 0x68fe * 0x68fe: itemValue = 0x61cc; break; //prot
                        default:
                            if (client.Player.Onrane >= 1) {
                                //vials
                                switch (packet.SorSlot.ObjectType * packet.ShardSlot.ObjectType) {
                                    case 0x236E * 0x236E: itemValue = 0x62a5; break; //life
                                    case 0x236F * 0x236F: itemValue = 0x619c; break; //mana
                                    case 0x2368 * 0x2368: itemValue = 0x619f; break; //atk
                                    case 0x2369 * 0x2369: itemValue = 0x62a3; break; //def
                                    case 0x236A * 0x236A: itemValue = 0x62a1; break; //spd
                                    case 0x236B * 0x236B: itemValue = 0x62a0; break; //vit
                                    case 0x236C * 0x236C: itemValue = 0x619e; break; //wis
                                    case 0x236D * 0x236D: itemValue = 0x62a4; break; //dex
                                    case 0x61C9 * 0x61C9: itemValue = 0x62a6; break; //mgt
                                    case 0x61CB * 0x61CB: itemValue = 0x62a7; break; //luc
                                    case 0x61CA * 0x61CA: itemValue = 0x619d; break; //res
                                    case 0x61CC * 0x61CC: itemValue = 0x62a2; break; //prot
                                    default: itemValue = 0x0; break;
                                }

                                client.Player.Manager.Database.UpdateOnrane(client.Account, -1);
                                client.Player.Onrane -= 1;
                                client.Player.ForceUpdate(client.Player.Onrane);
                            } else itemValue = 0x0;
                            break;
                    }

                    if (itemValue == 0x0) return;

                    var miscItem = client.Player.Manager.Resources.GameData.Items[itemValue];
                    client.Player.Inventory[packet.SorSlot.SlotId] = miscItem;
                    client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                    break;
            }
        }
    }
}