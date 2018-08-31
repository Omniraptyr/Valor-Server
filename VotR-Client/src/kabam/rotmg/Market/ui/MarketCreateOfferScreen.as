package kabam.rotmg.market.ui
{
import com.company.assembleegameclient.ui.DeprecatedTextButton;
import com.company.assembleegameclient.ui.Scrollbar;
import com.company.assembleegameclient.ui.dialogs.Dialog;

import flash.display.Shape;
import flash.display.Sprite;
import flash.events.Event;
import flash.events.MouseEvent;

import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.market.MarketResultSignal;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.messaging.impl.data.MarketOffer;
import kabam.rotmg.pets.view.dialogs.PetDialog;

import org.osflash.signals.natives.NativeMappedSignal;

public class MarketCreateOfferScreen extends Sprite
   {
      
      public static const WIDTH:int = 600;
      
      public static const HEIGHT:int = 600;
      
      public static var offerMask:Shape;
       
      
      private var scrollBar:Scrollbar;
      
      private var offerHolder:Sprite;
      
      private var offers:Vector.<OfferEntry>;
      
      private var addOfferButton:DeprecatedTextButton;
      
      private var saveOffersButton:DeprecatedTextButton;
      
      public var removed:NativeMappedSignal;
      
      public function MarketCreateOfferScreen()
      {
         super();
         this.removed = new NativeMappedSignal(this,Event.REMOVED_FROM_STAGE);
         this.offers = new Vector.<OfferEntry>();
         graphics.beginFill(0,0);
         graphics.drawRect(0,0,WIDTH,HEIGHT);
         graphics.endFill();
         if(!offerMask)
         {
            offerMask = new Shape();
            offerMask.graphics.beginFill(0,0);
            offerMask.graphics.drawRect(0,0,600,500);
            offerMask.graphics.endFill();
         }
         addChild(offerMask);
         this.offerHolder = new Sprite();
         this.offerHolder.mask = offerMask;
         addChild(this.offerHolder);
         this.saveOffersButton = new DeprecatedTextButton(21,"Save");
         this.saveOffersButton.x = 15;
         this.saveOffersButton.addEventListener(MouseEvent.CLICK,this.onSaveOffers);
         this.offerHolder.addChild(this.saveOffersButton);
         this.addOfferButton = new DeprecatedTextButton(21,"Add offer",100,true);
         this.addOfferButton.addEventListener(MouseEvent.CLICK,this.onAddOffer);
         this.addOfferButton.x = 465;
         this.offerHolder.addChild(this.addOfferButton);
         this.scrollBar = new Scrollbar(16,490);
         this.scrollBar.y = 5;
         this.scrollBar.x = 578;
         addChild(this.scrollBar);
         this.addOffer(new OfferEntry());
      }
      
      private function onSaveOffers(param1:MouseEvent) : void
      {
         var i:OfferEntry = null;
         var dialog:PetDialog = null;
         var event:MouseEvent = param1;
         var valid:Boolean = true;
         var offers:Vector.<MarketOffer> = new Vector.<MarketOffer>();
         for each(i in this.offers)
         {
            if(!i.isValidOffer())
            {
               valid = false;
            }
            offers.push(i.makeOffer());
         }
         if(!valid)
         {
            dialog = new PetDialog("Ooops :C","Some of your offers are not valid, check the price and make sure you gave them an item.","Ok",null,"/offerError");
            dialog.addFullDim();
            dialog.addEventListener(Dialog.LEFT_BUTTON,function(param1:Event):void
            {
               dialog.parent.removeChild(dialog);
            });
            parent.parent.addChild(dialog);
            return;
         }
         StaticInjectorContext.getInjector().getInstance(MarketResultSignal).add(this.onResult);
         GameServerConnection.instance.addOffer(offers);
         this.saveOffersButton.setEnabled(false);
      }
      
      private function onAddOffer(param1:MouseEvent) : void
      {
         this.addOffer(new OfferEntry());
      }
      
      private function addOffer(param1:OfferEntry) : void
      {
         param1.y = (this.offers.length + 1) * 5 + OfferEntry.HEIGHT * this.offers.length;
         param1.removeOffer.add(this.onOfferRemove);
         this.offerHolder.addChild(param1);
         this.offers.push(param1);
         this.update();
      }
      
      private function onOfferRemove(param1:OfferEntry) : void
      {
         var _loc2_:int = this.offers.indexOf(param1);
         this.offers.splice(_loc2_,1);
         if(this.offerHolder && this.offerHolder.contains(param1))
         {
            this.offerHolder.removeChild(param1);
         }
         var _loc3_:int = 0;
         while(_loc3_ < this.offers.length)
         {
            this.offers[_loc3_].y = (_loc3_ + 1) * 5 + OfferEntry.HEIGHT * _loc3_;
            _loc3_++;
         }
         this.update(true);
      }
      
      private function update(param1:Boolean = false) : void
      {
         this.scrollBar.setIndicatorSize(500,(this.offers.length + 1) * 5 + OfferEntry.HEIGHT * this.offers.length + 10,param1);
         this.scrollBar.addEventListener(Event.CHANGE,this.onScroll);
         this.addOfferButton.y = (this.offers.length + 1) * 5 + OfferEntry.HEIGHT * this.offers.length + 5;
         this.saveOffersButton.y = (this.offers.length + 1) * 5 + OfferEntry.HEIGHT * this.offers.length + 5;
      }
      
      private function onResult(param1:String, param2:Boolean) : void
      {
         var dialog:PetDialog = null;
         var message:String = param1;
         var error:Boolean = param2;
          StaticInjectorContext.getInjector().getInstance(MarketResultSignal).remove(this.onResult);
         if(parent && parent.parent && parent.parent.parent)
         {
            dialog = new PetDialog(!!error?"Ooops :C":"Success",message,"Ok",null,"/marketResult");
            dialog.addFullDim();
            dialog.addEventListener(Dialog.LEFT_BUTTON,function(param1:Event):void
            {
               dialog.parent.removeChild(dialog);
               (parent as MarketOverview).myOffers();
            });
            parent.parent.parent.addChild(dialog);
         }
      }
      
      private function onScroll(param1:Event) : void
      {
         this.offerHolder.y = -this.scrollBar.pos() * (this.offerHolder.height - 490);
      }
   }
}

