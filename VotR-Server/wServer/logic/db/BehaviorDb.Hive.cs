using wServer.realm;
using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Hive = () => Behav()
            .Init("Polerste, the Fierce Wasp",
                new State(
                    new RealmPortalDrop(),
                    new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(8, "CircleHive")
                        ),
                    new State("CircleHive",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Orbit(0.55, 4, target: "Hive Spawner Boss"),
                        new Reproduce("Hive Wasp Warrior 3", densityMax: 4, coolDown: 1000),
                        new Shoot(10, 1, projectileIndex: 0, coolDown: 3000),
                        new EntitiesNotExistsTransition(999, "Next", "Hive Spawner Boss")
                        ),
                    new State("Next",
                        new Taunt("BZzzzzz!"),
                        new Wander(0.65),
                        new Shoot(10, 6, shootAngle: 10, projectileIndex: 3, coolDown: 1000),
                        new Shoot(10, 2, shootAngle: 2, projectileIndex: 1, predictive: 2, coolDown: new Cooldown(500, 2000)),
                        new TimedTransition(6800, "OrbitThePlayer")
                        ),
                    new State("OrbitThePlayer",
                        new Prioritize(
                            new Orbit(0.65, 3),
                            new Wander(0.5)
                            ),
                        new Shoot(10, 8, projectileIndex: 2, coolDown: 2500),
                        new Shoot(10, 1, projectileIndex: 0, coolDown: 500),
                        new TimedTransition(6600, "stayback")
                        ),
                    new State("stayback",
                        new Flash(0xFF0000, 1, 1),
                        new BackAndForth(0.4, 3),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, 10, projectileIndex: 3, coolDown: 1000),
                        new TimedTransition(7200, "runaway")
                        ),
                    new State("runaway",
                        new Prioritize(
                            new StayBack(0.2, 2),
                            new Wander(0.1)
                            ),
                        new Grenade(4, 60, range: 6, coolDown: 1000),
                        new Reproduce("Hive Wasp Warrior 3", densityMax: 6, coolDown: 1000),
                        new Shoot(10, 7, shootAngle: 18, projectileIndex: 1, coolDown: 4000),
                        new TimedTransition(6800, "fight")
                        ),
                    new State("fight",
                        new Follow(0.6, 8, 1),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, 1, projectileIndex: 2, coolDown: 50),
                        new Shoot(10, 1, projectileIndex: 2, coolDown: 50, predictive: 0.5, coolDownOffset: 50),
                        new TimedTransition(7000, "OrbitThePlayer")
                        )
                    ),
                new Threshold(0.025,
                    new ItemLoot("Potion of Vitality", 0.5),
                    new ItemLoot("Potion of Dexterity", 0.5),
                    new TierLoot(9, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Winged Wasp Armor", 0.035),
                    new ItemLoot("The Bees Knees", 0.03),
                    new ItemLoot("Stinger Spell", 0.035),
                    new ItemLoot("Mark of Swiftness", 0.01)
                )
            )
         .Init("Hive Wasp Warrior 1",
            new State(
                new Prioritize(
                        new Orbit(0.35, 3, target: "Hive Spawner"),
                        new Follow(0.4, 8, 1),
                        new Wander(0.2)
                        ),
                new State("fight1",
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 2000),
                     new TimedTransition(4000, "fight2")
                    ),
                new State("fight2",
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 400),
                     new TimedTransition(2000, "fight1")
                    )
                )
            )
        .Init("Hive Wasp Warrior 2",
            new State(
                new Prioritize(
                        new Follow(0.6, 8, 1),
                        new Wander(0.2)
                        ),
                new State("fight1",
                     new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 0, coolDown: 3000)
                    )
                )
            )
        .Init("Hive Wasp Warrior 3",
            new State(
                new Prioritize(
                        new Orbit(0.4, 2, target: "Polerste, the Fierce Wasp"),
                        new Follow(0.6, 8, 1),
                        new Wander(0.2)
                        ),
                new State("fight1",
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: new Cooldown(500, 1250)),
                     new Shoot(10, count: 3, shootAngle: 4, predictive: 1, projectileIndex: 0, coolDown: new Cooldown(2000, 4000))
                    )
                )
            )
        .Init("Magic Hive Skeleton",
            new State(
                new State("fight1",
                    new Prioritize(
                        new Follow(0.5, 8, 1),
                        new Wander(0.2)
                        ),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 600),
                     new DamageTakenTransition(1000, "Invulnerable")
                    ),
                new State("Invulnerable",
                     new Wander(0.05),
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(10, count: 7, projectileIndex: 1, coolDown: 2000),
                     new TimedTransition(4000, "fight2")
                    ),
                new State("fight2",
                    new Prioritize(
                        new Follow(0.6, 8, 1),
                        new Wander(0.2)
                        ),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 50)
                    )
                )
            )
        .Init("Hive Knight",
                new State(
                    new Prioritize(
                        new Follow(0.2, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 1, projectileIndex: 1, coolDown: 1000),
                    new Shoot(8, 1, projectileIndex: 0, coolDown: 2600)
                    ),
                new Threshold(0.5,
                    new ItemLoot("Ragetalon Dagger", 0.01),
                    new ItemLoot("Ring of Superior Defense", 0.01)
                    )
            )
        .Init("Giant Wasp Warrior",
            new State(
                new Prioritize(
                        new Orbit(0.45, 3),
                        new BackAndForth(0.2, distance: 3)
                        ),
                new State("fight1",
                     new Grenade(4, 60, range: 6, coolDown: 1000),
                     new Shoot(12, count: 3, shootAngle: 14, projectileIndex: 0, coolDown: 2800),
                     new TimedTransition(4600, "fight2")
                    ),
                new State("fight2",
                     new Shoot(12, count: 1, projectileIndex: 0, predictive: 1, coolDown: 400),
                     new TimedTransition(4600, "fight1")
                    )
                )
            )
        .Init("Hive Spawner",
            new State(
                new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                new State("throwwasp",
                     new Reproduce("Hive Wasp Warrior 3", densityMax: 1, coolDown: 2000)
                    )
                ),
                new Threshold(0.025,
                    new ItemLoot("Potion of Speed", 0.38),
                    new ItemLoot("The Bees Knees", 0.04)
                )
            )
        .Init("Honey Bomb",
            new State(
                new OnDeathBehavior(new ApplySetpiece("HoneyDeath")),
                new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                new State("dead",
                     new Suicide()
                    )
                )
           )

        .Init("Hive Spawner Boss",
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                    new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("idle",
                        new EntitiesNotExistsTransition(999, "default", "Hive Spawner")
                        ),
                    new State("default",
                        new PlayerWithinTransition(8, "throwboss")
                        ),
                    new State("throwboss",
                        new TossObject("Polerste, the Fierce Wasp", 5, 270, coolDown: 5200),
                        new TimedTransition(2000, "Block")
                        )
                      ),
                    new State(
                        new TossObject("Honey Bomb", 7, coolDown: new Cooldown(2600, 1600)),
                    new State("Block",
                        new HealSelf(coolDown: 1200, amount: 100),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1200, "noBlock")
                        ),
                    new State("noBlock",
                        new TimedTransition(1200, "Block")
                            )
                        )
                    )
                )
            ;
    }
}