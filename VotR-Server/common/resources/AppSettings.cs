using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using log4net;

namespace common.resources
{
    public class AppSettings : InitSettings
    {
        static ILog log = LogManager.GetLogger(typeof(AppSettings));

        public string MenuMusic { get; private set; }
        public string DeadMusic { get; private set; }
        public int EditorMinRank { get; private set; }
        public int CharacterSlotCost { get; private set; }
        public int CharacterSlotCurrency { get; private set; }
        public int VaultChestCost { get; private set; }
        public int InventorySize { get; private set; }
        public int MaxStackablePotions { get; private set; }
        public int PotionPurchaseCooldown { get; private set; }
        public int PotionPurchaseCostCooldown { get; private set; }
        public int[] PotionPurchaseCosts { get; private set; }
        public bool DisableRegistration { get; private set; }
        public int MysteryBoxRefresh { get; private set; }
        public int MaxPetCount { get; private set; }
        public NewAccounts Accounts { get; private set; }
        public NewCharacters Characters { get; private set; }

        public AppSettings(string path)
        {
            log.Info("Loading app settings...");

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
                    int cost = 0;
                    int.TryParse(e.Value, out cost);
                    potCostList.Add(cost);
                }
                PotionPurchaseCosts = potCostList.ToArray();
            }
        }
    }

    public class NewAccounts : InitSettings
    {
        public int Gold { get; private set; }
        public int Fame { get; private set; }
        public int Onrane { get; private set; }
        public int Kantos { get; private set; }
        public int RaidToken { get; private set; }
        public bool ClassesUnlocked { get; private set; }
        public bool SkinsUnlocked { get; private set; }
        public int PetYardType { get; private set; }
        public int VaultCount { get; private set; }
        public int MaxCharSlot { get; private set; }
        public int Lootbox1 { get; private set; }
        public int Lootbox2 { get; private set; }
        public int Lootbox3 { get; private set; }
        public int Lootbox4 { get; private set; }
        public int Lootbox5 { get; private set; }
        public int SorStorage { get; private set; }
        public bool Striked { get; private set; }
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
        public bool Maxed { get; private set; }
        public int Level { get; private set; }

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
