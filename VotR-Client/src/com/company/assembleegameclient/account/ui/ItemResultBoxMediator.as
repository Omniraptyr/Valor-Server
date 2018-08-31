package com.company.assembleegameclient.account.ui {

import com.company.assembleegameclient.game.AGameSprite;

import kabam.rotmg.dialogs.control.CloseDialogsSignal;

import robotlegs.bender.bundles.mvcs.Mediator;

public class ItemResultBoxMediator extends Mediator {

    [Inject]
    public var view:ItemResultBox;
    [Inject]
    public var closeDialogs:CloseDialogsSignal;
    [Inject]
    private var gameSprite:AGameSprite;


    override public function initialize():void {
        this.gameSprite = this.view.gameSprite;
        this.view.cancel.add(this.onCancel);
    }

    override public function destroy():void {
        this.view.cancel.remove(this.onCancel);
    }

    private function onCancel():void {
        this.closeDialogs.dispatch();
    }


}
}//package com.company.assembleegameclient.account.ui
