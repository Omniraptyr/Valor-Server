package kabam.rotmg.game.view.components {
import com.company.assembleegameclient.game.AlertStatusModel;
import com.company.assembleegameclient.game.GiftStatusModel;
import com.company.assembleegameclient.objects.Player;
import com.company.assembleegameclient.sound.SoundEffectLibrary;

import flash.events.MouseEvent;

import kabam.lib.net.api.MessageProvider;

import kabam.lib.net.impl.SocketServer;

import kabam.rotmg.account.core.Account;
import kabam.rotmg.dialogs.control.CloseDialogsSignal;

import kabam.rotmg.game.signals.UpdateAlertStatusDisplaySignal;

import kabam.rotmg.game.signals.UpdateGiftStatusDisplaySignal;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.messaging.impl.outgoing.AlertNotice;
import kabam.rotmg.messaging.impl.outgoing.ForgeItem;
import kabam.rotmg.messaging.impl.outgoing.QoLAction;

import org.swiftsuspenders.Injector;

public class SorTabContentMediator {

    [Inject]
    public var view:SorTabContent;
    [Inject]
    public var account:Account;
    [Inject]
    public var injector:Injector;
    [Inject]
    public var closeDialogs:CloseDialogsSignal;
    [Inject]
    public var socketServer:SocketServer;
    [Inject]
    public var messages:MessageProvider;


    public function initialize():void {
        this.view.constructButton.addEventListener(MouseEvent.CLICK, this.onButtonClick1);
        this.view.withdrawButton.addEventListener(MouseEvent.CLICK, this.onButtonClick2);
    }
    protected function onButtonClick1(_arg_1:MouseEvent):void {
        var _local_1:QoLAction;
        _local_1 = (this.messages.require(GameServerConnection.QOLACTION) as QoLAction);
        _local_1.actionId_ = 1;
        this.socketServer.sendMessage(_local_1);
    }
    protected function onButtonClick2(_arg_1:MouseEvent):void {
        var _local_1:QoLAction;
        _local_1 = (this.messages.require(GameServerConnection.QOLACTION) as QoLAction);
        _local_1.actionId_ = 2;
        this.socketServer.sendMessage(_local_1);
    }


}
}
