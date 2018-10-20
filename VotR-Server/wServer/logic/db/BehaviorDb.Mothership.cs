using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Mothership = () => Behav()
        .Init("Alive Electric",
            new State(

                new State("Fight",
                    new Prioritize(
                        new Protect(0.6, "The Mothership", 10, 4),
                        new Wander(0.05)
                     ),
                     new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: new Cooldown(2600, 500)),
                     new TimedTransition(5200, "MovementChange")
                    ),
                new State("MovementChange",
                     new Follow(0.8, 8, 1),
                     new Shoot(8.4, count: 3, shootAngle: 14, projectileIndex: 0, coolDown: 3000),
                     new TimedTransition(3000, "Fight")
                    )
                )
            )
       .Init("UFO Shadow Turret",
         new State(
             new State(
                 new EntitiesNotExistsTransition(30, "Disabled", "The Mothership"),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Idle"
                    ),
                new State("ShootA",
                     new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 2000),
                     new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 2000),
                     new Shoot(8.4, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 2000),
                     new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 2000),
                     new TimedTransition(8000, "ShootB")
                    ),
                new State("ShootB",
                     new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 2000),
                     new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 2000),
                     new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 2000),
                     new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 2000),
                     new TimedTransition(8000, "ShootA")
                    )
                 ),
                new State("Disabled",
                    new Suicide()
                    )
                )
            )
        .Init("The Mothership",
                new State(
                    new ScaleHP(90000),
                    new DropPortalOnDeath("Galactic Plateau Portal"),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(6, "taunt1")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("taunt1",
                        new Flash(0x00FF00, 1, 2),
                        new TimedTransition(3600, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt("Commence Operation Destroy and Eliminate. C.O.D.E.", "We will erase you for eternity."),
                        new TimedTransition(5000, "taunt3")
                        ),
                    new State("taunt3",
                        new Taunt("Zrrrrt..."),
                        new TimedTransition(6000, "fight1")
                        )
                     ),
                    new State(
                    new HpLessTransition(0.5, "Overdrive"),
                    new State("fight1",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 3),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 5, shootAngle: 12, projectileIndex: 2, coolDown: new Cooldown(1000, 2000)),
                        new Shoot(10, count: 9, shootAngle: 8, projectileIndex: 3, predictive: 0.3, coolDown: 3000, coolDownOffset: 1000),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 1, coolDown: 1000),
                        new TimedTransition(8000, "fight2")
                        ),
                    new State("fight2",
                        new HealSelf(coolDown: 2000, amount: 100),
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 3),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 12, shootAngle: 8, projectileIndex: 2, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, count: 1, projectileIndex: 3, predictive: 0.5, coolDown: new Cooldown(200, 200)),
                        new TimedTransition(8000, "followabit1")
                        ),
                    new State("followabit1",
                        new Prioritize(
                            new Follow(0.3, 8, 1),
                            new StayCloseToSpawn(0.5, 3)
                        ),
                        new Shoot(10, count: 7, shootAngle: 14, projectileIndex: 1, coolDown: 1000),
                        new TimedTransition(3000, "GoBackHome2")
                        ),
                    new State("GoBackHome2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(speed: 0.6),
                        new TimedTransition(3600, "fight3")
                        ),
                    new State("fight3",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 3),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 1, predictive: 1, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 3, shootAngle: 20, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 10, projectileIndex: 1, coolDown: 3000),
                        new TimedTransition(6000, "GoBackHome1")
                        ),
                    new State("GoBackHome1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(speed: 0.6),
                        new TimedTransition(3600, "chargingshock")
                        ),
                    new State("chargingshock",
                        new Taunt("*Loud Mechanized Sound*"),
                        new Flash(0x000000, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.2, 2),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 5, projectileIndex: 2, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(10, count: 7, projectileIndex: 1, coolDown: 2500),
                        new Shoot(10, count: 1, projectileIndex: 3, coolDown: 400),
                        new TimedTransition(5000, "followabit2")
                        ),
                    new State("followabit2",
                        new Prioritize(
                            new Follow(0.25, 8, 1),
                            new StayCloseToSpawn(0.5, 3)
                        ),
                        new Shoot(10, count: 14, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(4000, "rumble1")
                        ),
                    new State("rumble1",
                        new Prioritize(
                            new StayCloseToSpawn(0.2, 2),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 10, shootAngle: 7, projectileIndex: 0, coolDown: 4000, coolDownOffset: 1000),
                        new Shoot(10, count: 4, shootAngle: 16, projectileIndex: 2, coolDown: new Cooldown(500, 3000)),
                        new TimedTransition(7400, "fight1")
                        )
                     ),

                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Overdrive",
                        new HealSelf(coolDown: 5000, amount: 60000),
                        new Flash(0x00FFFF, 1, 2),
                        new ReturnToSpawn(speed: 0.6),
                        new TimedTransition(5200, "OverdriveTaunt")
                        ),
                    new State("OverdriveTaunt",
                        new Taunt("Begin Overdrive..."),
                        new TimedTransition(4000, "Go")
                        ),
                    new State("Go",
                        new Taunt("Overdrive activated."),
                        new TimedTransition(5000, "Zfight1")
                        )
                     ),
                    new State(
                        new Order(999, "UFO Shadow Turret", "ShootA"),
                        new Reproduce("Alive Electric", densityMax: 4, coolDown: 4400),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                    new State("Zfight1",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 3),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 7, shootAngle: 12, projectileIndex: 2, coolDown: new Cooldown(1000, 2000)),
                        new Shoot(10, count: 13, shootAngle: 8, projectileIndex: 3, predictive: 0.3, coolDown: 3000, coolDownOffset: 1000),
                        new TimedTransition(8000, "Zfight2")
                        ),
                    new State("Zfight2",
                        new HealSelf(coolDown: 2000, amount: 100),
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 3),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 16, shootAngle: 8, projectileIndex: 2, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, count: 5, projectileIndex: 3, predictive: 0.5, coolDown: new Cooldown(200, 200)),
                        new TimedTransition(8000, "Zfollowabit1")
                        ),
                    new State("Zfollowabit1",
                        new Prioritize(
                            new Follow(0.3, 8, 1),
                            new StayCloseToSpawn(0.5, 3)
                        ),
                        new Shoot(10, count: 11, shootAngle: 14, projectileIndex: 1, coolDown: 1000),
                        new TimedTransition(3000, "ZGoBackHome2")
                        ),
                    new State("ZGoBackHome2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(speed: 0.6),
                        new TimedTransition(3600, "Zfight3")
                        ),
                    new State("Zfight3",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 3),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 7, shootAngle: 20, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 14, projectileIndex: 1, coolDown: 3000),
                        new TimedTransition(6000, "ZGoBackHome1")
                        ),
                    new State("ZGoBackHome1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(speed: 0.6),
                        new TimedTransition(3600, "Zchargingshock")
                        ),
                    new State("Zchargingshock",
                        new Taunt("*Loud Mechanized Sound*"),
                        new Flash(0x000000, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.2, 2),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 9, projectileIndex: 2, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(10, count: 11, projectileIndex: 1, coolDown: 2500),
                        new Shoot(10, count: 5, projectileIndex: 3, coolDown: 400),
                        new TimedTransition(5000, "Zfollowabit2")
                        ),
                    new State("Zfollowabit2",
                        new Prioritize(
                            new Follow(0.2, 8, 1),
                            new StayCloseToSpawn(0.5, 3)
                        ),
                        new Shoot(10, count: 12, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(4000, "Zrumble1")
                        ),
                    new State("Zrumble1",
                        new Prioritize(
                            new StayCloseToSpawn(0.2, 2),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 12, shootAngle: 7, projectileIndex: 0, coolDown: 4000, coolDownOffset: 1000),
                        new Shoot(10, count: 8, shootAngle: 16, projectileIndex: 2, coolDown: new Cooldown(500, 3000)),
                        new TimedTransition(7400, "Zfight1")
                        )
                      )

                    ),
                new MostDamagers(3,
                    LootTemplates.Sor3Perc()
                    ),
                new Threshold(0.01,
                    new ItemLoot("Potion of Defense", 1.0),
                    new TierLoot(8, ItemType.Weapon, 0.2),
                    new TierLoot(9, ItemType.Weapon, 0.03),
                    new TierLoot(10, ItemType.Weapon, 0.02),
                    new TierLoot(11, ItemType.Weapon, 0.01),
                    new TierLoot(3, ItemType.Ring, 0.2),
                    new TierLoot(4, ItemType.Ring, 0.05),
                    new TierLoot(5, ItemType.Ring, 0.01),
                    new TierLoot(7, ItemType.Armor, 0.2),
                    new TierLoot(8, ItemType.Armor, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.03),
                    new TierLoot(10, ItemType.Armor, 0.02),
                    new TierLoot(11, ItemType.Armor, 0.01),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(5, ItemType.Ability, 0.03),
                    new ItemLoot("Surge Cloak", 0.005),
                    new ItemLoot("V-X Spark Armor", 0.005)
                )
            )
            ;
    }
}