package kabam.rotmg.market {
import flash.events.MouseEvent;

import kabam.rotmg.account.core.Account;
import kabam.rotmg.dialogs.control.OpenDialogNoModalSignal;
import kabam.rotmg.market.ui.MarketOverview;

import robotlegs.bender.bundles.mvcs.Mediator;

public class MarketNPCPanelMediator extends Mediator {
    [Inject]
    public var view:MarketNPCPanel;         
    [Inject]
    public var dialogNoDim:OpenDialogNoModalSignal;
    [Inject]
    public var account:Account;
      
    public function MarketNPCPanelMediator() {
        super();
    }
	
    override public function initialize() : void {
        this.view.init();
        this.addListener();
    }
    
    private function addListener() : void {
        if(this.view.manageBtn) {
           this.view.manageBtn.addEventListener(MouseEvent.CLICK, this.openMarketView);
        }
    }
      
    override public function destroy() : void {
        super.destroy();
    }
	
    protected function openMarketView(e:MouseEvent) : void {
        this.dialogNoDim.dispatch(new MarketOverview());
    }
}
}