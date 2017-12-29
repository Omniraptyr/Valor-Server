package kabam.rotmg.Market
{
   import flash.display.Sprite;
   import kabam.rotmg.pets.view.components.CaretakerQuerySpeechBubble;
   import kabam.rotmg.pets.view.components.CaretakerQueryDetailBubble;
   import flash.display.Bitmap;
   import flash.display.BitmapData;

import kabam.rotmg.pets.view.dialogs.CaretakerQueryDialog;

public class InfoDialogQuery extends Sprite
   {
       
      
      private const _0O_S_:CaretakerQuerySpeechBubble = _oy();
      
      private var _0kY_:CaretakerQueryDetailBubble;
      
      private const icon:Bitmap = _05V_();
      
      public function InfoDialogQuery()
      {
         this._0kY_ = this._A_c();
         super();
      }
      
      private function _oy() : CaretakerQuerySpeechBubble
      {
         var _loc1_:CaretakerQuerySpeechBubble = null;
         _loc1_ = new CaretakerQuerySpeechBubble(CaretakerQueryDialog.QUERY);
         _loc1_.x = 60;
         addChild(_loc1_);
         return _loc1_;
      }
      
      private function _A_c() : CaretakerQueryDetailBubble
      {
         var _loc1_:CaretakerQueryDetailBubble = null;
         _loc1_ = new CaretakerQueryDetailBubble();
         _loc1_.y = 60;
         return _loc1_;
      }
      
      private function _05V_() : Bitmap
      {
         var _loc1_:Bitmap = null;
         _loc1_ = new Bitmap(this._0b4());
         _loc1_.x = 4;
         _loc1_.y = 6;
         addChild(_loc1_);
         return _loc1_;
      }
      
      private function _0b4() : BitmapData
      {
         return new BitmapDataSpy(42,42,true,4278255360);
      }
      
      public function _070(param1:String) : void
      {
         this._0kY_ = this._A_c();
         this._0kY_.setText(param1);
         removeChild(this._0O_S_);
         addChild(this._0kY_);
      }
      
      public function _14E_() : void
      {
         removeChild(this._0kY_);
         addChild(this._0O_S_);
      }
      
      public function _0K_L_(param1:BitmapData) : void
      {
         this.icon.bitmapData = param1;
         this.icon.scaleX = 0.5;
         this.icon.scaleY = 0.5;
      }
   }
}
