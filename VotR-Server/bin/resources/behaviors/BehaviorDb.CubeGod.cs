using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ CubeGod = () => Behav()
            .Init("Cube God",
                new State(
                    new Wander(.3),
                    new Shoot(30, 9, 10, 0, predictive: .5, coolDown: 750),
                    new Shoot(30, 4, 10, 1, predictive: .5, coolDown: 1500),
                    new Reproduce("Cube Overseer", 30, 10, coolDown: 1500)
                    ),
                new Threshold(.05,
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
                    new ItemLoot("Dirk of Cronus", .001),
                    new ItemLoot("Crimson Dagger of Tartarus", 0.0005)
                    )
            )
            .Init("Cube Overseer",
                new State(
                    new Prioritize(
                        new Orbit(.375, 10, 30, "Cube God", .075, 5),
                        new Wander(.375)
                        ),
                    new Reproduce("Cube Defender", 12, 10, coolDown: 1000),
                    new Reproduce("Cube Blaster", 30, 10, coolDown: 1000),
                    new Shoot(10, 4, 10, 0, coolDown: 750),
                    new Shoot(10, projectileIndex: 1, coolDown: 1500)
                    ),
                new Threshold(.01,
                    new ItemLoot("Skull of the Cubes", .0005),
                    new ItemLoot ("Fire Sword", .05)
                    )
            )
            .Init("Cube Defender",
                new State(
                    new Prioritize(
                        new Orbit(1.05, 5, 15, "Cube Overseer", .15, 3),
                        new Wander(1.05)
                        ),
                    new Shoot(10, coolDown: 500)
                    )
            )
            .Init("Cube Blaster",
                new State(
                    new State("Orbit",
                        new Prioritize(
                            new Orbit(1.05, 7.5, 40, "Cube Overseer", .15, 3),
                            new Wander(1.05)
                            ),
                        new EntityNotExistsTransition("Cube Overseer", 10, "Follow")
                        ),
                    new State("Follow",
                        new Prioritize(
                            new Follow(.75, 10, 1, 5000),
                            new Wander(1.05)
                            ),
                        new EntityNotExistsTransition("Cube Defender", 10, "Orbit"),
                        new TimedTransition(5000, "Orbit")
                        ),
                    new Shoot(10, 2, 10, 1, predictive: 1, coolDown: 500),
                    new Shoot(10, predictive: 1, coolDown: 1500)
                    )
            );
    }
}