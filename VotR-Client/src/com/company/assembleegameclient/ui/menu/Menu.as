package com.company.assembleegameclient.ui.menu {
import com.company.util.GraphicsUtil;
import com.company.util.RectangleUtil;
import com.company.assembleegameclient.game.GameSprite;

import flash.display.DisplayObjectContainer;
import flash.display.CapsStyle;
import flash.display.GraphicsPath;
import flash.display.GraphicsSolidFill;
import flash.display.GraphicsStroke;
import flash.display.IGraphicsData;
import flash.display.JointStyle;
import flash.display.LineScaleMode;
import flash.display.Sprite;
import flash.events.Event;
import flash.events.MouseEvent;
import flash.filters.DropShadowFilter;
import flash.geom.Rectangle;

import kabam.rotmg.ui.view.UnFocusAble;
public class Menu extends Sprite implements UnFocusAble {
    private var backgroundFill_:GraphicsSolidFill = new GraphicsSolidFill(0, 1);
    private var outlineFill_:GraphicsSolidFill = new GraphicsSolidFill(0, 1);
    private var lineStyle_:GraphicsStroke = new GraphicsStroke(1, false, LineScaleMode.NORMAL,
            CapsStyle.NONE, JointStyle.ROUND, 3, outlineFill_);
    private var path_:GraphicsPath = new GraphicsPath(new Vector.<int>(), new Vector.<Number>());
    private var background_:uint;
    private var outline_:uint;
    protected var yOffset:int;

    private const graphicsData_:Vector.<IGraphicsData> = new <IGraphicsData>[lineStyle_, backgroundFill_,
        path_, GraphicsUtil.END_FILL, GraphicsUtil.END_STROKE];

    public function Menu(bgColor:uint, outlineColor:uint) {
        super();
        this.background_ = bgColor;
        this.outline_ = outlineColor;
        this.yOffset = 40;
        filters = [new DropShadowFilter(0, 0, 0, 1, 16, 16)];
        addEventListener(Event.ADDED_TO_STAGE, this.onAddedToStage);
        addEventListener(Event.REMOVED_FROM_STAGE, this.onRemovedFromStage);
    }

    protected function addOption(option:MenuOption):void {
        option.x = 8;
        option.y = this.yOffset;
        addChild(option);
        this.yOffset += 28;
    }

    protected function onAddedToStage(e:Event):void {
        this.draw();
        this.position();
        addEventListener(Event.ENTER_FRAME, this.onEnterFrame);
        addEventListener(MouseEvent.ROLL_OUT, this.onRollOut);
    }

    protected function onRemovedFromStage(e:Event):void {
        removeEventListener(Event.ENTER_FRAME, this.onEnterFrame);
        removeEventListener(MouseEvent.ROLL_OUT, this.onRollOut);
    }

    protected function onEnterFrame(e:Event):void {
        if (stage == null) return;

        var stageRect:Rectangle = getRect(stage);
        var dist:Number = RectangleUtil.pointDist(stageRect, stage.mouseX, stage.mouseY);

        if (dist > 40) {
            this.remove()
        }
    }

    private function position() : void {
        if (stage == null) {
            return;
        }

        this.positionFixed();
    }

    public function scaleParent() : void {
        var sprite:* = null;

        if (this.parent is GameSprite) sprite = this;
        else sprite = this.parent;

        var scaleX:Number = 800 / stage.stageWidth;
        var scaleY:Number = 600 / stage.stageHeight;

        sprite.scaleX = scaleX / scaleY;
        sprite.scaleY = 1;
    }

    public function positionFixed() : void {
        var relX:Number = (stage.stageWidth - 800) * 0.5 + stage.mouseX;
        var relY:Number = (stage.stageHeight - 600) * 0.5 + stage.mouseY;
        var scale:Number = 600 / stage.stageHeight;

        this.scaleParent();

        relX = relX * scale;
        relY = relY * scale;

        if(stage == null) {
            return;
        }

        if( stage.mouseX + 0.5 * stage.stageWidth - 400 < stage.stageWidth * 0.5) {
            x = relX + 12;
        } else {
            x = relX - width - 1;
        }
        if (x < 12) {
            x = 12;
        }

        if (stage.mouseY + 0.5 * stage.stageHeight - 300 < stage.stageHeight * 0.333333333333333) {
            y = relY + 12;
        } else {
            y = relY - height - 1;
        }
        if (y < 12) {
            y = 12;
        }
    }

    protected function onRollOut(e:Event):void {
        this.remove();
    }

    public function remove():void {
        if (parent != null) {
            parent.removeChild(this);
        }
    }

    protected function draw():void {
        this.backgroundFill_.color = this.background_;
        this.outlineFill_.color = this.outline_;
        graphics.clear();
        GraphicsUtil.clearPath(this.path_);
        GraphicsUtil.drawCutEdgeRect(-6, -6,
                Math.max(154, (width + 12)),
                (height + 12), 4,
                [1, 1, 1, 1], this.path_);
        graphics.drawGraphicsData(this.graphicsData_);
    }
}
}