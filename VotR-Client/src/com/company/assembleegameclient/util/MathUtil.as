package com.company.assembleegameclient.util
{
   public class MathUtil
   {
       
      
      public function MathUtil()
      {
         super();
      }
      
      public static function round(_arg_1:Number, _arg_2:int = 0) : Number
      {
         var _local_3:int = Math.pow(10,_arg_2);
         return Math.round(_arg_1 * _local_3) / _local_3;
      }
   }
}
