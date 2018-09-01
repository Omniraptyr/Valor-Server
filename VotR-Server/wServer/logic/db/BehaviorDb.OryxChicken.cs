using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.logic.behaviors;
using common.resources;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ OryxChicken = () => Behav()
            .Init("Test Egg",
                new State(
                    new State("Idle",
                        new HpLessTransition(630000, "1")
                    ),
                    new State("1",
                        new HpLessTransition(610000, "2"),
                        new SetAltTexture(1)
                    ),
                    new State("2",
                        new HpLessTransition(590000, "3"),
                        new SetAltTexture(2)
                    ),
                    new State("3",
                        new HpLessTransition(570000, "4"),
                        new SetAltTexture(3)
                    ),
                    new State("4",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new SetAltTexture(4),
                        new TimedTransition(250, "Break")
                    ),
                    new State("Break",
                        new Transform("TestChicken 2")
                    )
                )
            )
            .Init("TestChicken 2",
                new State(
                    new State("Idle",
             new ChangeSize(20, 100),
                        new TimedTransition(600, "Phase One")
                    ),
                    new State("Phase One",
                        new Taunt("CLUCK!"),
                        new State("Shoot",
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 0, coolDown: 4000, coolDownOffset: 200),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 20, coolDown: 4000, coolDownOffset: 400),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 40, coolDown: 4000, coolDownOffset: 600),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 60, coolDown: 4000, coolDownOffset: 800),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 80, coolDown: 4000, coolDownOffset: 1000),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 100, coolDown: 4000, coolDownOffset: 1200),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 120, coolDown: 4000, coolDownOffset: 1400),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 140, coolDown: 4000, coolDownOffset: 1600),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 160, coolDown: 4000, coolDownOffset: 1800),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 180, coolDown: 4000, coolDownOffset: 2000),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 200, coolDown: 4000, coolDownOffset: 2200),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 220, coolDown: 4000, coolDownOffset: 2400),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 240, coolDown: 4000, coolDownOffset: 2600),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 260, coolDown: 4000, coolDownOffset: 2800),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 280, coolDown: 4000, coolDownOffset: 3000),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 300, coolDown: 4000, coolDownOffset: 3200),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 320, coolDown: 4000, coolDownOffset: 3400),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 340, coolDown: 4000, coolDownOffset: 3600),
                            new Shoot(15, projectileIndex: 0, count: 4, fixedAngle: 90, angleOffset: 360, coolDown: 4000, coolDownOffset: 3800),
                            new Shoot(15, projectileIndex: 4, count: 3, shootAngle: 20, coolDown: 1000),
                            new StayCloseToSpawn(0.6, 5),
                            new Wander(0.5),
                            new HpLessTransition(.800, "Phase Two")
                            ),
                        new State("Phase Two",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new OrderOnce(99, "TestChicken Small", "Orbit"),
                            new Taunt("Cluck cluck cluck ... CLUCK!"),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 0, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 180, shootAngle: 15),
                            new TimedTransition(100, "1"),
                            new HpLessTransition(.600, "Static1")
                            ),
                        new State("1",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 30, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 210, shootAngle: 15),
                            new TimedTransition(100, "2"),
                            new HpLessTransition(.600, "Static1")
                            ),
                            new State("2",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 60, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 240, shootAngle: 15),
                            new TimedTransition(100, "3"),
                            new HpLessTransition(.600, "Static1")
                                ),
                            new State("3",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 90, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 270, shootAngle: 15),
                            new TimedTransition(100, "4"),
                            new HpLessTransition(.600, "Static1")
                                ),
                                new State("4",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 120, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 300, shootAngle: 15),
                            new TimedTransition(100, "5"),
                            new HpLessTransition(.600, "Static1")
                                    ),
                                new State("5",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 150, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 330, shootAngle: 15),
                            new TimedTransition(100, "6"),
                            new HpLessTransition(.600, "Static1")
                                    ),
                                    new State("6",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 180, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 360, shootAngle: 15),
                            new TimedTransition(100, "Phase Two2"),
                            new HpLessTransition(.600, "Static1")
                                    ),
                                    new State("Phase Two2",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new OrderOnce(99, "TestChicken Small", "Orbit"),
                            new Taunt("Cluck cluck cluck ... CLUCK!"),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 0, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 180, shootAngle: 15),
                            new TimedTransition(100, "7"),
                            new HpLessTransition(.600, "Static1")
                            ),
                        new State("7",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 30, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 210, shootAngle: 15),
                            new TimedTransition(100, "8"),
                            new HpLessTransition(.600, "Static1")
                            ),
                            new State("8",
                                new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 60, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 240, shootAngle: 15),
                            new TimedTransition(100, "9"),
                            new HpLessTransition(.600, "Static1")
                                ),
                            new State("9",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 90, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 270, shootAngle: 15),
                            new TimedTransition(100, "10"),
                            new HpLessTransition(.600, "Static1")
                                ),
                                new State("10",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 120, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 300, shootAngle: 15),
                            new TimedTransition(100, "11"),
                            new HpLessTransition(.600, "Static1")
                                    ),
                                new State("11",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 150, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 330, shootAngle: 15),
                            new TimedTransition(100, "12"),
                            new HpLessTransition(.600, "Static1")
                                    ),
                                    new State("12",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 180, shootAngle: 15),
                            new Shoot(10, count: 5, projectileIndex: 0, coolDown: 100, fixedAngle: 360, angleOffset: 360, shootAngle: 15),
                            new TimedTransition(100, "Phase Two"),
                            new HpLessTransition(.600, "Static1")
                                        ),
                        new State("Static1",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                            new TimedTransition(3000, "Phase Three")
                        ),
                        new State("Phase Three",
                            new OrderOnce(1, "TestChicken Small", "OrbitPlayer"),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Wander(0.2),
                            new Follow(0.4, 6, 1),
                            new Shoot(22, count: 5, projectileIndex: 8, shootAngle: 20, fixedAngle: 180, coolDown: 500),
                            new Shoot(22, count: 5, projectileIndex: 7, shootAngle: 20, fixedAngle: 180, coolDown: 500),
                            new Shoot(22, count: 5, projectileIndex: 8, shootAngle: 20, fixedAngle: 360, coolDown: 500),
                            new Shoot(22, count: 5, projectileIndex: 7, shootAngle: 20, fixedAngle: 360, coolDown: 500),
                            new TimedTransition(500, "Immune"),
                            new HpLessTransition(0.3, "AlotOfBullets")
                                ),
                        new State("Immune",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Wander(0.2),
                            new Follow(0.4, 6, 1),
                            new TimedTransition(500, "Phase Three2"),
                            new HpLessTransition(0.3, "AlotOfBullets")
                                ),
                        new State("Phase Three2",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Wander(0.2),
                            new Follow(0.4, 6, 1),
                            new Shoot(22, count: 5, projectileIndex: 8, shootAngle: 20, fixedAngle: 90, coolDown: 500),
                            new Shoot(22, count: 5, projectileIndex: 7, shootAngle: 20, fixedAngle: 90, coolDown: 500),
                            new Shoot(22, count: 5, projectileIndex: 8, shootAngle: 20, fixedAngle: 270, coolDown: 500),
                            new Shoot(22, count: 5, projectileIndex: 7, shootAngle: 20, fixedAngle: 270, coolDown: 500),
                            new TimedTransition(500, "Damageable"),
                            new HpLessTransition(0.3, "AlotOfBullets")
                                ),
                            new State("Damageable",
                            new Reproduce("TestChicken Small", 40, 5, 4000),
                            new Wander(0.2),
                            new Follow(0.4, 6, 1),
                            new TimedTransition(500, "Phase Three"),
                         new HpLessTransition(0.3, "AlotOfBullets")
                                ),
                            new State("AlotOfBullets",
                                new OrderOnce(1, "TestChicken Small", "orbitattacking"),
                                new Reproduce("TestChicken Small", 40, 5, 4000),
                                new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                                new Wander(0.1),
                                new StayCloseToSpawn(0.1, 1),
                                new Shoot(20, count: 5, projectileIndex: 2, shootAngle: 25, fixedAngle: 90, coolDown: 1000),
                                new Shoot(20, count: 5, projectileIndex: 2, shootAngle: 25, fixedAngle: 270, coolDown: 1000),
                                new Shoot(20, count: 10, projectileIndex: 3, shootAngle: 10, fixedAngle: 180, coolDown: 1000),
                                new Shoot(20, count: 10, projectileIndex: 3, shootAngle: 10, fixedAngle: 360, coolDown: 1000),
                                new TimedTransition(1000, "Static2"),
                                new HpLessTransition(0.120, "FinalPhase")
                                ),
                            new State("Static2",
                                new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                                new Reproduce("TestChicken Small", 40, 5, 4000),
                                new Wander(0.1),
                                new StayCloseToSpawn(0.1, 1),
                                new TimedTransition(1000, "AttackingAgain"),
                                new HpLessTransition(0.120, "FinalPhase")
                                ),
                            new State("AttackingAgain",
                                new Reproduce("TestChicken Small", 40, 5, 4000),
                                new Wander(0.1),
                                new StayCloseToSpawn(0.1, 1),
                                new Shoot(20, count: 5, projectileIndex: 2, shootAngle: 25, fixedAngle: 90, coolDown: 1000),
                                new Shoot(20, count: 5, projectileIndex: 2, shootAngle: 25, fixedAngle: 270, coolDown: 1000),
                                new Shoot(20, count: 10, projectileIndex: 3, shootAngle: 10, fixedAngle: 180, coolDown: 1000),
                                new Shoot(20, count: 10, projectileIndex: 3, shootAngle: 10, fixedAngle: 360, coolDown: 1000),
                                new TimedTransition(1000, "Static3"),
                                new HpLessTransition(0.120, "FinalPhase")
                                ),
                            new State("Static3",
                                new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                                new Reproduce("TestChicken Small", 40, 5, 4000),
                                new Wander(0.1),
                                new StayCloseToSpawn(0.1, 1),
                                new TimedTransition(1000, "AlotOfBullets"),
                                new HpLessTransition(0.120, "FinalPhase")
                                ),
                    new State("FinalPhase",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                        new Wander(0.5),
                        new Follow(0.5, 6, 1),
                        new Shoot(10, count: 5, projectileIndex: 4, shootAngle: 20, predictive: 0.4, coolDown: 1000),
                        new Shoot(10, count: 10, projectileIndex: 3, shootAngle: 10, predictive: 1, coolDown: 2000),
                        new TimedTransition(4000, "FinalPhase2"),
                        new HpLessTransition(0.020, "CloseToDeath")
                        ),
                    new State("FinalPhase2",
                        new Wander(0.4),
                        new Follow(0.4, 6, 1),
                        new Shoot(10, count: 5, projectileIndex: 4, shootAngle: 20, predictive: 0.4, coolDown: 1000),
                        new Shoot(10, count: 10, projectileIndex: 3, shootAngle: 10, predictive: 1, coolDown: 1500),
                        new TimedTransition(3000, "FinalPhase"),
                        new HpLessTransition(0.020, "CloseToDeath")
                        ),
                    new State("CloseToDeath",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                        new Flash(0xffffff, 2, 1),
                        new TimedTransition(3000, "Death")
                        ),
                    new State("Death",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                        new Shoot(100, 10, projectileIndex: 6),
                        new Suicide()
                        )
                        )
                ),
                new Threshold(0.05,
                    new TierLoot(9, ItemType.Weapon, 0.03),
                    new TierLoot(9, ItemType.Armor, 0.03),
                    new TierLoot(4, ItemType.Ring, 0.015),
                    new TierLoot(4, ItemType.Ability, 0.04),
                    new TierLoot(10, ItemType.Weapon, 0.04),
                    new TierLoot(10, ItemType.Armor, 0.04),
                    new TierLoot(5, ItemType.Ring, 0.003),
                    new TierLoot(5, ItemType.Ability, 0.05),
                    new ItemLoot("Potion of Attack", 0.05),
                    new ItemLoot("Potion of Defense", 0.05),
                    new ItemLoot("Chicken Leg of Doom", 0.01),
                    new ItemLoot("Anatis Staff", 0.01)
                    )
            )
            .Init("TestChicken Small",
                new State(
                    new State("Orbit",
                        new Wander(.7),
                        new Orbit(0.37, 4, 20, "TestChicken 2"),
                        new Shoot(10, 8, projectileIndex: 2, coolDown: 2000)
                    ),
                new State("FollowAndAttack",
                    new Wander(0.4),
                new Prioritize(
                    new Protect(1, "TestChicken 2", 100, 5, 5),
                    new Follow(1.5, 8, 1)
                    ),
                new State("OrbitPlayer",
                    new Orbit(0.8, 3, 10, "TestChicken 2"),
                    new Shoot(7, projectileIndex: 0, count: 10, fixedAngle: 25, coolDown: 750)
                    ),
                new State("orbitattacking",
                    new Orbit(0.7, 5.5, 10, "TestChicken 2"),
                    new Shoot(20, projectileIndex: 3, count: 10, fixedAngle: 25, coolDown: 750)
                    ),
                    new State("Despawn",
                        new Suicide()
                    )
               )
                    )
            );
    }
}
