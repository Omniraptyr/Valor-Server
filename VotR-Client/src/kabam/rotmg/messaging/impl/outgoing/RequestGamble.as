package kabam.rotmg.messaging.impl.outgoing {
import flash.utils.IDataOutput;

public class RequestGamble extends OutgoingMessage {

    public var name_:String;
    public var amount_:int;

    public function RequestGamble(_arg1:uint, _arg2:Function) {
        super(_arg1, _arg2);
    }

    override public function writeToOutput(_arg1:IDataOutput):void {
        _arg1.writeUTF(this.name_);
        _arg1.writeInt(this.amount_);
    }

    override public function toString():String {
        return (formatToString("REQUESTGAMBLE", "name_", "amount_"));
    }


}
}
