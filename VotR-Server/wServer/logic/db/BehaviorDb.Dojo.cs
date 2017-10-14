using wServer.realm;
using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Dojo = () => Behav()
         .Init("Arnkz the Mega Samurai",
                new State(
                    new RealmPortalDrop(),
                    new State("default",
                        new PlayerWithinTransition(8, "taunt1"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                        ),
                     new State("taunt1",
                         new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt(1.00, "Hahaha! Don't be scared, is you ready?"),
                        new TimedTransition(3000, "fight1")
                        ),
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
                        new TimedTransition(6500, "fight1")
                        )
                    ),
                new Threshold(0.025,
                    new TierLoot(8, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(8, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(9, ItemType.Armor, 0.05),
                    new TierLoot(9, ItemType.Weapon, 0.05),
                    new TierLoot(3, ItemType.Ring, 0.025),
                    new ItemLoot("Black Belt", 0.05),
                    new ItemLoot("Ultimate Nunchucks", 0.005)
                )
            )

        .Init("Swift Ninja",
                new State(
                    new Taunt(0.5, "I'm too fast for you!"),
                    new Prioritize(
                        new Follow(1.25, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: new Cooldown(350, 100))
                    ),
                new TierLoot(3, ItemType.Weapon, 0.1)
            )
        .Init("Old Wise Sensei",
                new State(
                    new Prioritize(
                        new Follow(0.5, 8, 5),
                        new Wander(0.4)
                        ),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: new Cooldown(2000, 500)),
                    new Shoot(10, count: 3, projectileIndex: 1, coolDown: new Cooldown(4000, 1000))
                    ),
                new TierLoot(3, ItemType.Armor, 0.1)
            )
         .Init("Mad Samurai",
            new State(
                new State("fight1",

                     new Follow(0.4, 8, 1),
                     new Shoot(8.4, count: 3, shootAngle: 20, projectileIndex: 0, coolDown: 2400),
                     new TimedTransition(5000, "fight2")
                    ),
                new State("fight2",
                     new StayBack(0.3, 3),
                     new Shoot(10, count: 4, projectileIndex: 1, coolDown: 3000),
                     new Shoot(8.4, count: 2, projectileIndex: 2, coolDown: 3750),
                     new TimedTransition(5000, "fight1")
                    )
                )
            )
         .Init("Super Good Fighter",
                new State(
                    new Wander(0.2),
                    new Shoot(10, count: 2, projectileIndex: 0, coolDown: new Cooldown(4000, 500)),
                    new Shoot(10, count: 2, projectileIndex: 1, coolDown: new Cooldown(6000, 500))
                    )
            )
        ;
    }
}