import com.company.assembleegameclient.account.ui.TextInputField;
import com.company.assembleegameclient.ui.DeprecatedTextButton;
import com.company.assembleegameclient.ui.dialogs.Dialog;

import flash.display.Sprite;
import flash.events.Event;
import flash.events.MouseEvent;

import kabam.rotmg.market.ui.MarketInventorySlot;
import kabam.rotmg.messaging.impl.data.MarketOffer;
import kabam.rotmg.pets.view.dialogs.PetDialog;

import org.osflash.signals.Signal;

class OfferEntry extends Sprite
{
   
   public static const WIDTH:int = 560;
   
   public static const HEIGHT:int = 120;
    
   
   public var removeOffer:Signal;
   
   private var priceInput:TextInputField;
   
   private var removeButton:DeprecatedTextButton;
   
   private var sellSlot:MarketInventorySlot;
   
   function OfferEntry()
   {
      super();
      this.removeOffer = new Signal(OfferEntry);
      x = 10;
      graphics.beginFill(0,1);
      graphics.drawRect(0,0,WIDTH,HEIGHT);
      graphics.endFill();
      graphics.lineStyle(1,16777215,1);
      graphics.drawRect(0,0,WIDTH,HEIGHT);
      graphics.lineStyle();
      this.sellSlot = new MarketInventorySlot();
      this.sellSlot.x = 5;
      this.sellSlot.y = 10;
      addChild(this.sellSlot);
      this.priceInput = new TextInputField("Offer Price",false);
      this.priceInput.x = 55 + this.sellSlot.width;
      this.priceInput.y = 15;
      this.priceInput.inputText_.restrict = "0-9";
      addChild(this.priceInput);
      this.removeButton = new DeprecatedTextButton(21,"Remove",0,true);
      this.removeButton.textChanged.add(this.alignUI);
      this.removeButton.addEventListener(MouseEvent.CLICK,this.onRemoveClick);
      addChild(this.removeButton);
   }
   
   private function alignUI() : void
   {
      this.removeButton.x = WIDTH - this.removeButton.width - 20;
      this.removeButton.y = HEIGHT / 2 - this.removeButton.height / 2;
   }
   
   private function onRemoveClick(param1:MouseEvent) : void
   {
      var dialog:PetDialog = null;
      var event:MouseEvent = param1;
      dialog = new PetDialog("Confirm","Are you sure you want to remove this offer from your creation list?","Remove","Keep it","/removeConfirm");
      dialog.addFullDim();
      dialog.addEventListener(Dialog.RIGHT_BUTTON,function(param1:Event):void
      {
         dialog.parent.removeChild(dialog);
      });
      dialog.addEventListener(Dialog.LEFT_BUTTON,this.onRemoveOffer);
      parent.parent.parent.addChild(dialog);
   }
   
   private function onRemoveOffer(param1:Event) : void
   {
      (param1.target as PetDialog).parent.removeChild(param1.target as PetDialog);
      this.removeOffer.dispatch(this);
   }
   
   public function isValidOffer() : Boolean
   {
      var _loc1_:int = int(this.priceInput.text());
      if(_loc1_ < 0 || !this.priceInput.text())
      {
         this.priceInput.setError("Invalid Price");
         return false;
      }
      return this.sellSlot.itemId != -1;
   }
   
   public function makeOffer() : MarketOffer
   {
      var _loc1_:MarketOffer = new MarketOffer();
      _loc1_.objectSlot = this.sellSlot.makeObjectSlot();
      _loc1_.price = int(this.priceInput.text());
      return _loc1_;
   }
}
