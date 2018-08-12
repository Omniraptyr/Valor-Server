package kabam.rotmg.messaging.impl.incoming {
import flash.utils.IDataInput;

public class GambleStart extends IncomingMessage {

    public var amount_:int;
    public var name_:String;

    public function GambleStart(_arg1:uint, _arg2:Function) {
        super(_arg1, _arg2);
    }

    override public function parseFromInput(_arg1:IDataInput):void {
        this.amount_ = _arg1.readInt();
        this.name_ = _arg1.readUTF();

    }

    override public function toString():String {
        return (formatToString("GAMBLESTART", "amount_", "name_"));
    }


}
}
