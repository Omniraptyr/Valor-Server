using wServer.logic.behaviors;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Torii = () => Behav()
            .Init("Wicked Torii",
                new State(
                    new State("first",
                        new SetAltTexture(1, 3, 330),
                        new TimedTransition(1330, "second")
                    ),
                    new State("second",
                        new SetAltTexture(2, cooldown: 330),
                        new TimedTransition(200, "first")
                        )
                    )
            );
    }
}
