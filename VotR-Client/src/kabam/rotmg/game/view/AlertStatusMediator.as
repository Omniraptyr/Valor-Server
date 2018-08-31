package kabam.rotmg.game.view {
import com.company.assembleegameclient.objects.Player;
import com.company.assembleegameclient.sound.SoundEffectLibrary;

import flash.events.MouseEvent;

import kabam.lib.net.api.MessageProvider;
import kabam.lib.net.impl.SocketServer;
import kabam.rotmg.account.core.Account;
import kabam.rotmg.game.signals.UpdateAlertStatusDisplaySignal;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.messaging.impl.outgoing.AlertNotice;
import kabam.rotmg.ui.signals.UpdateHUDSignal;

import robotlegs.bender.bundles.mvcs.Mediator;

public class AlertStatusMediator extends Mediator {
    [Inject]
    public var updateAlertStatusDisplay:UpdateAlertStatusDisplaySignal;
    [Inject]
    public var view:AlertStatusDisplay;
    [Inject]
    public var account:Account;
    [Inject]
    public var updateHUD:UpdateHUDSignal;
    [Inject]
    public var socketServer:SocketServer;
    [Inject]
    public var messages:MessageProvider;

    override public function initialize():void {
        this.updateAlertStatusDisplay.add(this.onAlertUpdate);
        this.updateHUD.add(this.onUpdateHUD);
        if (this.account.isRegistered()) {
            this.view.drawAsOpen();
        } else {
            this.view.drawAsClosed();
        }
        this.view.addEventListener(MouseEvent.CLICK, this.onButtonClick);
    }

    override public function destroy():void {
        this.view.removeEventListener(MouseEvent.CLICK, this.onButtonClick);
        this.updateAlertStatusDisplay.remove(this.onAlertUpdate);
        this.updateHUD.remove(this.onUpdateHUD);
    }

    private function onUpdateHUD(plr:Player):void {
        this.view.updateAlertNum(plr.alertToken_);
    }

    private function onAlertUpdate():void {
        if (this.account.isRegistered()) {
            this.view.drawAsOpen();
        } else {
            this.view.drawAsClosed();
        }
    }

    protected function onButtonClick(e:MouseEvent):void {
        SoundEffectLibrary.play("button_click");
        var alertNotice:AlertNotice;
        alertNotice = (this.messages.require(GameServerConnection.ALERTNOTICE) as AlertNotice);
        alertNotice.alert_ = true;
        this.socketServer.sendMessage(alertNotice);
    }
}
}
