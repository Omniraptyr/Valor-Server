package kabam.rotmg.game.view.components {
import com.company.assembleegameclient.ui.tooltip.TextToolTip;

import flash.display.Sprite;
import flash.events.Event;
import flash.filters.DropShadowFilter;
import flash.text.TextFieldAutoSize;

import kabam.rotmg.core.signals.HideTooltipsSignal;
import kabam.rotmg.core.signals.ShowTooltipSignal;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;
import kabam.rotmg.tooltips.HoverTooltipDelegate;
import kabam.rotmg.tooltips.TooltipAble;

public class StatView extends Sprite implements TooltipAble {
    public var fullName_:String;
    public var description_:String;
    public var nameText_:TextFieldDisplayConcrete;
    public var valText_:TextFieldDisplayConcrete;
    public var redOnZero_:Boolean;
    public var val_:int = -1;
    public var boost_:int = -1;
    public var valColor_:uint = 0xB3B3B3;
    public var hoverTooltipDelegate:HoverTooltipDelegate;
    protected var tooltip_:TextToolTip;

    public function StatView(name:String, fullName:String, desc:String, redOnZero:Boolean) {
        super();
        this.fullName_ = fullName;
        this.description_ = desc;
        this.nameText_ = new TextFieldDisplayConcrete().setSize(13).setColor(0xB3B3B3);
        this.nameText_.setStringBuilder(new LineBuilder().setParams(name));
        this.configureTextAndAdd(this.nameText_);
        this.valText_ = new TextFieldDisplayConcrete().setSize(13).setColor(this.valColor_).setBold(true);
        this.valText_.setStringBuilder(new StaticStringBuilder("-"));
        this.configureTextAndAdd(this.valText_);
        this.redOnZero_ = redOnZero;
		
        this.tooltip_ = new TextToolTip(0x272727, 0x828282, fullName, desc, 150);
        this.hoverTooltipDelegate = new HoverTooltipDelegate();
        this.hoverTooltipDelegate.setDisplayObject(this);
        this.hoverTooltipDelegate.tooltip = this.tooltip_;
        addEventListener(Event.REMOVED_FROM_STAGE, this.onRemovedFromStage);
    }
	
    public function configureTextAndAdd(textField:TextFieldDisplayConcrete):void {
        textField.setAutoSize(TextFieldAutoSize.LEFT);
        textField.filters = [new DropShadowFilter(0, 0, 0)];
        addChild(textField);
    }

    public function draw(val:int, boost:int, max:int, ascendVal:int):void {
        var color:uint;
        if (val == this.val_ && boost == this.boost_) {
            return;
        }
        this.val_ = val;
        this.boost_ = boost;
        if(ascendVal >= 10) {
            color = 4286945;
        } else if ((val - boost) >= max) {
            color = 0xFCDF00;
		} else {
            if (this.redOnZero_ && this.val_ <= 0 || this.boost_ < 0) {
                color = 16726072;
            } else {
                if (this.boost_ > 0) {
                    color = 6206769;
                } else {
                    color = 0xB3B3B3;
                }
            }
        }
        if (this.valColor_ != color) {
            this.valColor_ = color;
            this.valText_.setColor(this.valColor_);
        }
        var valText:String = this.val_.toString();
        if (this.boost_ != 0) {
            valText += " (" + (this.boost_ > 0 ? "+" : "") + this.boost_.toString() + ")";
        }
        this.valText_.setStringBuilder(new StaticStringBuilder(valText));
        this.valText_.x = this.nameText_.getBounds(this).right;
    }
	
    protected function onRemovedFromStage(e:Event):void {
        removeEventListener(Event.REMOVED_FROM_STAGE, this.onRemovedFromStage);
        this.hoverTooltipDelegate.removeDisplayObject();
        this.hoverTooltipDelegate.tooltip = null;
        this.hoverTooltipDelegate = null;
        this.tooltip_ = null;
    }

    public function setShowToolTipSignal(showTooltip:ShowTooltipSignal):void {
        this.hoverTooltipDelegate.setShowToolTipSignal(showTooltip);
    }

    public function getShowToolTip():ShowTooltipSignal {
        return this.hoverTooltipDelegate.getShowToolTip();
    }

    public function setHideToolTipsSignal(hideTooltip:HideTooltipsSignal):void {
        this.hoverTooltipDelegate.setHideToolTipsSignal(hideTooltip);
    }

    public function getHideToolTips():HideTooltipsSignal {
        return this.hoverTooltipDelegate.getHideToolTips();
    }
}
}
