using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {

        private _ Drannol = () => Behav()

           .Init("BD Spirit Orb Green",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Green", 6, "die"),
                        new Prioritize(
                            new Follow(1.5, 16, 1),
                            new Wander(0.25)
                            )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
           .Init("BD Ultra Spirit Orb Green",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "activate")
                        ),
                    new State("activate",
                        new TossObject("BD Lava Bat", 4, 0, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 90, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 180, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 270, coolDown: 9999999),
                        new EntityExistsTransition("BD Lava Bat", 6, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Green", 6, "die"),
                        new Prioritize(
                            new Follow(1.5, 16, 1),
                            new Wander(0.25)
                            )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
        .Init("Bastille Sorcerer",
            new State(
                new State("Main",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new PlayerWithinTransition(6, "phasechooser")
                    ),
                new State("phasechooser",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(500, "Wanzyu", true),
                    new TimedTransition(500, "Tareg", true),
                    new TimedTransition(500, "Igaur", true),
                    new TimedTransition(500, "Nivitet", true)
                    ),
                new State("Tareg",
                    new SetAltTexture(1),
                    new Taunt("TAREG!"),
                    new Flash(0x0000FF, 1, 1),
                    new Grenade(2.5, 75, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Stunned, effectDuration: 1300, color: 0x0000FF, fixedAngle: 45),
                    new Grenade(2.5, 0, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Speedy, effectDuration: 700, color: 0x0000FF, fixedAngle: 45),
                    new Grenade(2.5, 75, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Stunned, effectDuration: 1300, color: 0x0000FF, fixedAngle: 135),
                    new Grenade(2.5, 0, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Speedy, effectDuration: 700, color: 0x0000FF, fixedAngle: 135),
                    new Grenade(2.5, 75, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Stunned, effectDuration: 1300, color: 0x0000FF, fixedAngle: 225),
                    new Grenade(2.5, 0, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Speedy, effectDuration: 700, color: 0x0000FF, fixedAngle: 225),
                    new Grenade(2.5, 75, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Stunned, effectDuration: 1300, color: 0x0000FF, fixedAngle: 315),
                    new Grenade(2.5, 0, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Speedy, effectDuration: 700, color: 0x0000FF, fixedAngle: 315),
                    new Shoot(15, count: 6, fixedAngle: 0, projectileIndex: 0, coolDown: 3000),
                    new Shoot(15, count: 6, fixedAngle: 45, projectileIndex: 0, coolDown: 3000, coolDownOffset: 200),
                    new Shoot(15, count: 6, fixedAngle: 90, projectileIndex: 0, coolDown: 3000, coolDownOffset: 400),
                    new Shoot(15, count: 6, fixedAngle: 135, projectileIndex: 0, coolDown: 3000, coolDownOffset: 600),
                    new Shoot(15, count: 6, fixedAngle: 180, projectileIndex: 0, coolDown: 3000, coolDownOffset: 800),
                    new Shoot(15, count: 6, fixedAngle: 225, projectileIndex: 0, coolDown: 3000, coolDownOffset: 1000),
                    new Shoot(15, count: 6, fixedAngle: 270, projectileIndex: 0, coolDown: 3000, coolDownOffset: 1200),
                    new Shoot(15, count: 6, fixedAngle: 315, projectileIndex: 0, coolDown: 3000, coolDownOffset: 1400),
                    new Shoot(15, count: 6, fixedAngle: 360, projectileIndex: 0, coolDown: 3000, coolDownOffset: 1600)
                        ),
                new State("Igaur",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(2),
                    new Taunt("IGAUR!"),
                    new Flash(0x00ff00, 1, 1),
                    new TimedTransition(500, "minions")
                        ),
                new State("minions",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TossObject("BD Axeman of Drannol", 3, 0, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 45, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 90, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 135, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 180, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 225, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 270, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 315, coolDown: 9999999),
                            new TimedTransition(1750, "waitforspawn")
                    ),
                new State("waitforspawn",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Flash(0x00ff00, 1, 1),
                            new EntitiesNotExistsTransition(10, "moreminions", "BD Axeman of Drannol")

                            ),
                 new State("moreminions",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TossObject("BD Lava Bat", 3, 0, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 0, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 0, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 45, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 45, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 45, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 90, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 90, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 90, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 135, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 135, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 135, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 180, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 180, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 180, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 225, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 225, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 225, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 270, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 270, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 270, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 315, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 315, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 315, coolDown: 9999999),
                            new TimedTransition(1750, "waitforspawn1")
                    ),
                new State("waitforspawn1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Flash(0x00ff00, 1, 1),
                            new EntitiesNotExistsTransition(10, "damage", "BD Lava Bat")

                            ),
                  new State("damage",
                            new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                            new Taunt("Must.. Recharge.."),
                            new TimedTransition(7000, "minions2")
                            ),
                  new State("minions2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TossObject("BD Axeman of Drannol", 3, 0, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 45, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 90, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 135, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 180, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 225, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 270, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 315, coolDown: 9999999),
                            new TimedTransition(1750, "waitforspawn2")
                    ),
                new State("waitforspawn2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Flash(0x00ff00, 1, 1),
                            new EntitiesNotExistsTransition(10, "moreminions2", "BD Axeman of Drannol")

                            ),
                  new State("moreminions2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TossObject("BD Lava Bat", 3, 0, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 0, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 0, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 45, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 45, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 45, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 90, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 90, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 90, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 135, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 135, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 135, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 180, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 180, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 180, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 225, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 225, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 225, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 270, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 270, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 270, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 3, 315, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 4, 315, coolDown: 9999999),
                            new TossObject("BD Lava Bat", 5, 315, coolDown: 9999999),
                            new TimedTransition(1750, "waitforspawn3")
                    ),
                new State("waitforspawn3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Flash(0x00ff00, 1, 1),
                            new EntitiesNotExistsTransition(10, "death", "BD Lava Bat")

                            ),
                        new State("death",
                            new Taunt("How could I run out of dark energy fighting a creature like you.."),
                            new TimedTransition(1500, "realshit")
                            ),
                        new State("realshit",
                            new Suicide()
                        ),
                new State("Nivitet",
                    new SetAltTexture(3),
                    new Taunt("NIVITET!"),
                    new Flash(0xffa500, 1, 1),
                    new TimedTransition(750, "chase")
                    ),
                    new State("chase",
                        new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 1, predictive: 1, coolDown: 3000),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new TossObject("Bd Ultra Faint Soul", 3, coolDown: 5000),
                        new TossObject("Bd Ultra Faint Soul", 3, coolDown: 5000),
                        new TossObject("Bd Ultra Faint Soul", 3, coolDown: 5000),
                        new TossObject("Bd Ultra Faint Soul", 3, coolDown: 5000),
                        new Follow(1.2, 8, 1),
                        new Charge(2, 5, 2000)
                        ),
                new State("Wanzyu",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(4),
                    new Taunt("WANZYU!"),
                    new Flash(0x551a8b, 1, 1),
                    new TossObject("Nagarith the Tormentor", 3, coolDown: 9999999),
                    new TimedTransition(5000, "nagarithcheck")
                    ),
                new State("nagarithcheck",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntitiesNotExistsTransition(30, "wanzyudeath", "Nagarith the Tormentor")

                            ),
                        new State("wanzyudeath",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Taunt("One... Last... Spell.."),
                            new TossObject("Bd Ultra Bastille Brute", 3, 90, coolDown: 9999999),
                            new TossObject("Bd Ultra Bastille Brute", 3, 270, coolDown: 9999999),
                            new TimedTransition(1500, "wanzyurealshit")
                            ),
                        new State("wanzyurealshit",
                            new Suicide()
                    )
                )
            )
        .Init("Ultra Bastille Sorcerer",
            new State(
                new State("Main",
                    new ScaleHP(10000),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new PlayerWithinTransition(6, "phasechooser")
                    ),
                new State("phasechooser",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(500, "Wanzyu", true),
                    new TimedTransition(500, "Tareg", true),
                    new TimedTransition(500, "Igaur", true),
                    new TimedTransition(500, "Nivitet", true)
                    ),
                new State("Tareg",
                    new SetAltTexture(1),
                    new Taunt("TAREG!"),
                    new Flash(0x0000FF, 1, 1),
                    new Grenade(2.5, 125, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Stunned, effectDuration: 1300, color: 0x0000FF, fixedAngle: 45),
                    new Grenade(2.5, 0, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Speedy, effectDuration: 700, color: 0x0000FF, fixedAngle: 45),
                    new Grenade(2.5, 125, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Stunned, effectDuration: 1300, color: 0x0000FF, fixedAngle: 135),
                    new Grenade(2.5, 0, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Speedy, effectDuration: 700, color: 0x0000FF, fixedAngle: 135),
                    new Grenade(2.5, 125, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Stunned, effectDuration: 1300, color: 0x0000FF, fixedAngle: 225),
                    new Grenade(2.5, 0, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Speedy, effectDuration: 700, color: 0x0000FF, fixedAngle: 225),
                    new Grenade(2.5, 125, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Stunned, effectDuration: 1300, color: 0x0000FF, fixedAngle: 315),
                    new Grenade(2.5, 0, range: 4, coolDown: 1000, effect: ConditionEffectIndex.Speedy, effectDuration: 700, color: 0x0000FF, fixedAngle: 315),
                    new Shoot(15, count: 6, fixedAngle: 0, projectileIndex: 0, coolDown: 3000),
                    new Shoot(15, count: 6, fixedAngle: 45, projectileIndex: 0, coolDown: 3000, coolDownOffset: 200),
                    new Shoot(15, count: 6, fixedAngle: 90, projectileIndex: 0, coolDown: 3000, coolDownOffset: 400),
                    new Shoot(15, count: 6, fixedAngle: 135, projectileIndex: 0, coolDown: 3000, coolDownOffset: 600),
                    new Shoot(15, count: 6, fixedAngle: 180, projectileIndex: 0, coolDown: 3000, coolDownOffset: 800),
                    new Shoot(15, count: 6, fixedAngle: 225, projectileIndex: 0, coolDown: 3000, coolDownOffset: 1000),
                    new Shoot(15, count: 6, fixedAngle: 270, projectileIndex: 0, coolDown: 3000, coolDownOffset: 1200),
                    new Shoot(15, count: 6, fixedAngle: 315, projectileIndex: 0, coolDown: 3000, coolDownOffset: 1400),
                    new Shoot(15, count: 6, fixedAngle: 360, projectileIndex: 0, coolDown: 3000, coolDownOffset: 1600)
                        ),
                new State("Igaur",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(2),
                    new Taunt("IGAUR!"),
                    new Flash(0x00ff00, 1, 1),
                    new TimedTransition(500, "minions")
                        ),
                new State("minions",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TossObject("BD Axeman of Drannol", 3, 0, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 45, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 90, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 135, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 180, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 225, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 270, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 315, coolDown: 9999999),
                            new TimedTransition(1750, "waitforspawn")
                    ),
                new State("waitforspawn",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Flash(0x00ff00, 1, 1),
                            new EntitiesNotExistsTransition(10, "moreminions", "BD Axeman of Drannol")

                            ),
                 new State("moreminions",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TossObject("BD Ultra Lava Bat", 3, 0, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 0, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 0, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 45, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 45, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 45, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 90, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 90, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 90, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 135, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 135, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 135, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 180, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 180, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 180, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 225, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 225, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 225, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 270, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 270, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 270, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 315, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 315, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 315, coolDown: 9999999),
                            new TimedTransition(1750, "waitforspawn1")
                    ),
                new State("waitforspawn1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Flash(0x00ff00, 1, 1),
                            new EntitiesNotExistsTransition(10, "damage", "BD Lava Bat")

                            ),
                  new State("damage",
                            new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                            new Taunt("Must.. Recharge.."),
                            new TimedTransition(7000, "minions2")
                            ),
                  new State("minions2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TossObject("BD Axeman of Drannol", 3, 0, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 45, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 90, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 135, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 180, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 225, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 270, coolDown: 9999999),
                            new TossObject("BD Axeman of Drannol", 3, 315, coolDown: 9999999),
                            new TimedTransition(1750, "waitforspawn2")
                    ),
                new State("waitforspawn2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Flash(0x00ff00, 1, 1),
                            new EntitiesNotExistsTransition(10, "moreminions2", "BD Axeman of Drannol")

                            ),
                  new State("moreminions2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TossObject("BD Ultra Lava Bat", 3, 0, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 0, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 0, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 45, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 45, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 45, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 90, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 90, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 90, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 135, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 135, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 135, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 180, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 180, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 180, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 225, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 225, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 225, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 270, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 270, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 270, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 3, 315, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 4, 315, coolDown: 9999999),
                            new TossObject("BD Ultra Lava Bat", 5, 315, coolDown: 9999999),
                            new TimedTransition(1750, "waitforspawn3")
                    ),
                new State("waitforspawn3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Flash(0x00ff00, 1, 1),
                            new EntitiesNotExistsTransition(10, "death", "BD Lava Bat")

                            ),
                        new State("death",
                            new Taunt("How could I run out of dark energy fighting a creature like you.."),
                            new TossObject("Bd Ultra Bastille Brute", 3, 90, coolDown: 9999999),
                            new TossObject("Bd Ultra Bastille Brute", 3, 270, coolDown: 9999999),
                            new TimedTransition(1500, "realshit")
                            ),
                        new State("realshit",
                            new Suicide()
                        ),
                new State("Nivitet",
                    new SetAltTexture(3),
                    new Taunt("NIVITET!"),
                    new Flash(0xffa500, 1, 1),
                    new TimedTransition(750, "chase")
                    ),
                    new State("chase",
                        new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 1, predictive: 1, coolDown: 3000),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new TossObject("Bd Ultra Faint Soul", 3, coolDown: 5000),
                        new TossObject("Bd Ultra Faint Soul", 3, coolDown: 5000),
                        new TossObject("Bd Ultra Faint Soul", 3, coolDown: 5000),
                        new TossObject("Bd Ultra Faint Soul", 3, coolDown: 5000),
                        new TossObject("Bd Ultra Faint Soul", 6, coolDown: 5000),
                        new TossObject("Bd Ultra Faint Soul", 6, coolDown: 5000),
                        new TossObject("Bd Ultra Faint Soul", 6, coolDown: 5000),
                        new TossObject("Bd Ultra Faint Soul", 6, coolDown: 5000),
                        new Follow(1.2, 8, 1),
                        new Charge(2, 5, 2000)
                        ),
                new State("Wanzyu",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(4),
                    new Taunt("WANZYU!"),
                    new Flash(0x551a8b, 1, 1),
                    new TossObject("Ultra Nagarith the Tormentor", 3, coolDown: 9999999),
                    new TimedTransition(5000, "nagarithcheck")
                    ),
                new State("nagarithcheck",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new EntitiesNotExistsTransition(30, "wanzyudeath", "Ultra Nagarith the Tormentor")

                            ),
                        new State("wanzyudeath",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Taunt("One... Last... Spell.."),
                            new TossObject("Bd Ultra Bastille Brute", 3, 90, coolDown: 9999999),
                            new TossObject("Bd Ultra Bastille Brute", 3, 270, coolDown: 9999999),
                            new TimedTransition(1500, "wanzyurealshit")
                            ),
                        new State("wanzyurealshit",
                            new Suicide()
                    )
                )
            )
                .Init("Nagarith the Tormentor",
            new State(
                new State("intro",
                    new Taunt("Drannol has summoned me back for a purpose... You shall not form that seal, the Eternal Beast will rise again!"),
                    new Orbit(speed: 1, radius: 5, target: "Bastille Sorcerer", orbitClockwise: true),
                    new Shoot(10, 7),
                    new TimedTransition(1000, "circleattack")
                    ),
                    new State("circleattack",
                        new Orbit(speed: 1.3, radius: 5, target: "Bastille Sorcerer", orbitClockwise: true),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 1, coolDown: 400, coolDownOffset: 750),
                        new HpLessTransition(0.5, "shotgun")
                    ),
                    new State("shotgun",
                        new Orbit(speed: 1.3, radius: 5, target: "Bastille Sorcerer", orbitClockwise: true),
                        //new Charge(3, 7, 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 1, coolDown: 400, coolDownOffset: 750),
                        //new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1, coolDown: 2000),
                        new TimedTransition(2500, "charge"),
                        new HpLessTransition(0.33, "bombcharge")
                    ),
                    new State("charge",
                        new Charge(3, 12),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1),
                        new TimedTransition(500, "shotgun"),
                        new HpLessTransition(0.33, "bombcharge")
                    ),
                    new State("bombcharge",
                        new Orbit(speed: 1.7, radius: 5, target: "Bastille Sorcerer", orbitClockwise: true),
                        new Grenade(3, 100, range: 20, coolDown: 1000, effect: ConditionEffectIndex.Slowed, effectDuration: 2000, color: 0xff0000),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 1, coolDown: 400, coolDownOffset: 750),
                        new TimedTransition(2000, "charge2")
                    ),
                    new State("charge2",
                        new Charge(3, 12),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1),
                        new TimedTransition(500, "bombcharge")

                    )
                )
            )
        .Init("Ultra Nagarith the Tormentor",
            new State(
                new State("intro",
                    new ScaleHP(15000),
                    new Taunt("Drannol has summoned me back for a purpose... You shall not form that seal, the Eternal Beast will rise again!"),
                    new Orbit(speed: 1, radius: 4, target: "Ultra Bastille Sorcerer", orbitClockwise: true),
                    new Shoot(10, 7),
                    new TimedTransition(1000, "circleattack")
                    ),
                    new State("circleattack",
                        new Orbit(speed: 1.3, radius: 4, target: "Ultra Bastille Sorcerer", orbitClockwise: true),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 1, coolDown: 400, coolDownOffset: 750),
                        new HpLessTransition(0.75, "shotgun")
                    ),
                    new State("shotgun",
                        new Orbit(speed: 1.3, radius: 4, target: "Ultra Bastille Sorcerer", orbitClockwise: true),
                        //new Charge(3, 7, 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 1, coolDown: 400, coolDownOffset: 750),
                        //new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1, coolDown: 2000),
                        new TimedTransition(2500, "charge"),
                        new HpLessTransition(0.50, "bombcharge")
                    ),
                    new State("charge",
                        new Charge(3, 12),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1),
                        new TimedTransition(500, "shotgun"),
                        new HpLessTransition(0.50, "bombcharge")
                    ),
                    new State("bombcharge",
                        new Orbit(speed: 1.7, radius: 4, target: "Ultra Bastille Sorcerer", orbitClockwise: true),
                        new Grenade(4, 100, range: 20, coolDown: 1000, effect: ConditionEffectIndex.Slowed, effectDuration: 2000, color: 0xff0000),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 1, coolDown: 400, coolDownOffset: 750),
                        new TimedTransition(2000, "charge2")
                    ),
                    new State("charge2",
                        new Charge(3, 12),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1),
                        new TimedTransition(500, "bombcharge")

                    )
                )
            )
                   .Init("BD Spirit Orb Blue",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Blue", 6, "die"),
                        new Prioritize(
                            new Follow(1.5, 6, 1),
                            new Wander(0.25)
                        )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
        .Init("BD Ultra Spirit Orb Blue",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "activate")
                        ),
                    new State("activate",
                        new TossObject("BD Lava Bat", 4, 0, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 90, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 180, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 270, coolDown: 9999999),
                        new EntityExistsTransition("BD Lava Bat", 6, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Blue", 6, "die"),
                        new Prioritize(
                            new Follow(1.5, 16, 1),
                            new Wander(0.25)
                            )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
                   .Init("BD Spirit Orb Purple",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Purple", 6, "die"),
                        new Prioritize(
                            new Follow(1.5, 6, 1),
                            new Wander(0.25)
                        )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
        .Init("BD Ultra Spirit Orb Purple",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "activate")
                        ),
                    new State("activate",
                        new TossObject("BD Lava Bat", 4, 0, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 90, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 180, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 270, coolDown: 9999999),
                        new EntityExistsTransition("BD Lava Bat", 6, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Purple", 6, "die"),
                        new Prioritize(
                            new Follow(1.5, 16, 1),
                            new Wander(0.25)
                            )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
                   .Init("BD Spirit Orb Orange",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Orange", 6, "die"),
                        new Prioritize(
                            new Follow(1.5, 6, 1),
                            new Wander(0.25)
                        )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
        .Init("BD Ultra Spirit Orb Orange",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "activate")
                        ),
                    new State("activate",
                        new TossObject("BD Lava Bat", 4, 0, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 90, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 180, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 270, coolDown: 9999999),
                        new EntityExistsTransition("BD Lava Bat", 6, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Orange", 6, "die"),
                        new Prioritize(
                            new Follow(1.5, 16, 1),
                            new Wander(0.25)
                            )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
            .Init("BD Spirit Orb Power",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new PlayerWithinTransition(1, "follow")
                        ),
                    new State("follow",
                        new EntityExistsTransition("Spiritorb Holder Default Yellow", 6, "die"),
                        new Prioritize(
                            new Follow(1.5, 6, 1),
                            new Wander(0.25)
                        )
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
            .Init("Spiritorb Holder Default Orange",
            new State(
                new TransformOnDeath("Spiritorb Holder Orange", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new EntityExistsTransition("BD Spirit Orb Orange", 6, "die"),
                        new EntityExistsTransition("BD Ultra Spirit Orb Orange", 6, "die")
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
            .Init("Spiritorb Holder Orange",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )

                    .Init("Spiritorb Holder Default Purple",
            new State(
                new TransformOnDeath("Spiritorb Holder Purple", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new EntityExistsTransition("BD Spirit Orb Purple", 6, "die"),
                        new EntityExistsTransition("BD Ultra Spirit Orb Purple", 6, "die")
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
            .Init("Spiritorb Holder Purple",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )


                .Init("BD Portal Spawner 1",
            new State(
                new DropPortalOnDeath("Hunter Cave Portal", 1, 120),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new EntitiesNotExistsTransition(9999, "activate", "Spiritorb Holder Default Purple", "Spiritorb Holder Default Green", "Spiritorb Holder Default Blue", "Spiritorb Holder Default Orange")
                    ),
                new State("activate",
                     new Suicide()
                    )
                )
            )
                .Init("BD Ultra Portal Spawner 1",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new EntitiesNotExistsTransition(9999, "activate", "Spiritorb Holder Default Purple", "Spiritorb Holder Default Green", "Spiritorb Holder Default Blue", "Spiritorb Holder Default Orange")
                    ),
                new State("activate",
                     new Spawn("Ultra Hunter Cave Portal"),
                     new Suicide()
                    )
                )
            )

        .Init("BD Lava Bat Spawner",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new PlayerWithinTransition(3, "spawn")
                    ),
                new State("spawn",
                    new Spawn("BD Lava Bat", 1, 1, coolDown: 99999),
                    new TimedTransition(20000, "idle")
                    )
                )
            )
        .Init("BD Ultra Lava Bat Spawner",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new PlayerWithinTransition(3, "spawn")
                    ),
                new State("spawn",
                    new Spawn("BD Ultra Lava Bat", 1, 1, coolDown: 99999),
                    new TimedTransition(20000, "idle")
                    )
                )
            )

            .Init("BD Tilespawner",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new PlayerWithinTransition(2, "tile1")
                    ),
                new State("tile1",
                    new ApplySetpiece("ScorchOne"),
                    new NoPlayerWithinTransition(2, "tile2")
                    ),
                new State("tile2",
                    new ApplySetpiece("LavaOne"),
                    new PlayerWithinTransition(2, "tile1")
                    )
                )
            )



                .Init("BD Puzzling Orange Deactivated",
            new State(
                new SetNoXP(),
                new TransformOnDeath("BD Puzzling Orange Activated", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new PlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
        .Init("BD Puzzling Orange Activated",
            new State(
                new SetNoXP(),
                new TransformOnDeath("BD Puzzling Orange Deactivated", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new NoPlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )


         .Init("BD Puzzling Purple Deactivated",
            new State(
                new SetNoXP(),
                new TransformOnDeath("BD Puzzling Purple Activated", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new PlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
        .Init("BD Puzzling Purple Activated",
            new State(
                new SetNoXP(),
                new TransformOnDeath("BD Puzzling Purple Deactivated", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new NoPlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )

        .Init("BD Portal Spawner 4",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new PlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )

        //30 seconds for orb spawns
            .Init("BD Taskmaster 1",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("start",
                    new EntityExistsTransition("BD Taskmaster 3", 9999, "begin")
                    ),
                new State("isorb",
                    new EntityNotExistsTransition("BD Spirit Orb Power", 9999, "begin")
                    ),
                new State("begin",
                    new Taunt(true, "A power orb spawns in 20 seconds..."),
                    new TimedTransition(20000, "abouttospawn")
                    ),
                new State("abouttospawn",
                    new Taunt(true, "A power orb spawns in 10 seconds..."),
                    new TimedTransition(10000, "spawn")
                    ),
                new State("spawn",
                     new Order(99, "BD Taskmaster 2", "first"),
                     new TimedTransition(1000, "isorb")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
        .Init("BD Ultra Taskmaster 1",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("start",
                    new EntityExistsTransition("BD Taskmaster 3", 9999, "begin")
                    ),
                new State("isorb",
                    new EntityNotExistsTransition("BD Spirit Orb Power", 9999, "begin")
                    ),
                new State("begin",
                    new Taunt(true, "A power orb spawns in 20 seconds..."),
                    new TimedTransition(20000, "abouttospawn")
                    ),
                new State("abouttospawn",
                    new Taunt(true, "A power orb spawns in 10 seconds..."),
                    new TimedTransition(10000, "spawn")
                    ),
                new State("spawn",
                     new Order(99, "BD Taskmaster 2", "first"),
                     new Order(99, "BD Taskmaster 6", "first"),
                     new TimedTransition(1000, "isorb")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
            .Init("BD Taskmaster 2",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("first",
                     new Spawn("BD Spirit Orb Power", 1, 1, coolDown: 99999),
                     new TimedTransition(1000, "idle")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )

            .Init("BD Taskmaster 4",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("first",
                     new Spawn("Flaming Summon", 1, 1, coolDown: 999999)
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
             .Init("BD Taskmaster 5",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )
        .Init("BD Taskmaster 6",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("first",
                     new Spawn("BD Ultra Bastille Brute", 1, 1, coolDown: 999999),
                     new TimedTransition(1000, "idle")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )

            .Init("BD Puzzling Blue Deactivated",
            new State(
                new SetNoXP(),
                new TransformOnDeath("BD Puzzling Blue Activated", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new PlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
        .Init("BD Puzzling Blue Activated",
            new State(
                new SetNoXP(),
                new TransformOnDeath("BD Puzzling Blue Deactivated", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new NoPlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )

                                        .Init("BD Puzzling Green Deactivated",
            new State(
                new SetNoXP(),
                new TransformOnDeath("BD Puzzling Green Activated", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new PlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )

        .Init("BD Puzzling Green Activated",
            new State(
                new SetNoXP(),
                new TransformOnDeath("BD Puzzling Green Deactivated", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new NoPlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )

         .Init("Twisted Shield",
            new State(
                new SetNoXP(),
                new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 2000),
                new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 2000),
                new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 2000),
                new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 2000),
                new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 2000),
                new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 2000),
                new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 2000),
                new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 2000),
                new Orbit(0.8, 3, 10, target: "Revil, the Twisted Vanguard"),
                new State("first",
                    new DamageTakenTransition(10000, "heal")
                    ),
                new State("heal",
                    new HealGroup(20, "Revil", coolDown: 9999, healAmount: 20000),
                    new TimedTransition(1000, "first")
                    )
                )
            )


         .Init("BD Puzzle 1 Controller",
            new State(
                new SetNoXP(),
                new RemoveObjectOnDeath("BD Wall Relic 1", 99),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("1",
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "2time")
                    ),
                new State("2time",
                     new Taunt("Mhm.", "Hmmm, seems to be right."),
                     new TimedTransition(4000, "2cooldown")
                    ),
                new State("2cooldown",
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "01"),
                     new TimedTransition(2000, "2")
                    ),
                new State("2",
                     //else
                     new Flash(0xFFFFFF, 1, 1),
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "3time")
                    ),
                new State("3time",
                     new Taunt("That's right.", "Correct."),
                     new TimedTransition(4000, "3cooldown")
                    ),
                new State("3cooldown",
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "01"),
                     new TimedTransition(2000, "3")
                    ),
                new State("3",
                     //else
                     new Flash(0xFFFFFF, 1, 1),
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "4time")
                    ),
                new State("4time",
                    new Taunt("You must know your stuff..."),
                     new TimedTransition(4000, "4cooldown")
                    ),
                new State("4cooldown",
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "01"),
                     new TimedTransition(2000, "4")
                    ),
                new State("4",
                     //else
                     new Flash(0xFFFFFF, 1, 1),
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "5")
                    ),
                new State("5",
                    new Suicide()
                    ),
                new State("0",
                     new Taunt("Something is not right here...", "That does not quite match this barrier spell, does it now?", "That can not be right...", "Mhm... No.", "Does not quite add up."),
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "2time")
                    ),
                new State("01",
                     new Taunt("Perhaps slow down.", "Patience."),
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "2time")
                    )
                )
            )


                 .Init("BD Puzzle 2 Controller",
            new State(
                new SetNoXP(),
                new RemoveObjectOnDeath("BD Wall Relic 2", 99),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("1",
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "2time")
                    ),
                new State("2time",
                     new Taunt("Mhm.", "Hmmm, seems to be right."),
                     new TimedTransition(4000, "2cooldown")
                    ),
                new State("2cooldown",
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new TimedTransition(2000, "2")
                    ),
                new State("2",
                     //else
                     new Flash(0xFFFFFF, 1, 1),
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "0"),

                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "3time")
                    ),
                new State("3time",
                     new Taunt("That's right.", "Correct."),
                     new TimedTransition(4000, "3cooldown")
                    ),
                new State("3cooldown",
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "01"),
                     new TimedTransition(2000, "3")
                    ),
                new State("3",
                    new Flash(0xFFFFFF, 1, 1),
                    new EntityExistsTransition("BD Puzzling Green Activated", 30, "4time"),
                     //else
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "0")
                    ),
                new State("4time",
                    new Taunt("You must know your stuff..."),
                     new TimedTransition(4000, "4cooldown")
                    ),
                new State("4cooldown",
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new TimedTransition(2000, "4")
                    ),
                new State("4",
                     //else
                     new Flash(0xFFFFFF, 1, 1),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "0"),

                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "5")
                    ),
                new State("5",
                    new Suicide()
                    ),
                new State("0",
                     new Taunt("Something is not right here...", "That does not quite match this barrier spell, does it now?", "That can not be right...", "Mhm... No.", "Does not quite add up."),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "2time")
                    ),
                new State("01",
                     new Taunt("Perhaps slow down.", "Patience."),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "2time")
                    )
                )
            )


                         .Init("BD Puzzle 3 Controller",
            new State(
                new SetNoXP(),
                new RemoveObjectOnDeath("BD Wall Relic 3", 99),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("1",
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "2time")
                    ),
                new State("2time",
                     new Taunt("Mhm.", "Hmmm, seems to be right."),
                     new TimedTransition(4000, "2cooldown")
                    ),
                new State("2cooldown",
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new TimedTransition(2000, "2")
                    ),
                new State("2",
                     //else
                     new Flash(0xFFFFFF, 1, 1),
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "0"),

                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "3time")
                    ),
                new State("3time",
                     new Taunt("That's right.", "Correct."),
                     new TimedTransition(4000, "3cooldown")
                    ),
                new State("3cooldown",
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "01"),
                     new TimedTransition(2000, "3")
                    ),
                new State("3",
                    new Flash(0xFFFFFF, 1, 1),
                    new EntityExistsTransition("BD Puzzling Purple Activated", 30, "4time"),
                     //else
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "0")
                    ),
                new State("4time",
                    new Taunt("You must know your stuff..."),
                     new TimedTransition(4000, "4cooldown")
                    ),
                new State("4cooldown",
                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "01"),
                     new TimedTransition(2000, "4")
                    ),
                new State("4",
                     //else
                     new Flash(0xFFFFFF, 1, 1),
                     new EntityExistsTransition("BD Puzzling Purple Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Green Activated", 30, "0"),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "0"),

                     new EntityExistsTransition("BD Puzzling Blue Activated", 30, "goodtogo")
                    ),
                new State("goodtogo",
                     new Flash(0xFFFFFF, 0.2, 5),
                     new Taunt("Very well... Goodluck on your journey.", "How far you have made it... You have passsed."),
                     new TimedTransition(4000, "die")
                    ),
                new State("die",
                     new Suicide()
                    ),
                new State("0",
                     new Taunt("Something is not right here...", "That doesn't quite match this barrier spell, does it now?", "That can not be right...", "Mhm... No.", "Does not quite add up."),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "2time")
                    ),
                new State("01",
                     new Taunt("Perhaps slow down.", "Patience."),
                     new EntityExistsTransition("BD Puzzling Orange Activated", 30, "2time")
                    )
                )
            )


            .Init("BD Logic 1",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )
                    .Init("BD Logic 2",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )
            .Init("Spiritorb Holder Default Green",
            new State(
                new TransformOnDeath("Spiritorb Holder Green", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new EntityExistsTransition("BD Spirit Orb Green", 6, "die"),
                        new EntityExistsTransition("BD Ultra Spirit Orb Green", 6, "die")
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )

            .Init("Spiritorb Holder Default Yellow",
            new State(
                new TransformOnDeath("Spiritorb Holder Yellow", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new EntityExistsTransition("BD Spirit Orb Power", 6, "die")
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )

                    .Init("DrannolTargetBurst",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("first",
                        new TimedTransition(100, "idle")
                        ),
                    new State("idle",
                        new EnemyAOE(3, false, 500, 550, true, 0xFF0000),
                        new Suicide()
                        )
                    )
                )
            )
        .Init("UltraDrannolTargetBurst",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("first",
                        new TimedTransition(100, "idle")
                        ),
                    new State("idle",
                        new EnemyAOE(3, false, 1000, 1050, true, 0xFF0000),
                        new Suicide()
                        )
                    )
                )
            )
               .Init("DrannolTarget",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Seek",
                      new Sequence(
                            new Timed(3000,
                                new Prioritize(
                                    new Follow(1.6, 8, 1),
                                    new Wander(0.7)
                                    )),
                            new Timed(2000,
                                new Prioritize(
                                    new Charge(3, 6, coolDown: 1000),
                                    new Swirl(1, 4, targeted: false)
                                    )),
                            new Timed(3000,
                                new Prioritize(
                                    new Orbit(1, 3),
                                    new Wander(0.8)
                                    )
                                )
                            ),
                        new TimedTransition(12000, "Countdown"),
                        new PlayerWithinTransition(1, "Countdown")
                        ),
                    new State("Countdown",
                        new SetAltTexture(1),
                        new TimedTransition(400, "Blam")
                        ),
                   new State("Blam",
                        new Spawn("DrannolTargetBurst", 1, 1, coolDown: 1000),
                        new Suicide()
                        )
                  )
            )
        .Init("UltraDrannolTarget",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Seek",
                      new Sequence(
                            new Timed(3000,
                                new Prioritize(
                                    new Follow(1.6, 8, 1),
                                    new Wander(0.7)
                                    )),
                            new Timed(2000,
                                new Prioritize(
                                    new Charge(3, 6, coolDown: 1000),
                                    new Swirl(1, 4, targeted: false)
                                    )),
                            new Timed(3000,
                                new Prioritize(
                                    new Orbit(1, 3),
                                    new Wander(0.8)
                                    )
                                )
                            ),
                        new TimedTransition(12000, "Countdown"),
                        new PlayerWithinTransition(1, "Countdown")
                        ),
                    new State("Countdown",
                        new SetAltTexture(1),
                        new TimedTransition(400, "Blam")
                        ),
                   new State("Blam",
                        new Spawn("UltraDrannolTargetBurst", 1, 1, coolDown: 1000),
                        new Suicide()
                        )
                  )
            )

            .Init("Spiritorb Holder Yellow",
            new State(
                new TransformOnDeath("Spiritorb Holder Default Yellow", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new TimedTransition(24000, "die")
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )
            .Init("Spiritorb Holder Green",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )


            .Init("Spiritorb Holder Default Blue",
            new State(
                new TransformOnDeath("Spiritorb Holder Blue", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle",
                        new EntityExistsTransition("BD Spirit Orb Blue", 6, "die"),
                        new EntityExistsTransition("BD Ultra Spirit Orb Blue", 6, "die")
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )

            .Init("Torch of the Hunter B",
            new State(
                new TransformOnDeath("Torch of the Hunter A", 1, 1, 1),
                new State("Main",
                    new State("idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntityExistsTransition("BD Logic 1", 999, "vuln")
                        ),
                    new State("vuln",
                        new HealSelf(coolDown: 5000)
                        )
                    )
                )
            )
                        .Init("Torch of the Hunter A",
            new State(
                new TransformOnDeath("Torch of the Hunter B", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Main",
                    new State("idle"
                        ),
                    new State("die",
                        new Suicide()
                        )
                    )
                )
            )

            .Init("Spiritorb Holder Blue",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )
            .Init("Scorching Wrath Helper Anchor",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )
        .Init("Ultra Scorching Wrath Helper Anchor",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
            )

            .Init("BD Warrior of Drannol",
            new State(
                new State("Main",
                    new Shoot(10, count: 1, projectileIndex: 2, predictive: 1, coolDown: 1000),
                    new HpLessTransition(0.15, "heal"),
                    new State("fight1",
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 0, predictive: 0.5, coolDown: 400),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 8, projectileIndex: 1, coolDown: 1600),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 800),
                        new TimedTransition(4000, "fight1")
                        )
                    ),
                    new State("heal",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new HealSelf(coolDown: 1000, amount: 2500),
                        new Wander(0.25),
                        new Shoot(10, count: 6, shootAngle: 8, projectileIndex: 1, predictive: 0.5, coolDown: 1000),
                        new TimedTransition(2000, "run")
                        ),
                    new State("run",
                    new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 0, coolDown: 400, shootLowHp: true)
                        )
                )
            )
            .Init("Scorching Crawler",
            new State(
                new State("Main",
                    new Flash(0xFF0000, 0.25, 4),
                    new State("fight1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Sequence(
                            new Timed(2200,
                                new Prioritize(
                                    new Wander(2)
                                    )),
                            new Timed(4000,
                                new Prioritize(
                                    new Charge(2, 6, coolDown: 1150),
                                    new Follow(0.6, 20, 1)
                                    )),
                            new Timed(4000,
                                new Prioritize(
                                    new Follow(0.4, 20, 1),
                                    new Wander(0.25)
                                    )
                                )
                            ),
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 0, predictive: 0.5, coolDown: 3000, coolDownOffset: 2400),
                        new EntityExistsTransition("Spiritorb Holder Yellow", 99, "fight2")
                        ),
                    new State("fight2",
                    new Prioritize(
                        new Follow(0.6, 20, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 0, predictive: 0.5, coolDown: 3000, coolDownOffset: 2400),
                        new EntityNotExistsTransition("Spiritorb Holder Yellow", 99, "fight1")
                        )
                    )
                )
            )
        .Init("Ultra Scorching Crawler",
            new State(
                new State("Main",
                    new Flash(0xFF0000, 0.25, 4),
                    new State("fight1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Sequence(
                            new Timed(2200,
                                new Prioritize(
                                    new Wander(2)
                                    )),
                            new Timed(4000,
                                new Prioritize(
                                    new Charge(2, 6, coolDown: 1150),
                                    new Follow(0.6, 20, 1)
                                    )),
                            new Timed(4000,
                                new Prioritize(
                                    new Follow(0.4, 20, 1),
                                    new Wander(0.25)
                                    )
                                )
                            ),
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 0, predictive: 0.5, coolDown: 3000, coolDownOffset: 2400),
                        new EntityExistsTransition("Spiritorb Holder Yellow", 99, "fight2")
                        ),
                    new State("fight2",
                    new Prioritize(
                        new Follow(0.6, 20, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 0, predictive: 0.5, coolDown: 3000, coolDownOffset: 2400),
                        new EntityNotExistsTransition("Spiritorb Holder Yellow", 99, "fight1")
                        )
                    )
                )
            )
                    .Init("BD Twisted Sentry",
            new State(
                new State("Main",
                    new State("idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(3, "charging")
                        ),
                    new State("charging",
                        new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ChangeSize(60, 150),
                        new TimedTransition(2000, "shoot")
                        ),
                    new State("shoot",
                        new HealSelf(coolDown: 4000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 2000),
                        new Shoot(10, count: 6, shootAngle: 20, projectileIndex: 0, coolDown: 900)
                        )
                    )
                )
            )

            .Init("BD Twisted Sentry Treasure",
            new State(
                new State("Main",
                    new State("idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(3, "charging")
                        ),
                    new State("charging",
                        new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                       new ChangeSize(60, 150),
                        new TimedTransition(2000, "shoot")
                        ),
                    new State("shoot",
                        new HealSelf(coolDown: 4000),
                        new Shoot(10, count: 5, shootAngle: 20, projectileIndex: 0, coolDown: 1000)
                        )
                    )
                ),
                    new Threshold(0.1,
                       new ItemLoot("Onrane Cache", 0.025),
                       new ItemLoot("Onrane", 0.045),
                       new ItemLoot("1000 Gold", 0.05),
                       new ItemLoot("Vial of Life", 0.5),
                       new ItemLoot("Vial of Speed", 0.5)
                       )
            )
            .Init("BD Axeman of Drannol",
            new State(
                new State("Main",
                    new State("fight1",
                    new Prioritize(
                        new Follow(0.75, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 2, shootAngle: 4, projectileIndex: 0, coolDown: 800),
                        new DamageTakenTransition(1000, "fight2")
                        ),
                    new State("fight2",
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 3, shootAngle: 4, projectileIndex: 0, coolDown: 200),
                        new TimedTransition(2000, "fight3")
                        ),
                    new State("fight3",
                        new Wander(0.1),
                        new Shoot(10, count: 6, projectileIndex: 1, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 4, projectileIndex: 0, coolDown: 100),
                        new TimedTransition(2000, "fight2")
                        )
                    )
                )
            )
                    .Init("BD Lava Bat",
            new State(
                new State("Main",
                    new State("fight1",
                    new Prioritize(
                        new Follow(1, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 0, coolDown: new Cooldown(800, 2000), coolDownOffset: 1400)
                        )
                    )
                )
            )
                       .Init("BD Ultra Lava Bat",
            new State(
                new State("Main",
                    new State("fight1",
                    new Prioritize(
                        new Follow(1, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 0, coolDown: new Cooldown(800, 2000), coolDownOffset: 00)
                        )
                    )
                )
            )
            .Init("Scorching Fanatic",
            new State(
                new State("Main",
                    new Taunt(0.25, "Aragah..", "Oogith..", "Blagaha!"),
                    new State("fight1",
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.25)
                        ),
                        new PlayerWithinTransition(2, "blowup")
                        ),
                  new State("blowup",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Shoot(10, count: 6, projectileIndex: 0, coolDown: 9999),
                    new Suicide()
                        )
                    )
                )
            )
            .Init("Ultra Scorching Fanatic",
            new State(
                new State("Main",
                    new Taunt(0.25, "Aragah..", "Oogith..", "Blagaha!"),
                    new State("fight1",
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.25)
                        ),
                        new PlayerWithinTransition(2, "blowup")
                        ),
                  new State("blowup",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Shoot(10, count: 6, projectileIndex: 0, coolDown: 9999),
                    new Suicide()
                        )
                    )
                )
            )
                .Init("Bastille Trap",
            new State(
                new SetNoXP(),
                  new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State(
                    new PlayerWithinTransition(1, "blowup")
                    ),
                new State("blowup",
                    new ApplySetpiece("BastilleLava"),
                    new Suicide()
                    )
                )
            )
                .Init("BerikaoFlood",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("spawn",
                    new ApplySetpiece("BastilleLava")
                    )
                )
            )

        .Init("BerikaoFlood1",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("spawn",
                    new ApplySetpiece("BastilleLava")
                )
            )
        )
        .Init("BerikaoFlood2",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("spawn",
                    new ApplySetpiece("BastilleLava")
                    ),
                new State("revert",
                    new ApplySetpiece("BastilleFloor")
                )
            )
        )
        .Init("BerikaoFlood3",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("spawn",
                    new ApplySetpiece("BastilleLava")
                    ),
                new State("revert",
                    new ApplySetpiece("BastilleFloor")
                )
            )
         )
        .Init("BerikaoPath",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("spawn",
                    new ReplaceTile("Black Lava", "BD Hunter Den Floor", 1)
                    )
                )
            )
            .Init("BD Bastille Brute",
            new State(
                new State("Main",
                    new HpLessTransition(0.15, "run"),
                    new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 1, predictive: 1, coolDown: 3000),
                    new State("fight1",
                        new Wander(0.1),
                        new Shoot(10, count: 4, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, coolDown: 1000, coolDownOffset: 800),
                        new TimedTransition(4000, "warning")
                        ),
                    new State("warning",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(0.50, "Graaagh!"),
                        new Flash(0xFF0000, 0.5, 2),
                        new TimedTransition(1400, "charge")
                        ),
                    new State("charge",
                        new Charge(2, range: 10, coolDown: 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new PlayerWithinTransition(4, "leave")
                        ),
                    new State("leave",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Prioritize(
                        new StayBack(0.8, 6),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 14, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(3000, "run")
                        ),
                     new State("run",
                     new Prioritize(
                        new Follow(1.2, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 4, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, coolDown: 1000, coolDownOffset: 800),
                        new TimedTransition(4000, "warning2")
                        ),
                     new State("warning2",
                     new Prioritize(
                        new Follow(1.2, 8, 1),
                        new Wander(0.25)
                        ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(0.50, "Graaagh!"),
                        new Flash(0xFF0000, 0.5, 2),
                        new TimedTransition(1400, "charge2")
                        ),
                     new State("charge2",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Charge(2, range: 10, coolDown: 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new PlayerWithinTransition(4, "fight1")
                        )
                    ),
                    new State("run",
                        new Flash(0xFFFFFF, 0.25, 4),
                        new Taunt("GRAAAAGH!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 6),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HealSelf(coolDown: 9999, amount: 8000),
                     new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 3, coolDown: 1000),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 2, predictive: 1, coolDown: 2000, coolDownOffset: 400)
                        )
                )
            )
        .Init("BD Ultra Bastille Brute",
            new State(
                new State("Main",
                    new HpLessTransition(0.15, "run"),
                    new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 1, predictive: 1, coolDown: 3000),
                    new State("fight1",
                        new Wander(0.1),
                        new Shoot(10, count: 4, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, coolDown: 1000, coolDownOffset: 800),
                        new TimedTransition(4000, "warning")
                        ),
                    new State("warning",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(0.50, "Graaagh!"),
                        new Flash(0xFF0000, 0.5, 2),
                        new TimedTransition(1400, "charge")
                        ),
                    new State("charge",
                        new Charge(2, range: 10, coolDown: 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new PlayerWithinTransition(4, "leave")
                        ),
                    new State("leave",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                    new Prioritize(
                        new StayBack(0.8, 6),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 14, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(3000, "run")
                        ),
                     new State("run",
                     new Prioritize(
                        new Follow(1.2, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 4, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, predictive: 0.5, coolDown: 1000, coolDownOffset: 400),
                        new Shoot(10, count: 2, shootAngle: 10, projectileIndex: 0, coolDown: 1000, coolDownOffset: 800),
                        new TimedTransition(4000, "warning2")
                        ),
                     new State("warning2",
                     new Prioritize(
                        new Follow(1.2, 8, 1),
                        new Wander(0.25)
                        ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(0.50, "Graaagh!"),
                        new Flash(0xFF0000, 0.5, 2),
                        new TimedTransition(1400, "charge2")
                        ),
                     new State("charge2",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Charge(2, range: 10, coolDown: 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, predictive: 0.5, coolDown: 1000),
                        new PlayerWithinTransition(4, "fight1")
                        )
                    ),
                    new State("run",
                        new Flash(0xFFFFFF, 0.25, 4),
                        new Taunt("GRAAAAGH!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 6),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HealSelf(coolDown: 9999, amount: 8000),
                     new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 3, coolDown: 1000),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 2, predictive: 1, coolDown: 2000, coolDownOffset: 400)
                        )
                )
            )
                    .Init("BD Lava Drake",
            new State(
                        new Prioritize(
                            new Orbit(0.7, 3, target: "BD Winged Beast"),
                            new Follow(0.5, 8, 1)
                            ),
                new State("Main",
                        new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 800),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Wander(0.5),
                        new Shoot(10, count: 8, projectileIndex: 2, coolDown: 1000),
                        new Shoot(10, count: 2, shootAngle: 16, projectileIndex: 0, coolDown: 800),
                        new TimedTransition(4000, "Main")
                        )
                    )
            )




                .Init("Flaming Summon",
                new State(
                    new ChangeSize(60, 100),
                    new Shoot(10, count: 12, projectileIndex: 2, coolDown: 4000),
                    new Grenade(4, 140, range: 8, coolDown: 2000, effect: ConditionEffectIndex.Bleeding, effectDuration: 3000, color: 0xFFFF00),
                    new Prioritize(
                          new Orbit(0.7, 3, target: "Drannol, the Eternal Beast", speedVariance: 0.05),
						  new Orbit(0.7, 3, target: "Ultra Drannol, the Eternal Beast", speedVariance: 0.05),
                          new Follow(0.5, 8, 1)
                   ),
                new State("Main",
                        new Shoot(10, count: 1, projectileIndex: 1, predictive: 1, coolDown: 4000),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 0, coolDown: 3000, angleOffset: 40),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 0, coolDown: 3000, angleOffset: 320),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 3, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 7, projectileIndex: 0, coolDown: 3000),
                        new TimedTransition(2000, "Main")
                        )
                    )
                )










                .Init("BD Winged Beast",
            new State(
                new State("Main",
                    new HpLessTransition(0.15, "rage"),
                    new State("fight1",
                        new Wander(0.1),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 8, projectileIndex: 1, coolDown: 1000, coolDownOffset: 1000),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Follow(0.8, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, count: 10, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(2000, "fight2b")
                        ),
                    new State("fight2b",
                        new Prioritize(
                            new Follow(0.8, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 3, shootAngle: 20, projectileIndex: 2, coolDown: 2000, coolDownOffset: 1000),
                        new Shoot(10, count: 6, projectileIndex: 2, coolDown: 2000, predictive: 1),
                        new TimedTransition(4000, "fight3")
                        ),
                    new State("fight3",
                        new Swirl(1, 3, 10),
                        new Shoot(10, count: 7, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 4, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(4000, "fight1")
                        )
                    ),
                   new State("rage",
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Follow(1.3, 8, 1),
                        new Shoot(10, count: 4, shootAngle: 6, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(3000, "rage2")
                        ),
                  new State("rage2",
                        new Shoot(10, count: 5, shootAngle: 6, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(2000, "rage")
                        )
                  )
            )
            .Init("BD Lava Golem",
            new State(
                new State("Main",
                    new State("fight1",
                        new Wander(0.1),
                        new Shoot(10, count: 6, shootAngle: 20, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 3, shootAngle: 40, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new BackAndForth(0.5, 3),
                        new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 2000),
                        new TimedTransition(4000, "fight3")
                        ),
                    new State("fight3",
                        new Prioritize(
                            new Follow(0.6, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 8, shootAngle: 20, projectileIndex: 0, coolDown: 3000),
                        new Shoot(10, count: 3, shootAngle: 40, projectileIndex: 1, coolDown: 1000),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            )
            .Init("BD Inferno Mage",
            new State(
                new State("Main",
                    new State("fight1",
                        new Prioritize(
                            new Follow(0.5, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 4, shootAngle: 18, projectileIndex: 0, coolDown: 1400),
                        new Shoot(10, count: 2, shootAngle: 30, projectileIndex: 0, coolDown: 1400, coolDownOffset: 600),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Wander(0.5),
                        new Shoot(10, count: 5, shootAngle: 18, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(4000, "fight3")
                        ),
                    new State("fight3",
                        new Prioritize(
                            new Follow(0.5, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 6, shootAngle: 24, projectileIndex: 0, coolDown: 1800),
                        new Shoot(10, count: 5, projectileIndex: 1, coolDown: 600),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            )
            .Init("BD Bastille Defender",
            new State(
                new State("Main",
                    new State("fight1",
                        new Orbit(0.5, 3, 10),
                        new Shoot(10, count: 2, shootAngle: 9, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 6, shootAngle: 12, projectileIndex: 1, coolDown: 3000),
                        new Grenade(4, 140, range: 8, coolDown: 1000),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                        new Wander(0.1),
                        new Shoot(10, count: 4, shootAngle: 9, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 800, coolDownOffset: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 800, coolDownOffset: 800),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 800, coolDownOffset: 1200),
                        new TimedTransition(4000, "fight3")
                        ),
                   new State("fight3",
                        new Prioritize(
                            new Follow(0.8, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 5, shootAngle: 20, projectileIndex: 2, coolDown: 2000),
                        new Grenade(1, 350, range: 8, coolDown: 4000),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            )
            .Init("BD Lava Fanatic",
            new State(
                new State("Main",
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(1, 8, 1),
                        new Wander(0.4)
                        ),
                    new State("fight1",
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 400),
                        new DamageTakenTransition(2000, "fight2")
                        ),
                    new State("fight2",
                        new ChangeSize(1, 140),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 1, coolDown: 400),
                        new DamageTakenTransition(2000, "fight3")
                        ),
                    new State("fight3",
                        new Shoot(10, count: 2, fixedAngle: 0, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 2, fixedAngle: 90, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 2, fixedAngle: 180, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 2, fixedAngle: 270, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new ChangeSize(1, 150),
                        new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 400)
                        )
                    )
                )
            )
            .Init("BD Ultra Lava Fanatic",
            new State(
                new State("Main",
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(1, 8, 1),
                        new Wander(0.4)
                        ),
                    new State("fight1",
                        new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 400),
                        new DamageTakenTransition(2000, "fight2")
                        ),
                    new State("fight2",
                        new ChangeSize(1, 140),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 1, coolDown: 400),
                        new DamageTakenTransition(2000, "fight3")
                        ),
                    new State("fight3",
                        new Shoot(10, count: 2, fixedAngle: 0, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 2, fixedAngle: 90, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 2, fixedAngle: 180, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new Shoot(10, count: 2, fixedAngle: 270, shootAngle: 20, projectileIndex: 3, coolDown: 2000),
                        new ChangeSize(1, 150),
                        new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 400)
                        )
                    )
                )
            )
            .Init("BD Inferno Brawler",
                new State(
                    new Prioritize(
                        new Follow(0.4, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 400),
                    new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 1, coolDown: 1200)
                    ),
                new Threshold(0.5,
                    new ItemLoot("Ravenheart Sword", 0.01),
                    new ItemLoot("Ring of Greater Dexterity", 0.01),
                    new ItemLoot("Golden Quiver", 0.01)
                    )
            )
            .Init("BD Inferno Assassin",
                new State(
                    new Prioritize(
                        new Follow(0.4, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 0, coolDown: 600)
                    ),
                new Threshold(0.5,
                    new ItemLoot("Ravenheart Sword", 0.01),
                    new ItemLoot("Staff of Diabolic Secrets", 0.01),
                    new ItemLoot("Golden Quiver", 0.01)
                    )
            )
            .Init("BD Faint Soul",
                new State(
                    new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 100)
                    )
            )
           .Init("BD Ultra Faint Soul",
                new State(
                    new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(10, count: 1, projectileIndex: 0, coolDown: 100)
                    )
            )
            /*.Init("BD Stone Urgle",
            new State(
                new State("Main",
                    new State("fight1",
                        new Shoot(10, count: 4, shootAngle: 18, projectileIndex: 0, coolDown: 1400),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Shoot(10, count: 5, shootAngle: 18, projectileIndex: 2, coolDown: 1000),
                        new TimedTransition(4000, "fight3")
                        ),
                    new State("fight3",
                        new Shoot(10, count: 6, shootAngle: 24, projectileIndex: 0, coolDown: 1800),
                        new Shoot(10, count: 5, projectileIndex: 1, coolDown: 600),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            )*/

            .Init("BD Stone Orb",
            new State(
                new TransformOnDeath("BD Faint Soul", 1, 6),
                new State("Main",
                    new EntitiesNotExistsTransition(6, "die", "BD Stone Urgle"),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("fight1",
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(3200, "fight2")
                        ),
                    new State("fight2",
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(2000, "fight1")
                        )
                    ),
                    new State("die",
                        new Flash(0xFF0000, 1, 2),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 800),
                        new Suicide()
                        )
                )
            )
            .Init("BD Ultra Stone Orb",
            new State(
                new TransformOnDeath("BD Ultra Faint Soul", 1, 6),
                new State("Main",
                    new EntitiesNotExistsTransition(6, "die", "BD Ultra Stone Urgle"),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("fight1",
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(3200, "fight2")
                        ),
                    new State("fight2",
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 400),
                        new EntitiesNotExistsTransition(4, "die", "BD Ultra Stone Urgle"),
                        new TimedTransition(2000, "fight1")
                        )
                    ),
                    new State("die",
                        new Flash(0xFF0000, 1, 2),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 800),
                        new Suicide()
                        )
                )
            )
            .Init("BD Stone Urgle",
            new State(
                new Prioritize(
                        new StayCloseToSpawn(0.8, 3),
                        new Wander(0.5)
                        ),
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new State("idle",
                        new PlayerWithinTransition(8, "begin")
                        ),
                new State("begin",
                        new TossObject("BD Stone Orb", 6, 0, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 45, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 90, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 135, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 180, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 225, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 270, coolDown: 9999999),
                        new TossObject("BD Stone Orb", 6, 315, coolDown: 9999999),
                        new TimedTransition(4000, "Main")
                    )
                ),
                new State("Main",
                    new Grenade(6, 200, range: 10, coolDown: 4000),
                    new State("fight1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "fight2")
                        ),
                    new State("fight2",
                        new TimedTransition(1000, "fight1")
                        )
                    )
                )
            )
            .Init("BD Ultra Stone Urgle",
            new State(
                new Prioritize(
                        new StayCloseToSpawn(0.8, 3),
                        new Wander(0.5)
                        ),
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new State("idle",
                        new PlayerWithinTransition(8, "begin")
                        ),
                new State("begin",
                        new TossObject("BD Ultra Stone Orb", 6, 0, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 45, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 90, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 135, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 180, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 225, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 270, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 315, coolDown: 9999999),
                        new TimedTransition(4000, "Main")
                        ),
                    new State("orbsv2",
                        new TossObject("BD Ultra Stone Orb", 6, 0, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 45, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 90, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 135, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 180, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 225, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 270, coolDown: 9999999),
                        new TossObject("BD Ultra Stone Orb", 6, 315, coolDown: 9999999),
                        new TimedTransition(4000, "Main2")
                    )
                ),
                new State("Main",
                    new Grenade(6, 200, range: 10, coolDown: 3000),
                    new State("fight1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "fight2"),
                        new EntitiesNotExistsTransition(6, "orbsv2", "BD Ultra Stone Orb")
                        ),
                    new State("fight2",
                        new TimedTransition(1000, "fight1")
                        )
                    ),
                new State("Main2",
                    new Grenade(6, 200, range: 10, coolDown: 3000),
                    new State("1fight1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "1fight2")
                        ),
                    new State("1fight2",
                        new TimedTransition(1000, "1fight1")
                        )
                    )
                )
            )

                      /*      .Init("BD Berikao, the Dark Hunter HUNTING",
                        new State(
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new State(
                            new State("waiting"
                                ),
                            new State("probing1",
                                new MoveTo(speed: 0.6f, x: 43, y: 42),
                                new TimedTransition(4000, "probing2")
                                ),
                            new State("probing2",
                                new MoveTo(speed: 0.6f, x: 41, y: 5),
                                new TimedTransition(4000, "probing3")
                                ),
                            new State("probing3",
                                new MoveTo(speed: 0.6f, x: 4, y: 5),
                                new TimedTransition(4000, "probing4")
                                ),
                            new State("probing4",
                                new MoveTo(speed: 0.6f, x: 5, y: 44),
                                new TimedTransition(4000, "probing1")
                             ),
                           new State("Reveal",
                                new Flash(0xFF0000, 0.25, 4),
                                new Taunt(0.75, "You are mine.."),
                                new SetAltTexture(0, 1, 10, true),
                                new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1000),
                                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                new TimedTransition(2000, "jump")
                                ),
                           new State("jump",
                                new SetAltTexture(1),
                                new Charge(2.2, range: 14, coolDown: 1000),
                                new Shoot(10, count: 10, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                                new TimedTransition(1600, "Unreveal")
                                ),
                           new State("Unreveal",
                                new SetAltTexture(0, 1, 10, true),
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new TimedTransition(2000, "runback")
                                ),
                           new State("runback",
                                new SetAltTexture(0),
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new ReturnToSpawn(8),
                                new TimedTransition(7000, "probing1")
                                ),
                           new State("runbackwait",
                                new SetAltTexture(0),
                                new ConditionalEffect(ConditionEffectIndex.Invincible),
                                new ReturnToSpawn(8)
                                )
                           )
                         )
                    )*/


                      .Init("BD Berikao, the Dark Hunter HUNTING 1",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetNoXP(),
                    new State(
                        new PlayerWithinTransition(4, "Reveal"),
                    new State("probing1",
                        new MoveTo(speed: 0.8f, x: 43, y: 43),
                        new TimedTransition(9000, "probing2")
                        ),
                    new State("probing2",
                        new MoveTo(speed: 0.8f, x: 44, y: 4),
                        new TimedTransition(9000, "probing3")
                        ),
                    new State("probing3",
                        new MoveTo(speed: 0.8f, x: 4, y: 3),
                        new TimedTransition(9000, "probing4")
                        ),
                    new State("probing4",
                        new MoveTo(speed: 0.8f, x: 4, y: 45),
                        new TimedTransition(9000, "probing1")
                            )
                        ),
                    new State("Reveal",
                        new Follow(0.6, 8, 1),
                        new Flash(0xFF0000, 0.25, 4),
                        new Taunt(0.75, "You are mine...", "Right... where... I want you...", "There you are..."),
                        new SetAltTexture(0, 1, 10, true),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 3000),
                        new Shoot(10, count: 1, projectileIndex: 1, predictive: 0.5, coolDown: 3000, coolDownOffset: 1500),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3800, "jump")
                        ),
                   new State("jump",
                       new Taunt(0.75, "Heheheh...", "Bloodshed is so... gorgeous..."),
                        new SetAltTexture(1),
                        new Charge(7, range: 16, coolDown: 1000),
                        new Shoot(10, count: 8, shootAngle: 8, projectileIndex: 0, coolDown: 200),
                        new TimedTransition(3200, "Unreveal")
                        ),
                   new State("Unreveal",
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2000, "die")
                        ),
                   new State("die",
                        new Suicide()
                        )
                )
            )
        .Init("BD Ultra Berikao, the Dark Hunter HUNTING 1",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetNoXP(),
                    new State(
                        new PlayerWithinTransition(4, "Reveal"),
                    new State("probing1",
                        new MoveTo(speed: 0.8f, x: 43, y: 43),
                        new TimedTransition(4500, "probing2")
                        ),
                    new State("probing2",
                        new MoveTo(speed: 0.8f, x: 44, y: 4),
                        new TimedTransition(4500, "probing3")
                        ),
                    new State("probing3",
                        new MoveTo(speed: 0.8f, x: 4, y: 3),
                        new TimedTransition(4500, "probing4")
                        ),
                    new State("probing4",
                        new MoveTo(speed: 0.8f, x: 4, y: 45),
                        new TimedTransition(4500, "probing1")
                            )
                        ),
                    new State("Reveal",
                        new Follow(0.6, 8, 1),
                        new Flash(0xFF0000, 0.25, 4),
                        new Taunt(0.75, "You are mine...", "Right... where... I want you...", "There you are..."),
                        new SetAltTexture(0, 1, 10, true),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 3000),
                        new Shoot(10, count: 1, projectileIndex: 1, predictive: 0.5, coolDown: 3000, coolDownOffset: 1500),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2400, "jump")
                        ),
                   new State("jump",
                       new Taunt(0.75, "Heheheh...", "Bloodshed is so... gorgeous..."),
                        new SetAltTexture(1),
                        new Charge(7, range: 16, coolDown: 1000),
                        new Shoot(10, count: 10, shootAngle: 8, projectileIndex: 0, coolDown: 200),
                        new TimedTransition(3200, "Unreveal")
                        ),
                   new State("Unreveal",
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2000, "die")
                        ),
                   new State("die",
                        new Suicide()
                        )
                )
            )
              .Init("Twisted Axe",
                new State(
                    new SetNoXP(),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("Seek",
                        new PlayerWithinTransition(3, "Die"),
                    new State("Seek1",
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
                        new TimedTransition(5000, "Seek2")
                        ),
                    new State("Seek2",
                        new Orbit(1.5, 6, 10, "Revil, the Twisted Vanguard"),
                        new TimedTransition(5000, "Seek1")
                        )
                    ),
                    new State("Die",
                        new Prioritize(
                            new Follow(1.5, 10, 2),
                            new Wander(1)
                            ),
                        new Shoot(10, count: 14, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(4000, "Seek1")
                        )
                  )
            )

            .Init("BD Tookytesttask2",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                    new EntityExistsTransition("BD Logic 1", 90, "pick")
                    ),
                new State("removeandwait",
                    new RemoveEntity(999, "BD Berikao, the Dark Hunter HUNTING 1"),
                    new RemoveEntity(999, "BD Berikao, the Dark Hunter HUNTING 2"),
                    new TimedTransition(4000, "idle")
                    ),
                new State(
                    new EntityExistsTransition("BD Logic 2", 90, "removeandwait"),
                new State("pick",
                    new TimedRandomTransition(4000, false, "spawn1", "spawn2")
                    ),
                new State("spawn1",
                    new Spawn("BD Berikao, the Dark Hunter HUNTING 1", 1, 1, coolDown: 99999),
                    new TimedTransition(4000, "spawn1B")
                    ),
                new State("spawn1B",
                    new EntitiesNotExistsTransition(999, "pick", "BD Berikao, the Dark Hunter HUNTING 1")
                    ),
                new State("spawn2",
                    new Spawn("BD Berikao, the Dark Hunter HUNTING 2", 1, 1, coolDown: 99999),
                    new TimedTransition(4000, "spawn2B")
                    ),
                new State("spawn2B",
                    new EntitiesNotExistsTransition(999, "pick", "BD Berikao, the Dark Hunter HUNTING 2")
                        )
                    )
                )
            )
        .Init("BD Ultra Tookytesttask2",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                    new EntityExistsTransition("BD Logic 1", 90, "pick")
                    ),
                new State("removeandwait",
                    new RemoveEntity(999, "BD Ultra Berikao, the Dark Hunter HUNTING 1"),
                    new RemoveEntity(999, "BD Ultra Berikao, the Dark Hunter HUNTING 2"),
                    new TimedTransition(4000, "idle")
                    ),
                new State(
                    new EntityExistsTransition("BD Logic 2", 90, "removeandwait"),
                new State("pick",
                    new TimedRandomTransition(4000, false, "spawn1", "spawn2")
                    ),
                new State("spawn1",
                    new Spawn("BD Ultra Berikao, the Dark Hunter HUNTING 1", 1, 1, coolDown: 99999),
                    new TimedTransition(4000, "spawn1B")
                    ),
                new State("spawn1B",
                    new EntitiesNotExistsTransition(999, "pick", "BD Ultra Berikao, the Dark Hunter HUNTING 1")
                    ),
                new State("spawn2",
                    new Spawn("BD Ultra Berikao, the Dark Hunter HUNTING 2", 1, 1, coolDown: 99999),
                    new TimedTransition(4000, "spawn2B")
                    ),
                new State("spawn2B",
                    new EntitiesNotExistsTransition(999, "pick", "BD Ultra Berikao, the Dark Hunter HUNTING 2")
                        )
                    )
                )
            )

                              .Init("BD Berikao, the Dark Hunter HUNTING 2",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetNoXP(),
                    new State(
                        new PlayerWithinTransition(4, "Reveal"),
                    new State("probing1",
                        new MoveTo(speed: 0.8f, x: 4, y: 45),
                        new TimedTransition(9000, "probing2")
                            ),
                    new State("probing2",
                        new MoveTo(speed: 0.8f, x: 4, y: 3),
                        new TimedTransition(9000, "probing3")
                        ),
                    new State("probing3",
                        new MoveTo(speed: 0.8f, x: 44, y: 4),
                        new TimedTransition(9000, "probing4")
                        ),
                    new State("probing4",
                        new MoveTo(speed: 0.8f, x: 43, y: 43),
                        new TimedTransition(9000, "probing1")
                        )
                    ),
                    new State("Reveal",
                        new Follow(0.6, 8, 1),
                        new Flash(0xFF0000, 0.25, 4),
                        new Taunt(0.75, "You are mine...", "Right... where... I want you...", "There you are..."),
                        new SetAltTexture(0, 1, 10, true),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 3000),
                        new Shoot(10, count: 1, projectileIndex: 1, predictive: 0.5, coolDown: 3000, coolDownOffset: 1500),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3800, "jump")
                        ),
                   new State("jump",
                       new Taunt(0.75, "Heheheh...", "Bloodshed is so... gorgeous..."),
                        new SetAltTexture(1),
                        new Charge(7, range: 16, coolDown: 1000),
                        new Shoot(10, count: 10, shootAngle: 12, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(3200, "Unreveal")
                        ),
                   new State("Unreveal",
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2000, "die")
                        ),
                   new State("die",
                        new Suicide()
                        )
                )
            )
        .Init("BD Ultra Berikao, the Dark Hunter HUNTING 2",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetNoXP(),
                    new State(
                        new PlayerWithinTransition(4, "Reveal"),
                    new State("probing1",
                        new MoveTo(speed: 0.8f, x: 4, y: 45),
                        new TimedTransition(4500, "probing2")
                            ),
                    new State("probing2",
                        new MoveTo(speed: 0.8f, x: 4, y: 3),
                        new TimedTransition(4500, "probing3")
                        ),
                    new State("probing3",
                        new MoveTo(speed: 0.8f, x: 44, y: 4),
                        new TimedTransition(4500, "probing4")
                        ),
                    new State("probing4",
                        new MoveTo(speed: 0.8f, x: 43, y: 43),
                        new TimedTransition(4500, "probing1")
                        )
                    ),
                    new State("Reveal",
                        new Follow(0.6, 8, 1),
                        new Flash(0xFF0000, 0.25, 4),
                        new Taunt(0.75, "You are mine...", "Right... where... I want you...", "There you are..."),
                        new SetAltTexture(0, 1, 10, true),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 3000),
                        new Shoot(10, count: 1, projectileIndex: 1, predictive: 0.5, coolDown: 3000, coolDownOffset: 1500),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2400, "jump")
                        ),
                   new State("jump",
                       new Taunt(0.75, "Heheheh...", "Bloodshed is so... gorgeous..."),
                        new SetAltTexture(1),
                        new Charge(7, range: 16, coolDown: 1000),
                        new Shoot(10, count: 8, shootAngle: 8, projectileIndex: 0, coolDown: 200),
                        new TimedTransition(3200, "Unreveal")
                        ),
                   new State("Unreveal",
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2000, "die")
                        ),
                   new State("die",
                        new Suicide()
                        )
                )
            )

                .Init("Revil, the Twisted Vanguard",
                new State(
                    new ScaleHP(35000),
                    new DropPortalOnDeath("The Steps Portal", 1, 120),
                    new ChangeMusicOnDeath("oldcity"),
                    new State("default",
                        new BackAndForth(0.3, 6),
                        new DamageTakenTransition(60000, "huh")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("huh",
                        new Taunt("Centuries... I have resided here waiting for a friendly challenge..."),
                        new TimedTransition(4000, "taunt1")
                        ),
                    new State("taunt1",
                        new Taunt("But it seems you have a more... malicious intent dealing with me."),
                        new TimedTransition(4000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt("I haven't fought for so long...", "My courage has not failed me for centuries... Let us hope it does not fail me now."),
                        new TimedTransition(4000, "taunt3")
                        ),
                    new State("taunt3",
                        new SetAltTexture(1),
                        new HealSelf(coolDown: 9999, amount: 80000),
                        new Taunt("Very Well.", "Let us begin."),
                        new BackAndForth(0.2, 3),
                        new Flash(0xFF0000, 0.5, 2),
                        new TimedTransition(4000, "top")
                        )
                    ),
                    new State(
                        new HpLessTransition(0.2, "suicide"),
                    new State("top",
                        new Taunt("WANZYU."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(3000, "chaseWanzyu")
                        ),
                    new State("chaseWanzyu",
                        new Flash(0xFF00FF, 0.5, 6),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Follow(1.2, 10, 2),
                            new Wander(1)
                            ),
                        new Shoot(10, 4, projectileIndex: 2, shootAngle: 6, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 4, shootAngle: 6, coolDown: 4000),
                        new EntityExistsTransition("BD Puzzling Purple Activated", 999, "returntop")
                        ),
                    new State("returntop",
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "fight1")
                        ),
                    new State("fight1",
                        new Grenade(3, 500, range: 3, coolDown: 1000),
                        new TimedTransition(14000, "return1"),
                    new State("fight1a",
                       new Prioritize(
                            new Follow(0.5, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, 4, projectileIndex: 3, shootAngle: 12, coolDown: 1000),
                        new TimedTransition(1000, "fight1b")
                        ),
                    new State("fight1b",
                        new Prioritize(
                            new Follow(0.5, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, 8, projectileIndex: 3, shootAngle: 12, coolDown: 1000),
                        new TimedTransition(1000, "fight1c")
                        ),
                    new State("fight1c",
                        new Prioritize(
                            new Follow(1.8, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new TimedTransition(4000, "fightblast")
                        ),
                     new State("fightblast",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 99999),
                        new TimedTransition(4000, "delay")
                        ),
                     new State("delay",
                        new Taunt(0.10, "Just like old times..."),
                        new TimedTransition(4000, "fight1a")
                        )
                    ),
                    new State("return1",
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 3, projectileIndex: 0, coolDown: 800),
                        new Taunt(0.25, "Farewell, challenger..."),
                        new Grenade(4, 120, range: 5, coolDown: 4000),
                        new TimedTransition(14000, "yell"),
                        new Shoot(10, count: 7, shootAngle: 10, projectileIndex: 1, predictive: 0.1, coolDown: 99999),
                        new State("fight2a",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 0, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "fight2b")
                            ),
                        new State("fight2b",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 40, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "fight2c")
                            ),
                        new State("fight2c",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 80, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "fight2d")
                            ),
                        new State("fight2d",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 120, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "fight2e")
                            ),
                        new State("fight2e",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 160, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "fight2f")
                            ),
                        new State("fight2f",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 200, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "fight2g")
                            ),
                        new State("fight2g",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 240, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "fight2h")
                            ),
                       new State("fight2h",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 280, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "fight2i")
                            ),
                       new State("fight2i",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 320, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "fight2j")
                            ),
                       new State("fight2j",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 360, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "fight2a")
                            )
                        ),
                    new State("yell",
                        new Taunt("TAREG."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "chasetareg")
                        ),
                    new State("chasetareg",
                        new Flash(0x0000FF, 0.5, 6),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Follow(1.2, 10, 2),
                            new Wander(1)
                            ),
                        new Shoot(10, 4, projectileIndex: 2, shootAngle: 6, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 4, shootAngle: 6, coolDown: 4000),
                        new EntityExistsTransition("BD Puzzling Blue Activated", 999, "return2")
                        ),
                    new State("return2",
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "fight3")
                        ),
                    new State("fight3",
                        new Shoot(10, count: 4, shootAngle: 6, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 1, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, count: 8, shootAngle: 6, projectileIndex: 0, coolDown: 2000, coolDownOffset: 1500),
                        new Orbit(0.6, 5, 10),
                        new Taunt(0.10, "Let's see how you HANDLE this... Heheh..."),
                        new TossObject("Twisted Axe", range: 8, coolDown: 99999),
                        new SetAltTexture(2),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(24000, "yell2")
                        ),
                    new State("yell2",
                        new SetAltTexture(1),
                        new RemoveEntity(999, "Twisted Axe"),
                        new Taunt("IGAUR."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "chaseIgaur")
                        ),
                    new State("chaseIgaur",
                        new Flash(0x00FF00, 0.5, 6),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Follow(1.2, 10, 2),
                            new Wander(1)
                            ),
                        new Shoot(10, 4, projectileIndex: 2, shootAngle: 6, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 4, shootAngle: 6, coolDown: 4000),
                        new EntityExistsTransition("BD Puzzling Green Activated", 999, "return3")
                        ),
                     new State("return3",
                        new Taunt(0.1, "You put up a fight... I didn't expect this..."),
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "fight4")
                        ),
                    new State("fight4",
                        new Prioritize(
                            new Charge(1, 10, coolDown: 3000),
                            new Orbit(0.4, 5)
                            ),
                        new SetAltTexture(0),
                        new TossObject("Twisted Shield", range: 4, angle: 90, coolDown: 99999),
                        new TossObject("Twisted Axe", range: 4, angle: 90, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 3, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 3, fixedAngle: 180, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 1, shootAngle: 14, coolDown: 4000),
                        new TimedTransition(20000, "yell3")
                        ),
                    new State("yell3",
                        new SetAltTexture(1),
                        new RemoveEntity(999, "Twisted Axe"),
                        new RemoveEntity(999, "Twisted Shield"),
                        new Taunt("NIVITET."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "chaseNivitet")
                        ),
                    new State("chaseNivitet",
                        new Flash(0xFFA500, 0.5, 6),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Follow(1.2, 10, 2),
                            new Wander(1)
                            ),
                        new Shoot(10, 4, projectileIndex: 2, shootAngle: 6, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 4, shootAngle: 6, coolDown: 4000),
                        new EntityExistsTransition("BD Puzzling Orange Activated", 999, "done")
                        ),
                    new State("done",
                        new Wander(0.1),
                        new TossObject("BD Winged Beast", 8, coolDown: 2000),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 2, shootAngle: 8, projectileIndex: 3, coolDown: 400),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(6000, "top")
                        ),
                    new State(
                    new State("suicide",
                        new ChangeMusic("oldcity"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new RemoveEntity(999, "Twisted Axe"),
                        new RemoveEntity(999, "Twisted Shield"),
                        new Flash(0xFFFFFF, 1, 2),
                        new Taunt("I... underestimated... you...", "Heheh... Haven't had a battle like this in a while... Thank you..."),
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedRandomTransition(8000, false, "rip", "getit")
                            ),
                    new State("rip",
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 99999),
                        new Suicide()
                            )
                            )
                          ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("getit",
                        new Taunt("I see what must be done...", "This battle has took long enough... You have truly finished me off..."),
                        new TimedTransition(6000, "getit2")
                            ),
                    new State("getit2",
                        new ChangeSize(20, 180),
                        new Taunt("This was my fault... I am sorry...", "Didn't want it to come to this... Lin... Please...", "I didn't want to cause any harm... But you pushed me to my limits..."),
                        new TimedTransition(6000, "getit3")
                            ),
                    new State("getit3",
                        new Flash(0xFF0000, 0.2, 8),
                        new HealSelf(coolDown: 3000, amount: 1750000),
                        new ChangeMusic("vanguarddying"),
                        new ChangeSize(60, 190),
                        new Taunt("I will show no mercy..."),
                        new TimedTransition(6000, "bfight1")
                        )
                      ),
                     new State(
                        new HpLessTransition(0.2, "reallydie"),
                    new State("bfight1",
                        new Grenade(3, 500, range: 3, coolDown: 1000),
                        new TimedTransition(14000, "breturn1"),
                    new State("bfight1a",
                       new Prioritize(
                            new Follow(0.7, acquireRange: 80, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, 4, projectileIndex: 3, shootAngle: 12, coolDown: 1000),
                        new TimedTransition(1000, "bfight1b")
                        ),
                    new State("bfight1b",
                        new Prioritize(
                            new Follow(0.5, acquireRange: 80, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, 8, projectileIndex: 3, shootAngle: 12, coolDown: 1000),
                        new TimedTransition(1000, "bfight1c")
                        ),
                    new State("bfight1c",
                        new Prioritize(
                            new Follow(1.8, acquireRange: 80, range: 8),
                            new Wander(1)
                            ),
                        new TimedTransition(4000, "bfightblast")
                        ),
                     new State("bfightblast",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 99999),
                        new TimedTransition(4000, "bdelay")
                        ),
                     new State("bdelay",
                        new Taunt(0.10, "Just like old times..."),
                        new TimedTransition(4000, "bfight1a")
                        )
                    ),
                    new State("breturn1",
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "bfight2")
                        ),
                    new State("bfight2",
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 3, projectileIndex: 0, coolDown: 800),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 8000),
                        new Taunt(0.25, "Farewell, challenger..."),
                        new Prioritize(
                            new Charge(2, 10, coolDown: 3000),
                            new Follow(0.6, acquireRange: 80, range: 8),
                            new Wander(1)
                            ),
                        new Grenade(4, 120, range: 5, coolDown: 4000),
                        new TimedTransition(14000, "byell"),
                        new Shoot(10, count: 7, shootAngle: 10, projectileIndex: 1, predictive: 0.1, coolDown: 99999),
                        new State("bfight2a",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 0, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2b")
                            ),
                        new State("bfight2b",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 40, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2c")
                            ),
                        new State("bfight2c",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 80, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2d")
                            ),
                        new State("bfight2d",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 120, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2e")
                            ),
                        new State("bfight2e",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 160, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2f")
                            ),
                        new State("bfight2f",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 200, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2g")
                            ),
                        new State("bfight2g",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 240, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2h")
                            ),
                       new State("bfight2h",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 280, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2i")
                            ),
                       new State("bfight2i",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 320, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2j")
                            ),
                       new State("bfight2j",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 360, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2a")
                            )
                        ),
                    new State("byell",
                        new Taunt("TAREG AH WAZYU!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "bchasetareg")
                        ),
                    new State("bchasetareg",
                        new Flash(0xFFFFFF, 0.5, 6),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Follow(1.2, 80, 2),
                            new Wander(1)
                            ),
                        new Shoot(10, 10, projectileIndex: 2, shootAngle: 6, coolDown: 1000),
                        new Shoot(10, 16, projectileIndex: 4, coolDown: 4000),
                        new EntitiesNotExistsTransition(999, "breturn2", "BD Puzzling Purple Deactivated", "BD Puzzling Blue Deactivated")
                        ),
                    new State("breturn2",
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "bfight3")
                        ),
                    new State("bfight3",
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 8, shootAngle: 6, projectileIndex: 1, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, count: 12, shootAngle: 6, projectileIndex: 0, coolDown: 2000, coolDownOffset: 1500),

                        new Taunt(0.10, "FOR LIN!"),
                        new Prioritize(
                            new Orbit(1, 3, 10),
                            new Follow(1.2, 80, 2),
                            new Wander(1)
                            ),
                        new TossObject("Twisted Axe", range: 8, angle: 90, coolDown: 99999),
                        new TossObject("Twisted Axe", range: 8, angle: 270, coolDown: 99999),
                        new SetAltTexture(2),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(22000, "byell2")
                        ),
                    new State("byell2",
                        new SetAltTexture(1),
                        new RemoveEntity(999, "Twisted Axe"),
                        new Taunt("IGAUR AH NIVITET!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "bchaseIgaur")
                        ),
                    new State("bchaseIgaur",
                        new Flash(0xFFFFFF, 0.5, 6),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Follow(1.2, 80, 2),
                            new Wander(1)
                            ),
                        new Shoot(10, 10, projectileIndex: 2, shootAngle: 6, coolDown: 1000),
                        new Shoot(10, 16, projectileIndex: 4, coolDown: 4000),
                        new EntitiesNotExistsTransition(999, "breturn3", "BD Puzzling Green Deactivated", "BD Puzzling Orange Deactivated")
                        ),
                     new State("breturn3",
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "bfight4")
                        ),
                    new State("bfight4",
                        new SetAltTexture(0),
                        new Prioritize(
                            new Charge(1, 10, coolDown: 3000),
                            new Follow(1.2, 80, 2),
                            new Orbit(0.4, 5)
                            ),
                        new TossObject("Twisted Shield", range: 4, angle: 90, coolDown: 99999),
                        new TossObject("Twisted Shield", range: 4, angle: 270, coolDown: 99999),
                        new TossObject("Twisted Axe", range: 4, angle: 90, coolDown: 99999),
                        new TossObject("Twisted Axe", range: 4, angle: 270, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 3, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 3, fixedAngle: 180, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 1, shootAngle: 14, coolDown: 4000),
                        new TimedTransition(20000, "byell3")
                        ),
                    new State("byell3",
                        new SetAltTexture(1),
                        new RemoveEntity(999, "Twisted Axe"),
                        new RemoveEntity(999, "Twisted Shield"),
                        new Taunt("AAARGH!."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "bfight1")
                                 )
                            ),
                 new State(
                    new State("reallydie",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new RemoveEntity(999, "Twisted Axe"),
                        new RemoveEntity(999, "Twisted Shield"),
                        new Flash(0xFFFFFF, 1, 2),
                        new Taunt("Noooo... I failed her..."),
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "dedo")
                            ),
                    new State("dedo",
                        new Spawn("BD Portal Spawner 2", givesNoXp: true),
                        new TransferDamageOnDeath("BD Portal Spawner 2"),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 99999),
                        new Suicide()
                            )
                        )
                    )
            )
        .Init("Ultra Revil, the Twisted Vanguard",
                new State(
                    new ScaleHP(125000),
                    new DropPortalOnDeath("Ultra The Steps", 1, 120),
                    new ChangeMusicOnDeath("oldcity"),
                    new State("default",
                        new BackAndForth(0.3, 6),
                        new DamageTakenTransition(60000, "getit")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("getit",
                        new Taunt("You will not reach Lin, we have been sealed off for centuries, but she knows I stand guard."),
                        new TimedTransition(6000, "getit2")
                            ),
                    new State("getit2",
                        new ChangeSize(20, 180),
                        new Taunt("I didn't want to cause any harm... But I'll do what needs to be done to keep her safe."),
                        new TimedTransition(6000, "getit3")
                            ),
                    new State("getit3",
                        new Flash(0xFF0000, 0.2, 8),
                        new ChangeMusic("vanguarddying"),
                        new ChangeSize(60, 190),
                        new Taunt("I will show no mercy..."),
                        new TimedTransition(6000, "bfight1")
                        )
                      ),
                     new State(
                        new HpLessTransition(0.2, "reallydie"),
                    new State("bfight1",
                        new Grenade(3, 500, range: 3, coolDown: 1000),
                        new TimedTransition(14000, "breturn1"),
                    new State("bfight1a",
                       new Prioritize(
                            new Follow(0.7, acquireRange: 80, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, 4, projectileIndex: 3, shootAngle: 12, coolDown: 1000),
                        new TimedTransition(1000, "bfight1b")
                        ),
                    new State("bfight1b",
                        new Prioritize(
                            new Follow(0.5, acquireRange: 80, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, 8, projectileIndex: 3, shootAngle: 12, coolDown: 1000),
                        new TimedTransition(1000, "bfight1c")
                        ),
                    new State("bfight1c",
                        new Prioritize(
                            new Follow(1.8, acquireRange: 80, range: 8),
                            new Wander(1)
                            ),
                        new TimedTransition(4000, "bfightblast")
                        ),
                     new State("bfightblast",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 99999),
                        new TimedTransition(4000, "bdelay")
                        ),
                     new State("bdelay",
                        new Taunt(0.10, "Just like old times..."),
                        new TimedTransition(4000, "bfight1a")
                        )
                    ),
                    new State("breturn1",
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "bfight2")
                        ),
                    new State("bfight2",
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 3, projectileIndex: 0, coolDown: 800),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable, duration: 8000),
                        new Taunt(0.25, "Farewell, challenger..."),
                        new Prioritize(
                            new Charge(2, 10, coolDown: 3000),
                            new Follow(0.6, acquireRange: 80, range: 8),
                            new Wander(1)
                            ),
                        new Grenade(4, 120, range: 5, coolDown: 4000),
                        new TimedTransition(14000, "byell"),
                        new Shoot(10, count: 7, shootAngle: 10, projectileIndex: 1, predictive: 0.1, coolDown: 99999),
                        new State("bfight2a",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 0, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2b")
                            ),
                        new State("bfight2b",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 40, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2c")
                            ),
                        new State("bfight2c",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 80, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2d")
                            ),
                        new State("bfight2d",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 120, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2e")
                            ),
                        new State("bfight2e",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 160, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2f")
                            ),
                        new State("bfight2f",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 200, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2g")
                            ),
                        new State("bfight2g",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 240, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2h")
                            ),
                       new State("bfight2h",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 280, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2i")
                            ),
                       new State("bfight2i",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 320, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2j")
                            ),
                       new State("bfight2j",
                            new Shoot(10, count: 3, shootAngle: 4, fixedAngle: 360, projectileIndex: 3, coolDown: 99999),
                            new TimedTransition(400, "bfight2a")
                            )
                        ),
                    new State("byell",
                        new Taunt("TAREG AH WAZYU!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "bchasetareg")
                        ),
                    new State("bchasetareg",
                        new Flash(0xFFFFFF, 0.5, 6),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Follow(1.2, 80, 2),
                            new Wander(1)
                            ),
                        new Shoot(10, 10, projectileIndex: 2, shootAngle: 6, coolDown: 1000),
                        new Shoot(10, 16, projectileIndex: 4, coolDown: 4000),
                        new EntitiesNotExistsTransition(999, "breturn2", "BD Puzzling Purple Deactivated", "BD Puzzling Blue Deactivated")
                        ),
                    new State("breturn2",
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "bfight3")
                        ),
                    new State("bfight3",
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 8, shootAngle: 6, projectileIndex: 1, coolDown: 2000, coolDownOffset: 400),
                        new Shoot(10, count: 12, shootAngle: 6, projectileIndex: 0, coolDown: 2000, coolDownOffset: 1500),

                        new Taunt(0.10, "FOR LIN!"),
                        new Prioritize(
                            new Orbit(1, 3, 10),
                            new Follow(1.2, 80, 2),
                            new Wander(1)
                            ),
                        new TossObject("Twisted Axe", range: 8, angle: 90, coolDown: 99999),
                        new TossObject("Twisted Axe", range: 8, angle: 270, coolDown: 99999),
                        new TossObject("Twisted Axe", range: 28, angle: 0, coolDown: 99999),
                        new SetAltTexture(2),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(22000, "byell2")
                        ),
                    new State("byell2",
                        new SetAltTexture(1),
                        new RemoveEntity(999, "Twisted Axe"),
                        new Taunt("IGAUR AH NIVITET!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "bchaseIgaur")
                        ),
                    new State("bchaseIgaur",
                        new Flash(0xFFFFFF, 0.5, 6),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new Follow(1.2, 80, 2),
                            new Wander(1)
                            ),
                        new Shoot(10, 10, projectileIndex: 2, shootAngle: 6, coolDown: 1000),
                        new Shoot(10, 16, projectileIndex: 4, coolDown: 4000),
                        new EntitiesNotExistsTransition(999, "breturn3", "BD Puzzling Green Deactivated", "BD Puzzling Orange Deactivated")
                        ),
                     new State("breturn3",
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "bfight4")
                        ),
                    new State("bfight4",
                        new SetAltTexture(0),
                        new Prioritize(
                            new Charge(1, 10, coolDown: 3000),
                            new Follow(1.2, 80, 2),
                            new Orbit(0.4, 5)
                            ),
                        new TossObject("Twisted Shield", range: 4, angle: 90, coolDown: 99999),
                        new TossObject("Twisted Shield", range: 4, angle: 270, coolDown: 99999),
                        new TossObject("Twisted Axe", range: 4, angle: 90, coolDown: 99999),
                        new TossObject("Twisted Axe", range: 4, angle: 270, coolDown: 99999),
                        new TossObject("Twisted Axe", range: 28, angle: 0, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 3, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 3, fixedAngle: 180, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 1, shootAngle: 14, coolDown: 4000),
                        new TimedTransition(20000, "byell3")
                        ),
                    new State("byell3",
                        new SetAltTexture(1),
                        new RemoveEntity(999, "Twisted Axe"),
                        new RemoveEntity(999, "Twisted Shield"),
                        new Taunt("AAARGH!."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "bfight1")
                                 )
                            ),
                 new State(
                    new State("reallydie",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new RemoveEntity(999, "Twisted Axe"),
                        new RemoveEntity(999, "Twisted Shield"),
                        new Flash(0xFFFFFF, 1, 2),
                        new Taunt("Noooo... I failed her..."),
                        new ReturnToSpawn(2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "dedo")
                            ),
                    new State("dedo",
                        new Spawn("BD Ultra Portal Spawner 2", givesNoXp: true),
                        new TransferDamageOnDeath("BD Ultra Portal Spawner 2"),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 2, coolDown: 99999),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 2, coolDown: 99999),
                        new Suicide()
                            )
                        )
                    )
            )

                .Init("BD Portal Spawner 2",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Idle",
                        new EntityNotExistsTransition("Revil, the Twisted Vanguard", 50, "Loot")
                        ),
                    new State("Loot",
                        new Suicide()
                        )
                ),
                new MostDamagers(3,
                    LootTemplates.NFabledItemsLoots2B()
                ),
                new Threshold(0.1,
                    new TierLoot(7, ItemType.Ring, 0.0033),
                    new ItemLoot("Sor Fragment Cache", 0.02),
                    new ItemLoot("Onrane Cache", 0.3),
                    new ItemLoot("Vial of Protection", 0.4),
                    new ItemLoot("Vial of Defense", 0.4),
                    new ItemLoot("Vial of Attack", 0.4),
                    new ItemLoot("Vial of Might", 0.4),
                    new ItemLoot("Vial of Vitality", 0.4),
                    new ItemLoot("Vial of Luck", 0.4),
                    new ItemLoot("Vial of Mana", 0.4)
                )
            )
        .Init("BD Ultra Portal Spawner 2",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Idle",
                        new EntityNotExistsTransition("Ultra Revil, the Twisted Vanguard", 50, "Loot")
                        ),
                    new State("Loot",
                        new Suicide()
                        )
                ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLoots2B()
                ),
                new Threshold(0.1,
                    new TierLoot(7, ItemType.Ring, 0.0033),
                    new ItemLoot("Sor Fragment Cache", 0.03),
                    new ItemLoot("Onrane Cache", 0.33),
                    new ItemLoot("Vial of Protection", 0.4),
                    new ItemLoot("Vial of Defense", 0.4),
                    new ItemLoot("Vial of Attack", 0.4),
                    new ItemLoot("Vial of Might", 0.4),
                    new ItemLoot("Vial of Vitality", 0.4),
                    new ItemLoot("Vial of Luck", 0.4),
                    new ItemLoot("Vial of Mana", 0.4)
                )
            )
            .Init("BD Berikao, the Dark Hunter",
                new State(
                    new ScaleHP(35000),
                    new DropPortalOnDeath("Twisted Trials Portal", 1, 120),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(8, "taunt1")
                        ),
                    new State("taunt1",
                        new Taunt("The shadows are what I thrive in..", "Get used to the darkness..for it will be your forever once I am through with you."),
                        new TimedTransition(2000, "taunt2")
                        ),
                    new State("taunt2",
                        new SetAltTexture(0, 1, 10, true),
                        new Taunt("Just let me get adjusted here..."),
                        new TimedTransition(4000, "taunt3")
                        ),
                    new State("taunt3",
                        new SetAltTexture(1),
                        new Taunt("Ah, yes..now where were we?"),
                        new TimedTransition(2000, "fight1")
                        )
                     ),
                    new State(
                        new DamageTakenTransition(400000, "Bshadows"),
                    new State("fight1",
                        new RemoveEntity(60, "BD Logic 2"),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new TossObject("BD Bastille Brute", range: 10, coolDown: 6000, probability: 0.75),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "fight1a")
                        ),
                     new State("fight1a",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "fight1b")
                        ),
                     new State("fight1b",
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Swirl(0.5, 2),
                        new Shoot(10, count: 7, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 14, projectileIndex: 2, predictive: 0.5, coolDown: 1000),
                        new TimedTransition(5000, "fight2a")
                        ),
                    new State("fight2a",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 400),

                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 0, projectileIndex: 1, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),
                        new TimedTransition(8000, "fight2b")
                        ),
                    new State("fight2b",
                        new Follow(0.4, 8, 1),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 400),

                        new Shoot(10, count: 7, shootAngle: 18, fixedAngle: 0, projectileIndex: 0, coolDown: 1000, coolDownOffset: 500),
                        new TimedTransition(8000, "phase")
                        ),
                    new State("phase",
                        new HealSelf(coolDown: 1000, amount: 40000),
                        new Taunt("Run, fools. You can't stand a chance in the darkness."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "phase2")
                        ),
                    new State("phase2",
                        new SetAltTexture(0, 1, 10, true),
                        new TimedTransition(4000, "phase3")
                        ),
                    new State("phase3",
                        new Prioritize(
                            new Follow(1.5),
                            new Wander(0.1)
                            ),
                        new SetAltTexture(0),
                        new PlayerWithinTransition(3, "phase2", seeInvis: true)
                        ),
                    new State("phase2",
                        new Taunt(0.75, "I see you, fool..your legacy ends here."),
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "jump")
                        ),
                    new State("jump",
                        new SetAltTexture(1),
                        new Charge(2, range: 10, coolDown: 4000),
                        new Shoot(10, count: 22, projectileIndex: 0, coolDown: 4000),
                        new PlayerWithinTransition(1, "runback")
                        ),
                    new State("runback",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "fight3")
                        ),
                    new State("fight3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 3, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "fight4")
                        ),
                    new State("fight4",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 4, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "shadows")
                     ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("shadows",
                        new HealSelf(coolDown: 9999, amount: 60000),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, -1),
                        new SetAltTexture(0, 1, 10, true),
                        new Taunt("Let the fun begin...", "LIGHTS OFF!"),
                        new ReturnToSpawn(2),
                        new TimedTransition(5000, "shadowswait")
                        ),
                    new State("shadowswait",
                        new SetAltTexture(0),
                        new Spawn("BD Logic 1", 1, 1, coolDown: 99999),
                        new EntitiesNotExistsTransition(9999, "shadowswait2", "Torch of the Hunter B")
                        ),
                    new State("shadowswait2",
                        new SetAltTexture(1),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, 0),
                        new RemoveEntity(60, "BD Logic 1"),
                        new Spawn("BD Logic 2", 1, 1, coolDown: 99999),
                        new Order(999, "Torch of the Hunter A", "die"),
                        new TimedTransition(4000, "fight1")
                                )
                            )
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Bshadows",
                        new HealSelf(coolDown: 9999, amount: 250000),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, -1),
                        new SetAltTexture(0, 1, 10, true),
                        new Taunt("More SLAUGHTER!", "and the Death Begins..."),
                        new ReturnToSpawn(2),
                        new TimedTransition(5000, "Bshadowswait")
                        ),
                    new State("Bshadowswait",
                        new SetAltTexture(0),
                        new Spawn("BD Logic 1", 1, 1, coolDown: 99999),
                        new EntitiesNotExistsTransition(9999, "Bshadowswait2", "Torch of the Hunter B")
                        ),
                    new State("Bshadowswait2",
                        new SetAltTexture(1),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, 0),
                        new RemoveEntity(60, "BD Logic 1"),
                        new Spawn("BD Logic 2", 1, 1, coolDown: 99999),
                        new Order(999, "Torch of the Hunter A", "die"),
                        new TimedTransition(4000, "Bfight1")
                            )
                        ),
                    new State(
                        new DamageTakenTransition(750000, "Cshadows"),
                    new State("Bfight1",
                        new RemoveEntity(60, "BD Logic 2"),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new TossObject("BD Bastille Brute", range: 10, coolDown: 6000, probability: 0.75),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Bfight1a")
                        ),
                     new State("Bfight1a",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Bfight1b")
                        ),
                     new State("Bfight1b",
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Bfight2")
                        ),
                    new State("Bfight2",
                        new Swirl(0.5, 2),
                        new Shoot(10, count: 7, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 14, projectileIndex: 2, predictive: 0.5, coolDown: 1000),
                        new TimedTransition(5000, "Bfight2a")
                        ),
                    new State("Bfight2a",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 400),

                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 0, projectileIndex: 1, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),
                        new TimedTransition(8000, "Bfight2b")
                        ),
                    new State("Bfight2b",
                        new Follow(0.4, 8, 1),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 400),

                        new Shoot(10, count: 7, shootAngle: 18, fixedAngle: 0, projectileIndex: 0, coolDown: 1000, coolDownOffset: 500),
                        new TimedTransition(8000, "Bphase")
                        ),
                    new State("Bphase",
                        new HealSelf(coolDown: 1000, amount: 40000),
                        new Taunt("Run, fools. You can't stand a chance in the darkness."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "Bphase2")
                        ),
                    new State("Bphase2",
                        new SetAltTexture(0, 1, 10, true),
                        new TimedTransition(4000, "Bphase3")
                        ),
                    new State("Bphase3",
                        new Prioritize(
                            new Follow(1.5),
                            new Wander(0.1)
                            ),
                        new SetAltTexture(0),
                        new PlayerWithinTransition(3, "Bphase2", seeInvis: true)
                        ),
                    new State("Bphase2",
                        new Taunt(0.75, "I see you, fool..your legacy ends here."),
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "Bjump")
                        ),
                    new State("Bjump",
                        new SetAltTexture(1),
                        new Charge(2, range: 10, coolDown: 4000),
                        new Shoot(10, count: 22, projectileIndex: 0, coolDown: 4000),
                        new PlayerWithinTransition(1, "Brunback")
                        ),
                    new State("Brunback",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "Bfight3")
                        ),
                    new State("Bfight3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 3, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "Bfight4")
                        ),
                    new State("Bfight4",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 4, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "Bshadows")
                        )
                     ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Cshadows",
                        new HealSelf(coolDown: 9999, amount: 10000),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, -1),
                        new SetAltTexture(0, 1, 10, true),
                        new Taunt("One last hunt..."),
                        new ReturnToSpawn(2),
                        new TimedTransition(5000, "Cshadowswait")
                        ),
                    new State("Cshadowswait",
                        new SetAltTexture(0),
                        new Spawn("BD Logic 1", 1, 1, coolDown: 99999),
                        new EntitiesNotExistsTransition(9999, "Cshadowswait2", "Torch of the Hunter B")
                        ),
                    new State("Cshadowswait2",
                        new SetAltTexture(1),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, 0),
                        new RemoveEntity(60, "BD Logic 1"),
                        new Spawn("BD Logic 2", 1, 1, coolDown: 99999),
                        new Order(999, "Torch of the Hunter A", "die"),
                        new TimedTransition(4000, "Cfight1")
                            )
                        ),
                    new State("Cfight1",
                        new RemoveEntity(60, "BD Logic 2"),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new TossObject("BD Bastille Brute", range: 10, coolDown: 6000, probability: 0.75),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Cfight1a")
                        ),
                     new State("Cfight1a",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Cfight1b")
                        ),
                     new State("Cfight1b",
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Cfight2")
                        ),
                    new State("Cfight2",
                        new Swirl(0.5, 2),
                        new Shoot(10, count: 7, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 14, projectileIndex: 2, predictive: 0.5, coolDown: 1000),
                        new TimedTransition(5000, "Cfight2a")
                        ),
                    new State("Cfight2a",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 400),

                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 0, projectileIndex: 1, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),
                        new TimedTransition(8000, "Cfight2b")
                        ),
                    new State("Cfight2b",
                        new Follow(0.4, 8, 1),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 400),

                        new Shoot(10, count: 7, shootAngle: 18, fixedAngle: 0, projectileIndex: 0, coolDown: 1000, coolDownOffset: 500),
                        new TimedTransition(8000, "Cphase")
                        ),
                    new State("Cphase",
                        new HealSelf(coolDown: 1000, amount: 40000),
                        new Taunt("Run, fools. You can't stand a chance in the darkness."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "Cphase2")
                        ),
                    new State("Cphase2",
                        new SetAltTexture(0, 1, 10, true),
                        new TimedTransition(4000, "Cphase3")
                        ),
                    new State("Cphase3",
                        new Prioritize(
                            new Follow(1.5),
                            new Wander(0.1)
                            ),
                        new SetAltTexture(0),
                        new PlayerWithinTransition(3, "Cphase2", seeInvis: true)
                        ),
                    new State("Cphase2",
                        new Taunt(0.75, "I see you, fool..your legacy ends here."),
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "Cjump")
                        ),
                    new State("Cjump",
                        new SetAltTexture(1),
                        new Charge(2, range: 10, coolDown: 4000),
                        new Shoot(10, count: 22, projectileIndex: 0, coolDown: 4000),
                        new PlayerWithinTransition(1, "Crunback")
                        ),
                    new State("Crunback",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "Cfight3")
                        ),
                    new State("Cfight3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 3, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "Cfight4")
                        ),
                    new State("Cfight4",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 4, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "Cshadows")
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.NFabledItemsLoots2B()
                ),
                new MostDamagers(3,
                    LootTemplates.GreaterPots()
                ),
                new MostDamagers(3,
                    LootTemplates.Sor4Perc()
                    ),
                    new Threshold(0.1,
                       new ItemLoot("Onrane Cache", 0.2),
                       new ItemLoot("Gold Cache", 0.077),
                       new ItemLoot("Vial of Life", 1),
                       new ItemLoot("Vial of Dexterity", 1),
                       new ItemLoot("Vial of Protection", 1),
                       new ItemLoot("Vial of Luck", 1)
                       )
            )
        .Init("BD Ultra Berikao, the Dark Hunter",
                new State(
                    new ScaleHP(125000),
                    new DropPortalOnDeath("Ultra Twisted Trials", 1, 120),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(8, "taunt1")
                        ),
                    new State("taunt1",
                        new Taunt("The shadows are what I thrive in..", "Get used to the darkness..for it will be your forever once I am through with you."),
                        new TimedTransition(2000, "taunt2")
                        ),
                    new State("taunt2",
                        new SetAltTexture(0, 1, 10, true),
                        new Taunt("Just let me get adjusted here..."),
                        new TimedTransition(4000, "taunt3")
                        ),
                    new State("taunt3",
                        new SetAltTexture(1),
                        new Taunt("Ah, yes..now where were we?"),
                        new TimedTransition(2000, "fight1")
                        )
                     ),
                    new State(
                        new DamageTakenTransition(400000, "Bshadows"),
                    new State("fight1",
                        new ReplaceTile("Black Lava", "BD Hunter Den Floor", 11),
                        new Order(100, "BerikaoPath", "idle"),
                        new RemoveEntity(60, "BD Logic 2"),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new TossObject("BD Ultra Bastille Brute", range: 10, coolDown: 6000, probability: 1),
                        new TossObject("BD Ultra Bastille Brute", range: 10, coolDown: 6000, probability: 1),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "fight1a")
                        ),
                     new State("fight1a",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "fight1b")
                        ),
                     new State("fight1b",
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Swirl(0.5, 2),
                        new Shoot(10, count: 7, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 14, projectileIndex: 2, predictive: 0.5, coolDown: 1000),
                        new TimedTransition(5000, "fight2a")
                        ),
                    new State("fight2a",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 400),

                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 0, projectileIndex: 1, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),
                        new TimedTransition(8000, "fight2b")
                        ),
                    new State("fight2b",
                        new Follow(0.4, 8, 1),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 400),

                        new Shoot(10, count: 7, shootAngle: 18, fixedAngle: 0, projectileIndex: 0, coolDown: 1000, coolDownOffset: 500),
                        new TimedTransition(8000, "phase")
                        ),
                    new State("phase",
                        new HealSelf(coolDown: 1000, amount: 40000),
                        new Taunt("Run, fools. You can't stand a chance in the darkness."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "phase2")
                        ),
                    new State("phase2",
                        new SetAltTexture(0, 1, 10, true),
                        new TimedTransition(4000, "phase3")
                        ),
                    new State("phase3",
                        new Prioritize(
                            new Follow(1.5),
                            new Wander(0.1)
                            ),
                        new SetAltTexture(0),
                        new PlayerWithinTransition(3, "phase2", seeInvis: true)
                        ),
                    new State("phase2",
                        new Taunt(0.75, "I see you, fool..your legacy ends here."),
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "jump")
                        ),
                    new State("jump",
                        new SetAltTexture(1),
                        new Charge(2, range: 10, coolDown: 4000),
                        new Shoot(10, count: 22, projectileIndex: 0, coolDown: 4000),
                        new PlayerWithinTransition(1, "runback")
                        ),
                    new State("runback",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "fight3")
                        ),
                    new State("fight3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 3, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "fight4")
                        ),
                    new State("fight4",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 4, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "shadows")
                     ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("shadows",
                        new HealSelf(coolDown: 9999, amount: 60000),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, -1),
                        new SetAltTexture(0, 1, 10, true),
                        new Taunt("Let the fun begin...", "LIGHTS OFF!"),
                        new ReturnToSpawn(2),
                        new Order(20, "BerikaoFlood", "spawn"),
                        new TimedTransition(1000, "alava")
                        ),
                    new State("alava",
                        new Order(20, "BerikaoFlood1", "spawn"),
                        new TimedTransition(1000, "alava1")
                        ),
                    new State("alava1",
                        new Order(20, "BerikaoFlood2", "spawn"),
                        new TimedTransition(1000, "alava2")
                        ),
                    new State("alava2",
                        new Order(20, "BerikaoFlood3", "spawn"),
                        new TimedTransition(5000, "shadowswait")
                        ),
                    new State("shadowswait",
                        new SetAltTexture(0),
                        new Spawn("BD Logic 1", 1, 1, coolDown: 99999),
                        new EntitiesNotExistsTransition(9999, "shadowswait2", "Torch of the Hunter B")
                        ),
                    new State("shadowswait2",
                        new SetAltTexture(1),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, 0),
                        new RemoveEntity(60, "BD Logic 1"),
                        new Spawn("BD Logic 2", 1, 1, coolDown: 99999),
                        new Order(999, "Torch of the Hunter A", "die"),
                        new Order(20, "BerikaoFlood", "idle"),
                        new Order(20, "BerikaoFlood1", "idle"),
                        new Order(20, "BerikaoFlood2", "idle"),
                        new Order(20, "BerikaoFlood3", "idle"),
                        new TimedTransition(4000, "fight1")
                                )
                            )
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Bshadows",
                        new HealSelf(coolDown: 9999, amount: 250000),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, -1),
                        new SetAltTexture(0, 1, 10, true),
                        new Taunt("More SLAUGHTER!", "and the Death Begins..."),
                        new ReturnToSpawn(2),
                        new Order(20, "BerikaoFlood", "spawn"),
                        new Order(100, "BerikaoPath", "idle"),
                        new TimedTransition(1000, "blava")
                        ),
                    new State("blava",
                        new Order(20, "BerikaoFlood1", "spawn"),
                        new TimedTransition(1000, "blava1")
                        ),
                    new State("blava1",
                        new Order(20, "BerikaoFlood2", "spawn"),
                        new TimedTransition(1000, "blava2")
                        ),
                    new State("blava2",
                        new Order(20, "BerikaoFlood3", "spawn"),
                        new TimedTransition(5000, "Bshadowswait")
                        ),
                    new State("Bshadowswait",
                        new SetAltTexture(0),
                        new Spawn("BD Logic 1", 1, 1, coolDown: 99999),
                        new EntitiesNotExistsTransition(9999, "Bshadowswait2", "Torch of the Hunter B")
                        ),
                    new State("Bshadowswait2",
                        new SetAltTexture(1),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, 0),
                        new RemoveEntity(60, "BD Logic 1"),
                        new Spawn("BD Logic 2", 1, 1, coolDown: 99999),
                        new Order(999, "Torch of the Hunter A", "die"),
                        new Order(20, "BerikaoFlood", "idle"),
                        new Order(20, "BerikaoFlood1", "idle"),
                        new Order(20, "BerikaoFlood2", "idle"),
                        new Order(20, "BerikaoFlood3", "idle"),
                        new TimedTransition(4000, "Bfight1")
                            )
                        ),
                    new State(
                        new DamageTakenTransition(750000, "Cshadows"),
                    new State("Bfight1",
                        new ReplaceTile("Black Lava", "BD Hunter Den Floor", 11),
                        new Order(100, "BerikaoPath", "spawn"),
                        new RemoveEntity(60, "BD Logic 2"),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new TossObject("BD Ultra Bastille Brute", range: 10, coolDown: 6000, probability: 1),
                        new TossObject("BD Ultra Bastille Brute", range: 10, coolDown: 6000, probability: 1),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Bfight1a")
                        ),
                     new State("Bfight1a",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Bfight1b")
                        ),
                     new State("Bfight1b",
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Bfight2")
                        ),
                    new State("Bfight2",
                        new Swirl(0.5, 2),
                        new Shoot(10, count: 7, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 14, projectileIndex: 2, predictive: 0.5, coolDown: 1000),
                        new TimedTransition(5000, "Bfight2a")
                        ),
                    new State("Bfight2a",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 400),

                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 0, projectileIndex: 1, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),
                        new TimedTransition(8000, "Bfight2b")
                        ),
                    new State("Bfight2b",
                        new Follow(0.4, 8, 1),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 400),

                        new Shoot(10, count: 7, shootAngle: 18, fixedAngle: 0, projectileIndex: 0, coolDown: 1000, coolDownOffset: 500),
                        new TimedTransition(8000, "Bphase")
                        ),
                    new State("Bphase",
                        new HealSelf(coolDown: 1000, amount: 40000),
                        new Taunt("Run, fools. You can't stand a chance in the darkness."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "Bphase2")
                        ),
                    new State("Bphase2",
                        new SetAltTexture(0, 1, 10, true),
                        new TimedTransition(4000, "Bphase3")
                        ),
                    new State("Bphase3",
                        new Prioritize(
                            new Follow(1.5),
                            new Wander(0.1)
                            ),
                        new SetAltTexture(0),
                        new PlayerWithinTransition(3, "Bphase2", seeInvis: true)
                        ),
                    new State("Bphase2",
                        new Taunt(0.75, "I see you, fool..your legacy ends here."),
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "Bjump")
                        ),
                    new State("Bjump",
                        new SetAltTexture(1),
                        new Charge(2, range: 10, coolDown: 4000),
                        new Shoot(10, count: 22, projectileIndex: 0, coolDown: 4000),
                        new PlayerWithinTransition(1, "Brunback")
                        ),
                    new State("Brunback",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "Bfight3")
                        ),
                    new State("Bfight3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 3, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "Bfight4")
                        ),
                    new State("Bfight4",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 4, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "Bshadows")
                        )
                     ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("Cshadows",
                        new HealSelf(coolDown: 9999, amount: 10000),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, -1),
                        new SetAltTexture(0, 1, 10, true),
                        new Taunt("One last hunt..."),
                        new ReturnToSpawn(2),
                        new Order(20, "BerikaoFlood", "spawn"),
                        new Order(100, "BerikaoPath", "idle"),
                        new TimedTransition(1000, "clava")
                        ),
                    new State("clava",
                        new Order(20, "BerikaoFlood1", "spawn"),
                        new TimedTransition(1000, "clava1")
                        ),
                    new State("clava1",
                        new Order(20, "BerikaoFlood2", "spawn"),
                        new TimedTransition(1000, "clava2")
                        ),
                    new State("clava2",
                        new Order(20, "BerikaoFlood3", "spawn"),
                        new TimedTransition(5000, "Cshadowswait")
                        ),
                    new State("Cshadowswait",
                        new SetAltTexture(0),
                        new Spawn("BD Logic 1", 1, 1, coolDown: 99999),
                        new EntitiesNotExistsTransition(9999, "Cshadowswait2", "Torch of the Hunter B")
                        ),
                    new State("Cshadowswait2",
                        new SetAltTexture(1),
                        new ConditionEffectRegion(ConditionEffectIndex.Blind, 999, 0),
                        new RemoveEntity(60, "BD Logic 1"),
                        new Spawn("BD Logic 2", 1, 1, coolDown: 99999),
                        new Order(999, "Torch of the Hunter A", "die"),
                        new Order(20, "BerikaoFlood", "idle"),
                        new Order(20, "BerikaoFlood1", "idle"),
                        new Order(20, "BerikaoFlood2", "idle"),
                        new Order(20, "BerikaoFlood3", "idle"),
                        new TimedTransition(4000, "Cfight1")
                            )
                        ),
                    new State("Cfight1",
                        new ReplaceTile("Black Lava", "BD Hunter Den Floor", 11),
                        new Order(100, "BerikaoPath", "spawn"),
                        new RemoveEntity(60, "BD Logic 2"),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new TossObject("BD Ultra Bastille Brute", range: 10, coolDown: 6000, probability: 1),
                        new TossObject("BD Ultra Bastille Brute", range: 10, coolDown: 6000, probability: 1),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Cfight1a")
                        ),
                     new State("Cfight1a",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Cfight1b")
                        ),
                     new State("Cfight1b",
                        new Flash(0x00FFFF, 1, 1),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 800),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 2000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 800, coolDownOffset: 500),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),



                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 45, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 135, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 225, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new Shoot(10, count: 2, shootAngle: 40, fixedAngle: 315, projectileIndex: 0, coolDown: 2000, coolDownOffset: 3000),
                        new TimedTransition(4000, "Cfight2")
                        ),
                    new State("Cfight2",
                        new Swirl(0.5, 2),
                        new Shoot(10, count: 7, shootAngle: 6, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, count: 14, projectileIndex: 2, predictive: 0.5, coolDown: 1000),
                        new TimedTransition(5000, "Cfight2a")
                        ),
                    new State("Cfight2a",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 400),

                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 0, projectileIndex: 1, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 90, projectileIndex: 1, coolDown: 800, coolDownOffset: 1000),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 180, projectileIndex: 1, coolDown: 800, coolDownOffset: 1500),
                        new Shoot(10, count: 6, shootAngle: 10, fixedAngle: 270, projectileIndex: 1, coolDown: 800, coolDownOffset: 800),
                        new TimedTransition(8000, "Cfight2b")
                        ),
                    new State("Cfight2b",
                        new Follow(0.4, 8, 1),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 400),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 400),

                        new Shoot(10, count: 7, shootAngle: 18, fixedAngle: 0, projectileIndex: 0, coolDown: 1000, coolDownOffset: 500),
                        new TimedTransition(8000, "Cphase")
                        ),
                    new State("Cphase",
                        new HealSelf(coolDown: 1000, amount: 40000),
                        new Taunt("Run, fools. You can't stand a chance in the darkness."),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "Cphase2")
                        ),
                    new State("Cphase2",
                        new SetAltTexture(0, 1, 10, true),
                        new TimedTransition(4000, "Cphase3")
                        ),
                    new State("Cphase3",
                        new Prioritize(
                            new Follow(1.5),
                            new Wander(0.1)
                            ),
                        new SetAltTexture(0),
                        new PlayerWithinTransition(3, "Cphase2", seeInvis: true)
                        ),
                    new State("Cphase2",
                        new Taunt(0.75, "I see you, fool..your legacy ends here."),
                        new SetAltTexture(0, 1, 10, true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "Cjump")
                        ),
                    new State("Cjump",
                        new SetAltTexture(1),
                        new Charge(2, range: 10, coolDown: 4000),
                        new Shoot(10, count: 22, projectileIndex: 0, coolDown: 4000),
                        new PlayerWithinTransition(1, "Crunback")
                        ),
                    new State("Crunback",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(2),
                        new TimedTransition(3000, "Cfight3")
                        ),
                    new State("Cfight3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 5, shootAngle: 10, projectileIndex: 3, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "Cfight4")
                        ),
                    new State("Cfight4",
                        new Prioritize(
                            new StayCloseToSpawn(0.8, 3),
                            new Wander(0.5)
                        ),
                        new Shoot(10, count: 4, projectileIndex: 0, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, coolDownOffset: 800, coolDown: 2000),
                        new TimedTransition(4000, "Cshadows")
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLoots2B()
                ),
                new MostDamagers(3,
                    LootTemplates.GreaterPots()
                ),
                new MostDamagers(3,
                    LootTemplates.Sor4Perc()
                    ),
                    new Threshold(0.1,
                       new TierLoot(7, ItemType.Ring, 0.06),
                       new ItemLoot("Onrane Cache", 0.22),
                       new ItemLoot("Gold Cache", 0.11),
                       new ItemLoot("Vial of Life", 1),
                       new ItemLoot("Vial of Dexterity", 1),
                       new ItemLoot("Vial of Protection", 1),
                       new ItemLoot("Vial of Luck", 1)
                       )
            )


                 .Init("Lin",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("waiting",
                     new PlayerWithinTransition(3, "taunt1")
                    ),
                new State("taunt1",
                     new Taunt("No one has ever has made it this far... I congratulate you..."),
                     new TimedTransition(4000, "taunt2")
                    ),
                new State("taunt2",
                     new Taunt("However..."),
                     new TimedTransition(6000, "taunt3")
                    ),
                new State("taunt3",
                     new Taunt("Your hands are the hands of a murderer..."),
                     new TimedTransition(6000, "taunt4")
                    ),
                new State("taunt4",
                     new Flash(0xFF0000, 0.25, 8),
                     new Taunt("YOU KILLED REVIL! NOW, YOU WILL PAY!"),
                     new TimedTransition(6000, "break")
                    ),
                new State("break",
                    new Order(90, "Scorching Wrath Run", "taunt1"),
                     new RemoveObjectOnDeath("BD Wall Relic 4", 99),
                     new ReplaceTile("BD The Steps", "Weaker Hot Lava", 99),
                     new Suicide()
                    )
                )
            )
        .Init("Ultra Lin",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("waiting",
                     new PlayerWithinTransition(3, "taunt1")
                    ),
                new State("taunt1",
                     new Taunt("No one has ever has made it this far... I congratulate you..."),
                     new TimedTransition(4000, "taunt2")
                    ),
                new State("taunt2",
                     new Taunt("However..."),
                     new TimedTransition(6000, "taunt3")
                    ),
                new State("taunt3",
                     new Taunt("Your hands are the hands of a murderer..."),
                     new TimedTransition(6000, "taunt4")
                    ),
                new State("taunt4",
                     new Flash(0xFF0000, 0.25, 8),
                     new Taunt("YOU KILLED REVIL! NOW, YOU WILL PAY!"),
                     new TimedTransition(6000, "break")
                    ),
                new State("break",
                    new Order(90, "Ultra Scorching Wrath Run", "taunt1"),
                     new RemoveObjectOnDeath("BD Wall Relic 4", 99),
                     new ReplaceTile("BD The Steps", "Weaker Hot Lava", 99),
                     new Suicide()
                    )
                )
            )

            .Init("Scorching Wrath Run",
            new State(
                new SetNoXP(),
                new State("0",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("taunt1",
                     new ChangeSize(60, 150),
                     new TimedTransition(4000, "taunt2")
                    ),
                new State("taunt2",
                     new Taunt("Your ashes will decorate these ruins!"),
                     new TimedTransition(4000, "go2")
                    )
                ),
                new State(
                    new Taunt("SURVIVE MY FURY!"),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(60000, "finish"),
                    new Orbit(2, 5, target: "BD Platform Helper"),
                new State("go2",
                   new Shoot(10, count: 1, shootAngle: 12, projectileIndex: 1, predictive: 0.1, coolDown: 600)
                        )
                    ),
                new State("finish",
                     new Order(90, "BD Platform Helper 2", "dead"),
                     new Order(90, "BD Platform Helper", "dead"),
                     new Suicide()
                    )
                )
            )
        .Init("Ultra Scorching Wrath Run",
            new State(
                new SetNoXP(),
                new State("0",
                    new ConditionalEffect(ConditionEffectIndex.Invincible)
                    ),
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("taunt1",
                     new ChangeSize(60, 150),
                     new TimedTransition(4000, "taunt2")
                    ),
                new State("taunt2",
                     new Taunt("Your ashes will decorate these ruins!"),
                     new TimedTransition(4000, "go2")
                    )
                ),
                new State(
                    new Taunt("SURVIVE MY FURY!"),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new TimedTransition(60000, "finish"),
                    new Orbit(2, 5, target: "BD Ultra Platform Helper"),
                new State("go2",
                   new Shoot(10, count: 1, shootAngle: 12, projectileIndex: 1, predictive: 0.1, coolDown: 600),
                   new Shoot(10, count: 1, shootAngle: 12, projectileIndex: 1, predictive: 0.1, coolDown: 600, coolDownOffset: 200)
                        )
                    ),
                new State("finish",
                     new Order(90, "BD Ultra Platform Helper 2", "dead"),
                     new Order(90, "BD Ultra Platform Helper", "dead"),
                     new Suicide()
                    )
                )
            )

            .Init("BD Platform Helper",
            new State(
                new DropPortalOnDeath("The Steps 2 Portal", 1, 120),
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("go1",
                    new TimedTransition(36000, "go2")
                    ),
                new State(
                    new MoveTo(speed: 0.3f, x: 16, y: 278),
                new State("go2",
                     new ApplySetpiece("SafePlatform"),
                     new TimedTransition(1000, "go3")
                    ),
                new State("go3",
                     new ApplySetpiece("SafePlatform"),
                     new TimedTransition(1000, "go2")
                        )
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )
        .Init("BD Ultra Platform Helper",
            new State(
                new DropPortalOnDeath("Ultra The Steps 2", 1, 120),
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("go1",
                    new TimedTransition(36000, "go2")
                    ),
                new State(
                    new MoveTo(speed: 0.3f, x: 16, y: 278),
                new State("go2",
                     new ApplySetpiece("SafePlatform"),
                     new TimedTransition(1000, "go3")
                    ),
                new State("go3",
                     new ApplySetpiece("SafePlatform"),
                     new TimedTransition(1000, "go2")
                        )
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )


            .Init("Scorching Wrath Helper 2",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("spawn",
                    new Spawn("BD Bastille Brute", 1, 1, coolDown: 99999)
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )
        .Init("Ultra Scorching Wrath Helper 2",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("spawn",
                    new Spawn("BD Ultra Bastille Brute", 1, 1, coolDown: 99999)
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )

            .Init("Spiritorb Holder Sentry",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("sentry1",
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 120, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 130, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 140, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 150, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 160, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 170, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 180, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(1, 8, projectileIndex: 0, coolDown: 4575, fixedAngle: 180, coolDownOffset: 2000, shootAngle: 45),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 180, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 170, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 150, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 140, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 130, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 120, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 110, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 100, coolDownOffset: 1600, shootAngle: 90)
                    ),
                 new State("sentry2",
                    new Shoot(10, count: 3, shootAngle: 20, projectileIndex: 1, predictive: 0.3, coolDown: 3000)
                    ),
                 new State("sentry3",
                    new Spawn("BD Bastille Brute", 1, 1, coolDown: 999999, givesNoXp: true),
                    new Shoot(8, count: 8, shootAngle: 20, projectileIndex: 1, predictive: 0.3, coolDown: 2000)
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )

        .Init("Ultra Spiritorb Holder Sentry",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("sentry1",
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 120, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 130, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 140, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 150, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 160, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 170, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 180, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(1, 8, projectileIndex: 0, coolDown: 4575, fixedAngle: 180, coolDownOffset: 2000, shootAngle: 45),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 180, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 170, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 150, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 140, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 130, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 120, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 110, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(1, 4, projectileIndex: 0, coolDown: 4575, fixedAngle: 100, coolDownOffset: 1600, shootAngle: 90)
                    ),
                 new State("sentry2",
                    new Shoot(10, count: 3, shootAngle: 20, projectileIndex: 1, predictive: 0.3, coolDown: 3000)
                    ),
                 new State("sentry3",
                    new Spawn("BD Ultra Bastille Brute", 1, 1, coolDown: 999999, givesNoXp: true),
                    new Shoot(8, count: 8, shootAngle: 20, projectileIndex: 1, predictive: 0.3, coolDown: 2000)
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )
                    .Init("Scorching Wrath Helper",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("spawn",
                    new Spawn("Scorching Fanatic", 1, 1, coolDown: 99999)
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )
        .Init("Ultra Scorching Wrath Helper",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle"
                    ),
                new State("spawn",
                    new Spawn("Ultra Scorching Fanatic", 1, 1, coolDown: 99999)
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )

                    .Init("BD Platform Helper 2",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("go1",
                    new TimedTransition(36000, "go2")
                    ),
                new State(
                    new MoveTo(speed: 0.3f, x: 16, y: 278),
                new State("go2",
                     new ApplySetpiece("BadPlatform"),
                     new TimedTransition(1000, "go3")
                    ),
                new State("go3",
                     new ApplySetpiece("BadPlatform"),
                     new TimedTransition(1000, "go2")
                        )
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )
        .Init("BD Ultra Platform Helper 2",
            new State(
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("go1",
                    new TimedTransition(36000, "go2")
                    ),
                new State(
                    new MoveTo(speed: 0.3f, x: 16, y: 278),
                new State("go2",
                     new ApplySetpiece("BadPlatform"),
                     new TimedTransition(1000, "go3")
                    ),
                new State("go3",
                     new ApplySetpiece("BadPlatform"),
                     new TimedTransition(1000, "go2")
                        )
                    ),
                new State("dead",
                    new Suicide()
                    )
                )
            )
            .Init("Scorching Wrath Real",
                new State(
                    //new DropPortalOnDeath("Summoning Point Portal", 1, 120),
                    new TransformOnDeath("Lin2", 1, 1),
                new State(
                    new ScaleHP(15000),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(8, "taunt")
                        ),
                    new State("taunt",
                        new Taunt("What have you done... Revil did nothing to you..."),
                        new TimedTransition(6000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt("My vengeance will be sweet..."),
                        new TimedTransition(6000, "windup")
                        )
                    ),
                    new State("windup",
                        new RemoveEntity(99, "Scorching Fanatic"),
                        new RemoveEntity(99, "BD Bastille Brute"),
                        new RemoveEntity(99, "BD Lava Bat"),
                        new Orbit(2, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "fight1")
                        ),
                    new State(
                        new HpLessTransition(0.25, "rage"),
                    new State(
                        new RemoveEntity(99, "Scorching Fanatic"),
                        new RemoveEntity(99, "BD Bastille Brute"),
                        new RemoveEntity(99, "BD Lava Bat"),
                        new Orbit(2, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new Shoot(10, 6, projectileIndex: 0, shootAngle: 14, coolDown: 2000),
                        new TimedTransition(14000, "windup2"),
                    new State("fight1",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 0, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 180, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1a")
                        ),
                    new State("fight1a",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 20, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 200, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1b")
                        ),
                    new State("fight1b",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 40, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 220, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1c")
                        ),
                    new State("fight1c",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 60, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 240, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1d")
                        ),
                    new State("fight1d",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 80, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 260, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1e")
                        ),
                    new State("fight1e",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 100, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 280, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1f")
                        ),
                    new State("fight1f",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 120, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 300, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1g")
                        ),
                    new State("fight1g",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 140, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 320, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1h")
                        ),
                    new State("fight1h",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 160, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 340, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1h")
                        ),
                    new State("fight1h",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 160, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 360, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1j")
                        ),
                    new State("fight1j",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 180, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 0, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1")
                        )
                    ),
                    new State("windup2",
                        new Taunt("THE BRUTES WILL DEVOUR YOUR BURNT CORPSES!"),
                        new Flash(0x0000FF, 0.2, 6),
                        new HealSelf(coolDown: 1000, amount: 1000),
                        new Orbit(2, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Order(99, "Scorching Wrath Helper", "spawn"),
                        new Orbit(2, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new Shoot(10, 3, projectileIndex: 1, shootAngle: 14, coolDown: 2000),
                        new Shoot(10, 10, projectileIndex: 2, coolDown: 2000, coolDownOffset: 1000),
                        new TimedTransition(8000, "fight3")
                        ),
                    new State(
                        new Taunt(0.5, "My wrath will burn your soul to ashes!"),
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                        new Order(99, "Scorching Wrath Helper 2", "spawn"),
                        new Order(99, "Scorching Wrath Helper", "idle"),
                        new Orbit(2, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 4, predictive: 0.1, coolDown: 400),
                        new TimedTransition(10000, "fight4"),
                    new State("fight3",
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 90, coolDown: 400, shootAngle: 18),
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 270, coolDown: 400, shootAngle: 18),
                        new TimedTransition(10000, "fightb")
                        ),
                    new State("fightb",
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 0, coolDown: 400, shootAngle: 18),
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 180, coolDown: 400, shootAngle: 18),
                        new TimedTransition(10000, "fight3")
                        )
                    ),
                    new State("fight4",
                        new TossObject("BD Lava Bat", 4, 0, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 45, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 90, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 135, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 180, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 225, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 270, coolDown: 9999999),
                        new TossObject("BD Lava Bat", 4, 315, coolDown: 9999999),
                        new Order(99, "Scorching Wrath Helper", "spawn"),
                        new Order(99, "Scorching Wrath Helper 2", "idle"),
                        new Orbit(2, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new Shoot(10, 10, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, 2, projectileIndex: 0, coolDown: 1000, shootAngle: 20),
                        new TimedTransition(8000, "fight5")
                            ),
                    new State("fight5",
                        new Orbit(2, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new Shoot(10, 10, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1, coolDown: 400),
                        new TimedTransition(8000, "killable")
                            ),
                    new State("killable",
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                        new TimedTransition(4000, "fight1")
                            )
                        ),
                   new State("rage",
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                       new HealSelf(coolDown: 99999, amount: 80000),
                       new Taunt(0.5, "DIE!!!"),
                       new Flash(0xFF0000, 0.2, 8),
                       new Prioritize(
                            new Follow(2, 16, 1),
                            new Wander(0.25)
                            ),
                        new Shoot(10, 12, projectileIndex: 3, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 1, coolDown: 400, shootAngle: 10),
                        new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 4, predictive: 0.1, coolDown: 800),
                        new TimedTransition(10000, "rage2")
                        ),
                   new State("rage2",
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                       new Grenade(4, 300, range: 10, coolDown: 1000, effect: ConditionEffectIndex.Paralyzed, effectDuration: 2000, color: 0x00FFFF),
                       new Taunt(0.5, "I WONT STOP UNTIL YOU ARE DEAD!"),
                       new Flash(0xFF0000, 0.2, 8),
                       new Prioritize(
                            new Orbit(1.5, 2, 1),
                            new Wander(0.25)
                            ),
                        new Shoot(10, 6, projectileIndex: 3, coolDown: 400),
                        new TimedTransition(10000, "return")
                        ),
                   new State("return",
                        new ReturnToSpawn(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "bfight1")
                        ),
                   new State(
                       new Grenade(2, 300, range: 10, coolDown: 400, effect: ConditionEffectIndex.Paralyzed, effectDuration: 2000, color: 0x00FFFF),
                       new Shoot(10, 7, projectileIndex: 3, shootAngle: 14, coolDown: 1800),
                   new State(
                        new RemoveEntity(99, "Scorching Fanatic"),
                        new RemoveEntity(99, "BD Bastille Brute"),
                        new RemoveEntity(99, "BD Lava Bat"),
                        new Orbit(2.5, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new Shoot(10, 6, projectileIndex: 0, shootAngle: 14, coolDown: 2000),
                        new TimedTransition(14000, "bwindup2"),
                    new State("bfight1",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 0, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 180, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1a")
                        ),
                    new State("bfight1a",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 20, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 200, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1b")
                        ),
                    new State("bfight1b",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 40, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 220, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1c")
                        ),
                    new State("bfight1c",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 60, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 240, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1d")
                        ),
                    new State("bfight1d",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 80, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 260, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1e")
                        ),
                    new State("bfight1e",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 100, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 280, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1f")
                        ),
                    new State("bfight1f",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 120, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 300, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1g")
                        ),
                    new State("bfight1g",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 140, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 320, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1h")
                        ),
                    new State("bfight1h",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 160, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 340, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1h")
                        ),
                    new State("bfight1h",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 160, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 360, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1j")
                        ),
                    new State("bfight1j",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 180, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 0, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1")
                        )
                    ),
                    new State("bwindup2",
                        new Taunt("THE BRUTES WILL DEVOUR YOUR BURNT CORPSES!"),
                        new Flash(0x0000FF, 0.2, 6),
                        new Orbit(2.5, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "bfight2")
                        ),
                    new State("bfight2",
                        new Order(99, "Scorching Wrath Helper", "spawn"),
                        new Orbit(2.5, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new Shoot(10, 3, projectileIndex: 1, shootAngle: 14, coolDown: 2000),
                        new Shoot(10, 10, projectileIndex: 2, coolDown: 2000, coolDownOffset: 1000),
                        new TimedTransition(8000, "bfight3")
                        ),
                    new State(
                        new Taunt(0.5, "My wrath will burn your soul to ashes!"),
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                        new Order(99, "Scorching Wrath Helper 2", "spawn"),
                        new Order(99, "Scorching Wrath Helper", "idle"),
                        new Orbit(2.5, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 4, predictive: 0.1, coolDown: 400),
                        new TimedTransition(10000, "bfight4"),
                    new State("bfight3",
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 90, coolDown: 400, shootAngle: 18),
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 270, coolDown: 400, shootAngle: 18),
                        new TimedTransition(10000, "bfightb")
                        ),
                    new State("bfightb",
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 0, coolDown: 400, shootAngle: 18),
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 180, coolDown: 400, shootAngle: 18),
                        new TimedTransition(10000, "bfight3")
                        )
                    ),
                    new State("bfight4",
                        new TossObject("BD Warrior of Drannol", 4, 0, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 45, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 90, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 135, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 180, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 225, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 270, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 315, coolDown: 9999999),
                        new Order(99, "Scorching Wrath Helper", "spawn"),
                        new Order(99, "Scorching Wrath Helper 2", "idle"),
                        new Orbit(2.5, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new Shoot(10, 10, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, 2, projectileIndex: 0, coolDown: 1000, shootAngle: 20),
                        new TimedTransition(8000, "bfight5")
                            ),
                    new State("bfight5",
                        new Taunt("...."),
                        new Orbit(2.5, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new Shoot(10, 10, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1, coolDown: 400),
                        new TimedTransition(8000, "bkillable")
                            ),
                    new State("bkillable",
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                        new TimedTransition(4000, "bfight1")
                            )
                       )
                    ),
                new MostDamagers(3,
                    LootTemplates.NFabledItemsLoots2B()
                ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.1,
                new TierLoot(7, ItemType.Ring, 0.003),
                new ItemLoot("Onrane Cache", 0.15),
                new ItemLoot("Gold Cache", 0.33),
                new ItemLoot("Vitality Eon", 0.02),
                new ItemLoot("Defense Eon", 0.02),
                new ItemLoot("Vial of Protection", 1),
                new ItemLoot("Vial of Vitality", 1),
                new ItemLoot("Vial of Defense", 1),
                new ItemLoot("Vial of Life", 1),
                new ItemLoot("Vial of Defense", 1),
                new ItemLoot("Vial of Attack", 0.6),
                new ItemLoot("Vial of Dexterity", 0.5),
                new ItemLoot("Vial of Luck", 0.5),
                new ItemLoot("Vial of Restoration", 0.5)
                    )
                )
        .Init("Ultra Scorching Wrath Real",
                new State(
                    //new DropPortalOnDeath("Summoning Point Portal", 1, 120),
                    new TransformOnDeath("UltraLin2", 1, 1),
                new State(
                    new ScaleHP(55000),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(8, "taunt")
                        ),
                    new State("taunt",
                        new Taunt("What have you done... Revil did nothing to you..."),
                        new TimedTransition(6000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt("My vengeance will be sweet..."),
                        new TimedTransition(6000, "windup")
                        )
                    ),
                    new State("windup",
                        new RemoveEntity(99, "Ultra Scorching Fanatic"),
                        new RemoveEntity(99, "BD Ultra Bastille Brute"),
                        new RemoveEntity(99, "BD Ultra Lava Bat"),
                        new Orbit(2, 8, 10, target: "Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "fight1")
                        ),
                    new State(
                        new HpLessTransition(0.4, "rage"),
                    new State(
                        new RemoveEntity(99, "Ultra Scorching Fanatic"),
                        new RemoveEntity(99, "BD Ultra Bastille Brute"),
                        new RemoveEntity(99, "BD Ultra Lava Bat"),
                        new Orbit(2, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new Shoot(10, 6, projectileIndex: 0, shootAngle: 14, coolDown: 2000),
                        new TimedTransition(14000, "windup2"),
                    new State("fight1",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 0, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 180, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1a")
                        ),
                    new State("fight1a",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 20, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 200, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1b")
                        ),
                    new State("fight1b",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 40, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 220, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1c")
                        ),
                    new State("fight1c",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 60, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 240, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1d")
                        ),
                    new State("fight1d",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 80, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 260, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1e")
                        ),
                    new State("fight1e",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 100, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 280, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1f")
                        ),
                    new State("fight1f",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 120, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 300, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1g")
                        ),
                    new State("fight1g",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 140, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 320, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1h")
                        ),
                    new State("fight1h",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 160, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 340, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1h")
                        ),
                    new State("fight1h",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 160, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 360, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1j")
                        ),
                    new State("fight1j",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 180, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 0, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "fight1")
                        )
                    ),
                    new State("windup2",
                        new Taunt("THE BRUTES WILL DEVOUR YOUR BURNT CORPSES!"),
                        new Flash(0x0000FF, 0.2, 6),
                        new HealSelf(coolDown: 1000, amount: 1000),
                        new Orbit(2, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Order(99, "Ultra Scorching Wrath Helper", "spawn"),
                        new Orbit(2, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new Shoot(10, 3, projectileIndex: 1, shootAngle: 14, coolDown: 2000),
                        new Shoot(10, 10, projectileIndex: 2, coolDown: 2000, coolDownOffset: 1000),
                        new TimedTransition(8000, "fight3")
                        ),
                    new State(
                        new Taunt(0.5, "My wrath will burn your soul to ashes!"),
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                        new Order(99, "Ultra Scorching Wrath Helper 2", "spawn"),
                        new Order(99, "Ultra Scorching Wrath Helper", "idle"),
                        new Orbit(2, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 4, predictive: 0.1, coolDown: 400),
                        new TimedTransition(10000, "fight4"),
                    new State("fight3",
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 90, coolDown: 400, shootAngle: 18),
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 270, coolDown: 400, shootAngle: 18),
                        new TimedTransition(10000, "fightb")
                        ),
                    new State("fightb",
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 0, coolDown: 400, shootAngle: 18),
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 180, coolDown: 400, shootAngle: 18),
                        new TimedTransition(10000, "fight3")
                        )
                    ),
                    new State("fight4",
                        new TossObject("BD Axeman of Drannol", 4, 45, coolDown: 9999999),
                        new TossObject("BD Axeman of Drannol", 4, 135, coolDown: 9999999),
                        new TossObject("BD Axeman of Drannol", 4, 225, coolDown: 9999999),
                        new TossObject("BD Axeman of Drannol", 4, 315, coolDown: 9999999),
                        new TossObject("BD Ultra Lava Bat", 4, 0, coolDown: 9999999),
                        new TossObject("BD Ultra Lava Bat", 4, 90, coolDown: 9999999),
                        new TossObject("BD Ultra Lava Bat", 4, 180, coolDown: 9999999),
                        new TossObject("BD Ultra Lava Bat", 4, 270, coolDown: 9999999),
                        new Order(99, "Ultra Scorching Wrath Helper", "spawn"),
                        new Order(99, "Ultra Scorching Wrath Helper 2", "idle"),
                        new Orbit(2, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new Shoot(10, 10, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, 2, projectileIndex: 0, coolDown: 1000, shootAngle: 20),
                        new TimedTransition(8000, "fight5")
                            ),
                    new State("fight5",
                        new Orbit(2, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new Shoot(10, 10, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1, coolDown: 400),
                        new TimedTransition(8000, "killable")
                            ),
                    new State("killable",
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                        new TimedTransition(4000, "fight1")
                            )
                        ),
                   new State("rage",
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                       new HealSelf(coolDown: 99999, amount: 80000),
                       new Taunt(0.5, "DIE!!!"),
                       new Flash(0xFF0000, 0.2, 8),
                       new Prioritize(
                            new Follow(2, 16, 1),
                            new Wander(0.25)
                            ),
                        new Shoot(10, 12, projectileIndex: 3, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 1, coolDown: 400, shootAngle: 10),
                        new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 4, predictive: 0.1, coolDown: 800),
                        new TimedTransition(10000, "rage2")
                        ),
                   new State("rage2",
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                       new Grenade(4, 300, range: 10, coolDown: 1000, effect: ConditionEffectIndex.Paralyzed, effectDuration: 2000, color: 0x00FFFF),
                       new Taunt(0.5, "I WONT STOP UNTIL YOU ARE DEAD!"),
                       new Flash(0xFF0000, 0.2, 8),
                       new Prioritize(
                            new Orbit(1.5, 2, 1),
                            new Wander(0.25)
                            ),
                        new Shoot(10, 6, projectileIndex: 3, coolDown: 400),
                        new TimedTransition(10000, "return")
                        ),
                   new State("return",
                        new ReturnToSpawn(1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "bfight1")
                        ),
                   new State(
                       new Grenade(2, 300, range: 10, coolDown: 400, effect: ConditionEffectIndex.Paralyzed, effectDuration: 2000, color: 0x00FFFF),
                       new Shoot(10, 7, projectileIndex: 3, shootAngle: 14, coolDown: 1800),
                   new State(
                        new RemoveEntity(99, "Ultra Scorching Fanatic"),
                        new RemoveEntity(99, "Ultra BD Bastille Brute"),
                        new RemoveEntity(99, "Ultra BD Lava Bat"),
                        new Orbit(2.5, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new Shoot(10, 6, projectileIndex: 0, shootAngle: 14, coolDown: 2000),
                        new TimedTransition(14000, "bwindup2"),
                    new State("bfight1",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 0, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 180, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1a")
                        ),
                    new State("bfight1a",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 20, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 200, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1b")
                        ),
                    new State("bfight1b",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 40, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 220, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1c")
                        ),
                    new State("bfight1c",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 60, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 240, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1d")
                        ),
                    new State("bfight1d",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 80, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 260, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1e")
                        ),
                    new State("bfight1e",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 100, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 280, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1f")
                        ),
                    new State("bfight1f",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 120, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 300, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1g")
                        ),
                    new State("bfight1g",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 140, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 320, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1h")
                        ),
                    new State("bfight1h",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 160, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 340, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1h")
                        ),
                    new State("bfight1h",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 160, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 360, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1j")
                        ),
                    new State("bfight1j",
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 180, shootAngle: 8, coolDown: 1000),
                        new Shoot(10, 6, projectileIndex: 2, fixedAngle: 0, shootAngle: 8, coolDown: 1000),
                        new TimedTransition(1000, "bfight1")
                        )
                    ),
                    new State("bwindup2",
                        new Taunt("THE BRUTES WILL DEVOUR YOUR BURNT CORPSES!"),
                        new Flash(0x0000FF, 0.2, 6),
                        new Orbit(2.5, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "bfight2")
                        ),
                    new State("bfight2",
                        new Order(99, "Ultra Scorching Wrath Helper", "spawn"),
                        new Orbit(2.5, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new Shoot(10, 3, projectileIndex: 1, shootAngle: 14, coolDown: 2000),
                        new Shoot(10, 10, projectileIndex: 2, coolDown: 2000, coolDownOffset: 1000),
                        new TimedTransition(8000, "bfight3")
                        ),
                    new State(
                        new Taunt(0.5, "My wrath will burn your soul to ashes!"),
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                        new Order(99, "Ultra Scorching Wrath Helper 2", "spawn"),
                        new Order(99, "Ultra Scorching Wrath Helper", "idle"),
                        new Orbit(2.5, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 4, predictive: 0.1, coolDown: 400),
                        new TimedTransition(10000, "bfight4"),
                    new State("bfight3",
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 90, coolDown: 400, shootAngle: 18),
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 270, coolDown: 400, shootAngle: 18),
                        new TimedTransition(10000, "bfightb")
                        ),
                    new State("bfightb",
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 0, coolDown: 400, shootAngle: 18),
                        new Shoot(10, 6, projectileIndex: 3, fixedAngle: 180, coolDown: 400, shootAngle: 18),
                        new TimedTransition(10000, "bfight3")
                        )
                    ),
                    new State("bfight4",
                        new TossObject("BD Warrior of Drannol", 4, 0, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 45, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 90, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 135, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 180, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 225, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 270, coolDown: 9999999),
                        new TossObject("BD Warrior of Drannol", 4, 315, coolDown: 9999999),
                        new Order(99, "Ultra Scorching Wrath Helper", "spawn"),
                        new Order(99, "Ultra Scorching Wrath Helper 2", "idle"),
                        new Orbit(2.5, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: true),
                        new Shoot(10, 10, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, 2, projectileIndex: 0, coolDown: 1000, shootAngle: 20),
                        new TimedTransition(8000, "bfight5")
                            ),
                    new State("bfight5",
                        new Taunt("...."),
                        new Orbit(2.5, 8, 10, target: "Ultra Scorching Wrath Helper Anchor", orbitClockwise: false),
                        new Shoot(10, 10, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 1, coolDown: 400),
                        new TimedTransition(8000, "bkillable")
                            ),
                    new State("bkillable",
                        new ConditionalEffect(ConditionEffectIndex.ArmorBroken),
                        new TimedTransition(4000, "bfight1")
                            )
                       )
                    ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLoots2B()
                ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.1,
                new TierLoot(7, ItemType.Ring, 0.0033),
                new ItemLoot("Onrane Cache", 0.22),
                new ItemLoot("Gold Cache", 0.6),
                new ItemLoot("Vitality Eon", 0.03),
                new ItemLoot("Defense Eon", 0.03),
                new ItemLoot("Vial of Protection", 1),
                new ItemLoot("Vial of Vitality", 1),
                new ItemLoot("Vial of Defense", 1),
                new ItemLoot("Vial of Life", 1),
                new ItemLoot("Vial of Defense", 1),
                new ItemLoot("Vial of Attack", 0.6),
                new ItemLoot("Vial of Dexterity", 0.5),
                new ItemLoot("Vial of Luck", 0.5),
                new ItemLoot("Vial of Restoration", 0.5)
                    )
                )
           .Init("Lin2",
            new State(
                new DropPortalOnDeath("Summoning Point Portal", 1, 120),
                new TransformOnDeath("Scorching Fanatic", 2, 3),
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("waiting",
                    new Flash(0xFFFFFF, 0.2, 12),
                    new Taunt("I can finally be at peace with him..."),
                    new TimedTransition(6000, "taunt1")
                    ),
                new State("taunt1",
                     new Suicide()
                    )
                )
            )
        .Init("UltraLin2",
            new State(
                new DropPortalOnDeath("Ultra Summoning Point", 1, 120),
                new TransformOnDeath("Ultra Scorching Fanatic", 2, 3),
                new SetNoXP(),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("waiting",
                    new Flash(0xFFFFFF, 0.2, 12),
                    new Taunt("I can finally be at peace with him..."),
                    new TimedTransition(6000, "taunt1")
                    ),
                new State("taunt1",
                     new Suicide()
                    )
                )
            )

            .Init("Drannol, the Eternal Beast",
                new State(
                    new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(30, "letusbegin")
                        ),
                    new State("letusbegin",
                        new Taunt(true, "Centuries...I have waited..The seal soon breaks."),
                        new TimedTransition(6000, "taunt1")
                        ),
                    new State("taunt1",
                        new Taunt(true, "You dare attempt to suppress the rise of my destruction."),
                        new TimedTransition(6000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt(true, "Sidon claims to aid me..mere mortals shouldn't interfere with the deals of gods."),
                        new TimedTransition(4000, "taunt3")
                        ),
                    new State("taunt3",
                        new Spawn("BD Taskmaster 3", 1, 1, coolDown: 99999),
                        new ChangeMusic("DrannolCage"),
                        new Taunt(true, "I will rip you to shreds..and when I'm done I'll destroy your puny safehaven so called the Nexus.", "My rage is an unstoppable force. Finally, this is the day of my judgement."),
                        new MoveTo(1, 44, 40),
                        new TimedTransition(10000, "DT1")
                        )
                    ),
                    new State(
                        new ReplaceTile("BD Ground 2", "Super Hot Lava", 99),
                        new DamageTakenTransition(80000, "Return1"),
                        new Shoot(20, count: 14, projectileIndex: 0, coolDown: 600),
                    new State(
                            new Shoot(1, count: 4, coolDown: 2000, projectileIndex: 4, fixedAngle: 90, rotateAngle: 10, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, count: 8, coolDown: 10000, projectileIndex: 4, fixedAngle: 180, coolDownOffset: 4000, shootAngle: 45),
                            new Shoot(1, count: 4, coolDown: 2000, projectileIndex: 4, fixedAngle: 180, rotateAngle: -10, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, count: 4, coolDown: 10000, projectileIndex: 4, fixedAngle: 90, coolDownOffset: 4000, shootAngle: 22.5),
                    new State("DT1",
                        new TimedTransition(10000, "DT2"),
                        new Prioritize(
                            new Charge(2, 8, coolDown: 4000),
                            new Follow(0.6),
                            new Wander(0.1)
                        ),
                        new Shoot(10, count: 6, shootAngle: 6, rotateAngle: 20, projectileIndex: 1, predictive: 0.1, coolDown: 2000)

                            )
                         ),
                    new State(
                            new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 90),
                            new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 270),
                            new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 0, coolDownOffset: 2000),
                            new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 180, coolDownOffset: 2000),
                    new State("DT2",
                        new TimedTransition(10000, "DT1"),
                        new Prioritize(
                            new Charge(2, 8, coolDown: 4000),
                            new Follow(0.4),
                            new Wander(0.1)
                        ),
                        new Shoot(10, count: 10, shootAngle: 8, rotateAngle: 20, projectileIndex: 1, predictive: 0.1, coolDown: 2000)

                            )
                         )
                      ),
                    new State("Return1",
                        new Taunt("You are nothing!"),
                        new MoveTo(1, 44, 40),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "DT3")
                        ),
                    new State(
                        new DamageTakenTransition(110000, "Return2"),
                        new State(
                            new Order(90, "Spiritorb Holder Sentry", "sentry1"),
                            new Shoot(20, count: 14, projectileIndex: 0, coolDown: 600),
                        new State(
                                new Shoot(1, count: 4, coolDown: 2000, projectileIndex: 4, fixedAngle: 90, rotateAngle: 10, coolDownOffset: 0, shootAngle: 90),
                                new Shoot(1, count: 8, coolDown: 10000, projectileIndex: 4, fixedAngle: 180, coolDownOffset: 4000, shootAngle: 45),
                                new Shoot(1, count: 4, coolDown: 2000, projectileIndex: 4, fixedAngle: 180, rotateAngle: -10, coolDownOffset: 0, shootAngle: 90),
                                new Shoot(1, count: 4, coolDown: 10000, projectileIndex: 4, fixedAngle: 90, coolDownOffset: 4000, shootAngle: 22.5),
                        new State("DT3",
                            new TimedTransition(10000, "DT4"),
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(0.8),
                                new Wander(0.1)
                            ),
                            new Shoot(10, count: 6, shootAngle: 6, rotateAngle: 20, projectileIndex: 1, predictive: 0.1, coolDown: 2000)
                                    )
                                )
                             ),
                        new State(
                                new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 90),
                                new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 270),
                                new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 0, coolDownOffset: 2000),
                                new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 180, coolDownOffset: 2000),
                        new State("DT4",
                            new TimedTransition(10000, "DT3"),
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(0.4),
                                new Wander(0.1)
                            ),
                            new Shoot(10, count: 4, shootAngle: 8, angleOffset: 40, projectileIndex: 1, predictive: 0.1, coolDown: 2000),
                            new Shoot(10, count: 4, shootAngle: 8, angleOffset: 320, projectileIndex: 1, predictive: 0.1, coolDown: 2000)
                             )
                          )
                        ),
                    new State("Return2",
                        new Order(90, "Spiritorb Holder Sentry", "idle"),
                        new MoveTo(1, 44, 40),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "DIE1")
                        ),
                    new State("DIE1",
                            new DamageTakenTransition(140000, "invulnerable"),
                            new Order(90, "Spiritorb Holder Sentry", "sentry2"),
                            new Order(90, "Scorching Wrath Helper", "spawn"),
                            new Taunt("Your lives will not be spared!"),
                            new TossObject("Scorching Fanatic", 4, 0, coolDown: 9999999),
                            new TossObject("Scorching Fanatic", 4, 45, coolDown: 9999999),
                            new TossObject("Scorching Fanatic", 4, 90, coolDown: 9999999),
                            new TossObject("Scorching Fanatic", 4, 135, coolDown: 9999999),
                            new TossObject("Scorching Fanatic", 4, 180, coolDown: 9999999),
                            new TossObject("Scorching Fanatic", 4, 225, coolDown: 9999999),
                            new TossObject("Scorching Fanatic", 4, 270, coolDown: 9999999),
                            new TossObject("Scorching Fanatic", 4, 315, coolDown: 9999999),
                            new Shoot(10, count: 8, projectileIndex: 2, coolDown: 3000),
                            new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 2, predictive: 0.1, coolDown: 1000, coolDownOffset: 1600),
                            new Shoot(10, count: 3, shootAngle: 8, angleOffset: 40, projectileIndex: 1, predictive: 0.1, coolDown: 1000),
                            new Shoot(10, count: 3, shootAngle: 8, angleOffset: 320, projectileIndex: 1, predictive: 0.1, coolDown: 1000)
                        ),
                    new State(
                        new Prioritize(
                            new StayAbove(0.7, 200),
                            new Follow(0.7, range: 7),
                            new Wander(0.4)
                            ),
                        new Flash(0x000000, 0.25, 4),
                        new DamageTakenTransition(170000, "Return3"),
                        new Order(90, "Scorching Wrath Helper", "idle"),
                        new TossObject("Scorching Fanatic", 4, 0, coolDown: 9999999),
                        new TossObject("Scorching Fanatic", 4, 45, coolDown: 9999999),
                        new TossObject("Scorching Fanatic", 4, 90, coolDown: 9999999),
                        new TossObject("Scorching Fanatic", 4, 135, coolDown: 9999999),
                        new TossObject("Scorching Fanatic", 4, 180, coolDown: 9999999),
                        new TossObject("Scorching Fanatic", 4, 225, coolDown: 9999999),
                        new TossObject("Scorching Fanatic", 4, 270, coolDown: 9999999),
                        new TossObject("Scorching Fanatic", 4, 315, coolDown: 9999999),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 2, predictive: 0.1, coolDown: 1000, coolDownOffset: 1600),
                        new Shoot(10, count: 3, shootAngle: 8, angleOffset: 40, projectileIndex: 1, predictive: 0.1, coolDown: 1000),
                        new Shoot(10, count: 3, shootAngle: 8, angleOffset: 320, projectileIndex: 1, predictive: 0.1, coolDown: 1000),
                     new State("invulnerable",
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new TimedTransition(4000, "notinvulnerable")
                          ),
                     new State("notinvulnerable",
                          new TimedTransition(4000, "invulnerable")
                          )
                        ),
                  new State("Return3",
                        new Order(90, "Spiritorb Holder Sentry", "idle"),
                        new MoveTo(1, 44, 40),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "f1")
                        ),
                  new State(
                   new DamageTakenTransition(200000, "ready1"),
                    new Order(90, "Spiritorb Holder Sentry", "sentry3"),
                    new State("f1",
                            new TimedTransition(1, "f2"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 0, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f2",
                            new TimedTransition(1, "f3"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 20, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f3",
                            new TimedTransition(1, "f4"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 40, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f4",
                            new TimedTransition(1, "f5"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 60, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f5",
                            new TimedTransition(1, "f6"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 80, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f6",
                            new TimedTransition(1, "f7"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 100, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f7",
                            new TimedTransition(1, "f8"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 120, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f8",
                            new TimedTransition(1, "f9"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 140, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f9",
                            new TimedTransition(1, "f10"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 160, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f10",
                            new TimedTransition(1, "f11"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 180, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f11",
                            new TimedTransition(1, "f12"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 200, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f12",
                            new TimedTransition(1, "f13"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 220, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f13",
                            new TimedTransition(1, "f15"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 240, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f15",
                            new TimedTransition(1, "f16"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 260, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f16",
                            new TimedTransition(1, "f17"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 280, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f17",
                            new TimedTransition(1, "f18"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 300, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f18",
                            new TimedTransition(1, "f19"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 320, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f19",
                            new TimedTransition(1, "f1"),
                            new Shoot(10, count: 2, shootAngle: 4, fixedAngle: 340, projectileIndex: 3, coolDown: 1)
                            )
                        ),
                    new State("1suppressionpurple",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(300000, "aseal1"),
                            new ReplaceTile("BD Ground 5d", "BD Ground 6d", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("aseal1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue1", "Wanzyu", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),


                    new State("1suppressionblue",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(300000, "bseal1"),
                            new ReplaceTile("BD Ground 5b", "BD Ground 6b", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("bseal1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue1", "Tareg", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("1suppressiongreen",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(300000, "cseal1"),
                            new ReplaceTile("BD Ground 5c", "BD Ground 6c", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("cseal1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue1", "Igaur", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("1suppressionorange",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(300000, "dseal1"),
                            new ReplaceTile("BD Ground 5a", "BD Ground 6a", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("dseal1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue1", "Nivitet", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),

                      new State(
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new State("ready1",
                            new Order(90, "Spiritorb Holder Sentry", "idle"),
                            new Order(90, "Scorching Wrath Helper", "idle"),
                            new MoveTo(1, 44, 40),
                            new TimedRandomTransition(6000, false, "1suppressionpurple", "1suppressionblue", "1suppressiongreen", "1suppressionorange")
                            ),
                        new State("continue1",
                            new Taunt("GAAAAH!"),
                            new ReplaceTile("BD Ground 6a", "BD Ground 5a", 99),
                            new ReplaceTile("BD Ground 6b", "BD Ground 5b", 99),
                            new ReplaceTile("BD Ground 6c", "BD Ground 5c", 99),
                            new ReplaceTile("BD Ground 6d", "BD Ground 5d", 99),
                            new ChangeSize(60, 140),
                            new Flash(0xFFFFFF, 0.5, 6),
                            new TimedTransition(4000, "dontremove")
                            )
                        ),
                    new State(
                            new Order(90, "Spiritorb Holder Sentry", "sentry3"),
                            new Taunt("YOUR FILTHY POWER ORB WILL BE NO MATCH AGAINST THE POWERS OF THIS ANCIENT SIGIL!"),
                            new Grenade(4, 80, range: 5, coolDown: 4000, effect: ConditionEffectIndex.Bleeding, effectDuration: 3000),
                            new Shoot(10, count: 3, shootAngle: 8, angleOffset: 40, projectileIndex: 3, predictive: 1, coolDown: 400),
                            new Shoot(10, count: 3, shootAngle: 8, angleOffset: 320, projectileIndex: 3, predictive: 1, coolDown: 400),
                            new Shoot(10, count: 4, shootAngle: 18, projectileIndex: 6, coolDown: 3000),
                            new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 7, coolDown: 6000),
                            new Shoot(10, count: 4, shootAngle: 10, angleOffset: 180, projectileIndex: 7, coolDown: 2000, coolDownOffset: 1200),
                            new Shoot(10, count: 4, shootAngle: 10, angleOffset: 0, projectileIndex: 7, coolDown: 2000, coolDownOffset: 1200),
                            new DamageTakenTransition(520000, "ready2"),
                        new State("dontremove",
                             new Prioritize(
                                    new Follow(1),
                                    new Wander(0.1)
                                ),
                            new TimedTransition(2000, "removeorb")
                                ),
                        new State("removeorb",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                             new Prioritize(
                                    new Charge(3, 8, coolDown: 3000),
                                    new Follow(1.4),
                                    new Wander(0.1)
                                ),
                            new Taunt(0.25, "Without your power orb you can't compete against my pure rage!", "You are worthless without your power orb..."),
                            new Flash(0x000000, 0.25, 4),
                            new RemoveEntity(7, "BD Spirit Orb Power"),
                            new TimedTransition(2000, "dontremove")
                            )
                      ),

                    new State("2suppressionpurple",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(620000, "aseal2"),
                            new ReplaceTile("BD Ground 5d", "BD Ground 6d", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("aseal2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue2", "Wanzyu", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),


                    new State("2suppressionblue",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(620000, "bseal2"),
                            new ReplaceTile("BD Ground 5b", "BD Ground 6b", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("bseal2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue2", "Tareg", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("2suppressiongreen",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(620000, "cseal2"),
                            new ReplaceTile("BD Ground 5c", "BD Ground 6c", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("cseal2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue2", "Igaur", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("2suppressionorange",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(620000, "dseal2"),
                            new ReplaceTile("BD Ground 5a", "BD Ground 6a", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("dseal2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue2", "Nivitet", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),


                      new State(
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new State("ready2",
                            new Order(90, "Spiritorb Holder Sentry", "idle"),
                            new Order(90, "Scorching Wrath Helper", "idle"),
                            new MoveTo(1, 44, 40),
                            new TimedRandomTransition(6000, false, "2suppressionpurple", "2suppressionblue", "2suppressiongreen", "2suppressionorange")
                            ),
                        new State("continue2",
                            new Taunt("GAAAAH!"),
                            new ReplaceTile("BD Ground 6a", "BD Ground 5a", 99),
                            new ReplaceTile("BD Ground 6b", "BD Ground 5b", 99),
                            new ReplaceTile("BD Ground 6c", "BD Ground 5c", 99),
                            new ReplaceTile("BD Ground 6d", "BD Ground 5d", 99),
                            new ChangeSize(60, 120),
                            new Flash(0xFFFFFF, 0.5, 6),
                            new TimedTransition(4000, "attack1a")
                            )
                        ),
                     new State(
                          new DamageTakenTransition(760000, "ready3"),
                    new State("attack1a",
                        new Order(90, "Scorching Wrath Helper", "spawn"),
                        new TossObject("Flaming Summon", 3, angle: 180, coolDown: 9999),
                        new TossObject("Flaming Summon", 3, angle: 0, coolDown: 9999),
                        new Taunt("My company and I will burn you to ashes!"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Order(90, "Scorching Wrath Helper", "spawn"),
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(0.4),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, projectileIndex: 7, coolDown: 6000),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 5, coolDown: 3000),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600),
                        new TimedTransition(4000, "attack2a")
                        ),
                    new State("attack2a",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(0.4),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, projectileIndex: 7, coolDown: 6000),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 5, coolDown: 3000),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600),
                        new EntitiesNotExistsTransition(99, "vulni", "Flaming Summon")
                            ),
                    new State("vulni",
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(0.4),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, projectileIndex: 7, coolDown: 6000),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 5, coolDown: 3000),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600)
                            )
                        ),


                    new State("3suppressionpurple",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(870000, "aseal3"),
                            new ReplaceTile("BD Ground 5d", "BD Ground 6d", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("aseal3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue3", "Wanzyu", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("3suppressionblue",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(870000, "bseal3"),
                            new ReplaceTile("BD Ground 5b", "BD Ground 6b", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("bseal3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue3", "Tareg", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("3suppressiongreen",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(870000, "cseal3"),
                            new ReplaceTile("BD Ground 5c", "BD Ground 6c", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("cseal3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue3", "Igaur", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("3suppressionorange",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(870000, "dseal3"),
                            new ReplaceTile("BD Ground 5a", "BD Ground 6a", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("dseal3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue3", "Nivitet", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),


                    new State(
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new State("ready3",
                            new Order(90, "Spiritorb Holder Sentry", "idle"),
                            new Order(90, "Scorching Wrath Helper", "idle"),
                            new MoveTo(1, 44, 40),
                            new TimedRandomTransition(6000, false, "3suppressionpurple", "3suppressionblue", "3suppressiongreen", "3suppressionorange")
                            ),
                        new State("continue3",
                            new Taunt("NO!"),
                            new ReplaceTile("BD Ground 6a", "BD Ground 5a", 99),
                            new ReplaceTile("BD Ground 6b", "BD Ground 5b", 99),
                            new ReplaceTile("BD Ground 6c", "BD Ground 5c", 99),
                            new ReplaceTile("BD Ground 6d", "BD Ground 5d", 99),
                            new ChangeSize(60, 100),
                            new Flash(0xFFFFFF, 0.5, 6),
                            new TimedTransition(4000, "crawlerphase")
                            ),
                    new State("crawlerphase",
                        new Taunt("I REFUSE TO BE SEALED ONCE AGAIN!"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TossObject("Scorching Crawler", 4, 0, coolDown: 9999999),
                        new TossObject("Scorching Crawler", 4, 45, coolDown: 9999999),
                        new TossObject("Scorching Crawler", 4, 90, coolDown: 9999999),
                        new TossObject("Scorching Crawler", 4, 135, coolDown: 9999999),
                        new TossObject("Scorching Crawler", 4, 180, coolDown: 9999999),
                        new TossObject("Scorching Crawler", 4, 225, coolDown: 9999999),
                        new TossObject("Scorching Crawler", 4, 270, coolDown: 9999999),
                        new TossObject("Scorching Crawler", 4, 315, coolDown: 9999999),

                        new TossObject("Scorching Crawler", 7, 45, coolDown: 9999999),
                        new TossObject("Scorching Crawler", 7, 135, coolDown: 9999999),
                        new TossObject("Scorching Crawler", 7, 225, coolDown: 9999999),
                        new TossObject("Scorching Crawler", 7, 315, coolDown: 9999999),
                        new TimedTransition(4000, "attack1b")
                        )
                    ),
                    new State(
                        new Reproduce("DrannolTarget", 40, 8, 2000),
                        new TossObject("BD Bastille Brute", 7, 45, coolDown: 9999999),
                        new TossObject("BD Bastille Brute", 7, 135, coolDown: 9999999),
                        new TossObject("BD Bastille Brute", 7, 225, coolDown: 9999999),
                        new TossObject("BD Bastille Brute", 7, 315, coolDown: 9999999),
                        new Order(90, "Spiritorb Holder Sentry", "sentry2"),
                        new Order(90, "Scorching Wrath Helper", "spawn"),
                        new EntitiesNotExistsTransition(99, "thenextone", "Scorching Crawler"),
                        new Shoot(20, count: 14, projectileIndex: 0, coolDown: 600),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new State("attack1b",
                            new Taunt("YOU SHALL BE CRUSHED!"),
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(1),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 2, shootAngle: 20, projectileIndex: 9, coolDown: 6000),

                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000),
                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60),
                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300),

                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 2600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60, coolDownOffset: 2600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300, coolDownOffset: 2600),

                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 4800),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60, coolDownOffset: 4800),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300, coolDownOffset: 4800),
                        new TimedTransition(8000, "attack1b")
                            ),
                     new State("attack2b",
                            new Prioritize(
                                new Charge(2, 8, coolDown: 6000),
                                new Follow(1),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 80, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 280, coolDownOffset: 1800),
                        new TimedTransition(4000, "attack3b")
                            ),
                       new State("attack3b",
                           new Flash(0xFF0000, 0.25, 6),
                            new Prioritize(
                                new Charge(2.5, 8, coolDown: 6000),
                                new Follow(1.5),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 80, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 280, coolDownOffset: 1800),
                        new TimedTransition(8000, "attack1b")
                            )
                        ),
                      new State(
                        new Reproduce("DrannolTarget", 40, 8, 2000),
                        new DamageTakenTransition(1020000, "ready4"),
                        new Shoot(20, count: 14, projectileIndex: 0, coolDown: 600),
                        new State("thenextone",
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(1.5),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 2, shootAngle: 20, projectileIndex: 9, coolDown: 6000),

                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000),
                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60),
                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300),

                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 2600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60, coolDownOffset: 2600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300, coolDownOffset: 2600),

                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 4800),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60, coolDownOffset: 4800),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300, coolDownOffset: 4800),
                        new TimedTransition(8000, "thenextone2")
                            ),
                     new State("thenextone2",
                            new Prioritize(
                                new Charge(2, 8, coolDown: 6000),
                                new Follow(1),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1200, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1200, angleOffset: 80, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1200, angleOffset: 280, coolDownOffset: 1800),
                        new TimedTransition(4000, "thenextone3")
                            ),
                       new State("thenextone3",
                           new Flash(0xFF0000, 0.25, 6),
                            new Prioritize(
                                new Charge(4, 8, coolDown: 6000),
                                new Follow(1.7),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1400, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1400, angleOffset: 80, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1400, angleOffset: 280, coolDownOffset: 1800),
                        new TimedTransition(8000, "thenextone")
                            )
                        ),


                    new State("4suppressionpurple",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(1200000, "aseal4"),
                            new ReplaceTile("BD Ground 5d", "BD Ground 6d", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("aseal4",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue4", "Wanzyu", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("4suppressionblue",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(1200000, "bseal4"),
                            new ReplaceTile("BD Ground 5b", "BD Ground 6b", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("bseal4",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue4", "Tareg", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("4suppressiongreen",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(1200000, "cseal4"),
                            new ReplaceTile("BD Ground 5c", "BD Ground 6c", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("cseal4",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue4", "Igaur", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("4suppressionorange",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(1200000, "dseal4"),
                            new ReplaceTile("BD Ground 5a", "BD Ground 6a", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("dseal4",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue4", "Nivitet", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),


                     new State(
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new State("ready4",
                            new Order(90, "Spiritorb Holder Sentry", "idle"),
                            new Order(90, "Scorching Wrath Helper", "idle"),
                            new MoveTo(1, 44, 40),
                            new TimedRandomTransition(6000, false, "4suppressionpurple", "4suppressionblue", "4suppressiongreen", "4suppressionorange")
                            ),
                        new State("continue4",
                            new Taunt("Not.......again..."),
                            new ReplaceTile("BD Ground 6a", "BD Ground 5a", 99),
                            new ReplaceTile("BD Ground 6b", "BD Ground 5b", 99),
                            new ReplaceTile("BD Ground 6c", "BD Ground 5c", 99),
                            new ReplaceTile("BD Ground 6d", "BD Ground 5d", 99),
                            new ChangeSize(80, 40),
                            new Flash(0xFFFFFF, 0.5, 6),
                            new TimedTransition(4000, "crybaby")
                            ),
                         new State("crybaby",
                            new Flash(0xFFFFFF, 0.2, 8),
                            new BackAndForth(1, 4),
                            new TimedTransition(4000, "suicide")
                            ),
                         new State("suicide",
                            new AnnounceOnDeath("An eternal threat has finally been sealed for another millenia..."),
                            new Suicide()
                            )
                        ),
                     new State(
                         new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new State("FAILED",
                            new Flash(0xFF0000, 0.25, 6),
                            new Taunt("Finally, the seal has been broken... Now you will all suffer!"),
                            new TimedTransition(6000, "byebye")
                            ),
                        new State("byebye",
                            new MoveTo(2, 44, 0),
                            new TimedTransition(8000, "latabih")
                            ),
                        new State("latabih",
                            new Suicide()
                            )
                         )
                    ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLoot2Drannol()
                ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.004,
                    new TierLoot(7, ItemType.Ring, 0.0033),
                    new ItemLoot("Drannol's Judgement", 0.001),
                    new ItemLoot("Bloodstone of Enmity", 0.003),
                    new ItemLoot("Ultimate Onrane Cache", 0.33),
                    new ItemLoot("10000 Gold", 0.12),
                    new ItemLoot("Large Sor Fragment", 0.006),
                    new ItemLoot("Medium Sor Fragment", 0.015),
                    new ItemLoot("Gold Cache", 0.5),
                    new ItemLoot("Vial of Life", 1),
                    new ItemLoot("Vial of Defense", 1),
                    new ItemLoot("Vial of Attack", 0.6),
                    new ItemLoot("Vial of Dexterity", 0.5),
                    new ItemLoot("Vial of Vitality", 0.5),
                    new ItemLoot("Vial of Speed", 0.5),
                    new ItemLoot("Vial of Mana", 0.5),
                    new ItemLoot("Vial of Might", 0.5),
                    new ItemLoot("Vial of Luck", 0.5),
                    new ItemLoot("Vial of Restoration", 0.5),
                    new ItemLoot("Vial of Protection", 0.5)
                )
            )
        .Init("Ultra Drannol, the Eternal Beast",
                new State(
                    new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(30, "letusbegin")
                        ),
                    new State("letusbegin",
                        new Taunt(true, "Centuries... I have waited... The seal soon breaks."),
                        new TimedTransition(6000, "taunt1")
                        ),
                    new State("taunt1",
                        new Taunt(true, "You dare attempt to suppress the rise of my destruction."),
                        new TimedTransition(6000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt(true, "Sidon claims to aid me... Mere mortals shouldn't interfere with the deals of gods."),
                        new TimedTransition(4000, "taunt3")
                        ),
                    new State("taunt3",
                        new Spawn("BD Taskmaster 3", 1, 1, coolDown: 99999),
                        new ChangeMusic("DrannolCage"),
                        new Taunt(true, "I will rip you to shreds... and when I'm done I'll destroy your puny safehaven so called the Nexus.", "My rage is an unstoppable force. Finally, this is the day of my judgement."),
                        new MoveTo(1, 44, 40),
                        new TimedTransition(10000, "DT1")
                        )
                    ),
                    new State(
                        new ReplaceTile("BD Ground 2", "Super Hot Lava", 99),
                        new DamageTakenTransition(80000, "Return1"),
                        new Shoot(20, count: 14, projectileIndex: 0, coolDown: 600),
                    new State(
                            new Shoot(1, count: 4, coolDown: 2000, projectileIndex: 4, fixedAngle: 90, rotateAngle: 10, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, count: 8, coolDown: 10000, projectileIndex: 4, fixedAngle: 180, coolDownOffset: 4000, shootAngle: 45),
                            new Shoot(1, count: 4, coolDown: 2000, projectileIndex: 4, fixedAngle: 180, rotateAngle: -10, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(1, count: 4, coolDown: 10000, projectileIndex: 4, fixedAngle: 90, coolDownOffset: 4000, shootAngle: 22.5),
                    new State("DT1",
                        new TimedTransition(10000, "DT2"),
                        new Prioritize(
                            new Charge(2, 8, coolDown: 4000),
                            new Follow(0.6),
                            new Wander(0.1)
                        ),
                        new Shoot(10, count: 6, shootAngle: 6, rotateAngle: 20, projectileIndex: 1, predictive: 0.1, coolDown: 2000)

                            )
                         ),
                    new State(
                            new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 90),
                            new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 270),
                            new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 0, coolDownOffset: 2000),
                            new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 180, coolDownOffset: 2000),
                    new State("DT2",
                        new TimedTransition(10000, "DT1"),
                        new Prioritize(
                            new Charge(2, 8, coolDown: 4000),
                            new Follow(0.4),
                            new Wander(0.1)
                        ),
                        new Shoot(10, count: 10, shootAngle: 8, rotateAngle: 20, projectileIndex: 1, predictive: 0.1, coolDown: 2000)

                            )
                         )
                      ),
                    new State("Return1",
                        new Taunt("You are nothing!"),
                        new MoveTo(1, 44, 40),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "DT3")
                        ),
                    new State(
                        new DamageTakenTransition(110000, "Return2"),
                        new State(
                            new Order(90, "Ultra Spiritorb Holder Sentry", "sentry1"),
                            new Shoot(20, count: 14, projectileIndex: 0, coolDown: 600),
                        new State(
                                new Shoot(1, count: 4, coolDown: 2000, projectileIndex: 4, fixedAngle: 90, rotateAngle: 10, coolDownOffset: 0, shootAngle: 90),
                                new Shoot(1, count: 8, coolDown: 10000, projectileIndex: 4, fixedAngle: 180, coolDownOffset: 4000, shootAngle: 45),
                                new Shoot(1, count: 4, coolDown: 2000, projectileIndex: 4, fixedAngle: 180, rotateAngle: -10, coolDownOffset: 0, shootAngle: 90),
                                new Shoot(1, count: 4, coolDown: 10000, projectileIndex: 4, fixedAngle: 90, coolDownOffset: 4000, shootAngle: 22.5),
                        new State("DT3",
                            new TimedTransition(10000, "DT4"),
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(0.8),
                                new Wander(0.1)
                            ),
                            new Shoot(10, count: 6, shootAngle: 6, rotateAngle: 20, projectileIndex: 1, predictive: 0.1, coolDown: 2000)
                                    )
                                )
                             ),
                        new State(
                                new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 90),
                                new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 270),
                                new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 0, coolDownOffset: 2000),
                                new Shoot(1, count: 4, shootAngle: 6, coolDown: 4000, projectileIndex: 4, fixedAngle: 180, coolDownOffset: 2000),
                        new State("DT4",
                            new TimedTransition(10000, "DT3"),
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(0.4),
                                new Wander(0.1)
                            ),
                            new Shoot(10, count: 4, shootAngle: 8, angleOffset: 40, projectileIndex: 1, predictive: 0.1, coolDown: 2000),
                            new Shoot(10, count: 4, shootAngle: 8, angleOffset: 320, projectileIndex: 1, predictive: 0.1, coolDown: 2000)
                             )
                          )
                        ),
                    new State("Return2",
                        new Order(90, "Ultra Spiritorb Holder Sentry", "idle"),
                        new MoveTo(1, 44, 40),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "DIE1")
                        ),
                    new State("DIE1",
                            new DamageTakenTransition(140000, "invulnerable"),
                            new Order(90, "Ultra Spiritorb Holder Sentry", "sentry2"),
                            new Order(90, "Ultra Scorching Wrath Helper", "spawn"),
                            new Taunt("Your lives will not be spared!"),
                            new TossObject("Ultra Scorching Fanatic", 4, 0, coolDown: 9999999),
                            new TossObject("Ultra Scorching Fanatic", 4, 45, coolDown: 9999999),
                            new TossObject("Ultra Scorching Fanatic", 4, 90, coolDown: 9999999),
                            new TossObject("Ultra Scorching Fanatic", 4, 135, coolDown: 9999999),
                            new TossObject("Ultra Scorching Fanatic", 4, 180, coolDown: 9999999),
                            new TossObject("Ultra Scorching Fanatic", 4, 225, coolDown: 9999999),
                            new TossObject("Ultra Scorching Fanatic", 4, 270, coolDown: 9999999),
                            new TossObject("Ultra Scorching Fanatic", 4, 315, coolDown: 9999999),
                            new Shoot(10, count: 8, projectileIndex: 2, coolDown: 3000),
                            new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 2, predictive: 0.1, coolDown: 1000, coolDownOffset: 1600),
                            new Shoot(10, count: 3, shootAngle: 8, angleOffset: 40, projectileIndex: 1, predictive: 0.1, coolDown: 1000),
                            new Shoot(10, count: 3, shootAngle: 8, angleOffset: 320, projectileIndex: 1, predictive: 0.1, coolDown: 1000)
                        ),
                    new State(
                        new Prioritize(
                            new StayAbove(0.7, 200),
                            new Follow(0.7, range: 7),
                            new Wander(0.4)
                            ),
                        new Flash(0x000000, 0.25, 4),
                        new DamageTakenTransition(170000, "Return3"),
                        new Order(90, "Ultra Scorching Wrath Helper", "idle"),
                        new TossObject("Ultra Scorching Fanatic", 4, 0, coolDown: 9999999),
                        new TossObject("Ultra Scorching Fanatic", 4, 45, coolDown: 9999999),
                        new TossObject("Ultra Scorching Fanatic", 4, 90, coolDown: 9999999),
                        new TossObject("Ultra Scorching Fanatic", 4, 135, coolDown: 9999999),
                        new TossObject("Ultra Scorching Fanatic", 4, 180, coolDown: 9999999),
                        new TossObject("Ultra Scorching Fanatic", 4, 225, coolDown: 9999999),
                        new TossObject("Ultra Scorching Fanatic", 4, 270, coolDown: 9999999),
                        new TossObject("Ultra Scorching Fanatic", 4, 315, coolDown: 9999999),
                        new Shoot(10, count: 6, shootAngle: 10, projectileIndex: 2, predictive: 0.1, coolDown: 1000, coolDownOffset: 1600),
                        new Shoot(10, count: 3, shootAngle: 8, angleOffset: 40, projectileIndex: 1, predictive: 0.1, coolDown: 1000),
                        new Shoot(10, count: 3, shootAngle: 8, angleOffset: 320, projectileIndex: 1, predictive: 0.1, coolDown: 1000),
                     new State("invulnerable",
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new TimedTransition(4000, "notinvulnerable")
                          ),
                     new State("notinvulnerable",
                          new TimedTransition(4000, "invulnerable")
                          )
                        ),
                  new State("Return3",
                        new Order(90, "Ultra Spiritorb Holder Sentry", "idle"),
                        new MoveTo(1, 44, 40),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(6000, "f1")
                        ),
                  new State(
                   new DamageTakenTransition(200000, "ready1"),
                    new Order(90, "Ultra Spiritorb Holder Sentry", "sentry3"),
                    new State("f1",
                            new TimedTransition(1, "f2"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 0, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f2",
                            new TimedTransition(1, "f3"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 20, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f3",
                            new TimedTransition(1, "f4"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 40, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f4",
                            new TimedTransition(1, "f5"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 60, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f5",
                            new TimedTransition(1, "f6"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 80, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f6",
                            new TimedTransition(1, "f7"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 100, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f7",
                            new TimedTransition(1, "f8"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 120, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f8",
                            new TimedTransition(1, "f9"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 140, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f9",
                            new TimedTransition(1, "f10"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 160, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f10",
                            new TimedTransition(1, "f11"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 180, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f11",
                            new TimedTransition(1, "f12"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 200, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f12",
                            new TimedTransition(1, "f13"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 220, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f13",
                            new TimedTransition(1, "f15"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 240, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f15",
                            new TimedTransition(1, "f16"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 260, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f16",
                            new TimedTransition(1, "f17"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 280, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f17",
                            new TimedTransition(1, "f18"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 300, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f18",
                            new TimedTransition(1, "f19"),
                            new Shoot(10, count: 4, shootAngle: 90, fixedAngle: 320, projectileIndex: 3, coolDown: 1)
                            ),
                    new State("f19",
                            new TimedTransition(1, "f1"),
                            new Shoot(10, count: 2, shootAngle: 4, fixedAngle: 340, projectileIndex: 3, coolDown: 1)
                            )
                        ),
                    new State("1suppressionpurple",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(300000, "aseal1"),
                            new ReplaceTile("BD Ground 5d", "BD Ground 6d", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("aseal1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue1", "Wanzyu", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),


                    new State("1suppressionblue",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(300000, "bseal1"),
                            new ReplaceTile("BD Ground 5b", "BD Ground 6b", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("bseal1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue1", "Tareg", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("1suppressiongreen",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(300000, "cseal1"),
                            new ReplaceTile("BD Ground 5c", "BD Ground 6c", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("cseal1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue1", "Igaur", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("1suppressionorange",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(300000, "dseal1"),
                            new ReplaceTile("BD Ground 5a", "BD Ground 6a", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("dseal1",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue1", "Nivitet", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),

                      new State(
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new State("ready1",
                            new Order(90, "Ultra Spiritorb Holder Sentry", "idle"),
                            new Order(90, "Ultra Scorching Wrath Helper", "idle"),
                            new MoveTo(1, 44, 40),
                            new TimedRandomTransition(6000, false, "1suppressionpurple", "1suppressionblue", "1suppressiongreen", "1suppressionorange")
                            ),
                        new State("continue1",
                            new Taunt("GAAAAH!"),
                            new ReplaceTile("BD Ground 6a", "BD Ground 5a", 99),
                            new ReplaceTile("BD Ground 6b", "BD Ground 5b", 99),
                            new ReplaceTile("BD Ground 6c", "BD Ground 5c", 99),
                            new ReplaceTile("BD Ground 6d", "BD Ground 5d", 99),
                            new ChangeSize(60, 140),
                            new Flash(0xFFFFFF, 0.5, 6),
                            new TimedTransition(4000, "dontremove")
                            )
                        ),
                    new State(
                            new Order(90, "Ultra Spiritorb Holder Sentry", "sentry3"),
                            new Taunt("YOUR FILTHY POWER ORB WILL BE NO MATCH AGAINST THE POWERS OF THIS ANCIENT SIGIL!"),
                            new Grenade(4, 80, range: 5, coolDown: 4000, effect: ConditionEffectIndex.Bleeding, effectDuration: 3000),
                            new Shoot(10, count: 3, shootAngle: 8, angleOffset: 40, projectileIndex: 3, predictive: 1, coolDown: 400),
                            new Shoot(10, count: 3, shootAngle: 8, angleOffset: 320, projectileIndex: 3, predictive: 1, coolDown: 400),
                            new Shoot(10, count: 4, shootAngle: 18, projectileIndex: 6, coolDown: 3000),
                            new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 7, coolDown: 6000),
                            new Shoot(10, count: 4, shootAngle: 10, angleOffset: 180, projectileIndex: 7, coolDown: 2000, coolDownOffset: 1200),
                            new Shoot(10, count: 4, shootAngle: 10, angleOffset: 0, projectileIndex: 7, coolDown: 2000, coolDownOffset: 1200),
                            new DamageTakenTransition(520000, "ready2"),
                        new State("dontremove",
                             new Prioritize(
                                    new Follow(1),
                                    new Wander(0.1)
                                ),
                            new TimedTransition(2000, "removeorb")
                                ),
                        new State("removeorb",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                             new Prioritize(
                                    new Charge(3, 8, coolDown: 3000),
                                    new Follow(1.4),
                                    new Wander(0.1)
                                ),
                            new Taunt(0.25, "Without your power orb you can't compete against my pure rage!", "You are worthless without your power orb..."),
                            new Flash(0x000000, 0.25, 4),
                            new RemoveEntity(7, "BD Spirit Orb Power"),
                            new TimedTransition(2000, "dontremove")
                            )
                      ),

                    new State("2suppressionpurple",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(620000, "aseal2"),
                            new ReplaceTile("BD Ground 5d", "BD Ground 6d", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("aseal2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue2", "Wanzyu", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),


                    new State("2suppressionblue",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(620000, "bseal2"),
                            new ReplaceTile("BD Ground 5b", "BD Ground 6b", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("bseal2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue2", "Tareg", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("2suppressiongreen",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(620000, "cseal2"),
                            new ReplaceTile("BD Ground 5c", "BD Ground 6c", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("cseal2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue2", "Igaur", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("2suppressionorange",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(620000, "dseal2"),
                            new ReplaceTile("BD Ground 5a", "BD Ground 6a", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("dseal2",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue2", "Nivitet", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),


                      new State(
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new State("ready2",
                            new Order(90, "Ultra Spiritorb Holder Sentry", "idle"),
                            new Order(90, "Ultra Scorching Wrath Helper", "idle"),
                            new MoveTo(1, 44, 40),
                            new TimedRandomTransition(6000, false, "2suppressionpurple", "2suppressionblue", "2suppressiongreen", "2suppressionorange")
                            ),
                        new State("continue2",
                            new Taunt("GAAAAH!"),
                            new ReplaceTile("BD Ground 6a", "BD Ground 5a", 99),
                            new ReplaceTile("BD Ground 6b", "BD Ground 5b", 99),
                            new ReplaceTile("BD Ground 6c", "BD Ground 5c", 99),
                            new ReplaceTile("BD Ground 6d", "BD Ground 5d", 99),
                            new ChangeSize(60, 120),
                            new Flash(0xFFFFFF, 0.5, 6),
                            new TimedTransition(4000, "attack1a")
                            )
                        ),
                     new State(
                          new DamageTakenTransition(760000, "ready3"),
                    new State("attack1a",
                        new Order(90, "Ultra Scorching Wrath Helper", "spawn"),
                        new TossObject("Ultra Bastille Sorcerer", 10, angle: 90, coolDown: 9999999),
                        new TossObject("Ultra Bastille Sorcerer", 5, angle: 90, coolDown: 9999999),
						new TossObject("Flaming Summon", 3, angle: 180, coolDown: 9999),
                        new TossObject("Flaming Summon", 3, angle: 0, coolDown: 9999),
                        new Taunt("Go my Sorcerers!"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(8000, "waitforsorc")
                        ),
                    new State("waitforsorc",
                        /*new Order(90, "Ultra Scorching Wrath Helper", "spawn"),
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(0.4),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, projectileIndex: 7, coolDown: 6000),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 5, coolDown: 3000),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600),
                        new TimedTransition(4000, "attack2a")
                        ),
                    new State("attack2a",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(0.4),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, projectileIndex: 7, coolDown: 6000),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 5, coolDown: 3000),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600),*/
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntitiesNotExistsTransition(99, "vulni", "Ultra Bastille Sorcerer")
                            ),
                    new State("vulni",
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(0.4),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, projectileIndex: 7, coolDown: 6000),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 5, coolDown: 3000),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 5, coolDown: 3000, coolDownOffset: 1600)
                            )
                        ),


                    new State("3suppressionpurple",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(870000, "aseal3"),
                            new ReplaceTile("BD Ground 5d", "BD Ground 6d", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("aseal3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue3", "Wanzyu", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("3suppressionblue",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(870000, "bseal3"),
                            new ReplaceTile("BD Ground 5b", "BD Ground 6b", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("bseal3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue3", "Tareg", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("3suppressiongreen",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(870000, "cseal3"),
                            new ReplaceTile("BD Ground 5c", "BD Ground 6c", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("cseal3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue3", "Igaur", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("3suppressionorange",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(870000, "dseal3"),
                            new ReplaceTile("BD Ground 5a", "BD Ground 6a", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("dseal3",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue3", "Nivitet", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),


                    new State(
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new State("ready3",
                            new Order(90, "Ultra Spiritorb Holder Sentry", "idle"),
                            new Order(90, "Ultra Scorching Wrath Helper", "idle"),
                            new MoveTo(1, 44, 40),
                            new TimedRandomTransition(6000, false, "3suppressionpurple", "3suppressionblue", "3suppressiongreen", "3suppressionorange")
                            ),
                        new State("continue3",
                            new Taunt("NO!"),
                            new ReplaceTile("BD Ground 6a", "BD Ground 5a", 99),
                            new ReplaceTile("BD Ground 6b", "BD Ground 5b", 99),
                            new ReplaceTile("BD Ground 6c", "BD Ground 5c", 99),
                            new ReplaceTile("BD Ground 6d", "BD Ground 5d", 99),
                            new ChangeSize(60, 100),
                            new Flash(0xFFFFFF, 0.5, 6),
                            new TimedTransition(4000, "crawlerphase")
                            ),
                    new State("crawlerphase",
                        new Taunt("I REFUSE TO BE SEALED ONCE AGAIN!"),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TossObject("Ultra Scorching Crawler", 4, 0, coolDown: 9999999),
                        new TossObject("Ultra Scorching Crawler", 4, 45, coolDown: 9999999),
                        new TossObject("Ultra Scorching Crawler", 4, 90, coolDown: 9999999),
                        new TossObject("Ultra Scorching Crawler", 4, 135, coolDown: 9999999),
                        new TossObject("Ultra Scorching Crawler", 4, 180, coolDown: 9999999),
                        new TossObject("Ultra Scorching Crawler", 4, 225, coolDown: 9999999),
                        new TossObject("Ultra Scorching Crawler", 4, 270, coolDown: 9999999),
                        new TossObject("Ultra Scorching Crawler", 4, 315, coolDown: 9999999),

                        new TossObject("Ultra Scorching Crawler", 7, 45, coolDown: 9999999),
                        new TossObject("Ultra Scorching Crawler", 7, 135, coolDown: 9999999),
                        new TossObject("Ultra Scorching Crawler", 7, 225, coolDown: 9999999),
                        new TossObject("Ultra Scorching Crawler", 7, 315, coolDown: 9999999),
                        new TimedTransition(4000, "attack1b")
                        )
                    ),
                    new State(
                        new Reproduce("UltraDrannolTarget", 40, 8, 2000),
                        new TossObject("BD Ultra Bastille Brute", 7, 45, coolDown: 9999999),
                        new TossObject("BD Ultra Bastille Brute", 7, 135, coolDown: 9999999),
                        new TossObject("BD Ultra Bastille Brute", 7, 225, coolDown: 9999999),
                        new TossObject("BD Ultra Bastille Brute", 7, 315, coolDown: 9999999),
                        new Order(90, "Ultra Spiritorb Holder Sentry", "sentry2"),
                        new Order(90, "Ultra Scorching Wrath Helper", "spawn"),
                        new EntitiesNotExistsTransition(99, "thenextone", "Ultra Scorching Crawler"),
                        new Shoot(20, count: 14, projectileIndex: 0, coolDown: 600),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new State("attack1b",
                            new Taunt("YOU SHALL BE CRUSHED!"),
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(1),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 2, shootAngle: 20, projectileIndex: 9, coolDown: 6000),

                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000),
                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60),
                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300),

                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 2600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60, coolDownOffset: 2600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300, coolDownOffset: 2600),

                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 4800),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60, coolDownOffset: 4800),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300, coolDownOffset: 4800),
                        new TimedTransition(8000, "attack1b")
                            ),
                     new State("attack2b",
                            new Prioritize(
                                new Charge(2, 8, coolDown: 6000),
                                new Follow(1),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 80, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 280, coolDownOffset: 1800),
                        new TimedTransition(4000, "attack3b")
                            ),
                       new State("attack3b",
                           new Flash(0xFF0000, 0.25, 6),
                            new Prioritize(
                                new Charge(2.5, 8, coolDown: 6000),
                                new Follow(1.5),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 80, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 280, coolDownOffset: 1800),
                        new TimedTransition(8000, "attack1b")
                            )
                        ),
                      new State(
                        new Reproduce("UltraDrannolTarget", 40, 8, 2000),
                        new DamageTakenTransition(1020000, "ready4"),
                        new Shoot(20, count: 14, projectileIndex: 0, coolDown: 600),
                        new State("thenextone",
                            new Prioritize(
                                new Charge(2, 8, coolDown: 4000),
                                new Follow(1.5),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 2, shootAngle: 20, projectileIndex: 9, coolDown: 6000),

                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000),
                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60),
                        new Shoot(10, count: 1, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300),

                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 2600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60, coolDownOffset: 2600),
                        new Shoot(10, count: 2, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300, coolDownOffset: 2600),

                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, coolDownOffset: 4800),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 60, coolDownOffset: 4800),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 8, coolDown: 2000, angleOffset: 300, coolDownOffset: 4800),
                        new TimedTransition(8000, "thenextone2")
                            ),
                     new State("thenextone2",
                            new Prioritize(
                                new Charge(2, 8, coolDown: 6000),
                                new Follow(1),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1200, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1200, angleOffset: 80, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1200, angleOffset: 280, coolDownOffset: 1800),
                        new TimedTransition(4000, "thenextone3")
                            ),
                       new State("thenextone3",
                           new Flash(0xFF0000, 0.25, 6),
                            new Prioritize(
                                new Charge(4, 8, coolDown: 6000),
                                new Follow(1.7),
                                new Wander(0.1)
                            ),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1400, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1400, angleOffset: 80, coolDownOffset: 1800),
                        new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 8, coolDown: 1400, angleOffset: 280, coolDownOffset: 1800),
                        new TimedTransition(8000, "thenextone")
                            )
                        ),


                    new State("4suppressionpurple",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(1200000, "aseal4"),
                            new ReplaceTile("BD Ground 5d", "BD Ground 6d", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("aseal4",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue4", "Wanzyu", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("4suppressionblue",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(1200000, "bseal4"),
                            new ReplaceTile("BD Ground 5b", "BD Ground 6b", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("bseal4",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue4", "Tareg", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("4suppressiongreen",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(1200000, "cseal4"),
                            new ReplaceTile("BD Ground 5c", "BD Ground 6c", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("cseal4",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue4", "Igaur", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),



                    new State("4suppressionorange",
                            new TimedTransition(10000, "FAILED"),
                            new DamageTakenTransition(1200000, "dseal4"),
                            new ReplaceTile("BD Ground 5a", "BD Ground 6a", 99),
                            new Flash(0xFFFFFF, 0.25, 6)
                            ),
                    new State("dseal4",
                            new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new TimedTransition(10000, "FAILED"),
                            new PlayerTextTransition("continue4", "Nivitet", 20),
                            new Flash(0xFF69B4, 0.5, 6)
                            ),


                     new State(
                          new ConditionalEffect(ConditionEffectIndex.Invincible),
                          new State("ready4",
                            new Order(90, "Ultra Spiritorb Holder Sentry", "idle"),
                            new Order(90, "Ultra Scorching Wrath Helper", "idle"),
                            new MoveTo(1, 44, 40),
                            new TimedRandomTransition(6000, false, "4suppressionpurple", "4suppressionblue", "4suppressiongreen", "4suppressionorange")
                            ),
                        new State("continue4",
                            new Taunt(0.05, "NOOOOOOOOO, I'VE BEEN SPRITED BY BITULOSS!"),
                            new Taunt("Not... again..."),
                            new ReplaceTile("BD Ground 6a", "BD Ground 5a", 99),
                            new ReplaceTile("BD Ground 6b", "BD Ground 5b", 99),
                            new ReplaceTile("BD Ground 6c", "BD Ground 5c", 99),
                            new ReplaceTile("BD Ground 6d", "BD Ground 5d", 99),
                            new ChangeSize(80, 40),
                            new Flash(0xFFFFFF, 0.5, 6),
                            new TimedTransition(4000, "crybaby")
                            ),
                         new State("crybaby",
                            new Flash(0xFFFFFF, 0.2, 8),
                            new BackAndForth(1, 4),
                            new TimedTransition(4000, "suicide")
                            ),
                         new State("suicide",
                            new AnnounceOnDeath("An eternal threat has finally been sealed for another millenia..."),
                            new Suicide()
                            )
                        ),
                     new State(
                         new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new State("FAILED",
                            new Flash(0xFF0000, 0.25, 6),
                            new Taunt("Finally, the seal has been broken... Now you will all suffer!"),
                            new TimedTransition(6000, "byebye")
                            ),
                        new State("byebye",
                            new MoveTo(2, 44, 0),
                            new TimedTransition(8000, "latabih")
                            ),
                        new State("latabih",
                            new Suicide()
                            )
                         )
                    ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLootUltraDrannol()
                ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.004,
                    new TierLoot(7, ItemType.Ring, 0.01),
                    new ItemLoot("Drannol's Judgement", 0.003),
                    new ItemLoot("Bloodstone of Enmity", 0.007),
                    new ItemLoot("Ultimate Onrane Cache", 0.4),
                    new ItemLoot("10000 Gold", 0.2),
                    new ItemLoot("Large Sor Fragment", 0.01),
                    new ItemLoot("Medium Sor Fragment", 0.033),
                    new ItemLoot("Gold Cache", 0.66),
                    new ItemLoot("Vial of Life", 1),
                    new ItemLoot("Vial of Defense", 1),
                    new ItemLoot("Vial of Attack", 0.6),
                    new ItemLoot("Vial of Dexterity", 0.5),
                    new ItemLoot("Vial of Vitality", 0.5),
                    new ItemLoot("Vial of Speed", 0.5),
                    new ItemLoot("Vial of Mana", 0.5),
                    new ItemLoot("Vial of Might", 1),
                    new ItemLoot("Vial of Luck", 1),
                    new ItemLoot("Vial of Restoration", 1),
                    new ItemLoot("Vial of Protection", 1)
                )
            )
;
    }
}