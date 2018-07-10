using common.resources;
using wServer.realm.entities;
using System;
using wServer.networking.packets.outgoing;
namespace wServer.realm
{
    public class StatsManager
    {
        internal const int NUM_STAT_TYPES = 15; // change this to add more stats
        private const float MIN_ATTACK_MULT = 0.5f;
        private const float MAX_ATTACK_MULT = 2f;
        private const float MIN_ATTACK_FREQ = 0.0015f;
        private const float MAX_ATTACK_FREQ = 0.008f;

        internal readonly Player Owner;
        internal readonly BaseStatManager Base;
        internal readonly BoostStatManager Boost;


        private readonly SV<int>[] _stats;

        public int this[int index] => Base[index] + Boost[index] + PWNum(index);

        public StatsManager(Player owner)
        {
            Owner = owner;
            Base = new BaseStatManager(this);
            Boost = new BoostStatManager(this);


            _stats = new SV<int>[NUM_STAT_TYPES];
            for (var i = 0; i < NUM_STAT_TYPES; i++)
                _stats[i] = new SV<int>(Owner, GetStatType(i), this[i], i != 0 && i != 1); // make maxHP and maxMP global update
        }

        public void ReCalculateValues(InventoryChangedEventArgs e = null)
        {
            Base.ReCalculateValues(e);
            Boost.ReCalculateValues(e);

            for (var i = 0; i < _stats.Length; i++)
                _stats[i].SetValue(this[i]);
        }

        internal void StatChanged(int index)
        {
            _stats[index].SetValue(this[index]);
        }

        public int GetAttackDamage(int min, int max, bool isAbility = false)
        {
            var ret = isDoubleDamage() * Owner.Client.Random.NextIntRange((uint)min, (uint)max) * GetAttackMult(isAbility) * CriticalModifier() + VengeanceDamage() + RelentlessDamage() + KaraDamage() + MoonLightDamage() + RageDamage();
            //Log.Info($"Dmg: {ret}");
            return (int)ret;
        }

        public float GetAttackMult(bool isAbility)
        {
            if (isAbility)
                return 1;

            if (Owner.HasConditionEffect(ConditionEffects.Weak))
                return MIN_ATTACK_MULT;

            var mult = MIN_ATTACK_MULT + (this[2] / 75f) * (MAX_ATTACK_MULT - MIN_ATTACK_MULT);
            if (Owner.HasConditionEffect(ConditionEffects.Damaging))
                mult *= 1.5f;

            if (Owner.CheckMerc())
                mult *= 1.15f;

            if (Owner.CheckMerc() && Owner.HasConditionEffect(ConditionEffects.Damaging))
                mult *= 1.65f;

            return mult;
        }
        public int RelentlessDamage()
        {
            if (Owner.HasConditionEffect(ConditionEffects.Relentless))
                return Owner.Surge * 6;
            return 0;
        }

        public int RageDamage()
        {
            if (Owner.Mark == 3)
                return Owner.Surge * 3;
            return 0;
        }

        public int VengeanceDamage()
        {
            if (Owner.HasConditionEffect(ConditionEffects.Vengeance))
                return (Owner.Stats[0] - Owner.HP) / 2;
            return 0;
        }
        private float CriticalModifier()
        {
            Random rnd = new Random();
            int luckNm = rnd.Next(1, 1001);
            var ret = 1.0f;
            if (luckNm <= Owner.Stats[9])
            {
                ret *= MightMultiplier();
                Owner.Client.SendPacket(new CriticalDamage()
                {
                    IsCritical = true,
                    CriticalHit = ret
                });
            }
            else
            {
                Owner.Client.SendPacket(new CriticalDamage()
                {
                    IsCritical = false,
                    CriticalHit = 1
                });
                ret = 1.0f;
            }
            return ret;
        }

        public float MightMultiplier()
        {
            float ret = Math.Min(3.5f, 1.0f + Owner.Stats[8] / 100);
            if (Owner.HasConditionEffect(ConditionEffects.Bravery))
                return ret * 2;
            return ret;
        }

        public float GetAttackFrequency()
        {
            if (Owner.HasConditionEffect(ConditionEffects.Dazed))
                return MIN_ATTACK_FREQ;

            var rof = MIN_ATTACK_FREQ + (this[5] / 75f) * (MAX_ATTACK_FREQ - MIN_ATTACK_FREQ);

            if (Owner.HasConditionEffect(ConditionEffects.Berserk))
                rof *= 1.5f;

            if (Owner.HasConditionEffect(ConditionEffects.SamuraiBerserk))
                rof *= 1.5f;

            if (Owner.HasConditionEffect(ConditionEffects.GraspofZol))
                rof *= 1.5f;

            if (Owner.HasConditionEffect(ConditionEffects.Alliance))
                rof *= 1.8f;


            return rof;
        }

