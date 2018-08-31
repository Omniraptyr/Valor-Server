package kabam.rotmg.sorForge {
import com.company.assembleegameclient.sound.SoundEffectLibrary;
import com.company.assembleegameclient.util.Currency;

import flash.display.DisplayObject;
import flash.display.Sprite;
import flash.events.Event;
import flash.events.MouseEvent;
import flash.filters.DropShadowFilter;
import flash.filters.GlowFilter;
import flash.geom.ColorTransform;
import flash.text.TextFieldAutoSize;
import flash.text.TextFormatAlign;

import kabam.rotmg.account.core.view.EmptyFrame;
import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.dialogs.control.FlushPopupStartupQueueSignal;
import kabam.rotmg.pets.view.components.PopupWindowBackground;
import kabam.rotmg.text.model.FontModel;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;
import kabam.rotmg.util.components.LegacyBuyButton;

public class SorForgeModal extends EmptyFrame {

    public static const MODAL_WIDTH:int = 240;
    public static const MODAL_HEIGHT:int = 250;
    private static const OVER_COLOR_TRANSFORM:ColorTransform = new ColorTransform(1, (220 / 0xFF), (133 / 0xFF));
    private static const DROP_SHADOW_FILTER:DropShadowFilter = new DropShadowFilter(0, 0, 0);
    private static const GLOW_FILTER:GlowFilter = new GlowFilter(0xFF0000, 1, 11, 5);
    private static const filterWithGlow:Array = [DROP_SHADOW_FILTER, GLOW_FILTER];
    private static const filterNoGlow:Array = [DROP_SHADOW_FILTER];


    public static var backgroundImageEmbed:Class = SorForger_backgroundImageEmbed;
    public static var modalWidth:int = MODAL_WIDTH;//440
    public static var modalHeight:int = MODAL_HEIGHT;//400

    private var fontModel:FontModel;
    public var buyButton:LegacyBuyButton;
    private var triggeredOnStartup:Boolean;
    private var sorPic:SorForge_ImageEmbed;

    public function SorForgeModal(_arg1:Boolean = false) {
        this.triggeredOnStartup = _arg1;
        this.fontModel = StaticInjectorContext.getInjector().getInstance(FontModel);
        modalWidth = MODAL_WIDTH;
        modalHeight = MODAL_HEIGHT;
        super(modalWidth, modalHeight);
        this.setCloseButton(true);
        this.setTitle("Ascend?", true);
        addEventListener(Event.ADDED_TO_STAGE, this.onAdded);
        addEventListener(Event.REMOVED_FROM_STAGE, this.destroy);
        closeButton.clicked.add(this.onCloseButtonClicked);
    }

    public static function getText(_arg1:String, _arg2:int, _arg3:int, _arg4:Boolean):TextFieldDisplayConcrete {
        var _local5:TextFieldDisplayConcrete = new TextFieldDisplayConcrete().setSize(18).setColor(0xFFFFFF).setTextWidth(((SorForgeModal.modalWidth - (TEXT_MARGIN * 2)) - 10));
        _local5.setBold(true);
        if (_arg4) {
            _local5.setStringBuilder(new StaticStringBuilder(_arg1));
        }
        else {
            _local5.setStringBuilder(new LineBuilder().setParams(_arg1));
        }
        _local5.setWordWrap(true);
        _local5.setMultiLine(true);
        _local5.setAutoSize(TextFieldAutoSize.CENTER);
        _local5.setHorizontalAlign(TextFormatAlign.CENTER);
        _local5.filters = [new DropShadowFilter(0, 0, 0)];
        _local5.x = _arg2;
        _local5.y = _arg3;
        return (_local5);
    }


    public function onCloseButtonClicked() : void {
        var _local1:FlushPopupStartupQueueSignal = StaticInjectorContext.getInjector().getInstance(FlushPopupStartupQueueSignal);
        closeButton.clicked.remove(this.onCloseButtonClicked);
        if (this.triggeredOnStartup) {
            _local1.dispatch();
        }
    }
    private function onAdded(_arg1:Event) : void {
    }

    public function onClick(_arg1:MouseEvent):void {
    }

    private function destroy(_arg1:Event):void {
        removeEventListener(Event.ADDED_TO_STAGE, this.onAdded);
        removeEventListener(Event.REMOVED_FROM_STAGE, this.destroy);
    }



    override protected function makeModalBackground():Sprite {
        var _local1:Sprite = new Sprite();
        var _local2:DisplayObject = new backgroundImageEmbed();
        _local2.width = (modalWidth + 1);
        _local2.height = (modalHeight - 25);
        _local2.y = 27;
        _local2.alpha = 1.00;
        this.sorPic = new SorForge_ImageEmbed();
        sorPic.y = 30;
        sorPic.x = 70;
        var _local4:PopupWindowBackground = new PopupWindowBackground();
        _local4.draw(modalWidth, modalHeight, PopupWindowBackground.TYPE_TRANSPARENT_WITH_HEADER);
        _local1.addChild(_local2);
        _local1.addChild(this.sorPic);
        _local1.addChild(_local4);
        this.buyButton = new LegacyBuyButton("", 16, 20, Currency.ONRANE);
        this.buyButton.y = 200
        this.buyButton.x = this.buyButton.x + 95
        this.buyButton.setEnabled(true)
        _local1.addChild(this.buyButton);
        this.buyButton.addEventListener(MouseEvent.CLICK, this.onMouseClick)
        return (_local1);
    }
    private function onMouseClick(e:MouseEvent):void {
        SoundEffectLibrary.play("button_click");
    }
    override public function onCloseClick(_arg1:MouseEvent):void {
        SoundEffectLibrary.play("button_click");
    }


}
}
