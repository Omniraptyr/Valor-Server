package com.company.assembleegameclient.ui.tooltip {
import com.company.assembleegameclient.constants.InventoryOwnerTypes;
import com.company.assembleegameclient.misc.UILabel;
import com.company.assembleegameclient.objects.ObjectLibrary;
import com.company.assembleegameclient.objects.Player;
import com.company.assembleegameclient.parameters.Parameters;
import com.company.assembleegameclient.ui.LineBreakDesign;
import com.company.assembleegameclient.util.TierUtil;
import com.company.util.BitmapUtil;
import com.company.util.KeyCodes;
import com.company.util.MoreStringUtil;

import flash.display.Bitmap;
import flash.display.BitmapData;
import flash.filters.DropShadowFilter;

import kabam.rotmg.constants.ActivationType;
import kabam.rotmg.messaging.impl.data.StatData;
import kabam.rotmg.text.model.TextKey;
import kabam.rotmg.text.view.TextFieldDisplayConcrete;
import kabam.rotmg.text.view.stringBuilder.AppendingLineBuilder;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;
import kabam.rotmg.text.view.stringBuilder.StaticStringBuilder;
import kabam.rotmg.text.view.stringBuilder.StringBuilder;

public class EquipmentToolTip extends ToolTip {
    private static const MAX_WIDTH:int = 230;

    private var icon:Bitmap;
    public var titleText:TextFieldDisplayConcrete;
    private var tierText:UILabel;
    private var descText:TextFieldDisplayConcrete;
    private var line1:LineBreakDesign;
    private var effectsText:TextFieldDisplayConcrete;
    private var line2:LineBreakDesign;
    private var restrictionsText:TextFieldDisplayConcrete;
    private var player:Player;
    private var isEquippable:Boolean = false;
    private var objectType:int;
    private var curItemXML:XML = null;
    private var objectXML:XML = null;
    private var slotTypeToTextBuilder:SlotComparisonFactory;
    private var restrictions:Vector.<Restriction>;
    private var effects:Vector.<Effect>;
    private var uniqueEffects:Vector.<Effect>;
    private var itemSlotTypeId:int;
    private var invType:int;
    private var inventoryOwnerType:String;
    private var isInventoryFull:Boolean;
    private var playerCanUse:Boolean;
    private var comparisonResults:SlotComparisonResult;
    private var legendaryText:TextFieldDisplayConcrete;

    public function EquipmentToolTip(_arg_1:int, _arg_2:Player, _arg_3:int, _arg_4:String, _arg_5:uint = 1, _arg_6:Boolean = false, _arg7:Object = null) {
        this.uniqueEffects = new Vector.<Effect>();
        this.objectType = _arg_1;
        this.player = _arg_2;
        this.invType = _arg_3;
        this.inventoryOwnerType = _arg_4;
        this.isInventoryFull = ((_arg_2) ? _arg_2.isInventoryFull() : false);
        this.playerCanUse = ((_arg_2) ? ObjectLibrary.isUsableByPlayer(_arg_1, _arg_2) : false);
        var _local_5:int = ((_arg_2) ? ObjectLibrary.getMatchingSlotIndex(_arg_1, _arg_2) : -1);
        var _local_6:uint = ((((this.playerCanUse) || ((this.player == null)))) ? 0x363636 : 6036765);
        var _local_7:uint = ((((this.playerCanUse) || ((_arg_2 == null)))) ? 0x9B9B9B : 10965039);
        super(_local_6, 1, _local_7, 1, true);
        this.slotTypeToTextBuilder = new SlotComparisonFactory();
        this.objectXML = ObjectLibrary.xmlLibrary_[_arg_1] || new XML();
        this.isEquippable = !((_local_5 == -1));
        this.effects = new Vector.<Effect>();
        this.itemSlotTypeId = int(this.objectXML.SlotType);
        if (this.player == null) {
            this.curItemXML = this.objectXML;
        }
        else {
            if (this.isEquippable) {
                if (this.player.equipment_[_local_5] != -1) {
                    this.curItemXML = ObjectLibrary.xmlLibrary_[this.player.equipment_[_local_5]];
                }
            }
        }
        this.addIcon();
        this.addTitle();
        this.addTierText();
        this.addDescriptionText();
        this.handleWisMod();
        this.buildCategorySpecificText();
        this.addUniqueEffectsToList();
        this.addNumProjectilesTagsToEffectsList();
        this.addRateOfFire();
        this.addProjectileTagsToEffectsList();
        this.addActivateTagsToEffectsList();
        this.addActivateOnEquipTagsToEffectsList();
        this.addDoseTagsToEffectsList();
        this.addMpCostTagToEffectsList();
        this.addHpCostTagToEffectsList();
        this.addSurgeCostTagToEffectsList();
        this.addCooldown();
        this.addSurgeMod();
        this.addFameBonusTagToEffectsList();
        this.makeEffectsList();
        this.makeLineTwo();
        this.makeRestrictionList();
        this.makeRestrictionText();
        this.makeLegendaryExtraText();
    }

    private function makeLegendaryExtraText():void {
        if (this.objectXML.hasOwnProperty("Legend")) {
            this.legendaryText = new TextFieldDisplayConcrete().setSize(12).setColor(0xFFFF19).setBold(true).setTextWidth(MAX_WIDTH - 4).setWordWrap(true);
            this.legendaryText.setStringBuilder(new StaticStringBuilder().setString((this.objectXML.Legend.Name + ": " + this.objectXML.Legend.Description)));
            this.legendaryText.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
            waiter.push(this.legendaryText.textChanged);
            addChild(this.legendaryText);
        }
    }

    private function addUniqueEffectsToList():void {
        var _local_1:XMLList;
        var _local_2:XML;
        var _local_3:String;
        var _local_4:String;
        var _local_5:String;
        var _local_6:AppendingLineBuilder;
        if (this.objectXML.hasOwnProperty("ExtraTooltipData")) {
            _local_1 = this.objectXML.ExtraTooltipData.EffectInfo;
            for each (_local_2 in _local_1) {
                _local_3 = _local_2.attribute("name");
                _local_4 = _local_2.attribute("description");
                _local_5 = ((((_local_3) && (_local_4))) ? ": " : "\n");
                _local_6 = new AppendingLineBuilder();
                if (_local_3) {
                    _local_6.pushParams(_local_3);
                }
                if (_local_4) {
                    _local_6.pushParams(_local_4, {}, TooltipHelper.getOpenTag(16777103), TooltipHelper.getCloseTag());
                }
                _local_6.setDelimiter(_local_5);
                this.uniqueEffects.push(new Effect(TextKey.BLANK, {"data": _local_6}));
            }
        }
    }

    private function isEmptyEquipSlot():Boolean {
        return (((this.isEquippable) && ((this.curItemXML == null))));
    }

    private function addIcon():void {
        var _local_1:XML = ObjectLibrary.xmlLibrary_[this.objectType];
        var _local_2:int = 5;
        if ((((this.objectType == 4874)) || ((this.objectType == 4618)))) {
            _local_2 = 8;
        }
        if (_local_1.hasOwnProperty("ScaleValue")) {
            _local_2 = _local_1.ScaleValue;
        }
        var _local_3:BitmapData = ObjectLibrary.getRedrawnTextureFromType(this.objectType, 60, true, true, _local_2);
        _local_3 = BitmapUtil.cropToBitmapData(_local_3, 4, 4, (_local_3.width - 8), (_local_3.height - 8));
        this.icon = new Bitmap(_local_3);
        addChild(this.icon);
    }

    private function addTierText():void {
        this.tierText = TierUtil.getTierTag(this.objectXML,16);
        if(this.tierText)
        {
            addChild(this.tierText);
        }
    }

    private function isPet():Boolean {
        var activateTags:XMLList;
        activateTags = this.objectXML.Activate.(text() == "PermaPet");
        return ((activateTags.length() >= 1));
    }

    private function addTitle():void {
        var _local_1:int = ((((this.playerCanUse) || ((this.player == null)))) ? 0xFFFFFF : 16549442);
        this.titleText = new TextFieldDisplayConcrete().setSize(16).setColor(_local_1).setBold(true).setTextWidth((((MAX_WIDTH - this.icon.width) - 4) - 30)).setWordWrap(true);
        this.titleText.setStringBuilder(new LineBuilder().setParams(ObjectLibrary.typeToDisplayId_[this.objectType]));
        this.titleText.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        waiter.push(this.titleText.textChanged);
        addChild(this.titleText);
    }

    private function buildUniqueTooltipData():String {
        var _local_1:XMLList;
        var _local_2:Vector.<Effect>;
        var _local_3:XML;
        if (this.objectXML.hasOwnProperty("ExtraTooltipData")) {
            _local_1 = this.objectXML.ExtraTooltipData.EffectInfo;
            _local_2 = new Vector.<Effect>();
            for each (_local_3 in _local_1) {
                _local_2.push(new Effect(_local_3.attribute("name"), _local_3.attribute("description")));
            }
        }
        return ("");
    }

    private function makeEffectsList():void {
        var _local_1:AppendingLineBuilder;
        if (((((!((this.effects.length == 0))) || (!((this.comparisonResults.lineBuilder == null))))) || (this.objectXML.hasOwnProperty("ExtraTooltipData")))) {
            this.line1 = new LineBreakDesign((MAX_WIDTH - 12), 0);
            this.effectsText = new TextFieldDisplayConcrete().setSize(14).setColor(0xB3B3B3).setTextWidth(MAX_WIDTH).setWordWrap(true).setHTML(true);
            _local_1 = this.getEffectsStringBuilder();
            this.effectsText.setStringBuilder(_local_1);
            this.effectsText.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
            if (_local_1.hasLines()) {
                addChild(this.line1);
                addChild(this.effectsText);
            }
        }
    }

    private function getEffectsStringBuilder():AppendingLineBuilder {
        var _local_1:AppendingLineBuilder = new AppendingLineBuilder();
        this.appendEffects(this.uniqueEffects, _local_1);
        if (this.comparisonResults.lineBuilder.hasLines()) {
            _local_1.pushParams(TextKey.BLANK, {"data": this.comparisonResults.lineBuilder});
        }
        this.appendEffects(this.effects, _local_1);
        return (_local_1);
    }

    private function appendEffects(_arg_1:Vector.<Effect>, _arg_2:AppendingLineBuilder):void {
        var _local_3:Effect;
        var _local_4:String;
        var _local_5:String;
        for each (_local_3 in _arg_1) {
            _local_4 = "";
            _local_5 = "";
            if (_local_3.color_) {
                _local_4 = (('<font color="#' + _local_3.color_.toString(16)) + '">');
                _local_5 = "</font>";
            }
            _arg_2.pushParams(_local_3.name_, _local_3.getValueReplacementsWithColor(), _local_4, _local_5);
        }
    }

    private function addNumProjectilesTagsToEffectsList():void {
        if (this.objectXML.hasOwnProperty("NumProjectiles"
                && this.objectXML.NumProjectiles != 1
                && !this.comparisonResults.processedTags
                        .hasOwnProperty(this.objectXML.NumProjectiles.toXMLString()) == true)) {
            this.effects.push(new Effect(TextKey.SHOTS, {"numShots": this.objectXML.NumProjectiles}));
        }
    }

    private function addFameBonusTagToEffectsList():void {
        var _local_1:int;
        var _local_2:uint;
        var _local_3:int;
        if (this.objectXML.hasOwnProperty("FameBonus")) {
            _local_1 = int(this.objectXML.FameBonus);
            _local_2 = ((this.playerCanUse) ? TooltipHelper.BETTER_COLOR : TooltipHelper.NO_DIFF_COLOR);
            if (((!((this.curItemXML == null))) && (this.curItemXML.hasOwnProperty("FameBonus")))) {
                _local_3 = int(this.curItemXML.FameBonus.text());
                _local_2 = TooltipHelper.getTextColor((_local_1 - _local_3));
            }
            this.effects.push(new Effect(TextKey.FAME_BONUS, {"percent": (this.objectXML.FameBonus + "%")}).setReplacementsColor(_local_2));
        }
    }

    private function addMpCostTagToEffectsList():void {
        if (this.objectXML.hasOwnProperty("MpEndCost")) {
            if (!this.comparisonResults.processedTags[this.objectXML.MpEndCost[0].toXMLString()]) {
                this.effects.push(new Effect(TextKey.MP_COST, {"cost": this.objectXML.MpEndCost}));
            }
        }
        else {
            if (((this.objectXML.hasOwnProperty("MpCost")) && (!(this.comparisonResults.processedTags[this.objectXML.MpCost[0].toXMLString()])))) {
                if (!this.comparisonResults.processedTags[this.objectXML.MpCost[0].toXMLString()]) {
                    this.effects.push(new Effect(TextKey.MP_COST, {"cost": this.objectXML.MpCost}));
                }
            }
        }
    }

    private function addHpCostTagToEffectsList():void {
        if (this.objectXML.hasOwnProperty("HpCost")) {
            this.effects.push(new Effect(TextKey.HP_COST, {"hpcost": this.objectXML.HpCost}));
        }
    }

    private function addSurgeCostTagToEffectsList():void {
        if (this.objectXML.hasOwnProperty("SurgeCost")) {
            this.effects.push(new Effect(TextKey.SURGE_COST, {"surgecost": this.objectXML.SurgeCost}));
        }
    }

    private function addDoseTagsToEffectsList():void {
        if (this.objectXML.hasOwnProperty("Doses")) {
            this.effects.push(new Effect(TextKey.DOSES, {"dose": this.objectXML.Doses}));
        }
    }

    private function addProjectileTagsToEffectsList():void {
        var projXML:XML;
        var minDmg:int;
        var maxDmg:int;
        var range:Number;
        var xml:XML;
        if (this.objectXML.hasOwnProperty("Projectile")
                && !this.comparisonResults.processedTags.hasOwnProperty(this.objectXML.Projectile.toXMLString())) {
            projXML = XML(this.objectXML.Projectile);
            minDmg = int(projXML.MinDamage);
            maxDmg = int(projXML.MaxDamage);
            this.effects.push(new Effect(TextKey.DAMAGE, {"damage":
                        (((minDmg == maxDmg)) ? minDmg : ((minDmg + " - ") + maxDmg)).toString()}));
            range = projXML.Speed * projXML.LifetimeMS / 10000;
            this.effects.push(new Effect(TextKey.RANGE, {"range": TooltipHelper.getFormattedRangeString(
                        (this.objectXML.Projectile.hasOwnProperty("Boomerang") ? range / 2 : range))}));

            if (this.objectXML.Projectile.hasOwnProperty("MultiHit")) {
                this.effects.push(new Effect(TextKey.MULTIHIT, {}).setColor(TooltipHelper.NO_DIFF_COLOR));
            }
            if (this.objectXML.Projectile.hasOwnProperty("PassesCover")) {
                this.effects.push(new Effect(TextKey.PASSES_COVER, {}).setColor(TooltipHelper.NO_DIFF_COLOR));
            }
            if (this.objectXML.Projectile.hasOwnProperty("ArmorPiercing")) {
                this.effects.push(new Effect(TextKey.ARMOR_PIERCING, {}).setColor(TooltipHelper.UNTIERED_COLOR));
            }
            if (this.objectXML.Projectile.hasOwnProperty("Boomerang")) {
                this.effects.push(new Effect("Shots boomerang", {}).setColor(TooltipHelper.NO_DIFF_COLOR));
            }
            if (this.objectXML.Projectile.hasOwnProperty("Parametric")) {
                this.effects.push(new Effect("Shots are parametric", {}).setColor(TooltipHelper.NO_DIFF_COLOR));
            }

            for each(xml in projXML.ConditionEffect) {
                this.effects.push(new Effect(TextKey.EFFECT_FOR_DURATION, {
                    "effect": xml,
                    "duration": xml.@duration
                }).setColor(TooltipHelper.NO_DIFF_COLOR));
            }

            for each (xml in projXML.CondChance) {
                this.effects.push(new Effect("{condChance}% to inflict " +
                        "{condEff} for {condDuration} seconds", {"condChance": this.objectXML.Projectile.CondChance.@chance,
                    "condEff": this.objectXML.Projectile.CondChance.@effect,
                    "condDuration": this.objectXML.Projectile.CondChance.@duration
                }));
            }
        }
    }

    private function addRateOfFire() : void {
        if (this.objectXML.hasOwnProperty("RateOfFire") && this.objectXML.RateOfFire != 1) {
            this.effects.push(new Effect("Rate of Fire: {rof}", {
                "rof": Math.round(this.objectXML.RateOfFire * 100) + "%"
            }));
        }
    }

    private function addCooldown() : void {
        if (this.objectXML.hasOwnProperty("Cooldown")) {
            this.effects.push(new Effect("Cooldown: {cd}", {
                "cd": this.objectXML.Cooldown + " seconds"
            }));
        }
    }

    private function addSurgeMod() : void {
        if (this.objectXML.hasOwnProperty("SurgeMod")) {
            this.effects.push(new Effect("SurgeMod: {sm}", {
                "sm": this.objectXML.SurgeMod
            }));
        }
    }

    private function addActivateTagsToEffectsList():void {
        var _local_1:XML;
        var _local_2:String;
        var _local_3:int;
        var _local_4:int;
        var _local_5:String;
        var _local_6:String;
        var _local_7:Object;
        var _local_8:String;
        var _local_9:uint;
        var _local_10:XML;
        var _local_11:Object;
        var _local_12:String;
        var _local_13:uint;
        var _local_14:XML;
        var _local_15:String;
        var _local_16:Object;
        var _local_17:String;
        var _local_18:Object;
        var _local_19:Number;
        var _local_20:Number;
        var _local_21:Number;
        var _local_22:Number;
        var _local_23:Number;
        var _local_24:Number;
        var _local_25:Number;
        var _local_26:Number;
        var _local_27:Number;
        var _local_28:Number;
        var _local_29:Number;
        var _local_30:Number;
        var _local_31:AppendingLineBuilder;
        for each (_local_1 in this.objectXML.Activate) {
            _local_5 = this.comparisonResults.processedTags[_local_1.toXMLString()];
            if (this.comparisonResults.processedTags[_local_1.toXMLString()] != true) {
                _local_6 = _local_1.toString();
                switch (_local_6) {
                    case ActivationType.COND_EFFECT_AURA:
                        this.effects.push(new Effect(TextKey.EFFECT_ON_SELF, {"effect": new AppendingLineBuilder().pushParams(TextKey.WITHIN_SQRS, {"range": _local_1.@range}, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag())}));
                        this.effects.push(new Effect(TextKey.EFFECT_FOR_DURATION, {
                            "effect": _local_1.@effect,
                            "duration": _local_1.@duration
                        }).setColor(TooltipHelper.NO_DIFF_COLOR));
                        break;
                    case ActivationType.COND_EFFECT_SELF:
                        this.effects.push(new Effect(TextKey.EFFECT_ON_SELF, {"effect": ""}));
                        this.effects.push(new Effect(TextKey.EFFECT_FOR_DURATION, {
                            "effect": _local_1.@effect,
                            "duration": _local_1.@duration
                        }));
                        break;
                    case ActivationType.STAT_BOOST_SELF:
                        this.effects.push(new Effect("{amount} {stat} for {duration} ",{
                            "amount": prefix(_local_1.@amount),
                            "stat": new LineBuilder().setParams(StatData.statToName(int(_local_1.@stat))),
                            "duration": TooltipHelper.getPlural(_local_1.@duration, "second")
                        }));
                        continue;
                    case ActivationType.HEAL:
                        this.effects.push(new Effect(TextKey.INCREMENT_STAT, {
                            "statAmount": (("+" + _local_1.@amount) + " "),
                            "statName": new LineBuilder().setParams(TextKey.STATUS_BAR_HEALTH_POINTS)
                        }));
                        break;
                    case ActivationType.HEAL_NOVA:
                        this.effects.push(new Effect(TextKey.PARTY_HEAL, {
                            "effect": new AppendingLineBuilder().pushParams(TextKey.HP_WITHIN_SQRS, {
                                "amount": _local_1.@amount,
                                "range": _local_1.@range
                            }, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag())
                        }));
                        break;
                    case ActivationType.MAGIC:
                        this.effects.push(new Effect(TextKey.INCREMENT_STAT, {
                            "statAmount": (("+" + _local_1.@amount) + " "),
                            "statName": new LineBuilder().setParams(TextKey.STATUS_BAR_MANA_POINTS)
                        }));
                        break;
                    case ActivationType.MAGIC_NOVA:
                        this.effects.push(new Effect(TextKey.FILL_PARTY_MAGIC, (((_local_1.@amount + " MP at ") + _local_1.@range) + " sqrs")));
                        break;
                    case ActivationType.TELEPORT:
                        this.effects.push(new Effect(TextKey.BLANK, {"data": new LineBuilder().setParams(TextKey.TELEPORT_TO_TARGET)}));
                        break;
                    case ActivationType.VAMPIRE_BLAST:
                        this.effects.push(new Effect(TextKey.STEAL, {
                            "effect": new AppendingLineBuilder().pushParams(TextKey.HP_WITHIN_SQRS, {
                                "amount": _local_1.@totalDamage,
                                "range": _local_1.@radius
                            }, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag())
                        }));
                        break;
                    case ActivationType.TRAP:
                        _local_7 = ((_local_1.hasOwnProperty("@condEffect")) ? _local_1.@condEffect : new LineBuilder().setParams(TextKey.CONDITION_EFFECT_SLOWED));
                        _local_8 = ((_local_1.hasOwnProperty("@condDuration")) ? _local_1.@condDuration : "5");
                        this.effects.push(new Effect(TextKey.TRAP, {
                            "data": new AppendingLineBuilder().pushParams(TextKey.HP_WITHIN_SQRS, {
                                "amount": _local_1.@totalDamage,
                                "range": _local_1.@radius
                            }, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag()).pushParams(TextKey.EFFECT_FOR_DURATION, {
                                "effect": _local_7,
                                "duration": _local_8
                            }, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag())
                        }));
                        break;
                    case ActivationType.STASIS_BLAST:
                        this.effects.push(new Effect(TextKey.STASIS_GROUP, {"stasis": new AppendingLineBuilder().pushParams(TextKey.SEC_COUNT, {"duration": _local_1.@duration}, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag())}));
                        break;
                    case ActivationType.DECOY:
                        this.effects.push(new Effect(TextKey.DECOY, {"data": new AppendingLineBuilder().pushParams(TextKey.SEC_COUNT, {"duration": _local_1.@duration}, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag())}));
                        break;
                    case ActivationType.LIGHTNING:
                        this.effects.push(new Effect(TextKey.LIGHTNING, {
                            "data": new AppendingLineBuilder().pushParams(TextKey.DAMAGE_TO_TARGETS, {
                                "damage": _local_1.@totalDamage,
                                "targets": _local_1.@maxTargets
                            }, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag())
                        }));
                        break;
                    case ActivationType.BURNING_LIGHTNING:
                        this.effects.push(new Effect(TextKey.LIGHTNING, {
                            "data": new AppendingLineBuilder().pushParams(TextKey.DAMAGE_TO_TARGETS, {
                                "damage": _local_1.@totalDamage,
                                "targets": _local_1.@maxTargets
                            }, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag())
                        }));
                        break;
                    case ActivationType.POISON_GRENADE:
                        this.effects.push(new Effect("Poison Grenade: {data}", {
                            "data": new AppendingLineBuilder().pushParams("Within {radius} sqrs\n" +
                                    "After {throwTime} seconds\n" +
                                    "{impactDamage} immediately + {damage} over {duration} seconds", {
                                "damage": _local_1.@totalDamage,
                                "duration": _local_1.@duration,
                                "radius": _local_1.@radius,
                                "impactDamage": _local_1.@impactDamage,
                                "throwTime": _local_1.@throwTime
                            }, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag())
                        }));
                        break;
                    case ActivationType.REMOVE_NEG_COND:
                        this.effects.push(new Effect(TextKey.REMOVES_NEGATIVE, {}).setColor(TooltipHelper.NO_DIFF_COLOR));
                        break;
                    case ActivationType.REMOVE_NEG_COND_SELF:
                        this.effects.push(new Effect(TextKey.REMOVES_NEGATIVE, {}).setColor(TooltipHelper.NO_DIFF_COLOR));
                        break;
                    case ActivationType.BANNER:
                        this.effects.push(new Effect("Banner: {data}", {
                            "data": new AppendingLineBuilder().pushParams("Within {radius} sqrs\n" +
                                    "Empower allies for {duration} seconds\n" +
                                    "Stays active for {lifetime} seconds", {
                                "lifetime": _local_1.@amount,
                                "duration": _local_1.@duration,
                                "radius": _local_1.@range
                            }, TooltipHelper.getOpenTag(TooltipHelper.NO_DIFF_COLOR), TooltipHelper.getCloseTag())
                        }));
                        break;
                    case ActivationType.GENERIC_ACTIVATE:
                        _local_9 = 16777103;
                        if (this.curItemXML != null) {
                            _local_10 = this.getEffectTag(this.curItemXML, _local_1.@effect);
                            if (_local_10 != null) {
                                _local_19 = Number(_local_1.@range);
                                _local_20 = Number(_local_10.@range);
                                _local_21 = Number(_local_1.@duration);
                                _local_22 = Number(_local_10.@duration);
                                _local_23 = ((_local_19 - _local_20) + (_local_21 - _local_22));
                                if (_local_23 > 0) {
                                    _local_9 = 0xFF00;
                                }
                                else {
                                    if (_local_23 < 0) {
                                        _local_9 = 0xFF0000;
                                    }
                                }
                            }
                        }
                        _local_11 = {
                            "range": _local_1.@range,
                            "effect": _local_1.@effect,
                            "duration": _local_1.@duration
                        };
                        _local_12 = "Within {range} sqrs\n{effect} for {duration} seconds";
                        if (_local_1.@target != "enemy") {
                            this.effects.push(new Effect(TextKey.PARTY_EFFECT, {"effect": LineBuilder.returnStringReplace(_local_12, _local_11)}).setReplacementsColor(_local_9));
                        }
                        else {
                            this.effects.push(new Effect(TextKey.ENEMY_EFFECT, {"effect": LineBuilder.returnStringReplace(_local_12, _local_11)}).setReplacementsColor(_local_9));
                        }
                        break;
                    case ActivationType.STAT_BOOST_AURA:
                        _local_13 = 16777103;
                        if (this.curItemXML != null) {
                            _local_14 = this.getStatTag(this.curItemXML, _local_1.@stat);
                            if (_local_14 != null) {
                                _local_24 = Number(_local_1.@range);
                                _local_25 = Number(_local_14.@range);
                                _local_26 = Number(_local_1.@duration);
                                _local_27 = Number(_local_14.@duration);
                                _local_28 = Number(_local_1.@amount);
                                _local_29 = Number(_local_14.@amount);
                                _local_30 = (((_local_24 - _local_25) + (_local_26 - _local_27)) + (_local_28 - _local_29));
                                if (_local_30 > 0) {
                                    _local_13 = 0xFF00;
                                }
                                else {
                                    if (_local_30 < 0) {
                                        _local_13 = 0xFF0000;
                                    }
                                }
                            }
                        }
                        _local_3 = int(_local_1.@stat);
                        _local_15 = LineBuilder.getLocalizedString2(StatData.statToName(_local_3));
                        _local_16 = {
                            "range": _local_1.@range,
                            "stat": _local_15,
                            "amount": _local_1.@amount,
                            "duration": _local_1.@duration
                        };
                        _local_17 = "Within {range} sqrs\nincrease {stat} by {amount} for {duration} seconds";
                        this.effects.push(new Effect(TextKey.PARTY_EFFECT, {"effect": LineBuilder.returnStringReplace(_local_17, _local_16)}).setReplacementsColor(_local_13));
                        break;
                    case ActivationType.INCREMENT_STAT:
                        _local_3 = int(_local_1.@stat);
                        _local_4 = int(_local_1.@amount);
                        _local_18 = {};
                        if (((!((_local_3 == StatData.HP_STAT))) && (!((_local_3 == StatData.MP_STAT))))) {
                            _local_2 = TextKey.PERMANENTLY_INCREASES;
                            _local_18["statName"] = new LineBuilder().setParams(StatData.statToName(_local_3));
                            this.effects.push(new Effect(_local_2, _local_18).setColor(16777103));
                            break;
                        }
                        _local_2 = TextKey.BLANK;
                        _local_31 = new AppendingLineBuilder().setDelimiter(" ");
                        _local_31.pushParams(TextKey.BLANK, {"data": new StaticStringBuilder(("+" + _local_4))});
                        _local_31.pushParams(StatData.statToName(_local_3));
                        _local_18["data"] = _local_31;
                        this.effects.push(new Effect(_local_2, _local_18));
                        break;
                    case ActivationType.POWER_STAT:
                        _local_3 = int(_local_1.@stat);
                        _local_4 = int(_local_1.@amount);
                        _local_18 = {};
                        if (((!((_local_3 == StatData.HP_STAT))) && (!((_local_3 == StatData.MP_STAT))))) {
                            _local_2 = "Permanently ascends {statName}";
                            _local_18["statName"] = new LineBuilder().setParams(StatData.statToName(_local_3));
                            this.effects.push(new Effect(_local_2, _local_18).setColor(16777103));
                            break;
                        }
                        _local_2 = TextKey.BLANK;
                        _local_31 = new AppendingLineBuilder().setDelimiter(" ");
                        _local_31.pushParams(TextKey.BLANK, {"data": new StaticStringBuilder(("+" + _local_4))});
                        _local_31.pushParams(StatData.statToName(_local_3));
                        _local_18["data"] = _local_31;
                        this.effects.push(new Effect(_local_2, _local_18));
                        break;
                    case ActivationType.TORII:
                        this.effects.push(new Effect("Spawns {type} Torii\n" +
                                "Disappears after {lifetime} seconds\n" +
                                "Applies '{effect}' in a {radius} sqrs area for {duration} seconds", {
                            "lifetime": _local_1.@amount,
                            "duration": _local_1.@duration,
                            "radius": _local_1.@range,
                            "effect": _local_1.@effect,
                            "type": (_local_1.@players == "true" ? "a defensive" : "an offensive")
                        }).setColor(TooltipHelper.NO_DIFF_COLOR));
                        break;
                    case ActivationType.SOR_ACTIVATE:
                        this.effects.push(new Effect("+{amount} Sor Fragments", {
                            "amount": _local_1.@amount
                        }).setColor(TooltipHelper.NO_DIFF_COLOR));
                        break;
                    case ActivationType.DICE:
                        this.effects.push(new Effect("Grants either {effs} for {dur} seconds", {
                            "effs": MoreStringUtil.gcArray(_local_1.@randVals.split(","), "or"),
                            "dur": _local_1.@duration
                        }));
                        break;
                    case ActivationType.RANDOM_CURRENCY:
                        this.effects.push(new Effect("Grants either {vals} {currency}", {
                            "vals": MoreStringUtil.gcArray(_local_1.@randVals.split(","), "or"),
                            "currency": _local_1.@currencyType
                        }));
                        break;
                }
            }
        }
    }

    private function getEffectTag(xml:XML, effectValue:String):XML {
        var matches:XMLList;
        var tag:XML;
        matches = xml.Activate.(text() == ActivationType.GENERIC_ACTIVATE);
        for each (tag in matches) {
            if (tag.@effect == effectValue) {
                return (tag);
            }
        }
        return null;
    }

    private function getStatTag(xml:XML, statValue:String):XML {
        var matches:XMLList;
        var tag:XML;
        matches = xml.Activate.(text() == ActivationType.STAT_BOOST_AURA);
        for each (tag in matches) {
            if (tag.@stat == statValue) {
                return (tag);
            }
        }
        return null;
    }

    private function addActivateOnEquipTagsToEffectsList():void {
        var _local1:XML;
        var _local2:Boolean = true;
        for each (_local1 in this.objectXML.ActivateOnEquip) {
            if (_local2) {
                this.effects.push(new Effect(TextKey.ON_EQUIP, ""));
                _local2 = false;
            }
            if (_local1.toString() == "IncrementStat") {
                this.effects.push(new Effect(TextKey.INCREMENT_STAT, getComparedStatText(_local1,
                         _local1.hasOwnProperty("isPerc") ? _local1.isPerc : false))
                        .setReplacementsColor(this.getComparedStatColor(_local1)));
            }
        }

        for each (_local1 in this.objectXML.Steal) {
            if (_local2) {
                this.effects.push(new Effect(TextKey.ON_EQUIP, ""));
                _local2 = false;
            }
            if (this.objectXML.Steal.@type == "life")
                this.effects.push(new Effect("+" + this.objectXML.Steal.@amount + " Life Steal", {})
                        .setColor(9055202));
            else
                this.effects.push(new Effect("+" + this.objectXML.Steal.@amount + " Mana Leech", {})
                        .setColor(9055202));
        }

        for each (_local1 in this.objectXML.EffectEquip) {
            if (_local2) {
                this.effects.push(new Effect(TextKey.ON_EQUIP, ""));
                _local2 = false;
            }
            var delay:String = (this.objectXML.EffectEquip.@delay % (10 | 15) == 0 && this.objectXML.EffectEquip.@delay > 60) ?
                    this.objectXML.EffectEquip.@delay / 60 + " minutes" :
                    this.objectXML.EffectEquip.@delay + " seconds";
            this.effects.push(new Effect("Grants '" + this.objectXML.EffectEquip.@effect
                    + (this.objectXML.EffectEquip.@delay == 0 ? "'"
                            : "' after " + delay), "")
                    .setColor(9055202));
        }
    }

    private static function getComparedStatText(xml:XML, isPerc:Boolean) : Object {
        var stat:int = int(xml.@stat);
        var amount:int = int(xml.@amount);
        return ({
            "statAmount": prefix(amount) + (isPerc ? "% " : " "),
            "statName": new LineBuilder().setParams(StatData.statToName(stat))
        });
    }

    private static function prefix(input:int) : String {
        var formattedStr:String = (input > -1 ? "+" : "");
        return formattedStr + input;
    }

    private function getComparedStatColor(activateXML:XML):uint {
        var match:XML;
        var otherAmount:int;
        var stat:int = int(activateXML.@stat);
        var amount:int = int(activateXML.@amount);
        var textColor:uint = ((this.playerCanUse) ? TooltipHelper.BETTER_COLOR : TooltipHelper.NO_DIFF_COLOR);
        var otherMatches:XMLList;
        if (this.curItemXML != null) {
            otherMatches = this.curItemXML.ActivateOnEquip.(@stat == stat);
        }
        if (((!((otherMatches == null))) && ((otherMatches.length() == 1)))) {
            match = XML(otherMatches[0]);
            otherAmount = int(match.@amount);
            textColor = TooltipHelper.getTextColor((amount - otherAmount));
        }
        if (amount < 0) {
            textColor = 0xFF0000;
        }
        return (textColor);
    }

    private function addEquipmentItemRestrictions():void {
        if (this.objectXML.hasOwnProperty("Treasure") == false) {
            this.restrictions.push(new Restriction(TextKey.EQUIP_TO_USE, 0xB3B3B3, false));
            if (((this.isInventoryFull) || ((this.inventoryOwnerType == InventoryOwnerTypes.CURRENT_PLAYER)))) {
                this.restrictions.push(new Restriction(TextKey.DOUBLE_CLICK_EQUIP, 0xB3B3B3, false));
            }
            else {
                this.restrictions.push(new Restriction(TextKey.DOUBLE_CLICK_TAKE, 0xB3B3B3, false));
            }
        }
    }


    private function addAbilityItemRestrictions():void {
        this.restrictions.push(new Restriction(TextKey.KEYCODE_TO_USE, 0xFFFFFF, false));
    }

    private function addConsumableItemRestrictions():void {
        this.restrictions.push(new Restriction(TextKey.CONSUMED_WITH_USE, 0xB3B3B3, false));
        if (((this.isInventoryFull) || ((this.inventoryOwnerType == InventoryOwnerTypes.CURRENT_PLAYER)))) {
            this.restrictions.push(new Restriction(TextKey.DOUBLE_CLICK_OR_SHIFT_CLICK_TO_USE, 0xFFFFFF, false));
        }
        else {
            this.restrictions.push(new Restriction(TextKey.DOUBLE_CLICK_TAKE_SHIFT_CLICK_USE, 0xFFFFFF, false));
        }
    }

    private function addReusableItemRestrictions():void {
        this.restrictions.push(new Restriction(TextKey.CAN_BE_USED_MULTIPLE_TIMES, 0xB3B3B3, false));
        this.restrictions.push(new Restriction(TextKey.DOUBLE_CLICK_OR_SHIFT_CLICK_TO_USE, 0xFFFFFF, false));
    }

    private function makeRestrictionList():void {
        var xml:XML;
        var meetsReq:Boolean;
        var stat:int;
        var val:int;
        this.restrictions = new Vector.<Restriction>();

        if (this.objectXML.hasOwnProperty("VaultItem")
                && this.invType != -1
                && this.invType != ObjectLibrary.idToType_["Vault Chest"]) {
            this.restrictions.push(new Restriction(TextKey.STORE_IN_VAULT, 16549442, true));
        }

        if (this.objectXML.hasOwnProperty("Soulbound")) {
            this.restrictions.push(new Restriction(TextKey.ITEM_SOULBOUND, 0xB3B3B3, false));
        }

        if (this.objectXML.hasOwnProperty("@setType")) {
            this.restrictions.push(new Restriction(("This item is a part of " + this.objectXML.attribute("setName")), 0xFF9900, false));
        }

        if (this.objectXML.hasOwnProperty("Legendary")) {
            this.titleText.setColor(0xFFFF00);
        }

        if (this.objectXML.hasOwnProperty("Fabled")) {
            this.titleText.setColor(0xFF0000);
        }

        if (this.objectXML.hasOwnProperty("PoZPage")) {
            this.restrictions.push(new Restriction("This item can be read to activate marks on your account.", 0xFF0000, true));
        }

        if (this.objectXML.hasOwnProperty("Shard") || this.objectXML.hasOwnProperty("Ascended")) {
            this.restrictions.push(new Restriction("This item can be used to forge legendaries.", 16738740, true));
        }

        if (this.objectXML.hasOwnProperty("FabledToken")) {
            this.restrictions.push(new Restriction("This item is used to open raids.", 0xFF00FF, true));
        }

        if (this.playerCanUse) {
            if (this.objectXML.hasOwnProperty("Usable")) {
                this.addAbilityItemRestrictions();
                this.addEquipmentItemRestrictions();
            } else {
                if (this.objectXML.hasOwnProperty("Consumable")) {
                    this.addConsumableItemRestrictions();
                } else {
                    if (this.objectXML.hasOwnProperty("InvUse")) {
                        this.addReusableItemRestrictions();
                    } else {
                        this.addEquipmentItemRestrictions();
                    }
                }
            }
        } else if (this.player != null) {
            this.restrictions.push(new Restriction(TextKey.NOT_USABLE_BY, 16549442, true));
        }

        if (ObjectLibrary.usableBy(this.objectType) != null) {
            this.restrictions.push(new Restriction(TextKey.USABLE_BY, 0xB3B3B3, false));
        }

        for each (xml in this.objectXML.EquipRequirement) {
            meetsReq = ObjectLibrary.playerMeetsRequirement(xml, this.player);
            if (xml.toString() == "Stat") {
                stat = int(xml.@stat);
                val = int(xml.@value);
                this.restrictions.push(
                        new Restriction("Requires " + StatData.statToName(stat) + " of " + val,
                                (meetsReq ? 0xB3B3B3 : 16549442),
                                !meetsReq)
                );
            }
        }
    }

    private function makeLineTwo():void {
        this.line2 = new LineBreakDesign((MAX_WIDTH - 12), 0);
        addChild(this.line2);
    }

    private function makeRestrictionText():void {
        if (this.restrictions.length != 0) {
            this.restrictionsText = new TextFieldDisplayConcrete().setSize(14).setColor(0xB3B3B3).setTextWidth((MAX_WIDTH - 4)).setIndent(-10).setLeftMargin(10).setWordWrap(true).setHTML(true);
            this.restrictionsText.setStringBuilder(this.buildRestrictionsLineBuilder());
            this.restrictionsText.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
            waiter.push(this.restrictionsText.textChanged);
            addChild(this.restrictionsText);
        }
    }

    private function buildRestrictionsLineBuilder():StringBuilder {
        var _local_2:Restriction;
        var _local_3:String;
        var _local_4:String;
        var _local_5:String;
        var _local_1:AppendingLineBuilder = new AppendingLineBuilder();
        for each (_local_2 in this.restrictions) {
            _local_3 = ((_local_2.bold_) ? "<b>" : "");
            _local_3 = _local_3.concat((('<font color="#' + _local_2.color_.toString(16)) + '">'));
            _local_4 = "</font>";
            _local_4 = _local_4.concat(((_local_2.bold_) ? "</b>" : ""));
            _local_5 = ((this.player) ? ObjectLibrary.typeToDisplayId_[this.player.objectType_] : "");
            _local_1.pushParams(_local_2.text_, {
                "unUsableClass": _local_5,
                "usableClasses": this.getUsableClasses(),
                "keyCode": KeyCodes.CharCodeStrings[Parameters.data_.useSpecial]
            }, _local_3, _local_4);
        }
        return (_local_1);
    }

    private function getUsableClasses():StringBuilder {
        var _local_3:String;
        var _local_1:Vector.<String> = ObjectLibrary.usableBy(this.objectType);
        var _local_2:AppendingLineBuilder = new AppendingLineBuilder();
        _local_2.setDelimiter(", ");
        for each (_local_3 in _local_1) {
            _local_2.pushParams(_local_3);
        }
        return (_local_2);
    }

    private function addDescriptionText():void {
        var _local_1:int;
        if (this.objectXML.hasOwnProperty("Legendary")) {
            _local_1 = 0xD4D406;
        }else{
            _local_1 = 0xB3B3B3;
        }
        this.descText = new TextFieldDisplayConcrete().setSize(14).setColor(_local_1).setTextWidth(MAX_WIDTH).setWordWrap(true);
        this.descText.setStringBuilder(new LineBuilder().setParams(String(this.objectXML.Description)));
        this.descText.filters = [new DropShadowFilter(0, 0, 0, 0.5, 12, 12)];
        waiter.push(this.descText.textChanged);
        addChild(this.descText);
    }

    override protected function alignUI():void {
        this.titleText.x = (this.icon.width + 4);
        this.titleText.y = ((this.icon.height / 2) - (this.titleText.height / 2));
        if (this.tierText) {
            this.tierText.y = ((this.icon.height / 2) - (this.tierText.height / 2));
            this.tierText.x = (MAX_WIDTH - 30);
        }
        this.descText.x = 4;
        this.descText.y = (this.icon.height + 2);
        if (contains(this.line1)) {
            this.line1.x = 8;
            this.line1.y = ((this.descText.y + this.descText.height) + 8);
            this.effectsText.x = 4;
            this.effectsText.y = (this.line1.y + 8);
        }
        else {
            this.line1.y = (this.descText.y + this.descText.height);
            this.effectsText.y = this.line1.y;
        }
        this.line2.x = 8;
        this.line2.y = ((this.effectsText.y + this.effectsText.height) + 8);
        var _local_1:uint = (this.line2.y + 8);
        if (this.restrictionsText) {
            this.restrictionsText.x = 4;
            this.restrictionsText.y = _local_1;
            _local_1 = (_local_1 + this.restrictionsText.height);
        }
        if (this.legendaryText) {
            if (contains(this.legendaryText)) {
                this.legendaryText.x = 4;
                this.legendaryText.y = _local_1;
            }
        }
    }

    private function buildCategorySpecificText():void {
        if (this.curItemXML != null) {
            this.comparisonResults = this.slotTypeToTextBuilder.getComparisonResults(this.objectXML, this.curItemXML);
        }
        else {
            this.comparisonResults = new SlotComparisonResult();
        }
    }

    private function handleWisMod():void {
        var _local_3:XML;
        var _local_4:XML;
        var _local_5:String;
        var _local_6:String;
        if (this.player == null) {
            return;
        }
        var _local_1:Number = (this.player.wisdom_ + this.player.wisdomBoost_);
        if (_local_1 < 30) {
            return;
        }
        var _local_2:Vector.<XML> = new Vector.<XML>();
        if (this.curItemXML != null) {
            this.curItemXML = this.curItemXML.copy();
            _local_2.push(this.curItemXML);
        }
        if (this.objectXML != null) {
            this.objectXML = this.objectXML.copy();
            _local_2.push(this.objectXML);
        }
        for each (_local_4 in _local_2) {
            for each (_local_3 in _local_4.Activate) {
                _local_5 = _local_3.toString();
                if (_local_3.@effect != "Stasis") {
                    _local_6 = _local_3.@useWisMod;
                    if (!(((((((_local_6 == "")) || ((_local_6 == "false")))) || ((_local_6 == "0")))) || ((_local_3.@effect == "Stasis")))) {
                        switch (_local_5) {
                            case ActivationType.HEAL_NOVA:
                                _local_3.@amount = this.modifyWisModStat(_local_3.@amount, 0);
                                _local_3.@range = this.modifyWisModStat(_local_3.@range);
                                break;
                            case ActivationType.COND_EFFECT_AURA:
                                _local_3.@duration = this.modifyWisModStat(_local_3.@duration);
                                _local_3.@range = this.modifyWisModStat(_local_3.@range);
                                break;
                            case ActivationType.COND_EFFECT_SELF:
                                _local_3.@duration = this.modifyWisModStat(_local_3.@duration);
                                break;
                            case ActivationType.STAT_BOOST_AURA:
                                _local_3.@amount = this.modifyWisModStat(_local_3.@amount, 0);
                                _local_3.@duration = this.modifyWisModStat(_local_3.@duration);
                                _local_3.@range = this.modifyWisModStat(_local_3.@range);
                                break;
                            case ActivationType.GENERIC_ACTIVATE:
                                _local_3.@duration = this.modifyWisModStat(_local_3.@duration);
                                _local_3.@range = this.modifyWisModStat(_local_3.@range);
                                break;
                            case ActivationType.POISON_GRENADE:
                                _local_3.@impactDamage = this.modifyWisModStat(_local_3.@impactDamage, 0);
                                _local_3.@totalDamage = this.modifyWisModStat(_local_3.@totalDamage, 0);
                                break;
                        }
                    }
                }
            }
        }
    }

    private function modifyWisModStat(_arg_1:String, _arg_2:Number = 1):String {
        var _local_5:Number;
        var _local_6:int;
        var _local_7:Number;
        var _local_3:String = "-1";
        var _local_4:Number = (this.player.wisdom_ + this.player.wisdomBoost_);
        if (_local_4 < 30) {
            _local_3 = _arg_1;
        }
        else {
            _local_5 = Number(_arg_1);
            _local_6 = (((_local_5) < 0) ? -1 : 1);
            _local_7 = (((_local_5 * _local_4) / 150) + (_local_5 * _local_6));
            _local_7 = (Math.floor((_local_7 * Math.pow(10, _arg_2))) / Math.pow(10, _arg_2));
            if ((_local_7 - (int(_local_7) * _local_6)) >= ((1 / Math.pow(10, _arg_2)) * _local_6)) {
                _local_3 = _local_7.toFixed(1);
            }
            else {
                _local_3 = _local_7.toFixed(0);
            }
        }
        return (_local_3);
       }
    }
}//package com.company.assembleegameclient.ui.tooltip

