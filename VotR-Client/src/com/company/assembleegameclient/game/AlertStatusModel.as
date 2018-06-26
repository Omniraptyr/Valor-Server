package com.company.assembleegameclient.game {
import kabam.rotmg.game.signals.UpdateAlertStatusDisplaySignal;

public class AlertStatusModel {

    [Inject]
    public var updateAlertStatusDisplay:UpdateAlertStatusDisplaySignal;
    public var hasAlert:Boolean;


    public function setAlertStatusReady(_arg1:Boolean):void {
        this.hasAlert = _arg1;
        this.updateAlertStatusDisplay.dispatch();
    }


}
}
