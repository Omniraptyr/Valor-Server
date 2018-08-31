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

public class NodeDisplay3 extends Sprite implements TooltipAble {

    public static const IMAGE_NAME:String = "marks10x10";
    public static const IMAGE_ID:int = 15;

    public var hoverTooltipDelegate:HoverTooltipDelegate;
    private var bitmap:Bitmap;
    private var background:Sprite;
    private var nodeTexture:BitmapData;
    private var tooltip:TextToolTip;
    public var gs_:AGameSprite;
    private var player:Player;

    public function NodeDisplay3(_arg1:Player) {
        this.player = _arg1;
        this.hoverTooltipDelegate = new HoverTooltipDelegate();
        super();
        mouseChildren = false;
        if(player.node3_ == 0){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet(IMAGE_NAME, IMAGE_ID), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Unknown", "No node activated.", 200);
        }
        if(player.node3_== 1){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 0), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Fortitude", "Raises your OVERALL defense by 5%.", 200);
        }
        if(player.node3_== 2){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 1), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Recovery", "Raises your OVERALL vitality by 5%.", 200);
        }
        if(player.node3_== 3){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 2), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Blood", "Raises your OVERALL attack by 5%.", 200);
        }
        if(player.node3_== 4){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 3), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Intelligence", "Raises your OVERALL wisdom by 5%.", 200);
        }
        if(player.node3_== 5){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 4), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Faith", "Raises your OVERALL protection by 5%.", 200);
        }
        if(player.node3_== 6){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 5), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Agility", "Raises your OVERALL dexterity by 5%.", 200);
        }
        if(player.node3_== 7){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 6), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Swiftness", "Raises your OVERALL speed by 5%.", 200);
        }
        if(player.node3_== 8){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 7), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Vigor", "Raises your OVERALL might by 5%.", 200);
        }
        if(player.node3_== 9){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 8), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Skill", "Raises your OVERALL luck by 5%.", 200);
        }
        if(player.node3_== 10){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 9), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Power", "Raises the time it takes for your surge to deplete.", 200);
        }
        if(player.node3_== 11){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 10), 46, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Node of Aid", "Raises your OVERALL restoration by 5%.", 200);
        }
        this.background = UIUtils.makeHUDBackground(30, 30);
        this.bitmap = new Bitmap(this.nodeTexture);
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