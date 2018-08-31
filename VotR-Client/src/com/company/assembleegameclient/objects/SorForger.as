package com.company.assembleegameclient.objects {
import com.company.assembleegameclient.game.GameSprite;
import com.company.assembleegameclient.ui.panels.Panel;

import kabam.rotmg.sorForge.components.SorForgePanel;

public class SorForger extends GameObject implements IInteractiveObject {

    public function SorForger(_arg_1:XML) {
        super(_arg_1);
        isInteractive_ = true;
    }

    public function getPanel(_arg_1:GameSprite):Panel {
        return (new SorForgePanel(_arg_1, objectType_));
    }


}
}//package com.company.assembleegameclient.objects
