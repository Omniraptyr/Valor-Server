#region

using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

//FULLY SHATTERS
//BEHAVIORS
//MADE BY
//MIKE (Qkm)
//MOISTED ON BY PATPOT

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Shatters = () => Behav()
        #region restofmobs
            .Init("shtrs Stone Paladin",
                new State(
                    new State("Idle",
                        new Prioritize(
                            new Wander(0.8)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Reproduce(densityMax: 4),
                        new PlayerWithinTransition(8, "Attacking")
                        ),
                    new State("Attacking",
                        new State("Bullet",
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 140, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 170, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 2000, shootAngle: 45),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 170, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 140, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 2000, shootAngle: 22.5),
                            new TimedTransition(2000, "Wait")
                            ),
                        new State("Wait",
                            new Follow(0.4, range: 2),
                            new Flash(0xff00ff00, 0.1, 20),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2000, "Bullet")
                            ),
                        new NoPlayerWithinTransition(13, "Idle")
                        )
                    )
            )
            .Init("shtrs Stone Knight",
            new State(
                new State("Follow",
                        new Follow(0.6, 10, 5),
                        new PlayerWithinTransition(5, "Charge")
                    ),
                    new State("Charge",
                        new TimedTransition(2000, "Follow"),
                        new Charge(2.5, 6, coolDown: 2000),
                        new Shoot(5, 16, projectileIndex: 0, coolDown: 2400, coolDownOffset: 400)
                        )
                    )
            )
        .Init("shtrs Lava Souls",
                new State(
                    new State("active",
                        new Follow(.7, range: 0),
                        new PlayerWithinTransition(2, "blink")
                    ),
                    new State("blink",
                        new Flash(0xfFF0000, flashRepeats: 10000, flashPeriod: 0.1),
                        new TimedTransition(2000, "explode")
                    ),
                    new State("explode",
                        new Flash(0xfFF0000, flashRepeats: 5, flashPeriod: 0.1),
                        new Shoot(5, 9),
                        new Suicide()
                    )
                )
            )
            .Init("shtrs Glassier Archmage",
            new State(
                    new StayBack(0.5, 5),
                new State("1st",
                    new Follow(0.8, range: 7),
                    new Shoot(20, projectileIndex: 2, count: 1, coolDown: 50),
                    new TimedTransition(5000, "next")
                    ),
                new State("next",
                    new Shoot(35, projectileIndex: 0, count: 25, coolDown: 5000),
                    new TimedTransition(25, "1st")
                    )
               )
        )
            .Init("shtrs Ice Adept",
            new State(
                new State("Main",
                    new TimedTransition(5000, "Throw"),
                    new Follow(0.8, range: 1),
                    new Shoot(10, 1, projectileIndex: 0, coolDown: 100, predictive: 1),
                    new Shoot(10, 3, projectileIndex: 1, shootAngle: 10, coolDown: 4000, predictive: 1)
                ),
                new State("Throw",
                    new TossObject("shtrs Ice Portal", 5, coolDown: 8000, coolDownOffset: 7000),
                    new TimedTransition(1000, "Main")
                )
                  ))

            .Init("shtrs Fire Adept",
            new State(
                new State("Main",
                    new TimedTransition(5000, "Throw"),
                    new Follow(0.8, range: 1),
                    new Shoot(10, 1, projectileIndex: 0, coolDown: 100, predictive: 1),
                    new Shoot(10, 3, projectileIndex: 1, shootAngle: 10, coolDown: 4000, predictive: 1)
                ),
                new State("Throw",
                    new TossObject("shtrs Fire Portal", 5, coolDown: 8000, coolDownOffset: 7000),
                    new TimedTransition(1000, "Main")
                )
                  ))
        #endregion restofmobs
        #region generators
            .Init("shtrs MagiGenerators",
            new State(
                new State("Main",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Shoot(15, 10, coolDown: 1000),
                    new Shoot(15, 1, projectileIndex: 1, coolDown: 2500),
                    new EntitiesNotExistsTransition(30, "Hide", "Shtrs Twilight Archmage", "shtrs Inferno", "shtrs Blizzard")
                ),
                new State("Hide",
                    new SetAltTexture(1),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                    ),
                new State("vulnerable",
                    new ConditionalEffect(ConditionEffectIndex.Armored)
                    ),
                new State("Despawn",
                    new Decay()
                    )
                  ))
        #endregion generators
        #region portals
            .Init("shtrs Ice Portal",
                new State(
                    new State("Idle",
                        new TimedTransition(1000, "Spin")
                    ),
                    new State("Spin",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1200),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 1200, coolDownOffset: 200),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 1200, coolDownOffset: 400),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 1200, coolDownOffset: 600),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 1200, coolDownOffset: 800),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 1200, coolDownOffset: 1000),
                            new TimedTransition(1200, "Pause")
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Idle")
                    )
                )
            )
            .Init("shtrs Fire Portal",
                new State(
                    new State("Idle",
                        new TimedTransition(1000, "Spin")
                    ),
                    new State("Spin",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1200),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 1200, coolDownOffset: 200),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 1200, coolDownOffset: 400),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 1200, coolDownOffset: 600),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 1200, coolDownOffset: 800),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 1200, coolDownOffset: 1000),
                            new TimedTransition(1200, "Pause")
                    ),
                    new State("Pause",
                       new TimedTransition(5000, "Idle")
                    )
                )
            )
            .Init("shtrs Ice Shield",
                new State(
                    new HpLessTransition(.2, "Death"),
                    new State(
                        new Charge(0.6, 7, coolDown: 5000),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 0, coolDown: 1200),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 10, coolDown: 1200, coolDownOffset: 200),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 20, coolDown: 1200, coolDownOffset: 400),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 30, coolDown: 1200, coolDownOffset: 600),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 40, coolDown: 1200, coolDownOffset: 800),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 50, coolDown: 1200, coolDownOffset: 1000)
                    ),
                    new State("Death",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(13, 45, 8, projectileIndex: 1, fixedAngle: 1, coolDown: 10000),
                        new Timed(1000, new Suicide())
                    )
                )
            )
            .Init("shtrs Ice Shield 2",
            new State(
                new HpLessTransition(0.3, "Death"),
                new State(
                    new Orbit(0.5, 5, 1, "shtrs Twilight Archmage"),
                    new Charge(0.1, 6, coolDown: 10000),
                new Shoot(13, 10, 8, projectileIndex: 0, coolDown: 1000, fixedAngle: 1)
                ),
            new State("Death",
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new Shoot(13, 45, projectileIndex: 1, coolDown: 10000),
                new Timed(1000, new Suicide())
                )
                )
            )
        #endregion portals
        #region 1stboss
            .Init("shtrs Bridge Sentinel",
                new State(
                    new Shoot(2, projectileIndex: 5, count: 3, fixedAngle: 0, coolDown: 10),
                    new Shoot(2, projectileIndex: 5, count: 3, fixedAngle: 45, coolDown: 10),
                    new Shoot(2, projectileIndex: 5, count: 3, fixedAngle: 90, coolDown: 10),
                    new Shoot(2, projectileIndex: 5, count: 3, fixedAngle: 135, coolDown: 10),
                    new Shoot(2, projectileIndex: 5, count: 3, fixedAngle: 180, coolDown: 10),
                    new HpLessTransition(0.1, "Death"),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(15, "Close Bridge")
                        ),
                    new State("Close Bridge",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Order(46, "shtrs Bridge Closer", "Closer"),
                        new TimedTransition(5000, "Close Bridge2")
                        ),
                    new State("Close Bridge2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Order(46, "shtrs Bridge Closer2", "Closer"),
                        new TimedTransition(5000, "Close Bridge3")
                        ),
                    new State("Close Bridge3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Order(46, "shtrs Bridge Closer3", "Closer"),
                        new TimedTransition(5000, "Close Bridge4")
                        ),
                    new State("Close Bridge4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Order(46, "shtrs Bridge Closer4", "Closer"),
                        new TimedTransition(6000, "BEGIN")
                        ),
                    new State("BEGIN",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntitiesNotExistsTransition(30, "Wake", "shtrs Bridge Obelisk A", "shtrs Bridge Obelisk B", "shtrs Bridge Obelisk D", "shtrs Bridge Obelisk E")
                    ),
                        new State("Wake",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Who has woken me...? Leave this place."),
                        new Timed(2100, new Shoot(15, 15, 12, projectileIndex: 0, fixedAngle: 180, coolDown: 700, coolDownOffset: 3000)),
                        new TimedTransition(8000, "Swirl Shot")
                        ),
                        new State("Swirl Shot",
                            new Taunt("Go."),
                            new TimedTransition(10000, "Blobomb"),
                            new State("Swirl1",
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 102, fixedAngle: 102, coolDown: 6000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 114, fixedAngle: 114, coolDown: 6000, coolDownOffset: 200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 126, fixedAngle: 126, coolDown: 6000, coolDownOffset: 400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 138, fixedAngle: 138, coolDown: 6000, coolDownOffset: 600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 150, fixedAngle: 150, coolDown: 6000, coolDownOffset: 800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 162, fixedAngle: 162, coolDown: 6000, coolDownOffset: 1000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 174, fixedAngle: 174, coolDown: 6000, coolDownOffset: 1200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 186, fixedAngle: 186, coolDown: 6000, coolDownOffset: 1400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 198, fixedAngle: 198, coolDown: 6000, coolDownOffset: 1600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 210, fixedAngle: 210, coolDown: 6000, coolDownOffset: 1800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 222, fixedAngle: 222, coolDown: 6000, coolDownOffset: 2000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 234, fixedAngle: 234, coolDown: 6000, coolDownOffset: 2200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 246, fixedAngle: 246, coolDown: 6000, coolDownOffset: 2400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 258, fixedAngle: 258, coolDown: 6000, coolDownOffset: 2600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 270, fixedAngle: 270, coolDown: 6000, coolDownOffset: 2800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 282, fixedAngle: 282, coolDown: 6000, coolDownOffset: 3000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 270, fixedAngle: 270, coolDown: 6000, coolDownOffset: 3200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 258, fixedAngle: 258, coolDown: 6000, coolDownOffset: 3400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 246, fixedAngle: 246, coolDown: 6000, coolDownOffset: 3600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 234, fixedAngle: 234, coolDown: 6000, coolDownOffset: 3800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 222, fixedAngle: 222, coolDown: 6000, coolDownOffset: 4000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 210, fixedAngle: 210, coolDown: 6000, coolDownOffset: 4200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 198, fixedAngle: 198, coolDown: 6000, coolDownOffset: 4400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 186, fixedAngle: 186, coolDown: 6000, coolDownOffset: 4600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 174, fixedAngle: 174, coolDown: 6000, coolDownOffset: 4800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 162, fixedAngle: 162, coolDown: 6000, coolDownOffset: 5000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 150, fixedAngle: 150, coolDown: 6000, coolDownOffset: 5200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 138, fixedAngle: 138, coolDown: 6000, coolDownOffset: 5400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 126, fixedAngle: 126, coolDown: 6000, coolDownOffset: 5600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 114, fixedAngle: 114, coolDown: 6000, coolDownOffset: 5800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 102, fixedAngle: 102, coolDown: 6000, coolDownOffset: 6000),
                            new TimedTransition(6000, "Swirl1")
                            )
                            ),
                            new State("Blobomb",
                            new Taunt("You live still? DO NOT TEMPT FATE!"),
                            new Taunt("CONSUME!"),
                            new Order(20, "shtrs blobomb maker", "Spawn"),
                            new EntityNotExistsTransition("shtrs Blobomb", 30, "SwirlAndShoot")
                                ),
                                new State("SwirlAndShoot",
                                    new TimedTransition(10000, "Blobomb"),
                                    new Taunt("FOOLS! YOU DO NOT UNDERSTAND!"),
                                    new ChangeSize(20, 130),
                            new Shoot(15, 15, 11, projectileIndex: 0, fixedAngle: 180, coolDown: 700, coolDownOffset: 700),
                                    new State("Swirl1_2",
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 102, fixedAngle: 102, coolDown: 6000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 114, fixedAngle: 114, coolDown: 6000, coolDownOffset: 200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 126, fixedAngle: 126, coolDown: 6000, coolDownOffset: 400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 138, fixedAngle: 138, coolDown: 6000, coolDownOffset: 600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 150, fixedAngle: 150, coolDown: 6000, coolDownOffset: 800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 162, fixedAngle: 162, coolDown: 6000, coolDownOffset: 1000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 174, fixedAngle: 174, coolDown: 6000, coolDownOffset: 1200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 186, fixedAngle: 186, coolDown: 6000, coolDownOffset: 1400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 198, fixedAngle: 198, coolDown: 6000, coolDownOffset: 1600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 210, fixedAngle: 210, coolDown: 6000, coolDownOffset: 1800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 222, fixedAngle: 222, coolDown: 6000, coolDownOffset: 2000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 234, fixedAngle: 234, coolDown: 6000, coolDownOffset: 2200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 246, fixedAngle: 246, coolDown: 6000, coolDownOffset: 2400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 258, fixedAngle: 258, coolDown: 6000, coolDownOffset: 2600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 270, fixedAngle: 270, coolDown: 6000, coolDownOffset: 2800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 282, fixedAngle: 282, coolDown: 6000, coolDownOffset: 3000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 270, fixedAngle: 270, coolDown: 6000, coolDownOffset: 3200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 258, fixedAngle: 258, coolDown: 6000, coolDownOffset: 3400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 246, fixedAngle: 246, coolDown: 6000, coolDownOffset: 3600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 234, fixedAngle: 234, coolDown: 6000, coolDownOffset: 3800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 222, fixedAngle: 222, coolDown: 6000, coolDownOffset: 4000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 210, fixedAngle: 210, coolDown: 6000, coolDownOffset: 4200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 198, fixedAngle: 198, coolDown: 6000, coolDownOffset: 4400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 186, fixedAngle: 186, coolDown: 6000, coolDownOffset: 4600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 174, fixedAngle: 174, coolDown: 6000, coolDownOffset: 4800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 162, fixedAngle: 162, coolDown: 6000, coolDownOffset: 5000),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 150, fixedAngle: 150, coolDown: 6000, coolDownOffset: 5200),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 138, fixedAngle: 138, coolDown: 6000, coolDownOffset: 5400),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 126, fixedAngle: 126, coolDown: 6000, coolDownOffset: 5600),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 114, fixedAngle: 114, coolDown: 6000, coolDownOffset: 5800),
                            new Shoot(50, projectileIndex: 0, count: 1, shootAngle: 102, fixedAngle: 102, coolDown: 6000, coolDownOffset: 6000),
                            new TimedTransition(6000, "Swirl1_2")
                            )
                                ),
                        new State("Death",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new CopyDamageOnDeath("shtrs Loot Balloon Bridge"),
                            new Taunt("I tried to protect you... I have failed. You release a great evil upon this realm...."),
                            new TimedTransition(2000, "Suicide")
                            ),
                        new State("Suicide",
                            new Shoot(35, projectileIndex: 0, count: 30),
                            new Order(1, "shtrs Chest Spawner 1", "Open"),
                            new Suicide()
                    )
                )
            )
        #endregion 1stboss
        #region blobomb
            .Init("shtrs Blobomb",
                new State(
                    new State("active",
                        new Follow(.7,acquireRange: 40, range: 0),
                        new PlayerWithinTransition(2, "blink")
                    ),
                    new State("blink",
                        new Flash(0xfFF0000, flashRepeats: 10000, flashPeriod: 0.1),
                        new TimedTransition(2000, "explode")
                    ),
                    new State("explode",
                        new Flash(0xfFF0000, flashRepeats: 5, flashPeriod: 0.1),
                        new Shoot(30, 36, fixedAngle: 0),
                        new Suicide()
                    )
                )
            )
        #endregion blobomb
        #region 2ndboss
            .Init("shtrs Twilight Archmage",
                new State(
                    new HpLessTransition(.1, "Death"),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntitiesNotExistsTransition(6, "Wake", "shtrs Archmage of Flame")
                    ),
                    new State("Wake",
                        new State("Comment1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new SetAltTexture(1),
                            new Taunt("Ha...ha........hahahahahaha! You will make a fine sacrifice!"),
                            new TimedTransition(3000, "Comment2")
                        ),
                        new SetAltTexture(1),
                        new State("Comment2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("You will find that it was...unwise...to wake me."),
                            new TimedTransition(1000, "Comment3")
                        ),
                        new State("Comment3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new SetAltTexture(1),
                            new Taunt("Let us see what can conjure up!"),
                            new TimedTransition(1000, "Comment4")
                        ),
                        new State("Comment4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new SetAltTexture(1),
                            new Taunt("I will freeze the life from you!"),
                            new TimedTransition(1000, "Shoot")
                        )
                    ),
                    new State("TossShit",
                        new TossObject("shtrs Ice Portal", 10, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 15, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 15, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 7, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 1, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 4, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 8, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 9, coolDown: 25000),        //NOT IN USE!
                        new TossObject("shtrs FireBomb", 5, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 7, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 11, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 13, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 12, coolDown: 25000),
                        new TossObject("shtrs FireBomb", 10, coolDown: 25000),
                        new Spawn("shtrs Ice Shield 2", maxChildren: 1, initialSpawn: 1, coolDown: 25000),
                        new TimedTransition(1, "Shoot")
                        ),
                  new State("Shoot",
                    new Shoot(15, 5, 5, projectileIndex: 1, coolDown: 800),
                    new Shoot(15, 5, 5, projectileIndex: 1, coolDown: 800, coolDownOffset: 200),
                    new Shoot(15, 5, 5, projectileIndex: 1, coolDown: 800, coolDownOffset: 400),
                    new Shoot(15, 5, 5, projectileIndex: 1, coolDown: 800, coolDownOffset: 600),
                    new Shoot(15, 5, 5, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),
                    new TimedTransition(800, "Shoot"),
                    new HpLessTransition(0.50, "Pre Birds")
                        ),
                    new State("Pre Birds",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("You leave me no choice...Inferno! Blizzard!"),
                        new TimedTransition(2000, "Birds")
                        ),
                    new State("Birds",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Spawn("shtrs Inferno", maxChildren: 1, initialSpawn: 1, coolDown: 1000000000),
                        new Spawn("shtrs Blizzard", maxChildren: 1, initialSpawn: 1, coolDown: 1000000000),
                        new EntitiesNotExistsTransition(500, "PreNewShit2", "shtrs Inferno", "shtrs Blizzard")
                        ),
                    new State("PreNewShit2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(1),
                        new TimedTransition(3000, "NewShit2")
                        ),
                    new State("NewShit2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new MoveTo2(0, -6, 1),
                        new TimedTransition(3000, "Active2")
                        ),
                    new State("Active2",
                        new Taunt("THE POWER...IT CONSUMES ME!"),
                        new Order(2, "shtrs MagiGenerators", "vulnerable"),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 100),
                        new Shoot(15, 20, projectileIndex: 3, coolDown: 100000000, coolDownOffset: 200),
                        new Shoot(15, 20, projectileIndex: 4, coolDown: 100000000, coolDownOffset: 300),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 400),
                        new Shoot(15, 20, projectileIndex: 5, coolDown: 100000000, coolDownOffset: 500),
                        new Shoot(15, 20, projectileIndex: 6, coolDown: 100000000, coolDownOffset: 600),
                        new TimedTransition(2000, "NewShit3")
                        ),
                    new State("NewShit3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new MoveTo2(4, 0, 1),
                        new TimedTransition(3000, "Active3")
                        ),
                    new State("Active3",
                        new Taunt("THE POWER...IT CONSUMES ME!"),
                        new Order(2, "shtrs MagiGenerators", "vulnerable"),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 100),
                        new Shoot(15, 20, projectileIndex: 3, coolDown: 100000000, coolDownOffset: 200),
                        new Shoot(15, 20, projectileIndex: 4, coolDown: 100000000, coolDownOffset: 300),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 400),
                        new Shoot(15, 20, projectileIndex: 5, coolDown: 100000000, coolDownOffset: 500),
                        new Shoot(15, 20, projectileIndex: 6, coolDown: 100000000, coolDownOffset: 600),
                        new TimedTransition(2000, "NewShit4")
                        ),
                    new State("NewShit4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new MoveTo2(0, 13, 1),
                        new TimedTransition(3000, "Active4")
                            ),
                    new State("Active4",
                        new Taunt("THE POWER...IT CONSUMES ME!"),
                        new Order(2, "shtrs MagiGenerators", "vulnerable"),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 100),
                        new Shoot(15, 20, projectileIndex: 3, coolDown: 100000000, coolDownOffset: 200),
                        new Shoot(15, 20, projectileIndex: 4, coolDown: 100000000, coolDownOffset: 300),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 400),
                        new Shoot(15, 20, projectileIndex: 5, coolDown: 100000000, coolDownOffset: 500),
                        new Shoot(15, 20, projectileIndex: 6, coolDown: 100000000, coolDownOffset: 600),
                        new TimedTransition(2000, "NewShit5")
                        ),
                    new State("NewShit5",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new MoveTo2(-4, 0, 1),
                        new TimedTransition(3000, "Active5")
                            ),
                    new State("Active5",
                        new Taunt("THE POWER...IT CONSUMES ME!"),
                        new Order(2, "shtrs MagiGenerators", "vulnerable"),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 100),
                        new Shoot(15, 20, projectileIndex: 3, coolDown: 100000000, coolDownOffset: 200),
                        new Shoot(15, 20, projectileIndex: 4, coolDown: 100000000, coolDownOffset: 300),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 400),
                        new Shoot(15, 20, projectileIndex: 5, coolDown: 100000000, coolDownOffset: 500),
                        new Shoot(15, 20, projectileIndex: 6, coolDown: 100000000, coolDownOffset: 600),
                        new TimedTransition(2000, "NewShit6")
                        ),
                    new State("NewShit6",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new MoveTo2(-4, 0, 1),
                        new TimedTransition(3000, "Active6")
                            ),
                    new State("Active6",
                        new Taunt("THE POWER...IT CONSUMES ME!"),
                        new Order(2, "shtrs MagiGenerators", "vulnerable"),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 100),
                        new Shoot(15, 20, projectileIndex: 3, coolDown: 100000000, coolDownOffset: 200),
                        new Shoot(15, 20, projectileIndex: 4, coolDown: 100000000, coolDownOffset: 300),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 400),
                        new Shoot(15, 20, projectileIndex: 5, coolDown: 100000000, coolDownOffset: 500),
                        new Shoot(15, 20, projectileIndex: 6, coolDown: 100000000, coolDownOffset: 600),
                        new TimedTransition(2000, "NewShit7")
                        ),
                    new State("NewShit7",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new MoveTo2(0, -13, 1),
                        new TimedTransition(3000, "Active7")
                            ),
                    new State("Active7",
                        new Taunt("THE POWER...IT CONSUMES ME!"),
                        new Order(2, "shtrs MagiGenerators", "vulnerable"),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 100),
                        new Shoot(15, 20, projectileIndex: 3, coolDown: 100000000, coolDownOffset: 200),
                        new Shoot(15, 20, projectileIndex: 4, coolDown: 100000000, coolDownOffset: 300),
                        new Shoot(15, 20, projectileIndex: 2, coolDown: 100000000, coolDownOffset: 400),
                        new Shoot(15, 20, projectileIndex: 5, coolDown: 100000000, coolDownOffset: 500),
                        new Shoot(15, 20, projectileIndex: 6, coolDown: 100000000, coolDownOffset: 600)
                        ),
                        new State("Death",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("IM..POSSI...BLE!"),
                            new CopyDamageOnDeath("shtrs Loot Balloon Mage"),
                            new Order(1, "shtrs Chest Spawner 2", "Open"),
                            new TimedTransition(2000, "Suicide")
                            ),
                        new State("Suicide",
                            new Shoot(35, projectileIndex: 0, count: 30),
                            new Suicide()
                    )
                )
            )
        #endregion 2ndboss
        #region birds
            .Init("shtrs Inferno",
                new State(
                    new Orbit(0.5, 4, 15, "shtrs Blizzard"),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 4333),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 3500),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 7250),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 10000)
                )
            )

            .Init("shtrs Blizzard",
                new State(
                    new State("Follow",
                    new Follow(0.3, range: 1, coolDown: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 25),
                            new TimedTransition(7000, "Spin")
                    ),
                    new State("Spin",
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(10, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(10, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(10, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(10, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(10, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(10, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(10, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(10, "Quadforce9")
                        ),
                        new State("Quadforce9",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 120, coolDown: 300),
                            new TimedTransition(10, "Quadforce10")
                        ),
                        new State("Quadforce10",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 135, coolDown: 300),
                            new TimedTransition(10, "Quadforce11")
                        ),
                        new State("Quadforce11",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 150, coolDown: 300),
                            new TimedTransition(10, "Quadforce12")
                        ),
                        new State("Quadforce12",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 165, coolDown: 300),
                            new TimedTransition(10, "Quadforce13")
                        ),
                        new State("Quadforce13",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 180, coolDown: 300),
                            new TimedTransition(10, "Quadforce14")
                        ),
                        new State("Quadforce14",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 195, coolDown: 300),
                            new TimedTransition(10, "Quadforce15")
                        ),
                        new State("Quadforce15",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 210, coolDown: 300),
                            new TimedTransition(10, "Quadforce16")
                        ),
                        new State("Quadforce16",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 225, coolDown: 300),
                            new TimedTransition(10, "Follow")

                            ))
                )
            )
        #endregion birds
        #region 1stbosschest
            .Init("shtrs Loot Balloon Bridge",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Order(46, "shtrs Spawn Bridge", "Open"),
                        new TimedTransition(5000, "Bridge")
                    ),
                    new State("Bridge")

                ),
                new Threshold(0.1,
                    new TierLoot(11, ItemType.Weapon, 1),
                    new TierLoot(12, ItemType.Weapon, 1),
                    new TierLoot(6, ItemType.Ability, 1),
                    new TierLoot(12, ItemType.Armor, 1),
                    new TierLoot(13, ItemType.Armor, 1),
                    new TierLoot(6, ItemType.Ring, 1),
                new Threshold(0.32,
                    new ItemLoot("Potion of Attack", 1),
                    new ItemLoot("Potion of Defense", 1),
                    new ItemLoot("Bracer of the Guardian", 0.3)
                    )
                )
            )
        #endregion 1stbosschest
        #region 2ndbosschest
            .Init("shtrs Loot Balloon Mage",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "Mage")
                    ),
                    new State("Mage")
                ),
                new Threshold(0.1,
                    new TierLoot(11, ItemType.Weapon, 1),
                    new TierLoot(12, ItemType.Weapon, 1),
                    new TierLoot(6, ItemType.Ability, 1),
                    new TierLoot(12, ItemType.Armor, 1),
                    new TierLoot(13, ItemType.Armor, 1),
                    new TierLoot(6, ItemType.Ring, 1),
                new Threshold(0.32,
                    new ItemLoot("Potion of Mana", 1),
                    new ItemLoot("The Twilight Gemstone", 0.30)
                    )
                )
            )
        #endregion 2ndbosschest
        #region BridgeStatues
            .Init("shtrs Bridge Obelisk A",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Shtrs Bridge Closer4", 100, "TALK")
                        ),
                    new State("TALK",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("DO NOT WAKE THE BRIDGE GUARDIAN!"),
                        new TimedTransition(2000, "AFK")
                        ),
                    new State("AFK",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0x0000FF0C, 0.5, 4),
                            new TimedTransition(2500, "activatetimer")
                        ),
                    new State("activatetimer",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Order(60, "shtrs obelisk timer", "timer1"),
                            new TimedTransition(1,"stopsettingoffmytimer")
                        ),
                    new State("stopsettingoffmytimer",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                    new State("Shoot",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 10000)
                        ),
                    new State("Pause",
                        new RemoveConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Spawn("shtrs Stone Knight", maxChildren: 1, initialSpawn: 1, coolDown: 7500),
                        new Spawn("shtrs Stone Mage", maxChildren: 1, initialSpawn: 1, coolDown: 7500)
                        )
                    )
            )
            .Init("shtrs Bridge Obelisk B",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Shtrs Bridge Closer4", 100, "TALK")
                        ),
                    new State("TALK",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("DO NOT WAKE THE BRIDGE GUARDIAN!"),
                        new TimedTransition(2000, "AFK")
                        ),
                    new State("AFK",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0x0000FF0C, 0.5, 4)
                        ),
                    new State("Shoot",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 10000)
                        ),
                    new State("guardiancheck",
                        new EntitiesNotExistsTransition(30, "Pause", "shtrs Bridge Obelisk A")
                        ),
                    new State("Pause",
                        new RemoveConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Spawn("shtrs Stone Knight", maxChildren: 1, initialSpawn: 1),
                        new Spawn("shtrs Stone Mage", maxChildren: 1, initialSpawn: 1)
                        )
                    )
            )
            .Init("shtrs Bridge Obelisk D",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Shtrs Bridge Closer4", 100, "TALK")
                        ),
                    new State("TALK",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("DO NOT WAKE THE BRIDGE GUARDIAN!"),
                        new TimedTransition(2000, "AFK")
                        ),
                    new State("AFK",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0x0000FF0C, 0.5, 4)
                        ),
                    new State("Shoot",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 10000)
                        ),
                    new State("guardiancheck",
                        new EntitiesNotExistsTransition(30, "Pause", "shtrs Bridge Obelisk B")
                        ),
                    new State("Pause",
                        new RemoveConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Spawn("shtrs Stone Knight", maxChildren: 1, initialSpawn: 1),
                        new Spawn("shtrs Stone Mage", maxChildren: 1, initialSpawn: 1)
                    )
            )
            )
            .Init("shtrs Bridge Obelisk E",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Shtrs Bridge Closer4", 100, "TALK")
                        ),
                    new State("TALK",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("DO NOT WAKE THE BRIDGE GUARDIAN!"),
                        new TimedTransition(2000, "AFK")
                        ),
                    new State("AFK",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0x0000FF0C, 0.5, 4)
                        ),
                    new State("Shoot",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 10000)
                        ),
                    new State("guardiancheck",
                        new EntitiesNotExistsTransition(30, "Pause", "shtrs Bridge Obelisk D")
                        ),
                    new State("Pause",
                        new RemoveConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Spawn("shtrs Stone Knight", maxChildren: 1, initialSpawn: 1),
                        new Spawn("shtrs Stone Mage", maxChildren: 1, initialSpawn: 1)
                    )
            )
            )
            .Init("shtrs Bridge Obelisk C",                                                     //YELLOW TOWERS!
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new EntityNotExistsTransition("Shtrs Bridge Closer4", 100, "JustKillMe")
                        ),
                    new State("JustKillMe",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "AFK")
                        ),
                    new State("AFK",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Flash(0x0000FF0C, 0.5, 4),
                            new TimedTransition(2500, "Shoot")
                        ),
                    new State("Shoot",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 10000),
                            new TimedTransition(10000, "Pause")
                        ),
                    new State("Pause",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Spawn("shtrs Stone Paladin", maxChildren: 1, initialSpawn: 1, coolDown: 7500),
                        new TimedTransition(7000, "Shoot")
                        )
                    )
            )
            .Init("shtrs Bridge Obelisk F",                                                     //YELLOW TOWERS!
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new EntityNotExistsTransition("Shtrs Bridge Closer4", 100, "JustKillMe")
                        ),
                    new State("JustKillMe",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "AFK")
                        ),
                    new State("AFK",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new ConditionalEffect(ConditionEffectIndex.Armored),
                            new Flash(0x0000FF0C, 0.5, 4),
                            new TimedTransition(2500, "Shoot")
                        ),
                    new State("Shoot",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 1800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 2800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 3800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 4800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 5800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 6800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 7800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 8800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9200),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9400),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9600),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 9800),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 10000, coolDownOffset: 10000),
                            new TimedTransition(10000, "Pause")
                        ),
                    new State("Pause",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Spawn("shtrs Stone Paladin", maxChildren: 1, initialSpawn: 1, coolDown: 7500),
                        new TimedTransition(7000, "Shoot")
                        )
                    )
            )
        #endregion BridgeStatues
        #region SomeMobs
            .Init("shtrs obelisk controller",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("wait",
                    new EntitiesNotExistsTransition(30, "obeliskshoot", "shtrs Bridge Obelisk A", "shtrs Bridge Obelisk B", "shtrs Bridge Obelisk D", "shtrs Bridge Obelisk E")
                        ),
                    new State("obeliskshoot",
                        new Order(60, "shtrs Bridge Obelisk A", "Shoot"),
                        new Order(60, "shtrs Bridge Obelisk B", "Shoot"),
                        new Order(60, "shtrs Bridge Obelisk D", "Shoot"),
                        new Order(60, "shtrs Bridge Obelisk E", "Shoot")
                        ),
                    new State("guardiancheck",
                        new Order(60, "shtrs Bridge Obelisk A", "Pause"),
                        new Order(60, "shtrs Bridge Obelisk B", "guardiancheck"),
                        new Order(60, "shtrs Bridge Obelisk D", "guardiancheck"),
                        new Order(60, "shtrs Bridge Obelisk E", "guardiancheck"),
                        new TimedTransition(1,"leavemychecksalone")
                        ),
                    new State("leavemychecksalone",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                        )
                )
            )
            .Init("shtrs obelisk timer",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("wait",
                    new EntitiesNotExistsTransition(30, "timer1", "shtrs Bridge Obelisk A", "shtrs Bridge Obelisk B", "shtrs Bridge Obelisk D", "shtrs Bridge Obelisk E")
                        ),
                    new State("timer1",
                        new Order(60, "shtrs obelisk controller", "obeliskshoot"),
                        new TimedTransition(10000, "guardiancheck")
                        ),
                    new State("guardiancheck",
                        new Order(60, "shtrs obelisk controller", "guardiancheck"),
                        new TimedTransition(1,"leavemychecksalone")
                        ),
                    new State("leavemychecksalone",
                        new TimedTransition(7000,"timer1")
                        )
                )
            )
            .Init("shtrs Titanum",
                new State(
                    new State("Wait",
                        new PlayerWithinTransition(7, "spawn")
                            ),
                    new State("spawn",
                        new Spawn("shtrs Stone Knight", maxChildren: 1, initialSpawn: 1, coolDown: 5000),
                        new Spawn("shtrs Stone Mage", maxChildren: 1, initialSpawn: 1, coolDown: 7500),
                        new TimedTransition(5000,"Wait")
                        )
                    )
            )
            .Init("shtrs Paladin Obelisk",
                new State(
                    new State("Wait",
                        new PlayerWithinTransition(5, "spawn")
                            ),
                    new State("spawn",
                        new Spawn("shtrs Stone Paladin", maxChildren: 1, initialSpawn: 1, coolDown: 7500)
                        )
                    )
            )
            .Init("shtrs Ice Mage",
                new State(
                    new State("Wait",
                        new PlayerWithinTransition(5, "fire")
                            ),
                    new State("fire",
                        new Follow(0.5, range: 1),
                        new Shoot(10, 5, 10, projectileIndex: 0, coolDown: 1500),
                        new TimedTransition(15000, "Spawn")
                        ),
                    new State("Spawn",
                        new Spawn("shtrs Ice Shield", maxChildren: 1, initialSpawn: 1, coolDown: 750000000),
                        new TimedTransition(25, "fire")
                        )
                    )
            )
            .Init("shtrs Archmage of Flame",
            new State(
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new PlayerWithinTransition(7, "Follow")
                    ),
                new State("Follow",
                    new Follow(1, range: 1),
                    new TimedTransition(5000, "Throw")
                    ),
                new State("Throw",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new TossObject("shtrs Firebomb", 1, angle: 90, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 2, angle: 20, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 3, angle: 72, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 4, angle: 270, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 5, angle: 140, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 6, angle: 220, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 6, angle: 48, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 5, angle: 56, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 4, angle: 180, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 3, angle: 30, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 2, angle: 0, coolDown: 5000),
                    new TossObject("shtrs Firebomb", 1, angle: 190, coolDown: 5000),
                    new TimedTransition(4000, "Fire")
                    ),
                new State("Fire",
                    new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 45, fixedAngle: 45, coolDown: 1, coolDownOffset: 0),
                    new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 90, fixedAngle: 90, coolDown: 1, coolDownOffset: 0),
                    new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 135, fixedAngle: 135, coolDown: 1, coolDownOffset: 0),
                    new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 180, fixedAngle: 180, coolDown: 1, coolDownOffset: 0),
                    new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 225, fixedAngle: 225, coolDown: 1, coolDownOffset: 0),
                    new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 270, fixedAngle: 270, coolDown: 1, coolDownOffset: 0),
                    new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 315, fixedAngle: 315, coolDown: 1, coolDownOffset: 0),
                    new Shoot(0, projectileIndex: 0, count: 1, shootAngle: 360, fixedAngle: 360, coolDown: 1, coolDownOffset: 0),
                    new TimedTransition(5000, "wait")
                    )
                )
            )

            .Init("shtrs Firebomb",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2000, "Explode")
                        ),
                    new State("Explode",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Shoot(100, projectileIndex: 0, count: 8),
                        new Suicide()
                        )
                    )
            )

            .Init("shtrs Fire Mage",
                new State(
                    new State("Wait",
                        new PlayerWithinTransition(5, "fire")
                            ),
                    new State("fire",
                        new Follow(0.5, range: 1),
                        new Shoot(10, 5, 10, projectileIndex: 0, coolDown: 1500),
                        new TimedTransition(10000, "nothing")
                            ),
                    new State("nothing",
                        new TimedTransition(1000, "fire")
                        )
                    )
            )
            .Init("shtrs Stone Mage",
                new State(
                    new State("Wait",
                        new PlayerWithinTransition(5, "fire")
                            ),
                    new State("fire",
                        new Follow(0.5, range: 1),
                        new Shoot(10, 2, 10, projectileIndex: 1, coolDown: 200),
                        new TimedTransition(10000, "invulnerable")
                            ),
                    new State("invulnerable",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, 2, 10, projectileIndex: 0, coolDown: 200),
                        new TimedTransition(3000, "fire")
                        )
                    )
            )
        #endregion SomeMobs
        #region WOODENGATESSWITCHESBRIDGES
            .Init("shtrs Wooden Gate 3",
                new State(
                    new State("Despawn",
                        new Decay(0)
                        )
                    )
            )
            //.Init("OBJECTHERE",
            //new State(
            //      new EntityNotExistTransition("shtrs Abandoned Switch 1", 10, "OPENGATE")
            //        ),
            //      new State("OPENGATE",
            //            new OpenGate("shtrs Wooden Gate", 10)
            //              )
            //        )
            //      )
            .Init("shtrs Wooden Gate",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 1", 10, "Despawn")
                        ),
                    new State("Despawn",
                        new Decay(0)
                        )
                    )
            )
            .Init("shtrs Abandoned Switch 1",
                new State(
                    new RemoveObjectOnDeath("shtrs Wooden Gate", 8)
                    )
            )
            .Init("Tooky Shatters Master",
                new State(
                    new SetNoXP(),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new RemoveObjectOnDeath("shtrs Wooden Gate 2", 14)
                    )
            )
            .Init("shtrs Wooden Gate 2",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("shtrs Abandoned Switch 2", 60, "Despawn")
                        ),
                    new State("Despawn",
                        new Decay(0)
                        )
                    )
            )
        .Init("shtrs Bridge Closer",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true)
                    ),
                new State("Closer",
                    new ChangeGroundOnDeath(new[] { "shtrs Bridge" }, new[] { "shtrs Pure Evil" },
                        1),
                    new Suicide()
                    ),
                new State("TwilightClose",
                    new ChangeGroundOnDeath(new[] { "shtrs Shattered Floor", "shtrs Disaster Floor" }, new[] { "shtrs Pure Evil" },
                        1),
                    new Suicide()

                    )
                )
            )
        .Init("shtrs Bridge Closer2",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true)
                    ),
                new State("Closer",
                    new ChangeGroundOnDeath(new[] { "shtrs Bridge" }, new[] { "shtrs Pure Evil" },
                        1),
                    new Suicide()
                    ),
                new State("TwilightClose",
                    new ChangeGroundOnDeath(new[] { "shtrs Shattered Floor", "shtrs Disaster Floor" }, new[] { "shtrs Pure Evil" },
                        1),
                    new Suicide()

                    )
                )
            )
        .Init("shtrs Bridge Closer3",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true)
                    ),
                new State("Closer",
                    new ChangeGroundOnDeath(new[] { "shtrs Bridge" }, new[] { "shtrs Pure Evil" },
                        1),
                    new Suicide()
                    ),
                new State("TwilightClose",
                    new ChangeGroundOnDeath(new[] { "shtrs Shattered Floor", "shtrs Disaster Floor" }, new[] { "shtrs Pure Evil" },
                        1),
                    new Suicide()

                    )
                )
            )
        .Init("shtrs Bridge Closer4",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true)
                    ),
                new State("Closer",
                    new ChangeGroundOnDeath(new[] { "shtrs Bridge" }, new[] { "shtrs Pure Evil" },
                        1),
                    new Suicide()
                    ),
                new State("TwilightClose",
                    new ChangeGroundOnDeath(new[] { "shtrs Shattered Floor", "shtrs Disaster Floor" }, new[] { "shtrs Pure Evil" },
                        1),
                    new Suicide()

                    )
                )
            )
        .Init("shtrs Spawn Bridge",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true)
                    ),
                new State("Open",
                    new ChangeGroundOnDeath(new[] { "shtrs Pure Evil" }, new[] { "shtrs Bridge" },
                        1),
                    new Suicide()
                    )
                )
            )
        .Init("shtrs Spawn Bridge 2",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new EntityNotExistsTransition("shtrs Abandoned Switch 3", 500, "Open")
                    ),
                new State("Open",
                    new ChangeGroundOnDeath(new[] { "shtrs Pure Evil" }, new[] { "shtrs Shattered Floor" },
                        1),
                    new Suicide()
                    ),
                new State("CloseBridge2",
                    new ChangeGroundOnDeath(new[] { "shtrs Shattered Floor" }, new[] { "shtrs Pure Evil" },
                        1),
                    new Suicide()
                    )
                )
            )
        .Init("shtrs Spawn Bridge 3",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new EntityNotExistsTransition("shtrs Twilight Archmage", 500, "Open")
                    ),
                new State("Open",
                    new ChangeGroundOnDeath(new[] { "shtrs Pure Evil" }, new[] { "shtrs Shattered Floor" },
                        1),
                    new Suicide()
                    )
                )
            )
        .Init("shtrs Spawn Bridge 5",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new EntityNotExistsTransition("shtrs Royal Guardian L", 100, "Open")
                    ),
                new State("Open",
                    new ChangeGroundOnDeath(new[] { "Dark Cobblestone" }, new[] { "Hot Lava" },
                        1),
                    new Suicide()
                    )
                )
            )
        #endregion WOODENGATESSWITCHESBRIDGES
        #region 3rdboss
            .Init("shtrs The Forgotten King",
                new State(
                    new HpLessTransition(0.1, "Death"),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ConditionalEffect(ConditionEffectIndex.Invisible),
                        new ConditionalEffect(ConditionEffectIndex.Stasis),
                        new TimedTransition(2000, "1st")
                    ),
                    new State("1st",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ConditionalEffect(ConditionEffectIndex.Invisible),
                        new ConditionalEffect(ConditionEffectIndex.Stasis),
                        new Spawn("shtrs Green Crystal", 1, 1),
                        new Spawn("shtrs Yellow Crystal", 1, 1),
                        new Spawn("shtrs Red Crystal", 1, 1),
                        new Spawn("shtrs Blue Crystal", 1, 1),
                        new EntityNotExistsTransition("shtrs Green Crystal", 50, "yellow")
                        ),
                    new State("yellow",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ConditionalEffect(ConditionEffectIndex.Invisible),
                        new ConditionalEffect(ConditionEffectIndex.Stasis),
                        new EntityNotExistsTransition("shtrs Yellow Crystal", 50, "blue")
                        ),
                    new State("blue",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ConditionalEffect(ConditionEffectIndex.Invisible),
                        new ConditionalEffect(ConditionEffectIndex.Stasis),
                        new EntityNotExistsTransition("shtrs Blue Crystal", 50, "red")
                        ),
                    new State("red",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ConditionalEffect(ConditionEffectIndex.Invisible),
                        new ConditionalEffect(ConditionEffectIndex.Stasis),
                        new EntityNotExistsTransition("shtrs Red Crystal", 50, "Swirl1")
                            ),
                        new State("Swirl1",
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 85, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 95, coolDown: 100),
                            new TimedTransition(50, "Swirl2")
                            ),
                        new State("Swirl2",
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 75, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 70, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 105, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 110, coolDown: 100),
                            new TimedTransition(50, "Swirl3")
                            ),
                        new State("Swirl3",
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 60, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 55, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 120, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 125, coolDown: 100),
                            new TimedTransition(50, "Swirl4")
                            ),
                        new State("Swirl4",
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 45, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 40, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 135, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 140, coolDown: 100),
                            new TimedTransition(50, "Swirl5")
                            ),
                        new State("Swirl5",
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 30, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 25, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 150, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 155, coolDown: 100),
                            new TimedTransition(50, "Swirl6")
                            ),
                        new State("Swirl6",
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 20, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 15, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 165, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 170, coolDown: 100),
                            new TimedTransition(50, "Swirl7")
                            ),
                        new State("Swirl7",
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 5, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 0, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 180, coolDown: 100),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 175, coolDown: 100),
                            new TimedTransition(50, "Swirl8")
                            ),
                        new State("Swirl8",
                            new TimedTransition(50, "Swirl9")
                            ),
                        new State("Swirl9",
                            new TimedTransition(50, "middle")
                            ),
                        new State("middle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ConditionalEffect(ConditionEffectIndex.Invisible),
                        new ConditionalEffect(ConditionEffectIndex.Stasis),
                            new MoveTo2(0, 8, 0.5f),
                            new TimedTransition(3000, "J Guardians")
                            ),
                        new State("J Guardians",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new ConditionalEffect(ConditionEffectIndex.Invisible),
                            new ConditionalEffect(ConditionEffectIndex.Stasis),
                            new Spawn("shtrs Royal Guardian J", 10),
                            new TimedTransition(50, "waiting")
                            ),
                        new State("waiting",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new ConditionalEffect(ConditionEffectIndex.Invisible),
                            new ConditionalEffect(ConditionEffectIndex.Stasis),
                            new EntityNotExistsTransition("shtrs Royal Guardian J", 10, "littlerage")
                            ),
                        new State("littlerage",
                            new ChangeSize(100, 330),
                            new Shoot(10, 1, projectileIndex: 2, coolDown: 10),
                            new Shoot(10, 1, projectileIndex: 3, coolDown: 10),
                            new TimedTransition(100, "Shoot1")
                            ),
                        new State("Shoot1",
                            new Shoot(10, 1, projectileIndex: 2, coolDown: 10),
                            new Shoot(10, 1, projectileIndex: 3, coolDown: 10),
                            new TimedTransition(100, "Shoot2")
                            ),
                        new State("Shoot2",
                            new Shoot(10, 1, projectileIndex: 2, coolDown: 10),
                            new Shoot(10, 1, projectileIndex: 3, coolDown: 10),
                            new TimedTransition(100, "Shoot3")
                            ),
                        new State("Shoot3",
                            new Shoot(10, 1, projectileIndex: 2, coolDown: 10),
                            new Shoot(10, 1, projectileIndex: 3, coolDown: 10),
                            new TimedTransition(100, "Shoot4")
                            ),
                        new State("Shoot4",
                            new Shoot(10, 1, projectileIndex: 2, coolDown: 10),
                            new Shoot(10, 1, projectileIndex: 3, coolDown: 10),
                            new TimedTransition(100, "Raged1")
                            ),
                        new State("Raged1",
                            new Taunt("TENTACLES OF WRATH"),
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Order(60, "shtrs Lava Souls maker", "Spawn"),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 3, coolDown: 10800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 4, coolDown: 10800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 6, coolDown: 10800, coolDownOffset: 200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 7, coolDown: 10800, coolDownOffset: 200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 9, coolDown: 10800, coolDownOffset: 400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 10, coolDown: 10800, coolDownOffset: 400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 12, coolDown: 10800, coolDownOffset: 600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 13, coolDown: 10800, coolDownOffset: 600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 10800, coolDownOffset: 800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 16, coolDown: 10800, coolDownOffset: 800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 18, coolDown: 10800, coolDownOffset: 1000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 19, coolDown: 10800, coolDownOffset: 1000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 21, coolDown: 10800, coolDownOffset: 1200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 22, coolDown: 10800, coolDownOffset: 1200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 24, coolDown: 10800, coolDownOffset: 1400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 25, coolDown: 10800, coolDownOffset: 1400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 27, coolDown: 10800, coolDownOffset: 1600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 28, coolDown: 10800, coolDownOffset: 1600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 10800, coolDownOffset: 1800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 31, coolDown: 10800, coolDownOffset: 1800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 33, coolDown: 10800, coolDownOffset: 2000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 34, coolDown: 10800, coolDownOffset: 2000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 36, coolDown: 10800, coolDownOffset: 2200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 37, coolDown: 10800, coolDownOffset: 2200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 39, coolDown: 10800, coolDownOffset: 2400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 40, coolDown: 10800, coolDownOffset: 2400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 42, coolDown: 10800, coolDownOffset: 2600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 43, coolDown: 10800, coolDownOffset: 2600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 10800, coolDownOffset: 2800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 46, coolDown: 10800, coolDownOffset: 2800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 48, coolDown: 10800, coolDownOffset: 3000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 49, coolDown: 10800, coolDownOffset: 3000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 51, coolDown: 10800, coolDownOffset: 3200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 52, coolDown: 10800, coolDownOffset: 3200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 54, coolDown: 10800, coolDownOffset: 3400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 55, coolDown: 10800, coolDownOffset: 3400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 57, coolDown: 10800, coolDownOffset: 3600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 58, coolDown: 10800, coolDownOffset: 3600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 10800, coolDownOffset: 3800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 61, coolDown: 10800, coolDownOffset: 3800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 63, coolDown: 10800, coolDownOffset: 4000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 64, coolDown: 10800, coolDownOffset: 4000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 66, coolDown: 10800, coolDownOffset: 4200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 67, coolDown: 10800, coolDownOffset: 4200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 69, coolDown: 10800, coolDownOffset: 4400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 70, coolDown: 10800, coolDownOffset: 4400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 72, coolDown: 10800, coolDownOffset: 4600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 73, coolDown: 10800, coolDownOffset: 4600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 10800, coolDownOffset: 4800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 76, coolDown: 10800, coolDownOffset: 4800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 78, coolDown: 10800, coolDownOffset: 5000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 79, coolDown: 10800, coolDownOffset: 5000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 81, coolDown: 10800, coolDownOffset: 5200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 82, coolDown: 10800, coolDownOffset: 5200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 84, coolDown: 10800, coolDownOffset: 5400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 85, coolDown: 10800, coolDownOffset: 5400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 87, coolDown: 10800, coolDownOffset: 5600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 88, coolDown: 10800, coolDownOffset: 5600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 90, coolDown: 10800, coolDownOffset: 5800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 91, coolDown: 10800, coolDownOffset: 5800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 93, coolDown: 10800, coolDownOffset: 6000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 94, coolDown: 10800, coolDownOffset: 6000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 96, coolDown: 10800, coolDownOffset: 6200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 97, coolDown: 10800, coolDownOffset: 6200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 99, coolDown: 10800, coolDownOffset: 6400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 100, coolDown: 10800, coolDownOffset: 6400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 102, coolDown: 10800, coolDownOffset: 6600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 103, coolDown: 10800, coolDownOffset: 6600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 105, coolDown: 10800, coolDownOffset: 6800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 106, coolDown: 10800, coolDownOffset: 6800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 108, coolDown: 10800, coolDownOffset: 7000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 109, coolDown: 10800, coolDownOffset: 7000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 111, coolDown: 10800, coolDownOffset: 7200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 112, coolDown: 10800, coolDownOffset: 7200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 114, coolDown: 10800, coolDownOffset: 7400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 115, coolDown: 10800, coolDownOffset: 7400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 117, coolDown: 10800, coolDownOffset: 7600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 118, coolDown: 10800, coolDownOffset: 7600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 120, coolDown: 10800, coolDownOffset: 7800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 121, coolDown: 10800, coolDownOffset: 7800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 123, coolDown: 10800, coolDownOffset: 8000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 124, coolDown: 10800, coolDownOffset: 8000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 126, coolDown: 10800, coolDownOffset: 8200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 127, coolDown: 10800, coolDownOffset: 8200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 129, coolDown: 10800, coolDownOffset: 8400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 130, coolDown: 10800, coolDownOffset: 8400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 132, coolDown: 10800, coolDownOffset: 8600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 133, coolDown: 10800, coolDownOffset: 8600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 135, coolDown: 10800, coolDownOffset: 8800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 136, coolDown: 10800, coolDownOffset: 8800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 138, coolDown: 10800, coolDownOffset: 9000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 139, coolDown: 10800, coolDownOffset: 9000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 141, coolDown: 10800, coolDownOffset: 9200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 142, coolDown: 10800, coolDownOffset: 9200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 144, coolDown: 10800, coolDownOffset: 9400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 145, coolDown: 10800, coolDownOffset: 9400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 147, coolDown: 10800, coolDownOffset: 9600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 148, coolDown: 10800, coolDownOffset: 9600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 150, coolDown: 10800, coolDownOffset: 9800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 151, coolDown: 10800, coolDownOffset: 9800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 153, coolDown: 10800, coolDownOffset: 10000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 154, coolDown: 10800, coolDownOffset: 10000),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 156, coolDown: 10800, coolDownOffset: 10200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 157, coolDown: 10800, coolDownOffset: 10200),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 159, coolDown: 10800, coolDownOffset: 10400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 160, coolDown: 10800, coolDownOffset: 10400),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 162, coolDown: 10800, coolDownOffset: 10600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 163, coolDown: 10800, coolDownOffset: 10600),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 165, coolDown: 10800, coolDownOffset: 10800),
                            new Shoot(50, projectileIndex: 4, count: 6, shootAngle: 60, fixedAngle: 166, coolDown: 10800, coolDownOffset: 10800),
                            new HpLessTransition(0.5, "MoveTo"),
                            new TimedTransition(10800, "Pause")
                            ),
                        new State("Pause",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Order(60, "shtrs Lava Souls maker","Idle"),
                            new TimedTransition(4000, "littlerage")
                            ),
                        new State("MoveTo",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new MoveTo2(0, -8, 0.5f),
                            new TimedTransition(1800, "God")
                            ),
                        new State("God",
                            new Taunt("YOU TEST THE PATIENCE OF A GOD"),
                            new Order(60, "shtrs Lava Souls maker", "Idle"),
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(10, 1, projectileIndex: 2, coolDown: 10),
                            new Shoot(10, 1, projectileIndex: 3, coolDown: 10),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 0, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 5, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 15, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 20, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 25, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 30, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 40, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 45, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 55, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 60, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 70, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 75, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 85, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 95, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 105, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 110, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 120, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 125, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 135, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 140, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 150, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 155, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 165, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 170, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 175, coolDown: 500),
                            new Shoot(15, 1, projectileIndex: 1, fixedAngle: 180, coolDown: 500),
                            new TimedTransition(10800, "Hahaha")
                            ),
                        new State("Hahaha",
                            new Taunt("Ha....Haaaa...haaaa"),
                            new TimedTransition(4000, "God")
                            ),
                        new State("Death",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new CopyDamageOnDeath("shtrs Loot Balloon King"),
                            new Order(1, "shtrs Chest Spawner 3", "Open"),
                            new Taunt("Impossible..........IMPOSSIBLE!"),
                            new TimedTransition(2000, "Suicide")
                            ),
                        new State("Suicide",
                            new Shoot(35, projectileIndex: 0, count: 30),
                            new Suicide()
                    )
                )
            )
            .Init("shtrs Royal Guardian J",
                new State(
                    new State("shoot",
                        new Orbit(0.35, 2, 5, "shtrs The Forgotten King"),
                        new Shoot(15, 8, projectileIndex: 0, coolDown: new Cooldown(3600, 3600))
                        )
                    )
            )
            .Init("shtrs Royal Guardian L",
                new State(
                    new State("1st",
                        new Follow(1, 8, 5),
                        new Shoot(15, 20, projectileIndex: 0),
                        new TimedTransition(1000, "2nd")
                        ),
                    new State("2nd",
                        new Follow(1, 8, 5),
                        new Shoot(10, projectileIndex: 1),
                        new TimedTransition(1000, "3rd")
                        ),
                    new State("3rd",
                        new Follow(1, 8, 5),
                        new Shoot(10, projectileIndex: 1),
                        new TimedTransition(1000, "1st")
                        )
                    )
            )
            .Init("shtrs Green Crystal",
                new State(
                    new HealGroup(30, "Crystals", coolDown: 2000, healAmount:3000),
                    new State("orbit",
                        new Orbit(1.0, 2, 10, "shtrs Yellow Crystal"),
                        new Follow(0.4, range: 6),
                        new Follow(0.6, range: 2),
                        new TimedTransition(3000, "dafuq")
                        ),
                    new State("dafuq",
                        new Follow(0.4, range: 2,duration: 2000,coolDown:1500),
                        new TimedTransition(2000,"orbit")
                        )
                    )
            )
            .Init("shtrs Yellow Crystal",
                new State(
                    new State("orbit",
                        new Orbit(1.0, 2, 10, "shtrs Blue Crystal"),
                        new Follow(0.4, range: 6),
                        new Follow(0.4, range: 6),
                        new TimedTransition(25, "shoot")
                        ),
                    new State("shoot",
                        new Shoot(5, 4, 4, projectileIndex: 0),
                        new TimedTransition(1, "dafuq")
                        ),
                    new State("dafuq",
                        new Orbit(1.0, 2, 5, "shtrs Blue Crystal"),
                        new Follow(0.4, range: 6),
                        new Shoot(5, 4, 4, projectileIndex: 0)
                        )
                    )
            )
            .Init("shtrs Red Crystal",
                new State(
                    new State("orbit",
                        new Orbit(1.0, 2, 10, "shtrs Green Crystal"),
                        new Follow(0.4,range:6),
                        new TimedTransition(5000, "ThrowPortal")
                        ),
                    new State("ThrowPortal",
                        new Orbit(1.0, 2, 10, "shtrs Green Crystal"),
                        new Follow(0.4, range: 6),
                        new TossObject("shtrs Fire Portal", 5, coolDown: 8000),
                        new TimedTransition(8000, "orbit")
                        )
                    )
            )
            .Init("shtrs Blue Crystal",
                new State(
                    new State("orbit",
                        new Orbit(1.0, 2, 10, "shtrs Red Crystal"),
                        new Follow(0.4, range: 6),
                        new TimedTransition(5000, "ThrowPortal")
                        ),
                    new State("ThrowPortal",
                        new Orbit(1.0, 2, 10, "shtrs Red Crystal"),
                        new Follow(0.4, range: 6),
                        new TossObject("shtrs Ice Portal", 5, coolDown: 8000),
                        new TimedTransition(8000, "orbit")
                        )
                    )
            )
        .Init("shtrs The Cursed Crown",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new EntityNotExistsTransition("shtrs Royal Guardian L", 100, "Open")
                    ),
                new State("Open",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new MoveTo2(0, -15, 0.5f),
                    new TimedTransition(3000, "WADAFAK")
                    ),
                new State("WADAFAK",
                    new TransformOnDeath("shtrs The Forgotten King"),
                    new Suicide()
                    )
                )
            )
        #endregion 3rdboss
        #region 3rdbosschest
            .Init("shtrs Loot Balloon King",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "Crown")
                    ),
                    new State("Crown")
                ),
                new Threshold(0.1,
                    new TierLoot(11, ItemType.Weapon, 1),
                    new TierLoot(12, ItemType.Weapon, 1),
                    new TierLoot(6, ItemType.Ability, 1),
                    new TierLoot(12, ItemType.Armor, 1),
                    new TierLoot(13, ItemType.Armor, 1),
                    new TierLoot(6, ItemType.Ring, 1),
                new Threshold(0.32,
                    new ItemLoot("Potion of Life", 1),
                    new ItemLoot("The Forgotten Crown", 1)
                    )
                )
            )
        #endregion 3rdbosschest
        // Use this for other stuff.
        #region NotInUse
        //      .Init("shtrs Spawn Bridge 6",
        //          new State(
        //              new State("Idle",
        //                  new ConditionalEffect(ConditionEffectIndex.Invincible, true),
        //                  new EntityNotExistsTransition("shtrs Royal Guardian L", 100, "Open")
        //                  ),
        //              new State("Open",
        //                  new ChangeGroundOnDeath(new[] { "Green BigSmall Squared" }, new[] { "Hot Lava" },
        //                      1),
        //                  new Suicide()
        //                  )
        //              )
        //          )
        //      .Init("shtrs Spawn Bridge 7",
        //          new State(
        //              new State("Idle",
        //                  new ConditionalEffect(ConditionEffectIndex.Invincible, true),
        //                  new EntityNotExistsTransition("shtrs Royal Guardian L", 100, "Open")
        //                  ),
        //              new State("Open",
        //                  new ChangeGroundOnDeath(new[] { "Gold Tile" }, new[] { "Hot Lava" },
        //                      1),
        //                  new Suicide()
        //                  )
        //              )
        //          )
        //      .Init("shtrs Spawn Bridge 8",
        //          new State(
        //              new State("Idle",
        //                  new ConditionalEffect(ConditionEffectIndex.Invincible, true),
        //                  new EntityNotExistsTransition("shtrs Royal Guardian L", 100, "Open")
        //                  ),
        //              new State("Open",
        //                  new ChangeGroundOnDeath(new[] { "Shattered Floor" }, new[] { "Hot Lava" },
        //                      1),
        //                  new Suicide()
        //                  )
        //              )
        //          )
        #endregion NotInUse
        #region MISC
        .Init("shtrs Chest Spawner 1",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new EntityNotExistsTransition("shtrs Bridge Sentinel", 500, "Open")
                    ),
                new State("Open",
                    new TransformOnDeath("shtrs Loot Balloon Bridge"),
                    new Suicide()
                    )
                )
            )
        .Init("shtrs Chest Spawner 2",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new EntityNotExistsTransition("shtrs Twilight Archmage", 500, "Open")
                    ),
                new State("Open",
                    new TransformOnDeath("shtrs Loot Balloon Mage"),
                    new Suicide()
                    )
                )
            )
        .Init("shtrs blobomb maker",
            new State(
                 new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                     new State("Spawn",
                        new Spawn("shtrs Blobomb", coolDown: 1500),
                        new TimedTransition(3000, "Spawn2")
                         ),
                     new State("Spawn2",
                         new Spawn("shtrs Blobomb", coolDown: 1000),
                         new TimedTransition(3000,"Idle")
                        )
                    )
                )
          .Init("shtrs Lava Souls maker",
            new State(
                 new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                     new State("Spawn",
                        new Spawn("shtrs Lava Souls",maxChildren:1, coolDown: 8000),
                        new TimedTransition(8000, "Spawn2")
                         ),
                     new State("Spawn2",
                         new Spawn("shtrs Lava Souls", maxChildren: 1, coolDown: 8000),
                         new TimedTransition(8000, "Spawn")
                        )
                    )
                )

        .Init("shtrs Chest Spawner 3",
            new State(
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new EntitiesNotExistsTransition(30, "Open", "shtrs The Cursed Crown", "shtrs The Forgotten King")
                    ),
                new State("Open",
                    new TransformOnDeath("shtrs Loot Balloon King"),
                    new Suicide()
                    )
                )
            )
        #endregion MISC
            ;
    }
}