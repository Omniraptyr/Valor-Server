package com.company.assembleegameclient.objects {
import com.company.assembleegameclient.map.Camera;
import com.company.assembleegameclient.map.Square;
import com.company.assembleegameclient.map.mapoverlay.CharacterStatusText;
import com.company.assembleegameclient.objects.particles.EffectProperties;
import com.company.assembleegameclient.objects.particles.HealingEffect;
import com.company.assembleegameclient.objects.particles.LevelUpEffect;
import com.company.assembleegameclient.objects.particles.ParticleEffect;
import com.company.assembleegameclient.parameters.Parameters;
import com.company.assembleegameclient.sound.SoundEffectLibrary;
import com.company.assembleegameclient.tutorial.Tutorial;
import com.company.assembleegameclient.tutorial.doneAction;
import com.company.assembleegameclient.util.AnimatedChar;
import com.company.assembleegameclient.util.ConditionEffect;
import com.company.assembleegameclient.util.FameUtil;
import com.company.assembleegameclient.util.FreeList;
import com.company.assembleegameclient.util.MaskedImage;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.assembleegameclient.util.redrawers.GlowRedrawer;
import com.company.util.CachingColorTransformer;
import com.company.util.ConversionUtil;
import com.company.util.GraphicsUtil;
import com.company.util.IntPoint;
import com.company.util.MoreColorUtil;
import com.company.util.PointUtil;
import com.company.util.Trig;

import flash.display.BitmapData;
import flash.display.GraphicsPath;
import flash.display.GraphicsSolidFill;
import flash.display.IGraphicsData;
import flash.geom.ColorTransform;
import flash.geom.Matrix;
import flash.geom.Point;
import flash.geom.Vector3D;
import flash.utils.Dictionary;
import flash.utils.getTimer;

import kabam.rotmg.assets.services.CharacterFactory;
import kabam.rotmg.chat.model.ChatMessage;
import kabam.rotmg.constants.ActivationType;
import kabam.rotmg.constants.GeneralConstants;
import kabam.rotmg.constants.UseType;
import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.game.model.PotionInventoryModel;
import kabam.rotmg.game.signals.AddTextLineSignal;
import kabam.rotmg.stage3D.GraphicsFillExtra;
import kabam.rotmg.text.model.TextKey;
import kabam.rotmg.text.view.BitmapTextFactory;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;
import kabam.rotmg.text.view.stringBuilder.StringBuilder;
import kabam.rotmg.ui.model.TabStripModel;

import org.swiftsuspenders.Injector;

public class Player extends Character {
    public static const MS_BETWEEN_TELEPORT:int = 10000;
    private static const MOVE_THRESHOLD:Number = 0.4;
    private static const NEARBY:Vector.<Point> = new <Point>[new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1)];
    private static const RANK_OFFSET_MATRIX:Matrix = new Matrix(1, 0, 0, 1, 2, 2);
    private static const NAME_OFFSET_MATRIX:Matrix = new Matrix(1, 0, 0, 1, 20, 1);
    private static const MIN_MOVE_SPEED:Number = 0.004;
    private static const MAX_MOVE_SPEED:Number = 0.0096;
    private static const MIN_ATTACK_FREQ:Number = 0.0015;
    private static const MAX_ATTACK_FREQ:Number = 0.008;
    private static const MIN_ATTACK_MULT:Number = 0.5;
    private static const MAX_ATTACK_MULT:Number = 2;
    private static const LOW_HEALTH_CT_OFFSET:int = 128;

    private static var lowHealthCT:Dictionary = new Dictionary();
    public static var rank:int = 0;
    public static var isAdmin:Boolean = false;
    public static var isMod:Boolean = false;
    private static var newP:Point = new Point();

    public var xpTimer:int;
    public var skinId:int;
    public var skin:AnimatedChar;
    public var isShooting:Boolean;
    public var accountId_:String = "";
    public var credits_:int = 0;
    public var tokens_:int = 0;
    public var numStars_:int = 0;
    public var fame_:int = 0;
    public var onrane_:int = 0;
    public var kantos_:int = 0;
    public var might_:int = 0;
    public var luck_:int = 0;
    public var sorStorage_:int = 0;
    public var protection_:int = 0;
    public var restoration_:int = 0;
    public var mightBoost_:int = 0;
    public var luckBoost_:int = 0;
    public var restorationBoost_:int = 0;
    public var protectionBoost_:int = 0;
    public var alertToken_:int = 0;
    public var nameChosen_:Boolean = false;
    public var currFame_:int = 0;
    public var nextClassQuestFame_:int = -1;
    public var guildName_:String = null;
    public var guildRank_:int = -1;
    public var isFellowGuild_:Boolean = false;
    public var rage_:int = -1;
    public var maxMP_:int = 200;
    public var mp_:Number = 0;
    public var nextLevelExp_:int = 1000;
    public var exp_:int = 0;
    public var attack_:int = 0;
    public var speed_:int = 0;
    public var protectionPointsMax_:int = 0;
    public var dexterity_:int = 0;
    public var vitality_:int = 0;
    public var wisdom_:int = 0;
    public var maxHPBoost_:int = 0;
    public var maxMPBoost_:int = 0;
    public var protectionPoints_:int = 0;
    public var attackBoost_:int = 0;
    public var defenseBoost_:int = 0;
    public var speedBoost_:int = 0;
    public var vitalityBoost_:int = 0;
    public var wisdomBoost_:int = 0;
    public var dexterityBoost_:int = 0;
    public var xpBoost_:int = 0;
    public var bronzeLootbox_:int = 0;
    public var silverLootbox_:int = 0;
    public var goldLootbox_:int = 0;
    public var eliteLootbox_:int = 0;
    public var premiumLootbox_:int = 0;
    public var healthPotionCount_:int = 0;
    public var magicPotionCount_:int = 0;
    public var attackMax_:int = 0;
    public var defenseMax_:int = 0;
    public var speedMax_:int = 0;
    public var dexterityMax_:int = 0;
    public var vitalityMax_:int = 0;
    public var wisdomMax_:int = 0;
    public var maxHPMax_:int = 0;
    public var maxMPMax_:int = 0;
    public var hasBackpack_:Boolean = false;
    public var marksEnabled_:Boolean = false;
    public var ascended_:Boolean = false;
    public var mark_:int = 0;
    public var node1_:int = 0;
    public var node2_:int = 0;
    public var node3_:int = 0;
    public var node4_:int = 0;
    public var rank_:int = 0;
    public var elite_:int = 0;
    public var luckMax_:int = 0;
    public var mightMax_:int = 0;
    public var restorationMax_:int = 0;
    public var protectionMax_:int = 0;
    public var admin_:Boolean = false;
    public var starred_:Boolean = false;
    public var ignored_:Boolean = false;
    public var distSqFromThisPlayer_:Number = 0;
    protected var rotate_:Number = 0;
    protected var relMoveVec_:Point = null;
    protected var moveMultiplier_:Number = 1;
    public var attackPeriod_:int = 0;
    public var nextAltAttack_:int = 0;
    public var lastAltAttack_:int = 0;
    public var nextTeleportAt_:int = 0;
    public var dropBoost:int = 0;
    public var tierBoost:int = 0;
    protected var healingEffect_:HealingEffect = null;
    protected var nearestMerchant_:Merchant = null;
    public var isDefaultAnimatedChar:Boolean = true;
    public var projectileIdSetOverrideNew:String = "";
    public var projectileIdSetOverrideOld:String = "";
    private var addTextLine:AddTextLineSignal;
    private var factory:CharacterFactory;
    private var ip_:IntPoint;
    public var criticalMultiplier_:Number;
    public var isCrit_:Boolean;

    private var rageBackFill_:GraphicsSolidFill = null;
    private var rageBackPath_:GraphicsPath = null;
    private var rageFill_:GraphicsSolidFill = null;
    private var ragePath_:GraphicsPath = null;
    private var hallucinatingMaskedImage_:MaskedImage = null;
    private var slideVec_:Vector3D;
    public var surge_:Number = 0;
    private var prevEffect_:String = "";
    private var effString_:String = "";
    private var unusualEffects_:Vector.<ParticleEffect> = null;

    public function Player(plrXML:XML) {
        this.ip_ = new IntPoint();
        var injector:Injector = StaticInjectorContext.getInjector();
        this.addTextLine = injector.getInstance(AddTextLineSignal);
        this.factory = injector.getInstance(CharacterFactory);
        super(plrXML);
        this.attackMax_ = int(plrXML.Attack.@max);
        this.defenseMax_ = int(plrXML.Defense.@max);
        this.speedMax_ = int(plrXML.Speed.@max);
        this.dexterityMax_ = int(plrXML.Dexterity.@max);
        this.vitalityMax_ = int(plrXML.HpRegen.@max);
        this.wisdomMax_ = int(plrXML.MpRegen.@max);
        this.maxHPMax_ = int(plrXML.MaxHitPoints.@max);
        this.maxMPMax_ = int(plrXML.MaxMagicPoints.@max);
        this.mightMax_ = int(plrXML.Might.@max);
        this.luckMax_ = int(plrXML.Luck.@max);
        this.restorationMax_ = int(plrXML.Restoration.@max);
        this.protectionMax_ = int(plrXML.Protection.@max);
        texturingCache_ = new Dictionary();
        unusualEffects_ = new Vector.<ParticleEffect>();
        this.slideVec_ = new Vector3D();
    }

    public static function fromPlayerXML(name:String, plrXML:XML):Player {
        var objType:int = int(plrXML.ObjectType);
        var properties:XML = ObjectLibrary.xmlLibrary_[objType];
        var plr:Player = new Player(properties);
        plr.name_ = name;
        plr.level_ = int(plrXML.Level);
        plr.exp_ = int(plrXML.Exp);
        plr.equipment_ = ConversionUtil.toIntVector(plrXML.Equipment);
        plr.lockedSlot = new Vector.<int>(plr.equipment_.length);
        plr.maxHP_ = int(plrXML.MaxHitPoints);
        plr.hp_ = int(plrXML.HitPoints);
        plr.maxMP_ = int(plrXML.MaxMagicPoints);
        plr.might_ = int(plrXML.Might);
        plr.luck_ = int(plrXML.Luck);
        plr.protection_ = int(plrXML.Restoration);
        plr.restoration_ = int(plrXML.Protection);
        plr.mp_ = int(plrXML.MagicPoints);
        plr.attack_ = int(plrXML.Attack);
        plr.defense_ = int(plrXML.Defense);
        plr.speed_ = int(plrXML.Speed);
        plr.dexterity_ = int(plrXML.Dexterity);
        plr.vitality_ = int(plrXML.HpRegen);
        plr.wisdom_ = int(plrXML.MpRegen);
        plr.tex1Id_ = int(plrXML.Tex1);
        plr.tex2Id_ = int(plrXML.Tex2);
        return (plr);
    }


    public function setRelativeMovement(rotate:Number, x:Number, y:Number):void {
        var cachedX:Number;
        if (this.relMoveVec_ == null) {
            this.relMoveVec_ = new Point();
        }
        this.rotate_ = rotate;
        this.relMoveVec_.x = x;
        this.relMoveVec_.y = y;
        if (isConfused()) {
            cachedX = this.relMoveVec_.x;
            this.relMoveVec_.x = -(this.relMoveVec_.y);
            this.relMoveVec_.y = -(cachedX);
            this.rotate_ = -(this.rotate_);
        }
    }

    public function setCredits(credits:int):void {
        this.credits_ = credits;
    }

    public function setTokens(tokens:int):void {
        this.tokens_ = tokens;
    }

    public function setOnrane(onrane:int):void {
        this.onrane_ = onrane;
    }

    public function setKantos(kantos:int):void {
        this.kantos_ = kantos;
    }

    public function setBronzeLootbox(box:int):void {
        this.bronzeLootbox_ = box;
    }

    public function setSilverLootbox(box:int):void {
        this.silverLootbox_ = box;
    }

    public function setGoldLootbox(box:int):void {
        this.goldLootbox_ = box;
    }

    public function setEliteLootbox(box:int):void {
        this.eliteLootbox_ = box;
    }

    public function setGuildName(_arg1:String):void {
        var _local3:GameObject;
        var _local4:Player;
        var _local5:Boolean;
        this.guildName_ = _arg1;
        var _local2:Player = map_.player_;
        if (_local2 == this) {
            for each (_local3 in map_.goDict_) {
                _local4 = (_local3 as Player);
                if (((!((_local4 == null))) && (!((_local4 == this))))) {
                    _local4.setGuildName(_local4.guildName_);
                }
            }
        }
        else {
            _local5 = ((((((!((_local2 == null))) && (!((_local2.guildName_ == null))))) && (!((_local2.guildName_ == ""))))) && ((_local2.guildName_ == this.guildName_)));
            if (_local5 != this.isFellowGuild_) {
                this.isFellowGuild_ = _local5;
                nameBitmapData_ = null;
            }
        }
    }

    public function isTeleportEligible(_arg1:Player):Boolean {
        return (!(((_arg1.isPaused()) || (_arg1.isInvisible()))));
    }

    public function msUtilTeleport():int {
        var _local1:int = getTimer();
        return (Math.max(0, (this.nextTeleportAt_ - _local1)));
    }

    public function teleportTo(_arg1:Player):Boolean {
        if (isPaused()) {
            this.addTextLine.dispatch(this.makeErrorMessage(TextKey.PLAYER_NOTELEPORTWHILEPAUSED));
            return (false);
        }
        var _local2:int = this.msUtilTeleport();
        if (_local2 > 0) {
            this.addTextLine.dispatch(this.makeErrorMessage(TextKey.PLAYER_TELEPORT_COOLDOWN, {"seconds": int(((_local2 / 1000) + 1))}));
            return (false);
        }
        if (!this.isTeleportEligible(_arg1)) {
            if (_arg1.isInvisible()) {
                this.addTextLine.dispatch(this.makeErrorMessage(TextKey.TELEPORT_INVISIBLE_PLAYER, {"player": _arg1.name_}));
            }
            else {
                this.addTextLine.dispatch(this.makeErrorMessage(TextKey.PLAYER_TELEPORT_TO_PLAYER, {"player": _arg1.name_}));
            }
            return (false);
        }
        map_.gs_.gsc_.teleport(_arg1.objectId_);
        this.nextTeleportAt_ = (getTimer() + MS_BETWEEN_TELEPORT);
        return (true);
    }

    private function makeErrorMessage(_arg1:String, _arg2:Object = null):ChatMessage {
        return (ChatMessage.make(Parameters.ERROR_CHAT_NAME, _arg1, -1, -1, "", false, _arg2));
    }

    public function levelUpEffect(text:String, showEff:Boolean = true):void {
        if (showEff && !Parameters.data_.noParticlesMaster) {
            this.levelUpParticleEffect();
        }
        var status:CharacterStatusText = new CharacterStatusText(this, 65280, 2000);
        status.setStringBuilder(new LineBuilder().setParams(text));
        map_.mapOverlay_.addStatusText(status);
    }

    public function handleLevelUp(_arg1:Boolean):void {
        SoundEffectLibrary.play("level_up");
        if (_arg1) {
            this.levelUpEffect(TextKey.PLAYER_NEWCLASSUNLOCKED, false);
            this.levelUpEffect(TextKey.PLAYER_LEVELUP);
        }
        else {
            this.levelUpEffect(TextKey.PLAYER_LEVELUP);
        }
    }

    public function levelUpParticleEffect(_arg1:uint = 0xFF00FF00):void {
        map_.addObj(new LevelUpEffect(this, _arg1, 20), x_, y_);
    }

    public function handleExpUp(_arg1:int):void {
        if (level_ == 20) {
            return;
        }
        var _local2:CharacterStatusText = new CharacterStatusText(this, 0xFF00, 1000);
        _local2.setStringBuilder(new LineBuilder().setParams(TextKey.PLAYER_EXP, {"exp": _arg1}));
        map_.mapOverlay_.addStatusText(_local2);
    }

    public function BotDModifier():Number {
        if(ObjectLibrary.typeToDisplayId_[this.equipment_[3]] == "Bracelet of the Demolished" && hp_ >= maxHP_ * 0.80){
            return 1.3;
        }else{
            return 1;
        }
    }
    public function KaraModifier():int {
        if(ObjectLibrary.typeToDisplayId_[this.equipment_[0]] == "Karana's Secret" && isInvisible() == true){
            return 20 + this.wisdom_*2;
        }else{
            return 0;
        }
    }
    private function getNearbyMerchant():Merchant {
        var _local3:Point;
        var _local4:Merchant;
        var _local1:int = ((((x_ - int(x_))) > 0.5) ? 1 : -1);
        var _local2:int = ((((y_ - int(y_))) > 0.5) ? 1 : -1);
        for each (_local3 in NEARBY) {
            this.ip_.x_ = (x_ + (_local1 * _local3.x));
            this.ip_.y_ = (y_ + (_local2 * _local3.y));
            _local4 = map_.merchLookup_[this.ip_];
            if (_local4 != null) {
                return ((((PointUtil.distanceSquaredXY(_local4.x_, _local4.y_, x_, y_) < 1)) ? _local4 : null));
            }
        }
        return (null);
    }

    public function walkTo(_arg1:Number, _arg2:Number):Boolean {
        this.modifyMove(_arg1, _arg2, newP);
        return (this.moveTo(newP.x, newP.y));
    }

    override public function moveTo(_arg1:Number, _arg2:Number):Boolean {
        var _local3:Boolean = super.moveTo(_arg1, _arg2);
        if (map_.gs_.evalIsNotInCombatMapArea()) {
            this.nearestMerchant_ = this.getNearbyMerchant();
        }
        return (_local3);
    }

    public function modifyMove(_arg1:Number, _arg2:Number, _arg3:Point):void {
        if (((isParalyzed()) || (isPetrified()))) {
            _arg3.x = x_;
            _arg3.y = y_;
            return;
        }
        var _local4:Number = (_arg1 - x_);
        var _local5:Number = (_arg2 - y_);
        if ((((((((_local4 < MOVE_THRESHOLD)) && ((_local4 > -(MOVE_THRESHOLD))))) && ((_local5 < MOVE_THRESHOLD)))) && ((_local5 > -(MOVE_THRESHOLD))))) {
            this.modifyStep(_arg1, _arg2, _arg3);
            return;
        }
        var _local6:Number = (MOVE_THRESHOLD / Math.max(Math.abs(_local4), Math.abs(_local5)));
        var _local7:Number = 0;
        _arg3.x = x_;
        _arg3.y = y_;
        var _local8:Boolean;
        while (!(_local8)) {
            if ((_local7 + _local6) >= 1) {
                _local6 = (1 - _local7);
                _local8 = true;
            }
            this.modifyStep((_arg3.x + (_local4 * _local6)), (_arg3.y + (_local5 * _local6)), _arg3);
            _local7 = (_local7 + _local6);
        }
    }

    public function modifyStep(_arg1:Number, _arg2:Number, _arg3:Point):void {
        var _local6:Number;
        var _local7:Number;
        var _local4:Boolean = ((((((x_ % 0.5) == 0)) && (!((_arg1 == x_))))) || (!((int((x_ / 0.5)) == int((_arg1 / 0.5))))));
        var _local5:Boolean = ((((((y_ % 0.5) == 0)) && (!((_arg2 == y_))))) || (!((int((y_ / 0.5)) == int((_arg2 / 0.5))))));
        if (((((!(_local4)) && (!(_local5)))) || (this.isValidPosition(_arg1, _arg2)))) {
            _arg3.x = _arg1;
            _arg3.y = _arg2;
            return;
        }
        if (_local4) {
            _local6 = (((_arg1) > x_) ? (int((_arg1 * 2)) / 2) : (int((x_ * 2)) / 2));
            if (int(_local6) > int(x_)) {
                _local6 = (_local6 - 0.01);
            }
        }
        if (_local5) {
            _local7 = (((_arg2) > y_) ? (int((_arg2 * 2)) / 2) : (int((y_ * 2)) / 2));
            if (int(_local7) > int(y_)) {
                _local7 = (_local7 - 0.01);
            }
        }
        if (!_local4) {
            _arg3.x = _arg1;
            _arg3.y = _local7;
            if (((!((square_ == null))) && (!((square_.props_.slideAmount_ == 0))))) {
                this.resetMoveVector(false);
            }
            return;
        }
        if (!_local5) {
            _arg3.x = _local6;
            _arg3.y = _arg2;
            if (((!((square_ == null))) && (!((square_.props_.slideAmount_ == 0))))) {
                this.resetMoveVector(true);
            }
            return;
        }
        var _local8:Number = (((_arg1) > x_) ? (_arg1 - _local6) : (_local6 - _arg1));
        var _local9:Number = (((_arg2) > y_) ? (_arg2 - _local7) : (_local7 - _arg2));
        if (_local8 > _local9) {
            if (this.isValidPosition(_arg1, _local7)) {
                _arg3.x = _arg1;
                _arg3.y = _local7;
                return;
            }
            if (this.isValidPosition(_local6, _arg2)) {
                _arg3.x = _local6;
                _arg3.y = _arg2;
                return;
            }
        }
        else {
            if (this.isValidPosition(_local6, _arg2)) {
                _arg3.x = _local6;
                _arg3.y = _arg2;
                return;
            }
            if (this.isValidPosition(_arg1, _local7)) {
                _arg3.x = _arg1;
                _arg3.y = _local7;
                return;
            }
        }
        _arg3.x = _local6;
        _arg3.y = _local7;
    }

    private function resetMoveVector(_arg1:Boolean):void {
        moveVec_.scaleBy(-0.5);
        if (_arg1) {
            moveVec_.y = (moveVec_.y * -1);
        }
        else {
            moveVec_.x = (moveVec_.x * -1);
        }
    }

    public function isValidPosition(_arg1:Number, _arg2:Number):Boolean {
        var _local3:Square = map_.getSquare(_arg1, _arg2);
        if (((!((square_ == _local3))) && ((((_local3 == null)) || (!(_local3.isWalkable())))))) {
            return (false);
        }
        var _local4:Number = (_arg1 - int(_arg1));
        var _local5:Number = (_arg2 - int(_arg2));
        if (_local4 < 0.5) {
            if (this.isFullOccupy((_arg1 - 1), _arg2)) {
                return (false);
            }
            if (_local5 < 0.5) {
                if (((this.isFullOccupy(_arg1, (_arg2 - 1))) || (this.isFullOccupy((_arg1 - 1), (_arg2 - 1))))) {
                    return (false);
                }
            }
            else {
                if (_local5 > 0.5) {
                    if (((this.isFullOccupy(_arg1, (_arg2 + 1))) || (this.isFullOccupy((_arg1 - 1), (_arg2 + 1))))) {
                        return (false);
                    }
                }
            }
        }
        else {
            if (_local4 > 0.5) {
                if (this.isFullOccupy((_arg1 + 1), _arg2)) {
                    return (false);
                }
                if (_local5 < 0.5) {
                    if (((this.isFullOccupy(_arg1, (_arg2 - 1))) || (this.isFullOccupy((_arg1 + 1), (_arg2 - 1))))) {
                        return (false);
                    }
                }
                else {
                    if (_local5 > 0.5) {
                        if (((this.isFullOccupy(_arg1, (_arg2 + 1))) || (this.isFullOccupy((_arg1 + 1), (_arg2 + 1))))) {
                            return (false);
                        }
                    }
                }
            }
            else {
                if (_local5 < 0.5) {
                    if (this.isFullOccupy(_arg1, (_arg2 - 1))) {
                        return (false);
                    }
                }
                else {
                    if (_local5 > 0.5) {
                        if (this.isFullOccupy(_arg1, (_arg2 + 1))) {
                            return (false);
                        }
                    }
                }
            }
        }
        return (true);
    }
    public function setEffect(_arg1:String):void
    {
        this.effString_ = _arg1;
    }
    public function isFullOccupy(_arg1:Number, _arg2:Number):Boolean {
        var _local3:Square = map_.lookupSquare(_arg1, _arg2);
        return ((((((_local3 == null)) || ((_local3.tileType_ == 0xFF)))) || (((!((_local3.obj_ == null))) && (_local3.obj_.props_.fullOccupy_)))));
    }

    override public function update(currentTime:int, deltaMS:int):Boolean {
        if(prevEffect_ != effString_)
        {
            prevEffect_ = effString_;
            for each(var _effect:ParticleEffect in unusualEffects_)
            {
                map_.removeObj(_effect.objectId_);
            }
            this.unusualEffects_ = new Vector.<ParticleEffect>();
            var _effXML:XML = XML(this.effString_);
            if(_effXML.name() == "Effects")
            {
                for each(var _childEff:XML in _effXML.children())
                {
                    var child:ParticleEffect = ParticleEffect.fromProps(new EffectProperties(_childEff), this);
                    if(child != null)
                    {
                        this.unusualEffects_.push(child);
                    }
                }
            }
            else
            {
                var _newEff:ParticleEffect = ParticleEffect.fromProps(new EffectProperties(XML(this.effString_)), this);
                if(_newEff != null)
                {
                    this.unusualEffects_.push(_newEff);
                }
            }
            for each(var eff:ParticleEffect in unusualEffects_)
            {
                map_.addObj(eff, x_, y_);
            }
        }
        if (this.tierBoost && !isPaused()) {
            this.tierBoost = this.tierBoost - deltaMS;
            if (this.tierBoost < 0) {
                this.tierBoost = 0;
            }
        }
        if (this.dropBoost && !isPaused()) {
            this.dropBoost = this.dropBoost - deltaMS;
            if (this.dropBoost < 0) {
                this.dropBoost = 0;
            }
        }
        if (this.xpTimer && !isPaused()) {
            this.xpTimer = this.xpTimer - deltaMS;
            if (this.xpTimer < 0) {
                this.xpTimer = 0;
            }
        }

        if (isHealing() && !isPaused()
                && this.healingEffect_ == null
                && !Parameters.data_.noParticlesMaster) {
            this.healingEffect_ = new HealingEffect(this);
            map_.addObj(this.healingEffect_, x_, y_);
        }
        else {
            if (this.healingEffect_ != null) {
                map_.removeObj(this.healingEffect_.objectId_);
                this.healingEffect_ = null;
            }
        }

        var angle:Number = Parameters.data_.cameraAngle;
        if (this.rotate_ != 0) {
            angle = angle + deltaMS * Parameters.PLAYER_ROTATE_SPEED * this.rotate_;
            Parameters.data_.cameraAngle = angle;
        }

        if (map_.player_ == this && isPaused()) {
            return true;
        }

        if (this.relMoveVec_ != null) {
            if (this.relMoveVec_.x != 0 || this.relMoveVec_.y != 0) {
                var mvSpd:Number = this.getMoveSpeed();
                var mvAngle:Number = Math.atan2(this.relMoveVec_.y, this.relMoveVec_.x);
                if (square_.props_.slideAmount_ > 0) {
                    slideVec_.x = mvSpd * Math.cos(angle + mvAngle);
                    slideVec_.y = mvSpd * Math.sin(angle + mvAngle);
                    slideVec_.z = 0;
                    moveVec_.scaleBy(square_.props_.slideAmount_);
                    if (moveVec_.length < slideVec_.length) {
                        slideVec_.scaleBy(1 - square_.props_.slideAmount_);
                        moveVec_ = moveVec_.add(slideVec_);
                    }
                }
                else {
                    moveVec_.x = mvSpd * Math.cos(angle + mvAngle);
                    moveVec_.y = mvSpd * Math.sin(angle + mvAngle);
                }
            }
            else {
                if (moveVec_.length > 0.00012 && square_.props_.slideAmount_ > 0) {
                    moveVec_.scaleBy(square_.props_.slideAmount_);
                }
                else {
                    moveVec_.x = 0;
                    moveVec_.y = 0;
                }
            }
            if (square_ != null && square_.props_.push_) {
                moveVec_.x = moveVec_.x - square_.props_.animate_.dx_ / 1000;
                moveVec_.y = moveVec_.y - square_.props_.animate_.dy_ / 1000;
            }
            this.walkTo(x_ + deltaMS * moveVec_.x, y_ + deltaMS * moveVec_.y);
        }
        else {
            if (!super.update(currentTime, deltaMS)) {
                return false;
            }
        }
        if (map_.player_ == this &&
                square_.props_.maxDamage_ > 0 &&
                (square_.lastDamage_ + 500) < currentTime &&
                !isInvincible() &&
                (square_.obj_ == null || !square_.obj_.props_.protectFromGroundDamage_)) {
            var dmg:int = map_.gs_.gsc_.getNextDamage(square_.props_.minDamage_, square_.props_.maxDamage_);
            var conditionEffects:Vector.<uint> = new Vector.<uint>();
            conditionEffects.push(ConditionEffect.GROUND_DAMAGE);
            damage(-1, dmg, conditionEffects, hp_ <= dmg, null);
            map_.gs_.gsc_.groundDamage(currentTime, x_, y_);
            square_.lastDamage_ = currentTime;
        }
        return true;
    }

    public function onMove():void {
        if (map_ == null) {
            return;
        }
        var _local1:Square = map_.getSquare(x_, y_);
        if (_local1.props_.sinking_) {
            sinkLevel_ = Math.min((sinkLevel_ + 1), Parameters.MAX_SINK_LEVEL);
            this.moveMultiplier_ = (0.1 + ((1 - (sinkLevel_ / Parameters.MAX_SINK_LEVEL)) * (_local1.props_.speed_ - 0.1)));
        }
        else {
            sinkLevel_ = 0;
            this.moveMultiplier_ = _local1.props_.speed_;
        }
    }

    override protected function makeNameBitmapData():BitmapData {
        var _local1:StringBuilder = new StaticStringBuilder(name_);
        var _local2:BitmapTextFactory = StaticInjectorContext.getInjector().getInstance(BitmapTextFactory);
        var _local3:BitmapData = _local2.make(_local1, 16, this.getNameColor(), true, NAME_OFFSET_MATRIX, true);
        _local3.draw(FameUtil.numStarsToIcon(this.numStars_, this.admin_), RANK_OFFSET_MATRIX);
        return (_local3);
    }

    private function getNameColor():uint {
        if (this.isFellowGuild_) {
            return (Parameters.FELLOW_GUILD_COLOR);
        }
        if (this.nameChosen_) {
            return (Parameters.NAME_CHOSEN_COLOR);
        }
        return (0xFFFFFF);
    }

	protected function drawRageBar(gfx:Vector.<IGraphicsData>, time:int) : void {
        var r:Number = NaN;
        var rw:Number = NaN;
        if (this.ragePath_ == null) {
            this.rageBackFill_ = new GraphicsSolidFill();
            this.rageBackPath_ = new GraphicsPath(GraphicsUtil.QUAD_COMMANDS, new Vector.<Number>());
            this.rageFill_ = new GraphicsSolidFill(16747520);
            this.ragePath_ = new GraphicsPath(GraphicsUtil.QUAD_COMMANDS, new Vector.<Number>());
        }
        if(this.rage_ <= Parameters.RAGE_THRESH) {
            r = (Parameters.RAGE_THRESH - this.rage_) / Parameters.RAGE_THRESH;
            this.rageBackFill_.color = MoreColorUtil.lerpColor(1118481, 16711680, Math.abs(Math.sin(time / 300)) * r);
        } else {
            this.rageBackFill_.color = 1118481;
        }
        var ragePath:Vector.<Number> = this.rageBackPath_.data as Vector.<Number>;
        ragePath.length = 0;
        ragePath.push(posS_[0] - 20 - 1.2,
		        posS_[1] + 12 - 0 - 0,
		        posS_[0] + 20 + 1.2,
		        posS_[1] + 12 - 0 - 0,
		        posS_[0] + 20 + 1.2,
		        posS_[1] + 12 + 5 + 1.2,
		        posS_[0] - 20 - 1.2,
		        posS_[1] + 12 + 5 + 1.2);
        gfx.push(this.rageBackFill_);
        gfx.push(this.rageBackPath_);
        gfx.push(GraphicsUtil.END_FILL);
        if(this.rage_ > 0) {
            rw = this.rage_ / 100 * 2 * 20;
            this.ragePath_.data.length = 0;
            ragePath = this.ragePath_.data as Vector.<Number>;
            ragePath.length = 0;
            ragePath.push(posS_[0] - 20,
			        posS_[1] + 12,
			        posS_[0] - 20 + rw,
			        posS_[1] + 12,
			        posS_[0] - 20 + rw,
			        posS_[1] + 12 + 5,
			        posS_[0] - 20,
			        posS_[1] + 12 + 5);
            gfx.push(this.rageFill_);
            gfx.push(this.ragePath_);
            gfx.push(GraphicsUtil.END_FILL);
        }
        GraphicsFillExtra.setSoftwareDrawSolid(this.rageFill_,true);
        GraphicsFillExtra.setSoftwareDrawSolid(this.rageBackFill_,true);
    }

    override public function draw(_arg_1:Vector.<IGraphicsData>, _arg_2:Camera, _arg_3:int) : void
    {
        switch (Parameters.data_.hideList) {
            case 1:
                if (this != map_.player_ && !this.starred_) return;
                break;
            case 2:
                if (this != map_.player_ && !this.isFellowGuild_) return;
                break;
            case 3:
                if (this != map_.player_ && !this.starred_ && !this.isFellowGuild_) return;
                break;
        }

        super.draw(_arg_1,_arg_2,_arg_3);

        if(this != map_.player_) {
            drawName(_arg_1, _arg_2);
        } else if(this.rage_ >= 1) {
            this.drawRageBar(_arg_1,_arg_3);
        }
    }

    private function getMoveSpeed():Number {
        if (isSlowed()) {
            return ((MIN_MOVE_SPEED * this.moveMultiplier_));
        }
        var _local1:Number = (MIN_MOVE_SPEED + ((this.speed_ / 75) * (MAX_MOVE_SPEED - MIN_MOVE_SPEED)));
        if (((isSpeedy()) || (isNinjaSpeedy()))) {
            _local1 = (_local1 * 1.5);
        }
        if (isSwiftness()) {
            _local1 = (_local1 * 1.7);
        }
        return ((_local1 * this.moveMultiplier_));
    }

    public function attackFrequency():Number {
        if (isDazed()) {
            return (MIN_ATTACK_FREQ);
        }
        var _local1:Number = (MIN_ATTACK_FREQ + (((this.dexterity_) / 75) * (MAX_ATTACK_FREQ - MIN_ATTACK_FREQ)));
        if (isBerserk() || isSamuraiBerserk() || isGrasp()) {
            _local1 = (_local1 * 1.5);
        }
        if (isAlliance()) {
            _local1 = (_local1 * 1.8);
        }
        return (_local1);
    }

    private function attackMultiplier():Number {
        if (isWeak()) {
            return (MIN_ATTACK_MULT);
        }
        var _local1:Number = (MIN_ATTACK_MULT + ((this.attack_ / 75) * (MAX_ATTACK_MULT - MIN_ATTACK_MULT)));
        if (isDamaging()) {
            _local1 = (_local1 * 1.5);
        }
        if(isMercy()){
            _local1 = (_local1 * 1.15);
        }

        if(isMercy() && isDamaging()){
            _local1 = (_local1 * 1.65);
        }
        return (_local1);
    }
    private function relentlessDamageBonus():Number{
        if(isRelentless()){
            return surge_*6;
        }else{
            return 0;
        }
    }
    private function MarkRage():Number{
        if(mark_ == 3){
            return surge_*3;
        }else{
            return 0;
        }
    }



    private function aegisDamageBonus():Number{
        if(isVengeance()){
            return (maxHP_-hp_)/2;
        }else{
            return 0;
        }
    }


    private function isMercy():Boolean{
        if(ObjectLibrary.typeToDisplayId_[this.equipment_[2]] == "Mercy of Yazanahar" && mp_ <= maxMP_/2){
            return true;
        }else{
            return false;
        }
    }
    private function makeSkinTexture():void {
        var _local1:MaskedImage = this.skin.imageFromAngle(0, AnimatedChar.STAND, 0);
        animatedChar_ = this.skin;
        texture_ = _local1.image_;
        mask_ = _local1.mask_;
        this.isDefaultAnimatedChar = true;
    }

    private function setToRandomAnimatedCharacter():void {
        var _local1:Vector.<XML> = ObjectLibrary.hexTransforms_;
        var _local2:uint = Math.floor((Math.random() * _local1.length));
        var _local3:int = _local1[_local2].@type;
        var _local4:TextureData = ObjectLibrary.typeToTextureData_[_local3];
        texture_ = _local4.texture_;
        mask_ = _local4.mask_;
        animatedChar_ = _local4.animatedChar_;
        this.isDefaultAnimatedChar = false;
    }

    override protected function getTexture(camera:Camera, currentTime:int):BitmapData {
        var pos:Number = 0;
        var action:int = AnimatedChar.STAND;

        if (this.isShooting || currentTime < (attackStart_ + this.attackPeriod_)) {
            facing_ = attackAngle_;
            pos = ((currentTime - attackStart_) % this.attackPeriod_) / this.attackPeriod_;
            action = AnimatedChar.ATTACK;
        }
        else {
            if (moveVec_.x != 0 || moveVec_.y != 0) {
                var movPeriod:int = 3.5 / this.getMoveSpeed();
                if (moveVec_.y != 0 || moveVec_.x != 0) {
                    facing_ = Math.atan2(moveVec_.y, moveVec_.x);
                }
                pos = (currentTime % movPeriod) / movPeriod;
                action = AnimatedChar.WALK;
            }
        }

        if (this.isHexed()) {
            this.isDefaultAnimatedChar && this.setToRandomAnimatedCharacter();
        }
        else {
            if (!this.isDefaultAnimatedChar) {
                this.makeSkinTexture();
            }
        }

        var maskImg:MaskedImage;
        if (camera.isHallucinating_) {
            maskImg = getHallucinatingMaskedImage();
        }
        else {
            maskImg = animatedChar_.imageFromFacing(facing_, camera, action, pos);
        }

        var tex1Id:int = tex1Id_;
        var tex2Id:int = tex2Id_;
        var tex:BitmapData;
        if (this.nearestMerchant_) {
            var merchDict:Dictionary = texturingCache_[this.nearestMerchant_];
            if (merchDict == null) {
                texturingCache_[this.nearestMerchant_] = new Dictionary();
            }
            else {
                tex = merchDict[maskImg];
            }
            tex1Id = this.nearestMerchant_.getTex1Id(tex1Id_);
            tex2Id = this.nearestMerchant_.getTex2Id(tex2Id_);
        }
        else {
            tex = texturingCache_[maskImg];
        }
        if (tex == null) {
            tex = TextureRedrawer.resize(maskImg.image_, maskImg.mask_, size_, false, tex1Id, tex2Id);
            if (this.nearestMerchant_ != null) {
                texturingCache_[this.nearestMerchant_][maskImg] = tex;
            }
            else {
                texturingCache_[maskImg] = tex;
            }
        }

        if (hp_ < maxHP_ * 0.2) {
            var intensity:Number = int(Math.abs(Math.sin(currentTime / 200)) * 10) / 10;
            var ct:ColorTransform = lowHealthCT[intensity];
            if (ct == null) {
                ct = new ColorTransform(1, 1, 1, 1,
                        intensity * LOW_HEALTH_CT_OFFSET,
                        -intensity * LOW_HEALTH_CT_OFFSET,
                        -intensity * LOW_HEALTH_CT_OFFSET);
                lowHealthCT[intensity] = ct;
            }
            tex = CachingColorTransformer.transformBitmapData(tex, ct);
        }

        var plrTex:BitmapData = texturingCache_[tex];
        if (plrTex == null) {
            plrTex = GlowRedrawer.outlineGlow(tex, this.glowColor_);
            texturingCache_[tex] = plrTex;
        }
        if (isPaused() || isStasis() || isPetrified()) {
            plrTex = CachingColorTransformer.filterBitmapData(plrTex, PAUSED_FILTER);
        }
        else {
            if (isInvisible()) {
                plrTex = CachingColorTransformer.alphaBitmapData(plrTex, 40);
            }
        }
        return plrTex;
    }

    private function getHallucinatingMaskedImage():MaskedImage {
        if (hallucinatingMaskedImage_ == null) {
            hallucinatingMaskedImage_ = new MaskedImage(getHallucinatingTexture(), null);
        }
        return hallucinatingMaskedImage_;
    }

    override public function getPortrait():BitmapData {
        var _local1:MaskedImage;
        var _local2:int;
        if (portrait_ == null) {
            _local1 = animatedChar_.imageFromDir(AnimatedChar.RIGHT, AnimatedChar.STAND, 0);
            _local2 = ((4 / _local1.image_.width) * 100);
            portrait_ = TextureRedrawer.resize(_local1.image_, _local1.mask_, _local2, true, tex1Id_, tex2Id_);
            portrait_ = GlowRedrawer.outlineGlow(portrait_, 0);
        }
        return (portrait_);
    }

    public function useAltWeapon(mouseX:Number, mouseY:Number, useType:int):Boolean {
        var activateXML:XML;
        var curTime:int;
        var shootAngle:Number;
        var manaCost:int;
        var cooldownMS:int;
        var surgeCost:int;
        var healthCost:int;
        if (map_ == null || isPaused()) {
            return false;
        }

        var itemId:int = equipment_[1];
        if (itemId == -1) {
            return false;
        }

        var itemXML:XML = ObjectLibrary.xmlLibrary_[itemId];
        if (itemXML == null || !itemXML.hasOwnProperty("Usable"))
            return false;

        var target:Point = map_.pSTopW(mouseX, mouseY);
        if (target == null) {
            SoundEffectLibrary.play("error");
            return false;
        }

        for each (activateXML in itemXML.Activate) {
            if (activateXML.toString() == ActivationType.TELEPORT) {
                if (!this.isValidPosition(target.x, target.y)) {
                    SoundEffectLibrary.play("error");
                    return false;
                }
            }
        }

        curTime = getTimer();
        if (curTime < this.nextAltAttack_) {
            SoundEffectLibrary.play("error");
            return false;
        }

        if (useType == UseType.START_USE) {
            surgeCost = int(itemXML.SurgeCost);
            healthCost = int(itemXML.HpCost);
            manaCost = int(itemXML.MpCost);

            if (manaCost != 0 && manaCost > this.mp_) {
                SoundEffectLibrary.play("no_mana");
                return false;
            }

            if (healthCost != 0 && healthCost > this.hp_) {
                SoundEffectLibrary.play("no_mana");
                return false;
            }

            if (surgeCost != 0 && surgeCost > this.surge_) {
                SoundEffectLibrary.play("no_mana");
                return false;
            }

            cooldownMS = 550;
            if (itemXML.hasOwnProperty("Cooldown")) {
                cooldownMS = (Number(itemXML.Cooldown) * 1000);
            }

            this.nextAltAttack_ = curTime + cooldownMS;
            this.lastAltAttack_ = curTime;

            map_.gs_.gsc_.useItem(curTime, objectId_, 1, itemId, target.x, target.y, useType);

            if (itemXML.Activate == ActivationType.SHOOT) {
                shootAngle = Math.atan2(mouseY, mouseX);
                this.doShoot(curTime, itemId, itemXML, (Parameters.data_.cameraAngle + shootAngle), false);
            }
        } else {
            if (itemXML.hasOwnProperty("MultiPhase")) {
                map_.gs_.gsc_.useItem(curTime, objectId_, 1, itemId, target.x, target.y, useType);
                manaCost = int(itemXML.MpEndCost);
                if (manaCost <= this.mp_) {
                    shootAngle = Math.atan2(mouseY, mouseX);
                    this.doShoot(curTime, itemId, itemXML, (Parameters.data_.cameraAngle + shootAngle), false);
                }
            }
        }
        return true;
    }

    public function attemptAttackAngle(angle:Number):void {
        this.shoot(Parameters.data_.cameraAngle + angle);
    }

    override public function setAttack(_arg1:int, _arg2:Number):void {
        var _local3:XML = ObjectLibrary.xmlLibrary_[_arg1];
        if ((((_local3 == null)) || (!(_local3.hasOwnProperty("RateOfFire"))))) {
            return;
        }
        var _local4:Number = Number(_local3.RateOfFire);
        this.attackPeriod_ = ((1 / this.attackFrequency()) * (1 / _local4));
        super.setAttack(_arg1, _arg2);
    }

    private function shoot(angle:Number):void {
        if (map_ == null || isStunned() || isPaused() || isPetrified()) {
            return;
        }

        var weapType:int = equipment_[0];
        if (weapType == -1) {
            return;
        }

        var weapon:XML = ObjectLibrary.xmlLibrary_[weapType];
        var curTime:int = getTimer();
        var fireRate:Number = Number(weapon.RateOfFire);
        this.attackPeriod_ = (1 / this.attackFrequency()) * (1 / fireRate);
        if (curTime < attackStart_ + this.attackPeriod_) {
            return;
        }

        doneAction(map_.gs_, Tutorial.ATTACK_ACTION);
        attackAngle_ = angle;
        attackStart_ = curTime;
        this.doShoot(attackStart_, weapType, weapon, attackAngle_, true);
    }

    private function doShoot(_arg1:int, _arg2:int, _arg3:XML, _arg4:Number, _arg5:Boolean):void {
        var _local11:uint;
        var _local12:Projectile;
        var _local13:int;
        var _local14:int;
        var _local15:Number;
        var _local16:int;
        var _local6:int = ((_arg3.hasOwnProperty("NumProjectiles")) ? int(_arg3.NumProjectiles) : 1);
        var _local7:Number = (((_arg3.hasOwnProperty("ArcGap")) ? Number(_arg3.ArcGap) : 11.25) * Trig.toRadians);
        var _local8:Number = (_local7 * (_local6 - 1));
        var _local9:Number = (_arg4 - (_local8 / 2));
        this.isShooting = _arg5;
        var _local10:int;
        while (_local10 < _local6) {
            _local11 = getBulletId();
            _local12 = (FreeList.newObject(Projectile) as Projectile);
            if (((_arg5) && (!((this.projectileIdSetOverrideNew == ""))))) {
                _local12.reset(_arg2, 0, objectId_, _local11, _local9, _arg1, this.projectileIdSetOverrideNew, this.projectileIdSetOverrideOld);
            }
            else {
                _local12.reset(_arg2, 0, objectId_, _local11, _local9, _arg1);
            }
            _local13 = int(_local12.projProps_.minDamage_);
            _local14 = int(_local12.projProps_.maxDamage_);
            _local15 = ((_arg5) ? this.attackMultiplier() : 1);
            _local16 = (map_.gs_.gsc_.getNextDamage(_local13, _local14) * _local15 + (this.relentlessDamageBonus() + this.aegisDamageBonus() + this.KaraModifier() + this.MarkRage()) * this.BotDModifier());
            if (_arg1 > (map_.gs_.moveRecords_.lastClearTime_ + 600)) {
                _local16 = 0;
            }
            _local12.setDamage(_local16);
            if ((((_local10 == 0)) && (!((_local12.sound_ == null))))) {
                SoundEffectLibrary.play(_local12.sound_, 0.75, false);
            }
            map_.addObj(_local12, (x_ + (Math.cos(_arg4) * 0.3)), (y_ + (Math.sin(_arg4) * 0.3)));
            map_.gs_.gsc_.playerShoot(_arg1, _local12);
            _local9 = (_local9 + _local7);
            _local10++;
        }
    }

    public function isHexed():Boolean {
        return (!(((condition_[ConditionEffect.CE_FIRST_BATCH] & ConditionEffect.HEXED_BIT) == 0)));
    }

    public function isInventoryFull():Boolean {
        if (equipment_ == null) {
            return (false);
        }
        var _local1:int = equipment_.length;
        var _local2:uint = 4;
        while (_local2 < _local1) {
            if (equipment_[_local2] <= 0) {
                return (false);
            }
            _local2++;
        }
        return (true);
    }

    public function nextAvailableInventorySlot():int {
        var _local1:int = ((this.hasBackpack_) ? equipment_.length : (equipment_.length - GeneralConstants.NUM_INVENTORY_SLOTS));
        var _local2:uint = 4;
        while (_local2 < _local1) {
            if (equipment_[_local2] <= 0) {
                return (_local2);
            }
            _local2++;
        }
        return (-1);
    }

    public function numberOfAvailableSlots():int {
        var _local1:int = ((this.hasBackpack_) ? equipment_.length : (equipment_.length - GeneralConstants.NUM_INVENTORY_SLOTS));
        var _local2:int;
        var _local3:uint = 4;
        while (_local3 < _local1) {
            if (equipment_[_local3] <= 0) {
                _local2++;
            }
            _local3++;
        }
        return (_local2);
    }

    public function swapInventoryIndex(_arg1:String):int {
        var _local2:int;
        var _local3:int;
        if (!this.hasBackpack_) {
            return (-1);
        }
        if (_arg1 == TabStripModel.BACKPACK) {
            _local2 = GeneralConstants.NUM_EQUIPMENT_SLOTS;
            _local3 = (GeneralConstants.NUM_EQUIPMENT_SLOTS + GeneralConstants.NUM_INVENTORY_SLOTS);
        }
        else {
            _local2 = (GeneralConstants.NUM_EQUIPMENT_SLOTS + GeneralConstants.NUM_INVENTORY_SLOTS);
            _local3 = equipment_.length;
        }
        var _local4:uint = _local2;
        while (_local4 < _local3) {
            if (equipment_[_local4] <= 0) {
                return (_local4);
            }
            _local4++;
        }
        return (-1);
    }

    public function getPotionCount(_arg1:int):int {
        switch (_arg1) {
            case PotionInventoryModel.HEALTH_POTION_ID:
                return (this.healthPotionCount_);
            case PotionInventoryModel.MAGIC_POTION_ID:
                return (this.magicPotionCount_);
        }
        return (0);
    }

    public function getTex1():int {
        return (tex1Id_);
    }

    public function getTex2():int {
        return (tex2Id_);
    }


}
}
