using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Cheese = () => Behav()
             // cube god with no minions basically
             .Init("The Cheesehead",
                 new State(
                             new StayCloseToSpawn(0.3, range: 7),
                            new Wander(0.5),
                              new Shoot(10, count: 10, coolDown: 2000),
                              new Shoot(10, count: 5, shootAngle: 4, projectileIndex: 1, coolDown: 1000)
                 ),
                 new Threshold(0.15,
                     new TierLoot(3, ItemType.Ring, 0.2),
                     new TierLoot(7, ItemType.Armor, 0.2),
                     new TierLoot(8, ItemType.Weapon, 0.2),
                     new TierLoot(4, ItemType.Ability, 0.1),
                     new TierLoot(8, ItemType.Armor, 0.1),
                     new TierLoot(4, ItemType.Ring, 0.05),
                     new TierLoot(9, ItemType.Armor, 0.03),
                     new TierLoot(5, ItemType.Ability, 0.03),
                     new TierLoot(9, ItemType.Weapon, 0.03),
                     new TierLoot(10, ItemType.Armor, 0.02),
                     new TierLoot(10, ItemType.Weapon, 0.02),
                     new TierLoot(11, ItemType.Armor, 0.01),
                     new TierLoot(11, ItemType.Weapon, 0.01),
                     new TierLoot(5, ItemType.Ring, 0.01),
                     new ItemLoot("Swiss Army Knife", 0.02),
                     new ItemLoot("Sword of the Devourer", 0.5),
                     new ItemLoot("King's Guard Sword", 0.5),
                     new ItemLoot("Potion of Speed", 1.00)
                 )
          );
    }
}