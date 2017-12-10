package kabam.rotmg.Market.ui
{
import kabam.rotmg.Market.MarketItemsResultSignal;
import kabam.rotmg.Market.MarketResultSignal;

import org.swiftsuspenders.Injector;

import robotlegs.bender.extensions.mediatorMap.api.IMediatorMap;

import robotlegs.bender.framework.api.IConfig;

public class MarketMediatorConfig implements IConfig
   {
       
      
      [Inject]
      public var injector:Injector;
      
      [Inject]
      public var mediatorMap:IMediatorMap;
      
      public function MarketMediatorConfig()
      {
         super();
      }
      
      public function configure() : void
      {
         this.injector.map(MarketItemsResultSignal).asSingleton();
         this.injector.map(MarketResultSignal).asSingleton();
         this.injector.map(MarketActionSignal).asSingleton();
         this.mediatorMap.map(MarketOverview).toMediator(MarketMediator);
      }
   }
}
