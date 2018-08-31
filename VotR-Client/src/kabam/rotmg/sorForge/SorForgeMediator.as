package kabam.rotmg.sorForge {
import com.company.assembleegameclient.game.AGameSprite;

import flash.events.MouseEvent;

import kabam.lib.net.api.MessageProvider;
import kabam.lib.net.impl.SocketServer;
import kabam.rotmg.dialogs.control.CloseDialogsSignal;
import kabam.rotmg.dialogs.control.OpenDialogNoModalSignal;
import kabam.rotmg.game.signals.AddTextLineSignal;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.messaging.impl.outgoing.SorForgeRequest;

import org.swiftsuspenders.Injector;

import robotlegs.bender.bundles.mvcs.Mediator;

public class SorForgeMediator extends Mediator {


    [Inject]
    public var injector:Injector;
    [Inject]
    public var closeDialogs:CloseDialogsSignal;
    [Inject]
    public var socketServer:SocketServer;
    [Inject]
    public var messages:MessageProvider;
    [Inject]
    public var view:SorForgeModal;
    [Inject]
    public var gameSprite:AGameSprite;
    [Inject]
    public var openNoModalDialog:OpenDialogNoModalSignal;
    [Inject]
    public var addTextLine:AddTextLineSignal;



    override public function initialize():void {
        this.view.buyButton.addEventListener(MouseEvent.CLICK, this.onButtonLaunch);
    }

    override public function destroy():void {
        super.destroy();
    }

    protected function onButtonLaunch(_arg_1:MouseEvent):void {
        var _local_1:SorForgeRequest;
        _local_1 = (this.messages.require(GameServerConnection.SORFORGEREQUEST) as SorForgeRequest);
        _local_1.isForge_ = true;
        this.socketServer.sendMessage(_local_1);
        this.closeDialogs.dispatch();
    }


}
}//package kabam.rotmg.pets.view.components
