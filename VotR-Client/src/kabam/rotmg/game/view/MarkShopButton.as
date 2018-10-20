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
import kabam.rotmg.markPurchaser.MarkOffersModal;
import kabam.rotmg.tooltips.HoverTooltipDelegate;
import kabam.rotmg.tooltips.TooltipAble;
import kabam.rotmg.ui.UIUtils;

public class MarkShopButton extends Sprite implements TooltipAble {
    public var hoverTooltipDelegate:HoverTooltipDelegate;
    private var bitmap:Bitmap;
    private var background:Sprite;
    private var bitmapData:BitmapData;
    private var tooltip:TextToolTip;
    public var gs_:AGameSprite;

    public function MarkShopButton() {
        this.hoverTooltipDelegate = new HoverTooltipDelegate();
        this.tooltip = new TextToolTip(0x363636, 0x000000, null, "Click here to open the Mark Shop window.", 200);
        super();
        mouseChildren = false;
        this.bitmapData = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("d3LofiObjEmbed", 880), 56, true, 0);
        this.background = UIUtils.makeHUDBackground(28, 27);
        this.bitmap = new Bitmap(this.bitmapData);
        this.bitmap.x = -9;
        this.bitmap.y = -11;
        this.hoverTooltipDelegate.setDisplayObject(this);
        this.hoverTooltipDelegate.tooltip = this.tooltip;
        this.drawAsOpen();
        addEventListener(MouseEvent.CLICK, onClick);
    }

    public function setShowToolTipSignal(signal:ShowTooltipSignal):void {
        this.hoverTooltipDelegate.setShowToolTipSignal(signal);
    }

    public function getShowToolTip():ShowTooltipSignal {
        return (this.hoverTooltipDelegate.getShowToolTip());
    }

    public function setHideToolTipsSignal(signal:HideTooltipsSignal):void {
        this.hoverTooltipDelegate.setHideToolTipsSignal(signal);
    }

    public function getHideToolTips():HideTooltipsSignal {
        return (this.hoverTooltipDelegate.getHideToolTips());
    }

    public function drawAsOpen():void {
        addChild(this.background);
        addChild(this.bitmap);
    }

    public static function onClick(e:MouseEvent):void {
       var openDialog:OpenDialogSignal = StaticInjectorContext.getInjector().getInstance(OpenDialogSignal);
       openDialog.dispatch(new MarkOffersModal());
       SoundEffectLibrary.play("button_click");
    }

    public function drawAsClosed():void {
        if (this.background && this.background.parent == this) {
            removeChild(this.background);
        }

        if (this.bitmap && this.bitmap.parent == this) {
            removeChild(this.bitmap);
        }
    }
}
}
