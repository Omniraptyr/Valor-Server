package kabam.rotmg.game.commands {
import com.company.assembleegameclient.game.AlertStatusModel;

import robotlegs.bender.bundles.mvcs.Command;

public class AlertStatusUpdateCommand extends Command {

    [Inject]
    public var model:AlertStatusModel;


    override public function execute():void {
        this.model.setAlertStatusReady(true);
    }


}
}