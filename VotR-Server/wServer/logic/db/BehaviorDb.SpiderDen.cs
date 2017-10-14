using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Spider_Den = () => Behav()
             .Init("Spider Egg Sac",
             new State(
                 new TransformOnDeath("Green Den Spider Hatchling", min: 3, max: 8),
                 new State("Idle",
                     new PlayerWithinTransition(1, "Open")
                     ),
                 new State("Open",
                     new Spawn("Green Den Spider Hatchling", 8, 1, coolDown: 500),
                     new Decay(0)
                     )
                 )
                )
             .Init("Green Den Spider Hatchling",
                 new State(
                     new Prioritize(
                         new StayAbove(0.4, 160),
                         new Follow(0.4, acquireRange: 9, range: 3.5, duration: 4),
                         new Wander(0.4)
                         ),
                     new Shoot(8, predictive: 0.2)
                        )
                        )
             .Init("Black Den Spider",
                 new State(
                     new State("Wander",
                         new StayAbove(0.2, 50),
                         new Wander(0.4),
                         new PlayerWithinTransition(7, "Attack")
                             ),
                     new State("Attack",
                         new StayAbove(0.2, 50),
                         new Prioritize(
                             new Charge(2),
                             new Wander(0.4)
                             ),
                         new Shoot(5, predictive: 1),
                         new TimedTransition(1000, "Wander")
                         )
                   ),
                   new ItemLoot("Healing Ichor", .05)
                   )
             .Init("Brown Den Spider",
                 new State(
                     new State("Idle",
                         new StayAbove(0.2, 50),
                         new Wander(0.4),
                         new PlayerWithinTransition(7, "Attack")
                         ),
                     new State("Attack",
                         new Prioritize(
                             new StayAbove(0.4, 160),
                             new Follow(0.9, acquireRange: 9, range: 0),
                             new Wander(0.4)
                             ),
                         new Shoot(8, count: 3, shootAngle: 10, coolDown: 400),
                         new TimedTransition(10000, "Idle")
                         )
                         ),
                   new ItemLoot("Healing Ichor", .05)
                         )
             .Init("Black Spotted Den Spider",
                 new State(
                     new Wander(0.4),
                     new Shoot(7)
                     ),
                   new ItemLoot("Healing Ichor", .05)
                     )
             .Init("Red Spotted Den Spider",
                 new State(
                     new Prioritize(
                     new Follow(0.3, acquireRange: 10, range: 4),
                     new Wander(0.5)
                     ),
                     new Shoot(10)
                     ),
                   new ItemLoot("Healing Ichor", .05)
                     )
             .Init("Arachna the Spider Queen",
                 new State(
                     new State("Idle",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new PlayerWithinTransition(10, "MakeWeb")
                     ),
                     new State("MakeWeb",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new TossObject("Arachna Web Spoke 1", range: 10, angle: 0, coolDown: 100000),
                         new TossObject("Arachna Web Spoke 7", range: 6, angle: 0, coolDown: 100000),
                         new TossObject("Arachna Web Spoke 2", range: 10, angle: 60, coolDown: 100000),
                         new TossObject("Arachna Web Spoke 3", range: 10, angle: 120, coolDown: 100000),
                         new TossObject("Arachna Web Spoke 8", range: 6, angle: 120, coolDown: 100000),
                         new TossObject("Arachna Web Spoke 4", range: 10, angle: 180, coolDown: 100000),
                         new TossObject("Arachna Web Spoke 5", range: 10, angle: 240, coolDown: 100000),
                         new TossObject("Arachna Web Spoke 9", range: 6, angle: 240, coolDown: 100000),
                         new TossObject("Arachna Web Spoke 6", range: 10, angle: 300, coolDown: 100000),
                         new TimedTransition(3500, "Attack")
                         ),
                     new State("Attack",
                         new Shoot(1, projectileIndex: 0, count: 8, coolDown: 1200, shootAngle: 45, fixedAngle: 0),
                         new Shoot(10, projectileIndex: 1, coolDown: 2000),
                         new State("Follow",
                             new Prioritize(
                                 new StayAbove(.6, 1),
                                 new StayBack(.6, distance: 8),
                                 new Wander(.7)
                                 ),
                             new TimedTransition(1000, "Return")
                                 ),
                         new State("Return",
                             new StayCloseToSpawn(.4, 1),
                             new TimedTransition(1000, "Follow")
                             ))
                         ),
                     new ItemLoot("Healing Ichor", 0.75),
                     new ItemLoot("Golden Dagger", 0.5),
                     new ItemLoot("Poison Fang Dagger", 0.1),
                     new ItemLoot("Spider's Eye Ring", 0.1)
                         )
             .Init("Arachna Web Spoke 1",
                 new State(
                     new State("Attack",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(1, count: 3, fixedAngle: 180, shootAngle: 60, coolDown: 150),
                     new EntityNotExistsTransition("Arachna the Spider Queen", 1000, "Die")
                     ),
                     new State("Die",
                         new Decay(0)
                     )
                     )
                     )
             .Init("Arachna Web Spoke 2",
                 new State(
                     new State("Attack",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(1, count: 1, fixedAngle: 240, shootAngle: 60, coolDown: 150),
                     new EntityNotExistsTransition("Arachna the Spider Queen", 1000, "Die")
                     ),
                     new State("Die",
                         new Decay(0)
                     )
                     )
                     )
             .Init("Arachna Web Spoke 3",
                 new State(
                     new State("Attack",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(1, count: 3, fixedAngle: 300, shootAngle: 60, coolDown: 150),
                     new EntityNotExistsTransition("Arachna the Spider Queen", 1000, "Die")
                     ),
                     new State("Die",
                         new Decay(0)
                     )
                     )
                     )
             .Init("Arachna Web Spoke 4",
                 new State(
                     new State("Attack",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(1, count: 1, fixedAngle: 0, shootAngle: 60, coolDown: 150),
                     new EntityNotExistsTransition("Arachna the Spider Queen", 1000, "Die")
                     ),
                     new State("Die",
                         new Decay(0)
                     )
                     )
                     )
             .Init("Arachna Web Spoke 5",
                 new State(
                     new State("Attack",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(1, count: 3, fixedAngle: 60, shootAngle: 60, coolDown: 150),
                     new EntityNotExistsTransition("Arachna the Spider Queen", 1000, "Die")
                     ),
                     new State("Die",
                         new Decay(0)
                     )
                     )
                     )
             .Init("Arachna Web Spoke 6",
                 new State(
                     new State("Attack",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(1, count: 1, fixedAngle: 120, shootAngle: 60, coolDown: 150),
                     new EntityNotExistsTransition("Arachna the Spider Queen", 1000, "Die")
                     ),
                     new State("Die",
                         new Decay(0)
                     )
                     )
                     )
             .Init("Arachna Web Spoke 7",
                 new State(
                     new State("Attack",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(1, count: 3, fixedAngle: 180, shootAngle: 60, coolDown: 150),
                     new EntityNotExistsTransition("Arachna the Spider Queen", 1000, "Die")
                     ),
                     new State("Die",
                         new Decay(0)
                     )
                     )
                     )
             .Init("Arachna Web Spoke 8",
                 new State(
                     new State("Attack",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(1, count: 3, fixedAngle: 300, shootAngle: 60, coolDown: 150),
                     new EntityNotExistsTransition("Arachna the Spider Queen", 1000, "Die")
                     ),
                     new State("Die",
                         new Decay(0)
                     )
                     )
                     )
             .Init("Arachna Web Spoke 9",
                 new State(
                     new State("Attack",
                     new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                     new Shoot(1, count: 3, fixedAngle: 60, shootAngle: 60, coolDown: 150),
                     new EntityNotExistsTransition("Arachna the Spider Queen", 1000, "Die")
                     ),
                     new State("Die",
                         new Decay(0)
                     )
                     )
                     )
        ;
    }
}