using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Stronghold = () => Behav()
            .Init("Golem King I",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new State("inactive"
                        ),
                    new State("1",
                        new TransformOnDeath("Golem King A", 1, 1, 1),
                        new Suicide()
                        ),
                     new State("2",
                        new TransformOnDeath("Golem King B", 1, 1, 1),
                        new Suicide()
                        ),
                     new State("3",
                        new TransformOnDeath("Golem King C", 1, 1, 1),
                        new Suicide()
                        )
                    )
            )
         .Init("Golem King A",
                new State(
                    new RealmPortalDrop(),
                    new TransformOnDeath("GolemA Test Chest", 1, 1, 1),
                    new State("default",
                        new PlayerWithinTransition(8, "awoken")
                        ),
                    new State("awoken",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt(1.00, "You've awoken me. Now, you will pay."),
                        new TimedTransition(4500, "FollowShootPhase")
                        ),
                    new State("FollowShootPhase",
                        new Follow(0.5, 8, 1),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 9, projectileIndex: 1, coolDown: 2500),
                        new Shoot(10, count: 7, projectileIndex: 2, coolDown: 3088),
                        new Shoot(10, count: 2, projectileIndex: 3, coolDown: 1500),
                        new TimedTransition(6750, "FoollowShootPhase2")
                        ),
                    new State("FoollowShootPhase2",
                        new Follow(0.7, 8, 1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(10, count: 12, projectileIndex: 2, coolDown: 2500),
                        new Shoot(10, count: 13, projectileIndex: 5, coolDown: 150),
                        new TimedTransition(6000, "WanderAndRek")
                        ),
                    new State("WanderAndRek",
                        new Wander(0.8),
                        new Flash(0xFF0000, 6, 6),
                        new Shoot(10, count: 24, projectileIndex: 6, coolDown: 4000),
                        new TimedTransition(8000, "TellAndMove")
                        ),
                    new State("TellAndMove",
                        new ReturnToSpawn(speed: 0.5),
                        new Taunt(1.00, "Stay away fiend!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "GoBlam")
                        ),
                    new State("GoBlam",
                        new Shoot(10, count: 3, shootAngle: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 1),
                        new Shoot(10, count: 3, shootAngle: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 1),
                        new Shoot(10, count: 3, shootAngle: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 1),
                        new Shoot(10, count: 3, shootAngle: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 1),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HealSelf(coolDown: 1000, amount: 250),
                        new TimedTransition(6000, "FollowShootPhase")
                        )
                    )
            )
        .Init("Golem King B",
                new State(
                    new RealmPortalDrop(),
                    new TransformOnDeath("GolemB Test Chest", 1, 1, 1),
                    new State("default",
                        new PlayerWithinTransition(8, "awoken")
                        ),
                    new State("awoken",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt(1.00, "You've awoken me. Now, you will pay."),
                        new TimedTransition(4500, "SwirlAndBlamo")
                        ),
                    new State("SwirlAndBlamo",
                        new Swirl(0.5, 7),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 6, projectileIndex: 1, coolDown: 2500),
                        new Shoot(10, count: 7, projectileIndex: 2, coolDown: 3088),
                        new Shoot(10, count: 3, shootAngle: 10, projectileIndex: 5, coolDown: 150),
                        new TimedTransition(6750, "AnnoyingStage")
                        ),
                    new State("AnnoyingStage",
                        new Follow(0.1, 8, 1),
                        new Shoot(10, count: 14, projectileIndex: 9, coolDown: 4750),
                        new Shoot(10, count: 10, projectileIndex: 4, coolDown: 200),
                        new Grenade(3, 250, 6, coolDown: 1500),
                        new TimedTransition(6000, "WanderAndRek")
                        ),
                    new State("WanderAndRek",
                        new ReturnToSpawn(speed: 0.5),
                        new Taunt(1.00, "Go away, mortal!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(4000, "GoBlam")
                        ),
                    new State("GoBlam",
                        new Shoot(10, count: 20, projectileIndex: 0, coolDown: 850),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new HealSelf(coolDown: 1000, amount: 250),
                        new TimedTransition(6000, "SwirlAndBlamo")
                        )
                    )
            )
                .Init("Golem King C",
                new State(
                    new RealmPortalDrop(),
                    new TransformOnDeath("GolemC Test Chest", 1, 1, 1),
                    new State("default",
                        new PlayerWithinTransition(8, "awoken")
                        ),
                    new State("awoken",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt(1.00, "You've awoken me. Now, you will pay."),
                        new TimedTransition(4500, "WanderAndShootW")
                        ),
                    new State("WanderAndShootW",
                        new Wander(0.75),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(10, count: 9, projectileIndex: 1, coolDown: 2500),
                        new Shoot(10, count: 9, projectileIndex: 3, coolDown: 3088),
                        new TimedTransition(6750, "HueHueShotgun")
                        ),
                    new State("HueHueShotgun",
                        new Follow(1.0, 8, 1),
                        new Shoot(10, count: 1, shootAngle: 16, projectileIndex: 0, coolDown: 1),
                        new TimedTransition(6000, "BlamoPam")
                        ),
                    new State("BlamoPam",
                        new StayBack(0.5, 5),
                        new Taunt(1.00, "You think you can beat me? You are already being beaten."),
                        new Shoot(10, count: 6, shootAngle: 20, projectileIndex: 7, coolDown: 1000),
                        new Shoot(10, count: 8, projectileIndex: 8, coolDown: 2000),
                        new Shoot(10, count: 14, projectileIndex: 9, coolDown: 4750),
                        new TimedTransition(10000, "WanderAndShootW")
                        )
                    )
            )

        .Init("GolemA Test Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.10,
                new TierLoot(12, ItemType.Weapon, 0.025),
                new TierLoot(6, ItemType.Ability, 0.015),
                new TierLoot(5, ItemType.Ability, 0.015),
                new TierLoot(13, ItemType.Armor, 0.04),
                new TierLoot(12, ItemType.Armor, 0.03),
                new TierLoot(10, ItemType.Weapon, 0.04),
                new TierLoot(11, ItemType.Weapon, 0.03),
                new ItemLoot("Potion of Attack", 1)
                )
            )
          .Init("GolemB Test Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.10,
                new TierLoot(12, ItemType.Weapon, 0.025),
                new TierLoot(6, ItemType.Ability, 0.015),
                new TierLoot(5, ItemType.Ability, 0.015),
                new TierLoot(13, ItemType.Armor, 0.04),
                new TierLoot(12, ItemType.Armor, 0.03),
                new TierLoot(10, ItemType.Weapon, 0.04),
                new TierLoot(11, ItemType.Weapon, 0.03),
                new ItemLoot("Potion of Vitality", 1)
                )
            )
                  .Init("GolemC Test Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                ),
                new Threshold(0.10,
                new TierLoot(12, ItemType.Weapon, 0.025),
                new TierLoot(6, ItemType.Ability, 0.015),
                new TierLoot(5, ItemType.Ability, 0.015),
                new TierLoot(13, ItemType.Armor, 0.04),
                new TierLoot(12, ItemType.Armor, 0.03),
                new TierLoot(10, ItemType.Weapon, 0.04),
                new TierLoot(11, ItemType.Weapon, 0.03),
                new ItemLoot("Potion of Dexterity", 1)
                )
            )
      ;
    }
}