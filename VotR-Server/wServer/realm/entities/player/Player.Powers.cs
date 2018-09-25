using common.resources;

namespace wServer.realm.entities
{
    partial class Player
    {
        public bool CheckInsurgency() {
            return Inventory[3] != null && Inventory[3].ObjectId == "Insurgency Amulet";
        }

        public bool CheckDRage() {
            return Inventory[2] != null && Inventory[2].ObjectId == "Drannol's Fury";
        }

        public bool CheckFRage() {
            return Inventory[1] != null && Inventory[1].ObjectId == "Fortification Shield";
        }

        public bool CheckSunMoon() {
            return Inventory[1] != null && Inventory[1].ObjectId == "The Sun & Moon Expansion" && Surge >= 50;
        }

        public bool CheckCrescent() {
            return Inventory[0] != null && Inventory[0].ObjectId == "Moon Crescent Halberd" && MP >= Stats[1] / 2;
        }

        public bool CheckGHelm() {
            return Inventory[1] != null && Inventory[1].ObjectId == "The Gilded Helm";
        }

        public bool CheckAnguish() {
            return Inventory[1] != null && Inventory[1].ObjectId == "Anguish of Drannol";
        }

        public bool CheckAnubis() {
            return Inventory[2] != null && Inventory[2].ObjectId == "Armor of Anubis" && Surge >= 20;
        }

        public bool CheckForce() {
            return Inventory[2] != null && Inventory[2].ObjectId == "Force Between Avex" && HP <= Stats[0] / 2;
        }

        public bool CheckMerc() {
            return Inventory[2] != null && Inventory[2].ObjectId == "Mercy of Yazanahar" && MP <= Stats[1] / 2;
        }

        public bool CheckRoyal() {
            return Inventory[0] != null && Inventory[0].ObjectId == "Staff of Royal Revenge" && this.AnyEnemyNearby(10) == false;
        }

        public bool CheckDemo() {
            return Inventory[3] != null && Inventory[3].ObjectId == "Bracelet of the Demolished" && HP >= (int)(Stats[0] * 0.8);
        }

        public bool CheckKar() {
            return Inventory[0] != null && Inventory[0].ObjectId == "Karana's Secret";
        }

        public bool CheckTinda() {
            return Inventory[0] != null && Inventory[0].ObjectId == "Dagger of Tindailius" && MP >= Stats[1] / 2;
        }

        public bool CheckGuilded() {
            return Inventory[0] != null && Inventory[0].ObjectId == "The Gilded Blade" && this.CountEntity2(6, null) >= 2;
        }

        public bool CheckAxe() {
            return Inventory[0] != null && Inventory[0].ObjectId == "Waraxe of Judgement" && Surge >= 25;
        }

        public bool CheckMocking() {
            return Inventory[0] != null && Inventory[0].ObjectId == "The Mocking Raven";
        }

        public bool CheckResistance() {
            return Inventory[2] != null && Inventory[2].ObjectId == "Words of Wisdom";
        }

        public bool CheckAegis() {
            return Inventory[2] != null && Inventory[2].ObjectId == "Aegis of the Devourer";
        }

        public void MainLegendaryPassives() {
            for (var i = 0; i < 3; i++) {
                var item = Inventory[i];
                if (item == null || !item.Legendary)
                    continue;
                foreach (var eff in item.Legend) {
                    ActivateMainPower(eff.PowerId, eff.HPAmount, eff.MPAmount, eff.SurgeAmount, eff.Stats);
                }
            }
        }

        public bool ResolveSlot0() {
            return Inventory[0] != null && Inventory[0].Legendary;
        }

        public bool ResolveSlot1() {
            return Inventory[1] != null && Inventory[1].Legendary;
        }

        public bool ResolveSlot2() {
            return Inventory[2] != null && Inventory[2].Legendary;
        }

        public bool ResolveSlot3() {
            return Inventory[3] != null && Inventory[3].Legendary;
        }

        //Add all main powers here
        private void ActivateMainPower(int id, int hp_, int mp_, int surge_, int stat_) {
            switch (id) {
                //Lifeline
                case 1:
                    if (HP <= Stats[0] / 3) {
                        ApplyConditionEffect(ConditionEffectIndex.HealthRecovery);
                    } else {
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
                    if (MP <= Stats[1] / 2) {
                        ApplyConditionEffect(ConditionEffectIndex.SlowedImmune);
                    } else {
                        ApplyConditionEffect(ConditionEffectIndex.SlowedImmune, 0);
                    }
                    break;
                //Stoneheart
                case 7:
                    if (HP >= Stats[0] / 2) {
                        ApplyConditionEffect(ConditionEffectIndex.ArmorBreakImmune);
                    } else {
                        ApplyConditionEffect(ConditionEffectIndex.ArmorBreakImmune, 0);
                    }
                    break;
                //Mana Recovery
                case 8:
                    if (Surge >= surge_) {
                        ApplyConditionEffect(ConditionEffectIndex.ManaRecovery);
                    } else {
                        ApplyConditionEffect(ConditionEffectIndex.ManaRecovery, 0);
                    }
                    break;
                case 9:
                    break;
                //Swiftness
                case 10:
                    if (Surge >= surge_) {
                        ApplyConditionEffect(ConditionEffectIndex.Swiftness);
                    } else {
                        ApplyConditionEffect(ConditionEffectIndex.Swiftness, 0);
                    }
                    break;
                //Rockheart
                case 11:
                    if (Surge >= surge_) {
                        ApplyConditionEffect(ConditionEffectIndex.PetrifyImmune);
                    } else {
                        ApplyConditionEffect(ConditionEffectIndex.PetrifyImmune, 0);
                    }
                    break;
                //Mindwalker
                case 12:
                    if (Surge >= surge_) {
                        ApplyConditionEffect(ConditionEffectIndex.PetrifyImmune);
                    } else {
                        ApplyConditionEffect(ConditionEffectIndex.PetrifyImmune, 0);
                    }
                    break;
            }
        }
    }
}