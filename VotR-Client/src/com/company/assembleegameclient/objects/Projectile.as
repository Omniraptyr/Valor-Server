package com.company.assembleegameclient.objects {
import com.company.assembleegameclient.engine3d.Point3D;
import com.company.assembleegameclient.map.Camera;
import com.company.assembleegameclient.map.Map;
import com.company.assembleegameclient.map.Square;
import com.company.assembleegameclient.objects.particles.HitEffect;
import com.company.assembleegameclient.objects.particles.SparkParticle;
import com.company.assembleegameclient.parameters.Parameters;
import com.company.assembleegameclient.tutorial.Tutorial;
import com.company.assembleegameclient.tutorial.doneAction;
import com.company.assembleegameclient.util.BloodComposition;
import com.company.assembleegameclient.util.ConditionEffect;
import com.company.assembleegameclient.util.FreeList;
import com.company.assembleegameclient.util.RandomUtil;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.util.GraphicsUtil;
import com.company.util.Trig;

import flash.display.BitmapData;
import flash.display.GradientType;
import flash.display.GraphicsGradientFill;
import flash.display.GraphicsPath;
import flash.display.IGraphicsData;
import flash.geom.Matrix;
import flash.geom.Point;
import flash.geom.Vector3D;
import flash.utils.Dictionary;

public class Projectile extends BasicObject {

    private static var objBullIdToObjId_:Dictionary = new Dictionary();

    public var props_:ObjectProperties;
    public var containerProps_:ObjectProperties;
    public var projProps_:ProjectileProperties;
    public var texture_:BitmapData;
    public var bulletId_:uint;
    public var ownerId_:int;
    public var containerType_:int;
    public var bulletType_:uint;
    public var damagesEnemies_:Boolean;
    public var damagesPlayers_:Boolean;
    public var damagesFromPlayer_:Boolean;
    public var damage_:int;
    public var sound_:String;
    public var startX_:Number;
    public var startY_:Number;
    public var startTime_:int;
    public var angle_:Number = 0;
    public var multiHitDict_:Dictionary;
    public var p_:Point3D;
    private var staticPoint_:Point;
    private var staticVector3D_:Vector3D;
    protected var shadowGradientFill_:GraphicsGradientFill;
    protected var shadowPath_:GraphicsPath;

    public function Projectile() {
        this.p_ = new Point3D(100);
        this.staticPoint_ = new Point();
        this.staticVector3D_ = new Vector3D();
        this.shadowGradientFill_ = new GraphicsGradientFill(GradientType.RADIAL, [0, 0], [0.5, 0], null, new Matrix());
        this.shadowPath_ = new GraphicsPath(GraphicsUtil.QUAD_COMMANDS, new Vector.<Number>());
        super();
    }

    public static function findObjId(_arg1:int, _arg2:uint):int {
        return (objBullIdToObjId_[((_arg2 << 24) | _arg1)]);
    }

    public static function getNewObjId(_arg1:int, _arg2:uint):int {
        var _local3:int = getNextFakeObjectId();
        objBullIdToObjId_[((_arg2 << 24) | _arg1)] = _local3;
        return (_local3);
    }

    public static function removeObjId(_arg1:int, _arg2:uint):void {
        delete objBullIdToObjId_[((_arg2 << 24) | _arg1)];
    }

    public static function dispose():void {
        objBullIdToObjId_ = new Dictionary();
    }


    public function reset(_arg1:int, _arg2:int, _arg3:int, _arg4:int, _arg5:Number, _arg6:int, _arg7:String = "", _arg8:String = ""):void {
        var _local11:Number;
        clear();
        this.containerType_ = _arg1;
        this.bulletType_ = _arg2;
        this.ownerId_ = _arg3;
        this.bulletId_ = _arg4;
        this.angle_ = Trig.boundToPI(_arg5);
        this.startTime_ = _arg6;
        objectId_ = getNewObjId(this.ownerId_, this.bulletId_);
        z_ = 0.5;
        this.containerProps_ = ObjectLibrary.propsLibrary_[this.containerType_];
        this.projProps_ = this.containerProps_.projectiles_[_arg2];
        var _local9:String = ((((!((_arg7 == ""))) && ((this.projProps_.objectId_ == _arg8)))) ? _arg7 : this.projProps_.objectId_);
        this.props_ = ObjectLibrary.getPropsFromId(_local9);
        hasShadow_ = (this.props_.shadowSize_ > 0);
        var _local10:TextureData = ObjectLibrary.typeToTextureData_[this.props_.type_];
        this.texture_ = _local10.getTexture(objectId_);
        this.damagesPlayers_ = this.containerProps_.isEnemy_;
        this.damagesFromPlayer_ = this.containerProps_.isPlayer_;
        this.damagesEnemies_ = !(this.damagesPlayers_);
        this.sound_ = this.containerProps_.oldSound_;
        this.multiHitDict_ = ((this.projProps_.multiHit_) ? new Dictionary() : null);
        if (this.projProps_.size_ >= 0) {
            _local11 = this.projProps_.size_;
        }
        else {
            _local11 = ObjectLibrary.getSizeFromType(this.containerType_);
        }
        this.p_.setSize((8 * (_local11 / 100)));
        this.damage_ = 0;
    }

    public function setDamage(_arg1:int):void {
        this.damage_ = _arg1;
    }

    override public function addTo(_arg1:Map, _arg2:Number, _arg3:Number):Boolean {
        var _local4:Player;
        this.startX_ = _arg2;
        this.startY_ = _arg3;
        if (!super.addTo(_arg1, _arg2, _arg3)) {
            return (false);
        }
        if (((!(this.containerProps_.flying_)) && (square_.sink_))) {
            z_ = 0.1;
        }
        else {
            _local4 = (_arg1.goDict_[this.ownerId_] as Player);
            if (((!((_local4 == null))) && ((_local4.sinkLevel_ > 0)))) {
                z_ = (0.5 - (0.4 * (_local4.sinkLevel_ / Parameters.MAX_SINK_LEVEL)));
            }
        }
        return (true);
    }

    public function moveTo(_arg1:Number, _arg2:Number):Boolean {
        var _local3:Square = map_.getSquare(_arg1, _arg2);
        if (_local3 == null) {
            return (false);
        }
        x_ = _arg1;
        y_ = _arg2;
        square_ = _local3;
        return (true);
    }

    override public function removeFromMap():void {
        super.removeFromMap();
        removeObjId(this.ownerId_, this.bulletId_);
        this.multiHitDict_ = null;
        FreeList.deleteObject(this);
    }

    private function positionAt(_arg1:int, _arg2:Point):void {
        var _local5:Number;
        var _local6:Number;
        var _local7:Number;
        var _local8:Number;
        var _local9:Number;
        var _local10:Number;
        var _local11:Number;
        var _local12:Number;
        var _local13:Number;
        var _local14:Number;
        _arg2.x = this.startX_;
        _arg2.y = this.startY_;
        var _local3:Number = (_arg1 * (this.projProps_.speed_ / 10000));
        var _local4:Number = ((((this.bulletId_ % 2)) == 0) ? 0 : Math.PI);
        if (this.projProps_.wavy_) {
            _local5 = (6 * Math.PI);
            _local6 = (Math.PI / 64);
            _local7 = (this.angle_ + (_local6 * Math.sin((_local4 + ((_local5 * _arg1) / 1000)))));
            _arg2.x = (_arg2.x + (_local3 * Math.cos(_local7)));
            _arg2.y = (_arg2.y + (_local3 * Math.sin(_local7)));
        }
        else {
            if (this.projProps_.parametric_) {
                _local8 = (((_arg1 / this.projProps_.lifetime_) * 2) * Math.PI);
                _local9 = (Math.sin(_local8) * (((this.bulletId_ % 2)) ? 1 : -1));
                _local10 = (Math.sin((2 * _local8)) * ((((this.bulletId_ % 4)) < 2) ? 1 : -1));
                _local11 = Math.sin(this.angle_);
                _local12 = Math.cos(this.angle_);
                _arg2.x = (_arg2.x + (((_local9 * _local12) - (_local10 * _local11)) * this.projProps_.magnitude_));
                _arg2.y = (_arg2.y + (((_local9 * _local11) + (_local10 * _local12)) * this.projProps_.magnitude_));
            }
            else {
                if (this.projProps_.boomerang_) {
                    _local13 = ((this.projProps_.lifetime_ * (this.projProps_.speed_ / 10000)) / 2);
                    if (_local3 > _local13) {
                        _local3 = (_local13 - (_local3 - _local13));
                    }
                }
                _arg2.x = (_arg2.x + (_local3 * Math.cos(this.angle_)));
                _arg2.y = (_arg2.y + (_local3 * Math.sin(this.angle_)));
                if (this.projProps_.amplitude_ != 0) {
                    _local14 = (this.projProps_.amplitude_ * Math.sin((_local4 + ((((_arg1 / this.projProps_.lifetime_) * this.projProps_.frequency_) * 2) * Math.PI))));
                    _arg2.x = (_arg2.x + (_local14 * Math.cos((this.angle_ + (Math.PI / 2)))));
                    _arg2.y = (_arg2.y + (_local14 * Math.sin((this.angle_ + (Math.PI / 2)))));
                }
            }
        }
    }

    override public function update(currentTime:int, msDelta:int):Boolean {
        var blood:Vector.<uint>;

        var lifetime:int = currentTime - this.startTime_;
        if (lifetime > this.projProps_.lifetime_) {
            return false;
        }

        var pnt:Point = this.staticPoint_;
        this.positionAt(lifetime, pnt);

        if (!this.moveTo(pnt.x, pnt.y) || square_.tileType_ == 0xFFFF) {
            if (this.damagesPlayers_) {
                map_.gs_.gsc_.squareHit(currentTime, this.bulletId_, this.ownerId_);
            }
            else if (square_.obj_ != null && !Parameters.data_.noParticlesMaster) {
                blood = BloodComposition.getColors(this.texture_);
                map_.addObj(new HitEffect(blood, 100, 3, this.angle_, this.projProps_.speed_), pnt.x, pnt.y);
            }
            return false;
        }

        if (square_.obj_ != null &&
                (!square_.obj_.props_.isEnemy_ || !this.damagesEnemies_) &&
                (square_.obj_.props_.enemyOccupySquare_ || !this.projProps_.passesCover_ && square_.obj_.props_.occupySquare_)) {
            if (this.damagesPlayers_) {
                map_.gs_.gsc_.otherHit(currentTime, this.bulletId_, this.ownerId_, square_.obj_.objectId_);
            }
            else if (!Parameters.data_.noParticlesMaster) {
                blood = BloodComposition.getColors(this.texture_);
                map_.addObj(new HitEffect(blood, 100, 3, this.angle_, this.projProps_.speed_), pnt.x, pnt.y);
            }
            return false;
        }

        var go:GameObject = this.getHit(pnt.x, pnt.y);
        if (go != null) {
            var player:Player = map_.player_;
            var goIsEnemy:Boolean = go.props_.isEnemy_;
            var goIsPlayer:Boolean = go.props_.isPlayer_;
            var goHit:Boolean = player != null &&
                    !player.isPaused() &&
                    !player.isHidden() &&
                    (this.damagesPlayers_ || goIsEnemy && this.ownerId_ == player.objectId_ || this.damagesFromPlayer_ || goIsPlayer && this.ownerId_ == player.objectId_);

            if (goHit) {
                var dmg:int = GameObject.damageWithDefense(this.damage_, go.defense_, this.projProps_.armorPiercing_, go.condition_);
                var dmg2:int = GameObject.damageWithDefense(this.damage_, go.defense_, true, go.condition_);
                var killed:Boolean = false;
                if (go.hp_ <= dmg) {
                    killed = true;
                    if (goIsEnemy) {
                        doneAction(map_.gs_, Tutorial.KILL_ACTION);
                    }
                }
                if(go.pvp_ && player.pvp_){
                    map_.gs_.gsc_.playerHit(this.bulletId_, go.objectId_);
                    if(go is Player && (go as Player).protectionPoints_ > 0){
                        go.damage(this.containerType_, dmg2, this.projProps_.effects_, false, this);
                    }else{
                        go.damage(this.containerType_, dmg, this.projProps_.effects_, false, this);
                    }
                }
                if (go == player) {
                    map_.gs_.gsc_.playerHit(this.bulletId_, this.ownerId_);
                    if(go is Player && (go as Player).protectionPoints_ > 0){
                        go.damage(this.containerType_, dmg2, this.projProps_.effects_, false, this);
                    }else{
                        go.damage(this.containerType_, dmg, this.projProps_.effects_, false, this);
                    }

                }
                else {
                    if (goIsEnemy) {
                        map_.gs_.gsc_.enemyHit(currentTime, this.bulletId_, go.objectId_, killed);
                        if(player.isCrit_ == false) {
                            go.damage(this.containerType_, dmg, this.projProps_.effects_, killed, this);
                        }else{
                            go.criticalDamage(this.containerType_, dmg, this.projProps_.effects_, killed, this);
                        }
                    }
                    else {
                        if (!this.projProps_.multiHit_) {
                            map_.gs_.gsc_.otherHit(currentTime, this.bulletId_, this.ownerId_, go.objectId_);
                        }
                    }
                }
            }

            if (this.projProps_.multiHit_) {
                this.multiHitDict_[go] = true;
            }
            else {
                return false;
            }
        }
        return true;
    }

    public function getHit(x:Number, y:Number):GameObject {
        var currentDSqr:Number = Number.MAX_VALUE;
        var hit:GameObject;
        for each (var go:GameObject in map_.visibleHit_) {
            var dx:Number;
            var dy:Number;
            if ((dx = Math.abs(go.x_ - x)) > go.radius_ ||
                    (dy = Math.abs(go.y_ - y)) > go.radius_ ||
                    go.dead_ ||
                    go.condition_[ConditionEffect.CE_FIRST_BATCH] & ConditionEffect.PROJ_NOHIT_BITMASK ||
                    map_.goDict_[go.objectId_] == null) {
                continue;
            }
            if ((this.damagesEnemies_ && go.objectId_ != this.ownerId_ && ((go.pvp_ && go.props_.isPlayer_) || go.props_.isEnemy_)) || (this.damagesPlayers_ && go.props_.isPlayer_)) {
                if (!projProps_.multiHit_ || multiHitDict_[go] == null) {
                    if (go == map_.player_ || go.props_.isPlayer_) {
                        var _owner:GameObject = map_.goDict_[this.ownerId_];
                        if (_owner is Player) {
                            if (_owner != null) {
                                if (go.canBeHitBy(_owner)) {
                                    return (go);
                                } else {
                                    continue;
                                }
                            } else {
                                return (go);
                            }
                        }
                    }

                    var dSqr:Number = dx * dx + dy * dy;
                    if (dSqr < currentDSqr) {
                        currentDSqr = dSqr;
                        hit = go;
                    }
                }

            }
        }
        return hit;
    }

    override public function draw(gfxVec:Vector.<IGraphicsData>, camera:Camera, time:int):void {
        var trailLifetime:int;
        var i:int;
        if (!Parameters.drawProj_) {
            return;
        }

        var tex:BitmapData = this.texture_;

        if (Parameters.data_.outlineProj) {
            var size:Number = (this.projProps_.size_ >= 0 ? this.projProps_.size_
                : ObjectLibrary.getSizeFromType(this.containerType_)) * 8;
            tex = TextureRedrawer.redraw(tex, size, true, 0, true, 5, 18 * (size / 800));
		}

        var rotation:Number = (this.props_.rotation_ == 0 ? 0 : time / this.props_.rotation_);
        this.staticVector3D_.x = x_;
        this.staticVector3D_.y = y_;
        this.staticVector3D_.z = z_;
        this.p_.draw(gfxVec, this.staticVector3D_,
                this.angle_ - camera.angleRad_ + this.props_.angleCorrection_ + rotation,
                camera.wToS_, camera, tex);

        if (!Parameters.data_.noParticlesMaster && this.projProps_.particleTrail_) {
            trailLifetime = (this.projProps_.particleTrailLifetimeMS != -1 ? this.projProps_.particleTrailLifetimeMS : 600);
            i = 0;
            for (; i < 3; i++) {
                if (map_ != null && map_.player_.objectId_ != this.ownerId_) {
                    if (this.projProps_.particleTrailIntensity_ == -1
                            && Math.random() * 100 > this.projProps_.particleTrailIntensity_) continue;
                }
                map_.addObj(new SparkParticle(100, this.projProps_.particleTrailColor_,
                        trailLifetime, 0.5, RandomUtil.plusMinus(3), RandomUtil.plusMinus(3)), x_, y_);
            }
        }
    }

    override public function drawShadow(_arg1:Vector.<IGraphicsData>, _arg2:Camera, _arg3:int):void {
        if (!Parameters.drawProj_) {
            return;
        }
        var _local4:Number = (this.props_.shadowSize_ / 400);
        var _local5:Number = (30 * _local4);
        var _local6:Number = (15 * _local4);
        this.shadowGradientFill_.matrix.createGradientBox((_local5 * 2), (_local6 * 2), 0, (posS_[0] - _local5), (posS_[1] - _local6));
        _arg1.push(this.shadowGradientFill_);
        this.shadowPath_.data.length = 0;
        Vector.<Number>(this.shadowPath_.data).push((posS_[0] - _local5), (posS_[1] - _local6), (posS_[0] + _local5), (posS_[1] - _local6), (posS_[0] + _local5), (posS_[1] + _local6), (posS_[0] - _local5), (posS_[1] + _local6));
        _arg1.push(this.shadowPath_);
        _arg1.push(GraphicsUtil.END_FILL);
    }


}
}