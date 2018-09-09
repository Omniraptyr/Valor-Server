using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Rift = () => Behav()
        .Init("Riv the Heavenly Champion",
                new State(
                    new RealmPortalDrop(),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(8, "taunt")
                        ),
                    new State("taunt",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt(1.00, "Prove yourself, warrior!", "You are no match against me! I have won 78130413 matches! I better make it 78130414!", "I don't lose. Especially to weaklings like you."),
                        new TimedTransition(4500, "ShotgunPhase")
                        ),
                    new State("ShotgunPhase",
                        new Wander(0.6),
                        new Shoot(10, count: 4, projectileIndex: 3, coolDown: 2500),
                        new Shoot(10, count: 6, predictive: 1, projectileIndex: 4, coolDown: 1750),
                        new TimedTransition(6000, "ShotgunPhase1")
                        ),
                   new State("ShotgunPhase1",
                        new Follow(0.45, 8, 1),
                        new Shoot(10, count: 8, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 12, predictive: 2, projectileIndex: 4, coolDown: 2800),
                        new TimedTransition(5000, "ReturnToSpawn1")
                        ),
                    new State("ReturnToSpawn1",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Flash(0x0000FF, 2, 2),
                        new ReturnToSpawn(speed: 0.5),
                        new Taunt(1.00, "Hahaha! You have strength, but do you have agility?"),
                        new TimedTransition(5000, "AgileShotguns")
                        ),
                      new State("AgileShotguns",
                        new Taunt(1.00, "You think you can get away with killing me? I do not think so."),
                        new HealSelf(coolDown: 1000, amount: 200),
                        new TimedTransition(10000, "TinyShotGun"),
                        new State("Quadforce1",
                            new Shoot(8.4, count: 3, shootAngle: 10, fixedAngle: 0, projectileIndex: 1, coolDown: 2000),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 70, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(70, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 70, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(70, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(8.4, count: 3, shootAngle: 10, fixedAngle: 90, projectileIndex: 1, coolDown: 2000),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 70, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(70, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 70, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(100, "Quadforce41")
                        ),
                        new State("Quadforce41",
                            new Shoot(8.4, count: 3, shootAngle: 10, fixedAngle: 180, projectileIndex: 1, coolDown: 2000),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 70, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(70, "Quadforce51")
                        ),
                        new State("Quadforce51",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 70, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(70, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(8.4, count: 3, shootAngle: 10, fixedAngle: 270, projectileIndex: 1, coolDown: 2000),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 70, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(70, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 70, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(70, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(8.4, count: 5, projectileIndex: 1, coolDown: 2000),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 70, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(70, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 70, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(70, "Quadforce1")
                        )
                    ),
                    new State("TinyShotGun",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Prioritize(
                            new StayBack(0.5, 4),
                            new Wander(0.2)
                            ),
                        new Shoot(8.4, count: 6, shootAngle: 7, projectileIndex: 2, coolDown: 2000),
                        new Shoot(8.4, count: 10, projectileIndex: 4, coolDown: 3000),
                        new TimedTransition(7500, "MinionPhase")
                        ),
                    new State("MinionPhase",
                        new Wander(0.8),
                        new Shoot(8.4, count: 8, shootAngle: 26, projectileIndex: 1, coolDown: 2500),
                        new Shoot(8.4, count: 4, shootAngle: 8, predictive: 2, projectileIndex: 4, coolDown: 1000),
                        new TossObject("HR Mini Angel", 8, coolDown: 1000),
                        new TossObject("HR Heavenly Priest", 8, coolDown: 2500),
                        new TimedTransition(5000, "ShotgunPhase")
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor1Perc()
                    ),
                new Threshold(0.01,
                    new ItemLoot("Potion of Vitality", 0.6),
                    new ItemLoot("Potion of Speed", 0.6),
                    new ItemLoot("Potion of Protection", 0.33),
                    new TierLoot(11, ItemType.Weapon, 0.1),
                    new TierLoot(12, ItemType.Armor, 0.1),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(5, ItemType.Ring, 0.05),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new ItemLoot("Orb of Heavenly Sight", 0.03),
                    new ItemLoot("Staff of Noble Magic", 0.03),
                    new ItemLoot("Heaven Monk's Apparel", 0.03),
                    new ItemLoot("Necklace of Crystalline Celestial Forces", 0.03),
                    new ItemLoot("Sheath of the Holy Revival", 0.03),
                    new ItemLoot("Spectrum Robe", 0.02),
                    new ItemLoot("Eternity Armor", 0.02)
                )
            )

        .Init("HR Valkrie",
            new State(
                new State("fight",
                    new Follow(0.65, 8, 1),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 750),
                     new TimedTransition(4000, "swag2")
                    ),
                new State("swag2",
                     new Follow(0.65, 8, 1),
                     new Shoot(8.4, count: 3, shootAngle: 16, projectileIndex: 1, coolDown: 400),
                     new TimedTransition(4000, "fight")
                    )
                )
            )
        .Init("HR Holy Swordsman",
            new State(
                new State("fight",
                    new Follow(1, 8, 1),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 300),
                     new TimedTransition(8000, "swag2")
                    ),
                new State("swag2",
                     new StayBack(0.5, 3),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 300),
                     new TimedTransition(2000, "fight")
                    )
                )
            )
        .Init("HR Mini Angel",
                new State("fight",
                     new Wander(0.5),
                     new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: new Cooldown(1500, 200))
                )
            )
        .Init("HR Heavenly Priest",
            new State(
                new HpLessTransition(0.12, "bam"),
                new HealSelf(coolDown: 4000, amount: 25),
                new State("fight",
                    new Wander(0.2),
                     new Shoot(10, count: 3, projectileIndex: 0, coolDown: 1000),
                     new TimedTransition(4000, "swag2")
                    ),
                new State("swag2",
                     new Wander(0.6),
                     new Shoot(8.4, count: 6, shootAngle: 16, projectileIndex: 2, coolDown: 800),
                     new TimedTransition(4000, "fight")
                    ),
                new State("bam",
                     new Shoot(8.4, count: 10, projectileIndex: 1, coolDown: 9999)
                    )
                )
            )

        ;
    }
}