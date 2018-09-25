package kabam.rotmg.game.view.components {
import flash.events.MouseEvent;

import kabam.lib.net.api.MessageProvider;
import kabam.lib.net.impl.SocketServer;
import kabam.rotmg.messaging.impl.GameServerConnection;
import kabam.rotmg.messaging.impl.outgoing.QoLAction;

public class SorTabContentMediator {
    [Inject]
    public var view:SorTabContent;
    [Inject]
    public var socketServer:SocketServer;
    [Inject]
    public var messages:MessageProvider;


    public function initialize():void {
        this.view.constructButton.addEventListener(MouseEvent.CLICK, this.onConstructClick);
    }

    protected function onConstructClick(e:MouseEvent):void {
        var pkt:QoLAction;
        pkt = (this.messages.require(GameServerConnection.QOLACTION) as QoLAction);
        pkt.actionId_ = 1;
        this.socketServer.sendMessage(pkt);
    }
}
}