import kabam.rotmg.text.view.stringBuilder.AppendingLineBuilder;
import kabam.rotmg.text.view.stringBuilder.LineBuilder;

class Effect {

    public var name_:String;
    public var valueReplacements_:Object;
    public var replacementColor_:uint = 16777103;
    public var color_:uint = 0xB3B3B3;

    public function Effect(_arg_1:String, _arg_2:Object) {
        this.name_ = _arg_1;
        this.valueReplacements_ = _arg_2;
    }

    public function setColor(_arg_1:uint):Effect {
        this.color_ = _arg_1;
        return (this);
    }

    public function setReplacementsColor(_arg_1:uint):Effect {
        this.replacementColor_ = _arg_1;
        return (this);
    }

    public function getValueReplacementsWithColor():Object {
        var _local_4:String;
        var _local_5:LineBuilder;
        var _local_1:Object = {};
        var _local_2:String = "";
        var _local_3:String = "";
        if (this.replacementColor_) {
            _local_2 = (('</font><font color="#' + this.replacementColor_.toString(16)) + '">');
            _local_3 = (('</font><font color="#' + this.color_.toString(16)) + '">');
        }
        for (_local_4 in this.valueReplacements_) {
            if ((this.valueReplacements_[_local_4] is AppendingLineBuilder)) {
                _local_1[_local_4] = this.valueReplacements_[_local_4];
            }
            else {
                if ((this.valueReplacements_[_local_4] is LineBuilder)) {
                    _local_5 = (this.valueReplacements_[_local_4] as LineBuilder);
                    _local_5.setPrefix(_local_2).setPostfix(_local_3);
                    _local_1[_local_4] = _local_5;
                }
                else {
                    _local_1[_local_4] = ((_local_2 + this.valueReplacements_[_local_4]) + _local_3);
                }
            }
        }
        return (_local_1);
    }


}
class Restriction {

    public var text_:String;
    public var color_:uint;
    public var bold_:Boolean;

    public function Restriction(_arg_1:String, _arg_2:uint, _arg_3:Boolean) {
        this.text_ = _arg_1;
        this.color_ = _arg_2;
        this.bold_ = _arg_3;
    }

}
