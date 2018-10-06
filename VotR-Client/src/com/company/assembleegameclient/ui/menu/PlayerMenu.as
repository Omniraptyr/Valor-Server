package com.company.assembleegameclient.ui.menu {
import com.company.assembleegameclient.game.AGameSprite;
import com.company.assembleegameclient.objects.Player;
import com.company.assembleegameclient.ui.GameObjectListItem;
import com.company.assembleegameclient.util.GuildUtil;
import com.company.util.AssetLibrary;

import flash.events.Event;
import flash.events.MouseEvent;

import kabam.rotmg.chat.control.ShowChatInputSignal;
import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.text.model.TextKey;

public class PlayerMenu extends Menu {
    public var gs_:AGameSprite;
    public var playerName_:String;
    public var player_:Player;
    public var playerPanel_:GameObjectListItem;

    public function PlayerMenu() {
        super(0x363636, 0xFFFFFF);
    }

    public function initDifferentServer(gs:AGameSprite, name:String,
                                        isGuild:Boolean = false, isOther:Boolean = false):void {
        var option:MenuOption;
        this.gs_ = gs;
        this.playerName_ = name;
        this.player_ = null;
        this.yOffset -= 25;
        option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig", 21)
                , 0xFFFFFF, TextKey.PLAYERMENU_PM);
        option.addEventListener(MouseEvent.CLICK, this.onPrivateMessage);
        addOption(option);
        if (isGuild) {
            option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig", 21)
                    , 0xFFFFFF, TextKey.PLAYERMENU_GUILDCHAT);
            option.addEventListener(MouseEvent.CLICK, this.onGuildMessage);
            addOption(option);
        }
        if (isOther) {
            option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig", 7)
                    , 0xFFFFFF, TextKey.PLAYERMENU_TRADE);
            option.addEventListener(MouseEvent.CLICK, this.onTradeMessage);
            addOption(option);
        }
    }

    public function init(gs:AGameSprite, plr:Player):void {
        var option:MenuOption;
        this.gs_ = gs;
        this.playerName_ = plr.name_;
        this.player_ = plr;
        this.playerPanel_ = new GameObjectListItem(0xB3B3B3, true, this.player_, false, true);
        this.yOffset += 7;
        addChild(this.playerPanel_);

        if (this.gs_.map.allowPlayerTeleport() && this.player_.isTeleportEligible(this.player_)) {
            option = new TeleportMenuOption(this.gs_.map.player_);
            option.addEventListener(MouseEvent.CLICK, this.onTeleport);
            addOption(option);
        }

        if (this.gs_.map.player_.guildRank_ >= GuildUtil.OFFICER
                && plr.guildName_ == null || plr.guildName_.length == 0) {
            option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig", 10)
                    , 0xFFFFFF, TextKey.PLAYERMENU_INVITE);
            option.addEventListener(MouseEvent.CLICK, this.onInvite);
            addOption(option);
        }

        if (!this.player_.starred_) {
            option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterface2", 5)
                    , 0xFFFFFF, TextKey.PLAYERMENU_LOCK);
            option.addEventListener(MouseEvent.CLICK, this.onLock);
            addOption(option);
        } else {
            option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterface2", 6)
                    , 0xFFFFFF, TextKey.PLAYERMENU_UNLOCK);
            option.addEventListener(MouseEvent.CLICK, this.onUnlock);
            addOption(option);
        }

        option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig", 7)
                , 0xFFFFFF, TextKey.PLAYERMENU_TRADE);
        option.addEventListener(MouseEvent.CLICK, this.onTrade);
        addOption(option);

        option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig", 10)
                , 0xFFFFFF, "Gamble");
        option.addEventListener(MouseEvent.CLICK, this.onGamble);
        addOption(option);

        option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig", 21)
                , 0xFFFFFF, TextKey.PLAYERMENU_PM);
        option.addEventListener(MouseEvent.CLICK, this.onPrivateMessage);
        addOption(option);

        if (this.player_.isFellowGuild_) {
            option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig", 21)
                    , 0xFFFFFF, TextKey.PLAYERMENU_GUILDCHAT);
            option.addEventListener(MouseEvent.CLICK, this.onGuildMessage);
            addOption(option);
        }

        if (!this.player_.ignored_) {
            option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig", 8)
                    , 0xFFFFFF, TextKey.FRIEND_BLOCK_BUTTON);
            option.addEventListener(MouseEvent.CLICK, this.onIgnore);
            addOption(option);
        } else {
            option = new MenuOption(AssetLibrary.getImageFromSet("lofiInterfaceBig", 9)
                    , 0xFFFFFF, TextKey.PLAYERMENU_UNIGNORE);
            option.addEventListener(MouseEvent.CLICK, this.onUnignore);
            addOption(option);
        }
    }

    private function onPrivateMessage(e:Event):void {
        var signal:ShowChatInputSignal = StaticInjectorContext.getInjector().getInstance(ShowChatInputSignal);
        signal.dispatch(true, (("/tell " + this.playerName_) + " "));
        remove();
    }

    private function onTradeMessage(e:Event):void {
        var signal:ShowChatInputSignal = StaticInjectorContext.getInjector().getInstance(ShowChatInputSignal);
        signal.dispatch(true, ("/trade " + this.playerName_));
        remove();
    }

    private function onGuildMessage(e:Event):void {
        var signal:ShowChatInputSignal = StaticInjectorContext.getInjector().getInstance(ShowChatInputSignal);
        signal.dispatch(true, "/g ");
        remove();
    }

    private function onTeleport(e:Event):void {
        this.gs_.map.player_.teleportTo(this.player_);
        remove();
    }

    private function onInvite(e:Event):void {
        this.gs_.gsc_.guildInvite(this.playerName_);
        remove();
    }

    private function onLock(_arg1:Event):void {
        this.gs_.map.party_.lockPlayer(this.player_);
        remove();
    }

    private function onUnlock(e:Event):void {
        this.gs_.map.party_.unlockPlayer(this.player_);
        remove();
    }

    private function onTrade(e:Event):void {
        this.gs_.gsc_.requestTrade(this.playerName_);
        remove();
    }

    private function onGamble(e:Event):void {
        this.gs_.gsc_.requestGamble(this.playerName_, 1000);
        remove();
    }

    private function onIgnore(e:Event):void {
        this.gs_.map.party_.ignorePlayer(this.player_);
        remove();
    }

    private function onUnignore(e:Event):void {
        this.gs_.map.party_.unignorePlayer(this.player_);
        remove();
    }
}
}
