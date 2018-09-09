using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;


namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Sphinx = () => Behav()
            .Init("Grand Sphinx",
                new State(
                    new ScaleHP(35000),
                    new DropPortalOnDeath("Tomb of the Ancients Portal", 0.33),
                    new State("Spawned",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Reproduce("Horrid Reaper", 30, 4, coolDown: 100),
                        new TimedTransition(500, "Attack1")
                        ),
                    new State("Attack1",
                        new Prioritize(
                            new Wander(0.5)
                            ),
                        new Shoot(12, count: 1, coolDown: 800),
                        new Shoot(12, count: 3, shootAngle: 10, coolDown: 1000),
                        new Shoot(12, count: 1, shootAngle: 130, coolDown: 1000),
                        new Shoot(12, count: 1, shootAngle: 230, coolDown: 1000),
                        new TimedTransition(6000, "TransAttack2")
                        ),
                    new State("TransAttack2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Wander(0.5),
                        new Flash(0x00FF0C, .25, 8),
                        new Taunt(0.99, "You hide behind rocks like cowards but you cannot hide from this!"),
                        new TimedTransition(2000, "Attack2")
                        ),
                    new State("Attack2",
                        new Prioritize(
                            new Wander(0.5)
                            ),
                        new Shoot(0, count: 8, shootAngle: 10, fixedAngle: 0, rotateAngle: 70, coolDown: 2000,
                            projectileIndex: 1),
                        new Shoot(0, count: 8, shootAngle: 10, fixedAngle: 180, rotateAngle: 70, coolDown: 2000,
                            projectileIndex: 1),
                        new TimedTransition(6200, "TransAttack3")
                        ),
                    new State("TransAttack3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Wander(0.5),
                        new Flash(0x00FF0C, .25, 8),
                        new TimedTransition(2000, "Attack3")
                        ),
                    new State("Attack3",
                        new Prioritize(
                            new Wander(0.5)
                            ),
                        new Shoot(20, count: 9, fixedAngle: 360 / 9, projectileIndex: 2, coolDown: 2300),
                        new TimedTransition(6000, "TransAttack1"),
                        new State("Shoot1",
                            new Shoot(20, count: 2, shootAngle: 4, projectileIndex: 2, coolDown: 700),
                            new TimedRandomTransition(1000, false,
                                "Shoot1",
                                "Shoot2"
                                )
                            ),
                        new State("Shoot2",
                            new Shoot(20, count: 8, shootAngle: 5, projectileIndex: 2, coolDown: 1100),
                            new TimedRandomTransition(1000, false,
                                "Shoot1",
                                "Shoot2"
                                )
                            )
                        ),
                    new State("TransAttack1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Wander(0.5),
                        new Flash(0x00FF0C, .25, 8),
                        new TimedTransition(2000, "Attack1"),
                        new HpLessTransition(0.15, "Order")
                        ),
                    new State("Order",
                        new Wander(0.5),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Order(30, "Horrid Reaper", "Die"),
                        new TimedTransition(1900, "Attack1")
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor3Perc()
                    ),
                 new MostDamagers(3,
                    LootTemplates.StatPots()
                ),
                new Threshold(0.01,
                    new ItemLoot("Potion of Vitality", 0.1),
                    new ItemLoot("Potion of Wisdom", 0.1),
                    new ItemLoot("Helm of the Juggernaut", 0.004)
                    )
            )
            .Init("Horrid Reaper",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("Move",
                        new Prioritize(
                            new StayCloseToSpawn(3, 10),
                            new Wander(3)
                            ),
                        new EntityNotExistsTransition("Grand Sphinx", 50, "Die"), //Just to be sure
                        new TimedRandomTransition(2000, true, "Attack")
                        ),
                    new State("Attack",
                        new Shoot(0, count: 6, fixedAngle: 360/6, coolDown: 700),
                        new PlayerWithinTransition(2, "Follow"),
                        new TimedRandomTransition(5000, true, "Move")
                        ),
                    new State("Follow",
                        new Prioritize(
                            new Follow(0.7, 10, 3)
                            ),
                        new Shoot(7, count: 1, coolDown: 700),
                        new TimedRandomTransition(5000, true, "Move")
                        ),
                    new State("Die",
                        new Taunt(0.99, "OOaoaoAaAoaAAOOAoaaoooaa!!!"),
                        new Decay(1000)
                        )
                    )
            )
            ;
    }
}