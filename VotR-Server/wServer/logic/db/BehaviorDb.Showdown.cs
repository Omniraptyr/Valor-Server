using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Crimson = () => Behav()
            .Init("Hades",
                new State(
                    new RealmPortalDrop(),
                    new HpLessTransition(0.14, "Dead1"),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(8, "talktransition")
                        ),
                     new State("talktransition",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "Hm?"),
                        new TimedTransition(4500, "talktransition2")
                        ),
                   new State("talktransition2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "This is quite suprising, didn't expect guest to show up."),
                        new TimedTransition(6500, "talktransition3")
                        ),
                   new State("talktransition3",
                        new Flash(0xFF0000, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "Well, you have chose this route. Death."),
                        new TimedTransition(5500, "FranticFlamePhase")
                        ),
                    new State("FranticFlamePhase",
                        new Taunt(1.00, "Feel that? Yes, that is fear."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 8, shootAngle: 16, projectileIndex: 2, coolDown: 40),
                        new Shoot(10, count: 12, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(5000, "FranticFlamePhase2")
                        ),
                    new State("FranticFlamePhase2",
                        new Shoot(10, count: 9, shootAngle: 16, projectileIndex: 2, coolDown: 40),
                        new Shoot(10, count: 13, projectileIndex: 0, coolDown: 700),
                        new TimedTransition(5000, "FranticFlamePhase3")
                        ),
                    new State("FranticFlamePhase3",
                        new Taunt("Your lives will be burned to ashes!", "Oh, what fun it is to BURN!"),
                        new Shoot(10, count: 4, shootAngle: 4, projectileIndex: 2, coolDown: 1),
                        new Shoot(10, count: 4, shootAngle: 4, projectileIndex: 2, coolDown: 1, coolDownOffset: 1),
                        new Shoot(10, count: 6, shootAngle: 18, projectileIndex: 1, predictive: 1, coolDown: 2000, coolDownOffset: 2000),
                        new TimedTransition(6000, "PerishingPhase")
                        ),
                    new State("PerishingPhase",
                        new Taunt(1.00, "I don't believe you will survive very long in here. The longer the last the closer to you being perished."),
                        new Wander(0.1),
                        new Shoot(10, count: 6, projectileIndex: 1, coolDown: 2750),
                        new Shoot(10, count: 4, shootAngle: 20, predictive: 2, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(8000, "LockingTargetPhaseStarting")
                        ),
                    new State("LockingTargetPhaseStarting",
                        new Flash(0xFF0000, 2, 2),
                        new Shoot(10, count: 12, projectileIndex: 3, coolDown: 775),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new RemoveEntity(9999, "HadesTarget"),
                        new Taunt(1.00, "I must charge my staff! Stand back fiend!"),
                        new TimedTransition(6750, "LockingTargetPhase")
                        ),
                    new State("LockingTargetPhase",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "My staff is now charged! Nothing can save you now!"),
                        new TossObject("HadesTarget", angle: null, range: 10, coolDown: 350),
                        new TimedTransition(7850, "RushingShotgunWarn")
                        ),
                    new State("RushingShotgunWarn",
                        new Flash(0xFF00FF, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1700, "RushingShotgunPhase")
                        ),
                    new State("RushingShotgunPhase",
                        new Follow(0.4, 8, 1),
                        new Shoot(10, count: 3, shootAngle: 16, projectileIndex: 2, coolDown: 100),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 3, coolDown: 1750, fixedAngle: 135),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 3, coolDown: 1750, fixedAngle: 45),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 3, coolDown: 1750, fixedAngle: 225),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 3, coolDown: 1750, fixedAngle: 315),
                        new TimedTransition(8000, "RushingShotgun2Phase")
                        ),
                   new State("RushingShotgun2Phase",
                        new Taunt(1.00, "Ahahaha! Feel the powerful force of the underworld!"),
                        new Follow(0.65, 8, 1),
                        new Shoot(10, count: 3, shootAngle: 30, projectileIndex: 1, coolDown: 2350),
                        new Shoot(10, count: 12, shootAngle: 4, projectileIndex: 4, coolDown: 1000),
                        new TimedTransition(8000, "RushingShotgun3Phase")
                        ),
                   new State("RushingShotgun3Phase",
                        new Taunt(1.00, "ADMIT YOUR DOOM!"),
                        new Follow(0.15, 8, 1),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1),
                        new TimedTransition(4000, "GetReadyMoveToCenter1")
                        ),
                    new State("GetReadyMoveToCenter1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "MoveToCenter1")
                        ),
                    new State("MoveToCenter1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new MoveTo(speed: 1, x: 15, y: 12),
                        new TimedTransition(2000, "GetReadyMoveToSpawn")
                        ),
                    new State("GetReadyMoveToSpawn",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "SpawnFollowerPhase")
                        ),
                    new State("SpawnFollowerPhase",
                        new Taunt(1.00, "My defenders will fight for me!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new InvisiToss("HadesFollower", range: 4, coolDown: 99999, angle: 0),
                        new InvisiToss("HadesFollower", range: 4, coolDown: 99999, angle: 180),
                        new InvisiToss("HadesFollower", range: 4, coolDown: 99999, angle: 270),
                        new InvisiToss("HadesFollower", range: 4, coolDown: 99999, angle: 45),
                        new InvisiToss("HadesFollower", range: 4, coolDown: 99999, angle: 90),
                        new InvisiToss("HadesFollower", range: 4, coolDown: 99999, angle: 315),
                        new InvisiToss("HadesFollower", range: 4, coolDown: 99999, angle: 215),
                        new InvisiToss("HadesFollower", range: 4, coolDown: 99999, angle: 135),
                        new TimedTransition(3000, "WaitingForDeads")
                        ),
                   new State("WaitingForDeads",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 12, projectileIndex: 4, coolDown: 400),
                        new EntitiesNotExistsTransition(9999, "FranticFlamePhase", "HadesFollower")
                        ),
                   new State("Dead1",
                        new Flash(0xFFFFF, 2, 2),
                        new Taunt(1.00, "What!? The SOULS that GIVE ME ENERGY ARE GONE! ARAAAGAAAGH!"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(3000, "ded")
                        ),
                   new State("ded",
                        new Shoot(10, count: 10, projectileIndex: 2, coolDown: 99999),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Suicide()
                        )
                    ),
                new Threshold(0.15,
                new TierLoot(12, ItemType.Weapon, 0.045),
                new TierLoot(11, ItemType.Weapon, 0.05),
                new TierLoot(6, ItemType.Ability, 0.045),
                new TierLoot(12, ItemType.Armor, 0.05),
                new ItemLoot("Greater Potion of Vitality", 1),
                new ItemLoot("Greater Potion of Attack", 1),
                new ItemLoot("Potion of Life", 1),
                new ItemLoot("Truncheon of Immortal Demons", 0.03),
                new ItemLoot("Coat of the Devil", 0.03),
                new ItemLoot("Skull of Hades", 0.03),
                new ItemLoot("Hellslicer", 0.04),
                new ItemLoot("The Eye of Peril", 0.04),
                new ItemLoot("Sinburn Hide", 0.03),
                new ItemLoot("Wildfire Crossbow", 0.03)
                )
            )

            .Init("HadesFollower",
                new State(
                    new HpLessTransition(0.1, "BlowUp"),
                    new State("Start",
                        new Flash(0xFF0000, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ChangeSize(40, 140),
                        new TimedTransition(1500, "Follow")
                        ),
                    new State("Follow",
                        new Prioritize(
                            new Follow(0.5, 8, 1),
                            new Wander(0.45)
                            ),
                        new Shoot(10, count: 8, projectileIndex: 1, coolDown: 900),
                        new Shoot(8.4, count: 4, projectileIndex: 0, coolDown: 1800)
                        ),
                  new State("BlowUp",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Shoot(10, count: 16, projectileIndex: 0, coolDown: 9999),
                        new Suicide()
                        )
                  )
            )

                                    .Init("HadesTarget",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Seek",
                               new Sequence(
                            new Timed(2000,
                                new Prioritize(
                                    new Follow(0.5, 8, 1),
                                    new Wander(0.7)
                                    )),
                            new Timed(2000,
                                new Prioritize(
                                    new Charge(1.4, 6, coolDown: 1150),
                                    new Swirl(1, 4, targeted: false)
                                    )),
                            new Timed(1000,
                                new Prioritize(
                                    new Orbit(0.55, 5),
                                    new Wander(0.8)
                                    )
                                )
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(1, "Countdown")
                        ),
                    new State("Countdown",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Shoot(10, count: 6, projectileIndex: 0, coolDown: 750),
                        new TimedTransition(2850, "Blam")
                        ),
                   new State("Blam",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Shoot(10, count: 11, projectileIndex: 1, coolDown: 9999),
                        new Suicide()
                        )
                  )
            )
                      .Init("Hades Test Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.15,
                new TierLoot(12, ItemType.Weapon, 0.045),
                new TierLoot(11, ItemType.Weapon, 0.05),
                new TierLoot(6, ItemType.Ability, 0.045),
                new TierLoot(12, ItemType.Armor, 0.05),
                new ItemLoot("Greater Potion of Vitality", 1),
                new ItemLoot("Greater Potion of Attack", 1),
                new ItemLoot("Potion of Life", 1),
                new ItemLoot("Truncheon of Immortal Demons", 0.03),
                new ItemLoot("Coat of the Devil", 0.03),
                new ItemLoot("Skull of Hades", 0.03),
                new ItemLoot("Hellslicer", 0.04),
                new ItemLoot("The Eye of Peril", 0.04),
                new ItemLoot("Sinburn Hide", 0.03),
                new ItemLoot("Wildfire Crossbow", 0.03)
                )
            )
        .Init("Crimson Trap",
            new State(
                new SetNoXP(),
                  new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State(
                    new PlayerWithinTransition(1, "blowup")
                    ),
                new State("blowup",
                    new ApplySetpiece("CrimsonLava"),
                    new Suicide()
                    )
                )
            )
            .Init("CRIM Crimson Wizard",
            new State(
                new State("wizzy0",
                    new Wander(0.25),
                    new Shoot(10, count: 5, shootAngle: 6, projectileIndex: 0, coolDown: 2000),
                    new TimedTransition(5000, "wizzy1")
                    ),
                new State("wizzy1",
                    new Flash(0xFF0000, 1, 1),
                    new ConditionalEffect(ConditionEffectIndex.Invincible, false),
                    new Grenade(2, 140, range: 6, coolDown: 2000),
                    new Shoot(10, count: 2, shootAngle: 2, projectileIndex: 1, coolDown: 200),
                    new TimedTransition(5000, "wizzy0")
                    )
                 )

            )
            .Init("CRIM Crimson Demon",
                new State(
                    new Prioritize(
                        new Follow(0.4, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 4, coolDown: 2000, coolDownOffset: 2200)
                    ),
                new ItemLoot("Fire Sword", 0.025),
                new ItemLoot("Steel Shield", 0.025)
            )
         .Init("CRIM Crimson Warrior",
            new State(
                new State("fight1",
                    new Prioritize(
                        new Follow(0.6, 8, 1),
                        new Wander(0.1)
                        ),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 400),
                    new TimedTransition(4000, "fight2")
                    ),
                new State("fight2",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable, false),
                    new Prioritize(
                        new Follow(0.3, 8, 1),
                        new Wander(0.1)
                        ),
                    new Shoot(10, count: 6, projectileIndex: 1, coolDown: 1000),
                    new TimedTransition(4000, "fight3")
                    ),
                new State("fight3",
                    new Wander(0.1),
                    new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 2, coolDown: 100),
                    new TimedTransition(4000, "fight1")
                    )
                 ),
                new ItemLoot("Fire Bow", 0.05),
                new Threshold(0.5,
                    new ItemLoot("Robe of the Moon Wizard", 0.01),
                    new ItemLoot("Vengeance Armor", 0.01)
                    )

            )
            .Init("CRIM Knight of Crimson",
            new State(
                new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1000),
                new Shoot(10, count: 5, shootAngle: 6, projectileIndex: 1, predictive: 1, coolDown: 4000, coolDownOffset: 1000),
                    new State("swag",
                        new TimedTransition(4000, "swag1"),
                    new Prioritize(
                        new Orbit(0.3, 3, 8, target: null),
                        new Wander(0.25)
                        ),
                    new State("swag1",
                        new TimedTransition(4000, "swag"),
                    new ConditionalEffect(ConditionEffectIndex.Armored, false),
                    new Prioritize(
                        new Follow(0.5, 8, 1),
                        new Wander(0.25)
                        )
                       )
                    )
                ),
                new ItemLoot("Fire Nova Spell", 0.02),
                new Threshold(0.1,
                    new ItemLoot("Wand of Dark Magic", 0.01),
                    new ItemLoot("Avenger Staff", 0.01),
                    new ItemLoot("Robe of the Invoker", 0.01),
                    new ItemLoot("Essence Tap Skull", 0.01),
                    new ItemLoot("Demonhunter Trap", 0.01)
                    )
            )
            .Init("CRIM Crimson Tornado",
                new State(
                    new Prioritize(
                        new Follow(0.2, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 8, projectileIndex: 0, coolDown: 6000, coolDownOffset: 1000),
                    new Grenade(4, 100, range: 5, coolDown: 3000)
                    )
            )
            .Init("CRIM Headhunter of the Caverns",
                new State(
                    new Prioritize(
                        new StayBack(0.2, 4),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 7, projectileIndex: 1, coolDown: 2000, coolDownOffset: 1000),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 400, coolDownOffset: 1000)
                    ),
                new ItemLoot("Spirit Salve Tome", 0.02),
                new Threshold(0.5,
                    new ItemLoot("Glass Sword", 0.01),
                    new ItemLoot("Ring of Greater Dexterity", 0.01),
                    new ItemLoot("Magesteel Quiver", 0.01)
                    )
            )
        .Init("CRIM Cavern Crystal",
                        new State(
                    new State("Spook",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntitiesNotExistsTransition(9999, "Commence", "CRIM Headhunter of the Caverns", "CRIM Crimson Tornado", "CRIM Knight of Crimson", "CRIM Crimson Warrior", "CRIM Crimson Wizard", "CRIM Crimson Demon")
                        ),
                    new State("Commence",
                       new DropPortalOnDeath("Crimson Showdown Portal", 100, timeout: 99999),
                       new Taunt(true, "The master wants to see you this instant!", "The time has come for you to meet your maker!", "The master will tolerate this no longer!"),
                       new Suicide()
                    )));
    }
}