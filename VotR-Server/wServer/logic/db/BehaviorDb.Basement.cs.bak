using wServer.realm;
using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Basement = () => Behav()
        .Init("Wraith of Fear",
            new State(
                new State("FollowAndShoot",
                new Prioritize(
                        new Follow(0.4, 8, 1),
                        new Wander(0.6)
                        ),
                     new Shoot(10, count: 5, shootAngle: 14, projectileIndex: 1, coolDown: new Cooldown(1200, 800)),
                     new TimedTransition(6400, "StunWave")
                    ),
                new State("StunWave",
                     new Swirl(0.4, 2, 8),
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(10, count: 8, projectileIndex: 0, coolDown: 250),
                     new TimedTransition(1250, "FollowAndShoot2")
                    ),
                new State("FollowAndShoot2",
                new Prioritize(
                        new Follow(0.4, 8, 1),
                        new Wander(0.6)
                        ),
                     new Shoot(10, count: 5, shootAngle: 14, projectileIndex: 2, coolDown: new Cooldown(1200, 800)),
                     new TimedTransition(6400, "FollowAndShoot")
                    )
                )
            )
        .Init("Dark Basement Warrior",
            new State(
                new State("fight1",
                new Prioritize(
                        new Follow(0.8, 8, 1),
                        new Wander(1)
                        ),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 400),
                     new TimedTransition(4000, "fight2")
                    ),
                new State("fight2",
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1, coolDownOffset: 10),
                     new TimedTransition(2600, "fight1")
                    )
                )
            )
        .Init("Living Garbage",
                new State(
                    new Wander(0.08),
                    new Shoot(8, count: 1, coolDown: new Cooldown(100, 600))
                    ),
                new ItemLoot("Minor Magic Potion", 0.1)
            )
        .Init("Dark Basement Fighter",
            new State(
                new State("fight1",
                new Prioritize(
                        new Follow(0.8, 8, 1),
                        new Wander(1)
                        ),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 400),
                     new TimedTransition(4000, "fight2")
                    ),
                new State("fight2",
                     new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 200),
                     new TimedTransition(2600, "fight1")
                    )
                )
            )
        .Init("Dark Basement Wizard",
            new State(
                new State("fight1",
                new Prioritize(
                        new Follow(0.5, 8, 1),
                        new Wander(1)
                        ),
                     new Shoot(10, count: 10, projectileIndex: 0, coolDown: 1600),
                     new TimedTransition(3600, "fight2")
                    ),
                new State("fight2",
                    new Prioritize(
                        new Follow(0.5, 8, 1),
                        new Wander(1)
                        ),
                     new Shoot(10, count: 10, projectileIndex: 1, coolDown: 1600),
                     new TimedTransition(3600, "fight1")
                    )
                )
            )
        .Init("Skeleton the Alive",
            new State(
                new State("fight1",
                new Prioritize(
                        new Follow(0.6, 8, 1),
                        new Wander(1)
                        ),
                     new HealSelf(coolDown: 3400),
                     new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                     new Shoot(10, count: 6, shootAngle: 12, projectileIndex: 1, coolDown: 1000, coolDownOffset: 600),
                     new Shoot(10, count: 7, projectileIndex: 0, coolDown: 1000, coolDownOffset: 1200),
                     new TimedTransition(6800, "fight2")
                    ),
                new State("fight2",
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Taunt("I'm not dead anymore! Is this the power of the great Tridorno?", "I feel like a new unholy being!", "Get out of the sorcerer's basement! He will turn you into us!"),
                    new Prioritize(
                        new Follow(0.35, 8, 1),
                        new Wander(1)
                        ),
                     new TossObject("The Alive Follower", 7, coolDown: 500),
                     new TimedTransition(3000, "fight1")
                    )
                )
            )
        .Init("The Alive Follower",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 760)
                    ),
                new ItemLoot("Minor Magic Potion", 0.1)
            )
        .Init("Sphere of Fear",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Idle"
                    ),
                new State("Shoot",
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: new Cooldown(2600, 1400)),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: new Cooldown(2600, 1400))
                    )
                )
            )
        .Init("Sphere of Sorrow",
            new State(
                new State("Shoot",
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 2800),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 2800),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 2800),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 2800)
                    )
                )
            )
        .Init("Wraith of Sorrow",
            new State(
                new TransformOnDeath("Wraith of Fear", 1, 1, 0.5),
                new State("fight1",
                     new Protect(0.6, "AB The Dark Sorcerer", 3),
                     new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 0, coolDown: new Cooldown(3000, 1600)),
                     new Shoot(10, count: 1, projectileIndex: 1, predictive: 1, coolDown: new Cooldown(2000, 800))
                    ),
                new State("Run",
                     new Flash(0xFF0000, 1, 1),
                     new Follow(0.5, 8, 1),
                     new Shoot(10, count: 3, projectileIndex: 1, coolDown: new Cooldown(1000, 1200))
                    )
                )
            )
        .Init("AB The Dark Sorcerer",
                new State(
                    new HpLessTransition(0.14, "rip1"),
                    new State("default",
                        new PlayerWithinTransition(5, "taunt")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("taunt",
                        new Taunt("I've created all of this..but you are determined to destroy it?"),
                        new TimedTransition(5000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt("I don't think that will cut it here.", "Why must you tear my creations I conjured apart?"),
                        new TimedTransition(4000, "taunt3")
                        ),
                    new State("taunt3",
                        new Taunt("This will stop now.", "I shall now tear you apart!"),
                        new TimedTransition(4000, "FollowAndShoot")
                        )
                      ),
                    new State("FollowAndShoot",
                        new Prioritize(
                            new Follow(0.5),
                            new Wander(0.4)
                            ),
                        new Shoot(10, count: 7, shootAngle: 14, projectileIndex: 3, predictive: 1, coolDown: new Cooldown(2000, 1800)),
                        new Shoot(10, count: 3, shootAngle: 4, projectileIndex: 4, coolDown: 50),
                        new Shoot(10, count: 3, shootAngle: 4, projectileIndex: 4, coolDown: 50, coolDownOffset: 100),
                        new TimedTransition(8200, "WanderAndShoot")
                        ),
                    new State("WanderAndShoot",
                        new Wander(0.8),
                        new Shoot(10, count: 16, projectileIndex: 2, coolDown: 1600),
                        new Grenade(6, 120, range: 4, coolDown: 2000),
                        new Shoot(10, count: 5, shootAngle: 16, projectileIndex: 3, coolDown: new Cooldown(1000, 500)),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(6600, "Panic")
                        ),
                    new State("Panic",
                        new BackAndForth(0.8, 3),
                        new Shoot(10, count: 1, projectileIndex: 3, coolDown: 1),
                        new Shoot(10, count: 5, projectileIndex: 4, coolDown: 200),
                        new Shoot(10, count: 8, projectileIndex: 4, coolDown: 200, coolDownOffset: 200),
                        new TimedTransition(5000, "HealABit")
                        ),
                    new State("HealABit",
                        new Taunt("I need MORE power!"),
                        new ReturnToSpawn(speed: 0.6),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFFFFFF, 1, 1),
                        new HealSelf(coolDown: 1000, amount: 2000),
                        new Shoot(10, count: 3, projectileIndex: 3, coolDown: 500),
                        new TimedTransition(3400, "HealABit2")
                        ),
                    new State("HealABit2",
                        new Taunt("Weaklings."),
                        new Order(999, "Sphere of Fear", "Shoot"),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(2000, "BigShot")
                        ),
                   new State(
                       new Reproduce("Wraith of Sorrow", densityMax: 2,  coolDown: 4400),
                    new State("BigShot",
                        new Prioritize(
                            new Follow(0.6),
                            new Wander(0.2)
                            ),
                        new Shoot(10, count: 6, projectileIndex: 3, coolDown: new Cooldown(100, 1000)),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 0, coolDown: 2600),
                        new TimedTransition(4000, "BigShot2")
                        ),
                    new State("BigShot2",
                        new Prioritize(
                            new Follow(0.6),
                            new Wander(0.2)
                            ),
                        new TossObject("Sphere of Sorrow", range: 7, coolDown: new Cooldown(3000, 2800)),
                        new Shoot(10, count: 12, projectileIndex: 3, coolDown: new Cooldown(100, 1000)),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 0, coolDown: 2600),
                        new TimedTransition(4000, "Boomerang")
                        ),
                    new State("Boomerang",
                        new Prioritize(
                            new Follow(0.6),
                            new Wander(0.2)
                            ),
                        new TossObject("Sphere of Sorrow", range: 7, coolDown: new Cooldown(5000, 2800)),
                        new Shoot(10, count: 7, projectileIndex: 1, coolDown: 1200),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(6000, "ABigShot")
                        ),
                    new State("ABigShot",
                        new Prioritize(
                            new Follow(0.6),
                            new Wander(0.2)
                            ),
                        new Shoot(10, count: 6, projectileIndex: 3, coolDown: new Cooldown(100, 1000)),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 0, coolDown: 2600),
                        new TimedTransition(4000, "ABigShot2")
                        ),
                    new State("ABigShot2",
                        new Prioritize(
                            new Follow(0.6),
                            new Wander(0.2)
                            ),
                        new TossObject("Sphere of Sorrow", range: 7, coolDown: new Cooldown(3000, 2800)),
                        new Shoot(10, count: 12, projectileIndex: 3, coolDown: new Cooldown(100, 1000)),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 0, coolDown: 2600),
                        new TimedTransition(4000, "ABoomerang")
                        ),
                    new State("ABoomerang",
                        new Prioritize(
                            new Follow(0.6),
                            new Wander(0.2)
                            ),
                        new TossObject("Sphere of Sorrow", range: 7, coolDown: new Cooldown(5000, 2800)),
                        new Shoot(10, count: 7, projectileIndex: 1, coolDown: 1200),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 2000),
                        new Order(999, "Sphere of Fear", "Idle"),
                        new TimedTransition(6000, "FollowAndShoot")
                            )
                        ),
                    new State("rip1",
                        new ReturnToSpawn(speed: 0.6),
                        new RemoveEntity(9999, "Sphere of Sorrow"),
                        new RemoveEntity(9999, "Sphere of Fear"),
                        new Taunt("I must leave my friends..."),
                        new Flash(0xFF00FF, 2, 4),
                        new TimedTransition(4000, "rip2")
                        ),
                    new State("rip2",
                        new Suicide()
                        )
                    ),
                new Threshold(0.025,
                    new TierLoot(10, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(10, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.05),
                    new TierLoot(11, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("1000 Gold", 0.05),
                    new ItemLoot("Onrane", 0.05),
                    new ItemLoot("Shoot Faster Potion", 0.8),
                    new ItemLoot("Dirk of Benevolence", 0.04),
                    new ItemLoot("Bow of the Lonesome Wraith", 0.04),
                    new ItemLoot("Wand of Fractured Time", 0.04),
                    new ItemLoot("Siphon of Courage", 0.04)
                )
            )
        .Init("AB Secret Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.15,
                new TierLoot(10, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(10, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.05),
                    new TierLoot(11, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Shoot Faster Potion", 0.8),
                    new ItemLoot("Dirk of Benevolence", 0.02),
                    new ItemLoot("Bow of the Lonesome Wraith", 0.02)
                )
            )
            ;
    }
}