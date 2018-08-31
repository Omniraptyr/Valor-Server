package kabam.rotmg.game.view {
import com.company.assembleegameclient.game.AGameSprite;
import com.company.assembleegameclient.objects.Player;
import com.company.assembleegameclient.ui.tooltip.TextToolTip;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.util.AssetLibrary;

import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.display.Sprite;

import kabam.rotmg.core.signals.HideTooltipsSignal;
import kabam.rotmg.core.signals.ShowTooltipSignal;
import kabam.rotmg.tooltips.HoverTooltipDelegate;
import kabam.rotmg.tooltips.TooltipAble;
import kabam.rotmg.ui.UIUtils;

public class SorDisplay extends Sprite implements TooltipAble {

    public static const IMAGE_NAME:String = "d3LofiObjEmbed";
    public static const IMAGE_ID:int = 438;

    public var hoverTooltipDelegate:HoverTooltipDelegate;
    private var bitmap:Bitmap;
    private var background:Sprite;
    private var sorTexture:BitmapData;
    private var tooltip:TextToolTip;
    public var gs_:AGameSprite;
    private var player:Player;

    public function SorDisplay(_arg1:Player) {
        this.player = _arg1;
        this.hoverTooltipDelegate = new HoverTooltipDelegate();
        this.sorTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet(IMAGE_NAME, IMAGE_ID), 64, true, 0);
        this.tooltip = new TextToolTip(0x363636, 0xFFFFFF, "Sor Fragments", "" + player.sorStorage_ + "/" + "30", 200);
        super();
        mouseChildren = false;
        this.background = UIUtils.makeHUDBackground(32, 32);
        this.bitmap = new Bitmap(this.sorTexture);
        this.bitmap.x = -8;
        this.bitmap.y = -8;
        this.hoverTooltipDelegate.setDisplayObject(this);
        this.hoverTooltipDelegate.tooltip = this.tooltip;
        this.drawAsOpen();
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

    public function drawAsClosed():void {
        if (((this.background) && ((this.background.parent == this)))) {
            removeChild(this.background);
        }
        if (((this.bitmap) && ((this.bitmap.parent == this)))) {
            removeChild(this.bitmap);
        }
    }


}
}