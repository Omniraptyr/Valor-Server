using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Kraken = () => Behav()
            .Init("Kraken Spawner A",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                    new PlayerWithinTransition(5, "spawn", true)
                    ),
                new State("spawn",
                    new Spawn("The Kraken A", 1, 1, coolDown: 9999),
                    new TimedTransition(2000, "idle2")
                    ),
                new State("idle2"
                    )
                )
            )
           .Init("Kraken Spawner B",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("nooneyet"
                    ),
                new State("idle",
                    new PlayerWithinTransition(5, "spawn", true)
                    ),
                new State("spawn",
                    new Spawn("The Kraken B", 1, 1, coolDown: 9999),
                    new TimedTransition(2000, "idle2")
                    ),
                new State("idle2"
                    )
                )
            )
            .Init("Kraken Spawner C",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("nooneyet"
                    ),
                new State("idle",
                    new PlayerWithinTransition(5, "spawn", true)
                    ),
                new State("spawn",
                    new Spawn("The Kraken C", 1, 1, coolDown: 9999),
                    new TimedTransition(2000, "idle2")
                    ),
                new State("idle2"
                    )
                )
            )
            .Init("Kraken Tentacle",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new SetAltTexture(0, 1, 100, true),
                new Shoot(10, 8, projectileIndex: 1, coolDown: 1000),
                new State("shoot",
                    new Shoot(10, 1, projectileIndex: 0, predictive: 0.5, coolDown: new Cooldown(4000, 4000), coolDownOffset: 4000)
                    ),
                new State("idle"
                    ),
                new State("grenades",
                    new Grenade(3, 200, range: 7, coolDown: new Cooldown(2000, 8000), effect: ConditionEffectIndex.Slowed, effectDuration: 2)
                    ),
                new State("both",
                    new Shoot(10, 1, projectileIndex: 0, predictive: 0.5, coolDown: new Cooldown(4000, 4000), coolDownOffset: 4000),
                    new Grenade(3, 200, range: 7, coolDown: new Cooldown(2000, 8000), effect: ConditionEffectIndex.Slowed, effectDuration: 2)
                    )
                )
            )
            .Init("Kraken Tentacle 2",
            new State(
                new Orbit(0.3, 3, target: "The Kraken", speedVariance: 0.01),
                new SetAltTexture(0, 1, 100, true),
                new Shoot(10, 8, projectileIndex: 1, coolDown: 1000),
                new State("shoot",
                    new Shoot(10, 1, projectileIndex: 0, predictive: 0.5, coolDown: new Cooldown(4000, 10000), coolDownOffset: 4000)
                    )
                )
            )
            .Init("Kraken Spawner D",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("nooneyet"
                    ),
                new State("idle",
                    new PlayerWithinTransition(5, "spawn", true)
                    ),
                new State("spawn",
                    new Spawn("The Kraken D", 1, 1, coolDown: 9999),
                    new TimedTransition(2000, "idle2")
                    ),
                new State("idle2"
                    )
                )
            )
            .Init("Kraken Spawner",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("nooneyet"
                    ),
                new State("idle",
                    new TimedTransition(6000, "spawn")
                    ),
                new State("spawn",
                    new Spawn("The Kraken", 1, 1, coolDown: 9999),
                    new TimedTransition(2000, "idle2")
                    ),
                new State("idle2"
                    )
                )
            )

        .Init("The Kraken",
                new State(
                    new AnnounceOnDeath("The Kraken was demolished in the safety of his own lair!"),
                    new State(
                        new DamageTakenTransition(45000, "die"),
                    new State("default",
                        new PlayerWithinTransition(8, "transition")
                        ),
                    new State("transition",
                        new SetAltTexture(1),
                        new TimedTransition(200, "transition2")
                        ),
                    new State("transition2",
                        new SetAltTexture(2),
                        new TimedTransition(200, "transition3")
                        ),
                    new State("transition3",
                        new SetAltTexture(3),
                        new TimedTransition(200, "transition4")
                        ),
                    new State("transition4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new InvisiToss("Kraken Tentacle 2", 3, 0, coolDown: 9999999),
                        new InvisiToss("Kraken Tentacle 2", 3, 45, coolDown: 9999999),
                        new InvisiToss("Kraken Tentacle 2", 3, 90, coolDown: 9999999),
                        new InvisiToss("Kraken Tentacle 2", 3, 135, coolDown: 9999999),
                        new InvisiToss("Kraken Tentacle 2", 3, 180, coolDown: 9999999),
                        new InvisiToss("Kraken Tentacle 2", 3, 225, coolDown: 9999999),
                        new InvisiToss("Kraken Tentacle 2", 3, 270, coolDown: 9999999),
                        new InvisiToss("Kraken Tentacle 2", 3, 315, coolDown: 9999999),
                        new TimedTransition(3200, "Stage1")
                        ),
                    new State(
                        new EntitiesNotExistsTransition(20, "Vulnerable","Kraken Tentacle 2"),
                        new TossObject("Giant Squid", 8, coolDown: new Cooldown(40000, 20000)),
                    new State("Stage1",
                        new Shoot(10, 8, projectileIndex: 1, shootAngle: 12, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 12, projectileIndex: 5, coolDown: 2000, coolDownOffset: 2000),
                        new TimedTransition(10000, "Stage2")
                        ),
                    new State("Stage2",
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, fixedAngle: 90, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, fixedAngle: 180, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, fixedAngle: 270, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, fixedAngle: 0, coolDown: 2000, coolDownOffset: 2000),


                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, fixedAngle: 45, coolDown: 2000, coolDownOffset: 6000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, fixedAngle: 135, coolDown: 2000, coolDownOffset: 6000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, fixedAngle: 225, coolDown: 2000, coolDownOffset: 6000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 8, fixedAngle: 315, coolDown: 2000, coolDownOffset: 6000),
                        new TimedTransition(10000, "Stage3")
                        ),
                    new State("Stage3",
                        new Shoot(10, 3, projectileIndex: 0, shootAngle: 40, coolDown: 1000, coolDownOffset: 3000),
                        new Shoot(10, 3, projectileIndex: 5, shootAngle: 10, fixedAngle: 90, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 3, projectileIndex: 5, shootAngle: 10, fixedAngle: 180, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 3, projectileIndex: 5, shootAngle: 10, fixedAngle: 270, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 3, projectileIndex: 5, shootAngle: 10, fixedAngle: 0, coolDown: 2000, coolDownOffset: 2000),
                        new TimedTransition(10000, "Stage4")
                        ),
                    new State("Stage4",
                         new Flash(0x00FFFF, 1, 2),
                        new TimedTransition(6000, "Stage5"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Quadforce1")
                        )
                     ),
                     new State("Stage5",
                        new Shoot(10, 3, projectileIndex: 4, shootAngle: 40, coolDown: 2000),
                        new Shoot(10, 6, projectileIndex: 3, coolDown: 4000),
                        new Shoot(10, 1, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(10000, "Stage1")
                        )
                    ),
                    new State("Vulnerable",
                        new Taunt("Skreee..."),
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                        new Flash(0x00FF00, 0.25, 4),
                        new TimedTransition(10000, "transition4")
                      )
                    ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                   new State("die",
                        new RemoveEntity(10, "Kraken Tentacle 2"),
                        new Taunt("SKRAAAAAAAAAAAAAAAA!"),
                        new Flash(0xFF0000, .25, 4),
                        new TimedTransition(4000, "die3")
                        ),
                   new State("die3",
                        new Shoot(8, count: 20, projectileIndex: 1, coolDown: 9999),
                        new Suicide()
                            )
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
                    new ItemLoot("Banner of the Furious Kraken", 0.50),
                    new TierLoot(6, ItemType.Ability, 0.7),
                    new TierLoot(12, ItemType.Armor, 0.07),
                    new TierLoot(12, ItemType.Weapon, 0.07),
                    new TierLoot(6, ItemType.Ring, 0.07)
                )
             )

                    .Init("The Kraken B",
                new State(
                    new State(
                        new DamageTakenTransition(25000, "die"),
                    new State("default",
                        new PlayerWithinTransition(8, "transition")
                        ),
                    new State("transition",
                        new SetAltTexture(1),
                        new TimedTransition(200, "transition2")
                        ),
                    new State("transition2",
                        new SetAltTexture(2),
                        new TimedTransition(200, "transition3")
                        ),
                    new State("transition3",
                        new SetAltTexture(3),
                        new TimedTransition(200, "transition4")
                        ),
                    new State("transition4",
                        new InvisiToss("Kraken Tentacle", range: 2, angle: 0, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 4, angle: 0, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 2, angle: 180, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 4, angle: 180, coolDown: 9999),
                        new TimedTransition(1000, "Stage1")
                        ),
                    new State("Stage1",
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -10, coolDown: 1200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -20, coolDown: 1200, coolDownOffset: 400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -30, coolDown: 1200, coolDownOffset: 800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -40, coolDown: 1200, coolDownOffset: 1200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -50, coolDown: 1200, coolDownOffset: 1600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -60, coolDown: 1200, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -70, coolDown: 1200, coolDownOffset: 2400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -80, coolDown: 1200, coolDownOffset: 2800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -90, coolDown: 1200, coolDownOffset: 3200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -100, coolDown: 1200, coolDownOffset: 3600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -110, coolDown: 1200, coolDownOffset: 4000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -120, coolDown: 1200, coolDownOffset: 4400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -130, coolDown: 1200, coolDownOffset: 4800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -140, coolDown: 1200, coolDownOffset: 5200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -150, coolDown: 1200, coolDownOffset: 5600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -160, coolDown: 1200, coolDownOffset: 6000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -170, coolDown: 1200, coolDownOffset: 6400),
                        new TimedTransition(10000, "Vulnerable1")
                        ),
                    new State("Vulnerable1",
                        new Order(10, "Kraken Tentacle", "grenades"),
                        new TimedTransition(6000, "Stage2")
                        ),
                    new State("Stage2",
                        new Order(10, "Kraken Tentacle", "idle"),
                        new Taunt(.50, "SKREEE!"),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -30, coolDown: 200, coolDownOffset: 3000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -150, coolDown: 200, coolDownOffset: 3000),


                        new Shoot(10, 1, projectileIndex: 1, fixedAngle: -70, coolDown: 2000),
                        new Shoot(10, 1, projectileIndex: 1, fixedAngle: -90, coolDown: 2000),
                        new Shoot(10, 1, projectileIndex: 1, fixedAngle: -110, coolDown: 2000),

                        new Shoot(10, 2, projectileIndex: 2, fixedAngle: -70, shootAngle: 10, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, 2, projectileIndex: 2, fixedAngle: -90, shootAngle: 10, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, 2, projectileIndex: 2, fixedAngle: -110, shootAngle: 10, coolDown: 2000, coolDownOffset: 1200),
                        new TimedTransition(8000, "Stage3")
                        ),
                   new State("Stage3",
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -10, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -20, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -30, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -40, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -50, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -60, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -70, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -80, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -100, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -110, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -120, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -130, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -140, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -150, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -160, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: -170, coolDown: 1000, coolDownOffset: 2000),
                        new TimedTransition(10000, "Stage4")
                        ),
                   new State("Stage4",
                        new Order(10, "Kraken Tentacle", "shoot"),
                        new Shoot(10, 1, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, 2, projectileIndex: 4, shootAngle: -20, coolDown: 3000, coolDownOffset: 2000),
                        new Shoot(10, 4, projectileIndex: 3, shootAngle: -20, coolDown: 1600, coolDownOffset: 2000),
                        new TimedTransition(10000, "Stage5")
                        ),
                   new State("Stage5",
                       new Order(10, "Kraken Tentacle", "shoot"),
                        new Shoot(10, 1, projectileIndex: 3, predictive: 0.5, coolDown: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -10, coolDown: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -20, coolDown: 2000, coolDownOffset: 200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -30, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -40, coolDown: 2000, coolDownOffset: 600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -50, coolDown: 2000, coolDownOffset: 800),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -60, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -70, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -60, coolDown: 2000, coolDownOffset: 1400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -50, coolDown: 2000, coolDownOffset: 1600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -40, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -30, coolDown: 2000, coolDownOffset: 2200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -20, coolDown: 2000, coolDownOffset: 2400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -10, coolDown: 2000, coolDownOffset: 2600),


                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -170, coolDown: 2000, coolDownOffset: 2400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -160, coolDown: 2000, coolDownOffset: 2200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -150, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -140, coolDown: 2000, coolDownOffset: 1800),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -130, coolDown: 2000, coolDownOffset: 1600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -120, coolDown: 2000, coolDownOffset: 1400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -110, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -120, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -130, coolDown: 2000, coolDownOffset: 800),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -140, coolDown: 2000, coolDownOffset: 600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -150, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -160, coolDown: 2000, coolDownOffset: 200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: -170, coolDown: 2000),
                        new TimedTransition(10000, "Stage6")
                        ),
                    new State("Stage6",
                        new Order(10, "Kraken Tentacle", "grenades"),
                        new Shoot(10, 1, projectileIndex: 1, coolDown: 1000),
                        new Shoot(10, 5, projectileIndex: 4, shootAngle: 10, fixedAngle: -90, coolDown: 2000),
                        new Shoot(10, 5, projectileIndex: 4, shootAngle: 10, fixedAngle: -150, coolDown: 2000, coolDownOffset: 4000),
                        new Shoot(10, 5, projectileIndex: 4, shootAngle: 10, fixedAngle: -30, coolDown: 2000, coolDownOffset: 4000),
                        new TimedTransition(10000, "Stage7")
                        ),
                    new State("Stage7",
                        new Shoot(10, 4, projectileIndex: 5, shootAngle: 8, coolDown: 2000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 10, fixedAngle: -90, coolDown: 2000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 10, fixedAngle: -150, coolDown: 2000, coolDownOffset: 4000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 10, fixedAngle: -30, coolDown: 2000, coolDownOffset: 4000),
                        new TimedTransition(8000, "Stage8")
                        ),
                    new State("Stage8",
                        new Order(10, "Kraken Tentacle", "shoot"),
                        new Shoot(10, 1, projectileIndex: 1, coolDown: 100),
                        new TimedTransition(8000, "Stage1")
                        )
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                   new State("die",
                        new RemoveEntity(10, "Kraken Tentacle"),
                        new Taunt("SKREEEEEEE!"),
                        new Flash(0xFF0000, .5, 3),
                        new SetAltTexture(2),
                        new TimedTransition(1000, "die2")
                        ),
                   new State("die2",
                        new Order(90, "Kraken Spawner C", "idle"),
                        new SetAltTexture(1),
                        new TimedTransition(2000, "die3")
                        ),
                   new State("die3",
                        new Suicide()
                            )
                        )
                    )
             )

                     .Init("The Kraken D",
                new State(
                    new State(
                        new DamageTakenTransition(25000, "die"),
                    new State("default",
                        new PlayerWithinTransition(8, "transition")
                        ),
                    new State("transition",
                        new SetAltTexture(1),
                        new TimedTransition(200, "transition2")
                        ),
                    new State("transition2",
                        new SetAltTexture(2),
                        new TimedTransition(200, "transition3")
                        ),
                    new State("transition3",
                        new SetAltTexture(3),
                        new TimedTransition(200, "transition4")
                        ),
                    new State("transition4",
                        new InvisiToss("Kraken Tentacle", range: 2, angle: 90, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 4, angle: 90, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 2, angle: 270, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 4, angle: 270, coolDown: 9999),
                        new TimedTransition(1000, "Stage1")
                        ),
                    new State("Stage1",
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 260, coolDown: 1200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 250, coolDown: 1200, coolDownOffset: 400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 240, coolDown: 1200, coolDownOffset: 800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 230, coolDown: 1200, coolDownOffset: 1200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 220, coolDown: 1200, coolDownOffset: 1600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 210, coolDown: 1200, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 200, coolDown: 1200, coolDownOffset: 2400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 190, coolDown: 1200, coolDownOffset: 2800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 180, coolDown: 1200, coolDownOffset: 3200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 170, coolDown: 1200, coolDownOffset: 3600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 160, coolDown: 1200, coolDownOffset: 4000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 150, coolDown: 1200, coolDownOffset: 4400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 140, coolDown: 1200, coolDownOffset: 4800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 130, coolDown: 1200, coolDownOffset: 5200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 120, coolDown: 1200, coolDownOffset: 5600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 110, coolDown: 1200, coolDownOffset: 6000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 100, coolDown: 1200, coolDownOffset: 6400),
                        new TimedTransition(10000, "Vulnerable1")
                        ),
                    new State("Vulnerable1",
                        new Order(10, "Kraken Tentacle", "grenades"),
                        new TimedTransition(6000, "State2Full")
                        ),
                    new State("State2Full",
                        new Shoot(10, 1, projectileIndex: 4, predictive: 1, coolDown: 2000),
                        new TimedTransition(8000, "Stage3"),
                    new State("Stage2A",
                        new Order(10, "Kraken Tentacle", "idle"),
                        new Taunt(.50, "..."),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 180, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 120, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 240, coolDown: 100),
                        new TimedTransition(1000, "Stage2B")
                        ),
                   new State("Stage2B",
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 200, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 140, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 260, coolDown: 100),
                        new TimedTransition(1000, "Stage2C")
                       ),
                   new State("Stage2C",
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 160, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 100, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 220, coolDown: 100),
                        new TimedTransition(1000, "Stage2A")
                       )
                   ),
                   new State("Stage3",
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 260, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 250, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 240, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 230, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 220, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 210, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 200, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 190, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 180, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 170, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 160, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 150, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 140, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 130, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 120, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 110, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 100, coolDown: 1000, coolDownOffset: 2000),
                        new TimedTransition(10000, "Stage4")
                        ),
                   new State("Stage4",
                        new Order(10, "Kraken Tentacle", "shoot"),
                        new Shoot(10, 1, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, 2, projectileIndex: 4, shootAngle: 20, coolDown: 3000, coolDownOffset: 2000),
                        new Shoot(10, 4, projectileIndex: 3, shootAngle: 20, coolDown: 1600, coolDownOffset: 2000),
                        new TimedTransition(10000, "Stage5")
                        ),
                   new State("Stage5",
                       new Order(10, "Kraken Tentacle", "shoot"),
                        new Shoot(10, 1, projectileIndex: 3, predictive: 0.5, coolDown: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 260, coolDown: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 250, coolDown: 2000, coolDownOffset: 200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 240, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 230, coolDown: 2000, coolDownOffset: 600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 220, coolDown: 2000, coolDownOffset: 800),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 210, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 200, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 210, coolDown: 2000, coolDownOffset: 1400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 220, coolDown: 2000, coolDownOffset: 1600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 230, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 240, coolDown: 2000, coolDownOffset: 2200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 260, coolDown: 2000, coolDownOffset: 2400),


                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 100, coolDown: 2000, coolDownOffset: 2200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 110, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 120, coolDown: 2000, coolDownOffset: 1800),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 130, coolDown: 2000, coolDownOffset: 1600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 140, coolDown: 2000, coolDownOffset: 1400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 150, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 140, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 130, coolDown: 2000, coolDownOffset: 800),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 120, coolDown: 2000, coolDownOffset: 600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 110, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 100, coolDown: 2000, coolDownOffset: 200),
                        new TimedTransition(10000, "Stage6")
                        ),
                    new State("Stage6",
                        new Order(10, "Kraken Tentacle", "shoot"),
                        new Shoot(10, 1, projectileIndex: 5, coolDown: 600),
                        new Shoot(10, 8, projectileIndex: 4, shootAngle: 10, fixedAngle: -180, coolDown: 2000),
                        new TimedTransition(10000, "Stage7")
                        ),
                    new State("Stage7",
                        new Order(10, "Kraken Tentacle", "grenades"),
                        new Shoot(10, 1, projectileIndex: 1, coolDown: 100),
                        new TimedTransition(8000, "Stage1")
                        )
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                   new State("die",
                        new RemoveEntity(10, "Kraken Tentacle"),
                        new Taunt("SKREEEEEEE!"),
                        new Flash(0xFF0000, .5, 3),
                        new SetAltTexture(2),
                        new TimedTransition(1000, "die2")
                        ),
                   new State("die2",
                        new ReplaceTile("Kraken Floor 1", "Kraken Pool", 90),
                        new Order(90, "Kraken Spawner", "idle"),
                        new SetAltTexture(1),
                        new TimedTransition(1000, "die3")
                        ),
                   new State("die3",
                        new Suicide()
                            )
                        )
                    )
             )

             .Init("The Kraken C",
                new State(
                    new State(
                        new DamageTakenTransition(25000, "die"),
                    new State("default",
                        new PlayerWithinTransition(8, "transition")
                        ),
                    new State("transition",
                        new SetAltTexture(1),
                        new TimedTransition(200, "transition2")
                        ),
                    new State("transition2",
                        new SetAltTexture(2),
                        new TimedTransition(200, "transition3")
                        ),
                    new State("transition3",
                        new SetAltTexture(3),
                        new TimedTransition(200, "transition4")
                        ),
                    new State("transition4",
                        new InvisiToss("Kraken Tentacle", range: 2, angle: 90, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 4, angle: 90, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 2, angle: 270, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 4, angle: 270, coolDown: 9999),
                        new TimedTransition(1000, "Stage1")
                        ),
                    new State("Stage1",
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -260, coolDown: 1200),    
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -270, coolDown: 1200, coolDownOffset: 400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -280, coolDown: 1200, coolDownOffset: 800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -290, coolDown: 1200, coolDownOffset: 1200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -300, coolDown: 1200, coolDownOffset: 1600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -310, coolDown: 1200, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -320, coolDown: 1200, coolDownOffset: 2400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -330, coolDown: 1200, coolDownOffset: 2800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -340, coolDown: 1200, coolDownOffset: 3200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -350, coolDown: 1200, coolDownOffset: 3600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -360, coolDown: 1200, coolDownOffset: 4000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -0, coolDown: 1200, coolDownOffset: 4400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -10, coolDown: 1200, coolDownOffset: 4800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -20, coolDown: 1200, coolDownOffset: 5200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -30, coolDown: 1200, coolDownOffset: 5600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -40, coolDown: 1200, coolDownOffset: 6000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: -50, coolDown: 1200, coolDownOffset: 6400),
                        new TimedTransition(10000, "Vulnerable1")
                        ),
                    new State("Vulnerable1",
                        new Order(10, "Kraken Tentacle", "grenades"),
                        new TimedTransition(6000, "State2Full")
                        ),
                    new State("State2Full",
                        new Shoot(10, 1, projectileIndex: 4, predictive: 1, coolDown: 2000),
                        new TimedTransition(8000, "Stage3"),
                    new State("Stage2A",
                        new Order(10, "Kraken Tentacle", "idle"),
                        new Taunt(.50, "..."),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 0, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 60, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 300, coolDown: 100),
                        new TimedTransition(1000, "Stage2B")
                        ),
                   new State("Stage2B",
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 20, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 80, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 320, coolDown: 100),
                        new TimedTransition(1000, "Stage2C")
                       ),
                   new State("Stage2C",
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 340, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 30, coolDown: 100),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 280, coolDown: 100),
                        new TimedTransition(1000, "Stage2A")
                       )
                   ),
                   new State("Stage3",
                        new Flash(0x0000FF, 1, 1),
                        new Taunt("SKRAAAAA!"),
                        new TossObject("Giant Squid", 8, coolDown: 1000),
                        new TimedTransition(4000, "Stage4")
                        ),
                   new State("Stage4",
                        new Order(10, "Kraken Tentacle", "both"),
                        new Shoot(10, 1, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, 2, projectileIndex: 1, shootAngle: 20, coolDown: 3000, coolDownOffset: 2000),
                        new Shoot(10, 6, projectileIndex: 0, shootAngle: 10, predictive: 1, coolDown: 1600, coolDownOffset: 2000),
                        new TimedTransition(8000, "Stage5")
                        ),
                   new State("Stage5",
                        new Shoot(10, 1, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, 2, projectileIndex: 4, shootAngle: 20, coolDown: 3000, coolDownOffset: 2000),
                        new Shoot(10, 4, projectileIndex: 3, shootAngle: 20, coolDown: 1600, coolDownOffset: 2000),
                        new TimedTransition(800, "Stage6")
                        ),
                    new State("Stage6",
                        new Shoot(10, 1, projectileIndex: 5, coolDown: 600),
                        new Shoot(10, 8, projectileIndex: 4, shootAngle: 10, fixedAngle: 0, coolDown: 2000),
                        new TimedTransition(10000, "Stage7")
                        ),
                    new State("Stage7",
                        new Order(10, "Kraken Tentacle", "grenades"),
                        new Shoot(10, 1, projectileIndex: 1, coolDown: 100),
                        new TimedTransition(8000, "Stage1")
                        )
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                   new State("die",
                        new RemoveEntity(10, "Kraken Tentacle"),
                        new Taunt("SKREEEEEEE!"),
                        new Flash(0xFF0000, .5, 3),
                        new SetAltTexture(2),
                        new TimedTransition(1000, "die2")
                        ),
                   new State("die2",
                        new Order(90, "Kraken Spawner D", "idle"),
                        new SetAltTexture(1),
                        new TimedTransition(2000, "die3")
                        ),
                   new State("die3",
                        new Suicide()
                            )
                        )
                    )
             )

            .Init("The Kraken A",
                new State(
                    new State(
                        new DamageTakenTransition(25000, "die"),
                    new State("default",
                        new PlayerWithinTransition(8, "transition")
                        ),
                    new State("transition",
                        new SetAltTexture(1),
                        new TimedTransition(200, "transition2")
                        ),
                    new State("transition2",
                        new SetAltTexture(2),
                        new TimedTransition(200, "transition3")
                        ),
                    new State("transition3",
                        new SetAltTexture(3),
                        new TimedTransition(200, "transition4")
                        ),
                    new State("transition4",
                        new InvisiToss("Kraken Tentacle", range: 2, angle: 0, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 4, angle: 0, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 2, angle: 180, coolDown: 9999),
                        new InvisiToss("Kraken Tentacle", range: 4, angle: 180, coolDown: 9999),
                        new TimedTransition(1000, "Stage1")
                        ),
                    new State("Stage1",
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 10, coolDown: 1200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 20, coolDown: 1200, coolDownOffset: 400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 30, coolDown: 1200, coolDownOffset: 800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 40, coolDown: 1200, coolDownOffset: 1200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 50, coolDown: 1200, coolDownOffset: 1600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 60, coolDown: 1200, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 70, coolDown: 1200, coolDownOffset: 2400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 80, coolDown: 1200, coolDownOffset: 2800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 90, coolDown: 1200, coolDownOffset: 3200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 100, coolDown: 1200, coolDownOffset: 3600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 110, coolDown: 1200, coolDownOffset: 4000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 120, coolDown: 1200, coolDownOffset: 4400),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 130, coolDown: 1200, coolDownOffset: 4800),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 140, coolDown: 1200, coolDownOffset: 5200),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 150, coolDown: 1200, coolDownOffset: 5600),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 160, coolDown: 1200, coolDownOffset: 6000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 170, coolDown: 1200, coolDownOffset: 6400),
                        new TimedTransition(10000, "Vulnerable1")
                        ),
                    new State("Vulnerable1",
                        new Order(10, "Kraken Tentacle", "grenades"),
                        new TimedTransition(6000, "Stage2")
                        ),
                    new State("Stage2",
                        new Order(10, "Kraken Tentacle", "idle"),
                        new Taunt(.50, "SKREEE!"),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 30, coolDown: 200, coolDownOffset: 3000),
                        new Shoot(10, 1, projectileIndex: 0, fixedAngle: 150, coolDown: 200, coolDownOffset: 3000),


                        new Shoot(10, 1, projectileIndex: 1, fixedAngle: 70, coolDown: 2000),
                        new Shoot(10, 1, projectileIndex: 1, fixedAngle: 90, coolDown: 2000),
                        new Shoot(10, 1, projectileIndex: 1, fixedAngle: 110, coolDown: 2000),

                        new Shoot(10, 2, projectileIndex: 2, fixedAngle: 70, shootAngle: 10, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, 2, projectileIndex: 2, fixedAngle: 90, shootAngle: 10, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, 2, projectileIndex: 2, fixedAngle: 110, shootAngle: 10, coolDown: 2000, coolDownOffset: 1200),
                        new TimedTransition(8000, "Stage3")
                        ),
                   new State("Stage3",
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 10, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 20, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 30, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 40, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 50, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 60, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 70, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 80, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 100, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 110, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 120, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 130, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 140, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 150, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 160, coolDown: 1000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 5, fixedAngle: 170, coolDown: 1000, coolDownOffset: 2000),
                        new TimedTransition(10000, "Stage4")
                        ),
                   new State("Stage4",
                        new Order(10, "Kraken Tentacle", "shoot"),
                        new Shoot(10, 1, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, 2, projectileIndex: 4, shootAngle: 20, coolDown: 3000, coolDownOffset: 2000),
                        new Shoot(10, 4, projectileIndex: 3, shootAngle: 20, coolDown: 1600, coolDownOffset: 2000),
                        new TimedTransition(10000, "Stage5")
                        ),
                   new State("Stage5",
                       new Order(10, "Kraken Tentacle", "shoot"),
                        new Shoot(10, 1, projectileIndex: 3, predictive: 0.5, coolDown: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 10, coolDown: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 20, coolDown: 2000, coolDownOffset: 200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 30, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 40, coolDown: 2000, coolDownOffset: 600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 50, coolDown: 2000, coolDownOffset: 800),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 60, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 70, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 60, coolDown: 2000, coolDownOffset: 1400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 50, coolDown: 2000, coolDownOffset: 1600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 40, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 30, coolDown: 2000, coolDownOffset: 2200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 20, coolDown: 2000, coolDownOffset: 2400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 10, coolDown: 2000, coolDownOffset: 2600),


                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 170, coolDown: 2000, coolDownOffset: 2400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 160, coolDown: 2000, coolDownOffset: 2200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 150, coolDown: 2000, coolDownOffset: 2000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 140, coolDown: 2000, coolDownOffset: 1800),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 130, coolDown: 2000, coolDownOffset: 1600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 120, coolDown: 2000, coolDownOffset: 1400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 110, coolDown: 2000, coolDownOffset: 1200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 120, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 130, coolDown: 2000, coolDownOffset: 800),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 140, coolDown: 2000, coolDownOffset: 600),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 150, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 160, coolDown: 2000, coolDownOffset: 200),
                        new Shoot(10, 1, projectileIndex: 2, fixedAngle: 170, coolDown: 2000),
                        new TimedTransition(10000, "Stage6")
                        ),
                    new State("Stage6",
                        new Order(10, "Kraken Tentacle", "grenades"),
                        new Shoot(10, 1, projectileIndex: 1, coolDown: 1000),
                        new Shoot(10, 5, projectileIndex: 4, shootAngle: 10, fixedAngle: 90, coolDown: 2000),
                        new Shoot(10, 5, projectileIndex: 4, shootAngle: 10, fixedAngle: 150, coolDown: 2000, coolDownOffset: 4000),
                        new Shoot(10, 5, projectileIndex: 4, shootAngle: 10, fixedAngle: 30, coolDown: 2000, coolDownOffset: 4000),
                        new TimedTransition(10000, "Stage7")
                        ),
                    new State("Stage7",
                        new Shoot(10, 4, projectileIndex: 5, shootAngle: 8, coolDown: 2000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 10, fixedAngle: 90, coolDown: 2000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 10, fixedAngle: 150, coolDown: 2000, coolDownOffset: 4000),
                        new Shoot(10, 3, projectileIndex: 2, shootAngle: 10, fixedAngle: 30, coolDown: 2000, coolDownOffset: 4000),
                        new TimedTransition(8000, "Stage8")
                        ),
                    new State("Stage8",
                        new Order(10, "Kraken Tentacle", "shoot"),
                        new Shoot(10, 1, projectileIndex: 1, coolDown: 100),
                        new TimedTransition(8000, "Stage1")
                        )
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                   new State("die",
                        new RemoveEntity(10, "Kraken Tentacle"),
                        new Taunt("SKREEEEEEE!"),
                        new Flash(0xFF0000, .5, 3),
                        new SetAltTexture(2),
                        new TimedTransition(1000, "die2")
                        ),
                   new State("die2",
                        new Order(90, "Kraken Spawner B", "idle"),
                        new SetAltTexture(1),
                        new TimedTransition(2000, "die3")
                        ),
                   new State("die3",
                        new Suicide()
                            )
                        )
                    )
             );
        }
}