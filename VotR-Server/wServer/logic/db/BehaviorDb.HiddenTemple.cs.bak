using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ HiddenTemple = () => Behav()
        .Init("Sand Beast A",
                  new State(
                      new State("grow",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ChangeSize(30, 185),
                        new TimedTransition(2250, "fight")
                        ),
                    new State("fight",
                        new Taunt(1.00, "Looks like you stepped straight into your death.", "GraaaaAAAAEAAAGGGH!", "I shall crush you into smithereens."),
                        new Prioritize(
                            new Follow(0.20, 8, 1),
                            new Wander(0.3)
                            ),
                        new Shoot(10, count: 18, shootAngle: 26, predictive: 1, projectileIndex: 0, coolDown: 4750),
                        new Shoot(10, count: 3, shootAngle: 20, predictive: 3.5, projectileIndex: 1, coolDown: 1450),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1450),
                        new TimedTransition(5000, "fight2")
                        ),
                     new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                         new Prioritize(
                            new StayBack(0.2, 2),
                            new Wander(0.3)
                            ),
                        new Shoot(10, count: 24, shootAngle: 20, predictive: 1, projectileIndex: 1, coolDown: 2750),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(5000, "fight")
                        )
                    )
              )
         .Init("Sand Beast B",
                  new State(
                      new State("grow",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ChangeSize(30, 140),
                        new TimedTransition(2250, "fight")
                        ),
                    new State("fight",
                        new Prioritize(
                            new Wander(0.65),
                            new Charge(0.25, 6, coolDown: 2000)
                            ),
                        new Shoot(10, count: 10, projectileIndex: 0, coolDown: 3000),
                        new Shoot(10, count: 6, predictive: 4, projectileIndex: 1, coolDown: 1000)
                        )
                    )
              )
        .Init("Armored Jackal Lord",
                  new State(
                    new State("fight",
                        new Prioritize(
                            new Follow(0.45, 8, 1),
                            new Wander(0.3)
                            ),
                        new Shoot(10, count: 4, shootAngle: 20, predictive: 3, projectileIndex: 1, coolDown: 1750),
                        new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 2450),
                        new TimedTransition(4750, "Invulnerable")
                        ),
                     new State("Invulnerable",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Orbit(0.8, 2, target: null),
                        new Shoot(10, count: 7, shootAngle: 30, projectileIndex: 1, coolDown: 700),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 0, coolDown: 1150),
                        new TimedTransition(3500, "fight")
                        )
                    )
              )
        .Init("Sandstone Ancient",
                  new State(
                     new State("SpinShot",
                          new Prioritize(
                            new Follow(0.20, 8, 1),
                            new Wander(0.6)
                            ),
                        new Shoot(10, count: 2, projectileIndex: 3, predictive: 2.25, coolDown: 50),
                        new TimedTransition(4000, "healing"),
                        new State("1",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 90, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(125, "2")
                        ),
                        new State("2",
                            new Shoot(0, projectileIndex: 2, count: 3, shootAngle: 90, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(125, "3")
                        ),
                        new State("3",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 90, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(125, "1")
                        )
                    ),
                     new State("healing",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x0000FF, 1, 1),
                        new HealSelf(coolDown: 1000),
                        new TimedTransition(3000, "SpinShot")
                        )
                    )
              )

       .Init("Giant Sandworm",
                  new State(
                    new State("fight",
                        new ChangeSize(40, 140),
                        new Prioritize(
                            new Follow(0.20, 8, 1),
                            new Wander(0.6)
                            ),
                        new Shoot(10, count: 6, shootAngle: 16, predictive: 4, projectileIndex: 0, coolDown: 500),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(7750, "Devouring")
                        ),
                     new State("Devouring",
                        new ChangeSize(40, 180),
                        new Flash(0xFF0000, 1, 1),
                        new Prioritize(
                            new Follow(0.32, 8, 1),
                            new Wander(0.1)
                            ),
                        new Shoot(10, count: 16, projectileIndex: 1, coolDown: 1),
                        new TimedTransition(4000, "fight")
                        )
                    )
              )
        .Init("Small Sandworm",
                new State(
                     new Follow(1, 8, 1),
                     new Shoot(8.4, count: 6, projectileIndex: 0, coolDown: 1500),
                     new Shoot(8.4, count: 1, projectileIndex: 1, coolDown: 3000)

                    )
            )
         .Init("Reincarnated Warrior",
                new State(
                     new Follow(0.4, 8, 1),
                     new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 1200),
                     new Shoot(8.4, count: 1, projectileIndex: 1, coolDown: 1800)

                    )
            )

        .Init("Reincarnated Knight",

                new State(
                     new Follow(0.25, 8, 1),
                     new Shoot(8.4, count: 2, projectileIndex: 0, coolDown: 1000)
                    )
            )
         .Init("Reincarnated Magician",
            new State(
                new State("swag",
                     new Follow(0.3, 8, 1),
                     new Shoot(8.4, count: 4, shootAngle: 8, projectileIndex: 0, coolDown: 300),
                     new TimedTransition(3250, "swag2")
                    ),
                new State("swag2",
                     new StayBack(0.3, 6),
                     new Shoot(8.4, count: 4, projectileIndex: 0, coolDown: 300),
                     new TimedTransition(3250, "swag")
                    )
                )
            )
        .Init("Temple Trap",
                  new State(
                   new TransformOnDeath("Sand Beast A", 1, 1, 1),
                    new State("waterfortrapped",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(1, "trapped")
                        ),
                     new State("trapped",
                        new Suicide()
                        )
                    )
              )

        .Init("Anubis Statue",
              new State(
                 new State("Active",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new EntityNotExistsTransition("Anubis Sarcophagus", 90000, "Start")
                    ),
                 new State("Start",
                    new Spawn("Temple Boss", 1),
                    new Suicide()
                            )
                    )
            )

                 .Init("Anubis Sarcophagus",
              new State(
                 new State("Idle",
                    new HpLessTransition(0.9, "SpinShot")
                 ),
                    new State("SpinShot",
                        new TossObject("Sand Beast B", range: 8, coolDown: 999999),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(250, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(250, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(250, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(250, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(250, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(250, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(250, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(250, "Quadforce1")
                        )
                    )
                 )
               )
              .Init("Temple Boss",
                new State(
                    new AnnounceOnDeath("Anubis was banished from his own tomb!"),
                    new HpLessTransition(0.12, "rage"),
                    new State("default",
                        new Taunt(1.00, "Fall into your own doom."),
                        new Flash(0x00FF00, 1, 1),
                        new PlayerWithinTransition(8, "starting")
                        ),
                    new State("starting",
                        new Wander(0.2),
                        new Shoot(0, projectileIndex: 5, count: 6, coolDown: 2500),
                        new TimedTransition(1000, "mainphase")
                        ),
                   new State("mainphase",
                      new Shoot(10, count: 6, projectileIndex: 5, coolDown: 5000),
                      new TimedTransition(10875, "killthem"),
                       new State("2",
                        new Taunt(1.00, "The other ancients have no real power. I will destoy you."),
                        new Prioritize(
                             new Follow(0.30, 8, 1),
                             new StayBack(0.3, 5)
                            ),
                        new Shoot(10, count: 4, shootAngle: 18, projectileIndex: 3, coolDown: 3000),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1000),
                        new TimedTransition(3250, "1")
                        ),
                     new State("1",
                          new Prioritize(
                             new Swirl(0.4, 4),
                             new StayBack(0.4, 5)
                            ),
                        new Shoot(10, count: 7, shootAngle: 46, projectileIndex: 0, coolDown: 3600),
                        new Shoot(10, count: 5, projectileIndex: 1, coolDown: 3000),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1500),
                        new TimedTransition(5250, "2")
                         )
                        ),
                    new State("killthem",
                      new Taunt(1.00, "The evil you have awakened is unlike anything you have ever faced. LEAVE!"),
                      new Prioritize(
                            new Wander(0.32),
                            new Orbit(0.8, 2, target: null)
                            ),
                        new Shoot(10, count: 3, shootAngle: 20, predictive: 1, coolDown: 1750),
                        new Shoot(10, count: 4, projectileIndex: 4, coolDown: 2000),
                        new TimedTransition(4500, "rush")
                        ),
                    new State("rush",
                        new Taunt(1.00, "Fighting me is like fighting 50 armies. SURRENDER!"),
                        new Prioritize(
                            new Follow(1, 8, 1, coolDown: 100),
                            new Wander(0.32)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 1, projectileIndex: 6, coolDown: 2),
                        new Shoot(10, count: 7, shootAngle: 30, projectileIndex: 7, coolDown: 2000),
                        new TimedTransition(4500, "heal")
                        ),
                    new State("heal",
                        new ReturnToSpawn(speed: 0.4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 4, shootAngle: 4, projectileIndex: 5, coolDown: 100),
                        new Shoot(10, count: 7, projectileIndex: 8, coolDown: 100),
                        new TimedTransition(7000, "battle")
                        ),
                    new State("battle",
                        new Wander(0.4),
                        new HealSelf(coolDown: 3000, amount: 1000),
                        new Shoot(10, count: 6, shootAngle: 20, projectileIndex: 4, coolDown: 2000),
                        new Shoot(10, count: 4, shootAngle: 4, projectileIndex: 0, coolDown: 2575),
                        new Shoot(10, count: 2, projectileIndex: 3, coolDown: 700),
                        new TimedTransition(5700, "vuln")
                        ),
                    new State("vuln",
                        new Flash(0xFFFFFF, 1, 1),
                        new Taunt(1.00, "The temple can only uphold my power for so long.....", "I can't hold on to my energy...it can't last forever...", "aregh...."),
                        new TimedTransition(6000, "starting")
                        ),
                    new State("rage",
                        new Taunt(1.00, "I WON'T ALLOW YOU TO RAID MY TEMPLE AND DESTROY ME!"),
                        new Follow(1.5, 8, 1),
                        new Flash(0xFF0000, 1, 1),
                        new Shoot(10, count: 2, shootAngle: 28, projectileIndex: 0, coolDown: 2750),
                        new Shoot(10, count: 6, projectileIndex: 3, coolDown: 3000),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000),
                        new Shoot(10, count: 4, shootAngle: 35, projectileIndex: 1, coolDown: 2250),
                        new Grenade(5, 100, 9, coolDown: 3500)
                        )
                    ),
                    new MostDamagers(3,
                    LootTemplates.GStatIncreasePotionsLoot2()
                    ),
                new Threshold(0.025,
                    new ItemLoot("Sor Fragment Cache", 0.75),
                    new ItemLoot("Onrane Cache", 0.75),
                    new ItemLoot("Onrane", 1.00),
                    new ItemLoot("Sor Fragment 1", 0.50),
                    new ItemLoot("Sor Fragment 2", 0.50),
                    new ItemLoot("Sor Fragment 3", 0.50),
                    new ItemLoot("Lost Scripture", 0.50),
                    new ItemLoot("Robe of Overgrowth", 0.50),
                    new TierLoot(6, ItemType.Ability, 0.7),
                    new TierLoot(12, ItemType.Armor, 0.07),
                    new TierLoot(12, ItemType.Weapon, 0.07),
                    new TierLoot(6, ItemType.Ring, 0.07)
                )
            )

         .Init("Anubis Test Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.15,
                new TierLoot(12, ItemType.Weapon, 0.065),
                new TierLoot(6, ItemType.Ability, 0.045),
                new TierLoot(5, ItemType.Ring, 0.045),
                new TierLoot(13, ItemType.Armor, 0.05),
                new ItemLoot("Greater Potion of Life", 1),
                new ItemLoot("Potion of Life", 1),
                new ItemLoot("Greater Potion of Mana", 0.9),
                new ItemLoot("Ring of the Hidden Temple", 0.05),
                new ItemLoot("Defender Sword", 0.05),
                new ItemLoot("Robe of Overgrowth", 0.05),
                new ItemLoot("Ancient Stiletto", 0.05)
                )
            )
        ;
    }
}