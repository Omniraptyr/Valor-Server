using wServer.networking.packets;
using wServer.networking.packets.incoming;
using System;
using common.resources;

namespace wServer.networking.handlers
{
    internal class ForgeItemHandler : PacketHandlerBase<ForgeItem>
    {
        public override PacketId ID => PacketId.FORGEITEM;

        protected override void HandlePacket(Client client, ForgeItem packet) {
            Handle(client, packet);
        }

        private readonly ushort[] cosmicList = { 0x69cd, 0x47cb, 0x46d8, 0x542b, 0x42c5, 0x42c7, 0x54d9, 0x46d5, 0x64aa,
                0x48fa, 0x69d1, 0x69d4, 0x42fa, 0x69d6, 0x69dc, 0x1644, 0x69db, 0x42fc,
                0x46d7, 0x54b6, 0x53de, 0x48fd, 0x69da, 0x69e8, 0x169f, 0x47f5, 0x47f8,
                0x47f3, 0x52df, 0x5839, 0x69e3, 0x69e4, 0x1399, 0x49f6, 0x49e4, 0x45d3,
                0x69e1, 0x1571, 0x49b2, 0x69d8, 0x42f4, 0x42b7, 0x42f8, 0x46f2, 0x1483,
                0x511a, 0x43a2, 0x179c, 0x56b8, 0x56b9, 0x69e6, 0x45ef, 0x42f6, 0x69e9,
                0x1636, 0x47db, 0x521c, 0x69ec, 0x69de, 0x69ed, 0x45d1 };
        private readonly ushort[] furyList = { 0x1485, 0x1398 };
        private readonly ushort[] zolList = { };

        private void Handle(Client client, ForgeItem packet) {
            Random rnd = new Random();
            if (packet.SorSlot.ObjectType == 18918) {
                ushort ItemValue() {
                    switch (packet.ShardSlot.ObjectType) {
                        case 0x68fa:
                            return cosmicList[rnd.Next(cosmicList.Length)];
                        case 0x68fb:
                            return furyList[rnd.Next(furyList.Length)];
                        case 0x68fc:
                            client.Player.SendError("The Zol Corruption shard has not been implemented yet.");
                            return 0x0;
                        //return zolList[rnd.Next(zolList.Length)];
                        case 0x47c4:
                            return 0x47bd;
                        default:
                            client.Player.SendError("You can't forge anything with these items.");
                            return 0x0;
                    }
                }

                Item item = null;
                if (ItemValue() != 0x0) {
                    item = client.Player.Manager.Resources.GameData.Items[ItemValue()];
                }

                client.Player.SendError("You have forged the item \"" + item.DisplayId == "" ?
                                                                        item.ObjectId
                                                                        : item.DisplayId + "\"");
                client.Player.Inventory[packet.SorSlot.SlotId] = item;
                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
            }
        }
    }
}