package kabam.rotmg.game.view
{
   public class ArenaInfoItem
   {
       
      
      public var name:String;
      
      public var open:Boolean;
      
      public function ArenaInfoItem()
      {
         super();
      }
      
      public static function parse(param1:Object) : ArenaInfoItem
      {
         var _loc2_:ArenaInfoItem = new ArenaInfoItem();
         _loc2_.name = param1.name;
         _loc2_.open = param1.open;
         return _loc2_;
      }
   }
}
