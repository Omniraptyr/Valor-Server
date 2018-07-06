using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Pumpkin = () => Behav()
            .Init("Pumpkin King of Peril",
                new State(
                    new RealmPortalDrop(),
                    new State("default",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(8, "taunt1")
                        ),
                    new State("taunt1",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("I know you. You're those stupid adventurers that kill gods and creatures...but you won't kill me!", "These fantastic pumpkins give me all the strength I could ask for!", "This time I'm going to carve YOU a frowny face! Mwhahaha!"),
                        new TimedTransition(5000, "RingAttack1")
                        ),
                    new State("RingAttack1",
                        new Flash(0xFF0000, 2, 2),
                        new Wander(0.2),
                        new ConditionalEffect(ConditionEffectIndex.Armored),
                        new Shoot(8, count: 8, projectileIndex: 0, coolDown: 4550, coolDownOffset: 1500),
                        new Shoot(8, count: 10, projectileIndex: 3, coolDown: 2000, shootAngle: 22),
                        new TimedTransition(6400, "Rush1")
                        ),
                    new State("Rush1",
                        new Prioritize(
                            new Follow(0.5, 8, 1),
                            new Wander(0.4)
                            ),
                        new Shoot(8, count: 6, shootAngle: 14, projectileIndex: 1, coolDown: 3200),
                        new Shoot(8, count: 6, predictive: 1, shootAngle: 28, projectileIndex: 1, coolDown: 2440),
                        new Shoot(10, count: 5, projectileIndex: 0, coolDown: 1600),
                        new TimedTransition(6000, "MaintainDist")
                        ),
                    new State("MaintainDist",
                        new Prioritize(
                            new StayBack(0.4),
                            new Wander(0.4)
                            ),
                        new HealSelf(coolDown: 2000, amount: 400),
                        new Shoot(9, count: 7, projectileIndex: 3, coolDown: new Cooldown(3000, 1000)),
                        new Shoot(10, count: 8, shootAngle: 14, projectileIndex: 2, coolDown: 1500),
                        new TimedTransition(6200, "BurstFlame")
                        ),
                    new State("BurstFlame",
                        new Flash(0x00F0FF, 2, 2),
                        new Grenade(5, 300, range: 8, coolDown: 1000),
                        new Taunt("Feel this power, it feels good to have it! Being a pumpkin is awesome!", "You should watch out! You might pout!", "Hello, to this! SMACK! In yo face!"),
                        new ReturnToSpawn(speed: 1),
                        new Shoot(8, count: 7, projectileIndex: 4, coolDown: 750, shootAngle: 12),
                        new TimedTransition(8000, "Fire")
                        ),
                    new State("Fire",
                        new Taunt("You will be destroyed, you won't kill me.", "You aren't ready for my wonderful crazy good power!", "FEEL THE CORNCHEESE!"),
                        new Wander(0.3),
                        new TossObject("Arena Skeleton", coolDown: 500),
                        new Shoot(9, count: 14, projectileIndex: 0, coolDown: 2000),
                        new Shoot(9, count: 6, projectileIndex: 2, predictive: 2, coolDown: 1000),
                        new TimedTransition(6000, "RingAttack1")
                        )
                    ),
                new Threshold(0.025,
                    new ItemLoot("Greater Potion of Mana", 1.0),
                    new TierLoot(10, ItemType.Weapon, 0.06),
                    new TierLoot(11, ItemType.Weapon, 0.05),
                    new TierLoot(12, ItemType.Weapon, 0.04),
                    new TierLoot(5, ItemType.Ability, 0.06),
                    new TierLoot(6, ItemType.Ability, 0.04),
                    new TierLoot(11, ItemType.Armor, 0.06),
                    new TierLoot(12, ItemType.Armor, 0.05),
                    new TierLoot(13, ItemType.Armor, 0.04),
                    new TierLoot(5, ItemType.Ring, 0.05),
                    new ItemLoot("Skull Helm", 0.01),
                    new ItemLoot("Colossal Skull", 0.01)

                )
            );
    }
}