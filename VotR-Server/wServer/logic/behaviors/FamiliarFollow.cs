using Mono.Game;
using System;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.behaviors
{
    internal class FamiliarFollow : CycleBehavior
    {
        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            FollowState s;
            if (state == null)
                s = new FollowState();
            else
                s = (FollowState)state;

            Status = CycleStatus.NotStarted;

            Player player = host.GetPlayerOwner();
            if (player.Owner == null)
            {
                host.Owner.LeaveWorld(host);
                return;
            }
            
            switch (s.State)
            {
                case F.DontKnowWhere:
                    if (s.RemainingTime > 0)
                        s.RemainingTime -= time.ElapsedMsDelta;
                    else
                        s.State = F.Acquired;
                    break;
                case F.Acquired:
                    if (player == null)
                    {
                        s.State = F.DontKnowWhere;
                        s.RemainingTime = 1000;
                        break;
                    }
                    if (s.RemainingTime > 0)
                        s.RemainingTime -= time.ElapsedMsDelta;

                    var vect = new Vector2(player.X - host.X, player.Y - host.Y);
                    if (vect.Length() > 20)
                    {
                        host.Move(player.X, player.Y);
                    }
                    else if (vect.Length() > 1)
                    {
                        var dist = host.GetSpeed(0.5f) * (time.ElapsedMsDelta / 1000f);
                        if (vect.Length() > 2)
                            dist = host.GetSpeed(0.7f + ((float)player.Stats[4] / 100)) * (time.ElapsedMsDelta / 1000f);

                        vect.Normalize();
                        host.ValidateAndMove(host.X + vect.X * dist, host.Y + vect.Y * dist);
                    }

                    break;
            }

            state = s;
        }

        private enum F
        {
            DontKnowWhere,
            Acquired,
        }

        private class FollowState
        {
            public int RemainingTime;
            public F State;
        }
    }
}