package com.company.assembleegameclient.util
{
import flash.filters.DropShadowFilter;
import flash.filters.GlowFilter;

public class FilterUtil
   {
      
      private static const STANDARD_DROP_SHADOW_FILTER:Array = [new DropShadowFilter(0,0,0,0.5,12,12)];
      
      private static const STANDARD_OUTLINE_FILTER:Array = [new GlowFilter(0,1,2,2,10,1)];
       
      
      public function FilterUtil()
      {
         super();
      }
      
      public static function getStandardDropShadowFilter() : Array
      {
         return STANDARD_DROP_SHADOW_FILTER;
      }
      
      public static function getTextOutlineFilter() : Array
      {
         return STANDARD_OUTLINE_FILTER;
      }
   }
}
