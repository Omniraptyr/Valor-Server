package kabam.rotmg.market {
import com.company.assembleegameclient.game.GameSprite;
import com.company.assembleegameclient.ui.DeprecatedTextButton;
import com.company.assembleegameclient.ui.panels.Panel;

import flash.display.Bitmap;

import kabam.rotmg.pets.util.PetsViewAssetFactory;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;

public class MarketNPCPanel extends Panel {
    private const title:TextFieldDisplayConcrete
	    = PetsViewAssetFactory.returnTextfield(16777215, 16, true);
	private var icon:Bitmap;
    private var _title:String = "Marketplace";
    private var _manage:String = "Manage";
	internal var manageBtn:DeprecatedTextButton;
    internal var type:uint;
	
    public function MarketNPCPanel(gs:GameSprite, type:uint) {
        this.type = type;
        super(gs);
    }
	
    private function positionAndAddText() : void {
        this.icon.x = 16;
        this.icon.y = -2;
        this.title.setStringBuilder(new StaticStringBuilder(this._title));
        this.title.x = 69;
        this.title.y = 28;
        addChild(this.title);
    }
	
    private function addManageBtn() : void {
        this.manageBtn = new DeprecatedTextButton(16, this._manage, 0, true);
        this.manageBtn.textChanged.addOnce(this.update);
        addChild(this.manageBtn);
    }
	
    public function init() : void {
        this.scaleIcon();
        this.positionAndAddText();
        this.addManageBtn();
    }
    
    private function scaleIcon() : void {
        this.icon = PetsViewAssetFactory.returnCaretakerBitmap(this.type);
        this.icon.scaleX = 0.5;
        this.icon.scaleY = 0.5;
        addChild(this.icon);
        this.icon.x = 5;
    }
    
    private function update() : void {
        if(this.manageBtn && contains(this.manageBtn)) {
            this.manageBtn.x = WIDTH / 2 - this.manageBtn.width / 2;
            this.manageBtn.y = HEIGHT - this.manageBtn.height - 4;
        }
    }
}
}