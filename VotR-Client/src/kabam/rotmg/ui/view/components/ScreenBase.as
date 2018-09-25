package kabam.rotmg.ui.view.components {
import com.company.assembleegameclient.ui.SoundIcon;

import flash.display.Sprite;

public class ScreenBase extends Sprite {
    private static var TitleScreenBackground:Class = ScreenBase_TitleScreenBackground;
    public function ScreenBase() {
        super();
        addChild(new TitleScreenBackground());
        addChild(new DarkLayer());
        addChild(new SoundIcon());
    }
}
}
