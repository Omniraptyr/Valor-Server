using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Aldragine = () => Behav()
        .Init("Zol Mine",
            new State(
                new State("1",
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 0, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                     new DamageTakenTransition(2500, "2")
                    ),
                new State("2",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new SetAltTexture(1),
                     new Flash(0xFFFFFF, 1, 1),
                     new TimedTransition(2000, "3")
                    ),
                new State("3",
                     new SetAltTexture(1),
                     new Shoot(10, count: 8, projectileIndex: 2, coolDown: 2000),
                     new Suicide()
                    )
                )
            )
        .Init("Beacon of Zol A",
            new State(
                new SetNoXP(),
                new TransformOnDeath("Beacon of Zol B", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new PlayerWithinTransition(3, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
        .Init("Beacon of Zol B",
            new State(
                new SetNoXP(),
                new TransformOnDeath("Beacon of Zol A", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new NoPlayerWithinTransition(3, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
         .Init("ULTRA Beacon of Zol A",
            new State(
                new SetNoXP(),
                new TransformOnDeath("ULTRA Beacon of Zol B", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new PlayerWithinTransition(2, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
        .Init("ULTRA Beacon of Zol B",
            new State(
                new SetNoXP(),
                new TransformOnDeath("ULTRA Beacon of Zol A", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new NoPlayerWithinTransition(2, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
        .Init("Mark of Zol A",
            new State(
                new SetNoXP(),
                new TransformOnDeath("Mark of Zol B", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new PlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
        .Init("Mark of Zol B",
            new State(
                new SetNoXP(),
                new TransformOnDeath("Mark of Zol A", 1, 1, 1),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first",
                     new NoPlayerWithinTransition(1, "suicide2")
                    ),
                new State("suicide2",
                     new Suicide()
                    )
                )
            )
        .Init("A Plate 1",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("first1",
                    new SetAltTexture(0),
                     new PlayerWithinTransition(1, "first")
                    ),
                new State("first",
                     new SetAltTexture(1),
                     new NoPlayerWithinTransition(1, "first1")
                    ),
                new State("ZolCry",
                    new Flash(0x0000FF, 1, 1),
                    new SetAltTexture(1),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1),
                     new TimedTransition(3000, "first1")
                    ),
                new State("suicide3",
                     new Suicide()
                    )
                )
            )
        .Init("Stone of Zol",
            new State(
                new State("1",
                    new Shoot(10, count: 8, projectileIndex: 0, coolDown: 2500),
                     new HpLessTransition(0.15, "2"),
                     new HealSelf(coolDown: 8000)
                    ),
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new State("2",
                     new Flash(0xFF00FF, 1, 1),
                     new TimedTransition(1600, "3")
                    ),
                new State("3",
                     new Shoot(10, count: 12, projectileIndex: 0, coolDown: 9999),
                     new Suicide()
                        )
                    )
                )
            )
        .Init("Giant Cube of Zol",
            new State(
                new State("Default",
                    new EntityExistsTransition("AH The Heart", 50, "Transfer"),
                    new EntityExistsTransition("AH ULTRA The Heart", 50, "Transfer"),
                    new TimedTransition(1000, "Main")
                    ),
                new State("Transfer",
                    new TransferDamageOnDeath("AH The Heart", 50),
                    new TransferDamageOnDeath("AH ULTRA The Heart", 50),
                    new TimedTransition(1000, "Main")
                    ),
                new State("Main",
                    new State("swag1",
                        new Shoot(10, count: 5, shootAngle: 14, projectileIndex: 0, coolDown: new Cooldown(3000, 1000)),
                        new Shoot(10, count: 1, shootAngle: 2, projectileIndex: 1, coolDown: 500),
                        new TimedTransition(5000, "swag2")
                    ),
                    new State("swag2",
                        new TossObject("Cube of Zol", coolDown: 2500),
                        new TimedTransition(5000, "swag1")
                        )
                    )
                )
            )
        .Init("Portal to Eternity",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("swag1",
                     new EntitiesNotExistsTransition(5, "dying", "Corrupted Stone Giant A")
                    ),
                new State("dying",
                     new Flash(0xFF00FF, 1, 2),
                     new TimedTransition(2500, "swag2")
                    ),
                new State("swag2",
                     new Shoot(10, count: 10, projectileIndex: 0, coolDown: 9999),
                     new Suicide()
                    )
                )
            )
        .Init("Demon of the Dark",
            new State(
                new State("Default",
                    new EntityExistsTransition("AH The Heart", 50, "Transfer"),
                    new EntityExistsTransition("AH ULTRA The Heart", 50, "Transfer"),
                    new TimedTransition(1000, "Main")
                    ),
                new State("Transfer",
                    new TransferDamageOnDeath("AH The Heart", 50),
                    new EntityExistsTransition("AH ULTRA The Heart", 50, "Transfer"),
                    new TimedTransition(1000, "Main")
                    ),
                new State("Main",
                    new State("fight1",
                        new Prioritize(
                            new Follow(0.8, 8, 1),
                            new Wander(0.5)
                            ),
                        new Shoot(10, count: 3, shootAngle: 12, projectileIndex: 0, coolDown: 2000),
                        new Shoot(10, count: 7, projectileIndex: 1, coolDown: 6000),
                        new TimedTransition(6800, "fight2")
                        ),
                    new State("fight2",
                        new Prioritize(
                            new Follow(0.5, 8, 1),
                            new Wander(0.5)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 5, projectileIndex: 2, coolDown: 2000),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            )
        .Init("Headless Stone Giant",
            new State(
                new State("fight1",
                    new Prioritize(
                        new Follow(0.2, 8, 1),
                        new Wander(0.2)
                        ),
                     new Shoot(10, count: 6, projectileIndex: 0, coolDown: 3400)
                    )
                )
            )
        .Init("Corrupted Stone Giant B",
            new State(
                new State("Default",
                    new EntityExistsTransition("AH The Heart", 50, "Transfer"),
                    new EntityExistsTransition("AH ULTRA The Heart", 50, "Transfer"),
                    new TimedTransition(1000, "Main")
                    ),
                new State("Transfer",
                    new TransferDamageOnDeath("AH The Heart", 50),
                    new TransferDamageOnDeath("AH ULTRA The Heart", 50),
                    new TimedTransition(1000, "Main")
                    ),
                new State("Main",
                    new TransformOnDeath("Headless Stone Giant", 1, 1, 1),
                    new Orbit(0.15, 3.7, 20),
                    new State("fight1",
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 4200, coolDownOffset: 1000),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 2400, coolDownOffset: 1000),
                        new TimedTransition(5000, "fight2")
                        ),
                    new State("fight2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 4200, coolDownOffset: 1000),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 2400, coolDownOffset: 1000),
                        new TimedTransition(3600, "fight1")
                        )
                    )
                )
            )
        .Init("Corrupted Stone Giant C",
            new State(
                new Grenade(2, 20, 5, coolDown: 3000),
                new TossObject("Servant of Darkness", 5, coolDown: 4000, coolDownOffset: 2000),
                new HealSelf(coolDown: 2000, amount: 1000),
                new TransformOnDeath("Headless Stone Giant", 1, 1, 1),
                new Orbit(0.3, 3, 20),
                new State("fight1",
                     new Shoot(10, count: 5, shootAngle: 12, projectileIndex: 0, coolDown: 4200),
                     new TimedTransition(5000, "fight2")
                    ),
                new State("fight2",
                     new Shoot(10, count: 5, shootAngle: 12, projectileIndex: 0, coolDown: 4200),
                     new TimedTransition(5000, "fight1")
                    )
                )
            )
        .Init("Corrupted Stone Giant A",
            new State(
                new TransformOnDeath("Headless Stone Giant", 1, 1, 1),
                new Grenade(2, 100, range: 6, coolDown: 3000),
                new Orbit(0.45, 3, 20, "Portal to Eternity"),
                new State("fight1",
                     new Shoot(10, count: 5, shootAngle: 8, projectileIndex: 0, coolDown: 1000),
                     new TimedTransition(5000, "fight2")
                    ),
                new State("fight2",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(10, count: 1, projectileIndex: 1, coolDown: 250),
                     new TimedTransition(3000, "fight3")
                    ),
                new State("fight3",
                     new ConditionalEffect(ConditionEffectIndex.Armored),
                     new Shoot(10, count: 16, projectileIndex: 2, coolDown: 1000),
                     new TimedTransition(5000, "fight1")
                    )
                )
            )
        .Init("Haunting Knight",
            new State(
                new ConditionalEffect(ConditionEffectIndex.StunImmune),
                new ConditionalEffect(ConditionEffectIndex.ArmorBreakImmune),
                new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                new State("fight1",
                    new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.2)
                        ),
                     new Shoot(10, count: 8, shootAngle: 22, projectileIndex: 1, coolDown: 5000, coolDownOffset: 3000),
                     new Shoot(10, count: 9, projectileIndex: 0, coolDown: 6000, coolDownOffset: 3000),
                     new TimedTransition(5000, "fight2")
                    ),
                new State("fight2",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new HealSelf(coolDown: 1000),
                     new TimedTransition(2000, "fight1")
                    )
                )
            )
        .Init("Cube of Zol",
            new State(
                new State("Default",
                    new EntityExistsTransition("AH The Heart", 50, "Transfer"),
                    new EntityExistsTransition("AH ULTRA The Heart", 50, "Transfer"),
                    new TimedTransition(1000, "Main")
                    ),
                new State("Transfer",
                    new TransferDamageOnDeath("AH The Heart", 50),
                    new TransferDamageOnDeath("AH ULTRA The Heart", 50),
                    new TimedTransition(1000, "Main")
                    ),
                new State("Main",
                    new State("",
                        new Wander(0.8),
                        new Shoot(8, 1, coolDown: 750)
                        )
                    )
                ),
            new Threshold(0.5,
                new ItemLoot("Mithril Shield", 0.01),
                new ItemLoot("Agateclaw Dagger", 0.01)
                )
            )
          .Init("AH Sincryer Orb",
            new State(
                new State(
                    new Flash(0x00FF00, 0.25, 6),
                    new Shoot(10, count: 6, projectileIndex: 0, coolDown: 1000, coolDownOffset: 3000)
                    )
                )
            )
        .Init("Servant of Darkness",
            new State(
                new State("Default",
                    new EntityExistsTransition("AH The Heart", 50, "Transfer"),
                    new EntityExistsTransition("AH ULTRA The Heart", 50, "Transfer"),
                    new TimedTransition(1000, "Main")
                    ),
                new State("Transfer",
                    new TransferDamageOnDeath("AH The Heart", 50),
                    new TransferDamageOnDeath("AH ULTRA The Heart", 50),
                    new TimedTransition(1000, "Main")
                     ),
                new State("Main",
                    new Wander(1),
                    new State("fight1",
                        new Shoot(10, count: 2, shootAngle: 8, projectileIndex: 0, coolDown: 200),
                        new TimedTransition(4000, "fight2")
                        ),
                    new State("fight2",
                        new Shoot(10, count: 5, projectileIndex: 1, coolDown: 1200),
                        new TimedTransition(4000, "fight1")
                        )
                    )
                )
            )
        .Init("Niolru",
            new State(
                new State("fight1",
                     new Prioritize(
                        new Follow(0.8, 8, 1),
                        new Wander(0.2)
                        ),
                     new Shoot(10, count: 5, shootAngle: 5, projectileIndex: 0, coolDown: 3000),
                     new DamageTakenTransition(3500, "fight2")
                    ),
                new State(
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.4)
                        ),
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                new State("fight2",
                     new ChangeSize(25, 140),
                     new Shoot(10, count: 5, shootAngle: 5, projectileIndex: 1, coolDown: 2400),
                     new TimedTransition(6000, "fight3")
                    ),
                new State("fight3",
                     new Shoot(10, count: 4, projectileIndex: 2, coolDown: 600),
                     new TimedTransition(4000, "fight2")
                        )
                    )
                )
            )
            .Init("Corrupted Entity",
            new State(
                new SetNoXP(),
                new State("omw",
                    new Taunt(0.25, "Yesss....YESSSS......", "I FEEL SO..POWERFUL!", "MY VEINS...THE ZOL COURSES WITHIN THEM!", "Old companions...I AM YOUR NEW MASTER!", "...."),
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new ChangeSize(60, 150),
                     new TimedTransition(6000, "omw2")
                    ),
              new State("omw2",
                  new Flash(0x00FF00, 0.2, 8),
                    new Taunt(0.25, "Time to demonstrate my new powers..", "Come here you fool...", "I've been burdened by you fools for too long..DIE!"),
                     new TimedTransition(2000, "fight2")
                    ),
                new State(
                    new Prioritize(
                        new Follow(1, 8, 1),
                        new Wander(0.4)
                        ),
                        new Shoot(10, count: 1, fixedAngle: 45, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 135, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 225, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 315, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 0, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 90, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 180, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(10, count: 1, fixedAngle: 270, projectileIndex: 1, coolDown: 4000, coolDownOffset: 4000),

                        new Shoot(10, count: 5, shootAngle: 12, projectileIndex: 0, coolDown: 2000, coolDownOffset: 4000),
                new State("fight2",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new TimedTransition(4000, "fight3")
                    ),
                new State("fight3",
                     new HealSelf(2000),
                     new TimedTransition(4000, "fight2")
                        )
                    )
                )
            )
        .Init("Cleric of Zol",
                new State(
                    new Wander(0.6),
                    new HealGroup(10, "Zol", coolDown: 6000, healAmount: 50),
                    new Shoot(12, count: 1, projectileIndex: 0, coolDown: 1000)
                    ),
                new Threshold(0.5,
                    new ItemLoot("Tome of Divine Favor", 0.25)
                    )
            )
        .Init("Zol Sorcerer",
            new State(
                new EntityExistsTransition("AH The Heart", 9999, "fight4"),

                new State("fight1",
                    new Prioritize(
                        new Follow(0.35, 8, 1),
                        new Wander(1)
                        ),
                     new Shoot(10, count: 7, shootAngle: 16, projectileIndex: 0, coolDown: 2000),
                     new TimedTransition(4000, "box")
                    ),
                new State("box",
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                     new Taunt("You should not be here mortal!", "Your fate has already fell at the hands of the Zol!", "LEAVE, {PLAYER}!"),
                     new BackAndForth(0.4, 3),
                     new Shoot(10, count: 6, projectileIndex: 2, coolDown: 2000),
                     new Shoot(10, count: 1, projectileIndex: 0, coolDown: 60),
                     new TimedTransition(4000, "fight2")
                    ),
                new State("fight2",
                    new Prioritize(
                        new StayBack(0.4, 6),
                        new Wander(1)
                        ),
                     new Shoot(10, count: 5, shootAngle: 26, projectileIndex: 1, coolDown: 1000),
                     new TimedTransition(4000, "fight1")
                    ),
                new State("fight4",
                     new TransferDamageOnDeath("AH The Heart"),
                     new Orbit(0.5, 5, 20, "AH The Heart"),
                     new Shoot(10, count: 2, shootAngle: 18, projectileIndex: 0, coolDown: new Cooldown(4000, 2000))
                    )
                )
            )
        .Init("Zol Bomber",
            new State(
                new State("fight1",
                    new Prioritize(
                        new Follow(0.4, 8, 1),
                        new Wander(1)
                        ),
                    new Shoot(10, count: 4, projectileIndex: 1, coolDown: 2000),
                     new TossObject("Zol Mine", range: 7, coolDown: new Cooldown(6200, 4000), coolDownOffset: 2400),
                     new HpLessTransition(0.15, "fight2")
                    ),
                new State(
                    new Follow(1, 8, 1),
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                new State("fight2",
                     new Flash(0xFF0000, 1, 3),
                     new PlayerWithinTransition(2, "ded")
                    ),
                new State("ded",
                     new Shoot(10, count: 12, projectileIndex: 0, coolDown: 9999),
                     new Suicide()
                        )
                    )
                )
            )
        .Init("AH Feral of the Zol",
            new State(
                new State("fight1",
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(0.4, range: 7),
                        new Wander(0.4)
                        ),
                     new Shoot(10, count: 5, shootAngle: 14, projectileIndex: 0, predictive: 1, coolDown: 3000),
                     new TimedTransition(3000, "charging")
                    ),
                 new State("charging",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Taunt("YOU SHALL BE DEVOURED."),
                     new Flash(0xFF0000, 0.25, 4),
                     new Shoot(10, count: 18, projectileIndex: 0, coolDown: 2000),
                     new Charge(speed: 2, range: 10, coolDown: 4000),
                     new TimedTransition(4000, "grr")
                    ),
                new State("grr",
                     new StayBack(0.7, distance: 3),
                     new Shoot(10, count: 8, shootAngle: 20, projectileIndex: 1, coolDown: 400),
                     new Shoot(10, count: 6, projectileIndex: 0, coolDown: 2000),
                     new TimedTransition(4000, "fight2")
                    ),
                new State("fight2",
                     new Wander(0.1),
                     new Shoot(10, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 100),
                     new TimedTransition(4000, "heal")
                    ),
                new State("heal",
                     new HealGroup(1, "Self", coolDown: 2000, healAmount: 500),
                     new Grenade(7, 125, range: 8, coolDown: 1000),
                     new Shoot(10, count: 4, shootAngle: 40, projectileIndex: 0, coolDown: new Cooldown(1000, 500)),
                     new TimedTransition(4000, "fight1")
                    )
                )
            )
         .Init("AH Zol Incarnation",
         new State(
            new State(
                new TimedTransition(8000, "Sneaky"),
                new State("Fight1",
                     new Shoot(4, count: 1, projectileIndex: 1, coolDown: 1),
                     new Prioritize(
                        new Follow(0.6, range: 7),
                        new Wander(0.4)
                     ),
                     new Shoot(10, count: 4, shootAngle: 18, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                     new Shoot(10, count: 4, shootAngle: 18, fixedAngle: 180, projectileIndex: 0, coolDown: 1000),
                     new TimedTransition(2000, "Fight2")
                    ),
                new State("Fight2",
                     new Shoot(4, count: 1, projectileIndex: 1, coolDown: 1),
                     new Prioritize(
                        new Follow(0.6, range: 7),
                        new Wander(0.4)
                     ),
                     new Shoot(10, count: 4, shootAngle: 18, fixedAngle: 90, projectileIndex: 0, coolDown: 1000),
                     new Shoot(10, count: 4, shootAngle: 18, fixedAngle: 270, projectileIndex: 0, coolDown: 1000),
                     new TimedTransition(2000, "Fight1")
                    )
                 ),
                new State("Sneaky",
                     new ChangeSize(10, 0),
                     new Follow(1, range: 7),
                     new TimedTransition(4000, "Reveal")
                    ),
                new State("Reveal",
                     new ConditionalEffect(ConditionEffectIndex.Armored),
                     new Flash(0xFF00FF, 1, 1),
                     new ChangeSize(10, 130),
                     new Shoot(10, count: 6, projectileIndex: 1, coolDown: 2000),
                     new Orbit(1, 3, target: null, orbitClockwise: true),
                     new TimedTransition(4000, "Fight1")
                    )
                )
            )
         .Init("AH Ultra Zol Turret",
            new State(
                new TransformOnDeath("AH Ultra Zol Turret Disabled", 1, 1, 1),
                new SetNoXP(),
                new State("switch1",
                     new Shoot(8, count: 2, shootAngle: 90, projectileIndex: 0, coolDown: 4000),
                     new Shoot(8, count: 2, shootAngle: 0, projectileIndex: 0, coolDown: 4000, coolDownOffset: 2000),
                     new DamageTakenTransition(25000, "switch2")
                    ),
                new State("switch2",
                     new Suicide()
                    )
                 )
              )
         .Init("AH Ultra Zol Turret Disabled",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new TransformOnDeath("AH Ultra Zol Turret", 1, 1, 1),
                new SetNoXP(),
                new State("switch",
                     new Flash(0xFF00FF, 1, 1),
                     new TimedTransition(6000, "die")
                    ),
                new State("die",
                     new Suicide()
                    )
                 )
              )
        .Init("Brute of the Hideout",
                new State(
                    new State("Default",
                        new EntityExistsTransition("AH The Heart", 50, "Transfer"),
                        new EntityExistsTransition("AH ULTRA The Heart", 50, "Transfer"),
                        new TimedTransition(1000, "Main")
                        ),
                    new State("Transfer",
                        new TransferDamageOnDeath("AH The Heart", 50),
                        new TransferDamageOnDeath("AH ULTRA The Heart", 50),
                        new TimedTransition(1000, "Main")
                        ),
                    new State("Main",
                        new Prioritize(
                            new Follow(1, 8, 1),
                            new Wander(0.4)
                            ),
                        new Shoot(8, 1, coolDown: 100)
                        )
                    ),
                new Threshold(0.5,
                    new ItemLoot("Ring of Exalted Vitality", 0.01)
                    )
            )
         .Init("AH Battlemage of the Zol",
                new State(
                    new Shoot(8, count: 1, projectileIndex: 2, coolDown: new Cooldown(2000, 1000)),
                    new Shoot(8, count: 6, projectileIndex: 3, coolDown: 3000),
                    new State("Default",
                        new Wander(0.1),
                        new Shoot(8, count: 2, shootAngle: 6, projectileIndex: 0, coolDown: new Cooldown(600, 1000)),
                        new PlayerWithinTransition(3, "Shotgun")
                        ),
                    new State("Shotgun",
                        new Prioritize(
                            new Follow(1.5, 8, 1),
                            new Wander(0.25)
                        ),
                        new Taunt(0.50, "I call upon the great Zol to EMPOWER ME!", "You'll be eradicated quickly, fiend."),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new Shoot(8, count: 3, shootAngle: 8, projectileIndex: 1, predictive: 1, coolDown: 1000),
                        new Shoot(8, count: 4, projectileIndex: 3, coolDown: 600),
                        new TimedTransition(3000, "Default2")
                        ),
                    new State("Default2",
                        new Shoot(8, count: 6, shootAngle: 18, projectileIndex: 0, coolDown: new Cooldown(1200, 2000)),
                        new Shoot(8, count: 8, projectileIndex: 1, coolDown: 400),
                        new TimedTransition(4600, "Default")
                        )
                    ),
                new Threshold(0.5,
                    new ItemLoot("Bow of Innocent Blood", 0.02),
                    new ItemLoot("Abyssal Armor", 0.02)
                    )
            )
            .Init("AH ULTRA Aldragine Clone",
                new State(
                    new SetNoXP(),
                    new SetAltTexture(1),
                    new Orbit(0.3, 4, 8, target: "AH ULTRA Aldragine"),
                    new State("Shotgun",
                        new Shoot(8, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(1000, "Shotgun2")
                        ),
                    new State("Shotgun2",
                        new Shoot(8, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(1000, "Shotgun2")
                        )
                    )
                )
        .Init("AH Big Purple Slime",
                new State(
                    new Shoot(10, 3, shootAngle: 10, coolDown: 1400),
                    new Wander(0.1),
                    new TransformOnDeath("AH Little Purple Slime", 1, 6, 1)
                    )
            )
        .Init("AH Little Purple Slime",
                new State(
                    new Shoot(10, 1, shootAngle: 10, coolDown: 700),
                    new Wander(0.1)
                    )
            )
        .Init("Aldragine TaskMaster 1",
            new State(
                new DropPortalOnDeath("Sincryer's Gate Portal", 100, timeout: 180),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new EntitiesNotExistsTransition(9999, "activate", "Portal to Eternity")
                    ),
                new State("activate",
                     new Suicide()
                    )
                )
            )
                .Init("AH Ultra Sincryer Gate Opener",
            new State(
                new DropPortalOnDeath("Ultra The Nontridus Portal", 100, timeout: 180),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new EntitiesNotExistsTransition(9999, "activate", "AH Ultra The Sincryer")
                    ),
                new State("activate",
                     new Suicide()
                    )
                )
            )
            .Init("AH Sincryer Gate Opener",
            new State(
                new DropPortalOnDeath("The Nontridus Portal", 100, timeout: 180),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new EntitiesNotExistsTransition(9999, "activate", "AH The Sincryer")
                    ),
                new State("activate",
                     new Suicide()
                    )
                )
            )
        .Init("Aldragine TaskMaster Ultra",
            new State(
                new DropPortalOnDeath("Ultra Sincryer's Gate Portal", 100, timeout: 180),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new EntitiesNotExistsTransition(9999, "activate", "Portal to Eternity")
                    ),
                new State("activate",
                     new Suicide()
                    )
                )
            )
        .Init("AH The Sincryer",
                new State(
                    new DropPortalOnDeath("The Nontridus Portal", 100, timeout: 180),
                    new ScaleHP(35000),
                    new HpLessTransition(0.14, "spookded"),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntitiesNotExistsTransition(9999, "talk1", "Stone of Zol")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("talk1",
                        new Taunt("Revealing the power of Zol can't be returned.", "The Zol is everywhere... You've released evil upon yourself."),
                        new TimedTransition(5000, "talk2")
                        ),
                    new State("talk2",
                        new Taunt("You have made a grave mistake."),
                        new TimedTransition(5000, "talk3")
                        ),
                    new State("talk3",
                        new Taunt("Now, this mistake is your end."),
                        new TimedTransition(5000, "talk4")
                        ),
                    new State("talk4",
                        new Taunt("Perish."),
                        new TimedTransition(5000, "go")
                        )
                      ),
                    new State("go",
                        new Prioritize(
                            new Follow(0.8, 8, 1),
                            new Wander(1)
                            ),
                        new Shoot(8, count: 14, shootAngle: 20, projectileIndex: 4, coolDown: 600),
                        new Shoot(8, count: 3, shootAngle: 10, projectileIndex: 1, predictive: 2, coolDown: 1600),
                        new TimedTransition(9000, "go2")
                        ),
                    new State("go2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Prioritize(
                            new StayBack(0.4, 4),
                            new Swirl(1, 10)
                            ),
                        new Shoot(12, count: 6, shootAngle: 4, predictive: 1, projectileIndex: 0, coolDown: 1),
                        new Shoot(8, count: 10, projectileIndex: 2, coolDown: new Cooldown(2000, 1000)),
                        new TimedTransition(9000, "spook")
                        ),
                    new State("spook",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(1),
                        new TimedTransition(3000, "go3")
                        ),
                    new State("go3",
                        new Taunt("They fight with their lives!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Zol Bomber", 6, 0, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 45, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 90, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 135, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 180, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 225, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 270, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 315, coolDown: 9999999),
                        new TossObject("Zol Bomber", 9, 0, coolDown: 9999999),
                        new TossObject("Zol Bomber", 9, 90, coolDown: 9999999),
                        new TossObject("Zol Bomber", 9, 180, coolDown: 9999999),
                        new TossObject("Zol Bomber", 9, 270, coolDown: 9999999),
                        new TimedTransition(3200, "checkforbombers")
                        ),
                    new State("checkforbombers",
                        new Shoot(10, count: 9, shootAngle: 8, projectileIndex: 3, coolDownOffset: 1100, angleOffset: 270, coolDown: 3000),
                        new Shoot(10, count: 9, shootAngle: 8, projectileIndex: 3, coolDownOffset: 1100, angleOffset: 90, coolDown: 3000),
                        new Shoot(12, count: 5, shootAngle: 12, projectileIndex: 4, coolDown: 1000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntitiesNotExistsTransition(9999, "tauntu", "Zol Bomber")
                        ),
                    new State("tauntu",
                        new Taunt("Your life now belongs to me."),
                        new TimedTransition(4000, "swag21")
                        ),
                    new State("swag21",
                        new Flash(0x0F0F0F, 2, 2),
                        new Grenade(4, 300, coolDown: 3000),
                        new Shoot(12, count: 10, shootAngle: 4, predictive: 1, projectileIndex: 0, coolDown: 1),
                        new Prioritize(
                            new Charge(2, 10, coolDown: 4000),
                            new Wander(0.2)
                            ),
                        new Shoot(12, count: 12, projectileIndex: 2, coolDown: 4000),
                        new TimedTransition(12000, "basic2")
                        ),
                    new State("basic2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Prioritize(
                            new Follow(0.6),
                            new Wander(0.2)
                            ),
                        new Shoot(8, count: 4, projectileIndex: 4, coolDown: 400),
                        new Shoot(8, count: 6, projectileIndex: 4, coolDown: 1400),
                        new Shoot(12, count: 18, projectileIndex: 0, coolDown: 2500),
                        new TimedTransition(5000, "basic3")
                        ),
                    new State("basic3",
                        new Wander(0.4),
                        new Shoot(8, count: 10, projectileIndex: 4, coolDown: 1000),
                        new Shoot(12, count: 6, shootAngle: 8, projectileIndex: 2, coolDown: 2200),
                        new TossObject("AH Big Purple Slime", range: 4, coolDown: 2500),
                        new TimedTransition(5000, "cryofsin")
                        ),
                    new State("cryofsin",
                        new Taunt(true, "THE TIME IS NOW!", "A SERENADE FOR YOUR DOOM!"),
                        new Flash(0xFF0000, 1, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(1),
                        new TimedTransition(4400, "cry")
                        ),
                    new State("cry",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Al lar kall zanus du era!", "Rul ah ka tera nol zan!"),
                        new Shoot(30, count: 34, projectileIndex: 0, coolDown: 1000),
                        new ReplaceTile("Zol Aura Dormant", "Zol Aura", 250),
                        new TimedTransition(8000, "gofirst")
                        ),
                    new State("gofirst",
                        new HealSelf(coolDown: 1000, amount: 10000),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Prioritize(
                            new Follow(1.2),
                            new Wander(0.2)
                            ),
                        new TossObject("AH Sincryer Orb", range: 10, coolDown: 1000),
                        new ReplaceTile("Zol Aura", "Zol Aura Dormant", 250),
                        new Shoot(8, count: 4, projectileIndex: 4, coolDown: 400),
                        new Shoot(8, count: 6, projectileIndex: 4, coolDown: 1400),
                        new Shoot(12, count: 18, projectileIndex: 0, coolDown: 2500),
                        new TimedTransition(5000, "go")
                        ),
                    new State("spookded",
                        new Flash(0x00FF00, 1, 3),
                        new Taunt("YOU WILL NOT SURVIVE THE ONSLAUGHT OF THE ZOL!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(1),
                        new TimedTransition(6000, "ded")
                        ),
                    new State("ded",
                        new Suicide()
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLootZol()
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor4Perc()
                    ),
                    new Threshold(0.1,
                       new ItemLoot("Onrane Cache", 0.015),
                       new ItemLoot("Gold Cache", 0.07),
                       new ItemLoot("Vial of Life", 1),
                       new ItemLoot("Vial of Mana", 1)
                       )
            )
           .Init("AH ULTRA The Sincryer",
                new State(
                    new DropPortalOnDeath("Ultra The Nontridus Portal", 100, timeout: 180),
                    new ScaleHP(125000),
                    new HpLessTransition(0.14, "spookded"),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new EntitiesNotExistsTransition(9999, "talk1", "Stone of Zol")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("talk1",
                        new Taunt("The Zol grows stronger night by night... Can you not see your failure already?"),
                        new TimedTransition(5000, "talk2")
                        ),
                    new State("talk2",
                        new Taunt("You have once again made a grave mistake."),
                        new TimedTransition(5000, "talk3")
                        ),
                    new State("talk3",
                        new Taunt("Now, this mistake will be your end."),
                        new TimedTransition(5000, "talk4")
                        ),
                    new State("talk4",
                        new Taunt("PERISH!"),
                        new TimedTransition(5000, "go")
                        )
                      ),
                    new State(
                        new Shoot(12, count: 1, projectileIndex: 5, coolDown: 6000),
                        new Shoot(12, count: 2, shootAngle: 8, projectileIndex: 5, coolDown: 6000, coolDownOffset: 1000),
                        new Shoot(12, count: 3, shootAngle: 10, projectileIndex: 5, coolDown: 6000, coolDownOffset: 2000),
                    new State("go",
                        new Prioritize(
                            new Follow(0.8, 8, 1),
                            new Wander(1)
                            ),
                        new Shoot(8, count: 14, shootAngle: 20, projectileIndex: 4, coolDown: 600),
                        new Shoot(8, count: 3, shootAngle: 10, projectileIndex: 1, predictive: 2, coolDown: 1600),
                        new TimedTransition(9000, "go2")
                        ),
                    new State("go2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Prioritize(
                            new StayBack(0.4, 4),
                            new Swirl(1, 10)
                            ),
                        new Shoot(12, count: 6, shootAngle: 4, predictive: 1, projectileIndex: 0, coolDown: 1),
                        new Shoot(8, count: 10, projectileIndex: 2, coolDown: new Cooldown(2000, 1000)),
                        new TimedTransition(9000, "spook")
                        ),
                    new State("spook",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(1),
                        new TimedTransition(3000, "go3")
                        ),
                    new State("go3",
                        new Taunt("They fight with their lives!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Zol Bomber", 6, 0, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 45, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 90, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 135, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 180, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 225, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 270, coolDown: 9999999),
                        new TossObject("Zol Bomber", 6, 315, coolDown: 9999999),
                        new TossObject("Zol Bomber", 9, 0, coolDown: 9999999),
                        new TossObject("Zol Bomber", 9, 90, coolDown: 9999999),
                        new TossObject("Zol Bomber", 9, 180, coolDown: 9999999),
                        new TossObject("Zol Bomber", 9, 270, coolDown: 9999999),
                        new TossObject("AH Zol Incarnation", 6, 0, coolDown: 9999999),
                        new TossObject("AH Zol Incarnation", 6, 90, coolDown: 9999999),
                        new TossObject("AH Zol Incarnation", 6, 180, coolDown: 9999999),
                        new TossObject("AH Zol Incarnation", 6, 270, coolDown: 9999999),
                        new TimedTransition(3200, "checkforbombers")
                        ),
                    new State("checkforbombers",
                        new Shoot(10, count: 9, shootAngle: 8, projectileIndex: 3, coolDownOffset: 1100, angleOffset: 270, coolDown: 3000),
                        new Shoot(10, count: 9, shootAngle: 8, projectileIndex: 3, coolDownOffset: 1100, angleOffset: 90, coolDown: 3000),
                        new Shoot(12, count: 5, shootAngle: 12, projectileIndex: 4, coolDown: 1000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntitiesNotExistsTransition(9999, "tauntu", "Zol Bomber")
                        ),
                    new State("tauntu",
                        new Taunt("Your life now belongs to me and me only!"),
                        new TimedTransition(4000, "swag21")
                        ),
                    new State("swag21",
                        new Flash(0x0F0F0F, 2, 2),
                        new Grenade(4, 300, coolDown: 3000),
                        new Shoot(12, count: 10, shootAngle: 4, predictive: 1, projectileIndex: 0, coolDown: 1),
                        new Prioritize(
                            new Charge(2, 10, coolDown: 4000),
                            new Wander(0.2)
                            ),
                        new Shoot(12, count: 18, projectileIndex: 2, coolDown: 4000),
                        new TimedTransition(12000, "basic2")
                        ),
                    new State("basic2",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Prioritize(
                            new Follow(0.6),
                            new Wander(0.2)
                            ),
                        new Shoot(8, count: 4, projectileIndex: 4, coolDown: 400),
                        new Shoot(8, count: 6, projectileIndex: 4, coolDown: 1400),
                        new Shoot(12, count: 18, projectileIndex: 0, coolDown: 2500),
                        new TimedTransition(5000, "basic3")
                        ),
                    new State("basic3",
                        new Wander(0.4),
                        new Shoot(8, count: 12, projectileIndex: 4, coolDown: 1000),
                        new Shoot(12, count: 6, shootAngle: 8, projectileIndex: 2, coolDown: 2200),
                        new TossObject("AH Big Purple Slime", range: 4, coolDown: 2500),
                        new TimedTransition(5000, "cryofsin")
                        ),
                    new State("cryofsin",
                        new Taunt(true, "THE TIME IS NOW!", "A SERENADE FOR YOUR DOOM!"),
                        new Flash(0xFF0000, 1, 2),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new ReturnToSpawn(1),
                        new TimedTransition(4400, "cry")
                        ),
                    new State("cry",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Al lar kall zanus du era!", "Rul ah ka tera nol zan!"),
                        new Shoot(30, count: 34, projectileIndex: 0, coolDown: 1000),
                        new ReplaceTile("Zol Aura Dormant", "Zol Aura", 250),
                        new TimedTransition(8000, "gofirst")
                        ),
                    new State("gofirst",
                        new HealSelf(coolDown: 1000, amount: 10000),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Prioritize(
                            new Follow(1.2),
                            new Wander(0.2)
                            ),
                        new TossObject("AH Sincryer Orb", range: 10, coolDown: 1000),
                        new ReplaceTile("Zol Aura", "Zol Aura Dormant", 250),
                        new Shoot(8, count: 4, projectileIndex: 4, coolDown: 400),
                        new Shoot(8, count: 6, projectileIndex: 4, coolDown: 1400),
                        new Shoot(12, count: 18, projectileIndex: 0, coolDown: 2500),
                        new TimedTransition(5000, "go")
                        )
                    ),
                    new State("spookded",
                        new Flash(0x00FF00, 1, 3),
                        new Taunt("YOU WILL NOT SURVIVE THE ONSLAUGHT OF THE ZOL!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(1),
                        new TimedTransition(6000, "ded")
                        ),
                    new State("ded",
                        new Suicide()
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLootZolUltra()
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                    new Threshold(0.1,
                       new TierLoot(7, ItemType.Ring, 0.0011),
                       new ItemLoot("Onrane Cache", 0.2),
                       new ItemLoot("Gold Cache", 0.1),
                       new ItemLoot("Vial of Life", 1),
                       new ItemLoot("Vial of Mana", 1)
                       )
            )
            .Init("AH Heart Portal Spawner",
                new State(
                   new DropPortalOnDeath("Keeping of Aldragine Portal", timeout: 60),
                   new State("Default",
                       new Suicide()
                       )
                   )
            )
           .Init("AH ULTRA Heart Portal Spawner",
                new State(
                   new DropPortalOnDeath("Ultra Keeping of Aldragine Portal", timeout: 60),
                   new State("Default",
                       new Suicide()
                       )
                   )
            )
           .Init("AH Heart Loot Ctrl",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("Idle",
                        new EntityNotExistsTransition("AH The Heart", 50, "Loot")
                        ),
                    new State("Loot",
                        new Suicide()
                        )
                ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLootZol()
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.1,
                new TierLoot(7, ItemType.Ring, 0.003),
                new ItemLoot("Onrane Cache", 0.1),
                new ItemLoot("Gold Cache", 0.3),
                new ItemLoot("Wisdom Eon", 0.01),
                new ItemLoot("Attack Eon", 0.01),
                new ItemLoot("Vial of Life", 1),
                new ItemLoot("Vial of Mana", 1),
                new ItemLoot("Vial of Defense", 1),
                new ItemLoot("Vial of Attack", 0.6),
                new ItemLoot("Vial of Dexterity", 0.5),
                new ItemLoot("Vial of Vitality", 0.5),
                new ItemLoot("Vial of Wisdom", 0.5),
                new ItemLoot("Vial of Speed", 0.5)
                )
            )
           .Init("AH ULTRA Heart Loot Ctrl",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("Idle",
                        new EntityNotExistsTransition("AH ULTRA The Heart", 50, "Loot")
                        ),
                    new State("Loot",
                        new Suicide()
                        )
                ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLootZolUltra()
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.1,
                new TierLoot(7, ItemType.Ring, 0.0033),
                new ItemLoot("Onrane Cache", 0.2),
                new ItemLoot("Gold Cache", 0.5),
                new ItemLoot("Wisdom Eon", 0.02),
                new ItemLoot("Attack Eon", 0.02),
                new ItemLoot("Vial of Life", 1),
                new ItemLoot("Vial of Mana", 1),
                new ItemLoot("Vial of Defense", 1),
                new ItemLoot("Vial of Attack", 1),
                new ItemLoot("Vial of Dexterity", 1),
                new ItemLoot("Vial of Vitality", 1),
                new ItemLoot("Vial of Wisdom", 1),
                new ItemLoot("Vial of Speed", 1)
                )
            )
            /*.Init("AH TZol Portal Spawner",
                new State(
                   new DropPortalOnDeath("Treasure of Zol Portal", timeout: 60),
                   new State("Default",
                       new TimedTransition(3000, "Spawn")
                       ),
                   new State("Spawn",
                       new Suicide()
                       )
                   )
            )*/
            .Init("AH Aldragine Loot Ctrl",
                new State(
                    //new TransformOnDeath("AH TZol Portal Spawner"),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("Idle",
                        new EntityNotExistsTransition("AH Aldragine", 50, "Loot")
                        ),
                    new State("Loot",
                        new Suicide()
                        )
                ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLoot1()
                ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.1,
                    new TierLoot(7, ItemType.Ring, 0.0033),
                    new ItemLoot("Spiritclaw", 0.001),
                    new ItemLoot("Zol Elixir", 0.003),
                    new ItemLoot("Ultimate Onrane Cache", 0.3),
                    new ItemLoot("The Stronghold Key", 0.01),
                    new ItemLoot("10000 Gold", 0.1),
                    new ItemLoot("Vial of Life", 1),
                    new ItemLoot("Vial of Defense", 1),
                    new ItemLoot("Vial of Attack", 0.6),
                    new ItemLoot("Vial of Dexterity", 0.5),
                    new ItemLoot("Vial of Vitality", 0.5),
                    new ItemLoot("Vial of Wisdom", 0.5),
                    new ItemLoot("Vial of Speed", 0.5),
                    new ItemLoot("Vial of Mana", 0.5)
                )
            )
        .Init("AH ULTRA Aldragine Loot Ctrl",
                new State(
                    //new TransformOnDeath("AH TZol Portal Spawner"),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("Idle",
                        new EntityNotExistsTransition("AH ULTRA Aldragine", 50, "Loot")
                        ),
                    new State("Loot",
                        new Suicide()
                        )
                ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLootUltra()
                ),
                new Threshold(0.1,
                    new TierLoot(7, ItemType.Ring, 0.1),
                    new ItemLoot("Spiritclaw", 0.003),
                    new ItemLoot("Zol Elixir", 0.007),
                    new ItemLoot("Sor Fragment Cache", 0.1),
                    new ItemLoot("Ultimate Onrane Cache", 0.33),
                    new ItemLoot("The Stronghold Key", 0.01),
                    new ItemLoot("10000 Gold", 0.15),
                    new ItemLoot("Vial of Life", 1),
                    new ItemLoot("Vial of Defense", 1),
                    new ItemLoot("Vial of Attack", 1),
                    new ItemLoot("Vial of Dexterity", 1),
                    new ItemLoot("Vial of Vitality", 1),
                    new ItemLoot("Vial of Wisdom", 1),
                    new ItemLoot("Vial of Speed", 1),
                    new ItemLoot("Vial of Mana", 1)
                )
            )
        .Init("AH Secret Chest",
                new State(
                    new ScaleHP(10000),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                new Threshold(0.15,
                new ItemLoot("Gold Cache", 0.35),
                new ItemLoot("Onrane", 1),
                new ItemLoot("Onrane Cache", 0.08),
                new ItemLoot("Robe of Wrath", 0.25)
                )
            )
        .Init("Construct of Zol",
            new State(
                new TransformOnDeath("Niolru", 4, 6, 1),
                new Orbit(0.2, 6, 20, "AH The Vision of Aldragine"),
                new Orbit(0.2, 6, 20, "AH Ultra The Vision of Aldragine"),
                new State("1",
                     new Shoot(12, count: 6, projectileIndex: 0, coolDown: 3800, coolDownOffset: 2000),
                     new HpLessTransition(0.15, "explode"),
                     new HealGroup(10, "ZolBoss", coolDown: new Cooldown(4000, 1500), healAmount: 1500)
                    ),
                new State("explode",
                     new Shoot(12, count: 3, projectileIndex: 0, coolDown: 2500),
                     new Suicide()
                    )
                )
            )
       .Init("AH Aura Controller",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("Deactivate",
                    new ReplaceTile("Zol Aura", "Zol Aura Dormant", 250),
                    new TimedTransition(5000, "Activate")
                    ),
                new State("Activate",
                    new ReplaceTile("Zol Aura Dormant", "Zol Aura", 250),
                    new TimedTransition(5000, "Deactivate")
                    )
                )
            )
        .Init("AH The Vision of Aldragine",
                new State(
                    new ScaleHP(50000),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new DropPortalOnDeath("Core of the Hideout Portal", 100, timeout: 180),
                    new HpLessTransition(0.15, "spookded"),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("callout",
                        new RemoveConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt(true, "He will fulfill the destiny in store. Come. Let me show you his vision.", "Even the ancients, the controllers, and Oryx himself fear us. Share that fear with them.", "Courage can only take you so far."),
                        new PlayerWithinTransition(8, "start")
                        ),
                    new State("start",
                        new Flash(0xFF0000, 2, 2),
                        new TimedTransition(4000, "talk")
                        ),
                    new State("talk",
                        new Taunt("They say the Zol was only a Myth...what fools....."),
                        new TimedTransition(6500, "SummonConstructs")
                        )
                      ),
                    new State("SummonConstructs",
                        new Taunt("You can't withstand the Zol."),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TossObject("Construct of Zol", 6, 270, coolDown: 9999999),
                        new TossObject("Construct of Zol", 6, 90, coolDown: 9999999),
                        new TimedTransition(2000, "grenade1")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(12, count: 3, shootAngle: 18, projectileIndex: 0, coolDown: 800),
                        new Shoot(11, count: 2, projectileIndex: 3, coolDown: 1600),
                        new EntitiesNotExistsTransition(999, "nextfam", "Construct of Zol"),
                    new State("grenade1",
                        new Shoot(8.4, count: 5, shootAngle: 10, fixedAngle: 0, projectileIndex: 1, coolDown: 1200),
                        new TimedTransition(2400, "grenade2")
                            ),
                        new State("grenade2",
                        new Shoot(8.4, count: 5, shootAngle: 10, fixedAngle: 90, projectileIndex: 1, coolDown: 1200),
                        new TimedTransition(2400, "grenade3")
                            ),
                        new State("grenade3",
                        new Shoot(8.4, count: 5, shootAngle: 10, fixedAngle: 180, projectileIndex: 1, coolDown: 1200),
                        new TimedTransition(2400, "grenade4")
                            ),
                        new State("grenade4",
                        new Shoot(8.4, count: 5, shootAngle: 10, fixedAngle: 270, projectileIndex: 1, coolDown: 1200),
                        new TimedTransition(2400, "grenade1")
                            )
                        ),
                    new State("nextfam",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Flash(0xFFFFFF, 1, 2),
                        new Shoot(8.4, count: 6, projectileIndex: 0, coolDown: 1200),
                        new TimedTransition(5000, "Quadforce1")
                        ),
                   new State(
                       new Shoot(12, count: 1, predictive: 1.5, projectileIndex: 2, coolDown: 1000),
                       new TimedTransition(8000, "nextfam2"),
                    new State("Quadforce1",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 0, coolDown: 50),
                            new TimedTransition(100, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 15, coolDown: 50),
                            new TimedTransition(100, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 30, coolDown: 50),
                            new TimedTransition(100, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 45, coolDown: 50),
                            new TimedTransition(100, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 45, coolDown: 50),
                            new TimedTransition(100, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 30, coolDown: 50),
                            new TimedTransition(100, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 15, coolDown: 50),
                            new TimedTransition(100, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 0, coolDown: 50),
                            new TimedTransition(100, "Quadforce1")
                        )
                     ),
                    new State("nextfam2",
                        new HealSelf(coolDown: 2500, amount: 50000),
                        new Taunt("Your essence is mine!"),
                        new TossObject("Demon of the Dark", 9, 0, coolDown: 9999999),
                        new TossObject("Demon of the Dark", 9, 90, coolDown: 9999999),
                        new TossObject("Demon of the Dark", 9, 180, coolDown: 9999999),
                        new TossObject("Demon of the Dark", 9, 270, coolDown: 9999999),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFFFFFF, 1, 2),
                        new TimedTransition(5000, "AuraofZol")
                        ),
                    new State("AuraofZol",
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new Shoot(11, count: 5, projectileIndex: 3, coolDown: 50),
                        new Shoot(11, count: 4, shootAngle: 12, projectileIndex: 4, coolDown: 1500),
                        new TimedTransition(8000, "nextfam3")
                        ),
                    new State("nextfam3",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Flash(0xFFFFFF, 1, 2),
                        new Shoot(8.4, count: 12, projectileIndex: 0, coolDown: 1200),
                        new TimedTransition(5000, "nextfam4")
                        ),
                    new State("nextfam4",
                        new Shoot(8.4, count: 6, projectileIndex: 0, coolDown: 1200),
                        new Shoot(8.4, count: 5, projectileIndex: 2, coolDown: 600),
                        new Shoot(8.4, count: 7, shootAngle: 10, projectileIndex: 1, coolDown: 1600),
                        new Shoot(8.4, count: 3, shootAngle: 2, projectileIndex: 2, coolDown: 1600, coolDownOffset: 500),
                        new TimedTransition(6400, "SummonConstructs")
                        ),
                    new State("spookded",
                        new Flash(0xF0FFF0, 1, 3),
                        new Taunt("....Have I not succeeded this time?", "Aaah..so you don't see it?", "Will the vision finally be broken?"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(1),
                        new TimedTransition(6000, "ded")
                        ),
                    new State("ded",
                        new Suicide()
                        )
                    ),
               new MostDamagers(3,
                    LootTemplates.FabledItemsLootZol()
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                    new Threshold(0.1,
                        new TierLoot(7, ItemType.Ring, 0.003),
                        new ItemLoot("Onrane Cache", 0.5),
                        new ItemLoot("Gold Cache", 0.3),
                        new ItemLoot("Vial of Life", 1),
                        new ItemLoot("Vial of Defense", 1),
                        new ItemLoot("Vial of Attack", 0.6),
                        new ItemLoot("Vial of Dexterity", 0.6),
                        new ItemLoot("Vial of Vitality", 0.5),
                        new ItemLoot("Vial of Wisdom", 0.5)
                )
            )
        .Init("AH ULTRA The Vision of Aldragine",
                new State(
                    new ScaleHP(125000),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new DropPortalOnDeath("Ultra Core of the Hideout Portal", 100, timeout: 180),
                    new HpLessTransition(0.15, "spookded"),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("callout",
                        new RemoveConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt(true, "He will fulfill the destiny in store. Come. Let me show you his vision.", "Even the ancients, the controllers, and Oryx himself fear us. Share that fear with them.", "Courage can only take you so far."),
                        new PlayerWithinTransition(8, "start")
                        ),
                    new State("start",
                        new Flash(0xFF0000, 2, 2),
                        new TimedTransition(4000, "talk")
                        ),
                    new State("talk",
                        new Taunt("They say the Zol was only a Myth... what fools... it's always been no mystery to you though..."),
                        new TimedTransition(6500, "SummonConstructs")
                        )
                      ),
                    new State(
                        new Shoot(14, count: 2, projectileIndex: 5, predictive: 1, coolDown: new Cooldown(4000, 2000)),
                        new Grenade(4, 200, range: 8, coolDown: 8000, effect: ConditionEffectIndex.Quiet, effectDuration: 6, color: 8388736),
                    new State("SummonConstructs",
                        new Taunt("You can't withstand the Zol."),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TossObject("Construct of Zol", 6, 270, coolDown: 9999999),
                        new TossObject("Construct of Zol", 6, 90, coolDown: 9999999),
                        new TimedTransition(2000, "grenade1")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(12, count: 3, shootAngle: 18, projectileIndex: 0, coolDown: 800),
                        new Shoot(11, count: 2, projectileIndex: 3, coolDown: 1600),
                        new EntitiesNotExistsTransition(999, "nextfam", "Construct of Zol"),
                    new State("grenade1",
                        new Shoot(8.4, count: 5, shootAngle: 10, fixedAngle: 0, projectileIndex: 1, coolDown: 1200),
                        new TimedTransition(2400, "grenade2")
                            ),
                        new State("grenade2",
                        new Shoot(8.4, count: 5, shootAngle: 10, fixedAngle: 90, projectileIndex: 1, coolDown: 1200),
                        new TimedTransition(2400, "grenade3")
                            ),
                        new State("grenade3",
                        new Shoot(8.4, count: 5, shootAngle: 10, fixedAngle: 180, projectileIndex: 1, coolDown: 1200),
                        new TimedTransition(2400, "grenade4")
                            ),
                        new State("grenade4",
                        new Shoot(8.4, count: 5, shootAngle: 10, fixedAngle: 270, projectileIndex: 1, coolDown: 1200),
                        new TimedTransition(2400, "grenade1")
                            )
                        ),
                    new State("nextfam",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Flash(0xFFFFFF, 1, 2),
                        new Shoot(8.4, count: 6, projectileIndex: 0, coolDown: 1200),
                        new TimedTransition(5000, "Quadforce1")
                        ),
                   new State(
                       new Shoot(12, count: 1, predictive: 1.5, projectileIndex: 2, coolDown: 1000),
                       new TimedTransition(8000, "nextfam2"),
                    new State("Quadforce1",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 0, coolDown: 50),
                            new TimedTransition(100, "Quadforce2")
                        ),
                        new State("Quadforce2",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 15, coolDown: 50),
                            new TimedTransition(100, "Quadforce3")
                        ),
                        new State("Quadforce3",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 30, coolDown: 50),
                            new TimedTransition(100, "Quadforce4")
                        ),
                        new State("Quadforce4",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 45, coolDown: 50),
                            new TimedTransition(100, "Quadforce5")
                        ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 45, coolDown: 50),
                            new TimedTransition(100, "Quadforce6")
                        ),
                        new State("Quadforce6",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 30, coolDown: 50),
                            new TimedTransition(100, "Quadforce7")
                        ),
                        new State("Quadforce7",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 15, coolDown: 50),
                            new TimedTransition(100, "Quadforce8")
                        ),
                        new State("Quadforce8",
                            new Shoot(0, projectileIndex: 1, count: 5, shootAngle: 75, fixedAngle: 0, coolDown: 50),
                            new TimedTransition(100, "Quadforce1")
                        )
                     ),
                    new State("nextfam2",
                        new HealSelf(coolDown: 2500, amount: 50000),
                        new Taunt("Your essence is mine!"),
                        new TossObject("Demon of the Dark", 9, 0, coolDown: 9999999),
                        new TossObject("Demon of the Dark", 9, 90, coolDown: 9999999),
                        new TossObject("Demon of the Dark", 9, 180, coolDown: 9999999),
                        new TossObject("Demon of the Dark", 9, 270, coolDown: 9999999),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFFFFFF, 1, 2),
                        new TimedTransition(5000, "blaster")
                        ),
                    new State("blaster",
                        new TossObject("AH Feral of the Zol", 4, 0, coolDown: 9999999),
                        new TossObject("AH Feral of the Zol", 4, 270, coolDown: 9999999),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(14, count: 6, projectileIndex: 5, coolDown: 2000),
                        new TimedTransition(4000, "AuraofZol")
                        ),
                    new State("AuraofZol",
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new Shoot(11, count: 5, projectileIndex: 3, coolDown: 50),
                        new Shoot(11, count: 4, shootAngle: 12, projectileIndex: 4, coolDown: 1500),
                        new TimedTransition(8000, "nextfam3")
                        ),
                    new State("nextfam3",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Flash(0xFFFFFF, 1, 2),
                        new Shoot(8.4, count: 12, projectileIndex: 0, coolDown: 1200),
                        new TimedTransition(5000, "nextfam4")
                        ),
                    new State("nextfam4",
                        new Shoot(8.4, count: 6, projectileIndex: 0, coolDown: 1200),
                        new Shoot(8.4, count: 5, projectileIndex: 2, coolDown: 600),
                        new Shoot(8.4, count: 7, shootAngle: 10, projectileIndex: 1, coolDown: 1600),
                        new Shoot(8.4, count: 3, shootAngle: 2, projectileIndex: 2, coolDown: 1600, coolDownOffset: 500),
                        new TimedTransition(6400, "SummonConstructs")
                        )
                    ),
                    new State("spookded",
                        new Flash(0xF0FFF0, 1, 3),
                        new Taunt("...Have I not succeeded this time?", "Aaah... so you don't see it?", "Will the vision finally be broken?"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(1),
                        new TimedTransition(6000, "ded")
                        ),
                    new State("ded",
                        new Suicide()
                        )
                    ),
                new MostDamagers(3,
                    LootTemplates.FabledItemsLootZolUltra()
                    ),
                new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                    new Threshold(0.1,
                        new TierLoot(7, ItemType.Ring, 0.0033),
                        new ItemLoot("Onrane Cache", 0.55),
                        new ItemLoot("Gold Cache", 0.33),
                        new ItemLoot("Vial of Life", 1),
                        new ItemLoot("Vial of Defense", 1),
                        new ItemLoot("Vial of Attack", 1),
                        new ItemLoot("Vial of Dexterity", 1),
                        new ItemLoot("Vial of Vitality", 1),
                        new ItemLoot("Vial of Wisdom", 1)
                )
            )
        .Init("AH The Heart",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("idle",
                        new PlayerWithinTransition(6, "default")
                        ),
                    new State("default",
                        new Taunt("Only the worthy will survive...stand on the plates to survive the challenge!"),
                        new TimedTransition(5000, "begin")
                        ),
                    new State(
                        new Flash(0xFF00FF, 1, 2),
                    new State("begin",
                        new Taunt(true, "GANUS AND NIRUX WILL BE FORGIVEN. WILL YOU?"),
                        new TimedTransition(7000, "begin2")
                        ),
                    new State("begin2",
                        new Taunt("DO YOU ACCEPT MY CHALLENGE?", "THE ECHOES OF ZOL HAVE SEEN YOU FIGHT. ENGAGE IN THE TEST?"),
                        new PlayerTextTransition("commence", "Unleash the Power of the Zol!", 99, false, true)
                        )
                      ),
                    new State("commence",
                        new Taunt("Such charisma would get you killed here. Let it begin.", "Have never seen anyone so excited to be crushed...", "It would be unlikely you'll live to tell the tale.", "You seem brave now..."),
                        new TimedTransition(6000, "Burst1")
                        ),
                new State(
                    new EntityExistsTransition("Beacon of Zol A", 9999, "Failed"),
                    new State("Burst1",
                        //Shoot projectiles in a ring every other moment
                        new Shoot(10, count: 8, projectileIndex: 0, coolDown: 8000),
                        //Spawn the Zol Sorcerers
                        new InvisiToss("Zol Sorcerer", 5, 0, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 90, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 180, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 270, coolDown: 9999999),
                        //Start Spawning Servants shortly after
                        new InvisiToss("Servant of Darkness", 8, 45, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Servant of Darkness", 8, 135, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Servant of Darkness", 8, 225, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Servant of Darkness", 8, 315, coolDown: 20000, coolDownOffset: 2600),
                        //Start Spawning Brutes
                        new InvisiToss("Brute of the Hideout", 4, 45, coolDown: 22500, coolDownOffset: 1400),
                        new InvisiToss("Brute of the Hideout", 4, 135, coolDown: 22500, coolDownOffset: 1400),
                        new InvisiToss("Brute of the Hideout", 4, 225, coolDown: 22500, coolDownOffset: 1400),
                        new InvisiToss("Brute of the Hideout", 4, 315, coolDown: 22500, coolDownOffset: 1400),
                        // Spawn demons
                        new InvisiToss("Demon of the Dark", 8, 45, coolDown: 40000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 135, coolDown: 40000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 225, coolDown: 40000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 315, coolDown: 40000, coolDownOffset: 2600),
                        new TimedTransition(74000, "ReadyBurst2")
                        ),
                    new State("ReadyBurst2",
                        new RemoveEntity(999, "Giant Cube of Zol"),
                        new RemoveEntity(999, "Cube of Zol"),
                        new RemoveEntity(999, "Niolru"),
                        new RemoveEntity(999, "Brute of the Hideout"),
                        new RemoveEntity(999, "Zol Sorcerer"),
                        new RemoveEntity(999, "Corrupted Stone Giant B"),
                        new RemoveEntity(999, "Demon of the Dark"),
                        new RemoveEntity(999, "Servant of Darkness"),
                        new RemoveEntity(999, "AH Little Purple Slime"),
                        new RemoveEntity(999, "AH Big Purple Slime"),
                        new Flash(0x0000FF, 1, 1),
                        new Taunt(true, "Burst 1 has been defeated. Stay on your plates warriors...there is more to come."),
                        new TimedTransition(10000, "Burst2")
                        ),
                    new State("Burst2",
                        //Shoot projectiles in a ring every other moment
                        new Shoot(10, count: 16, projectileIndex: 0, coolDown: 8000),
                       //Spawn the Zol Sorcerers
                       new InvisiToss("Zol Sorcerer", 5, 0, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 90, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 180, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 270, coolDown: 9999999),
                        // Spawn demons
                        new InvisiToss("Demon of the Dark", 8, 45, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 135, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 225, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 315, coolDown: 20000, coolDownOffset: 2600),
                        //Start Spawning Cubes
                        new InvisiToss("Giant Cube of Zol", 6, 65, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 155, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 245, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 335, coolDown: 34000, coolDownOffset: 6000),
                        //Start Spawning Slimes
                        new InvisiToss("AH Big Purple Slime", 8, 65, coolDown: 25000, coolDownOffset: 6000),
                        new InvisiToss("AH Big Purple Slime", 8, 155, coolDown: 25000, coolDownOffset: 6000),
                        new InvisiToss("AH Big Purple Slime", 8, 245, coolDown: 25000, coolDownOffset: 6000),
                        new InvisiToss("AH Big Purple Slime", 8, 335, coolDown: 25000, coolDownOffset: 6000),
                        new TimedTransition(74000, "ReadyFinalBurst")
                      ),
                      new State("ReadyFinalBurst",
                        new RemoveEntity(999, "Giant Cube of Zol"),
                        new RemoveEntity(999, "Cube of Zol"),
                        new RemoveEntity(999, "Niolru"),
                        new RemoveEntity(999, "Brute of the Hideout"),
                        new RemoveEntity(999, "Zol Sorcerer"),
                        new RemoveEntity(999, "Corrupted Stone Giant B"),
                        new RemoveEntity(999, "Demon of the Dark"),
                        new RemoveEntity(999, "Servant of Darkness"),
                        new RemoveEntity(999, "AH Little Purple Slime"),
                        new RemoveEntity(999, "AH Big Purple Slime"),
                        new Flash(0x0000FF, 1, 1),
                        new Taunt(true, "Burst 2 has been defeated. Final Burst is near..you must be prepared!"),
                        new TimedTransition(10000, "FinalBurst")
                        ),
                    new State("FinalBurst",
                        //Shoot projectiles in a ring every other moment
                        new Shoot(10, count: 22, projectileIndex: 0, coolDown: 8000),
                        //Spawn the Zol Sorcerers
                        new InvisiToss("Zol Sorcerer", 5, 0, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 90, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 180, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 270, coolDown: 9999999),
                        //Start Spawning Servants shortly after
                        new InvisiToss("Corrupted Stone Giant B", 10, 45, coolDown: 60000, coolDownOffset: 2600),
                        new InvisiToss("Corrupted Stone Giant B", 10, 135, coolDown: 60000, coolDownOffset: 2600),
                        new InvisiToss("Corrupted Stone Giant B", 10, 225, coolDown: 60000, coolDownOffset: 2600),
                        new InvisiToss("Corrupted Stone Giant B", 10, 315, coolDown: 60000, coolDownOffset: 2600),
                        // Spawn demons
                        new InvisiToss("Demon of the Dark", 8, 45, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 135, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 225, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 315, coolDown: 20000, coolDownOffset: 2600),
                        //Start Spawning Cubes
                        new InvisiToss("Giant Cube of Zol", 6, 65, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 155, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 245, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 335, coolDown: 34000, coolDownOffset: 6000),
                        //Start Spawning Slimes
                        new InvisiToss("AH Big Purple Slime", 8, 65, coolDown: 22500, coolDownOffset: 6000),
                        new InvisiToss("AH Big Purple Slime", 8, 155, coolDown: 22500, coolDownOffset: 6000),
                        new InvisiToss("AH Big Purple Slime", 8, 245, coolDown: 22500, coolDownOffset: 6000),
                        new InvisiToss("AH Big Purple Slime", 8, 335, coolDown: 22500, coolDownOffset: 6000),
                        new TimedTransition(74000, "Done")
                        )
                      ),
                    new State("Failed",
                        new Taunt(true, "THERE IS NO REMORSE. YOU ARE BANISHED.", "YOU HAVE NOT BEEN FORGIVEN. REIGN.", "WE DO NOT FORGIVE. YOU WON'T ADVANCE. YOU WILL BE LEFT TO BE DOOMED."),
                        new Flash(0xFF0000, 0.25, 3),
                        new TimedTransition(6000, "Failure")
                        ),
                    new State("Done",
                        //Delete all spooks
                        new RemoveEntity(999, "Giant Cube of Zol"),
                        new RemoveEntity(999, "Cube of Zol"),
                        new RemoveEntity(999, "Niolru"),
                        new RemoveEntity(999, "Brute of the Hideout"),
                        new RemoveEntity(999, "Zol Sorcerer"),
                        new RemoveEntity(999, "Corrupted Stone Giant B"),
                        new RemoveEntity(999, "Demon of the Dark"),
                        new RemoveEntity(999, "Servant of Darkness"),
                        new RemoveEntity(999, "AH Little Purple Slime"),
                        new RemoveEntity(999, "AH Big Purple Slime"),
                        new Flash(0xFFFFFF, 1, 3),
                        new Taunt("You have shown that you can withstand us...but can you resist the FULL power of the Zol?", "It must have took preparation to defeat us. I applaud you.", "Congratulations! You have passed the final test to get to Aldragine."),
                        new TimedTransition(6000, "Success")
                        ),
                    new State("Failure",
                        new Shoot(40, count: 42, projectileIndex: 1, coolDown: 500),
                        new Suicide()
                        ),
                    new State("Success",
                        new DropPortalOnDeath("Keeping of Aldragine Portal", 1, timeout: 180),
                        //new InvisiToss("AH Loot Chest 3", 2, 270, coolDown: 9999999),
                        new Spawn("AH Heart Loot Ctrl", givesNoXp: true),
                        new TransferDamageOnDeath("AH Heart Loot Ctrl"),
                        new Suicide()
                        )
                    )
                )
        .Init("AH ULTRA The Heart",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("idle",
                        new PlayerWithinTransition(6, "default")
                        ),
                    new State("default",
                        new Taunt("Only the worthy will survive...stand on the plates to survive the challenge!"),
                        new TimedTransition(5000, "begin")
                        ),
                    new State(
                        new Flash(0xFF00FF, 1, 2),
                    new State("begin",
                        new Taunt(true, "GANUS AND NIRUX WILL BE FORGIVEN. WILL YOU?"),
                        new TimedTransition(7000, "begin2")
                        ),
                    new State("begin2",
                        new Taunt("DO YOU ACCEPT MY CHALLENGE?", "THE ECHOES OF ZOL HAVE SEEN YOU FIGHT. ENGAGE IN THE TEST?"),
                        new PlayerTextTransition("commence", "Unleash the Power of the Zol!", 99, false, true)
                        )
                      ),
                    new State("commence",
                        new Taunt("Such charisma would get you killed here. Let it begin.", "Have never seen anyone so excited to be crushed...", "It would be unlikely you'll live to tell the tale.", "You seem brave now..."),
                        new TimedTransition(6000, "Burst1")
                        ),
                new State(
                    new EntityExistsTransition("ULTRA Beacon of Zol A", 9999, "Failed"),
                    new State("Burst1",
                        //Shoot projectiles in a ring every other moment
                        new Shoot(10, count: 8, projectileIndex: 0, coolDown: 8000),
                        //Spawn the Zol Sorcerers
                        new InvisiToss("Zol Sorcerer", 5, 0, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 90, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 180, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 270, coolDown: 9999999),
                        //Start Spawning Servants shortly after
                        new InvisiToss("Servant of Darkness", 8, 45, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Servant of Darkness", 8, 135, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Servant of Darkness", 8, 225, coolDown: 20000, coolDownOffset: 2600),
                        new InvisiToss("Servant of Darkness", 8, 315, coolDown: 20000, coolDownOffset: 2600),
                        //Start Spawning Brutes
                        new InvisiToss("Brute of the Hideout", 4, 45, coolDown: 32500, coolDownOffset: 1400),
                        new InvisiToss("Brute of the Hideout", 4, 135, coolDown: 32500, coolDownOffset: 1400),
                        new InvisiToss("Brute of the Hideout", 4, 225, coolDown: 32500, coolDownOffset: 1400),
                        new InvisiToss("Brute of the Hideout", 4, 315, coolDown: 32500, coolDownOffset: 1400),
                        // Spawn demons
                        new InvisiToss("Demon of the Dark", 8, 45, coolDown: 44000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 135, coolDown: 44000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 225, coolDown: 44000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 315, coolDown: 44000, coolDownOffset: 2600),
                        // Spawn niolru
                        new InvisiToss("Niolru", 8, 45, coolDown: 38000, coolDownOffset: 2600),
                        new InvisiToss("Niolru", 8, 135, coolDown: 38000, coolDownOffset: 2600),
                        new InvisiToss("Niolru", 8, 225, coolDown: 38000, coolDownOffset: 2600),
                        new InvisiToss("Niolru", 8, 315, coolDown: 38000, coolDownOffset: 2600),
                        new TimedTransition(74000, "ReadyBurst2")
                        ),
                    new State("ReadyBurst2",
                        new RemoveEntity(999, "Giant Cube of Zol"),
                        new RemoveEntity(999, "Cube of Zol"),
                        new RemoveEntity(999, "Niolru"),
                        new RemoveEntity(999, "Brute of the Hideout"),
                        new RemoveEntity(999, "Zol Sorcerer"),
                        new RemoveEntity(999, "Corrupted Stone Giant B"),
                        new RemoveEntity(999, "Demon of the Dark"),
                        new RemoveEntity(999, "Servant of Darkness"),
                        new RemoveEntity(999, "AH Little Purple Slime"),
                        new RemoveEntity(999, "AH Big Purple Slime"),
                        new Flash(0x0000FF, 1, 1),
                        new Taunt(true, "Burst 1 has been defeated. Stay on your plates warriors...there is more to come."),
                        new TimedTransition(10000, "Burst2")
                        ),
                    new State("Burst2",
                        //Shoot projectiles in a ring every other moment
                        new Shoot(10, count: 16, projectileIndex: 0, coolDown: 8000),
                       //Spawn the Zol Sorcerers
                       new InvisiToss("Zol Sorcerer", 5, 0, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 90, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 180, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 270, coolDown: 9999999),
                        // Spawn demons
                        new InvisiToss("Demon of the Dark", 8, 45, coolDown: 25000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 135, coolDown: 25000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 225, coolDown: 25000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 315, coolDown: 25000, coolDownOffset: 2600),
                        //Start Spawning Cubes
                        new InvisiToss("Giant Cube of Zol", 6, 65, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 155, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 245, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 335, coolDown: 34000, coolDownOffset: 6000),
                        //Start Spawning Slimes
                        new InvisiToss("AH Big Purple Slime", 8, 65, coolDown: 25000, coolDownOffset: 6000),
                        new InvisiToss("AH Big Purple Slime", 8, 155, coolDown: 25000, coolDownOffset: 6000),
                        new InvisiToss("AH Big Purple Slime", 8, 245, coolDown: 25000, coolDownOffset: 6000),
                        new InvisiToss("AH Big Purple Slime", 8, 335, coolDown: 25000, coolDownOffset: 6000),
                        // Spawn niolru
                        new InvisiToss("Niolru", 8, 45, coolDown: 38000, coolDownOffset: 2600),
                        new InvisiToss("Niolru", 8, 135, coolDown: 38000, coolDownOffset: 2600),
                        new InvisiToss("Niolru", 8, 225, coolDown: 38000, coolDownOffset: 2600),
                        new InvisiToss("Niolru", 8, 315, coolDown: 38000, coolDownOffset: 2600),
                        new TimedTransition(74000, "ReadyFinalBurst")
                      ),
                      new State("ReadyFinalBurst",
                        new RemoveEntity(999, "Giant Cube of Zol"),
                        new RemoveEntity(999, "Cube of Zol"),
                        new RemoveEntity(999, "Niolru"),
                        new RemoveEntity(999, "Brute of the Hideout"),
                        new RemoveEntity(999, "Zol Sorcerer"),
                        new RemoveEntity(999, "Corrupted Stone Giant B"),
                        new RemoveEntity(999, "Demon of the Dark"),
                        new RemoveEntity(999, "Servant of Darkness"),
                        new RemoveEntity(999, "AH Little Purple Slime"),
                        new RemoveEntity(999, "AH Big Purple Slime"),
                        new Flash(0x0000FF, 1, 1),
                        new Taunt(true, "Burst 2 has been defeated. Final Burst is near..you must be prepared!"),
                        new TimedTransition(10000, "FinalBurst")
                        ),
                    new State("FinalBurst",
                        //Shoot projectiles in a ring every other moment
                        new Shoot(10, count: 22, projectileIndex: 0, coolDown: 8000),
                        //Spawn the Zol Sorcerers
                        new InvisiToss("Zol Sorcerer", 5, 0, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 90, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 180, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 5, 270, coolDown: 9999999),
                        //Start Spawning Servants shortly after
                        new InvisiToss("Corrupted Stone Giant B", 10, 45, coolDown: 30000, coolDownOffset: 2600),
                        new InvisiToss("Corrupted Stone Giant B", 10, 135, coolDown: 30000, coolDownOffset: 2600),
                        new InvisiToss("Corrupted Stone Giant B", 10, 225, coolDown: 30000, coolDownOffset: 2600),
                        new InvisiToss("Corrupted Stone Giant B", 10, 315, coolDown: 30000, coolDownOffset: 2600),
                        // Spawn demons
                        new InvisiToss("Demon of the Dark", 8, 45, coolDown: 25000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 135, coolDown: 25000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 225, coolDown: 25000, coolDownOffset: 2600),
                        new InvisiToss("Demon of the Dark", 8, 315, coolDown: 25000, coolDownOffset: 2600),
                        //Start Spawning Cubes
                        new InvisiToss("Giant Cube of Zol", 6, 65, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 155, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 245, coolDown: 34000, coolDownOffset: 6000),
                        new InvisiToss("Giant Cube of Zol", 6, 335, coolDown: 34000, coolDownOffset: 6000),
                        //Start Spawning Slimes
                        new InvisiToss("AH Feral of the Zol", 8, 65, coolDown: 50000, coolDownOffset: 6000),
                        new InvisiToss("AH Feral of the Zol", 8, 155, coolDown: 50000, coolDownOffset: 6000),
                        new InvisiToss("AH Feral of the Zol", 8, 245, coolDown: 50000, coolDownOffset: 6000),
                        new InvisiToss("AH Feral of the Zol", 8, 335, coolDown: 50000, coolDownOffset: 6000),
                        // Spawn niolru
                        new InvisiToss("Niolru", 8, 45, coolDown: 25000, coolDownOffset: 2600),
                        new InvisiToss("Niolru", 8, 135, coolDown: 25000, coolDownOffset: 2600),
                        new InvisiToss("Niolru", 8, 225, coolDown: 25000, coolDownOffset: 2600),
                        new InvisiToss("Niolru", 8, 315, coolDown: 25000, coolDownOffset: 2600),
                        new TimedTransition(74000, "Done")
                        )
                      ),
                    new State("Failed",
                        new Taunt(true, "THERE IS NO REMORSE. YOU ARE BANISHED.", "YOU HAVE NOT BEEN FORGIVEN. REIGN.", "WE DO NOT FORGIVE. YOU WON'T ADVANCE. YOU WILL BE LEFT TO BE DOOMED."),
                        new Flash(0xFF0000, 0.25, 3),
                        new TimedTransition(6000, "Failure")
                        ),
                    new State("Done",
                        //Delete all spooks
                        new RemoveEntity(999, "Giant Cube of Zol"),
                        new RemoveEntity(999, "Cube of Zol"),
                        new RemoveEntity(999, "Niolru"),
                        new RemoveEntity(999, "Brute of the Hideout"),
                        new RemoveEntity(999, "Zol Sorcerer"),
                        new RemoveEntity(999, "Corrupted Stone Giant B"),
                        new RemoveEntity(999, "Demon of the Dark"),
                        new RemoveEntity(999, "Servant of Darkness"),
                        new RemoveEntity(999, "AH Little Purple Slime"),
                        new RemoveEntity(999, "AH Big Purple Slime"),
                        new Flash(0xFFFFFF, 1, 3),
                        new Taunt("You have shown that you can withstand us...but can you resist the FULL power of the Zol?", "It must have took preparation to defeat us. I applaud you.", "Congratulations! You have passed the final test to get to Aldragine."),
                        new TimedTransition(6000, "Success")
                        ),
                    new State("Failure",
                        new Shoot(40, count: 42, projectileIndex: 1, coolDown: 500),
                        new Suicide()
                        ),
                    new State("Success",
                        new DropPortalOnDeath("Ultra Keeping of Aldragine Portal", 1, timeout: 180),
                        //new InvisiToss("AH Loot Chest 3", 2, 270, coolDown: 9999999),
                        new Spawn("AH ULTRA Heart Loot Ctrl", givesNoXp: true),
                        new TransferDamageOnDeath("AH ULTRA Heart Loot Ctrl"),
                        new Suicide()
                        )
                    )
                )
        .Init("AH Aldragine",
                new State(
                    new ScaleHP(70000),
                    new HpLessTransition(0.13, "ded"),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(4, "intimidation")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("intimidation",
                        new ChangeSize(25, 220),
                        new TimedTransition(8000, "starttalk")
                        ),
                    new State("starttalk",
                        new Taunt("I'd assume it took you quite long to get here. Only to die."),
                        new TimedTransition(4000, "talk1")
                        ),
                    new State("talk1",
                        new Taunt("You've been heeded multiple warnings, but you fail to see that you WON'T MAKE ME FALL LIKE THE OTHERS.", "Your poor comprehension of true power leads me to think you are genuinely stupid."),
                        new TimedTransition(6000, "talk2")
                        ),
                    new State("talk2",
                        new Flash(0x00FF00, 1, 2),
                        new Taunt("Now, I'll show you the true meaning of power. Come closer. Let me show you."),
                        new PlayerWithinTransition(1, "talk3")
                        ),
                    new State("talk3",
                        new Flash(0xFF0000, 1, 2),
                        new TimedTransition(4000, "Start")
                        )
                      ),
                    new State("Start",
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new Shoot(8, count: 7, projectileIndex: 2, coolDown: 3000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 45, coolDown: 500, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 135, coolDown: 500, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 225, coolDown: 500, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 315, coolDown: 500, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 4, coolDown: new Cooldown(3000, 2400)),
                        new Shoot(8, count: 4, shootAngle: 10, projectileIndex: 0, predictive: 2, coolDown: new Cooldown(2000, 1000)),
                        new DamageTakenTransition(26000, "BestShot")
                        ),
                    new State("BestShot",
                        new ReturnToSpawn(1),
                        new HealSelf(coolDown: 30000, amount: 9999999),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Is that all you've got?", "Hahaha!"),
                        new TimedTransition(7500, "Start2")
                        ),
                    new State("Start2",
                        new Taunt("You are nothing to me but another small issue to fix."),
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new Shoot(8, count: 7, projectileIndex: 2, coolDown: 3000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 45, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 135, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 225, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 315, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 4, coolDown: new Cooldown(2000, 1000)),
                        new Shoot(8, count: 4, shootAngle: 10, projectileIndex: 2, predictive: 2, coolDown: new Cooldown(1000, 1000)),
                        new DamageTakenTransition(26000, "BestShot2")
                        ),
                    new State("BestShot2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(1),
                        new Flash(0x0000FF, 1, 3),
                        new TimedTransition(6000, "GoToLeft")
                        ),
                    new State("GoToLeft",
                        new MoveTo(speed: 1, x: 2, y: 14),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "HauntingKnights")
                        ),
                    new State("HauntingKnights",
                        new TossObject("Haunting Knight", range: 15, angle: 0, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 10, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 20, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 30, coolDown: 99999, coolDownOffset: 1800),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "HauntingKnightsClear")
                        ),
                    new State("HauntingKnightsClear",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8, count: 1, projectileIndex: 4, fixedAngle: 180, coolDown: 4000, coolDownOffset: 3000),
                        new Shoot(8, count: 1, projectileIndex: 4, fixedAngle: 0, coolDown: 4000, coolDownOffset: 3000),
                        new Shoot(8, count: 14, shootAngle: 22, projectileIndex: 4, fixedAngle: 0, coolDown: 6400, coolDownOffset: 3000),
                        new InvisiToss("Zol Sorcerer", 13, 0, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 13, 20, coolDown: 9999999),
                        new InvisiToss("Zol Bomber", 11, 0, coolDown: 9999999),
                        new InvisiToss("Zol Bomber", 11, 20, coolDown: 9999999),
                        new InvisiToss("Demon of the Dark", 7, 0, coolDown: 9999999),
                        new InvisiToss("Demon of the Dark", 7, 20, coolDown: 9999999),
                        new InvisiToss("Giant Cube of Zol", 4, 0, coolDown: 9999999),
                        new InvisiToss("Giant Cube of Zol", 4, 40, coolDown: 9999999),
                        new EntitiesNotExistsTransition(999, "GotoCenter", "Haunting Knight")
                        ),
                    new State("GotoCenter",
                        new ReturnToSpawn(1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "Basic")
                        ),
                    new State("Basic",
                        new Shoot(8, count: 20, projectileIndex: 5, coolDown: 3000),
                        new Shoot(8, count: 5, shootAngle: 6, projectileIndex: 6, coolDown: 1200),
                        new Shoot(10, count: 1, projectileIndex: 2, predictive: 1, coolDown: 50),
                        new TimedTransition(7400, "KillStones")
                        ),
                    new State("KillStones",
                        new Flash(0x0F00F0, 1, 2),
                        new Shoot(8, count: 1, shootAngle: 6, projectileIndex: 6, coolDown: 3200),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Stone of Zol", range: 9, angle: 90, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 270, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 180, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 0, coolDown: 99999),
                        new TimedTransition(2000, "KillStones2")
                        ),
                    new State(
                        new Taunt(0.50, "Your time is ticking, warriors!", "Unstoppable."),
                        new TimedTransition(15000, "Failed"),
                    new State("KillStones2",
                        new Shoot(8, count: 3, shootAngle: 6, projectileIndex: 6, coolDown: 400),
                        new Shoot(8, count: 6, shootAngle: 6, projectileIndex: 7, predictive: 1, coolDown: 400, coolDownOffset: 800),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new HealSelf(coolDown: 2500, amount: 3000),
                        new Flash(0x0F00F0, 1, 2),
                        new Shoot(12, count: 1, shootAngle: 6, projectileIndex: 6, coolDown: 3000),
                        new EntitiesNotExistsTransition(999, "Start3", "Stone of Zol")
                        )
                    ),
                    new State("Start3",
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 45, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 135, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 225, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 315, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 4, coolDown: new Cooldown(200, 1000)),
                        new TimedTransition(10000, "SpawnCGiant")
                        ),
                    new State("SpawnCGiant",
                        new Flash(0x0000FF, 1, 4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8, count: 7, projectileIndex: 4, coolDown: 99999),
                        new TimedTransition(6200, "CheckForNeccessaries")
                        ),
                    new State(
                        new TimedTransition(30000, "StopBeforeRape4"),
                    new State("CheckForNeccessaries",
                        new Shoot(8, count: 14, projectileIndex: 7, coolDown: 4000, coolDownOffset: 10000),
                        new TossObject("Corrupted Stone Giant C", range: 10, angle: 270, coolDown: 10000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityExistsTransition("Mark of Zol A", 9999, "Failed")
                      )
                    ),
                    new State("StopBeforeRape4",
                        new Taunt("You think you can just stop the Zol from becoming stronger?!", "NO MORTAL WILL RESIST THE CONSUMPTION OF THE ZOL!"),
                        new Flash(0x00FFFF, 1, 1),
                        new TossObject("Niolru", 2, 0, coolDown: 9999999),
                        new TossObject("Niolru", 2, 90, coolDown: 9999999),
                        new TossObject("Niolru", 2, 180, coolDown: 9999999),
                        new TossObject("Niolru", 2, 270, coolDown: 9999999),
                        new TimedTransition(4000, "BHellSecond")
                        ),
                    new State("BHellSecond",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(12000, "BeamofDeath"),
                        new Shoot(8, count: 3, projectileIndex: 9, coolDown: 2000),
                        new State("222Idle",
                            new TimedTransition(1000, "222Spin")
                        ),
                        new State("222Spin",
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1200),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 1200, coolDownOffset: 200),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 1200, coolDownOffset: 400),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 1200, coolDownOffset: 600),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 1200, coolDownOffset: 800),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 1200, coolDownOffset: 1000),
                                new TimedTransition(1200, "222Pause")
                        ),
                        new State("222Pause",
                           new Shoot(8, count: 8, projectileIndex: 3, coolDown: 9999),
                           new TimedTransition(3000, "222Idle")
                        )
                    ),
                    new State("BeamofDeath",
                        new Taunt("You shall be brought to the hands of doom by me!"),
                        new HealSelf(coolDown: 99999, amount: 40000),
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(14, count: 1, projectileIndex: 3, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(14, count: 12, projectileIndex: 6, coolDown: 3000, coolDownOffset: 3000),
                        new TimedTransition(12000, "GoToRight")
                        ),
                    new State("GoToRight",
                        new MoveTo(speed: 1, x: 24, y: 14),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "HauntingKnightsB")
                        ),
                    new State("HauntingKnightsB",
                        new TossObject("Haunting Knight", range: 15, angle: 180, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 190, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 200, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 210, coolDown: 99999, coolDownOffset: 1800),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "HauntingKnightsClearB")
                        ),
                    new State("HauntingKnightsClearB",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8, count: 1, projectileIndex: 4, fixedAngle: 180, coolDown: 4000, coolDownOffset: 3000),
                        new Shoot(8, count: 1, projectileIndex: 4, fixedAngle: 0, coolDown: 4000, coolDownOffset: 3000),
                        new Shoot(8, count: 14, shootAngle: 22, projectileIndex: 4, fixedAngle: 180, coolDown: 6400, coolDownOffset: 3000),
                        new InvisiToss("Zol Sorcerer", 13, 180, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 13, 200, coolDown: 9999999),
                        new InvisiToss("Zol Bomber", 11, 180, coolDown: 9999999),
                        new InvisiToss("Zol Bomber", 11, 200, coolDown: 9999999),
                        new InvisiToss("Demon of the Dark", 7, 180, coolDown: 9999999),
                        new InvisiToss("Demon of the Dark", 7, 200, coolDown: 9999999),
                        new InvisiToss("Giant Cube of Zol", 4, 180, coolDown: 9999999),
                        new InvisiToss("Giant Cube of Zol", 4, 200, coolDown: 9999999),
                        new EntitiesNotExistsTransition(999, "GotoCenterB", "Haunting Knight")
                        ),
                    new State("GotoCenterB",
                        new ReturnToSpawn(1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "BasicB")
                        ),
                    new State("BasicB",
                        new Shoot(8, count: 20, projectileIndex: 5, coolDown: 3000),
                        new Shoot(8, count: 5, shootAngle: 6, projectileIndex: 6, coolDown: 1200),
                        new Shoot(10, count: 1, projectileIndex: 2, predictive: 1, coolDown: 50),
                        new TimedTransition(7400, "KillStonesB")
                        ),
                    new State("KillStonesB",
                        new Flash(0x0F00F0, 1, 2),
                        new Shoot(8, count: 1, shootAngle: 6, projectileIndex: 6, coolDown: 3200),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Stone of Zol", range: 9, angle: 90, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 270, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 180, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 0, coolDown: 99999),
                        new TimedTransition(2000, "KillStones2B")
                        ),
                    new State(
                        new Taunt(0.50, "Your time is ticking, warriors!", "Unstoppable."),
                        new TimedTransition(15000, "Failed"),
                    new State("KillStones2B",
                            new Shoot(8, count: 3, shootAngle: 6, projectileIndex: 6, coolDown: 400),
                            new Shoot(8, count: 6, shootAngle: 6, projectileIndex: 7, predictive: 1, coolDown: 400, coolDownOffset: 800),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new HealSelf(coolDown: 1500, amount: 3000),
                        new Flash(0x0F00F0, 1, 2),
                        new Shoot(12, count: 1, shootAngle: 6, projectileIndex: 6, coolDown: 3000),
                        new EntitiesNotExistsTransition(999, "Start3B", "Stone of Zol")
                        )
                    ),
                    new State("Start3B",
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 45, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 135, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 225, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 315, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 4, coolDown: new Cooldown(200, 1000)),
                        new TimedTransition(10000, "SpawnCGiantB")
                        ),
                    new State("SpawnCGiantB",
                        new Flash(0x0000FF, 1, 4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8, count: 7, projectileIndex: 4, coolDown: 99999),
                        new TimedTransition(6200, "CheckForNeccessariesB")
                        ),
                    new State(
                        new TimedTransition(30000, "StopBeforeRape"),
                    new State("CheckForNeccessariesB",
                        new Shoot(8, count: 14, projectileIndex: 7, coolDown: 4000, coolDownOffset: 10000),
                        new TossObject("Corrupted Stone Giant C", range: 10, angle: 270, coolDown: 10000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityExistsTransition("Mark of Zol A", 9999, "Failed")
                      )
                    ),
                    new State("StopBeforeRape",
                        new Taunt("You think you can just stop the Zol from becoming stronger?!", "NO MORTAL WILL RESIST THE CONSUMPTION OF THE ZOL!"),
                        new Flash(0x00FFFF, 1, 1),
                        new TossObject("Niolru", 2, 0, coolDown: 9999999),
                        new TossObject("Niolru", 2, 90, coolDown: 9999999),
                        new TossObject("Niolru", 2, 180, coolDown: 9999999),
                        new TossObject("Niolru", 2, 270, coolDown: 9999999),
                        new TimedTransition(4000, "BHell")
                        ),
                    new State("BHell",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(12000, "Vulnerable1"),
                        new Shoot(8, count: 3, projectileIndex: 9, coolDown: 2000),
                        new State("22Idle",
                            new TimedTransition(1000, "22Spin")
                        ),
                        new State("22Spin",
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1200),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 1200, coolDownOffset: 200),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 1200, coolDownOffset: 400),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 1200, coolDownOffset: 600),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 1200, coolDownOffset: 800),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 1200, coolDownOffset: 1000),
                                new TimedTransition(1200, "22Pause")
                        ),
                        new State("22Pause",
                           new Shoot(8, count: 8, projectileIndex: 3, coolDown: 9999),
                           new TimedTransition(3000, "22Idle")
                        )
                    ),
                    new State("Vulnerable1",
                        new Taunt("You are worthless beings!"),
                        new Prioritize(
                             new Follow(0.7, 8, 1),
                             new Wander(0.05)
                             ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HealSelf(coolDown: 8000, amount: 2500),
                        new Shoot(8, count: 10, shootAngle: 10, projectileIndex: 1, coolDown: new Cooldown(2000, 1000)),
                        new Shoot(8, count: 5, projectileIndex: 5, coolDown: 500, coolDownOffset: 1000),
                        new Grenade(2, 400, range: 9, coolDown: 5000),
                        new TimedTransition(8000, "Vulnerable")
                        ),
                    new State("Vulnerable",
                        new MoveTo(speed: 1, x: 13, y: 9),
                        new Flash(0xF000FF, 1, 2),
                        new TimedTransition(12000, "Nope")
                        ),
                    new State("Nope",
                        new Taunt("Nice try, but your power is worthless compared to mine.", "I shall not be brought down by weaklings.", "The Zol surges within me"),
                        new Flash(0x00FF00, 1, 3),
                        new ReturnToSpawn(1),
                        new HealSelf(coolDown: 10000, amount: 2500),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Servant of Darkness", 2, 0, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 45, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 90, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 135, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 180, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 225, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 270, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 315, coolDown: 9999999),
                        new TimedTransition(10000, "Start2")
                        ),
                    new State("ded",
                        new Flash(0xFFFFFF, 1, 3),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(true, "Awaited the day for me to be defeated...I will have vengeance."),
                        new ReturnToSpawn(1),
                        new TimedTransition(6000, "Success")
                        ),
                    new State("Success",
                        new AnnounceOnDeath("The Zol, a dark burden, seems to fade away slowly..."),
                        new Shoot(8, count: 10, projectileIndex: 2, coolDown: 9999),
                        new Spawn("AH Aldragine Loot Ctrl", givesNoXp: true),
                        new TransferDamageOnDeath("AH Aldragine Loot Ctrl"),
                        new Suicide()
                        ),
                    new State("Failed",
                        new Flash(0xFF0000, 1, 3),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(true, "I HAVE GAINED ENOUGH ZOL. THE WORLDS WILL SOON BE OURS..."),
                        new ReturnToSpawn(1),
                        new TimedTransition(6000, "Failure")
                        ),
                    new State("Failure",
                        new Shoot(8, count: 56, projectileIndex: 4, coolDown: 9999),
                        new Suicide()
                        )
                    )
                )
        .Init("AH ULTRA Aldragine",
                new State(
                    new ScaleHP(175000),
                    new HpLessTransition(0.13, "ded"),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(4, "intimidation")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("intimidation",
                        new ChangeSize(25, 220),
                        new TimedTransition(8000, "starttalk")
                        ),
                    new State("starttalk",
                        new Taunt("The prey of the Zol has returned just to be erased from existence once again."),
                        new TimedTransition(4000, "talk1")
                        ),
                    new State("talk1",
                        new Taunt("Haven't you already understood the power of the Zol?"),
                        new TimedTransition(6000, "talk2")
                        ),
                    new State("talk2",
                        new Flash(0x00FF00, 1, 2),
                        new Taunt("This time there will be no return from the reign of the Zol. Come...let me show you."),
                        new PlayerWithinTransition(1, "talk3")
                        ),
                    new State("talk3",
                        new Flash(0xFF0000, 1, 2),
                        new TimedTransition(4000, "Start")
                        )
                      ),
                    new State("Start",
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new Shoot(8, count: 7, projectileIndex: 2, coolDown: 3000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 45, coolDown: 500, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 135, coolDown: 500, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 225, coolDown: 500, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 315, coolDown: 500, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 4, coolDown: new Cooldown(3000, 2400)),
                        new Shoot(8, count: 4, shootAngle: 10, projectileIndex: 0, predictive: 2, coolDown: new Cooldown(2000, 1000)),
                        new DamageTakenTransition(26000, "BestShot")
                        ),
                    new State("BestShot",
                        new ReturnToSpawn(1),
                        new HealSelf(coolDown: 60000, amount: 9999999),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("You can do better than that...", "Not even a scratch. Pitiful."),
                        new TimedTransition(7500, "Start2")
                        ),
                    new State("Start2",
                        new Taunt("You are nothing to me but another small issue to fix."),
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new Shoot(8, count: 7, projectileIndex: 2, coolDown: 3000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 45, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 135, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 225, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 315, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 4, coolDown: new Cooldown(2000, 1000)),
                        new Shoot(8, count: 4, shootAngle: 10, projectileIndex: 2, predictive: 2, coolDown: new Cooldown(1000, 1000)),
                        new DamageTakenTransition(26000, "BestShot2")
                        ),
                    new State("BestShot2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(1),
                        new Flash(0x0000FF, 1, 3),
                        new TimedTransition(6000, "GoToLeft")
                        ),
                    new State("GoToLeft",
                        new MoveTo(speed: 1, x: 2, y: 14),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "HauntingKnights")
                        ),
                    new State("HauntingKnights",
                        new TossObject("Haunting Knight", range: 15, angle: 0, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 10, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 20, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 30, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 40, coolDown: 99999, coolDownOffset: 1800),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "HauntingKnightsClear")
                        ),
                    new State("HauntingKnightsClear",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                                new Shoot(8, count: 1, projectileIndex: 4, fixedAngle: 180, coolDown: 4000, coolDownOffset: 3000),
                        new Shoot(8, count: 1, projectileIndex: 4, fixedAngle: 0, coolDown: 4000, coolDownOffset: 3000),
                        new Shoot(8, count: 14, shootAngle: 22, projectileIndex: 4, fixedAngle: 0, coolDown: 6400, coolDownOffset: 3000),
                        new InvisiToss("Zol Sorcerer", 13, 0, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 13, 20, coolDown: 9999999),
                        new InvisiToss("Zol Bomber", 11, 0, coolDown: 9999999),
                        new InvisiToss("Zol Bomber", 11, 20, coolDown: 9999999),
                        new InvisiToss("AH Zol Incarnation", 9, 0, coolDown: 9999999),
                        new InvisiToss("AH Zol Incarnation", 9, 20, coolDown: 9999999),
                        new InvisiToss("Demon of the Dark", 7, 0, coolDown: 9999999),
                        new InvisiToss("Demon of the Dark", 7, 20, coolDown: 9999999),
                        new InvisiToss("Giant Cube of Zol", 4, 0, coolDown: 9999999),
                        new InvisiToss("Giant Cube of Zol", 4, 40, coolDown: 9999999),
                        new EntitiesNotExistsTransition(999, "GotoCenter", "Haunting Knight")
                        ),
                    new State("GotoCenter",
                        new ReturnToSpawn(1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "ClonezA")
                        ),
                    new State("ClonezA",
                        new TossObject("AH Battlemage of the Zol", 6, 0, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 45, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 90, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 135, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 180, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 225, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 270, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 315, coolDown: 9999999),

                        new InvisiToss("AH ULTRA Aldragine Clone", 4, 0, coolDown: 9999999),
                        new InvisiToss("AH ULTRA Aldragine Clone", 4, 180, coolDown: 9999999),
                        new TimedTransition(4000, "ClonezAAttack")
                        ),
                    new State("ClonezAAttack",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8, count: 2, shootAngle: 6, projectileIndex: 10, coolDown: new Cooldown(600, 1000)),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new EntitiesNotExistsTransition(999, "Basic", "AH ULTRA Aldragine Clone")
                        ),
                    new State("Basic",
                        new Shoot(8, count: 20, projectileIndex: 5, coolDown: 3000),
                        new Shoot(8, count: 5, shootAngle: 6, projectileIndex: 6, coolDown: 1200),
                        new Shoot(10, count: 1, projectileIndex: 2, predictive: 1, coolDown: 50),
                        new TimedTransition(7400, "KillStones")
                        ),
                    new State("KillStones",
                        new Flash(0x0F00F0, 1, 2),
                        new Shoot(8, count: 1, shootAngle: 6, projectileIndex: 6, coolDown: 3200),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Stone of Zol", range: 9, angle: 90, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 270, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 180, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 0, coolDown: 99999),
                        new TimedTransition(2000, "KillStones2")
                        ),
                    new State(
                        new Taunt(0.50, "Your time is ticking, warriors!", "Unstoppable."),
                        new TimedTransition(15000, "Failed"),
                    new State("KillStones2",
                        new Shoot(8, count: 3, shootAngle: 6, projectileIndex: 6, coolDown: 400),
                        new Shoot(8, count: 6, shootAngle: 6, projectileIndex: 7, predictive: 1, coolDown: 400, coolDownOffset: 800),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new HealSelf(coolDown: 2500, amount: 3000),
                        new Flash(0x0F00F0, 1, 2),
                        new Shoot(12, count: 1, shootAngle: 6, projectileIndex: 6, coolDown: 3000),
                        new EntitiesNotExistsTransition(999, "Start3", "Stone of Zol")
                        )
                    ),
                    new State("Start3",
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 45, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 135, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 225, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 315, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 4, coolDown: new Cooldown(200, 1000)),
                        new Shoot(8, count: 5, projectileIndex: 4, predictive: 0.5, coolDown: new Cooldown(2000, 2000)),
                        new TimedTransition(10000, "SpawnCGiant")
                        ),
                    new State("SpawnCGiant",
                        new Flash(0x0000FF, 1, 4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8, count: 7, projectileIndex: 4, coolDown: 99999),
                        new TimedTransition(6200, "CheckForNeccessaries")
                        ),
                    new State(
                        new TimedTransition(30000, "StopBeforeRape4"),
                    new State("CheckForNeccessaries",
                        new Shoot(8, count: 14, projectileIndex: 7, coolDown: 4000, coolDownOffset: 10000),
                        new TossObject("Corrupted Stone Giant C", range: 10, angle: 270, coolDown: 10000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityExistsTransition("Mark of Zol A", 9999, "Failed")
                      )
                    ),
                    new State("StopBeforeRape4",
                        new Taunt("You think you can just stop the Zol from becoming stronger?!", "NO MORTAL WILL RESIST THE CONSUMPTION OF THE ZOL!"),
                        new Flash(0x00FFFF, 1, 1),
                        new TossObject("Niolru", 2, 0, coolDown: 9999999),
                        new TossObject("Niolru", 2, 90, coolDown: 9999999),
                        new TossObject("Niolru", 2, 180, coolDown: 9999999),
                        new TossObject("Niolru", 2, 270, coolDown: 9999999),
                        new TimedTransition(4000, "BHellSecond")
                        ),
                    new State("BHellSecond",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(12000, "BeamofDeath"),
                        new Shoot(8, count: 3, projectileIndex: 9, coolDown: 2000),
                        new State("222Idle",
                            new TimedTransition(1000, "222Spin")
                        ),
                        new State("222Spin",
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1200),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 1200, coolDownOffset: 200),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 1200, coolDownOffset: 400),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 1200, coolDownOffset: 600),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 1200, coolDownOffset: 800),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 1200, coolDownOffset: 1000),
                                new TimedTransition(1200, "222Pause")
                        ),
                        new State("222Pause",
                           new Shoot(8, count: 8, projectileIndex: 3, coolDown: 9999),
                           new TimedTransition(3000, "222Idle")
                        )
                    ),
                    new State("BeamofDeath",
                        new Taunt("You shall be brought to the hands of doom by me!"),
                        new HealSelf(coolDown: 99999, amount: 40000),
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(14, count: 1, projectileIndex: 3, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(14, count: 12, projectileIndex: 6, coolDown: 3000, coolDownOffset: 3000),
                        new TimedTransition(12000, "GoToRight")
                        ),
                    new State("GoToRight",
                        new MoveTo(speed: 1, x: 24, y: 14),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "HauntingKnightsB")
                        ),
                    new State("HauntingKnightsB",
                        new TossObject("Haunting Knight", range: 15, angle: 180, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 190, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 200, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 210, coolDown: 99999, coolDownOffset: 1800),
                        new TossObject("Haunting Knight", range: 15, angle: 220, coolDown: 99999, coolDownOffset: 1800),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "HauntingKnightsClearB")
                        ),
                    new State("HauntingKnightsClearB",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                                new Shoot(8, count: 1, projectileIndex: 4, fixedAngle: 180, coolDown: 4000, coolDownOffset: 3000),
                        new Shoot(8, count: 1, projectileIndex: 4, fixedAngle: 0, coolDown: 4000, coolDownOffset: 3000),
                        new Shoot(8, count: 14, shootAngle: 22, projectileIndex: 4, fixedAngle: 180, coolDown: 6400, coolDownOffset: 3000),
                        new InvisiToss("Zol Sorcerer", 13, 180, coolDown: 9999999),
                        new InvisiToss("Zol Sorcerer", 13, 200, coolDown: 9999999),
                        new InvisiToss("Zol Bomber", 11, 180, coolDown: 9999999),
                        new InvisiToss("Zol Bomber", 11, 200, coolDown: 9999999),
                        new InvisiToss("AH Zol Incarnation", 9, 180, coolDown: 9999999),
                        new InvisiToss("AH Zol Incarnation", 9, 200, coolDown: 9999999),
                        new InvisiToss("Demon of the Dark", 7, 180, coolDown: 9999999),
                        new InvisiToss("Demon of the Dark", 7, 200, coolDown: 9999999),
                        new InvisiToss("Giant Cube of Zol", 4, 180, coolDown: 9999999),
                        new InvisiToss("Giant Cube of Zol", 4, 200, coolDown: 9999999),
                        new EntitiesNotExistsTransition(999, "GotoCenterB", "Haunting Knight")
                        ),
                    new State("GotoCenterB",
                        new ReturnToSpawn(1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "ClonezB")
                        ),
                    new State("ClonezB",
                        new TossObject("AH Battlemage of the Zol", 6, 0, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 45, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 90, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 135, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 180, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 225, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 270, coolDown: 9999999),
                        new TossObject("AH Battlemage of the Zol", 6, 315, coolDown: 9999999),
                        new InvisiToss("AH ULTRA Aldragine Clone", 4, 0, coolDown: 9999999),
                        new InvisiToss("AH ULTRA Aldragine Clone", 4, 180, coolDown: 9999999),
                        new TimedTransition(4000, "ClonezBAttack")
                        ),
                    new State("ClonezBAttack",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8, count: 2, shootAngle: 6, projectileIndex: 10, coolDown: new Cooldown(600, 1000)),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new EntitiesNotExistsTransition(999, "BasicB", "AH ULTRA Aldragine Clone")
                        ),
                    new State("BasicB",
                        new Shoot(8, count: 20, projectileIndex: 5, coolDown: 3000),
                        new Shoot(8, count: 5, shootAngle: 6, projectileIndex: 6, coolDown: 1200),
                        new Shoot(10, count: 1, projectileIndex: 2, predictive: 1, coolDown: 50),
                        new TimedTransition(7400, "KillStonesB")
                        ),
                    new State("KillStonesB",
                        new Flash(0x0F00F0, 1, 2),
                        new Shoot(8, count: 1, shootAngle: 6, projectileIndex: 6, coolDown: 3200),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Stone of Zol", range: 9, angle: 90, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 270, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 180, coolDown: 99999),
                        new TossObject("Stone of Zol", range: 8, angle: 0, coolDown: 99999),
                        new TimedTransition(2000, "KillStones2B")
                        ),
                    new State(
                        new Taunt(0.50, "Your time is ticking, warriors!", "Unstoppable."),
                        new TimedTransition(15000, "Failed"),
                    new State("KillStones2B",
                            new Shoot(8, count: 3, shootAngle: 6, projectileIndex: 6, coolDown: 400),
                            new Shoot(8, count: 6, shootAngle: 6, projectileIndex: 7, predictive: 1, coolDown: 400, coolDownOffset: 800),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new HealSelf(coolDown: 1500, amount: 3000),
                        new Flash(0x0F00F0, 1, 2),
                        new Shoot(12, count: 1, shootAngle: 6, projectileIndex: 6, coolDown: 3000),
                        new EntitiesNotExistsTransition(999, "Start3B", "Stone of Zol")
                        )
                    ),
                    new State("Start3B",
                        new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                             ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 45, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 135, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 225, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 3, fixedAngle: 315, coolDown: 1, coolDownOffset: 2000),
                        new Shoot(8, count: 1, projectileIndex: 4, coolDown: new Cooldown(200, 1000)),
                        new Shoot(8, count: 5, projectileIndex: 4, predictive: 0.5, coolDown: new Cooldown(2000, 2000)),
                        new TimedTransition(10000, "SpawnCGiantB")
                        ),
                    new State("SpawnCGiantB",
                        new Flash(0x0000FF, 1, 4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8, count: 7, projectileIndex: 4, coolDown: 99999),
                        new TimedTransition(6200, "CheckForNeccessariesB")
                        ),
                    new State(
                        new TimedTransition(30000, "StopBeforeRape"),
                    new State("CheckForNeccessariesB",
                        new Shoot(8, count: 14, projectileIndex: 7, coolDown: 4000, coolDownOffset: 10000),
                        new TossObject("Corrupted Stone Giant C", range: 10, angle: 270, coolDown: 10000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityExistsTransition("Mark of Zol A", 9999, "Failed")
                      )
                    ),
                    new State("StopBeforeRape",
                        new Taunt("You think you can just stop the Zol from becoming stronger?!", "NO MORTAL WILL RESIST THE CONSUMPTION OF THE ZOL!"),
                        new Flash(0x00FFFF, 1, 1),
                        new TossObject("Niolru", 2, 0, coolDown: 9999999),
                        new TossObject("Niolru", 2, 90, coolDown: 9999999),
                        new TossObject("Niolru", 2, 180, coolDown: 9999999),
                        new TossObject("Niolru", 2, 270, coolDown: 9999999),
                        new TimedTransition(4000, "BHell")
                        ),
                    new State("BHell",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new TimedTransition(12000, "Vulnerable1"),
                        new Shoot(8, count: 3, projectileIndex: 9, coolDown: 2000),
                        new State("22Idle",
                            new TimedTransition(1000, "22Spin")
                        ),
                        new State("22Spin",
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1200),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 1200, coolDownOffset: 200),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 1200, coolDownOffset: 400),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 1200, coolDownOffset: 600),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 1200, coolDownOffset: 800),
                                new Shoot(0, projectileIndex: 8, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 1200, coolDownOffset: 1000),
                                new TimedTransition(1200, "22Pause")
                        ),
                        new State("22Pause",
                           new Shoot(8, count: 8, projectileIndex: 3, coolDown: 9999),
                           new TimedTransition(3000, "22Idle")
                        )
                    ),
                    new State("Vulnerable1",
                        new Taunt("You are worthless beings!"),
                        new Prioritize(
                             new Follow(0.7, 8, 1),
                             new Wander(0.05)
                             ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HealSelf(coolDown: 8000, amount: 2500),
                        new Shoot(8, count: 10, shootAngle: 10, projectileIndex: 1, coolDown: new Cooldown(2000, 1000)),
                        new Shoot(8, count: 5, projectileIndex: 5, coolDown: 500, coolDownOffset: 1000),
                        new Grenade(2, 400, range: 9, coolDown: 5000),
                        new TimedTransition(8000, "Vulnerable")
                        ),
                    new State("Vulnerable",
                        new MoveTo(speed: 1, x: 13, y: 9),
                        new Flash(0xF000FF, 1, 2),
                        new TimedTransition(12000, "Nope")
                        ),
                    new State("Nope",
                        new Taunt("Nice try, but your power is worthless compared to mine.", "I shall not be brought down by weaklings.", "The Zol surges within me"),
                        new Flash(0x00FF00, 1, 3),
                        new ReturnToSpawn(1),
                        new HealSelf(coolDown: 10000, amount: 2500),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Servant of Darkness", 2, 0, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 45, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 90, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 135, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 180, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 225, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 270, coolDown: 9999999),
                        new TossObject("Servant of Darkness", 2, 315, coolDown: 9999999),
                        new TimedTransition(10000, "Start2")
                        ),
                    new State("ded",
                        new Flash(0xFFFFFF, 1, 3),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(true, "Awaited the day for me to be defeated...I will have vengeance."),
                        new ReturnToSpawn(1),
                        new TimedTransition(6000, "Success")
                        ),
                    new State("Success",
                        new AnnounceOnDeath("The Zol, a dark burden, seems to fade away slowly...once again.."),
                        new Shoot(8, count: 10, projectileIndex: 2, coolDown: 9999),
                        new Spawn("AH ULTRA Aldragine Loot Ctrl", givesNoXp: true),
                        new TransferDamageOnDeath("AH ULTRA Aldragine Loot Ctrl"),
                        new Suicide()
                        ),
                    new State("Failed",
                        new Flash(0xFF0000, 1, 3),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(true, "I HAVE GAINED ENOUGH ZOL. THE WORLDS WILL SOON BE OURS..."),
                        new ReturnToSpawn(1),
                        new TimedTransition(6000, "Failure")
                        ),
                    new State("Failure",
                        new Shoot(8, count: 56, projectileIndex: 4, coolDown: 9999),
                        new Suicide()
                        )
                    )
                )
            ;
    }
}