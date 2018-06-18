using wServer.realm;
using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ LairOfDraconis = () => Behav()
         //Dragon Souls swag
         .Init("NM Altar of Draconis",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("idle",
                        new Spawn("Dragon Table MM", 1, 1, coolDown: 99999),
                        new EntitiesNotExistsTransition(9999, "dropportal", "NM Red Dragon God", "NM Blue Dragon God", "NM Green Dragon God", "NM Black Dragon God")
                    ),
                    new State("dropportal",
                       new Suicide()
                    )
                )
            )

         .Init("NM Red Dragon Soul",
                new State(
                    new SetNoXP(),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("idle",
                        new PlayerTextTransition("goToRedDragon", "Red", 99, false, true),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                    ),
                    new State("goToRedDragon",
                        new Order(670, "NM Green Dragon Soul", "redinactive"),
                        new Order(670, "NM Black Dragon Soul", "redinactive"),
                        new Order(670, "NM Red Dragon Soul", "redinactive"),
                        new Order(670, "NM Blue Dragon Soul", "redinactive"),
                        new RemoveTileObject("Iron Brick", 99),
                        new Orbit(0.45, 2.5, 9999, "NM Red Dragon God"),
                        new Suicide()
                        ),
                    new State("rip",
                        new Suicide()
                        ),
                    new State("greeninactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Green Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("redinactive",
                        new EntitiesNotExistsTransition(9999, "rip", "NM Red Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("blackinactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Black Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("blueinactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Blue Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        )

                    )
            )
          .Init("NM Blue Dragon Soul",
                new State(
                    new SetNoXP(),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("idle",
                        new PlayerTextTransition("goToBlueDragon", "Blue", 99, false, true),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                    ),
                    new State("goToBlueDragon",
                        new Order(670, "NM Green Dragon Soul", "blueinactive"),
                        new Order(670, "NM Black Dragon Soul", "blueinactive"),
                        new Order(670, "NM Red Dragon Soul", "blueinactive"),
                        new Order(670, "NM Blue Dragon Soul", "blueinactive"),
                        new RemoveTileObject("Ice Cave Wall", 99),
                        new Orbit(0.45, 2.5, 9999, "NM Blue Dragon God"),
                        new Suicide()
                        ),
                    new State("rip",
                        new Suicide()
                        ),
                    new State("greeninactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Green Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("redinactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Red Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("blackinactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Black Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("blueinactive",
                        new EntitiesNotExistsTransition(9999, "rip", "NM Blue Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        )
                    )
            )
        .Init("NM Green Dragon Soul",
                new State(
                    new SetNoXP(),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("idle",
                        new PlayerTextTransition("goToGreenDragon", "Green", 99, false, true),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                    ),
                    new State("goToGreenDragon",
                        new Order(670, "NM Green Dragon Soul", "greeninactive"),
                        new Order(670, "NM Black Dragon Soul", "greeninactive"),
                        new Order(670, "NM Red Dragon Soul", "greeninactive"),
                        new Order(670, "NM Blue Dragon Soul", "greeninactive"),
                        new RemoveTileObject("Jungle Temple Walls", 99),
                        new Orbit(0.45, 2.5, 9999, "NM Green Dragon God"),
                        new Suicide()
                        ),
                    new State("rip",
                        new Suicide()
                        ),
                    new State("greeninactive",
                        new EntitiesNotExistsTransition(9999, "rip", "NM Green Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("redinactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Red Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("blackinactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Black Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("blueinactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Blue Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        )
                    )
            )
        .Init("NM Black Dragon Soul",
                new State(
                    new SetNoXP(),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("idle",
                        new PlayerTextTransition("goToBlackDragon", "Black", 99, false, true),
                        new Orbit(0.3, 2.5, 20, "NM Altar of Draconis")
                    ),
                    new State("goToBlackDragon",
                        new Order(670, "NM Green Dragon Soul", "blackinactive"),
                        new Order(670, "NM Black Dragon Soul", "blackinactive"),
                        new Order(670, "NM Red Dragon Soul", "blackinactive"),
                        new Order(670, "NM Blue Dragon Soul", "blackinactive"),
                        new RemoveTileObject("Blue Wall", 99),
                        new Orbit(0.45, 2.5, 9999, "NM Black Dragon God"),
                        new Suicide()
                        ),
                    new State("rip",
                        new Suicide()
                        ),
                    new State("greeninactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Green Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("redinactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Red Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("blackinactive",
                        new EntitiesNotExistsTransition(9999, "rip", "NM Black Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        ),
                    new State("blueinactive",
                        new EntitiesNotExistsTransition(9999, "idle", "NM Blue Dragon God"),
                        new Orbit(0.2, 2.5, 20, "NM Altar of Draconis")
                        )
                    )
            )
        //Test Chest
         .Init("lod Blue Loot Balloon",
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
                new Threshold(0.15,
                new TierLoot(12, ItemType.Weapon, 0.045),
                new TierLoot(12, ItemType.Weapon, 0.05),
                new TierLoot(6, ItemType.Ability, 0.045),
                new TierLoot(13, ItemType.Armor, 0.05),
                new ItemLoot("Ivory Ring", 0.05),
                new ItemLoot("Potion of Mana", 0.8),
                new ItemLoot("Water Dragon Silk Robe", 0.05),
                new ItemLoot("Large Blue Dragon Scale Cloth", 0.045),
                new ItemLoot("Small Blue Dragon Scale Cloth", 0.045),
                new ItemLoot("The World Tarot Card", 0.05),
                new ItemLoot("Dragon Pearl", 0.08)
                )
            )
        .Init("lod Green Loot Balloon",
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
                new Threshold(0.15,
                new TierLoot(12, ItemType.Weapon, 0.045),
                new TierLoot(12, ItemType.Weapon, 0.05),
                new TierLoot(6, ItemType.Ability, 0.045),
                new TierLoot(4, ItemType.Ability, 0.065),
                new TierLoot(13, ItemType.Armor, 0.05),
                new ItemLoot("Ivory Ring", 0.05),
                new ItemLoot("Leaf Dragon Hide Armor", 0.05),
                new ItemLoot("Large Green Dragon Scale Cloth", 0.045),
                new ItemLoot("Small Green Dragon Scale Cloth", 0.045),
                new ItemLoot("The World Tarot Card", 0.03),
                new ItemLoot("Dragon Pearl", 0.08)
                )
            )
        .Init("lod Black Loot Balloon",
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
                new Threshold(0.15,
                new TierLoot(12, ItemType.Weapon, 0.045),
                new TierLoot(12, ItemType.Weapon, 0.05),
                new TierLoot(6, ItemType.Ability, 0.045),
                new TierLoot(4, ItemType.Ability, 0.065),
                new TierLoot(13, ItemType.Armor, 0.05),
                new ItemLoot("Ivory Ring", 0.05),
                new ItemLoot("Celestial Blade", 0.05),
                new ItemLoot("Large Midnight Dragon Scale Cloth", 0.045),
                new ItemLoot("Small Midnight Dragon Scale Cloth", 0.045),
                new ItemLoot("The World Tarot Card", 0.03),
                new ItemLoot("Wine Cellar Incantation", 0.01),
                new ItemLoot("Dragon Pearl", 0.08)
                )
            )

        .Init("lod Red Loot Balloon",
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
                new Threshold(0.15,
                new TierLoot(12, ItemType.Weapon, 0.045),
                new TierLoot(12, ItemType.Weapon, 0.05),
                new TierLoot(6, ItemType.Ability, 0.045),
                new TierLoot(5, ItemType.Ability, 0.065),
                new TierLoot(13, ItemType.Armor, 0.05),
                new ItemLoot("Ivory Ring", 0.05),
                new ItemLoot("Fire Dragon Battle Armor", 0.05),
                new ItemLoot("Large Red Dragon Scale Cloth", 0.045),
                new ItemLoot("Small Red Dragon Scale Cloth", 0.045),
                new ItemLoot("The World Tarot Card", 0.03),
                new ItemLoot("Wine Cellar Incantation", 0.01),
                new ItemLoot("Dragon Pearl", 0.08)
                )
            )

             /*   .Init("lod Ivory Loot",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.15,
                new TierLoot(12, ItemType.Weapon, 0.065),
                new TierLoot(12, ItemType.Weapon, 0.055),
                new TierLoot(6, ItemType.Ability, 0.065),
                new TierLoot(5, ItemType.Ability, 0.0685),
                new TierLoot(13, ItemType.Armor, 0.0525),
                new ItemLoot("Midnight Star", 0.04),
                new ItemLoot("Ivory Ring", 0.055),
                new ItemLoot("Large Ivory Dragon Scale Cloth", 0.045),
                new ItemLoot("Small Ivory Dragon Scale Cloth", 0.047),
                new ItemLoot("The World Tarot Card", 0.05),
                new ItemLoot("Wine Cellar Incantation", 0.02),
                new ItemLoot("Dragon Pearl", 0.1)
                )
            )*/

        //Dragon mini0ns & spawners
          .Init("NM Blue Dragon Minion",
                new State(
                       new Prioritize(
                           new Orbit(0.48, 2.5, 20, "NM Blue Dragon God", speedVariance: 0.1),
                           new Follow(0.25, 8, 1),
                           new Wander(0.11)
                         ),
                     new Shoot(8.4, count: 1, projectileIndex: 2, coolDown: 1100, coolDownOffset: 1500),
                     new Shoot(8.4, count: 1, projectileIndex: 2, coolDown: 2000)
                    )
            )
        .Init("NM Red Dragon Minion",
                new State(
                    new Prioritize(
                        new Follow(0.65, 8, 1),
                        new Swirl(0.3, 8, 10, targeted: false)
                        ),
                     new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 2760, coolDownOffset: 1500)
                    )
            )
          .Init("NM Red Dragon Lava Bomb",
                    new State(
                   new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ApplySetpiece("LavaSquare"),
                    new Suicide()
                    ))
          .Init("NM Red Dragon Lava Trigger",
                    new State(
                   new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ApplySetpiece("LavaSafe"),
                    new Suicide()
                    ))
         .Init("NM Black Dragon Minion",
            new State(
                new State("idle&heal",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                     new SetAltTexture(0),
                     new HealSelf(coolDown: new Cooldown(3500, 1000)),
                     new PlayerWithinTransition(3, "active")
                    ),
                new State("active",
                    new Wander(0.5),
                    new SetAltTexture(1),
                    new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 450),
                    new TimedTransition(3000, "idle&heal"),
                    new NoPlayerWithinTransition(3, "idle&heal")
                    )
                )
            )
        .Init("NM Black Dragon Shadow",
            new State(
                new Orbit(0.25, 3, 20, "NM Black Dragon God"),
                 new State("orbitandattack",
                    new Shoot(8.4, count: 2, shootAngle: 30, projectileIndex: 0, coolDown: 1450),
                    new Shoot(8.4, count: 2, shootAngle: 20, projectileIndex: 1, coolDown: 1750),
                    new HpLessTransition(0.11, "blam")
                    ),
                 new State("blam",
                    new Flash(0xFFFFFF, 2, 3),
                    new Shoot(8.4, count: 4, projectileIndex: 0, coolDown: 1000),
                    new Suicide()
                    )
                )
            )
          .Init("NM Green Dragon Minion",
                new State(
                     new Prioritize(
                            new Protect(0.5, "NM Blue Dragon God", protectionRange: 15, reprotectRange: 3),
                            new Follow(0.3, 8, 1),
                            new Wander(0.35)
                            ),
                     new Shoot(8.4, count: 1, projectileIndex: 2, coolDown: new Cooldown(1000, 700), coolDownOffset: 1500),
                     new Shoot(8.4, count: 1, projectileIndex: 2, coolDown: 1800)
                    )
            )
        .Init("NM Green Dragon Shield",
                new State(
                    new TransformOnDeath("NM Green Dragon Minion", 1, 1, 1),
                    new HealGroup(8, "Dragon Gods", coolDown: new Cooldown(3500, 1250), healAmount: 100),
                    new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: new Cooldown(1700, 560), coolDownOffset: 1500),
                     new Orbit(0.3, 3, 20, "NM Green Dragon God")
                    )
            )
              .Init("lod Mirror Wyvern1",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 1)
                    )
            )
              .Init("lod White Dragon Orb",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Shoot(8.4, count: 6, projectileIndex: 0, coolDown: 3000),
                    new Shoot(8.4, count: 6, projectileIndex: 1, coolDown: 2671)
                    )
            )
               .Init("lod Red Soul Flame",
                new State(
                    new Shoot(8.4, count: 6, shootAngle: 22, projectileIndex: 0, fixedAngle: 90, coolDown: new Cooldown(2000, 1000))
                    )
            )
               .Init("lod Green Soul Flame",
                new State(
                    new Shoot(8.4, count: 6, shootAngle: 22, projectileIndex: 0, fixedAngle: 90, coolDown: new Cooldown(2000, 1000))
                    )
            )
                .Init("lod Blue Soul Flame",
                new State(
                    new Shoot(8.4, count: 6, shootAngle: 22, projectileIndex: 0, fixedAngle: 90, coolDown: new Cooldown(2000, 1000))
                    )
            )
               .Init("lod Black Soul Flame",
                new State(
                    new Shoot(8.4, count: 6, shootAngle: 22, projectileIndex: 0, fixedAngle: 90, coolDown: new Cooldown(2000, 1000))
                    )
            )
        //Dragon b0sses

        //Nikao
        .Init("NM Blue Dragon God",
                new State(
                    new TransformOnDeath("lod Blue Loot Balloon", 1, 1, 1),
                    new HpLessTransition(0.12, "DyingPhase"),
                    new State("idle",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("NM Blue Dragon Soul", 9999, "Awakening")
                        ),
                    new State("Awakening",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Flash(0xFFFFFF, 2, 3),
                        new TimedTransition(4768, "mychildren")
                        ),
                    new State("mychildren",
                         new SetAltTexture(0),
                        new Taunt(0.80, "My children will feast on your soul!", "Look out! My minions will help me!", "If I don't kill you, my minions will!"),
                        new Spawn("NM Blue Dragon Minion", 2, 1, coolDown: 5000),
                        new Prioritize(
                             new Follow(0.75, 8, 1),
                             new StayBack(0.2, 4)
                            ),
                        new Shoot(10, count: 9, shootAngle: 26, projectileIndex: 3, predictive: 1.6, coolDown: 500),
                        new Shoot(10, count: 5, shootAngle: 20, projectileIndex: 1, coolDown: 2000),
                         new Shoot(10, count: 3, projectileIndex: 2, coolDown: 1570),
                        new TimedTransition(8950, "tastymostrels")
                        ),
                    new State("tastymostrels",
                        new Taunt(0.80, "You're a nasty little pest!", "You look like a tasty morsel! *SCREEEEEECH*"),
                        new Prioritize(
                             new StayBack(0.3, 3),
                             new Wander(0.12)
                            ),
                        new Shoot(10, count: 16, projectileIndex: 3, predictive: 1.5, coolDown: 1050),
                        new Shoot(10, count: 5, shootAngle: 20, projectileIndex: 1, predictive: 0.5, coolDown: 1475),
                        new TimedTransition(7450, "tastymostrels2")
                        ),
                    new State("tastymostrels2",
                        new Taunt(0.80, "You can not handle the full power of my onslaught"),
                        new Prioritize(
                            new Follow(0.885, 8, 1),
                            new StayBack(0.3, 3)
                            ),
                        new Shoot(10, count: 16, projectileIndex: 3, predictive: 2.25, coolDown: 2550),
                        new Shoot(10, count: 8, shootAngle: 20, projectileIndex: 3, predictive: 2.25, coolDown: 1250),
                        new Shoot(10, count: 5, shootAngle: 20, projectileIndex: 1, predictive: 0.5, coolDown: 1600),
                        new Shoot(10, count: 7, shootAngle: 18, projectileIndex: 2, coolDown: 2000, coolDownOffset: 2000),
                        new TimedTransition(9000, "returntospawn")
                        ),
                    new State("returntospawn",
                        new ReturnToSpawn(speed: 0.5),
                        new Shoot(10, count: 16, projectileIndex: 3, coolDown: 1000),
                        new TimedTransition(2000, "standandrek")
                        ),
                      new State("standandrek",
                        new Taunt(1.00, "You look tasty! I'm going to eat you!", "Yum! I can already taste you!"),
                        new Shoot(10, count: 21, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 5, shootAngle: 26, projectileIndex: 2, predictive: 0.5, coolDown: 500),
                        new Shoot(10, count: 3, shootAngle: 26, projectileIndex: 3, predictive: 4.5, coolDown: 1500),
                        new TimedTransition(8500, "mychildren")
                        ),
                   new State(
                      new ConditionalEffect(ConditionEffectIndex.Invincible),
                      new State("DyingPhase",
                        new RemoveEntity(9999, "NM Blue Dragon Minion"),
                        new ReturnToSpawn(speed: 0.3),
                        new Flash(0xFFFFFF, 2, 3),
                        new Taunt(1.00, "I have underestimated your power!", "WHY! YOU WERE GOING TO BE SO DELICIOUS IN MY STOMACH!"),
                        new TimedTransition(4750, "restinwater")
                        ),
                       new State("restinwater",
                        new Suicide()
                        )
                      )
                    )
                  )

        //Limoz
        .Init("NM Green Dragon God",
                new State(
                    new TransformOnDeath("lod Green Loot Balloon", 1, 1, 1),
                    new HpLessTransition(0.12, "DyingPhase"),
                    new State("idle",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("NM Green Dragon Soul", 9999, "Awakening")
                        ),
                    new State("Awakening",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Flash(0xFFFFFF, 2, 3),
                        new TimedTransition(4768, "myhide")
                        ),
                    new State("myhide",
                         new SetAltTexture(0),
                        new Taunt(1.00, "My own hide is but one of my defenses!", "My hide is tougher than your boots!"),
                        new TossObject("NM Green Dragon Shield", 4, 0, coolDown: 9999999),
                        new TossObject("NM Green Dragon Shield", 4, 45, coolDown: 9999999),
                        new TossObject("NM Green Dragon Shield", 4, 90, coolDown: 9999999),
                        new TossObject("NM Green Dragon Shield", 4, 135, coolDown: 9999999),
                        new TossObject("NM Green Dragon Shield", 4, 180, coolDown: 9999999),
                        new TossObject("NM Green Dragon Shield", 4, 225, coolDown: 9999999),
                        new TossObject("NM Green Dragon Shield", 4, 270, coolDown: 9999999),
                        new TossObject("NM Green Dragon Shield", 4, 315, coolDown: 9999999),
                        new InvisiToss("NM Green Dragon Minion", 4, 180, coolDown: 9999999),
                        new InvisiToss("NM Green Dragon Minion", 4, 225, coolDown: 9999999),
                        new InvisiToss("NM Green Dragon Minion", 4, 270, coolDown: 9999999),
                        new InvisiToss("NM Green Dragon Minion", 4, 315, coolDown: 9999999),
                        new TimedTransition(3250, "actualhidephase")
                        ),
                    new State("actualhidephase",
                        new Shoot(10, count: 12, projectileIndex: 0, coolDown: 1700),
                        new Shoot(10, count: 5, shootAngle: 20, projectileIndex: 1, predictive: 0.5, coolDown: 1475),
                        new Shoot(10, count: 2, shootAngle: 30, projectileIndex: 2, predictive: 0.5, coolDown: 1675),
                        new EntitiesNotExistsTransition(9999, "chaseandrek", "NM Green Dragon Shield")
                        ),
                    new State("chaseandrek",
                        new Taunt(0.80, "Taste my wrath!"),
                        new InvisiToss("NM Green Dragon Minion", 4, 180, coolDown: 9999999),
                        new InvisiToss("NM Green Dragon Minion", 4, 225, coolDown: 9999999),
                        new InvisiToss("NM Green Dragon Minion", 4, 270, coolDown: 9999999),
                        new InvisiToss("NM Green Dragon Minion", 4, 315, coolDown: 9999999),
                        new Follow(0.78, 8, 1),
                        new Shoot(10, count: 12, projectileIndex: 0, coolDown: new Cooldown(1000, 500)),
                        new Shoot(10, count: 7, shootAngle: 38, projectileIndex: 4, predictive: 0.5, coolDown: 325),
                        new Shoot(10, count: 5, shootAngle: 38, projectileIndex: 1, predictive: 0.5, coolDown: 325),
                        new TimedTransition(9000, "returntospawn")
                        ),
                    new State("returntospawn",
                        new ReturnToSpawn(speed: 0.5),
                        new Shoot(10, count: 10, projectileIndex: 0, coolDown: 500),
                        new Shoot(10, count: 10, shootAngle: 40, projectileIndex: 1, coolDown: 500),
                        new TimedTransition(2750, "standandrek")
                        ),
                      new State("standandrek",
                        new Taunt(1.00, "Give me strength!", "I will fight until death!"),
                        new TimedTransition(2500, "SpinShot")
                        ),
                      new State("SpinShot",
                        new Shoot(10, count: 10, projectileIndex: 0, predictive: 2.25, coolDown: 1000),
                        new TimedTransition(3000, "myhide"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Quadforce1")
                        )
                    ),
                   new State(
                      new ConditionalEffect(ConditionEffectIndex.Invincible),
                      new State("DyingPhase",
                        new RemoveEntity(9999, "NM Green Dragon Minion"),
                        new RemoveEntity(9999, "NM Green Dragon Shield"),
                        new ReturnToSpawn(speed: 0.3),
                        new Flash(0xFFFFFF, 2, 3),
                        new Taunt(1.00, "Flee my servants, I can protect you no longer!", "The salad was too bad for me."),
                        new TimedTransition(4750, "restinhides")
                        ),
                       new State("restinhides",
                        new Suicide()
                        )
                      )
                    )
            )

        //Feargus
        .Init("NM Black Dragon God",
                new State(
                    new TransformOnDeath("lod Black Loot Balloon", 1, 1, 1),
                    new HpLessTransition(0.12, "DyingPhase"),
                    new State("idle",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("NM Black Dragon Soul", 9999, "Awakening")
                        ),
                    new State("Awakening",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Flash(0xFFFFFF, 2, 3),
                        new TimedTransition(4768, "backandforth")
                        ),
                  new State("backandforth",
                      new Shoot(10, count: 8, shootAngle: 28, projectileIndex: 6, coolDown: 3451),
                      new Shoot(10, count: 5, shootAngle: 28, projectileIndex: 5, coolDown: 2600),
                      new Shoot(10, count: 3, shootAngle: 28, projectileIndex: 7, coolDown: 2982),
                      new TimedTransition(8875, "spawnshades"),
                       new State("2",
                        new SetAltTexture(0),
                        new Taunt(1.00, "Prepare to meet your doom! There is no mercy here."),
                        new Prioritize(
                             new Follow(0.34, 8, 1),
                             new StayBack(0.3, 5)
                            ),
                        new Shoot(10, count: 12, projectileIndex: 0, coolDown: 3000),
                        new Shoot(10, count: 6, shootAngle: 60, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 2, projectileIndex: 1, coolDown: 1500),
                        new TimedTransition(3250, "1")
                        ),
                     new State("1",
                        new SetAltTexture(0),
                        new Grenade(5, 100, range: 6, coolDown: 2000),
                        new ReturnToSpawn(speed: 0.4),
                        new Shoot(10, count: 8, shootAngle: 28, projectileIndex: 6, coolDown: 2600),
                        new Shoot(10, count: 2, shootAngle: 36, projectileIndex: 0, coolDown: 3000),
                        new Shoot(10, count: 8, shootAngle: 60, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 2, projectileIndex: 1, coolDown: 1500),
                        new TimedTransition(3250, "2")
                         )
                        ),
                    new State("spawnshades",
                        new InvisiToss("NM Black Dragon Shadow", 4, 180, coolDown: 9999999),
                        new InvisiToss("NM Black Dragon Shadow", 4, 225, coolDown: 9999999),
                        new TimedTransition(500, "shadesandrek")
                        ),
                  new State("shadesandrek",
                                            new Shoot(10, count: 8, shootAngle: 28, projectileIndex: 6, coolDown: 3451),
                      new Shoot(10, count: 5, shootAngle: 28, projectileIndex: 5, coolDown: 2600),
                      new Shoot(10, count: 3, shootAngle: 28, projectileIndex: 7, coolDown: 2982),
                      new TimedTransition(12875, "returntospawn"),
                    new State("1",
                        new SetAltTexture(0),
                        new Taunt(0.80, "I shall devour you whole."),
                        new Prioritize(
                             new Follow(0.34, 8, 1),
                             new StayBack(0.3, 5)
                            ),
                        new Shoot(10, count: 12, projectileIndex: 0, coolDown: 3000),
                        new Shoot(10, count: 6, shootAngle: 60, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 2, projectileIndex: 1, coolDown: 1000),
                        new Shoot(10, count: 2, projectileIndex: 3, predictive: 2, coolDown: 2500),
                        new TimedTransition(3250, "2")
                        ),
                     new State("2",
                        new SetAltTexture(0),
                        new ReturnToSpawn(speed: 0.4),
                        new Shoot(10, count: 2, shootAngle: 36, projectileIndex: 0, coolDown: 3000),
                        new Shoot(10, count: 8, shootAngle: 60, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 2, projectileIndex: 1, coolDown: 1500),
                        new Shoot(10, count: 2, projectileIndex: 3, predictive: 2, coolDown: 1700),
                        new Grenade(5, 100, range: 6, coolDown: 2000),
                        new TimedTransition(3250, "1")
                         )
                        ),
                    new State("returntospawn",
                        new ReturnToSpawn(speed: 0.5),
                        new Shoot(10, count: 4, shootAngle: 36, projectileIndex: 3, coolDown: 3000),
                        new TimedTransition(2000, "invisibleattack")
                        ),
                      new State("invisibleattack",
                       new Shoot(10, count: 8, shootAngle: 28, projectileIndex: 6, coolDown: 2600),
                       new SetAltTexture(2),
                       new Wander(0.2),
                       new RemoveEntity(9999, "NM Black Dragon Shadow"),
                       new ConditionalEffect(ConditionEffectIndex.Invincible),
                       new Shoot(10, count: 2, shootAngle: 36, projectileIndex: 0, coolDown: 3000),
                        new Shoot(10, count: 8, shootAngle: 60, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 2, projectileIndex: 1, coolDown: 1500),
                        new Shoot(10, count: 2, projectileIndex: 3, predictive: 2, coolDown: 1700),
                        new TimedTransition(7000, "backandforth")
                        ),
                   new State(
                      new ConditionalEffect(ConditionEffectIndex.Invincible),
                      new State("DyingPhase",
                        new RemoveEntity(9999, "NM Black Dragon Shadow"),
                        new RemoveEntity(9999, "NM Black Dragon Minion"),
                        new ReturnToSpawn(speed: 0.3),
                        new Flash(0xFFFFFF, 2, 3),
                        new Taunt(1.00, "Until we meet again...sub-creature..."),
                        new TimedTransition(4750, "restindark")
                        ),
                       new State("restindark",
                        new Suicide()
                        )
                      )
                    )
            )
        //Pyyr
        .Init("NM Red Dragon God",
                new State(
                    new TransformOnDeath("lod Red Loot Balloon", 1, 1, 1),
                    new HpLessTransition(0.12, "DyingPhase"),
                    new State("idle",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityNotExistsTransition("NM Red Dragon Soul", 9999, "Awakening")
                        ),
                    new State("Awakening",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Flash(0xFFFFFF, 2, 3),
                        new TimedTransition(4768, "mychildren")
                        ),
                    new State("mychildren",
                        new SetAltTexture(0),
                        new TimedTransition(3000, "shootbigballs")
                      ),
                    new State("shootbigballs",
                        new Reproduce("NM Red Dragon Minion", 5, 5, coolDown: 4750),
                        new ReturnToSpawn(speed: 0.6),
                        new Shoot(10, count: 9, projectileIndex: 0, coolDown: 2500),
                        new Shoot(10, count: 12, projectileIndex: 1, coolDown: 5000),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(6000, "chase")
                        ),
                    new State("chase",
                        new Taunt(1.00, "Eat these delicious flames and balls!", "Fire is my favorite!"),
                        new Prioritize(
                            new Follow(0.885, 8, 1),
                            new StayBack(0.3, 3)
                            ),
                        new Shoot(10, count: 12, projectileIndex: 3, predictive: 2.25, coolDown: 2550),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 0, coolDown: 3250),
                        new TimedTransition(9000, "breath")
                        ),
                    new State("breath",
                        new Taunt(1.00, "I shall breathe straight fire onto you!", "Check out this mixtape!"),
                        new Swirl(1.10, 5, 8, false),
                        new Shoot(10, count: 3, shootAngle: 3, projectileIndex: 0, coolDown: 1),
                        new TimedTransition(7500, "breatah")
                        ),
                   new State("breatah",
                        new Taunt(1.00, "You can't stop the FLAMING FIRESZ!"),
                        new Wander(1),
                        new Shoot(10, count: 18, shootAngle: 3, projectileIndex: 1, coolDown: 1500),
                        new TimedTransition(6000, "shootbigballs")
                        ),
                   new State(
                      new ConditionalEffect(ConditionEffectIndex.Invincible),
                      new State("DyingPhase",
                        new RemoveEntity(9999, "NM Red Dragon Minion"),
                        new ReturnToSpawn(speed: 0.3),
                        new Flash(0xFFFFFF, 2, 3),
                        new Taunt(1.00, "The flame has been put out! Darn."),
                        new TimedTransition(4750, "restinwater")
                        ),
                       new State("restinwater",
                        new Suicide()
                        )
                      )
                    )
                  )

            .Init("lod Ivory Wyvern",
                new State(
                    new RealmPortalDrop(),
                    //new TransformOnDeath("lod Ivory Loot", 1, 1, 1),
                    new HpLessTransition(0.11, "ripwyvern"),
                    new RealmPortalDrop(),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(7, "talk1")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("talk1",
                        new Taunt(1.00, "Thank you adventurer, you have freed the souls of the four dragons so that I may consume their powers."),
                        new TimedTransition(4500, "talk2")
                        ),
                   new State("talk2",
                        new Taunt(1.00, "I owe you much, but I cannot let you leave. These walls will make a fine graveyard for your bones."),
                        new TimedTransition(4500, "talk3")
                            ),
                   new State("talk3",
                        new Taunt(1.00, "Behold the glory of my true powers!", "Time to munch on you like potato chips."),
                        new TimedTransition(2000, "Mirrors")
                            )
                        ),
                    new State("Mirrors",
                        new BackAndForth(0.35, 10),
                        new TossObject("lod Mirror Wyvern1", 10, angle: 180, coolDown: 99999),
                        new TossObject("lod Mirror Wyvern1", 6, angle: 180, coolDown: 99999),
                        new TossObject("lod Mirror Wyvern1", 10, angle: 0, coolDown: 99999),
                        new TossObject("lod Mirror Wyvern1", 5, angle: 0, coolDown: 99999),
                        new Shoot(8.4, count: 7, shootAngle: 16, projectileIndex: 0, coolDown: 1),
                        new DamageTakenTransition(14000, "movetothemiddle2")
                        ),
                    new State("movetothemiddle2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new MoveTo(speed: 0.5f, x: 13, y: 5),
                        new Taunt("Look at these beautiful flames!"),
                        new TimedTransition(2000, "Flames")
                        ),
                    new State("Flames",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new RemoveEntity(9999, "lod Mirror Wyvern1"),
                        new TossObject("lod Black Soul Flame", 10, angle: 180, coolDown: 99999),
                        new TossObject("lod Red Soul Flame", 6, angle: 180, coolDown: 99999),
                        new TossObject("lod Green Soul Flame", 10, angle: 0, coolDown: 99999),
                        new TossObject("lod Blue Soul Flame", 5, angle: 0, coolDown: 99999),
                        new TimedTransition(2000, "checkforflames")
                        ),
                    new State(
                         new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("checkforflames",
                        new EntitiesNotExistsTransition(9999, "movetothemiddle", "lod Black Soul Flame", "lod Blue Soul Flame", "lod Red Soul Flame", "lod Green Soul Flame")
                        ),
                    new State("movetothemiddle",

                        new MoveTo(speed: 0.5f, x: 13, y: 16),
                        new Taunt("You darith try to beatith me ith, preparith to dieith in theith Ivoryith Wyvernith where youith will cryith everyith timeith."),
                        new TimedTransition(4000, "alldshots")
                        )
                        ),
                    new State("alldshots",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HealSelf(coolDown: 1750, amount: 1000),
                        new Shoot(8.4, count: 10, shootAngle: 14, projectileIndex: 0, coolDown: 3500),
                        new Shoot(8.4, count: 8, shootAngle: 10, fixedAngle: 45, projectileIndex: 1, coolDown: 2000),
                        new Shoot(8.4, count: 8, shootAngle: 10, fixedAngle: 135, projectileIndex: 2, coolDown: 2000),
                        new Shoot(8.4, count: 8, shootAngle: 10, fixedAngle: 225, projectileIndex: 3, coolDown: 2000),
                        new Shoot(8.4, count: 8, shootAngle: 10, fixedAngle: 315, projectileIndex: 4, coolDown: 2000),
                        new TimedTransition(8250, "whiteorbs")
                        ),
                    new State("whiteorbs",

                        new TossObject("lod White Dragon Orb", 10, angle: 45, coolDown: 99999),
                        new TossObject("lod White Dragon Orb", 10, angle: 135, coolDown: 99999),
                        new TossObject("lod White Dragon Orb", 10, angle: 225, coolDown: 99999),
                        new TossObject("lod White Dragon Orb", 10, angle: 315, coolDown: 99999),
                        new TossObject("lod White Dragon Orb", 10, angle: 90, coolDown: 99999),
                        new TossObject("lod White Dragon Orb", 10, angle: 0, coolDown: 99999),
                        new TossObject("lod White Dragon Orb", 10, angle: 180, coolDown: 99999),
                        new TossObject("lod White Dragon Orb", 10, angle: 270, coolDown: 99999),
                        new TimedTransition(2000, "chaseandfight")
                        ),
                    new State("chaseandfight",
                        new Follow(0.2, 8, 1),
                        new Shoot(8.4, count: 12, shootAngle: 14, projectileIndex: 0, coolDown: 6000),
                        new Shoot(8.4, count: 24, projectileIndex: 0, coolDown: 10000),
                        new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 4812),
                        new Shoot(8.4, count: 1, projectileIndex: 1, coolDown: 6812),
                        new Shoot(8.4, count: 1, projectileIndex: 2, coolDown: 8912),
                        new Shoot(8.4, count: 1, projectileIndex: 3, coolDown: 7212),
                        new Shoot(8.4, count: 1, projectileIndex: 4, coolDown: 9812)
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                   new State("ripwyvern",
                       new RemoveEntity(9999, "lod White Dragon Orb"),
                        new MoveTo(speed: 0.5f, x: 13, y: 16),
                        new Taunt("You may have beaten me this time, but I will find a way to leave this place! And on that day, you will suffer greatly!"),
                        new TimedTransition(3000, "rip4evs")
                        ),
                      new State("rip4evs",
                        new Suicide()
                        )
                    )

                ),
                                new MostDamagers(3,
                    LootTemplates.SFLow()
                    ),
                new Threshold(0.15,
                    new ItemLoot("Greater Potion of Dexterity", 0.3),
                    new ItemLoot("Greater Potion of Wisdom", 0.3),
                    new TierLoot(12, ItemType.Weapon, 0.065),
                    new TierLoot(12, ItemType.Weapon, 0.055),
                    new TierLoot(6, ItemType.Ability, 0.065),
                    new TierLoot(5, ItemType.Ability, 0.0685),
                    new TierLoot(13, ItemType.Armor, 0.0525),
                    new ItemLoot("Midnight Star", 0.04),
                    new ItemLoot("Ivory Ring", 0.055),
                    new ItemLoot("Large Ivory Dragon Scale Cloth", 0.045),
                    new ItemLoot("Small Ivory Dragon Scale Cloth", 0.047)
            )
            )
;
    }
}