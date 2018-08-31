package kabam.rotmg.game.view {
import com.company.assembleegameclient.game.GameSprite;
import com.company.assembleegameclient.parameters.Parameters;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.util.AssetLibrary;

import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.display.Sprite;
import flash.events.MouseEvent;
import flash.filters.DropShadowFilter;

import kabam.rotmg.assets.services.IconFactory;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;
import kabam.rotmg.ui.view.SignalWaiter;

import org.osflash.signals.Signal;

public class LootboxesDisplay extends Sprite {

    private static const FONT_SIZE:int = 18;
    public static const IMAGE_NAME:String = "legendaries8x8Embed";
    public static const IMAGE_ID:int = 16;
    public static const waiter:SignalWaiter = new SignalWaiter();

    private var lootbox1Text:TextFieldDisplayConcrete;
    private var lootbox2Text:TextFieldDisplayConcrete;
    private var lootbox3Text:TextFieldDisplayConcrete;
    private var lootbox4Text:TextFieldDisplayConcrete;
    private var lootbox1Icon:Bitmap;
    private var lootbox2Icon:Bitmap;
    private var lootbox3Icon:Bitmap;
    private var lootbox4Icon:Bitmap;
    private var lootBox1_:int = -1;
    private var lootBox2_:int = -1;
    private var lootBox3_:int = -1;
    private var lootBox4_:int = -1;
    private var gs:GameSprite;
    public var openAccountDialog:Signal;

    public function LootboxesDisplay(_arg_1:GameSprite = null) {
        this.openAccountDialog = new Signal();
        super();
        this.gs = _arg_1;
        this.lootbox1Text = this.makeTextField();
        waiter.push(this.lootbox1Text.textChanged);
        addChild(this.lootbox1Text);
        var _local_5:BitmapData = AssetLibrary.getImageFromSet(IMAGE_NAME, IMAGE_ID);
        _local_5 = TextureRedrawer.redraw(_local_5, 40, true, 0);
        this.lootbox1Icon = new Bitmap(_local_5);
        addChild(this.lootbox1Icon);
        this.lootbox3Text = this.makeTextField();
        waiter.push(this.lootbox3Text.textChanged);
        addChild(this.lootbox3Text);
        this.lootbox3Icon = new Bitmap(IconFactory.makeLootbox3());
        addChild(this.lootbox3Icon);
        this.lootbox4Text = this.makeTextField();
        waiter.push(this.lootbox4Text.textChanged);
        addChild(this.lootbox4Text);
        this.lootbox4Icon = new Bitmap(IconFactory.makeLootbox4());
        addChild(this.lootbox4Icon);
            this.lootbox2Text = this.makeTextField();
            waiter.push(this.lootbox2Text.textChanged);
            addChild(this.lootbox2Text);
            this.lootbox2Icon = new Bitmap(IconFactory.makeLootbox2());
            addChild(this.lootbox2Icon);
        this.draw(0, 0, 0, 0);
        mouseEnabled = true;
        doubleClickEnabled = true;
        addEventListener(MouseEvent.DOUBLE_CLICK, this.onDoubleClick, false, 0, true);
        waiter.complete.add(this.onAlignHorizontal);
    }

    private function onAlignHorizontal():void {

            this.lootbox1Icon.x = -(this.lootbox1Icon.width);
            this.lootbox1Text.x = ((this.lootbox1Icon.x - this.lootbox1Text.width) + 8);
            this.lootbox1Text.y = ((this.lootbox1Icon.y + (this.lootbox1Icon.height / 2)) - (this.lootbox1Text.height / 2));

            this.lootbox3Icon.x = (this.lootbox1Icon.x + 10);
            this.lootbox3Icon.y = (this.lootbox1Icon.y + 30);
            this.lootbox3Text.x = ((this.lootbox3Icon.x - this.lootbox3Text.width) - 2);
            this.lootbox3Text.y = ((this.lootbox3Icon.y + (this.lootbox3Icon.height / 2)) - (this.lootbox3Text.height / 2));

            this.lootbox2Icon.x = this.lootbox2Text.x + 10;
            this.lootbox2Icon.y = this.lootbox2Text.y + 10;
            this.lootbox2Text.x = this.lootbox4Text.x - 5;
            this.lootbox2Text.y = this.lootbox4Text.y + 10;


            this.lootbox4Icon.x = (this.lootbox3Icon.x + 40);
            this.lootbox4Icon.y = (this.lootbox3Icon.y);
            this.lootbox4Text.x = ((this.lootbox4Icon.x - this.lootbox4Text.width) - 2);
            this.lootbox4Text.y = ((this.lootbox4Icon.y + (this.lootbox4Icon.height / 2)) - (this.lootbox4Text.height / 2));

    }

    private function onDoubleClick(_arg_1:MouseEvent):void {
        if (((((!(this.gs)) || (this.gs.evalIsNotInCombatMapArea()))) || ((Parameters.data_.clickForGold == true)))) {
            this.openAccountDialog.dispatch();
        }
    }

    public function makeTextField(_arg_1:uint = 0xFFFFFF):TextFieldDisplayConcrete {
        var _local_2:TextFieldDisplayConcrete = new TextFieldDisplayConcrete().setSize(FONT_SIZE).setColor(_arg_1).setTextHeight(16);
        _local_2.filters = [new DropShadowFilter(0, 0, 0, 1, 4, 4, 2)];
        return (_local_2);
    }

    public function draw(_arg_1:int, _arg_2:int, _arg_3:int, _arg_4:int):void {
        this.lootBox1_ = _arg_1;
        this.lootBox3_ = _arg_3;
        this.lootBox4_ = _arg_4;
        this.lootBox2_ = _arg_2;
        this.lootbox3Text.setStringBuilder(new StaticStringBuilder(this.lootBox3_.toString()));
        this.lootbox2Text.setStringBuilder(new StaticStringBuilder(this.lootBox2_.toString()));
        this.lootbox4Text.setStringBuilder(new StaticStringBuilder(this.lootBox4_.toString()));
        this.lootbox1Text.setStringBuilder(new StaticStringBuilder(this.lootBox1_.toString()));
        if (waiter.isEmpty()) {
            this.onAlignHorizontal();
        }
    }



}
}//package kabam.rotmg.game.view
