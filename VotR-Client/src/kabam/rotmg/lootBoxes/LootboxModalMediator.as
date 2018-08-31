package kabam.rotmg.lootBoxes {
import com.company.assembleegameclient.game.AGameSprite;

import flash.events.MouseEvent;

import kabam.lib.net.api.MessageProvider;
import kabam.lib.net.impl.SocketServer;
import kabam.rotmg.dialogs.control.CloseDialogsSignal;
import kabam.rotmg.dialogs.control.OpenDialogNoModalSignal;
import kabam.rotmg.game.signals.AddTextLineSignal;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.messaging.impl.outgoing.UnboxRequest;

import org.swiftsuspenders.Injector;

import robotlegs.bender.bundles.mvcs.Mediator;

public class LootboxModalMediator extends Mediator {


    [Inject]
    public var injector:Injector;
    [Inject]
    public var closeDialogs:CloseDialogsSignal;
    [Inject]
    public var socketServer:SocketServer;
    [Inject]
    public var messages:MessageProvider;
    [Inject]
    public var view:LootboxModal;
    [Inject]
    public var gameSprite:AGameSprite;
    [Inject]
    public var openNoModalDialog:OpenDialogNoModalSignal;
    [Inject]
    public var addTextLine:AddTextLineSignal;



    override public function initialize():void {
        this.view.Lootbox1Amount.addEventListener(MouseEvent.CLICK, this.onButton1);
        this.view.Lootbox2Amount.addEventListener(MouseEvent.CLICK, this.onButton2);
        this.view.Lootbox3Amount.addEventListener(MouseEvent.CLICK, this.onButton3);
        this.view.Lootbox4Amount.addEventListener(MouseEvent.CLICK, this.onButton4);
        this.view.Lootbox5Amount.addEventListener(MouseEvent.CLICK, this.onButton5);
    }

    override public function destroy():void {
        super.destroy();
    }

    protected function onButton1(_arg_1:MouseEvent):void {
        var _local_1:UnboxRequest;
        _local_1 = (this.messages.require(GameServerConnection.UNBOXREQUEST) as UnboxRequest);
        _local_1.lootboxType_ = 1;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }

    protected function onButton2(_arg_1:MouseEvent):void {
        var _local_1:UnboxRequest;
        _local_1 = (this.messages.require(GameServerConnection.UNBOXREQUEST) as UnboxRequest);
        _local_1.lootboxType_ = 2;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }

    protected function onButton3(_arg_1:MouseEvent):void {
        var _local_1:UnboxRequest;
        _local_1 = (this.messages.require(GameServerConnection.UNBOXREQUEST) as UnboxRequest);
        _local_1.lootboxType_ = 3;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }

    protected function onButton4(_arg_1:MouseEvent):void {
        var _local_1:UnboxRequest;
        _local_1 = (this.messages.require(GameServerConnection.UNBOXREQUEST) as UnboxRequest);
        _local_1.lootboxType_ = 4;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }

    protected function onButton5(_arg_1:MouseEvent):void {
        var _local_1:UnboxRequest;
        _local_1 = (this.messages.require(GameServerConnection.UNBOXREQUEST) as UnboxRequest);
        _local_1.lootboxType_ = 5;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }



}
}//package kabam.rotmg.pets.view.components
