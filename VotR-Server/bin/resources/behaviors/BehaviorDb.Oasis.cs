using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using common;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Oasis = () => Behav()
            .Init("Oasis Giant",
                new State(
                    new Shoot(10, count: 4, shootAngle: 7, predictive: 1),
                    new Prioritize(
                        new StayCloseToSpawn(0.3, 2),
                        new Wander(0.4)
                        ),
                    new SpawnGroup("Oasis", maxChildren: 20, coolDown: 5000),
                    new Taunt(0.7, 10000,
                        "Come closer, {PLAYER}! Yes, closer!",
                        "I rule this place, {PLAYER}!",
                        "Surrender to my aquatic army, {PLAYER}!",
                        "You must be thirsty, {PLAYER}. Enter my waters!",
                        "Minions! We shall have {PLAYER} for dinner!"
                        )
                    ),
                new Threshold(0.1,
                    new ItemLoot("Wand of Pristine Environments", 0.01)
                    )
            )
            .Init("Oasis Ruler",
                new State(
                    new Prioritize(
                        new Protect(0.5, "Oasis Giant", acquireRange: 15, protectionRange: 10, reprotectRange: 3),
                        new Follow(1, range: 9),
                        new Wander(0.5)
                        ),
                    new Shoot(10)
                    ),
                new ItemLoot("Magic Potion", 0.05)
            )
            .Init("Oasis Soldier",
                new State(
                    new Prioritize(
                        new Protect(0.5, "Oasis Giant", acquireRange: 15, protectionRange: 11, reprotectRange: 3),
                        new Follow(1, range: 7),
                        new Wander(0.5)
                        ),
                    new Shoot(10, predictive: 0.5)
                    ),
                new ItemLoot("Health Potion", 0.05)
            )
            .Init("Oasis Creature",
                new State(
                    new Prioritize(
                        new Protect(0.5, "Oasis Giant", acquireRange: 15, protectionRange: 12, reprotectRange: 3),
                        new Follow(1, range: 5),
                        new Wander(0.5)
                        ),
                    new Shoot(10, coolDown: 400)
                    ),
                new ItemLoot("Health Potion", 0.05)
            )
            .Init("Oasis Monster",
                new State(
                    new Prioritize(
                        new Protect(0.5, "Oasis Giant", acquireRange: 15, protectionRange: 13, reprotectRange: 3),
                        new Follow(1, range: 3),
                        new Wander(0.5)
                        ),
                    new Shoot(10, predictive: 0.5)
                    ),
                new ItemLoot("Magic Potion", 0.05)
            );
    }
}