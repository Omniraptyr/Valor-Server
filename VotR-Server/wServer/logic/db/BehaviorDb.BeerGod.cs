using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ BeerGod = () => Behav()
        .Init("Beer God",
            new State(
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("default",
                     new PlayerWithinTransition(6, "grow")
                    ),
                new State("grow",
                     new ChangeSize(30, 145),
                     new TimedTransition(5500, "fight1")
                    )
                  ),
                new State("fight1",
                     new Taunt("These drunken barrels are cylinders to perfection"),
                     new Wander(0.5),
                     new Shoot(10, count: 6, projectileIndex: 1, coolDown: 1000),
                     new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: new Cooldown(500, 100)
                    )
                )
            ),
                            new MostDamagers(3,
                    LootTemplates.SorRare()
                    ),
            new Threshold(0.01,
                    new ItemLoot("Mad God Ale", 1.00),
                    new ItemLoot("Oryx Stout", 1.00),
                    new ItemLoot("Realm-wheat Hefeweizen", 1.00)
                )
            )

        ;
    }
}