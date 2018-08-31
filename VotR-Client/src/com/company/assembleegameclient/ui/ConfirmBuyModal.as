package com.company.assembleegameclient.ui {
import com.company.assembleegameclient.objects.SellableObject;
import com.company.assembleegameclient.util.Currency;

import flash.display.Sprite;
import flash.events.Event;
import flash.events.MouseEvent;

import kabam.rotmg.fortune.components.ItemWithTooltip;
import kabam.rotmg.pets.util.PetsViewAssetFactory;
import kabam.rotmg.pets.view.components.DialogCloseButton;
import kabam.rotmg.pets.view.components.PopupWindowBackground;
import kabam.rotmg.text.model.TextKey;
import kabam.rotmg.text.view.TextFieldConcreteBuilder;
import kabam.rotmg.util.components.LegacyBuyButton;

import org.osflash.signals.Signal;
import org.osflash.signals.natives.NativeSignal;

public class ConfirmBuyModal extends Sprite {
    public static const WIDTH:int = 280;
    public static const HEIGHT:int = 240;
    public static const TEXT_MARGIN:int = 20;

    public static var free:Boolean = true;

    private const closeButton:DialogCloseButton = PetsViewAssetFactory.returnCloseButton(ConfirmBuyModal.WIDTH);
    private const buyButton:LegacyBuyButton = new LegacyBuyButton(TextKey.SELLABLEOBJECTPANEL_BUY, 16, 0, Currency.INVALID);

    private var buyButtonClicked:NativeSignal;
    private var availableInventoryNumber:int;
    private var owner_:SellableObject;
    public var buyItem:Signal;
    public var open:Boolean;
    public var buttonWidth:int;

    public function ConfirmBuyModal(_arg1:Signal, _arg2:SellableObject, _arg3:Number, _arg4:int):void {
        var _local6:TextFieldConcreteBuilder;
        var _local8:ItemWithTooltip;
        super();
        ConfirmBuyModal.free = false;
        this.buyItem = _arg1;
        this.owner_ = _arg2;
        this.buttonWidth = _arg3;
        this.availableInventoryNumber = _arg4;
        this.events();
        addEventListener(Event.REMOVED_FROM_STAGE, this.onRemovedFromStage);
        this.positionAndStuff();
        this.addChildren();
        this.buyButton.setPrice(this.owner_.price_, this.owner_.currency_);
        var _local5:String = this.owner_.soldObjectName();
        _local6 = new TextFieldConcreteBuilder();
        _local6.containerMargin = TEXT_MARGIN;
        _local6.containerWidth = WIDTH;
        addChild(_local6.getLocalizedTextObject(TextKey.BUY_CONFIRMATION_TITLE, TEXT_MARGIN, 5));
        addChild(_local6.getLocalizedTextObject(TextKey.BUY_CONFIRMATION_DESC, TEXT_MARGIN, 40));
        addChild(_local6.getLocalizedTextObject(_local5, TEXT_MARGIN, 90));
        if (this.owner_.getSellableType() != -1) {
            _local8 = new ItemWithTooltip(this.owner_.getSellableType(), 128);
        }
        _local8.x = (((WIDTH * 1) / 2) - (_local8.width / 2));
        _local8.y = 100;
        addChild(_local8);
        this.open = true;
    }

    private static function makeModalBackground(_arg1:int, _arg2:int):PopupWindowBackground {
        var _local3:PopupWindowBackground = new PopupWindowBackground();
        _local3.draw(_arg1, _arg2);
        _local3.divide(PopupWindowBackground.HORIZONTAL_DIVISION, 30);
        return (_local3);
    }

    private function positionAndStuff():void {
        var _local1:int = -300;
        var _local2:int = -200;
        this.x = (_local1 + ((-1 * ConfirmBuyModal.WIDTH) * 0.5));
        this.y = (_local2 + ((-1 * ConfirmBuyModal.HEIGHT) * 0.5));
        this.buyButton.x = (this.buyButton.x + 35);
        this.buyButton.y = (this.buyButton.y + 195);
        this.buyButton.x = ((WIDTH / 2) - (this.buttonWidth / 2));
    }

    private function events():void {
        this.closeButton.clicked.add(this.onCloseClick);
        this.buyButtonClicked = new NativeSignal(this.buyButton, MouseEvent.CLICK, MouseEvent);
        this.buyButtonClicked.add(this.onBuyClick);
    }

    private function addChildren():void {
        addChild(makeModalBackground(ConfirmBuyModal.WIDTH, ConfirmBuyModal.HEIGHT));
        addChild(this.closeButton);
        addChild(this.buyButton);
    }

    public function onCloseClick():void {
        this.close();
    }

    public function onBuyClick(_arg1:MouseEvent):void {
        this.buyItem.dispatch(this.owner_);
        this.close();
    }

    private function close():void {
        parent.removeChild(this);
        ConfirmBuyModal.free = true;
        this.open = false;
    }

    private function onRemovedFromStage(_arg1:Event):void {
        ConfirmBuyModal.free = true;
        this.open = false;
    }
}
}
