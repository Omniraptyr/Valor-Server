using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Lotll = () => Behav()
            .Init("Lord of the Lost Lands",
                new State(
                    new DropPortalOnDeath("Ice Cave Portal",0.5),
                    new State("Waiting",
                        new HpLessTransition(0.99, "Start1.0")
                        ),
                    new State("Start1.0",
                        new HpLessTransition(0.1, "Dead"),
                        new State("Start",
                            new SetAltTexture(0),
                            new Prioritize(
                                new Wander(0.8)
                                ),
                            new Shoot(0, count: 7, shootAngle: 10, fixedAngle: 180, coolDown: 2000),
                            new Shoot(0, count: 7, shootAngle: 10, fixedAngle: 0, coolDown: 2000),
                            new TossObject("Guardian of the Lost Lands", 5, coolDown: 1000),
                            new TimedTransition(100, "Spawning Guardian")
                            ),
                        new State("Spawning Guardian",
                            new TossObject("Guardian of the Lost Lands", 5, coolDown: 1000),
                            new TimedTransition(3100, "Attack")
                            ),
                        new State("Attack",
                            new SetAltTexture(0),
                            new Wander(0.8),
                            new PlayerWithinTransition(1, "Follow"),
                            new TimedTransition(10000, "Gathering"),
                            new State("Attack1.0",
                                new TimedRandomTransition(3000, false,
                                    "Attack1.1",
                                    "Attack1.2"),
                                new State("Attack1.1",
                                    new Shoot(12, count: 7, shootAngle: 10, coolDown: 2000),
                                    new Shoot(12, count: 7, shootAngle: 190, coolDown: 2000),
                                    new TimedTransition(2000, "Attack1.0")
                                    ),
                                new State("Attack1.2",
                                    new Shoot(0, count: 7, shootAngle: 10, fixedAngle: 180, coolDown: 3000),
                                    new Shoot(0, count: 7, shootAngle: 10, fixedAngle: 0, coolDown: 3000),
                                    new TimedTransition(2000, "Attack1.0")
                                    )
                                )
                            ),
                        new State("Follow",
                            new Prioritize(
                                new Follow(1, 20, 3),
                                new Wander(0.4)
                                ),
                            new Shoot(20, count: 7, shootAngle: 10, coolDown: 1300),
                            new TimedTransition(5000, "Gathering")
                            ),
                        new State("Gathering",
                            new Taunt(0.99, "Gathering power!"),
                            new SetAltTexture(3),
                            new TimedTransition(2000, "Gathering1.0")
                            ),
                        new State("Gathering1.0",
                            new TimedTransition(5000, "Protection"),
                            new State("Gathering1.1",
                                new Shoot(30, 4, fixedAngle: 90, projectileIndex: 1, coolDown: 2000),
                                new TimedTransition(1500, "Gathering1.2")
                                ),
                            new State("Gathering1.2",
                                new Shoot(30, 4, fixedAngle: 45, projectileIndex: 1, coolDown: 2000),
                                new TimedTransition(1500, "Gathering1.1")
                                )
                            ),
                        new State("Protection",
                            new SetAltTexture(0),
                            new TossObject("Protection Crystal", 4, angle: 0, coolDown: 5000),
                            new TossObject("Protection Crystal", 4, angle: 45, coolDown: 5000),
                            new TossObject("Protection Crystal", 4, angle: 90, coolDown: 5000),
                            new TossObject("Protection Crystal", 4, angle: 135, coolDown: 5000),
                            new TossObject("Protection Crystal", 4, angle: 180, coolDown: 5000),
                            new TossObject("Protection Crystal", 4, angle: 225, coolDown: 5000),
                            new TossObject("Protection Crystal", 4, angle: 270, coolDown: 5000),
                            new TossObject("Protection Crystal", 4, angle: 315, coolDown: 5000),
                            new EntityExistsTransition("Protection Crystal", 10, "Waiting")
                            )
                        ),
                    new State("Waiting",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new SetAltTexture(1),
                        new EntityNotExistsTransition("Protection Crystal", 10, "Start1.0")
                        ),
                    new State("Dead",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new SetAltTexture(3),
                        new Taunt(0.99, "NOOOO!!!!!!"),
                        new Flash(0xFF0000, .1, 1000),
                        new TimedTransition(2000, "Suicide")
                        ),
                    new State("Suicide",
                        new ConditionalEffect(ConditionEffectIndex.StunImmune, true),
                        new Shoot(0, 8, fixedAngle: 360/8, projectileIndex: 1),
                        new Suicide()
                        )
                    ),
                new Threshold(0.01,
                    new TierLoot(8, ItemType.Weapon, .15),
                    new TierLoot(9, ItemType.Weapon, .1),
                    new TierLoot(10, ItemType.Weapon, .07),
                    new TierLoot(11, ItemType.Weapon, .05),
                    new TierLoot(4, ItemType.Ability, .15),
                    new TierLoot(5, ItemType.Ability, .07),
                    new TierLoot(8, ItemType.Armor, .2),
                    new TierLoot(9, ItemType.Armor, .15),
                    new TierLoot(10, ItemType.Armor, .10),
                    new TierLoot(11, ItemType.Armor, .07),
                    new TierLoot(12, ItemType.Armor, .04),
                    new TierLoot(3, ItemType.Ring, .15),
                    new TierLoot(4, ItemType.Ring, .07),
                    new TierLoot(5, ItemType.Ring, .03),
                    new ItemLoot("Potion of Defense", .1),
                    new ItemLoot("Potion of Attack", .1),
                    new ItemLoot("Potion of Vitality", .1),
                    new ItemLoot("Potion of Wisdom", .1),
                    new ItemLoot("Potion of Speed", .1),
                    new ItemLoot("Potion of Dexterity", .1),
                    new ItemLoot("Shield of Ogmur", .004)
                    )
            )
            .Init("Protection Crystal",
                new State(
                    new Prioritize(
                        new Orbit(0.3, 4, 10, "Lord of the Lost Lands")
                        ),
                    new Shoot(8, count: 4, shootAngle: 7, coolDown: 500)
                    )
            )
            .Init("Guardian of the Lost Lands",
                new State(
                    new State("Full",
                        new Spawn("Knight of the Lost Lands", 2, 1, coolDown: 4000),
                        new Prioritize(
                            new Follow(0.6, 20, 6),
                            new Wander(0.2)
                            ),
                        new Shoot(10, count: 8, fixedAngle: 360/8, coolDown: 3000, projectileIndex: 1),
                        new Shoot(10, count: 5, shootAngle: 10, coolDown: 1500),
                        new HpLessTransition(0.25, "Low")
                        ),
                    new State("Low",
                        new Prioritize(
                            new StayBack(0.6, 5),
                            new Wander(0.2)
                            ),
                        new Shoot(10, count: 8, fixedAngle: 360/8, coolDown: 3000, projectileIndex: 1),
                        new Shoot(10, count: 5, shootAngle: 10, coolDown: 1500)
                        )
                    ),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
            )
            .Init("Knight of the Lost Lands",
                new State(
                    new Prioritize(
                        new Follow(1, 20, 4),
                        new StayBack(0.5, 2),
                        new Wander(0.3)
                        ),
                    new Shoot(13, 1, coolDown: 700)
                    ),
                new ItemLoot("Health Potion", 0.1),
                new ItemLoot("Magic Potion", 0.1)
            )
            ;
    }
}