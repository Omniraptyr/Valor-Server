#region

using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Tomb = () => Behav()
            .Init("Tomb Defender",
                new State(
                    new State("idle",
                        new Taunt("THIS WILL NOW BE YOUR TOMB!"),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Orbit(.6, 5, target: "Tomb Boss Anchor", radiusVariance: 0.5),
                        new HpLessTransition(.99, "weakning")
                        ),
                    new State("weakning",
                        new Orbit(.6, 5, target: "Tomb Boss Anchor", radiusVariance: 0.5),
                        new Taunt("Impudence! I am an immortal, I needn't take you seriously."),
                        new Shoot(50, 24, projectileIndex: 3, coolDown: 6000, coolDownOffset: 2000),
                        new HpLessTransition(.97, "active")
                        ),
                    new State("active",
                        new Orbit(.7, 5, target: "Tomb Boss Anchor", radiusVariance: 0.5),
                        new Taunt("The others use tricks, but I shall stun you with my brute strength!"),
                        new Shoot(50, 8, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(50, 4, projectileIndex: 1, coolDown: 3000, coolDownOffset: 500),
                        new Shoot(50, 6, projectileIndex: 0, coolDown: 3100, coolDownOffset: 500),
                        new HpLessTransition(.9, "boomerang")
                        ),
                    new State("boomerang",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Orbit(.6, 5, target: "Tomb Boss Anchor", radiusVariance: 0.5),
                        new Taunt("Nut, disable our foes!"),
                        new Shoot(50, 8, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(50, 8, 10, 1, coolDown: 4750, coolDownOffset: 500),
                        new Shoot(50, 1, 10, 0, coolDown: 4750, coolDownOffset: 500),
                        new HpLessTransition(.66, "double shot")
                        ),
                    new State("double shot",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Orbit(.7, 5, target: "Tomb Boss Anchor", radiusVariance: 0.5),
                        new Shoot(50, 8, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(50, 8, 10, 1, coolDown: 4750, coolDownOffset: 500),
                        new Shoot(50, 2, 10, 0, coolDown: 4750, coolDownOffset: 500),
                        new HpLessTransition(.5, "artifacts")
                        ),
                    new State("triple shot",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Orbit(.6, 5, target: "Tomb Boss Anchor", radiusVariance: 0.5),
                        new Taunt("Awe at my wondrous defense!"),
                        new Shoot(50, 8, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(50, 8, 10, 1, coolDown: 4750, coolDownOffset: 500),
                        new Shoot(50, 3, 10, 0, coolDown: 4750, coolDownOffset: 500),
                        new HpLessTransition(.2, "rage")
                        ),
                    new State("artifacts",
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Taunt("My artifacts shall prove my wall of defense is impenetrable!"),
                        new Orbit(.6, 5, target: "Tomb Boss Anchor", radiusVariance: 0.5),
                        new Shoot(50, 8, projectileIndex: 2, coolDown: 1000, coolDownOffset: 500),
                        new Shoot(50, 8, 10, 1, coolDown: 4750, coolDownOffset: 500),
                        new Shoot(50, 2, 10, 0, coolDown: 4750, coolDownOffset: 500),
                        new Spawn("Pyramid Artifact 1", 3, 3, 2000),
                        new Reproduce("Pyramid Artifact 1", 10, 3, 1500),
                        new Spawn("Pyramid Artifact 2", 3, 0, 3500000),
                        new Reproduce("Pyramid Artifact 2", 10, 3, 1500),
                        new Spawn("Pyramid Artifact 3", 3, 0, 3500000),
                        new Reproduce("Pyramid Artifact 3", 10, 3, 1500),
                        new HpLessTransition(.33, "triple shot")
                        ),
                    new State("rage",
                        new Taunt("The end of your path is here!"),
                        new Follow(1.3, range: 1, duration: 5000, coolDown: 0),
                        new Flash(0xfFF0000, 1, 9000001),
                        new Shoot(50, 8, 10, 1, coolDown: 4750, coolDownOffset: 500),
                        new Shoot(50, 4, 10, 4, coolDown: 300),
                        new Shoot(50, 3, 10, 0, coolDown: 4750, coolDownOffset: 500)
                        )
                    ),
                 new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                    new Threshold(0.32,
                        new ItemLoot("Onrane", 0.75),
                        new ItemLoot("Gold Cache", 0.02),
                        new ItemLoot("Potion of Life", 1)
                    ),
                    new Threshold(0.1,
                        new ItemLoot("Ring of the Pyramid", 0.1),
                        new ItemLoot("Tome of Holy Protection", 0.4)
                    ),
                    new Threshold(0.2
                    )
            )
            .Init("Tomb Support",
                                new State(
                                        new Taunt(0.99, "ENOUGH OF YOUR VANDALISM!"),
                                        new State("Idle",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new EntityNotExistsTransition("Tomb Boss Anchor", 50, "IdlePhase1"),
                                                new EntityExistsTransition("Tomb Boss Anchor", 50, "IdlePhase2")
                                        ),
                                        new State("IdlePhase1",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new HpLessTransition(0.99, "Phase1")
                                        ),
                                        new State("IdlePhase2",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new HpLessTransition(0.98, "2Phase1")
                                        ),
                                        //                                      If Anchor Don't Exist
                                        new State("Phase1",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new Prioritize(
                                                        new Wander(0.3)
                                                ),
                                                new HealSelf(coolDown: 6000),
                                                new HpLessTransition(0.97, "Phase2")
                                        ),
                                        new State("Phase2",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new Prioritize(
                                                        new Wander(0.3)
                                                ),
                                                new HealGroup(1, "Tomb Bosses", coolDown: 1500, healAmount: 1500),
                                                new Shoot(60, count: 15, fixedAngle: 360 / 15, projectileIndex: 7, coolDown: 10000),
                                                new HpLessTransition(0.94, "Phase3")
                                        ),

                                        new State("Phase3",
                                                new Prioritize(
                                                        new Wander(0.3)
                                                ),
                                                new HealGroup(1, "Tomb Bosses", coolDown: 1500, healAmount: 1500),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 3000),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 1000),
                                                new HpLessTransition(0.92, "Phase4")
                                        ),
                                        new State("Phase4",
                                                new Prioritize(
                                                        new Wander(0.3)
                                                ),
                                                new HealGroup(1, "Tomb Bosses", coolDown: 2500, healAmount: 1500),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 3000),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 1000),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 2000),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 3000),
                                                new HpLessTransition(0.80, "Phase5")
                                        ),
                                        new State("Phase5",
                                                new Prioritize(
                                                        new Wander(0.4)
                                                ),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 3000),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 1000),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 2700),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 3000),
                                                new Shoot(16, count: 6, shootAngle: 360 / 6, projectileIndex: 4, coolDown: 2000),
                                                new Shoot(16, count: 5, shootAngle: 360 / 5, projectileIndex: 3, coolDown: 2500),
                                                new HpLessTransition(0.60, "Phase6")
                                        ),
                                        new State("Phase6",
                                                new Prioritize(
                                                        new Wander(0.4)
                                                ),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 2600),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 800),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 2000),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 2400),
                                                new Shoot(16, count: 6, shootAngle: 360 / 6, projectileIndex: 4, coolDown: 1500),
                                                new Shoot(16, count: 5, shootAngle: 360 / 5, projectileIndex: 3, coolDown: 1800),
                                                new Shoot(40, count: 2, fixedAngle: 140, shootAngle: 9, projectileIndex: 8, coolDown: 1000),
                                                new HpLessTransition(0.50, "Phase7")
                                        ),
                                        new State("Phase7",
                                                new Taunt(0.99, "My artifacts shall make your lethargic lives end much more swiftly!"),
                                                new Prioritize(
                                                        new Wander(0.4)
                                                ),
                                                new Spawn("Sphinx Artifact 1", 3, initialSpawn: 1),
                                                new Spawn("Sphinx Artifact 2", 3, initialSpawn: 1),
                                                new Spawn("Sphinx Artifact 3", 3, initialSpawn: 1),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 2600),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 800),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 2000),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 2400),
                                                new Shoot(16, count: 6, shootAngle: 360 / 6, projectileIndex: 4, coolDown: 1500),
                                                new Shoot(16, count: 5, shootAngle: 360 / 5, projectileIndex: 3, coolDown: 1800),
                                                new HpLessTransition(0.30, "Phase8")
                                        ),
                                        new State("Phase8",
                                                new Prioritize(
                                                        new Wander(0.6)
                                                ),
                                                new Spawn("Sphinx Artifact 1", 3, coolDown: 20000),
                                                new Spawn("Sphinx Artifact 2", 3, coolDown: 20000),
                                                new Spawn("Sphinx Artifact 3", 3, coolDown: 20000),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 2300),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 800),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 1700),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 2000),
                                                new Shoot(16, count: 6, shootAngle: 360 / 6, projectileIndex: 4, coolDown: 1300),
                                                new Shoot(16, count: 5, shootAngle: 360 / 5, projectileIndex: 3, coolDown: 1500),
                                                new HpLessTransition(0.10, "Rage")
                                        ),
                                        new State("Rage",
                                                new Taunt(0.99, "This cannot be! You shall not succeed!"),
                                                new Flash(0xFF0000, .1, 1000),
                                                new Prioritize(
                                                        new Follow(1, 10, 3)
                                                ),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 2600),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 800),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 2000),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 2400),
                                                new Shoot(16, count: 6, shootAngle: 360 / 6, projectileIndex: 4, coolDown: 1500),
                                                new Shoot(16, count: 5, shootAngle: 360 / 5, projectileIndex: 3, coolDown: 1800),
                                                new Shoot(40, count: 7, fixedAngle: 160, shootAngle: 12, projectileIndex: 8, coolDown: 1500)
                                        ),
                                        new State("2Phase1",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new HealGroup(1, "Tomb Bosses", coolDown: 1500, healAmount: 1500),
                                                new HpLessTransition(0.97, "2Phase2")
                                        ),
                                        new State("2Phase2",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new HealGroup(1, "Tomb Bosses", coolDown: 1500, healAmount: 1500),
                                                new Shoot(60, count: 15, fixedAngle: 360 / 15, projectileIndex: 7, coolDown: 10000),
                                                new HpLessTransition(0.94, "2Phase3")
                                        ),

                                        new State("2Phase3",
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new HealGroup(1, "Tomb Bosses", coolDown: 1500, healAmount: 1500),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 3000),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 1000),
                                                new HpLessTransition(0.92, "2Phase4")
                                        ),
                                        new State("2Phase4",
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new HealGroup(1, "Tomb Bosses", coolDown: 1500, healAmount: 1500),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 3000),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 1000),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 2000),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 3000),
                                                new HpLessTransition(0.80, "2Phase5")
                                        ),
                                        new State("2Phase5",
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 3000),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 1000),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 2700),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 3000),
                                                new Shoot(16, count: 6, shootAngle: 360 / 6, projectileIndex: 4, coolDown: 2000),
                                                new Shoot(16, count: 5, shootAngle: 360 / 5, projectileIndex: 3, coolDown: 2500),
                                                new HpLessTransition(0.60, "2Phase6")
                                        ),
                                        new State("2Phase6",
                                                new Prioritize(
                                                        new Orbit(0.4, 5, 20, "Tomb Boss Anchor")
                                                ),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 2600),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 800),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 2700),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 3000),
                                                new Shoot(16, count: 6, shootAngle: 360 / 6, projectileIndex: 4, coolDown: 2000),
                                                new Shoot(16, count: 5, shootAngle: 360 / 5, projectileIndex: 3, coolDown: 2500),
                                                new Shoot(40, count: 4, fixedAngle: 140, shootAngle: 9, projectileIndex: 8, coolDown: 1000),
                                                new HpLessTransition(0.50, "2Phase7")
                                        ),
                                        new State("2Phase7",
                                                new Taunt(0.99, "My artifacts shall make your lethargic lives end much more swiftly!"),
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new Spawn("Sphinx Artifact 1", 3, initialSpawn: 1),
                                                new Spawn("Sphinx Artifact 2", 3, initialSpawn: 1),
                                                new Spawn("Sphinx Artifact 3", 3, initialSpawn: 1),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 2600),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 800),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 2700),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 3000),
                                                new Shoot(16, count: 6, shootAngle: 360 / 6, projectileIndex: 4, coolDown: 2000),
                                                new Shoot(16, count: 5, shootAngle: 360 / 5, projectileIndex: 3, coolDown: 2500),
                                                new HpLessTransition(0.30, "2Phase8")
                                        ),
                                        new State("2Phase8",
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new Spawn("Sphinx Artifact 1", 3, coolDown: 20000),
                                                new Spawn("Sphinx Artifact 2", 3, coolDown: 20000),
                                                new Spawn("Sphinx Artifact 3", 3, coolDown: 20000),
                                                new Shoot(16, count: 1, projectileIndex: 6, coolDown: 2300),
                                                new Shoot(32, count: 1, projectileIndex: 5, coolDown: 800),
                                                new Shoot(16, count: 3, shootAngle: 360 / 3, projectileIndex: 1, coolDown: 2700),
                                                new Shoot(16, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 3000),
                                                new Shoot(16, count: 6, shootAngle: 360 / 6, projectileIndex: 4, coolDown: 2000),
                                                new Shoot(16, count: 5, shootAngle: 360 / 5, projectileIndex: 3, coolDown: 2500),
                                                new HpLessTransition(0.10, "Rage")
                                        )
                                ),
                 new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                                new Threshold(0.01,
                                        new ItemLoot("Onrane", 0.75),
                                        new ItemLoot("Gold Cache", 0.02),
                                        new ItemLoot("Potion of Life", 1),
                                        new ItemLoot("Potion of Vitality", 0.8),
                                        new ItemLoot("Ring of the Sphinx", 0.1)
                                )
                        )

           .Init("Tomb Attacker",
                                new State(
                                        new Taunt(0.99, "YOU HAVE AWAKENED US!"),
                                        new State("Idle",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new EntityNotExistsTransition("Tomb Boss Anchor", 50, "IdlePhase1"),
                                                new EntityExistsTransition("Tomb Boss Anchor", 50, "IdlePhase2")
                                        ),
                                        new State("IdlePhase1",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new HpLessTransition(0.99, "1Phase")
                                        ),
                                        new State("IdlePhase2",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new HpLessTransition(0.98, "1Phase2")
                                        ),
                                        //                                      If Anchor Don't Exist
                                        new State("1Phase",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new Taunt(0.99, "Nut, protect me at once!"),
                                                new Prioritize(
                                                        new Wander(0.3)
                                                ),
                                                new Shoot(60, count: 15, fixedAngle: 360 / 15, projectileIndex: 3, coolDown: 10000),
                                                new HpLessTransition(0.97, "2Phase")
                                        ),
                                        new State("2Phase",
                                                new Prioritize(
                                                        new Wander(0.4)
                                                ),
                                                new Shoot(20, count: 2, shootAngle: 12, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Grenade(3, 50, 7, coolDown: 3000),
                                                new HpLessTransition(.9, "3Phase")
                                        ),
                                        new State("3Phase",
                                                new Prioritize(
                                                        new Wander(0.4)
                                                ),
                                                new Spawn("Scarab", 3),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 3500),
                                                new Shoot(20, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 1500),
                                                new Shoot(20, count: 2, shootAngle: 12, projectileIndex: 5, coolDown: 1500),
                                                new Shoot(16, count: 1, projectileIndex: 0, coolDown: 2300),
                                                new Shoot(20, count: 1, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Grenade(3, 50, 7, coolDown: 2500),
                                                new HpLessTransition(.8, "4Phase")
                                                ),
                                        new State("4Phase",
                                                new Prioritize(
                                                        new Wander(0.4)
                                                ),
                                                new Spawn("Scarab", 3),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 3500),
                                                new Shoot(20, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 1500),
                                                new Shoot(20, count: 2, shootAngle: 12, projectileIndex: 5, coolDown: 1500),
                                                new Shoot(16, count: 1, projectileIndex: 0, coolDown: 2300),
                                                new Shoot(20, count: 1, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Grenade(3, 50, 7, coolDown: 2500),
                                                new HpLessTransition(.7, "5Phase")
                                        ),
                                        new State("5Phase",
                                                new Prioritize(
                                                        new Wander(0.4)
                                                ),
                                                new Spawn("Scarab", 3),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 3500),
                                                new Shoot(20, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 1500),
                                                new Shoot(20, count: 2, shootAngle: 12, projectileIndex: 5, coolDown: 1500),
                                                new Shoot(16, count: 1, projectileIndex: 0, coolDown: 2300),
                                                new Shoot(20, count: 1, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Grenade(3, 50, 7, coolDown: 2500),
                                                new HpLessTransition(.5, "6Phase")
                                        ),
                                        new State("6Phase",
                                                new Taunt(0.99, "My artifacts shall destroy from your soul to your flesh"),
                                                new Prioritize(
                                                        new Wander(0.4)
                                                ),
                                                new Spawn("Nile Artifact 1", 3, initialSpawn: 1),
                                                new Spawn("Nile Artifact 2", 3, initialSpawn: 1),
                                                new Spawn("Nile Artifact 3", 3, initialSpawn: 1),
                                                new Shoot(20, count: 5, shootAngle: 360 / 5, projectileIndex: 2, coolDown: 2000),
                                                new Shoot(20, count: 4, shootAngle: 40, projectileIndex: 5, coolDown: 1500),
                                                new Shoot(20, count: 3, shootAngle: 10, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 5000),
                                                new Shoot(16, count: 1, projectileIndex: 0, coolDown: 1500, predictive: 0.5),
                                                new Grenade(3, 50, 7, coolDown: 2000),
                                                new Reproduce("Scarab", 3, 3, coolDown: 10000),
                                                new HpLessTransition(0.30, "7Phase")
                                        ),
                                        new State("7Phase",
                                                new Prioritize(
                                                        new Wander(0.6)
                                                ),
                                                new Spawn("Nile Artifact 1", 3, coolDown: 20000),
                                                new Spawn("Nile Artifact 2", 3, coolDown: 20000),
                                                new Spawn("Nile Artifact 3", 3, coolDown: 20000),
                                                new Shoot(20, count: 5, shootAngle: 360 / 5, projectileIndex: 2, coolDown: 2000),
                                                new Shoot(20, count: 4, shootAngle: 40, projectileIndex: 5, coolDown: 1500),
                                                new Shoot(20, count: 3, shootAngle: 10, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 5000),
                                                new Shoot(16, count: 1, projectileIndex: 0, coolDown: 1500, predictive: 0.5),
                                                new Grenade(3, 50, 10, coolDown: 2000),
                                                new Reproduce("Scarab", 3, 3, coolDown: 10000),
                                                new HpLessTransition(0.10, "Rage")
                                        ),
                                        new State("Rage",
                                                new Taunt(0.99, "Argh! You shall pay for your crimes!"),
                                                new Flash(0xFF0000, 1, 1000),
                                                new Prioritize(
                                                        new StayBack(1, 7)
                                                ),
                                                new Spawn("Nile Artifact 1", 3, coolDown: 20000),
                                                new Spawn("Nile Artifact 2", 3, coolDown: 20000),
                                                new Spawn("Nile Artifact 3", 3, coolDown: 20000),
                                                new Reproduce("Scarab", 3, 3, coolDown: 5000),
                                                new Grenade(4, 50, 7, coolDown: 2000),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 3000),
                                                new Shoot(20, count: 1, fixedAngle: 10, projectileIndex: 5),
                                                new Shoot(20, count: 1, fixedAngle: 350, projectileIndex: 5),
                                                new Shoot(20, count: 1, projectileIndex: 2, coolDown: 500, predictive: 0.5)
                                        ),
                                        //                                                                                              IfAnchorExist
                                        new State("1Phase2",
                                                new ConditionalEffect(ConditionEffectIndex.Armored),
                                                new Taunt(0.99, "Nut, protect me at once!"),
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new Shoot(60, count: 15, fixedAngle: 360 / 15, projectileIndex: 3, coolDown: 10000),
                                                new HpLessTransition(0.97, "2Phase2")
                                        ),
                                        new State("2Phase2",
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new Shoot(20, count: 2, shootAngle: 12, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Grenade(3, 50, 7, coolDown: 3000),
                                                new HpLessTransition(.9, "3Phase2")
                                        ),
                                        new State("3Phase2",
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new Spawn("Scarab", 3),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 3500),
                                                new Shoot(20, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 1500),
                                                new Shoot(20, count: 2, shootAngle: 12, projectileIndex: 5, coolDown: 1500),
                                                new Shoot(16, count: 1, projectileIndex: 0, coolDown: 2300),
                                                new Shoot(20, count: 1, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Grenade(3, 50, 7, coolDown: 2500),
                                                new HpLessTransition(.8, "4Phase2")
                                        ),
                                        new State("4Phase2",
                                                new Prioritize(
                                                        new Orbit(0.4, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new Spawn("Scarab", 3),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 3500),
                                                new Shoot(20, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 1500),
                                                new Shoot(20, count: 2, shootAngle: 12, projectileIndex: 5, coolDown: 1500),
                                                new Shoot(16, count: 1, projectileIndex: 0, coolDown: 2300),
                                                new Shoot(20, count: 1, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Grenade(3, 50, 7, coolDown: 2500),
                                                new HpLessTransition(.7, "5Phase2")
                                        ),
                                        new State("5Phase2",
                                                new Prioritize(
                                                        new Orbit(0.6, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new Spawn("Scarab", 3),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 3500),
                                                new Shoot(20, count: 4, shootAngle: 360 / 4, projectileIndex: 2, coolDown: 1500),
                                                new Shoot(20, count: 2, shootAngle: 12, projectileIndex: 5, coolDown: 1500),
                                                new Shoot(16, count: 1, projectileIndex: 0, coolDown: 2300),
                                                new Shoot(20, count: 1, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Grenade(3, 50, 7, coolDown: 2500),
                                                new HpLessTransition(.5, "6Phase2")
                                        ),
                                        new State("6Phase2",
                                                new Taunt(0.99, "My artifacts shall destroy from your soul to your flesh"),
                                                new Prioritize(
                                                        new Orbit(0.6, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new Spawn("Nile Artifact 1", 3, initialSpawn: 1),
                                                new Spawn("Nile Artifact 2", 3, initialSpawn: 1),
                                                new Spawn("Nile Artifact 3", 3, initialSpawn: 1),
                                                new Shoot(20, count: 5, shootAngle: 360 / 5, projectileIndex: 2, coolDown: 2000),
                                                new Shoot(20, count: 4, shootAngle: 40, projectileIndex: 5, coolDown: 1500),
                                                new Shoot(20, count: 3, shootAngle: 10, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 5000),
                                                new Shoot(16, count: 1, projectileIndex: 0, coolDown: 1500, predictive: 0.5),
                                                new Grenade(3, 50, 7, coolDown: 2000),
                                                new Reproduce("Scarab", 3, 3, coolDown: 10000),
                                                new HpLessTransition(0.30, "7Phase2")
                                        ),
                                        new State("7Phase2",
                                                new Prioritize(
                                                        new Orbit(0.6, 3, 20, "Tomb Boss Anchor")
                                                ),
                                                new Spawn("Nile Artifact 1", 3, coolDown: 20000),
                                                new Spawn("Nile Artifact 2", 3, coolDown: 20000),
                                                new Spawn("Nile Artifact 3", 3, coolDown: 20000),
                                                new Shoot(20, count: 5, shootAngle: 360 / 5, projectileIndex: 2, coolDown: 2000),
                                                new Shoot(20, count: 4, shootAngle: 40, projectileIndex: 5, coolDown: 1500),
                                                new Shoot(20, count: 3, shootAngle: 10, projectileIndex: 2, coolDown: 500, predictive: 0.5),
                                                new Shoot(14.4, count: 8, fixedAngle: 360 / 8, projectileIndex: 1, coolDown: 5000),
                                                new Shoot(16, count: 1, projectileIndex: 0, coolDown: 1500, predictive: 0.5),
                                                new Grenade(3, 50, 10, coolDown: 2000),
                                                new Reproduce("Scarab", 3, 3, coolDown: 10000),
                                                new HpLessTransition(0.10, "Rage")
                                        )
                                ),
                 new MostDamagers(3,
                    LootTemplates.Sor5Perc()
                    ),
                                new Threshold(0.01,
                                        new ItemLoot("Onrane", 0.75),
                                        new ItemLoot("Gold Cache", 0.02),
                                        new ItemLoot("Potion of Attack", 0.8),
                                        new ItemLoot("Ring of the Nile", 0.1),
                                        new ItemLoot("Book of Geb", 0.042),
                                        new ItemLoot("Scepter of Geb", 0.042),
                                        new ItemLoot("Shendyt of Geb", 0.042)
                        )
                        )

            //Minions
            .Init("Pyramid Artifact 1",
                new State(
                    new Prioritize(
                        new Orbit(1, 2, target: "Tomb Defender", radiusVariance: 0.5),
                        new Follow(0.85, range: 1, duration: 5000, coolDown: 0)
                        ),
                    new Shoot(3, coolDown: 2500)
                    ))

            .Init("Pyramid Artifact 2",
                new State(
                    new Prioritize(
                        new Orbit(1, 2, target: "Tomb Attacker", radiusVariance: 0.5),
                        new Follow(0.85, range: 1, duration: 5000, coolDown: 0)
                        ),
                    new Shoot(3, coolDown: 2500)
                    ))

            .Init("Pyramid Artifact 3",
                new State(
                    new Prioritize(
                        new Orbit(1, 2, target: "Tomb Support", radiusVariance: 0.5),
                        new Follow(0.85, range: 1, duration: 5000, coolDown: 0)
                        ),
                    new Shoot(3, coolDown: 2500)
                    ))

            .Init("Tomb Defender Statue",
                new State(
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Inactive Sarcophagus", 1000, "checkActive"),
                        new EntityNotExistsTransition("Active Sarcophagus", 1000, "checkInactive")
                        ),
                    new State("checkActive",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Active Sarcophagus", 1000, "ItsGoTime")
                        ),
                    new State("checkInactive",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Inactive Sarcophagus", 1000, "ItsGoTime")
                        ),
                    new State("ItsGoTime",
                        new Taunt("THIS WILL NOW BE YOUR TOMB!"),
                        new Transform("Tomb Defender")
                        )
                    ))

            .Init("Tomb Support Statue",
                new State(
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Inactive Sarcophagus", 1000, "checkActive"),
                        new EntityNotExistsTransition("Active Sarcophagus", 1000, "checkInactive")
                        ),
                    new State("checkActive",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Active Sarcophagus", 1000, "ItsGoTime")
                        ),
                    new State("checkInactive",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Inactive Sarcophagus", 1000, "ItsGoTime")
                        ),
                    new State("ItsGoTime",
                        new Taunt("ENOUGH OF YOUR VANDALISM!"),
                        new Transform("Tomb Support")
                        )
                    ))

            .Init("Tomb Attacker Statue",
                new State(
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Inactive Sarcophagus", 1000, "checkActive"),
                        new EntityNotExistsTransition("Active Sarcophagus", 1000, "checkInactive")
                        ),
                    new State("checkActive",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Active Sarcophagus", 1000, "ItsGoTime")
                        ),
                    new State("checkInactive",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new EntityNotExistsTransition("Inactive Sarcophagus", 1000, "ItsGoTime")
                        ),
                    new State("ItsGoTime",
                        new Taunt("YOU HAVE AWAKENED US"),
                        new Transform("Tomb Attacker")
                        )
                    ))

            .Init("Inactive Sarcophagus",
                new State(
                    new State(
                        new EntityNotExistsTransition("Beam Priestess", 14, "checkPriest"),
                        new EntityNotExistsTransition("Beam Priest", 1000, "checkPriestess")
                        ),
                    new State("checkPriest",
                        new EntityNotExistsTransition("Beam Priest", 1000, "activate")
                        ),
                    new State("checkPriestess",
                        new EntityNotExistsTransition("Beam Priestess", 1000, "activate")
                        ),
                    new State("activate",
                        new Transform("Active Sarcophagus")
                        )
                    ))

            .Init("Scarab",
                new State(
                    new NoPlayerWithinTransition(7, "Idle"),
                    new PlayerWithinTransition(7, "Chase"),
                    new State("Idle",
                        new Wander(.1)
                    ),
                    new State("Chase",
                        new Follow(1.5, 7, 0),
                        new Shoot(3, projectileIndex: 1, coolDown: 500)
                    )
                )
                )

         .Init("Eagle Sentry",
                new State(
                    new NoPlayerWithinTransition(12, "Idle"),
                    new PlayerWithinTransition(12, "Chase"),
                    new State("Idle",
                        new Wander(.03)
                    ),
                    new State("Chase",
                        new Follow(.7, 7, 0),
                        new Shoot(25, 12, projectileIndex: 1, coolDown: 3000)
                    )
                )
                )

           .Init("Bloated Mummy",
                new State(
                    new NoPlayerWithinTransition(12, "Idle"),
                    new PlayerWithinTransition(12, "Chase"),
                    new State("Idle",
                        new Wander(.03)
                    ),
                    new State("Chase",
                        new Follow(.6, 7, 0),
                        new Reproduce("Scarab", 10, 3, 3000),
                        new Shoot(25, 22, projectileIndex: 0, coolDown: 2250)
                    )
                )
                )

             .Init("Lion Archer",
                new State(
                    new NoPlayerWithinTransition(12, "Idle"),
                    new PlayerWithinTransition(12, "Chase"),
                    new State("Idle",
                        new Wander(.03)
                    ),
                    new State("Chase",
                        new Follow(.4, 7, 0),
                        new Shoot(25, 3, projectileIndex: 1, coolDown: 1250),
                        new Shoot(25, 1, projectileIndex: 3, fixedAngle: 0, coolDown: 6000),
                        new Shoot(25, 1, projectileIndex: 3, fixedAngle: 90, coolDown: 6000),
                        new Shoot(25, 1, projectileIndex: 3, fixedAngle: 180, coolDown: 6000),
                        new Shoot(25, 1, projectileIndex: 3, fixedAngle: 270, coolDown: 6000)
                    )
                )
                )

        .Init("Jackal Warrior",
                new State(
                    new NoPlayerWithinTransition(12, "Idle"),
                    new PlayerWithinTransition(12, "Chase"),
                    new State("Idle",
                        new Wander(.03)
                    ),
                    new State("Chase",
                        new Follow(.9, 7, 0),

                        new Shoot(25, 1, shootAngle: 25, projectileIndex: 0, coolDown: 1250)
                    )
                )
                )

        .Init("Jackal Assassin",
                new State(
                    new NoPlayerWithinTransition(12, "Idle"),
                    new PlayerWithinTransition(12, "Chase"),
                    new State("Idle",
                        new Wander(.03)
                    ),
                    new State("Chase",
                        new Follow(.9, 7, 0),

                        new Shoot(25, 1, shootAngle: 25, projectileIndex: 0, coolDown: 1250)
                    )
                )
              )

            .Init("Jackal Veteran",
                new State(
                    new NoPlayerWithinTransition(12, "Idle"),
                    new PlayerWithinTransition(12, "Chase"),
                    new State("Idle",
                        new Wander(.03)
                    ),
                    new State("Chase",
                        new Follow(.9, 7, 0),

                        new Shoot(25, 1, shootAngle: 25, projectileIndex: 0, coolDown: 1250)
                    )
                )
             )

             .Init("Jackal Lord",
                new State(
                    new NoPlayerWithinTransition(12, "Idle"),
                    new PlayerWithinTransition(12, "Chase"),
                    new State("Idle",
                        new Wander(.03)
                    ),
                    new State("Chase",
                        new Follow(.9, 7, 0),
                        new Reproduce("Jackal Warrior", 10, 2, 10000),
                        new Reproduce("Jackal Veteran", 10, 1, 10000),
                        new Reproduce("Jackal Assassin", 10, 1, 10000),
                        new Shoot(25, 4, shootAngle: 25, projectileIndex: 0, coolDown: 1250)
                    )
                )
              )

            .Init("Active Sarcophagus",
                new State(
                    new State(
                        new HpLessTransition(95, "stun")
                        ),
                    new State("stun",
                        new Shoot(50, 8, 10, 0, coolDown: 1250, coolDownOffset: 500),
                        new Shoot(50, 8, 10, 0, coolDown: 1500, coolDownOffset: 1000),
                        new Shoot(50, 8, 10, 0, coolDown: 1750, coolDownOffset: 1500),
                        new TimedTransition(1500, "idle")
                        ),
                    new State("idle",
                        new ChangeSize(100, 100)
                        )
                    ),

                    new Threshold(0.32,
                        new ItemLoot("Potion of Speed", 0.15)
                    ),
                    new Threshold(0.2
                    )
            )

                    .Init("Beam Priest",
                new State(
                    new State("weakning",
                        new Orbit(.4, 6, target: "Active Sarcophagus", radiusVariance: 0.5),
                        new Shoot(50, 3, projectileIndex: 1, coolDown: 3500),
                        new Shoot(50, 6, projectileIndex: 0, coolDown: 7210)

                        )
                    )
            )
              .Init("Tomb Thunder Turret",
                new State(
                    new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2500, "Spin")
                    ),
                    new State("Spin",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(150, "Quadforce2")
                        ),
                        new State("Quadforce2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(150, "Quadforce3")
                        ),
                        new State("Quadforce3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(150, "Quadforce4")
                        ),
                        new State("Quadforce4",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce5")
                        ),
                        new State("Quadforce5",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(150, "Quadforce6")
                        ),
                        new State("Quadforce6",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(150, "Quadforce7")
                        ),
                        new State("Quadforce7",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(150, "Quadforce8")
                        ),
                        new State("Quadforce8",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(150, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                       new TimedTransition(5000, "Spin")
                    )
                )
            )

              .Init("Tomb Fire Turret",
                new State(
                    new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2500, "Spin")
                    ),
                    new State("Spin",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(150, "Quadforce2")
                        ),
                        new State("Quadforce2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(150, "Quadforce3")
                        ),
                        new State("Quadforce3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(150, "Quadforce4")
                        ),
                        new State("Quadforce4",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce5")
                        ),
                        new State("Quadforce5",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(150, "Quadforce6")
                        ),
                        new State("Quadforce6",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(150, "Quadforce7")
                        ),
                        new State("Quadforce7",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(150, "Quadforce8")
                        ),
                        new State("Quadforce8",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(150, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                       new TimedTransition(5000, "Spin")
                    )
                )
            )

        .Init("Tomb Frost Turret",
                new State(
                    new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2500, "Spin")
                    ),
                    new State("Spin",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(2000, "Pause"),
                        new State("Quadforce1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(150, "Quadforce2")
                        ),
                        new State("Quadforce2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(150, "Quadforce3")
                        ),
                        new State("Quadforce3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(150, "Quadforce4")
                        ),
                        new State("Quadforce4",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(150, "Quadforce5")
                        ),
                        new State("Quadforce5",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(150, "Quadforce6")
                        ),
                        new State("Quadforce6",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(150, "Quadforce7")
                        ),
                        new State("Quadforce7",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(150, "Quadforce8")
                        ),
                        new State("Quadforce8",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                            new Shoot(0, projectileIndex: 0, count: 5, shootAngle: 60, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(150, "Quadforce1")
                        )
                    ),
                    new State("Pause",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                       new TimedTransition(5000, "Spin")
                    )
                )
            )

        .Init("Beam Priestess",
                new State(
                    new State("weakning",
                        new Orbit(.6, 9, target: "Active Sarcophagus", radiusVariance: 0.5),
                        new Shoot(50, 6, projectileIndex: 1, coolDown: 3500),
                        new Shoot(50, 2, projectileIndex: 0, coolDown: 7210)

                        )
                    )
            )

            .Init("Tomb Boss Anchor",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new RealmPortalDrop(),
                    new State("Idle",
                        new EntitiesNotExistsTransition(300, "Death", "Tomb Support", "Tomb Attacker", "Tomb Defender",
                            "Active Sarcophagus", "Tomb Defender Statue", "Tomb Support Statue", "Tomb Attacker Statue")
                    ),
                    new State("Death",
                        new RemoveEntity(10, "Tomb Portal of Cowardice"),
                        new Suicide()
                    )
                )

            );
    }
}