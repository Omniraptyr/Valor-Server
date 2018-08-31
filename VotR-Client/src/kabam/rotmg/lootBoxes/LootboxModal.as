package kabam.rotmg.lootBoxes {
import com.company.assembleegameclient.objects.Player;
import com.company.assembleegameclient.sound.SoundEffectLibrary;
import com.company.assembleegameclient.ui.DeprecatedTextButton;
import com.company.assembleegameclient.util.Currency;
import com.company.util.MoreColorUtil;

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
import kabam.rotmg.game.model.GameModel;
import kabam.rotmg.game.view.LootboxesDisplay;
import kabam.rotmg.pets.view.components.PopupWindowBackground;
import kabam.rotmg.text.model.FontModel;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;
import kabam.rotmg.util.components.LegacyBuyButton;

public class LootboxModal extends EmptyFrame {

    public static const MODAL_WIDTH:int = 490;
    public static const MODAL_HEIGHT:int = 400;
    private static const OVER_COLOR_TRANSFORM:ColorTransform = new ColorTransform(1, (220 / 0xFF), (133 / 0xFF));
    private static const DROP_SHADOW_FILTER:DropShadowFilter = new DropShadowFilter(0, 0, 0);
    private static const GLOW_FILTER:GlowFilter = new GlowFilter(0xFF0000, 1, 11, 5);
    private static const filterWithGlow:Array = [DROP_SHADOW_FILTER, GLOW_FILTER];
    private static const filterNoGlow:Array = [DROP_SHADOW_FILTER];

    public static var backgroundImageEmbed:Class = LootboxBackground_ImageEmbed;
    public static var modalWidth:int = MODAL_WIDTH;//440
    public static var modalHeight:int = MODAL_HEIGHT;//400

    private var fontModel:FontModel;
    private var triggeredOnStartup:Boolean;
    public var lootboxDisplay_:LootboxesDisplay;
    private var Lootbox_Image1:BronzeLootbox_ImageEmbed;
    private var Lootbox_Image2:SilverLootbox_ImageEmbed;
    private var Lootbox_Image3:GoldLootbox_ImageEmbed;
    private var Lootbox_Image4:EliteLootbox_ImageEmbed;
    private var Lootbox_Image5:PremiumLootbox_ImageEmbed;
    private var Lootbox1Title:TextFieldDisplayConcrete;
    private var Lootbox2Title:TextFieldDisplayConcrete;
    private var Lootbox3Title:TextFieldDisplayConcrete;
    private var Lootbox4Title:TextFieldDisplayConcrete;
    private var Lootbox5Title:TextFieldDisplayConcrete;
    public var Lootbox1Amount:DeprecatedTextButton;
    public var Lootbox2Amount:DeprecatedTextButton;
    public var Lootbox3Amount:DeprecatedTextButton;
    public var Lootbox4Amount:LegacyBuyButton;
    public var Lootbox5Amount:LegacyBuyButton;

    public function LootboxModal(_arg1:Boolean = false) {
        this.triggeredOnStartup = _arg1;
        this.fontModel = StaticInjectorContext.getInjector().getInstance(FontModel);
        modalWidth = MODAL_WIDTH;
        modalHeight = MODAL_HEIGHT;
        super(modalWidth, modalHeight);
        this.setCloseButton(true);
        this.setTitle("Lootboxes", true);
        addEventListener(Event.ADDED_TO_STAGE, this.onAdded);
        addEventListener(Event.REMOVED_FROM_STAGE, this.destroy);
        closeButton.clicked.add(this.onCloseButtonClicked);
    }

    public static function getText(_arg1:String, _arg2:int, _arg3:int, _arg4:Boolean):TextFieldDisplayConcrete {
        var _local5:TextFieldDisplayConcrete = new TextFieldDisplayConcrete().setSize(18).setColor(0xFFFFFF).setTextWidth(((LootboxModal.modalWidth - (TEXT_MARGIN * 2)) - 10));
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


    private function destroy(_arg1:Event):void {
        removeEventListener(Event.ADDED_TO_STAGE, this.onAdded);
        removeEventListener(Event.REMOVED_FROM_STAGE, this.destroy);
    }

    private function onArrowHover(_arg1:MouseEvent):void {
        _arg1.currentTarget.transform.colorTransform = OVER_COLOR_TRANSFORM;
    }

    private function onArrowHoverOut(_arg1:MouseEvent):void {
        _arg1.currentTarget.transform.colorTransform = MoreColorUtil.identity;
    }



    override protected function makeModalBackground():Sprite {
        var _local1:Sprite = new Sprite();
        var _local2:DisplayObject = new backgroundImageEmbed();
        _local2.width = (modalWidth + 1);
        _local2.height = (modalHeight - 25);
        _local2.y = 27;
        _local2.alpha = 1.00;
        this.Lootbox_Image1 = new BronzeLootbox_ImageEmbed();
        this.Lootbox_Image1.y = 60;
        this.Lootbox_Image1.x = 10;
        Lootbox_Image1.width = 72;
        Lootbox_Image1.height = 72;
        this.Lootbox_Image2 = new SilverLootbox_ImageEmbed();
        this.Lootbox_Image2.y = 60;
        this.Lootbox_Image2.x = 110;
        Lootbox_Image2.width = 72;
        Lootbox_Image2.height = 72;
        this.Lootbox_Image3 = new GoldLootbox_ImageEmbed();
        this.Lootbox_Image3.y = 60;
        this.Lootbox_Image3.x = 210;
        Lootbox_Image3.width = 72;
        Lootbox_Image3.height = 72;
        this.Lootbox_Image4 = new EliteLootbox_ImageEmbed();
        this.Lootbox_Image4.y = 60;
        this.Lootbox_Image4.x = 310;
        Lootbox_Image4.width = 72;
        Lootbox_Image4.height = 72;
        this.Lootbox_Image5 = new PremiumLootbox_ImageEmbed();
        this.Lootbox_Image5.y = 60;
        this.Lootbox_Image5.x = 410;
        Lootbox_Image5.width = 72;
        Lootbox_Image5.height = 72;
        this.Lootbox1Title = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFFFF).setBold(true).setTextWidth(20);
        this.Lootbox1Title.setStringBuilder(new StaticStringBuilder().setString(("Bronze Lootbox")));
        this.Lootbox1Title.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.Lootbox1Title.x = this.Lootbox_Image1.x ;
        this.Lootbox1Title.y = this.Lootbox_Image1.y - 10;

        this.Lootbox1Amount = new DeprecatedTextButton(12, "Unbox");
        this.Lootbox1Amount.y = this.Lootbox_Image1.y + 80;
        this.Lootbox1Amount.x = this.Lootbox_Image1.x + 10;
        this.Lootbox1Amount.setEnabled(true);

        this.Lootbox2Title = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFFFF).setBold(true).setTextWidth(20);
        this.Lootbox2Title.setStringBuilder(new StaticStringBuilder().setString(("Silver Lootbox")));
        this.Lootbox2Title.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.Lootbox2Title.x = this.Lootbox_Image2.x;
        this.Lootbox2Title.y = this.Lootbox_Image2.y - 10;

        this.Lootbox2Amount = new DeprecatedTextButton(12, "Unbox");
        this.Lootbox2Amount.y = this.Lootbox_Image2.y + 80;
        this.Lootbox2Amount.x = this.Lootbox_Image2.x + 10;
        this.Lootbox2Amount.setEnabled(true);


        this.Lootbox3Title = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFFFF).setBold(true).setTextWidth(20);
        this.Lootbox3Title.setStringBuilder(new StaticStringBuilder().setString(("Gold Lootbox")));
        this.Lootbox3Title.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.Lootbox3Title.x = this.Lootbox_Image3.x;
        this.Lootbox3Title.y = this.Lootbox_Image3.y - 10;

        this.Lootbox3Amount = new DeprecatedTextButton(12, "Unbox");
        this.Lootbox3Amount.y = this.Lootbox_Image3.y + 80;
        this.Lootbox3Amount.x = this.Lootbox_Image3.x + 10;
        this.Lootbox3Amount.setEnabled(true);

        this.Lootbox4Title = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFFFF).setBold(true).setTextWidth(20);
        this.Lootbox4Title.setStringBuilder(new StaticStringBuilder().setString(("Elite Lootbox")));
        this.Lootbox4Title.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.Lootbox4Title.x = this.Lootbox_Image4.x;
        this.Lootbox4Title.y = this.Lootbox_Image4.y - 10;

        this.Lootbox4Amount = new LegacyBuyButton("", 12, 5, Currency.ONRANE);
        this.Lootbox4Amount.y = this.Lootbox_Image4.y + 80;
        this.Lootbox4Amount.x = this.Lootbox_Image4.x + 17;
        this.Lootbox4Amount.setEnabled(true)

        this.Lootbox5Title = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFF00).setBold(true).setTextWidth(20);
        this.Lootbox5Title.setStringBuilder(new StaticStringBuilder().setString(("Premium Lootbox")));
        this.Lootbox5Title.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.Lootbox5Title.x = this.Lootbox_Image5.x - 8;
        this.Lootbox5Title.y = this.Lootbox_Image5.y - 10;

        this.Lootbox5Amount = new LegacyBuyButton("", 12, 600, Currency.KANTOS);
        this.Lootbox5Amount.y = this.Lootbox_Image5.y + 80;
        this.Lootbox5Amount.x = this.Lootbox_Image5.x + 10;
        this.Lootbox5Amount.setEnabled(true)

        var _local4:PopupWindowBackground = new PopupWindowBackground();
        _local4.draw(modalWidth, modalHeight, PopupWindowBackground.TYPE_TRANSPARENT_WITH_HEADER);
        _local1.addChild(_local2);
        _local1.addChild(_local4);
        _local1.addChild(this.Lootbox_Image1);
        _local1.addChild(this.Lootbox_Image2);
        _local1.addChild(this.Lootbox_Image3);
        _local1.addChild(this.Lootbox_Image4);
        _local1.addChild(this.Lootbox_Image5);
        _local1.addChild(this.Lootbox1Title);
        _local1.addChild(this.Lootbox2Title);
        _local1.addChild(this.Lootbox3Title);
        _local1.addChild(this.Lootbox4Title);
        _local1.addChild(this.Lootbox5Title);
        _local1.addChild(this.Lootbox1Amount);
        _local1.addChild(this.Lootbox2Amount);
        _local1.addChild(this.Lootbox3Amount);
        _local1.addChild(this.Lootbox4Amount);
        _local1.addChild(this.Lootbox5Amount);
        this.lootboxDisplay_ = new LootboxesDisplay(null);
        this.lootboxDisplay_.x = this.Lootbox3Amount.x + 36;
        this.lootboxDisplay_.y = this.Lootbox3Amount.y + 20;
        _local1.addChild(this.lootboxDisplay_);
        var _local_3:Player = StaticInjectorContext.getInjector().getInstance(GameModel).player;
        if (_local_3 != null) {
            this.lootboxDisplay_.draw(_local_3.bronzeLootbox_, _local_3.silverLootbox_, _local_3.goldLootbox_, _local_3.eliteLootbox_);
        }
        //_local1.addChild(_local5);
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
