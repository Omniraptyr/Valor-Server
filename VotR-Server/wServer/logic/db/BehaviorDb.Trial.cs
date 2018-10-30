using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Trial = () => Behav()

            .Init("CR Priest",
                  new State(
                    new TransformOnDeath("CR Corpse of Illusions", min: 1, max: 3, probability: 0.75),
                    new HpLessTransition(0.25, "dying"),
                    new State("gitgud",
                        new Follow(0.3, 8, 1),
                        new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 0, coolDown: 1400),
                        new Shoot(10, count: 2, shootAngle: 8, projectileIndex: 1, predictive: 1, coolDown: 3250),
                        new TimedTransition(4000, "gitgud2")
                        ),
                    new State("gitgud2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Follow(0.3, 8, 1),
                        new Shoot(10, count: 6, projectileIndex: 0, coolDown: 500),
                        new Shoot(10, count: 4, shootAngle: 8, projectileIndex: 1, predictive: 1, coolDown: 1000),
                        new TimedTransition(3000, "gitgud")
                        ),
                    new State("dying",
                    new Flash(0xFFFFFF, 1, 1),
                    new Taunt("STAY PUT, WEAKLING!"),
                    new Charge(0.25, coolDown: 4000),
                    new Shoot(10, count: 8, projectileIndex: 2, coolDown: 4000)
                       )
                    ),
                new ItemLoot("Magic Potion", 0.25)
              )

        .Init("CR Guardian of Illusionist",
                  new State(
                    new State("gitgud",
                        new Follow(0.6, 8, 1),
                        new Shoot(10, count: 3, projectileIndex: 0, coolDown: 1000),
                        new HpLessTransition(0.25, "gitgud2")
                        ),
                    new State("gitgud2",
                    new StayBack(0.3, 2),
                    new Shoot(10, count: 8, projectileIndex: 1, coolDown: 1900)
                       )
                    ),
                  new TierLoot(6, ItemType.Weapon, 0.2),
                  new TierLoot(7, ItemType.Weapon, 0.1)
                 )
        .Init("CR Executor of Illusionist",
                  new State(
                    new State("wander",
                        new Wander(0.4),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 400)
               )))
        .Init("CR Corpse of Illusions",
                  new State(
                    new State("wander",
                        new Follow(0.2, 8, 1),
                        new Shoot(10, count: 12, projectileIndex: 0, coolDown: 4000)
               )))
        .Init("CR Sorcerer of Illusionist",
                  new State(
                    new State("ShootStaff",
                        new Wander(0.42),
                        new Shoot(10, count: 7, shootAngle: 6, projectileIndex: 0, coolDown: 1000, coolDownOffset: 2000),
                        new TimedTransition(6000, "Ep")
                        ),
                    new State("Ep",
                    new BackAndForth(0.6, 2),
                    new HealSelf(coolDown: 2000),
                    new Shoot(10, count: 10, projectileIndex: 1, coolDown: 1000),
                    new TimedTransition(4000, "ShootStaff2")
                       ),
                   new State("ShootStaff2",
                        new Orbit(0.8, 2, target: null),
                        new Shoot(10, count: 1, projectileIndex: 2, coolDown: 1),
                        new TimedTransition(5000, "ShootStaff")
                        )
                    ),
                new ItemLoot("Magic Potion", 0.25),
                new ItemLoot("Health Potion", 0.25)
                 )
           .Init("CR Rogue of Illusionist",
                new State(
                  new State("fight",
                      new SetAltTexture(0),
                      new Wander(0.5),
                      new Grenade(2, 200, range: 7, coolDown: 2000),
                      new Shoot(10, count: 1, projectileIndex: 1, coolDown: 200),
                      new TimedTransition(4250, "fight1")
                      ),
                  new State("fight1",
                  new ConditionalEffect(ConditionEffectIndex.Invincible),
                  new SetAltTexture(1),
                  new Follow(1, 8, 1),
                  new PlayerWithinTransition(1, "HIYA")
                     ),
                  new State("HIYA",
                      new SetAltTexture(0),
                      new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1),
                      new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1, coolDownOffset: 1),
                      new TimedTransition(3000, "fight")
                      )
                  )
               )
        .Init("CR Illusion Manifestation",
                new State(
                  new Shoot(10, count: 10, projectileIndex: 0, coolDown: 1000),
                  new State("fight",
                      new Follow(0.4, 8, 1),
                      new Shoot(10, count: 8, shootAngle: 18, projectileIndex: 1, coolDown: 2000),
                      new Shoot(10, count: 4, shootAngle: 18, projectileIndex: 2, coolDown: 3700),
                      new TimedTransition(6000, "fight1")
                      ),
                  new State("fight1",
                  new Flash(0xFF0000, 1, 1),
                  new ConditionalEffect(ConditionEffectIndex.Armored),
                  new Orbit(0.8, 3, target: null),
                  new Shoot(10, count: 5, projectileIndex: 2, coolDown: 1000),
                  new TimedTransition(6000, "fight")
                     )
                  )
               )
             .Init("CR Golem of Illusions",
                new State(
                  new Shoot(10, count: 6, projectileIndex: 0, coolDown: 3000),
                  new State("fight",
                      new Follow(0.4, 8, 1),
                      new Shoot(10, count: 8, shootAngle: 18, projectileIndex: 1, coolDown: 2000)
                      )
                  )
               )
        .Init("CR Mini Blocker",
                new State(
                  new Orbit(0.4, 4, target: null),
                  new State("fight",
                      new Shoot(10, count: 3, projectileIndex: 0, coolDown: 2000)
                      )
                  )
               )
                .Init("CR Spawner 3",
            new State(
                new DropPortalOnDeath("Crypt of the Illusionist Portal", 100, timeout: 180),
                new ConditionalEffect(ConditionEffectIndex.Invincible),
                new State("idle",
                     new EntitiesNotExistsTransition(9999, "activate", "CR Illusion Manifestation")
                    ),
                new State("activate",
                     new Suicide()
                    )
                )
            )
              .Init("CR Illusion Manifestation A",
                new State(
                  new Shoot(10, count: 10, projectileIndex: 0, coolDown: 1000),
                  new State("fight",
                      new Follow(0.4, 8, 1),
                      new Shoot(10, count: 8, shootAngle: 18, projectileIndex: 1, coolDown: 2000),
                      new Shoot(10, count: 4, shootAngle: 18, projectileIndex: 2, coolDown: 3700),
                      new TimedTransition(6000, "fight1")
                      ),
                  new State("fight1",
                  new Flash(0xFF0000, 1, 1),
                  new ConditionalEffect(ConditionEffectIndex.Armored),
                  new Orbit(0.8, 3, target: null),
                  new Shoot(10, count: 5, projectileIndex: 2, coolDown: 1000),
                  new TimedTransition(6000, "fight")
                     )
                  )
               )
        .Init("CR Pillar of Illusions",
                new State(
                    new EntitiesNotExistsTransition(40, "dead", "The Illusionist"),
                    new ConditionalEffect(ConditionEffectIndex.StasisImmune),
                    new SetNoXP(),
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                  new State("activated1",
                      new SetAltTexture(0),
                      new Shoot(10, count: 8, projectileIndex: 0, coolDown: 6000),
                      new TimedTransition(8000, "activated2")
                      ),
                  new State("activated2",
                      new SetAltTexture(1),
                      new Shoot(10, count: 8, projectileIndex: 1, coolDown: 6000),
                      new TimedTransition(8000, "activated1")
                      ),
                  new State("dead",
                      new Suicide()
                      )
                  )
               )
              .Init("The Illusionist",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.StunImmune),
                    new DamageTakenTransition(80000, "sinkstate"),
                    new RealmPortalDrop(),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(12, "taunt")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("taunt",
                        new Taunt("Finally, you have found me. At a cost of course...."),
                        new TimedTransition(4000, "taunt2")
                        ),
                    new State("taunt2",
                        new Taunt("The time for you to face me at last.", "This is the day of reckoning, my friend."),
                        new TimedTransition(4000, "taunt3")
                        ),
                    new State("taunt3",
                        new Taunt("Banishment is near.", "You WILL be erased, {PLAYER}."),
                        new TimedTransition(4000, "startfirst")
                      ),
                    new State("startfirst",
                        new TossObject("CR Pillar of Illusions", 8, 0, coolDown: 9999999),
                        new TossObject("CR Pillar of Illusions", 8, 90, coolDown: 9999999),
                        new TossObject("CR Pillar of Illusions", 8, 180, coolDown: 9999999),
                        new TossObject("CR Pillar of Illusions", 8, 270, coolDown: 9999999),
                        new TimedTransition(5000, "start")
                        )
                      ),
                    new State("start",
                        new TossObject("CR Illusion Manifestation A", range: 8, coolDown: 8000),
                        new TossObject("CR Illusion Manifestation", range: 8, coolDown: 8000),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Wander(0.4),
                        new Shoot(10, count: 7, projectileIndex: 1, predictive: 1, coolDownOffset: 600, coolDown: 1800),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 1),
                        new TimedTransition(8000, "fight1")
                        ),
                    new State("fight1",
                        new Follow(0.4, 8, 1),
                        new Shoot(10, count: 8, shootAngle: 20, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 12, projectileIndex: 1, coolDown: 3000),
                        new Shoot(10, count: 6, shootAngle: 4, projectileIndex: 3, coolDown: 500),
                        new TimedTransition(5000, "return")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("return",
                        new ReturnToSpawn(speed: 0.5),
                        new SetAltTexture(1),
                        new TimedTransition(5000, "returntalk")
                        ),
                    new State("returntalk",
                        new Taunt("No longer will I put up with this foolishness."),
                        new TimedTransition(4000, "command")
                        )
                      ),
                    new State("command",
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1),
                        new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1, coolDownOffset: 1),
                        new Shoot(10, count: 16, projectileIndex: 1, coolDown: 2000),
                        new TimedTransition(6000, "basictwo")
                        ),
                    new State("basictwo",
                        new Shoot(10, count: 10, shootAngle: 6, projectileIndex: 1, coolDown: 3000),
                        new TimedTransition(6000, "Orbit")
                        ),
                    new State("Orbit",
                        new TossObject("CR Mini Blocker", range: 6, coolDown: 4000),
                        new Orbit(0.5, 5, target: null),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 3, shootAngle: 6, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, coolDown: 1000),
                        new TimedTransition(8000, "start")
                        ),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                    new State("sinkstate",
                        new ReturnToSpawn(speed: 0.6),
                        new SetAltTexture(1),
                        new TimedTransition(5000, "returntalk5")
                        ),
                    new State("returntalk5",
                        new Taunt(true, "DIE!"),
                        new Shoot(10, count: 5, shootAngle: 6, projectileIndex: 2, coolDown: 2000),
                        new Shoot(10, count: 8, projectileIndex: 0, coolDown: 6000),
                        new Shoot(10, count: 1, projectileIndex: 1, coolDown: 200),
                        new TimedTransition(4000, "start")
                        )
                      )
                    ),
                                new MostDamagers(3,
                    LootTemplates.SorRare()
                    ),
                new Threshold(0.05,
                    new ItemLoot("Potion of Mana", 1.0),
                    new ItemLoot("Potion of Protection", 1.0),
                    new TierLoot(11, ItemType.Weapon, 0.1),
                    new TierLoot(12, ItemType.Armor, 0.1),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(5, ItemType.Ring, 0.05),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new ItemLoot("Onrane", 0.8),
                    new ItemLoot("Gold Cache", 0.4),
                    new ItemLoot("Warped Worlds Staff", 0.005),
                    new ItemLoot("Null-Magic Trap", 0.005),
                    new ItemLoot("Mirage Lance", 0.005)
                )
            )
    ;
    }
}