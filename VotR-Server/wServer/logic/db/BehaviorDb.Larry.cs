using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Larry = () => Behav()
            .Init("Larry Gigsman, the Superhuman",
                new State(
                    new ScaleHP(100000),
                    new State("default",
                        new Wander(0.05),
                        new PlayerWithinTransition(8, "taunt")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("taunt",
                        new Taunt("You can't possibly beat me..the almighty Larry Gigsman!"),
                        new TimedTransition(10000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt("You don't realize that I am the best of the best!"),
                        new TimedTransition(10000, "taunt3")
                        ),
                    new State("taunt3",
                        new Taunt("Do you wish to fight me?"),
                        new PlayerTextTransition("Start1", "yes")
                        )
                      ),
                    new State(
                        new SetAltTexture(0),
                        new Shoot(10, 4, projectileIndex: 5, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 6, shootAngle: 14, coolDown: 3000, coolDownOffset: 1000),
                        new Prioritize(
                            new Follow(0.4, acquireRange: 15, range: 8),
                            new Wander(0.6)
                            ),
                        new TimedTransition(9200, "Rush"),
                    new State("Start1",
                        new Shoot(10, 10, projectileIndex: 3, coolDown: 1000),
                        new TimedTransition(1000, "Start2")
                        ),
                    new State("Start2",
                        new Shoot(10, 10, projectileIndex: 4, coolDown: 1000),
                        new TimedTransition(1000, "Start1")
                        )
                        ),
                    new State("Rush",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Taunt(0.50, "You won't get away!"),
                        new Prioritize(
                            new Follow(1, 8, 1),
                            new Wander(1)
                            ),
                        new Shoot(10, 12, projectileIndex: 5, coolDown: 3000),
                        new Shoot(10, 1, projectileIndex: 6, coolDown: 500),
                        new TimedTransition(7400, "Pink")
                        ),
                    new State(
                        new Shoot(10, 8, projectileIndex: 5, coolDown: 2000),
                        new Shoot(10, 4, projectileIndex: 6, coolDown: 4000, coolDownOffset: 2000),
                        new Prioritize(
                            new Follow(0.4, acquireRange: 15, range: 8),
                            new Wander(0.6)
                            ),
                        new TimedTransition(9200, "Start1"),
                    new State("Pink",
                        new SetAltTexture(2),
                        new Shoot(10, 5, projectileIndex: 0, shootAngle: 14, coolDown: 600),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, predictive: 1, coolDown: 1800, coolDownOffset: 1000),
                        new TimedTransition(5000, "Orange")
                        ),
                    new State("Orange",
                        new SetAltTexture(1),
                        new Shoot(10, 5, projectileIndex: 1, shootAngle: 14, coolDown: 600),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, predictive: 1, coolDown: 1800, coolDownOffset: 1000),
                        new TimedTransition(5000, "Green")
                        ),
                    new State("Green",
                        new SetAltTexture(3),
                        new Shoot(10, 5, projectileIndex: 2, shootAngle: 14, coolDown: 600),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, predictive: 1, coolDown: 1800, coolDownOffset: 1000),
                        new TimedTransition(5000, "Pink")
                        )
                        ),
                    new State("dead1",
                        new SetAltTexture(4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("I DONT WANNA DIE TODAY"),
                        new TimedTransition(4800, "officiallydead")
                        ),
                    new State("officiallydead",
                        new Suicide()
                        )
                    ),
                new Threshold(0.025,
                    new ItemLoot("Larry Gun", 0.00005),
                    new ItemLoot("Sword of Orange Fever", 0.1),
                    new ItemLoot("Papercutter", 0.1),
                    new ItemLoot("No Sunflowers", 0.1),
                    new ItemLoot("Smileyman's Shank", 0.1),
                    new ItemLoot("Thisswordugly", 0.1),
                    new ItemLoot("Tree Stick Red Wand", 0.1),
                    new ItemLoot("Master Eon", 0.003),
                    new ItemLoot("Gold Cache", 0.1)
                )
          )
        ;
    }
}