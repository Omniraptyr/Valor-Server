using common.resources;
using wServer.networking.packets;
using System.Collections.Generic;
using System;
namespace wServer.realm.entities
{
    partial class Player
    {

        int surgeBonus = 0;
        public double attackPercentage;
        public double defensePercentage;
        public double wisdomPercentage;
        public double vitalityPercentage;
        public double speedPercentage;
        public double mightPercentage;
        public double luckPercentage;
        public double restorationPercentage;
        public  double protectionPercentage;
        public double dexterityPercentage;


        public void MarksActivate()
        {


            switch (Node1)
            {
                case 1:
                    defensePercentage += 0.05;
                    break;
                case 2:
                    vitalityPercentage += 0.05;
                    break;
                case 3:
                    attackPercentage += 0.05;
                    break;
                case 4:
                    wisdomPercentage += 0.05;
                    break;
                case 5:
                    protectionPercentage += 0.05;
                    break;
                case 6:
                    dexterityPercentage += 0.05;
                    break;
                case 7:
                    speedPercentage += 0.05;
                    break;
                case 8:
                    mightPercentage += 0.05;
                    break;
                case 9:
                    luckPercentage += 0.05;
                    break;
                case 10:
                    surgeBonus += 4;
                    break;
                case 11:
                    luckPercentage += 0.05;
                    break;
            }

            switch (Node2)
            {
                case 1:
                    defensePercentage += 0.05;
                    break;
                case 2:
                    vitalityPercentage += 0.05;
                    break;
                case 3:
                    attackPercentage += 0.05;
                    break;
                case 4:
                    wisdomPercentage += 0.05;
                    break;
                case 5:
                    protectionPercentage += 0.05;
                    break;
                case 6:
                    dexterityPercentage += 0.05;
                    break;
                case 7:
                    speedPercentage += 0.05;
                    break;
                case 8:
                    mightPercentage += 0.05;
                    break;
                case 9:
                    luckPercentage += 0.05;
                    break;
                case 10:
                    surgeBonus += 4;
                    break;
                case 11:
                    luckPercentage += 0.05;
                    break;
            }

            switch (Node3)
            {
                case 1:
                    defensePercentage += 0.05;
                    break;
                case 2:
                    vitalityPercentage += 0.05;
                    break;
                case 3:
                    attackPercentage += 0.05;
                    break;
                case 4:
                    wisdomPercentage += 0.05;
                    break;
                case 5:
                    protectionPercentage += 0.05;
                    break;
                case 6:
                    dexterityPercentage += 0.05;
                    break;
                case 7:
                    speedPercentage += 0.05;
                    break;
                case 8:
                    mightPercentage += 0.05;
                    break;
                case 9:
                    luckPercentage += 0.05;
                    break;
                case 10:
                    surgeBonus += 4;
                    break;
                case 11:
                    luckPercentage += 0.05;
                    break;
            }


            switch (Node4)
            {
                case 1:
                    defensePercentage += 0.05;
                    break;
                case 2:
                    vitalityPercentage += 0.05;
                    break;
                case 3:
                    attackPercentage += 0.05;
                    break;
                case 4:
                    wisdomPercentage += 0.05;
                    break;
                case 5:
                    protectionPercentage += 0.05;
                    break;
                case 6:
                    dexterityPercentage += 0.05;
                    break;
                case 7:
                    speedPercentage += 0.05;
                    break;
                case 8:
                    mightPercentage += 0.05;
                    break;
                case 9:
                    luckPercentage += 0.05;
                    break;
                case 10:
                    surgeBonus += 4;
                    break;
                case 11:
                    luckPercentage += 0.05;
                    break;
            }
            Stats.Boost.ActivateBoost2[3].Push(Convert.ToInt32(Stats[3] * defensePercentage), false);
            Stats.Boost.ActivateBoost2[6].Push(Convert.ToInt32(Stats[6] * vitalityPercentage), false);
            Stats.Boost.ActivateBoost2[2].Push(Convert.ToInt32(Stats[2] * attackPercentage), false);
            Stats.Boost.ActivateBoost2[7].Push(Convert.ToInt32(Stats[7] * wisdomPercentage), false);
            Stats.Boost.ActivateBoost2[11].Push(Convert.ToInt32(Stats[11] * protectionPercentage), false);
            Stats.Boost.ActivateBoost2[5].Push(Convert.ToInt32(Stats[5] * dexterityPercentage), false);
            Stats.Boost.ActivateBoost2[4].Push(Convert.ToInt32(Stats[4] * speedPercentage), false);
            Stats.Boost.ActivateBoost2[8].Push(Convert.ToInt32(Stats[8] * mightPercentage), false);
            Stats.Boost.ActivateBoost2[9].Push(Convert.ToInt32(Stats[9] * luckPercentage), false);
            Stats.Boost.ActivateBoost2[10].Push(Convert.ToInt32(Stats[10] * luckPercentage), false);


            switch (Mark)
            {
                case 1:
                    Stats.Boost.ActivateBoost2[1].Push(Convert.ToInt32(Stats[1] * 0.25), false);
                    break;
                case 2:
                    Stats.Boost.ActivateBoost2[0].Push(Convert.ToInt32(Stats[0] * 0.25), false);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Stats.Boost.ActivateBoost2[3].Push(Convert.ToInt32(Stats[3] * 0.05), false);
                    Stats.Boost.ActivateBoost2[6].Push(Convert.ToInt32(Stats[6] * 0.05), false);
                    Stats.Boost.ActivateBoost2[2].Push(Convert.ToInt32(Stats[2] * 0.05), false);
                    Stats.Boost.ActivateBoost2[7].Push(Convert.ToInt32(Stats[7] * 0.05), false);
                    Stats.Boost.ActivateBoost2[11].Push(Convert.ToInt32(Stats[11] * 0.05), false);
                    Stats.Boost.ActivateBoost2[5].Push(Convert.ToInt32(Stats[5] * 0.05), false);
                    Stats.Boost.ActivateBoost2[4].Push(Convert.ToInt32(Stats[4] * 0.05), false);
                    Stats.Boost.ActivateBoost2[8].Push(Convert.ToInt32(Stats[8] * 0.05), false);
                    Stats.Boost.ActivateBoost2[9].Push(Convert.ToInt32(Stats[9] * 0.05), false);
                    Stats.Boost.ActivateBoost2[10].Push(Convert.ToInt32(Stats[10] * 0.05), false);
                    break;
                case 7:
                    //not yet added
                    break;
                case 8:
                    if (ResolveSlot0() == true && ResolveSlot1() == true && ResolveSlot2() == true && ResolveSlot3() == true)
                    {
                    //not yet added
                    }
                    break;
                case 9:
                    //not yet added
                    break;
                case 10:
                    //not yet added
                    break;
                case 11:
                    //not yet added
                    break;
            }
        }
    }
}