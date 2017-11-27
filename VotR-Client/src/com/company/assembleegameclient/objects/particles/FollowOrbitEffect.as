
package com.company.assembleegameclient.objects.particles {

import com.company.assembleegameclient.objects.GameObject;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.util.AssetLibrary;

import flash.display.BitmapData;

public class FollowOrbitEffect extends ParticleEffect {

    //color = particle color
    //speed = speed of orbit
    //life = life of fading bitmaps
    //lifeVariance = life variance of fading bitmaps
    //lifeB = life of particles
    //lifeBVariance = life variance of particles
    //size = size of bitmap + fading bitmaps
    //sizeB = size of particles
    //radius = radius of orbit
    //followRate = general speed multiplier for following

    public function FollowOrbitEffect(_arg1:EffectProperties, _arg2:GameObject) {
      this._origin = _arg2;
      this.xmlDat = _arg1;
      this.angle_ = this.xmlDat.angleOffset;
      if (this.xmlDat.bitmapFile) {
        this.bitmapData = AssetLibrary.getImageFromSet(this.xmlDat.bitmapFile, this.xmlDat.bitmapIndex);
        this.bitmapData = TextureRedrawer.redraw(this.bitmapData, this.xmlDat.size, true, 0);
      } else {
        this.bitmapData = TextureRedrawer.redrawSolidSquare(this.xmlDat.color, this.xmlDat.size);
      }
    }
    private var mainParticle:OrbitObject;
    private var _origin:GameObject;
    private var angle_:Number = 0;
    private var _ge:Number = 0;
    private var xmlDat:EffectProperties;
    private var bitmapData:BitmapData;

    override public function update(_arg1:int, _arg2:int):Boolean {
      var _local3:Number = (_arg1 / 1000);
      var _local4:Number = (_arg2 / 1000);
      if (this._origin.map_ == null) {
        return (false);
      }
      x_ = this._origin.x_;
      y_ = this._origin.y_;
      z_ = (this._origin.z_ + this.xmlDat.zOffset);
      this._ge = (this._ge + _local4);
      if(this.mainParticle == null) {
        this.mainParticle = new OrbitObject(this.bitmapData);
        this.mainParticle.lX_ = 0;
        this.mainParticle.lY_ = 0;
        map_.addObj(this.mainParticle, x_, y_);
        this.mainParticle.z_ = this.xmlDat.zOffset;
      }
      this.angle_ += this.xmlDat.speed * _local4;
      this.angle_ = this.angle_ % 360;
      this.mainParticle.lX_ = this.xmlDat.radius * Math.cos(this.angle_ * Math.PI / 180);
      this.mainParticle.lY_ = -this.xmlDat.radius * Math.sin(this.angle_ * Math.PI / 180);
      this.mainParticle.x_ = this.x_ + this.mainParticle.lX_;
      this.mainParticle.y_ = this.y_ + this.mainParticle.lY_;
      this.mainParticle.square_ = map_.getSquare(this.mainParticle.x_, this.mainParticle.y_);
      return (true);
    }

    override public function removeFromMap():void {
      if(this.mainParticle != null) {
        map_.removeObj(this.mainParticle.objectId_);
      }
      super.removeFromMap();
    }

  }
}//package _0K_m