        public static float GetDefenseDamage(Entity host, int dmg, int def)
        {
            if (host.HasConditionEffect(ConditionEffects.Armored))
                def *= 2;
            if (host.HasConditionEffect(ConditionEffects.ArmorBroken))
                def = 0;

            float limit = dmg * 0.25f;//0.15f;

            float ret;
            if (dmg - def < limit) ret = limit;
            else ret = dmg - def;

            if (host.HasConditionEffect(ConditionEffects.Curse))
                ret = (int)(ret * 1.20);

            if (host.HasConditionEffect(ConditionEffects.Invulnerable) ||
                host.HasConditionEffect(ConditionEffects.Invincible))
                ret = 0;
            return ret;
        }

        public float GetDefenseDamage(int dmg, bool noDef)
        {
            var def = this[3];
            if (Owner.HasConditionEffect(ConditionEffects.Armored))
                def *= 2;
            if (Owner.HasConditionEffect(ConditionEffects.ArmorBroken) || noDef)
                def = 0;

            float limit = dmg * 0.25f;//0.15f;

            float ret;
            if (dmg - def < limit) ret = limit;
            else ret = dmg - def;

            if (Owner.HasConditionEffect(ConditionEffects.Petrify))
                ret = (int)(ret * .9);
            if (Owner.HasConditionEffect(ConditionEffects.Curse))
                ret = (int)(ret * 1.20);
            if (Owner.HasConditionEffect(ConditionEffects.Invulnerable) ||
                Owner.HasConditionEffect(ConditionEffects.Invincible))
                ret = 0;
            return ret;
        }

        public int KaraDamage()
        {
            if (Owner.CheckKar() && Owner.HasConditionEffect(ConditionEffects.Invisible))
            {
                return Owner.Stats[7] * 2 + 20;
            }
            else
            {
                return 0;
            }
        }

        public int MoonLightDamage()
        {
            if (Owner.CheckMoonlight() && Owner.Surge >= 30)
            {
                return Owner.MP * 2;
            }
            else if (Owner.CheckMoonlight())
            {
                return Owner.MP;
            }
            else
            {
                return 0;
            }
        }

        public int isDoubleDamage()
        {
            if (Owner.CheckDemo())
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public static float GetSpeed(Entity entity, float stat)
        {
            var ret = 4 + 5.6f * (stat / 75f);
            if (entity.HasConditionEffect(ConditionEffects.Speedy))
                ret *= 1.5f;
            if (entity.HasConditionEffect(ConditionEffects.Swiftness))
                ret *= 1.7f;
            if (entity.HasConditionEffect(ConditionEffects.Slowed))
                ret = 4;
            if (entity.HasConditionEffect(ConditionEffects.Paralyzed))
                ret = 0;
            return ret;
        }

        public float GetSpeed()
        {
            return GetSpeed(Owner, this[4]);
        }

        public float GetHPRegen()
        {
            if (Owner.HasConditionEffect(ConditionEffects.Corrupted))
            {
                return 0;
            }
            else
            {
                var vit = this[6];
                if (Owner.HasConditionEffect(ConditionEffects.Sick))
                    vit = 0;

                return 6 + vit * .12f;
            }

        }

        public float GetMPRegen()
        {
            if (Owner.HasConditionEffect(ConditionEffects.Corrupted))
            {
                return 0;
            }
            else
            {

                int wis = this[7];
                if (Owner.HasConditionEffect(ConditionEffects.Quiet))
                    return 0;
                if (Owner.HasConditionEffect(ConditionEffects.Empowered))
                    return 26f + 0.06f * wis;
                if (Owner.HasConditionEffect(ConditionEffects.ManaRecovery))
                    return 24f + 0.06f * wis;
                if (Owner.Mark == 4 && Owner.Surge >= 25)
                    return 18f + 0.06f * wis;

                return 0.5f + this[7] * .06f;
            }
        }

        public static string StatIndexToName(int index)
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
                case 12: return "DamageMin";
                case 13: return "DamageMax";
                case 14: return "FortuneBoost";
            }
            return null;
        }

        public static int GetStatIndex(string name)
        {
            switch (name)
            {
                case "MaxHitPoints": return 0;
                case "MaxMagicPoints": return 1;
                case "Attack": return 2;
                case "Defense": return 3;
                case "Speed": return 4;
                case "Dexterity": return 5;
                case "HpRegen": return 6;
                case "MpRegen": return 7;
                case "Might": return 8;
                case "Luck": return 9;
                case "Restoration": return 10;
                case "Protection": return 11;
                case "DamageMin": return 12;
                case "DamageMax": return 13;
                case "FortuneBoost": return 14;
            }
            return -1;
        }

