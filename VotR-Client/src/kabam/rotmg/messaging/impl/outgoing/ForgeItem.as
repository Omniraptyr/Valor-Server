package kabam.rotmg.messaging.impl.outgoing {
import flash.utils.IDataOutput;

import kabam.rotmg.messaging.impl.data.SlotObjectData;

public class ForgeItem extends OutgoingMessage {

    public function ForgeItem(_arg_1:uint, _arg_2:Function) {
        super(_arg_1, _arg_2);
    }

    public var sor_:SlotObjectData
    public var shard_:SlotObjectData


    override public function writeToOutput(_arg1:IDataOutput):void {
        this.sor_.writeToOutput(_arg1);
        this.shard_.writeToOutput(_arg1);

    }

    override public function toString():String {
        return formatToString("FORGEITEM", "sor_", "shard_");
    }
}
}
