using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Dojo = () => Behav()

           .Init("Arnkz Student",
                    new State(
                    new State("fight1",
                       new Prioritize(
                            new Follow(0.5, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Taunt(0.20, "Hiya!", "Take this!"),
                       new Prioritize(
                            new Orbit(0.3, 3, 10, "Arnkz the Mega Samurai", speedVariance: 0.1, radiusVariance: 0.5),
                            new Charge(1, 10, coolDown: 2000),
                            new Wander(0.5)
                            ),
                       new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 1, coolDown: 2000),
                       new TimedTransition(4000, "fight1")
                        )
                    )
                )
         .Init("Arnkz the Mega Samurai",
                new State(
                    new HpLessTransition(0.2, "rage"),
                    new RealmPortalDrop(),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(8, "taunt1")
                        ),
                     new State("taunt1",
                        new Taunt(1.00, "Hahaha! Don't be scared, are you ready?", "You need to be taught a valuable lesson about true skill!"),
                        new TimedTransition(6000, "fight1")
                         )
                        ),
                     new State(
                         new Reproduce("Arnkz Student", 20, 5, 6000),
                    new State("fight1",
                        new Wander(0.4),
                        new Shoot(10, count: 3, shootAngle: 14, projectileIndex: 1, coolDown: 4000),
                        new Shoot(10, count: 7, shootAngle: 16, projectileIndex: 0, coolDown: 4000),
                        new TimedTransition(5250, "fight2")
                        ),
                     new State("fight2",
                        new Taunt(1.00, "I'm going to slice and dice!"),
                        new Prioritize(
                            new Follow(0.65, 8, 1),
                            new Wander(0.5)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 8, projectileIndex: 3, coolDown: 3000),
                        new Shoot(10, count: 6, projectileIndex: 3, coolDown: 3000, coolDownOffset: 1000),
                        new Shoot(10, count: 4, projectileIndex: 3, coolDown: 3000, coolDownOffset: 1500),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 1, coolDown: 2000),
                        new TimedTransition(6500, "fight3")
                        ),
                    new State("fight3",
                        new Wander(0.75),
                        new Shoot(10, count: 6, projectileIndex: 2, coolDown: 1000),
                        new Shoot(10, count: 6, projectileIndex: 0, coolDown: 1000),
                        new Grenade(5, 150, range: 5, coolDown: 2000),
                        new TimedTransition(6500, "fight4")
                        ),
                     new State("fight4",
                        new Prioritize(
                            new Charge(1, range: 10, coolDown: 3000),
                            new Follow(0.55, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 6, projectileIndex: 3, coolDown: 1000),
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 4, coolDown: 1000, coolDownOffset: 600),
                        new TimedTransition(6000, "fight1")
                        ),
                     new State("rage",
                        new Flash(0xFF0000, 1, 2),
                        new Taunt("My master sure is going to be proud!"),
                        new Prioritize(
                            new Charge(1, range: 10, coolDown: 3000),
                            new Follow(0.75, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 6, projectileIndex: 2, coolDown: 1600),
                        new Shoot(10, count: 6, shootAngle: 8, projectileIndex: 4, coolDown: 1000, coolDownOffset: 1000)
                       
                         ))
                    ),
                new Threshold(0.025,
                    new ItemLoot("Hidden Technique Potion", 1),
                    new ItemLoot("Greater Magic Potion", 1),
                    new ItemLoot("Greater Health Potion", 1),
                    new TierLoot(8, ItemType.Weapon, 0.75),
                    new TierLoot(4, ItemType.Ability, 0.5),
                    new TierLoot(8, ItemType.Armor, 0.5),
                    new TierLoot(3, ItemType.Ring, 0.2),
                    new TierLoot(9, ItemType.Armor, 0.05),
                    new TierLoot(9, ItemType.Weapon, 0.05),
                    new TierLoot(3, ItemType.Ring, 0.025),
                    new ItemLoot("Hidden Technique", 0.1),
                    new ItemLoot("Black Belt", 0.01),
                    new ItemLoot("Ultimate Nunchucks", 0.005)
                )
            )
        ;
    }
}