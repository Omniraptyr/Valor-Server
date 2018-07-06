using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Unspeakable = () => Behav()
        .Init("UNP Conjured Swordman",
            new State(
                new State(
                    new Prioritize(
                        new Follow(0.47, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 20, coolDown: 2500),
                    new Shoot(8, 2, shootAngle: 60, predictive: 2, coolDown: 6500),
                    new HpLessTransition(0.11, "explode")
                    ),
                new State("explode",
                    new Shoot(8, 8, projectileIndex: 1, coolDown: 2500),
                    new Suicide()
                    )
                ),
                new ItemLoot("Magic Potion", 0.05),
                new Threshold(0.5,
                    new ItemLoot("Mithril Armor", 0.01)
                    )
            )
         .Init("UNP Shadow Knight",
                  new State(
                    new State("Chase",
                        new Follow(0.6, 8, 1),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 700),
                        new TimedTransition(4000, "Wander")
                        ),
                    new State("Wander",
                     new Wander(0.5),
                      new Shoot(10, count: 1, projectileIndex: 0, coolDown: 350),
                     new TimedTransition(3000, "Chase")

                    )
                 )
              )
         .Init("UNP Sorcerer of the Unspeakable",
                  new State(
                    new State("Chase",
                        new Wander(0.6),
                        new Shoot(10, count: 6, shootAngle: 20, projectileIndex: 0, coolDown: 1200),
                        new TimedTransition(6000, "Hurts")
                        ),
                    new State("Hurts",
                      new Taunt(1.00, "Take this!", "The wrath of the Dark Knight is revealed!"),
                      new StayBack(0.2, 4),
                      new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1500),
                     new TimedTransition(3000, "Chase")

                    )
                 )
              )
        .Init("UNP Corrupted Soul",
                  new State(
                    new State("wander",
                         new Prioritize(
                             new StayCloseToSpawn(0.7, 3),
                             new Wander(0.06)
                            ),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: new Cooldown(1750, 1000))
                        )
                 )
              )
        .Init("UNP Something Odd",
                  new State(
                    new State("chase",
                         new Prioritize(
                             new Follow(1, 8, 1),
                             new Wander(0.1)
                            ),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, coolDown: 3000)
                        )
                     )
                  )
        .Init("UNP Robed Knight",
                  new State(
                    new State("chase",
                         new Prioritize(
                             new Orbit(0.3, 3, 20, "Lord of the Lost Lands"),
                             new Follow(0.6, 8, 1)
                            ),
                        new Shoot(10, count: 4, projectileIndex: 0, coolDown: 2000)
                        )
                        )
                  )
        .Init("UNP Stone Phantom Knight",
                  new State(
                    new State("Fight",
                        new Wander(0.14),
                        new Shoot(10, count: 4, shootAngle: 32, projectileIndex: 0, coolDown: 1500),
                        new TimedTransition(6000, "Charge")
                        ),
                    new State("Charge",
                        new Flash(0xFF0000, 1, 1),
                        new Shoot(10, count: 10, projectileIndex: 1, coolDown: 1000),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(1000, "Chase")
                        ),
                    new State("Chase",
                      new Follow(1.25, 8, 1),
                      new Shoot(10, count: 5, shootAngle: 50, projectileIndex: 2, coolDown: 750),
                     new TimedTransition(3000, "Fight")
                    )
                 )
              )

        //1st Boss Servant

         .Init("UNP Servant of the Dark Knight",
                new State(
                    new DropPortalOnDeath("Domain of the Dark Knight Portal", 100),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(8, "start")
                        ),
                    new State("start",
                        new Taunt(1.00, "I won't let you go any further! I shall guard the Dark Knight with my life!"),
                        new TimedTransition(1000, "fight1")
                        ),
                    new State("fight1",
                        new Wander(0.25),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 6, shootAngle: 9, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, coolDown: 500),
                        new TimedTransition(6500, "fight2")
                        ),
                    new State("fight2",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Prioritize(
                           new StayAbove(1, 200),
                           new Follow(1, range: 7),
                           new Wander(0.4)
                        ),
                        new Grenade(3, 80, range: 6, coolDown: 3000),
                        new Shoot(10, count: 7, shootAngle: 9, projectileIndex: 1, coolDown: 4500),
                        new Shoot(10, count: 5, shootAngle: 18, projectileIndex: 2, coolDown: 1250),
                        new TimedTransition(6500, "fight3")
                        ),
                    new State("fight3",
                        new Wander(0.2),
                        new Shoot(10, count: 12, shootAngle: 26, projectileIndex: 3, coolDown: 400),
                        new Shoot(10, count: 3, shootAngle: 14, projectileIndex: 0, coolDown: 1500),
                        new TimedTransition(6500, "returnandTaunt")
                        ),
                    new State("returnandTaunt",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "Aid me!", "You can't kill me! I refuse to die!", "The sorcerers will destroy you!"),
                        new ReturnToSpawn(speed: 0.5),
                        new Flash(0xFF0000, 1, 1),
                        new TimedTransition(6550, "spawn")
                        ),
                   new State("spawn",
                        new TossObject("UNP Sorcerer of the Unspeakable", 4, 0, coolDown: 9999999),
                        new TossObject("UNP Sorcerer of the Unspeakable", 4, 90, coolDown: 9999999),
                        new TossObject("UNP Sorcerer of the Unspeakable", 4, 180, coolDown: 9999999),
                        new TossObject("UNP Sorcerer of the Unspeakable", 4, 270, coolDown: 9999999),
                        new TimedTransition(2000, "fight1")
                        )
                    ),
                                new MostDamagers(3,
                    LootTemplates.SFLow()
                    ),
                new Threshold(0.025,
                    new ItemLoot("Potion of Defense", 1.0),
                    new ItemLoot("Potion of Speed", 1.0),
                    new TierLoot(11, ItemType.Weapon, 0.1),
                    new TierLoot(5, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Ghilact Dagger", 0.04),
                    new ItemLoot("Jacket of True Darkness", 0.01)
                )
            )

         .Init("UNP The Dark Knight",
                new State(
                    new RealmPortalDrop(),
                    new ConditionalEffect(ConditionEffectIndex.ArmorBreakImmune),
                    new ConditionalEffect(ConditionEffectIndex.StunImmune),
                    new ConditionalEffect(ConditionEffectIndex.ParalyzeImmune),
                    new ConditionalEffect(ConditionEffectIndex.CurseImmune),
                    new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                    new ConditionalEffect(ConditionEffectIndex.DazedImmune),
                    new ConditionalEffect(ConditionEffectIndex.SlowedImmune),
                    new TransformOnDeath("Dark Knight Test Chest", 1, 1, 1),
                    new HpLessTransition(0.12, "deathbegins"),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(7, "start")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("start",
                        new Taunt(1.00, "I understand now why I was banished from my kingdom..."),
                        new TimedTransition(3000, "talk1")
                        ),
                    new State("talk1",
                        new Taunt(1.00, "I failed my master...I failed my people...but now.."),
                        new TimedTransition(3000, "talk2")
                        ),
                    new State("talk2",
                        new Taunt(1.00, "I will fail them no more...draw your weapon..."),
                        new TimedTransition(3000, "talk3")
                        ),
                    new State("talk3",
                        new Taunt(1.00, "and PREPARE TO DIE!"),
                        new TimedTransition(3000, "GetReady")
                        )
                        ),
                    new State("GetReady",
                        new Flash(0xFFF240, 1, 1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2500, "fight2")
                        ),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 4, shootAngle: 4, projectileIndex: 0, coolDown: 1),
                        new Shoot(10, count: 10, projectileIndex: 1, coolDown: 1750),
                        new TimedTransition(5000, "fight3")
                        ),
                    new State("fight3",
                            new Prioritize(
                                 new Follow(0.4, 8, 1),
                                 new Wander(0.5)
                                ),
                    new Taunt(0.50, "You shouldn't have come here! Now you will die a painful death."),
                        new Shoot(10, count: 20, shootAngle: 6, projectileIndex: 5, coolDown: 3400),
                        new Shoot(10, count: 5, shootAngle: 28, projectileIndex: 2, coolDown: 2600),
                        new TimedTransition(4750, "fight4")
                        ),
                    new State("fight4",
                            new Prioritize(
                                 new StayCloseToSpawn(0.7, 2),
                                 new Wander(0.5)
                                ),
                        new Shoot(10, count: 8, shootAngle: 15, projectileIndex: 4, coolDown: 1750, fixedAngle: 135),
                        new Shoot(10, count: 8, shootAngle: 15, projectileIndex: 4, coolDown: 1750, fixedAngle: 45),
                        new Shoot(10, count: 8, shootAngle: 15, projectileIndex: 4, coolDown: 1750, fixedAngle: 225),
                        new Shoot(10, count: 8, shootAngle: 15, projectileIndex: 4, coolDown: 1750, fixedAngle: 315),
                        new Shoot(10, count: 3, shootAngle: 30, projectileIndex: 3, coolDown: 3400),
                        new TimedTransition(4750, "fight5")
                        ),
                     new State("fight5",
                          new Prioritize(
                            new Follow(0.20, 8, 1),
                            new Wander(0.6)
                            ),
                        new Taunt(1.00, "Hahahahah! It is all over!"),
                        new TimedTransition(4500, "heal"),
                        new State("1",
                            new Shoot(10, count: 6, projectileIndex: 3, coolDown: 3400),
                            new TimedTransition(300, "2")
                        ),
                        new State("2",
                            new Shoot(10, count: 12, projectileIndex: 3, coolDown: 3400),
                            new TimedTransition(300, "3")
                        ),
                        new State("3",
                            new Shoot(10, count: 24, projectileIndex: 3, coolDown: 3400),
                            new TimedTransition(300, "4")
                        ),
                         new State("4",
                            new Shoot(10, count: 48, projectileIndex: 5, coolDown: 3400),
                            new Shoot(10, count: 24, projectileIndex: 0, coolDown: 3400),
                            new Shoot(10, count: 32, projectileIndex: 1, coolDown: 3400),
                            new TimedTransition(300, "1")
                        )
                    ),
                     new State("heal",
                        new ReturnToSpawn(speed: 0.5),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Flash(0xFFFFFF, 1, 1),
                        new HealSelf(coolDown: 2000, amount: 6500),
                        new TimedTransition(8000, "spawn")
                        ),
                   new State("spawn",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TossObject("UNP Stone Phantom Knight", 6, 0, coolDown: 9999999),
                        new TossObject("UNP Stone Phantom Knight", 6, 90, coolDown: 9999999),
                        new TossObject("UNP Stone Phantom Knight", 6, 180, coolDown: 9999999),
                        new TossObject("UNP Stone Phantom Knight", 6, 270, coolDown: 9999999),
                        new TimedTransition(2000, "fight6")
                    ),
                   new State("fight6",
                        new Swirl(0.4, 4, 8),
                        new Shoot(10, count: 8, shootAngle: 24, projectileIndex: 4, coolDown: 2000),
                        new Shoot(10, count: 6, shootAngle: 16, predictive: 1.5, projectileIndex: 2, coolDown: 1250),
                        new Shoot(10, count: 8, shootAngle: 16, projectileIndex: 0, coolDown: 675),
                        new Grenade(4.5, 221, 6, coolDown: 1000),
                        new TimedTransition(5750, "fight7")
                       ),
                   new State("fight7",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new StayBack(0.2, 2),
                        new Shoot(10, count: 30, shootAngle: 28, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 15, shootAngle: 24, projectileIndex: 3, coolDown: 1000),
                        new TimedTransition(3750, "rush")
                       ),
                   new State("rush",
                        new Taunt(1.00, "YOU CAN'T STOP FATE!", "YOUR DESTINY IS DEATH!", "RUN, YOU PATHETIC PHEASANTS!"),
                        new Prioritize(
                        new Follow(1.50, 8, 1),
                        new Wander(0.85)
                            ),
                        new Shoot(10, count: 15, shootAngle: 20, projectileIndex: 0, coolDown: 1350),
                        new Shoot(10, count: 17, shootAngle: 24, predictive: 1, projectileIndex: 3, coolDown: 1000),
                        new Shoot(10, count: 14, shootAngle: 24, predictive: 2, projectileIndex: 4, coolDown: 2000),
                        new Shoot(10, count: 5, projectileIndex: 2, coolDown: 900),
                        new TimedTransition(6750, "rush2")
                       ),
                    new State("rush2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "lol rip u guys", "YOUR END IS NOW"),
                        new Prioritize(
                        new Follow(1.72, 8, 1),
                        new Wander(0.75)
                            ),
                        new Shoot(10, count: 30, shootAngle: 1, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(8000, "rush3")
                       ),
                   new State("rush3",
                        new Taunt(1.00, "SORCERERS! GET RID OF THEM!", "I will tolerate no more! "),
                        new Wander(0.65),
                        new Shoot(10, count: 7, shootAngle: 1, projectileIndex: 1, coolDown: 500),
                        new TossObject("UNP Sorcerer of the Unspeakable", 1, 0, coolDown: 9999999),
                        new TimedTransition(2000, "fight8")
                       ),
                  new State("fight8",
                      new Flash(0x00FF00, 1, 8),
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                        new TimedTransition(12750, "fight2")
                       ),
                   new State("deathbegins",
                       new Taunt(1.00, "I CANNOT BELIEVE I HAVE FAILED ONCE AGAIN! THE FORGOTTEN WILL AVENGE ME!", "NO! NO! NOO! WHY CAN'T I EVER BE HONORED!", "NEXT TIME IT'LL BE OVER!", "I won't let this happen again, my king.."),
                        new ReturnToSpawn(speed: 0.5),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Flash(0x0000FF, 1, 6),
                        new TimedTransition(8000, "rip")
                        ),
                   new State("rip",
                       new Shoot(10, count: 10, projectileIndex: 1, coolDown: 9999),
                       new Suicide()
                    )
                 )
            )

         .Init("Dark Knight Test Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                                new MostDamagers(3,
                    LootTemplates.SFLow()
                    ),
                new Threshold(0.11,
				new ItemLoot("Potion of Luck", 1),
                new ItemLoot("Greater Potion of Mana", 1),
                new ItemLoot("Greater Potion of Defense", 1),
                new ItemLoot("Greater Potion of Attack", 0.6),
                new ItemLoot("Greater Potion of Speed", 0.5),
                new ItemLoot("Greater Potion of Wisdom", 0.5),
                new ItemLoot("Greater Potion of Dexterity", 0.5),
                new ItemLoot("Greater Potion of Vitality", 0.5),
		    	new ItemLoot("Night Dice", 0.02),
                new ItemLoot("Jacket of True Darkness", 0.025),
                new ItemLoot("Broadsword of Bloodshed", 0.02),
                new ItemLoot("Evil Shield of the Dark Knight", 0.02),
                new ItemLoot("Amulet of the Dark Knight", 0.02),
                new ItemLoot("Chestguard of the Underworld", 0.02),
                    new TierLoot(10, ItemType.Weapon, 0.07),
                    new TierLoot(11, ItemType.Weapon, 0.06),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new TierLoot(5, ItemType.Ability, 0.07),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.07),
                    new TierLoot(12, ItemType.Armor, 0.06),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(5, ItemType.Ring, 0.06)
                )
            );
    }
}