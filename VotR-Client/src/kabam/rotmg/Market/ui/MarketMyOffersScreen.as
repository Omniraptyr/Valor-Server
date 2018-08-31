package kabam.rotmg.market.ui
{
import com.company.assembleegameclient.ui.Scrollbar;
import com.company.assembleegameclient.ui.dialogs.Dialog;

import flash.display.Shape;
import flash.display.Sprite;
import flash.events.Event;
import flash.text.TextFieldAutoSize;

import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.market.MarketItemsResultSignal;
import kabam.rotmg.market.MarketResultSignal;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.messaging.impl.data.PlayerShopItem;
import kabam.rotmg.pets.view.dialogs.PetDialog;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;

import org.osflash.signals.natives.NativeMappedSignal;

public class MarketMyOffersScreen extends Sprite
   {
      
      public static const WIDTH:int = 600;
      
      public static const HEIGHT:int = 600;
       
      
      private var status:TextFieldDisplayConcrete;
      
      private var scrollBar:Scrollbar;
      
      private var offerHolder:Sprite;
      
      public var removed:NativeMappedSignal;
      
      public function MarketMyOffersScreen()
      {
         super();
         this.removed = new NativeMappedSignal(this,Event.REMOVED_FROM_STAGE);
         this.status = new TextFieldDisplayConcrete().setSize(46).setBold(true).setStringBuilder(new StaticStringBuilder("Loading...")).setAutoSize(TextFieldAutoSize.CENTER).setTextWidth(600).setVerticalAlign(TextFieldDisplayConcrete.MIDDLE).setPosition(0,250).setColor(16777215);
         addChild(this.status);
         StaticInjectorContext.getInjector().getInstance(MarketItemsResultSignal).add(this.onOffersGet);
         GameServerConnection.instance.requestMarketOffers();
      }
      
      private function onOffersGet(param1:Vector.<PlayerShopItem>) : void
      {
         var _loc4_:OfferEntry = null;
         var _loc5_:PlayerShopItem = null;
         StaticInjectorContext.getInjector().getInstance(MarketItemsResultSignal).remove(this.onOffersGet);
         if(param1.length == 0)
         {
            this.status.setStringBuilder(new StaticStringBuilder("No offers yet."));
         }
         else
         {
            this.status.visible = false;
         }
         var _loc2_:Shape = new Shape();
         _loc2_.graphics.beginFill(0,0);
         _loc2_.graphics.drawRect(0,0,600,500);
         _loc2_.graphics.endFill();
         addChild(_loc2_);
         this.offerHolder = new Sprite();
         this.offerHolder.mask = _loc2_;
         var _loc3_:Number = 5;
         for each(_loc5_ in param1)
         {
            _loc4_ = new OfferEntry(_loc5_);
            _loc4_.y = _loc3_;
            _loc4_.removeOffer.add(this.onOfferRemove);
            this.offerHolder.addChild(_loc4_);
            _loc3_ = _loc3_ + (5 + OfferEntry.HEIGHT);
         }
         addChild(this.offerHolder);
         this.scrollBar = new Scrollbar(16,490);
         this.scrollBar.y = 5;
         this.scrollBar.x = 578;
         addChild(this.scrollBar);
         this.scrollBar.setIndicatorSize(500,this.offerHolder.height);
         this.scrollBar.addEventListener(Event.CHANGE,this.onScroll);
      }
      
      private function onOfferRemove(param1:PlayerShopItem) : void
      {
         StaticInjectorContext.getInjector().getInstance(MarketResultSignal).add(this.onResult);
         GameServerConnection.instance.removeMarketOffer(param1);
      }
      
      private function onResult(param1:String, param2:Boolean) : void
      {
         var dialog:PetDialog = null;
         var message:String = param1;
         var error:Boolean = param2;
         StaticInjectorContext.getInjector().getInstance(MarketResultSignal).remove(this.onResult);
         dialog = new PetDialog(error?"Ooops :C":"Success",message,"Ok",null,"/marketResult");
         dialog.addFullDim();
         dialog.addEventListener(Dialog.LEFT_BUTTON,function(param1:Event):void
         {
            dialog.parent.removeChild(dialog);
            (parent as MarketOverview).myOffers();
         });
         parent.parent.parent.addChild(dialog);
      }
      
      private function onScroll(param1:Event) : void
      {
         this.offerHolder.y = -this.scrollBar.pos() * (this.offerHolder.height - 490);
      }
   }
}

