using common.resources;
using System;
using System.Collections.Generic;
using System.Linq;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.loot
{
    public struct LootDef
    {
        public LootDef(Item item, double probabilty) {
            Item = item;
            Probability = probabilty;
        }

        public readonly Item Item;
        public readonly double Probability;
    }

    public class Loot : List<ILootDef>
    {
        public Loot() {
        }

        public Loot(params ILootDef[] lootDefs) {  //For independent loots(e.g. chests)
            AddRange(lootDefs);
        }

        private static readonly Random Rand = new Random();

        private static readonly string[] ValuableItems = {
            "Master Eon",
            "10000 Gold",
            "Three Tiny Sor Fragments",
            "Sor Fragment Cache",
            "Small Sor Fragment",
            "Medium Sor Fragment",
            "Large Sor Fragment",
            "Sor Crystal",
            "Legendary Sor Crystal",
            "Warped Worlds Staff",
            "Null-Magic Trap",
            "Marble Tablet",
            "The ET Experience",
            "Wildfire Crossbow",
            "The Eye of Peril",
            "Shard of Ancient Assault",
            "Shard of the Stone Soul",
            "Spirit of the Heart",
            "Wrath of Aldragine",
            "Age of Zol",
            "Spiritclaw",
            "Hunter Necklace",
            "Quiver of the Onslaught",
            "Banner of Revenge",
            "Twisted Amulet",
            "Evisceration Claws",
            "Titanic Bracelet",
            "Drannol's Judgement",
            "Toxin of the Vicious"
        };

        public IEnumerable<Item> GetLoots(RealmManager manager, int min, int max) {  //For independent loots(e.g. chests)
            var consideration = new List<LootDef>();
            foreach (var i in this)
                i.Populate(manager, null, null, Rand, consideration);

            var retCount = Rand.Next(min, max);
            foreach (var i in consideration) {
                if (Rand.NextDouble() < i.Probability) {
                    yield return i.Item;
                    retCount--;
                }
                if (retCount == 0)
                    yield break;
            }
        }

        public void Handle(Enemy enemy, RealmTime time) {
            var consideration = new List<LootDef>();

            var sharedLoots = new List<Item>();
            foreach (var i in this)
                i.Populate(enemy.Manager, enemy, null, Rand, consideration);
            foreach (var i in consideration) {
                if (Rand.NextDouble() < i.Probability)
                    sharedLoots.Add(i.Item);
            }

            var dats = enemy.DamageCounter.GetPlayerData();
            var loots = enemy.DamageCounter.GetPlayerData().ToDictionary(
                d => d.Item1, d => (IList<Item>)new List<Item>());

            foreach (var loot in sharedLoots.Where(item => item.Soulbound))
                loots[dats[Rand.Next(dats.Length)].Item1].Add(loot);

            foreach (var dat in dats) {
                consideration.Clear();
                foreach (var i in this)
                    i.Populate(enemy.Manager, enemy, dat, Rand, consideration);

                var lootDropBoost = dat.Item1.LDBoostTime > 0 ? 1.5 : 1;
                var luckStatBoost = 1 + dat.Item1.Stats.Boost[14] / 100.0;

                var playerLoot = loots[dat.Item1];
                foreach (var i in consideration) {
                    if (Rand.NextDouble() < i.Probability * lootDropBoost * luckStatBoost)
                        playerLoot.Add(i.Item);
                }
            }

            AddBagsToWorld(enemy, sharedLoots, loots);
        }

        private static void AddBagsToWorld(Enemy enemy, IList<Item> shared, IDictionary<Player, IList<Item>> soulbound) {
            var pub = new List<Player>();  //only people not getting soulbound
            foreach (var i in soulbound) {
                if (i.Value.Count > 0)
                    ShowBags(enemy, i.Value, i.Key);
                else
                    pub.Add(i.Key);
            }
            if (pub.Count > 0 && shared.Count > 0)
                ShowBags(enemy, shared, pub.ToArray());
        }

        private static void ShowBags(Enemy enemy, IEnumerable<Item> loots, params Player[] owners) {
            var ownerIds = owners.Select(x => x.AccountId).ToArray();
            var bagType = 0;
            var items = new Item[8];
            var idx = 0;

            foreach (var i in loots) {
                if (i.BagType > bagType) bagType = i.BagType;
                items[idx] = i;
                idx++;

                if (ValuableItems.Contains(i.ObjectId))
                    foreach (var p in enemy.Owner.Players.Values)
                        p.SendHelp("<" + owners[0].Name + "> has received a drop: '"
                                                  + i.ObjectId + "'");

                if (idx == 8) {
                    ShowBag(enemy, ownerIds, bagType, items);

                    bagType = 0;
                    items = new Item[8];
                    idx = 0;
                }
            }

            if (idx > 0)
                ShowBag(enemy, ownerIds, bagType, items);
        }

        private static void ShowBag(Enemy enemy, int[] owners, int bagType, Item[] items) {
            ushort bag = 0x0500;
            switch (bagType) {
                case 0:
                    bag = 0x500;
                    break;

                case 1:
                    bag = 0x506;
                    break;

                case 2:
                    bag = 0x503;
                    break;

                case 3:
                    bag = 0x508;
                    break;

                case 4:
                    bag = 0x509;
                    break;

                case 5:
                    bag = 0x050B;
                    break;

                case 6:
                    bag = 0x050C;
                    break;

                case 7:
                    bag = 0xfff;
                    break;

                case 8:
                    bag = 0x1861;
                    break;

                case 9:
                    bag = 0x169a;
                    break;

                case 10:
                    bag = 0x506f;
                    break;

                case 11:
                    bag = 0x44d4;
                    break;
            }
            var container = new Container(enemy.Manager, bag, 1000 * 60, true);
            for (var j = 0; j < 8; j++)
                container.Inventory[j] = items[j];
            container.BagOwners = owners;
            container.Move(
                enemy.X + (float)((Rand.NextDouble() * 2 - 1) * 0.5),
                enemy.Y + (float)((Rand.NextDouble() * 2 - 1) * 0.5));
            container.SetDefaultSize(bagType == 11 ? 120 : (bagType > 3 ? 110 : 80));
            enemy.Owner.EnterWorld(container);
        }
    }
}