using common.resources;
using wServer.realm;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Avatar = () => Behav()
            .Init("shtrs Defense System", //Avatar of the Forgotten King 
                new State(
                    new State("Normal1",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HpLessTransition(0.80, "Phase1"), //Shadowman
                        new State("Attack0.1",
                            new Taunt("BURN!"),
                            new Shoot(0, count: 1, fixedAngle: 220, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 230, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 240, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack0.2")
                            ),
                        new State("Attack0.2",
                            new Shoot(0, count: 1, fixedAngle: 310, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 320, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 330, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack0.3")
                            ),
                        new State("Attack0.3",
                            new Taunt("HAHAHAHAHA!"),
                            new Shoot(0, count: 1, fixedAngle: 130, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 140, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 150, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack1.1")
                            ),
                        new State("Attack1.1",
                            new Taunt("LEAVE THIS PLACE!"),
                            new Flash(0xFFFFFF, 0.5, 4),
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: 10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Attack1.2")
                            ),
                        new State("Attack1.2",
                            new Shoot(0, count: 8, fixedAngle: 45, rotateAngle: -10, coolDown: 200),
                            new TimedTransition(2000, "Attack1.21")
                            ),
                        new State("Attack1.21",
                            new Shoot(0, count: 8, fixedAngle: 45, rotateAngle: 10, coolDown: 200),
                            new TimedTransition(2000, "Attack1.3")
                            ),
                        new State("Attack1.3",
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: -10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Attack1.31")
                            ),
                        new State("Attack1.31",
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: 10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Vul1")
                            ),
                        new State("Vul1",
                            new RemoveConditionalEffect(ConditionEffectIndex.Armored),
                            new Taunt("I must gather my strength!", "Foolish whelps, leave me be!"),
                            new Flash(0xFF0000, 0.5, 8),
                            new TimedTransition(4000, "Attack0.1")
                            )
                        ),
                    new State("Phase1",
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Be comsumed by shadow!"),
                        new TossObject("shtrs shadowmans", range: 4, angle: 0, coolDown: 50000),
                        new TossObject("shtrs shadowmans", range: 4, angle: 45, coolDown: 50000),
                        new TossObject("shtrs shadowmans", range: 4, angle: 90, coolDown: 50000),
                        new TossObject("shtrs shadowmans", range: 4, angle: 135, coolDown: 50000),
                        new TossObject("shtrs shadowmans", range: 4, angle: 180, coolDown: 50000),
                        new TossObject("shtrs shadowmans", range: 4, angle: 225, coolDown: 50000),
                        new TossObject("shtrs shadowmans", range: 4, angle: 270, coolDown: 50000),
                        new TossObject("shtrs shadowmans", range: 4, angle: 315, coolDown: 50000),
                        new EntityExistsTransition("shtrs shadowmans", 5, "Waiting1")
                        ),
                    new State("Waiting1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs shadowmans", 5, "Phase2.0")
                        ),
                    new State("Phase2.0",
                        new SetAltTexture(0),
                        new HpLessTransition(0.60, "Phase2"),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new State("Attack2.1",
                            new Taunt("BURN!"),
                            new Shoot(0, count: 1, fixedAngle: 220, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 230, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 240, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack2.2")
                            ),
                        new State("Attack2.2",
                            new Shoot(0, count: 1, fixedAngle: 310, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 320, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 330, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack2.3")
                            ),
                        new State("Attack2.3",
                            new Taunt("HAHAHAHAHA!"),
                            new Shoot(0, count: 1, fixedAngle: 130, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 140, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 150, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack3.1")
                            ),
                        new State("Attack3.1",
                            new Taunt("LEAVE THIS PLACE!"),
                            new Flash(0xFFFFFF, 0.5, 4),
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: 10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Attack3.2")
                            ),
                        new State("Attack3.2",
                            new Shoot(0, count: 8, fixedAngle: 45, rotateAngle: -10, coolDown: 200),
                            new TimedTransition(2000, "Attack3.21")
                            ),
                        new State("Attack3.21",
                            new Shoot(0, count: 8, fixedAngle: 45, rotateAngle: 10, coolDown: 200),
                            new TimedTransition(2000, "Attack3.3")
                            ),
                        new State("Attack3.3",
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: -10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Attack3.31")
                            ),
                        new State("Attack3.31",
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: 10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Vul2")
                            ),
                        new State("Vul2",
                            new RemoveConditionalEffect(ConditionEffectIndex.Armored),
                            new Taunt("I must gather my strength!", "Foolish whelps, leave me be!"),
                            new Flash(0xFF0000, 0.5, 8),
                            new TimedTransition(4000, "Attack2.1")
                            )
                        ),
                    new State("Phase2", //Eye
                        new Taunt("EYE see you!"),
                        new SetAltTexture(1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("shtrs eyeswarmer", 6, "Phase3.0"),
                        new State("Spawn",
                            new Spawn("shtrs eyeswarmer", 6, 1, coolDown: 14000),
                            new TimedTransition(10000, "Respawn")
                            ),
                        new State("Respawn",
                            new Spawn("shtrs eyeswarmer", 6, 1, coolDown: 14000),
                            new TimedTransition(10000, "Spawn")
                            )
                        ),
                    new State("Phase3.0",
                        new SetAltTexture(0),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HpLessTransition(0.45, "Phase3"),
                        new State("Attack4.1",
                            new Taunt("BURN!"),
                            new Shoot(0, count: 1, fixedAngle: 220, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 230, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 240, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack4.2")
                            ),
                        new State("Attack4.2",
                            new Shoot(0, count: 1, fixedAngle: 310, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 320, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 330, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack4.3")
                            ),
                        new State("Attack4.3",
                            new Taunt("HAHAHAHAHA!"),
                            new Shoot(0, count: 1, fixedAngle: 130, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 140, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 150, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack5.1")
                            ),
                        new State("Attack5.1",
                            new Taunt("LEAVE THIS PLACE!"),
                            new Flash(0xFFFFFF, 0.5, 4),
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: 10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Attack5.2")
                            ),
                        new State("Attack5.2",
                            new Shoot(0, count: 8, fixedAngle: 45, rotateAngle: -10, coolDown: 200),
                            new TimedTransition(2000, "Attack5.21")
                            ),
                        new State("Attack5.21",
                            new Shoot(0, count: 8, fixedAngle: 45, rotateAngle: 10, coolDown: 200),
                            new TimedTransition(2000, "Attack5.3")
                            ),
                        new State("Attack5.3",
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: -10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Attack5.31")
                            ),
                        new State("Attack5.31",
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: 10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Vul3")
                            ),
                        new State("Vul3",
                            new RemoveConditionalEffect(ConditionEffectIndex.Armored),
                            new Taunt("I must gather my strength!", "Foolish whelps, leave me be!"),
                            new Flash(0xFF0000, 0.5, 8),
                            new TimedTransition(4000, "Attack4.1")
                            )
                        ),
                    new State("Phase3", //Blobomb
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HpLessTransition(0.20, "Phase4"),
                        new Taunt("You shall be food for the ether, Blobs, attack!"),
                        new State("Attack6.1",
                            new Taunt("BURN!"),
                            new Order(20, "shtrs blobomb maker", "Spawn"),
                            new Shoot(0, count: 1, fixedAngle: 220, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 230, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 240, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack6.2")
                            ),
                        new State("Attack6.2",
                            new Shoot(0, count: 1, fixedAngle: 310, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 320, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 330, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack6.3")
                            ),
                        new State("Attack6.3",
                            new Taunt("HAHAHAHAHA!"),
                            new Shoot(0, count: 1, fixedAngle: 130, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 140, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 150, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack7.1")
                            ),
                        new State("Attack7.1",
                            new Taunt("LEAVE THIS PLACE!"),
                            new Flash(0xFFFFFF, 0.5, 4),
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: 10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Attack7.2")
                            ),
                        new State("Attack7.2",
                            new Shoot(0, count: 8, fixedAngle: 45, rotateAngle: -10, coolDown: 200),
                            new TimedTransition(2000, "Attack7.21")
                            ),
                        new State("Attack7.21",
                            new Shoot(0, count: 8, fixedAngle: 45, rotateAngle: 10, coolDown: 200),
                            new TimedTransition(2000, "Attack7.3")
                            ),
                        new State("Attack7.3",
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: -10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Attack7.31")
                            ),
                        new State("Attack7.31",
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: 10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Vul4")
                            ),
                        new State("Vul4",
                            new RemoveConditionalEffect(ConditionEffectIndex.Armored),
                            new Taunt("I must gather my strength!", "Foolish whelps, leave me be!"),
                            new Flash(0xFF0000, 0.5, 8),
                            new Order(20, "shtrs blobomb maker", "Waiting"),
                            new TimedTransition(4000, "Attack6.1")
                            )
                        ),
                    new State("Phase4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Order(20, "shtrs Pillar 1", "Wake"),
                        new Order(20, "shtrs Pillar 2", "Wake"),
                        new Order(20, "shtrs Pillar 3", "Wake"),
                        new Order(20, "shtrs Pillar 4", "Wake"),
                        new Order(20, "shtrs blobomb maker", "Die"),
                        new TimedTransition(1000, "Waiting4")
                        ),
                    new State("Waiting4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new State("Waiting4.0",
                            new EntityNotExistsTransition("shtrs Pillar 1", 20, "Waiting4.2")
                            ),
                        new State("Waiting4.2",
                            new EntityNotExistsTransition("shtrs Pillar 2", 20, "Waiting4.3")
                            ),
                        new State("Waiting4.3",
                            new EntityNotExistsTransition("shtrs Pillar 3", 20, "Waiting4.4")
                            ),
                        new State("Waiting4.4",
                            new EntityNotExistsTransition("shtrs Pillar 4", 20, "Final")
                            )
                        ),
                    new State("Final",
                        new HpLessTransition(0.10, "Die"),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new State("Attack8.1",
                            new Taunt("BURN!"),
                            new Shoot(0, count: 1, fixedAngle: 220, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 230, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 240, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack8.2")
                            ),
                        new State("Attack8.2",
                            new Shoot(0, count: 1, fixedAngle: 310, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 320, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 330, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack8.3")
                            ),
                        new State("Attack8.3",
                            new Taunt("HAHAHAHAHA!"),
                            new Shoot(0, count: 1, fixedAngle: 130, rotateAngle: 3, coolDown: 300),
                            new Shoot(0, count: 1, fixedAngle: 140, rotateAngle: 3, coolDownOffset: 300, coolDown: 200),
                            new Shoot(0, count: 1, fixedAngle: 150, rotateAngle: 3, coolDownOffset: 600, coolDown: 100),
                            new TimedTransition(900, "Attack9.1")
                            ),
                        new State("Attack9.1",
                            new Taunt("LEAVE THIS PLACE!"),
                            new Flash(0xFFFFFF, 0.5, 4),
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: 10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Attack9.2")
                            ),
                        new State("Attack9.2",
                            new Shoot(0, count: 8, fixedAngle: 45, rotateAngle: -10, coolDown: 200),
                            new TimedTransition(2000, "Attack9.21")
                            ),
                        new State("Attack9.21",
                            new Shoot(0, count: 8, fixedAngle: 45, rotateAngle: 10, coolDown: 200),
                            new TimedTransition(2000, "Attack9.3")
                            ),
                        new State("Attack9.3",
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: -10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Attack9.31")
                            ),
                        new State("Attack9.31",
                            new Shoot(0, count: 6, fixedAngle: 36, rotateAngle: 10, coolDown: 200, projectileIndex: 1),
                            new TimedTransition(2000, "Vul5")
                            ),
                        new State("Vul5",
                            new RemoveConditionalEffect(ConditionEffectIndex.Armored),
                            new Taunt("I must gather my strength!", "Foolish whelps, leave me be!"),
                            new Flash(0xFF0000, 0.5, 8),
                            new TimedTransition(4000, "Attack8.1")
                            )
                        ),
                    new State("Die",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "Suicide"),
                        new Taunt("YOU KNOW NOT WHAT YOU HAVE DONE!"),
                        new Flash(0xFF0000, 0.5, 8)
                        ),
                    new State("Suicide",
                        new Shoot(0, count: 8, fixedAngle: 360/8, projectileIndex: 1),
                        new Suicide()
                        )
                    ),
                new Threshold(0.01,
                    new TierLoot(9, ItemType.Weapon, 0.18),
                    new TierLoot(10, ItemType.Weapon, 0.13),
                    new TierLoot(11, ItemType.Weapon, 0.08),
                    new TierLoot(9, ItemType.Armor, 0.18),
                    new TierLoot(10, ItemType.Armor, 0.13),
                    new TierLoot(11, ItemType.Armor, 0.10),
                    new TierLoot(12, ItemType.Armor, 0.007),
                    new ItemLoot("Potion of Defense", .1),
                    new ItemLoot("Potion of Attack", .1),
                    new ItemLoot("Potion of Vitality", .1),
                    new ItemLoot("Potion of Wisdom", .1),
                    new ItemLoot("Potion of Speed", .1),
                    new ItemLoot("Potion of Dexterity", .1),
                    new ItemLoot("Tablet of the King's Avatar", 0.008),
                    new ItemLoot("Staff of the Great Climbing", 0.008),
                    new ItemLoot("AvatarRobe", 0.008),
					new ItemLoot("Pizza Ring", 0.005),
                    new ItemLoot("AvatarRing", 0.008)
                    )
            )
            .Init("shtrs Pillar 1", //Killer Pillar | Up Left
                new State(
                    new State("Waiting Order",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                    new State("Wake",
                        new Taunt(true, "PROTECT THE AVATAR"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "Attack")
                        ),
                    new State("Attack",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFF0000, 0.5, 8),
                        new TimedTransition(4000, "Keep Calm"),
                        new Shoot(20, count: 1, projectileIndex: 1, predictive: 1, coolDown: 1800),
                        new Shoot(10, projectileIndex: 0, count: 10, fixedAngle: 36, rotateAngle: 18, coolDown: 500)
                        ),
                    new State("Keep Calm",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Flash(0x0033FF, 0.5, 26),
                        new TimedTransition(13000, "Attack")
                        )
                    )
            )
            .Init("shtrs Pillar 2", //Killer Pillar | Down Left
                new State(
                    new State("Waiting Order",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                    new State("Wake",
                        new Taunt(true, "PROTECT THE AVATAR"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "Attack")
                        ),
                    new State("Attack",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFF0000, 0.5, 8),
                        new TimedTransition(4000, "Keep Calm"),
                        new Shoot(20, count: 1, projectileIndex: 1, predictive: 1, coolDown: 1800),
                        new Shoot(10, projectileIndex: 0, count: 10, fixedAngle: 36, rotateAngle: 18, coolDown: 500)
                        ),
                    new State("Keep Calm",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Flash(0x0033FF, 0.5, 26),
                        new TimedTransition(13000, "Attack")
                        )
                    )
            )
            .Init("shtrs Pillar 3", //Killer Pillar | Up Right
                new State(
                    new State("Waiting Order",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                    new State("Wake",
                        new Taunt(true, "PROTECT THE AVATAR"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(9000, "Attack")
                        ),
                    new State("Attack",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFF0000, 0.5, 8),
                        new TimedTransition(4000, "Keep Calm"),
                        new Shoot(20, count: 1, projectileIndex: 1, predictive: 1, coolDown: 1800),
                        new Shoot(10, projectileIndex: 0, count: 10, fixedAngle: 36, rotateAngle: 18, coolDown: 500)
                        ),
                    new State("Keep Calm",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Flash(0x0033FF, 0.5, 26),
                        new TimedTransition(13000, "Attack")
                        )
                    )
            )
            .Init("shtrs Pillar 4", //Killer Pillar | Down Right
                new State(
                    new State("Waiting Order",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                    new State("Wake",
                        new Taunt(true, "PROTECT THE AVATAR"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(13000, "Attack")
                        ),
                    new State("Attack",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFF0000, 0.5, 8),
                        new TimedTransition(4000, "Keep Calm"),
                        new Shoot(20, count: 1, projectileIndex: 1, predictive: 1, coolDown: 1800),
                        new Shoot(10, projectileIndex: 0, count: 10, fixedAngle: 36, rotateAngle: 18, coolDown: 500)
                        ),
                    new State("Keep Calm",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Flash(0x0033FF, 0.5, 26),
                        new TimedTransition(13000, "Attack")
                        )
                    )
            )
            .Init("shtrs shadowmans", //Shades of the Avatar
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Armored, true),
                    new HealEntity(30, "shtrs shadowmans", 1000, coolDown: 4000),
                    new State("Shoot",
                        new Shoot(80, count: 1, coolDown: 5000, projectileIndex: 1, predictive: 1),
                        new State("Shoot1 90°",
                            new Shoot(0, count: 4, fixedAngle: 45, coolDown: 3000),
                            new TimedTransition(2000, "Shoot1 45°")
                            ),
                        new State("Shoot1 45°",
                            new Shoot(0, count: 4, fixedAngle: 90, coolDown: 3000),
                            new TimedTransition(2000, "Shoot1 90°")
                            )
                        )
                    )
            )
            .Init("shtrs eyeswarmer", //Eye of the Avatar
                new State(
                    new Orbit(0.8, 3, 10, "shtrs Defense System", speedVariance: 0.3, radiusVariance: 0.5),
                    new Shoot(20, count: 1, predictive: 1, coolDown: 1500),
                    new Decay(11000)
                    )
            )
            .Init("shtrs portal maker",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new DropPortalOnDeath("The Shatters", 0.5),
                    new State("Spawn Avatar",
                        new Spawn("shtrs Defense System", 1, 1, coolDown: 10000000, givesNoXp: false),
                        new EntityExistsTransition("shtrs Defense System", 10, "Waiting")
                        ),
                    new State("Waiting",
                        new EntityNotExistsTransition("shtrs Defense System", 10, "Die")
                        ),
                    new State("Die",
                        new Suicide()
                        )
                    )
            )
            .Init("shtrs blobomb maker",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Waiting"),
                    new State("Spawn",
                        new Spawn("shtrs blobomb", 1, 1, coolDown: 5000),
                        new TimedTransition(4000, "Respawn")
                        ),
                    new State("Respawn",
                        new Spawn("shtrs blobomb", 1, 1, coolDown: 5000),
                        new TimedTransition(4000, "Spawn")
                        ),
                    new State("Die",
                        new Suicide()
                        )
                    )
            )
            .Init("shtrs Blobomb", //Blobomb
                new State(
                    new State("Follow",
                        new Prioritize(
                            new Follow(0.6, 20, 0)
                            ),
                        new PlayerWithinTransition(1, "Wait"),
                        new TimedTransition(10000, "Wait") //To stop some overspawning
                        ),
                    new State("Wait",
                        new Flash(0xFF0000, 1, 10),
                        new TimedTransition(1000, "Explode")
                        ),
                    new State("Explode",
                        new Shoot(6, 36, fixedAngle: 360/36),
                        new Suicide()
                        )
                    )
            )
            ;
    }
}