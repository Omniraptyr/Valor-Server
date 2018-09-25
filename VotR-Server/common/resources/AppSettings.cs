using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using log4net;

namespace common.resources
{
    public class AppSettings : InitSettings
    {
        public string MenuMusic { get; }
        public string DeadMusic { get; }
        public int EditorMinRank { get; }
        public int CharacterSlotCost { get; }
        public int CharacterSlotCurrency { get; }
        public int VaultChestCost { get; }
        public int InventorySize { get; }
        public int MaxStackablePotions { get; }
        public int PotionPurchaseCooldown { get; }
        public int PotionPurchaseCostCooldown { get; }
        public int[] PotionPurchaseCosts { get; }
        public bool DisableRegistration { get; }
        public int MysteryBoxRefresh { get; }
        public int MaxPetCount { get; }
        public NewAccounts Accounts { get; }
        public NewCharacters Characters { get; }

        public AppSettings(string path)
        {
            elem = XElement.Parse(File.ReadAllText(path));

            MenuMusic = GetStringValue("MenuMusic");
            DeadMusic = GetStringValue("DeadMusic");
            EditorMinRank = GetIntValue("EditorMinRank");
            CharacterSlotCost = GetIntValue("CharacterSlotCost");
            CharacterSlotCurrency = GetIntValue("CharacterSlotCurrency");
            VaultChestCost = GetIntValue("VaultChestCost");
            MaxStackablePotions = GetIntValue("MaxStackablePotions");
            PotionPurchaseCooldown = GetIntValue("PotionPurchaseCooldown");
            PotionPurchaseCostCooldown = GetIntValue("PotionPurchaseCostCooldown");
            DisableRegistration = GetBoolValue("DisableRegist");
            MysteryBoxRefresh = GetIntValue("MysteryBoxRefresh");
            MaxPetCount = GetIntValue("MaxPetCount");
            Accounts = new NewAccounts(elem.Element("NewAccounts"));
            Characters = new NewCharacters(elem.Element("NewCharacters"));

            InventorySize = GetIntValue("InventorySize");
            if (InventorySize == 0) InventorySize = 20;

            if (Exists("PotionPurchaseCosts"))
            {
                var potCosts = elem.Element("PotionPurchaseCosts");
                var potCostList = new List<int>();
                foreach (var e in potCosts.XPathSelectElements("//cost"))
                {
                    int.TryParse(e.Value, out var cost);
                    potCostList.Add(cost);
                }
                PotionPurchaseCosts = potCostList.ToArray();
            }
        }
    }

    public class NewAccounts : InitSettings
    {
        public int Gold { get; }
        public int Fame { get; }
        public int Onrane { get; }
        public int Kantos { get; }
        public int RaidToken { get; }
        public bool ClassesUnlocked { get; }
        public bool SkinsUnlocked { get; }
        public int PetYardType { get; }
        public int VaultCount { get; }
        public int MaxCharSlot { get; }
        public int Lootbox1 { get; }
        public int Lootbox2 { get; }
        public int Lootbox3 { get; }
        public int Lootbox4 { get; }
        public int Lootbox5 { get; }
        public int SorStorage { get; }
        public bool Striked { get; }
        public NewAccounts(XElement e)
        {
            elem = e;

            Gold = GetIntValue("Gold");
            Fame = GetIntValue("Fame");
            Onrane = GetIntValue("Onrane");
            Kantos = GetIntValue("Kantos");
            RaidToken = GetIntValue("RaidToken");
            Lootbox1 = GetIntValue("Lootbox1");
            Lootbox2 = GetIntValue("Lootbox2");
            Lootbox3 = GetIntValue("Lootbox3");
            Lootbox4 = GetIntValue("Lootbox4");
            Lootbox5 = GetIntValue("Lootbox5");
            ClassesUnlocked = GetBoolValue("ClassesUnlocked");
            SkinsUnlocked = GetBoolValue("SkinsUnlocked");
            PetYardType = GetIntValue("PetYardType");
            VaultCount = GetIntValue("VaultCount");
            MaxCharSlot = GetIntValue("MaxCharSlot");
            SorStorage = GetIntValue("SorStorage");
            Striked = GetBoolValue("Striked");
        }
    }

    public class NewCharacters : InitSettings
    {
        public bool Maxed { get; }
        public int Level { get; }

        public NewCharacters(XElement e)
        {
            elem = e;

            Maxed = GetBoolValue("Maxed");
            Level = GetIntValue("Level");
        }
    }

    public class InitSettings
    {
        protected XElement elem;

        protected bool Exists(string element)
        {
            return elem.Element(element) != null;
        }

        protected int GetIntValue(string element)
        {
            return Exists(element) ? int.Parse(elem.Element(element).Value) : 0;
        }

        protected bool GetBoolValue(string element)
        {
            return Exists(element) ? (elem.Element(element).Value.Equals("1")) : false;
        }

        protected string GetStringValue(string element)
        {
            return Exists(element) ? elem.Element(element).Value : "";
        }
    }
}
