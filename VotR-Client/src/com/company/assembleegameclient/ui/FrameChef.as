/**
 * Created by vooolox on 07-2-2016.
 */
package com.company.assembleegameclient.ui {
import com.company.assembleegameclient.account.ui.*;
import com.company.ui.BaseSimpleText;
import com.company.util.GraphicsUtil;

import flash.display.CapsStyle;
import flash.display.DisplayObject;
import flash.display.GraphicsPath;
import flash.display.GraphicsSolidFill;
import flash.display.GraphicsStroke;
import flash.display.IGraphicsData;
import flash.display.JointStyle;
import flash.display.LineScaleMode;
import flash.display.Sprite;
import flash.events.Event;
import flash.filters.DropShadowFilter;

import kabam.rotmg.pets.view.components.DialogCloseButton;

public class FrameChef extends Sprite
{

    public function FrameChef(_arg1:String, button1Text:String, _arg5:int = 288) {
        this.frameTextInputBoxes = new Vector.<TextInputField>();
        this.frameTextButtons_ = new Vector.<DeprecatedClickableText>();
        this.primaryColorLight = new GraphicsSolidFill(0x220022, 1);
        this.primaryColorDark = new GraphicsSolidFill(0x444444, 1);
        this.outlineFill_ = new GraphicsSolidFill(0xFFFFFF, 1);
        this._graphicsStroke = new GraphicsStroke(1, false, LineScaleMode.NORMAL, CapsStyle.NONE, JointStyle.ROUND, 3, this.outlineFill_);
        this.path1_ = new GraphicsPath(new Vector.<int>(), new Vector.<Number>());
        this.path2_ = new GraphicsPath(new Vector.<int>(), new Vector.<Number>());
        this.graphicsData_ = new <IGraphicsData>[primaryColorDark, path2_, GraphicsUtil.END_FILL, primaryColorLight, path1_, GraphicsUtil.END_FILL, _graphicsStroke, path2_, GraphicsUtil.END_STROKE];
        super();
        this.w_ = _arg5;
        this.frameTitle = new BaseSimpleText(12, 0xFFFFFF, false, 0, 0);
        this.frameTitle.text = _arg1;
        this.frameTitle.updateMetrics();
        this.frameTitle.filters = [new DropShadowFilter(0, 0, 0)];
        this.frameTitle.x = 5;
        this.frameTitle.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        addChild(this.frameTitle);
        this.Button1 = new DeprecatedClickableText(18, true, button1Text);
        if (button1Text != "") {
            this.Button1.buttonMode = true;
            this.Button1.x = (this.w_ / 2) - (Button1.width / 2);
            addChild(this.Button1);
        }
        this.XButton = new DialogCloseButton();
        this.XButton.x = ((this.w_ - this.XButton.width) - 15);
        addChild(this.XButton);
        filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        addEventListener(Event.ADDED_TO_STAGE, this.onAddedToStage);
        addEventListener(Event.REMOVED_FROM_STAGE, this.onRemovedFromStage);
    }
    public var frameTitle:BaseSimpleText;
    public var Button1:DeprecatedClickableText;
    public var XButton:DialogCloseButton;
    public var frameTextInputBoxes:Vector.<TextInputField>;
    public var frameTextButtons_:Vector.<DeprecatedClickableText>;
    protected var w_:int = 288;
    protected var h_:int = 400;
    private var graphicsData_:Vector.<IGraphicsData>;
    private var primaryColorLight:GraphicsSolidFill;
    private var primaryColorDark:GraphicsSolidFill;
    private var outlineFill_:GraphicsSolidFill;
    private var _graphicsStroke:GraphicsStroke;
    private var path1_:GraphicsPath;
    private var path2_:GraphicsPath;
    public function addTextButton(_arg1:DeprecatedClickableText):void
    {
        this.frameTextButtons_.push(_arg1);
        addChild(_arg1);
        _arg1.y = (this.h_ - 66);
        _arg1.x = 17;
        this.h_ = (this.h_ + 20);
    }

    public function addDisplayObject(_arg1:DisplayObject, _arg2:int = 8):void
    {
        addChild(_arg1);
        _arg1.y = (this.h_ - 66);
        _arg1.x = _arg2;
        this.h_ = (this.h_ + _arg1.height);
    }

    public function addLabel(_arg1:String):void
    {
        var _local2:BaseSimpleText;
        _local2 = new BaseSimpleText(12, 0xFFFFFF, false, 0, 0);
        _local2.text = _arg1;
        _local2.updateMetrics();
        _local2.filters = [new DropShadowFilter(0, 0, 0)];
        addChild(_local2);
        _local2.y = (this.h_ - 66);
        _local2.x = 17;
        this.h_ = (this.h_ + 20);
    }

    public function addHeaderText(_arg1:String):void {
        var _local2:BaseSimpleText = new BaseSimpleText(20, 0xB2B2B2, false, 0, 0);
        _local2.text = _arg1;
        _local2.setBold(true);
        _local2.updateMetrics();
        _local2.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        addChild(_local2);
        _local2.y = (this.h_ - 60);
        _local2.x = 15;
        this.h_ = (this.h_ + 40);
    }


    public function offsetH(_arg1:int):void
    {
        this.h_ = (this.h_ + _arg1);
    }

    public function setAllButtonsGray():void {
        var _local1:DeprecatedClickableText;
        mouseEnabled = false;
        mouseChildren = false;
        for each (_local1 in this.frameTextButtons_)
        {
            _local1.setDefaultColor(0xB3B3B3);
        }
        this.Button1.setDefaultColor(0xB3B3B3);
    }

    public function setAllButtonsWhite():void {
        var _local1:TextInputField;
        var _local2:DeprecatedClickableText;
        var _local5:DeprecatedClickableText;
        mouseEnabled = true;
        mouseChildren = true;
        for each (_local1 in this.frameTextInputBoxes) {
        }
        for each (_local5 in this.frameTextButtons_) {
            _local2 = _local5;
            _local2.setColor(0xFFFFFF);
        }
        this.Button1.setColor(0xFFFFFF);
    }

    public function draw():void {
        this.graphics.clear();
        GraphicsUtil.clearPath(this.path1_);
        GraphicsUtil.drawUI(-6, -6, this.w_, (20 + 12), 4, [1, 1, 0, 0], this.path1_);
        GraphicsUtil.clearPath(this.path2_);
        GraphicsUtil.drawUI(-6, -6, this.w_, this.h_, 4, [1, 1, 1, 1], this.path2_);
        (this.Button1.y = (this.h_ - 48));
        this.graphics.drawGraphicsData(this.graphicsData_);
    }

    public function onAddedToStage(_arg1:Event):void {
        this.draw();
        this.x = (400 - ((this.w_ - 6) / 2));
        this.y = (300 - (h_ / 2)); //was height
        if (this.frameTextInputBoxes.length > 0) {
            (stage.focus = this.frameTextInputBoxes[0].inputText_);
        }
    }

    private function onRemovedFromStage(_arg1:Event):void {
    }

}
}

