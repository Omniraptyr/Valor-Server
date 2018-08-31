/**
 * Created by club5_000 on 1/21/2016.
 */
package com.company.assembleegameclient.account.ui.Unboxing {

import com.company.assembleegameclient.sound.SoundEffectLibrary;
import com.company.util.GraphicsUtil;

import flash.display.GraphicsPath;
import flash.display.GraphicsSolidFill;
import flash.display.IGraphicsData;
import flash.display.Sprite;
import flash.events.Event;

public class UnboxScroll extends Sprite {
    public static const WIDTH:int = 250;
    public static const HEIGHT:int = 85;

    public function UnboxScroll(_scrollSpeed:Number, _itemTypes:Vector.<int>) {
        this.scrollSpeed_ = _scrollSpeed;
        this.itemTypes_ = _itemTypes;
        addEventListener(Event.ADDED_TO_STAGE, onAddedToStage);
        addEventListener(Event.REMOVED_FROM_STAGE, onRemovedFromStage);
    }

    private var unboxSquareHolder_:Sprite;
    private var unboxSquares_:Vector.<UnboxSquare>;
    public var scrollSpeed_:Number;
    public var currentScrollSpeed_:Number = 1;
    public var currentBox_:int = 0;
    public var itemTypes_:Vector.<int>;

    private function draw():void {
        graphics.clear();
        graphics.beginGradientFill("linear", [0x000000, 0x1a1919, 0x272727], null, null, null, "pad", "rgb");
        graphics.drawRect(0, 0, WIDTH, HEIGHT);
        graphics.endFill();
        var _local1:GraphicsSolidFill = new GraphicsSolidFill(0xFFFFFF, 1);
        var _local2:GraphicsPath = new GraphicsPath(new Vector.<int>(), new Vector.<Number>());
        var _local3:Vector.<IGraphicsData> = new <IGraphicsData>[_local1, _local2, GraphicsUtil.END_FILL];
        GraphicsUtil.drawTriangle(WIDTH / 2 - 5, 0, 10, 5, false, _local2);
        graphics.drawGraphicsData(_local3);
        GraphicsUtil.clearPath(_local2);
        GraphicsUtil.drawTriangle(WIDTH / 2 - 5, HEIGHT - 5, 10, 5, true, _local2);
        graphics.drawGraphicsData(_local3);
    }

    private function initSquares():void {
        if(this.unboxSquareHolder_ != null) {
            removeChild(this.unboxSquareHolder_);
        }
        var _local2:Sprite = new Sprite();
        _local2.graphics.beginFill(0x000000, 1);
        _local2.graphics.drawRect(0, 0, WIDTH, HEIGHT);
        _local2.graphics.endFill();
        _local2.visible = false;
        addChild(_local2);
        this.unboxSquareHolder_ = new Sprite();
        this.unboxSquareHolder_.mask = _local2;
        this.unboxSquares_ = new Vector.<UnboxSquare>();
        for(var i:int=0;i<itemTypes_.length;i++) {
            var _local1:UnboxSquare = new UnboxSquare(this.itemTypes_[i], i);
            _local1.x = (i * (75 + 15)) - (75 / 2);
            _local1.y = 0;
            this.unboxSquares_.push(_local1);
            this.unboxSquareHolder_.addChild(_local1);
        }
        this.unboxSquareHolder_.x = WIDTH / 2;
        this.unboxSquareHolder_.y = 5;
        addChild(this.unboxSquareHolder_);

        this.currentScrollSpeed_ = 1;
        this.currentBox_ = 0;
    }

    private function onEnterFrame(event:Event):void {
        if(this.unboxSquareHolder_ == null) {
            return;
        }
        for each(var i:UnboxSquare in this.unboxSquares_) {
            i.x -= this.currentScrollSpeed_ * 18;
        }
        if(this.unboxSquares_[this.currentBox_ + 1].x <= 0) {
            this.currentBox_++;
            SoundEffectLibrary.play("inventory_move_item");
        }
        this.currentScrollSpeed_ -= (1 / this.scrollSpeed_);
        if(this.currentScrollSpeed_ <= 0) {
            this.currentScrollSpeed_ = 0;
            dispatchEvent(new Event(Event.COMPLETE));
            trace(this.currentBox_);
        }
    }

    private function onAddedToStage(event:Event):void {
        this.draw();
        this.initSquares();
        addEventListener(Event.ENTER_FRAME, onEnterFrame);
    }

    private function onRemovedFromStage(event:Event):void {
        removeEventListener(Event.ENTER_FRAME, onEnterFrame);
    }
}
}
