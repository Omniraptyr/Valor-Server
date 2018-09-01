using wServer.logic.transitions;
using wServer.logic.behaviors;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Swamp = () => Behav()
            .Init("swmp Swamp Spirit",
                new State(
                    new State("1",
                        new Wander(.4),
                        new Shoot(15, 4, 9, 0, predictive: 1, coolDown: 1000),
                        new Shoot(22, 1, projectileIndex: 0, predictive: 0.5, coolDown: 500),
                        new Shoot(21, 8, 45, 1, angleOffset: 0, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(21, 8, 45, 1, angleOffset: 45, coolDown: 1000, coolDownOffset: 1000),
                        new HpLessTransition(.500, "2")
                        ),
                    new State("2",
                        new ReturnToSpawn(.5),
                        new ConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Flash(0x09cc09, 1, 2),
                        new TimedTransition(2000, "3")
                        ),
                    new State("3",
                        new RemoveConditionalEffect(common.resources.ConditionEffectIndex.Invulnerable),
                        new Flash(0x09cc09, 1, 10),
                        new Shoot(21, 20, shootAngle: 8, projectileIndex: 1, fixedAngle: 180, angleOffset: 0, coolDown: 10000, coolDownOffset: 2000),
                        new Shoot(21, 20, shootAngle: 8, projectileIndex: 1, fixedAngle: 180, angleOffset: 288, coolDown: 10000, coolDownOffset: 4000),
                        new Shoot(21, 20, shootAngle: 8, projectileIndex: 1, fixedAngle: 180, angleOffset: 216, coolDown: 10000, coolDownOffset: 6000),
                        new Shoot(21, 20, shootAngle: 8, projectileIndex: 1, fixedAngle: 180, angleOffset: 144, coolDown: 10000, coolDownOffset: 8000),
                        new Shoot(21, 20, shootAngle: 8, projectileIndex: 1, fixedAngle: 180, angleOffset: 72, coolDown: 10000, coolDownOffset: 10000),
                        new TimedTransition(10000, "4")
                        ),
                    new State("4",
                        new Shoot(15, 5, 20, 0, predictive: 1, coolDown: 1000),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 0, coolDown: 10000, coolDownOffset: 200),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 20, coolDown: 10000, coolDownOffset: 400),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 40, coolDown: 10000, coolDownOffset: 600),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 60, coolDown: 10000, coolDownOffset: 800),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 80, coolDown: 10000, coolDownOffset: 1000),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 100, coolDown: 10000, coolDownOffset: 1200),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 120, coolDown: 10000, coolDownOffset: 1400),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 140, coolDown: 10000, coolDownOffset: 1600),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 160, coolDown: 10000, coolDownOffset: 1800),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 180, coolDown: 10000, coolDownOffset: 2000),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 180, coolDown: 10000, coolDownOffset: 2200),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 160, coolDown: 10000, coolDownOffset: 2400),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 140, coolDown: 10000, coolDownOffset: 2600),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 120, coolDown: 10000, coolDownOffset: 2800),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 100, coolDown: 10000, coolDownOffset: 3000),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 80, coolDown: 10000, coolDownOffset: 3200),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 60, coolDown: 10000, coolDownOffset: 3400),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 40, coolDown: 10000, coolDownOffset: 3600),
                            new Shoot(21, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 20, coolDown: 10000, coolDownOffset: 3800),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 0, coolDown: 10000, coolDownOffset: 4000),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 0, coolDown: 10000, coolDownOffset: 4200),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 20, coolDown: 10000, coolDownOffset: 4400),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 40, coolDown: 10000, coolDownOffset: 4600),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 60, coolDown: 10000, coolDownOffset: 4800),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 80, coolDown: 10000, coolDownOffset: 5000),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 100, coolDown: 10000, coolDownOffset: 5200),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 120, coolDown: 10000, coolDownOffset: 5400),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 140, coolDown: 10000, coolDownOffset: 5600),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 160, coolDown: 10000, coolDownOffset: 5800),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 180, coolDown: 10000, coolDownOffset: 6000),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 180, coolDown: 10000, coolDownOffset: 6200),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 160, coolDown: 10000, coolDownOffset: 6400),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 140, coolDown: 10000, coolDownOffset: 6600),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 120, coolDown: 10000, coolDownOffset: 6800),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 100, coolDown: 10000, coolDownOffset: 7000),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 80, coolDown: 10000, coolDownOffset: 7200),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 60, coolDown: 10000, coolDownOffset: 7400),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 40, coolDown: 10000, coolDownOffset: 7600),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 20, coolDown: 10000, coolDownOffset: 7800),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 0, coolDown: 10000, coolDownOffset: 8000),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 0, coolDown: 10000, coolDownOffset: 8200),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 20, coolDown: 10000, coolDownOffset: 8400),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 40, coolDown: 10000, coolDownOffset: 8600),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 60, coolDown: 10000, coolDownOffset: 8800),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 80, coolDown: 10000, coolDownOffset: 9000),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 100, coolDown: 10000, coolDownOffset: 9200),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 120, coolDown: 10000, coolDownOffset: 9400),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 140, coolDown: 10000, coolDownOffset: 9600),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 160, coolDown: 10000, coolDownOffset: 9800),
                            new Shoot(15, projectileIndex: 1, count: 4, fixedAngle: 90, angleOffset: 180, coolDown: 10000, coolDownOffset: 10000),
                            new TimedTransition(10000, "3")
                        )
                    )
            )
        ;
    }
}
