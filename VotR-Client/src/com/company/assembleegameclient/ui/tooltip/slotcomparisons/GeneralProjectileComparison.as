package com.company.assembleegameclient.ui.tooltip.slotcomparisons {
import com.company.assembleegameclient.ui.tooltip.TooltipHelper;

import kabam.rotmg.text.model.TextKey;
import kabam.rotmg.text.view.stringBuilder.AppendingLineBuilder;

public class GeneralProjectileComparison extends SlotComparison {
    private var itemXML:XML;
    private var curItemXML:XML;
    private var projXML:XML;
    private var otherProjXML:XML;

    override protected function compareSlots(_arg1:XML, _arg2:XML):void {
        this.itemXML = _arg1;
        this.curItemXML = _arg2;
        comparisonStringBuilder = new AppendingLineBuilder();
        if (_arg1.hasOwnProperty("NumProjectiles")) {
            this.addNumProjectileText();
            processedTags[_arg1.NumProjectiles.toXMLString()] = true;
        }
        if (_arg1.hasOwnProperty("Projectile")) {
            this.addProjectileText();
            processedTags[_arg1.Projectile.toXMLString()] = true;
        }
    }

    private function addProjectileText():void {
        this.addDamageText();
        var _local1:Number = ((Number(this.projXML.Speed) * Number(this.projXML.LifetimeMS)) / 10000);
        var _local2:Number = ((Number(this.otherProjXML.Speed) * Number(this.otherProjXML.LifetimeMS)) / 10000);
        var _local3:String = TooltipHelper.getFormattedRangeString(_local1);
		var _local4:XML;
        comparisonStringBuilder.pushParams(TextKey.RANGE, {"range": wrapInColoredFont(_local3, getTextColor((_local1 - _local2)))});
        if (this.projXML.hasOwnProperty("MultiHit")) {
            comparisonStringBuilder.pushParams(TextKey.MULTIHIT, {}, TooltipHelper.getOpenTag(NO_DIFF_COLOR), TooltipHelper.getCloseTag());
        }
        if (this.projXML.hasOwnProperty("PassesCover")) {
            comparisonStringBuilder.pushParams(TextKey.PASSES_COVER, {}, TooltipHelper.getOpenTag(NO_DIFF_COLOR), TooltipHelper.getCloseTag());
        }
        if (this.projXML.hasOwnProperty("ArmorPiercing")) {
            comparisonStringBuilder.pushParams(TextKey.ARMOR_PIERCING, {}, TooltipHelper.getOpenTag(UNTIERED_COLOR), TooltipHelper.getCloseTag());
        }
        if (this.projXML.hasOwnProperty("Boomerang")) {
            comparisonStringBuilder.pushParams("Shots boomerang", {}, TooltipHelper.getOpenTag(NO_DIFF_COLOR), TooltipHelper.getCloseTag());
        }
        if (this.projXML.hasOwnProperty("Parametric")) {
            comparisonStringBuilder.pushParams("Shots are parametric", {}, TooltipHelper.getOpenTag(NO_DIFF_COLOR), TooltipHelper.getCloseTag());
        }
		for each (_local4 in this.projXML.ConditionEffect) {
            comparisonStringBuilder.pushParams("Shot Effect:\n{condition}", {
                        "condition":
                                wrapInColoredFont(this.projXML.ConditionEffect + " for "
                                        + this.projXML.ConditionEffect.@duration + " seconds", NO_DIFF_COLOR)
                });
        }		
        for each (_local4 in this.projXML.CondChance) {
            var durColor:uint = getTextColor(this.itemXML.CondChance.@duration - this.itemXML.CondChance.@duration);
            var chanceColor:uint = getTextColor(this.itemXML.CondChance.@chance - this.itemXML.CondChance.@chance);
            comparisonStringBuilder.pushParams("{condChance}% to inflict " +
                "{condEff} for {condDuration} seconds"
                , {"condChance": wrapInColoredFont(this.projXML.CondChance.@chance, chanceColor),
                    "condEff": wrapInColoredFont(this.projXML.CondChance.@effect, chanceColor),
                    "condDuration": wrapInColoredFont(this.projXML.CondChance.@duration, durColor)
                });
        }
    }
    
    private function addNumProjectileText():void {
        var _local1:int = int(this.itemXML.NumProjectiles);
        var _local2:int = int(this.curItemXML.NumProjectiles);
        var _local3:uint = getTextColor((_local1 - _local2));
        comparisonStringBuilder.pushParams(TextKey.SHOTS, {"numShots": wrapInColoredFont(_local1.toString(), _local3)});
    }

    private function addDamageText():void {
        this.projXML = XML(this.itemXML.Projectile);
        var _local1:int = int(this.projXML.MinDamage);
        var _local2:int = int(this.projXML.MaxDamage);
        var _local3:Number = ((_local2 + _local1) / 2);
        this.otherProjXML = XML(this.curItemXML.Projectile);
        var _local4:int = int(this.otherProjXML.MinDamage);
        var _local5:int = int(this.otherProjXML.MaxDamage);
        var _local6:Number = ((_local5 + _local4) / 2);
        var _local7:String = (((_local1 == _local2)) ? _local1 : ((_local1 + " - ") + _local2)).toString();
        comparisonStringBuilder.pushParams(TextKey.DAMAGE, {"damage": wrapInColoredFont(_local7, getTextColor((_local3 - _local6)))});
    }
}
}
