package kabam.rotmg.markPurchaser {
import com.company.assembleegameclient.game.AGameSprite;

import flash.events.MouseEvent;

import kabam.lib.net.api.MessageProvider;
import kabam.lib.net.impl.SocketServer;
import kabam.rotmg.dialogs.control.CloseDialogsSignal;
import kabam.rotmg.dialogs.control.OpenDialogNoModalSignal;
import kabam.rotmg.game.signals.AddTextLineSignal;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.messaging.impl.outgoing.MarkRequest;

import org.swiftsuspenders.Injector;

import robotlegs.bender.bundles.mvcs.Mediator;

public class MarkOffersMediator extends Mediator {


    [Inject]
    public var injector:Injector;
    [Inject]
    public var closeDialogs:CloseDialogsSignal;
    [Inject]
    public var socketServer:SocketServer;
    [Inject]
    public var messages:MessageProvider;
    [Inject]
    public var view:MarkOffersModal;
    [Inject]
    public var gameSprite:AGameSprite;
    [Inject]
    public var openNoModalDialog:OpenDialogNoModalSignal;
    [Inject]
    public var addTextLine:AddTextLineSignal;



    override public function initialize():void {
        this.view.engage1.addEventListener(MouseEvent.CLICK, this.onButton1);
        this.view.engage2.addEventListener(MouseEvent.CLICK, this.onButton2);
        this.view.engage3.addEventListener(MouseEvent.CLICK, this.onButton3);
        this.view.engage4.addEventListener(MouseEvent.CLICK, this.onButton4);
        this.view.engage5.addEventListener(MouseEvent.CLICK, this.onButton5);
        this.view.engage6.addEventListener(MouseEvent.CLICK, this.onButton6);
        this.view.engage7.addEventListener(MouseEvent.CLICK, this.onButton7);
        this.view.engage8.addEventListener(MouseEvent.CLICK, this.onButton8);
        this.view.engage9.addEventListener(MouseEvent.CLICK, this.onButton9);
        this.view.engage10.addEventListener(MouseEvent.CLICK, this.onButton10);
        this.view.engage11.addEventListener(MouseEvent.CLICK, this.onButton11);
        this.view.engage12.addEventListener(MouseEvent.CLICK, this.onButton12);
        this.view.engage13.addEventListener(MouseEvent.CLICK, this.onButton13);
        this.view.engage14.addEventListener(MouseEvent.CLICK, this.onButton14);
        this.view.engage15.addEventListener(MouseEvent.CLICK, this.onButton15);
        this.view.engage16.addEventListener(MouseEvent.CLICK, this.onButton16);
        this.view.engage17.addEventListener(MouseEvent.CLICK, this.onButton17);
        this.view.engage18.addEventListener(MouseEvent.CLICK, this.onButton18);
    }

    override public function destroy():void {
        super.destroy();
    }

    protected function onButton1(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 1;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton2(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 2;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton3(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 3;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton4(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 4;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton5(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 5;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton6(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 6;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton7(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 7;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton8(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 8;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton9(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 9;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton10(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 10;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton11(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 11;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton12(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 12;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton13(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 13;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton14(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 14;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton15(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 15;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton16(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 16;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton17(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 17;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }
    protected function onButton18(_arg_1:MouseEvent):void {
        var _local_1:MarkRequest;
        _local_1 = (this.messages.require(GameServerConnection.MARKREQUEST) as MarkRequest);
        _local_1.markId_ = 18;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }



}
}//package kabam.rotmg.pets.view.components
