package com.company.assembleegameclient.game {
import kabam.rotmg.game.signals.UpdateMarkShopButtonSignal;

public class MarkShopModel {

    [Inject]
    public var updateMarkShopButton:UpdateMarkShopButtonSignal;


    public function setMarkShopReady():void {
        this.updateMarkShopButton.dispatch();
    }


}
}//package com.company.assembleegameclient.game
