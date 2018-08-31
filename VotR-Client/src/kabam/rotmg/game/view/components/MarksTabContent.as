package kabam.rotmg.game.view.components {
import com.company.assembleegameclient.objects.Player;

import flash.display.Sprite;
import flash.filters.DropShadowFilter;

import kabam.rotmg.game.view.MarkDisplay;
import kabam.rotmg.game.view.NodeDisplay1;
import kabam.rotmg.game.view.NodeDisplay2;
import kabam.rotmg.game.view.NodeDisplay3;
import kabam.rotmg.game.view.NodeDisplay4;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;
import kabam.rotmg.ui.model.TabStripModel;

public class MarksTabContent extends Sprite {

    private var background:Sprite;
    private var nodetext:TextFieldDisplayConcrete;
    private var marktext:TextFieldDisplayConcrete;
    public var nodeDisplay1:NodeDisplay1;
    public var nodeDisplay2:NodeDisplay2;
    public var nodeDisplay3:NodeDisplay3;
    public var nodeDisplay4:NodeDisplay4;
    public var markDisplay:MarkDisplay;
    private var player:Player;

    public function MarksTabContent(_arg1:Player) {
        this.player = _arg1;
        this.background = new Sprite();this.nodetext = new TextFieldDisplayConcrete().setSize(14).setColor(0xFFFFFF).setBold(true);
        this.nodetext.setStringBuilder(new StaticStringBuilder("Nodes"));
        this.nodetext.filters = [new DropShadowFilter(0, 0, 0, 1, 4, 4, 2)];
        this.marktext = new TextFieldDisplayConcrete().setSize(14).setColor(0xFFFFFF).setBold(true);
        this.marktext.setStringBuilder(new StaticStringBuilder("Mark"));
        this.marktext.filters = [new DropShadowFilter(0, 0, 0, 1, 4, 4, 2)];
        super();
        this.addChildren();
        addChild(this.background);
        this.init(_arg1);
        this.positionChildren();
        this.showNodeDisplay();
    }
    private function addChildren():void {
        this.background.addChild(this.nodetext);
        this.background.addChild(this.marktext);
    }
    private function init(_arg1:Player):void {
        this.background.name = TabStripModel.MARKS;
    }
    private function showNodeDisplay():void {
        this.markDisplay = new MarkDisplay(player);
        this.markDisplay.x = this.marktext.x;
        this.markDisplay.y = this.marktext.y + 25;
        addChild(this.markDisplay);
        this.nodeDisplay1 = new NodeDisplay1(player);
        this.nodeDisplay1.x = this.nodetext.x;
        this.nodeDisplay1.y = this.nodetext.y + 20;
        addChild(this.nodeDisplay1);
        this.nodeDisplay2 = new NodeDisplay2(player);
        this.nodeDisplay2.x = this.nodeDisplay1.x + 40;
        this.nodeDisplay2.y = this.nodeDisplay1.y;
        addChild(this.nodeDisplay2);
        this.nodeDisplay3 = new NodeDisplay3(player);
        this.nodeDisplay3.x = this.nodeDisplay1.x;
        this.nodeDisplay3.y = this.nodeDisplay1.y + 40;
        addChild(this.nodeDisplay3);
        this.nodeDisplay4 = new NodeDisplay4(player);
        this.nodeDisplay4.x = this.nodeDisplay2.x;
        this.nodeDisplay4.y = this.nodeDisplay2.y + 40;
        addChild(this.nodeDisplay4);

    }
    private function positionChildren():void {
        this.nodetext.x = this.nodetext.x + 10;
        this.marktext.x = this.nodetext.x + 100;
    }

}
}
