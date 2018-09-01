using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.logic.behaviors;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Asylum = () => Behav()
            .Init("BedlamGod",
                new State(
                    new State("1",
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(15, "2")
                        ),
                    new State("2",
                        new Taunt("Welcome to my Asylum…."),
                        new Spawn("Chaos Guardians", 3, coolDown: 1000),
                        new Spawn("Insane Patient", 5, coolDown: 1000),
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "3")
                        ),
                    new State("3",
                         new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                         new Shoot(20, 1, projectileIndex: 0, predictive: 1, coolDown: 500),
                         new Shoot(15, 3, 8, 1, predictive: 1, coolDown: 6000),
                         new Shoot(20, 16, 22.5, 4, 360, coolDown: 5000),
                         new EntityNotExistsTransition("Chaos Guardians", 20, "4")
                        ),
                    new State("4",
                        new RemoveConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Taunt("You will 'ALL' die here!"),
                        new Spawn("Roach", 4, 1, 1000),
                        new TimedTransition(1000, "5")
                        ),
                    new State("5",
                        new Follow(0.5, range: 40),
                         new Shoot(20, 1, projectileIndex: 0, predictive: 1, coolDown: 1000),
                         new Shoot(15, 3, 8, 1, predictive: 1, coolDown: 3000),
                         new Shoot(20, 8, 45, 3, 360, coolDown: 2000),
                         new Shoot(5, 2, 15, 2, predictive: 1, coolDown: 2000),
                         new HpLessTransition(.75, "6")
                        ),
                    new State("6",
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Taunt("Bring forth… THE CHAOS!"),
                        new Spawn("Nurse", 4, coolDown: 1000),
                        new TimedTransition(1000, "7")
                        ),
                    new State("7",
                        new RemoveConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Wander(1),
                        new StayAbove(1, 1),
                        new Reproduce("Chaos Guardians", 0, 3, 7000),
                        new Shoot(20, 1, projectileIndex: 0, predictive: 1, coolDown: 1000),
                        new Shoot(15, 3, 8, 1, predictive: 1, coolDown: 3000),
                        new Shoot(20, 8, 45, 3, 360, coolDown: 2000),
                        new Shoot(5, 2, 15, 2, predictive: 1, coolDown: 2000),
                        new HpLessTransition(.50, "8")
                        ),
                    new State("8",
                        new Reproduce("Chaos Guardians", 0, 3, 5000),
                        new Shoot(20, 8, 45, 3, 360, coolDown: 2000),
                        new OrderOnce(99, "Chaos Guardians", "2"),
                        new HpLessTransition(.20, "9")
                        ),
                    new State("9",
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Taunt("You think this is over? Hah… The madness never ends…"),
                        new Shoot(20, 8, 45, 3, 360, coolDown: 1000),
                        new Spawn("Chaos Guardians", 3, 0, coolDown: 1000),
                        new Shoot(20, 16, 22.5, 4, 360, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(20, 16, 22.5, 4, 360, coolDown: 1000, coolDownOffset: 1000),
                        new TimedTransition(1000, "10")
                        ),
                    new State("10",
                        new RemoveConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Shoot(20, 1, projectileIndex: 0, predictive: 1, coolDown: 1000),
                         new Shoot(15, 3, 8, 1, predictive: 1, coolDown: 3000),
                         new Shoot(20, 8, 45, 3, 360, coolDown: 2000),
                         new Shoot(20, 16, 22.5, 4, 360, coolDown: 3500),
                         new Shoot(5, 2, 15, 2, predictive: 1, coolDown: 2000),
                         new Reproduce("Chaos Guardians", 0.5, 3, coolDown: 2000),
                         new Reproduce("Roach", 0.5, 5, coolDown: 500)
                             )
                        ),
                            new Threshold(0.05,
                                new ItemLoot("Potion of Might", 0.5),
                                new ItemLoot("Potion of Protection", 0.5),
                                new ItemLoot("Unholy Spell", 0.01),
                                new ItemLoot("Unholy Wand", 0.01)
                        )
                   )
                   .Init("Chaos Guardians",
                       new State(
                           new State("1",
                           new Orbit(1.5, 3.5),
                           new HealEntity(20, "BedlamGod", 80, 1000),
                           new Shoot(24, 8, 45, 0, 360, coolDown: 5000),
                           new Shoot(5, 1, projectileIndex: 1, predictive: 0.8, coolDown: 1000)
                               ),
                           new State("2",
                               new Follow(1.5, range: 16),
                               new HealEntity(1, "Bedlam, God of Chaos", 80, coolDown: 999999999),
                               new Shoot(10, 1, projectileIndex: 2, predictive: 1, coolDown: 1000)
                           )
                       )
                        )
                   .Init("Insane Patient",
                       new State(
                       new Wander(2),
                       new Protect(1, "BedlamGod", 5, 2),
                       new Shoot(10, 1, projectileIndex: 0, predictive: 1, coolDown: 2000)
                           )
                           )
                   .Init("Nurse",
                       new State(
                        new Wander(1),
                        new StayBack(1.5, 3),
                        new Shoot(8, 1, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(30, 8, 45, 1, 360, coolDown: 3000)
                           )
                           )
                   .Init("Roach",
                        new State(
                            new Wander(3.5),
                            new Shoot(30, 1, projectileIndex: 0, predictive: 1, coolDown: 333)
                        )
            )
        .Init("AsylumStatue",
            new State(
                new State("1",
                    new ConditionalEffect(common.resources.ConditionEffectIndex.Paused),
                    new ConditionalEffect(common.resources.ConditionEffectIndex.Invincible),
                    new PlayerWithinTransition(6, "2")
                    ),
                new State("2",
                    new RemoveConditionalEffect(common.resources.ConditionEffectIndex.Paused),
                    new RemoveConditionalEffect(common.resources.ConditionEffectIndex.Invincible),
                    new NoPlayerWithinTransition(6, "1"),
                    new Shoot(10, 5, 7, 3, predictive: 1, coolDown: 1000),
                    new Shoot(10, 1, projectileIndex: 0, predictive: 1, coolDown: 500),
                    new Shoot(15, 2, 5, 1, 90, coolDown: 2000, coolDownOffset: 1000),
                    new Shoot(15, 2, 5, 2, 90, coolDown: 2000, coolDownOffset: 2000)
                    )
                )
            )
         .Init("AsylumGuard",
            new State(
                new ConditionalEffect(common.resources.ConditionEffectIndex.Armored),
                new Wander(0.1),
                new TossObject("AsylumBomb", 7, coolDown: 4500),
                new Shoot(12, 2, 10, coolDown: 3500),
                new State("1",
                    new Shoot(99, 4, 10, projectileIndex: 1, fixedAngle: 0, angleOffset: 0, coolDown: 999999),
                    new TimedTransition(500, "2")
                    ),
                new State("2",
                    new Shoot(99, 4, 10, projectileIndex: 1, fixedAngle: 0, angleOffset: 45, coolDown: 999999),
                    new TimedTransition(500, "3")
                    ),
                new State("3",
                    new Shoot(99, 4, 10, projectileIndex: 1, fixedAngle: 0, angleOffset: 90, coolDown: 999999),
                    new TimedTransition(500, "4")
                    ),
                new State("4",
                    new Shoot(99, 4, 10, projectileIndex: 1, fixedAngle: 0, angleOffset: 135, coolDown: 999999),
                    new TimedTransition(500, "5")
                    ),
                new State("5",
                    new Shoot(99, 4, 10, projectileIndex: 1, fixedAngle: 0, angleOffset: 180, coolDown: 999999),
                    new TimedTransition(500, "6")
                    ),
                new State("6",
                    new Shoot(99, 4, 10, projectileIndex: 1, fixedAngle: 0, angleOffset: 225, coolDown: 999999),
                    new TimedTransition(500, "7")
                    ),
                new State("7",
                    new Shoot(99, 4, 10, projectileIndex: 1, fixedAngle: 0, angleOffset: 270, coolDown: 999999),
                    new TimedTransition(500, "8")
                    ),
                new State("8",
                    new Shoot(99, 4, 10, projectileIndex: 1, fixedAngle: 0, angleOffset: 315, coolDown: 999999),
                    new TimedTransition(500, "9")
                    ),
                new State("9",
                    new TimedTransition(2000, "1")
                    )
                )
            )
        .Init("AsylumBomb",
            new State(
                new State("1",
                    new TimedTransition(2000, "2")
                    ),
                new State("2",
                    new Shoot(99, 8, 45, fixedAngle: 0),
                    new Suicide()
                    )
                )
            )

        .Init("AsylumMaggots",
            new State(
                new Wander(0.5),
                new Shoot(10, 1, projectileIndex: 0, predictive: 1, coolDown: 500)
                )
            )
        .Init("Bird3",
            new State(
                new ConditionalEffect(common.resources.ConditionEffectIndex.Invincible),
                new PlayerWithinTransition(3, "Move"),
                new NoPlayerWithinTransition(3, "Idle"),
                new State("Idle",
                    new ConditionalEffect(common.resources.ConditionEffectIndex.Invincible),
                    new State("Move",
            new ConditionalEffect(common.resources.ConditionEffectIndex.Invincible),
            new Wander(0.4)
                        )
                    )
            )
            )
        .Init("AsylumLootEye",
            new State(
                new State("1",
                    new ConditionalEffect(common.resources.ConditionEffectIndex.Invincible),
                    new PlayerWithinTransition(6, "2")
                    ),
                new State("2",
                    new RemoveConditionalEffect(common.resources.ConditionEffectIndex.Invincible),
                    new NoPlayerWithinTransition(6, "1"),
                    new Shoot(10, 16, 22.5, 0, 360, predictive: 0.3, coolDown: 500),
                    new TossObject("AsylumLootBomb", 6, coolDown: 500)
                    )
                )
            )
        .Init("AsylumLootBomb",
            new State(
                new State("1",
                    new PlayerWithinTransition(4, "2")
                    ),
                new State("2",
                    new Shoot(30, 8, 45, 0, 360, coolDown: 1000),
                    new TimedTransition(1000, "3")
                    ),
                new State("3",
                    new Suicide()
                    )
                )
            )
         .Init("Asylum Wizzard",
                new State(
                    new Spawn("Wizzard Spawn", 5, 0, 200),
                    new State("pause",
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "start_the_fun")
                        ),
                    new State("start_the_fun",
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1500, "Daisy_attack")
                        ),
                    new State("Daisy_attack",
                        new Prioritize(
                            new StayCloseToSpawn(0.3, 7),
                            new Wander(0.3)
                            ),
                        new State("Quadforce1",
                            new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(200, "Quadforce2")
                            ),
                        new State("Quadforce2",
                            new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(200, "Quadforce3")
                            ),
                        new State("Quadforce3",
                            new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(200, "Quadforce4")
                            ),
                        new State("Quadforce4",
                            new Shoot(10, projectileIndex: 3, coolDown: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(200, "Quadforce5")
                            ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(200, "Quadforce6")
                            ),
                        new State("Quadforce6",
                            new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(200, "Quadforce7")
                            ),
                        new State("Quadforce7",
                            new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(200, "Quadforce8")
                            ),
                        new State("Quadforce8",
                            new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                            new Shoot(10, projectileIndex: 3, coolDown: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(200, "Quadforce1")
                            ),
                        new HpLessTransition(0.3, "Whoa_nelly"),
                        new TimedTransition(18000, "Warning")
                        ),
                    new State("Warning",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 7),
                            new Wander(0.5)
                            ),
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 15),
                        new Follow(0.4, 9, 2),
                        new TimedTransition(3000, "Summon_the_clones")
                        ),
                    new State("Summon_the_clones",
                        new Prioritize(
                            new StayCloseToSpawn(0.85, 7),
                            new Wander(0.85)
                            ),
                        new Shoot(10, projectileIndex: 0, coolDown: 1000),
                        new Spawn("Wizzard Clone", 4, 0, 200),
                        new TossObject("Wizzard Clone", 5, 0, 100000),
                        new TossObject("Wizzard Clone", 5, 240, 100000),
                        new TossObject("Wizzard Clone", 7, 60, 100000),
                        new TossObject("Wizzard Clone", 7, 300, 100000),
                        new State("invulnerable_clone",
                            new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                            new TimedTransition(3000, "vulnerable_clone")
                            ),
                        new State("vulnerable_clone",
                            new TimedTransition(1200, "invulnerable_clone")
                            ),
                        new TimedTransition(16000, "Warning2")
                        ),
                    new State("Warning2",
                        new Prioritize(
                            new StayCloseToSpawn(0.85, 7),
                            new Wander(0.85)
                            ),
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 25),
                        new TimedTransition(5000, "Whoa_nelly")
                        ),
                    new State("Whoa_nelly",
                        new Prioritize(
                            new StayCloseToSpawn(0.6, 7),
                            new Wander(0.6)
                            ),
                        new Shoot(10, projectileIndex: 3, count: 3, shootAngle: 120, coolDown: 900),
                        new Shoot(10, projectileIndex: 2, count: 3, shootAngle: 15, fixedAngle: 40, coolDown: 1600,
                            coolDownOffset: 0),
                        new Shoot(10, projectileIndex: 2, count: 3, shootAngle: 15, fixedAngle: 220, coolDown: 1600,
                            coolDownOffset: 0),
                        new Shoot(10, projectileIndex: 2, count: 3, shootAngle: 15, fixedAngle: 130, coolDown: 1600,
                            coolDownOffset: 800),
                        new Shoot(10, projectileIndex: 2, count: 3, shootAngle: 15, fixedAngle: 310, coolDown: 1600,
                            coolDownOffset: 800),
                        new State("invulnerable_whoa",
                            new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2600, "vulnerable_whoa")
                            ),
                        new State("vulnerable_whoa",
                            new TimedTransition(1200, "invulnerable_whoa")
                            ),
                        new TimedTransition(10000, "Absolutely_Massive")
                        ),
                    new State("Absolutely_Massive",
                        new ChangeSize(13, 260),
                        new Prioritize(
                            new StayCloseToSpawn(0.2, 7),
                            new Wander(0.2)
                            ),
                        new Shoot(10, projectileIndex: 1, count: 9, shootAngle: 40, fixedAngle: 40, coolDown: 2000,
                            coolDownOffset: 400),
                        new Shoot(10, projectileIndex: 1, count: 9, shootAngle: 40, fixedAngle: 60, coolDown: 2000,
                            coolDownOffset: 800),
                        new Shoot(10, projectileIndex: 1, count: 9, shootAngle: 40, fixedAngle: 50, coolDown: 2000,
                            coolDownOffset: 1200),
                        new Shoot(10, projectileIndex: 1, count: 9, shootAngle: 40, fixedAngle: 70, coolDown: 2000,
                            coolDownOffset: 1600),
                        new State("invulnerable_mass",
                            new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2600, "vulnerable_mass")
                            ),
                        new State("vulnerable_mass",
                            new TimedTransition(1000, "invulnerable_mass")
                            ),
                        new TimedTransition(14000, "Start_over_again")
                        ),
                    new State("Start_over_again",
                        new ChangeSize(-20, 100),
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 15),
                        new TimedTransition(3000, "Daisy_attack")
                        )
                    ),
                new Threshold(1,
                    new ItemLoot("Potion of Vitality", 1)
                ),
                new Threshold(0.015,
                    new TierLoot(2, common.resources.ItemType.Potion, 0.07)
                    ),
                new Threshold(0.03,
                    new ItemLoot("Crystal Wand", 0.005),
                    new ItemLoot("Crystal Sword", 0.006)
                    )
            )
            .Init("Wizzard Clone",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(0.85, range: 5),
                        new Wander(0.85)
                        ),
                    new Shoot(10, coolDown: 1400),
                    new State("taunt",
                        new Taunt(0.09, "I am legion, for we are many!"),
                        new TimedTransition(1000, "no_taunt")
                        ),
                    new State("no_taunt",
                        new TimedTransition(1000, "taunt")
                        ),
                    new Decay(17000)
                    )
            )
            .Init("Wizzard Spawn",
                new State(
                    new State("change_position_fast",
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayCloseToSpawn(3.6, 12),
                            new Wander(3.6)
                            ),
                        new TimedTransition(800, "attack")
                        ),
                    new State("attack",
                        new Shoot(10, predictive: 0.3, coolDown: 500),
                        new State("keep_distance",
                            new Prioritize(
                                new StayCloseToSpawn(1, 12),
                                new Orbit(1, 9, target: "Asylum Wizzard", radiusVariance: 0)
                                ),
                            new TimedTransition(2000, "go_anywhere")
                            ),
                        new State("go_anywhere",
                            new Prioritize(
                                new StayCloseToSpawn(1, 12),
                                new Wander(1)
                                ),
                            new TimedTransition(2000, "keep_distance")
                            )
                        )
                    )
            )
        ;
    }
}