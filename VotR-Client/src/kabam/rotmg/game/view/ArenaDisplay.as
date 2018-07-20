package kabam.rotmg.game.view
{
import com.company.assembleegameclient.ui.tooltip.TextToolTip;
import com.company.util.AssetLibrary;

import flash.display.Sprite;

   import flash.display.Bitmap;
   import flash.display.BitmapData;
   import com.company.assembleegameclient.game.GameSprite;
   import flash.events.MouseEvent;
   import flash.geom.Rectangle;
   import com.company.assembleegameclient.util.TextureRedrawer;
   import flash.filters.DropShadowFilter;

import kabam.rotmg.core.signals.HideTooltipsSignal;

import kabam.rotmg.core.signals.ShowTooltipSignal;

import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;
import kabam.rotmg.tooltips.HoverTooltipDelegate;

import kabam.rotmg.tooltips.TooltipAble;
import kabam.rotmg.ui.UIUtils;

public class ArenaDisplay extends Sprite implements TooltipAble
   {
      
      public static const ICON_FILE:String = "lofiInterface2";
      
      public static const ICON_INDEX:int = 8;
       
      
      public var noIdeaWhatItIs:HoverTooltipDelegate;
      
      private var icon:Bitmap;
      
      private var background:Sprite;
      
      private var iconBitmapData:BitmapData;
      
      private var text:TextFieldDisplayConcrete;
      
      private var tooltip:TextToolTip;
      
      private var gs:GameSprite;
      
      private var menu:ArenaMenu;
      
      public function ArenaDisplay(param1:GameSprite)
      {
         var _loc2_:Rectangle = null;
         var _loc3_:int = 0;
         this.gs = param1;
         this.noIdeaWhatItIs = new HoverTooltipDelegate();
         this.tooltip = new TextToolTip(3552822,10197915,null,"Click to see if there are any running arena games.",160);
         super();
         mouseChildren = false;
         this.iconBitmapData = TextureRedrawer.redraw(AssetLibrary.getImageFromSet(ICON_FILE,ICON_INDEX),40,true,0);
         this.background = UIUtils.makeStaticHUDBackground();
         this.icon = new Bitmap(this.iconBitmapData);
         this.icon.x = -5;
         this.icon.y = -8;
         this.text = new TextFieldDisplayConcrete().setSize(16).setColor(16777215);
         this.text.setStringBuilder(new LineBuilder().setParams("Arena"));
         this.text.filters = [new DropShadowFilter(0,0,0,1,4,4,2)];
         this.text.setVerticalAlign(TextFieldDisplayConcrete.BOTTOM);
         this.noIdeaWhatItIs.setDisplayObject(this);
         this.noIdeaWhatItIs.tooltip = this.tooltip;
         this.addChilds();
         _loc2_ = this.icon.getBounds(this);
         _loc3_ = 10;
         this.text.x = _loc2_.right - _loc3_;
         this.text.y = _loc2_.bottom - _loc3_ - 2;
         addEventListener(MouseEvent.CLICK,this.onClick);
      }
      
      public function setShowToolTipSignal(param1:ShowTooltipSignal) : void
      {
         this.noIdeaWhatItIs.setShowToolTipSignal(param1);
      }
      
      public function getShowToolTip() : ShowTooltipSignal
      {
         return this.noIdeaWhatItIs.getShowToolTip();
      }

      public function setHideToolTipsSignal(param1:HideTooltipsSignal) : void
      {
         this.noIdeaWhatItIs.setHideToolTipsSignal(param1);
      }
      
      public function getHideToolTips() : HideTooltipsSignal
      {
         return this.noIdeaWhatItIs.getHideToolTips();
      }
      
      public function addChilds() : void
      {
         addChild(this.background);
         addChild(this.text);
         addChild(this.icon);
      }
      
      private function onClick(param1:MouseEvent) : void
      {
         if(this.menu && this.gs.contains(this.menu))
         {
            this.gs.removeChild(this.menu);
         }
         this.menu = new ArenaMenu();
         this.menu.init(this.gs);
         this.gs.addChild(this.menu);
         if(this.tooltip && this.tooltip.parent)
         {
            this.tooltip.parent.removeChild(this.tooltip);
         }
      }
   }
}

