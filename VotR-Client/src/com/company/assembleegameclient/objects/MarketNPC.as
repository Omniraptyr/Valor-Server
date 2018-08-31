package com.company.assembleegameclient.objects
{
import com.company.assembleegameclient.game.GameSprite;
import com.company.assembleegameclient.ui.panels.Panel;
import com.company.assembleegameclient.ui.tooltip.TextToolTip;
import com.company.assembleegameclient.ui.tooltip.ToolTip;

import kabam.rotmg.market.MarketNPCPanel;

public class MarketNPC extends GameObject implements IInteractiveObject
   {
       
      
      public function MarketNPC(param1:XML)
      {
         super(param1);
         isInteractive_ = true;
      }
      
      public function getTooltip() : ToolTip
      {
         return new TextToolTip(3552822,10197915,"Marketplace","Open",200);
      }

       public function getPanel(_arg_1:GameSprite):Panel {
           return (new MarketNPCPanel(_arg_1, objectType_));
       }
   }
}
