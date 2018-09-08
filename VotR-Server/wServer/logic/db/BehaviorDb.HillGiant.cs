using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ HillGiant = () => Behav()
            .Init("Ogla, the Giant God",
                new State(
                    new RealmPortalDrop(),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(8, "basic")
                        ),
                    new State(
                        new HpLessTransition(0.1, "rage"),
                        new Shoot(10, count: 16, projectileIndex: 2, coolDown: 2000),
                    new State("basic",
                        new Prioritize(
                            new Follow(0.6),
                            new Wander(0.2)
                            ),
                        new Shoot(10, count: 8, shootAngle: 8, projectileIndex: 3, predictive: 0.7, coolDown: 1000),
                        new TimedTransition(6000, "basic1")
                        ),
                    new State("basic1",
                        new Wander(0.6),
                        new Shoot(10, count: 6, shootAngle: 8, projectileIndex: 1, predictive: 0.7, coolDown: 800),
                        new TimedTransition(6000, "basic2")
                        ),
                    new State("basic2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayBack(0.4, 4),
                            new Wander(1)
                            ),
                        new Shoot(10, count: 10, projectileIndex: 1, coolDown: 1200),
                        new TimedTransition(4000, "basic3")
                             ),
                    new State("basic3",
                        new Flash(0xFFFFFF, 0.25, 4),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Prioritize(
                            new Follow(0.6, 8, 1),
                            new Charge(0.7, range: 6, coolDown: 2000),
                            new Wander(1)
                            ),
                        new Shoot(10, count: 7, shootAngle: 10, projectileIndex: 0, coolDown: 1800),
                        new TimedTransition(6000, "basic")
                             )
                        ),
                   new State("rage",
                        new Flash(0xFF0000, 0.25, 4),
                        new TossObject("Giant Priestess", 4, 0, coolDown: 9999999),
                        new TossObject("Giant Priestess", 4, 90, coolDown: 9999999),
                        new TossObject("Giant Priestess", 4, 180, coolDown: 9999999),
                        new TossObject("Giant Priestess", 4, 270, coolDown: 9999999),
                        new Prioritize(
                            new Follow(1),
                            new Wander(0.2)
                            ),
                        new Shoot(10, count: 6, shootAngle: 8, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 7, shootAngle: 16, projectileIndex: 1, predictive: 1, coolDown: 2000, coolDownOffset: 800)
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor1Perc()
                    ),
                new Threshold(0.025,
                    new ItemLoot("Earthforce Dice", 0.001),
                    new ItemLoot("Hill Giant Club", 0.001),
                    new ItemLoot("Helm of the Macrotitans", 0.001),
                    new ItemLoot("Potion of Restoration", 0.75),
                    new TierLoot(8, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(8, ItemType.Armor, 0.2),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(9, ItemType.Armor, 0.06),
                    new TierLoot(9, ItemType.Weapon, 0.06),
                    new TierLoot(4, ItemType.Ring, 0.025)
                )
            )
            .Init("Giant Knight",
            new State(
                new State("Main",
                    new Shoot(10, count: 8, projectileIndex: 1, coolDown: 800),
                    new State("fight1",
                        new Prioritize(
                            new Follow(0.4, 8, 1),
                            new Wander(0.25)
                            ),
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(4000, "fight2")
                        )
                    ),
                    new State("fight2",
                        new Prioritize(
                            new Orbit(0.4, 4, acquireRange: 10, target: null),
                            new Wander(0.25)
                            ),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 200),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            .Init("Giant Warrior",
            new State(
                new Shoot(10, count: 8, projectileIndex: 1, coolDown: 800),
                new State(
                    new Prioritize(
                        new Orbit(0.6, 2, 10),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, projectileIndex: 0, coolDown: 4000)
                    )
                  ),
                new ItemLoot("Fire Sword", 0.05),
                new Threshold(0.5,
                    new ItemLoot("Glass Sword", 0.01)
                    )
            )
            .Init("Giant Armored Warrior",
            new State(
                new Shoot(10, count: 8, projectileIndex: 1, coolDown: 800),
                new State(
                    new Prioritize(
                        new Orbit(0.75, 2, 10),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, projectileIndex: 0, coolDown: 2000),
                    new Shoot(8, 6, shootAngle: 10, projectileIndex: 0, coolDown: 2000, coolDownOffset: 1400)
                    )
                  ),
                new ItemLoot("Fire Sword", 0.05),
                new Threshold(0.5,
                    new ItemLoot("Glass Sword", 0.01)
                    )
            )
            .Init("Giant Priestess",
            new State(
                new State("first",
                    new HpLessTransition(0.1, "first2"),
                    new Shoot(10, count: 8, projectileIndex: 1, coolDown: 800),
                    new Wander(0.4),
                    new Shoot(8, 7, projectileIndex: 0, coolDown: 3400)
                    ),
               new State("first2",
                    new HealGroup(6, "Giant", coolDown: 1000, healAmount: 50),
                    new Shoot(10, count: 8, projectileIndex: 1, coolDown: 800),
                    new Wander(0.4),
                    new Shoot(8, 7, projectileIndex: 0, coolDown: 3400)
                    )
                ),
                new ItemLoot("Pit Viper Poison", 0.02),
                new Threshold(0.1,
                    new ItemLoot("Wand of Dark Magic", 0.01),
                    new ItemLoot("Avenger Staff", 0.01),
                    new ItemLoot("Robe of the Invoker", 0.01)
                    )
            )
            .Init("Giant King",
                new State(
                    new Shoot(10, count: 8, projectileIndex: 1, coolDown: 800),
                    new Prioritize(
                        new Follow(0.9, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, projectileIndex: 0, coolDown: 2000),
                    new Shoot(8, 1, projectileIndex: 2, coolDown: 2000, coolDownOffset: 1600)
                    ),
                new ItemLoot("Thunderclap Scepter", 0.02),
                new Threshold(0.1,
                    new ItemLoot("Obsidian Dagger", 0.02),
                    new ItemLoot("Steel Helm", 0.02)
                    )
            )
            .Init("Archer Giant",
            new State(
                new State("Main",
                    new Shoot(10, count: 8, projectileIndex: 1, coolDown: 800),
                    new State("fight1",
                        new Prioritize(
                            new Follow(0.6, 8, 1),
                            new Wander(0.25)
                            ),
                        new Shoot(10, count: 4, shootAngle: 10, projectileIndex: 0, coolDown: 1600),
                        new TimedTransition(4000, "fight2")
                        )
                    ),
                    new State("fight2",
                        new Prioritize(
                            new StayBack(0.7, 8),
                            new Wander(0.25)
                            ),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 800),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            ;
    }
}