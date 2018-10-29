using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ ElementalRuins = () => Behav()
              .Init("Elemental Brute",
                  new State(
                    new State("JacobIsBad",
                        new Prioritize(
                            new Follow(1, 8, 1),
                            new Wander(0.1)
                            ),
                        new Shoot(10, predictive: 1, projectileIndex: 1, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 20, projectileIndex: 0, coolDown: 50),
                        new TimedTransition(5750, "SwirlAndShotgun")
                        ),
                    new State("SwirlAndShotgun",
                    new Swirl(speed: 0.48, radius: 3),
                     new Shoot(10, count: 10, projectileIndex: 1, coolDown: 500),
                     new TimedTransition(3750, "JacobIsBad")
                       )
                    )
                  )
                      .Init("Mage of the Elements",
                  new State(
                    new State("Shotgun",
                    new Wander(0.38),
                        new Shoot(10, predictive: 5, projectileIndex: 2, coolDown: 200),
                        new Shoot(10, count: 4, shootAngle: 30, projectileIndex: 0, coolDown: 750),
                        new TimedTransition(3950, "Rush")
                        ),
                    new State("Rush",
                    new Follow(1.38, 8, 1),
                      new Shoot(10, count: 4, shootAngle: 16, projectileIndex: 1, coolDown: 1250),
                     new TimedTransition(2750, "Vulnerable")
                    ),
                    new State("Vulnerable",
                        new Taunt(1.00, "Eaargh!"),
                    new StayBack(0.48, 5),
                    new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1000),
                     new TimedTransition(3500, "Protect")
                    ),
                   new State("Protect",
                       new Taunt(1.00, "The shrine shall uphold the ruins!"),
                       new Taunt(0.50, "I shall defend the power of the ruins!"),
                       new Taunt(0.10, "It is over for you mortals!"),
                  new Prioritize(
                            new Orbit(0.5, 2, 20, "Shrine of the Elements"),
                            new Follow(0.35, 8, 1)
                            ),
                     new Shoot(10, count: 3, shootAngle: 5, projectileIndex: 0, coolDown: 1),
                     new TimedTransition(4750, "Shotgun")

                    )
                 )
              )
         .Init("Shrine of the Elements",
                    new State(
                        new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(3, "WaitingForHit")
                        ),
                    new State("WaitingForHit",
                    new InvisiToss("Lesser Air Elemental", 3.4, angle: 90, coolDown: 24750),
                    new InvisiToss("Lesser Water Elemental", 3.4, angle: 180, coolDown: 27750),
                    new InvisiToss("Lesser Earth Elemental", 3.4, angle: 0, coolDown: 25750),
                    new InvisiToss("Lesser Fire Elemental", 3.4, angle: 270, coolDown: 26750),
                    new HpLessTransition(0.25, "ShootAndDie")
                        ),
                    new State("ShootAndDie",
                        new Flash(0xFF0000, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(4750, "Pie")
                    ),
                     new State("Pie",
                        new TransformOnDeath("Elemental Brute", 1, 2, 1),
                       new ConditionalEffect(ConditionEffectIndex.Invincible),
                       new Shoot(8.4, count: 20, projectileIndex: 0),
                       new Suicide()
                    )
                )
            )
              .Init("Shrine of Urios",
                  new State(
                    new State("JacobIsBad",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                        ),
                    new State("JacobKills",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Grenade(4, 450, 7, fixedAngle: null, coolDown: 1250)
                    )
                 )
              )
           .Init("Lesser Air Elemental",
                new State(
                     new Wander(0.45),
                     new Shoot(8.4, count: 1, shootAngle: 80, predictive: 0.5, projectileIndex: 0, coolDown: 400)
                    )
            )
           .Init("Lesser Fire Elemental",
                new State(
                     new Follow(0.65, 8, 1),
                     new Shoot(8.4, count: 8, predictive: 6, projectileIndex: 0, coolDown: 1600),
                      new Shoot(8.4, count: 4, projectileIndex: 0, coolDown: 1200)
                    )
            )
              .Init("Lesser Earth Elemental",
                  new State(
                    new State("Vulnerable",
                        new Follow(0.45, 8, 1),
                        new Shoot(10, count: 3, projectileIndex: 0, coolDown: 475),
                        new TimedTransition(6000, "Invulnerable")
                        ),
                    new State("Invulnerable",
                        new Follow(0.25, 8, 1),
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                      new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 0, coolDown: 275),
                     new TimedTransition(3500, "Vulnerable")

                    )
                 )
              )
                   .Init("Lesser Water Elemental",
                new State(
                     new Wander(0.56),
                     new Shoot(8.4, count: 3, shootAngle: 36, projectileIndex: 0, coolDown: 2750),
                      new Shoot(8.4, count: 2, shootAngle: 16, projectileIndex: 1, coolDown: 800)
                    )
            )
                 .Init("Summoner of Elements",
                  new State(
                   new State("Spawn",
                   new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                   new PlayerWithinTransition(5, "Enemies")
                    ),
                    new State("Enemies",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new TossObject("Summoner Water Elemental", 2, 0, coolDown: 9999999),
                    new TossObject("Summoner Air Elemental", 2, 90, coolDown: 9999999),
                    new TossObject("Summoner Fire Elemental", 2, 180, coolDown: 9999999),
                    new TossObject("Summoner Earth Elemental", 2, 270, coolDown: 9999999),
                    new TimedTransition(4250, "GetEm")
                    ),
                   new State("GetEm",
                   new Grenade(3, 200, 7, null, coolDown: 2250),
                   new ConditionalEffect(ConditionEffectIndex.Armored),
                   new Follow(0.38, 8, 1)

                    )
                 )
              )
                   .Init("Summoner Water Elemental",
                new State(
                     new Orbit(0.35, 2, 20, "Summoner of Elements"),
                     new Shoot(8.4, count: 3, shootAngle: 10, projectileIndex: 1, coolDown: 1000),
                     new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 460)
                    )
            )
                   .Init("Summoner Earth Elemental",
                new State(
                     new Orbit(0.35, 2, 20, "Summoner of Elements"),
                     new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 750)
                    )
            )
                   .Init("Summoner Fire Elemental",
                new State(
                     new Orbit(0.35, 2, 20, "Summoner of Elements"),
                     new Shoot(8.4, count: 6, projectileIndex: 0, coolDown: 1675)
                    )
            )
                   .Init("Summoner Air Elemental",
                new State(
                     new Orbit(0.35, 2, 20, "Summoner of Elements"),
                     new Shoot(8.4, count: 2, shootAngle: 60, projectileIndex: 0, coolDown: 1000)
                    )
            )
        //Swag
                    .Init("Urios, God of Elements",
                new State(
                    new ScaleHP(35000),
                    new RealmPortalDrop(),
                    //new TransformOnDeath("Urios Test Chest", 1, 1, 1),
                     new DamageTakenTransition(88800, "RealRage"),
                    new State("idle",

                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new PlayerWithinTransition(6, "talktransition")
                        ),
                    new State("talktransition",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "I felt your presence already. It's not new information that you were here."),
                        new TimedTransition(6500, "talktransition2")
                        ),
                   new State("talktransition2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "Let me give you time to leave this place first."),
                        new TimedTransition(3500, "talktransition3")
                        ),
                   new State("talktransition3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "5"),
                        new TimedTransition(2500, "talktransition4")
                        ),
                  new State("talktransition4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "4"),
                        new TimedTransition(2500, "talktransition5")
                        ),
                 new State("talktransition5",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "3"),
                        new TimedTransition(2500, "talktransition6")
                        ),
                 new State("talktransition6",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "2"),
                        new TimedTransition(2500, "talktransition7")
                        ),
                 new State("talktransition7",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "1"),
                        new TimedTransition(2500, "talktransition8")
                        ),
                 new State("talktransition8",
                     new Flash(0xF1F042, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "THE POWER EMERGES WITHIN ME.  PREPARE TO BECOME ONLY ANOTHER BLOODSTAIN IN THE RUINS!"),
                        new TimedTransition(4750, "EarthTrans")
                        ),
                     new State("EarthTrans",
                       new Flash(0x008000, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4250, "EarthPhase")
                        ),
                    new State("EarthPhase",
                        new SetAltTexture(0),
                        new Taunt(1.00, "Earth. This great power is nothing compared to such weaklings."),
                        new Shoot(10, count: 5, shootAngle: 6, projectileIndex: 0, coolDown: 500, coolDownOffset: 700),
                        new Shoot(10, count: 10, projectileIndex: 0, coolDown: 1500, coolDownOffset: 2500),
                        new Grenade(2.5, 300, 7, null, coolDown: 3250),
                        new Follow(0.5, 8, 1),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(12500, "FireTrans")
                        ),
                   new State("FireTrans",
                       new Flash(0xFF0000, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4250, "FirePhase")
                        ),
                    new State("FirePhase",
                        new SetAltTexture(2),

                        new Taunt(1.00, "Fire. The flames of the inferno are sure to burn you to ashes."),
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                         new Shoot(1, 4, coolDown: 2000, fixedAngle: 100, projectileIndex: 4, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 4000, fixedAngle: 110, projectileIndex: 4, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 1750, fixedAngle: 120, projectileIndex: 4, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 800, fixedAngle: 130, projectileIndex: 4, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 3000, fixedAngle: 140, projectileIndex: 4, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 5000, fixedAngle: 150, projectileIndex: 4, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 2000, fixedAngle: 160, projectileIndex: 4, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 170, projectileIndex: 5, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(1, 4, coolDown: 10000, fixedAngle: 180, projectileIndex: 5, coolDownOffset: 1800, shootAngle: 90),
                        new TimedTransition(12500, "WaterTrans")
                        ),
                    new State("WaterTrans",
                        new Flash(0x0000FF, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4250, "WaterPhase")
                        ),
                    new State("WaterPhase",
                        new SetAltTexture(1),
                        new Taunt(1.00, "Water. Let the tidal wave hurl upon you!"),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 2, coolDown: 1400, coolDownOffset: 2500),
                        new Shoot(10, count: 4, shootAngle: 28, predictive: 4, projectileIndex: 1, coolDown: 3000),
                        new Shoot(10, count: 6, shootAngle: 28, predictive: 8, projectileIndex: 3, coolDown: 5000),
                        new Shoot(10, count: 7, shootAngle: 30, projectileIndex: 3, coolDown: 4700),
                        new Wander(0.7),
                        new TimedTransition(12500, "AirTrans")
                        ),
                   new State("AirTrans",
                       new SetAltTexture(3),
                        new Flash(0xFFFFFF, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4250, "AirPhase")
                        ),
                    new State("AirPhase",
                        new Taunt(1.00, "Air. The tornado will carry you away and rip you apart."),
                        new Prioritize(
                            new Swirl(0.55, 4),
                            new StayBack(0.5, 4)
                            ),
                        new Shoot(8.4, count: 8, predictive: 0.5, projectileIndex: 6, coolDown: 3000),
                        new Shoot(8.4, count: 1, predictive: 0.5, projectileIndex: 7, coolDown: 200),
                        new Shoot(8.4, count: 4, shootAngle: 60, projectileIndex: 7, coolDown: 2500),
                        new Shoot(8.4, count: 1, projectileIndex: 6, coolDown: 2),
                        new TimedTransition(12500, "EarthTrans")
                        ),
                    new State("RealRage",
                        new Order(5, "Shrine of Urios", "JacobIsBad"),
                        new Taunt(1.00, "The time is come...the elements are ME! THE SHRINE WILL GIVE ME POWER!"),
                        new Follow(0.8, 8, 1, coolDown: 1000),
                        new Flash(0xFF9900, 2, 2),
                        new Shoot(10, count: 2, shootAngle: 40, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 5, shootAngle: 20, predictive: 8, projectileIndex: 3, coolDown: 2600),
                        new Shoot(8.4, count: 3, predictive: 0.5, projectileIndex: 7, coolDown: 1500),
                        new Shoot(8.4, count: 1, projectileIndex: 5, coolDown: 3250),
                        new ConditionalEffect(ConditionEffectIndex.Armored)
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor2Perc()
                    ),
                new MostDamagers(3,
                    new ItemLoot("Potion of Restoration", 1.00)
                    ),
                new Threshold(0.15,
                    new TierLoot(11, ItemType.Weapon, 0.015),
                    new TierLoot(10, ItemType.Weapon, 0.02),
                    new TierLoot(13, ItemType.Armor, 0.015),
                    new TierLoot(12, ItemType.Armor, 0.02),
                    new ItemLoot("Potion of Mana", 0.8),
                    new ItemLoot("Elemental Tome", 0.01),
                    new ItemLoot("Wand of Elemental Sanctuary", 0.01),
                    new ItemLoot("Earthbound Lance", 0.01)
                )
            );

             /* .Init("Urios Test Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new MostDamagers(3,
                    new ItemLoot("Potion of Restoration", 1.00)
                    ),
                new Threshold(0.15,
                new TierLoot(11, ItemType.Weapon, 0.015),
                new TierLoot(10, ItemType.Weapon, 0.02),
                new TierLoot(13, ItemType.Armor, 0.015),
                new TierLoot(12, ItemType.Armor, 0.02),
                new ItemLoot("Potion of Mana", 0.8),
                new ItemLoot("Elemental Tome", 0.04),
                new ItemLoot("Wand of Elemental Sanctuary", 0.04),
                new ItemLoot("Earthbound Lance", 0.04)
                )
            );*/
    }
}