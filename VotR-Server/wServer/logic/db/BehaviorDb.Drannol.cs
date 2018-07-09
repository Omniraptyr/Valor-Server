using wServer.realm;
using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {

        private _ Drannol = () => Behav()

           .Init("BD Spirit Orb Green",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Green", 6, "die"),
                        new Prioritize(
                            new Follow(2.5, 16, 1),
                            new Wander(0.25)
                            )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
                   .Init("BD Spirit Orb Blue",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Blue", 6, "die"),
                        new Prioritize(
                            new Follow(2.5, 16, 1),
                            new Wander(0.25)
                        )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
                   .Init("BD Spirit Orb Purple",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Purple", 6, "die"),
                        new Prioritize(
                            new Follow(2.5, 16, 1),
                            new Wander(0.25)
                        )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
                   .Init("BD Spirit Orb Orange",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Orange", 6, "die"),
                        new Prioritize(
                            new Follow(2.5, 16, 1),
                            new Wander(0.25)
                        )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
            .Init("Spiritorb Holder Default Orange",
            new State(
                new TransformOnDeath("Spiritorb Holder Orange", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new EntityExistsTransition("BD Spirit Orb Orange", 6, "die")
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
            .Init("Spiritorb Holder Orange",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )

                    .Init("Spiritorb Holder Default Purple",
            new State(
                new TransformOnDeath("Spiritorb Holder Purple", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new EntityExistsTransition("BD Spirit Orb Purple", 6, "die")
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
            .Init("Spiritorb Holder Purple",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )


                .Init("BD Tookytesttask",
            new State(

                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new EntitiesNotExistsTransition(9999, "activate", "Spiritorb Holder Default Purple", "Spiritorb Holder Default Green", "Spiritorb Holder Default Blue", "Spiritorb Holder Default Orange")
                    ),
                new State("activate",
                     new Taunt(true, "Good job!")
                    )
                )
            )

        .Init("BD Lava Bat Spawner",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new PlayerWithinTransition(3, "spawn")
                    ),
                new State("spawn",
                    new Spawn("BD Lava Bat", 1, 1, coolDown: 99999),
                    new TimedTransition(20000, "idle")
                    )
                )
            )

            .Init("BD Logic 1",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )
                    .Init("BD Logic 2",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )
                            .Init("Spiritorb Holder Default Green",
            new State(
                new TransformOnDeath("Spiritorb Holder Green", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new EntityExistsTransition("BD Spirit Orb Green", 6, "die")
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
            .Init("Spiritorb Holder Green",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )


            .Init("Spiritorb Holder Default Blue",
            new State(
                new TransformOnDeath("Spiritorb Holder Blue", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new EntityExistsTransition("BD Spirit Orb Blue", 6, "die")
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )

            .Init("Torch of the Hunter B",
            new State(
                new TransformOnDeath("Torch of the Hunter A", 1, 1, 1),
                new State("Main",
                    new State("idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityExistsTransition("BD Logic 1", 999, "vuln")
                        ),
                    new State("vuln",
                        new HealSelf(coolDown: 8000)
                        )
                    )
                )
            )
                        .Init("Torch of the Hunter A",
            new State(
                new TransformOnDeath("Torch of the Hunter B", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle"
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )

            .Init("Spiritorb Holder Blue",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )

            .Init("BD Warrior of Drannol",
            new State(
                new State("Main",
                    new Shoot(10, count: 1, projectileIndex: 2, predictive: 1, coolDown: 1000),
                    new HpLessTransition(0.15, "heal"),
                    new State("fight1",
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 0, predictive: 0.5, coolDown: 400),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 8, projectileIndex: 1, coolDown: 1600),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 800),
                        new TimedTransition(4000, "fight1")
                        )
                    ),
                    new State("heal",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new HealSelf(coolDown: 1000, amount: 2500),
                        new Wander(0.25),
                        new Shoot(10, count: 6, shootAngle: 8, projectileIndex: 1, predictive: 0.5, coolDown: 1000),
                        new TimedTransition(2000, "run")
                        ),
                    new State("run",
                    new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 0, coolDown: 400, shootLowHp: true)
                        )
                )
            )
            .Init("BD Axeman of Drannol",
            new State(
                new State("Main",
                    new State("fight1",
                    new Prioritize(
                        new Follow(0.75, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 2, shootAngle: 4, projectileIndex: 0, coolDown: 800),
                        new DamageTakenTransition(1000, "fight2")
                        ),
                    new State("fight2",
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 3, shootAngle: 4, projectileIndex: 0, coolDown: 200),
                        new TimedTransition(2000, "fight3")
                        ),
                    new State("fight3",
                        new Wander(0.1),
                        new Shoot(10, count: 6, projectileIndex: 1, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 4, projectileIndex: 0, coolDown: 100),
                        new TimedTransition(2000, "fight2")
                        )
                    )
                )
            )
                    .Init("BD Lava Bat",
            new State(
                new State("Main",
                    new State("fight1",
                    new Prioritize(
                        new Follow(1, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 0, coolDown: new Cooldown(800, 2000), coolDownOffset: 1400)
                        )
                    )
                )
            )
                .Init("Bastille Trap",
            new State(
                new SetNoXP(),
                  new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State(
                    new PlayerWithinTransition(1, "blowup")
                    ),
                new State("blowup",
                    new ApplySetpiece("BastilleLava"),
                    new Suicide()
                    )
                )
            )
            .Init("BD Bastille Brute",
            new State(
                new State("Main",
                    new HpLessTransition(0.15, "run"),
                    new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 1, predictive: 1, coolDown: 3000),
                    new State("fight1",
                        new Wander(0.1),
                        new Shoot(10, count: 4, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, coolDown: 1000, coolDownOffset: 800),
                        new TimedTransition(4000, "warning")
                        ),
                    new State("warning",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(0.50, "Graaagh!"),
                        new Flash(0xFF0000, 0.5, 2),
                        new TimedTransition(1400, "charge")
                        ),
                    new State("charge",
                        new Charge(2, range: 10, coolDown: 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new PlayerWithinTransition(4, "leave")
                        ),
                    new State("leave",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Prioritize(
                        new StayBack(0.8, 6),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 14, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(3000, "run")
                        ),
                     new State("run",
                     new Prioritize(
                        new Follow(1.2, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 4, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, coolDown: 1000, coolDownOffset: 800),
                        new TimedTransition(4000, "warning2")
                        ),
                     new State("warning2",
                     new Prioritize(
                        new Follow(1.2, 8, 1),
                        new Wander(0.25)
                        ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(0.50, "Graaagh!"),
                        new Flash(0xFF0000, 0.5, 2),
                        new TimedTransition(1400, "charge2")
                        ),
                     new State("charge2",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Charge(2, range: 10, coolDown: 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new PlayerWithinTransition(4, "fight1")
                        )
                    ),
                    new State("run",
                        new Flash(0xFFFFFF, 0.25, 4),
                        new Taunt("GRAAAAGH!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 6),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HealSelf(coolDown: 9999, amount: 8000),
                     new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 3, coolDown: 1000),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 2, predictive: 1, coolDown: 2000, coolDownOffset: 400)
                        )
                )
            )
                    .Init("BD Lava Drake",
            new State(
                        new Prioritize(
                            new Orbit(0.7, 3, target: "BD Winged Beast"),
                            new Follow(0.5, 8, 1)
                            ),
                new State("Main",
                        new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 800),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Wander(0.5),
                        new Shoot(10, count: 8, projectileIndex: 2, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 16, projectileIndex: 0, coolDown: 800),
                        new TimedTransition(4000, "Main")
                        )
                    )
            )














                .Init("BD Winged Beast",
            new State(
                new State("Main",
                    new HpLessTransition(0.15, "rage"),
                    new State("fight1",
                        new Wander(0.1),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 8, projectileIndex: 1, coolDown: 1000, coolDownOffset: 1000),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Follow(0.8, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, count: 10, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(2000, "fight2b")
                        ),
                    new State("fight2b",
                        new Prioritize(
                            new Follow(0.8, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 3, shootAngle: 20, projectileIndex: 2, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, count: 6, projectileIndex: 2, coolDown: 2000, predictive: 1),
                        new TimedTransition(4000, "fight3")
                        ),
                    new State("fight3",
                        new Swirl(1, 3, 10),
                        new Shoot(10, count: 7, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 4, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(4000, "fight1")
                        )
                    ),
                   new State("rage",
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Follow(1.3, 8, 1),
                        new Shoot(10, count: 4, shootAngle: 6, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(3000, "rage2")
                        ),
                  new State("rage2",
                        new Shoot(10, count: 5, shootAngle: 6, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(2000, "rage")
                        )
                  )
            )
            .Init("BD Lava Golem",
            new State(
                new State("Main",
                    new State("fight1",
                        new Wander(0.1),
                        new Shoot(10, count: 6, shootAngle: 20, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 3, shootAngle: 40, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new BackAndForth(0.5, 3),
                        new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(4000, "fight3")
                        ),
                    new State("fight3",
                        new Prioritize(
                            new Follow(0.6, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 8, shootAngle: 20, projectileIndex: 0, coolDown: 3000),
                        new Shoot(10, count: 3, shootAngle: 40, projectileIndex: 1, coolDown: 1000),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            )
            .Init("BD Inferno Mage",
            new State(
                new State("Main",
                    new State("fight1",
                        new Prioritize(
                            new Follow(0.5, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 4, shootAngle: 18, projectileIndex: 0, coolDown: 1400),
                        new Shoot(10, count: 2, shootAngle: 30, projectileIndex: 0, coolDown: 1400, coolDownOffset: 600),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Wander(0.5),
                        new Shoot(10, count: 5, shootAngle: 18, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(4000, "fight3")
                        ),
                    new State("fight3",
                        new Prioritize(
                            new Follow(0.5, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 6, shootAngle: 24, projectileIndex: 0, coolDown: 1800),
                        new Shoot(10, count: 5, projectileIndex: 1, coolDown: 600),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            )
            .Init("BD Bastille Defender",
            new State(
                new State("Main",
                    new State("fight1",
                        new Orbit(0.5, 3, 10),
                        new Shoot(10, count: 2, shootAngle: 9, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 6, shootAngle: 12, projectileIndex: 1, coolDown: 3000),
                        new Grenade(4, 140, range: 8, coolDown: 1000),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                        new Wander(0.1),
                        new Shoot(10, count: 4, shootAngle: 9, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 800, coolDownOffset: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 800, coolDownOffset: 800),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 800, coolDownOffset: 1200),
                        new TimedTransition(4000, "fight3")
                        ),
                   new State("fight3",
                        new Prioritize(
                            new Follow(0.8, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 5, shootAngle: 20, projectileIndex: 2, coolDown: 2000),
                        new Grenade(1, 350, range: 8, coolDown: 4000),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            )
            .Init("BD Lava Fanatic",
            new State(
                new State("Main",
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(1, 8, 1),
                        new Wander(0.4)
                        ),
                    new State("fight1",
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 400),
                        new DamageTakenTransition(2000, "fight2")
                        ),
                    new State("fight2",
                        new ChangeSize(1, 140),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 1, coolDown: 400),
                        new DamageTakenTransition(2000, "fight3")
                        ),
                    new State("fight3",
                        new Shoot(10, count: 2, fixedAngle: 0, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 2, fixedAngle: 90, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 2, fixedAngle: 180, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 2, fixedAngle: 270, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new ChangeSize(1, 150),
                        new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 400)
                        )
                    )
                )
            )
            .Init("BD Inferno Brawler",
                new State(
                    new Prioritize(
                        new Follow(0.4, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 400),
                    new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 1, coolDown: 1200)
                    ),
                new Threshold(0.5,
                    new ItemLoot("Ravenheart Sword", 0.01),
                    new ItemLoot("Ring of Greater Dexterity", 0.01),
                    new ItemLoot("Golden Quiver", 0.01)
                    )
            )
            .Init("BD Inferno Assassin",
                new State(
                    new Prioritize(
                        new Follow(0.4, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 0, coolDown: 600)
                    ),
                new Threshold(0.5,
                    new ItemLoot("Ravenheart Sword", 0.01),
                    new ItemLoot("Staff of Diabolic Secrets", 0.01),
                    new ItemLoot("Golden Quiver", 0.01)
                    )
            )
                    .Init("BD Faint Soul",
                new State(
                    new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 100)
                    )
            )
            /*.Init("BD Stone Urgle",
            new State(
                new State("Main",
                    new State("fight1",
                        new Shoot(10, count: 4, shootAngle: 18, projectileIndex: 0, coolDown: 1400),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Shoot(10, count: 5, shootAngle: 18, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(4000, "fight3")
                        ),
                    new State("fight3",
                        new Shoot(10, count: 6, shootAngle: 24, projectileIndex: 0, coolDown: 1800),
                        new Shoot(10, count: 5, projectileIndex: 1, coolDown: 600),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            )*/

            .Init("BD Stone Orb",
            new State(
                new TransformOnDeath("BD Faint Soul", 1, 6),
                new State("Main",
                    new EntitiesNotExistsTransition(6, "die", "BD Stone Urgle"),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("fight1",
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(3200, "fight2")
                        ),
                    new State("fight2",
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(2000, "fight1")
                        )
                    ),
                    new State("die",
                        new Flash(0xFF0000, 1, 2),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 800),
                        new Suicide()
                        )
                )
            )
            .Init("BD Stone Urgle",
            new State(
                new Prioritize(
                        new StayCloseToSpawn(0.8, 3),
                        new Wander(0.5)
                        ),
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new State("idle",
                        new PlayerWithinTransition(8, "begin")
                        ),
                new State("begin",
                        new TossObject("BD Stone Orb", 6, 0, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 45, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 90, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 135, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 180, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 225, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 270, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 315, coolDown: 9999999),
                        new TimedTransition(4000, "Main")
                    )
                ),
                new State("Main",
                    new Grenade(6, 200, range: 10, coolDown: 4000),
                    new State("fight1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "fight2")
                        ),
                    new State("fight2",
                        new TimedTransition(1000, "fight1")
                        )
                    )
                )
            )

                      /*      .Init("BD Berikao, the Dark Hunter HUNTING",
                        new State(
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new State(
                            new State("waiting"
                                ),
                            new State("probing1",
                                new MoveTo(speed: 0.6f, x: 43, y: 42),
                                new TimedTransition(4000, "probing2")
                                ),
                            new State("probing2",
                                new MoveTo(speed: 0.6f, x: 41, y: 5),
                                new TimedTransition(4000, "probing3")
                                ),
                            new State("probing3",
                                new MoveTo(speed: 0.6f, x: 4, y: 5),
                                new TimedTransition(4000, "probing4")
                                ),
                            new State("probing4",
                                new MoveTo(speed: 0.6f, x: 5, y: 44),
                                new TimedTransition(4000, "probing1")
                             ),
                           new State("Reveal",
                                new Flash(0xFF0000, 0.25, 4),
                                new Taunt(0.75, "You are mine.."),
                                new SetAltTexture(0, 1, 10, true),
                                new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000),
                                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                new TimedTransition(2000, "jump")
                                ),
                           new State("jump",
                                new SetAltTexture(1),
                                new Charge(2.2, range: 14, coolDown: 1000),
                                new Shoot(10, count: 10, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                                new TimedTransition(1600, "Unreveal")
                                ),
                           new State("Unreveal",
                                new SetAltTexture(0, 1, 10, true),
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new TimedTransition(2000, "runback")
                                ),
                           new State("runback",
                                new SetAltTexture(0),
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new ReturnToSpawn(8),
                                new TimedTransition(7000, "probing1")
                                ),
                           new State("runbackwait",
                                new SetAltTexture(0),
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new ReturnToSpawn(8)
                                )
                           )
                         )
                    )*/


                      .Init("BD Berikao, the Dark Hunter HUNTING 1",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetNoXP(),
                    new State(
                        new PlayerWithinTransition(4, "Reveal"),
                    new State("probing1",
                        new MoveTo(speed: 0.8f, x: 43, y: 43),
                        new TimedTransition(9000, "probing2")
                        ),
                    new State("probing2",
                        new MoveTo(speed: 0.8f, x: 44, y: 4),
                        new TimedTransition(9000, "probing3")
                        ),
                    new State("probing3",
                        new MoveTo(speed: 0.8f, x: 4, y: 3),
                        new TimedTransition(9000, "probing4")
                        ),
                    new State("probing4",
                        new MoveTo(speed: 0.8f, x: 4, y: 45),
                        new TimedTransition(9000, "probing1")
                            )
                        ),
                    new State("Reveal",
                        new Follow(0.6, 8, 1),
                        new Flash(0xFF0000, 0.25, 4),
                        new Taunt(0.75, "You are mine..", "Right..where..I want you..", "There you are.."),
                        new SetAltTexture(0, 1, 10, true),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 3000),
                        new Shoot(10, count: 1, projectileIndex: 1, predictive: 0.5, coolDown: 3000, coolDownOffset: 1500),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3800, "jump")
                        ),
                   new State("jump",
                       new Taunt(0.75, "Heheheh..", "Bloodshed is so..gorgeous.."),
                        new SetAltTexture(1),
                        new Charge(7, range: 16, coolDown: 1000),
                        new Shoot(10, count: 10, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(3200, "Unreveal")
                        ),
                   new State("Unreveal",
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2000, "die")
                        ),
                   new State("die",
                        new Suicide()
                        )
                )
            )

            .Init("BD Tookytesttask2",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                    new EntityExistsTransition("BD Logic 1", 90, "pick")
                    ),
                new State("removeandwait",
                    new RemoveEntity(999, "BD Berikao, the Dark Hunter HUNTING 1"),
                    new RemoveEntity(999, "BD Berikao, the Dark Hunter HUNTING 2"),
                    new TimedTransition(4000, "idle")
                    ),
                new State(
                    new EntityExistsTransition("BD Logic 2", 90, "removeandwait"),
                new State("pick",
                    new TimedRandomTransition(4000, false, "spawn1", "spawn2")
                    ),
                new State("spawn1",
                    new Spawn("BD Berikao, the Dark Hunter HUNTING 1", 1, 1, coolDown: 99999),
                    new TimedTransition(4000, "spawn1B")
                    ),
                new State("spawn1B",
                    new EntitiesNotExistsTransition(999, "pick", "BD Berikao, the Dark Hunter HUNTING 1")
                    ),
                new State("spawn2",
                    new Spawn("BD Berikao, the Dark Hunter HUNTING 2", 1, 1, coolDown: 99999),
                    new TimedTransition(4000, "spawn2B")
                    ),
                new State("spawn2B",
                    new EntitiesNotExistsTransition(999, "pick", "BD Berikao, the Dark Hunter HUNTING 2")
                        )
                    )
                )
            )

                              .Init("BD Berikao, the Dark Hunter HUNTING 2",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetNoXP(),
                    new State(
                        new PlayerWithinTransition(4, "Reveal"),
                    new State("probing1",
                        new MoveTo(speed: 0.8f, x: 4, y: 45),
                        new TimedTransition(9000, "probing2")
                            ),
                    new State("probing2",
                        new MoveTo(speed: 0.8f, x: 4, y: 3),
                        new TimedTransition(9000, "probing3")
                        ),
                    new State("probing3",
                        new MoveTo(speed: 0.8f, x: 44, y: 4),
                        new TimedTransition(9000, "probing4")
                        ),
                    new State("probing4",
                        new MoveTo(speed: 0.8f, x: 43, y: 43),
                        new TimedTransition(9000, "probing1")
                        )
                    ),
                    new State("Reveal",
                        new Follow(0.6, 8, 1),
                        new Flash(0xFF0000, 0.25, 4),
                        new Taunt(0.75, "You are mine..", "Right..where..I want you..", "There you are.."),
                        new SetAltTexture(0, 1, 10, true),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 3000),
                        new Shoot(10, count: 1, projectileIndex: 1, predictive: 0.5, coolDown: 3000, coolDownOffset: 1500),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3800, "jump")
                        ),
                   new State("jump",
                       new Taunt(0.75, "Heheheh..", "Bloodshed is so..gorgeous.."),
                        new SetAltTexture(1),
                        new Charge(7, range: 16, coolDown: 1000),
                        new Shoot(10, count: 10, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(3200, "Unreveal")
                        ),
                   new State("Unreveal",
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2000, "die")
                        ),
                   new State("die",
                        new Suicide()
                        )
                )
            )


            .Init("BD Berikao, the Dark Hunter",
                new State(
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(8, "taunt1")
                        ),
                    new State("taunt1",
                        new Taunt("The shadows are what I thrive in..", "Get used to the darkness..for it will be your forever once I am through with you."),
                        new TimedTransition(2000, "taunt2")
                        ),
                    new State("taunt2",
                        new SetAltTexture(0, 1, 10, true),
                        new Taunt("Just let me get adjusted here..."),
                        new TimedTransition(4000, "taunt3")
                        ),
                    new State("taunt3",
                        new SetAltTexture(1),
                        new Taunt("Ah, yes..now where were we?"),
                        new TimedTransition(2000, "fight1")
                        )
                     ),
                    new State("fight1",
                        new RemoveEntity(60, "BD Logic 2"),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new TossObject("BD Bastille Brute", range: 10, coolDown: 6000, probability: 0.75),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "fight1a")
                        ),
                     new State("fight1a",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "fight1b")
                        ),
                     new State("fight1b",
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Swirl(0.5, 2),
                        new Shoot(10, count: 7, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 14, projectileIndex: 2, predictive: 0.5, coolDown: 1000),
                        new Shoot(10, count: 4, projectileIndex: 4, predictive: 0.5, coolDown: 2000),
                        new Shoot(10, count: 4, shootAngle: 30, projectileIndex: 4, predictive: 0.5, coolDown: 2000, coolDownOffset: 800),
                        new TimedTransition(5000, "fight2a")
                        ),
                    new State("fight2a",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 400),

                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 0, projectileIndex: 1, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),
                        new TimedTransition(8000, "fight2b")
                        ),
                    new State("fight2b",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Follow(0.4, 8, 1),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 400),

                        new Shoot(10, count: 7, shootAngle: 18, fixedAngle: 0, projectileIndex: 0, coolDown: 1000, coolDownOffset: 500),
                        new TimedTransition(8000, "phase")
                        ),
                    new State("phase",
                        new HealSelf(coolDown: 1000, amount: 40000),
                        new Taunt("Run, fools. You can't stand a chance in the darkness."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "phase2")
                        ),
                    new State("phase2",
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(4000, "phase3")
                        ),
                    new State("phase3",
                        new Prioritize(
                            new Follow(1.5),
                            new Wander(0.1)
                            ),
                        new SetAltTexture(0),
                        new PlayerWithinTransition(3, "phase2", seeInvis: true)
                        ),
                    new State("phase2",
                        new Taunt(0.75, "I see you, fool..your legacy ends here."),
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "jump")
                        ),
                    new State("jump",
                        new SetAltTexture(1),
                        new Charge(2, range: 10, coolDown: 4000),
                        new Shoot(10, count: 22, projectileIndex: 0, coolDown: 4000),
                        new PlayerWithinTransition(1, "runback")
                        ),
                    new State("runback",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "fight3")
                        ),
                    new State("fight3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 3, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "fight4")
                        ),
                    new State("fight4",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 7, shootAngle: 10, projectileIndex: 4, predictive: 1, coolDown: 2000),
                        new Shoot(10, count: 4, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "shadows")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("shadows",
                        new HealSelf(coolDown: 9999, amount: 60000),
                        new ConditionEffectRegion(ConditionEffectIndex.Darkness, 999, -1),
                        new SetAltTexture(0, 1, 10, true),
                        new Taunt("Let the fun begin...", "LIGHTS OFF!"),
                        new ReturnToSpawn(2),
                        new TimedTransition(5000, "shadowswait")
                        ),
                    new State("shadowswait",
                        new SetAltTexture(0),
                        new Spawn("BD Logic 1", 1, 1, coolDown: 99999),
                        new EntitiesNotExistsTransition(9999, "shadowswait2", "Torch of the Hunter B")
                        ),
                    new State("shadowswait2",
                        new SetAltTexture(1),
                        new ConditionEffectRegion(ConditionEffectIndex.Darkness, 999, 0),
                        new RemoveEntity(60, "BD Logic 1"),
                        new Spawn("BD Logic 2", 1, 1, coolDown: 99999),
                        new Order(999, "Torch of the Hunter A", "die"),
                        new TimedTransition(4000, "fight1")
                            )
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLoot2B()
                ),
                new MostDamagers(3,
                    LootTemplates.SFLow()
                    ),
                new Threshold(0.05,
                    new TierLoot(12, ItemType.Weapon, 0.08),
                    new TierLoot(5, ItemType.Ability, 0.07),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(13, ItemType.Armor, 0.06),
                    new TierLoot(7, ItemType.Ring, 0.08),
                    new ItemLoot("Greater Potion of Life", 1),
                    new ItemLoot("Greater Potion of Defense", 1),
                    new ItemLoot("Greater Potion of Attack", 0.6),
                    new ItemLoot("Greater Potion of Dexterity", 0.5),
                    new ItemLoot("Greater Potion of Vitality", 0.5),
                    new ItemLoot("Greater Potion of Speed", 0.5),
                    new ItemLoot("Greater Potion of Mana", 0.5)
                )
            );
    }
}