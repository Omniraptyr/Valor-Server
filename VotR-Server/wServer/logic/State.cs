using System;
using System.Collections.Generic;
using wServer.realm;

namespace wServer.logic
{
    public interface IStateChildren { }
    public class State : IStateChildren
    {
        public State(params IStateChildren[] children) : this("", children) { }
        public State(string name, params IStateChildren[] children) {
            Name = name;
            States = new List<State>();
            Behaviors = new List<Behavior>();
            Transitions = new List<Transition>();
            foreach (var i in children) {
                switch (i) {
                    case State state:
                        state.Parent = this;
                        States.Add(state);
                        break;
                    case Behavior behavior:
                        Behaviors.Add(behavior);
                        break;
                    case Transition transition:
                        Transitions.Add(transition);
                        break;
                    default:
                        throw new NotSupportedException("Unknown children type.");
                }
            }
        }

        public string Name { get; }
        public State Parent { get; private set; }
        public IList<State> States { get; }
        public IList<Behavior> Behaviors { get; }
        public IList<Transition> Transitions { get; }

        public static State CommonParent(State a, State b) {
            if (a == null || b == null) return null;
            return _CommonParent(a, a, b);
        }

        private static State _CommonParent(State current, State a, State b) {
            if (b.Is(current)) return current;
            return a.Parent == null ? null : _CommonParent(current.Parent, a, b);
        }

        //child is parent
        //parent is not child
        public bool Is(State state) {
            if (this == state) return true;
            return Parent != null && Parent.Is(state);
        }

        public event EventHandler<BehaviorEventArgs> Death;

        internal void OnDeath(BehaviorEventArgs e) {
            Death?.Invoke(this, e);
            Parent?.OnDeath(e);
        }

        internal void Resolve(Dictionary<string, State> states) {
            states[Name] = this;
            foreach (var i in States)
                i.Resolve(states);
        }
        internal void ResolveChildren(Dictionary<string, State> states) {
            foreach (var i in States)
                i.ResolveChildren(states);
            foreach (var j in Transitions)
                j.Resolve(states);
            foreach (var j in Behaviors)
                j.Resolve(this);
        }

        private void ResolveTransition(Dictionary<string, State> states) {
            foreach (var i in Transitions)
                i.Resolve(states);
        }

        public override string ToString() {
            return Name;
        }

        public static readonly State NullState = new State();
    }

    public class BehaviorEventArgs : EventArgs
    {
        public BehaviorEventArgs(Entity host, RealmTime time) {
            Host = host;
            Time = time;
        }
        public Entity Host { get; }
        public RealmTime Time { get; }
    }
}
