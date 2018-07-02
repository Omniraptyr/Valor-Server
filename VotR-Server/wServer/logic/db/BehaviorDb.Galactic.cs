using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Galactic = () => Behav()
        .Init("Alien Bot",
            new State(
                new Shoot(10, count: 5, projectileIndex: 1, coolDown: 4000),
                new Prioritize(
                        new Follow(0.45, 8, 1),
                        new Wander(0.6)
                        ),
                new State("shoot1",
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 50),
                     new TimedTransition(100, "shoot2")
                    ),
                new State("shoot2",
                     new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 0, coolDown: 50),
                     new TimedTransition(100, "shoot1")
                    )
                )
            )
        .Init("Brute Alien Blasterman",
            new State(
                new DamageTakenTransition(2400, "Rage"),
                new Wander(0.05),
                new State("Fight",
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1400),
                     new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 1, coolDown: 3000, coolDownOffset: 1600)
                    ),
                new State("Rage",
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                     new Shoot(10, count: 1, projectileIndex: 1, predictive: 1, coolDown: 1000),
                     new Shoot(10, count: 8, projectileIndex: 2, coolDown: 2000)
                    )
                )
            )
        .Init("Alien Archer",
            new State(
                new State("fight1",
                     new Wander(0.4),
                     new Shoot(10, count: 4, shootAngle: 10, projectileIndex: 0, coolDown: new Cooldown(2000, 1400)),
                     new TimedTransition(5000, "fight2")
                    ),
                new State("fight2",
                     new Follow(0.4, 7, 1),
                     new Shoot(10, count: 1, projectileIndex: 1, predictive: 1, coolDown: 2500),
                     new TimedTransition(5000, "fight1")
                    )
                )
            )
          .Init("Alien Mage",
            new State(
                new Shoot(10, count: 5, shootAngle: 12, projectileIndex: 0, coolDown: new Cooldown(2600, 1000)),
                new Shoot(10, count: 1, projectileIndex: 0, coolDown: 4000),
                new State("movement1",
                     new Follow(0.5, 9, 1),
                     new TimedTransition(4600, "movement2")
                    ),
                new State("movement2",
                     new Swirl(0.4, 5),
                     new TimedTransition(4000, "movement1")
                    )
                )
            )
        .Init("Alien Mastermind",
            new State(
                new Follow(0.65, 9, 1),
                new Shoot(10, count: 6, projectileIndex: 0, coolDown: new Cooldown(4800, 2000))
                )
            )
        .Init("Alien UFO",
            new State(
                new State("fight1",
                     new Follow(0.6, 9, 1),
                     new Grenade(4, 160, range: 6, coolDown: new Cooldown(1800, 1000)),
                     new TimedTransition(5200, "fight2")
                    ),
                new State("fight2",
                     new ConditionalEffect(ConditionEffectIndex.Armored),
                     new Wander(0.03),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1),
                     new TimedTransition(3000, "fight1")
                    )
                )
            )
        .Init("Galactic Trap",
            new State(
                new State("shoot",
                    new Spawn("Alien Mastermind", 1, 1, coolDown: new Cooldown(7000, 2000)),
                     new Shoot(10, count: 5, projectileIndex: 0, coolDown: new Cooldown(1600, 800))
                    )
                )
            )
        .Init("Galactic Plateau Crystal",
                new State(
                ),
                new Threshold(0.05,
                    new ItemLoot("Qaru", 0.9)
                    )
            )
        .Init("Galactic Tower Defender",
         new State(
             new State(
                 new EntitiesNotExistsTransition(999, "Disabled", "The Overseer"),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Wait",
                     new TimedTransition(8200, "Charge")
                    ),
                new State("Charge",
                     new Flash(0x0000FF, 1, 2),
                     new TimedTransition(2800, "Blast")
                    ),
                new State("Blast",
                     new Shoot(10, count: 6, projectileIndex: 0, coolDown: 500),
                     new TimedTransition(1000, "Wait")
                    )
                 ),
                new State("Disabled",
                    new ChangeSize(50, 120)
                    )
                )
            )
        .Init("Alien Ifogenae Tank",
            new State(
                new TransformOnDeath("Alien Ifogenae Tank 2", 1, 1, 1),
                new State("Wait",
                     new TimedTransition(6600, "Blast")
                    ),
                new State("Blast",
                     new Shoot(10, count: 5, projectileIndex: 0, coolDown: 1000),
                     new TimedTransition(3000, "Wait")
                    )
                )
            )
        .Init("Alien Ifogenae Tank 2",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new TransformOnDeath("Alien Archer", 1, 3, 1),
                new TransformOnDeath("Alien Ifogenae Tank", 1, 1, 1),
                new State("Idle"
                    ),
                new State("Die",
                     new Suicide()
                    )
                )
            )
        .Init("GP Test Taskmaster",
            new State(
                new Taunt(true, "Launchpad ready. Please confirm."),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new EntitiesNotExistsTransition(9999, "activate", "Galactic Tower Defender")
                    ),
                new State("activate",
                    new Taunt(true, "Launchpad activated."),
                    new DropPortalOnDeath("The Regolith Portal", 100, timeout: 180),
                     new Suicide()
                    )
                )
            )
        .Init("The Overseer",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                    new TransformOnDeath("GP Test Taskmaster", 1, 1, 1),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(8, "taunt1")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("taunt1",
                        new Taunt("Arakataaaagh!", "Oaaaaraaaghtktktk"),
                        new TimedTransition(4000, "taunt2")
                        ),
                    new State("taunt2",
                        new Flash(0xFF0000, 1, 1),
                        new Taunt("Rakhrakhaaarr!", "Yoaaaraaghyaa."),
                        new TimedTransition(4000, "fight1")
                        )
                     ),
                    new State("fight1",
                        new Wander(0.4),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 7, shootAngle: 14, projectileIndex: 1, coolDown: new Cooldown(2000, 1000)),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 0, predictive: 1, coolDown: 2000, coolDownOffset: 1000),
                        new TimedTransition(6800, "fight2")
                        ),
                    new State("fight2",
                        new Prioritize(
                            new Follow(0.5, 8, 1),
                            new Wander(0.6)
                        ),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 4, shootAngle: 4, projectileIndex: 2, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, count: 6, shootAngle: 2, projectileIndex: 2, coolDown: 2000, coolDownOffset: 800),
                        new Shoot(10, count: 10, projectileIndex: 1, coolDown: 4000),
                        new TimedTransition(7200, "fight3")
                        ),
                    new State("fight3",
                        new Prioritize(
                            new Follow(0.2, 8, 1),
                            new Wander(0.4)
                        ),
                        new Shoot(10, count: 1, projectileIndex: 3, coolDown: 1),
                        new Shoot(10, count: 4, shootAngle: 18, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(6000, "fight4")
                        ),
                    new State("fight4",
                        new Taunt("Taaraakcghaa!", "Zaaraaaghok.", "Eraaaackghh!"),
                        new Prioritize(
                            new Follow(0.7, 8, 1),
                            new Wander(0.4)
                        ),
                        new Spawn("Galactic Trap", 1, 1, coolDown: 1000),
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 3, coolDown: 1800),
                        new Shoot(10, count: 6, projectileIndex: 2, coolDown: 3000),
                        new TimedTransition(6000, "fight1")
                        )
                    ),
                new Threshold(0.025,
                    new ItemLoot("Potion of Protection", 1.0),
                    new ItemLoot("Greater Potion of Wisdom", 0.6),
                    new TierLoot(10, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.2),
                    new TierLoot(10, ItemType.Armor, 0.1),
                    new TierLoot(4, ItemType.Ring, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.05),
                    new TierLoot(11, ItemType.Weapon, 0.05),
                    new ItemLoot("Some Alien Equipment", 0.75),
                    new ItemLoot("Ieastorian Armor", 0.035),
                    new ItemLoot("Otherworldly Blades", 0.01),
                    new ItemLoot("Blade of the Nightbringer", 0.035),
                    new ItemLoot("Dire Sword", 0.035)
                )
            )
        .Init("The Alien King",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.StunImmune),
                    new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                    new State("default",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntitiesNotExistsTransition(999, "taunt1", "Alien Ifogenae Tank")
                        ),
                    new State(
                        new SetAltTexture(0),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("taunt1",
                        new Taunt("We will defend against any attack. Including you. Commence Code GREEN!"),
                        new TimedTransition(4000, "Commence")
                        )
                     ),
                    new State("Commence",
                        new Order(999, "Alien Ifogenae Tank 2", "Die"),
                        new TimedTransition(4000, "Shotgun")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HealSelf(coolDown: 6000, amount: 100),
                        new EntitiesNotExistsTransition(999, "Charge", "Alien Ifogenae Tank"),
                    new State("Shotgun",
                        new Shoot(10, count: 7, shootAngle: 16, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 4, projectileIndex: 4, coolDown: 2800, coolDownOffset: 600),
                        new Shoot(10, count: 8, projectileIndex: 4, coolDown: 2800, coolDownOffset: 1200),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 4, predictive: 0.5, coolDown: 2800, coolDownOffset: 1800),
                        new TimedTransition(10000, "Shotty1")
                        ),
                    new State("Shotty1",
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 2, coolDown: new Cooldown(1000, 1000)),
                        new Shoot(10, count: 12, shootAngle: 8, projectileIndex: 0, coolDown: new Cooldown(3000, 1000)),
                        new TossObject("Alien UFO", 6, coolDown: 2000),
                        new TimedTransition(8000, "BlastAndBeFast")
                        ),
                    new State("BlastAndBeFast",
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 3600),
                        new TimedTransition(14000, "Fight3"),
                        new State("Quadforce1",
                        new Shoot(8.4, count: 4, shootAngle: 4, fixedAngle: 0, projectileIndex: 1, coolDown: 1),
                        new TimedTransition(3000, "Quadforce2")
                        ),
                        new State("Quadforce2",
                             new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 225, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 3, coolDown: 20),
                            new TimedTransition(2000, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(8.4, count: 4, shootAngle: 4, fixedAngle: 90, projectileIndex: 1, coolDown: 1),
                            new TimedTransition(3000, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 225, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 3, coolDown: 20),
                            new TimedTransition(2000, "Quadforce41")
                        ),
                        new State("Quadforce41",
                            new Shoot(8.4, count: 4, shootAngle: 4, fixedAngle: 180, projectileIndex: 1, coolDown: 1),
                            new TimedTransition(3000, "Quadforce51")
                        ),
                        new State("Quadforce51",
                            new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 225, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 3, coolDown: 20),
                            new TimedTransition(2000, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(8.4, count: 4, shootAngle: 4, fixedAngle: 270, projectileIndex: 1, coolDown: 1),
                            new TimedTransition(3000, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 225, projectileIndex: 3, coolDown: 20),
                             new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 3, coolDown: 20),
                            new TimedTransition(2000, "Quadforce1")
                            ),
                        new State("Fight3",
                        new Shoot(10, count: 7, shootAngle: 8, projectileIndex: 1, coolDown: new Cooldown(1000, 1000)),
                        new Shoot(10, count: 5, shootAngle: 18, projectileIndex: 2, coolDown: new Cooldown(2000, 1000)),
                        new TimedTransition(6000, "Shotgun")
                           )
                        )
                     ),
                    new State("Charge",
                        new SetAltTexture(1),
                        new Taunt("Vulnerable stasis activated..."),
                        new TimedTransition(5600, "ShootFast")
                        ),
                      new State("ShootFast",
                        new SetAltTexture(0),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1),
                        new TimedTransition(4000, "Commence")
                        )
                    ),
                new Threshold(0.03,
                    new ItemLoot("Potion of Might", 1.0),
                    new ItemLoot("Potion of Vitality", 1.0),
                    new TierLoot(10, ItemType.Weapon, 0.2),
                    new TierLoot(4, ItemType.Ability, 0.2),
                    new TierLoot(10, ItemType.Armor, 0.1),
                    new TierLoot(4, ItemType.Ring, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.1),
                    new TierLoot(11, ItemType.Weapon, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.055),
                    new TierLoot(9, ItemType.Weapon, 0.055),
                    new ItemLoot("Some Alien Equipment", 0.75),
                    new ItemLoot("Gold Cache", 0.05),
                    new ItemLoot("The ET Experience", 0.035),
                    new ItemLoot("Otherworldly Blades", 0.01),
                    new ItemLoot("Blade of the Nightbringer", 0.035)
                )
            )
            ;
    }
}