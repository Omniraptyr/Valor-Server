package com.company.assembleegameclient.account.ui {
import com.company.assembleegameclient.game.AGameSprite;
import com.company.assembleegameclient.objects.ObjectLibrary;
import com.company.util.BitmapUtil;

import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.events.Event;
import flash.events.MouseEvent;

import org.osflash.signals.Signal;

public class ItemResultBox extends Frame2 {

    public const cancel:Signal = new Signal();
    public const showInventory:Signal = new Signal();

    public var gameSprite:AGameSprite;
    private var itemType_:int;
    private var itemBitmap_:Bitmap;

    public function ItemResultBox(_arg_1:AGameSprite, _arg_2:int) {
        this.gameSprite = _arg_1;
        this.itemType_ = _arg_2;
        super("You unboxed a " + ObjectLibrary.typeToDisplayId_[this.itemType_], "", 288);
        XButton.addEventListener(MouseEvent.CLICK, this.onClose);
        var _local3:BitmapData = ObjectLibrary.getRedrawnTextureFromType(this.itemType_, 60, true, true, 5);
        _local3 = BitmapUtil.cropToBitmapData(_local3, 4, 4, (_local3.width - 8), (_local3.height - 8));
        this.itemBitmap_ = new Bitmap(_local3);
        addEventListener(Event.ENTER_FRAME, showInventory_);
        this.itemBitmap_.scaleX = this.itemBitmap_.scaleY = 3;
        this.addDisplayObject(this.itemBitmap_, this.w_ / 2 - this.itemBitmap_.width / 2 - 10);
    }

    private function onClose(e:Event) : void {
        stage.focus = null;
        dispatchEvent(new Event(Event.COMPLETE));
    }

    private function showInventory_(event:Event):void {
        this.showInventory.dispatch();
    }

}
}//package com.company.assembleegameclient.account.ui
