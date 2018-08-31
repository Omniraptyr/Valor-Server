package kabam.rotmg.markPurchaser.components {
import com.company.assembleegameclient.game.GameSprite;
import com.company.assembleegameclient.ui.DeprecatedTextButton;
import com.company.assembleegameclient.ui.panels.Panel;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.assembleegameclient.util.redrawers.GlowRedrawer;
import com.company.util.AssetLibrary;
import com.company.util.BitmapUtil;

import flash.display.Bitmap;
import flash.display.BitmapData;

import kabam.rotmg.pets.util.PetsViewAssetFactory;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;

public class MarksPanel extends Panel {

    private const titleText:TextFieldDisplayConcrete = PetsViewAssetFactory.returnTextfield(0xFFFFFF, 16, true);

    internal var pageIcon:BitmapData = TextureRedrawer.resize(AssetLibrary.getImageFromSet("d3LofiObjEmbed", 880), null, 100, true, 0, 0);
    private var icon:Bitmap;
    private var title:String = "Mark Shop";
    private var buttonText:String = "Offers";
    private var objectType:int;
    internal var offersButton:DeprecatedTextButton;

    public function MarksPanel(_arg_1:GameSprite, _arg_2:int) {
        super(_arg_1);
        this.objectType = _arg_2;
        this.titleText.setStringBuilder(new LineBuilder().setParams(this.title));
        this.titleText.x = 48;
        this.titleText.y = 28;
        addChild(this.titleText);
        this.offersButton = new DeprecatedTextButton(16, this.buttonText);
        this.offersButton.textChanged.addOnce(this.alignButton);
        addChild(this.offersButton);
    }

    private static function cropAndGlowIcon(_arg_1:BitmapData):BitmapData {
        _arg_1 = GlowRedrawer.outlineGlow(_arg_1, 0xFFFFFFFF);
        return (BitmapUtil.cropToBitmapData(_arg_1, 10, 10, (_arg_1.width - 20), (_arg_1.height - 20)));
    }

    public function init():void {
        this.icon = new Bitmap(cropAndGlowIcon(this.pageIcon));
        this.icon.x = -4;
        this.icon.y = -8;
        addChild(this.icon);
    }

    private function alignButton():void {
        this.offersButton.x = ((WIDTH / 2) - (this.offersButton.width / 2));
        this.offersButton.y = ((HEIGHT - this.offersButton.height) - 4);
    }


}
}//package kabam.rotmg.pets.view.components
