using System.Linq;
using wServer.networking.packets;
using wServer.networking.packets.incoming;
using wServer.networking.packets.outgoing;
using wServer.networking.packets.outgoing.pets;
using wServer.realm.entities;
using System;
namespace wServer.networking.handlers
{
    internal class ForgeItemHandler : PacketHandlerBase<ForgeItem>
    {
        public override PacketId ID => PacketId.FORGEITEM;

        protected override void HandlePacket(Client client, ForgeItem packet)
        {
            Handle(client, packet);
        }

        private void Handle(Client client, ForgeItem packet)
        {
            Random rnd = new Random();
            int drop = rnd.Next(1, 3);
            try
            {
                if (packet.SorSlot.ObjectType == 18918)
                {
                    if (packet.ShardSlot.ObjectType == 0x68fa)
                    {
                        switch (drop)
                        {
                            case 1:
                                client.Player.SendError("You have forged the Insurgency Amulet!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69cd];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 2:
                                client.Player.SendError("You have forged the Amulet of Resurrection!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x47cb];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                    }

                    }
                    else
                    {
                        client.Player.SendError("You do not have the materials to forge a legendary.");
                    }
                }
            }
            catch (Exception e)
            {
                client.Player.SendError("Error!");
                Console.WriteLine("{0} Exception caught.", e);
            }



        }
        
    }
}