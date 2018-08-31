package kabam.rotmg.game.view.components {
import com.company.assembleegameclient.objects.Player;

import flash.display.Sprite;
import flash.events.MouseEvent;
import flash.filters.GlowFilter;

import kabam.rotmg.game.model.StatModel;
import kabam.rotmg.text.model.TextKey;

import org.osflash.signals.natives.NativeSignal;

public class StatsView extends Sprite {

    private static const statsModel:Array = [
	new StatModel(TextKey.STAT_MODEL_ATTACK_SHORT, TextKey.STAT_MODEL_ATTACK_LONG, 
	TextKey.STAT_MODEL_ATTACK_DESCRIPTION, true), 
	
	new StatModel(TextKey.STAT_MODEL_DEFENSE_SHORT, TextKey.STAT_MODEL_DEFENSE_LONG, 
	TextKey.STAT_MODEL_DEFENSE_DESCRIPTION, false),
	
	new StatModel(TextKey.STAT_MODEL_SPEED_SHORT, TextKey.STAT_MODEL_SPEED_LONG,
	TextKey.STAT_MODEL_SPEED_DESCRIPTION, true),
	
	new StatModel(TextKey.STAT_MODEL_DEXTERITY_SHORT, TextKey.STAT_MODEL_DEXTERITY_LONG,
	TextKey.STAT_MODEL_DEXTERITY_DESCRIPTION, true),
	
	new StatModel(TextKey.STAT_MODEL_VITALITY_SHORT, TextKey.STAT_MODEL_VITALITY_LONG, 
	TextKey.STAT_MODEL_VITALITY_DESCRIPTION, true),
	
	new StatModel(TextKey.STAT_MODEL_WISDOM_SHORT, TextKey.STAT_MODEL_WISDOM_LONG, 
	TextKey.STAT_MODEL_WISDOM_DESCRIPTION, true),
	
	new StatModel(TextKey.STAT_MODEL_MIGHT_SHORT, TextKey.STAT_MODEL_MIGHT_LONG, 
	TextKey.STAT_MODEL_MIGHT_DESCRIPTION, true),
	
	new StatModel(TextKey.STAT_MODEL_LUCK_SHORT, TextKey.STAT_MODEL_LUCK_LONG, 
	TextKey.STAT_MODEL_LUCK_DESCRIPTION, true), 
	
	new StatModel(TextKey.STAT_MODEL_RESTORATION_SHORT, TextKey.STAT_MODEL_RESTORATION_LONG,
	TextKey.STAT_MODEL_RESTORATION_DESCRIPTION, true), 
	
	new StatModel(TextKey.STAT_MODEL_PROTECTION_SHORT, TextKey.STAT_MODEL_PROTECTION_LONG,
	TextKey.STAT_MODEL_PROTECTION_DESCRIPTION, true)];
	
    public static const ATTACK:int = 0;
    public static const DEFENSE:int = 1;
    public static const SPEED:int = 2;
    public static const DEXTERITY:int = 3;
    public static const VITALITY:int = 4;
    public static const WISDOM:int = 5;
    public static const MIGHT:int = 6;
    public static const LUCK:int = 7;
    public static const RESTORATION:int = 8;
    public static const PROTECTION:int = 9;
    public static const STATE_UNDOCKED:String = "state_undocked";
    public static const STATE_DOCKED:String = "state_docked";
    public static const STATE_DEFAULT:String = STATE_DOCKED;//"state_docked"

    private const WIDTH:int = 191;
    private const HEIGHT:int = 45;

    private var background:Sprite;
    public var stats_:Vector.<StatView>;
    public var containerSprite:Sprite;
    public var mouseDown:NativeSignal;
    public var currentState:String = "state_docked";

    public function StatsView() {
        this.background = this.createBackground();
        this.stats_ = new Vector.<StatView>();
        this.containerSprite = new Sprite();
        super();
        addChild(this.background);
        addChild(this.containerSprite);
        this.createStats();
        mouseChildren = false;
        this.mouseDown = new NativeSignal(this, MouseEvent.MOUSE_DOWN, MouseEvent);
    }

    private function createStats():void {
        var sV:StatView;
        var rows:int;
        var i:int;
        while (i < statsModel.length) {
            sV = this.createStat(i, rows);
            this.stats_.push(sV);
            this.containerSprite.addChild(sV);
            rows += i % 2;
            i++;
        }
    }

    private function createStat(i:int, rows:int):StatView {
        var sV:StatView;
        var sM:StatModel = statsModel[i];
        sV = new StatView(sM.name, sM.abbreviation, sM.description, sM.redOnZero);
        sV.x = i % 2 * this.WIDTH / 2;
        sV.y = rows * this.HEIGHT / 3 + 9;
        return (sV);
    }

    public function draw(plr:Player):void {
        if (plr) {
            this.setBackgroundVisibility();
            this.drawStats(plr);
        }
        this.containerSprite.x = (this.WIDTH - this.containerSprite.width) / 2;
    }

    private function drawStats(plr:Player):void {
        this.stats_[ATTACK].draw(plr.attack_, plr.attackBoost_, plr.attackMax_,
		Math.max((plr.attack_ - plr.attackBoost_) - plr.attackMax_, 0));
		
        this.stats_[DEFENSE].draw(plr.defense_, plr.defenseBoost_, plr.defenseMax_, 
		Math.max((plr.defense_ - plr.defenseBoost_) - plr.defenseMax_, 0));
		
        this.stats_[SPEED].draw(plr.speed_, plr.speedBoost_, plr.speedMax_,
		Math.max((plr.speed_ - plr.speedBoost_) - plr.speedMax_, 0));
		
        this.stats_[DEXTERITY].draw(plr.dexterity_, plr.dexterityBoost_, plr.dexterityMax_, 
		Math.max((plr.dexterity_ - plr.dexterityBoost_) - plr.dexterityMax_, 0));
		
        this.stats_[VITALITY].draw(plr.vitality_, plr.vitalityBoost_, plr.vitalityMax_, 
		Math.max((plr.vitality_ - plr.vitalityBoost_) - plr.vitalityMax_, 0));
		
        this.stats_[WISDOM].draw(plr.wisdom_, plr.wisdomBoost_, plr.wisdomMax_,
		Math.max((plr.wisdom_ - plr.wisdomBoost_) - plr.wisdomMax_, 0));
		
        this.stats_[MIGHT].draw(plr.might_, plr.mightBoost_, plr.mightMax_, 
		Math.max((plr.might_ - plr.mightBoost_) - plr.mightMax_, 0));
		
        this.stats_[LUCK].draw(plr.luck_, plr.luckBoost_, plr.luckMax_,
		Math.max((plr.luck_ - plr.luckBoost_) - plr.luckMax_, 0));
		
        this.stats_[RESTORATION].draw(plr.restoration_, plr.restorationBoost_, plr.restorationMax_,
		Math.max((plr.restoration_ - plr.restorationBoost_) - plr.restorationMax_, 0));
		
        this.stats_[PROTECTION].draw(plr.protection_, plr.protectionBoost_, plr.protectionMax_, 
		Math.max((plr.protection_ - plr.protectionBoost_) - plr.protectionMax_, 0));
    }

    public function dock():void {
        this.currentState = STATE_DOCKED;
    }

    public function undock():void {
        this.currentState = STATE_UNDOCKED;
    }

    private function createBackground():Sprite {
        this.background = new Sprite();
        this.background.graphics.clear();
        this.background.graphics.beginFill(0x363636);
        this.background.graphics.lineStyle(2, 0xFFFFFF);
        this.background.graphics.drawRoundRect(-5, 2, (this.WIDTH + 10), (this.HEIGHT + 46), 10);
        this.background.filters = [new GlowFilter(0, 1, 10, 10, 1, 3)];
        return (this.background);
    }

    private function setBackgroundVisibility():void {
        if (this.currentState == STATE_UNDOCKED) {
            this.background.alpha = 1;
        } else if (this.currentState == STATE_DOCKED) {
            this.background.alpha = 0;
        }
    }
}
}
