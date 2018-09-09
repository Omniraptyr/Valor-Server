using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ FrostChamber = () => Behav()
        .Init("Frozen Warrior 1",
            new State(
                new State("Bullet",
                    new Follow(0.4, 8, 1),
                    new Shoot(10, count: 3, projectileIndex: 0, coolDown: 2200),
                    new TimedTransition(4200, "NadeEm")
                    ),
                new State("NadeEm",
                    new Wander(0.2),
                    new Shoot(10, count: 2, projectileIndex: 0, coolDown: 2800),
                    new Grenade(3, 120, coolDown: 4400),
                    new TimedTransition(4200, "Bullet")
                    )
                )
            )
        .Init("Frozen Warrior 2",
                new State(
                    new Swirl(0.4),
                    new Shoot(10, count: 4, shootAngle: 16, projectileIndex: 0, coolDown: 3800)
                    )
            )
        .Init("Frozen Soul",
                new State(
                    new Follow(0.4, 8, 1),
                    new Taunt(0.50, "Uaag!", "Tasty mortals!", "Delicious souls!", "Come here.."),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: new Cooldown(1800, 600)),
                    new Shoot(10, count: 0, projectileIndex: 0, predictive: 1, coolDown: new Cooldown(2200, 600), coolDownOffset: 600)
                    )
            )
        .Init("Frozen Shield",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new State("Circle",
                        new Orbit(0.35, 3, 20, "Bergelmir, the Frost Guardian"),
                        new Shoot(8, count: 7, projectileIndex: 0, coolDown: 4000, coolDownOffset: 600)
                        )
                    )
                )
        .Init("Frozen Sphere Turret",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Inactive"
                        ),
                    new State("Active",
                        new Shoot(8, count: 3, shootAngle: 60, projectileIndex: 0, coolDown: new Cooldown(3800, 1000))
                        ),
                    new State("Active2",
                        new Shoot(8, count: 1, projectileIndex: 0, coolDown: new Cooldown(1400, 600))
                        ),
                    new State("Active3",
                        new Shoot(8, count: 1, projectileIndex: 0, coolDown: new Cooldown(3800, 400)),
                        new Reproduce("Frozen Warrior 1", densityMax: 1, densityRadius: 16, coolDown: new Cooldown(3600, 800)),
                        new Reproduce("Frozen Warrior 2", densityMax: 1, densityRadius: 16, coolDown: new Cooldown(3600, 800))
                        ),
                    new State("Active4",
                        new Shoot(10, count: 2, shootAngle: 16, projectileIndex: 0, coolDown: 1200),
                        new Reproduce("Frozen Warrior 1", densityMax: 1, densityRadius: 16, coolDown: new Cooldown(4000, 800)),
                        new Reproduce("Frozen Warrior 2", densityMax: 1, densityRadius: 16, coolDown: new Cooldown(4000, 800))
                        )
                    )
                )
        .Init("Bergelmir, the Frost Guardian",
                new State(
                    new AnnounceOnDeath("The Frost Guardian seems to finally melt away..."),
                    new ConditionalEffect(ConditionEffectIndex.SlowedImmune),
                    new RealmPortalDrop(),
                    new State("idle",
                        new PlayerWithinTransition(8, "taunt1")
                        ),
                    new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("taunt1",
                        new Taunt(1.00, "Hello, adventurer. You seem cold..."),
                        new TimedTransition(5000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt(1.00, "I would agree though, it is very chilly in my chamber."),
                        new TimedTransition(5000, "taunt3")
                        ),
                    new State("taunt3",
                        new Taunt(1.00, "Well enough with the chit-chat."),
                        new TimedTransition(5000, "taunt4")
                        ),
                    new State("taunt4",
                        new Taunt(1.00, "Your companions might just come pay their respects at your frozen gravestone."),
                        new TimedTransition(5000, "flash")
                        ),
                    new State("flash",
                        new Flash(0x0000BB, 4, 4),
                        new TimedTransition(5800, "ShotgunPhase1")
                        )
                    ),
                    new State("ShotgunPhase1",
                        new Order(99, "Frozen Sphere Turret", "Active"),
                        new Taunt(1.00, "I will shred you to pieces."),
                        new Prioritize(
                            new Follow(0.52, 8, 1),
                            new Wander(0.4)
                            ),
                        new Shoot(8.4, count: 6, shootAngle: 20, projectileIndex: 4, coolDown: new Cooldown(2400, 100)),
                        new Shoot(8.4, count: 10, shootAngle: 12, projectileIndex: 1, predictive: 2, coolDown: 3400, coolDownOffset: 600),
                        new Shoot(8.4, count: 8, shootAngle: 22, projectileIndex: 0, predictive: 4, coolDown: 3400, coolDownOffset: 1400),
                        new Shoot(8.4, count: 9, projectileIndex: 4, coolDown: 5200),
                        new TossObject("Frozen Soul", 4, 0, coolDown: 9999999),
                        new TossObject("Frozen Soul", 4, 90, coolDown: 9999999),
                        new TossObject("Frozen Soul", 4, 180, coolDown: 9999999),
                        new TossObject("Frozen Soul", 4, 270, coolDown: 9999999),
                        //Extra Souls
                        new TossObject("Frozen Soul", 4, 180, coolDown: 9999999, coolDownOffset: 1000),
                        new TossObject("Frozen Soul", 4, 90, coolDown: 9999999, coolDownOffset: 1000),
                        new TimedTransition(10000, "WanderandAttack1")
                        ),
                    new State("WanderandAttack1",
                        new Wander(0.6),
                        new Shoot(8.4, count: 6, projectileIndex: 4, coolDown: 3000, coolDownOffset: 600),
                        new Shoot(8.4, count: 10, shootAngle: 50, projectileIndex: 4, coolDown: 3000, coolDownOffset: 1000),
                        new TossObject("Frozen Soul", 4, 180, coolDown: 9999999, coolDownOffset: 5000),
                        new TossObject("Frozen Soul", 4, 90, coolDown: 9999999, coolDownOffset: 5000),
                        new Order(99, "Frozen Sphere Turret", "Active3"),
                        new TimedTransition(8000, "flashwarning")
                        ),
                    new State("flashwarning",
                        new TossObject("Frozen Soul", 4, 0, coolDown: 9999999),
                        new TossObject("Frozen Soul", 4, 90, coolDown: 9999999),
                        new TossObject("Frozen Soul", 4, 180, coolDown: 9999999),
                        new TossObject("Frozen Soul", 4, 270, coolDown: 9999999),
                        //Extra Souls
                        new TossObject("Frozen Soul", 4, 180, coolDown: 9999999, coolDownOffset: 1000),
                        new TossObject("Frozen Soul", 4, 90, coolDown: 9999999, coolDownOffset: 1000),
                        new TossObject("Frozen Soul", 4, 270, coolDown: 9999999, coolDownOffset: 1000),
                        new TossObject("Frozen Soul", 4, 0, coolDown: 9999999, coolDownOffset: 1000),
                        new Taunt("Ice isn't nice when you can't see the rice!", "Fear my fast ultimate fighting abilities! They are cool!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFF0000, 3, 3),
                        new TimedTransition(4800, "RushCrnrTR1")
                        ),
                    //Rush to Corner Top Right
                    new State("RushCrnrTR1",
                        new Order(99, "Frozen Sphere Turret", "Active4"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        //new MoveTo2(35, 9, speed: 1.6, isMapPosition: true, once: true),
                        new TimedTransition(3400, "RushCrnrTR2")
                        ),
                    new State("RushCrnrTR2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8.4, count: 16, projectileIndex: 3, coolDown: 2000),
                        new Shoot(8.4, count: 1, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(7600, "RushCrnrTL1")
                        ),
                    //Rush to Corner Top Left
                    new State("RushCrnrTL1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        //new MoveTo2(10, 9, speed: 1.6, isMapPosition: true, once: true),
                        new TimedTransition(3400, "RushCrnrTL2")
                        ),
                    new State("RushCrnrTL2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8.4, count: 16, projectileIndex: 3, coolDown: 2000),
                        new Shoot(8.4, count: 1, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(7600, "RushCrnrBL1")
                        ),
                    //Rush to Corner Bottom Left
                    new State("RushCrnrBL1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        //new MoveTo2(10, 23, speed: 1.6, isMapPosition: true, once: true),
                        new TimedTransition(3400, "RushCrnrBL2")
                        ),
                    new State("RushCrnrBL2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8.4, count: 16, projectileIndex: 3, coolDown: 2000),
                        new Shoot(8.4, count: 1, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(7600, "RushCrnrBR1")
                        ),
                    //Rush to Corner Bottom Right
                    new State("RushCrnrBR1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        //new MoveTo2(35, 23, speed: 1.6, isMapPosition: true, once: true),
                        new TimedTransition(3400, "RushCrnrBR2")
                        ),
                    new State("RushCrnrBR2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8.4, count: 16, projectileIndex: 3, coolDown: 2000),
                        new Shoot(8.4, count: 1, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(7600, "HealingPhaseBef")
                        ),
                    new State("HealingPhaseBef",
                        new Flash(0x00FF00, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        //new MoveTo2(23, 16, speed: 1, isMapPosition: true, once: true),
                        new TimedTransition(4600, "HealStart")
                        ),
                    new State("HealStart",
                        new Order(99, "Frozen Sphere Turret", "Active2"),
                        new Taunt("Regaining my strength by eating ice cubes is fun!", "It's like the Ice Age all over again!"),
                        new TimedTransition(8000, "ProtectionPhase")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("ProtectionPhase",
                        new Order(99, "Frozen Sphere Turret", "Active"),
                        new Flash(0xFFFFFF, 2, 2),
                        new TossObject("Frozen Shield", 3, 0, coolDown: 9999999),
                        new TossObject("Frozen Shield", 3, 90, coolDown: 9999999),
                        new TossObject("Frozen Shield", 3, 180, coolDown: 9999999),
                        new TossObject("Frozen Shield", 3, 270, coolDown: 9999999),
                        new TimedTransition(3000, "ShieldCheck")
                        ),
                    new State("ShieldCheck",
                        new Grenade(3, 80, range: 4, coolDown: new Cooldown(3400, 1000)),
                        new EntitiesNotExistsTransition(99, "CenterPhase1", "Frozen Shield")
                        )
                      ),
                     new State("CenterPhase1",
                        new Order(99, "Frozen Sphere Turret", "Active3"),
                        new TimedTransition(11000, "ShotgunPhase1"),
                        new TossObject("Frozen Soul", 4, 0, coolDown: 9999999),
                        new TossObject("Frozen Soul", 4, 90, coolDown: 9999999),
                        new TossObject("Frozen Soul", 4, 180, coolDown: 9999999),
                        new TossObject("Frozen Soul", 4, 270, coolDown: 9999999),

                        new TossObject("Frozen Soul", 4, 0, coolDown: 9999999, coolDownOffset: 1000),
                        new TossObject("Frozen Soul", 4, 90, coolDown: 9999999, coolDownOffset: 1000),
                        new TossObject("Frozen Soul", 4, 180, coolDown: 9999999, coolDownOffset: 1000),
                        new TossObject("Frozen Soul", 4, 270, coolDown: 9999999, coolDownOffset: 1000),
                        new Shoot(8.4, count: 3, shootAngle: 20, projectileIndex: 5, coolDown: 4800, coolDownOffset: 600),
                        new Shoot(8.4, count: 2, shootAngle: 18, projectileIndex: 0, coolDown: 4800, coolDownOffset: 1800),
                        new Shoot(8.4, count: 1, projectileIndex: 2, coolDown: 4800, coolDownOffset: 2400),
                        new State("Duoforce1",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Duoforce2")
                        ),
                        new State("Duoforce2",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Duoforce3")
                        ),
                        new State("Duoforce3",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Duoforce4")
                        ),
                        new State("Duoforce4",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Duoforce21")
                        ),
                         new State("Duoforce21",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(75, "Duoforce23")
                        ),
                         new State("Duoforce23",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(75, "Duoforce25")
                        ),
                         new State("Duoforce25",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(75, "Duoforce26")
                        ),
                         new State("Duoforce26",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(75, "Duoforce24")
                        ),
                         new State("Duoforce24",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(75, "Duoforce22")
                        ),
                          new State("Duoforce22",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(75, "Duoforce5")
                        ),
                        new State("Duoforce5",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(75, "Duoforce6")
                        ),
                        new State("Duoforce6",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(75, "Duoforce7")
                        ),
                        new State("Duoforce7",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(75, "Duoforce8")
                        ),
                        new State("Duoforce8",
                            new Shoot(0, projectileIndex: 3, count: 2, shootAngle: 180, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(75, "Duoforce1")
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
                    new ItemLoot("Frozen Chestguard", 0.50),
                    new TierLoot(6, ItemType.Ability, 0.1),
                    new TierLoot(12, ItemType.Armor, 0.1),
                    new TierLoot(12, ItemType.Weapon, 0.1),
                    new TierLoot(6, ItemType.Ring, 0.1)
                    )
                )
         ;
    }
}