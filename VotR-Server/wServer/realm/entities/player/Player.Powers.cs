using System;
using common.resources;

namespace wServer.realm.entities
{
    partial class Player
    {
        public int PowerIdentify()
        {

            int powerId = 0;
            for (var i = 0; i < 4; i++)
            {
                var item = Inventory[i];
                if (item == null || !item.Legendary)
                    continue;
                foreach (var eff in item.Legend)
                {
                    switch (eff.PowerId)
                    {
                        case 1:
                            powerId = 1;
                            break;
                    }
                }
                return powerId;
            }
            return 0;
        }
    }
}