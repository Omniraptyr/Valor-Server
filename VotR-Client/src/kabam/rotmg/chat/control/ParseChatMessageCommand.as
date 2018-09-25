package kabam.rotmg.chat.control {
import com.company.assembleegameclient.objects.GameObject;
import com.company.assembleegameclient.objects.ObjectLibrary;
import com.company.assembleegameclient.parameters.Parameters;

import kabam.rotmg.account.core.Account;
import kabam.rotmg.appengine.api.AppEngineClient;
import kabam.rotmg.build.api.BuildData;
import kabam.rotmg.chat.model.ChatMessage;
import kabam.rotmg.dailyLogin.model.DailyLoginModel;
import kabam.rotmg.game.signals.AddTextLineSignal;
import kabam.rotmg.text.model.TextKey;
import kabam.rotmg.ui.model.HUDModel;

public class ParseChatMessageCommand {

    [Inject]
    public var data:String;
    [Inject]
    public var hudModel:HUDModel;
    [Inject]
    public var addTextLine:AddTextLineSignal;
    [Inject]
    public var client:AppEngineClient;
    [Inject]
    public var account:Account;
    [Inject]
    public var buildData:BuildData;
    [Inject]
    public var dailyLoginModel:DailyLoginModel;


    public function execute():void {
        switch (this.data) {
            case "/c":
            case "/class":
            case "/classes":
                var classCount:Object = {};
                var loops:uint = 0;
                var go:GameObject = null;
                var classList:String = "";
                var goType:* = null;
                for each (go in this.hudModel.gameSprite.map.goDict_) {
                    if (go.props_.isPlayer_) {
                        classCount[go.objectType_] = (classCount[go.objectType_] != undefined ? classCount[go.objectType_] + 1 : 1);
                        loops++;
                    }
                }

                for (goType in classCount) {
                    classList += " " + ObjectLibrary.typeToDisplayId_[goType] + ": " + classCount[goType];
                }
                this.addTextLine.dispatch(ChatMessage.make("","Classes online (" + loops + "):" + classList));
                break;
            default:
                this.hudModel.gameSprite.gsc_.playerText(this.data);
        }
    }


}
}