        public static int GetStatIndex(StatsType stat)
        {
            switch (stat)
            {
                case StatsType.MaximumHP:
                    return 0;
                case StatsType.MaximumMP:
                    return 1;
                case StatsType.Attack:
                    return 2;
                case StatsType.Defense:
                    return 3;
                case StatsType.Speed:
                    return 4;
                case StatsType.Dexterity:
                    return 5;
                case StatsType.Vitality:
                    return 6;
                case StatsType.Wisdom:
                    return 7;
                case StatsType.Might:
                    return 8;
                case StatsType.Luck:
                    return 9;
                case StatsType.Restoration:
                    return 10;
                case StatsType.Protection:
                    return 11;
                case StatsType.DamageMin:
                    return 12;
                case StatsType.DamageMax:
                    return 13;
                case StatsType.Fortune:
                    return 14;
                default:
                    return -1;
            }
        }

        public static StatsType GetStatType(int stat)
        {
            switch (stat)
            {
                case 0:
                    return StatsType.MaximumHP;
                case 1:
                    return StatsType.MaximumMP;
                case 2:
                    return StatsType.Attack;
                case 3:
                    return StatsType.Defense;
                case 4:
                    return StatsType.Speed;
                case 5:
                    return StatsType.Dexterity;
                case 6:
                    return StatsType.Vitality;
                case 7:
                    return StatsType.Wisdom;
                case 8:
                    return StatsType.Might;
                case 9:
                    return StatsType.Luck;
                case 10:
                    return StatsType.Restoration;
                case 11:
                    return StatsType.Protection;
                case 12:
                    return StatsType.DamageMin;
                case 13:
                    return StatsType.DamageMax;
                case 14:
                    return StatsType.Fortune;
                default:
                    return StatsType.None;
            }
        }

        public static StatsType GetBoostStatType(int stat)
        {
            switch (stat)
            {
                case 0:
                    return StatsType.HPBoost;
                case 1:
                    return StatsType.MPBoost;
                case 2:
                    return StatsType.AttackBonus;
                case 3:
                    return StatsType.DefenseBonus;
                case 4:
                    return StatsType.SpeedBonus;
                case 5:
                    return StatsType.DexterityBonus;
                case 6:
                    return StatsType.VitalityBonus;
                case 7:
                    return StatsType.WisdomBonus;
                case 8:
                    return StatsType.MightBonus;
                case 9:
                    return StatsType.LuckBonus;
                case 10:
                    return StatsType.RestorationBonus;
                case 11:
                    return StatsType.ProtectionBonus;
                case 12:
                    return StatsType.DamageMinBonus;
                case 13:
                    return StatsType.DamageMaxBonus;
                case 14:
                    return StatsType.FortuneBonus;
                default:
                    return StatsType.None;
            }
        }

        public static StatsType GetPowerStatType(int stat)
        {
            switch (stat)
            {
                case 0:
                    return StatsType.PWMaximumHP;
                case 1:
                    return StatsType.PWMaximumMP;
                case 2:
                    return StatsType.PWAttack;
                case 3:
                    return StatsType.PWDefense;
                case 4:
                    return StatsType.PWSpeed;
                case 5:
                    return StatsType.PWDexterity;
                case 6:
                    return StatsType.PWVitality;
                case 7:
                    return StatsType.PWWisdom;
                case 8:
                    return StatsType.PWMight;
                case 9:
                    return StatsType.PWLuck;
                case 10:
                    return StatsType.PWRestoration;
                case 11:
                    return StatsType.PWProtection;
                default:
                    return StatsType.None;
            }
        }

        public int PWNum(int stat)
        {
            switch (stat)
            {
                case 0:
                    return Owner.PWHealth;
                case 1:
                    return Owner.PWMana;
                case 2:
                    return Owner.PWAttack;
                case 3:
                    return Owner.PWDefense;
                case 4:
                    return Owner.PWSpeed;
                case 5:
                    return Owner.PWDexterity;
                case 6:
                    return Owner.PWVitality;
                case 7:
                    return Owner.PWWisdom;
                case 8:
                    return Owner.PWMight;
                case 9:
                    return Owner.PWLuck;
                case 10:
                    return Owner.PWRestoration;
                case 11:
                    return Owner.PWProtection;
                default:
                    return 0;
            }
        }
    }
}
