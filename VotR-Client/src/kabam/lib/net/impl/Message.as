package kabam.lib.net.impl {
import flash.utils.IDataInput;
import flash.utils.IDataOutput;

public class Message {
    public var pool:MessagePool;
    public var prev:Message;
    public var next:Message;
    private var isCallback:Boolean;
    public var id:uint;
    public var callback:Function;

    public function Message(id:uint, callback:Function = null) {
        this.id = id;
        this.isCallback = callback != null;
        this.callback = callback;
    }

    public function parseFromInput(data:IDataInput):void {
    }

    public function writeToOutput(data:IDataOutput):void {
    }

    public function toString():String {
        return this.formatToString("MESSAGE", "id");
    }

    protected function formatToString(input:String, ..._args):String {
        var str:String = "[" + input;
        var loops:int = 0;
        while (loops < _args.length) {
            str += " " + _args[loops] + '="' + this[_args[loops]] + '"';
            loops++;
        }
        return str + "]";
    }

    public function consume():void {
        this.isCallback && this.callback(this);
        this.prev = null;
        this.next = null;
        this.pool.append(this);
    }
}
}
