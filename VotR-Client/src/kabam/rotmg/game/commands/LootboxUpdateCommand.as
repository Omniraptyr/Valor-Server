package kabam.rotmg.game.commands {
import com.company.assembleegameclient.game.LootboxModel;

import robotlegs.bender.bundles.mvcs.Command;

public class LootboxUpdateCommand extends Command {

    [Inject]
    public var model:LootboxModel;


    override public function execute():void {
        this.model.setLootboxReady();
    }


}
}//package kabam.rotmg.game.commands
