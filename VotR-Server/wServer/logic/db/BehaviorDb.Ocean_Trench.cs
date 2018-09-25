using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Ocean_Trench = () => Behav()
          .Init("Coral Gift",
           new State(
            new State("Texture1",
             new SetAltTexture(1),
             new TimedTransition(500, "Texture2")
             ),
            new State("Texture2",
             new SetAltTexture(2),
             new TimedTransition(500, "Texture0")
             ),
            new State("Texture0",
             new SetAltTexture(0),
             new TimedTransition(500, "Texture1")
             )
             ),
            new Threshold(0.01,
            new ItemLoot("Coral Juice", 0.3),
                          new ItemLoot("Potion of Mana", 0.1),
                          new ItemLoot("Coral Bow", 0.02),
                          new ItemLoot("Coral Venom Trap", 0.03),
                          new ItemLoot("Coral Silk Armor", 0.04),
                          new ItemLoot("Coral Ring", 0.04)
                          )
           )

          .Init("Coral Bomb Big",
           new State(
            new State("Spawning",
             new TossObject("Coral Bomb Small", 1, angle: 30, coolDown: 500),
             new TossObject("Coral Bomb Small", 1, angle: 90, coolDown: 500),
             new TossObject("Coral Bomb Small", 1, angle: 150, coolDown: 500),
             new TossObject("Coral Bomb Small", 1, angle: 210, coolDown: 500),
             new TossObject("Coral Bomb Small", 1, angle: 270, coolDown: 500),
             new TossObject("Coral Bomb Small", 1, angle: 330, coolDown: 500),
             new TimedTransition(500, "Attack")
             ),
            new State("Attack",
             new Shoot(4.4, count: 5, fixedAngle: 0, shootAngle: 70),
             new Suicide()
             )
             )
             )
          .Init("Coral Bomb Small",
           new State(
            new State("Attack",
             new Shoot(3.8, count: 5, fixedAngle: 0, shootAngle: 70),
             new Suicide()
             )
             )
             )
          .Init("Deep Sea Beast",
           new State(
            new ChangeSize(11, 100),
            new Prioritize(
             new StayCloseToSpawn(0.2, 2),
             new Follow(0.2, acquireRange: 4, range: 1)
              ),
             new Shoot(1.8, count: 1, projectileIndex: 0, coolDown: 1000),
             new Shoot(2.5, count: 1, projectileIndex: 1, coolDown: 1000),
             new Shoot(3.3, count: 1, projectileIndex: 2, coolDown: 1000),
             new Shoot(4.2, count: 1, projectileIndex: 3, coolDown: 1000)
               )
               )

             .Init("Thessal the Mermaid Goddess",
           new State(
            new TransformOnDeath("Thessal the Mermaid Goddess Wounded", probability: 0.1),
            new State("Start",
             new Prioritize(
              new StayCloseToSpawn(0.3, 2),
              new Wander(0.3),
              new Follow(0.3, acquireRange: 10, range: 2)
             ),
             new EntityNotExistsTransition("Deep Sea Beast", 20, "Spawning Deep"),
             new HpLessTransition(1, "Attack1"),
             new HpLessTransition(0.5, "Attack2"),
             new TransformOnDeath("Thessal the Mermaid Goddess Wounded", probability: 0.1)
             ),
            new State("Spawning Bomb",
              new Prioritize(
              new StayCloseToSpawn(0.3, 2),
              new Wander(0.3)
             ),
             new TossObject("Coral Bomb Big", angle: 45),
             new TossObject("Coral Bomb Big", angle: 135),
             new TossObject("Coral Bomb Big", angle: 225),
             new TossObject("Coral Bomb Big", angle: 315),
             new TimedTransition(900, "Start")
             ),
            new State("Spawning Deep",
             new TossObject("Deep Sea Beast", 14, angle: 0),
             new TossObject("Deep Sea Beast", 14, angle: 90),
             new TossObject("Deep Sea Beast", 14, angle: 180),
             new TossObject("Deep Sea Beast", 14, angle: 270),
             new TimedTransition(1000, "Start")
             ),
            new State("Attack1",
             //new TimedTransition(2000, "Trident", randomized: true),
             new TimedTransition(2000, "Yellow Wall", randomized: true),
             new TimedTransition(2000, "Super Trident", randomized: true),
             new TimedTransition(2000, "Thunder Swirl", randomized: true),
             new TimedTransition(2000, "Spawning Bomb", randomized: true)
            ),
            new State("Thunder Swirl",
              new Prioritize(
              new Wander(0.3)
             ),
             new Shoot(10, count: 8, shootAngle: 360 / 8, projectileIndex: 0),
             new TimedTransition(501, "Start")
            ),
            new State("Trident",
              new Prioritize(
               new StayCloseToSpawn(0.3, 1),
              new Wander(0.3)
             ),
             new Shoot(21, count: 2, fixedAngle: 0, shootAngle: 10, projectileIndex: 1),
             new Shoot(21, count: 2, fixedAngle: 90, shootAngle: 10, projectileIndex: 1),
             new Shoot(21, count: 2, fixedAngle: 180, shootAngle: 10, projectileIndex: 1),
             new Shoot(21, count: 2, fixedAngle: 270, shootAngle: 10, projectileIndex: 1),
             new Shoot(21, count: 2, fixedAngle: 45, shootAngle: 10, projectileIndex: 1, coolDownOffset: 500),
             new Shoot(21, count: 2, fixedAngle: 135, shootAngle: 10, projectileIndex: 1, coolDownOffset: 500),
             new Shoot(21, count: 2, fixedAngle: 225, shootAngle: 10, projectileIndex: 1, coolDownOffset: 500),
             new Shoot(21, count: 2, fixedAngle: 315, shootAngle: 10, projectileIndex: 1, coolDownOffset: 500),
             new TimedTransition(501, "Start")
            ),
            new State("Super Trident",
              new Prioritize(
              new StayCloseToSpawn(0.3, 2),
              new Wander(0.3)
             ),
             new Shoot(21, count: 2, fixedAngle: 0, shootAngle: 10, projectileIndex: 2),
             new Shoot(21, count: 2, fixedAngle: 90, shootAngle: 10, projectileIndex: 2),
             new Shoot(21, count: 2, fixedAngle: 180, shootAngle: 10, projectileIndex: 2),
             new Shoot(21, count: 2, fixedAngle: 270, shootAngle: 10, projectileIndex: 2),
             new Shoot(21, count: 2, fixedAngle: 45, shootAngle: 10, projectileIndex: 2, coolDownOffset: 500),
             new Shoot(21, count: 2, fixedAngle: 135, shootAngle: 10, projectileIndex: 2, coolDownOffset: 500),
             new Shoot(21, count: 2, fixedAngle: 225, shootAngle: 10, projectileIndex: 2, coolDownOffset: 500),
             new Shoot(21, count: 2, fixedAngle: 315, shootAngle: 10, projectileIndex: 2, coolDownOffset: 500),
             new TimedTransition(501, "Start")
            ),
            new State("Yellow Wall",
             new Flash(0xFFFF00, .1, 15),
             new Prioritize(
              new ReturnToSpawn(2),
              new StayCloseToSpawn(0.3, 1)
             ),
             new Shoot(18, count: 30, fixedAngle: 6, projectileIndex: 3),
             new TimedTransition(501, "Start")
            ),
            new State("Attack2",
             new TimedTransition(2000, "Trident", randomized: true),
             new TimedTransition(2000, "Yellow Wall", randomized: true),
             new TimedTransition(2000, "Super Trident", randomized: true),
             new TimedTransition(2000, "Thunder Swirl", randomized: true),
             new TimedTransition(2000, "Spawning Bomb", randomized: true)
            )
            ),
                           new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
             new Threshold(0.01,
                 new ItemLoot("ShrimpQuiver", 0.04),
              new ItemLoot("Coral Bow", 0.04),
              new ItemLoot("Coral Venom Trap", 0.045),
              new ItemLoot("Coral Silk Armor", 0.04),
              new ItemLoot("Coral Ring", 0.55),
              new ItemLoot("Golden Conch", 0.05),
              new ItemLoot("Golden Cockle", 0.05),
              new ItemLoot("Golden Horn Conch", 0.05)
              ),
             new Threshold(0.2,
              new ItemLoot("Potion of Mana", 1),
              new ItemLoot("Potion of Wisdom", 0.5)
              )
          )
          .Init("Thessal the Mermaid Goddess Wounded",
           new State(
               new ConditionalEffect(ConditionEffectIndex.Invincible, true),
               new State("Say",
                   new Taunt("Is King Alexander alive?"),
                   new PlayerTextTransition("Throw Gifts", "HE LIVES AND REIGNS AND CONQUERS THE WORLD", 8, false, true),
                   new TimedTransition(12000, "Doom")
                   ),
               new State("Throw Gifts",
                   new Taunt("Thank you, kind sailor"),
                   new TossObject("Coral Gift", 4, 60, coolDown: 999999),
                   new TossObject("Coral Gift", 4, 180, coolDown: 999999),
                   new TossObject("Coral Gift", 4, 300, coolDown: 999999),
                   new TimedTransition(4000, "Suicide")
                   ),
               new State("Doom",
                   new Taunt("You speak LIES!"),
                   new SetAltTexture(1),
                   new Shoot(18, count: 30, fixedAngle: 6, projectileIndex: 3, coolDown: 1000),
                   new Shoot(18, count: 30, fixedAngle: 6, projectileIndex: 1, coolDown: 1500),
                   new Shoot(10, count: 8, shootAngle: 360 / 8, projectileIndex: 0, coolDown: 1250),
                   new TimedTransition(4000, "Suicide")
                   ),
               new State("Suicide",
                   new Suicide()
                   )
               )
             )
           .Init("Sea Horse",
                 new State(
                     new State(
                         new Prioritize(
                             new Protect(1, "Sea Mare"),
                             new Wander(1)
                         ),
                         new Shoot(7, count: 2, shootAngle: 10, coolDown: 660)

                     )
                 )
             )
          .Init("Sea Mare",
                 new State(
                     new Prioritize(
                         new Follow(.8, 10, 1),
                         new Wander(1)
                     ),
                     new Shoot(5, count: 3, shootAngle: 120, coolDown: 500),
                     new Shoot(3, count: 1, projectileIndex: 1, shootAngle: 0, coolDown: 1500)
             ),
                              new Threshold(0.2,
              new ItemLoot("Wavebreaker", 0.0001)
              )
            )
            .Init("Giant Squid",
                 new State(
                     new Prioritize(
                         new Follow(.8, 10, 1),
                          new Wander(1)
                     ),
                     new Shoot(10, count: 1, shootAngle: 0, coolDown: 250),
                     new TossObject("Ink Bubble", 7, angle: null, coolDown: 1000)

             ))
          .Init("Ink Bubble",
                 new State(
                     new Shoot(1, count: 1, shootAngle: 0, coolDown: 200)
                     ))
          .Init("Sea Slurp Home",
                 new State(
                     new Shoot(4, count: 8, shootAngle: 45, coolDown: 500),
                     new Shoot(2, count: 8, shootAngle: 45, projectileIndex: 1, coolDown: 500),
                     new Spawn("Grey Sea Slurp", 8, coolDown: 1000)
                     ))
         .Init("Grey Sea Slurp",
                 new State(
                     new State(
                         new Prioritize(
                             new Protect(1, "Sea Slurp Home"),
                             new Wander(1)
                         ),
                         new Shoot(8, count: 1, shootAngle: 0, coolDown: 500),
                         new Shoot(4, count: 8, shootAngle: 45, projectileIndex: 1, coolDown: 500)

                     )
                 )
             );
    }
}