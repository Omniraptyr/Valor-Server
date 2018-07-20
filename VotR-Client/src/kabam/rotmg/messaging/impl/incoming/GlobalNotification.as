package kabam.rotmg.messaging.impl.incoming {
import flash.utils.IDataInput;

public class GlobalNotification extends IncomingMessage
{

    public static const ADD_ARENA:int = 1;

    public static const DELETE_ARENA:int = 2;


    public var type:int;

    public var text:String;

    public function GlobalNotification(param1:uint, param2:Function)
    {
        super(param1,param2);
    }

    override public function parseFromInput(param1:IDataInput) : void
    {
        this.type = param1.readInt();
        this.text = param1.readUTF();
    }

    override public function toString() : String
    {
        return formatToString("GLOBAL_NOTIFICATION","type","text");
    }
}
}
