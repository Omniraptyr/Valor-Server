using System;
using common.resources;
namespace wServer.realm.entities
{
    partial class Player
    {
        private float _healing;
        private float _healing2;
        private float _healing3;
        private float _healing4;
        private float _bleeding;
        private float _surgeDepletion;
        private float _surgeDepletion2;
        private int _newbieTime;
        private int _canTpCooldownTime;
        private bool _isSurgeGone;
        private bool _surgeWither;
        public int ProtectionDamage;

        private void HandleEffects(RealmTime time)
        {
            if (time.TickCount % 50 == 0) {
                if (CheckAxe()) {
                    Stats.Boost.ActivateBoost[0].Push(300, true);
                    Stats.ReCalculateValues();
                } else {
                    Stats.Boost.ActivateBoost[0].Pop(300, true);
                    Stats.ReCalculateValues();
                }

                if (CheckSunMoon()) {
                    Stats.Boost.ActivateBoost[1].Push(100);
                    Stats.ReCalculateValues();
                } else {
                    Stats.Boost.ActivateBoost[1].Pop(100);
                    Stats.ReCalculateValues();
                }

                if (CheckAnubis()) {
                    Stats.Boost.ActivateBoost[1].Push(60);
                    Stats.ReCalculateValues();
                } else {
                    Stats.Boost.ActivateBoost[1].Pop(60);
                    Stats.ReCalculateValues();
                }

                if (Protection > 0 && HasConditionEffect(ConditionEffects.Corrupted)) {
                    ApplyConditionEffect(ConditionEffectIndex.Corrupted, 0);
                }

                if (Protection > 0) {
                    ApplyConditionEffect(ConditionEffectIndex.ParalyzeImmune);
                    ApplyConditionEffect(ConditionEffectIndex.StunImmune);
                } else {
                    ApplyConditionEffect(ConditionEffectIndex.ParalyzeImmune, 0);
                    ApplyConditionEffect(ConditionEffectIndex.StunImmune, 0);
                }

                if (CheckMocking()) {
                    ApplyConditionEffect(ConditionEffectIndex.Relentless);
                } else {
                    ApplyConditionEffect(ConditionEffectIndex.Relentless, 0);
                }

                if (CheckCrescent()) {
                    ApplyConditionEffect(ConditionEffectIndex.SlowedImmune);
                } else {
                    ApplyConditionEffect(ConditionEffectIndex.SlowedImmune, 0);
                }

                if (CheckGHelm()) {
                    _gildHelmBonus = 8;
                } else {
                    _gildHelmBonus = 0;
                }

                if (CheckForce()) {
                    ApplyConditionEffect(ConditionEffectIndex.ArmorBreakImmune);
                } else {
                    ApplyConditionEffect(ConditionEffectIndex.ArmorBreakImmune, 0);
                }

                if (CheckRoyal()) {
                    ApplyConditionEffect(ConditionEffectIndex.HealthRecovery);
                } else {
                    ApplyConditionEffect(ConditionEffectIndex.HealthRecovery, 0);
                }

                if (CheckResistance()) {
                    ApplyConditionEffect(ConditionEffectIndex.SlowedImmune);
                } else {
                    ApplyConditionEffect(ConditionEffectIndex.SlowedImmune, 0);
                }

                if (CheckAegis()) {
                    ApplyConditionEffect(ConditionEffectIndex.Vengeance);
                } else {
                    ApplyConditionEffect(ConditionEffectIndex.Vengeance, 0);
                }

                if (CheckGuilded()) {
                    ApplyConditionEffect(ConditionEffectIndex.Alliance);
                } else {
                    ApplyConditionEffect(ConditionEffectIndex.Alliance, 0);
                }
                MainLegendaryPassives();
            }

            ProtectionMax = (int)(((Math.Pow(Stats[11], 2)) * 0.04) + (Stats[0] / 50)) + 5;
            Protection = (int)(((Math.Pow(Stats[11], 2)) * 0.04) + (Stats[0] / 50)) + 5 - ProtectionDamage;

            if (Protection < 0) {
                Protection = 0;
            }

            if (Surge == 100) {
                ProtectionDamage = 0;
            }

            if (SurgeCounter == 1) {
                Surge = 0;
            }

            if (_client.Account.Hidden && !HasConditionEffect(ConditionEffects.Hidden))
            {
                ApplyConditionEffect(ConditionEffectIndex.Hidden);
                ApplyConditionEffect(ConditionEffectIndex.Invincible);
                Manager.Clients[Client].Hidden = true;
            }

            if (Muted && !HasConditionEffect(ConditionEffects.Muted))
                ApplyConditionEffect(ConditionEffectIndex.Muted);
          
            if (HasConditionEffect(ConditionEffects.Healing) && !HasConditionEffect(ConditionEffects.Sick) && !HasConditionEffect(ConditionEffects.DrakzixCharging))
            {
                if (_healing > 1)
                {
                    HP = Math.Min(Stats[0], HP + (int)_healing);
                    _healing -= (int)_healing;
                }
                _healing += 28 * (time.ElapsedMsDelta / 1000f);
            }

            if (Mark == 4 && Surge >= 25)
            {
                if (_healing3 > 1)
                {
                    HP = Math.Min(Stats[0], HP + (int)_healing3);
                    _healing3 -= (int)_healing3;
                }
                _healing3 += 24 * (time.ElapsedMsDelta / 1000f);
            }

            if (CheckAxe())
            {
                if (_healing4 > 1)
                {
                    HP = Math.Min(Stats[0], HP + (int)_healing4);
                    _healing4 -= (int)_healing4;
                }
                _healing4 += 24 * (time.ElapsedMsDelta / 1000f);
            }

            if (HasConditionEffect(ConditionEffects.HealthRecovery) 
                && !HasConditionEffect(ConditionEffects.Sick) 
                && !HasConditionEffect(ConditionEffects.DrakzixCharging))
            {
                if (_healing2 > 1)
                {
                    HP = Math.Min(Stats[0], HP + (int)_healing2);
                    _healing2 -= (int)_healing2;
                }
                _healing2 += 36 * (time.ElapsedMsDelta / 1000f);
            }

            if (HasConditionEffect(ConditionEffects.Quiet) && MP > 0)
                MP = 0;
            
            if (HasConditionEffect(ConditionEffects.Bleeding) && HP > 1)
            {
                if (_bleeding > 1)
                {
                    HP -= (int)_bleeding;
                    if (HP < 1)
                        HP = 1;
                    _bleeding -= (int)_bleeding;
                }
                _bleeding += 28 * (time.ElapsedMsDelta / 1000f);
            }

            if (_isSurgeGone)
            {
                if (_surgeDepletion > 1)
                {
                    SurgeCounter -= (int)_surgeDepletion;
                    if (SurgeCounter < 1)
                        SurgeCounter = 0;
                    _surgeDepletion -= (int)_surgeDepletion;
                    if (SurgeCounter == 0)
                    {
                        _isSurgeGone = false;
                        _surgeWither = true;
                    }
                }
                _surgeDepletion += (28-(_surgeBonus+_gildHelmBonus)) * (time.ElapsedMsDelta / 1000f);
            }

            if (_surgeWither)
            {
                if (_surgeDepletion2 > 1)
                {
                    Surge -= (int)_surgeDepletion2;
                    if (Surge < 1)
                        Surge = 0;
                    _surgeDepletion2 -= (int)_surgeDepletion2;
                }
                _surgeDepletion2 += 14 * (time.ElapsedMsDelta / 1000f);
            }

            if (HasConditionEffect(ConditionEffects.NinjaSpeedy))
            {
                MP = Math.Max(0, (int)(MP - 10 * time.ElapsedMsDelta / 1000f));

                if (MP == 0)
                    ApplyConditionEffect(ConditionEffectIndex.NinjaSpeedy, 0);
            }

            if (HasConditionEffect(ConditionEffects.SamuraiBerserk))
            {
                MP = Math.Max(0, (int)(MP - 10 * time.ElapsedMsDelta / 1000f));

                if (MP == 0)
                    ApplyConditionEffect(ConditionEffectIndex.SamuraiBerserk, 0);
            }

            if (HasConditionEffect(ConditionEffects.DrakzixCharging))
            {

                Owner.Timers.Add(new WorldTimer(100, (w, t) =>
                {
                    HP -= 10;
                    DrainedHP += 1;
                }));
            }

            if (_newbieTime > 0)
            {
                _newbieTime -= time.ElapsedMsDelta;
                if (_newbieTime < 0) 
                    _newbieTime = 0;
            }

            if (_canTpCooldownTime > 0)
            {
                _canTpCooldownTime -= time.ElapsedMsDelta;
                if (_canTpCooldownTime < 0)
                    _canTpCooldownTime = 0;
            }
        }

        private bool CanHpRegen()
        {
            if (HasConditionEffect(ConditionEffects.Sick))
                return false;
            if (HasConditionEffect(ConditionEffects.Bleeding))
                return false;
            return true;
        }

        private bool CanMpRegen()
        {
            if (HasConditionEffect(ConditionEffects.Quiet) ||
                    HasConditionEffect(ConditionEffects.NinjaSpeedy) || 
                        HasConditionEffect(ConditionEffects.SamuraiBerserk))
                return false;
            
            return true;
        }

        internal void SetNewbiePeriod()
        {
            _newbieTime = 3000;
        }

        internal void SetTPDisabledPeriod()
        {
            _canTpCooldownTime = 10 * 1000; // 10 seconds
        }

        public bool IsVisibleToEnemy()
        {
            if (HasConditionEffect(ConditionEffects.Paused))
                return false;
            if (HasConditionEffect(ConditionEffects.Invisible))
                return false;
            if (HasConditionEffect(ConditionEffects.Hidden))
                return false;
            if (_newbieTime > 0)
                return false;
            return true;
        }

        public bool TPCooledDown()
        {
            return _canTpCooldownTime <= 0;
        }
    }
}