import com.company.assembleegameclient.objects.ObjectLibrary;
import com.company.assembleegameclient.ui.DeprecatedTextButton;
import com.company.assembleegameclient.ui.dialogs.Dialog;
import com.company.assembleegameclient.ui.tooltip.ToolTip;

import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.display.Sprite;
import flash.events.Event;
import flash.events.MouseEvent;
import flash.globalization.DateTimeFormatter;
import flash.globalization.LocaleID;

import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.core.signals.ShowTooltipSignal;
import kabam.rotmg.messaging.impl.data.PlayerShopItem;
import kabam.rotmg.pets.view.dialogs.PetDialog;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;

import org.osflash.signals.Signal;

class OfferEntry extends Sprite
{
   
   public static const WIDTH:int = 560;
   
   public static const HEIGHT:int = 70;
   
   private static var toolTip:ToolTip;
    
   
   public var removeOffer:Signal;
   
   private var item:PlayerShopItem;
   
   private var removeButton:DeprecatedTextButton;
   
   private var isLast:Boolean;
   
   function OfferEntry(param1:PlayerShopItem)
   {
      super();
      this.removeOffer = new Signal(PlayerShopItem);
      this.item = param1;
      this.isLast = param1.isLast;
      x = 10;
      graphics.beginFill(0,1);
      graphics.drawRect(0,0,WIDTH,HEIGHT);
      graphics.endFill();
      graphics.lineStyle(1,16777215,1);
      graphics.drawRect(0,0,WIDTH,HEIGHT);
      graphics.lineStyle();
      var _loc2_:BitmapData = ObjectLibrary.getRedrawnTextureFromType(param1.itemId,100,true);
      addChild(new Bitmap(_loc2_));
      var _loc3_:String = !!ObjectLibrary.xmlLibrary_[param1.itemId].hasOwnProperty("DisplayId")?ObjectLibrary.xmlLibrary_[param1.itemId].DisplayId:ObjectLibrary.xmlLibrary_[param1.itemId].@id;
      var _loc4_:TextFieldDisplayConcrete = new TextFieldDisplayConcrete().setSize(22).setColor(16777215).setPosition(_loc2_.width,5).setBold(true).setStringBuilder(new LineBuilder().setParams(_loc3_));
      addChild(_loc4_);
      var _loc5_:DateTimeFormatter = new DateTimeFormatter(LocaleID.DEFAULT);
      _loc5_.setDateTimePattern("yyyy-MM-dd HH:mm:ss");
      var _loc6_:TextFieldDisplayConcrete = new TextFieldDisplayConcrete().setSize(16).setColor(16777215).setPosition(_loc2_.width,35).setStringBuilder(new StaticStringBuilder("Added at: " + _loc5_.formatUTC(new Date(param1.insertTime * 1000)) + " UTC"));
      addChild(_loc6_);
      this.removeButton = new DeprecatedTextButton(21,"Remove",0,true);
      this.removeButton.textChanged.add(this.alignUI);
      this.removeButton.addEventListener(MouseEvent.CLICK,this.onRemoveClick);
      addChild(this.removeButton);
      addEventListener(MouseEvent.ROLL_OVER,this.onRollOver);
      addEventListener(MouseEvent.ROLL_OUT,this.onRollOut);
   }
   
