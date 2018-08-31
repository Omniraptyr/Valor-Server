package kabam.rotmg.game.commands {
import com.company.assembleegameclient.game.MarkShopModel;

import robotlegs.bender.bundles.mvcs.Command;

public class MarkShopUpdateCommand extends Command {

    [Inject]
    public var model:MarkShopModel;


    override public function execute():void {
        this.model.setMarkShopReady();
    }


}
}//package kabam.rotmg.game.commands
