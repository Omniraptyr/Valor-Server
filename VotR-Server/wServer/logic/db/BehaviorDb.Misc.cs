#region

using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.logic.behaviors.PetBehaviors;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Misc = () => Behav()
            .Init("White Fountain",
                new State(
                    new HealPlayer(5, 450, 100)
                )
            )
            .Init("Winter Fountain Frozen",
                new State(
                    new HealPlayer(5, 450, 100)
                )
            )
            .Init("Nexus Crier",
                new State("Active",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new BackAndForth(.2, 3)
                )
            )
            .Init("Elite Skeleton",
                new State(
                    new State("Default",
                        new Prioritize(
                            new Follow(1.2, 8, 1),
                            new Wander(0.4)
                        ),
                        new Shoot(8, 6, 8, 2, coolDown: 800),
                        new TimedTransition(3000, "Default1")
                    ),
                    new State("Default1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Charge(2, 10, 1000),
                            new Wander(0.4)
                        ),
                        new Shoot(8, 12, projectileIndex: 1, coolDown: 200),
                        new TimedTransition(2000, "Default2")
                    ),
                    new State("Default2",
                        new Prioritize(
                            new StayBack(1, 4),
                            new Wander(0.4)
                        ),
                        new Shoot(8, 4, 8, 0, coolDown: 800),
                        new TimedTransition(3000, "Default3")
                    ),
                    new State("Default3",
                        new Taunt(0.05, "You don't belong here.."),
                        new HealSelf(1000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "Default")
                    )
                )
            )
            .Init("TF Sector",
                new State(
                    new EntitiesNotExistsTransition(99, "die", "TF The Fallen"),
                    new Orbit(0.35, 8, 20, "TF The Fallen"),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("recker",
                        new TimedTransition(12000, "GoDumb"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 1400),
                            new TimedTransition(1400, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 1400),
                            new TimedTransition(1400, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 1400),
                            new TimedTransition(1400, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 1400),
                            new TimedTransition(1400, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 1400),
                            new TimedTransition(1400, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 1400),
                            new TimedTransition(1400, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 1400),
                            new TimedTransition(1400, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 1400),
                            new TimedTransition(1400, "Quadforce1")
                        )
                    ),
                    new State("GoDumb",
                        new Shoot(8.4, 8, 24, 0, coolDown: 2500),
                        new Grenade(3, 160, 8, coolDown: 1000),
                        new TimedTransition(8000, "recker")
                    ),
                    new State("die",
                        new Suicide()
                    )
                )
            )
            .Init("TF The Fallen",
                new State(
                    new State(
                        new HpLessTransition(0.13, "rip1"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new State("idle",
                            new EntitiesNotExistsTransition(9999, "taunt", "TF Creature Wizard", "TF Warrior",
                                "TF Knight 1", "TF KNight 2")
                        ),
                        new State("taunt",
                            new Taunt(true, "Come. You shall be destroyed by the hands of me.",
                                "We do not have mercy on your souls nor does our leader. Die.",
                                "Our time of awakening has come. Join us or be slayed."),
                            new TimedTransition(10000, "waitforplayers")
                        ),
                        new State("waitforplayers",
                            new PlayerWithinTransition(8, "plantspookstart")
                        ),
                        new State("plantspookstart",
                            new Taunt(
                                "Ah. The time has come. The time for the end of the human race. Consuming your spirits will make me more powerful than ever!"),
                            new InvisiToss("TF Sector", 8, 0, 9999999),
                            new InvisiToss("TF Sector", 8, 180, 9999999),
                            new TimedTransition(5000, "fight1")
                        )
                    ),
                    new State("fight1",
                        new Shoot(8.4, 1, projectileIndex: 3, coolDown: 1),
                        new Shoot(8.4, 5, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(8000, "fight2")
                    ),
                    new State("fight2",
                        new HealSelf(2000, 6000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8.4, 8, 16, 2, coolDown: 2000),
                        new Shoot(8.4, 4, 16, predictive: 4, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(8000, "fight3")
                    ),
                    new State("fight3",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8.4, 5, projectileIndex: 3, coolDown: 2000),
                        new Shoot(8.4, 8, 12, predictive: 2, projectileIndex: 2, coolDown: 1),
                        new TimedTransition(10000, "fight1"),
                        new State("Quadforce1",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 100),
                            new TimedTransition(200, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 100),
                            new TimedTransition(200, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 100),
                            new TimedTransition(200, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 100),
                            new TimedTransition(200, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 100),
                            new TimedTransition(200, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 100),
                            new TimedTransition(200, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 100),
                            new TimedTransition(200, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 4, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 100),
                            new TimedTransition(200, "Quadforce1")
                        )
                    ),
                    new State("rip1",
                        new RemoveEntity(9999, "TF Sector"),
                        new Taunt("I NEVER THOUGHT I WOULD SEE THE END OF ME!", "THE REST OF MY POWER...IT FADES AWAY!",
                            "GAAAAAAR AAAAGH!"),
                        new Flash(0xFFFF00, 2, 4),
                        new TimedTransition(4000, "rip2")
                    ),
                    new State("rip2",
                        new Suicide()
                    )
                ),
                new Threshold(0.025,
                    new TierLoot(10, ItemType.Weapon, 0.07),
                    new TierLoot(11, ItemType.Weapon, 0.06),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new TierLoot(5, ItemType.Ability, 0.07),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.07),
                    new TierLoot(12, ItemType.Armor, 0.06),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(6, ItemType.Ring, 0.06),
                    new ItemLoot("Menacing Sword of No Escape", 0.05),
                    new ItemLoot("Battleplate of Sacred Warlords", 0.05),
                    new ItemLoot("Onrane", 0.05)
                )
            )
            .Init("Sheep",
                new State(
                    new PlayerWithinTransition(15, "player_nearby"),
                    new State("player_nearby",
                        new Prioritize(
                            new StayCloseToSpawn(0.1, 2),
                            new Wander(0.1)
                        ),
                        new Taunt(0.001, 1000, "baa", "baa baa")
                    )
                )
            )
            .Init("Target Spawner",
                new State(
                    new State("Default",
                        new EntityNotExistsTransition("Target Strong", 1, "Spawn")
                    ),
                    new State("Spawn",
                        new Spawn("Target Strong", 1, 1),
                        new TimedTransition(200, "Default")
                    )
                )
            )
            .Init("Dummy Spawner",
                new State(
                    new State("Default",
                        new EntityNotExistsTransition("Dummy Strong", 1, "Spawn")
                    ),
                    new State("Spawn",
                        new Spawn("Dummy Strong", 1, 1),
                        new TimedTransition(200, "Default")
                    )
                )
            )
            .Init("GhostShip Nexus",
                new State(
                    new PlayerWithinTransition(15, "player_nearby"),
                    new State("player_nearby",
                        new Prioritize(
                            new StayCloseToSpawn(0.1, 2),
                            new Wander(0.1)
                        )
                    )
                )
            )

           .Init("T0 Talisman",
                new State(
                    new FamiliarFollow(),
                    new TalismanAttack(280, ConditionEffectIndex.Dazed, 1000)
                )
            )
            .Init("T1 Talisman",
                new State(
                    new FamiliarFollow(),
                    new TalismanAttack(320, ConditionEffectIndex.Dazed, 1000)
                )
            )
            .Init("T2 Talisman",
                new State(
                    new FamiliarFollow(),
                    new TalismanAttack(400, ConditionEffectIndex.Dazed, 1000)
                )
            )
            .Init("T3 Talisman",
                new State(
                    new FamiliarFollow(),
                    new TalismanAttack(520, ConditionEffectIndex.Dazed, 1000)
                )
            )
            .Init("T4 Talisman",
                new State(
                    new FamiliarFollow(),
                    new TalismanAttack(600, ConditionEffectIndex.Dazed, 2000)
                )
            )
            .Init("T5 Talisman",
                new State(
                    new FamiliarFollow(),
                    new TalismanAttack(640, ConditionEffectIndex.Dazed, 2000)
                )
            )
            .Init("T6 Talisman",
                new State(
                    new FamiliarFollow(),
                    new TalismanAttack(680, ConditionEffectIndex.Dazed, 3000)
                )
            )
           .Init("UDL Talisman",
                new State(
                    new FamiliarFollow(),
                    new TalismanAttack(680, ConditionEffectIndex.Curse, 4000)
                )
            )
           .Init("Demon Talisman",
                new State(
                    new FamiliarFollow(),
                    new TalismanAttack(800, ConditionEffectIndex.Dazed, 4000)
                )
            );
    }
}