package kabam.rotmg.sorForge.components {
import com.company.assembleegameclient.game.AGameSprite;

import flash.events.MouseEvent;

import kabam.rotmg.dialogs.control.OpenDialogNoModalSignal;
import kabam.rotmg.sorForge.SorForgerUI;

import robotlegs.bender.bundles.mvcs.Mediator;

public class SorForgePanelMediator extends Mediator {

    [Inject]
    public var view:SorForgePanel;
    [Inject]
    public var gameSprite:AGameSprite;
    [Inject]
    public var openNoModalDialog:OpenDialogNoModalSignal;


    override public function initialize():void {
        this.view.init();
        this.view.forgeButton.addEventListener(MouseEvent.CLICK, this.onButtonLeftClick);
    }

    override public function destroy():void {
        super.destroy();
    }

    protected function onButtonLeftClick(_arg_1:MouseEvent):void {
        this.openNoModalDialog.dispatch(new SorForgerUI(this.gameSprite));
    }


}
}//package kabam.rotmg.pets.view.components
