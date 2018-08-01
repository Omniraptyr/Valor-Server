package kabam.rotmg.messaging.impl.data {
import flash.utils.IDataInput;
import flash.utils.IDataOutput;

import kabam.rotmg.text.model.TextKey;

public class StatData {

    public static const MAX_HP_STAT:int = 0;
    public static const HP_STAT:int = 1;
    public static const SIZE_STAT:int = 2;
    public static const MAX_MP_STAT:int = 3;
    public static const MP_STAT:int = 4;
    public static const NEXT_LEVEL_EXP_STAT:int = 5;
    public static const EXP_STAT:int = 6;
    public static const LEVEL_STAT:int = 7;
    public static const INVENTORY_0_STAT:int = 8;
    public static const INVENTORY_1_STAT:int = 9;
    public static const INVENTORY_2_STAT:int = 10;
    public static const INVENTORY_3_STAT:int = 11;
    public static const INVENTORY_4_STAT:int = 12;
    public static const INVENTORY_5_STAT:int = 13;
    public static const INVENTORY_6_STAT:int = 14;
    public static const INVENTORY_7_STAT:int = 15;
    public static const INVENTORY_8_STAT:int = 16;
    public static const INVENTORY_9_STAT:int = 17;
    public static const INVENTORY_10_STAT:int = 18;
    public static const INVENTORY_11_STAT:int = 19;
    public static const ATTACK_STAT:int = 20;
    public static const DEFENSE_STAT:int = 21;
    public static const SPEED_STAT:int = 22;
    public static const VITALITY_STAT:int = 26;
    public static const WISDOM_STAT:int = 27;
    public static const DEXTERITY_STAT:int = 28;
    public static const CONDITION_STAT:int = 29;
    public static const NUM_STARS_STAT:int = 30;
    public static const NAME_STAT:int = 31;
    public static const TEX1_STAT:int = 32;
    public static const TEX2_STAT:int = 33;
    public static const MERCHANDISE_TYPE_STAT:int = 34;
    public static const CREDITS_STAT:int = 35;
    public static const MERCHANDISE_PRICE_STAT:int = 36;
    public static const ACTIVE_STAT:int = 37;
    public static const ACCOUNT_ID_STAT:int = 38;
    public static const FAME_STAT:int = 39;
    public static const MERCHANDISE_CURRENCY_STAT:int = 40;
    public static const CONNECT_STAT:int = 41;
    public static const MERCHANDISE_COUNT_STAT:int = 42;
    public static const MERCHANDISE_MINS_LEFT_STAT:int = 43;
    public static const MERCHANDISE_DISCOUNT_STAT:int = 44;
    public static const MERCHANDISE_RANK_REQ_STAT:int = 45;
    public static const MAX_HP_BOOST_STAT:int = 46;
    public static const MAX_MP_BOOST_STAT:int = 47;
    public static const ATTACK_BOOST_STAT:int = 48;
    public static const DEFENSE_BOOST_STAT:int = 49;
    public static const SPEED_BOOST_STAT:int = 50;
    public static const VITALITY_BOOST_STAT:int = 51;
    public static const WISDOM_BOOST_STAT:int = 52;
    public static const DEXTERITY_BOOST_STAT:int = 53;
    public static const OWNER_ACCOUNT_ID_STAT:int = 54;
    public static const RANK_REQUIRED_STAT:int = 55;
    public static const NAME_CHOSEN_STAT:int = 56;
    public static const CURR_FAME_STAT:int = 57;
    public static const NEXT_CLASS_QUEST_FAME_STAT:int = 58;
    public static const GLOW_COLOR_STAT:int = 59;
    public static const SINK_LEVEL_STAT:int = 60;
    public static const ALT_TEXTURE_STAT:int = 61;
    public static const GUILD_NAME_STAT:int = 62;
    public static const GUILD_RANK_STAT:int = 63;
    public static const BREATH_STAT:int = 64;
    public static const XP_BOOSTED_STAT:int = 65;
    public static const XP_TIMER_STAT:int = 66;
    public static const LD_TIMER_STAT:int = 67;
    public static const LT_TIMER_STAT:int = 68;
    public static const HEALTH_POTION_STACK_STAT:int = 69;
    public static const MAGIC_POTION_STACK_STAT:int = 70;
    public static const BACKPACK_0_STAT:int = 71;
    public static const BACKPACK_1_STAT:int = 72;
    public static const BACKPACK_2_STAT:int = 73;
    public static const BACKPACK_3_STAT:int = 74;
    public static const BACKPACK_4_STAT:int = 75;
    public static const BACKPACK_5_STAT:int = 76;
    public static const BACKPACK_6_STAT:int = 77;
    public static const BACKPACK_7_STAT:int = 78;
    public static const HASBACKPACK_STAT:int = 79;
    public static const TEXTURE_STAT:int = 80;
    public static const PET_INSTANCEID_STAT:int = 81;
    public static const PET_NAME_STAT:int = 82;
    public static const PET_TYPE_STAT:int = 83;
    public static const PET_RARITY_STAT:int = 84;
    public static const PET_MAXABILITYPOWER_STAT:int = 85;
    public static const PET_FAMILY_STAT:int = 86;
    public static const PET_FIRSTABILITY_POINT_STAT:int = 87;
    public static const PET_SECONDABILITY_POINT_STAT:int = 88;
    public static const PET_THIRDABILITY_POINT_STAT:int = 89;
    public static const PET_FIRSTABILITY_POWER_STAT:int = 90;
    public static const PET_SECONDABILITY_POWER_STAT:int = 91;
    public static const PET_THIRDABILITY_POWER_STAT:int = 92;
    public static const PET_FIRSTABILITY_TYPE_STAT:int = 93;
    public static const PET_SECONDABILITY_TYPE_STAT:int = 94;
    public static const PET_THIRDABILITY_TYPE_STAT:int = 95;
    public static const NEW_CON_STAT:int = 96;
    public static const FORTUNE_TOKEN_STAT:int = 97;
    public static const ONRANE_STAT = 106;
    public static const KANTOS_STAT = 107;
    public static const RAID_TOKEN = 108;
    public static const RAID_RANK = 109;
    public static const SURGE = 110;
    public static const MIGHT_STAT = 112;
    public static const MIGHT_BOOST_STAT = 113;
    public static const LUCK_STAT = 114;
    public static const LUCK_BOOST_STAT = 115;
    public static const LOOTBOX1 = 116;
    public static const LOOTBOX2 = 117;
    public static const LOOTBOX3 = 118;
    public static const LOOTBOX4 = 119;
    public static const LOOTBOX5 = 120;
    public static const RESTORATION_STAT = 121;
    public static const PROTECTION_STAT = 122;
    public static const RESTORATION_BOOST_STAT = 123;
    public static const PROTECTION_BOOST_STAT = 124;
    public static const PROTECTIONPOINTS = 125;
    public static const PROTECTIONMAX = 126;
    public static const EFFECT = 127;
    public static const MARKSENABLED = 128;
    public static const MARK = 129;
    public static const NODE1 = 130;
    public static const NODE2 = 131;
    public static const NODE3 = 132;
    public static const NODE4 = 133;
    public static const PWMAX_HP_STAT:int = 134;
    public static const PWMAX_MP_STAT:int = 135;
    public static const PWATTACK_STAT:int = 136;
    public static const PWDEFENSE_STAT:int = 137;
    public static const PWSPEED_STAT:int = 138;
    public static const PWVITALITY_STAT:int = 139;
    public static const PWWISDOM_STAT:int = 140;
    public static const PWDEXTERITY_STAT:int = 141;
    public static const PWMIGHT_STAT = 142;
    public static const PWLUCK_STAT = 143;
    public static const PWRESTORATION_STAT = 144;
    public static const PWPROTECTION_STAT = 145;
    public static const ASCENSIONENABLED = 146;
    public static const RAGE_STAT = 147;
    public static const SOR_STORAGE = 148;
    public static const ELITE = 150;

    // unimplemented
    public static const DAMAGE_MIN:int = 98;
    public static const DAMAGE_MAX:int = 99;
    public static const DAMAGE_MIN_BONUS = 100;
    public static const DAMAGE_MAX_BONUS = 101;
    public static const FORTUNE_BONUS = 105;
    public static const RANK = 103;
    public static const STRIKED = 149;
    public static const ADMIN = 104;
    public static const FORTUNE = 102;

    public var statType_:uint = 0;
    public var statValue_:int;
    public var strStatValue_:String;


    public static function statToName(_arg1:int):String {
        switch (_arg1) {
            case MAX_HP_STAT:
                return (TextKey.STAT_DATA_MAXHP);
            case HP_STAT:
                return (TextKey.STATUS_BAR_HEALTH_POINTS);
            case SIZE_STAT:
                return (TextKey.STAT_DATA_SIZE);
            case MAX_MP_STAT:
                return (TextKey.STAT_DATA_MAXMP);
            case MP_STAT:
                return (TextKey.STATUS_BAR_MANA_POINTS);
            case EXP_STAT:
                return (TextKey.STAT_DATA_XP);
            case LEVEL_STAT:
                return (TextKey.STAT_DATA_LEVEL);
            case ATTACK_STAT:
                return (TextKey.STAT_MODEL_ATTACK_LONG);
            case DEFENSE_STAT:
                return (TextKey.STAT_MODEL_DEFENSE_LONG);
            case SPEED_STAT:
                return (TextKey.STAT_MODEL_SPEED_LONG);
            case VITALITY_STAT:
                return (TextKey.STAT_MODEL_VITALITY_LONG);
            case WISDOM_STAT:
                return (TextKey.STAT_MODEL_WISDOM_LONG);
            case DEXTERITY_STAT:
                return (TextKey.STAT_MODEL_DEXTERITY_LONG);
            case LUCK_STAT:
                return (TextKey.STAT_MODEL_LUCK_LONG);
            case MIGHT_STAT:
                return (TextKey.STAT_MODEL_MIGHT_LONG);
            case RESTORATION_STAT:
                return (TextKey.STAT_MODEL_RESTORATION_LONG);
            case PROTECTION_STAT:
                return (TextKey.STAT_MODEL_PROTECTION_LONG);
            case FORTUNE:
                return (TextKey.STAT_MODEL_FORTUNE_LONG);
        }
        return (TextKey.STAT_DATA_UNKNOWN_STAT);
    }


    public function isStringStat():Boolean {
        switch (this.statType_) {
            case NAME_STAT:
            case GUILD_NAME_STAT:
            case PET_NAME_STAT:
            case ACCOUNT_ID_STAT:
            case OWNER_ACCOUNT_ID_STAT:
            case EFFECT:
                return (true);
        }
        return (false);
    }

    public function parseFromInput(_arg1:IDataInput):void {
        this.statType_ = _arg1.readUnsignedByte();
        if (!this.isStringStat()) {
            this.statValue_ = _arg1.readInt();
        }
        else {
            this.strStatValue_ = _arg1.readUTF();
        }
    }

    public function writeToOutput(_arg1:IDataOutput):void {
        _arg1.writeByte(this.statType_);
        if (!this.isStringStat()) {
            _arg1.writeInt(this.statValue_);
        }
        else {
            _arg1.writeUTF(this.strStatValue_);
        }
    }

    public function toString():String {
        if (!this.isStringStat()) {
            return ((((("[" + this.statType_) + ": ") + this.statValue_) + "]"));
        }
        return ((((("[" + this.statType_) + ': "') + this.strStatValue_) + '"]'));
    }


}
}
