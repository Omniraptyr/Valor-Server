package com.company.assembleegameclient.game {
import kabam.rotmg.game.signals.UpdateLootboxButtonSignal;

public class LootboxModel {

    [Inject]
    public var updateLootboxSignal:UpdateLootboxButtonSignal;


    public function setLootboxReady():void {
        this.updateLootboxSignal.dispatch();
    }


}
}//package com.company.assembleegameclient.game
