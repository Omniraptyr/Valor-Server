using common.resources;
using System;
using System.Collections.Generic;

namespace wServer.realm.entities
{
    partial class Player
    {

        public Tuple<Item> GetUnboxResult(int crateType, Random rand)
        {   
            
            Lootbox loot = Manager.Resources.GameData.Lootboxes[Manager.Resources.GameData.IdtoLootboxType[LootboxType(crateType)]];
            if (rand == null)
                rand = new Random();
            double choice = rand.NextDouble();
            double totalChance = 0;
            foreach (Tuple<double, List<CrateLoot>> i in loot.CrateLoot)
            {
                totalChance += i.Item1;
                if (choice < totalChance)
                {
                    var crateLoot = i.Item2.RandomElement(rand);
                    return GetCrateLoot(crateLoot, rand);
                }
            }
            Item item = Manager.Resources.GameData.Items[Manager.Resources.GameData.IdToObjectType["Gold Medal"]];
            return Tuple.Create(item);
        }
        public string LootboxType(int crateName)
        {
            switch (crateName)
            {
                case 1: return "Bronze Lootbox";
                case 2: return "Silver Lootbox";
                case 3: return "Gold Lootbox";
                case 4: return "Elite Lootbox";
                case 5: return "Premium Lootbox";
            }
            return "Unknown";
        }
        public Tuple<Item> GetCrateLoot(CrateLoot crateLoot, Random rand)
        {
            if (rand == null)
                rand = new Random();
            Item item = null;
            switch (crateLoot.Type)
            {
                case CrateLootTypes.Item:
                    {
                        item = Manager.Resources.GameData.Items[Manager.Resources.GameData.IdToObjectType[crateLoot.Name]];
                    }
                    break;
            }
            return Tuple.Create(item);
        }
    }
}