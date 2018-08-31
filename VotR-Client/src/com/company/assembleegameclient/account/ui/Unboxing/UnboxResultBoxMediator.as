package com.company.assembleegameclient.account.ui.Unboxing
{
import com.company.assembleegameclient.account.ui.ItemResultBox;
import com.company.assembleegameclient.game.AGameSprite;
import com.company.assembleegameclient.sound.SoundEffectLibrary;

import kabam.rotmg.dialogs.control.CloseDialogsSignal;
import kabam.rotmg.dialogs.control.OpenDialogSignal;

import robotlegs.bender.bundles.mvcs.Mediator;

public class UnboxResultBoxMediator extends Mediator
{

    [Inject]
    public var view:UnboxResultBox;
    [Inject]
    public var closeDialogs:CloseDialogsSignal;
    [Inject]
    private var gameSprite:AGameSprite;
    [Inject]
    public var unboxScroll:UnboxScroll;
    [Inject]
    public var openDialog:OpenDialogSignal;

    override public function initialize():void
    {
        this.gameSprite = this.view.gameSprite;
        this.unboxScroll = this.view.unboxScroll_;
        this.view.cancel.add(this.onCancel);
        this.view.hideInventory.add(this.onHideInventory);
        this.view.completed.add(this.onCompleted)
    }

    override public function destroy():void
    {
        this.view.cancel.remove(this.onCancel);
        this.view.hideInventory.remove(this.onHideInventory);
        this.view.completed.remove(this.onCompleted);
    }
    private function onCompleted():void{
        SoundEffectLibrary.play("enter_realm");
        this.closeDialogs.dispatch()
        this.openDialog.dispatch(new ItemResultBox(this.gameSprite, unboxScroll.itemTypes_[45]));
    }

    private function onHideInventory():void{
        //this.hideMInventory.dispatch();
    }



    private function onCancel():void
    {
        this.closeDialogs.dispatch();
    }


}
}//package com.company.assembleegameclient.account.ui.Unboxing