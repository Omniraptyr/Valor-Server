using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Yazanahar = () => Behav()
            .Init("Yazanahar",
                new State(
                    new DropPortalOnDeath("Ancient Depths Portal"),
                    new ScaleHP(100000),
                    new HpLessTransition(0.20, "death1"),
                    new SetAltTexture(2),
                    new State(
                        new State("default",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new PlayerTextTransition("default1", "Arise, Yazanahar, ARISE!", 8, false, false)

                        ),
                        new State("default1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Flash(0xFFFFFF, 2, 2),
                            new TimedTransition(6000, "default2")
                        ),
                        new State("default2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Taunt("Entering this forbidden land comes with a toll.", "You do not seem worthy enough to enter these depths."),
                            new TimedTransition(4000, "default3")
                        ),
                        new State("default3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Taunt("Stand back..Let me show you what I am made of...", "Flee. NOW! Before you end up another worthless spirit."),
                            new TimedTransition(2000, "startup")
                        )
                    ),
                    new State("startup",
                        new Taunt(true, "Power."),
                        new SetAltTexture(0),
                        new Shoot(10, 38, projectileIndex: 2, coolDown: 9999),
                        new TimedTransition(4000, "spawnhelpers")
                    ),
                    new State("spawnhelpers",
                        new InvisiToss("Yazanahar Helper", 2, 0, coolDown: 9999999),
                        new InvisiToss("Yazanahar Helper", 2, 90, coolDown: 9999999),
                        new InvisiToss("Yazanahar Helper", 2, 180, coolDown: 9999999),
                        new InvisiToss("Yazanahar Helper", 2, 270, coolDown: 9999999),
                        new Shoot(10, 14, shootAngle: 4, projectileIndex: 5, predictive: 2, coolDown: 2000),
                        new TimedTransition(12000, "begin")
                    ),
                    new State("begin",
                        new Flash(0xFF0000, 1, 1),
                        new TimedTransition(4000, "StartWaves1")
                    ),
                    new State(
                        new TimedTransition(8000, "WeirdMovement1"),
                        new State("StartWaves1",
                            new Shoot(10, count: 7, shootAngle: 2, fixedAngle: 90, projectileIndex: 0, coolDown: 400),
                            new Shoot(10, count: 7, shootAngle: 2, fixedAngle: 180, projectileIndex: 0, coolDown: 400),
                            new Shoot(10, count: 7, shootAngle: 2, fixedAngle: 270, projectileIndex: 0, coolDown: 400),
                            new Shoot(10, count: 7, shootAngle: 2, fixedAngle: 0, projectileIndex: 0, coolDown: 400),
                            new TimedTransition(800, "StartWaves2")
                        ),
                        new State("StartWaves2",
                            new Shoot(10, count: 7, shootAngle: 2, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                            new Shoot(10, count: 7, shootAngle: 2, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                            new Shoot(10, count: 7, shootAngle: 2, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                            new Shoot(10, count: 7, shootAngle: 2, fixedAngle: 315, projectileIndex: 0, coolDown: 400),
                            new TimedTransition(800, "StartWaves1")
                        )
                    ),
                    new State(
                        new Shoot(10, 8, projectileIndex: 1, coolDown: 2000),
                        new RemoveEntity(8, "Yazanahar Helper"),

                        new State(
                            new TimedTransition(24000, "Return"),
                            new State("WeirdMovement1",
                                new Charge(2.5, range: 8, coolDown: 4600),
                                new TimedTransition(4000, "Flash")
                            ),
                            new State("Flash",
                                new BackAndForth(0.4, distance: 4),
                                new Flash(0xFF0000, 1, 1),
                                new TimedTransition(3000, "WeirdMovement2")
                            ),
                            new State("WeirdMovement2",
                                new Grenade(1, 500, range: 8, coolDown: 1000),
                                new Shoot(10, count: 2, shootAngle: 18, projectileIndex: 3, coolDown: 1000),
                                new Shoot(10, count: 8, shootAngle: 8, projectileIndex: 4, coolDown: 100),
                                new TimedTransition(4000, "WeirdMovement1")
                            )
                        ),
                        new State(
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new State("Return",
                                new ReturnToSpawn(speed: 1.2),
                                new TimedTransition(6000, "Reform")
                            ),

                            new State("Reform",
                                new SetAltTexture(1),
                                new InvisiToss("Split Yazanahar", 2, 0, coolDown: 9999999),
                                new InvisiToss("Split Yazanahar", 2, 180, coolDown: 9999999),
                                new InvisiToss("Split Yazanahar", 2, 270, coolDown: 9999999),
                                new TimedTransition(5000, "checker")
                            ),
                            new State("checker",
                                new EntitiesNotExistsTransition(20, "Ongo", "Split Yazanahar")
                            )
                        ),
                        new State("Ongo",
                            new ConditionalEffect(ConditionEffectIndex.Armored),
                            new SetAltTexture(0),
                            new Prioritize(
                                new StayCloseToSpawn(0.5, 3),
                                new Wander(0.05)
                            ),
                            new Grenade(2, 400, range: 8, coolDown: 400),
                            new Shoot(10, 6, projectileIndex: 1, coolDown: 4000),
                            new Shoot(10, 10, shootAngle: 10, projectileIndex: 5, coolDown: 5000),
                            new Shoot(10, 5, shootAngle: 4, projectileIndex: 2, coolDown: 1600),
                            new TimedTransition(8000, "fast")
                        ),
                        new State("fast",
                            new Taunt("Your soul essence is a feast, {PLAYER}"),
                            new ConditionalEffect(ConditionEffectIndex.Armored),
                            new SetAltTexture(0),
                            new Prioritize(
                                new Orbit(0.7, 2, target: null)
                            ),
                            new Shoot(10, 20, projectileIndex: 2, coolDown: 2000),
                            new Shoot(10, 7, shootAngle: 12, predictive: 1, projectileIndex: 0, coolDown: 6000),
                            new Shoot(10, 5, shootAngle: 4, projectileIndex: 2, coolDown: 1600),
                            new Shoot(10, 10, shootAngle: 4, projectileIndex: 4, coolDown: 2900),
                            new TimedTransition(15000, "Return2")
                        ),
                        new State("Return2",
                            new Flash(0x000000, 2, 2),
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new ReturnToSpawn(speed: 1.2),
                            new TimedTransition(6000, "DropDown")
                        ),
                        new State("DropDown",
                            new HealSelf(coolDown: 6000, amount: 1000),
                            new Shoot(10, 6, shootAngle: 22, projectileIndex: 6, coolDown: 1600),
                            new Shoot(10, 3, shootAngle: 8, projectileIndex: 2, coolDown: 400),
                            new Shoot(10, 9, shootAngle: 8, projectileIndex: 4, predictive: 1, coolDown: 400, coolDownOffset: 800),
                            new Taunt("You strange mortals think you have the bravery and courage of a true guardian?", "Cowards."),
                            new ConditionalEffect(ConditionEffectIndex.Armored),
                            new InvisiToss("Yazanahar Helper 2", 4, 0, coolDown: 9999999),
                            new InvisiToss("Yazanahar Helper 2", 2, 45, coolDown: 9999999),
                            new InvisiToss("Yazanahar Helper 2", 4, 90, coolDown: 9999999),
                            new InvisiToss("Yazanahar Helper 2", 2, 135, coolDown: 9999999),
                            new InvisiToss("Yazanahar Helper 2", 4, 180, coolDown: 9999999),
                            new InvisiToss("Yazanahar Helper 2", 2, 225, coolDown: 9999999),
                            new InvisiToss("Yazanahar Helper 2", 4, 270, coolDown: 9999999),
                            new InvisiToss("Yazanahar Helper 2", 2, 315, coolDown: 9999999),
                            new TimedTransition(24000, "tttt")
                        ),
                        new State("tttt",
                            new Order(6, "Yazanahar Helper 2", "Explode"),
                            new Taunt("Havent died yet have you?!", "Your lives WILL be crushed!", "Forward you come, the graves you will be."),
                            new ConditionalEffect(ConditionEffectIndex.Armored),
                            new TimedTransition(4000, "swagche")
                        ),
                        new State("swagche",
                            new HealSelf(coolDown: 1000, amount: 300),
                            new Shoot(10, 24, projectileIndex: 5, coolDown: 6000),
                            new Shoot(10, 4, projectileIndex: 4, predictive: 1, shootAngle: 12, coolDown: 100),
                            new Shoot(10, 1, projectileIndex: 6, coolDown: 100),
                            new Shoot(10, 1, projectileIndex: 6, coolDown: 100, coolDownOffset: 100),
                            new TimedTransition(9000, "startup")
                        ),
                        new State("death1",
                            new Taunt(true, "..."),
                            new Flash(0x000055, 1, 1),
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new RemoveEntity(20, "Yazanahar Helper"),
                            new RemoveEntity(20, "Yazanahar Helper 2"),
                            new ReturnToSpawn(speed: 2),
                            new TimedTransition(8600, "death")
                        ),
                        new State("death",
                            new Suicide()
                        )
                    )
                ),
                new MostDamagers(3,
                    LootTemplates.Sor3Perc()
                    ),
                new Threshold(0.01,
                    new ItemLoot("Potion of Life", 0.5),
                    new ItemLoot("Potion of Mana", 0.5),
                    new ItemLoot("Potion of Vitality", 0.5),
                    new ItemLoot("Potion of Dexterity", 0.5),
                    new ItemLoot("Potion of Speed", 0.5),
                    new ItemLoot("Potion of Attack", 0.5),
                    new ItemLoot("Potion of Defense", 0.5),
                    new ItemLoot("Potion of Wisdom", 0.5),
                    new ItemLoot("Greater Potion of Life", 0.1),
                    new ItemLoot("Greater Potion of Mana", 0.1),
                    new ItemLoot("Greater Potion of Vitality", 0.1),
                    new ItemLoot("Greater Potion of Dexterity", 0.1),
                    new ItemLoot("Greater Potion of Speed", 0.1),
                    new ItemLoot("Greater Potion of Attack", 0.1),
                    new ItemLoot("Greater Potion of Defense", 0.1),
                    new ItemLoot("Greater Potion of Wisdom", 0.1),
                    new ItemLoot("Shard of Ancient Assault", 0.001),
                    new TierLoot(11, ItemType.Weapon, 0.1),
                    new TierLoot(6, ItemType.Ability, 0.1),
                    new TierLoot(11, ItemType.Armor, 0.1),
                    new TierLoot(5, ItemType.Ring, 0.05),
                    new TierLoot(12, ItemType.Armor, 0.05),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new TierLoot(6, ItemType.Ring, 0.025)
                )
            )

            .Init("Split Yazanahar",
                new State(
                    new ScaleHP(5000),
                    new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                    new State("swag",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 3),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 8, projectileIndex: 0, coolDown: 1400),
                        new TimedTransition(12000, "time")
                    ),
                    new State("time",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 8, shootAngle: 6, projectileIndex: 1, coolDown: 1),
                        new TimedTransition(8000, "swag")
                    )
                )
            )
            .Init("Yazanahar Helper",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("swag",
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1)
                    )
                )
            )
            .Init("Yazanahar Helper 2",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("1",
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 600),
                        new TimedTransition(4000, "2")
                    ),
                    new State("2",
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 600),
                        new TimedTransition(4000, "3")
                    ),
                    new State("3",
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 600),
                        new TimedTransition(4000, "4")
                    ),
                    new State("4",
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 600),
                        new TimedTransition(4000, "1")
                    ),

                    new State("Explode",
                        new Shoot(10, count: 12, projectileIndex: 0, coolDown: 99999),
                        new Suicide()
                    )
                )
            )
            .Init("Vicious Croc",
                new State(
                    new State(
                        new Prioritize(
                            new Protect(0.8, "Krokanich", acquireRange: 16, protectionRange: 4, reprotectRange: 2),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 3, shootAngle: 10, predictive: 0.2, projectileIndex: 0, coolDown: new Cooldown(2000, 6000)),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: new Cooldown(2000, 2000)),
                        new HpLessTransition(0.4, "rush")
                    ),
                    new State("rush",
                        new Shoot(10, count: 8, projectileIndex: 2, coolDown: 400),
                        new Prioritize(
                            new Charge(2, range: 10, coolDown: 3000),
                            new Follow(0.6, 10, range: 6),
                            new Wander(0.5)
                            )
                        )
                    )
            )
                    .Init("Book of Lore",
                new State(
                    new State(
                        new Prioritize(
                            new Follow(0.4, 10, range: 6),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, predictive: 0.2, projectileIndex: 0, coolDown: new Cooldown(2000, 4000))
                    )
                )
            )
        .Init("Krokanich",
                new State(
                    new RemoveObjectOnDeath("The Depths Wall 3", 90),
                    new HpLessTransition(0.15, "rage"),
                    new ScaleHP(15000),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(6, "basic")
                        ),
                    new State("basic",
                        new Flash(0xFF0000, 2, 2),
                        new TimedTransition(2000, "fight1")
                        )
                    ),
                    new State("fight1",
                        new Wander(0.4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 1000),
                        new Shoot(10, count: 6, shootAngle: 10, predictive: 0.5, projectileIndex: 1, coolDown: 800),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State(
                        new Reproduce("Vicious Croc", 20, 10, 2000),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 2000),
                        new Prioritize(
                            new Follow(0.6, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, count: 8, shootAngle: 10, predictive: 0.5, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, 12, projectileIndex: 2, predictive: 1, coolDown: 2000, coolDownOffset: 800),
                        new TimedTransition(8000, "fight3")
                        ),
                    new State("fight3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 500),
                        new Prioritize(
                            new Follow(0.4, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 2, shootAngle: 8, predictive: 0.5, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 4, shootAngle: 12, predictive: 0.5, projectileIndex: 0, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, count: 6, shootAngle: 18, predictive: 0.5, projectileIndex: 0, coolDown: 2000, coolDownOffset: 4000),
                        new Shoot(10, 3, projectileIndex: 4, shootAngle: 18, coolDown: 1000, coolDownOffset: 600),
                        new TimedTransition(6000, "fight4")
                        ),
                    new State("fight4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 1000),
                        new Prioritize(
                            new Follow(0.8, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, count: 3, shootAngle: 18, predictive: 0.5, projectileIndex: 2, coolDown: 600),
                        new Shoot(10, 6, projectileIndex: 0, coolDown: 3000),

                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000, angleOffset: 40),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000, coolDownOffset: 400, angleOffset: 60),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000, coolDownOffset: 600, angleOffset: 80),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000, coolDownOffset: 800, angleOffset: 100),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000, coolDownOffset: 1000, angleOffset: 120),

                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000, angleOffset: 320),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000, coolDownOffset: 400, angleOffset: 300),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000, coolDownOffset: 600, angleOffset: 280),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000, coolDownOffset: 800, angleOffset: 260),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000, coolDownOffset: 1000, angleOffset: 220),
                        new TimedTransition(8000, "fight5")
                        ),
                    new State("fight5",
                        new Wander(1),
                        new HealSelf(coolDown: 3000, amount: 1000),
                        new Shoot(10, count: 6, projectileIndex: 2, coolDown: 1000, rotateAngle: 20),
                        new Shoot(10, count: 4, shootAngle: 12, projectileIndex: 4, coolDown: 200),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(6000, "fight1")
                            )
                        ),
                    new State("rage",
                        new Flash(0xFF0000, 0.2, 4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 1000),
                        new Prioritize(
                            new Charge(2, range: 10, coolDown: 4000),
                            new Follow(1.5, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, count: 5, shootAngle: 12, predictive: 0.5, projectileIndex: 0, coolDown: 3000),
                        new Shoot(10, 6, projectileIndex: 0, coolDown: 3000),

                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000, angleOffset: 40),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000, coolDownOffset: 400, angleOffset: 60),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000, coolDownOffset: 800, angleOffset: 80),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000, coolDownOffset: 1200, angleOffset: 100),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000, coolDownOffset: 1600, angleOffset: 120),

                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000, angleOffset: 320),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000, coolDownOffset: 400, angleOffset: 300),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000, coolDownOffset: 800, angleOffset: 280),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000, coolDownOffset: 1200, angleOffset: 260),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000, coolDownOffset: 1600, angleOffset: 220)
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.025,
                    new ItemLoot("Greater Potion of Might", 1),
                    new ItemLoot("Greater Potion of Attack", 1),
                    new ItemLoot("Greater Potion of Restoration", 1),
                    new ItemLoot("Draketail Blade", 0.01),
                    new ItemLoot("Crashing Crescendo", 0.01)
                )
            )

         .Init("Xanarich, the Chosen One",
                new State(
                    new HpLessTransition(0.15, "rage"),
                    new ScaleHP(15000),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(6, "basic")
                        ),
                    new State("basic",
                        new Taunt("The ancient depths has been kept secret for ages.."),
                        new TimedTransition(4000, "number")
                        ),
                    new State("number",
                        new Flash(0xFF0000, 2, 2),
                        new Taunt("You dare kill my ancient guardian, kill my pets, now I will take your life."),
                        new TimedTransition(4000, "droporb")
                        ),
                   new State("droporb",
                        new TossObject("Orbiter Richmaster", range: 5, angle: 0, coolDown: 9999),
                        new TimedTransition(4000, "start")
                        ),
                   new State("start",
                        new Follow(1.2, 8, 1),
                        new Shoot(10, count: 12, projectileIndex: 1, coolDown: new Cooldown(2000, 4000)),
                        new Shoot(10, count: 6, projectileIndex: 0, coolDown: 800),
                        new Taunt("My trusty followers... Take care of these fools."),
                        new EntityNotExistsTransition("Orbiter Richmaster", 99, "begin")
                        ),
                   new State("begin",
                        new Flash(0xFF0000, 2, 2),
                        new Taunt("I see, I will have to do this my self."),
                        new TimedTransition(4000, "fight2")
                        )
                    ),
                    new State(
                        new Reproduce("Book of Lore", 20, 8, 1000),
                    new State("fight2",
                        new Shoot(1, count: 4, projectileIndex: 1, coolDown: 200, fixedAngle: 90, rotateAngle: 10, coolDownOffset: 0, shootAngle: 90),
                        new Shoot(1, count: 8, projectileIndex: 1, coolDown: 10000, fixedAngle: 180, coolDownOffset: 2000, shootAngle: 45),
                        new Shoot(1, count: 4, projectileIndex: 1, coolDown: 200, fixedAngle: 180, rotateAngle: -10, coolDownOffset: 0, shootAngle: 90),
                        new Shoot(1, count: 4, projectileIndex: 1, coolDown: 10000, fixedAngle: 90, coolDownOffset: 2000, shootAngle: 22.5),
                        new TimedTransition(2000, "fight2b")
                        ),
                    new State("fight2b",
                        new Shoot(1, count: 4, projectileIndex: 1, coolDown: 200, fixedAngle: 90, rotateAngle: 10, coolDownOffset: 0, shootAngle: 90),
                        new Shoot(1, count: 8, projectileIndex: 1, coolDown: 10000, fixedAngle: 180, coolDownOffset: 2000, shootAngle: 45),
                        new Shoot(1, count: 4, projectileIndex: 1, coolDown: 200, fixedAngle: 180, rotateAngle: -10, coolDownOffset: 0, shootAngle: 90),
                        new Shoot(1, count: 4, projectileIndex: 1, coolDown: 10000, fixedAngle: 90, coolDownOffset: 2000, shootAngle: 22.5),
                        new TimedTransition(2000, "fight3")
                        ),
                    new State("fight3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 1000),
                        new Prioritize(
                            new Follow(1, 8, 1),
                            new Wander(1)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 20, shootAngle: 8, predictive: 0.5, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 6, shootAngle: 16, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(8000, "fight4")
                        ),
                    new State("fight4",
                        new Grenade(6, 200, range: 8, coolDown: 2000, effect: ConditionEffectIndex.Blind, effectDuration: 4000, color: 0x00FF00),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 500),
                        new Prioritize(
                            new Swirl(0.6, radius: 4),
                            new Wander(1)
                            ),
                        new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 0, coolDown: 200),

                        new Shoot(10, count: 6, projectileIndex: 3, shootAngle: 8, coolDown: 1000, fixedAngle: 0),
                        new Shoot(10, count: 6, projectileIndex: 3, shootAngle: 8, coolDown: 1000, fixedAngle: 0),
                        new Shoot(10, count: 6, projectileIndex: 3, shootAngle: 8, coolDown: 1000, fixedAngle: 0),
                        new Shoot(10, count: 6, projectileIndex: 3, shootAngle: 8, coolDown: 1000, fixedAngle: 0),
                        new TimedTransition(8000, "Return")
                        ),
                    new State("Return",
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "fight5")
                        ),
                    new State("fight5",
                        new Wander(0.1),
                        new HealSelf(coolDown: 2000, amount: 10000),
                        new Shoot(10, count: 1, projectileIndex: 4, coolDown: 1),
                        new Shoot(10, count: 6, projectileIndex: 4, coolDown: 200),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(6000, "spiral")
                            ),
                    new State("spiral",
                        new Grenade(2, 200, range: 8, coolDown: 2000, effect: ConditionEffectIndex.Confused, effectDuration: 4000, color: 0x0000FF),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 1000),
                        new TimedTransition(8000, "droporb"),
                        new Shoot(10, count: 10, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 0, coolDown: 2000),
                        new State("Duoforce1",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 0, coolDown: 300),
                            new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 1, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Duoforce2")
                        ),
                        new State("Duoforce2",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Duoforce3")
                        ),
                        new State("Duoforce3",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Duoforce4")
                        ),
                        new State("Duoforce4",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Duoforce21")
                        ),
                         new State("Duoforce21",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 60, coolDown: 300),
                            new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 1, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(75, "Duoforce23")
                        ),
                         new State("Duoforce23",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(75, "Duoforce25")
                        ),
                         new State("Duoforce25",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(75, "Duoforce26")
                        ),
                         new State("Duoforce26",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(75, "Duoforce24")
                        ),
                         new State("Duoforce24",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 75, coolDown: 300),
                            new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 1, fixedAngle: 180, coolDown: 300),
                            new TimedTransition(75, "Duoforce22")
                        ),
                          new State("Duoforce22",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(75, "Duoforce5")
                        ),
                        new State("Duoforce5",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Duoforce6")
                        ),
                        new State("Duoforce6",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Duoforce7")
                        ),
                        new State("Duoforce7",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 15, coolDown: 300),
                            new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 1, fixedAngle: 270, coolDown: 300),
                            new TimedTransition(75, "Duoforce8")
                        ),
                        new State("Duoforce8",
                            new Shoot(0, projectileIndex: 2, count: 2, shootAngle: 180, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Duoforce1")
                            )
                        )
                    ),
                    new State("rage",
                        new Taunt("I will not stand this foolery any longer!"),
                        new Grenade(3, 200, range: 8, coolDown: 2000, effect: ConditionEffectIndex.Paralyzed, effectDuration: 2000, color: 0x00FF00),
                        new Reproduce("Book of Lore", 20, 8, 1000),
                        new Flash(0xFF0000, 0.2, 4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 4000),
                        new Prioritize(
                            new Follow(1.5, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, count: 7, shootAngle: 12, predictive: 0.5, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 6, projectileIndex: 1, coolDown: 2000, coolDownOffset: 800)
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.025,
                    new ItemLoot("Greater Potion of Life", 1),
                    new ItemLoot("Greater Potion of Protection", 1),
                    new ItemLoot("Gold Cache", 1),
                    new ItemLoot("Onrane", 1),
                    new ItemLoot("Chosen Bow", 0.01),
                    new ItemLoot("Quiver of the Chosen", 0.01),
                    new ItemLoot("Chosen Armor", 0.01),
                    new ItemLoot("Shard of Ancient Assault", 0.005)
                )
            )

           .Init("Orbiter Richmaster",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State(
                    new InvisiToss("Janirich", range: 6, angle: 140, coolDown: 9999),
                    new InvisiToss("Ranarich", range: 6, angle: 270, coolDown: 9999),
                    new InvisiToss("Zanarich", range: 6, angle: 0, coolDown: 9999),
                    new TimedTransition(4000, "Start")
                    ),
                new State("Start",
                    new Orbit(0.4, 6, 10, "Xanarich, the Chosen One"),
                    new EntitiesNotExistsTransition(99, "Die", "Janirich", "Ranarich", "Zanarich")
                    ),
                new State("Die",
                    new Suicide()
                    )
                )
            )
                    .Init("Janirich",
                new State(
                    new Shoot(8, count: 12, projectileIndex: 2, coolDown: new Cooldown(2000, 4000)),
                    new Shoot(8, count: 4, shootAngle: 20, projectileIndex: 0, coolDown: 1200),
                    new Shoot(8, count: 7, shootAngle: 14, projectileIndex: 0, predictive: 0.5, coolDown: new Cooldown(2000, 2000), coolDownOffset: 2000),
                    new Shoot(8, count: 2, shootAngle: 8, projectileIndex: 1, coolDown: 2000),
                    new State("OrbitOut",
                        new Orbit(0.6, 6, acquireRange: 15, target: "Orbiter Richmaster", speedVariance: 0.01, orbitClockwise: false),
                        new TimedTransition(8000, "OrbitIn")
                        ),
                    new State("OrbitIn",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Orbit(0.6, 4, acquireRange: 15, target: "Orbiter Richmaster", speedVariance: 0.01, orbitClockwise: false),
                        new TimedTransition(8000, "OrbitOut")
                        )
                    )
            )
                            .Init("Ranarich",
                new State(
                    new Shoot(8, count: 1, projectileIndex: 1, coolDown: 400, fixedAngle: 0),
                    new Shoot(8, count: 1, projectileIndex: 1, coolDown: 400, fixedAngle: 90),
                    new Shoot(8, count: 1, projectileIndex: 1, coolDown: 400, fixedAngle: 180),
                    new Shoot(8, count: 1, projectileIndex: 1, coolDown: 400, fixedAngle: 270),
                    new Shoot(8, count: 5, shootAngle: 14, projectileIndex: 0, coolDown: 1600),
                    new HealEntity(20, "Janirich", healAmount: 500, coolDown: 2000),
                    new HealEntity(20, "Zanarich", healAmount: 500, coolDown: 2000),
                    new HealSelf(coolDown: 10000, amount: 500),
                    new State("OrbitOut",
                        new Orbit(0.6, 6, acquireRange: 15, target: "Orbiter Richmaster", speedVariance: 0.01, orbitClockwise: true),
                        new TimedTransition(8000, "OrbitIn")
                        ),
                    new State("OrbitIn",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Orbit(0.6, 4, acquireRange: 15, target: "Orbiter Richmaster", speedVariance: 0.01, orbitClockwise: true),
                        new TimedTransition(8000, "OrbitOut")
                        )
                    )
            )
                            .Init("Zanarich",
                new State(
                    new Shoot(8, count: 8, shootAngle: 16, projectileIndex: 0, coolDown: new Cooldown(3000, 4000)),
                    new Shoot(8, count: 2, shootAngle: 6, projectileIndex: 1, coolDown: 3000),
                    new Shoot(8, count: 4, shootAngle: 6, projectileIndex: 1, coolDown: 3000, coolDownOffset: 3800),
                    new Grenade(3, 280, range: 8, coolDown: 4000),
                    new State("OrbitOut",
                        new Orbit(0.6, 6, acquireRange: 15, target: "Orbiter Richmaster", speedVariance: 0.01, orbitClockwise: false),
                        new TimedTransition(8000, "OrbitIn")
                        ),
                    new State("OrbitIn",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Orbit(0.6, 4, acquireRange: 15, target: "Orbiter Richmaster", speedVariance: 0.01, orbitClockwise: false),
                        new TimedTransition(8000, "OrbitOut")
                        )
                    )
            );
    }
}