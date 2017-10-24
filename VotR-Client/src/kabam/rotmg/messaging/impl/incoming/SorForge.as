package kabam.rotmg.messaging.impl.incoming {
import flash.utils.IDataInput;

public class SorForge extends IncomingMessage {

    public var isForge:Boolean;

    public function SorForge(_arg_1:uint, _arg_2:Function) {
        super(_arg_1, _arg_2);
    }

    override public function parseFromInput(_arg_1:IDataInput):void {

        this.isForge = _arg_1.readBoolean();

    }

    override public function toString():String {
        return (formatToString("SORFORGE", "isForge"));
    }


}
}//package kabam.rotmg.messaging.impl.incoming
