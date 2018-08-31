/**
 * Created by club5_000 on 9/13/2014.
 */
package com.company.assembleegameclient.account.ui.Unboxing {

import com.company.assembleegameclient.account.ui.FrameuBox;
import com.company.assembleegameclient.game.AGameSprite;

import flash.events.Event;

import org.osflash.signals.Signal;

public class UnboxResultBox extends FrameuBox {


    public const cancel:Signal = new Signal();
    public const completed:Signal = new Signal();
    public const hideInventory:Signal = new Signal();

    public function UnboxResultBox(_gs:AGameSprite, _items:Vector.<int>) {
        super("Unboxing...", "", 300);
        this.gameSprite = _gs;
        this.unboxScroll_ = new UnboxScroll(444 + (Math.random() * 8), _items);
        this.unboxScroll_.x = (this.w_ / 2) - (UnboxScroll.WIDTH / 2) - 4;
        this.unboxScroll_.y = this.h_ - 66;
        addChild(this.unboxScroll_);
        this.offsetH(UnboxScroll.HEIGHT);
        addEventListener(Event.ENTER_FRAME, hideInventory_);
        this.unboxScroll_.addEventListener(Event.COMPLETE, onComplete);
    }
    public var gameSprite:AGameSprite;
    public var unboxScroll_:UnboxScroll;

    private function onComplete(event:Event):void {
        this.completed.dispatch();
    }

    private function hideInventory_(event:Event):void {
        this.hideInventory.dispatch();
    }

}
}
