package kabam.rotmg.game.view {
import kabam.rotmg.account.core.signals.OpenMoneyWindowSignal;
import kabam.rotmg.core.model.PlayerModel;

import robotlegs.bender.bundles.mvcs.Mediator;

public class LootboxesDisplayMediator extends Mediator {

    [Inject]
    public var view:LootboxesDisplay;
    [Inject]
    public var model:PlayerModel;
    [Inject]
    public var openMoneyWindow:OpenMoneyWindowSignal;


    override public function initialize():void {
        this.model.lootBox1Changed.add(this.onLootbox1Changed);
        this.model.lootBox2Changed.add(this.onLootbox2Changed);
        this.model.lootBox3Changed.add(this.onLootbox3Changed);
        this.model.lootBox4Changed.add(this.onLootbox4Changed);
        this.view.openAccountDialog.add(this.onOpenAccountDialog);
    }

    override public function destroy():void {
        this.model.lootBox1Changed.remove(this.onLootbox1Changed);
        this.model.lootBox2Changed.remove(this.onLootbox2Changed);
        this.model.lootBox3Changed.remove(this.onLootbox1Changed);
        this.model.lootBox4Changed.remove(this.onLootbox2Changed);
        this.view.openAccountDialog.remove(this.onOpenAccountDialog);
    }

    private function onLootbox1Changed(_arg_1:int):void {
        this.view.draw(this.model.getLootbox1(), this.model.getLootbox2(), this.model.getLootbox3(), this.model.getLootbox4());
    }

    private function onLootbox2Changed(_arg_1:int):void {
        this.view.draw(this.model.getLootbox1(), this.model.getLootbox2(), this.model.getLootbox3(), this.model.getLootbox4());
    }

    private function onLootbox3Changed(_arg_1:int):void {
        this.view.draw(this.model.getLootbox1(), this.model.getLootbox2(), this.model.getLootbox3(), this.model.getLootbox4());
    }

    private function onLootbox4Changed(_arg_1:int):void {
        this.view.draw(this.model.getLootbox1(), this.model.getLootbox2(), this.model.getLootbox3(), this.model.getLootbox4());
    }






    private function onOpenAccountDialog():void {
        this.openMoneyWindow.dispatch();
    }


}
}//package kabam.rotmg.game.view
