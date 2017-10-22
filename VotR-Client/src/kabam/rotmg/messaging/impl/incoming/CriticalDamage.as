package kabam.rotmg.messaging.impl.incoming {
import flash.utils.IDataInput;

public class CriticalDamage extends IncomingMessage {

    public var isCritical_:Boolean;
    public var criticalHit_:Number;

    public function CriticalDamage(_arg_1:uint, _arg_2:Function) {
        super(_arg_1, _arg_2);
    }

    override public function parseFromInput(_arg_1:IDataInput):void {

        this.isCritical_ = _arg_1.readBoolean();
        this.criticalHit_ = _arg_1.readFloat();

    }

    override public function toString():String {
        return (formatToString("CRITICALDAMAGE", "isCritical_", "criticalHit_"));
    }


}
}//package kabam.rotmg.messaging.impl.incoming
