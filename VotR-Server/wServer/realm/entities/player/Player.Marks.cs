namespace wServer.realm.entities
{
    partial class Player
    {
        private int _gildHelmBonus;
        private int _surgeBonus;
        public double AttackPercentage;
        public double DefensePercentage;
        public double WisdomPercentage;
        public double VitalityPercentage;
        public double SpeedPercentage;
        public double MightPercentage;
        public double LuckPercentage;
        public double ProtectionPercentage;
        public double DexterityPercentage;

        public void MarksActivate() {
            switch (Node1) {
                case 1:
                    DefensePercentage += 0.05;
                    break;
                case 2:
                    VitalityPercentage += 0.05;
                    break;
                case 3:
                    AttackPercentage += 0.05;
                    break;
                case 4:
                    WisdomPercentage += 0.05;
                    break;
                case 5:
                    ProtectionPercentage += 0.05;
                    break;
                case 6:
                    DexterityPercentage += 0.05;
                    break;
                case 7:
                    SpeedPercentage += 0.05;
                    break;
                case 8:
                    MightPercentage += 0.05;
                    break;
                case 9:
                    LuckPercentage += 0.05;
                    break;
                case 10:
                    _surgeBonus += 4;
                    break;
                case 11:
                    LuckPercentage += 0.05;
                    break;
            }

            switch (Node2) {
                case 1:
                    DefensePercentage += 0.05;
                    break;
                case 2:
                    VitalityPercentage += 0.05;
                    break;
                case 3:
                    AttackPercentage += 0.05;
                    break;
                case 4:
                    WisdomPercentage += 0.05;
                    break;
                case 5:
                    ProtectionPercentage += 0.05;
                    break;
                case 6:
                    DexterityPercentage += 0.05;
                    break;
                case 7:
                    SpeedPercentage += 0.05;
                    break;
                case 8:
                    MightPercentage += 0.05;
                    break;
                case 9:
                    LuckPercentage += 0.05;
                    break;
                case 10:
                    _surgeBonus += 4;
                    break;
                case 11:
                    LuckPercentage += 0.05;
                    break;
            }

            switch (Node3) {
                case 1:
                    DefensePercentage += 0.05;
                    break;
                case 2:
                    VitalityPercentage += 0.05;
                    break;
                case 3:
                    AttackPercentage += 0.05;
                    break;
                case 4:
                    WisdomPercentage += 0.05;
                    break;
                case 5:
                    ProtectionPercentage += 0.05;
                    break;
                case 6:
                    DexterityPercentage += 0.05;
                    break;
                case 7:
                    SpeedPercentage += 0.05;
                    break;
                case 8:
                    MightPercentage += 0.05;
                    break;
                case 9:
                    LuckPercentage += 0.05;
                    break;
                case 10:
                    _surgeBonus += 4;
                    break;
                case 11:
                    LuckPercentage += 0.05;
                    break;
            }

            switch (Node4) {
                case 1:
                    DefensePercentage += 0.05;
                    break;
                case 2:
                    VitalityPercentage += 0.05;
                    break;
                case 3:
                    AttackPercentage += 0.05;
                    break;
                case 4:
                    WisdomPercentage += 0.05;
                    break;
                case 5:
                    ProtectionPercentage += 0.05;
                    break;
                case 6:
                    DexterityPercentage += 0.05;
                    break;
                case 7:
                    SpeedPercentage += 0.05;
                    break;
                case 8:
                    MightPercentage += 0.05;
                    break;
                case 9:
                    LuckPercentage += 0.05;
                    break;
                case 10:
                    _surgeBonus += 4;
                    break;
                case 11:
                    LuckPercentage += 0.05;
                    break;
            }

            Stats.Boost.ActivateBoost[2].AddOffset((int)(Stats[2] * AttackPercentage));
            Stats.Boost.ActivateBoost[3].AddOffset((int)(Stats[3] * DefensePercentage));
            Stats.Boost.ActivateBoost[4].AddOffset((int)(Stats[4] * SpeedPercentage));
            Stats.Boost.ActivateBoost[5].AddOffset((int)(Stats[5] * DexterityPercentage));
            Stats.Boost.ActivateBoost[6].AddOffset((int)(Stats[6] * VitalityPercentage));
            Stats.Boost.ActivateBoost[7].AddOffset((int)(Stats[7] * WisdomPercentage));
            Stats.Boost.ActivateBoost[8].AddOffset((int)(Stats[8] * MightPercentage));
            Stats.Boost.ActivateBoost[9].AddOffset((int)(Stats[9] * LuckPercentage));
            Stats.Boost.ActivateBoost[10].AddOffset((int)(Stats[10] * LuckPercentage));
            Stats.Boost.ActivateBoost[11].AddOffset((int)(Stats[11] * ProtectionPercentage));

            switch (Mark) {
                case 1:
                    Stats.Boost.ActivateBoost[1].AddOffset((int)(Stats[1] * 0.25));
                    break;
                case 2:
                    Stats.Boost.ActivateBoost[0].AddOffset((int)(Stats[0] * 0.25));
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Stats.Boost.ActivateBoost[2].AddOffset((int)(Stats[2] * 0.05));
                    Stats.Boost.ActivateBoost[3].AddOffset((int)(Stats[3] * 0.05));
                    Stats.Boost.ActivateBoost[4].AddOffset((int)(Stats[4] * 0.05));
                    Stats.Boost.ActivateBoost[5].AddOffset((int)(Stats[5] * 0.05));
                    Stats.Boost.ActivateBoost[6].AddOffset((int)(Stats[6] * 0.05));
                    Stats.Boost.ActivateBoost[7].AddOffset((int)(Stats[7] * 0.05));
                    Stats.Boost.ActivateBoost[8].AddOffset((int)(Stats[8] * 0.05));
                    Stats.Boost.ActivateBoost[9].AddOffset((int)(Stats[9] * 0.05));
                    Stats.Boost.ActivateBoost[10].AddOffset((int)(Stats[10] * 0.05));
                    Stats.Boost.ActivateBoost[11].AddOffset((int)(Stats[11] * 0.05));
                    break;
                case 7:
                    //not yet added
                    break;
                case 8:
                    if (ResolveSlot0() && ResolveSlot1() && ResolveSlot2() && ResolveSlot3()) {
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