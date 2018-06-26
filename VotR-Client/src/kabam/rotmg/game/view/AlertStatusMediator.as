package kabam.rotmg.game.view {
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

import org.swiftsuspenders.Injector;

public class AlertStatusMediator {

    [Inject]
    public var updateAlertStatusDisplay:UpdateAlertStatusDisplaySignal;
    [Inject]
    public var view:AlertStatusDisplay;
    [Inject]
    public var alertStatusModel:AlertStatusModel;
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
    [Inject]

    public function initialize():void {
        this.updateAlertStatusDisplay.add(this.onLootboxUpdate);
        if (this.account.isRegistered()) {
            this.view.drawAsOpen();
        }
        else {
            this.view.drawAsClosed();
        }
        this.view..addEventListener(MouseEvent.CLICK, this.onButtonClick);
    }

    private function onLootboxUpdate():void {
        if (this.account.isRegistered()) {
            this.view.drawAsOpen();
        }
        else {
            this.view.drawAsClosed();
        }
    }

    protected function onButtonClick(_arg_1:MouseEvent):void {
        SoundEffectLibrary.play("button_click");
        var _local_1:AlertNotice;
        _local_1 = (this.messages.require(GameServerConnection.ALERTNOTICE) as AlertNotice);
        _local_1.alert_ = true;
        this.socketServer.sendMessage(_local_1);
    }


}
}