   private function onRollOver(param1:MouseEvent) : void
   {
      if(toolTip != null)
      {
         if(toolTip.parent != null)
         {
            toolTip.parent.removeChild(toolTip);
         }
      }
      toolTip = new OfferToolTip(this.item);
      StaticInjectorContext.getInjector().getInstance(ShowTooltipSignal).dispatch(toolTip);
   }
   
   private function onRollOut(param1:MouseEvent) : void
   {
      if(toolTip && toolTip.parent)
      {
         toolTip.parent.removeChild(toolTip);
      }
   }
   
   private function alignUI() : void
   {
      this.removeButton.x = WIDTH - this.removeButton.width - 10;
      this.removeButton.y = HEIGHT / 2 - this.removeButton.height / 2;
   }
   
   private function onRemoveClick(param1:MouseEvent) : void
   {
      var dialog:PetDialog = null;
      var event:MouseEvent = param1;
      dialog = new PetDialog("Are you sure?",!!this.isLast?"This action cannot be undone, continue?":"This action will cost you 50 gold and cannot be undone, continue?","Remove","Keep it","/removeConfirm");
      dialog.addFullDim();
      dialog.addEventListener(Dialog.RIGHT_BUTTON,function(param1:Event):void
      {
         dialog.parent.removeChild(dialog);
      });
      dialog.addEventListener(Dialog.LEFT_BUTTON,function(param1:Event):void
      {
         removeOffer.dispatch(item);
         dialog.parent.removeChild(dialog);
      });
      parent.parent.parent.addChild(dialog);
   }
}


class OfferToolTip extends ToolTip
{
    
   
   private var itemName:TextFieldDisplayConcrete;
   
   private var date:TextFieldDisplayConcrete;
   
   private var price:TextFieldDisplayConcrete;
   
   private var count:TextFieldDisplayConcrete;
   
   private var icon:Bitmap;
   
   function OfferToolTip(param1:PlayerShopItem)
   {
      super(0,1,16777215,1,true);
      var _loc2_:BitmapData = ObjectLibrary.getRedrawnTextureFromType(param1.itemId,100,true);
      addChild(this.icon = new Bitmap(_loc2_));
      var _loc3_:String = !!ObjectLibrary.xmlLibrary_[param1.itemId].hasOwnProperty("DisplayId")?ObjectLibrary.xmlLibrary_[param1.itemId].DisplayId:ObjectLibrary.xmlLibrary_[param1.itemId].@id;
      this.itemName = new TextFieldDisplayConcrete().setSize(22).setColor(16777215).setBold(true).setStringBuilder(new LineBuilder().setParams(_loc3_));
       waiter.push(this.itemName.textChanged);
      addChild(this.itemName);
      var _loc4_:DateTimeFormatter = new DateTimeFormatter(LocaleID.DEFAULT);
      _loc4_.setDateTimePattern("yyyy-MM-dd HH:mm:ss");
      this.date = new TextFieldDisplayConcrete().setSize(16).setColor(16777215).setStringBuilder(new StaticStringBuilder("Added at: " + _loc4_.formatUTC(new Date(param1.insertTime * 1000)) + " UTC"));
       waiter.push(this.date.textChanged);
      addChild(this.date);
      this.price = new TextFieldDisplayConcrete().setSize(16).setColor(16777215).setStringBuilder(new StaticStringBuilder("Will be sold for: " + param1.price));
       waiter.push(this.price.textChanged);
      addChild(this.price);
      this.count = new TextFieldDisplayConcrete().setSize(16).setColor(16777215).setStringBuilder(new StaticStringBuilder((param1.count == -1?"1":param1.count) + " in stock."));
       waiter.push(this.count.textChanged);
      addChild(this.count);
   }
   
   override protected function alignUI() : void
   {
      this.itemName.x = this.icon.width + 4;
      this.itemName.y = this.icon.height / 2 - this.itemName.height / 2;
      this.date.x = 8;
      this.date.y = height + 5;
      this.price.x = 8;
      this.price.y = height + 5;
      this.count.x = 8;
      this.count.y = height + 5;
   }
}
