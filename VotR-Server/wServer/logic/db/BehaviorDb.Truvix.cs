using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Truvix = () => Behav()
            .Init("Truvix, the Lord Wanderer",
                new State(
                    new DropPortalOnDeath("The Genisus Portal"),
                    new OrderOnDeath(60, "Genisus Inhibitor", "dead"),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(4, "taunt")
                        ),
                    new State("taunt",
                        new Taunt("You dare march into my sacred domain.."),
                        new TimedTransition(3000, "taunt2")
                        ),
                    new State("taunt2",
                        new Order(60, "Genisus Inhibitor", "shoot"),
                        new Taunt("I will send you on your way to eternal suffering...", "Surrender to your banishment."),
                        new TimedTransition(3000, "battle1")
                        )
                    ),
                    new State(
                        new HpLessTransition(.2, "rage"),
                    new State(
                        new Spawn("Truvix Follower", 5, coolDown: 10000),
                        new Spawn("Truvix Bladesman", 3, coolDown: 14000),
                    new State("battle1",
                        new Shoot(10, projectileIndex: 1, fixedAngle: 0, coolDown: 2000),
                        new Shoot(10, projectileIndex: 1, fixedAngle: 45, coolDown: 2000, coolDownOffset: 200),
                        new Shoot(10, projectileIndex: 1, fixedAngle: 90, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, projectileIndex: 1, fixedAngle: 135, coolDown: 2000, coolDownOffset: 600),
                        new Shoot(10, projectileIndex: 1, fixedAngle: 180, coolDown: 2000, coolDownOffset: 800),
                        new Shoot(10, projectileIndex: 1, fixedAngle: 225, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, projectileIndex: 1, fixedAngle: 270, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, projectileIndex: 1, fixedAngle: 315, coolDown: 2000, coolDownOffset: 1400),
                        new TimedTransition(20000, "battle2"),
                    new State("fight1",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 3),
                            new Wander(0.05)
                        ),
                        new Shoot(10, 4, shootAngle: 8, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, 6, shootAngle: 20, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new HealSelf(9999, 12500),
                        new Prioritize(
                            new Follow(0.7, 8, 1),
                            new Wander(0.05)
                        ),
                        new Shoot(10, 6, shootAngle: 10, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(4000, "return")
                        ),
                    new State("return",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ConditionalEffect(ConditionEffectIndex.ParalyzeImmune),
                        new ReturnToSpawn(2),
                        new TimedTransition(4000, "fight1")
                        )
                    ),
                    new State("battle2",
                        new TossObject("Truvix Bladesman", 3, 0, coolDown: 9999999),
                        new TossObject("Truvix Bladesman", 3, 270, coolDown: 9999999),
                        new TossObject("Truvix Bladesman", 3, 90, coolDown: 9999999),
                        new TossObject("Truvix Bladesman", 3, 180, coolDown: 9999999),
                        new Prioritize(
                            new Charge(0.5, range: 6, coolDown: 6000),
                            new Wander(0.05)
                        ),
                        new Shoot(10, projectileIndex: 2, predictive: 1, coolDown: 1000),

                        new Shoot(10, 4, shootAngle: 18, projectileIndex: 3, coolDown: 2000),


                        new Shoot(10, projectileIndex: 4, fixedAngle: 0, coolDown: 4000),
                        new Shoot(10, projectileIndex: 4, fixedAngle: 45, coolDown: 4000),
                        new Shoot(10, projectileIndex: 4, fixedAngle: 90, coolDown: 4000),
                        new Shoot(10, projectileIndex: 4, fixedAngle: 135, coolDown: 4000),
                        new Shoot(10, projectileIndex: 4, fixedAngle: 180, coolDown: 4000),
                        new Shoot(10, projectileIndex: 4, fixedAngle: 225, coolDown: 4000),
                        new Shoot(10, projectileIndex: 4, fixedAngle: 270, coolDown: 4000),
                        new Shoot(10, projectileIndex: 4, fixedAngle: 315, coolDown: 4000),

                        new TimedTransition(14000, "return2")
                        ),
                    new State("return2",
                        new HealSelf(coolDown: 1000, amount: 500),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ConditionalEffect(ConditionEffectIndex.ParalyzeImmune),
                        new ReturnToSpawn(2),
                        new TimedTransition(4000, "battle3")
                        ),
                    new State("battle3",
                        new Prioritize(
                            new Orbit(0.8, 2, 10, null),
                            new Wander(0.05)
                        ),
                        new HealSelf(9999, 2500),
                        new Shoot(10, 2, shootAngle: 4, projectileIndex: 5, coolDown: 2400),
                        new TossObject("Truvix Bomb", 3, 0, coolDown: 9999999),
                        new TossObject("Truvix Bomb", 6, 45, coolDown: 9999999),
                        new TossObject("Truvix Bomb", 3, 90, coolDown: 9999999),
                        new TossObject("Truvix Bomb", 6, 135, coolDown: 9999999),
                        new TossObject("Truvix Bomb", 3, 180, coolDown: 9999999),
                        new TossObject("Truvix Bomb", 6, 225, coolDown: 9999999),
                        new TossObject("Truvix Bomb", 3, 270, coolDown: 9999999),
                        new TossObject("Truvix Bomb", 6, 315, coolDown: 9999999),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(10000, "battle4")
                            ),
                     new State("battle4",
                         new Wander(0.01),
                        new RemoveEntity(30, "Truvix Bladesman"),
                        new Grenade(4, 50, range: 8, coolDown: 2000),
                        new Shoot(10, 8, projectileIndex: 2, coolDown: 6000),
                        new Shoot(10, 3, shootAngle: 4, projectileIndex: 1, coolDown: 400),
                        new TimedTransition(6000, "battle1")
                            )
                        )
                     ),
                     new State("rage",
                        new Prioritize(
                            new Follow(0.7, 8, 1),
                            new Wander(0.05)
                        ),
                        new HealSelf(coolDown: 99999, amount: 7500),
                        new Shoot(10, projectileIndex: 5, predictive: 1, coolDown: 2000),
                        new Shoot(10, 5, shootAngle: 30, projectileIndex: 3, coolDown: 1000),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TossObject("Truvix Bomb", range: 6, coolDown: 5000)
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor3Perc()
                    ),
                new Threshold(0.01,
                    new ItemLoot("Potion of Vitality", 0.1),
                    new ItemLoot("Potion of Attack", 0.1),
                    new TierLoot(11, ItemType.Weapon, 1),
                    new TierLoot(6, ItemType.Ability, 0.5),
                    new TierLoot(11, ItemType.Armor, 1),
                    new TierLoot(5, ItemType.Ring, 0.5),
                    new TierLoot(12, ItemType.Armor, 0.1),
                    new TierLoot(12, ItemType.Weapon, 0.1),
                    new TierLoot(6, ItemType.Ring, 0.1),
                    new ItemLoot("Guardian Sword", 0.001),
                    new ItemLoot("Truestone Ring", 0.01),
                    new ItemLoot("Prime Chaotic Seal", 0.01),
                    new ItemLoot("Ascendant Quiver", 0.005)
                )
            )
            .Init("Genisus Inhibitor",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("shoot",
                        new Shoot(10, projectileIndex: 0, fixedAngle: 0, coolDown: 4000),
                        new Shoot(10, projectileIndex: 0, fixedAngle: 45, coolDown: 4000, coolDownOffset: 600),
                        new Shoot(10, projectileIndex: 0, fixedAngle: 90, coolDown: 4000, coolDownOffset: 1200),
                        new Shoot(10, projectileIndex: 0, fixedAngle: 135, coolDown: 4000, coolDownOffset: 1800),
                        new Shoot(10, projectileIndex: 0, fixedAngle: 180, coolDown: 4000, coolDownOffset: 2400),
                        new Shoot(10, projectileIndex: 0, fixedAngle: 225, coolDown: 4000, coolDownOffset: 3000),
                        new Shoot(10, projectileIndex: 0, fixedAngle: 270, coolDown: 4000, coolDownOffset: 3600),
                        new Shoot(10, projectileIndex: 0, fixedAngle: 315, coolDown: 4000, coolDownOffset: 4200)
                    ),
               new State("dead",
                        new Suicide()
                    )
                )
            )

                    .Init("Truvix Follower",
                new State(
                    new Prioritize(
                        new StayBack(0.4, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 2, shootAngle: 10, projectileIndex: 1, coolDown: 1000),
                    new Shoot(8, 1, shootAngle: 10, projectileIndex: 0, predictive: 1, coolDown: 2000)
                    )
            )

                        .Init("Truvix Bladesman",
                new State(
                    new Prioritize(
                        new Follow(0.6, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 4, shootAngle: 10, coolDown: 800)
                    )

                 )

            .Init("Truvix Bomb",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(3000, "Explode")
                        ),
                    new State("Explode",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Shoot(100, projectileIndex: 0, count: 10),
                        new Suicide()
                        )
                    )
            )


            ;
    }
}