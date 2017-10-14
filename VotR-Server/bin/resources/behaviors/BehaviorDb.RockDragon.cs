using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ RockDragon = () => Behav()
            .Init("Dragon Head", //6Alt Texture | 0->3 Proj
                new State(
                    new TransferDamageOnDeath("Dragon Head Spawner"),
                    new State("Invul",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new State("Spawn Segment",
                            new SetAltTexture(0),
                            new Spawn("Body Segment A", 1, 1, 5000),
                            new Spawn("Body Segment B", 1, 1, 5000),
                            new Spawn("Body Segment C", 1, 1, 5000),
                            new Spawn("Body Segment D", 1, 1, 5000),
                            new Spawn("Body Segment E", 1, 1, 5000),
                            new Spawn("Body Segment F", 1, 1, 5000),
                            new Spawn("Body Segment G", 1, 1, 5000),
                            new Spawn("Body Segment H", 1, 1, 5000),
                            new Spawn("Body Segment I", 1, 1, 5000),
                            new Spawn("Body Segment Tail", 1, 1, 5000),
                            new TimedTransition(1500, "Movement")
                            ),
                        new State("Movement", //MYSTERY I DON4T KNOW HOW TO MADE IT
                            new GroupNotExistTransition(100, "Attack", "Body Segments"),
                            new Shoot(60, count: 5, fixedAngle: 0, shootAngle: 10, coolDown: 1000,
                                projectileIndex: 1),
                            new State("Random", //Wrong Idea
                                new TimedRandomTransition(10, false,
                                    "BR",
                                    "TR",
                                    "BL",
                                    "TL"
                                    )
                                ),
                            new State("TL",
                                new Orbit(2, 1, 50, "Dragon Marker TL", 0, 2),
                                new TimedTransition(2000, "Random")
                                ),
                            new State("TR",
                                new Orbit(2, 1, 50, "Dragon Marker TR", 0, 2, true),
                                new TimedTransition(2000, "Random")
                                ),
                            new State("BL",
                                new Orbit(2, 1, 50, "Dragon Marker BL", 0, 2),
                                new TimedTransition(2000, "Random")
                                ),
                            new State("BR",
                                new Orbit(2, 1, 50, "Dragon Marker BR", 0, 2, true),
                                new TimedTransition(2000, "Random")
                                )
                            )
                        ),
                    new State("Attack",
                        new SetAltTexture(1, 6, 500, true),
                        new Prioritize(
                            new StayCloseToSpawn(2, 20),
                            new Wander(1.5)
                            ),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: new Cooldown(2000, 500)),
                        new Shoot(20, count: 5, fixedAngle: 360/5, projectileIndex: 3, coolDown: 2000),
                        new Shoot(20, count: 5, fixedAngle: 360/5, projectileIndex: 3, coolDown: 2000,
                            coolDownOffset: 500),
                        new TimedTransition(15000, "Spawn Segment")
                        )
                    ),
                new Threshold(0.01,
                    new TierLoot(8, ItemType.Weapon, .15),
                    new TierLoot(9, ItemType.Weapon, .1),
                    new TierLoot(10, ItemType.Weapon, .07),
                    new TierLoot(11, ItemType.Weapon, .05),
                    new TierLoot(4, ItemType.Ability, .15),
                    new TierLoot(5, ItemType.Ability, .07),
                    new TierLoot(8, ItemType.Armor, .2),
                    new TierLoot(9, ItemType.Armor, .15),
                    new TierLoot(10, ItemType.Armor, .10),
                    new TierLoot(11, ItemType.Armor, .07),
                    new TierLoot(12, ItemType.Armor, .04),
                    new TierLoot(5, ItemType.Ring, .03),
                    new ItemLoot("Potion of Defense", .1),
                    new ItemLoot("Potion of Attack", .1),
                    new ItemLoot("Potion of Vitality", .1),
                    new ItemLoot("Potion of Wisdom", .1),
                    new ItemLoot("Potion of Speed", .1),
                    new ItemLoot("Potion of Dexterity", .1),
                    new ItemLoot("Ray Katana", .01)
                    )
            )
            #region Segment

            .Init("Body Segment A", // A to I = 9Segment +1Tail | Proj Invis ? 
                new State(
                    new TransformOnDeath("Body Segment Bomb"),
                    new Protect(2, "Dragon Head", 20, 2, 2)
                    )
            )
            .Init("Body Segment B", // A to I = 9Segment +1Tail | Proj Invis ? 
                new State(
                    new TransformOnDeath("Body Segment Bomb"),
                    new State("Wait", //Prevent Wrong Order when he spawn.
                        new TimedTransition(1000, "WastedLine7")
                        ),
                    new State("WastedLine7",
                        new Protect(2, "Body Segment A", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment A", 100, "WastedLine8")
                        ),
                    new State("WastedLine8",
                        new Protect(2, "Dragon Head", 20, 2, 2)
                        )
                    )
            )
            .Init("Body Segment C", // A to I = 9Segment +1Tail | Proj Invis ? 
                new State(
                    new TransformOnDeath("Body Segment Bomb"),
                    new State("Wait",
                        new TimedTransition(1000, "WastedLine6")
                        ),
                    new State("WastedLine6",
                        new Protect(2, "Body Segment B", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment B", 100, "WastedLine7")
                        ),
                    new State("WastedLine7",
                        new Protect(2, "Body Segment A", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment A", 100, "WastedLine8")
                        ),
                    new State("WastedLine8",
                        new Protect(2, "Dragon Head", 20, 2, 2)
                        )
                    )
            )
            .Init("Body Segment D", // A to I = 9Segment +1Tail | Proj Invis ? 
                new State(
                    new TransformOnDeath("Body Segment Bomb"),
                    new State("Wait",
                        new TimedTransition(1000, "WastedLine5")
                        ),
                    new State("WastedLine5",
                        new Protect(2, "Body Segment C", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment C", 100, "WastedLine6")
                        ),
                    new State("WastedLine6",
                        new Protect(2, "Body Segment B", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment B", 100, "WastedLine7")
                        ),
                    new State("WastedLine7",
                        new Protect(2, "Body Segment A", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment A", 100, "WastedLine8")
                        ),
                    new State("WastedLine8",
                        new Protect(2, "Dragon Head", 20, 2, 2)
                        )
                    )
            )
            .Init("Body Segment E", // A to I = 9Segment +1Tail | Proj Invis ? 
                new State(
                    new TransformOnDeath("Body Segment Bomb"),
                    new State("Wait",
                        new TimedTransition(1000, "WastedLine4")
                        ),
                    new State("WastedLine4",
                        new Protect(2, "Body Segment D", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment D", 100, "WastedLine5")
                        ),
                    new State("WastedLine5",
                        new Protect(2, "Body Segment C", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment C", 100, "WastedLine6")
                        ),
                    new State("WastedLine6",
                        new Protect(2, "Body Segment B", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment B", 100, "WastedLine7")
                        ),
                    new State("WastedLine7",
                        new Protect(2, "Body Segment A", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment A", 100, "WastedLine8")
                        ),
                    new State("WastedLine8",
                        new Protect(2, "Dragon Head", 20, 2, 2)
                        )
                    )
            )
            .Init("Body Segment F", // A to I = 9Segment +1Tail | Proj Invis ? 
                new State(
                    new TransformOnDeath("Body Segment Bomb"),
                    new State("Wait",
                        new TimedTransition(1000, "WastedLine3")
                        ),
                    new State("WastedLine3",
                        new Protect(2, "Body Segment E", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment E", 100, "WastedLine4")
                        ),
                    new State("WastedLine4",
                        new Protect(2, "Body Segment D", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment D", 100, "WastedLine5")
                        ),
                    new State("WastedLine5",
                        new Protect(2, "Body Segment C", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment C", 100, "WastedLine6")
                        ),
                    new State("WastedLine6",
                        new Protect(2, "Body Segment B", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment B", 100, "WastedLine7")
                        ),
                    new State("WastedLine7",
                        new Protect(2, "Body Segment A", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment A", 100, "WastedLine8")
                        ),
                    new State("WastedLine8",
                        new Protect(2, "Dragon Head", 20, 2, 2)
                        )
                    )
            )
            .Init("Body Segment G", // A to I = 9Segment +1Tail | Proj Invis ? 
                new State(
                    new TransformOnDeath("Body Segment Bomb"),
                    new State("Wait",
                        new TimedTransition(1000, "WastedLine2")
                        ),
                    new State("WastedLine2",
                        new Protect(2, "Body Segment F", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment F", 100, "WastedLine3")
                        ),
                    new State("WastedLine3",
                        new Protect(2, "Body Segment E", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment E", 100, "WastedLine4")
                        ),
                    new State("WastedLine4",
                        new Protect(2, "Body Segment D", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment D", 100, "WastedLine5")
                        ),
                    new State("WastedLine5",
                        new Protect(2, "Body Segment C", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment C", 100, "WastedLine6")
                        ),
                    new State("WastedLine6",
                        new Protect(2, "Body Segment B", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment B", 100, "WastedLine7")
                        ),
                    new State("WastedLine7",
                        new Protect(2, "Body Segment A", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment A", 100, "WastedLine8")
                        ),
                    new State("WastedLine8",
                        new Protect(2, "Dragon Head", 20, 2, 2)
                        )
                    )
            )
            .Init("Body Segment H", // A to I = 9Segment +1Tail | Proj Invis ? 
                new State(
                    new TransformOnDeath("Body Segment Bomb"),
                    new State("Wait",
                        new TimedTransition(1000, "WastedLine1")
                        ),
                    new State("WastedLine1",
                        new Protect(2, "Body Segment G", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment G", 100, "WastedLine2")
                        ),
                    new State("WastedLine2",
                        new Protect(2, "Body Segment F", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment F", 100, "WastedLine3")
                        ),
                    new State("WastedLine3",
                        new Protect(2, "Body Segment E", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment E", 100, "WastedLine4")
                        ),
                    new State("WastedLine4",
                        new Protect(2, "Body Segment D", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment D", 100, "WastedLine5")
                        ),
                    new State("WastedLine5",
                        new Protect(2, "Body Segment C", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment C", 100, "WastedLine6")
                        ),
                    new State("WastedLine6",
                        new Protect(2, "Body Segment B", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment B", 100, "WastedLine7")
                        ),
                    new State("WastedLine7",
                        new Protect(2, "Body Segment A", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment A", 100, "WastedLine8")
                        ),
                    new State("WastedLine8",
                        new Protect(2, "Dragon Head", 20, 2, 2)
                        )
                    )
            )
            .Init("Body Segment I", // A to I = 9Segment +1Tail | Proj Invis ? 
                new State(
                    new TransformOnDeath("Body Segment Bomb"),
                    new State("Wait",
                        new TimedTransition(1000, "WastedLine")
                        ),
                    new State("WastedLine",
                        new Protect(2, "Body Segment H", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment H", 100, "WastedLine1")
                        ),
                    new State("WastedLine1",
                        new Protect(2, "Body Segment G", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment G", 100, "WastedLine2")
                        ),
                    new State("WastedLine2",
                        new Protect(2, "Body Segment F", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment F", 100, "WastedLine3")
                        ),
                    new State("WastedLine3",
                        new Protect(2, "Body Segment E", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment E", 100, "WastedLine4")
                        ),
                    new State("WastedLine4",
                        new Protect(2, "Body Segment D", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment D", 100, "WastedLine5")
                        ),
                    new State("WastedLine5",
                        new Protect(2, "Body Segment C", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment C", 100, "WastedLine6")
                        ),
                    new State("WastedLine6",
                        new Protect(2, "Body Segment B", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment B", 100, "WastedLine7")
                        ),
                    new State("WastedLine7",
                        new Protect(2, "Body Segment A", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment A", 100, "WastedLine8")
                        ),
                    new State("WastedLine8",
                        new Protect(2, "Dragon Head", 20, 2, 2)
                        )
                    )
            )
            .Init("Body Segment Tail",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable, true),
                    new State("Wait",
                        new TimedTransition(1000, "Wasted Line")
                        ),
                    new State("Wasted Line",
                        new Protect(2, "Body Segment I", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment I", 100, "WastedLine")
                        ),
                    new State("WastedLine",
                        new Protect(2, "Body Segment H", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment H", 100, "WastedLine1")
                        ),
                    new State("WastedLine1",
                        new Protect(2, "Body Segment G", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment G", 100, "WastedLine2")
                        ),
                    new State("WastedLine2",
                        new Protect(2, "Body Segment F", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment F", 100, "WastedLine3")
                        ),
                    new State("WastedLine3",
                        new Protect(2, "Body Segment E", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment E", 100, "WastedLine4")
                        ),
                    new State("WastedLine4",
                        new Protect(2, "Body Segment D", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment D", 100, "WastedLine5")
                        ),
                    new State("WastedLine5",
                        new Protect(2, "Body Segment C", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment C", 100, "WastedLine6")
                        ),
                    new State("WastedLine6",
                        new Protect(2, "Body Segment B", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment B", 100, "WastedLine7")
                        ),
                    new State("WastedLine7",
                        new Protect(2, "Body Segment A", 20, 2, 2),
                        new EntityNotExistsTransition("Body Segment A", 100, "WastedLine8")
                        ),
                    new State("WastedLine8",
                        new Suicide()
                        )
                    )
            )
            .Init("Body Segment Bomb", // All Texture 1 ? |
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Prepare",
                        new SetAltTexture(0, 1, 250, true),
                        new TimedTransition(2000, "Explode")
                        ),
                    new State("Explode",
                        new Shoot(0, count: 14, fixedAngle: 360/14, coolDown: 5000),
                        new Suicide()
                        )
                    )
            )
            #endregion Segment

            .Init("Rock Dragon Bat", // All Texture 1 ? | 0->3 Proj
                new State(
                    new State("Normal",
                        new Prioritize(
                            new Follow(0.6, 10, 3),
                            new Wander(0.4)
                            ),
                        new Shoot(10, count: 3, shootAngle: 7, coolDown: new Cooldown(1200, 200), projectileIndex: 3),
                        new Shoot(7, count: 1, projectileIndex: 0, coolDown: 1500),
                        new Shoot(7, count: 1, projectileIndex: 1, coolDown: 1500, coolDownOffset: 100),
                        new Shoot(7, count: 1, projectileIndex: 2, coolDown: 1500, coolDownOffset: 200),
                        new PlayerWithinTransition(2, "Explode")
                        ),
                    new State("Explode",
                        new Shoot(0, count: 10, fixedAngle: 36, projectileIndex: 0),
                        new Suicide()
                        )
                    )
            )
            .Init("Dragon Head Spawner", //Spawn Dragon
                new State(
                    //                  new DropPortalOnDeath("Lair of Draconis Portal",0.5),
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Spawn",
                        new Spawn("Dragon Head", 1, 1, 10000, givesNoXp: false),
                        new TimedTransition(1000, "Wait")
                        ),
                    new State("Wait")
                    )
            )
            .Init("Dragon Marker BR", //  Maybe for Movement And Spawn of Bat
                new State(
                    new State("Spawn",
                        new Reproduce("Rock Dragon Bat", 100, 6, 4000),
                        new EntityNotExistsTransition("Dragon Head", 100, "Die")
                        ),
                    new State("Die",
                        new Suicide()
                        )
                    )
            )
            .Init("Dragon Marker BL", //  Maybe for Movement And Spawn of Bat
                new State(
                    new State("Spawn",
                        new Reproduce("Rock Dragon Bat", 100, 6, 4000),
                        new EntityNotExistsTransition("Dragon Head", 100, "Die")
                        ),
                    new State("Die",
                        new Suicide()
                        )
                    )
            )
            .Init("Dragon Marker TR", //  Maybe for Movement And Spawn of Bat
                new State(
                    new State("Spawn",
                        new Reproduce("Rock Dragon Bat", 100, 6, 4000),
                        new EntityNotExistsTransition("Dragon Head", 100, "Die")
                        ),
                    new State("Die",
                        new Suicide()
                        )
                    )
            )
            .Init("Dragon Marker TL", //   Maybe for Movement And Spawn of Bat
                new State(
                    new State("Spawn",
                        new Reproduce("Rock Dragon Bat", 100, 6, 4000),
                        new EntityNotExistsTransition("Dragon Head", 100, "Die")
                        ),
                    new State("Die",
                        new Suicide()
                        )
                    )
            )
            ;
    }
}