package kabam.rotmg.messaging.impl.incoming{

import flash.utils.IDataInput;

public class UnboxResultPacket extends IncomingMessage
{

    public function UnboxResultPacket(_arg_1:uint, _arg_2:Function)
    {
        this.items_ = new Vector.<int>();
        super(_arg_1, _arg_2);
    }

    public var items_:Vector.<int>;

    override public function parseFromInput(_arg1:IDataInput):void
    {
        this.items_.length = 0;
        var _local1:int;
        var _local2:int = _arg1.readShort();
        this.items_.length = _local2;
        for(_local1 = 0; _local1 < _local2; _local1++)
        {
            this.items_[_local1] = _arg1.readInt();
        }

    }

    override public function toString():String
    {
        return (formatToString("UNBOXRESULT", "items_"));
    }

}
}