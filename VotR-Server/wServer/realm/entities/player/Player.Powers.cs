using common.resources;
using wServer.networking.packets;
using System.Collections.Generic;
using System;
namespace wServer.realm.entities
{
    partial class Player
    {
        public bool CheckInsurgency()
        {
            if (Inventory[3] == null)
            {
                return false;
            }
            if (Inventory[3].ObjectId == "Insurgency Amulet")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckDRage()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].ObjectId == "Drannol's Fury")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckD2Rage()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].ObjectId == "Drannol's Judgement")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckFRage()
        {
            if (Inventory[1] == null)
            {
                return false;
            }
            if (Inventory[1].ObjectId == "Fortification Shield")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckSunMoon()
        {
            if (Inventory[1] == null)
            {
                return false;
            }
            if (Inventory[1].ObjectId == "The Sun & Moon Expansion" && Surge >= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckCrescent()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].ObjectId == "Moon Crescent Halberd" && MP >= Stats[1] / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckGHelm()
        {
            if (Inventory[1] == null)
            {
                return false;
            }
            if (Inventory[1].ObjectId == "The Gilded Helm")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckAnguish()
        {
            if (Inventory[1] == null)
            {
                return false;
            }
            if (Inventory[1].ObjectId == "Anguish of Drannol")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckForItems(string item1)
        {
            if (Inventory[4].ObjectId == item1 || Inventory[5].ObjectId == item1 || Inventory[6].ObjectId == item1 || Inventory[7].ObjectId == item1 || Inventory[8].ObjectId == item1 || Inventory[9].ObjectId == item1 || Inventory[10].ObjectId == item1 || Inventory[11].ObjectId == item1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckDim()
        {
            if (Inventory[1] == null)
            {
                return false;
            }
            if (Inventory[1].ObjectId == "Dimensional Prism" && Surge >= 25)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckBifierce()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].ObjectId == "The Bifierce" && HP <= Stats[0]/2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckAnubis()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].ObjectId == "Armor of Anubis" && Surge >= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckForce()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].ObjectId == "Force Between Avex" && HP <= Stats[0]/2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckMerc()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].ObjectId == "Mercy of Yazanahar" && MP <= Stats[1] / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckRoyal()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].ObjectId == "Staff of Royal Revenge" && this.AnyEnemyNearby(10) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckStar()
        {
            if (Inventory[3] == null)
            {
                return false;
            }
            if (Inventory[3].ObjectId == "Starcrash Ring")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckInfernus()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].ObjectId == "The Infernus")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckDran()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].ObjectId == "Dranbiel Garbs" && MP >= Stats[1] / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIok()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].ObjectId == "Iok's Relief" && Surge >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckDemo()
        {
            if (Inventory[3] == null)
            {
                return false;
            }
            if (Inventory[3].ObjectId == "Bracelet of the Demolished" && HP == Stats[0])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckFang()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].ObjectId == "The Bleeding Fang" && Surge >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckKar()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].ObjectId == "Karana's Secret")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckMeteor()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].ObjectId == "Meteor" && Inventory[1].ObjectId == "Burning Tome" || Inventory[0].ObjectId == "Meteor" && Inventory[1].ObjectId == "Scorching Scepter")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckFurious()
        {
            if (Inventory[3] == null)
            {
                return false;
            }
            if (Inventory[3].ObjectId == "Furious Gauntlet" && Surge >= 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckMoonlight()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].ObjectId == "Moonlight")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckGuilded()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].ObjectId == "The Gilded Blade" && this.CountEntity2(6, null) >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckAxe()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].ObjectId == "Waraxe of Judgement" && Surge >= 25)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckMocking()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].ObjectId == "The Mocking Raven")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckResistance()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].ObjectId == "Words of Wisdom")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckAegis()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].ObjectId == "Aegis of the Devourer")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
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

        public bool ResolveSlot0()
        {
            if (Inventory[0] == null)
            {
                return false;
            }
            if (Inventory[0].Legendary == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ResolveSlot1()
        {
            if (Inventory[1] == null)
            {
                return false;
            }
            if (Inventory[1].Legendary == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ResolveSlot2()
        {
            if (Inventory[2] == null)
            {
                return false;
            }
            if (Inventory[2].Legendary == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ResolveSlot3()
        {
            if (Inventory[3] == null)
            {
                return false;
            }
            if (Inventory[3].Legendary == true)
            {
                return true;
            }
            else
            {
                return false;
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
                //Lifeline
                case 1:
                    if(HP <= Stats[0] / 3)
                    {
                        ApplyConditionEffect(ConditionEffectIndex.HealthRecovery);
                    }
                    else
                    {
                        ApplyConditionEffect(ConditionEffectIndex.HealthRecovery, 0);
                    }
                    break;
                //Warcry
                case 2:
                    break;
                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;
                case 6:
                    if (MP <= Stats[1] / 2)
                    {
                        ApplyConditionEffect(ConditionEffectIndex.SlowedImmune);
                    }
                    else
                    {
                        ApplyConditionEffect(ConditionEffectIndex.SlowedImmune, 0);
                    }
                    break;
                    //Stoneheart
                case 7:
                    if (HP >= Stats[0] / 2)
                    {
                        ApplyConditionEffect(ConditionEffectIndex.ArmorBreakImmune);
                    }
                    else
                    {
                        ApplyConditionEffect(ConditionEffectIndex.ArmorBreakImmune, 0);
                    }
                    break;
                //Mana Recovery
                case 8:
                    if (Surge >= surge_)
                    {
                        ApplyConditionEffect(ConditionEffectIndex.ManaRecovery);
                    }
                    else
                    {
                        ApplyConditionEffect(ConditionEffectIndex.ManaRecovery, 0);
                    }
                    break;
                case 9:
                    break;
                //Swiftness
                case 10:
                    if (Surge >= surge_)
                    {
                        ApplyConditionEffect(ConditionEffectIndex.Swiftness);
                    }
                    else
                    {
                        ApplyConditionEffect(ConditionEffectIndex.Swiftness, 0);
                    }
                    break;
                //Rockheart
                case 11:
                    if (Surge >= surge_)
                    {
                        ApplyConditionEffect(ConditionEffectIndex.PetrifyImmune);
                    }
                    else
                    {
                        ApplyConditionEffect(ConditionEffectIndex.PetrifyImmune, 0);
                    }
                    break;
                //Mindwalker
                case 12:
                    if (Surge >= surge_)
                    {
                        ApplyConditionEffect(ConditionEffectIndex.PetrifyImmune);
                    }
                    else
                    {
                        ApplyConditionEffect(ConditionEffectIndex.PetrifyImmune, 0);
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