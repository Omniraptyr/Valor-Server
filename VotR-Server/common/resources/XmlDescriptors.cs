using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace common.resources
{
    public enum ItemType
    {
        Weapon,
        Ability,
        Armor,
        Ring,
        Potion,
        StatPot,
        Other,
        None
    }

    public enum CurrencyType
    {
        Gold = 0,
        Fame = 1,
        GuildFame = 2,
        Tokens = 3,
        Onrane = 4,
        Kantos = 5
    }

    [Flags]
    public enum ConditionEffects : ulong
    {
        Dead =              1 << 0,
        Quiet =             1 << 1,
        Weak =              1 << 2,
        Slowed =            1 << 3,
        Sick =              1 << 4,
        Dazed =             1 << 5,
        Stunned =           1 << 6,
        Blind =             1 << 7,
        Hallucinating =     1 << 8,
        Drunk =             1 << 9,
        Confused =          1 << 10,
        StunImmume =        1 << 11,
        Invisible =         1 << 12,
        Paralyzed =         1 << 13,
        Speedy =            1 << 14,
        Bleeding =          1 << 15,
        ArmorBreakImmune =  1 << 16,
        Healing =           1 << 17,
        Damaging =          1 << 18,
        Berserk =           1 << 19,
        Paused =            1 << 20,
        Stasis =            1 << 21,
        StasisImmune =      1 << 22,
        Invincible =        1 << 23,
        Invulnerable =      1 << 24,
        Armored =           1 << 25,
        ArmorBroken =       1 << 26,
        Hexed =             1 << 27,
        NinjaSpeedy =       1 << 28,
        Unstable =          1 << 29,
        Darkness =          1 << 30,
        SlowedImmune =      (ulong) 1 << 31,
        DazedImmune =       (ulong) 1 << 32,
        ParalyzeImmune =    (ulong) 1 << 33,
        Petrify =           (ulong) 1 << 34,
        PetrifyImmune =     (ulong) 1 << 35,
        Swiftness =         (ulong) 1 << 36,
        Curse =             (ulong) 1 << 37,
        CurseImmune =       (ulong) 1 << 38,
        HPBoost =           (ulong) 1 << 39,
        MPBoost =           (ulong) 1 << 40,
        AttBoost =          (ulong) 1 << 41,
        DefBoost =          (ulong) 1 << 42,
        SpdBoost =          (ulong) 1 << 43,
        DexBoost =          (ulong) 1 << 44,
        VitBoost =          (ulong) 1 << 45,
        WisBoost =          (ulong) 1 << 46,
        Hidden =            (ulong) 1 << 47,
        Muted =             (ulong) 1 << 48,
        Empowered =         (ulong) 1 << 49,
        Bravery =           (ulong) 1 << 50,
        Exhausted =         (ulong)1 << 51,
        Surged =            (ulong)1 << 52,
        Corrupted =         (ulong)1 << 53,
        GraspofZol =        (ulong)1 << 54,
        SamuraiBerserk =    (ulong)1 << 55,
        DrakzixCharging =   (ulong)1 << 56,
        Relentless =        (ulong)1 << 58,
        Vengeance =         (ulong)1 << 59,
        ManaRecovery =      (ulong)1 << 60,
        Alliance =          (ulong)1 << 61,
        HealthRecovery =    (ulong)1 << 62
    }

    public enum ConditionEffectIndex
    {
        Dead = 0,
        Quiet = 1,
        Weak = 2,
        Slowed = 3,
        Sick = 4,
        Dazed = 5,
        Stunned = 6,
        Blind = 7,
        Hallucinating = 8,
        Drunk = 9,
        Confused = 10,
        StunImmune = 11,
        Invisible = 12,
        Paralyzed = 13,
        Speedy = 14,
        Bleeding = 15,
        ArmorBreakImmune = 16,
        Healing = 17,
        Damaging = 18,
        Berserk = 19,
        Paused = 20,
        Stasis = 21,
        StasisImmune = 22,
        Invincible = 23,
        Invulnerable = 24,
        Armored = 25,
        ArmorBroken = 26,
        Hexed = 27,
        NinjaSpeedy = 28,
        Unstable = 29,
        Darkness = 30,
        SlowedImmune = 31,
        DazedImmune = 32,
        ParalyzeImmune = 33,
        Petrify = 34,
        PetrifyImmune = 35,
        Swiftness = 36,
        Curse = 37,
        CurseImmune = 38,
        HPBoost = 39,
        MPBoost = 40,
        AttBoost = 41,
        DefBoost = 42,
        SpdBoost = 43,
        DexBoost = 44,
        VitBoost = 45,
        WisBoost = 46,
        Hidden = 47,
        Muted = 48,
        Empowered = 49,
        Bravery = 50,
        Exhausted = 51,
        Surged = 52,
        Corrupted = 53,
        GraspofZol = 54,
        SamuraiBerserk = 55,
        DrakzixCharging = 56,
        Relentless = 58,
        Vengeance = 59,
        ManaRecovery = 60,
        Alliance = 61,
        HealthRecovery = 62
    }

    public class ConditionEffect
    {
        public ConditionEffectIndex Effect { get; set; }
        public int DurationMS { get; set; }
        public float Range { get; set; }
        public ConditionEffect() { }
        public ConditionEffect(XElement elem, bool isCondChance = false) {
            Effect = (ConditionEffectIndex)Enum.Parse(typeof(ConditionEffectIndex),
                isCondChance ?
                    elem.Attribute("effect") != null ?
                         elem.Attribute("effect").Value.Replace(" ", "")
                         : string.Empty
                    : elem.Value.Replace(" ", ""));
            if (elem.Attribute("duration") != null)
                DurationMS = (int)(float.Parse(elem.Attribute("duration").Value) * 1000);
            if (elem.Attribute("range") != null)
                Range = float.Parse(elem.Attribute("range").Value);
        }
    }
    public class LegendaryPower
    {
        public int PowerId { get; }
        public string Name { get; }
        public string Description { get; }
        public int Stats { get; }
        public int HPAmount { get; }
        public int MPAmount { get; }
        public int SurgeAmount { get; }

        public LegendaryPower(XElement elem)
        {
            if (elem.Attribute("stat") != null)
                Stats = Utils.FromString(elem.Attribute("stat").Value);
            if (elem.Attribute("id") != null)
                PowerId = Utils.FromString(elem.Attribute("id").Value);
            Name = elem.Element("Name").Value;
            Description = elem.Element("Description").Value;
            HPAmount = Utils.FromString(elem.Element("HP")?.Value ?? "0");
            MPAmount = Utils.FromString(elem.Element("MP")?.Value ?? "0");
            SurgeAmount = Utils.FromString(elem.Element("Surge")?.Value ?? "0");
        }
    }
    public class ProjectileDesc
    {
        public int BulletType { get; }
        public string ObjectId { get; }
        public int LifetimeMS { get; }
        public float Speed { get; }
        public int Size { get; }
        public int MinDamage { get; }
        public int MaxDamage { get; }

        public ConditionEffect[] Effects { get; set; }
        public KeyValuePair<ConditionEffect, double>[] CondChance { get; }

        public bool MultiHit { get; }
        public bool PassesCover { get; }
        public bool ArmorPiercing { get; }
        public bool ParticleTrail { get; }
        public bool Wavy { get; }
        public bool Parametric { get; }
        public bool Boomerang { get; }

        public float Amplitude { get; }
        public float Frequency { get; }
        public float Magnitude { get; }

        public ProjectileDesc(XElement elem)
        {
            XElement n;
            if (elem.Attribute("id") != null)
                BulletType = Utils.FromString(elem.Attribute("id").Value);
            ObjectId = elem.Element("ObjectId").Value;
            LifetimeMS = Utils.FromString(elem.Element("LifetimeMS")?.Value ?? "0");
            Speed = float.Parse(elem.Element("Speed").Value);
            if ((n = elem.Element("Size")) != null)
                Size = Utils.FromString(n.Value);

            var dmg = elem.Element("Damage");
            if (dmg != null)
                MinDamage = MaxDamage = Utils.FromString(dmg.Value);
            else
            {
                MinDamage = Utils.FromString(elem.Element("MinDamage").Value);
                MaxDamage = Utils.FromString(elem.Element("MaxDamage").Value);
            }

            List<ConditionEffect> effects = new List<ConditionEffect>();
            foreach (XElement i in elem.Elements("ConditionEffect"))
                effects.Add(new ConditionEffect(i));
            Effects = effects.ToArray();

            List<KeyValuePair<ConditionEffect, double>> condChance
                = new List<KeyValuePair<ConditionEffect, double>>();
            foreach (XElement i in elem.Elements("CondChance")) {
                condChance.Add(new KeyValuePair<ConditionEffect, double>(
                    new ConditionEffect(i, true),
                    double.Parse(i.Attribute("chance").Value)));
            }
            CondChance = condChance.ToArray();

            MultiHit = elem.Element("MultiHit") != null;
            PassesCover = elem.Element("PassesCover") != null;
            ArmorPiercing = elem.Element("ArmorPiercing") != null;
            ParticleTrail = elem.Element("ParticleTrail") != null;
            Wavy = elem.Element("Wavy") != null;
            Parametric = elem.Element("Parametric") != null;
            Boomerang = elem.Element("Boomerang") != null;

            n = elem.Element("Amplitude");
            if (n != null)
                Amplitude = float.Parse(n.Value);
            else
                Amplitude = 0;
            n = elem.Element("Frequency");
            if (n != null)
                Frequency = float.Parse(n.Value);
            else
                Frequency = 1;
            n = elem.Element("Magnitude");
            if (n != null)
                Magnitude = float.Parse(n.Value);
            else
                Magnitude = 3;
        }
    }

    public enum ActivateEffects
    {
        Shoot,
        DualShoot,
        StatBoostSelf,
        StatBoostAura,
        BulletNova,
        BulletNova2,
        ConditionEffectAura,
        ConditionEffectSelf,
        Heal,
        HealNova,
        Magic,
        MagicNova,
        Teleport,
        VampireBlast,
        Trap,
        StasisBlast,
        Decoy,
        Lightning,
        BurningLightning,
        PoisonGrenade,
        RemoveNegativeConditions,
        RemoveNegativeConditionsSelf,
        IncrementStat,
        PowerStat,
        Drake,
        PermaPet,
        Create,
        DazeBlast,
        ClearConditionEffectAura,
        ClearConditionEffectSelf,
        Dye,
        ShurikenAbility,
        TomeDamage,
        MultiDecoy,
        Mushroom,
        PearlAbility,
        BuildTower,
        MonsterToss,
        PartyAOE,
        MiniPot,
        Halo,
        Fame,
        SamuraiAbility,
        Summon,
        ChristmasPopper,
        Belt,
        Totem,
        UnlockPortal,
        CreatePet,
        Pet,
        UnlockSkin,
        GenericActivate,
        MysteryPortal,
        ChangeSkin,
        FixedStat,
        Backpack,
        XPBoost,
        LDBoost,
        LTBoost,
        UnlockEmote,
        HealingGrenade,
        PetSkin,
        Unlock,
        MysteryDyes,
        UnScroll,
        BlackScroll,
        RenamePet,
        IdScroll,
        BrownScroll,
        HealNovaSigil,
        SorForge,
        RevivementBox,
        NeonBox,
        DareFistBox,
        VorvBox,
        GPBox,
        RandomGold,
        EffectRandom,
        MayhemBox,
        SunshineBox,
        BlizzardBox,
        WigWeekBox,
        TreasureActivate,
        LootboxActivate,
        PetStoneActivate,
        DiceActivate,
        DDiceActivate,
        PLootboxActivate,
        MarksActivate,
        AscensionActivate,
        InsigniaActivate,
        Banner,
        SorMachine,
        SiphonAbility,
        OnraneActivate,
        RandomKantos,
        RandomOnrane,
        PoZPage,
        URandomOnrane,
        FameActivate,
        ActivateFragment,
        AsiHeal,
        AsiimovBox,
        NewCharSlot,
        RageReapBox,
        SamuraiAbility2,
        BronzeLockbox,
        BigStasisBlast,
        SpiderTrap,
        AstonAbility,
        RoyalTrap,
        OPBUFF,
        WARPAWNBUFF,
        SilentBox,
        CrimsonBox,
        FUnlockPortal,
        CreateGauntlet,
        Heal2,
        Magic2,
        SorConstruct,
        BurstInferno,
        AbbyConstruct,
        Torii,
        JacketAbility,
        SorActivate,
        TalismanAbility

    }

    public class ActivateEffect
    {
        public ActivateEffects Effect { get; }
        public int Stats { get; }
        public int Amount { get; }
        public int Amount2 { get; }
        public float Range { get; }
        public float DurationSec { get; }
        public int DurationMS { get; }
        public int DurationMS2 { get; private set; }
        public int DurationMSAlt { get; }
        public ConditionEffectIndex? ConditionEffect { get; }
        public ConditionEffectIndex? CheckExistingEffect { get; }
        public float EffectDuration { get; }
        public int MaximumDistance { get; }
        public float Radius { get; }
        public int TotalDamage { get; }
        public int ImpactDamage { get; }
        public int ThrowTime { get; }
        public string ObjectId { get; }
        public string ObjectId2 { get; private set; }
        public int AngleOffset { get; }
        public int MaxTargets { get; }
        public string Id { get; }
        public string DungeonName { get; }
        public string LockedName { get; }
        public uint Color { get; }
        public ushort SkinType { get; }
        public int SkinType2 { get; }
        public int Size { get; }
        public bool NoStack { get; }
        public bool UseWisMod { get; }
        public string Target { get; }
        public string Center { get; }
        public int VisualEffect { get; }
        public bool Players { get; }
        public ushort ObjType { get; }

        public ActivateEffect(XElement elem)
        {
            Effect = (ActivateEffects)Enum.Parse(typeof(ActivateEffects), elem.Value);
            if (elem.Attribute("stat") != null)
                Stats = Utils.FromString(elem.Attribute("stat").Value);

            if (elem.Attribute("amount") != null)
                Amount = Utils.FromString(elem.Attribute("amount").Value);

            if (elem.Attribute("amount2") != null)
                Amount2 = Utils.FromString(elem.Attribute("amount2").Value);

            if (elem.Attribute("range") != null)
                Range = float.Parse(elem.Attribute("range").Value);
            if (elem.Attribute("duration") != null)
            {
                DurationSec = float.Parse(elem.Attribute("duration").Value);
                DurationMS = (int) (DurationSec * 1000);
            }

            if (elem.Attribute("duration2") != null)
                DurationMS = (int)(float.Parse(elem.Attribute("duration2").Value) * 1000);

            if (elem.Attribute("durationAlt") != null)
                DurationMSAlt = (int)(float.Parse(elem.Attribute("durationAlt").Value) * 1000);

            if (elem.Attribute("effect") != null)
            {
                if (Enum.TryParse(elem.Attribute("effect").Value.Replace(" ", ""), true, out ConditionEffectIndex condEff))
                    ConditionEffect = condEff;
            }
            if (elem.Attribute("checkExistingEffect") != null)
            {
                if (Enum.TryParse(elem.Attribute("checkExistingEffect").Value, true, out ConditionEffectIndex condEff))
                    CheckExistingEffect = condEff;
            }
            if (elem.Attribute("condEffect") != null)
            {
                if (Enum.TryParse(elem.Attribute("condEffect").Value.Replace(" ", ""), true, out ConditionEffectIndex condEff))
                    ConditionEffect = condEff;
            }

            if (elem.Attribute("condDuration") != null)
                EffectDuration = float.Parse(elem.Attribute("condDuration").Value);

            if (elem.Attribute("maxDistance") != null)
                MaximumDistance = Utils.FromString(elem.Attribute("maxDistance").Value);

            if (elem.Attribute("radius") != null)
                Radius = float.Parse(elem.Attribute("radius").Value);

            if (elem.Attribute("totalDamage") != null)
                TotalDamage = Utils.FromString(elem.Attribute("totalDamage").Value);

            if (elem.Attribute("impactDamage") != null)
                ImpactDamage = Utils.FromString(elem.Attribute("impactDamage").Value);

            if (elem.Attribute("throwTime") != null)
                ThrowTime = (int)(float.Parse(elem.Attribute("throwTime").Value) * 1000);

            if (elem.Attribute("objectId") != null)
                ObjectId = elem.Attribute("objectId").Value;
            if (elem.Attribute("objectId2") != null)
                ObjectId = elem.Attribute("objectId2").Value;

            if (elem.Attribute("angleOffset") != null)
                AngleOffset = Utils.FromString(elem.Attribute("angleOffset").Value);

            if (elem.Attribute("maxTargets") != null)
                MaxTargets = Utils.FromString(elem.Attribute("maxTargets").Value);

            if (elem.Attribute("id") != null)
                Id = elem.Attribute("id").Value;

            if (elem.Attribute("dungeonName") != null)
                DungeonName = elem.Attribute("dungeonName").Value;

            if (elem.Attribute("lockedName") != null)
                LockedName = elem.Attribute("lockedName").Value;

            if (elem.Attribute("color") != null)
                Color = uint.Parse(elem.Attribute("color").Value.Substring(2), NumberStyles.AllowHexSpecifier);

            if (elem.Attribute("skinType") != null)
                SkinType = ushort.Parse(elem.Attribute("skinType").Value.Substring(2), NumberStyles.AllowHexSpecifier);

            if (elem.Attribute("skinType2") != null)
                SkinType2 = int.Parse(elem.Attribute("skinType2").Value);

            if (elem.Attribute("size") != null)
                Size = int.Parse(elem.Attribute("size").Value);

            if (elem.Attribute("noStack") != null)
                NoStack = elem.Attribute("noStack").Value.Equals("true");

            if (elem.Attribute("useWisMod") != null)
                UseWisMod = elem.Attribute("useWisMod").Value.Equals("true");

            if (elem.Attribute("target") != null)
                Target = elem.Attribute("target").Value;

            if (elem.Attribute("center") != null)
                Center = elem.Attribute("center").Value;

            if (elem.Attribute("visualEffect") != null)
                VisualEffect = Utils.FromString(elem.Attribute("visualEffect").Value);

            if (elem.Attribute("players") != null)
                Players = elem.Attribute("players").Value.Equals("true");

            if (elem.Attribute("objType") != null)
                ObjType = ushort.Parse(elem.Attribute("objType").Value.Substring(2), NumberStyles.AllowHexSpecifier);
        }
    }
    public class Setpiece
    {
        public string Type { get; }
        public ushort Slot { get; }
        public ushort ItemType { get; }

        public Setpiece(XElement elem)
        {
            Type = elem.Value;
            Slot = ushort.Parse(elem.Attribute("slot").Value);
            ItemType = ushort.Parse(elem.Attribute("itemtype").Value.Substring(2), NumberStyles.AllowHexSpecifier);
        }
    }


    public class PortalDesc : ObjectDesc
    {
        public int Timeout { get; }
        public bool NexusPortal { get; }
        public bool Locked { get; }

        public PortalDesc(ushort type, XElement elem) : base(type, elem)
        {
            XElement n;

            if (elem.Element("NexusPortal") != null)
                NexusPortal = true;

            Timeout = (n = elem.Element("Timeout")) != null ? 
                int.Parse(n.Value) : 30;

            Locked = elem.Element("LockedPortal") != null;
        }
    }
    public class Item
    {
        public ushort ObjectType { get; }
        public string ObjectId { get; }
        public int SlotType { get; }
        public int Tier { get; }
        public string Description { get; }
        public float RateOfFire { get; }
        public bool Usable { get; }
        public int BagType { get; }
        public int MpCost { get; }
        public int HpCost { get; }
        public int SurgeCost { get; }
        public bool Legendary { get; }
        public bool Fabled { get; }
        public bool Shard { get; }
        public bool Fragment { get; }
        public bool Ascended { get; }
        public int MpEndCost { get; }
        public int FameBonus { get; }
        public int SurgeMod { get; }
        public int NumProjectiles { get; }
        public float ArcGap { get; }
        public float ArcGap1 { get; }
        public float ArcGap2 { get; }
        public int NumProjectiles1 { get; }
        public int NumProjectiles2 { get; }
        public bool DualShooting { get; }
        public bool Consumable { get; }
        public bool InvUse { get; }
        public bool Potion { get; }
        public string DisplayId { get; }
        public string DisplayName { get; }
        public string SuccessorId { get; }
        public bool Soulbound { get; }
        public bool Undead { get; }
        public bool PUndead { get; }
        public bool SUndead { get; }
        public float Cooldown { get; }
        public bool Resurrects { get; }
        public int Texture1 { get; }
        public int Texture2 { get; }
        public bool Secret { get; }
        public int Doses { get; }
        public PFamily Family { get; }
        public PRarity Rarity { get; }

        public KeyValuePair<int, int>[] StatsBoost { get; }
        public ActivateEffect[] ActivateEffects { get; }
        public ProjectileDesc[] Projectiles { get; }
        public LegendaryPower[] Legend { get; }
        public KeyValuePair<int, int>[] StatsBoostPerc { get; }
        public KeyValuePair<string, int>[] Steal { get; }
        public KeyValuePair<int, int>[] StatReq { get; }
        public KeyValuePair<string, int>[] EffectEquip { get; }

        public Item(ushort type, XElement elem)
        {
            XElement n;

            ObjectType = type;

            ObjectId = elem.Attribute(XName.Get("id")).Value;

            SlotType = Utils.FromString(elem.Element("SlotType").Value);

            if ((n = elem.Element("Tier")) != null)
                try
                {
                    Tier = Utils.FromString(n.Value);
                }
                catch
                {
                    Tier = -1;
                }
            else
                Tier = -1;

            Description = elem.Element("Description").Value;

            RateOfFire = (n = elem.Element("RateOfFire")) != null ? float.Parse(n.Value) : 1;

            Usable = elem.Element("Usable") != null;

            BagType = (n = elem.Element("BagType")) != null ? Utils.FromString(n.Value) : 0;

            MpCost = (n = elem.Element("MpCost")) != null ? Utils.FromString(n.Value) : 0;

            HpCost = (n = elem.Element("HpCost")) != null ? Utils.FromString(n.Value) : 0;

            Legendary = elem.Element("Legendary") != null;

            Fabled = elem.Element("Fabled") != null;

            Shard = elem.Element("Shard") != null;

            Fragment = elem.Element("Fragment") != null;

            Ascended = elem.Element("Ascended") != null;

            SurgeCost = (n = elem.Element("SurgeCost")) != null ? Utils.FromString(n.Value) : 0;

            MpEndCost = (n = elem.Element("MpEndCost")) != null ? Utils.FromString(n.Value) : 0;

            FameBonus = (n = elem.Element("FameBonus")) != null ? Utils.FromString(n.Value) : 0;

            NumProjectiles = (n = elem.Element("NumProjectiles")) != null ? Utils.FromString(n.Value) : 1;

            SurgeMod = (n = elem.Element("SurgeMod")) != null ? Utils.FromString(n.Value) : 0;

            ArcGap = (n = elem.Element("ArcGap")) != null ? Utils.FromString(n.Value) : 11.25f;

            ArcGap1 = (n = elem.Element("ArcGap1")) != null ? Utils.FromString(n.Value) : 11.25f;

            ArcGap2 = (n = elem.Element("ArcGap2")) != null ? Utils.FromString(n.Value) : 11.25f;

            NumProjectiles1 = (n = elem.Element("NumProjectiles1")) != null ? Utils.FromString(n.Value) : 1;

            NumProjectiles2 = (n = elem.Element("NumProjectiles2")) != null ? Utils.FromString(n.Value) : 1;

            DualShooting = elem.Element("DualShooting") != null;

            Consumable = elem.Element("Consumable") != null;

            InvUse = elem.Element("InvUse") != null;

            Potion = elem.Element("Potion") != null;

            DisplayId = (n = elem.Element("DisplayId")) != null ? n.Value : null;

            DisplayName = GetDisplayName();

            Doses = (n = elem.Element("Doses")) != null ? Utils.FromString(n.Value) : 0;

            Family = PetDesc.GetFamily(elem.Element("PetFamily"));
            Rarity = PetDesc.GetRarity(elem.Element("Rarity"));

            SuccessorId = (n = elem.Element("SuccessorId")) != null ? n.Value : null;

            Soulbound = elem.Element("Soulbound") != null;

            Undead = elem.Element("Undead") != null;

            PUndead = elem.Element("PUndead") != null;

            SUndead = elem.Element("SUndead") != null;

            Secret = elem.Element("Secret") != null;

            Cooldown = (n = elem.Element("Cooldown")) != null ? float.Parse(n.Value) : 0;

            Resurrects = elem.Element("Resurrects") != null;

            Texture1 = (n = elem.Element("Tex1")) != null ? Convert.ToInt32(n.Value, 16) : 0;

            Texture2 = (n = elem.Element("Tex2")) != null ? Convert.ToInt32(n.Value, 16) : 0;

            var stats = new List<KeyValuePair<int, int>>();
            var percStats = new List<KeyValuePair<int, int>>();
            StatsBoost = stats.ToArray();
            StatsBoostPerc = percStats.ToArray();
            foreach (var i in elem.Elements("ActivateOnEquip")) {
                switch (i.Value) {
                    case "IncrementStat":
                        stats.Add(new KeyValuePair<int, int>(int.Parse(i.Attribute("stat").Value), int.Parse(i.Attribute("amount").Value)));
                        StatsBoost = stats.ToArray();
                        break;
                    /*case "IncrStatPerc":
                        percStats.Add(new KeyValuePair<int, int>(int.Parse(i.Attribute("stat").Value), int.Parse(i.Attribute("amount").Value)));
                        StatsBoostPerc = percStats.ToArray();
                        break;*/
                }
            }

            ActivateEffects = elem.Elements("Activate").Select(i => new ActivateEffect(i)).ToArray();

            Projectiles = elem.Elements("Projectile").Select(i => new ProjectileDesc(i)).ToArray();

            StatReq = elem.Elements("StatReq")
                .Select(i => new KeyValuePair<int, int>
                    (int.Parse(i.Attribute("stat").Value), int.Parse(i.Attribute("amount").Value))).ToArray();

            Legend = elem.Elements("Legend").Select(i => new LegendaryPower(i)).ToArray();

            Steal = elem.Elements("Steal")
                .Select(i => new KeyValuePair<string, int>
                    (i.Attribute("type").Value, int.Parse(i.Attribute("amount").Value))).ToArray();

            EffectEquip = elem.Elements("EffectEquip")
                .Select(i => new KeyValuePair<string, int>
                    (i.Attribute("effect").Value, int.Parse(i.Attribute("delay").Value))).ToArray();
        }

        public override string ToString()
        {
            return ObjectId;
        }


        // this gets the item name players can see in their client
        private string GetDisplayName()
        {
            if (DisplayId == null)
            {
                return ObjectId;
            }

            if (DisplayId[0].Equals('{'))
            {
                return ObjectId;
            }

            return DisplayId;
        }
    }
    public class EquipmentSetDesc
    {
        public ushort Type { get; private set; }
        public string Id { get; private set; }

        public ActivateEffect[] ActivateOnEquipAll { get; private set; }
        public Setpiece[] Setpieces { get; private set; }

        public static EquipmentSetDesc FromElem(ushort type, XElement setElem, out ushort skinType)
        {
            skinType = 0;

            var activate = new List<ActivateEffect>();
            foreach (XElement i in setElem.Elements("ActivateOnEquipAll"))
            {
                var ae = new ActivateEffect(i);
                activate.Add(ae);

                if (ae.SkinType != 0)
                    skinType = ae.SkinType;
            }
                
            var setpiece = new List<Setpiece>();
            foreach (XElement i in setElem.Elements("Setpiece"))
                setpiece.Add(new Setpiece(i));

            var eqSet = new EquipmentSetDesc();
            eqSet.Type = type;
            eqSet.Id = setElem.Attribute("id").Value;
            eqSet.ActivateOnEquipAll = activate.ToArray();
            eqSet.Setpieces = setpiece.ToArray();

            return eqSet;
        }
    }

    public class Lootbox
    {
        public ushort Type { get; private set; }
        public string Id { get; private set; }
        public List<Tuple<double, List<CrateLoot>>> CrateLoot { get; private set; }

        public static Lootbox FromElem(ushort type, XElement elem)
        {

            var crateLoot = new List<Tuple<double, List<CrateLoot>>>();
            foreach (XElement i in elem.Elements("CrateLoot"))
            {
                var crateLootList = new List<CrateLoot>();
                foreach (XElement o in i.Elements("Loot"))
                    crateLootList.Add(new CrateLoot(o));
                crateLoot.Add(Tuple.Create(double.Parse(i.Attribute("chance").Value), crateLootList));
            }
            crateLoot.Sort((a, b) => a.Item1.CompareTo(b.Item1));

            var lootbox = new Lootbox();
            lootbox.Type = type;
            lootbox.Id = elem.Attribute("id").Value;
            lootbox.CrateLoot = crateLoot;
            return lootbox;
        }
       
    }

    public class SkinDesc
    {
        public ushort Type { get; private set; }
        public ObjectDesc ObjDesc { get; private set; }

        public ushort PlayerClassType { get; private set; }
        public ushort UnlockLevel { get; private set; }
        public bool Restricted { get; private set; }
        public bool Expires { get; private set; }
        public int Cost { get; private set; }
        public bool UnlockSpecial { get; private set; }
        public bool NoSkinSelect { get; private set; }
        public int Size { get; private set; }
        public string PlayerExclusive { get; private set; }

        public static SkinDesc FromElem(ushort type, XElement skinElem)
        {
            var pct = skinElem.Element("PlayerClassType");
            if (pct == null) return null;

            var sd = new SkinDesc();
            sd.Type = type;
            sd.ObjDesc = new ObjectDesc(type, skinElem);
            sd.PlayerClassType = (ushort)Utils.FromString(pct.Value);
            sd.Restricted = skinElem.Element("Restricted") != null;
            sd.Expires = skinElem.Element("Expires") != null;
            sd.UnlockSpecial = skinElem.Element("UnlockSpecial") != null;
            sd.NoSkinSelect = skinElem.Element("NoSkinSelect") != null;
            sd.PlayerExclusive = skinElem.Element("PlayerExclusive") == null ? 
                null : skinElem.Element("PlayerExclusive").Value;

            var ul = skinElem.Element("UnlockLevel");
            if (ul != null) sd.UnlockLevel = ushort.Parse(ul.Value);
            var cost = skinElem.Element("Cost");
            sd.Cost = cost != null ? int.Parse(cost.Value) : 1000;

            var size = skinElem.Attribute("size");
            if (size != null)
                sd.Size = Utils.FromString(size.Value);
            else
                sd.Size = 100;

            return sd;
        }
    }
    public enum CrateLootTypes
    {
        Item,
        TieredStrangifier,
        StrangePart,
        Skin
    }
    public class CrateLoot
    {
        public CrateLoot(XElement elem)
        {
            XAttribute n;
            Type = (CrateLootTypes)Enum.Parse(typeof(CrateLootTypes), elem.Value);
            if ((n = elem.Attribute("strange")) != null)
                Strange = (n.Value == "true");
            else
                Strange = false;
            if ((n = elem.Attribute("name")) != null)
                Name = n.Value;
            if ((n = elem.Attribute("minTier")) != null)
                MinTier = int.Parse(n.Value);
            if ((n = elem.Attribute("maxTier")) != null)
                MaxTier = int.Parse(n.Value);
            if ((n = elem.Attribute("tier")) != null)
                MinTier = MaxTier = int.Parse(n.Value);
            if ((n = elem.Attribute("series")) != null)
                Series = int.Parse(n.Value);
            else
                Series = 0;
            if ((n = elem.Attribute("premium")) != null)
                Premium = (n.Value == "true");
            else
                Premium = false;
            if ((n = elem.Attribute("unusual")) != null)
                Unusual = (n.Value == "true");
            else
                Unusual = false;
            if ((n = elem.Attribute("nameColor")) != null)
                NameColor = (uint)Utils.FromString(n.Value);
            else
                NameColor = 0xFFFFFF;
        }

        public CrateLootTypes Type { get; }
        public bool Strange { get; }
        public string Name { get; }
        public int MinTier { get; }
        public int MaxTier { get; }
        public int Series { get; }
        public bool Premium { get; }
        public bool Unusual { get; }
        public uint NameColor { get; }
    }
    public class SpawnCount
    {
        public int Mean { get; }
        public int StdDev { get; }
        public int Min { get; }
        public int Max { get; }

        public SpawnCount(XElement elem)
        {
            Mean = Utils.FromString(elem.Element("Mean").Value);
            StdDev = Utils.FromString(elem.Element("StdDev").Value);
            Min = Utils.FromString(elem.Element("Min").Value);
            Max = Utils.FromString(elem.Element("Max").Value);
        }
    }
    public class UnlockClass
    {
        public ushort? Type { get; }
        public ushort? Level { get; }
        public uint? Cost { get; }

        public UnlockClass(XElement elem)
        {
            XElement n;
            if ((n = elem.Element("UnlockLevel")) != null &&
                n.Attribute("type") != null &&
                n.Attribute("level") != null)
            {
                Type = (ushort) Utils.FromString(n.Attribute("type").Value);
                Level = (ushort) Utils.FromString(n.Attribute("level").Value);
            }
            if ((n = elem.Element("UnlockCost")) != null)
                Cost = (uint) Utils.FromString(n.Value);
        }
    }
    public class Stat
    {
        public string Type { get; }
        public int MaxValue { get; }
        public int StartingValue { get; }
        public int MinIncrease { get; }
        public int MaxIncrease { get; }

        public Stat(int index, XElement elem)
        {
            Type = StatIndexToName(index);

            var x = elem.Element(Type);
            if (x != null)
            {
                StartingValue = int.Parse(x.Value);
                MaxValue = int.Parse(x.Attribute("max").Value);
            }
            
            var y = elem.Elements("LevelIncrease");
            foreach (var s in y)
                if (s.Value == Type)
                {
                    MinIncrease = int.Parse(s.Attribute("min").Value);
                    MaxIncrease = int.Parse(s.Attribute("max").Value);
                    break;
                }
        }

        private static string StatIndexToName(int index)
        {
            switch (index)
            {
                case 0: return "MaxHitPoints";
                case 1: return "MaxMagicPoints";
                case 2: return "Attack";
                case 3: return "Defense";
                case 4: return "Speed";
                case 5: return "Dexterity";
                case 6: return "HpRegen";
                case 7: return "MpRegen";
                case 8: return "Might";
                case 9: return "Luck";
                case 10: return "Restoration";
                case 11: return "Protection";
            } return null;
        }
    }
    public class PlayerDesc : ObjectDesc
    {
        public int[] SlotTypes { get; }
        public ushort[] Equipment { get; }
        public Stat[] Stats { get; }
        public UnlockClass Unlock { get; }

        public PlayerDesc(ushort type, XElement elem) : base(type, elem)
        {
            SlotTypes = elem.Element("SlotTypes").Value.CommaToArray<int>();
            Equipment = elem.Element("Equipment").Value.CommaToArray<ushort>();
            Stats = new Stat[12];
            for (var i = 0; i < Stats.Length; i++)
                Stats[i] = new Stat(i, elem);
            if (elem.Element("UnlockLevel") != null ||
                elem.Element("UnlockCost") != null)
                Unlock = new UnlockClass(elem);
        }
    }
    public class ObjectDesc
    {
        public ushort ObjectType { get; }
        public string ObjectId { get; }
        public string DisplayId { get; }
        public string DungeonName { get; }
        public string Group { get; }
        public string Class { get; }
        public bool Character { get; }
        public bool Player { get; }
        public bool Enemy { get; }
        public bool OccupySquare { get; }
        public bool FullOccupy { get; }
        public bool EnemyOccupySquare { get; }
        public bool Static { get; }
        public bool BlocksSight { get; }
        public bool NoMiniMap { get; }
        public bool ProtectFromGroundDamage { get; }
        public bool ProtectFromSink { get; }
        public bool Flying { get; }
        public bool ShowName { get; }
        public bool DontFaceAttacks { get; }
        public int MinSize { get; }
        public int MaxSize { get; }
        public int SizeStep { get; }
        public TagList Tags { get; }
        public ProjectileDesc[] Projectiles { get; }
        public int MaxHP { get; }
        public int Defense { get; }
        public string Terrain { get; }
        public float SpawnProbability { get; }
        public SpawnCount Spawn { get; }
        public bool Cube { get; }
        public bool God { get; }
        public bool Quest { get; }
        public bool Lootdrop { get; }
        public bool Elitedrop { get; }
        public bool UElitedrop { get; }
        public bool ResetSS { get; }
        public int? Level { get; }
        public bool ArmorBreakImmune { get; }
        public bool CurseImmune { get; }
        public bool DazedImmune { get; }
        public bool ParalyzeImmune { get; }
        public bool PetrifyImmune { get; }
        public bool SlowedImmune { get; }
        public bool StasisImmune { get; }
        public bool StunImmune { get; }
        public bool Oryx { get; }
        public bool Hero { get; }
        public int? PerRealmMax { get; }
        public float? ExpMultiplier { get; }    //Exp gained = level total / 10 * multi
        public bool Restricted { get; }
        public bool IsPet { get; }
        public bool IsPetSkin { get; }
        public bool IsPetProjectile { get; }
        public bool IsPetBehavior { get; }
        public bool IsPetAbility { get; }
        public bool Connects { get; }
        public bool TrollWhiteBag { get; }

        public ObjectDesc(ushort type, XElement elem)
        {
            XElement n;
            ObjectType = type;
            ObjectId = elem.Attribute("id").Value;
            Class = elem.Element("Class").Value;
            Group = (n = elem.Element("Group")) != null ? n.Value : null;
            DisplayId = (n = elem.Element("DisplayId")) != null ? n.Value : null;
            DungeonName = (n = elem.Element("DungeonName")) != null ? n.Value : DisplayId;
            Character = Class.Equals("Character");
            Player = elem.Element("Player") != null;
            Enemy = elem.Element("Enemy") != null;
            OccupySquare = elem.Element("OccupySquare") != null;
            FullOccupy = elem.Element("FullOccupy") != null;
            EnemyOccupySquare = elem.Element("EnemyOccupySquare") != null;
            Static = elem.Element("Static") != null;
            BlocksSight = elem.Element("BlocksSight") != null;
            NoMiniMap = elem.Element("NoMiniMap") != null;
            ProtectFromGroundDamage = elem.Element("ProtectFromGroundDamage") != null;
            ProtectFromSink = elem.Element("ProtectFromSink") != null;
            Flying = elem.Element("Flying") != null;
            ShowName = elem.Element("ShowName") != null;
            DontFaceAttacks = elem.Element("DontFaceAttacks") != null;

            if (elem.Element("Restricted") != null)
                Restricted = true;

            if ((n = elem.Element("Size")) != null)
            {
                MinSize = MaxSize = Utils.FromString(n.Value);
                SizeStep = 0;
            }
            else
            {
                MinSize = (n = elem.Element("MinSize")) != null ? 
                    Utils.FromString(n.Value) : 100;
                MaxSize = (n = elem.Element("MaxSize")) != null ? 
                    Utils.FromString(n.Value) : 100;
                SizeStep = (n = elem.Element("SizeStep")) != null ? 
                    Utils.FromString(n.Value) : 0;
            }

            Projectiles = elem.Elements("Projectile")
                .Select(i => new ProjectileDesc(i)).ToArray();

            if ((n = elem.Element("MaxHitPoints")) != null)
                MaxHP = Utils.FromString(n.Value);
            if ((n = elem.Element("Defense")) != null)
                Defense = Utils.FromString(n.Value);
            if ((n = elem.Element("Terrain")) != null)
                Terrain = n.Value;
            if ((n = elem.Element("SpawnProbability")) != null)
                SpawnProbability = float.Parse(n.Value);
            if ((n = elem.Element("Spawn")) != null)
                Spawn = new SpawnCount(n);

            God = elem.Element("God") != null;
            Cube = elem.Element("Cube") != null;
            Quest = elem.Element("Quest") != null;
            Lootdrop = elem.Element("Lootdrop") != null;
            Elitedrop = elem.Element("Elitedrop") != null;
            UElitedrop = elem.Element("UElitedrop") != null;
            ResetSS = elem.Element("ResetSS") != null;
            if ((n = elem.Element("Level")) != null)
                Level = Utils.FromString(n.Value);
            else
                Level = null;

            Tags = new TagList();
            if (elem.Elements("Tag").Any())
                foreach (XElement i in elem.Elements("Tag"))
                    Tags.Add(new Tag(i));

            ArmorBreakImmune = elem.Element("ArmorBreakImmune") != null;
            CurseImmune = elem.Element("CurseImmune") != null;
            DazedImmune = elem.Element("DazedImmune") != null;
            ParalyzeImmune = elem.Element("ParalyzeImmune") != null;
            PetrifyImmune = elem.Element("PetrifyImmune") != null;
            SlowedImmune = elem.Element("SlowedImmune") != null;
            StasisImmune = elem.Element("StasisImmune") != null;
            StunImmune = elem.Element("StunImmune") != null;

            Oryx = elem.Element("Oryx") != null;
            Hero = elem.Element("Hero") != null;
            
            if ((n = elem.Element("PerRealmMax")) != null)
                PerRealmMax = Utils.FromString(n.Value);
            else
                PerRealmMax = null;
            if ((n = elem.Element("XpMult")) != null)
                ExpMultiplier = float.Parse(n.Value);
            else
                ExpMultiplier = null;

            IsPet = elem.Element("Pet") != null;
            IsPetSkin = elem.Element("PetSkin") != null;
            IsPetProjectile = elem.Element("PetProjectile") != null;
            IsPetBehavior = elem.Element("PetBehavior") != null;
            IsPetAbility = elem.Element("PetAbility") != null;
            Connects = elem.Element("Connects") != null;
            TrollWhiteBag = elem.Element("TrollWhiteBag") != null;
        }
    }
    public class TagList : List<Tag>
    {
        public bool ContainsTag(string name)
        {
            return this.Any(i => i.Name == name);
        }

        public string TagValue(string name, string value)
        {
            return
                (from i in this where i.Name == name where i.Values.ContainsKey(value) select i.Values[value])
                    .FirstOrDefault();
        }
    }
    public class Tag
    {
        public Tag(XElement elem)
        {
            Name = elem.Attribute("name").Value;
            Values = new Dictionary<string, string>();
            foreach (XElement i in elem.Elements())
            {
                if (Values.ContainsKey(i.Name.ToString()))
                    Values.Remove(i.Name.ToString());
                Values.Add(i.Name.ToString(), i.Value);
            }
        }

        public string Name { get; }
        public Dictionary<string, string> Values { get; }
    }

    public class TileDesc
    {
        public ushort ObjectType { get; }
        public string ObjectId { get; }
        public bool NoWalk { get; }
        public bool Damaging { get; }
        public int MinDamage { get; }
        public int MaxDamage { get; }
        public float Speed { get; }
        public bool Push { get; }
        public float PushX { get; }
        public float PushY { get; }

        public TileDesc(ushort type, XElement elem)
        {
            XElement n;
            ObjectType = type;
            ObjectId = elem.Attribute("id").Value;
            NoWalk = elem.Element("NoWalk") != null;
            if ((n = elem.Element("MinDamage")) != null)
            {
                MinDamage = Utils.FromString(n.Value);
                Damaging = true;
            }
            if ((n = elem.Element("MaxDamage")) != null)
            {
                MaxDamage = Utils.FromString(n.Value);
                Damaging = true;
            }
            if ((n = elem.Element("Speed")) != null)
                Speed = float.Parse(n.Value);
            Push = elem.Element("Push") != null;
            if (Push)
            {
                var anim = elem.Element("Animate");
                if (anim.Attribute("dx") != null)
                    PushX = float.Parse(anim.Attribute("dx").Value);
                if (elem.Attribute("dy") != null)
                    PushY = float.Parse(anim.Attribute("dy").Value);
            }
        }
    }

    public class DungeonDesc
    {
        public string Name { get; }
        public ushort PortalId { get; }
        public int Background { get; }
        public bool AllowTeleport { get; }
        public string Json { get; }

        public DungeonDesc(XElement elem)
        {
            Name = elem.Attribute("name").Value;
            PortalId = (ushort)Utils.FromString(elem.Attribute("type").Value);
            Background = Utils.FromString(elem.Element("Background").Value);
            AllowTeleport = elem.Element("AllowTeleport") != null;
            Json = elem.Element("Json").Value;
        }
    }
}