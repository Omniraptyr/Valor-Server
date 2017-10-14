using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ SkullShrine = () => Behav()
            .Init("Skull Shrine",
                new State(
                    new Shoot(30, 9, 10, coolDown: 750,predictive:1), // add prediction after fixing it...
                    new Reproduce("Red Flaming Skull", 40, 20, coolDown: 500),
                    new Reproduce("Blue Flaming Skull", 40, 20, coolDown: 500)
                    ),
                new Threshold(0.05,
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
                    new ItemLoot("Captain America Seal", .0025),
                    new ItemLoot("Assassin Ring", .0025),
                    new ItemLoot("Large Cloud Cloth", .01),
                    new ItemLoot("Small Cloud Cloth", .01),
                    new ItemLoot("Large Plaid Cloth", .01),
                    new ItemLoot("Small Plaid Cloth", .01),
                    new ItemLoot("Large Skull Cloth", .01),
                    new ItemLoot("Small Skull Cloth", .01),
                    new ItemLoot("Invisi Armor", .0025),
                    new ItemLoot("Orb of Conflict", .001)
                    )
            )
            .Init("Red Flaming Skull",
                new State(
                    new State("Orbit Skull Shrine",
                        new Prioritize(
                            new Protect(.3, "Skull Shrine", 30, 15, 15),
                            new Wander(.3)
                            ),
                        new EntityNotExistsTransition("Skull Shrine", 40, "Wander")
                        ),
                    new State("Wander",
                        new Wander(.3)
                        ),
                    new Shoot(12, 2, 10, coolDown: 750)
                    ),
                    new Threshold(.01,
                        new ItemLoot("Flaming Boomerang", .0005)
                    )
            )
            .Init("Blue Flaming Skull",
                new State(
                    new State("Orbit Skull Shrine",
                        new Orbit(1.5, 15, 40, "Skull Shrine", .6, 10, orbitClockwise: null),
                        new EntityNotExistsTransition("Skull Shrine", 40, "Wander")
                        ),
                    new State("Wander",
                        new Wander(1.5)
                        ),
                    new Shoot(12, 2, 10, coolDown: 750)
                    )
            );
    }
}