import com.company.assembleegameclient.game.AGameSprite;

import com.company.assembleegameclient.ui.menu.Menu;

import com.company.assembleegameclient.ui.menu.MenuOption;

import com.company.util.AssetLibrary;
import flash.events.MouseEvent;
import flash.events.Event;

import kabam.rotmg.chat.control.ShowChatInputSignal;

import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.game.view.ArenaInfoItem;
import kabam.rotmg.game.view.GlobalArenaInformation;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;

class ArenaMenu extends Menu
{
    
   
   public var gs_:AGameSprite;
   
   function ArenaMenu()
   {
       super(3552822,16777215);
   }
   
   public function init(param1:AGameSprite) : void
   {
      var _loc2_:MenuOption = null;
      var _loc5_:* = null;
      var _loc6_:TextFieldDisplayConcrete = null;
      var _loc7_:ArenaInfoItem = null;
      var _loc8_:Function = null;
      this.gs_ = param1;
      this.yOffset = this.yOffset - 10;
      var _loc3_:GlobalArenaInformation = StaticInjectorContext.getInjector().getInstance(GlobalArenaInformation);
      var _loc4_:int = 0;
      for(_loc5_ in _loc3_.games)
      {
         _loc4_++;
      }
      _loc6_ = new TextFieldDisplayConcrete().setSize(14).setColor(16777215).setStringBuilder(new StaticStringBuilder((_loc4_ == 0?"No c":"C") + "urrent arena games"));
      addChild(_loc6_);
      for each(_loc7_ in _loc3_.games)
      {
         if(_loc7_.open)
         {
            _loc2_ = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig",10),16777215,"Join " + _loc7_.name);
            switch(_loc7_.name)
            {
               case "Oryx Arena":
                  _loc8_ = this.onOryxArenaJoinClick;
                  break;
               case "Public Arena":
                  _loc8_ = this.onPublicArenaJoinClick;
            }
            if(_loc8_ != null)
            {
               _loc2_.addEventListener(MouseEvent.CLICK,_loc8_);
            }
            addOption(_loc2_);
         }
         _loc2_ = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig",6),16777215,"Spectate " + _loc7_.name);
         switch(_loc7_.name)
         {
            case "Oryx Arena":
               _loc8_ = this.onOryxArenaSpectateClick;
               break;
            case "Public Arena":
               _loc8_ = this.onPublicArenaSpectateClick;
         }
         if(_loc8_ != null)
         {
            _loc2_.addEventListener(MouseEvent.CLICK,_loc8_);
         }
          addOption(_loc2_);
      }
      _loc2_ = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig",8),16777215,"Close");
      _loc2_.addEventListener(MouseEvent.CLICK,this.onCloseClick);
       addOption(_loc2_);
      this.yOffset = this.yOffset + 8;
   }
   
   private function onPublicArenaJoinClick(param1:MouseEvent) : void
   {
       GameServerConnection.instance.playerText("/arena");
      remove();
   }
   
   private function onOryxArenaJoinClick(param1:MouseEvent) : void
   {
       GameServerConnection.instance.playerText("/oa");
      remove();
   }
   
   private function onPublicArenaSpectateClick(param1:MouseEvent) : void
   {
       GameServerConnection.instance.playerText("/spectate 1");
      remove();
   }
   
   private function onOryxArenaSpectateClick(param1:MouseEvent) : void
   {
      GameServerConnection.instance.playerText("/spectate 0");
      remove();
   }
   
   private function onGuildMessage(param1:Event) : void
   {
      var _loc2_:ShowChatInputSignal = StaticInjectorContext.getInjector().getInstance(ShowChatInputSignal);
      _loc2_.dispatch(true,"/g ");
      remove();
   }
   
   private function onCloseClick(param1:MouseEvent) : void
   {
      remove();
   }
}
