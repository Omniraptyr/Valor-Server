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
            int drop = rnd.Next(1, 61);
            int drop2 = rnd.Next(1, 3);
            try
            {
                if (packet.SorSlot.ObjectType == 18918)
                {
                    if (packet.ShardSlot.ObjectType == 0x68fa)
                    {
                        //This looks terribly ugly so Im changing to the Lootbox system for Sors later
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
                            case 3:
                                client.Player.SendError("You have forged the Unoch's Truth!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x46d8];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 4:
                                client.Player.SendError("You have forged the Soul Buster!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x542b];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 5:
                                client.Player.SendError("You have forged the The 2-K!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x42c5];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 6:
                                client.Player.SendError("You have forged the Decimator Bow!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x42c7];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 7:
                                client.Player.SendError("You have forged the Unoch's Defiance!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x54d9];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 8:
                                client.Player.SendError("You have forged the Force Between Avex!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x46d5];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 9:
                                client.Player.SendError("You have forged the Oath of the Ages!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x64aa];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 10:
                                client.Player.SendError("You have forged the Vardon's Resilience!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x48fa];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 11:
                                client.Player.SendError("You have forged the Mocking Raven!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69d1];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 12:
                                client.Player.SendError("You have forged the Gilded Blade!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69d4];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 13:
                                client.Player.SendError("You have forged the Platinum Argarius!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x42fa];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 14:
                                client.Player.SendError("You have forged the Moon Crescent Halberd!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69d6];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 15:
                                client.Player.SendError("You have forged the Staff of Royal Revenge!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69dc];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 16:
                                client.Player.SendError("You have forged the Whispers of Murak'ul!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x1644];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 17:
                                client.Player.SendError("You have forged the Starcrash Ring!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69db];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 18:
                                client.Player.SendError("You have forged the Stargazer!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x42fc];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 19:
                                client.Player.SendError("You have forged the Sorrowful Boundtouch!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x46d7];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 20:
                                client.Player.SendError("You have forged the Cloud Edge!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x54b6];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 21:
                                client.Player.SendError("You have forged the Ring of the Unstable Mind!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x53de];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 22:
                                client.Player.SendError("You have forged the Calling of the Storm!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x48fd];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 23:
                                client.Player.SendError("You have forged the Armor of Anubis!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69da];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 24:
                                client.Player.SendError("You have forged the Furious Gauntlets!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69e8];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 25:
                                client.Player.SendError("You have forged the March of the Army!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x169f];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 26:
                                client.Player.SendError("You have forged the Chaos theory!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x47f5];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 27:
                                client.Player.SendError("You have forged the Opus Salutem!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x47f8];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 28:
                                client.Player.SendError("You have forged the Man O War!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x47f3];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 29:
                                client.Player.SendError("You have forged the Bracelet of the Demolished!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x52df];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 30:
                                client.Player.SendError("You have forged the Jackpot!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x5839];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 31:
                                client.Player.SendError("You have forged the Dranbiel Garbs!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69e3];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 32:
                                client.Player.SendError("You have forged the Protector of Grandeur!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69e4];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 33:
                                client.Player.SendError("You have forged the Quiver of Vast Power!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x1399];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 34:
                                client.Player.SendError("You have forged the Zeal of the Far-Ranger!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x49f6];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 35:
                                client.Player.SendError("You have forged the Hide of Garutious!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x49e4];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 36:
                                client.Player.SendError("You have forged the Exile's Resolve!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x45d3];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 37:
                                client.Player.SendError("You have forged the Tool of Galactic Destruction!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69e1];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 38:
                                client.Player.SendError("You have forged the Hallowed Shield!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x1571];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 39:
                                client.Player.SendError("You have forged the Cataclysmic Veil!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x49b2];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 40:
                                client.Player.SendError("You have forged the Hand of Zeus!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69d8];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 41:
                                client.Player.SendError("You have forged the Faith of the Angel!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x42f4];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 42:
                                client.Player.SendError("You have forged the Dirk of Notorious Agents!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x42b7];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 43:
                                client.Player.SendError("You have forged the Dagger of Tindailius!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x42f8];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 44:
                                client.Player.SendError("You have forged the Vulcanstriker!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x46f2];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 45:
                                client.Player.SendError("You have forged the Mind of Aanaraki!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x1483];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 46:
                                client.Player.SendError("You have forged the Revenant Prism!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x511a];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 47:
                                client.Player.SendError("You have forged the Grasp of Elysium!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x43a2];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 48:
                                client.Player.SendError("You have forged the Petrification Cloak!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x179c];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 49:
                                client.Player.SendError("You have forged the Garnet's Onslaught!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x56b8];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 50:
                                client.Player.SendError("You have forged the Jade's Judgement!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x56b9];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 51:
                                client.Player.SendError("You have forged the Karana's Secret!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69e6];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 52:
                                client.Player.SendError("You have forged the Pernicious Fate-36!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x45ef];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 53:
                                client.Player.SendError("You have forged the Tyrant Helm!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x42f6];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 54:
                                client.Player.SendError("You have forged the Sun and Moon Expansion!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69e9];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 55:
                                client.Player.SendError("You have forged the Haloflower Toxin!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x1636];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 56:
                                client.Player.SendError("You have forged the Never Before Seen!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x47db];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 57:
                                client.Player.SendError("You have forged the Scythe of Grim Memories!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x521c];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 58:
                                client.Player.SendError("You have forged the Eye of Insanity!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69ec];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 59:
                                client.Player.SendError("You have forged the Helm of Erebus!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69de];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 60:
                                client.Player.SendError("You have forged the Gilded Helm!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x69ed];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 61:
                                client.Player.SendError("You have forged the Brace of Anguish!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x45d1];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                        }

                    }else if (packet.ShardSlot.ObjectType == 0x68fb)
                    {
                        switch (drop2)
                        {
                            case 1:
                                client.Player.SendError("You have forged the Waraxe of Judgement!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x1485];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                            case 2:
                                client.Player.SendError("You have forged the Infernus!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x1398];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
                                break;
                             }
                        }
                    else if (packet.ShardSlot.ObjectType == 0x47c4)
                    {
                                client.Player.SendError("You have forged the Undead Nemesis!");
                                client.Player.Inventory[packet.SorSlot.SlotId] = client.Player.Manager.Resources.GameData.Items[0x47bd];
                                client.Player.Inventory[packet.ShardSlot.SlotId] = null;
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