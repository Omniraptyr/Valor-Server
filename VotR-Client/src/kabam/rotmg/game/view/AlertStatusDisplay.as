package kabam.rotmg.game.view {
import com.company.assembleegameclient.ui.tooltip.TextToolTip;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.util.AssetLibrary;

import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.display.Sprite;
import flash.filters.DropShadowFilter;
import flash.geom.Rectangle;

import kabam.rotmg.core.signals.HideTooltipsSignal;
import kabam.rotmg.core.signals.ShowTooltipSignal;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;
import kabam.rotmg.tooltips.HoverTooltipDelegate;
import kabam.rotmg.tooltips.TooltipAble;
import kabam.rotmg.ui.UIUtils;

public class AlertStatusDisplay extends Sprite implements TooltipAble {
    public static const IMAGE_NAME:String = "legendaries8x8Embed";
    public static const IMAGE_ID:int = 208;
    private static const ALERT_TEXT:String = "This launches an alert if you have any. Dying in an alert will cause you to lose 10% of your gold, but your character won't be lost.";

    public var hoverTooltipDelegate:HoverTooltipDelegate;
    private var bitmap:Bitmap;
    private var background:Sprite;
    private var bitmapData:BitmapData;
    private var text:TextFieldDisplayConcrete;
    private var tooltip:TextToolTip;
    private var alertNum:int = 0;

    public function AlertStatusDisplay() {
        this.hoverTooltipDelegate = new HoverTooltipDelegate();
        this.tooltip = new TextToolTip(0x363636, 0x9B9B9B, null, ALERT_TEXT, 200);
        super();
        mouseChildren = false;

        this.bitmapData = TextureRedrawer.redraw(AssetLibrary.getImageFromSet(IMAGE_NAME, IMAGE_ID), 40, true, 0);
        this.background = UIUtils.makeStaticHUDBackground();
        this.bitmap = new Bitmap(this.bitmapData);
        this.bitmap.x = -5;
        this.bitmap.y = -8;
        this.text = new TextFieldDisplayConcrete().setSize(16).setColor(0xFFFFFF);
        this.text.setStringBuilder(new StaticStringBuilder("Alerts"));
        this.text.filters = [new DropShadowFilter(0, 0, 0, 1, 4, 4, 2)];
        this.text.setVerticalAlign(TextFieldDisplayConcrete.BOTTOM);
        this.hoverTooltipDelegate.setDisplayObject(this);
        this.hoverTooltipDelegate.tooltip = this.tooltip;
        this.drawAsOpen();

        var bounds:Rectangle = this.bitmap.getBounds(this);
        this.text.x = bounds.right - 10;
        this.text.y = bounds.bottom - 12;
    }

    internal function updateAlertNum(alertNum:int) : void {
        if (this.alertNum == alertNum) return;

        this.tooltip.setText(new StaticStringBuilder(ALERT_TEXT + "\n\nCurrent amount of alerts: " + (this.alertNum = alertNum)));
    }

    public function setShowToolTipSignal(showTooltip:ShowTooltipSignal):void {
        this.hoverTooltipDelegate.setShowToolTipSignal(showTooltip);
    }

    public function getShowToolTip():ShowTooltipSignal {
        return (this.hoverTooltipDelegate.getShowToolTip());
    }

    public function setHideToolTipsSignal(hideTooltips:HideTooltipsSignal):void {
        this.hoverTooltipDelegate.setHideToolTipsSignal(hideTooltips);
    }

    public function getHideToolTips():HideTooltipsSignal {
        return (this.hoverTooltipDelegate.getHideToolTips());
    }

    public function drawAsOpen():void {
        addChild(this.background);
        addChild(this.text);
        addChild(this.bitmap);
    }

    public function drawAsClosed():void {
        if (this.background && this.background.parent == this) {
            removeChild(this.background);
        }
        if (this.text && this.text.parent == this) {
            removeChild(this.text);
        }
        if (this.bitmap && this.bitmap.parent == this) {
            removeChild(this.bitmap);
        }
    }

}
}
