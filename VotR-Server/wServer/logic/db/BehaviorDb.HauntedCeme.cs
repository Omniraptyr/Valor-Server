using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ HauntedCeme = () => Behav()
        //Arena 1
            .Init("Arena Skeleton",
                new State(
                    new Prioritize(
                        new Follow(0.45, 8, 1),
                        new Wander(0.35)
                        ),
                     new Shoot(10, count: 1, projectileIndex: 0, predictive: 0.5, coolDown: 1200),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 900)
                    ),
                new ItemLoot("Spirit Salve Tome", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Greater Dexterity", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
                    .Init("Troll 1",
                new State(
                     new Follow(0.4, 8, 1),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 850)
                    ),
                new ItemLoot("Tome of Renewing", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Greater Defense", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
                                    .Init("Troll 2",
             new State(
                new Follow(0.3, 8, 1),
                new Shoot(10, count: 1, projectileIndex: 0, coolDown: 850),
                new Grenade(3.5, 80, 8, coolDown: 2750)
            ),
                new ItemLoot("Ravenheart Sword", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Wand of Death", 0.01),
                    new ItemLoot("Ring of Greater Health", 0.01),
                    new ItemLoot("Steel Shield", 0.01)
                    )
            )
             .Init("Arena Mushroom",
                        new State(
                    new State("Mush1",
                       new HpLessTransition(0.75, "Mush2")
                        ),
                    new State("Mush2",
                        new SetAltTexture(1),
                       new HpLessTransition(0.50, "Mush3")
                        ),
                      new State("Mush3",
                          new SetAltTexture(2),
                       new HpLessTransition(0.25, "die")
                        ),
                       new State("die",
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 1000),
                       new Suicide()
                        )
                )
            )
                 .Init("Troll 3",
                new State(
                    new State("trololo",
                        new PlayerWithinTransition(8, "move"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                    new State("move",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new MoveTo(speed: 1, x: 22, y: 18),
                    new TimedTransition(500, "trolled")
                        ),
                    new State("trolled",
                        new Wander(0.4),
                        new TossObject("Arena Mushroom", 3, coolDown: 2000),
                        new Shoot(10, count: 6, projectileIndex: 0, coolDown: 1250),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000),
                        new DamageTakenTransition(5000, "skilitins")
                        ),
                    new State("skilitins",
                        new Shoot(10, predictive: 1, coolDown: 1750),
                        new TossObject("Arena Skeleton", 3, coolDown: 1000),
                        new TimedTransition(4750, "skelcheck")
                        ),
                    new State("skelcheck",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, predictive: 1, coolDown: 1750),
                        new TossObject("Arena Skeleton", 3, coolDown: 3000),
                        new EntitiesNotExistsTransition(9999, "trolled", "Arena Skeleton")
                        )
                    ),
                new Threshold(0.025,
                    new TierLoot(8, ItemType.Weapon, 0.1),
                    new TierLoot(5, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Potion of Speed", 1),
                    new ItemLoot("Potion of Wisdom", 0.5)
                    )
            )
        //Arena 2
                    .Init("Arena Possessed Girl",
                new State(
                    new Prioritize(
                        new Follow(0.55, 8, 1),
                        new Wander(0.35)
                        ),
                    new Shoot(10, count: 8, projectileIndex: 0, coolDown: 1250)
                    ),
                new ItemLoot("Avenger Staff", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Superior Magic", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
                            .Init("Arena Ghost 1",
                new State(
                        new Follow(0.4, 8, 1),
                     new Shoot(10, count: 1, projectileIndex: 0, predictive: 2.5, coolDown: 1200),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 900)
                    ),
                new ItemLoot("Avenger Staff", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Mithril Chainmail", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
                            .Init("Arena Ghost 2",
                    new State(
                    new State("GetRekt",
                       new Follow(0.3, 8, 1),
                       new SetAltTexture(0),
                       new Shoot(8.4, count: 3, shootAngle: 20, projectileIndex: 0, coolDown: 1250),
                       new TimedTransition(3700, "Scrub")
                        ),
                    new State("Scrub",
                        new Wander(0.6),
                       new ConditionalEffect(ConditionEffectIndex.Invincible),
                       new SetAltTexture(1),
                            new TimedTransition(3700, "GetRekt")
                        )
          ))
                                    .Init("Arena Statue Left",
                    new State(
                    new State("GetRekt",
                        new EntityExistsTransition("FateT", 9999, "getem"),
                         new ConditionalEffect(ConditionEffectIndex.Invincible),
                       new SetAltTexture(1)
                        ),
                    new State("getem",
                       new SetAltTexture(0),
                       new Follow(0.6, 8, 1),
                       new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 275)
                        )
          ))
                                            .Init("Arena Statue Right",
                    new State(
                    new State("GetRekt",
                        new EntityExistsTransition("GloryT", 9999, "getem"),
                         new ConditionalEffect(ConditionEffectIndex.Invincible),
                       new SetAltTexture(1)
                        ),

                    new State("getem",
                         new SetAltTexture(0),
                       new Follow(0.6, 8, 1),
                       new Shoot(8.4, count: 1, projectileIndex: 1, coolDown: 575),
                       new Shoot(8.4, count: 3, shootAngle: 20, projectileIndex: 0, coolDown: 1000)
                        )
          ))
       .Init("Arena Ghost Bride",
            new State(
                    new State("trololo",
                        new PlayerWithinTransition(8, "fightTillFate"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                    new State("moveFate",
                        new SetAltTexture(0),
                    new MoveTo(speed: 1, x: 21, y: 11),
                    new TimedTransition(500, "goByeFate")
                        ),
                    new State("moveGlory",
                        new SetAltTexture(0),
                    new MoveTo(speed: 1, x: 27, y: 11),
                    new TimedTransition(500, "goByeGlory")
                        ),
                    new State("fightTillFate",
                        new BackAndForth(1, 2),
                        new SetAltTexture(0),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1100),
                        new Shoot(10, count: 8, projectileIndex: 1, coolDown: 1000),
                        new TimedTransition(4000, "moveFate")
                        ),
                   new State("fightTillGlory",
                        new BackAndForth(1, 2),
                        new SetAltTexture(0),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1100),
                        new Shoot(10, count: 8, projectileIndex: 1, coolDown: 1000),
                        new TimedTransition(4000, "moveGlory")
                        ),
                    new State("goByeFate",
                        new Spawn("FateT", initialSpawn: 1, maxChildren: 1, coolDown: 99999),
                        //  new Order(9999, "Arena Statue Left", "getem"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new SetAltTexture(1),
                        new EntitiesNotExistsTransition(9999, "fightTillGlory", "Arena Statue Left")
                        ),
                    new State("goByeGlory",
                        new SetAltTexture(1),
                        new Spawn("GloryT", initialSpawn: 1, maxChildren: 1, coolDown: 99999),
                        //  new Order(9999, "Arena Statue Right", "getem"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntitiesNotExistsTransition(9999, "justfight", "Arena Statue Right")
                        ),
                                        new State("justfight",
                        new Wander(1),
                        new Shoot(10, count: 6, shootAngle: 5, projectileIndex: 0, coolDown: 1100),
                        new Shoot(10, count: 2, shootAngle: 5, projectileIndex: 1, coolDown: 1000)
                                        )
                    ),
                new Threshold(0.025,
                    new TierLoot(8, ItemType.Weapon, 0.1),
                    new TierLoot(5, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Potion of Speed", 1),
                    new ItemLoot("Amulet of Resurrection", 0.0002),
                    new ItemLoot("Potion of Wisdom", 0.5)
                   ))

        //Arena 3
                   .Init("Arena Risen Archer",
                new State(
                     new StayBack(0.65, 4),
                     new Shoot(10, count: 1, projectileIndex: 0, predictive: 0.5, coolDown: 1200),
                     new Shoot(10, count: 8, projectileIndex: 1, coolDown: 1450)
                    ),
                new ItemLoot("Spirit Salve Tome", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Greater Dexterity", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
                           .Init("Arena Risen Brawler",
                new State(
                     new Follow(0.55, 8, 1),
                     new Shoot(10, count: 5, projectileIndex: 0, shootAngle: 5, predictive: 0.5, coolDown: 1200)
                    ),
                new ItemLoot("Spirit Salve Tome", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Greater Dexterity", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
                                   .Init("Arena Risen Mummy",
                new State(
                     new Follow(0.55, 8, 1),
                     new Shoot(10, count: 8, projectileIndex: 0, shootAngle: 14, predictive: 5, coolDown: 3750)
                    ),
                new ItemLoot("Spirit Salve Tome", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Superior Dexterity", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
                                   .Init("Arena Risen Mage",
                new State(
                     new Follow(0.3, 8, 1),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1200),
                    new HealGroup(10, "Hallowrena", coolDown: 5000)
                    ),
                new ItemLoot("Magesteel Quiver", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Greater Dexterity", 0.01),
                    new ItemLoot("Verdant Bow", 0.01)
                    )
            )
                                           .Init("Arena Risen Warrior",
                new State(
                     new Follow(0.6, 8, 1),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 10)
                    ),
                new ItemLoot("DDOS Sword", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01)
                    )
            )
            .Init("Arena Blue Flame",
                        new State(
                    new State("imgonnagetcha",
                        new Follow(0.65, 8, 1),
                        new PlayerWithinTransition(1, "blam")
                        ),
                    new State("blam",
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 1000),
                       new Suicide()
                    )))
                         .Init("Arena Grave Caretaker",
                new State(
                    new State("gravesandk",
                        new StayBack(0.78, 4),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1500),
                        new Shoot(10, count: 1, projectileIndex: 0, predictive: 7, coolDown: 300),
                        new Shoot(10, count: 6, projectileIndex: 1, coolDown: 1000),
                        new Spawn("Arena Blue Flame", initialSpawn: 1, maxChildren: 1, coolDown: 3750)
                        )
                    ),
                new Threshold(0.025,
                    new TierLoot(10, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(4, ItemType.Ring, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.05),
                    new TierLoot(11, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Potion of Speed", 1),
                    new ItemLoot("Potion of Wisdom", 0.5)
                    )
            )
        //Arena 4
                           .Init("Classic Ghost",
                new State(
                     new Wander(0.5),
                     new Shoot(10, count: 3, projectileIndex: 0, shootAngle: 3, predictive: 1, coolDown: 1200)
                    ),
                new ItemLoot("Timelock Orb", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Greater Attack", 0.01),
                    new ItemLoot("Steel Shield", 0.01)
                    )
            )
                         .Init("Mini Werewolf",
                new State(
                     new Follow(0.5, 8, 1),
                     new Shoot(10, count: 3, projectileIndex: 0, coolDown: 1200)
                    ),
                new ItemLoot("Magic Potion", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Greater Attack", 0.01),
                    new ItemLoot("Steel Shield", 0.01)
                    )
            )
                    .Init("Zombie Hulk",
                new State(
                    new Prioritize(
                        new Follow(0.6, 8, 1),
                        new Wander(0.2)
                        ),
                     new Shoot(10, count: 4, projectileIndex: 0, shootAngle: 5, coolDown: 1500),
                     new Shoot(10, count: 1, projectileIndex: 1, coolDown: 2000)
                    ),
                new ItemLoot("Health Potion", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Greater Dexterity", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
                            .Init("Werewolf",
                new State(
                        new Wander(0.4),
                     new Shoot(10, count: 6, projectileIndex: 0, shootAngle: 5, coolDown: 1500),
                     new Spawn("Mini Werewolf", initialSpawn: 1, maxChildren: 3, coolDown: 7000)
                    ),
                new ItemLoot("Health Potion", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Golden Sword", 0.01),
                    new ItemLoot("Ring of Greater Dexterity", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
                            .Init("Blue Zombie",
                new State(
                     new Follow(0.1, 8, 1),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1000)
                    )
            )
                                    .Init("Flying Flame Skull",
                new State(
                     new Swirl(0.65, 7),
                     new Shoot(10, count: 10, projectileIndex: 0, coolDown: 500),
                      new ConditionalEffect(ConditionEffectIndex.Invincible)
                    )
            )
                                    .Init("Halloween Zombie Spawner",
                    new State(
                    new State("idle",
                       new ConditionalEffect(ConditionEffectIndex.Invincible)
                        ),
                    new State("spawn",
                        new Spawn("Blue Zombie", initialSpawn: 1, maxChildren: 1, coolDown: 6850)
                        )
          ))
                    //GHOST OF SKULD LETS GOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    .Init("Ghost of Skuld",
                new State(
                    new RealmPortalDrop(),
                    new HpLessTransition(0.1, "deadTask"),
                    new State("skuld1",
                        new Order(9999, "Halloween Zombie Spawner", "spawn"),
                        new Taunt(1.00, "Your reward is....A SWIFT DEATH!"),
                        new InvisiToss("Flying Flame Skull", range: 6, angle: 270, coolDown: 9999),
                        new InvisiToss("Flying Flame Skull", range: 6, angle: 90, coolDown: 9999),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4500, "gotem")
                        ),
                    new State("gotem",
                         new Shoot(10, count: 5, shootAngle: 5, projectileIndex: 0, coolDown: 700),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1200),
                        new Shoot(12, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 4000),
                        new Shoot(12, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 4000),
                        new Shoot(12, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 4000),
                        new Shoot(12, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 4000),
                        new TimedTransition(10000, "telestart")
                        ),
                   new State("blam1",
                       new SetAltTexture(1),
                       new Shoot(10, count: 7, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 1400),
                        new TimedTransition(5000, "tele7")
                        ),
                                      new State("blam2",
                                          new SetAltTexture(1),
                        new Shoot(10, count: 7, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 1400),
                        new TimedTransition(5000, "tele5")
                        ),
                                new State("blam3",
                                    new SetAltTexture(1),
                        new Shoot(10, count: 7, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 1400),
                        new TimedTransition(5000, "tele4")
                        ),
                                new State("blam4",
                                    new SetAltTexture(1),
                        new Shoot(10, count: 7, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 1400),
                        new TimedTransition(5000, "tele6")
                        ),
                               new State("blam5",
                                   new SetAltTexture(1),
                        new Shoot(10, count: 7, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 1400),
                        new TimedTransition(5000, "tele2")
                        ),
                                        new State("blam6",
                                            new SetAltTexture(1),
                        new Shoot(10, count: 7, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 1400),
                        new TimedTransition(5000, "tele3")
                        ),
                                      new State("blam7",
                                          new SetAltTexture(1),
                                          new Shoot(10, count: 7, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 1400),
                        new TimedTransition(5000, "tele8")
                        ),
                                      new State("blam8",
                                          new SetAltTexture(1),
                                          new Shoot(10, count: 7, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 1, coolDown: 1400),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 1400),
                        new TimedTransition(5000, "tele8")
                        ),
                    new State("telestart",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "tele1")
                        ),
                    new State("tele1",
                        new SetAltTexture(11),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new MoveTo(speed: 2, x: 24, y: 18),
                        new TimedTransition(1000, "blam2")
                        ),
                    new State("tele2",
                        new SetAltTexture(11),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new MoveTo(speed: 2, x: 17, y: 26),
                        new TimedTransition(1000, "blam3")
                        ),
                    new State("tele3",
                        new SetAltTexture(11),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new MoveTo(speed: 2, x: 29, y: 19),
                        new TimedTransition(1000, "blam4")
                        ),
                    new State("tele4",
                        new SetAltTexture(11),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new MoveTo(speed: 2, x: 29, y: 29),
                        new TimedTransition(1000, "blam5")
                        ),
                   new State("tele5",
                        new SetAltTexture(11),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new MoveTo(speed: 2, x: 24, y: 18),
                        new TimedTransition(1000, "blam6")
                        ),
                  new State("tele6",
                        new SetAltTexture(11),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new MoveTo(speed: 2, x: 25, y: 35),
                        new TimedTransition(1000, "blam7")
                        ),
                  new State("tele7",
                        new SetAltTexture(11),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new MoveTo(speed: 2, x: 20, y: 29),
                        new TimedTransition(1000, "blam8")
                        ),
                  new State("tele8",
                        new SetAltTexture(11),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new MoveTo(speed: 2, x: 24, y: 24),
                        new TimedTransition(1000, "gotem")
                        ),
                    new State("deadTask",
        new RemoveEntity(9999, "Halloween Zombie Spawner"),
        new RemoveEntity(9999, "Blue Zombie"),
        new RemoveEntity(9999, "Flying Flame Skull"),
                        new Suicide()
                        )
                    ),
                                new MostDamagers(3,
                    LootTemplates.Sor1Perc()
                    ),
                new Threshold(0.025,
                    new TierLoot(11, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(11, ItemType.Armor, 0.1),
                    new TierLoot(5, ItemType.Ring, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.05),
                    new TierLoot(11, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Potion of Vitality", 1),
                    new ItemLoot("Potion of Wisdom", 0.5),
                    new ItemLoot("Resurrected Warrior's Armor", 0.04),
                    new ItemLoot("Plague Poison", 0.04),
                    new ItemLoot("Etherite Dagger", 0.02),
                    new ItemLoot("Ghastly Drape", 0.02),
                    new ItemLoot("Mantle of Skuld", 0.02),
                    new ItemLoot("Spectral Ring of Horrors", 0.02)
                    )
            )

                                           //Arena Spawners & Logic
                                           .Init("Arena South Gate Spawner",
                                       new State(
                                            new State("Greeting",
                                               new ConditionalEffect(ConditionEffectIndex.Invincible)
                                               ),
                                           new State("arena1wave1",
                                               new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena1wave2",
                                           new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 3, coolDown: 90000)
                                               ),
                                           new State("arena1wave3",
                                           new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 3, coolDown: 90000),
                                           new Spawn("Troll 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Troll 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena1wave4",
                                           new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Troll 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Troll 2", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                           new State("arena2wave1",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena2wave2",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Possessed Girl", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena2wave3",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Arena Possessed Girl", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena2wave4",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Arena Possessed Girl", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena3wave1",
                                           new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena3wave2",
                                           new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                             new Spawn("Arena Risen Warrior", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                           new State("arena3wave3",
                                           new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                             new Spawn("Arena Risen Brawler", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                            new State("arena3wave4",
                                           new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Risen Brawler", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave1",
                                           new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave2",
                                           new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Zombie Hulk", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave3",
                                           new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Zombie Hulk", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave4",
                                           new Spawn("Zombie Hulk", initialSpawn: 2, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               )
                                           )
                                   )

                                           .Init("Arena East Gate Spawner",
                                       new State(
                                                                new State("Greeting",
                                               new ConditionalEffect(ConditionEffectIndex.Invincible)
                                               ),
                                           new State("arena1wave1",
                                               new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena1wave2",
                                           new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 3, coolDown: 90000)
                                               ),
                                           new State("arena1wave3",
                                           new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 3, coolDown: 90000)
                                               ),
                                           new State("arena1wave4",
                                           new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Troll 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Troll 2", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                           new State("arena2wave1",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena2wave2",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Possessed Girl", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena2wave3",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena2wave4",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                           new State("arena3wave1",
                                           new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena3wave2",
                                           new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                             new Spawn("Arena Risen Warrior", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                           new State("arena3wave3",
                                           new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                             new Spawn("Arena Risen Brawler", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                            new State("arena3wave4",
                                           new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Risen Brawler", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave1",
                                           new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave2",
                                           new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Zombie Hulk", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave3",
                                           new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Zombie Hulk", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave4",
                                           new Spawn("Zombie Hulk", initialSpawn: 2, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               )
                                           )
                                   )

                                           .Init("Arena West Gate Spawner",
                                       new State(
                                                                new State("Greeting",
                                               new ConditionalEffect(ConditionEffectIndex.Invincible)
                                               ),
                                           new State("arena1wave1",
                                               new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                           new State("arena1wave2",
                                           new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 3, coolDown: 90000),
                                           new Spawn("Troll 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena1wave3",
                                           new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 3, coolDown: 90000),
                                           new Spawn("Troll 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Troll 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena1wave4",
                                           new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Troll 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Troll 2", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                           new State("arena2wave1",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena2wave2",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Possessed Girl", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena2wave3",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Arena Possessed Girl", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena2wave4",
                                           new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Arena Possessed Girl", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena3wave1",
                                           new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena3wave2",
                                           new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                             new Spawn("Arena Risen Warrior", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                           new State("arena3wave3",
                                           new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                             new Spawn("Arena Risen Brawler", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                               ),
                                            new State("arena3wave4",
                                           new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Risen Brawler", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave1",
                                           new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave2",
                                           new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Zombie Hulk", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave3",
                                           new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                           new Spawn("Zombie Hulk", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               ),
                                           new State("arena4wave4",
                                           new Spawn("Zombie Hulk", initialSpawn: 2, maxChildren: 1, coolDown: 90000),
                                           new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                               )
                                           )
                                   )

                                                   //North/Boss Spawner
                                                   .Init("Arena North Gate Spawner",
                                               new State(
                                                 new State("Greeting",
                                               new ConditionalEffect(ConditionEffectIndex.Invincible)
                                               ),
                                                   new State("arena1wave1",
                                                       new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                                       ),
                                                   new State("arena1wave2",
                                                   new Spawn("Troll 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena1wave3",
                                                   new Spawn("Troll 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena1wave4",
                                                   new Spawn("Arena Skeleton", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Troll 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Troll 2", initialSpawn: 1, maxChildren: 2, coolDown: 90000)
                                                       ),
                                                   new State("arena1boss",
                                                   new Spawn("Troll 3", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena2wave1",
                                                   new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena2wave2",
                                                   new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Arena Possessed Girl", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena2wave3",
                                                   new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Arena Possessed Girl", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena2wave4",
                                                   new Spawn("Arena Ghost 1", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                                   new Spawn("Arena Ghost 2", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Arena Possessed Girl", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                  new State("arena2boss",
                                                   new Spawn("Arena Ghost Bride", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena3wave1",
                                                   new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena3wave2",
                                                   new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                     new Spawn("Arena Risen Warrior", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena3wave3",
                                                   new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                     new Spawn("Arena Risen Brawler", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                    new State("arena3wave4",
                                                   new Spawn("Arena Risen Mage", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Arena Risen Brawler", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Arena Risen Archer", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                  new State("arena3boss",
                                                   new Spawn("Arena Grave Caretaker", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena4wave1",
                                                   new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 2, coolDown: 90000),
                                                   new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena4wave2",
                                                   new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Zombie Hulk", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena4wave3",
                                                   new Spawn("Classic Ghost", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Zombie Hulk", initialSpawn: 1, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       ),
                                                   new State("arena4wave4",
                                                   new Spawn("Zombie Hulk", initialSpawn: 2, maxChildren: 1, coolDown: 90000),
                                                   new Spawn("Werewolf", initialSpawn: 1, maxChildren: 1, coolDown: 90000)
                                                       )
                                                   )
                                           )

                                        //Arena Battlemastahs/Logic
                                        .Init("Area 1 Controller",
                                       new State(
                                       new ConditionalEffect(ConditionEffectIndex.Invincible),
                                           new State("Greeting",
                                               new PlayerWithinTransition(2, "talk1")
                                               ),
                                           new State("talk1",
                                               new SetAltTexture(2),
                                           new Taunt(1.00, "Welcome to my domain. I challenge you, warrior, to defeat my undead hordes and claim your prize..."),
                                           new TimedTransition(5000, "talk3")
                                               ),
                                        new State("talk3",
                                            new SetAltTexture(1),
                                           new Taunt(1.00, "Prepare yourself, Say Ready when you wish the battle to begin!"),
                                            new PlayerTextTransition("1", "Ready", 99, false, true)
                                               ),
                                           new State("1",
                                               new SetAltTexture(0),
                                               new Order(9999, "Arena East Gate Spawner", "arena1wave1"),
                                               new Order(9999, "Arena West Gate Spawner", "arena1wave1"),
                                               new Order(9999, "Arena South Gate Spawner", "arena1wave1"),
                                               new Order(9999, "Arena North Gate Spawner", "arena1wave1"),
                                                new TimedTransition(2750, "2")
                                               ),
                                                              new State("2",
                                               new SetAltTexture(0),
                                               new EntitiesNotExistsTransition(9999, "3", "Arena Skeleton", "Troll 1", "Troll 2")
                                               ),
                                                  new State("3",
                                               new SetAltTexture(1),
                                           new Taunt(1.00, "Only seconds until the next wave."),
                                           new TimedTransition(5000, "4")
                                               ),
                                          new State("4",
                                               new SetAltTexture(0),
                                               new Order(9999, "Arena East Gate Spawner", "arena1wave2"),
                                               new Order(9999, "Arena West Gate Spawner", "arena1wave2"),
                                               new Order(9999, "Arena South Gate Spawner", "arena1wave2"),
                                               new Order(9999, "Arena North Gate Spawner", "arena1wave2"),
                                                new TimedTransition(2750, "5")
                                               ),
                                        new State("5",
                                               new SetAltTexture(0),
                                               new EntitiesNotExistsTransition(9999, "6", "Arena Skeleton", "Troll 1", "Troll 2")
                                               ),
                                        new State("6",
                                               new SetAltTexture(1),
                                           new Taunt(1.00, "Only seconds until the next wave."),
                                           new TimedTransition(5000, "7")
                                               ),
                                        new State("7",
                                               new SetAltTexture(0),
                                               new Order(9999, "Arena East Gate Spawner", "arena1wave3"),
                                               new Order(9999, "Arena West Gate Spawner", "arena1wave3"),
                                               new Order(9999, "Arena South Gate Spawner", "arena1wave3"),
                                               new Order(9999, "Arena North Gate Spawner", "arena1wave3"),
                                                new TimedTransition(2750, "8")
                                               ),
                                       new State("8",
                                               new SetAltTexture(0),
                                               new EntitiesNotExistsTransition(9999, "9", "Arena Skeleton", "Troll 1", "Troll 2")
                                               ),
                                         new State("9",
                                               new SetAltTexture(1),
                                           new Taunt(1.00, "Only seconds until the next wave."),
                                           new TimedTransition(5000, "10")
                                               ),
                                         new State("10",
                                               new SetAltTexture(0),
                                               new Order(9999, "Arena East Gate Spawner", "arena1wave4"),
                                               new Order(9999, "Arena West Gate Spawner", "arena1wave4"),
                                               new Order(9999, "Arena South Gate Spawner", "arena1wave4"),
                                               new Order(9999, "Arena North Gate Spawner", "arena1wave4"),
                                                new TimedTransition(2750, "11")
                                               ),
                                         new State("11",
                                               new SetAltTexture(0),
                                               new EntitiesNotExistsTransition(9999, "12", "Arena Skeleton", "Troll 1", "Troll 2")
                                               ),
                                        new State("12",
                                           new SetAltTexture(1),
                                           new Taunt(1.00, "Only seconds until the next wave."),
                                           new TimedTransition(5000, "13")
                                               ),
                                        new State("13",
                                               new SetAltTexture(0),
                                               new Order(9999, "Arena North Gate Spawner", "arena1boss"),
                                                new TimedTransition(2750, "14")
                                               ),
                                       new State("14",
                                               new SetAltTexture(0),
                                               new EntitiesNotExistsTransition(9999, "portal", "Troll 3")
                                               ),
                                       new State("portal",
                                               new SetAltTexture(0),
                                               new DropPortalOnDeath("Haunted Cemetery Gates Portal", 100, timeout: 9999),
                                               new Suicide()
                                               )

                                           )
                                   )

                                              .Init("Area 2 Controller",
                                       new State(
                                           new ConditionalEffect(ConditionEffectIndex.Invincible),
                                           new State("Greeting",
                                               new PlayerWithinTransition(2, "talk3")
                                               ),
                                        new State("talk3",
                                            new SetAltTexture(1),
                                           new Taunt(1.00, "Prepare yourself, Say Ready when you wish the battle to begin!"),
                                           new PlayerTextTransition("1", "Ready", 99, false, true)
                                               ),
                                           new State("1",
                                               new SetAltTexture(0),
                                               new Order(9999, "Arena East Gate Spawner", "arena2wave1"),
                                               new Order(9999, "Arena West Gate Spawner", "arena2wave1"),
                                               new Order(9999, "Arena South Gate Spawner", "arena2wave1"),
                                               new Order(9999, "Arena North Gate Spawner", "arena2wave1"),
                                                new TimedTransition(2750, "2")
                                               ),
                                                              new State("2",
                                               new SetAltTexture(0),
                                               new EntitiesNotExistsTransition(9999, "3", "Arena Possessed Girl", "Arena Ghost 1", "Arena Ghost 2")
                                               ),
                                                  new State("3",
                                               new SetAltTexture(2),
                                           new Taunt(1.00, "Only seconds until the next wave."),
                                           new TimedTransition(5000, "4")
                                               ),
                                          new State("4",
                                               new SetAltTexture(0),
                                               new Order(9999, "Arena East Gate Spawner", "arena2wave2"),
                                               new Order(9999, "Arena West Gate Spawner", "arena2wave2"),
                                               new Order(9999, "Arena South Gate Spawner", "arena2wave2"),
                                               new Order(9999, "Arena North Gate Spawner", "arena2wave2"),
                                                new TimedTransition(2750, "5")
                                               ),
                                        new State("5",
                                               new SetAltTexture(0),
                                               new EntitiesNotExistsTransition(9999, "6", "Arena Possessed Girl", "Arena Ghost 1", "Arena Ghost 2")
                                               ),
                                        new State("6",
                                               new SetAltTexture(2),
                                           new Taunt(1.00, "Only seconds until the next wave."),
                                           new TimedTransition(5000, "7")
                                               ),
                                        new State("7",
                                               new SetAltTexture(0),
                                               new Order(9999, "Arena East Gate Spawner", "arena2wave3"),
                                               new Order(9999, "Arena West Gate Spawner", "arena2wave3"),
                                               new Order(9999, "Arena South Gate Spawner", "arena2wave3"),
                                               new Order(9999, "Arena North Gate Spawner", "arena2wave3"),
                                                new TimedTransition(2750, "8")
                                               ),
                                       new State("8",
                                               new SetAltTexture(0),
                                               new EntitiesNotExistsTransition(9999, "9", "Arena Possessed Girl", "Arena Ghost 1", "Arena Ghost 2")
                                               ),
                                         new State("9",
                                               new SetAltTexture(2),
                                           new Taunt(1.00, "Only seconds until the next wave."),
                                           new TimedTransition(5000, "10")
                                               ),
                                         new State("10",
                                               new SetAltTexture(0),
                                               new Order(9999, "Arena East Gate Spawner", "arena2wave4"),
                                               new Order(9999, "Arena West Gate Spawner", "arena2wave4"),
                                               new Order(9999, "Arena South Gate Spawner", "arena2wave4"),
                                               new Order(9999, "Arena North Gate Spawner", "arena2wave4"),
                                                new TimedTransition(2750, "11")
                                               ),
                                         new State("11",
                                               new SetAltTexture(0),
                                               new EntitiesNotExistsTransition(9999, "12", "Arena Possessed Girl", "Arena Ghost 1", "Arena Ghost 2")
                                               ),
                                        new State("12",
                                           new SetAltTexture(2),
                                           new Taunt(1.00, "Only seconds until the next wave."),
                                           new TimedTransition(5000, "13")
                                               ),
                                        new State("13",
                                               new SetAltTexture(0),
                                               new Order(9999, "Arena North Gate Spawner", "arena2boss"),
                                                new TimedTransition(2750, "14")
                                               ),
                                       new State("14",
                                               new SetAltTexture(0),
                                               new EntitiesNotExistsTransition(9999, "portal", "Arena Ghost Bride")
                                               ),
                                       new State("portal",
                                               new SetAltTexture(0),
                                               new DropPortalOnDeath("Haunted Cemetery Graves Portal", 100, timeout: 9999),
                                               new Suicide()
                                               )

                                           )
                                   )

                .Init("Area 3 Controller",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Greeting",
                        new PlayerWithinTransition(2, "talk1")
                        ),
                    new State("talk1",
                        new SetAltTexture(2),
                    new Taunt(1.00, "You've made it this far.."),
                    new TimedTransition(5000, "talk3")
                        ),
                 new State("talk3",
                     new SetAltTexture(1),
                    new Taunt(1.00, "Prepare yourself, Say Ready when you wish the battle to begin!"),
                    new PlayerTextTransition("1", "Ready", 99, false, true)
                        ),
                    new State("1",
                        new SetAltTexture(0),
                        new Order(9999, "Arena East Gate Spawner", "arena3wave1"),
                        new Order(9999, "Arena West Gate Spawner", "arena3wave1"),
                        new Order(9999, "Arena South Gate Spawner", "arena3wave1"),
                        new Order(9999, "Arena North Gate Spawner", "arena3wave1"),
                         new TimedTransition(2750, "2")
                        ),
                                       new State("2",
                        new SetAltTexture(0),
                        new EntitiesNotExistsTransition(9999, "3", "Arena Risen Warrior", "Arena Risen Archer", "Arena Risen Mage", "Arena Risen Brawler")
                        ),
                           new State("3",
                        new SetAltTexture(2),
                    new Taunt(1.00, "Only seconds until the next wave."),
                    new TimedTransition(5000, "4")
                        ),
                   new State("4",
                        new SetAltTexture(0),
                        new Order(9999, "Arena East Gate Spawner", "arena3wave2"),
                        new Order(9999, "Arena West Gate Spawner", "arena3wave2"),
                        new Order(9999, "Arena South Gate Spawner", "aren3wave2"),
                        new Order(9999, "Arena North Gate Spawner", "arena3wave2"),
                         new TimedTransition(2750, "5")
                        ),
                 new State("5",
                        new SetAltTexture(0),
                        new EntitiesNotExistsTransition(9999, "6", "Arena Risen Warrior", "Arena Risen Archer", "Arena Risen Mage", "Arena Risen Brawler")
                        ),
                 new State("6",
                        new SetAltTexture(2),
                    new Taunt(1.00, "Only seconds until the next wave."),
                    new TimedTransition(5000, "7")
                        ),
                 new State("7",
                        new SetAltTexture(0),
                        new Order(9999, "Arena East Gate Spawner", "arena3wave3"),
                        new Order(9999, "Arena West Gate Spawner", "arena3wave3"),
                        new Order(9999, "Arena South Gate Spawner", "arena3wave3"),
                        new Order(9999, "Arena North Gate Spawner", "arena3wave3"),
                         new TimedTransition(2750, "8")
                        ),
                new State("8",
                        new SetAltTexture(0),
                        new EntitiesNotExistsTransition(9999, "9", "Arena Risen Warrior", "Arena Risen Archer", "Arena Risen Mage", "Arena Risen Brawler")
                        ),
                  new State("9",
                        new SetAltTexture(2),
                    new Taunt(1.00, "Only seconds until the next wave."),
                    new TimedTransition(5000, "10")
                        ),
                  new State("10",
                        new SetAltTexture(0),
                        new Order(9999, "Arena East Gate Spawner", "arena3wave4"),
                        new Order(9999, "Arena West Gate Spawner", "arena3wave4"),
                        new Order(9999, "Arena South Gate Spawner", "arena3wave4"),
                        new Order(9999, "Arena North Gate Spawner", "arena3wave4"),
                         new TimedTransition(2750, "11")
                        ),
                  new State("11",
                        new SetAltTexture(0),
                        new EntitiesNotExistsTransition(9999, "12", "Arena Risen Warrior", "Arena Risen Archer", "Arena Risen Mage", "Arena Risen Brawler")
                        ),
                 new State("12",
                    new SetAltTexture(2),
                    new Taunt(1.00, "Only seconds until the next wave."),
                    new TimedTransition(5000, "13")
                        ),
                 new State("13",
                        new SetAltTexture(0),
                        new Order(9999, "Arena North Gate Spawner", "arena3boss"),
                         new TimedTransition(2750, "14")
                        ),
                new State("14",
                        new SetAltTexture(0),
                        new EntitiesNotExistsTransition(9999, "portal", "Arena Grave Caretaker")
                        ),
                new State("portal",
                        new SetAltTexture(0),
                        new DropPortalOnDeath("Haunted Cemetery Final Rest Portal", 100, timeout: 9999),
                        new Suicide()
                        )
                    )
            )

                                       .Init("Area 4 Controller",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Greeting",
                        new PlayerWithinTransition(2, "talk1")
                        ),
                    new State("talk1",
                        new SetAltTexture(2),
                    new Taunt(1.00, "The final battle is imminent."),
                    new TimedTransition(5000, "talk3")
                        ),
                 new State("talk3",
                     new SetAltTexture(1),
                    new Taunt(1.00, "Prepare yourself, Say Ready when you wish the battle to begin!"),
                    new PlayerTextTransition("1", "Ready", 99, false, true)
                        ),
                    new State("1",
                        new SetAltTexture(0),
                        new Order(9999, "Arena East Gate Spawner", "aren4wave1"),
                        new Order(9999, "Arena West Gate Spawner", "arena4wave1"),
                        new Order(9999, "Arena South Gate Spawner", "arena4wave1"),
                        new Order(9999, "Arena North Gate Spawner", "arena4wave1"),
                         new TimedTransition(2750, "2")
                        ),
                                       new State("2",
                        new SetAltTexture(0),
                        new EntitiesNotExistsTransition(9999, "3", "Classic Ghost", "Werewolf", "Zombie Hulk", "Mini Werewolf")
                        ),
                           new State("3",
                        new SetAltTexture(2),
                    new Taunt(1.00, "Only seconds until the next wave."),
                    new TimedTransition(5000, "4")
                        ),
                   new State("4",
                        new SetAltTexture(0),
                        new Order(9999, "Arena East Gate Spawner", "arena4wave2"),
                        new Order(9999, "Arena West Gate Spawner", "arena4wave2"),
                        new Order(9999, "Arena South Gate Spawner", "aren4wave2"),
                        new Order(9999, "Arena North Gate Spawner", "arena4wave2"),
                         new TimedTransition(2750, "5")
                        ),
                 new State("5",
                        new SetAltTexture(0),
                        new EntitiesNotExistsTransition(9999, "6", "Classic Ghost", "Werewolf", "Zombie Hulk", "Mini Werewolf")
                        ),
                 new State("6",
                        new SetAltTexture(2),
                    new Taunt(1.00, "Only seconds until the next wave."),
                    new TimedTransition(5000, "7")
                        ),
                 new State("7",
                        new SetAltTexture(0),
                        new Order(9999, "Arena East Gate Spawner", "arena4wave3"),
                        new Order(9999, "Arena West Gate Spawner", "arena4wave3"),
                        new Order(9999, "Arena South Gate Spawner", "arena4wave3"),
                        new Order(9999, "Arena North Gate Spawner", "arena4wave3"),
                         new TimedTransition(2750, "8")
                        ),
                new State("8",
                        new SetAltTexture(0),
                        new EntitiesNotExistsTransition(9999, "9", "Classic Ghost", "Werewolf", "Zombie Hulk", "Mini Werewolf")
                        ),
                  new State("9",
                        new SetAltTexture(2),
                    new Taunt(1.00, "Only seconds until the next wave."),
                    new TimedTransition(5000, "10")
                        ),
                  new State("10",
                        new SetAltTexture(0),
                        new Order(9999, "Arena East Gate Spawner", "arena4wave4"),
                        new Order(9999, "Arena West Gate Spawner", "arena4wave4"),
                        new Order(9999, "Arena South Gate Spawner", "arena4wave4"),
                        new Order(9999, "Arena North Gate Spawner", "arena4wave4"),
                         new TimedTransition(2750, "11")
                        ),
                  new State("11",
                        new SetAltTexture(0),
                        new EntitiesNotExistsTransition(9999, "12", "Classic Ghost", "Werewolf", "Zombie Hulk", "Mini Werewolf")
                        ),
                 new State("12",
                    new SetAltTexture(2),
                    new Taunt(1.00, "Only seconds until the next wave."),
                    new TimedTransition(5000, "13")
                        ),
                 new State("13",
                        new SetAltTexture(0),
                         new TimedTransition(2750, "14")
                        ),
                new State("14",
                        new SetAltTexture(0),
                          new EntitiesNotExistsTransition(9999, "portal", "Classic Ghost", "Werewolf", "Zombie Hulk", "Mini Werewolf")
                        ),
                new State("portal",
                        new SetAltTexture(0),
                        new TransformOnDeath("Ghost of Skuld", 1, 1, 1),
                        new Suicide()
                        )

                    )
            );
    }
}