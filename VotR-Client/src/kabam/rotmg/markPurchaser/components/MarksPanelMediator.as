package kabam.rotmg.markPurchaser.components {
import kabam.rotmg.markPurchaser.MarkOffersModal;
import kabam.rotmg.markPurchaser.components.*;

import com.company.assembleegameclient.game.AGameSprite;

import flash.events.MouseEvent;

import kabam.rotmg.dialogs.control.OpenDialogNoModalSignal;
import kabam.rotmg.dialogs.control.OpenDialogSignal;
import kabam.rotmg.pets.view.FeedPetView;
import kabam.rotmg.pets.view.FusePetView;
import kabam.rotmg.sorForge.SorForgerUI;

import robotlegs.bender.bundles.mvcs.Mediator;

public class MarksPanelMediator extends Mediator {

    [Inject]
    public var view:MarksPanel;
    [Inject]
    public var gameSprite:AGameSprite;
    [Inject]
    public var openNoModalDialog:OpenDialogNoModalSignal;


    override public function initialize():void {
        this.view.init();
        this.view.offersButton.addEventListener(MouseEvent.CLICK, this.onButtonLeftClick);
    }

    override public function destroy():void {
        super.destroy();
    }

    protected function onButtonLeftClick(_arg_1:MouseEvent):void {
        this.openNoModalDialog.dispatch(new MarkOffersModal(this.gameSprite));
    }


}
}//package kabam.rotmg.pets.view.components
