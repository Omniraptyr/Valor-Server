package kabam.rotmg.messaging.impl.outgoing {
import flash.utils.IDataOutput;

public class SorForgeRequest extends OutgoingMessage {

    public var isForge_:Boolean;

    public function SorForgeRequest(_arg1:uint, _arg2:Function) {
        super(_arg1, _arg2);
    }

    override public function writeToOutput(_arg1:IDataOutput):void {
        _arg1.writeBoolean(this.isForge_);
    }

    override public function toString():String {
        return (formatToString("SORFORGEREQUEST", "isForge_"));
    }


}
}
