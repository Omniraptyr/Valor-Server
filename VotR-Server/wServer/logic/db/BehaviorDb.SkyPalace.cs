using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ SkyPalace = () => Behav()
            .Init("Colothiois the Exalted",
                new State(
                    new State("default",
                        new ScaleHP(55000),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(10, "talk")
                        ),
                    new State("talk",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("Welcome to paradise... Oh, paradise for me that is; you all will die here!"),
                        new Flash(0xff0000, 5, 0),
                        new TimedTransition(5000, "begin")
                        ),
                    new State("begin",
                        new InvisiToss("Elemental Cloud", range: 1, angle: 0, coolDown: 20000),
                        new InvisiToss("Elemental Cloud", range: 2, angle: 90, coolDown: 20000),
                        new InvisiToss("Elemental Cloud", range: 3, angle: 180, coolDown: 20000),
                        new InvisiToss("Elemental Cloud", range: 4, angle: 270, coolDown: 20000),
                        new Shoot(15, 1, rotateAngle: 24, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 45, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 62, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 87, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 125, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 148, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 169, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 183, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 214, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 236, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 276, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 301, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 315, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 336, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 348, coolDown: 150),
                        new Shoot(15, 1, rotateAngle: 363, coolDown: 150),
                        new HpLessTransition(0.75, "pew")
                        ),
                    new State("pew",
                        new Shoot(10, count: 33, projectileIndex: 1, rotateAngle: 30, shootAngle: 10, coolDown: 500, fixedAngle: 270),
                        new Shoot(10, count: 3, projectileIndex: 0, shootAngle: 30, predictive: 0.25, coolDown: 1800, coolDownOffset: 1000),
                        new ReplaceTile("Sky Palace floor3", "Tod Lava", 200),
                        new HpLessTransition(0.33, "fight")
                        ),
                    new State("fight",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Elemental Turret1", 10, 315, coolDown: 100000),
                        new TossObject("Elemental Turret2", 10, 45, coolDown: 100000),
                        new TossObject("Elemental Turret3", 10, 135, coolDown: 100000),
                        new TossObject("Elemental Turret4", 10, 225, coolDown: 100000),
                        new TimedTransition(5000, "waitingforturret")
                        ),
                    new State("waitingforturret",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntitiesNotExistsTransition(200, "rage", "Elemental Turret1", "Elemental Turret2", "Elemental Turret3", "Elemental Turret4")
                        ),
                    new State("rage",
                        new Shoot(10, count: 9, projectileIndex: 1, rotateAngle: 90, shootAngle: 10, coolDown: 1000, fixedAngle: 270),
                        new Shoot(10, count: 9, projectileIndex: 0, rotateAngle: 90, shootAngle: 10, coolDown: 1000, fixedAngle: 180),
                        new InvisiToss("Elemental Cloud", range: 1, angle: 0, coolDown: 20000),
                        new InvisiToss("Elemental Cloud", range: 2, angle: 90, coolDown: 20000),
                        new InvisiToss("Elemental Cloud", range: 3, angle: 180, coolDown: 20000),
                        new InvisiToss("Elemental Cloud", range: 4, angle: 270, coolDown: 20000),
                        new Grenade(2, 100, range: 6, fixedAngle: 45, coolDown: 2000, color: 0xFFFF00),
                        new Grenade(2, 100, range: 6, fixedAngle: 135, coolDown: 2000, color: 0xFFFF00),
                        new Grenade(2, 100, range: 6, fixedAngle: 225, coolDown: 2000, color: 0xFFFF00),
                        new Grenade(2, 100, range: 6, fixedAngle: 315, coolDown: 2000, color: 0xFFFF00),
                        new Grenade(2, 100, range: 6, fixedAngle: 90, coolDown: 4000, color: 0xFFFF00),
                        new Grenade(2, 100, range: 6, fixedAngle: 180, coolDown: 4000, color: 0xFFFF00),
                        new Grenade(2, 100, range: 6, fixedAngle: 270, coolDown: 4000, color: 0xFFFF00),
                        new Grenade(2, 100, range: 6, fixedAngle: 360, coolDown: 4000, color: 0xFFFF00)
                        )
                     ),
                     new MostDamagers(3,
                        LootTemplates.Sor1Perc()
                    ),
                 new Threshold(0.15,
                     new ItemLoot("Thunder and Lightning", 0.005),
                     new ItemLoot("Seal of Sky Serenade", 0.005),
                     new ItemLoot("Potion of Dexterity", 1.0),
                     new ItemLoot("Potion of Mana", 1.0),
                     new TierLoot(3, ItemType.Ring, 0.2),
                     new TierLoot(7, ItemType.Armor, 0.2),
                     new TierLoot(8, ItemType.Weapon, 0.2),
                     new TierLoot(4, ItemType.Ability, 0.1),
                     new TierLoot(8, ItemType.Armor, 0.1),
                     new TierLoot(4, ItemType.Ring, 0.05),
                     new TierLoot(9, ItemType.Armor, 0.03),
                     new TierLoot(5, ItemType.Ability, 0.03),
                     new TierLoot(9, ItemType.Weapon, 0.03),
                     new TierLoot(10, ItemType.Armor, 0.02),
                     new TierLoot(10, ItemType.Weapon, 0.02),
                     new TierLoot(11, ItemType.Armor, 0.01),
                     new TierLoot(11, ItemType.Weapon, 0.01),
                     new TierLoot(5, ItemType.Ring, 0.01)
                 )
            )
            .Init("Elemental Cloud",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("begin",
                        new SetAltTexture(0),
                        new Orbit(0.5, 3, target: "Colothiois the Exalted"),
                        new Charge(3, 6, coolDown: 1000),
                        new Swirl(1, 4, targeted: false),
                        new PlayerWithinTransition(1, "zap"),
                        new EntitiesNotExistsTransition(20, "death", "Colothiois the Exalted")
                        ),
                    new State("zap",
                        new SetAltTexture(1),
                        new Flash(0xFFFF00, 4, 4),
                        new Shoot(10, 1, coolDown: 5000),
                        new TimedTransition(2500, "death")
                        ),
                    new State("death",
                        new Suicide()
                        )
            )
            )
        .Init("Elemental Turret1",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Armored),
                new ScaleHP(3000),
                new State("shoot",
                    new Shoot(10, 1, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 90, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 105, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 120, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 150, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 165, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 180, coolDown: 1400)
                    )
                )
            )
        .Init("Elemental Turret2",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Armored),
                new ScaleHP(3000),
                new State("shoot",
                    new Shoot(10, 1, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 180, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 195, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 210, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 240, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 255, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 270, coolDown: 1400)
                    )
                )
            )
        .Init("Elemental Turret3",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Armored),
                new ScaleHP(3000),
                new State("shoot",
                    new Shoot(10, 1, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 270, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 285, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 300, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 330, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 345, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 360, coolDown: 1400)
                    )
                )
            )
        .Init("Elemental Turret4",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Armored),
                new ScaleHP(3000),
                new State("shoot",
                    new Shoot(10, 1, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 0, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 15, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 30, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 60, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 75, coolDown: 1400),
                    new Shoot(10, 1, fixedAngle: 90, coolDown: 1400)
                    )
                )
            )
         .Init("Tod",
            new State(
                new ScaleHP(50000),
                new DropPortalOnDeath("Sky Palace Portal"),
                new State("shoot",
                    new Taunt("Skrrt"),
                    new Wander(0.4),
                    new Shoot(10, 1, angleOffset: 0, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 320, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 330, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 340, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 350, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 10, coolDown: 2000, projectileIndex: 1),
                    new Shoot(10, 1, angleOffset: 20, coolDown: 2000, projectileIndex: 1),
                    new Shoot(10, 1, angleOffset: 30, coolDown: 2000, projectileIndex: 1),
                    new Shoot(10, 1, angleOffset: 40, coolDown: 2000, projectileIndex: 1),
                    new HpLessTransition(0.75, "wowokay")
                    ),
                new State("wowokay",
                    new Follow(1, 8, 1),
                    new Shoot(10, 1, angleOffset: 0, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 320, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 330, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 340, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 350, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 10, coolDown: 2000, projectileIndex: 1),
                    new Shoot(10, 1, angleOffset: 20, coolDown: 2000, projectileIndex: 1),
                    new Shoot(10, 1, angleOffset: 30, coolDown: 2000, projectileIndex: 1),
                    new Shoot(10, 1, angleOffset: 40, coolDown: 2000, projectileIndex: 1),
                    new HpLessTransition(0.35, "wellthen")
                    ),
                new State("wellthen",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ReturnToSpawn(2),
                    new TimedTransition(3000, "skrrt")
                    ),
                new State("skrrt",
                    new Order(50, "TLava Spawner", "activate"),
                    new TimedTransition(2000, "chasebutnotomni")
                        ),
                new State("chasebutnotomni",
                    new Follow(1.1, 8, 1),
                    new Shoot(10, 1, angleOffset: 0, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 320, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 330, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 340, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 350, coolDown: 2000, projectileIndex: 0),
                    new Shoot(10, 1, angleOffset: 10, coolDown: 2000, projectileIndex: 1),
                    new Shoot(10, 1, angleOffset: 20, coolDown: 2000, projectileIndex: 1),
                    new Shoot(10, 1, angleOffset: 30, coolDown: 2000, projectileIndex: 1),
                    new Shoot(10, 1, angleOffset: 40, coolDown: 2000, projectileIndex: 1),
                    new Shoot(10, 2, shootAngle: 12, angleOffset: 24, coolDown: 2000, projectileIndex: 2),
                    new Shoot(10, 2, shootAngle: 12, angleOffset: 48, coolDown: 2000, projectileIndex: 2),
                    new Shoot(10, 2, shootAngle: 12, angleOffset: 336, coolDown: 2000, projectileIndex: 3),
                    new Shoot(10, 2, shootAngle: 12, angleOffset: 312, coolDown: 2000, projectileIndex: 3),
                    new HpLessTransition(0.05, "dying")
                    ),
                new State("dying",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new ReturnToSpawn(2),
                    new Taunt("Time to join the others..."),
                    new TimedTransition(3000, "deadboy")
                    ),
                new State("deadboy",
                    new Suicide()
                    )
                ),
               new MostDamagers(3,
                     LootTemplates.StatPots()
                     ),
               new MostDamagers(3,
                        LootTemplates.Sor1Perc()
                    ),
                 new Threshold(0.15,
                     new ItemLoot("Sky Tome", 0.005),
                     new TierLoot(3, ItemType.Ring, 0.2),
                     new TierLoot(7, ItemType.Armor, 0.2),
                     new TierLoot(8, ItemType.Weapon, 0.2),
                     new TierLoot(4, ItemType.Ability, 0.1),
                     new TierLoot(8, ItemType.Armor, 0.1),
                     new TierLoot(4, ItemType.Ring, 0.05),
                     new TierLoot(9, ItemType.Armor, 0.03),
                     new TierLoot(5, ItemType.Ability, 0.03),
                     new TierLoot(9, ItemType.Weapon, 0.03),
                     new TierLoot(10, ItemType.Armor, 0.02),
                     new TierLoot(10, ItemType.Weapon, 0.02),
                     new TierLoot(11, ItemType.Armor, 0.01),
                     new TierLoot(11, ItemType.Weapon, 0.01),
                     new TierLoot(5, ItemType.Ring, 0.01)
                 )
            )
        .Init("TLava Spawner",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("wait",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                new State("activate",
                    new ApplySetpiece("TLava"),
                    new Suicide()
                    )
                )
            )
        .Init("Tod Spike",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )
            .Init("Zeus",
                 new State(
                     new ScaleHP(35000),
                     new TimedTransition(6000, "wait"),
                     new State("wait",
                     new PlayerWithinTransition(7, "move")
                         ),
                     new State("move",
                         new Wander(0.1),
                         new Shoot(20, 1, coolDown: 1500),
                         new Shoot(20, count: 14, projectileIndex: 1, coolDown: 1700),
                         new Spawn("Zeus Cloud", 5, coolDown: 5000)
                         )
                     ),
                     new MostDamagers(3,
                         LootTemplates.SorRare()
                         ),
                     new Threshold(0.025,
                         new ItemLoot("Thunder and Lightning", 0.001),
                         new ItemLoot("Seal of Sky Serenade", 0.001),
                         new ItemLoot("Potion of Dexterity", 1.0)
                     )
            )
            .Init("Zeus Cloud",
                   new State(
                       new State("fight",
                           new Orbit(1.5, 5, target: "Zeus", orbitClockwise: true),
                           new Shoot(20, count: 7, projectileIndex: 0, coolDown: 600),
                           new TimedTransition(2500, "switch")
                           ),
                       new State("switch",
                           new Orbit(1.5, 5, target: "Zeus", orbitClockwise: false),
                           new Shoot(20, count: 7, projectileIndex: 0, coolDown: 600),
                           new TimedTransition(2500, "fight")
                           )
                       )
                )
            .Init("Cloud Elemental",
                new State(
                    new State("shotgun",
                        new Follow(0.5, 8, 1),
                        new Shoot(10, 6, coolDown: 2500, projectileIndex: 0),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1, coolDown: 1500),
                        new TimedTransition(10000, "turret")
                        ),
                    new State("turret",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Flash(0xFFFF00, 4, 4),
                        new Shoot(10, count: 8, projectileIndex: 1, rotateAngle: 60, shootAngle: 20, coolDown: 500, fixedAngle: 270),
                        new Shoot(10, count: 8, projectileIndex: 1, rotateAngle: 60, shootAngle: 20, coolDown: 1000, fixedAngle: 90)
                        )

                    )
            )
            .Init("Angel",
            new State(
                new State("shots",
                    new Wander(0.1),
                    new Shoot(15, 1, coolDown: 750),
                    new TimedTransition(3750, "charge")
                    ),
                new State("charge",
                    new Charge(2, 6, coolDown: 6000),
                    new Shoot(15, 5, shootAngle: 15, coolDown: 6000),
                    new TimedTransition(1000, "shots")
                    )
                )
            )
            .Init("Angel2",
            new State(
                new State("grenades",
                    new Wander(0.1),
                    new Grenade(5, 65, range: 5, coolDown: 1000),
                    new TimedTransition(3000, "ubermode")
                    ),
                new State("ubermode",
                    new Grenade(7, 100, range: 5, coolDown: 350),
                    new TimedTransition(1750, "grenades")
                    )
                )
            )
            ;
    }
}