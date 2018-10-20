using System;
using System.Collections.Generic;
using common.resources;
using wServer.logic;
using wServer.networking.packets.outgoing;
using wServer.realm.terrain;
using wServer.realm.worlds;

namespace wServer.realm.entities
{
    public class Enemy : Character
    {
        private readonly bool stat;
        public Enemy ParentEntity;

        public Enemy(RealmManager manager, ushort objType)
            : base(manager, objType)
        {
            stat = ObjectDesc.MaxHP == 0;
            DamageCounter = new DamageCounter(this);
        }

        public DamageCounter DamageCounter { get; private set; }

        public WmapTerrain Terrain { get; set; }

        private Position? pos;
        public Position SpawnPoint => pos ?? new Position { X = X, Y = Y };

        public override void Init(World owner)
        {
            base.Init(owner);
            if (ObjectDesc.StasisImmune)
                ApplyConditionEffect(new ConditionEffect()
                {
                    Effect = ConditionEffectIndex.StasisImmune,
                    DurationMS = -1
                });
        }

        public void SetDamageCounter(DamageCounter counter, Enemy enemy)
        {
            DamageCounter = counter;
            DamageCounter.UpdateEnemy(enemy);
        }

        public event EventHandler<BehaviorEventArgs> OnDeath;

        public void Death(RealmTime time)
        {
            DamageCounter.Death(time);
            CurrentState?.OnDeath(new BehaviorEventArgs(this, time));
            OnDeath?.Invoke(this, new BehaviorEventArgs(this, time));
            Owner.LeaveWorld(this);
        }

        public int Damage(Player from, RealmTime time, int dmg, bool noDef, params ConditionEffect[] effs)
        {
            if (stat) return 0;
            if (HasConditionEffect(ConditionEffects.Invincible))
                return 0;
            if (!HasConditionEffect(ConditionEffects.Paused) &&
                !HasConditionEffect(ConditionEffects.Stasis))
            {
                var def = ObjectDesc.Defense;
                if (noDef)
                    def = 0;
                dmg = (int)StatsManager.GetDefenseDamage(this, dmg, def);
                var effDmg = dmg;
                if (effDmg > HP)
                    effDmg = HP;
                if (!HasConditionEffect(ConditionEffects.Invulnerable))
                    HP -= dmg;
                ApplyConditionEffect(effs);
                Owner.BroadcastPacketNearby(new Damage()
                {
                    TargetId = Id,
                    Effects = 0,
                    DamageAmount = (ushort)dmg,
                    Kill = HP < 0,
                    BulletId = 0,
                    ObjectId = from.Id
                }, this, null, PacketPriority.Low);

                DamageCounter.HitBy(from, time, null, dmg);

                if (HP < 0 && Owner != null)
                {
                    Death(time);
                }

                return effDmg;
            }
            return 0;
        }

        private int hpHits, manaHits;

        public override bool HitByProjectile(Projectile projectile, RealmTime time)
        {
            if (stat) return false;
            if (HasConditionEffect(ConditionEffects.Invincible))
                return false;
            if (projectile.ProjectileOwner is Player p &&
                !HasConditionEffect(ConditionEffects.Paused) &&
                !HasConditionEffect(ConditionEffects.Stasis))
            {
                var def = ObjectDesc.Defense;
                if (projectile.ProjDesc.ArmorPiercing)
                    def = 0;
                var dmg = (int)StatsManager.GetDefenseDamage(this, projectile.Damage, def);
                if (!HasConditionEffect(ConditionEffects.Invulnerable))
                    HP -= dmg;
                ConditionEffect[] effs = null;
                foreach (var pair in projectile.ProjDesc.CondChance)
                {
                    if (pair.Value == 0 || pair.Key == default(ConditionEffect)) continue;

                    if (pair.Value / 100d > new Random().NextDouble())
                    {
                        var effList = new List<ConditionEffect>(projectile.ProjDesc.Effects) {pair.Key};
                        effs = effList.ToArray();
                    }
                }
                ApplyConditionEffect(effs ?? projectile.ProjDesc.Effects);
                Owner.BroadcastPacketNearby(new Damage
                {
                    TargetId = Id,
                    Effects = projectile.ConditionEffects,
                    DamageAmount = (ushort)dmg,
                    Kill = HP < 0,
                    BulletId = projectile.ProjectileId,
                    ObjectId = projectile.ProjectileOwner.Self.Id
                }, this, p, PacketPriority.Low);

                if (p.LifeSteal != 0 && !p.HasConditionEffect(ConditionEffects.Sick)) {
                    var maxHP = p.Stats[0];
                    var lifeSteal = p.LifeSteal;

                    if (lifeSteal >= 1 && p.HP < maxHP)
                        p.HP = p.HP + lifeSteal > maxHP ? maxHP : p.HP + lifeSteal;
                    else {
                        hpHits++;
                        if (hpHits >= 1 / lifeSteal)
                            p.HP = p.HP + lifeSteal > maxHP ? maxHP : p.HP + lifeSteal;
                    }
                }

                if (p.ManaLeech != 0 && !p.HasConditionEffect(ConditionEffects.Quiet)) {
                    var maxMP = p.Stats[1];
                    var manaLeech = p.ManaLeech;

                    if (manaLeech >= 1 && p.MP < maxMP)
                        p.MP = p.MP + manaLeech > maxMP ? maxMP : p.MP + manaLeech;
                    else {
                        manaHits++;
                        if (manaHits >= 1 / manaLeech)
                            p.MP = p.MP + manaLeech > maxMP ? maxMP : p.MP + manaLeech;
                    }
                }

                DamageCounter.HitBy(p, time, projectile, dmg);

                if (HP < 0 && Owner != null)
                {
                    Death(time);
                }
                return true;
            }
            return false;
        }

        public override void Tick(RealmTime time)
        {
            if (pos == null)
                pos = new Position() { X = X, Y = Y };

            if (!stat && HasConditionEffect(ConditionEffects.Bleeding))
            {
                HP -= (int)(MaximumHP / 650f * time.ElapsedMsDelta / 1000f);
            }
            base.Tick(time);
        }
    }
}