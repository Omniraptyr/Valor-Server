
package com.company.assembleegameclient.objects.particles {
import com.company.assembleegameclient.map.Camera;
import com.company.assembleegameclient.objects.BasicObject;
import com.company.util.CachingColorTransformer;
import com.company.util.GraphicsUtil;

import flash.display.BitmapData;
import flash.display.GraphicsBitmapFill;
import flash.display.GraphicsPath;
import flash.display.IGraphicsData;
import flash.geom.Matrix;

public class OrbitObject extends BasicObject {

    public function OrbitObject(_arg1:BitmapData) {
        this.vS_ = new Vector.<Number>(8);
        this._01i = new Matrix();
        this.path_ = new GraphicsPath(GraphicsUtil.QUAD_COMMANDS, null);
        this.bitmapFill_ = new GraphicsBitmapFill(null, null, false, false);
        super();
        this.bitmapFill_.bitmapData = _arg1;
        this.bitmapData_ = _arg1;
        objectId_ = getNextFakeObjectId();
    }
    public var _G_n:Number = 0;
    public var _G_m:Number = 0;
    public var _null_:Number;
    public var _0K_5:Number;
    public var _0A_7:Number;
    public var _size:Number;
    public var lX_:Number = 0;
    public var lY_:Number = 0;
    public var pOwnerX_:Number = 0;
    public var pOwnerY_:Number = 0;
    public var cloudInitLife_:Number = 0;
    public var fadeInitLife_:Number = 0;
    public var fadedIn_:Boolean = false;
    public var bitmapData_:BitmapData;
    public var bitmapIndex_:Number = -1;
    public var alpha_:Number = 1;
    protected var vS_:Vector.<Number>;
    protected var _01i:Matrix;
    protected var path_:GraphicsPath;
    protected var bitmapFill_:GraphicsBitmapFill;

    override public function draw(_arg1:Vector.<IGraphicsData>, _arg2:Camera, _arg3:int):void {
        this.bitmapFill_.bitmapData = this.bitmapData_;
        this.bitmapFill_.bitmapData = CachingColorTransformer.alphaBitmapData(this.bitmapData_, this.alpha_);
        var _local4:Number = (this.bitmapFill_.bitmapData.width / 2);
        var _local5:Number = (this.bitmapFill_.bitmapData.height / 2);
        this.vS_[6] = (this.vS_[0] = (posS_[3] - _local4));
        this.vS_[3] = (this.vS_[1] = (posS_[4] - _local5));
        this.vS_[4] = (this.vS_[2] = (posS_[3] + _local4));
        this.vS_[7] = (this.vS_[5] = (posS_[4] + _local5));
        this.path_.data = this.vS_;
        this._01i.identity();
        this._01i.translate(this.vS_[0], this.vS_[1]);
        this.bitmapFill_.matrix = this._01i;
        _arg1.push(this.bitmapFill_);
        _arg1.push(this.path_);
        _arg1.push(GraphicsUtil.END_FILL);
    }

    override public function removeFromMap():void {
        map_ = null;
        square_ = null;
    }

    public function initialize(_arg1:Number, _arg2:Number, _arg3:Number, _arg4:Number, _arg5:Number):void {
        this._G_n = _arg1;
        this._G_m = _arg1;
        this._null_ = _arg2;
        this._0K_5 = _arg3;
        this._0A_7 = _arg4;
        z_ = _arg5;
    }

}
}//package _0K_m

