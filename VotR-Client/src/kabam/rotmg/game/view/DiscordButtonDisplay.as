package kabam.rotmg.game.view {
import com.company.assembleegameclient.game.GameSprite;
import com.company.assembleegameclient.ui.tooltip.TextToolTip;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.util.AssetLibrary;

import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.display.Sprite;
import flash.events.MouseEvent;
import flash.filters.DropShadowFilter;
import flash.geom.Rectangle;
import flash.net.URLRequest;
import flash.net.navigateToURL;

import kabam.rotmg.core.signals.HideTooltipsSignal;
import kabam.rotmg.core.signals.ShowTooltipSignal;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;
import kabam.rotmg.tooltips.HoverTooltipDelegate;
import kabam.rotmg.tooltips.TooltipAble;
import kabam.rotmg.ui.UIUtils;

public class DiscordButtonDisplay extends Sprite implements TooltipAble {
      public var hoverTooltipDelegate:HoverTooltipDelegate;
      private var icon:Bitmap;
      private var background:Sprite;
      private var iconBitmapData:BitmapData;
      private var text:TextFieldDisplayConcrete;
      private var tooltip:TextToolTip;
      private var gs:GameSprite;
      
      public function DiscordButtonDisplay(gs:GameSprite) {
         this.gs = gs;
         this.hoverTooltipDelegate = new HoverTooltipDelegate();
         this.tooltip = new TextToolTip(3552822, 10197915, null, "Click here to join our Discord server.", 160);
         super();
         mouseChildren = false;

         this.iconBitmapData = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("lofiInterfaceBig", 31), 20, true, 0);
         this.background = UIUtils.makeStaticHUDBackground();
         this.icon = new Bitmap(this.iconBitmapData);
         this.icon.x = -5;
         this.icon.y = -8;
         this.text = new TextFieldDisplayConcrete().setSize(16).setColor(16777215);
         this.text.setStringBuilder(new LineBuilder().setParams("Discord"));
         this.text.filters = [new DropShadowFilter(0, 0, 0, 1, 4, 4, 2)];
         this.text.setVerticalAlign(TextFieldDisplayConcrete.BOTTOM);
         this.hoverTooltipDelegate.setDisplayObject(this);
         this.hoverTooltipDelegate.tooltip = this.tooltip;
         this.addChilds();

         var bounds:Rectangle = this.icon.getBounds(this);
         this.text.x = bounds.right - 10;
         this.text.y = bounds.bottom - 12;
         addEventListener(MouseEvent.CLICK, onClick);
      }
      
      public function setShowToolTipSignal(signal:ShowTooltipSignal) : void {
         this.hoverTooltipDelegate.setShowToolTipSignal(signal);
      }
      
      public function getShowToolTip() : ShowTooltipSignal {
         return this.hoverTooltipDelegate.getShowToolTip();
      }

      public function setHideToolTipsSignal(signal:HideTooltipsSignal) : void {
         this.hoverTooltipDelegate.setHideToolTipsSignal(signal);
      }
      
      public function getHideToolTips() : HideTooltipsSignal {
         return this.hoverTooltipDelegate.getHideToolTips();
      }
      
      public function addChilds() : void {
         addChild(this.background);
         addChild(this.text);
         addChild(this.icon);
      }
      
      private static function onClick(e:MouseEvent) : void {
          var request:URLRequest = new URLRequest("http://discord.gg/5r5c2Nm");
          navigateToURL(request, "_blank");
      }
   }
}
