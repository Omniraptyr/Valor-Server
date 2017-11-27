/**
 * Created by Roxy on 12/31/2015.
 */
package com.company.assembleegameclient.objects.particles
{
import com.company.assembleegameclient.objects.BasicObject;
import com.company.assembleegameclient.objects.GameObject;

public class QuadSpaceConcentrate extends ParticleEffect
    {
        private var squareArea:Number;
        private var intensity:Number;
        private var host:GameObject;
        private var properties:EffectProperties;
        private var time:Number;

        private var TLParticle:BasicObject;
        private var TRParticle:BasicObject;
        private var BRParticle:BasicObject;
        private var BLParticle:BasicObject;

        public function QuadSpaceConcentrate(_arg1:EffectProperties, _arg2:GameObject)
        {
            this.host = _arg2;
            this.properties = _arg1;
            this.squareArea = this.properties.size;
            this.intensity = this.properties.intensity;
        }

        override public function update(_arg1:int, _arg2:int):Boolean
        {
            var _local3:Number = (_arg1 / 1000);
            var _local4:Number = (_arg2 / 1000);
            if (this.host.map_ == null)
            {
                return (false);
            }
            x_ = this.host.x_;
            y_ = this.host.y_;
            z_ = this.host.z_;
            this.time = (this.time + _local4);
            /*
            if (this.particle_ == null) //Initialize the particle
            {
                this.particle_ = new OrbitObject(this.bitmapData);
                this.particle_.lX_ = 0;
                this.particle_.lY_ = 0;
                map_.addObj(this.particle_, x_, y_);
                this.particle_.z_ = this._properties.zOffset;
            }

            this.angle_ += this._properties.speed * _local4;
            this.angle_ = this.angle_ % 360;
            this.particle_.lX_ = this._properties.radius * Math.cos(this.angle_ * Math.PI / 180);
            this.particle_.lY_ = -this._properties.radius * Math.sin(this.angle_ * Math.PI / 180);
            this.particle_.x_ = this.x_ + this.particle_.lX_;
            this.particle_.y_ = this.y_ + this.particle_.lY_;
            this.particle_._0H_B_ = map_.getSquare(this.particle_.x_, this.particle_.y_);
             */
            return (true);
        }
    }
}
