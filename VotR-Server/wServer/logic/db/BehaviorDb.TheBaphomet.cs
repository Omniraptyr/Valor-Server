using wServer.realm;
using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ TheBaphomet = () => Behav()
            .Init("The Baphomet",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new State("default",
                        new Taunt(false, 40000, "Judgement is near fools. Drannol will be released and you will all suffer.", "Truly laughable how you so called Warriors think you will prevail against us.", "Making a deal with me will benefit you greatly..and will amuse me as well.", "Once the Eternal Beast is released things will change around here..", "This place looks even better than I thought it would. Can't wait for my time destroy it.", "If I was you, I would have surrendered my life a long time ago.", "All of you mortals are all just so...pathetic.", "You guys should think about getting rid of these White Fountains. Too flashy.", "Safehavens are overrated.", "Such cowards. You won't be able to hide here for long, weaklings.")
                        )
                    )
            )
            ;
    }
}