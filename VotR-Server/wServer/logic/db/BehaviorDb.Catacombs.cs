using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Catacombs = () => Behav()
        .Init("Grey Torch Wall",
                new State(
                    new State("Idle",
                        new EntitiesNotExistsTransition(9999, "Rip", "Arena Spider")
                    ),
                    new State("Rip",
                        new Decay(500)
                    )
               )
            )
         .Init("Tooky Catacombs Master",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new RemoveObjectOnDeath("Grey Torch Wall", 99),
                    new State("Idle",
                        new EntitiesNotExistsTransition(999, "Rip", "Arena Spider")
                    ),
                    new State("Rip",
                        new Suicide()
                    )
                )
            )
        .Init("Tooky Test TaskMastah",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new PlayerWithinTransition(24, "active")
                    ),
                new State("active",
                    new Taunt(true, "It's been a long time since I have had a visitor..I guess you will be the next soul to be devoured? Stay here. I have something for you."),
                    new TimedTransition(12500, "spawn"),
                    new NoPlayerWithinTransition(24, "idle")
                    ),
                new State("spawn",
                    new Spawn("Corrupted Flames of Fate", 1, 1, coolDown: 99999),
                    new Suicide()
                    )
                )
            )
        .Init("Corrupted Flames of Fate",
                new State(
                    new State("default",
                        new ChangeSize(35, 200),
                        new PlayerWithinTransition(8, "basic")
                        ),
                    new State("basic",
                        new Taunt(1.00, "Oh, what a joy! A delicious snack!"),
                        new Prioritize(
                            new Follow(0.45, 8, 1),
                            new Wander(0.2)
                            ),
                        new Shoot(10, count: 5, shootAngle: 22, projectileIndex: 3, coolDown: 3750),
                        new Shoot(10, count: 3, shootAngle: 22, projectileIndex: 3, predictive: 2, coolDown: 2500, coolDownOffset: 1200),
                        new TimedTransition(6750, "trailofdeath")
                        ),
                    new State("trailofdeath",
                        new HealSelf(coolDown: 1300, amount: 500),
                         new Prioritize(
                             new StayCloseToSpawn(1.2, 6),
                             new Wander(0.4)
                             ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 1, shootAngle: 8, projectileIndex: 1, coolDown: 1),
                        new Shoot(10, count: 1, shootAngle: 8, projectileIndex: 1, coolDown: 1, coolDownOffset: 10),
                        new TimedTransition(5250, "blaster")
                        ),
                    new State("blaster",
                        new Taunt(1.00, "Your life belongs to me now."),
                        new Swirl(0.5, 6, 8),
                        new Shoot(10, count: 7, shootAngle: 32, projectileIndex: 0, coolDown: 6300),
                        new TimedTransition(5750, "ringblam")
                        ),
                    new State("ringblam",
                        new Wander(0.4),
                        new Shoot(10, count: 6, shootAngle: 22, projectileIndex: 3, coolDown: 3750),
                        new Shoot(10, count: 10, projectileIndex: 2, coolDown: 4000),
                        new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 0, coolDown: 6000),
                        new TimedTransition(7250, "ringblam2")
                        ),
                    new State("ringblam2",
                        new Taunt(1.00, "You can't survive forever in this scorching heat."),
                        new HealSelf(coolDown: 500, amount: 1500),
                        new Follow(0.5, 8, 1),
                        new Shoot(10, count: 24, projectileIndex: 1, coolDown: 2000),
                        new Grenade(5, 70, range: 4, coolDown: 3000),
                        new TimedTransition(6000, "basic")
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor2Perc()
                    ),
                new Threshold(0.025,
                    new ItemLoot("Potion of Defense", 1.0),
                    new ItemLoot("Potion of Dexterity", 1.0),
                    new ItemLoot("Potion of Might", 1.0),
                    new TierLoot(10, ItemType.Weapon, 0.07),
                    new TierLoot(11, ItemType.Weapon, 0.06),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new TierLoot(5, ItemType.Ability, 0.07),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.07),
                    new TierLoot(12, ItemType.Armor, 0.06),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(5, ItemType.Ring, 0.06),
                    new ItemLoot("Forsaken Shield", 0.004),
                    new ItemLoot("Sword of Dark Necromancy", 0.005),
                    new ItemLoot("Ring of Undeadly Conjury", 0.002),
                    new ItemLoot("Gold Cache", 0.8)

                )
            )
        .Init("Skeleton of War",
                new State(
                    new Prioritize(
                        new Follow(0.4, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, count: 1, projectileIndex: 0, coolDown: new Cooldown(3000, 1000)),
                    new Shoot(8, count: 1, projectileIndex: 1, coolDown: 9750)
                    ),
                new TierLoot(4, ItemType.Weapon, 0.03)
            )
        .Init("Skeleton of Death",
                new State(
                    new Prioritize(
                        new Follow(0.3, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, count: 2, shootAngle: 50, projectileIndex: 0, coolDown: new Cooldown(7500, 1250))
                    ),
                new TierLoot(4, ItemType.Armor, 0.03)
            )
        .Init("Demon of the Catacombs",
                new State(
                    new Wander(1),
                    new Shoot(8, count: 2, shootAngle: 26, projectileIndex: 0, coolDown: new Cooldown(4500, 1250)),
                    new Shoot(8, count: 1, projectileIndex: 1, coolDown: new Cooldown(2000, 1500))
                    )
            )
        .Init("Enlargened Death Slug",
                new State(
                    new Wander(0.45),
                    new Shoot(8, count: 1, projectileIndex: 0, coolDown: new Cooldown(2750, 1000))
                    )
            )
         .Init("Living Ectoplasm",
                new State(
                    new StayCloseToSpawn(0.3, 5),
                    new Shoot(8, count: 3, shootAngle: 4, projectileIndex: 0, coolDown: new Cooldown(5500, 1750))
                    )
            )
        .Init("Catacombs Turret 2",
                                new State(
                                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                                        new Shoot(6, count: 1, coolDown: 100)
                                                )
              )
        .Init("Catacombs Turret 1",
                                new State(
                                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                                        new Shoot(10, count: 1, coolDown: new Cooldown(7500, 1250))
                                                )
              )
        .Init("Wizard of Evil Souls",
             new State(
                    new State("RingofBlast",
                    new Wander(0.2),
                    new Shoot(8, count: 5, projectileIndex: 0, coolDown: new Cooldown(4750, 2000)),
                    new TimedTransition(6250, "Follow")
                        ),
                    new State("Follow",
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(1, range: 7),
                        new Wander(0.4)
                        ),
                     new Shoot(10, count: 3, shootAngle: 16, projectileIndex: 1, coolDown: 3500),
                     new Shoot(10, count: 4, shootAngle: 12, predictive: 2.5, projectileIndex: 0, coolDown: 6000),
                     new TimedTransition(6750, "Flash")
                    ),
                    new State("Flash",
                    new Taunt("I can already feel the darkest souls go through me!", "I will feast on your corpse...", "You can't survive here for too long!"),
                    new Flash(0x00FF00, 4, 4),
                     new TimedTransition(3750, "Rush")
                    ),
                   new State("Rush",
                       new Taunt(0.50, "Hahaha! Run mortal!"),
                       new Prioritize(
                            new Follow(1, range: 7),
                            new Wander(1)
                            ),
                     new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1),
                     new TimedTransition(5750, "RingofBlast")

                    )
                 )
              )
         .Init("Guardian of the Catacombs",
             new State(
                    new State("WalkTowards",
                    new Prioritize(
                        new Follow(0.5, 8, 1),
                        new Wander(0.45)
                        ),
                    new Shoot(8, count: 1, projectileIndex: 0, coolDown: new Cooldown(3250, 1000)),
                    new TimedTransition(7250, "Orbit")
                        ),
                    new State("Orbit",
                    new Flash(0x000000, 4, 4),
                    new Orbit(0.8, 3, 8),
                    new Shoot(10, count: 3, shootAngle: 16, projectileIndex: 1, coolDown: 1750),
                    new TimedTransition(5000, "WalkTowards2")
                    ),
                   new State("WalkTowards2",
                    new Prioritize(
                        new Follow(0.2, 8, 1),
                        new Wander(0.45)
                        ),
                    new Shoot(8, count: 5, shootAngle: 16, projectileIndex: 2, coolDown: new Cooldown(4500, 1000)),
                    new TimedTransition(6050, "Heal")
                        ),
                   new State("Heal",
                       new Flash(0x000000, 4, 4),
                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                      new HealSelf(coolDown: 1000, amount: 75),
                     new TimedTransition(5000, "WalkTowards")

                    )
                 )
              )

        .Init("Grotesque of Rock",
             new State(
                 new HpLessTransition(0.13, "BlowUp"),
                    new State("PinkBoltin",
                    new Prioritize(
                        new Follow(0.2, 8, 1),
                        new Wander(0.6)
                        ),
                    new Shoot(8, count: 3, shootAngle: 26, projectileIndex: 0, coolDown: new Cooldown(3000, 1000)),
                    new TimedTransition(8000, "DontSitOnMe")
                        ),
                    new State("DontSitOnMe",
                    new Wander(1),
                    new Flash(0x000000, 4, 4),
                    new Shoot(10, count: 18, projectileIndex: 1, coolDown: 2000),
                    new TimedTransition(6000, "PinkBoltin")
                    ),
                   new State("BlowUp",
                       new Shoot(8, count: 4, projectileIndex: 2, coolDown: 3000),
                       new Suicide()
                    )
                 )
              )
        .Init("Treasure Statue of the Catacombs",
                                new State(
                                        new State("Waiting",
                                                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                                new PlayerWithinTransition(10, "Idle")
                                        ),
                                        new State("Idle",
                                                new Taunt(0.99, "Gain my wonderful treasures and destroy me!")
                                        )
                                        ),
                                new Threshold(0.01,
                                new ItemLoot("Onrane", 0.4),
                                new ItemLoot("Potion of Mana", 0.3),
                                new ItemLoot("Potion of Vitality", 0.3),
                                new ItemLoot("Potion of Might", 0.3),
                                new ItemLoot("Gold Cache", 0.4),
                                new TierLoot(10, ItemType.Armor, .08),
                                new TierLoot(10, ItemType.Weapon, .08),
                                new TierLoot(11, ItemType.Armor, .06),
                                new TierLoot(11, ItemType.Weapon, .06),
                                new TierLoot(4, ItemType.Ring, .08)
                                                )
                        )
        .Init("Ugajuajn",
             new State(
                 new State("Idle",
                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                      new PlayerWithinTransition(6, "Follow")
                              ),
                    new State("Follow",
                    new Prioritize(
                        new Follow(0.35, 8, 1),
                        new Wander(0.6)
                        ),
                    new Shoot(8, count: 6, projectileIndex: 0, coolDown: 4000),
                    new Shoot(8, count: 8, projectileIndex: 1, coolDown: 4000, coolDownOffset: 1250),
                    new TimedTransition(11000, "Ecto")
                        ),
                    new State("Ecto",
                    new Spawn("Living Ectoplasm", 1, 1, coolDown: 5000),
                    new TimedTransition(2000, "Follow")
                    )
                 )
              )
        .Init("Doomages",
                new State(
                    new State("default",
                        new PlayerWithinTransition(8, "taunt1"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                        ),
                    new State("taunt1",
                        new Taunt(1.00, "Munching on your bones will have a nice crunch to it!"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(4500, "Blargh1")
                        ),
                    new State("Blargh1",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 7, shootAngle: 18, projectileIndex: 1, coolDown: 2750),
                        new Shoot(10, count: 5, projectileIndex: 3, coolDown: 4000, coolDownOffset: 1000),
                        new TimedTransition(5250, "Blargh2")
                        ),
                     new State("Blargh2",
                        new Wander(0.4),
                        new Shoot(10, count: 5, shootAngle: 14, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(5000, "Warn1")
                        ),
                     new State("Warn1",
                        new Flash(0xFF0000, 3, 3),
                        new TimedTransition(3000, "Blargh3")
                        ),
                   new State("Blargh3",
                        new Shoot(10, count: 16, projectileIndex: 0, coolDown: 850),
                        new TimedTransition(4750, "Blargh4")
                        ),
                   new State("Blargh4",
                        new Shoot(10, count: 8, shootAngle: 6, projectileIndex: 0, coolDown: 2850),
                        new TimedTransition(3000, "Blargh1")
                        )
                    ),
                                new MostDamagers(3,
                    LootTemplates.Sor4Perc()
                    ),
                new Threshold(0.025,
                    new ItemLoot("Onrane", 0.3),
                    new ItemLoot("Potion of Might", 1.0),
                    new ItemLoot("Potion of Life", 1.0),
                    new ItemLoot("Potion of Wisdom", 1.0),
                    new TierLoot(9, ItemType.Weapon, 0.07),
                    new TierLoot(10, ItemType.Weapon, 0.06),
                    new TierLoot(11, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ability, 0.07),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(9, ItemType.Armor, 0.07),
                    new TierLoot(10, ItemType.Armor, 0.06),
                    new TierLoot(11, ItemType.Armor, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.06),
                    new ItemLoot("Sword of Dark Necromancy", 0.005),
                    new ItemLoot("Olden Necromancy Cloth", 0.002)

                )
            )

        //TRIDORNO IS BACK HAHAHAHAHHA LETS GOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        .Init("Tridorno",
                new State(
                    new HpLessTransition(0.11, "TheLightDeath"),
                    new State("default",
                        new PlayerWithinTransition(8, "taunt1"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("taunt1",
                        new Taunt(1.00, "You are finally here..."),
                        new TimedTransition(4500, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt(1.00, "I heard you move throughout the Catacombs. Was it really worth it though?"),
                        new TimedTransition(4500, "taunt3")
                        ),
                    new State("taunt3",
                        new Taunt(1.00, "It isn't very easy getting here..I've guarded this place for centuries. Every intruder has only been an addition to my pile of bones."),
                        new TimedTransition(4500, "taunt4")
                        ),
                    new State("taunt4",
                        new Taunt(1.00, "I can already see you being added to my collection.."),
                        new Flash(0xF0F0F0, 3, 3),
                        new TimedTransition(5500, "WanderandShoot")
                        )
                        ),
                    new State("WanderandShoot",
                        new Wander(0.75),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 6, shootAngle: 24, projectileIndex: 5, coolDown: 4750),
                        new Shoot(10, count: 4, shootAngle: 24, predictive: 2, projectileIndex: 4, coolDown: 3500),
                        new Shoot(10, count: 14, predictive: 2, projectileIndex: 4, coolDown: 3500),
                        new TimedTransition(16500, "RunandGun")
                        ),
                     new State("RunandGun",
                         new Prioritize(
                            new Follow(0.62, 8, 1),
                            new Wander(0.5)
                            ),
                        new HealSelf(coolDown: 1500, amount: 100),
                        new Shoot(10, count: 7, shootAngle: 38, projectileIndex: 0, coolDown: 5000),
                        new Shoot(10, count: 3, shootAngle: 24, projectileIndex: 3, coolDown: 3500),
                        new Grenade(4, 175, 7, coolDown: 3250),
                        new TimedTransition(15850, "LightningFam")
                        ),

                     new State("LightningFam",
                         new HealSelf(coolDown: 99999, amount: 62500),
                        new Sequence(
                            new Timed(3000,
                                new Prioritize(
                                    new BackAndForth(0.6, 4)
                                    )),
                            new Timed(4000,
                                new Prioritize(
                                    new Follow(0.4, 8, 1),
                                    new Wander(0.8)
                                    )),
                            new Timed(2655,
                                new Prioritize(
                                    new StayBack(0.3, 3),
                                    new Wander(0.5)
                                    )
                                )
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8.4, count: 2, shootAngle: 20, fixedAngle: 0, projectileIndex: 1, coolDown: 1200),
                        new Shoot(8.4, count: 2, shootAngle: 20, fixedAngle: 90, projectileIndex: 1, coolDown: 1200),
                        new Shoot(8.4, count: 2, shootAngle: 20, fixedAngle: 180, projectileIndex: 1, coolDown: 1200),
                        new Shoot(8.4, count: 2, shootAngle: 20, fixedAngle: 270, projectileIndex: 1, coolDown: 1200),
                        new Shoot(10, count: 3, shootAngle: 14, projectileIndex: 4, coolDown: 5000),
                        new DamageTakenTransition(45750, "ReturnToSpawn")
                        ),
                     new State("ReturnToSpawn",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x000000, 3, 3),
                        new ReturnToSpawn(speed: 0.75),
                        new TimedTransition(5500, "taunt11")
                        ),
                     new State("taunt11",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt(1.00, "Your struggle to live is amusing.", "Having a hard time I see?"),
                        new TimedTransition(4700, "spodermen")
                        ),
                     new State("spodermen",
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Arena Spider", 8, 0, coolDown: 9999999),
                        new TossObject("Arena Spider", 10, 45, coolDown: 9999999),
                        new TossObject("Arena Spider", 7, 90, coolDown: 9999999),
                        new TossObject("Arena Spider", 5, 135, coolDown: 9999999),
                        new TossObject("Arena Spider", 12, 180, coolDown: 9999999),
                        new TossObject("Arena Spider", 8, 225, coolDown: 9999999),
                        new TossObject("Arena Spider", 6, 270, coolDown: 9999999),
                        new TossObject("Arena Spider", 8, 315, coolDown: 9999999),
                        new TossObject("Arena Spider", 10, 260, coolDown: 9999999),
                        new TossObject("Arena Spider", 13, 160, coolDown: 9999999),
                        new TossObject("Arena Spider", 12, 70, coolDown: 9999999),
                        new TossObject("Arena Spider", 12, 30, coolDown: 9999999),
                        new TimedTransition(3000, "CheckSpoders")
                        ),
                   new State("CheckSpoders",
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Prioritize(
                            new Follow(0.2, 8, 1),
                            new Wander(0.2)
                            ),
                        new HealSelf(coolDown: 2000, amount: 250),
                        new Shoot(10, count: 6, projectileIndex: 5, coolDown: 5000),
                        new TossObject("Catacombs Turret 1", 8, 0, coolDown: 9999999),
                        new TossObject("Catacombs Turret 1", 8, 45, coolDown: 9999999),
                        new TossObject("Catacombs Turret 1", 8, 90, coolDown: 9999999),
                        new TossObject("Catacombs Turret 1", 8, 135, coolDown: 9999999),
                        new TossObject("Catacombs Turret 1", 8, 180, coolDown: 9999999),
                        new TossObject("Catacombs Turret 1", 8, 225, coolDown: 9999999),
                        new TossObject("Catacombs Turret 1", 8, 270, coolDown: 9999999),
                        new TossObject("Catacombs Turret 1", 8, 315, coolDown: 9999999),
                        new EntitiesNotExistsTransition(9999, "FireFam", "Arena Spider")
                        ),
                   new State("FireFam",
                        new Sequence(
                            new Timed(3000,
                                new Prioritize(
                                    new BackAndForth(0.6, 4)
                                    )),
                            new Timed(4000,
                                new Prioritize(
                                    new Follow(0.4, 8, 1),
                                    new Wander(0.8)
                                    )),
                            new Timed(2655,
                                new Prioritize(
                                    new StayBack(0.3, 3),
                                    new Wander(0.5)
                                    )
                                )
                            ),
                        new Taunt("I MUST STOP YOU NOW!", "You are over!"),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 7000, coolDownOffset: 0),
                         new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 7000, coolDownOffset: 100),
                         new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 7000, coolDownOffset: 400),
                         new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 7000, coolDownOffset: 800),
                         new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 7000, coolDownOffset: 1200),
                         new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 7000, coolDownOffset: 1600),
                         new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 7000, coolDownOffset: 2000),
                         new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 2, coolDown: 7000, coolDownOffset: 2400),

                          new Shoot(10, count: 10, shootAngle: 18, projectileIndex: 3, coolDown: 5000, predictive: 3),

                          new Shoot(10, count: 5, projectileIndex: 1, coolDown: 6000),
                          new Shoot(10, count: 1, projectileIndex: 0, coolDown: 3750)

                        ),
                   new State("TheLightDeath",
                        new Taunt("THE LIGHT SHINES ON ME...I CAN NO LONGER FEEL DARKNESS!"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Flash(0xFFFFFF, 3, 3),
                        new ReturnToSpawn(speed: 0.75),
                        new TimedTransition(6000, "rip")
                        ),
                   new State("rip",
                        new Suicide()
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor4Perc()
                    ),
                new Threshold(0.025,
                    new ItemLoot("Gold Cache", 1.0),
                    new ItemLoot("Onrane", 1.0),
                    new ItemLoot("Potion of Might", 1.0),
                    new ItemLoot("Potion of Life", 0.8),
                    new ItemLoot("Potion of Mana", 0.8),
                    new ItemLoot("Potion of Dexterity", 0.6),
                    new ItemLoot("Potion of Vitality", 0.6),
                    new ItemLoot("Potion of Defense", 0.6),
                    new ItemLoot("Potion of Speed", 0.4),
                    new TierLoot(10, ItemType.Weapon, 0.092),
                    new TierLoot(11, ItemType.Weapon, 0.085),
                    new TierLoot(12, ItemType.Weapon, 0.082),
                    new TierLoot(5, ItemType.Ability, 0.082),
                    new TierLoot(6, ItemType.Ability, 0.072),
                    new TierLoot(11, ItemType.Armor, 0.092),
                    new TierLoot(12, ItemType.Armor, 0.085),
                    new TierLoot(13, ItemType.Armor, 0.072),
                    new TierLoot(6, ItemType.Ring, 0.075),
                    new ItemLoot("Forsaken Shield", 0.05),
                    new ItemLoot("Sword of Dark Necromancy", 0.025),
                    new ItemLoot("Staff of the Withering", 0.002),
                    new ItemLoot("Gold Cache", 0.8),
                    new ItemLoot("Daring Windrage Robe", 0.002),
                    new ItemLoot("Necromantic Charm", 0.002),
                    new ItemLoot("Skull of Glowing Plagues", 0.002),
                    new ItemLoot("Ring of Pestilence", 0.002)

                )
            )
        ;
    }
}