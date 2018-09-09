using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Hollows = () => Behav()
        .Init("Hand of Terradius Activater",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ChangeSize(15, 100),
                        new TimedTransition(2000, "die")
                    ),
                    new State("die",
                        new State("dead",
                            new Decay()
                       )
                    )
                )
            )
       .Init("Hand of Terradius Crystal",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("yep",
                        new Orbit(0.25, 6, 30, "Hand of Terradius"),
                        new Grenade(4, 360, range: 8, coolDown: 6000),
                        new Shoot(8.4, count: 5, projectileIndex: 0, coolDown: new Cooldown(4000, 2000))
                        ),
                    new State("yep2",
                        new Flash(0x00FF00, 2, 1),
                        new Sequence(
                            new Timed(5000,
                                new Prioritize(
                                    new Orbit(0.40, 8, 11),
                                    new Shoot(8.4, count: 5, projectileIndex: 0, coolDown: 1000)
                                    )),
                            new Timed(6000,
                                new Prioritize(
                                    new Orbit(0.40, 6, 100, "Hand of Terradius"),
                                    new Shoot(8.4, count: 6, shootAngle: 6, projectileIndex: 0, coolDown: new Cooldown(500, 100))
                                    )
                                )
                        )
                    )
                 )
            )
        .Init("Hand of Terradius",
                new State(
                    new AnnounceOnDeath("One of Terradius's henchmen are down..3 more to go.."),
                    new HpLessTransition(0.11, "Die"),
                    new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("default",
                        new PlayerWithinTransition(4, "awaken")
                        ),
                    new State("awaken",
                        new SetAltTexture(1),
                        new ChangeSize(20, 140),
                        new TimedTransition(6000, "taunt1")
                        ),
                    new State("taunt1",
                        new Taunt("I have awoken for a purpose."),
                        new TimedTransition(4500, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt("My purpose is to obliterate any entity that threatens Terradius."),
                        new TimedTransition(4500, "taunt3")
                        ),
                    new State("taunt3",
                        new Taunt("I serve him. Orders are orders. Prepare to die."),
                        new TimedTransition(4000, "aw2")
                        ),
                    new State("aw2",
                        new ChangeSize(10, 155),
                        new Flash(0xFF0000, 1, 2),
                        new TimedTransition(3000, "spawncrystal")
                        )
                     ),
                    new State("spawncrystal",
                        new InvisiToss("Hand of Terradius Crystal", 6, 0, coolDown: 9999999),
                        new TimedTransition(1200, "Fight")
                        ),
                    new State("Fight",
                        new Prioritize(
                            new Follow(0.6, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 8, shootAngle: 8, projectileIndex: 0, coolDown: new Cooldown(1200, 600)),
                        new Shoot(10, count: 12, projectileIndex: 2, coolDown: new Cooldown(3000, 200)),
                        new Grenade(3, 300, range: 8, coolDown: new Cooldown(4000, 2000)),
                        new TimedTransition(9000, "Fight2")
                        ),
                    new State("Fight2",
                        new Taunt("Behold! Strength like no other!", "Welcome to your grave."),
                        new Prioritize(
                            new Follow(0.4, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 4, shootAngle: 8, predictive: 1, projectileIndex: 0, coolDown: new Cooldown(1000, 200)),
                        new Shoot(10, count: 18, projectileIndex: 2, coolDown: new Cooldown(8000, 200)),
                        new Grenade(1, 100, range: 8, coolDown: new Cooldown(2000, 2000)),
                        new TimedTransition(8000, "Fight3")
                        ),
                    new State("Fight3",
                        new Flash(0x0000FF, 1, 1),
                        new Prioritize(
                            new StayBack(0.3, 2),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 8, shootAngle: 12, projectileIndex: 1, coolDown: new Cooldown(1000, 200)),
                        new Shoot(10, count: 4, shootAngle: 4, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(6000, "wanderandshoot")
                        ),
                    new State(
                    new State("wanderandshoot",
                        new Sequence(
                            new Timed(3000,
                                new Follow(0.4, 8, 1)
                                ),
                            new Timed(4000,
                                new Wander(0.6)
                                ),
                            new Timed(3000,
                                new Charge(1, range: 8, coolDown: 3000)
                                )
                        ),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 0, coolDown: new Cooldown(4000, 2000)),
                        new Shoot(10, count: 10, projectileIndex: 5, coolDown: 2000),
                        new Shoot(10, count: 3, shootAngle: 6, predictive: 0.5, projectileIndex: 3, coolDown: new Cooldown(2000, 2000)),
                        new TimedTransition(10000, "returntospawn")
                        )
                      ),
                    new State("returntospawn",
                        new ReturnToSpawn(speed: 1),
                        new Order(90, "Hand of Terradius Crystal", "yep2"),
                        new TimedTransition(3000, "stayinplace")
                        ),
                    new State(
                        new HealSelf(coolDown: new Cooldown(3000, 1000), amount: 2500),
                        new TimedTransition(18000, "chargerush"),
                    new State("stayinplace",
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 3, coolDown: 1000),
                        new Shoot(10, count: 12, projectileIndex: 4, coolDown: 2000),
                        new TimedTransition(6000, "stayinplace1")
                        ),
                    new State("stayinplace1",
                        new Grenade(2, 300, 4, coolDown: 500),
                        new Shoot(10, count: 24, projectileIndex: 5, coolDown: 2000),
                        new TimedTransition(3000, "stayinplace2")
                        ),
                    new State("stayinplace2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 3, coolDown: 1000),
                        new Shoot(10, count: 12, projectileIndex: 4, coolDown: 2000),
                        new TimedTransition(6000, "stayinplace3")
                        ),
                    new State("stayinplace3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 24, projectileIndex: 5, coolDown: 2000),
                        new Grenade(2, 300, 4, coolDown: 500),
                        new TimedTransition(3000, "stayinplace")
                        )
                      ),
                    new State("chargerush",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFF0000, 1, 1),
                        new Order(90, "Hand of Terradius Crystal", "yep"),
                        new TimedTransition(3000, "Rush1")
                        ),
                    new State("Rush1",
                        new HealSelf(coolDown: 200, amount: 250),
                        new Taunt("This power...IT EMERGES WITHIN!", "You can't resist against this pure strength!", "Your death approaches, {PLAYER}."),
                        new Prioritize(
                            new Follow(1, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 4, shootAngle: 10, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 8, projectileIndex: 1, coolDown: new Cooldown(1200, 200)),
                        new Shoot(10, count: 2, shootAngle: 20, predictive: 1, projectileIndex: 2, coolDown: 500),
                        new TimedTransition(8000, "Rush2")
                        ),
                    new State("Rush2",
                        new Taunt("Awakening me was a mistake."),
                        new Swirl(0.3, radius: 6),
                        new Shoot(10, count: 16, shootAngle: 14, projectileIndex: 5, coolDown: 500),
                        new Shoot(10, count: 1, projectileIndex: 5, coolDown: 100),
                        new TimedTransition(8000, "Wander1")
                        ),
                    new State("Wander1",
                        new HealSelf(coolDown: 3000, amount: 4000),
                        new Taunt("We WILL NOT FALL."),
                        new Wander(0.1),
                        new TossObject("Terradius Servant A", 2, angle: 0, coolDown: 99999),
                        new TossObject("Terradius Servant A", 2, angle: 90, coolDown: 99999),
                        new TossObject("Terradius Servant A", 2, angle: 180, coolDown: 99999),
                        new TossObject("Terradius Servant A", 2, angle: 270, coolDown: 99999),
                        new Shoot(10, count: 10, shootAngle: 18, projectileIndex: 1, coolDown: 1000),
                        new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 10, projectileIndex: 4, coolDown: 2000),
                        new TimedTransition(7200, "Fight")
                        ),
                    new State("Die",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("My life essence withers away...", "It..is...over"),
                        new ReturnToSpawn(speed: 1),
                        new RemoveEntity(999, "Hand of Terradius Crystal"),
                        new TimedTransition(4000, "rip")
                        ),
                    new State("rip",
                        new Suicide()
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.GreaterPots()
                    ),
                new Threshold(0.025,
                    new ItemLoot("Sor Fragment Cache", 0.75),
                    new ItemLoot("Onrane Cache", 0.75),
                    new ItemLoot("Onrane", 1.00),
                    new ItemLoot("Large Sor Fragment", 0.33),
                    new ItemLoot("Mirror Dagger", 0.25),
                    new ItemLoot("Adroit Armor", 0.25),
                    new TierLoot(6, ItemType.Ability, 0.1),
                    new TierLoot(12, ItemType.Armor, 0.1),
                    new TierLoot(12, ItemType.Weapon, 0.1),
                    new TierLoot(6, ItemType.Ring, 0.1)
                )
            )
        .Init("Terradius Servant A",
                new State(
                    new State("Go1",
                        new Prioritize(
                            new Follow(0.5, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 6, shootAngle: 4, projectileIndex: 0, coolDown: 600),
                        new TimedTransition(4000, "Go2")
                    ),
                    new State("Go2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Prioritize(
                            new StayBack(0.4, 4),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 10, shootAngle: 6, projectileIndex: 0, coolDown: 1200),
                        new TimedTransition(4000, "Go1")
                    )
                )
            );
    }
}