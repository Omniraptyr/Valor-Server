package com.company.assembleegameclient.screens {
import com.company.assembleegameclient.appengine.SavedCharactersList;
import com.company.assembleegameclient.constants.ScreenTypes;
import com.company.assembleegameclient.objects.ObjectLibrary;
import com.company.rotmg.graphics.ScreenGraphic;

import flash.display.Sprite;
import flash.events.Event;
import flash.events.MouseEvent;

import kabam.rotmg.core.model.PlayerModel;
import kabam.rotmg.game.view.CreditDisplay;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.ui.view.components.ScreenBase;

import org.osflash.signals.Signal;

public class NewCharacterScreen extends Sprite {

    private var backButton_:TitleMenuOption;
    private var creditDisplay_:CreditDisplay;
    private var boxes_:Object;
    public var tooltip:Signal;
    public var close:Signal;
    public var selected:Signal;
    public var buy:Signal;
    private var isInitialized:Boolean = false;

    public function NewCharacterScreen() {
        this.boxes_ = {};
        super();
        this.tooltip = new Signal(Sprite);
        this.selected = new Signal(int);
        this.close = new Signal();
        this.buy = new Signal(int);
        addChild(new ScreenBase());
        addChild(new AccountScreen());
        addChild(new ScreenGraphic());
    }

    public function initialize(_arg_1:PlayerModel):void {
        var _local_2:int;
        var _local_3:XML;
        var _local_4:int;
        var _local_5:String;
        var _local_6:Boolean;
        var _local_7:CharacterBox;
        if (this.isInitialized) {
            return;
        }
        this.isInitialized = true;
        this.backButton_ = new TitleMenuOption(ScreenTypes.BACK, 36, false);
        this.backButton_.addEventListener(MouseEvent.CLICK, this.onBackClick);
        this.backButton_.setVerticalAlign(TextFieldDisplayConcrete.MIDDLE);
        addChild(this.backButton_);
        this.creditDisplay_ = new CreditDisplay();
        this.creditDisplay_.draw(_arg_1.getCredits(), _arg_1.getFame(), _arg_1.getOnrane(), _arg_1.getKantos());
        addChild(this.creditDisplay_);
        _local_2 = 0;
        while (_local_2 < ObjectLibrary.playerChars_.length) {
            _local_3 = ObjectLibrary.playerChars_[_local_2];
            _local_4 = int(_local_3.@type);
            _local_5 = _local_3.@id;
            if (!_arg_1.isClassAvailability(_local_5, SavedCharactersList.UNAVAILABLE)) {
                _local_6 = _arg_1.isClassAvailability(_local_5, SavedCharactersList.UNRESTRICTED);
                _local_7 = new CharacterBox(_local_3, _arg_1.getCharStats()[_local_4], _arg_1, _local_6);
                _local_7.x = (((50 + (110 * int((_local_2 % 7)))) + 70) - _local_7.width);
                _local_7.y = (70 + (110 * int((_local_2 / 7))));
                this.boxes_[_local_4] = _local_7;
                _local_7.addEventListener(MouseEvent.ROLL_OVER, this.onCharBoxOver);
                _local_7.addEventListener(MouseEvent.ROLL_OUT, this.onCharBoxOut);
                _local_7.characterSelectClicked_.add(this.onCharBoxClick);
                _local_7.buyButtonClicked_.add(this.onBuyClicked);
                if ((((_local_4 == 784)) && (!(_local_7.available_)))) {
                    _local_7.setSale(75);
                }
                addChild(_local_7);
            }
            _local_2++;
        }
        this.backButton_.x = ((stage.stageWidth / 2) - (this.backButton_.width / 2));
        this.backButton_.y = 550;
        this.creditDisplay_.x = stage.stageWidth;
        this.creditDisplay_.y = 20;
    }

    private function onBackClick(_arg1:Event):void {
        this.close.dispatch();
    }

    private function onCharBoxOver(_arg1:MouseEvent):void {
        var _local2:CharacterBox = (_arg1.currentTarget as CharacterBox);
        _local2.setOver(true);
        this.tooltip.dispatch(_local2.getTooltip());
    }

    private function onCharBoxOut(_arg1:MouseEvent):void {
        var _local2:CharacterBox = (_arg1.currentTarget as CharacterBox);
        _local2.setOver(false);
        this.tooltip.dispatch(null);
    }

    private function onCharBoxClick(_arg1:MouseEvent):void {
        this.tooltip.dispatch(null);
        var _local2:CharacterBox = (_arg1.currentTarget.parent as CharacterBox);
        if (!_local2.available_) {
            return;
        }
        var _local3:int = _local2.objectType();
        this.selected.dispatch(_local3);
    }

    public function updateCreditsAndFame(_arg_1:int, _arg_2:int, _arg_3:int, _arg_4:int):void {
        this.creditDisplay_.draw(_arg_1, _arg_2, _arg_3, _arg_4);
    }

    public function update(_arg1:PlayerModel):void {
        var _local3:XML;
        var _local4:int;
        var _local5:String;
        var _local6:Boolean;
        var _local7:CharacterBox;
        var _local2:int;
        while (_local2 < ObjectLibrary.playerChars_.length) {
            _local3 = ObjectLibrary.playerChars_[_local2];
            _local4 = int(_local3.@type);
            _local5 = String(_local3.@id);
            if (!_arg1.isClassAvailability(_local5, SavedCharactersList.UNAVAILABLE)) {
                _local6 = _arg1.isClassAvailability(_local5, SavedCharactersList.UNRESTRICTED);
                _local7 = this.boxes_[_local4];
                if (_local7) {
                    _local7.setIsBuyButtonEnabled(true);
                    if (((_local6) || (_arg1.isLevelRequirementsMet(_local4)))) {
                        _local7.unlock();
                    }
                }
            }
            _local2++;
        }
    }

    private function onBuyClicked(_arg1:MouseEvent):void {
        var _local3:int;
        var _local2:CharacterBox = (_arg1.currentTarget.parent as CharacterBox);
        if (((_local2) && (!(_local2.available_)))) {
            _local3 = int(_local2.playerXML_.@type);
            _local2.setIsBuyButtonEnabled(false);
            this.buy.dispatch(_local3);
        }
    }


}
}
