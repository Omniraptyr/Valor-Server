using Mono.Game;
using wServer.realm;
using wServer.realm.entities;
using wServer.realm.terrain;
using wServer.realm.worlds.logic;
using Player = wServer.realm.entities.Player;

namespace wServer.logic.behaviors.PetBehaviors
{
    internal class PetFollow : CycleBehavior
    {
        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            if ((host as Pet)?.PlayerOwner == null) return;
            var pet = (Pet)host;
            FollowState s;
            if (state == null)
            {
                s = new FollowState();
                s.State = F.DontKnowWhere;
                s.RemainingTime = 1000;
            }
            else
            {
                s = (FollowState) state;
            }

            Status = CycleStatus.NotStarted;


            var player = host.Owner.GetEntity(pet.PlayerOwner.Id) as Player;
            if (player == null)
            {
                var tile = host.Owner.Map[(int)host.X, (int)host.Y];
                if (tile.Region != TileRegion.PetRegion)
                {
                    if (!(host.Owner is PetYard))
                    {
                        host.Owner.LeaveWorld(host);
                        Status = CycleStatus.Completed;
                        return;
                    }
                    if (tile.Region != TileRegion.Spawn)
                    {
                        host.Owner.LeaveWorld(host);
                        Status = CycleStatus.Completed;
                        return;
                    }
                }
            }

            Status = CycleStatus.InProgress;

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
