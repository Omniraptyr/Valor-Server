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

public class MarkDisplay extends Sprite implements TooltipAble {

    public static const IMAGE_NAME:String = "marks10x10";
    public static const IMAGE_ID:int = 15;

    public var hoverTooltipDelegate:HoverTooltipDelegate;
    private var bitmap:Bitmap;
    private var background:Sprite;
    private var nodeTexture:BitmapData;
    private var tooltip:TextToolTip;
    public var gs_:AGameSprite;
    private var player:Player;

    public function MarkDisplay(_arg1:Player) {
        this.player = _arg1;
        this.hoverTooltipDelegate = new HoverTooltipDelegate();
        super();
        mouseChildren = false;
        if(player.mark_== 0){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet(IMAGE_NAME, IMAGE_ID), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Unknown", "No mark activated.", 200);
        }
        if(player.mark_== 1){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 16), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Sorcery", "Raises your OVERALL magic by 25%", 200);
        }
        if(player.mark_== 2){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 17), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Lifecharged", "Raises your OVERALL health by 25%", 200);
        }
        if(player.mark_== 3){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 18), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Rage", "Having surge increases your outputting damage.", 200);
        }
        if(player.mark_== 4){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 19), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Energy Eye", "You gain 2 extra surge on killing enemies and having at least 25 surge increases HP/MP regen.", 200);
        }
        if(player.mark_== 5){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 20), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Second Chance", "You have a 25% chance of getting resurrected.", 200);
        }
        if(player.mark_== 6){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 21), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Unity", "All stats except mana and health are raised by 5%.", 200);
        }
        if(player.mark_== 7){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 22), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Zol Beast", "When invisible you gain 20% extra dexterity, attack and luck.", 200);
        }
        if(player.mark_== 8){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 23), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Resolve", "If you have all legendaries equipped you gain a 10% stat boost to ALL stats.", 200);
        }
        if(player.mark_== 9){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 24), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Detonation", "Enemies that you kill have a chance to leave a bomb which shortly after detonates. The explosion deal 20000 damage.", 200);
        }
        if(player.mark_== 10){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 25), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Guardian", "If your surge is above 60 and you use an ability you summon a golem that does damage based on defense, vitality. Health is then added to it. The golem does not leave until you are below 60 surge.", 200);
        }
        if(player.mark_== 11){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 26), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Reaper", "Killing certain amounts of enemies grants bonus", 200);
        }
        if(player.mark_== 12){
            this.nodeTexture = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 27), 92, true, 0);
            this.tooltip = new TextToolTip(0x363636, 0x660000, "Zen", "Using abilities heal you 50 health and 10 mana.", 200);
        }
        this.background = UIUtils.makeHUDBackground(60, 60);
        this.bitmap = new Bitmap(this.nodeTexture);
        this.bitmap.x = -5;
        this.bitmap.y = -4;
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