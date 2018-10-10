using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Suffering = () => Behav()

            .Init("Malgoric Altar Taskmaster",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("spawn",
                    new Spawn("Malgoric Altar", 1, 1, coolDown: 99999)
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )
            .Init("Malgoric Altar",
            new State(
                new HealEntity(99, "Malgor, the Eternal Fiend", 1000, coolDown: 4000),
                new Shoot(3, projectileIndex: 0, coolDown: 4000)
                )
            )
                    .Init("MLair Throne",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )
             .Init("Demonic Scarab",
                new State(
                    new NoPlayerWithinTransition(7, "Idle"),
                    new PlayerWithinTransition(7, "Chase"),
                    new State("Idle",
                        new Wander(.1)
                    ),
                    new State("Chase",
                        new Follow(1.5, 7, 0),
                        new Shoot(3, projectileIndex: 1, coolDown: 400),
                        new Shoot(3, projectileIndex: 0, coolDown: 2000)
                    )
                )
           )
            .Init("Ranger of Malgor",
            new State(
                new State("fight1",
                    new Wander(0.5),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 4000),
                     new TimedTransition(4000, "fight2")
                    ),
                new State("fight2",
                    new Charge(1, 6, coolDown: 3000),
                    new Shoot(10, count: 3, shootAngle: 30, projectileIndex: 0, coolDown: 3000),
                    new TimedTransition(6000, "fight1")
                    )
                )
            )
                    .Init("Mage of Malgor",
            new State(
                new State("fight1",
                    new Orbit(0.5, 4, target: "Malgor, the Eternal Fiend", speedVariance: 0.01, orbitClockwise: true),
                     new Shoot(10, count: 5, shootAngle: 20, projectileIndex: 0, coolDown: 4000),
                     new TimedTransition(4000, "fight2")
                    ),
                new State("fight2",
                    new Orbit(0.5, 4, target: "Malgor, the Eternal Fiend", speedVariance: 0.01, orbitClockwise: false),
                    new Shoot(10, count: 3, shootAngle: 30, projectileIndex: 0, coolDown: 3000),
                    new TimedTransition(6000, "fight1")
                    )
                )
            )
            .Init("Malgor, the Eternal Fiend",
                new State(
                    new State(
                        new AnnounceOnDeath("Another elder has fallen.."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ScaleHP(200000),
                    new State("default",
                        new PlayerWithinTransition(6, "taunt1")
                        ),
                    new State("taunt1",
                        new Taunt("It's sad..it really is.."),
                        new TimedTransition(4000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt("Defeating the Zol made you think you were unstoppable didn't it?"),
                        new TimedTransition(6000, "taunt3")
                        ),
                    new State("taunt3",
                        new Taunt("and successfully sealing one of the elders? Sidon has demanded this ends here, and I will be rewarded greatly for doing so."),
                        new TimedTransition(6000, "taunt4")
                        ),
                    new State("taunt4",
                        new Taunt("There will be blood."),
                        new TimedTransition(4000, "begin")
                        ),
                    new State("begin",
                        new Taunt("Heheh.."),
                        new Flash(0xFF0000, 0.25, 4),
                        new ConditionEffectRegion(ConditionEffectIndex.Bleeding, 999, 12000),
                        new TimedTransition(1000, "Blast")
                        )
                    ),
                    new State(
                        new DamageTakenTransition(1700000, "ragestart"),
                        new Reproduce("Mage of Malgor", 10, 4, coolDown: 2000),
                        new Reproduce("Ranger of Malgor", 10, 4, coolDown: 2000),
                    new State("Blast",
                        new Shoot(10, 12, projectileIndex: 11, coolDown: 2000),
                        new TimedTransition(2000, "fight1")
                        ),
                    new State("fight1",
                        new Grenade(3, 100, range: 5, coolDown: 1000, effect: ConditionEffectIndex.Slowed, effectDuration: 3000, color: 0xFFFF00),
                        new Prioritize(
                            new Follow(1.2, 8, 5),
                            new Charge(2, 8, coolDown: 4000)
                        ),
                        //Swipe Shotgun
                        new Shoot(10, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, projectileIndex: 1, coolDown: 2000, angleOffset: 10),
                        new Shoot(10, projectileIndex: 1, coolDown: 2000, angleOffset: 20),
                        new Shoot(10, projectileIndex: 2, coolDown: 2000, angleOffset: 30),
                        new Shoot(10, projectileIndex: 2, coolDown: 2000, angleOffset: 40),
                        new Shoot(10, projectileIndex: 3, coolDown: 2000, angleOffset: 50),
                        new Shoot(10, projectileIndex: 3, coolDown: 2000, angleOffset: 60),
                        new Shoot(10, projectileIndex: 4, coolDown: 2000, angleOffset: 70),
                        new Shoot(10, projectileIndex: 4, coolDown: 2000, angleOffset: 80),
                        new Shoot(10, projectileIndex: 5, coolDown: 2000, angleOffset: 90),
                        new Shoot(10, projectileIndex: 5, coolDown: 2000, angleOffset: 100),
                        new TimedTransition(8000, "fight2")
                        ),
                    new State("fight2",
                        new Prioritize(
                            new Orbit(0.7, 3, target: null, orbitClockwise: true)
                        ),
                        //Rapid Shotgun and Stun Spiral
                        new Shoot(10, count: 7, shootAngle: 10, projectileIndex: 9, coolDown: 400, predictive: 1),
                        new Shoot(10, count: 3, shootAngle: 30, projectileIndex: 8, coolDown: 600, rotateAngle: 40),
                        new TimedTransition(8000, "return1")
                        ),
                    new State("return1",
                        new ReturnToSpawn(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("You will not prevail!"),
                        new TimedTransition(4000, "fight3")
                        ),
                   new State("fight3",
                        new Prioritize(
                            new Follow(0.7, 8, 1),
                            new Wander(0.1)
                        ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Taunt("You will not prevail!"),
                        //Sporadic Meteor Shotgun
                        new Shoot(10, count: 1, projectileIndex: 10, coolDown: 1800, coolDownOffset: 800),
                        new Shoot(10, count: 1, projectileIndex: 10, coolDown: 1800, coolDownOffset: 600, angleOffset: 70),
                        new Shoot(10, count: 1, projectileIndex: 10, coolDown: 1800, coolDownOffset: 1000, angleOffset: 320),
                        new Shoot(10, count: 1, projectileIndex: 10, coolDown: 1800, coolDownOffset: 1000, predictive: 0.5),
                        new Shoot(10, count: 3, shootAngle: 24, projectileIndex: 10, coolDown: 800, predictive: 0.5),
                        new TimedRandomTransition(8000, false, "fight4A", "fight4B")
                        ),
                    new State("fight4A",
                        //Up Down Shotguns
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 6000),
                        new Reproduce("Demonic Scarab", 10, 4, coolDown: 1000),
                        new Wander(0.5),
                        new Grenade(5, 400, range: 5, coolDown: 1000),

                        new Shoot(10, count: 6, shootAngle: 14, projectileIndex: 3, fixedAngle: 0, coolDown: 1000),
                        new Shoot(10, count: 6, shootAngle: 14, projectileIndex: 3, fixedAngle: 180, coolDown: 1000),

                        new Shoot(10, count: 2, shootAngle: 8, projectileIndex: 7, rotateAngle: -80, coolDown: 400),
                        new Shoot(10, count: 2, shootAngle: 8, projectileIndex: 7, rotateAngle: 80, coolDown: 400),
                        new TimedTransition(10000, "return2")
                        ),
                   new State("fight4B",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 4000),
                        new Reproduce("Demonic Scarab", 10, 4, coolDown: 1000),
                        new Prioritize(
                            new Follow(1, 8, 1),
                            new Wander(0.1)
                        ),
                        //Ring Attack and Heal
                        new HealSelf(coolDown: 2000, amount: 10000),
                        new Shoot(10, count: 6, projectileIndex: 12, rotateAngle: 40, coolDown: 1000),
                        new Shoot(10, count: 1, projectileIndex: 13, fixedAngle: 0, coolDown: 400),
                        new TimedTransition(10000, "return2")
                        ),
                   new State(
                       new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("return2",
                        new ReturnToSpawn(1),
                        new TimedTransition(4000, "blooddrain")
                        ),
                    new State("blooddrain",
                        new Taunt("Ah, the blood of my enemies shall surge my powers!"),
                        new Flash(0x000000, 0.25, 4),
                        new ConditionEffectRegion(ConditionEffectIndex.Bleeding, 999, 8000),
                        new TimedTransition(4000, "Altars")
                            ),
                    new State("Altars",
                        new Order(99, "Malgoric Altar Taskmaster", "spawn"),
                        new TimedTransition(4000, "WaitforAltars")
                            ),
                    new State("WaitforAltars",
                        new Order(99, "Malgoric Altar Taskmaster", "idle"),
                        new EntitiesNotExistsTransition(99, "fight5", "Malgoric Altar"),
                        new Prioritize(
                            new Follow(0.7, 99, 1),
                            new Wander(0.1)
                        ),
                        new Shoot(10, 6, shootAngle: 20, projectileIndex: 11, coolDown: 2000)
                            )
                        ),
                    new State("fight5",
                        new ReturnToSpawn(1),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 4, shootAngle: 90, projectileIndex: 10, rotateAngle: 40, coolDown: 400),
                        new Shoot(10, count: 8, projectileIndex: 8, coolDown: 2000),
                        new TimedTransition(8000, "Blast")
                            )
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("ragestart",
                        new ReturnToSpawn(1),
                        new TimedTransition(4000, "ragetaunt1")
                            ),
                    new State("ragetaunt1",
                        new Taunt("Enough! Come closer or you will SUFFER!"),
                        new TimedTransition(6000, "change")
                            ),
                    new State("change",
                        new ReplaceTile("MLair Floor3", "Super Mega Hot Lava", 99),
                        new ReplaceTile("MLair Floor5", "Super Mega Hot Lava", 99),
                        new ReplaceTile("Blood Ground", "Super Mega Hot Lava", 99),
                        new TimedTransition(6000, "ragefightstart")
                            )
                        ),
                    new State("ragefightstart",
                        new HealSelf(coolDown: 4000, amount: 750000),
                        new MoveTo(1, 21, 19),
                        new TimedTransition(4000, "ragefight")
                            ),
                    new State("ragefight",
                        new Grenade(3, 200, 5, coolDown: 6000),
                        new Reproduce("Demonic Scarab", 10, 2, coolDown: 3000),
                        new Reproduce("Mage of Malgor", 10, 3, coolDown: 2000),
                        new Reproduce("Ranger of Malgor", 10, 3, coolDown: 2000),
                        new Shoot(10, count: 2, shootAngle: 180, projectileIndex: 14, rotateAngle: 90, coolDown: 3600),
                        new Shoot(10, count: 5, shootAngle: 20, projectileIndex: 15, predictive: 0.5, coolDown: 2400),
                        new Shoot(10, count: 1, projectileIndex: 8, coolDown: 3000, predictive: 0.5),
                        new Shoot(10, count: 4, shootAngle: 16, projectileIndex: 6, coolDown: 6000, predictive: 0.5)
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new MostDamagers(3,
                    LootTemplates.GreaterPots()
                    ),
                new MostDamagers(3,
                    LootTemplates.StatPots()
                    ),
                new Threshold(0.001,
                    new ItemLoot("Two Tiny Sor Fragments", 1),
                    new ItemLoot("Onrane Cache", 1),
                    new ItemLoot("Gold Cache", 0.6),
                    new ItemLoot("Onrane", 0.5),
                    new ItemLoot("Small Sor Fragment", 0.25),
                    new ItemLoot("Medium Sor Fragment", 0.1),
                    new ItemLoot("Bone Axe", 0.02),
                    new ItemLoot("Sor Crystal", 0.005),
                    new ItemLoot("Malgoric Skull", 0.02),
                    new ItemLoot("Malgoric Charm", 0.02),
                    new ItemLoot("Master Eon", 0.001),
                    new ItemLoot("Greater Potion of Protection", 1),
                    new ItemLoot("Greater Potion of Vitality", 1),
                    new ItemLoot("Greater Potion of Defense", 1),
                    new ItemLoot("Greater Potion of Life", 1),
                    new ItemLoot("Greater Potion of Defense", 1),
                    new ItemLoot("Greater Potion of Attack", 0.6),
                    new ItemLoot("Greater Potion of Dexterity", 0.5),
                    new ItemLoot("Greater Potion of Luck", 0.5),
                    new ItemLoot("Greater Potion of Restoration", 0.5),
                    new TierLoot(12, ItemType.Weapon, 0.1),
                    new TierLoot(6, ItemType.Ability, 0.1),
                    new TierLoot(13, ItemType.Armor, 0.1),
                    new TierLoot(6, ItemType.Ring, 0.05),
                    new TierLoot(14, ItemType.Armor, 0.05),
                    new TierLoot(13, ItemType.Weapon, 0.05),
                    new TierLoot(7, ItemType.Ring, 0.025)
                )
            )
            ;
    }
}