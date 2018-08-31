package kabam.rotmg.game.view {
import com.company.assembleegameclient.game.AGameSprite;
import com.company.assembleegameclient.sound.SoundEffectLibrary;
import com.company.assembleegameclient.ui.tooltip.TextToolTip;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.util.AssetLibrary;

import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.display.Sprite;
import flash.events.MouseEvent;

import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.core.signals.HideTooltipsSignal;
import kabam.rotmg.core.signals.ShowTooltipSignal;
import kabam.rotmg.dialogs.control.OpenDialogSignal;
import kabam.rotmg.lootBoxes.LootboxModal;
import kabam.rotmg.tooltips.HoverTooltipDelegate;
import kabam.rotmg.tooltips.TooltipAble;
import kabam.rotmg.ui.UIUtils;

public class LootboxModalButton extends Sprite implements TooltipAble {

    public static const IMAGE_NAME:String = "lofiCharBig";
    public static const IMAGE_ID:int = 101;

    public var hoverTooltipDelegate:HoverTooltipDelegate;
    private var bitmap:Bitmap;
    private var background:Sprite;
    private var lootBoxTexture:BitmapData;
    private var tooltip:TextToolTip;
    public var gs_:AGameSprite;

    public function LootboxModalButton() {
        this.hoverTooltipDelegate = new HoverTooltipDelegate();
        this.tooltip = new TextToolTip(0x363636, 0x000000, null, "Unbox the latest Lootboxes you've earned.", 200);
        super();
        mouseChildren = false;
        this.lootBoxTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet(IMAGE_NAME, IMAGE_ID), 28, true, 0);
        this.background = UIUtils.makeHUDBackground(28, 27);
        this.bitmap = new Bitmap(this.lootBoxTexture);
        this.bitmap.x = -9;
        this.bitmap.y = -9;
        this.hoverTooltipDelegate.setDisplayObject(this);
        this.hoverTooltipDelegate.tooltip = this.tooltip;
        this.drawAsOpen();
        addEventListener(MouseEvent.CLICK, this.onClick);
    }

    public function setShowToolTipSignal(_arg_1:ShowTooltipSignal):void {
        this.hoverTooltipDelegate.setShowToolTipSignal(_arg_1);
    }

    public function getShowToolTip():ShowTooltipSignal {
        return (this.hoverTooltipDelegate.getShowToolTip());
    }

    public function setHideToolTipsSignal(_arg_1:HideTooltipsSignal):void {
        this.hoverTooltipDelegate.setHideToolTipsSignal(_arg_1);
    }

    public function getHideToolTips():HideTooltipsSignal {
        return (this.hoverTooltipDelegate.getHideToolTips());
    }

    public function drawAsOpen():void {
        addChild(this.background);
        addChild(this.bitmap);
    }

    public function onClick(_arg_1:MouseEvent):void {
       var _local_2:OpenDialogSignal = StaticInjectorContext.getInjector().getInstance(OpenDialogSignal);
       _local_2.dispatch(new LootboxModal());
       SoundEffectLibrary.play("button_click");
    }

    public function drawAsClosed():void {
        if (((this.background) && ((this.background.parent == this)))) {
            removeChild(this.background);
        }
        if (((this.bitmap) && ((this.bitmap.parent == this)))) {
            removeChild(this.bitmap);
        }
    }


}
}//package kabam.rotmg.game.view
