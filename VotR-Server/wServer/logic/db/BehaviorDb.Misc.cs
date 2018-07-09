#region

using wServer.realm;
using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Misc = () => Behav()
            .Init("White Fountain",
                new State(
                    new HealPlayer(5, coolDown: 450, healAmount: 100)
                    )
            )
            .Init("Winter Fountain Frozen", //Frozen <3
                                            //Kabam let it go :DDD
                new State(
                    new HealPlayer(5, coolDown: 450, healAmount: 100)
                    )
            )
            .Init("Nexus Crier",
              new State("Active",
                  new ConditionalEffect(ConditionEffectIndex.Invincible),
                  new BackAndForth(.2, 3),
                  new Taunt(0.4, 10000, "Welcome to Vengeance of the Risen!", "Enjoy your stay on Vengeance of the Risen!", "Report bugs and exploiters to admins!", "Hi! I'm the nexus crier!")
                  )
                )
            .Init("Sheep",
                new State(
                    new PlayerWithinTransition(15, "player_nearby"),
                    new State("player_nearby",
                        new Prioritize(
                            new StayCloseToSpawn(0.1, 2),
                            new Wander(0.1)
                            ),
                        new Taunt(0.001, 1000, "baa", "baa baa")
                        )
                    )
            );
    }
}