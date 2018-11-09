using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Concealment = () => Behav()
            .Init("The Dreadnought",
                new State(
                    new ScaleHP(35000),
                    new RealmPortalDrop(),
                    new State("default",
                        new PlayerWithinTransition(14, "fight1")
                        ),
                    new State("fight1",
                        new Taunt(1.00, "....*silent tone*......"),
                        new Wander(0.4),
                        new Shoot(8.4, count: 12, shootAngle: 26, projectileIndex: 1, coolDown: 1200),
                        new Shoot(10, count: 1, projectileIndex: 4, coolDown: 1),
                        new TimedTransition(3000, "fight2")
                       ),
                    new State("fight2",
                        new Wander(0.65),
                        new Shoot(10, count: 1, projectileIndex: 4, coolDown: 1),
                        new Shoot(8.4, count: 6, shootAngle: 16, projectileIndex: 1, coolDown: 1500),
                        new Shoot(8.4, count: 12, shootAngle: 16, predictive: 2, projectileIndex: 2, coolDown: 2200),
                        new TimedTransition(7000, "fight3")
                       ),
                    new State("fight3",
                        new Swirl(1, 8, 10),
                        new Shoot(10, count: 20, shootAngle: 28, projectileIndex: 3, coolDown: 2800),
                        new Shoot(10, count: 12, projectileIndex: 5, coolDown: 1600),
                        new Shoot(8.4, count: 8, shootAngle: 16, predictive: 1, projectileIndex: 1, coolDown: 2200),
                        new TimedTransition(6500, "fight4")
                       ),
                    new State("fight4",
                        new Taunt(1.00, "....*LOUD NOISE*......"),
                        new Follow(0.6, 8, 1),
                        new Shoot(10, count: 20, shootAngle: 28, projectileIndex: 5, coolDown: 2800),
                        new Shoot(10, count: 6, projectileIndex: 0, coolDown: 1600),
                        new Shoot(8.4, count: 28, projectileIndex: 3, coolDown: 6000),
                        new Shoot(8.4, count: 8, shootAngle: 16, projectileIndex: 2, coolDown: 2200),
                        new TimedTransition(7000, "fight5")
                       ),
                    new State("fight5",
                        new Wander(0.5),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HealSelf(coolDown: 1000, amount: 100),
                        new Shoot(10, count: 6, shootAngle: 28, projectileIndex: 0, coolDown: 3000),
                        new Shoot(8.4, count: 8, shootAngle: 16, predictive: 3, projectileIndex: 3, coolDown: 2200),
                        new Shoot(7, count: 13, projectileIndex: 2, coolDown: 800),
                        new TimedTransition(6000, "fight6")
                       ),
                    new State("fight6",
                        new BackAndForth(1, 7),
                        new Shoot(10, count: 6, shootAngle: 16, projectileIndex: 0, coolDown: 10),
                        new Shoot(8.4, count: 22, projectileIndex: 3, coolDown: 2200),
                        new TimedTransition(4000, "fight7")
                       ),
                    new State("fight7",
                        new Taunt(1.00, "......"),
                        new Flash(0xFF0FF0, 2, 2),
                        new ConditionalEffect(ConditionEffectIndex.ArmorBreakImmune),
                        new Swirl(0.5, 8, 10),
                        new Shoot(10, count: 9, shootAngle: 12, projectileIndex: 2, coolDown: 1000),
                        new Shoot(10, count: 3, shootAngle: 60, projectileIndex: 0, coolDown: 750),
                        new Shoot(10, count: 5, projectileIndex: 4, coolDown: 1250),
                        new Grenade(7, 85, range: 8, coolDown: 20),
                        new TimedTransition(4000, "fight1")
                       )
                    ),
                                new MostDamagers(3,
                    LootTemplates.SorRare()
                    ),
                                new MostDamagers(3,
                    new ItemLoot("Potion of Might", 1.0)
                ),
                new MostDamagers(1,
                    new ItemLoot("Potion of Defense", 1.0)
                ),
                new MostDamagers(3,
                    LootTemplates.Sor2Perc()
                    ),
                new Threshold(0.022,
                    new TierLoot(10, ItemType.Weapon, 0.06),
                    new TierLoot(11, ItemType.Weapon, 0.05),
                    new TierLoot(12, ItemType.Weapon, 0.04),
                    new TierLoot(5, ItemType.Ability, 0.06),
                    new TierLoot(6, ItemType.Ability, 0.04),
                    new TierLoot(11, ItemType.Armor, 0.06),
                    new TierLoot(12, ItemType.Armor, 0.05),
                    new TierLoot(13, ItemType.Armor, 0.04),
                    new TierLoot(6, ItemType.Ring, 0.06),
                    new ItemLoot("Potion of Restoration", 1),
                    new ItemLoot("Rally of the Dreadnought", 0.04),
                    new ItemLoot("Mythical Basilisk Venom", 0.04),
                    new ItemLoot("Bow of Dreadful Reign", 0.04)
                )
            )
          .Init("Concealment Guard",
            new State(
                new State("fight",
                     new Follow(0.6, 8, 1),
                     new Shoot(8.4, count: 2, shootAngle: 4, projectileIndex: 0, coolDown: 1000),
                     new TimedTransition(4000, "swag2")
                    ),
                new State("swag2",
                     new Follow(0.8, 8, 1),
                     new Shoot(8.4, count: 4, shootAngle: 16, projectileIndex: 0, coolDown: 500),
                     new TimedTransition(2000, "fight")
                    )
                )
            )
          .Init("Possessed Concealment Guard",
            new State(
                new State("fight",
                     new Follow(0.4, 8, 1),
                     new Shoot(8.4, count: 4, shootAngle: 60, projectileIndex: 0, coolDown: 2000),
                     new TimedTransition(4000, "swag2")
                    ),
                new State("swag2",
                     new Follow(0.5, 8, 1),
                     new Shoot(8.4, count: 4, projectileIndex: 0, coolDown: 1000),
                     new TimedTransition(2000, "fight")
                    )
                )
            )
           .Init("Dreaded Huntsman",
            new State(
                new State("fight",
                     new StayBack(0.2, 2),
                     new Shoot(8.4, count: 4, shootAngle: 12, projectileIndex: 0, coolDown: 450),
                     new TimedTransition(3000, "swag2")
                    ),
                new State("swag2",
                     new ConditionalEffect(ConditionEffectIndex.Armored),
                     new Follow(0.25, 8, 1),
                     new Shoot(8.4, count: 7, shootAngle: 16, projectileIndex: 1, coolDown: 1000),
                     new TimedTransition(3000, "fight")
                    )
                )
            )
          .Init("Knight of Material",
                new State("fight",
                     new Wander(0.1),
                     new Shoot(8.4, count: 1, projectileIndex: 0, coolDown: 450)
                )
            )
          .Init("Warrior of the Dreadnought",
                new State("fight",
                     new Follow(0.8, 8, 1),
                     new Shoot(8.4, count: 6, shootAngle: 8, projectileIndex: 0, coolDown: 2000),
                    new Shoot(8.4, count: 8, projectileIndex: 0, coolDown: 4000)
                )
            )
          .Init("Dreadnought's Servant",
            new State(
                new State("fight",
                     new Follow(0.6, 1, 8),
                     new Shoot(8.4, count: 2, shootAngle: 10, projectileIndex: 1, coolDown: 1000),
                     new TimedTransition(3000, "swag2")
                    ),
                new State("swag2",
                     new Orbit(0.2, 4),
                     new Shoot(8.4, count: 4, shootAngle: 18, projectileIndex: 0, coolDown: 1000),
                     new TimedTransition(3000, "swag3")
                    ),
                new State("swag3",
                    new Taunt(1.00, "You aren't leaving here alive.", "You will be trapped here..Just like our master!"),
                     new ConditionalEffect(ConditionEffectIndex.Armored),
                     new Shoot(8.4, count: 7, projectileIndex: 2, coolDown: 1000),
                     new TimedTransition(3000, "fight")
                    )
                )
            )
          .Init("Mystical Basilisk",
                new State(
                  new DamageTakenTransition(3000, "Sentry"),
                  new Grenade(2, 100, range: 5, coolDown: 3000),
                  new State("fight",
                     new Wander(0.5),
                     new Shoot(8.4, count: 2, shootAngle: 2, projectileIndex: 0, coolDown: 1500),
                     new Shoot(8.4, count: 3, shootAngle: 8, projectileIndex: 1, coolDown: 1000),
                     new TimedTransition(4000, "swag2")
                    ),
                new State("swag2",
                     new Follow(0.4, 8, 1),
                     new Shoot(8.4, count: 8, projectileIndex: 0, coolDown: 1500),
                     new Shoot(8.4, count: 5, projectileIndex: 1, coolDown: 1000),
                     new TimedTransition(3000, "swag3")
                    ),
                new State("swag3",
                    new HealSelf(coolDown: 3000, amount: 80),
                    new Flash(0x0000FF, 1, 1),
                    new Taunt("Your time is up here.", "The treasures of the concealment belong here, not yours to take."),
                    new TimedTransition(2000, "fight8")
                    ),
                new State("fight8",
                     new Shoot(8.4, count: 3, shootAngle: 8, projectileIndex: 2, coolDown: 2000),
                     new TimedTransition(4000, "fight")
                    ),
                new State("Sentry",
                     new Shoot(8.4, count: 6, shootAngle: 8, projectileIndex: 2, coolDown: 2000)
                    )
                )
            )
           .Init("Treasure Basilisk",
                new State(
                  new ScaleHP(35000),
                  new State("default",
                  new Taunt(true, "Find us..kill us..gain our treasures, if you are brave."),
                   new PlayerWithinTransition(8, "fight")
                   ),
                  new State("fight",
                     new Wander(0.5),
                     new Shoot(8.4, count: 12, projectileIndex: 2, coolDown: 1000),
                     new Shoot(8.4, count: 6, projectileIndex: 1, coolDown: 1000),
                     new TimedTransition(4750, "fight2")
                    ),
                new State("fight2",
                    new Taunt(1.00, "You want treasure, but I want your corpse.", "You shouldn't have found me. You'll now be found dead.", "I'd like to think you're just another snack.", "Pepper will go good with your flesh.", "The crunch of your bones will be quite satisfying to hear.", "I will rip your head off and drink the blood out of your body.", "Leave."),
                     new ConditionalEffect(ConditionEffectIndex.Armored),
                     new HealSelf(coolDown: 500, amount: 300),
                     new Shoot(8.4, count: 4, shootAngle: 6, projectileIndex: 0, coolDown: 100),
                     new TimedTransition(4000, "fight3")
                    ),
                new State("fight3",
                    new Follow(0.4, 8, 1),
                    new Taunt(1.00, "Do you not enjoy your life? You must not because now I will take it away from you."),
                     new ConditionalEffect(ConditionEffectIndex.Armored),
                     new Shoot(8.4, count: 5, shootAngle: 18, projectileIndex: 0, coolDown: 1000),
                     new Shoot(8.4, count: 8, shootAngle: 24, projectileIndex: 2, coolDown: 2240),
                     new Shoot(8.4, count: 3, projectileIndex: 1, coolDown: 2740),
                     new TimedTransition(4000, "fight")
                    )
                ),
                new Threshold(0.15,
                    new TierLoot(9, ItemType.Weapon, 0.06),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(11, ItemType.Weapon, 0.04),
                    new TierLoot(10, ItemType.Armor, 0.06),
                    new TierLoot(11, ItemType.Armor, 0.05),
                    new TierLoot(12, ItemType.Armor, 0.04),
                    new ItemLoot("Potion of Might", 1.00),
                    new ItemLoot("Lorespire Robe", 0.03)
                )

            )
        ;
    }
}