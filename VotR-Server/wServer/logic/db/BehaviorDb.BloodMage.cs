using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ BloodMage = () => Behav()
        .Init("Blood Boss Anchor",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )
        .Init("Stone of Blood 1",
            new State(
                //new ScaleHP(500),
                new State("badaura",
                     new Shoot(10, count: 4, projectileIndex: 0, coolDown: 80)
                    )
                )
            )
        .Init("Zaragon, the Blood Mage",
                new State(
                    new ScaleHP(25000),
                    new DropPortalOnDeath("The Catacombs Portal"),
                    new Orbit(0.3, 3, target: "Blood Boss Anchor"),
                    new HpLessTransition(0.18, "Dead1"),
                    new State("swag",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(8, "Waiting")
                        ),
                    new State("Waiting",
                        new Flash(0x00FF00, 1, 2),
                        new Taunt("No one but me shall seal your fate, {PLAYER}."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(8000, "Sentry1")
                        ),
                    new State(
                        new Shoot(8.4, count: 8, projectileIndex: 3, coolDown: 100),
                    new State("Sentry1",
                        new Flash(0x00FFFF, 1, 2),
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new RemoveEntity(99, "Stone of Blood 1"),
                        new Shoot(8.4, count: 6, shootAngle: 10, projectileIndex: 0, coolDown: 200),
                        new Shoot(8.4, count: 3, shootAngle: 10, projectileIndex: 0, predictive: 2, coolDown: 200, coolDownOffset: 3000),
                        new Shoot(8.4, count: 1, projectileIndex: 1, coolDown: 2000),
                        new TimedTransition(8000, "Sentry2")
                        ),
                    new State("Sentry2",
                        new TossObject("Stone of Blood 1", range: 8, coolDown: 2000),
                        new Shoot(8.4, count: 10, projectileIndex: 1, coolDown: 3000),
                        new Shoot(8.4, count: 10, shootAngle: 30, projectileIndex: 0, predictive: 1, coolDown: 1000, coolDownOffset: 2000),
                        new TimedTransition(8000, "Sentry3")
                        ),
                    new State("Sentry3",
                        new Flash(0x00FFFF, 1, 2),
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new Shoot(8.4, count: 18, projectileIndex: 0, coolDown: 3000),
                        new Shoot(8.4, count: 5, shootAngle: 5, projectileIndex: 2, coolDown: 200),
                        new TimedTransition(8000, "Sentry4")
                        ),
                    new State("Sentry4",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Grenade(3, 180, range: 7),
                        new Shoot(8.4, count: 12, projectileIndex: 2, coolDown: 2000),
                        new Shoot(8.4, count: 3, shootAngle: 16, projectileIndex: 2, coolDown: 200),
                        new TimedTransition(8000, "Sentry5")
                        ),
                    new State("Sentry5",
                        new Flash(0x00FFFF, 1, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8.4, count: 10, projectileIndex: 0, coolDown: 2000),
                        new Shoot(8.4, count: 1, projectileIndex: 1, coolDown: 200),
                        new TimedTransition(5000, "spiral1")
                        ),
                     new State("spiral1",
                         new Flash(0x00FFFF, 1, 2),
                         new ConditionalEffect(ConditionEffectIndex.Armored),
                         new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new Shoot(8.4, count: 2, shootAngle: 60, projectileIndex: 1, coolDown: 600),
                        new TimedTransition(7000, "Sentry1"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Quadforce1")
                        )
                    )
                   ),
                    new State("Dead1",
                        new RemoveEntity(99, "Blood Boss Anchor"),
                        new Taunt("Finally, rest."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, true),
                        new Flash(0x0000FF, 0.2, 3),
                        new TimedTransition(3250, "dead")
                        ),
                    new State("dead",
                        new Suicide()
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor3Perc()
                    ),
                new Threshold(0.01,
                    new ItemLoot("Bloodbath Dagger", 0.01),
                    new ItemLoot("God Blood Robes", 0.005),
                    new ItemLoot("Banner of the Blood Mountains", 0.005),
                    new ItemLoot("Titan Blood Armor", 0.005),
                    new TierLoot(8, ItemType.Weapon, 0.3),
                    new TierLoot(9, ItemType.Weapon, 0.275),
                    new TierLoot(10, ItemType.Weapon, 0.225),
                    new TierLoot(11, ItemType.Weapon, 0.08),
                    new TierLoot(8, ItemType.Armor, 0.2),
                    new TierLoot(9, ItemType.Armor, 0.175),
                    new TierLoot(10, ItemType.Armor, 0.15),
                    new TierLoot(11, ItemType.Armor, 0.1),
                    new TierLoot(12, ItemType.Armor, 0.05),
                    new TierLoot(4, ItemType.Ability, 0.15),
                    new TierLoot(5, ItemType.Ability, 0.1),
                    new TierLoot(5, ItemType.Ring, 0.05)
                )
            )
            ;
    }
}