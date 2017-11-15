using common.resources;
using wServer.realm.entities;
using System;
using wServer.networking.packets.outgoing;
namespace wServer.realm
{
    public class StatsManager
    {
        internal const int NumStatTypes = 15; // change this to add more stats
        private const float MinAttackMult = 0.5f;
        private const float MaxAttackMult = 2f;
        private const float MinAttackFreq = 0.0015f;
        private const float MaxAttackFreq = 0.008f;

        internal readonly Player Owner;
        internal readonly BaseStatManager Base;
        internal readonly BoostStatManager Boost;

        private readonly SV<int>[] _stats;

        public int this[int index] => Base[index] + Boost[index];

        public StatsManager(Player owner)
        {
            Owner = owner;
            Base = new BaseStatManager(this);
            Boost = new BoostStatManager(this);

            _stats = new SV<int>[NumStatTypes];
            for (var i = 0; i < NumStatTypes; i++)
                _stats[i] = new SV<int>(Owner, GetStatType(i), this[i], i != 0 && i!= 1); // make maxHP and maxMP global update
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
            var ret = Owner.Client.Random.NextIntRange((uint)min, (uint)max) * GetAttackMult(isAbility) * CriticalModifier() + RelentlessDamage();
            //Log.Info($"Dmg: {ret}");
            return (int)ret;
        } 

        public float GetAttackMult(bool isAbility)
        {
            if (isAbility)
                return 1;

            if (Owner.HasConditionEffect(ConditionEffects.Weak))
                return MinAttackMult;

            var mult = MinAttackMult + (this[2] / 75f) * (MaxAttackMult - MinAttackMult);
            if (Owner.HasConditionEffect(ConditionEffects.Damaging))
                mult *= 1.5f;

            return mult;
        }

        public int RelentlessDamage()
        {
            if (Owner.HasConditionEffect(ConditionEffects.Relentless))
            {
                return Owner.Surge * 6;
            }
            else
            {
                return 0;
            }
        }

        private float CriticalModifier()
        {
            Random rnd = new Random();
            int luckNm = rnd.Next(1, 1001);
            var ret = 1.0f;
            if (luckNm <= Owner.Stats[9])
            {
                ret *= FinalMightMultiplier();
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

        public float FinalMightMultiplier()
        {
            if (Owner.HasConditionEffect(ConditionEffects.Bravery))
            {
                return MightMultiplier() * 2;
            }
            else
            {
                return MightMultiplier();
            }
        }

        private float MightMultiplier()
        {

            if (Owner.Stats[8] >= 0 && Owner.Stats[8] <= 10)
            {
                return 1.1f;
            }
            else if (Owner.Stats[8] >= 11 && Owner.Stats[8] <= 20)
            {
                return 1.2f;
            }
            else if (Owner.Stats[8] >= 21 && Owner.Stats[8] <= 30)
            {
                return 1.3f;
            }
            else if (Owner.Stats[8] >= 31 && Owner.Stats[8] <= 40)
            {
                return 1.4f;
            }
            else if (Owner.Stats[8] >= 41 && Owner.Stats[8] <= 50)
            {
                return 1.5f;
            }
            else if (Owner.Stats[8] >= 51 && Owner.Stats[8] <= 60)
            {
                return 1.6f;
            }
            else if (Owner.Stats[8] >= 61 && Owner.Stats[8] <= 70)
            {
                return 1.7f;
            }
            else if (Owner.Stats[8] >= 71 && Owner.Stats[8] <= 80)
            {
                return 1.8f;
            }
            else if (Owner.Stats[8] >= 81 && Owner.Stats[8] <= 90)
            {
                return 1.9f;
            }
            else if (Owner.Stats[8] >= 91 && Owner.Stats[8] <= 100)
            {
                return 2.0f;
            }
            else if (Owner.Stats[8] >= 101 && Owner.Stats[8] <= 110)
            {
                return 2.1f;
            }
            else if (Owner.Stats[8] >= 111 && Owner.Stats[8] <= 120)
            {
                return 2.2f;
            }
            else if (Owner.Stats[8] >= 121 && Owner.Stats[8] <= 130)
            {
                return 2.3f;
            }
            else if (Owner.Stats[8] >= 131 && Owner.Stats[8] <= 140)
            {
                return 2.4f;
            }
            else if (Owner.Stats[8] >= 141 && Owner.Stats[8] <= 150)
            {
                return 2.5f;
            }
            else if (Owner.Stats[8] >= 151 && Owner.Stats[8] <= 160)
            {
                return 2.6f;
            }
            else if (Owner.Stats[8] >= 161 && Owner.Stats[8] <= 170)
            {
                return 2.7f;
            }
            else if (Owner.Stats[8] >= 171 && Owner.Stats[8] <= 180)
            {
                return 2.8f;
            }
            else if (Owner.Stats[8] >= 181 && Owner.Stats[8] <= 190)
            {
                return 2.9f;
            }
            else if (Owner.Stats[8] >= 191 && Owner.Stats[8] <= 200)
            {
                return 3.0f;
            }
            else if (Owner.Stats[8] >= 201 && Owner.Stats[8] <= 210)
            {
                return 3.1f;
            }
            else if (Owner.Stats[8] >= 211 && Owner.Stats[8] <= 220)
            {
                return 3.2f;
            }
            else if (Owner.Stats[8] >= 221 && Owner.Stats[8] <= 230)
            {
                return 3.3f;
            }
            else if (Owner.Stats[8] >= 231 && Owner.Stats[8] <= 240)
            {
                return 3.4f;
            }
            else if (Owner.Stats[8] >= 241 && Owner.Stats[8] <= 250 || Owner.Stats[8] >= 250)
            {
                return 3.5f;
            }
            return 1.0f;

        }

        public float GetAttackFrequency()
        {
            if (Owner.HasConditionEffect(ConditionEffects.Dazed))
                return MinAttackFreq;

            var rof = MinAttackFreq + (this[5] / 75f) * (MaxAttackFreq - MinAttackFreq);

            if (Owner.HasConditionEffect(ConditionEffects.Berserk))
                rof *= 1.5f;

            if (Owner.HasConditionEffect(ConditionEffects.SamuraiBerserk))
                rof *= 1.5f;

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

        public static float GetSpeed(Entity entity, float stat)
        {
            var ret = 4 + 5.6f * (stat / 75f);
            if (entity.HasConditionEffect(ConditionEffects.Speedy))
                ret *= 1.5f;
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
            else{
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
                    return 22f + 0.06f * wis;
                if (Owner.HasConditionEffect(ConditionEffects.ManaRecovery))
                    return 25f + 0.06f * wis;

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
            } return null;
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
            } return -1;
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
    }
}
