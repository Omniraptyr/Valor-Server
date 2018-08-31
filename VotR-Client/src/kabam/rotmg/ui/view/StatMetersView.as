package kabam.rotmg.ui.view {
import com.company.assembleegameclient.objects.Player;
import com.company.assembleegameclient.ui.ExperienceBoostTimerPopup;
import com.company.assembleegameclient.ui.StatusBar;

import flash.display.Sprite;
import flash.events.Event;

import kabam.rotmg.text.model.TextKey;

public class StatMetersView extends Sprite {
    private var expBar_:StatusBar;
    private var fameBar_:StatusBar;
    private var hpBar_:StatusBar;
    private var mpBar_:StatusBar;
    private var surgeBar_:StatusBar;
    private var protectionBar:StatusBar;
    private var areTempXpListenersAdded:Boolean;
    private var curXPBoost:int;
    private var expTimer:ExperienceBoostTimerPopup;

    public function StatMetersView() {
        const barSize:int = 13;
        this.expBar_ = new StatusBar(176, barSize, 5931045, 0x545454, TextKey.EXP_BAR_LEVEL);
        this.fameBar_ = new StatusBar(176, barSize, 0xE25F00, 0x545454, TextKey.CURRENCY_FAME);
        this.hpBar_ = new StatusBar(176, barSize, 14693428, 0x545454, TextKey.STATUS_BAR_HEALTH_POINTS);
        this.mpBar_ = new StatusBar(176, barSize, 6325472, 0x545454, TextKey.STATUS_BAR_MANA_POINTS);
        this.surgeBar_ = new StatusBar(176 / 2 - 2, barSize, 0xFFFF66, 0x545454, "SG");
        this.protectionBar = new StatusBar(176 / 2 - 2, barSize, 0xFFFFFF, 0x545454, "PT");

        this.hpBar_.y = 12 + 6;
        this.mpBar_.y = 24 + 12;
	    this.protectionBar.y = this.surgeBar_.y = 36 + 18;
		this.surgeBar_.x = 176 / 2 + 2;
        this.expBar_.visible = true;
        this.fameBar_.visible = false;

        addChild(this.expBar_);
        addChild(this.fameBar_);
        addChild(this.hpBar_);
        addChild(this.mpBar_);
        addChild(this.surgeBar_);
        addChild(this.protectionBar);
    }

    public function update(plr:Player):void {
        this.expBar_.setLabelText(TextKey.EXP_BAR_LEVEL, {"level": plr.level_});
        if (plr.level_ != 20) {
            if (this.expTimer) {
                this.expTimer.update(plr.xpTimer);
            }
            if (!this.expBar_.visible) {
                this.expBar_.visible = true;
                this.fameBar_.visible = false;
            }
            this.expBar_.draw(plr.exp_, plr.nextLevelExp_, 0);
            if (this.curXPBoost != plr.xpBoost_) {
                this.curXPBoost = plr.xpBoost_;
                if (this.curXPBoost) {
                    this.expBar_.showMultiplierText();
                }
                else {
                    this.expBar_.hideMultiplierText();
                }
            }
            if (plr.xpTimer) {
                if (!this.areTempXpListenersAdded) {
                    this.expBar_.addEventListener("MULTIPLIER_OVER", this.onExpBarOver);
                    this.expBar_.addEventListener("MULTIPLIER_OUT", this.onExpBarOut);
                    this.areTempXpListenersAdded = true;
                }
            }
            else {
                if (this.areTempXpListenersAdded) {
                    this.expBar_.removeEventListener("MULTIPLIER_OVER", this.onExpBarOver);
                    this.expBar_.removeEventListener("MULTIPLIER_OUT", this.onExpBarOut);
                    this.areTempXpListenersAdded = false;
                }
                if (this.expTimer && this.expTimer.parent) {
                    removeChild(this.expTimer);
                    this.expTimer = null;
                }
            }
        }
        else {
            if (!this.fameBar_.visible) {
                this.fameBar_.visible = true;
                this.expBar_.visible = false;
            }
            this.fameBar_.draw(plr.currFame_, plr.nextClassQuestFame_, 0);
        }
        this.hpBar_.draw(plr.hp_, plr.maxHP_, plr.maxHPBoost_, plr.maxHPMax_,
                Math.max((plr.maxHP_ - plr.maxHPBoost_) - plr.maxHPMax_, 0));
        this.mpBar_.draw(plr.mp_, plr.maxMP_, plr.maxMPBoost_, plr.maxMPMax_,
                Math.max((plr.maxMP_ - plr.maxMPBoost_) - plr.maxMPMax_, 0));
        this.surgeBar_.draw(plr.surge_, 100, 0);
        this.protectionBar.draw(plr.protectionPoints_, plr.protectionPointsMax_, 0);
    }

    private function onExpBarOver(e:Event):void {
        addChild(this.expTimer = new ExperienceBoostTimerPopup());
    }

    private function onExpBarOut(e:Event):void {
        if (this.expTimer && this.expTimer.parent) {
            removeChild(this.expTimer);
            this.expTimer = null;
        }
    }
}
}
