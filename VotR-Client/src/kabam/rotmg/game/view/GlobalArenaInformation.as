package kabam.rotmg.game.view
{
import com.adobe.serialization.json.JSON;
import flash.utils.Dictionary;
import kabam.rotmg.messaging.impl.incoming.GlobalNotification;

public class GlobalArenaInformation
   {
       
      
      public var games:Dictionary;
      
      public function GlobalArenaInformation()
      {
         super();
      }
      
      public function reset() : void
      {

         this.games = new Dictionary();
      }
      
      public function globalNotification(param1:GlobalNotification) : void
      {
         var _loc2_:ArenaInfoItem = null;
         if(param1.type == GlobalNotification.ADD_ARENA)
         {
            _loc2_ = ArenaInfoItem.parse(com.adobe.serialization.json.JSON.decode(param1.text));
            this.games[_loc2_.name] = _loc2_;
         }
         if(param1.type == GlobalNotification.DELETE_ARENA)
         {
            delete this.games[param1.text];
         }
      }
   }
}
