using common.resources;
using wServer.networking.packets;
using System.Collections.Generic;
using System;
namespace wServer.realm.entities
{
    partial class Player
    {
        public void MainLegendaryPassives()
        {
            for (var i = 0; i < 3; i++)
            {
                var item = Inventory[i];
                if (item == null || !item.Legendary)
                    continue;
                foreach (var eff in item.Legend)
                {
                        ActivateMainPower(eff.PowerId, eff.HPAmount, eff.MPAmount, eff.SurgeAmount, eff.Stats);
                }
            } 
        }
        public bool CheckForLeggies()
        {
            for (var i = 0; i < 3; i++)
            {
                var item = Inventory[i];
                if (item == null || !item.Legendary)
                    continue;
                return true;
            }
            return false;
        }

        //Add all main powers here
        private void ActivateMainPower(int id, int hp_, int mp_, int surge_, int stat_)
        {
            var idx = StatsManager.GetStatIndex((StatsType)stat_);
                switch (id)
            {
                //Recovery
                case 1:
                    break;
                //Mana Focus
                case 2:
                    int a = Convert.ToInt32(Stats[2] * 0.20);
                    if (Surge >= surge_)
                    {
                        Stats.Boost.ActivateBoost[idx].Push(a, false);
                        Stats.ReCalculateValues();
                    }
                    else
                    {
                        Stats.Boost.ActivateBoost[idx].Pop(a, false);
                        Stats.ReCalculateValues();
                    }
                    break;
                case 3:
                    int n = Convert.ToInt32(Stats[7] * 0.40);
                    if (HP <= MaximumHP / 3)
                    {
                        Stats.Boost.ActivateBoost[idx].Push(n, false);
                        Stats.ReCalculateValues();
                    }
                    else
                    {
                        Stats.Boost.ActivateBoost[idx].Pop(n, false);
                        Stats.ReCalculateValues();
                    }
                    break;
            }
        }
        private void ActivateSecondaryPower(int id)
        {
            List<Packet> pkts = new List<Packet>();

            switch (id)
            {
                //MiniHeal
                case 2:
                    ApplyConditionEffect(ConditionEffectIndex.Invulnerable);
                    break;

                default:
                    break;
            }
        }
        public int SecondaryPowerIdentify()
        {
            int powerId = 0;
                var item = Inventory[3];
            try
            {
                if (item.Legendary)
                {
                    foreach (var eff in item.Legend)
                    {
                        powerId = eff.PowerId;

                    }
                }
                return powerId;
            }
            catch
            {
                return 0;
            }
        }
    }
}