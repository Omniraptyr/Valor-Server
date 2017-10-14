using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ GhostShip = () => Behav()
            .Init("Ghost Ship",
                new State(
                    new State("Waiting Player",
                        new SetAltTexture(1),
                        new Prioritize(
                            new Orbit(0.2, 2, 10, "Ghost Ship Anchor")
                            ),
                        new HpLessTransition(0.98, "Start")
                        ),
                    new State("Start",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(0.5, 0),
                        new SetAltTexture(0),
                        new TimedTransition(3000, "PreAttack")
                        ),
                    new State("PreAttack",
                        new ReturnToSpawn(0.5, 0),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new SetAltTexture(2),
                        new OrderOnce(100, "Beach Spectre Spawner", "Active"),
                        new TimedTransition(300, "Phase1+2")
                        ),
                    new State("Phase1+2",
                        new SetAltTexture(0),
                        new Reproduce("Vengeful Spirit", 20, 4, coolDown: 4000),
                        new TossObject("Water Mine", angle: 1, coolDown: 5000, minRange: 3, maxRange: 7,
                            minAngle: 1, maxAngle: 359),
                        new State("Attack",
                            new Prioritize(
                                new Follow(0.2, 10, 3),
                                new Wander(0.3),
                                new StayCloseToSpawn(0.4, 7)
                                ),
                            new Taunt(0.30, "Fire at will!"),
                            new Shoot(10, count: 3, shootAngle: 6, coolDown: 2000),
                            new Shoot(10, count: 1, coolDown: 800),
                            new HpLessTransition(0.90, "TransAttack")
                            ),
                        new State("TransAttack",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new State("TransAttack1",
                                new Taunt(0.99, "Ready..."),
                                new ReturnToSpawn(0.3),
                                new TimedTransition(1000, "TransAttack1.1")
                                ),
                            new State("TransAttack1.1",
                                new Wander(0.3),
                                new Taunt(0.99, "Aim..."),
                                new TimedTransition(1000, "Phase2")
                                ),
                            new State("Phase2",
                                new HpLessTransition(0.7, "Phase3"),
                                new Prioritize(
                                    new Follow(0.2, 10, 3),
                                    new Wander(0.3),
                                    new StayCloseToSpawn(0.4, 7)
                                    ),
                                new State("Attack1.1",
                                    new Taunt(0.99, "FIRE!"),
                                    new Shoot(0, count: 3, shootAngle: 20, fixedAngle: 270, coolDown: 3000),
                                    new Shoot(0, count: 3, shootAngle: 20, fixedAngle: 90, coolDown: 3000),
                                    new TimedTransition(1000, "Attack1.2")
                                    ),
                                new State("Attack1.2",
                                    new Shoot(0, count: 3, shootAngle: 20, fixedAngle: 0, coolDown: 3000),
                                    new Shoot(0, count: 3, shootAngle: 20, fixedAngle: 180, coolDown: 3000),
                                    new TimedTransition(1000, "Attack1.3")
                                    ),
                                new State("Attack1.3",
                                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                    new Shoot(0, count: 3, shootAngle: 20, fixedAngle: 270, coolDown: 3000),
                                    new Shoot(0, count: 3, shootAngle: 20, fixedAngle: 90, coolDown: 3000),
                                    new TimedTransition(1000, "Attack1.4")
                                    ),
                                new State("Attack1.4",
                                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                    new Shoot(0, count: 12, fixedAngle: 360/12, coolDown: 3000),
                                    new TimedTransition(1500, "Attack1.5")
                                    ),
                                new State("Attack1.5",
                                    new Shoot(0, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 3000),
                                    new Shoot(0, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 3000),
                                    new Shoot(0, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 3000),
                                    new Shoot(0, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 3000),
                                    new TimedTransition(1000, "Attack1.6")
                                    ),
                                new State("Attack1.6",
                                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                    new Shoot(0, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 3000),
                                    new Shoot(0, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 3000),
                                    new Shoot(0, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 3000),
                                    new Shoot(0, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 3000),
                                    new TimedTransition(1000, "Attack1.7")
                                    ),
                                new State("Attack1.7",
                                    new Shoot(0, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 5000),
                                    new Shoot(0, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 5000),
                                    new Shoot(0, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 5000),
                                    new Shoot(0, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 5000),
                                    new TimedTransition(3000, "TransAttack")
                                    )))
                        ),
                    new State("Phase3",
                        new Shoot(0, 4, fixedAngle: 360/4, rotateAngle: 35, coolDown: 1000),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1400, predictive: 1),
                        new Reproduce("Vengeful Spirit", 20, 4, coolDown: 4000),
                        new Reproduce("Water Mine", 20, 5, coolDown: 3000),
                        new HpLessTransition(0.5, "Phase4"),
                        new ReturnToSpawn(0.4),
                        new State("Invul",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2000, "Vul")
                            ),
                        new State("Vul",
                            new TimedTransition(3000, "Invul")
                            )
                        ),
                    new State("Phase4",
                        new Prioritize(
                            new Follow(0.2, 10, 3),
                            new Wander(0.4),
                            new StayCloseToSpawn(0.4, 7)
                            ),
                        new TossObject("Water Mine", angle: 1, coolDown: 5000, minRange: 3, maxRange: 7,
                            minAngle: 1, maxAngle: 359),
                        new Shoot(20, count: 2, shootAngle: 8, coolDown: 800),
                        new Shoot(20, count: 3, shootAngle: 8, coolDown: 1300),
                        new Shoot(20, count: 2, shootAngle: 8, coolDown: 2000, projectileIndex: 1),
                        new HpLessTransition(0.4, "PrePhase5"),
                        new State("Invul1",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2000, "Vul1")
                            ),
                        new State("Vul1",
                            new TimedTransition(3000, "Invul1")
                            )
                        ),
                    new State("PrePhase5",
                        new TossObject("Tempest Cloud", 8, 0, tossInvis: true, coolDown: 10000),
                        new TossObject("Tempest Cloud", 8, 36, tossInvis: true, coolDown: 10000),
                        new TossObject("Tempest Cloud", 8, 72, tossInvis: true, coolDown: 10000),
                        new TossObject("Tempest Cloud", 8, 108, tossInvis: true, coolDown: 10000),
                        new TossObject("Tempest Cloud", 8, 144, tossInvis: true, coolDown: 10000),
                        new TossObject("Tempest Cloud", 8, 180, tossInvis: true, coolDown: 10000),
                        new TossObject("Tempest Cloud", 8, 216, tossInvis: true, coolDown: 10000),
                        new TossObject("Tempest Cloud", 8, 252, tossInvis: true, coolDown: 10000),
                        new TossObject("Tempest Cloud", 8, 288, tossInvis: true, coolDown: 10000),
                        new TossObject("Tempest Cloud", 8, 324, tossInvis: true, coolDown: 10000),
                        new EntityExistsTransition("Tempest Cloud", 10, "Phase5")
                        ),
                    new State("Phase5",
                        new OrderOnce(100, "Beach Spectre Spawner", "Active"),
                        new Shoot(0, 4, fixedAngle: 360/4, rotateAngle: 35, coolDown: 1000),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1400, predictive: 1),
                        new Reproduce("Vengeful Spirit", 20, 4, coolDown: 4000),
                        new Reproduce("Water Mine", 20, 5, coolDown: 3000),
                        new HpLessTransition(0.2, "PrePhase6"),
                        new ReturnToSpawn(0.4),
                        new State("Invul2",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2000, "Vul2")
                            ),
                        new State("Vul2",
                            new TimedTransition(3000, "Invul2")
                            )
                        ),
                    new State("PrePhase6",
                        new Taunt(0.99, "Fire at will!!!"),
                        new TimedTransition(100, "Phase6")
                        ),
                    new State("Phase6",
                        new Prioritize(
                            new Follow(0.2, 10, 3),
                            new Wander(0.4),
                            new StayCloseToSpawn(0.4, 7)
                            ),
                        new TossObject("Water Mine", angle: 1, coolDown: 5000, minRange: 3, maxRange: 7,
                            minAngle: 1, maxAngle: 359),
                        new Shoot(20, count: 2, shootAngle: 8, coolDown: 800),
                        new Shoot(20, count: 3, shootAngle: 8, coolDown: 1300),
                        new Shoot(20, count: 2, shootAngle: 8, coolDown: 2000, projectileIndex: 1),
                        new State("Invul3",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2000, "Vul3")
                            ),
                        new State("Vul3",
                            new TimedTransition(3000, "Invul3")
                            )
                        )
                    ),
                new ItemLoot("Ghost Pirate Rum", .2),
                new Threshold(0.01,
                    new ItemLoot("Potion of Wisdom", .1),
                    new TierLoot(8, ItemType.Weapon, 0.12),
                    new TierLoot(9, ItemType.Weapon, 0.10),
                    new TierLoot(8, ItemType.Armor, 0.12),
                    new TierLoot(9, ItemType.Armor, 0.10),
                    new TierLoot(3, ItemType.Ability, 0.12),
                    new TierLoot(4, ItemType.Ability, 0.10),
                    new TierLoot(4, ItemType.Ring, 0.07),
                    new TierLoot(10, ItemType.Weapon, 0.06),
                    new TierLoot(11, ItemType.Weapon, 0.04),
                    new TierLoot(10, ItemType.Armor, 0.06),
                    new TierLoot(11, ItemType.Armor, 0.04),
                    new TierLoot(5, ItemType.Ability, 0.04),
                    new TierLoot(5, ItemType.Ring, 0.04),
                    new ItemLoot("Wine Cellar Incantation", .001),
                    new ItemLoot("Flaming Sword of Fury", .005),
                    new ItemLoot("Seal of Splashing Lava", .005),
                    new ItemLoot("Steel Armor of Magma", .005),
                    new ItemLoot("Ring of Boiling Lava", .005)
                    )
            )
            .Init("Ghost Ship Anchor",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Waiting",
                        new EntityNotExistsTransition("Ghost Ship", 20, "Davy Or No ?")
                        ),
                    new State("Davy Or No ?",
                        new TimedRandomTransition(10, false, // 1/2 to get davy
                            "Davy",
                            "nah")
                        ),
                    new State("nah",
                        new Suicide()
                        ),
                    new State("nah2",
                        new DropPortalOnDeath("Davy Jones' Locker Portal", 1),
                        new Suicide()
                        ),
                    new State("Davy",
                        new GroundTransform("Ghost Water Beach", relativeX: 1, relativeY: 0, persist: true),
                        new GroundTransform("Ghost Water Beach", relativeX: 0, relativeY: 0, persist: true),
                        new GroundTransform("Ghost Water Beach", relativeX: -1, relativeY: 0, persist: true),
                        new GroundTransform("Ghost Water Beach", relativeX: 0, relativeY: 1, persist: true),
                        new GroundTransform("Ghost Water Beach", relativeX: 0, relativeY: -1, persist: true),
                        new TossObject("Palm Tree", 1, angle: 0, coolDown: 10000, tossInvis: true),
                        new TossObject("Palm Tree", 1, angle: 180, coolDown: 10000, tossInvis: true),
                        new TimedTransition(1000, "nah2")
                        )
                    )
            )
            .Init("Vengeful Spirit",
                new State(
                    new ChangeSize(20, 100),
                    new State("Charge",
                        new Prioritize(
                            new Charge(3),
                            new Wander(0.1)
                            ),
                        new Shoot(5, count: 3, shootAngle: 8, coolDown: 1000),
                        new EntityNotExistsTransition("Ghost Ship", 20, "Die")
                        ),
                    new State("Die",
                        new Suicide()
                        )
                    )
            )
            .Init("Tempest Cloud",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Texture",
                        new ChangeSize(10, 140),
                        new State("Texture1",
                            new SetAltTexture(1, 9, cooldown: 200),
                            new TimedTransition(2000, "Attack")
                            )
                        ),
                    new State("Attack",
                        new Prioritize(
                            new Orbit(0.4, 8, 20, "Ghost Ship")
                            ),
                        new Shoot(0, count: 10, fixedAngle: 360/10, coolDown: 700),
                        new EntityNotExistsTransition("Ghost Ship", 30, "Die")
                        ),
                    new State("Die",
                        new State("Tex",
                            new SetAltTexture(9),
                            new TimedTransition(200, "Tex1")
                            ),
                        new State("Tex1",
                            new SetAltTexture(8),
                            new TimedTransition(200, "Tex2")
                            ),
                        new State("Tex2",
                            new SetAltTexture(7),
                            new TimedTransition(200, "Tex3")
                            ),
                        new State("Tex3",
                            new SetAltTexture(6),
                            new TimedTransition(200, "Tex4")
                            ),
                        new State("Tex4",
                            new SetAltTexture(5),
                            new TimedTransition(200, "Tex5")
                            ),
                        new State("Tex5",
                            new SetAltTexture(4),
                            new TimedTransition(200, "Tex6")
                            ),
                        new State("Tex6",
                            new SetAltTexture(3),
                            new TimedTransition(200, "Tex7")
                            ),
                        new State("Tex7",
                            new SetAltTexture(2),
                            new TimedTransition(200, "Tex8")
                            ),
                        new State("Tex8",
                            new SetAltTexture(1),
                            new TimedTransition(200, "Tex9")
                            ),
                        new State("Tex9",
                            new SetAltTexture(0),
                            new TimedTransition(200, "Tex10")
                            ),
                        new State("Tex10",
                            new Suicide()
                            )
                        )
                    )
            )
            .Init("Water Mine",
                new State(
                    new Decay(10000),
                    new State("GRAB IT",
                        new EntityNotExistsTransition("Ghost Ship", 20, "BOOOM"),
                        new Prioritize(
                            new Follow(0.2, 10, 0)
                            ),
                        new PlayerWithinTransition(3, "BOOOM")
                        ),
                    new State("BOOOM",
                        new Shoot(0, count: 10, fixedAngle: 360/10),
                        new Suicide()
                        )
                    )
            )
            .Init("Beach Spectre Spawner",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new EntityNotExistsTransition("Ghost Ship", 60, "Die"),
                    new State("Waiting Order"),
                    new State("Active",
                        new PlayerWithinTransition(7, "Spawn")
                        ),
                    new State("Spawn",
                        new Reproduce("Beach Spectre", 3, 1, coolDown: 1000),
                        new NoPlayerWithinTransition(8, "Active")
                        ),
                    new State("Die",
                        new Suicide()
                        )
                    )
            )
            .Init("Beach Spectre",
                new State(
                    new ChangeSize(20, 100),
                    new State("Attack",
                        new Prioritize(
                            new Wander(0.1)
                            ),
                        new Shoot(5, count: 3, shootAngle: 12, coolDown: 1300),
                        new NoPlayerWithinTransition(7, "Die")
                        ),
                    new State("Die",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ChangeSize(20, 0),
                        new Decay(3000)
                        )
                    )
            )
            ;
    }
}