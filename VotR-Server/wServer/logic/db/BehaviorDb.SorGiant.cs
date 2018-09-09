using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ SorGiant = () => Behav()
            .Init("Sorgigas, the Sor Giant",
                new State(
                    new ScaleHP(50000),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(12, "taunt")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("taunt",
                        new Taunt("You think you can just come steal my powerful crystals from me?"),
                        new TimedTransition(4000, "taunt2")
                        ),
                    new State("taunt2",
                        new Flash(0x0000FF, 2, 2),
                        new Taunt("Well, I have got news for you. NO ONE STEALS MY CRYSTALS!"),
                        new TimedTransition(4000, "Fight1")
                        )
                     ),
                    new State("Fight1",
                    new RemoveEntity(20, "Sor Fiend"),
                    new Prioritize(
                        new StayCloseToSpawn(0.5, 3),
                        new Wander(0.05)
                    ),
                        new Shoot(8, count: 8, shootAngle: 10, projectileIndex: 2, coolDown: 1000),
                        new Shoot(8, count: 4, shootAngle: 16, projectileIndex: 1, coolDown: 200),
                        new Grenade(4, 120, range: 8, coolDown: 80, effect: ConditionEffectIndex.Exhausted, effectDuration: 4, color: 0x00FF00),
                        new TimedTransition(6000, "Fight2")
                    ),
                    new State("Fight2",
                        new Follow(0.6, 8, 1),
                        new Taunt("Come here you, pest!"),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8, count: 5, shootAngle: 6, projectileIndex: 0, coolDown: new Cooldown(400, 800)),
                        new TimedTransition(8000, "Return")
                        ),
                   new State("Return",
                                new Taunt("You won't be alive after this one!"),
                                new ReturnToSpawn(speed: 1),
                                new TimedTransition(6000, "Go")
                        ),
                     new State("Go",
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 600, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 800, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 140, coolDownOffset: 1000,
                                shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 1200,
                                shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 1400,
                                shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 170, coolDownOffset: 1600,
                                shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 1800,
                                shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 8, coolDown: 10000, fixedAngle: 180, coolDownOffset: 2000,
                                shootAngle: 45, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 0, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 170, coolDownOffset: 200, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 600, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 140, coolDownOffset: 800, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 1000,
                                shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 1200,
                                shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 1400,
                                shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 1600,
                                shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 1800, shootAngle: 90, projectileIndex: 3),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 2000,
                                shootAngle: 22.5, projectileIndex: 3),
                            new TimedTransition(2000, "SpawnStuff")
                            ),
                    new State("SpawnStuff",
                        new Flash(0xFF0000, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TossObject("Sor Fiend", 4, 0, coolDown: 9999999),
                        new TossObject("Sor Fiend", 4, 45, coolDown: 9999999),
                        new TossObject("Sor Fiend", 4, 90, coolDown: 9999999),
                        new TossObject("Sor Fiend", 4, 135, coolDown: 9999999),
                        new TossObject("Sor Fiend", 4, 180, coolDown: 9999999),
                        new TossObject("Sor Fiend", 4, 225, coolDown: 9999999),
                        new TossObject("Sor Fiend", 4, 270, coolDown: 9999999),
                        new TossObject("Sor Fiend", 4, 315, coolDown: 9999999),
                        new TimedTransition(4000, "AttackAgain"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Quadforce1")
                        )
                    ),
                    new State("AttackAgain",
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 600, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 800, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 140, coolDownOffset: 1000,
                                shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 1200,
                                shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 1400,
                                shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 170, coolDownOffset: 1600,
                                shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 1800,
                                shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 8, coolDown: 10000, fixedAngle: 180, coolDownOffset: 2000,
                                shootAngle: 45, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 180, coolDownOffset: 0, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 170, coolDownOffset: 200, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 150, coolDownOffset: 600, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 140, coolDownOffset: 800, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 130, coolDownOffset: 1000,
                                shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 120, coolDownOffset: 1200,
                                shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 110, coolDownOffset: 1400,
                                shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 100, coolDownOffset: 1600,
                                shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 1800, shootAngle: 90, projectileIndex: 0),
                            new Shoot(1, count: 4, coolDown: 10000, fixedAngle: 90, coolDownOffset: 2000,
                                shootAngle: 22.5, projectileIndex: 0),
                            new TimedTransition(2000, "Fight3")
                            ),
                    new State("Fight3",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 3),
                            new Wander(0.05)
                        ),
                        new Shoot(10, count: 14, projectileIndex: 1, coolDown: 2000),
                        new Shoot(8, count: 4, shootAngle: 16, projectileIndex: 0, predictive: 1, coolDown: 800),
                        new Grenade(6, 120, range: 8, coolDown: 2000, fixedAngle: 90, effect: ConditionEffectIndex.Exhausted, effectDuration: 4, color: 0x00FF00),
                        new Grenade(6, 120, range: 8, coolDown: 2000, fixedAngle: 180, effect: ConditionEffectIndex.Exhausted, effectDuration: 4, color: 0x00FF00),
                        new Grenade(6, 120, range: 8, coolDown: 2000, fixedAngle: 270, effect: ConditionEffectIndex.Exhausted, effectDuration: 4, color: 0x00FF00),
                        new Grenade(6, 120, range: 8, coolDown: 2000, fixedAngle: 0, effect: ConditionEffectIndex.Exhausted, effectDuration: 4, color: 0x00FF00),
                        new TimedTransition(8000, "Fight4")
                        ),
                    new State("Fight4",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 3),
                            new Wander(0.1)
                        ),
                        new Shoot(10, count: 20, projectileIndex: 2, coolDown: 1000),
                        new Shoot(10, count: 4, shootAngle: 4, projectileIndex: 3, coolDown: 1400),
                        new TimedTransition(4000, "Fight1")
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.05,
                    new ItemLoot("Infused Katana", 0.005),
                    new ItemLoot("Potion of Vitality", 0.5),
                    new ItemLoot("Potion of Dexterity", 0.5),
                    new ItemLoot("Potion of Wisdom", 0.5),
                    new TierLoot(10, ItemType.Weapon, 0.1),
                    new TierLoot(6, ItemType.Ability, 0.1),
                    new TierLoot(10, ItemType.Armor, 0.1),
                    new TierLoot(5, ItemType.Ring, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.05),
                    new TierLoot(11, ItemType.Weapon, 0.05),
                    new TierLoot(7, ItemType.Ring, 0.01),
                    new TierLoot(6, ItemType.Ring, 0.025)
                    )
            )
            .Init("Sor Fiend",
                new State(
                    new ScaleHP(1000),
                    new TransformOnDeath("Sor Soul", min: 1, max: 1, probability: 0.5),
                    new SetNoXP(),
                    new Wander(0.2),
                    new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 0, coolDown: 3000),
                    new Shoot(10, count: 1, projectileIndex: 1, coolDown: 800, predictive: 1)
                    )
            )
            .Init("Sor Soul",
                new State(
                    new SetNoXP(),
                    new Prioritize(
                        new Follow(1.3, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 6, projectileIndex: 0, coolDown: 100)
                    )
            )
            ;
    }
}