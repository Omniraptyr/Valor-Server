using wServer.logic.behaviors;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ BeachBum = () => Behav()
        .Init("Beach Bum",
         new State(
           new Prioritize(
               new StayCloseToSpawn(0.5, 3),
               new Wander(0.05)
                  )
                ),
                new ItemLoot("Davy's Key", 1)
            )
    ;
    }
}