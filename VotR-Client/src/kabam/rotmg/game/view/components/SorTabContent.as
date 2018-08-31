package kabam.rotmg.game.view.components {
import com.company.assembleegameclient.objects.Player;
import com.company.assembleegameclient.sound.SoundEffectLibrary;
import com.company.assembleegameclient.ui.DeprecatedTextButton;

import flash.display.Sprite;
import flash.events.MouseEvent;
import flash.filters.DropShadowFilter;

import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.dialogs.control.OpenDialogSignal;
import kabam.rotmg.game.view.FameWithdrawDisplay;
import kabam.rotmg.game.view.SorDisplay;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;
import kabam.rotmg.ui.model.TabStripModel;

public class SorTabContent extends Sprite {

    private var background:Sprite;
    private var storageText:TextFieldDisplayConcrete;
    private var sorDisplay:SorDisplay;
    private var fameDisplay:FameWithdrawDisplay;
    private var player:Player;
    public var constructButton:DeprecatedTextButton;
    public var withdrawButton:DeprecatedTextButton;
    public function SorTabContent(_arg1:Player) {
        this.player = _arg1;
        this.background = new Sprite();
        this.storageText = new TextFieldDisplayConcrete().setSize(16).setColor(0xFFFFFF).setBold(true);
        this.storageText.setStringBuilder(new StaticStringBuilder("Storage"));
        this.storageText.filters = [new DropShadowFilter(0, 0, 0, 1, 4, 4, 2)];
        super();
        this.addChildren();
        addChild(this.background);
        this.init(_arg1);
        this.positionChildren();
        this.showStorageDisplay();
        this.constructButton.addEventListener(MouseEvent.CLICK, this.onClick);
        this.withdrawButton.addEventListener(MouseEvent.CLICK, this.onClick);
    }
    private function addChildren():void {
        this.background.addChild(this.storageText);
    }
    private function init(_arg1:Player):void {
        this.background.name = TabStripModel.PETS;
    }
    private function showStorageDisplay():void {
        this.sorDisplay = new SorDisplay(player);
        this.sorDisplay.x = this.storageText.x;
        this.sorDisplay.y = this.storageText.y + 20;
        addChild(this.sorDisplay);
        this.constructButton = new DeprecatedTextButton(16, "Construct");
        this.constructButton.x = this.sorDisplay.x + 40;
        this.constructButton.y = this.sorDisplay.y;
        addChild(this.constructButton);

        this.fameDisplay = new FameWithdrawDisplay(player);
        this.fameDisplay.x = this.sorDisplay.x;
        this.fameDisplay.y = this.sorDisplay.y + 40;
        addChild(this.fameDisplay);
        this.withdrawButton = new DeprecatedTextButton(16, "Withdraw");
        this.withdrawButton.x = this.fameDisplay.x + 40;
        this.withdrawButton.y = this.fameDisplay.y;
        addChild(this.withdrawButton);

    }
    private function positionChildren():void {
        this.storageText.x = this.storageText.x + 10;
    }
    public function onClick(_arg_1:MouseEvent):void {
        var _local_2:OpenDialogSignal = StaticInjectorContext.getInjector().getInstance(OpenDialogSignal);
        SoundEffectLibrary.play("button_click");
    }

}
}
