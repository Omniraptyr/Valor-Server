using common.resources;
using System;
using System.Collections.Generic;
using System.Linq;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.loot
{
    public interface ILootDef
    {
        void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat,
                      Random rand, IList<LootDef> lootDefs);
    }

    internal class MostDamagers : ILootDef
    {
        private readonly ILootDef[] loots;
        private readonly int amount;

        public MostDamagers(int amount, params ILootDef[] loots)
        {
            this.amount = amount;
            this.loots = loots;
        }

        public string Lootstate { get; set; }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat, Random rand, IList<LootDef> lootDefs)
        {
            var data = enemy.DamageCounter.GetPlayerData();
            var mostDamage = GetMostDamage(data);
            foreach (var loot in mostDamage.Where(pl => pl.Equals(playerDat)).SelectMany(pl => loots))
                loot.Populate(manager, enemy, null, rand, lootDefs);
        }

        private IEnumerable<Tuple<Player, int>> GetMostDamage(IEnumerable<Tuple<Player, int>> data)
        {
            var damages = data.Select(_ => _.Item2).ToList();
            var len = damages.Count < amount ? damages.Count : amount;
            for (var i = 0; i < len; i++)
            {
                var val = damages.Max();
                yield return data.FirstOrDefault(_ => _.Item2 == val);
                damages.Remove(val);
            }
        }
    }

    public class OnlyOne : ILootDef
    {
        private readonly ILootDef[] loots;

        public OnlyOne(params ILootDef[] loots)
        {
            this.loots = loots;
        }

        public string Lootstate { get; set; }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat, Random rand, IList<LootDef> lootDefs)
        {
            loots[rand.Next(0, loots.Length)].Populate(manager, enemy, playerDat, rand, lootDefs);
        }
    }

    public class ItemLoot : ILootDef
    {
        private string item;
        private double probability;

        public ItemLoot(string item, double probability)
        {
            this.item = item;
            this.probability = probability;
        }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat,
                             Random rand, IList<LootDef> lootDefs)
        {
            if (playerDat != null) return;
            var dat = manager.Resources.GameData;
            if (dat.IdToObjectType.ContainsKey(item)
                && dat.Items.ContainsKey(dat.IdToObjectType[item]))
                lootDefs.Add(new LootDef(dat.Items[dat.IdToObjectType[item]], probability));
        }
    }

    public enum LItemType
    {
        Weapon,
        Ability,
        Armor,
        Ring,
        Potion
    }

    public class TierLoot : ILootDef
    {
        public static readonly int[] WeaponT = new int[] { 1, 2, 3, 8, 17, 24, 29, 34 };
        public static readonly int[] AbilityT = new int[] { 4, 5, 11, 12, 13, 15, 16, 18, 19, 20, 21, 22, 23, 27, 28, 30, 32, 33, 35 };
        public static readonly int[] ArmorT = new int[] { 6, 7, 14, };
        public static readonly int[] RingT = new int[] { 9 };
        public static readonly int[] PotionT = new int[] { 10 };

        private byte tier;
        private int[] types;
        private double probability;

        public TierLoot(byte tier, ItemType type, double probability)
        {
            this.tier = tier;
            switch (type)
            {
                case ItemType.Weapon:
                    types = WeaponT; break;
                case ItemType.Ability:
                    types = AbilityT; break;
                case ItemType.Armor:
                    types = ArmorT; break;
                case ItemType.Ring:
                    types = RingT; break;
                case ItemType.Potion:
                    types = PotionT; break;
                default:
                    throw new NotSupportedException(type.ToString());
            }
            this.probability = probability;
        }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat,
                             Random rand, IList<LootDef> lootDefs)
        {
            if (playerDat != null) return;
            Item[] candidates = manager.Resources.GameData.Items
                .Where(item => Array.IndexOf(types, item.Value.SlotType) != -1)
                .Where(item => item.Value.Tier == tier)
                .Select(item => item.Value)
                .ToArray();
            foreach (var i in candidates)
                lootDefs.Add(new LootDef(i, probability / candidates.Length));
        }
    }
    public static class LootTemplates
    {

        public static ILootDef[] StatIncreasePotionsLoot()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Potion of Defense", 1),
                    new ItemLoot("Potion of Attack", 1),
                    new ItemLoot("Potion of Speed", 1),
                    new ItemLoot("Potion of Vitality", 1),
                    new ItemLoot("Potion of Wisdom", 1),
                    new ItemLoot("Potion of Dexterity", 1)
                )
             };
        }




        public static ILootDef[] GStatIncreasePotionsLoot()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Greater Potion of Defense", 1),
                    new ItemLoot("Greater Potion of Attack", 1),
                    new ItemLoot("Greater Potion of Speed", 1),
                    new ItemLoot("Greater Potion of Vitality", 1),
                    new ItemLoot("Greater Potion of Wisdom", 1),
                    new ItemLoot("Greater Potion of Dexterity", 1)
                )
             };
        }

        public static ILootDef[] GStatIncreasePotionsLoot2()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Greater Potion of Defense", 1),
                    new ItemLoot("Greater Potion of Attack", 1),
                    new ItemLoot("Greater Potion of Speed", 1),
                    new ItemLoot("Greater Potion of Vitality", 1),
                    new ItemLoot("Greater Potion of Wisdom", 1),
                    new ItemLoot("Greater Potion of Dexterity", 1),
                    new ItemLoot("Greater Potion of Restoration", 1),
                    new ItemLoot("Greater Potion of Protection", 1),
                    new ItemLoot("Greater Potion of Might", 1),
                    new ItemLoot("Greater Potion of Luck", 1),
                    new ItemLoot("Greater Potion of Life", 1),
                    new ItemLoot("Greater Potion of Mana", 1)
                )
             };
        }

        public static ILootDef[] GoldLoot()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("1 Gold", 0.025),
                    new ItemLoot("5 Gold", 0.025),
                    new ItemLoot("10 Gold", 0.025)
                ),
             };
        }

        //Hideout Fabled Dungeon
        public static ILootDef[] FabledItemsLoot1()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Kismet Seal", 0.75),
                    new ItemLoot("Soundpiercer Shuriken", 0.75),
                    new ItemLoot("Doomgrazer", 0.75),
                    new ItemLoot("Age of Zol", 0.75),
                    new ItemLoot("Wrath of Aldragine", 0.75),
                    new ItemLoot("Bane of the Vision", 0.75),
                    new ItemLoot("Spirit of the Heart", 0.75),
                    new ItemLoot("The Grand Finale", 0.75),
                    new ItemLoot("Merit of Rebellion", 0.75),
                    new ItemLoot("Enigma Wand", 0.75),
                    new ItemLoot("Spear of the Unforgiven", 0.75),
                    new ItemLoot("Dagger of Corruption", 0.75)
                ),
                //Have another chance to get fabled iten
                new OnlyOne(
                    new ItemLoot("Kismet Seal", 0.5),
                    new ItemLoot("Soundpiercer Shuriken", 0.5),
                    new ItemLoot("Doomgrazer", 0.5),
                    new ItemLoot("Age of Zol", 0.5),
                    new ItemLoot("Wrath of Aldragine", 0.5),
                    new ItemLoot("Bane of the Vision", 0.5),
                    new ItemLoot("Spirit of the Heart", 0.5),
                    new ItemLoot("The Grand Finale", 0.5),
                    new ItemLoot("Merit of Rebellion", 0.5),
                    new ItemLoot("Enigma Wand", 0.5),
                    new ItemLoot("Spear of the Unforgiven", 0.5),
                    new ItemLoot("Dagger of Corruption", 0.5)
                ),
                //You have a 100% chance to get attack or wisdom eon
                new OnlyOne(
                    new ItemLoot("Attack Eon", 1),
                    new ItemLoot("Wisdom Eon", 1)
                ),
                //You have a 25% chance to get ANOTHER attack or wisdom eon
                new OnlyOne(
                    new ItemLoot("Attack Eon", 0.25),
                    new ItemLoot("Wisdom Eon", 0/25)
                ),
                //High chance to get 2 cloth
                new OnlyOne(
                    new ItemLoot("Large Zol Cloth", 0.6),
                    new ItemLoot("Small Zol Cloth", 0.6)
                ),
                new OnlyOne(
                    new ItemLoot("Large Vortex Cloth", 0.6),
                    new ItemLoot("Small Vortex Cloth", 0.6)
                    ),
                new OnlyOne(
                    new ItemLoot("Large Aura Cloth", 0.6),
                    new ItemLoot("Small Aura Cloth", 0.6)
                    ),
                new OnlyOne(
                    new ItemLoot("Sword of Dark Retribution", 0.8),
                    new ItemLoot("Helm of Dark Retribution", 0.8),
                    new ItemLoot("Armor of Dark Retribution", 0.8),
                    new ItemLoot("Ring of Dark Retribution", 0.8)
                    ),
                new OnlyOne(
                    new ItemLoot("Sword of Dark Retribution", 0.8),
                    new ItemLoot("Helm of Dark Retribution", 0.8),
                    new ItemLoot("Armor of Dark Retribution", 0.8),
                    new ItemLoot("Ring of Dark Retribution", 0.8)
                    )
            };
        }
        public static ILootDef[] RaidTokens()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("The Zol Awakening (Token)", 0.25),
                    new ItemLoot("Calling of the Titan (Token)", 0.25),
                    new ItemLoot("A Fallen Light (Token)", 0.25),
                    new ItemLoot("Sidon's Fall (Token)", 0.25),
                    new ItemLoot("War of Decades (Token)", 0.25)
                )
             };
        }
        public static ILootDef[] FabledItemsLootUltra()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Master Eon", 0.01)
                ),
                new OnlyOne(
                    new ItemLoot("1000 Gold", 1),
                    new ItemLoot("100 Gold", 1)
                ),
                //Whole Sor Crystal
                new OnlyOne(
                    new ItemLoot("Legendary Sor Crystal", 0.50),
                    new ItemLoot("Ultimate Onrane Cache", 0.50)
                ),
                //certain fabled item
               new OnlyOne(
                    new ItemLoot("Kismet Seal", 1),
                    new ItemLoot("Soundpiercer Shuriken", 1),
                    new ItemLoot("Doomgrazer", 1),
                    new ItemLoot("Age of Zol", 1),
                    new ItemLoot("Wrath of Aldragine", 1),
                    new ItemLoot("Bane of the Vision", 1),
                    new ItemLoot("Spirit of the Heart", 1),
                    new ItemLoot("The Grand Finale", 1),
                    new ItemLoot("Merit of Rebellion", 1),
                    new ItemLoot("Enigma Wand", 1),
                    new ItemLoot("Spear of the Unforgiven", 1),
                    new ItemLoot("Dagger of Corruption", 1)
                ),
                new OnlyOne(
                    new ItemLoot("Kismet Seal", 0.75),
                    new ItemLoot("Soundpiercer Shuriken", 0.75),
                    new ItemLoot("Doomgrazer", 0.75),
                    new ItemLoot("Age of Zol", 0.75),
                    new ItemLoot("Wrath of Aldragine", 0.75),
                    new ItemLoot("Bane of the Vision", 0.75),
                    new ItemLoot("Spirit of the Heart", 0.75),
                    new ItemLoot("The Grand Finale", 0.75),
                    new ItemLoot("Merit of Rebellion", 0.75),
                    new ItemLoot("Enigma Wand", 0.75),
                    new ItemLoot("Spear of the Unforgiven", 0.75),
                    new ItemLoot("Dagger of Corruption", 0.75)
                ),
                //Have another chance to get fabled iten
                new OnlyOne(
                    new ItemLoot("Kismet Seal", 0.75),
                    new ItemLoot("Soundpiercer Shuriken", 0.75),
                    new ItemLoot("Doomgrazer", 0.75),
                    new ItemLoot("Age of Zol", 0.75),
                    new ItemLoot("Wrath of Aldragine", 0.75),
                    new ItemLoot("Bane of the Vision", 0.75),
                    new ItemLoot("Spirit of the Heart", 0.75),
                    new ItemLoot("The Grand Finale", 0.75),
                    new ItemLoot("Merit of Rebellion", 0.75),
                    new ItemLoot("Enigma Wand", 0.75),
                    new ItemLoot("Spear of the Unforgiven", 0.75),
                    new ItemLoot("Dagger of Corruption", 0.75)
                ),
                //You have a 100% chance to get attack or wisdom eon
                new OnlyOne(
                    new ItemLoot("Attack Eon", 1),
                    new ItemLoot("Wisdom Eon", 1)
                ),
                //You have a 75% chance to get ANOTHER attack or wisdom eon
                new OnlyOne(
                    new ItemLoot("Attack Eon", 0.75),
                    new ItemLoot("Wisdom Eon", 0.75)
                ),
                //High chance to get 2 cloth
                new OnlyOne(
                    new ItemLoot("Large Zol Cloth", 0.75),
                    new ItemLoot("Small Zol Cloth", 0.75)
                ),
                new OnlyOne(
                    new ItemLoot("Large Vortex Cloth", 0.75),
                    new ItemLoot("Small Vortex Cloth", 0.75)
                    ),
                new OnlyOne(
                    new ItemLoot("Large Aura Cloth", 0.75),
                    new ItemLoot("Small Aura Cloth", 0.75)
                    ),
                new OnlyOne(
                    new ItemLoot("Sword of Dark Retribution", 0.8),
                    new ItemLoot("Helm of Dark Retribution", 0.8),
                    new ItemLoot("Armor of Dark Retribution", 0.8),
                    new ItemLoot("Ring of Dark Retribution", 0.8)
                    ),
                new OnlyOne(
                    new ItemLoot("Sword of Dark Retribution", 0.8),
                    new ItemLoot("Helm of Dark Retribution", 0.8),
                    new ItemLoot("Armor of Dark Retribution", 0.8),
                    new ItemLoot("Ring of Dark Retribution", 0.8)
                    )
            };
        }
        //1/125K
        public static ILootDef[] SFExtremelyLow()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Sor Fragment 1", 0.000008),
                    new ItemLoot("Sor Fragment 2", 0.000008),
                    new ItemLoot("Sor Fragment 3", 0.000008)
                )
             };
        }
        //1/50k
        public static ILootDef[] SFLow()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Sor Fragment 1", 0.00002),
                    new ItemLoot("Sor Fragment 2", 0.00002),
                    new ItemLoot("Sor Fragment 3", 0.00002)
                )
             };
        }
        //1/50
        public static ILootDef[] SFElite()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Sor Fragment 1", 0.02),
                    new ItemLoot("Sor Fragment 2", 0.02),
                    new ItemLoot("Sor Fragment 3", 0.02)
                )
             };
        }
        //1/100
        public static ILootDef[] SFCrystal()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Sor Fragment 1", 0.01),
                    new ItemLoot("Sor Fragment 2", 0.01),
                    new ItemLoot("Sor Fragment 3", 0.01)
                )
             };
        }
        //1/1000
        public static ILootDef[] SFCrystal2()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Sor Fragment 1", 0.001),
                    new ItemLoot("Sor Fragment 2", 0.001),
                    new ItemLoot("Sor Fragment 3", 0.001)
                )
             };
        }
        //1/25
        public static ILootDef[] SFGigas()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Sor Fragment 1", 0.04),
                    new ItemLoot("Sor Fragment 2", 0.04),
                    new ItemLoot("Sor Fragment 3", 0.04)
                )
             };
        }
        //Sincryer (Hideout) Fabled Dungeon
        public static ILootDef[] FabledItemsLoot2()
        {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Kismet Seal", 0.75),
                    new ItemLoot("Soundpiercer Shuriken", 0.75),
                    new ItemLoot("Doomgrazer", 0.75),
                    new ItemLoot("Age of Zol", 0.75),
                    new ItemLoot("Wrath of Aldragine", 0.75),
                    new ItemLoot("Bane of the Vision", 0.75),
                    new ItemLoot("Spirit of the Heart", 0.75),
                    new ItemLoot("The Grand Finale", 0.75),
                    new ItemLoot("Merit of Rebellion", 0.75),
                    new ItemLoot("Enigma Wand", 0.75),
                    new ItemLoot("Spear of the Unforgiven", 0.75),
                    new ItemLoot("Dagger of Corruption", 0.75)
                ),
                new OnlyOne(
                    new ItemLoot("Sword of Dark Retribution", 0.8),
                    new ItemLoot("Helm of Dark Retribution", 0.8),
                    new ItemLoot("Armor of Dark Retribution", 0.8),
                    new ItemLoot("Ring of Dark Retribution", 0.8)
                    )
            };
        }
    }
    public class Threshold : ILootDef
    {
        private double threshold;
        private ILootDef[] children;

        public Threshold(double threshold, params ILootDef[] children)
        {
            this.threshold = threshold;
            this.children = children;
        }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat,
                             Random rand, IList<LootDef> lootDefs)
        {
            if (playerDat != null && playerDat.Item2 / (double)enemy.ObjectDesc.MaxHP >= threshold / Math.Max(enemy.Owner.Players.Count() / 2, 1))
            {
                foreach (var i in children)
                    i.Populate(manager, enemy, null, rand, lootDefs);
            }
        }
    }


    public class Threshold2 : ILootDef
    {
        private Player player;

        private double threshold;
        private int supportScore;
        private ILootDef[] children;


        public Threshold2(double threshold, int supportScore, params ILootDef[] children)
        {
            this.threshold = threshold;
            this.supportScore = supportScore;
            this.children = children;
        }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat,
                             Random rand, IList<LootDef> lootDefs)
        {
            if (playerDat != null && playerDat.Item2 / (double)enemy.ObjectDesc.MaxHP >= threshold / Math.Max(enemy.Owner.Players.Count() / 2, 1) || playerDat != null && playerDat.Item2 / (double)enemy.ObjectDesc.MaxHP >= 0.01 / Math.Max(enemy.Owner.Players.Count() / 2, 1) && player.SupportScore >= supportScore)
            {
                foreach (var i in children)
                    i.Populate(manager, enemy, null, rand, lootDefs);
            }
        }
    }

}