using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Palace = () => Behav()
           //TRoom Boss
           .Init("Construct of the Storm",
             new State(
                     new State("GetClose",
                         new PlayerWithinTransition(8, "state1")
                         ),
                     new State("state1",
                          new ConditionalEffect(ConditionEffectIndex.Armored),
                      new Taunt(1.00, "Fine. I must keep myself concealed!"),
                      new Shoot(6.3, count: 4, projectileIndex: 3, coolDown: 1700),
                      new Shoot(6.3, count: 6, projectileIndex: 2, coolDown: 3750),
                      new Grenade(6, 100, range: 8, fixedAngle: 90, coolDown: 3000),
                       new Grenade(6, 100, range: 8, fixedAngle: 0, coolDown: 3000),
                        new Grenade(6, 100, range: 8, fixedAngle: 180, coolDown: 3000),
                        new Grenade(6, 100, range: 8, fixedAngle: 270, coolDown: 3000),
                        new TimedTransition(10000, "state2"),
                        new HpLessTransition(0.30, "state2"),
                         new SetAltTexture(1),
                          new Shoot(6.3, count: 8, shootAngle: 60, projectileIndex: 2, coolDown: 1000)
                         ),
                     new State("state2",
                            new Taunt(1.00, "This form is sure to take you down!"),
                            new SetAltTexture(2),
                          new Wander(0.2),
                          new Shoot(6.3, count: 1, projectileIndex: 3, coolDown: 1700),
                          new Shoot(6.3, count: 10, projectileIndex: 0, coolDown: 5000),
                          new Shoot(6.3, count: 10, projectileIndex: 1, coolDown: 6000),
                         new ChangeSize(15, 140)
                         )
                 ),
                 new Threshold(0.18,
                     new ItemLoot("Potion of Speed", 0.8)
                 )
             )
           .Init("Hideout Thunder Walker",
                 new State(
                       new Wander(0.35),
                      new Shoot(8.4, count: 4, shootAngle: 10, projectileIndex: 0, predictive: 6, coolDown: 2500),
                      new Shoot(8.4, count: 2, projectileIndex: 0, coolDown: 1000),
                      new Grenade(1.5, 150, 4, coolDown: 3000)
                     )
             )
           .Init("Hideout Shocker Knight",
                 new State(
                      new Follow(1, 8, 1),
                      new Shoot(8.4, count: 1, shootAngle: 5, projectileIndex: 0, coolDown: 1800)
                     )
             )
                   .Init("Hideout Thunder Paladin",
                 new State(
                      new Follow(0.5, 8, 1),
                      new Shoot(8.4, count: 5, shootAngle: 5, projectileIndex: 0, coolDown: 1800)
                     )
             )
                   .Init("Hideout Thunder Fiend",
                 new State(
                      new Wander(0.1),
                      new Shoot(8.4, count: 4, shootAngle: 12, projectileIndex: 0, coolDown: 1000)
                     )
             )
                   .Init("Hideout Crawler",
                 new State(
                      new Orbit(0.8, 4),
                      new Shoot(8.4, count: 3, shootAngle: 6, projectileIndex: 0, coolDown: 600),
                      new Shoot(8.4, count: 6, projectileIndex: 0, coolDown: 600, coolDownOffset: 600)
                     )
             )
          .Init("Hideout Electric Overseer",
                         new State(
                     new State("Electrical",
                         new Swirl(0.65, 4, targeted: false),
                         new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                         new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 1000),
                         new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 1000),
                         new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 1000),
                     new HpLessTransition(0.35, "GetHelp")
                         ),
                     new State("GetHelp",
                         new Taunt(0.90, "The eye of the storm will consume you!"),
                          new Taunt(0.25, "I call upon the great Weather God to aid me!"),
                        new Spawn("Hideout Thunder Walker", initialSpawn: 1, maxChildren: 2, coolDown: 2000),
                        new Shoot(8.4, count: 2, projectileIndex: 0, coolDown: 1000),
                        new Follow(0.3, 8, 1)
                     )))
           .Init("Hideout Wraith",
                         new State(
                               new HpLessTransition(0.35, "WraithSmall"),
                     new State("WraithWalk",
                        new Follow(0.5, 8, 1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 10),
                        new TimedTransition(6000, "WraithRun")

                         ),
                     new State("WraithRun",
                        new StayBack(0.8, 4),
                        new Shoot(8.4, count: 10, projectileIndex: 1, shootAngle: 60, coolDown: 1700),
                             new TimedTransition(6000, "WraithWalk")
                         ),
                        new State("WraithSmall",
                         new ChangeSize(-15, 20),
                         new Flash(0xFFFFFF, 0.2, 5),
                         new Shoot(8.4, count: 8, projectileIndex: 1, coolDown: 745),
                         new Follow(0.92, 8, 1)
                         )
                 ),
                 new Threshold(0.6,
                     new ItemLoot("Cloudflash Scepter", 0.01),
                      new ItemLoot("Mithril Armor", 0.01),
                      new ItemLoot("Wand of Death", 0.01)
                     )
             )
                   .Init("Hideout Lightning Hound",
                         new State(
                             new TransformOnDeath("Hideout Crawler", min: 2, max: 3),
                     new State("WraithWalk",
                        new Follow(0.5, 8, 1),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8.4, count: 3, shootAngle: 6, projectileIndex: 2, coolDown: 2800),
                        new Shoot(8.4, count: 4, shootAngle: 6, projectileIndex: 2, predictive: 1, coolDown: 2800, coolDownOffset: 2600),
                        new Shoot(8.4, count: 6, projectileIndex: 1, coolDown: 2000),
                        new Shoot(8.4, count: 4, projectileIndex: 1, coolDown: 2000, coolDownOffset: 2000),
                        new TimedTransition(6000, "WraithRun")
                         ),
                     new State("WraithRun",
                        new Wander(0.1),
                        new Shoot(8.4, count: 10, projectileIndex: 0, shootAngle: 10, coolDown: 800),
                             new TimedTransition(6000, "WraithWalk")
                         )
                 ),
                 new Threshold(0.6,
                      new ItemLoot("Prism of Figments", 0.01),
                      new ItemLoot("Wyvern Skin Armor", 0.01)
                     )
             )
          //Cloud Defenders and Attackers

          //Defender
          .Init("Hideout Cloud Shield 2",
                     new State(
                         new Follow(0.2, 8, 1),
                         new Grenade(2, 100, 8, coolDown: new Cooldown(1000, 3000)),
                     new State("Defender1",

                     new TimedTransition(4500, "Defender2")
                         ),
                     new State("Defender2",
                        new TimedTransition(3000, "Defender1"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                     )))
                       //Attacker
                       .Init("Hideout Cloud Shield",
                 new State(
                      new Follow(0.6, 8, 1),
                      new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 1000)
                     ))


            .Init("Hideout Thunder Menace",
                         new State(
                             new HealGroup(8, "Iegon", coolDown: 4000, healAmount: 300),
                             new TransformOnDeath("Hideout Lightning Hound", min: 1, max: 2),
                     new State("WraithWalk",
                        new Follow(0.5, 8, 1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(8.4, count: 2, shootAngle: 6, projectileIndex: 0, coolDown: 200),
                        new TimedTransition(4000, "WraithRun")
                         ),
                     new State("WraithRun",
                        new Follow(0.5, 8, 1),
                        new Shoot(8.4, count: 3, shootAngle: 6, projectileIndex: 1, predictive: 1, coolDown: 600),
                        new TimedTransition(4000, "WraithWalk")
                         )
                 )
             )

        .Init("Iegon the Weather God",
                new State(
                    new RealmPortalDrop(),
                    new HpLessTransition(0.25, "rage"),
                    new State(
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new PlayerWithinTransition(4, "taunt")
                        ),
                    new State("taunt",
                        new Taunt("Infiltrating my palace will get you killed. How brave.", "Heroic behavior is a myth."),
                        new TimedTransition(5000, "taunt1")
                        ),
                    new State("taunt1",
                        new Taunt("Time to get completely obliterated!"),
                        new TimedTransition(5000, "fight1")
                        )
                      ),
                    new State("fight1",
                        new Prioritize(
                         new StayCloseToSpawn(0.5, 3),
                         new Wander(0.05)
                        ),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8.4, count: 6, shootAngle: 8, projectileIndex: 4, coolDown: 2000),
                        new Shoot(8.4, count: 7, projectileIndex: 1, coolDown: 400),
                        new TimedTransition(6000, "fight2")
                        ),
                    new State("fight2",
                           new Prioritize(
                             new StayCloseToSpawn(0.5, 3),
                             new Wander(0.05)
                            ),
                         new Shoot(8.4, count: 10, projectileIndex: 0, coolDown: 3000),
                         new Shoot(8.4, count: 3, fixedAngle: 0, shootAngle: 8, projectileIndex: 2, coolDown: 200),
                         new Shoot(8.4, count: 3, fixedAngle: 90, shootAngle: 8, projectileIndex: 2, coolDown: 200),
                         new Shoot(8.4, count: 3, fixedAngle: 180, shootAngle: 8, projectileIndex: 2, coolDown: 200),
                         new Shoot(8.4, count: 3, fixedAngle: 270, shootAngle: 8, projectileIndex: 2, coolDown: 200),
                        new TimedTransition(8000, "fight3")
                        ),
                    new State("fight3",
                        new Follow(0.6, 8, 1),
                        new Grenade(3, 200, range: 8, coolDown: 1000),
                        new Shoot(8.4, count: 8, shootAngle: 12, projectileIndex: 3, coolDown: 2000),
                        new Shoot(8.4, count: 6, projectileIndex: 1, coolDown: 1000),
                        new TimedTransition(6000, "returntospawn")
                        ),
                    new State("returntospawn",
                        new HealSelf(coolDown: 200, amount: 800),
                        new ReturnToSpawn(speed: 1),
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(4000, "Fighttwnty")
                        ),
                    new State("Fighttwnty",
                                                new Prioritize(
                         new StayCloseToSpawn(0.5, 3),
                         new Wander(0.05)
                        ),
                             new Taunt(1.00, "Fighting me must be pure sport for you? You aren't getting anywhere."),
                             new Flash(0x0000FF, 0.2, 5),
                             new ConditionalEffect(ConditionEffectIndex.Armored),
                             new Shoot(8.4, count: 2, fixedAngle: 90, projectileIndex: 1, coolDown: 1000),
                             new Shoot(8.4, count: 2, fixedAngle: 180, projectileIndex: 1, coolDown: 2000),
                           new Shoot(8.4, count: 2, fixedAngle: 270, projectileIndex: 1, coolDown: 3000),
                            new Shoot(8.4, count: 2, fixedAngle: 0, projectileIndex: 1, coolDown: 4000),
                            new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 2, coolDown: 500),
                            new Shoot(8.4, count: 1, fixedAngle: 125, projectileIndex: 2, coolDown: 1000),
                            new Shoot(8.4, count: 1, fixedAngle: 210, projectileIndex: 2, coolDown: 1500),
                            new Shoot(8.4, count: 1, fixedAngle: 300, projectileIndex: 2, coolDown: 2000),
                             new TimedTransition(8500, "swaq")
                            ),
                     new State("swaq",
                        new TossObject("Hideout Thunder Menace", range: 7, coolDown: 1000),
                        new TimedTransition(2000, "fight1")
                        ),
                       new State("rage",
                             new Shoot(10, count: 6, shootAngle: 6, projectileIndex: 1, coolDown: 1800),
                             new Shoot(10, count: 7, projectileIndex: 3, coolDown: 1500),
                             new Follow(0.65, 8, 1)
                         )
                    ),
                                new MostDamagers(3,
                    LootTemplates.SorRare()
                    ),
                new Threshold(0.025,
                    new ItemLoot("Potion of Speed", 1.0),
                    new ItemLoot("Potion of Luck", 1.0),
                    new TierLoot(9, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Ring of the Storm Gods", 0.02),
                    new ItemLoot("Typhoon Wand", 0.02),
                    new ItemLoot("Stormbreaker", 0.02),
                    new ItemLoot("Dagger of Unearthly Storms", 0.02)
                )
            )
        ;
    }
}