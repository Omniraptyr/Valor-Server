package com.company.assembleegameclient.parameters {
import com.company.util.KeyCodes;
import com.company.util.MoreDateUtil;

import flash.display.DisplayObject;
import flash.display.StageScaleMode;
import flash.events.Event;
import flash.net.SharedObject;
import flash.system.Capabilities;
import flash.utils.Dictionary;

public class Parameters {
    public static const BUILD_VERSION:String = "75";
    public static const MINOR_VERSION:String = "A7";
    public static const FULL_BUILD:String = BUILD_VERSION + "." + MINOR_VERSION;
    public static const ENABLE_ENCRYPTION:Boolean = true;
    public static const PORT:int = 2050;
    public static const ALLOW_SCREENSHOT_MODE:Boolean = false;
    public static const FELLOW_GUILD_COLOR:uint = 10944349;
    public static const NAME_CHOSEN_COLOR:uint = 0xFCDF00;
    public static const PLAYER_ROTATE_SPEED:Number = 0.003;
    public static const RAGE_THRESH:int = 80;
    public static const SERVER_CHAT_NAME:String = "";
    public static const CLIENT_CHAT_NAME:String = "*Client*";
    public static const ERROR_CHAT_NAME:String = "*Error*";
    public static const HELP_CHAT_NAME:String = "*Help*";
    public static const GUILD_CHAT_NAME:String = "*Guild*";
    public static const NAME_CHANGE_PRICE:int = 5000;
    public static const GUILD_CREATION_PRICE:int = 1000;
    public static const TUTORIAL_GAMEID:int = -1;
    public static const NEXUS_GAMEID:int = -2;
    public static const RANDOM_REALM_GAMEID:int = -3;
    public static const MAPTEST_GAMEID:int = -6;
    public static const MAX_SINK_LEVEL:Number = 18;
    public static const TERMS_OF_USE_URL:String = ""; //add tos later (?)
    public static const PRIVACY_POLICY_URL:String = ""; //add pp later (?)
    public static const USER_GENERATED_CONTENT_TERMS:String = ""; //add tos later (?)
    public static const RANDOM1:String = "BA15DE";
    public static const RANDOM2:String = "612a806cac78114ba5013cb531";
    public static const RSA_PUBLIC_KEY:String =
            "-----BEGIN PUBLIC KEY-----\n" +
            "MFswDQYJKoZIhvcNAQEBBQADSgAwRwJAeyjMOLhcK4o2AnFRhn8vPteUy5Fux/cX" +
            "N/J+wT/zYIEUINo02frn+Kyxx0RIXJ3CvaHkwmueVL8ytfqo8Ol/OwIDAQAB\n" +
            "-----END PUBLIC KEY-----";
    public static const skinTypes16:Vector.<int> = new <int>[1027, 0x0404, 1029, 1030, 10973];
    public static const itemTypes16:Vector.<int> = new <int>[5473, 5474, 5475, 5476, 10939];

    public static var root:DisplayObject;
    public static var data_:Object = null;
    public static var GPURenderError:Boolean = false;
    public static var blendType_:int = 1;
    public static var drawProj_:Boolean = true;
    public static var screenShotMode_:Boolean = false;
    public static var screenShotSlimMode_:Boolean = false;
    public static var sendLogin_:Boolean = true;
    private static var savedOptions_:SharedObject = null;
    private static var keyNames_:Dictionary = new Dictionary();


    public static function load():void {
        try {
            savedOptions_ = SharedObject.getLocal("ValorOptions", "/");
            data_ = savedOptions_.data;
        } catch (error:Error) {
            data_ = new Object();
        }
        setDefaults();
        save();
    }

    public static function save():void {
        try {
            if (savedOptions_ != null) {
                savedOptions_.flush();
            }
        } catch (error:Error) { }
    }

    private static function setDefaultKey(val:String, keyCode:uint):void {
        if (!data_.hasOwnProperty(val)) {
            data_[val] = keyCode;
        }
        keyNames_[val] = true;
    }

    public static function setKey(val:String, keyCode:uint):void {
        var key:String;
        for (key in keyNames_) {
            if (data_[key] == keyCode) {
                data_[key] = KeyCodes.UNSET;
            }
        }
        data_[val] = keyCode;
    }

    private static function setDefault(val:String, obj:*):void {
        if (!data_.hasOwnProperty(val)) {
            data_[val] = obj;
        }
    }

    public static function isGpuRender():Boolean {
        return false; //!GPURenderError && data_.GPURender && !Map.forceSoftwareRender; temp disable
    }

    public static function clearGpuRenderEvent(e:Event):void {
        clearGpuRender();
    }

    public static function clearGpuRender():void {
        GPURenderError = true;
    }

    public static function setDefaults():void {
        setDefaultKey("moveLeft", KeyCodes.A);
        setDefaultKey("moveRight", KeyCodes.D);
        setDefaultKey("moveUp", KeyCodes.W);
        setDefaultKey("moveDown", KeyCodes.S);
        setDefaultKey("rotateLeft", KeyCodes.Q);
        setDefaultKey("rotateRight", KeyCodes.E);
        setDefaultKey("useSpecial", KeyCodes.SPACE);
        setDefaultKey("interact", KeyCodes.NUMBER_0);
        setDefaultKey("useInvSlot1", KeyCodes.NUMBER_1);
        setDefaultKey("useInvSlot2", KeyCodes.NUMBER_2);
        setDefaultKey("useInvSlot3", KeyCodes.NUMBER_3);
        setDefaultKey("useInvSlot4", KeyCodes.NUMBER_4);
        setDefaultKey("useInvSlot5", KeyCodes.NUMBER_5);
        setDefaultKey("useInvSlot6", KeyCodes.NUMBER_6);
        setDefaultKey("useInvSlot7", KeyCodes.NUMBER_7);
        setDefaultKey("useInvSlot8", KeyCodes.NUMBER_8);
        setDefaultKey("escapeToNexus2", KeyCodes.F5);
        setDefaultKey("escapeToNexus", KeyCodes.R);
        setDefaultKey("autofireToggle", KeyCodes.I);
        setDefaultKey("scrollChatUp", KeyCodes.PAGE_UP);
        setDefaultKey("scrollChatDown", KeyCodes.PAGE_DOWN);
        setDefaultKey("miniMapZoomOut", KeyCodes.MINUS);
        setDefaultKey("miniMapZoomIn", KeyCodes.EQUAL);
        setDefaultKey("resetToDefaultCameraAngle", KeyCodes.Z);
        setDefaultKey("togglePerformanceStats", KeyCodes.UNSET);
        setDefaultKey("options", KeyCodes.O);
        setDefaultKey("questlog", KeyCodes.Y);
        setDefaultKey("toggleCentering", KeyCodes.X);
        setDefaultKey("chat", KeyCodes.ENTER);
        setDefaultKey("chatCommand", KeyCodes.SLASH);
        setDefaultKey("tell", KeyCodes.TAB);
        setDefaultKey("guildChat", KeyCodes.G);
        setDefaultKey("testOne", KeyCodes.PERIOD);
        setDefaultKey("toggleFullscreen", KeyCodes.UNSET);
        setDefaultKey("useHealthPotion", KeyCodes.F);
        setDefaultKey("GPURenderToggle", KeyCodes.UNSET);
        setDefaultKey("friendList", KeyCodes.UNSET);
        setDefaultKey("useMagicPotion", KeyCodes.V);
        setDefaultKey("switchTabs", KeyCodes.B);
        setDefaultKey("particleEffect", KeyCodes.P);
        setDefaultKey("toggleHPBar", KeyCodes.H);
        setDefault("playerObjectType", 782);
        setDefault("playMusic", true);
        setDefault("showTierTag",true);
        setDefault("playSFX", true);
        setDefault("playPewPew", true);
        setDefault("centerOnPlayer", true);
        setDefault("preferredServer", null);
        setDefault("needsTutorial", true);
        setDefault("needsRandomRealm", true);
        setDefault("cameraAngle", ((7 * Math.PI) / 4));
        setDefault("defaultCameraAngle", ((7 * Math.PI) / 4));
        setDefault("showQuestPortraits", true);
        setDefault("fullscreenMode", false);
        setDefault("showProtips", true);
        setDefault("protipIndex", 0);
        setDefault("joinDate", MoreDateUtil.getDayStringInPT());
        setDefault("lastDailyAnalytics", null);
        setDefault("allowRotation", true);
        setDefault("allowMiniMapRotation", false);
        setDefault("charIdUseMap", {});
        setDefault("drawShadows", true);
        setDefault("textBubbles", true);
        setDefault("showTradePopup", true);
        setDefault("paymentMethod", null);
        setDefault("filterLanguage", true);
        setDefault("showGuildInvitePopup", true);
        setDefault("clickForGold", false);
        setDefault("contextualPotionBuy", true);
        setDefault("inventorySwap", true);
        setDefault("hideList", 0);
        setDefault("particleEffect", false);
        setDefault("uiQuality", true);
        setDefault("disableEnemyParticles", false);
        setDefault("disableAllyParticles", false);
        setDefault("disablePlayersHitParticles", false);
        setDefault("cursorSelect", "4");
        setDefault("GPURender", false);
        setDefault("forceChatQuality", false);
        setDefault("hidePlayerChat", false);
        setDefault("chatStarRequirement", 1);
        setDefault("chatAll", true);
        setDefault("chatWhisper", true);
        setDefault("chatGuild", true);
        setDefault("chatTrade", true);
        setDefault("toggleBarText", false);
        setDefault("particleEffect", true);
        if (((data_.hasOwnProperty("playMusic")) && ((data_.playMusic == true)))) {
            setDefault("musicVolume", 1);
        }
        else {
            setDefault("musicVolume", 0);
        }
        if (((data_.hasOwnProperty("playSFX")) && ((data_.playMusic == true)))) {
            setDefault("SFXVolume", 1);
        }
        else {
            setDefault("SFXVolume", 0);
        }
        setDefault("HPBar", false);
        setDefault("outlineProj", true);
        setDefault("noAllyNotifications", false);
        setDefault("noAllyDamage", false);
        setDefault("noEnemyDamage", false);
        setDefault("noParticlesMaster", false);
        setDefault("stageScale", StageScaleMode.NO_SCALE);
    }
}
}