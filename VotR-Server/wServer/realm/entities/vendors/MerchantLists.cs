using System;
using System.Collections.Generic;
using System.Linq;
using common;
using common.resources;
using log4net;
using wServer.realm.terrain;

namespace wServer.realm.entities.vendors
{
    public class ShopItem : ISellableItem
    {
        public ushort ItemId { get; private set; }
        public int Price { get; }
        public int Count { get; }
        public string Name { get; }

        public ShopItem(string name, int price, int count = -1) {
            ItemId = ushort.MaxValue;
            Price = price;
            Count = count;
            Name = name;
        }

        public void SetItem(ushort item) {
            if (ItemId != ushort.MaxValue)
                throw new AccessViolationException("Can't change item after it has been set.");

            ItemId = item;
        }
    }

    internal static class MerchantLists
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MerchantLists));

        private static readonly List<ISellableItem> Weapon = new List<ISellableItem> {
            new ShopItem("Dagger of Foul Malevolence", 1000),
            new ShopItem("Bow of Covert Havens", 1000),
            new ShopItem("Staff of the Cosmic Whole", 1000),
            new ShopItem("Wand of Recompense", 1000),
            new ShopItem("Sword of Acclaim", 1000),
            new ShopItem("Masamune", 1000),
            new ShopItem("Master Blades", 1000),
            new ShopItem("Lance of the Last Stand", 1000),
            new ShopItem("Staff of the Vital Unity", 7500),
            new ShopItem("Sadamune", 7500),
            new ShopItem("Sword of Splendor", 7500),
            new ShopItem("Wand of Evocation", 7500),
            new ShopItem("Bow of Mystical Energy", 7500),
            new ShopItem("Dagger of Sinister Deeds", 7500),
            new ShopItem("Ivory Blades", 7500),
            new ShopItem("Ornate Lance", 7500)
        };

        private static readonly List<ISellableItem> Ability = new List<ISellableItem> {
            new ShopItem("Cloak of Ghostly Concealment", 2000),
            new ShopItem("Quiver of Elvish Mastery", 2000),
            new ShopItem("Elemental Detonation Spell", 2000),
            new ShopItem("Tome of Holy Guidance", 2000),
            new ShopItem("Helm of the Great General", 2000),
            new ShopItem("Colossus Shield", 2000),
            new ShopItem("Seal of the Blessed Champion", 2000),
            new ShopItem("Baneserpent Poison", 2000),
            new ShopItem("Bloodsucker Skull", 2000),
            new ShopItem("Giantcatcher Trap", 2000),
            new ShopItem("Planefetter Orb", 2000),
            new ShopItem("Prism of Apparitions", 2000),
            new ShopItem("Scepter of Storms", 2000),
            new ShopItem("Doom Circle", 2000),
            new ShopItem("Sheath of the Holy Revival", 2000),
            new ShopItem("Banner of True War", 2000),
            new ShopItem("Siphon of Redemption", 2000),
            new ShopItem("Sanctified Charm", 2000),
            new ShopItem("Stone Dice", 2000),
            new ShopItem("Jacket of Sorrows", 2000)
        };

        private static readonly List<ISellableItem> Armor = new List<ISellableItem> {
            new ShopItem("Robe of the Grand Sorcerer", 1000),
            new ShopItem("Hydra Skin Armor", 1000),
            new ShopItem("Acropolis Armor", 1000),
            new ShopItem("Wyrmhide Armor", 7500),
            new ShopItem("Robe of the Star Mother", 7500),
            new ShopItem("Dominion Armor", 7500)
        };

        private static readonly List<ISellableItem> Rings = new List<ISellableItem> {
             new ShopItem("Ring of Unbound Attack", 3000),
             new ShopItem("Ring of Unbound Defense", 3000),
             new ShopItem("Ring of Unbound Speed", 3000),
             new ShopItem("Ring of Unbound Dexterity", 3000),
             new ShopItem("Ring of Unbound Vitality", 3000),
             new ShopItem("Ring of Unbound Wisdom", 3000),
             new ShopItem("Ring of Unbound Health", 3000),
             new ShopItem("Ring of Unbound Magic", 3000)
        };

        private static readonly List<ISellableItem> Aldragine = new List<ISellableItem> {
            new ShopItem("Scepter of the Other", 150),
            new ShopItem("Burden of the Warpawn", 160),
            new ShopItem("The Odyssey", 120),
            new ShopItem("The Executioner", 120),
            new ShopItem("Rip of Soul", 130),
            new ShopItem("Sincryer's Demise", 140)
        };

        private static readonly List<ISellableItem> Drannol = new List<ISellableItem> {
            new ShopItem("Aegis of the Devourer", 130),
            new ShopItem("Drannol's Fury", 120),
            new ShopItem("Grasp of Elysium", 140),
            new ShopItem("Fortification Shield", 160),
            new ShopItem("Never Before Seen", 120),
            new ShopItem("The Master's Betrayal", 110)
        };

        private static readonly List<ISellableItem> Special = new List<ISellableItem> {
            new ShopItem("Backpack", 100000),
            new ShopItem("Amulet of Resurrection", 750000)
        };

        private static readonly List<ISellableItem> LegendaryConsumables = new List<ISellableItem> {
            new ShopItem("Speedier Sprout", 100000),
            new ShopItem("Pandora's Box", 500000),
            new ShopItem("Purification Crystal", 250000)
        };

        private static readonly List<ISellableItem> Coins = new List<ISellableItem> {
            new ShopItem("100 Gold", 100),
            new ShopItem("1000 Gold", 1000),
            new ShopItem("10000 Gold", 10000),
            new ShopItem("100000 Gold", 100000)
        };

        public static readonly Dictionary<TileRegion, Tuple<List<ISellableItem>, CurrencyType, int>> Shops =
            new Dictionary<TileRegion, Tuple<List<ISellableItem>, CurrencyType, int>>
        {
            { TileRegion.Store_1, new Tuple<List<ISellableItem>, CurrencyType, int>(Weapon, CurrencyType.Fame, 0) },
            { TileRegion.Store_2, new Tuple<List<ISellableItem>, CurrencyType, int>(Ability, CurrencyType.Fame, 0) },
            { TileRegion.Store_3, new Tuple<List<ISellableItem>, CurrencyType, int>(Armor, CurrencyType.Fame, 0) },
            { TileRegion.Store_4, new Tuple<List<ISellableItem>, CurrencyType, int>(Rings, CurrencyType.Fame, 0) },
            { TileRegion.Store_5, new Tuple<List<ISellableItem>, CurrencyType, int>(Coins, CurrencyType.Gold, 0) },
            { TileRegion.Store_7, new Tuple<List<ISellableItem>, CurrencyType, int>(Special, CurrencyType.Fame, 0) },
            { TileRegion.Store_8, new Tuple<List<ISellableItem>, CurrencyType, int>(LegendaryConsumables, CurrencyType.Fame, 0) },
            { TileRegion.Store_15, new Tuple<List<ISellableItem>, CurrencyType, int>(Aldragine, CurrencyType.Onrane, 20) },
            { TileRegion.Store_16, new Tuple<List<ISellableItem>, CurrencyType, int>(Drannol, CurrencyType.Onrane, 20) },
        };

        public static void Init(RealmManager manager) {
            foreach (var shop in Shops)
                foreach (var shopItem in shop.Value.Item1.OfType<ShopItem>()) {
                    if (manager.Resources.GameData.IdToObjectType.TryGetValue(shopItem.Name, out var id))
                        shopItem.SetItem(id);
                }
        }
    }
}