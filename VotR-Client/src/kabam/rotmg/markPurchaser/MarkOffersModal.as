package kabam.rotmg.markPurchaser {
import com.company.assembleegameclient.sound.SoundEffectLibrary;
import com.company.assembleegameclient.util.Currency;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.util.AssetLibrary;

import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.display.DisplayObject;
import flash.display.Sprite;
import flash.events.Event;
import flash.events.MouseEvent;
import flash.filters.DropShadowFilter;
import flash.text.TextFieldAutoSize;
import flash.text.TextFormatAlign;

import kabam.rotmg.account.core.view.EmptyFrame;
import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.dialogs.control.FlushPopupStartupQueueSignal;
import kabam.rotmg.pets.view.components.PopupWindowBackground;
import kabam.rotmg.raidLauncher.RaidLauncherModal;
import kabam.rotmg.raidLauncher.RaidLauncher_backgroundImageEmbed;
import kabam.rotmg.text.model.FontModel;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;
import kabam.rotmg.util.components.LegacyBuyButton;

public class MarkOffersModal extends EmptyFrame {

    public static const MODAL_WIDTH:int = 640;
    public static const MODAL_HEIGHT:int = 500;

    public static var backgroundImageEmbed:Class = RaidLauncher_backgroundImageEmbed;
    public static var modalWidth:int = MODAL_WIDTH;//440
    public static var modalHeight:int = MODAL_HEIGHT;//400

    private var bitmap1:Bitmap;
    private var nodeTexture1:BitmapData;
    private var node1Desc:TextFieldDisplayConcrete;
    private var bitmap2:Bitmap;
    private var nodeTexture2:BitmapData;
    private var node2Desc:TextFieldDisplayConcrete;
    private var bitmap3:Bitmap;
    private var nodeTexture3:BitmapData;
    private var node3Desc:TextFieldDisplayConcrete;
    private var bitmap4:Bitmap;
    private var nodeTexture4:BitmapData;
    private var node4Desc:TextFieldDisplayConcrete;
    private var bitmap5:Bitmap;
    private var nodeTexture5:BitmapData;
    private var node5Desc:TextFieldDisplayConcrete;
    private var bitmap6:Bitmap;
    private var nodeTexture6:BitmapData;
    private var node6Desc:TextFieldDisplayConcrete;
    private var bitmap7:Bitmap;
    private var nodeTexture7:BitmapData;
    private var node7Desc:TextFieldDisplayConcrete;
    private var bitmap8:Bitmap;
    private var nodeTexture8:BitmapData;
    private var node8Desc:TextFieldDisplayConcrete;
    private var bitmap9:Bitmap;
    private var nodeTexture9:BitmapData;
    private var node9Desc:TextFieldDisplayConcrete;
    private var bitmap10:Bitmap;
    private var nodeTexture10:BitmapData;
    private var node10Desc:TextFieldDisplayConcrete;
    private var bitmap11:Bitmap;
    private var nodeTexture11:BitmapData;
    private var node11Desc:TextFieldDisplayConcrete;
    private var bitmap12:Bitmap;
    private var nodeTexture12:BitmapData;
    private var node12Desc:TextFieldDisplayConcrete;
    private var bitmap13:Bitmap;
    private var nodeTexture13:BitmapData;
    private var node13Desc:TextFieldDisplayConcrete;
    private var bitmap14:Bitmap;
    private var nodeTexture14:BitmapData;
    private var node14Desc:TextFieldDisplayConcrete;
    private var bitmap15:Bitmap;
    private var nodeTexture15:BitmapData;
    private var node15Desc:TextFieldDisplayConcrete;
    private var bitmap16:Bitmap;
    private var nodeTexture16:BitmapData;
    private var node16Desc:TextFieldDisplayConcrete;
    private var bitmap17:Bitmap;
    private var nodeTexture17:BitmapData;
    private var node17Desc:TextFieldDisplayConcrete;
    private var bitmap18:Bitmap;
    private var nodeTexture18:BitmapData;
    private var node18Desc:TextFieldDisplayConcrete;
    private var fontModel:FontModel;
    public var engage1:LegacyBuyButton;
    public var engage2:LegacyBuyButton;
    public var engage3:LegacyBuyButton;
    public var engage4:LegacyBuyButton;
    public var engage5:LegacyBuyButton;
    public var engage6:LegacyBuyButton;
    public var engage7:LegacyBuyButton;
    public var engage8:LegacyBuyButton;
    public var engage9:LegacyBuyButton;
    public var engage10:LegacyBuyButton;
    public var engage11:LegacyBuyButton;
    public var engage12:LegacyBuyButton;
    public var engage13:LegacyBuyButton;
    public var engage14:LegacyBuyButton;
    public var engage15:LegacyBuyButton;
    public var engage16:LegacyBuyButton;
    public var engage17:LegacyBuyButton;
    public var engage18:LegacyBuyButton;

    public function MarkOffersModal() {
        this.fontModel = StaticInjectorContext.getInjector().getInstance(FontModel);
        modalWidth = MODAL_WIDTH;
        modalHeight = MODAL_HEIGHT;
        super(modalWidth, modalHeight);
        this.setCloseButton(true);
        this.setTitle("Choose a Mark to engage", true);
        addEventListener(Event.ADDED_TO_STAGE, this.onAdded);
        addEventListener(Event.REMOVED_FROM_STAGE, this.destroy);
        closeButton.clicked.add(this.onCloseButtonClicked);
    }

    public static function getText(_arg1:String, _arg2:int, _arg3:int, _arg4:Boolean):TextFieldDisplayConcrete {
        var _local5:TextFieldDisplayConcrete = new TextFieldDisplayConcrete().setSize(18).setColor(0xFFFFFF).setTextWidth(((RaidLauncherModal.modalWidth - (TEXT_MARGIN * 2)) - 10));
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
        closeButton.clicked.remove(this.onCloseButtonClicked);
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
        var _local4:PopupWindowBackground = new PopupWindowBackground();
        _local4.draw(modalWidth, modalHeight, PopupWindowBackground.TYPE_TRANSPARENT_WITH_HEADER);
        _local1.addChild(_local2);
        _local1.addChild(_local4);

        this.engage1 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage1.y = 108;
        this.engage1.x = this.engage1.x + 30;
        this.engage1.setEnabled(true);
        _local1.addChild(this.engage1);
        this.engage1.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture1 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 0), 92, true, 0);
        this.bitmap1 = new Bitmap(this.nodeTexture1);
        this.bitmap1.y = this.engage1.y - 80;
        this.bitmap1.x = this.engage1.x - 10;
        _local1.addChild(this.bitmap1);

        this.node1Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node1Desc.setStringBuilder(new StaticStringBuilder().setString(("DEF +5%")));
        this.node1Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node1Desc.x = this.bitmap1.x + 60;
        this.node1Desc.y = this.bitmap1.y + 20;
        _local1.addChild(this.node1Desc);

        this.engage2 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage2.y = 108;
        this.engage2.x = this.engage1.x + 100;
        this.engage2.setEnabled(true);
        _local1.addChild(this.engage2);
        this.engage2.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture2 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 1), 92, true, 0);
        this.bitmap2 = new Bitmap(this.nodeTexture2);
        this.bitmap2.y = this.engage2.y - 80;
        this.bitmap2.x = this.engage2.x - 10;
        _local1.addChild(this.bitmap2);

        this.node2Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node2Desc.setStringBuilder(new StaticStringBuilder().setString(("VIT +5%")));
        this.node2Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node2Desc.x = this.bitmap2.x + 60;
        this.node2Desc.y = this.bitmap2.y + 20;
        _local1.addChild(this.node2Desc);


        this.engage3 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage3.y = 108;
        this.engage3.x = this.engage2.x + 100;
        this.engage3.setEnabled(true);
        _local1.addChild(this.engage3);
        this.engage3.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture3 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 2), 92, true, 0);
        this.bitmap3 = new Bitmap(this.nodeTexture3);
        this.bitmap3.y = this.engage3.y - 80;
        this.bitmap3.x = this.engage3.x - 10;
        _local1.addChild(this.bitmap3);

        this.node3Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node3Desc.setStringBuilder(new StaticStringBuilder().setString(("ATT +5%")));
        this.node3Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node3Desc.x = this.bitmap3.x + 60;
        this.node3Desc.y = this.bitmap3.y + 20;
        _local1.addChild(this.node3Desc);

        this.engage4 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage4.y = 108;
        this.engage4.x = this.engage3.x + 100;
        this.engage4.setEnabled(true);
        _local1.addChild(this.engage4);
        this.engage4.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture4 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 3), 92, true, 0);
        this.bitmap4 = new Bitmap(this.nodeTexture4);
        this.bitmap4.y = this.engage4.y - 80;
        this.bitmap4.x = this.engage4.x - 10;
        _local1.addChild(this.bitmap4);

        this.node4Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node4Desc.setStringBuilder(new StaticStringBuilder().setString(("WIS +5%")));
        this.node4Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node4Desc.x = this.bitmap4.x + 60;
        this.node4Desc.y = this.bitmap4.y + 20;
        _local1.addChild(this.node4Desc);

        this.engage5 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage5.y = 108;
        this.engage5.x = this.engage4.x + 100;
        this.engage5.setEnabled(true);
        _local1.addChild(this.engage5);
        this.engage5.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture5 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 4), 92, true, 0);
        this.bitmap5 = new Bitmap(this.nodeTexture5);
        this.bitmap5.y = this.engage5.y - 80;
        this.bitmap5.x = this.engage5.x - 10;
        _local1.addChild(this.bitmap5);

        this.node5Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node5Desc.setStringBuilder(new StaticStringBuilder().setString(("PRT +5%")));
        this.node5Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node5Desc.x = this.bitmap5.x + 60;
        this.node5Desc.y = this.bitmap5.y + 20;
        _local1.addChild(this.node5Desc);


        this.engage6 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage6.y = 108;
        this.engage6.x = this.engage5.x + 100;
        this.engage6.setEnabled(true);
        _local1.addChild(this.engage6);
        this.engage6.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture6 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 5), 92, true, 0);
        this.bitmap6 = new Bitmap(this.nodeTexture6);
        this.bitmap6.y = this.engage6.y - 80;
        this.bitmap6.x = this.engage6.x - 10;
        _local1.addChild(this.bitmap6);

        this.node6Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node6Desc.setStringBuilder(new StaticStringBuilder().setString(("DEX +5%")));
        this.node6Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node6Desc.x = this.bitmap6.x + 60;
        this.node6Desc.y = this.bitmap6.y + 20;
        _local1.addChild(this.node6Desc);


        this.engage7 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage7.y = 230;
        this.engage7.x = this.engage1.x;
        this.engage7.setEnabled(true);
        _local1.addChild(this.engage7);
        this.engage7.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture7 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 6), 92, true, 0);
        this.bitmap7 = new Bitmap(this.nodeTexture7);
        this.bitmap7.y = this.engage7.y - 80;
        this.bitmap7.x = this.engage7.x - 10;
        _local1.addChild(this.bitmap7);

        this.node7Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node7Desc.setStringBuilder(new StaticStringBuilder().setString(("SPD +5%")));
        this.node7Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node7Desc.x = this.bitmap7.x + 60;
        this.node7Desc.y = this.bitmap7.y + 20;
        _local1.addChild(this.node7Desc);

        this.engage8 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage8.y = 230;
        this.engage8.x = this.engage7.x + 100;
        this.engage8.setEnabled(true);
        _local1.addChild(this.engage8);
        this.engage8.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture8 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 7), 92, true, 0);
        this.bitmap8 = new Bitmap(this.nodeTexture8);
        this.bitmap8.y = this.engage8.y - 80;
        this.bitmap8.x = this.engage8.x - 10;
        _local1.addChild(this.bitmap8);

        this.node8Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node8Desc.setStringBuilder(new StaticStringBuilder().setString(("MGT +5%")));
        this.node8Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node8Desc.x = this.bitmap8.x + 60;
        this.node8Desc.y = this.bitmap8.y + 20;
        _local1.addChild(this.node8Desc);

        this.engage9 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage9.y = 230;
        this.engage9.x = this.engage8.x + 100;
        this.engage9.setEnabled(true);
        _local1.addChild(this.engage9);
        this.engage9.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture9 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 8), 92, true, 0);
        this.bitmap9 = new Bitmap(this.nodeTexture9);
        this.bitmap9.y = this.engage9.y - 80;
        this.bitmap9.x = this.engage9.x - 10;
        _local1.addChild(this.bitmap9);

        this.node9Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node9Desc.setStringBuilder(new StaticStringBuilder().setString(("LUC +5%")));
        this.node9Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node9Desc.x = this.bitmap9.x + 60;
        this.node9Desc.y = this.bitmap9.y + 20;
        _local1.addChild(this.node9Desc);

        this.engage11 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage11.y = 230;
        this.engage11.x = this.engage9.x + 100;
        this.engage11.setEnabled(true);
        _local1.addChild(this.engage11);
        this.engage11.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture11 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 10), 92, true, 0);
        this.bitmap11 = new Bitmap(this.nodeTexture11);
        this.bitmap11.y = this.engage11.y - 80;
        this.bitmap11.x = this.engage11.x - 10;
        _local1.addChild(this.bitmap11);

        this.node11Desc = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node11Desc.setStringBuilder(new StaticStringBuilder().setString(("RES +5%")));
        this.node11Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node11Desc.x = this.bitmap11.x + 60;
        this.node11Desc.y = this.bitmap11.y + 20;
        _local1.addChild(this.node11Desc);

        this.engage10 = new LegacyBuyButton("", 16, 15, Currency.ONRANE);
        this.engage10.y = 230;
        this.engage10.x = this.engage11.x + 100;
        this.engage10.setEnabled(true);
        _local1.addChild(this.engage10);
        this.engage10.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture10 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 9), 92, true, 0);
        this.bitmap10 = new Bitmap(this.nodeTexture10);
        this.bitmap10.y = this.engage10.y - 80;
        this.bitmap10.x = this.engage10.x - 10;
        _local1.addChild(this.bitmap10);

        this.node10Desc = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node10Desc.setStringBuilder(new StaticStringBuilder().setString(("SG Depletes Slower")));
        this.node10Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node10Desc.x = this.bitmap10.x + 60;
        this.node10Desc.y = this.bitmap10.y + 20;
        _local1.addChild(this.node10Desc);

        this.engage12 = new LegacyBuyButton("", 16, 40, Currency.ONRANE);
        this.engage12.y = 352;
        this.engage12.x = this.engage1.x;
        this.engage12.setEnabled(true);
        _local1.addChild(this.engage12);
        this.engage12.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture12 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 16), 92, true, 0);
        this.bitmap12 = new Bitmap(this.nodeTexture12);
        this.bitmap12.y = this.engage12.y - 80;
        this.bitmap12.x = this.engage12.x - 10;
        _local1.addChild(this.bitmap12);

        this.node12Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node12Desc.setStringBuilder(new StaticStringBuilder().setString(("MP +25%")));
        this.node12Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node12Desc.x = this.bitmap12.x + 60;
        this.node12Desc.y = this.bitmap12.y + 20;
        _local1.addChild(this.node12Desc);

        this.engage13 = new LegacyBuyButton("", 16, 40, Currency.ONRANE);
        this.engage13.y = 352;
        this.engage13.x = this.engage1.x + 100;
        this.engage13.setEnabled(true);
        _local1.addChild(this.engage13);
        this.engage13.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture13 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 17), 92, true, 0);
        this.bitmap13 = new Bitmap(this.nodeTexture13);
        this.bitmap13.y = this.engage13.y - 80;
        this.bitmap13.x = this.engage13.x - 10;
        _local1.addChild(this.bitmap13);

        this.node13Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node13Desc.setStringBuilder(new StaticStringBuilder().setString(("HP +25%")));
        this.node13Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node13Desc.x = this.bitmap13.x + 60;
        this.node13Desc.y = this.bitmap13.y + 20;
        _local1.addChild(this.node13Desc);

        this.engage14 = new LegacyBuyButton("", 16, 40, Currency.ONRANE);
        this.engage14.y = 352;
        this.engage14.x = this.engage13.x + 100;
        this.engage14.setEnabled(true);
        _local1.addChild(this.engage14);
        this.engage14.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture14 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 18), 92, true, 0);
        this.bitmap14 = new Bitmap(this.nodeTexture14);
        this.bitmap14.y = this.engage14.y - 80;
        this.bitmap14.x = this.engage14.x - 10;
        _local1.addChild(this.bitmap14);

        this.node14Desc = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFFFF).setBold(true).setTextWidth(10);
        this.node14Desc.setStringBuilder(new StaticStringBuilder().setString(("Surge increases damage")));
        this.node14Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node14Desc.x = this.bitmap14.x + 60;
        this.node14Desc.y = this.bitmap14.y + 20;
        _local1.addChild(this.node14Desc);

        this.engage15 = new LegacyBuyButton("", 16, 40, Currency.ONRANE);
        this.engage15.y = 352;
        this.engage15.x = this.engage14.x + 180;
        this.engage15.setEnabled(true);
        _local1.addChild(this.engage15);
        this.engage15.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture15 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 19), 92, true, 0);
        this.bitmap15 = new Bitmap(this.nodeTexture15);
        this.bitmap15.y = this.engage15.y - 80;
        this.bitmap15.x = this.engage15.x - 10;
        _local1.addChild(this.bitmap15);

        this.node15Desc = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFFFF).setBold(true).setTextWidth(14);
        this.node15Desc.setStringBuilder(new StaticStringBuilder().setString(("Gain 2 extra surge.")));
        this.node15Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node15Desc.x = this.bitmap15.x + 60;
        this.node15Desc.y = this.bitmap15.y + 20;
        _local1.addChild(this.node15Desc);

        this.engage16 = new LegacyBuyButton("", 16, 40, Currency.ONRANE);
        this.engage16.y = 470;
        this.engage16.x = this.engage1.x;
        this.engage16.setEnabled(true);
        _local1.addChild(this.engage16);
        this.engage16.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture16 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 20), 92, true, 0);
        this.bitmap16 = new Bitmap(this.nodeTexture16);
        this.bitmap16.y = this.engage16.y - 80;
        this.bitmap16.x = this.engage16.x - 10;
        _local1.addChild(this.bitmap16);

        this.node16Desc = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFFFF).setBold(true).setTextWidth(14);
        this.node16Desc.setStringBuilder(new StaticStringBuilder().setString(("25% Resurrection")));
        this.node16Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node16Desc.x = this.bitmap16.x + 60;
        this.node16Desc.y = this.bitmap16.y + 20;
        _local1.addChild(this.node16Desc);

        this.engage17 = new LegacyBuyButton("", 16, 40, Currency.ONRANE);
        this.engage17.y = 470;
        this.engage17.x = this.engage1.x + 160;
        this.engage17.setEnabled(true);
        _local1.addChild(this.engage17);
        this.engage17.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture17 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 21), 92, true, 0);
        this.bitmap17 = new Bitmap(this.nodeTexture17);
        this.bitmap17.y = this.engage17.y - 80;
        this.bitmap17.x = this.engage17.x - 10;
        _local1.addChild(this.bitmap17);

        this.node17Desc = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFFFF).setBold(false).setTextWidth(14);
        this.node17Desc.setStringBuilder(new StaticStringBuilder().setString(("+5% all except HP/MP")));
        this.node17Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node17Desc.x = this.bitmap17.x + 60;
        this.node17Desc.y = this.bitmap17.y + 20;
        _local1.addChild(this.node17Desc);

        this.engage18 = new LegacyBuyButton("", 16, 40, Currency.ONRANE);
        this.engage18.y = 470;
        this.engage18.x = this.engage17.x + 160;
        this.engage18.setEnabled(true);
        _local1.addChild(this.engage18);
        this.engage18.addEventListener(MouseEvent.CLICK, onMouseClick);

        this.nodeTexture18 = TextureRedrawer.redraw(AssetLibrary.getImageFromSet("marks10x10", 27), 92, true, 0);
        this.bitmap18 = new Bitmap(this.nodeTexture18);
        this.bitmap18.y = this.engage18.y - 80;
        this.bitmap18.x = this.engage18.x - 10;
        _local1.addChild(this.bitmap18);

        this.node18Desc = new TextFieldDisplayConcrete().setSize(10).setColor(0xFFFFFF).setBold(true).setTextWidth(14);
        this.node18Desc.setStringBuilder(new StaticStringBuilder().setString(("Heal 50 hp & 10 mp on ability")));
        this.node18Desc.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        this.node18Desc.x = this.bitmap18.x + 60;
        this.node18Desc.y = this.bitmap18.y + 20;
        _local1.addChild(this.node18Desc);

        return (_local1);
    }

    private static function onMouseClick(e:MouseEvent):void {
        SoundEffectLibrary.play("button_click");
    }

    override public function onCloseClick(_arg1:MouseEvent):void {
        SoundEffectLibrary.play("button_click");
    }


}
}
