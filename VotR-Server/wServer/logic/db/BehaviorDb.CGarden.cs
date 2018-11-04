using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ CGarden = () => Behav()
            .Init("Chomper",
            new State(
                new ScaleHP(2000),
                new State("waiting",
                    new PlayerWithinTransition(12, "begin")
                    ),
                new State("begin",
                    new Shoot(40, 1, projectileIndex: 0, coolDown: 400),
                    new Shoot(40, 4, shootAngle: 30, projectileIndex: 1, coolDown: 1000),
                    new Follow(0.6, 10, 2),
                    new TimedTransition(6000, "spray")
                    ),
                new State("spray",
                    new Wander(0.2),
                    new Shoot(40, 6, shootAngle: 10, fixedAngle: 60, coolDown: 2000),
                    new Shoot(40, 6, shootAngle: 10, fixedAngle: 150, coolDown: 2000, coolDownOffset: 500),
                    new Shoot(40, 6, shootAngle: 10, fixedAngle: 240, coolDown: 2000, coolDownOffset: 1000),
                    new Shoot(40, 6, shootAngle: 10, fixedAngle: 330, coolDown: 2000, coolDownOffset: 1500),
                    new TimedTransition(6000, "rage")
                    ),
                new State("rage",
                    new Follow(1.3, 10, 1),
                     new Flash(0xfFF0000, flashRepeats: 1, flashPeriod: 2000),
                     new Shoot(40, 2, shootAngle: 30, projectileIndex: 0, coolDown: 200),
                     new Shoot(40, 18, shootAngle: 20, projectileIndex: 2, coolDown: 600, coolDownOffset: 400),
                     new TimedTransition(8000, "begin")
                    )
                )
            )
               .Init("The Y-Eater",
                new State(
                    new State("locate",
                        new Follow(1.3, range: 0),
                        new PlayerWithinTransition(2, "preyeet")
                        ),
                    new State("preyeet",
                        new Flash(0xfFF0000, flashRepeats: 1, flashPeriod: 2000),
                        new TimedTransition(1000, "yeet")
                        ),
                    new State("yeet",
                        new Shoot(40, 18, shootAngle: 20, coolDown: 99999),
                        new Suicide()
                            )
                        )
                    )
        .Init("Kwargnor the Devourer of worlds",
            new State(
                new ScaleHP(2000),
                new State("fuckyouandyourmovement",
                    new Wander(0.4),
                    new Shoot(40, 1, predictive: 1, coolDown: 1000),
                    new Shoot(40, 3, projectileIndex: 1, shootAngle: 10, coolDown: 3500, coolDownOffset: 500),
                    new TimedTransition(7500, "nowitsmyturntomove")
                    ),
                new State("nowitsmyturntomove",
                    new Taunt("Feel my rock"),
                    new Follow(0.4, 10, 3),
                    new Shoot(40, 1, predictive: 1, projectileIndex: 2, coolDown: 1500, coolDownOffset: 300),
                    new TimedTransition(9000, "fuckyouandyourmovement")
                    )
                )
            )
        .Init("Garganite",
            new State(
                new ScaleHP(2000),
                new State("locate",
                    new PlayerWithinTransition(6, "begin")
                    ),
                new State("begin",
                    new Follow(0.4, 10, 3),
                    new Shoot(40, 3, shootAngle: 7, projectileIndex: 0, coolDown: 1800),
                    new Shoot(40, 5, shootAngle: 14, projectileIndex: 0, coolDown: 3600, coolDownOffset: 1800),
                    new HpLessTransition(0.45, "anger")
                    ),
                new State("anger",
                    new Shoot(40, 7, shootAngle: 10, projectileIndex: 1, coolDown: 500),
                    new Shoot(40, 2, projectileIndex: 0, coolDown: 850),
                    new Shoot(40, 3, projectileIndex: 0, coolDown: 1700, coolDownOffset: 850),
                    new Shoot(40, 4, projectileIndex: 0, coolDown: 2550, coolDownOffset: 1700),
                    new Shoot(40, 5, projectileIndex: 0, coolDown: 3400, coolDownOffset: 2550),
                    new HpLessTransition(0.2, "evenmoreanger")
                    ),
                new State("evenmoreanger",
                    new Shoot(40, 7, shootAngle: 10, projectileIndex: 2, rotateAngle: 90, coolDown: 750),
                    new Shoot(40, 3, projectileIndex: 1, coolDown: 1000),
                    new Grenade(2, 250, 3, coolDown: 3000)
                    )
                )
            )
        .Init("Vitalia",
            new State(
                new RemoveObjectOnDeath("CGarden Wall Lenin", 600),
                new State("wait",
                    new ScaleHP(45000),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new PlayerWithinTransition(15, "dialogue")
                    ),
                new State("dialogue",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("So you did find your way through the garden..."),
                    new TimedTransition(2250, "dialogue2")
                    ),
                new State("dialogue2",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("No one has made it through the garden alive for hundreds of years..."),
                    new TimedTransition(2250, "dialogue3")
                    ),
                new State("dialogue3",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("You'll make for a nice snack."),
                    new TimedTransition(2250, "activate")
                    ),
                new State("activate",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Flash(0xfFF0000, flashRepeats: 1, flashPeriod: 3),
                    new TimedTransition(2000, "fight")
                    ),
                new State("fight",
                    new Taunt("Lets see how your dodging skills are!"),
                    new Shoot(40, 8, shootAngle: 15, projectileIndex: 0, coolDown: 1000),
                    new Shoot(40, 1, shootAngle: 180, projectileIndex: 0, coolDown: 1000),
                    new Shoot(40, 2, projectileIndex: 1, coolDown: 1500, coolDownOffset: 2000),
                    new Shoot(40, 2, fixedAngle: 45, projectileIndex: 1, coolDown: 1500, coolDownOffset: 1000),
                    new Shoot(40, 2, fixedAngle: 135, projectileIndex: 2, coolDown: 1500, coolDownOffset: 1500),
                    new Shoot(40, 2, fixedAngle: 225, projectileIndex: 3, coolDown: 1500, coolDownOffset: 2000),
                    new Shoot(40, 2, fixedAngle: 315, projectileIndex: 4, coolDown: 1500, coolDownOffset: 2500),
                    new Shoot(40, 1, projectileIndex: 5, coolDown: 4000, coolDownOffset: 4000),
                    new Shoot(40, 1, projectileIndex: 6, coolDown: 2000, coolDownOffset: 750),
                    new TossObject("The Y-Eater", 4, 90, coolDown: 7500),
                    new TossObject("The Y-Eater", 4, 180, coolDown: 7500),
                    new TossObject("The Y-Eater", 4, 270, coolDown: 7500),
                    new TossObject("The Y-Eater", 4, 0, coolDown: 7500),
                    new DamageTakenTransition(162500,"fight2")
                    ),
                new State("fight2",
                    new Taunt("Good luck dodging when you're trapped in my vines!"),
                    new Order(60, "Vitalia Vine Helper", "timer"),
                    new Spawn("Vitalia Vine", 1, 1, coolDown: 999999),
                    new TimedTransition(1000, "fight2a")
                    ),
                new State("fight2a",
                    new Shoot(40, 3, fixedAngle: 45, projectileIndex: 7, coolDown: 750, coolDownOffset: 250),
                    new Shoot(40, 3, fixedAngle: 135, projectileIndex: 8, coolDown: 750, coolDownOffset: 500),
                    new Shoot(40, 3, fixedAngle: 225, projectileIndex: 9, coolDown: 750, coolDownOffset: 750),
                    new Shoot(40, 3, fixedAngle: 315, projectileIndex: 10, coolDown: 750, coolDownOffset: 1000),
                    new DamageTakenTransition(250000,"fight2b"),
                    new TimedTransition(7500, "fight2b")
                    ),
                new State("fight2b",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Order(60, "Vitalia Vine Helper", "wait"),
                    new Taunt("Lets see if you can survive my minions!"),
                    new Shoot(40, 4, fixedAngle: 45, shootAngle: 90, projectileIndex: 11, coolDown: 50, coolDownOffset: 100),
                    new TossObject("Chomper", 5, 135, coolDown: 1000000),
                    new TossObject("Chomper", 5, 315, coolDown: 1000000),
                    new TossObject("Kwargnor the Devourer of worlds", 5, 45, coolDown: 10000, coolDownOffset: 15000),
                    new TossObject("Kwargnor the Devourer of worlds", 5, 225, coolDown: 10000, coolDownOffset: 15000),
                    new TimedTransition(20000, "waitfight2b")
                    ),
                new State("waitfight2b",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Shoot(40, 4, fixedAngle: 45, shootAngle: 90, projectileIndex: 11, coolDown: 50, coolDownOffset: 100),
                    new EntitiesNotExistsTransition(20, "fight2c", "Chomper", "Kwargnor the Devourer of worlds")
                    ),
                new State("fight2c",
                    new Taunt("Fine! I didn't need them anyway"),
                    new Shoot(40, 4, fixedAngle: 45, shootAngle: 90, projectileIndex: 11, coolDown: 50, coolDownOffset: 100),
                    new Shoot(40, 4, shootAngle: 13, projectileIndex: 0, coolDown: 300),
                    new TossObject("The Y-Eater", 2, coolDown: 3000),
                    new DamageTakenTransition(375000,"fight3")
                    ),
                new State("fight3",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new TimedTransition(2000, "purplelava")
                    ),
                new State("purplelava",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new ReplaceTile("CGarden Floor Dark", "CGarden Lava2", 80),
                    new TimedTransition(3000,"fight3b")
                    ),
                new State("fight3b",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Taunt("AAAAAAAA"),
                     new TimedTransition(2000, "skinswitch")
                    ),
                new State("skinswitch",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new SetAltTexture(2),
                    new TimedTransition(1000, "skinswitch2")
                    ),
                new State("skinswitch2",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new SetAltTexture(3),
                    new TimedTransition(1000, "skinswitch3")
                    ),
                new State("skinswitch3",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new SetAltTexture(1),
                    new TimedTransition(1000, "fight4t")
                    ),
                new State("fight4t",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Taunt("Finally I could get out of that form, thank you warrior."),
                    new TimedTransition(2000, "fight4")
                    ),
                new State("fight4",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Flash(0xfFF0000, flashRepeats: 1, flashPeriod: 3),
                    new ChangeSize(25, 200),
                    new Taunt("This does not mean you shall be spared."),
                    new TimedTransition(2000, "fight4a")
                    ),
                new State("fight4a",
                    new Spawn("Vitalia Tracker", 1, 1),
                    new Follow(1, 10, 0),
                    new Wander(0.4),
                    new Shoot(40, 18, shootAngle: 20, projectileIndex: 13, coolDown: 3000),
                    new TimedTransition(5000, "fight4aa"),
                    new DamageTakenTransition(468750,"fight5")
                    ),
                new State("fight4aa",
                    new Charge(2, 1, coolDown: 100000),
                    new Flash(0xfFF0000, flashRepeats: 1, flashPeriod: 3),
                    new Shoot(40, 20, projectileIndex: 14, coolDown: 100000000, coolDownOffset: 3000),
                    new Shoot(40, 20, projectileIndex: 15, coolDown: 100000000, coolDownOffset: 3500),
                    new Shoot(40, 20, projectileIndex: 14, coolDown: 100000000, coolDownOffset: 5000),
                    new Shoot(40, 20, projectileIndex: 15, coolDown: 100000000, coolDownOffset: 5500),
                    new TimedTransition(5000, "fight4b"),
                    new DamageTakenTransition(468750, "fight5")
                    ),
                new State("fight4b",
                    new Follow(1, 10, 0),
                    new Shoot(40, 18, shootAngle: 20, projectileIndex: 13, coolDown: 3000),
                    new Shoot(40, 3, shootAngle: 13, projectileIndex: 15, coolDown: 400, coolDownOffset: 500),
                    new TimedTransition(5000, "fight4a"),
                    new DamageTakenTransition(468750, "fight5")
                    ),
                new State("fight5",
                    new Orbit(1, 5, 10, "Vitalia Tracker"),
                    new Charge(3, 10, coolDown: 6000),
                    new Follow(2, 10, 1),
                    new TossObject("Vitalia Vine", 5, coolDown: 3500),
                    new Shoot(40, 1, projectileIndex: 15, coolDown: 600),
                    new Shoot(40, 6, projectileIndex: 14, coolDown: 6000, coolDownOffset: 6000),
                    new Shoot(40, 3, fixedAngle: 45, projectileIndex: 7, coolDown: 1000, coolDownOffset: 250),
                    new DamageTakenTransition(531250,"fight5a")
                    ),
                new State("fight5a",
                    new Orbit(1, 5, 10, "Vitalia Tracker"),
                    new Charge(3, 10, coolDown: 6000),
                    new Follow(2, 10, 1),
                    new TossObject("Vitalia Vine", 5, coolDown: 3500),
                    new TossObject("Chomper", 5, coolDown: 6000),
                    new Shoot(40, 1, projectileIndex: 15, coolDown: 600),
                    new Shoot(40, 6, projectileIndex: 14, coolDown: 6000, coolDownOffset: 6000),
                    new Shoot(40, 3, fixedAngle: 45, projectileIndex: 7, coolDown: 1000, coolDownOffset: 250),
                    new Shoot(40, 3, fixedAngle: 135, projectileIndex: 8, coolDown: 1000, coolDownOffset: 500),
                    new DamageTakenTransition(562500,"fight5b")
                    ),
                new State("fight5b",
                    new Orbit(1, 5, 10, "Vitalia Tracker"),
                    new Charge(3, 10, coolDown: 6000),
                    new Follow(2, 10, 1),
                    new TossObject("Vitalia Vine", 5, coolDown: 3500),
                    new TossObject("Chomper", 5, coolDown: 6000),
                    new TossObject("Kwargnor the Devourer of worlds", 5, coolDown: 8000),
                    new Shoot(40, 1, projectileIndex: 15, coolDown: 600),
                    new Shoot(40, 6, projectileIndex: 14, coolDown: 6000, coolDownOffset: 6000),
                    new Shoot(40, 3, fixedAngle: 45, projectileIndex: 7, coolDown: 1000, coolDownOffset: 250),
                    new Shoot(40, 3, fixedAngle: 135, projectileIndex: 8, coolDown: 1000, coolDownOffset: 500),
                    new Shoot(40, 3, fixedAngle: 225, projectileIndex: 9, coolDown: 1000, coolDownOffset: 750),
                    new Shoot(40, 3, fixedAngle: 315, projectileIndex: 10, coolDown: 1000, coolDownOffset: 1000),
                    new DamageTakenTransition(593750,"death")
                    ),
                new State("death",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Flash(0xFFFFFF, 1, 2),
                    new ReturnToSpawn(2),
                    new ReplaceTile("CGarden Lava2","CGarden Floor Dark", 80),
                    new Taunt("You.. Cant.. Kill.. Nature.."),
                    new TimedTransition(2500, "ripmyman")
                    ),
                new State("ripmyman",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new TimedTransition(2000, "canyoudiealready")
                    ),
                new State("canyoudiealready",
                    new Suicide()
                    )
                ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.01,
                    new ItemLoot("Greater Potion of Life", 1),
                    new ItemLoot("Greater Potion of Vitality", 1),
                    new ItemLoot("1000 Gold", 1),
                    new ItemLoot("Gold Cache", 1),
                    new ItemLoot("Onrane", 1),
                    new ItemLoot("Viperstring", 0.01),
                    new ItemLoot("Blade of Thorns", 0.01),
                    new ItemLoot("Rose Petal Amulet", 0.01),
                    new ItemLoot("Rose Petal Staff", 0.01)
                )
            )
        .Init("Vitalia Turret",
            new State(
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new PlayerWithinTransition(7, "diagonal")
                    ),
                new State("diagonal",
                    new SetAltTexture(2),
                    new Shoot(40, 4, fixedAngle: 90, projectileIndex: 0, coolDown: 50),
                    new TimedTransition(5000, "line")
                    ),
                new State("line",
                    new SetAltTexture(1),
                    new Order(40, "Vitalia Turret Helper", "shoot"),
                    new TimedTransition(5000, "diagonal")
                    )
                )
            )
        .Init("Vitalia Turret Helper",
            new State(
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                new State("shoot",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Shoot(40, 2, fixedAngle: 90, shootAngle: 180, coolDown: 50),
                    new TimedTransition(5000, "wait"),
                    new EntitiesNotExistsTransition(5, "wait", "Vitalia Turret")
                    )
                )
            )
        .Init("Vitalia Turret Helper2",
            new State(
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntitiesNotExistsTransition(5, "timer", "Vitalia Turret")
                    ),
                new State("timer",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(30000, "spawn")
                    ),
                new State("spawn",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new InvisiToss("Vitalia Turret", 1, angle: 0, coolDown: 900000),
                    new TimedTransition(1500, "wait")
                    )
                )
            )
        .Init("Vitalia Vine",
            new State(
                new State("begin",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Follow(1, 10, 0),
                    new Shoot(5, 1, projectileIndex: 0, coolDown: 500),
                    new PlayerWithinTransition(1, "wegotem")
                    ),
                new State("wegotem",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new ApplySetpiece("VitaliaVine"),
                    new TimedTransition(500, "wait")
                    ),
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ReturnToSpawn(1)
                    )
                )
            )
        .Init("Vitalia Vine2",
            new State(
                new State("begin",
                     new ConditionalEffect(ConditionEffectIndex.Invincible),
                     new Shoot(5, 1, projectileIndex: 0, coolDown: 500),
                     new TimedTransition(3000, "death")
                    ),
                new State("death",
                    new Suicide()
                    )
                )
            )
        .Init("Vitalia Vine Helper",
            new State(
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                new State("timer",
                    new TimedTransition(10000, "spawn")
                    ),
                new State("spawn",
                    new Spawn("Vitalia Vine", 1, 1, coolDown: 999999),
                    new TimedTransition(1000, "timer")
                    )
                )
            )
        .Init("Vitalia Colour Changer",
            new State(
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                new State("blank",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ReplaceTile("CGarden Floor Blue1", "CGarden Floor", 0),
                    new ReplaceTile("CGarden Floor Red1", "CGarden Floor", 0),
                    new ReplaceTile("CGarden Floor Yellow1", "CGarden Floor", 0),
                    new ReplaceTile("CGarden Floor Purple1", "CGarden Floor", 0)
                    ),
                new State("purple",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ReplaceTile("CGarden Floor", "CGarden Floor Purple1", 0),
                    new TimedTransition(1000, "wait")
                    ),
                new State("blue",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ReplaceTile("CGarden Floor", "CGarden Floor Blue1", 0),
                    new TimedTransition(1000, "wait")
                    ),
                new State("red",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ReplaceTile("CGarden Floor", "CGarden Floor Red1", 0),
                    new TimedTransition(1000, "wait")
                    ),
                new State("yellow",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ReplaceTile("CGarden Floor", "CGarden Floor Yellow1", 0),
                    new TimedTransition(1000, "wait")
                    )
                )
            )
        .Init("Vitalia Tracker",
            new State(
                new Follow(2, 10, 1)
                )
            )
            .Init("CGarden Wall Lenin",
                new State(
                    new State("Idle",
                        new PlayerTextTransition("Despawn", "Almighty Lenin, grant us passage!", 8, false, false)
                        ),
                    new State("Despawn",
                        new Decay(0)
                        )
                    )
            )
             .Init("CGarden Wall Lenin Spawner",
                new State(
                    new State("Idle",
                        new EntityNotExistsTransition("Vitalia", 1000, "spawn")
                        ),
                    new State("spawn",
                        new Spawn("CGarden Wall Lenin")
                        )
                    )
            )
        .Init("Lenin",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "Crown")
                    ),
                    new State("Crown")
                ),
               new Threshold(0.02,
                    new ItemLoot("Potion of Life", 1),
                    new ItemLoot("Potion of Mana", 1),
                    new ItemLoot("Potion of Attack", 1),
                    new ItemLoot("Potion of Defense", 1),
                    new ItemLoot("Potion of Speed", 1),
                    new ItemLoot("Potion of Dexterity", 1),
                    new ItemLoot("Potion of Vitality", 1),
                    new ItemLoot("Potion of Wisdom", 1),
                    new ItemLoot("Potion of Might", 1),
                    new ItemLoot("Potion of Luck", 1),
                    new ItemLoot("Potion of Restoration", 1),
                    new ItemLoot("Potion of Protection", 1),
                    new ItemLoot("Skull of Lenin", 0.01)
                    )
                )
           .Init("Lenin Big",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)

                )
            )
            )
        .Init("CGarden Boulder",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                        ),
                    new State("rollout",
                        new Shoot(500, 1, projectileIndex: 0, fixedAngle: 90, coolDown: 50000),
                        new TimedTransition(1500, "shootagain")
                        ),
                    new State("shootagain",
                        new Shoot(500, 1, projectileIndex: 0, fixedAngle: 90, coolDown: 50000),
                        new Suicide()

                )
            )
            )
        .Init("CGarden Skull wait",
                new State(
                    new TransformOnDeath("CGarden Skull Fountain"),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                        ),
                    new State("order",
                        new Suicide()

                )
            )
            )
        .Init("CGarden Skull Fountain",
                new State(
                    new TransformOnDeath("CGarden Skull Fountain Loop"),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2800, "loop animation")
                        ),
                    new State("loop animation",
                        new Suicide()

                )
            )
            )
           .Init("CGarden Skull Fountain Loop",
                new State(
                    new TransformOnDeath("CGarden Skull wait"),
                    new State("bombs",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TossObject("Granithia Bomb", range: 5, coolDown: 2000),
                        new TossObject("Granithia Bomb", range: 5, coolDown: 2000, coolDownOffset: 450)
                        ),
                    new State("death",
                        new Suicide()


                )
            )
            )
        .Init("Granithia",
                new State(
                    new State("locate",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(8, "preyeet")
                        ),
                    new State("preyeet",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("How dare you come into our Garden and slay my sister!"),
                        new TimedTransition(2500, "yeet")
                        ),
                    new State("yeet",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("You will not find me so easy to defeat."),
                        new TimedTransition(2500, "stillyeeting")
                        ),
                    new State("stillyeeting",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("She was always the kinder one, I show no such mercy"),
                        new TimedTransition(3000, "fight")
                        ),
                    new State("fight",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("Dodge this!"),
                        new Order(40, "CGarden Boulder", "rollout"),
                        new TimedTransition(200, "fighta")
                        ),
                    new State("fighta",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Order(500, "CGarden Skull wait", "order"),
                        new TimedTransition(2000, "fightb")
                        ),
                    new State("fightb",
                        new Taunt("Lets see how well you do when split apart!"),
                        new Shoot(50, 8, fixedAngle: 45, projectileIndex: 4, shootAngle: 45, coolDown: 25),
                        new Shoot(50, 8, fixedAngle: 45, projectileIndex: 4, shootAngle: 45, coolDown: 50, coolDownOffset: 50),
                        new DamageTakenTransition(100000, "fight2"),
                        new TimedTransition(4500, "fightba")
                        ),
                    new State("fightba",
                        new Taunt("SWITCH!"),
                        new Shoot(50, 8, fixedAngle: 72, projectileIndex: 4, shootAngle: 45, coolDown: 25),
                        new Shoot(50, 8, fixedAngle: 72, projectileIndex: 4, shootAngle: 45, coolDown: 50, coolDownOffset: 50),
                        new DamageTakenTransition(100000, "fight2"),
                        new TimedTransition(4500, "fightbb")
                        ),
                    new State("fightbb",
                        new Taunt("SWITCH!"),
                        new Shoot(50, 8, fixedAngle: 45, projectileIndex: 4, shootAngle: 45, coolDown: 25),
                        new Shoot(50, 8, fixedAngle: 45, projectileIndex: 4, shootAngle: 45, coolDown: 50, coolDownOffset: 50),
                        new DamageTakenTransition(100000, "fight2"),
                        new TimedTransition(4500, "fightba")
                        ),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Order(500, "CGarden Skull Fountain Loop", "death"),
                        new Taunt("Pathetic, maybe you can deal more damage when all together."),
                        new MoveTo2(0, -10, 0.3, true),
                        new TimedTransition(1500, "fight2a")
                        ),
                    new State("fight2a",
                        new Wander(0.3),
                        new Shoot(50, 3, shootAngle: 12, projectileIndex: 0, coolDown: 1150),
                        new Shoot(50, 8, fixedAngle: 45, shootAngle: 5, projectileIndex: 1, coolDown: 3000),
                        new DamageTakenTransition(250000, "fight3"),
                        new TimedTransition(5000, "fight2b")
                        ),
                    new State("fight2b",
                        new Shoot(60, 36, shootAngle: 10, projectileIndex: 5, coolDown: 2000),
                        new Grenade(5, 150, 0, fixedAngle: 0, coolDown: 2000),
                        new DamageTakenTransition(250000, "fight3"),
                        new TimedTransition(4000, "fight2a")
                        ),
                    new State("fight3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(1),
                        new Taunt("Servants, ATTACK!"),
                        new TossObject("Servant of Granithia", 4, 270, coolDown: 99999),
                        new TossObject("Servant of Granithia", 4, 225, coolDown: 99999),
                        new TossObject("Servant of Granithia", 4, 315, coolDown: 99999),
                        new TossObject("Servant of Granithia", 4, 315, coolDown: 99999, coolDownOffset: 8000),
                        new TossObject("Servant of Granithia", 4, 360, coolDown: 99999, coolDownOffset: 8000),
                        new TossObject("Servant of Granithia", 4, 45, coolDown: 99999, coolDownOffset: 8000),
                        new TossObject("Servant of Granithia", 4, 45, coolDown: 99999, coolDownOffset: 16000),
                        new TossObject("Servant of Granithia", 4, 90, coolDown: 99999, coolDownOffset: 16000),
                        new TossObject("Servant of Granithia", 4, 135, coolDown: 99999, coolDownOffset: 16000),
                        new TossObject("Servant of Granithia", 4, 135, coolDown: 99999, coolDownOffset: 24000),
                        new TossObject("Servant of Granithia", 4, 180, coolDown: 99999, coolDownOffset: 24000),
                        new TossObject("Servant of Granithia", 4, 225, coolDown: 99999, coolDownOffset: 24000),
                        new TimedTransition(28000, "waitforservants")
                        ),
                    new State("waitforservants",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntitiesNotExistsTransition(30, "fight4", "Servant of Granithia")
                        ),
                    new State("fight4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("IM GETTING SICK OF YOU! LEAVE MY GARDEN!"),
                        new TimedTransition(2000, "fight4a")
                        ),
                    new State("fight4a",
                        new Follow(0.6, 10, 0),
                        new Order(500, "CGarden Skull wait", "order"),
                        new Grenade(3, 200, 5, coolDown: 1300),
                        new Shoot(50, 3, shootAngle: 12, projectileIndex: 0, coolDown: 950),
                        new Shoot(50, 8, shootAngle: 30, projectileIndex: 6, coolDown: 800),
                        new DamageTakenTransition(275000, "fight4b")
                        ),
                     new State("fight4b",
                        new Follow(0.8, 10, 0),
                        new Grenade(3, 200, 5, coolDown: 1300),
                        new Shoot(50, 3, shootAngle: 12, projectileIndex: 0, coolDown: 950),
                        new Shoot(50, 8, shootAngle: 30, projectileIndex: 6, coolDown: 800),
                        new DamageTakenTransition(300000, "fight4c")
                         ),
                     new State("fight4c",
                        new Follow(1, 10, 0),
                        new Grenade(3, 200, 5, coolDown: 1300),
                        new Shoot(50, 3, shootAngle: 12, projectileIndex: 0, coolDown: 950),
                        new Shoot(50, 8, shootAngle: 30, projectileIndex: 6, coolDown: 800),
                        new DamageTakenTransition(350000, "fight4d")
                         ),
                     new State("fight4d",
                        new Follow(1.2, 10, 0),
                        new Grenade(3, 200, 5, coolDown: 1300),
                        new Shoot(50, 3, shootAngle: 12, projectileIndex: 0, coolDown: 950),
                        new Shoot(50, 8, shootAngle: 30, projectileIndex: 6, coolDown: 800),
                        new DamageTakenTransition(400000, "fight5")
                         ),
                     new State("fight5",
                         new ConditionalEffect(ConditionEffectIndex.Invincible),
                         new ChangeSize(5, 200),
                         new Taunt("ENOUGH!I SHALL END YOU ALL!"),
                         new TimedTransition(1500, "fight5a")
                         ),
                     new State("fight5a",
                          new Wander(0.1),
                          new Shoot(60, 36, shootAngle: 10, projectileIndex: 5, coolDown: 2000),
                          new Shoot(60, 36, shootAngle: 10, projectileIndex: 5, coolDown: 2000, coolDownOffset: 1000),
                          new Shoot(60, 36, shootAngle: 10, projectileIndex: 5, coolDown: 2000, coolDownOffset: 2000),
                          new Shoot(60, 36, shootAngle: 10, projectileIndex: 5, coolDown: 2000, coolDownOffset: 3000),
                          new DamageTakenTransition(490000, "death"),
                          new TimedTransition(5000, "fight5b")
                         ),
                     new State("fight5b",
                         new Charge(2, 10),
                         new Shoot(60, 1, projectileIndex:1, fixedAngle: 90, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 100, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 110, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 127, coolDown: 2000,coolDownOffset:500),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 145, coolDown: 2000,coolDownOffset:1000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 162, coolDown: 2000,coolDownOffset:1500),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 180, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 190, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 200, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 217, coolDown: 2000, coolDownOffset: 500),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 235, coolDown: 2000, coolDownOffset: 1000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 252, coolDown: 2000, coolDownOffset: 1500),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 270, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 280, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 290, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 307, coolDown: 2000, coolDownOffset: 500),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 325, coolDown: 2000, coolDownOffset: 1000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 342, coolDown: 2000, coolDownOffset: 1500),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 0, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 10, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 20, coolDown: 2000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 37, coolDown: 2000, coolDownOffset: 500),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 55, coolDown: 2000, coolDownOffset: 1000),
                         new Shoot(60, 1, projectileIndex: 1, fixedAngle: 72, coolDown: 2000, coolDownOffset: 1500),
                         new DamageTakenTransition(490000, "death"),
                         new TimedTransition(5000,"fight5c")
                         ),
                     new State("fight5c",
                         new Taunt("Try not to get flattened!"),
                         new Shoot(60,1,projectileIndex:3,predictive:1,coolDown:750),
                         new DamageTakenTransition(490000,"death"),
                         new TimedTransition(5000,"fight5a")
                         ),
                     new State("death",
                         new ConditionalEffect(ConditionEffectIndex.Invincible),
                         new Taunt("You can weather a rock as much as you'd like... but it will never be gone for good..."),
                         new TimedTransition(2000,"sodramatic")
                         ),
                     new State("sodramatic",
                         new Suicide()
                         

                            )
                        )
                    )
          .Init("Granithia Bomb",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(600, "Explode")
                        ),
                    new State("Explode",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Shoot(100, projectileIndex: 0, count: 8),
                        new Suicide()
                        )
                    )
            )
        .Init("Servant of Granithia",
            new State(
                new State("wait",
                    new ScaleHP(2000),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new PlayerWithinTransition(7, "attack")
                    ),
                new State("attack",
                    new Follow(0.7, 10, 3),
                    new Shoot(20, 5, shootAngle: 36, coolDown: 1750, coolDownOffset: 250),
                    new Shoot(20, 3, shootAngle: 15, projectileIndex: 1, coolDown: 1500, coolDownOffset: 350),
                    new DamageTakenTransition(10000,"uberattack"),
                    new TimedTransition(5000, "attackbutwander")
                    ),
                new State("attackbutwander",
                    new Wander(1),
                    new Shoot(20, 5, shootAngle: 36, coolDown: 1750, coolDownOffset: 250),
                    new Shoot(20, 3, shootAngle: 15, projectileIndex: 1, coolDown: 1500, coolDownOffset: 350),
                    new HpLessTransition(0.15, "uberattack"),
                    new TimedTransition(3500, "attack")
                    ),
                new State("uberattack",
                    new Flash(0xff00ff00, 0.1, 20),
                    new Shoot(20, 9, shootAngle: 30, projectileIndex: 1, coolDown: 100, coolDownOffset: 250)
                    )
                )
            )
            ;
    }
}