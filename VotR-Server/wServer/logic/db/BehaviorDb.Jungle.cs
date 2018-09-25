using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Jungle = () => Behav()
        .Init("Mixcoatl the Masked God",
                new State(
                    new DropPortalOnDeath("Realm Portal", 100),
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Wander(0.5),
                        new PlayerWithinTransition(10, "Start")
                        ),
                    new State("Start",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(2),
                        new SetAltTexture(3),
                        new TimedTransition(200, "Start 2")
                        ),
                    new State("Start 2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new SetAltTexture(4),
                        new TimedTransition(200, "Start 3")
                        ),
                    new State("Start 3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new SetAltTexture(5),
                        new TimedTransition(200, "Start 4")
                        ),
                    new State("Start 4",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ReturnToSpawn(2),
                        new SetAltTexture(6),
                        new TimedTransition(400, "Start Fight")
                        ),
                     new State("Start Fight",
                        new ReturnToSpawn(2),
                        new Shoot(20, 3, shootAngle: 5, fixedAngle: 0, projectileIndex: 1, angleOffset: 0, coolDownOffset: 200),
                        new Shoot(20, 3, shootAngle: 5, fixedAngle: 0, projectileIndex: 1, angleOffset: 45, coolDownOffset: 400),
                        new Shoot(20, 3, shootAngle: 5, fixedAngle: 0, projectileIndex: 1, angleOffset: 90, coolDownOffset: 600),
                        new Shoot(20, 3, shootAngle: 5, fixedAngle: 0, projectileIndex: 1, angleOffset: 135, coolDownOffset: 800),
                        new Shoot(20, 3, shootAngle: 5, fixedAngle: 0, projectileIndex: 1, angleOffset: 180, coolDownOffset: 1000),
                        new Shoot(20, 3, shootAngle: 5, fixedAngle: 0, projectileIndex: 1, angleOffset: 225, coolDownOffset: 1200),
                        new Shoot(20, 3, shootAngle: 5, fixedAngle: 0, projectileIndex: 1, angleOffset: 270, coolDownOffset: 1400),
                        new Shoot(20, 3, shootAngle: 5, fixedAngle: 0, projectileIndex: 1, angleOffset: 315, coolDownOffset: 1600),
                        new TimedTransition(4000, "Start Fight 2")
                        ),
                      new State("Start Fight 2",
                        new ReturnToSpawn(2),
                        new Order(50, "Boss Totem", "Fire!"),
                        new SetAltTexture(1),
                        new Shoot(20, 8, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(5000, "Charge")
                        ),
                      new State("Charge",
                        new Prioritize(
                            new Follow(0.5, 10, 10),
                            new Wander(0.5)
                            ),
                        new ReturnToSpawn(2),
                        new Order(50, "Boss Totem", "Fire!"),
                        new SetAltTexture(1),
                        new Shoot(20, 8, fixedAngle: 45, projectileIndex: 0, coolDown: 400),
                        new TimedTransition(8000, "Start Fight")
                        )
                        ),
                     new Threshold(0.2,
                     new ItemLoot("Staff of the Crystal Serpent", .25),
                     new ItemLoot("Robe of the Tlatoani", .20),
                     new ItemLoot("Crystal Bone Ring", .15),
                     new ItemLoot("Cracked Crystal Skull", .20)
                     ),
                       new ItemLoot("Pollen Powder", 1),
                       new ItemLoot("Pollen Powder", 0.99),
                       new ItemLoot("Pollen Powder", 0.88)
            )
        .Init("Boss Totem",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible)
                        ),
                    new State("Fire!",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Shoot(10, 6, fixedAngle: 60, coolDown: 400),
                        new EntityNotExistsTransition("Mixcoatl the Masked God", 100, "Idle"),
                        new TimedTransition(4000, "Idle")
                        )))
         .Init("Totem Spirit",
                new State(
                    new State("Wander",
                        new Wander(0.4),
                        new StayCloseToSpawn(0.5, 3),
                        new Shoot(8, 1, 0, 0, coolDown: 750)
                        )))
        .Init("Jungle Totem",
                new State(
                    new State("Stand",
                        new Spawn("Totem Spirit", 3),
                        new Shoot(9, 9, 15, 0, coolDown: 1500)
                        )))
        .Init("Basilisk Baby",
                new State(
                    new State("Protect Mommy",
                        new Protect(0.4, "Basilisk", 8, 5, 4),
                        new Shoot(7, 1, 0, 0, coolDown: 750)
                        )))
        .Init("Basilisk",
                new State(
                    new State("Kill",
                        new Prioritize(
                        new Follow(0.6, 6, 1),
                        new Wander(0.5)
                        ),
                        new Shoot(6, 1, projectileIndex: 0, coolDown: 750),
                        new Shoot(6, 1, projectileIndex: 1, coolDown: 750),
                        new Shoot(6, 1, projectileIndex: 2, coolDown: 750),
                        new Shoot(6, 1, projectileIndex: 3, coolDown: 750)
                        )))
        .Init("Mask Shaman",
                new State(
                    new State("Circle",
                        new Orbit(0.4, 3, 10, "Jungle Fire"),
                        new HealGroup(8, "Mask Men", coolDown: 2000),
                        new Shoot(7, 8, 45, 0, coolDown: 1500),
                        new EntityNotExistsTransition("Jungle Fire", 5, "Wander")
                        ),
                    new State("Wander",
                        new Wander(0.4),
                        new HealGroup(8, "Mask Men", coolDown: 2000),
                        new Shoot(7, 8, 45, 0, coolDown: 1500)
                        )))
        .Init("Mask Warrior",
                new State(
                    new State("Protect",
                        new Protect(0.3, "Mask Shaman", 10, 2, 1),
                        new Shoot(7, 8, 45, 0, coolDown: 1500)
                        )))
        .Init("Mask Hunter",
                new State(
                    new State("Killa",
                    new Prioritize(
                        new Follow(0.8, 8, 1),
                        new Wander(0.5)
                        ),
                    new Shoot(8, 1, coolDown: 1000)
                        )))
         .Init("Jungle Fire",
                new State(
                    new State("Burn",
                        new Shoot(1, 1, 0, 0, coolDown: 1000),
                        new Shoot(7, 1, 0, 1, coolDownOffset: 500),
                        new Shoot(7, 1, 0, 1, coolDownOffset: 600),
                        new Shoot(7, 1, 0, 1, coolDownOffset: 700),
                        new Shoot(7, 1, 0, 1, coolDownOffset: 800)
                        )))
                    ;
    }
}