package kabam.rotmg.market.ui
{
import kabam.rotmg.dialogs.control.CloseDialogsSignal;
import kabam.rotmg.messaging.impl.GameServerConnection;

import robotlegs.bender.bundles.mvcs.Mediator;

public class MarketMediator extends Mediator
   {
       
      
      [Inject]
      public var view:MarketOverview;
      
      [Inject]
      public var doAction:MarketActionSignal;
      
      [Inject]
      public var closeDialogs:CloseDialogsSignal;
      
      private var packetManager:GameServerConnection;
      
      public function MarketMediator()
      {
         super();
      }
      
      override public function initialize() : void
      {
         this.packetManager = GameServerConnection.instance;
         this.doAction.add(this.onAction);
         this.view.closeButton_.clicked.add(this.closeDialog);
      }
      
      private function closeDialog() : void
      {
         this.closeDialogs.dispatch();
      }
      
      private function onAction(param1:String) : void
      {
         this.packetManager.playerText(param1);
      }
      
      override public function destroy() : void
      {
         this.doAction.remove(this.onAction);
      }
   }
}
