package kabam.rotmg.game.view {

import kabam.rotmg.account.core.Account;
import kabam.rotmg.game.signals.UpdateMarkShopButtonSignal;

public class MarkShopMediator {

    [Inject]
    public var updateMarkShopButton:UpdateMarkShopButtonSignal;
    [Inject]
    public var view:RaidLauncherButton;
    [Inject]
    public var account:Account;

    public function initialize():void {
        this.updateMarkShopButton.add(this.onMarkShopUpdate);
        if (this.account.isRegistered()) {
            this.view.drawAsOpen();
        }
        else {
            this.view.drawAsClosed();
        }
    }

    private function onMarkShopUpdate():void {
        if (this.account.isRegistered()) {
            this.view.drawAsOpen();
        }
        else {
            this.view.drawAsClosed();
        }
    }


}
}//package kabam.rotmg.game.view
