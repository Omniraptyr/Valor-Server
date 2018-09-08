using System;
using System.Collections.Generic;
using wServer.realm;

namespace wServer.logic
{
    public abstract class Transition : IStateChildren
    {
        public State[] TargetState { get; private set; }

        protected readonly string[] TargetStates;
        protected int SelectedState;

        protected Transition(params string[] targetStates) {
            TargetStates = targetStates;
        }

        public bool Tick(Entity host, RealmTime time) {
            host.StateStorage.TryGetValue(this, out var state);

            var ret = TickCore(host, time, ref state);
            if (ret)
                host.SwitchTo(TargetState[SelectedState]);

            if (state == null)
                host.StateStorage.Remove(this);
            else
                host.StateStorage[this] = state;
            return ret;
        }

        public void OnStateEntry(Entity host, RealmTime time) {
            if (!host.StateStorage.TryGetValue(this, out var state))
                state = null;

            OnStateEntry(host, time, ref state);

            if (state == null)
                host.StateStorage.Remove(this);
            else
                host.StateStorage[this] = state;
        }

        protected virtual void OnStateEntry(Entity host, RealmTime time, ref object state) {
        }

        protected abstract bool TickCore(Entity host, RealmTime time, ref object state);

        internal void Resolve(IDictionary<string, State> states) {
            var numStates = TargetStates.Length;
            TargetState = new State[numStates];
            for (var i = 0; i < numStates; i++)
                TargetState[i] = states[TargetStates[i]];
        }

        [ThreadStatic]
        private static Random _rand;
        protected static Random Random => _rand ?? (_rand = new Random());
    }
}
