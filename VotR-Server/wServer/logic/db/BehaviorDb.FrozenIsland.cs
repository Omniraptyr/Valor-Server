using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ FrozenIsland = () => Behav()
        .Init("Frost Wyrm",
                new State(
                    new Prioritize(
                        //new Protect(0.97, "Giant Frost Wyrm", protectionRange: 4),
                        new Follow(0.65, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(7, count: 1, projectileIndex: 0, coolDown: new Cooldown(3000, 2000))
              )
            )
        .Init("Ice Bat",
                new State(
                    new Follow(1.5, 8, 1),
                    new Shoot(10, count: 1, coolDown: 800)
                    )
            )
        .Init("Ice Magician",
                new State(
                    new Prioritize(
                        new Follow(0.4, 8, 1),
                        new Wander(0.4)
                        ),
                    new Shoot(7, count: 3, shootAngle: 6, projectileIndex: 0, predictive: 1, coolDown: new Cooldown(3000, 1000))
              ),
            new ItemLoot("Charcoal", 0.1)
            )
        .Init("Knight of Frost",
                new State(
                    new Prioritize(
                        new Follow(0.25, 8, 1),
                        new Wander(0.4)
                        ),
                    new Shoot(7, count: 1, projectileIndex: 0, coolDown: 2000),
                    new Shoot(7, count: 5, shootAngle: 8, projectileIndex: 1, coolDown: 3000)
              ),
            new ItemLoot("Wheat", 0.1)
            )
        .Init("Warrior of Frost",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.6)
                        ),
                    new Shoot(7, count: 1, projectileIndex: 0, coolDown: 1400)
              )
            )
        .Init("Ice Soul Shield",
                new State(
                    new Swirl(0.6, 6),
                    new Grenade(4, 80, coolDown: 2800)
              )
            )
        .Init("Ice Cleric",
                new State(
                    new Prioritize(
                        new Follow(0.4, 8, 1),
                        new Wander(0.4)
                        ),
                    new HealEntity(5, "IceCleric", 100, coolDown: 2000),
                    new Shoot(7, count: 3, shootAngle: 60, projectileIndex: 0, coolDown: new Cooldown(3000, 500))
                )
            )
        .Init("Great Wizard of Frost",
                new State(
                  new State("Shoot1",
                    new Wander(0.45),
                        new Shoot(10, count: 3, shootAngle: 30, predictive: 1, projectileIndex: 1, coolDown: 1250),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 825),
                        new TimedTransition(4450, "Charge")
                        ),
                    new State("Charge",
                      new Follow(0.4, 8, 1),
                      new Shoot(10, count: 7, projectileIndex: 0, coolDown: 2500),
                      new TimedTransition(7500, "Blamo")
                    ),
                    new State("Blamo",
                     new Prioritize(
                        new Follow(0.3, 8, 1),
                        new Wander(0.3)
                       ),
                     new Shoot(10, count: 4, shootAngle: 24, projectileIndex: 1, coolDown: 1750),
                     new TossObject("Ice Soul Shield", coolDown: 3000),
                     new TimedTransition(9000, "Shoot1")
                    )
                 )
              )
        .Init("Frost Giant",
                new State(
                  new State("FightAndGuard",
                        new Taunt(0.20, "Aaaraauggh!"),
                        new Prioritize(
                          new Follow(0.25, 8, 1),
                          new Wander(0.2)
                        ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 6, shootAngle: 22, projectileIndex: 1, coolDown: 2750),
                        new Shoot(10, count: 3, shootAngle: 22, predictive: 2.5, projectileIndex: 0, coolDown: 3250),
                        new TimedTransition(8000, "FightAndGetHard")
                        ),
                    new State("FightAndGetHard",
                      new Taunt(0.20, "Aaaraauggh!"),
                        new Prioritize(
                          new Follow(0.25, 8, 1),
                          new Wander(0.2)
                        ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 8, shootAngle: 22, projectileIndex: 1, coolDown: 2750),
                        new Shoot(10, count: 6, shootAngle: 22, predictive: 2.5, projectileIndex: 0, coolDown: 3250),
                        new TimedTransition(4000, "Spawn")
                        ),
                    new State("Spawn",
                     new Prioritize(
                        new Follow(0.37, 8, 1),
                        new Wander(0.3)
                       ),
                     new Shoot(10, count: 4, shootAngle: 24, projectileIndex: 1, coolDown: 1750),
                     new Reproduce("Warrior of Frost", densityMax: 1, densityRadius: 16, coolDown: new Cooldown(4600, 1000)),
                     new Reproduce("Knight of Frost", densityMax: 1, densityRadius: 16, coolDown: new Cooldown(4600, 1000)),
                     new TimedTransition(6000, "FightAndGuard")
                    )
                 )
              )
        .Init("Blizzard Skeleton",
                new State(
                  new State("RunFast",
                        new Prioritize(
                          new StayAbove(0.8, 2),
                          new Follow(0.7, 8, 1),
                          new Wander(0.4)
                        ),
                        new Shoot(10, count: 2, shootAngle: 40, predictive: 1, projectileIndex: 2, coolDown: 800),
                        new Shoot(10, count: 8, projectileIndex: 1, coolDown: 4000),
                        new TimedTransition(4500, "BigAttack")
                        ),
                    new State("BigAttack",
                        new Prioritize(
                          new Follow(0.4, 8, 1),
                          new Wander(0.6)
                        ),
                        new Shoot(10, count: 6, shootAngle: 18, projectileIndex: 0, coolDown: 2800),
                        new Shoot(10, count: 4, shootAngle: 28, predictive: 2, projectileIndex: 1, coolDown: 3200),
                        new Grenade(3, 230, coolDown: 3000),
                        new TimedTransition(6000, "RunFast")
                        )
                     )
                  )
        .Init("Fighter of Frost",
                new State(
                  new State("Fighter",
                        new Prioritize(
                          new Follow(0.3, 8, 1),
                          new Wander(0.4)
                        ),
                        new Shoot(10, count: 3, shootAngle: 30, predictive: 1, projectileIndex: 0, coolDown: 2400),
                        new TimedTransition(5000, "Mightier")
                        ),
                    new State("Mightier",
                        new Flash(0x0000FF, 2, 2),
                        new Charge(0.6, 6, coolDown: 3000),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(5000, "Fighter")
                        )
                     )
                  )

          ;
    }
}