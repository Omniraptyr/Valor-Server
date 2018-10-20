package com.company.util {
import flash.utils.ByteArray;

public class MoreStringUtil {
    public static function hexStringToByteArray(str:String) : ByteArray {
        var byteArray:ByteArray = new ByteArray();
        var loops:int = 0;
        while (loops < str.length) {
            byteArray.writeByte(parseInt(str.substr(loops, 2), 16));
            loops += 2;
        }
        return byteArray;
    }

    public static function cmp(base:String, other:String) : Number {
        return base.localeCompare(other);
    }

    private static function trimWhitespace(str:String) : String {
        if (str == null)
            return "";

        return str.replace(/^\s+|\s+$/g, "");
    }

    public static function gcArray(arr:Array, sep:String) : String { //gc = grammatically correct,
        var endStr:String = "";                                      //best name i could come up with
        for (var i:int = 0; i < arr.length; i++) {                   //at 3 am
            var trimmedStr:String = trimWhitespace(arr[i]);
            if (arr.length == 1) endStr = trimmedStr;
            else {
                if (i != arr.length - 1) endStr += trimmedStr + ", ";
                else endStr += sep + " " + trimmedStr;
            }
        }
        return endStr;
    }
}
}
