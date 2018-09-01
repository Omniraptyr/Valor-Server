using wServer.realm;

namespace wServer.logic.behaviors
{
    class MultiplyLootValue : Behavior
    {
        //State storage: cooldown timer

        int multiplier;

        public MultiplyLootValue(int multiplier)
        {
            this.multiplier = multiplier;
        }

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            state = false;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            bool multiplied = (bool)state;
            if (!multiplied)
            {
                var newLootValue = host.LootValue * multiplier;
                host.LootValue = newLootValue;
                multiplied = true;
            }
            state = multiplied;
        }
    }
}
