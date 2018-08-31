package kabam.rotmg.sorForge {
import com.company.assembleegameclient.game.AGameSprite;

import flash.events.MouseEvent;

import kabam.lib.net.api.MessageProvider;
import kabam.lib.net.impl.SocketServer;
import kabam.rotmg.dialogs.control.CloseDialogsSignal;
import kabam.rotmg.dialogs.control.OpenDialogNoModalSignal;
import kabam.rotmg.game.signals.AddTextLineSignal;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.messaging.impl.data.SlotObjectData;
import kabam.rotmg.messaging.impl.outgoing.ForgeItem;
import kabam.rotmg.questrewards.components.ModalItemSlot;

import org.swiftsuspenders.Injector;

import robotlegs.bender.bundles.mvcs.Mediator;

public class SorForgerUIMediator extends Mediator {


  /*  [Inject]
    public var cookResultDone:CookResultSignal;*/
    [Inject]
    public var injector:Injector;
    [Inject]
    public var closeDialogs:CloseDialogsSignal;
    [Inject]
    public var socketServer:SocketServer;
    [Inject]
    public var messages:MessageProvider;
    [Inject]
    public var view:SorForgerUI;
    [Inject]
    public var gameSprite:AGameSprite;
    [Inject]
    public var openNoModalDialog:OpenDialogNoModalSignal;
    [Inject]
    public var addTextLine:AddTextLineSignal;
    [Inject]
    public var itemslot1:ModalItemSlot;
    [Inject]
    public var itemslot4:ModalItemSlot;
    [Inject]
    public var slot1Data:SlotObjectData;
    [Inject]
    public var slot4Data:SlotObjectData;



    override public function initialize():void {
        this.clearItemslots();
        this.itemslot1 = this.view.getItemSlot1()
        this.itemslot4 = this.view.getItemSlot4()
        this.view.forgeButton.addEventListener(MouseEvent.CLICK, this.onButtonForge);
    }
    override public function destroy():void {
        super.destroy();
    }

    private function clearItemslots() : void {
        this.itemslot1 = null;
        this.itemslot4 = null;

    }
    protected function onButtonForge(_arg_1:MouseEvent):void {
        slot1Data = new SlotObjectData();
        slot1Data.objectId_ = this.itemslot1.objectId;
        slot1Data.objectType_ = this.itemslot1.itemId;
        slot1Data.slotId_ = this.itemslot1.slotId;
        slot4Data = new SlotObjectData();
        slot4Data.objectId_ = this.itemslot4.objectId;
        slot4Data.objectType_ = this.itemslot4.itemId;
        slot4Data.slotId_ = this.itemslot4.slotId;
        var _local_1:ForgeItem;
        _local_1 = (this.messages.require(GameServerConnection.FORGEITEM) as ForgeItem);
        _local_1.sor_ = this.slot4Data;
        _local_1.shard_ = this.slot1Data;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch()
    }


}
}//package kabam.rotmg.pets.view.components
