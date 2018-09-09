using System;
using System.Collections.Generic;
using System.Linq;
using common.resources;
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
        private readonly ILootDef[] _loots;
        private readonly int _amount;

        public MostDamagers(int amount, params ILootDef[] loots) {
            _amount = amount;
            _loots = loots;
        }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat, Random rand, IList<LootDef> lootDefs) {
            var data = enemy.DamageCounter.GetPlayerData();
            var mostDamage = GetMostDamage(data);
            foreach (var loot in mostDamage.Where(pl => pl.Equals(playerDat)).SelectMany(pl => _loots))
                loot.Populate(manager, enemy, null, rand, lootDefs);
        }

        private IEnumerable<Tuple<Player, int>> GetMostDamage(IEnumerable<Tuple<Player, int>> data) {
            var damages = data.Select(_ => _.Item2).ToList();
            var len = damages.Count < _amount ? damages.Count : _amount;
            for (var i = 0; i < len; i++) {
                var val = damages.Max();
                yield return data.FirstOrDefault(_ => _.Item2 == val);
                damages.Remove(val);
            }
        }
    }

    public class OnlyOne : ILootDef
    {
        private readonly ILootDef[] _loots;

        public OnlyOne(params ILootDef[] loots) {
            _loots = loots;
        }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat, Random rand, IList<LootDef> lootDefs) {
            _loots[rand.Next(0, _loots.Length)].Populate(manager, enemy, playerDat, rand, lootDefs);
        }
    }

    public class ItemLoot : ILootDef
    {
        private readonly string _item;
        private readonly double _probability;

        public ItemLoot(string item, double probability) {
            _item = item;
            _probability = probability;
        }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat,
                             Random rand, IList<LootDef> lootDefs) {
            if (playerDat != null) return;
            var dat = manager.Resources.GameData;
            if (dat.IdToObjectType.ContainsKey(_item)
                && dat.Items.ContainsKey(dat.IdToObjectType[_item]))
                lootDefs.Add(new LootDef(dat.Items[dat.IdToObjectType[_item]], _probability));
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
        public static readonly int[] WeaponT = { 1, 2, 3, 8, 17, 24, 29, 34 };
        public static readonly int[] AbilityT = { 4, 5, 11, 12, 13, 15, 16, 18, 19, 20, 21, 22, 23, 27, 28, 30, 32, 33, 35 };
        public static readonly int[] ArmorT = { 6, 7, 14 };
        public static readonly int[] RingT = { 9 };
        public static readonly int[] PotionT = { 10 };

        private readonly byte _tier;
        private readonly int[] _types;
        private readonly double _probability;

        public TierLoot(byte tier, ItemType type, double probability) {
            _tier = tier;
            switch (type) {
                case ItemType.Weapon:
                    _types = WeaponT; break;
                case ItemType.Ability:
                    _types = AbilityT; break;
                case ItemType.Armor:
                    _types = ArmorT; break;
                case ItemType.Ring:
                    _types = RingT; break;
                case ItemType.Potion:
                    _types = PotionT; break;
                default:
                    throw new NotSupportedException(type.ToString());
            }
            _probability = probability;
        }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat,
                             Random rand, IList<LootDef> lootDefs) {
            if (playerDat != null) return;
            var candidates = manager.Resources.GameData.Items
                .Where(item => Array.IndexOf(_types, item.Value.SlotType) != -1)
                .Where(item => item.Value.Tier == _tier)
                .Select(item => item.Value)
                .ToArray();
            foreach (var i in candidates)
                lootDefs.Add(new LootDef(i, _probability / candidates.Length));
        }
    }

    public static class LootTemplates
    {
        public static ILootDef[] StatPots() {
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

        public static ILootDef[] GreaterPots() {
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

        //Hideout Fabled Dungeon
        public static ILootDef[] FabledItemsLoot1() {
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
                    new ItemLoot("Wisdom Eon", 0.25)
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
                    ),
                new OnlyOne(
                    new ItemLoot("Medium Sor Fragment", 0.5)
                )
            };
        }
        public static ILootDef[] RaidTokens() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("The Zol Awakening (Token)", 0.25),
                    new ItemLoot("Calling of the Titan (Token)", 0.25)
                   // new ItemLoot("A Fallen Light (Token)", 0.25),
                  //  new ItemLoot("Sidon's Fall (Token)", 0.25),
                 //   new ItemLoot("War of Decades (Token)", 0.25)
                )
             };
        }
        public static ILootDef[] FabledItemsLootUltra() {
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
                    new ItemLoot("Legendary Sor Crystal", 0.15),
                    new ItemLoot("Ultimate Onrane Cache", 0.33)
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
                    ),
               new OnlyOne(
                    new ItemLoot("Large Sor Fragment", 0.25)
                )
            };
        }

        public static ILootDef[] FabledItemsLoot2Drannol() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Bloodwell", 0.75),
                    new ItemLoot("Lavos Armor", 0.75),
                    new ItemLoot("Quiver of the Onslaught", 0.75),
                    new ItemLoot("Stonepraise Tome", 0.75),
                    new ItemLoot("Realitytaker Orb", 0.75),
                    new ItemLoot("Evisceration Claws", 0.75),
                    new ItemLoot("Heatblast Trap", 0.75),
                    new ItemLoot("Royalty Bow", 0.75),
                    new ItemLoot("Banner of Revenge", 0.75),
                    new ItemLoot("Percussion Shield", 0.75),
                    new ItemLoot("Toxin of the Vicious", 0.75),
                    new ItemLoot("Implacable Ram", 0.75),
                    new ItemLoot("Darkin Blades", 0.75),
                    new ItemLoot("The Twisted Cloak", 0.75),
                    new ItemLoot("The Twisted Axe", 0.75),
                    new ItemLoot("Twisted Amulet", 0.75),
                    new ItemLoot("The Twisted Axe", 0.75),
                    new ItemLoot("Hunter Necklace", 0.75),
                    new ItemLoot("Corruption Spell", 0.75),
                    new ItemLoot("Titanic Bracelet", 0.75)
                ),
                //Have another chance to get fabled item
                new OnlyOne(
                    new ItemLoot("Bloodwell", 0.50),
                    new ItemLoot("Lavos Armor", 0.50),
                    new ItemLoot("Quiver of the Onslaught", 0.50),
                    new ItemLoot("Stonepraise Tome", 0.50),
                    new ItemLoot("Realitytaker Orb", 0.50),
                    new ItemLoot("Evisceration Claws", 0.50),
                    new ItemLoot("Heatblast Trap", 0.50),
                    new ItemLoot("Royalty Bow", 0.50),
                    new ItemLoot("Banner of Revenge", 0.50),
                    new ItemLoot("Percussion Shield", 0.50),
                    new ItemLoot("Toxin of the Vicious", 0.50),
                    new ItemLoot("Implacable Ram", 0.50),
                    new ItemLoot("Darkin Blades", 0.50),
                    new ItemLoot("The Twisted Cloak", 0.50),
                    new ItemLoot("The Twisted Axe", 0.50),
                    new ItemLoot("Twisted Amulet", 0.50),
                    new ItemLoot("The Twisted Axe", 0.50),
                    new ItemLoot("Hunter Necklace", 0.50),
                    new ItemLoot("Corruption Spell", 0.50),
                    new ItemLoot("Titanic Bracelet", 0.50)
                ),
                //You have a 100% chance to get attack or wisdom eon
                new OnlyOne(
                    new ItemLoot("Defense Eon", 1),
                    new ItemLoot("Vitality Eon", 1)
                ),
                //You have a 25% chance to get ANOTHER attack or wisdom eon
                new OnlyOne(
                    new ItemLoot("Defense Eon", 1),
                    new ItemLoot("Vitality Eon", 1)
                ),
                new OnlyOne(
                    new ItemLoot("Medium Sor Fragment", 0.1)
                )
            };
        }

        public static ILootDef[] SorVeryRare() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Tiny Sor Fragment", 0.0008)
                )
             };
        }

        public static ILootDef[] SorRare() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Tiny Sor Fragment", 0.002)
                )
             };
        }

        public static ILootDef[] SorUncommon() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Tiny Sor Fragment", 0.001)
                )
             };
        }

        public static ILootDef[] SorCommon() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Tiny Sor Fragment", 0.04)
                )
             };
        }


        public static ILootDef[] FabledItemsLoot2B() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Bloodwell", 0.75),
                    new ItemLoot("Lavos Armor", 0.75),
                    new ItemLoot("Quiver of the Onslaught", 0.75),
                    new ItemLoot("Stonepraise Tome", 0.75),
                    new ItemLoot("Realitytaker Orb", 0.75),
                    new ItemLoot("Evisceration Claws", 0.75),
                    new ItemLoot("Titanic Bracelet", 0.75),
                    new ItemLoot("Heatblast Trap", 0.75),
                    new ItemLoot("Royalty Bow", 0.75),
                    new ItemLoot("Banner of Revenge", 0.75),
                    new ItemLoot("Percussion Shield", 0.75),
                    new ItemLoot("Toxin of the Vicious", 0.75),
                    new ItemLoot("Implacable Ram", 0.75),
                    new ItemLoot("Darkin Blades", 0.75),
                    new ItemLoot("The Twisted Cloak", 0.75),
                    new ItemLoot("The Twisted Axe", 0.75),
                    new ItemLoot("Twisted Amulet", 0.75),
                    new ItemLoot("The Twisted Axe", 0.75),
                    new ItemLoot("Corruption Spell", 0.75)
                ),
                new OnlyOne(
                    new ItemLoot("Small Sor Fragment", 0.1)
                )
            };
        }
        public static ILootDef[] FabledItemsLoots2B() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Bloodwell", 0.75),
                    new ItemLoot("Lavos Armor", 0.75),
                    new ItemLoot("Quiver of the Onslaught", 0.75),
                    new ItemLoot("Stonepraise Tome", 0.75),
                    new ItemLoot("Realitytaker Orb", 0.75),
                    new ItemLoot("Evisceration Claws", 0.75),
                    new ItemLoot("Titanic Bracelet", 0.75),
                    new ItemLoot("Heatblast Trap", 0.75),
                    new ItemLoot("Royalty Bow", 0.75),
                    new ItemLoot("Banner of Revenge", 0.75),
                    new ItemLoot("Percussion Shield", 0.75),
                    new ItemLoot("Toxin of the Vicious", 0.75),
                    new ItemLoot("Implacable Ram", 0.75),
                    new ItemLoot("Darkin Blades", 0.75),
                    new ItemLoot("The Twisted Cloak", 0.75),
                    new ItemLoot("The Twisted Axe", 0.75),
                    new ItemLoot("Twisted Amulet", 0.75),
                    new ItemLoot("The Twisted Axe", 0.75),
                    new ItemLoot("Hunter Necklace", 0.75),
                    new ItemLoot("Corruption Spell", 0.75)
                ),
                new OnlyOne(
                    new ItemLoot("Small Sor Fragment", 0.1)
                )
            };
        }

        public static ILootDef[] Sor1Perc() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Two Tiny Sor Fragments", 0.01),
                    new ItemLoot("Three Tiny Sor Fragments", 0.01),
                    new ItemLoot("Tiny Sor Fragment", 0.01)
                ),
                new OnlyOne(
                    new ItemLoot("Wine Cellar Incantation", 0.005)
                ),
                new OnlyOne(
                    new ItemLoot("Shine", 0.005)
                )
            };
        }

        public static ILootDef[] Sor2Perc() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Two Tiny Sor Fragments", 0.02),
                    new ItemLoot("Three Tiny Sor Fragments", 0.02),
                    new ItemLoot("Tiny Sor Fragment", 0.02)
                ),
                new OnlyOne(
                    new ItemLoot("Wine Cellar Incantation", 0.005)
                ),
                new OnlyOne(
                    new ItemLoot("Shine", 0.005)
                )
            };
        }

        public static ILootDef[] Sor3Perc() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Two Tiny Sor Fragments", 0.03),
                    new ItemLoot("Three Tiny Sor Fragments", 0.03),
                    new ItemLoot("Tiny Sor Fragment", 0.03)
                ),
                new OnlyOne(
                    new ItemLoot("Wine Cellar Incantation", 0.005)
                ),
                new OnlyOne(
                    new ItemLoot("Shine", 0.005)
                )
            };
        }

        public static ILootDef[] Sor4Perc() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Two Tiny Sor Fragments", 0.04),
                    new ItemLoot("Three Tiny Sor Fragments", 0.04),
                    new ItemLoot("Tiny Sor Fragment", 0.04)
                ),
                new OnlyOne(
                    new ItemLoot("Wine Cellar Incantation", 0.005)
                ),
                new OnlyOne(
                    new ItemLoot("Shine", 0.005)
                )
            };
        }

        public static ILootDef[] Sor5Perc() {
            return new ILootDef[]
            {
                new OnlyOne(
                    new ItemLoot("Two Tiny Sor Fragments", 0.05),
                    new ItemLoot("Three Tiny Sor Fragments", 0.05),
                    new ItemLoot("Tiny Sor Fragment", 0.05)
                ),
                new OnlyOne(
                    new ItemLoot("Wine Cellar Incantation", 0.005)
                ),
                new OnlyOne(
                    new ItemLoot("Shine", 0.005)
                )
            };
        }

        //Sincryer (Hideout) Fabled Dungeon
        public static ILootDef[] FabledItemsLoot2() {
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
                    ),
                new OnlyOne(
                    new ItemLoot("Two Tiny Sor Fragments", 0.1)
                )
            };
        }
    }

    public class Threshold : ILootDef
    {
        private readonly double _threshold;
        private readonly ILootDef[] _children;

        public Threshold(double threshold, params ILootDef[] children) {
            _threshold = threshold;
            _children = children;
        }

        public void Populate(RealmManager manager, Enemy enemy, Tuple<Player, int> playerDat,
                             Random rand, IList<LootDef> lootDefs) {
            if (playerDat != null && playerDat.Item2 / (double)enemy.ObjectDesc.MaxHP >= (_threshold - (_threshold * playerDat.Item1.thresholdBoost())) / Math.Max(enemy.Owner.Players.Count() / 2, 1)) {
                foreach (var i in _children)
                    i.Populate(manager, enemy, null, rand, lootDefs);
            }
        }
    }
}