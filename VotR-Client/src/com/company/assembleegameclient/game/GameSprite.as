package com.company.assembleegameclient.game {
import com.company.assembleegameclient.game.events.MoneyChangedEvent;
import com.company.assembleegameclient.map.Map;
import com.company.assembleegameclient.objects.GameObject;
import com.company.assembleegameclient.objects.IInteractiveObject;
import com.company.assembleegameclient.objects.Pet;
import com.company.assembleegameclient.objects.Player;
import com.company.assembleegameclient.objects.Projectile;
import com.company.assembleegameclient.parameters.Parameters;
import com.company.assembleegameclient.ui.GuildText;
import com.company.assembleegameclient.ui.RankText;
import com.company.assembleegameclient.ui.menu.PlayerMenu;
import com.company.assembleegameclient.util.TextureRedrawer;
import com.company.util.CachingColorTransformer;
import com.company.util.MoreColorUtil;
import com.company.util.MoreObjectUtil;
import com.company.util.PointUtil;

import flash.display.DisplayObject;
import flash.display.Sprite;
import flash.display.StageScaleMode;
import flash.events.Event;
import flash.events.MouseEvent;
import flash.filters.ColorMatrixFilter;
import flash.utils.ByteArray;
import flash.utils.getTimer;

import kabam.lib.loopedprocs.LoopedCallback;
import kabam.lib.loopedprocs.LoopedProcess;
import kabam.rotmg.account.core.Account;
import kabam.rotmg.arena.view.ArenaTimer;
import kabam.rotmg.arena.view.ArenaWaveCounter;
import kabam.rotmg.chat.view.Chat;
import kabam.rotmg.constants.GeneralConstants;
import kabam.rotmg.core.StaticInjectorContext;
import kabam.rotmg.core.model.MapModel;
import kabam.rotmg.core.model.PlayerModel;
import kabam.rotmg.core.view.Layers;
import kabam.rotmg.dailyLogin.signal.ShowDailyCalendarPopupSignal;
import kabam.rotmg.dialogs.control.AddPopupToStartupQueueSignal;
import kabam.rotmg.dialogs.control.FlushPopupStartupQueueSignal;
import kabam.rotmg.dialogs.control.OpenDialogSignal;
import kabam.rotmg.dialogs.model.DialogsModel;
import kabam.rotmg.game.view.AlertStatusDisplay;
import kabam.rotmg.game.view.DiscordButtonDisplay;
import kabam.rotmg.game.view.CreditDisplay;
import kabam.rotmg.game.view.LootboxModalButton;
import kabam.rotmg.game.view.MarkShopButton;
import kabam.rotmg.game.view.RaidLauncherButton;
import kabam.rotmg.maploading.signals.HideMapLoadingSignal;
import kabam.rotmg.maploading.signals.MapLoadedSignal;
import kabam.rotmg.messaging.impl.GameServerConnectionConcrete;
import kabam.rotmg.messaging.impl.incoming.MapInfo;
import kabam.rotmg.packages.services.PackageModel;
import kabam.rotmg.promotions.model.BeginnersPackageModel;
import kabam.rotmg.promotions.signals.ShowBeginnersPackageSignal;
import kabam.rotmg.servers.api.Server;
import kabam.rotmg.stage3D.Renderer;
import kabam.rotmg.ui.UIUtils;
import kabam.rotmg.ui.view.HUDView;

import org.osflash.signals.Signal;

public class GameSprite extends AGameSprite {
    protected static const PAUSED_FILTER:ColorMatrixFilter = new ColorMatrixFilter(MoreColorUtil.greyscaleFilterMatrix);

    public const monitor:Signal = new Signal(String, int);
    public const modelInitialized:Signal = new Signal();
    public const drawCharacterWindow:Signal = new Signal(Player);

    public var chatBox_:Chat;
    public var isNexus_:Boolean = false;
    public var idleWatcher_:IdleWatcher;
    public var rankText_:RankText;
    public var guildText_:GuildText;
    public var creditDisplay_:CreditDisplay;
    public var alertStatusDisplay:AlertStatusDisplay;
    public var raidLauncherButton:RaidLauncherButton;
    public var lootBoxButton:LootboxModalButton;
    public var markShopButton:MarkShopButton;
    public var arenaTimer:ArenaTimer;
    public var arenaWaveCounter:ArenaWaveCounter;
    public var mapModel:MapModel;
    public var beginnersPackageModel:BeginnersPackageModel;
    public var dialogsModel:DialogsModel;
    public var showBeginnersPackage:ShowBeginnersPackageSignal;
    public var openDailyCalendarPopupSignal:ShowDailyCalendarPopupSignal;
    public var openDialog:OpenDialogSignal;
    public var showPackage:Signal;
    public var packageModel:PackageModel;
    public var addToQueueSignal:AddPopupToStartupQueueSignal;
    public var flushQueueSignal:FlushPopupStartupQueueSignal;
    private var focus:GameObject;
    private var isGameStarted:Boolean;
    private var displaysPosY:uint = 4;
    private var currentPackage:DisplayObject;
    public var chatPlayerMenu:PlayerMenu;
    public var discordButton:DiscordButtonDisplay;

    public function GameSprite(_arg1:Server, _arg2:int, _arg3:Boolean, _arg4:int, _arg5:int, _arg6:ByteArray, _arg7:PlayerModel, _arg8:String, _arg9:Boolean) {
        this.showPackage = new Signal();
        this.currentPackage = new Sprite();
        super();
        this.model = _arg7;
        map = new Map(this);
        addChild(map);
        gsc_ = new GameServerConnectionConcrete(this, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg8, _arg9);
        mui_ = new MapUserInput(this);
        this.chatBox_ = new Chat();
        this.chatBox_.list.addEventListener(MouseEvent.MOUSE_DOWN, this.onChatDown);
        this.chatBox_.list.addEventListener(MouseEvent.MOUSE_UP, this.onChatUp);
        addChild(this.chatBox_);
        this.idleWatcher_ = new IdleWatcher();
    }

    public static function dispatchMapLoaded(_arg1:MapInfo):void {
        var _local2:MapLoadedSignal = StaticInjectorContext.getInjector().getInstance(MapLoadedSignal);
        ((_local2) && (_local2.dispatch(_arg1)));
    }

    private static function hidePreloader():void {
        var _local1:HideMapLoadingSignal = StaticInjectorContext.getInjector().getInstance(HideMapLoadingSignal);
        ((_local1) && (_local1.dispatch()));
    }


    public function onChatDown(_arg1:MouseEvent):void {
        if (this.chatPlayerMenu != null) {
            this.removeChatPlayerMenu();
        }
        mui_.onMouseDown(_arg1);
    }

    public function onChatUp(_arg1:MouseEvent):void {
        mui_.onMouseUp(_arg1);
    }

    override public function setFocus(_arg1:GameObject):void {
        _arg1 = ((_arg1) || (map.player_));
        this.focus = _arg1;
    }

    public function addChatPlayerMenu(_arg1:Player, _arg2:Number, _arg3:Number, _arg4:String = null, _arg5:Boolean = false, _arg6:Boolean = false):void {
        this.removeChatPlayerMenu();
        this.chatPlayerMenu = new PlayerMenu();
        if (_arg4 == null) {
            this.chatPlayerMenu.init(this, _arg1);
        }
        else {
            if (_arg6) {
                this.chatPlayerMenu.initDifferentServer(this, _arg4, _arg5, _arg6);
            }
            else {
                if ((((_arg4.length > 0)) && ((((((_arg4.charAt(0) == "#")) || ((_arg4.charAt(0) == "*")))) || ((_arg4.charAt(0) == "@")))))) {
                    return;
                }
                this.chatPlayerMenu.initDifferentServer(this, _arg4, _arg5);
            }
        }
        addChild(this.chatPlayerMenu);
        this.chatPlayerMenu.x = _arg2;
        this.chatPlayerMenu.y = (_arg3 - this.chatPlayerMenu.height);
    }

    public function removeChatPlayerMenu():void {
        if (((!((this.chatPlayerMenu == null))) && (!((this.chatPlayerMenu.parent == null))))) {
            removeChild(this.chatPlayerMenu);
            this.chatPlayerMenu = null;
        }
    }

    override public function applyMapInfo(_arg1:MapInfo):void {
        map.setProps(_arg1.width_, _arg1.height_, _arg1.name_, _arg1.background_, _arg1.allowPlayerTeleport_, _arg1.showDisplays_);
        dispatchMapLoaded(_arg1);
    }

    public function hudModelInitialized():void {
        hudView = new HUDView();
        hudView.x = 600;
        addChild(hudView);
    }

    override public function initialize():void {
        var _local1:Account;
        map.initialize();
        this.modelInitialized.dispatch();
        if (this.evalIsNotInCombatMapArea()) {
            this.showSafeAreaDisplays();
        }
        if (map.name_ == "Arena" || map.name_ == "DeathArena") {
            this.showTimer();
            this.showWaveCounter();
        }
        _local1 = StaticInjectorContext.getInjector().getInstance(Account);
        if (map.name_ == Map.NEXUS) {
            this.flushQueueSignal.dispatch();
        }
        this.isNexus_ = (map.name_ == Map.NEXUS);
        if (((this.isNexus_) || ((map.name_ == Map.DAILY_QUEST_ROOM)))) {
            this.creditDisplay_ = new CreditDisplay(this, true, true);
        }
        else {
            this.creditDisplay_ = new CreditDisplay(this);
        }
        this.creditDisplay_.x = 594;
        this.creditDisplay_.y = 0;
        addChild(this.creditDisplay_);
        var _local3:Object = {
            "game_net_user_id": _local1.gameNetworkUserId(),
            "game_net": _local1.gameNetwork(),
            "play_platform": _local1.playPlatform()
        };
        MoreObjectUtil.addToObject(_local3, _local1.getCredentials());
        Parameters.save();
        hidePreloader();
        stage.dispatchEvent(new Event(Event.RESIZE));
        this.parent.parent.setChildIndex((this.parent.parent as Layers).top, 2);
    }

    private function showSafeAreaDisplays():void {
        this.showRankText();
        this.showGuildText();
        this.showAlertStatusDisplay();
        this.addDiscordButton();
        this.showRaidLauncher();
        this.showLootboxButton();
        this.showMarkShopButton();
    }

    private function showTimer():void {
        this.arenaTimer = new ArenaTimer();
        this.arenaTimer.y = 5;
        addChild(this.arenaTimer);
    }

    private function showWaveCounter():void {
        this.arenaWaveCounter = new ArenaWaveCounter();
        this.arenaWaveCounter.y = 5;
        this.arenaWaveCounter.x = 5;
        addChild(this.arenaWaveCounter);
    }

    private function addDiscordButton():void {
        this.discordButton = new DiscordButtonDisplay(this);
        this.discordButton.x = 6;
        this.discordButton.y = (this.displaysPosY + 2);
        this.displaysPosY = (this.displaysPosY + UIUtils.NOTIFICATION_SPACE);
        addChild(this.discordButton);
    }

    private function showAlertStatusDisplay():void {
        this.alertStatusDisplay = new AlertStatusDisplay();
        this.alertStatusDisplay.x = 6;
        this.alertStatusDisplay.y = (this.displaysPosY + 2);
        this.displaysPosY = (this.displaysPosY + UIUtils.NOTIFICATION_SPACE);
        addChild(this.alertStatusDisplay);
    }

    private function showRaidLauncher():void {
        this.raidLauncherButton = new RaidLauncherButton();
        this.raidLauncherButton.x = 6;
        this.raidLauncherButton.y = (this.displaysPosY + 2);
        this.displaysPosY = (this.displaysPosY + UIUtils.NOTIFICATION_SPACE);
        addChild(this.raidLauncherButton);
    }

    private function showLootboxButton():void {
        this.lootBoxButton = new LootboxModalButton();
        this.lootBoxButton.x = this.raidLauncherButton.x + 32;
        this.lootBoxButton.y = this.raidLauncherButton.y;
        addChild(this.lootBoxButton);
    }

    private function showMarkShopButton():void {
        this.markShopButton = new MarkShopButton();
        this.markShopButton.x = this.lootBoxButton.x + 32;
        this.markShopButton.y = this.lootBoxButton.y;
        addChild(this.markShopButton);
    }

    private function showGuildText():void {
        this.guildText_ = new GuildText("", -1);
        this.guildText_.x = 64;
        this.guildText_.y = 6;
        addChild(this.guildText_);
    }

    private function showRankText():void {
        this.rankText_ = new RankText(-1, true, false);
        this.rankText_.x = 8;
        this.rankText_.y = this.displaysPosY;
        this.displaysPosY = (this.displaysPosY + UIUtils.NOTIFICATION_SPACE);
        addChild(this.rankText_);
    }

    private function updateNearestInteractive():void {
        var _local4:Number;
        var _local7:GameObject;
        var _local8:IInteractiveObject;
        if (((!(map)) || (!(map.player_)))) {
            return;
        }
        var _local1:Player = map.player_;
        var _local2:Number = GeneralConstants.MAXIMUM_INTERACTION_DISTANCE;
        var _local3:IInteractiveObject;
        var _local5:Number = _local1.x_;
        var _local6:Number = _local1.y_;
        for each (_local7 in map.goDict_) {
            _local8 = (_local7 as IInteractiveObject);
            if (((_local8) && (((!((_local8 is Pet))) || (this.map.isPetYard))))) {
                if ((((Math.abs((_local5 - _local7.x_)) < GeneralConstants.MAXIMUM_INTERACTION_DISTANCE)) || ((Math.abs((_local6 - _local7.y_)) < GeneralConstants.MAXIMUM_INTERACTION_DISTANCE)))) {
                    _local4 = PointUtil.distanceXY(_local7.x_, _local7.y_, _local5, _local6);
                    if ((((_local4 < GeneralConstants.MAXIMUM_INTERACTION_DISTANCE)) && ((_local4 < _local2)))) {
                        _local2 = _local4;
                        _local3 = _local8;
                    }
                }
            }
        }
        this.mapModel.currentInteractiveTarget = _local3;
    }

    public function onScreenResize(e:Event) : void {
        var scaleX:Number = 800 / stage.stageWidth;
        var scaleY:Number = 600 / stage.stageHeight;
        if (this.map != null) {
            this.map.scaleX = scaleX;
            this.map.scaleY = scaleY;
        }
        if (this.hudView != null) {
            this.hudView.scaleX = scaleX / scaleY;
            this.hudView.scaleY = 1;
            this.hudView.y = 0;
            this.hudView.x = 800 - 200 * this.hudView.scaleX;
            if (this.creditDisplay_ != null) {
                this.creditDisplay_.x = this.hudView.x - 6 * this.creditDisplay_.scaleX;
            }
        }
        if (this.chatBox_ != null) {
            this.chatBox_.scaleX = scaleX / scaleY;
            this.chatBox_.scaleY = 1;
            this.chatBox_.y = 300 + 300 * (1 - this.chatBox_.scaleY);
        }
        if (this.rankText_ != null) {
            this.rankText_.scaleX = scaleX;
            this.rankText_.scaleY = scaleY;
            this.rankText_.x = 8 * this.rankText_.scaleX;
            this.rankText_.y = 4 * this.rankText_.scaleY;
        }
        if (this.guildText_ != null) {
            this.guildText_.scaleX = scaleX;
            this.guildText_.scaleY = scaleY;
            this.guildText_.x = 64 * this.guildText_.scaleX;
            this.guildText_.y = 6 * this.guildText_.scaleY;
        }
        if (this.creditDisplay_ != null) {
            this.creditDisplay_.scaleX = scaleX;
            this.creditDisplay_.scaleY = scaleY;
        }
        if (this.discordButton != null) {
            this.discordButton.scaleX = scaleX;
            this.discordButton.scaleY = scaleY;
            this.discordButton.x = 6 * this.discordButton.scaleX;
            this.discordButton.y = 62 * this.discordButton.scaleY;
        }
        if (this.alertStatusDisplay != null) {
            this.alertStatusDisplay.scaleX = scaleX;
            this.alertStatusDisplay.scaleY = scaleY;
            this.alertStatusDisplay.x = 6 * this.alertStatusDisplay.scaleX;
            this.alertStatusDisplay.y = 34 * this.alertStatusDisplay.scaleY;
        }
        if (this.markShopButton != null) {
            this.markShopButton.scaleX = scaleX;
            this.markShopButton.scaleY = scaleY;
            this.markShopButton.x = 70 * this.markShopButton.scaleX;
            this.markShopButton.y = 90 * this.markShopButton.scaleY;
        }
        if (this.lootBoxButton != null) {
            this.lootBoxButton.scaleX = scaleX;
            this.lootBoxButton.scaleY = scaleY;
            this.lootBoxButton.x = 38 * this.lootBoxButton.scaleX;
            this.lootBoxButton.y = 90 * this.lootBoxButton.scaleY;
        }
        if (this.raidLauncherButton != null) {
            this.raidLauncherButton.scaleX = scaleX;
            this.raidLauncherButton.scaleY = scaleY;
            this.raidLauncherButton.x = 6 * this.raidLauncherButton.scaleX;
            this.raidLauncherButton.y = 90 * this.raidLauncherButton.scaleY;
        }
    }

    public function connect():void {
        if (!this.isGameStarted) {
            this.isGameStarted = true;
            Renderer.inGame = true;
            gsc_.connect();
            this.idleWatcher_.start(this);
            lastUpdate_ = getTimer();
            stage.addEventListener(MoneyChangedEvent.MONEY_CHANGED, this.onMoneyChanged);
            stage.addEventListener(Event.ENTER_FRAME, this.onEnterFrame);

            this.parent.parent.setChildIndex((this.parent.parent as Layers).top, 0);
            stage.scaleMode = Parameters.data_.stageScale;
            stage.addEventListener(Event.RESIZE, this.onScreenResize);
            stage.dispatchEvent(new Event(Event.RESIZE));

            LoopedProcess.addProcess(new LoopedCallback(100, this.updateNearestInteractive));
        }
    }

    public function disconnect():void {
        if (this.isGameStarted) {
            this.isGameStarted = false;
            Renderer.inGame = false;
            this.idleWatcher_.stop();
            stage.removeEventListener(MoneyChangedEvent.MONEY_CHANGED, this.onMoneyChanged);
            stage.removeEventListener(Event.ENTER_FRAME, this.onEnterFrame);

            stage.removeEventListener(Event.RESIZE, this.onScreenResize);
            stage.scaleMode = StageScaleMode.EXACT_FIT;
            stage.dispatchEvent(new Event(Event.RESIZE));

            LoopedProcess.destroyAll();
            contains(map) && removeChild(map);
            map.dispose();
            CachingColorTransformer.clear();
            TextureRedrawer.clearCache();
            Projectile.dispose();
            gsc_.disconnect();
        }
    }

    private function onMoneyChanged(_arg1:Event):void {
        gsc_.checkCredits();
    }

    override public function evalIsNotInCombatMapArea():Boolean {
        return ((((((((((((map.name_ == Map.NEXUS)) || ((map.name_ == Map.VAULT)))) || ((map.name_ == Map.GUILD_HALL)))) || ((map.name_ == Map.CLOTH_BAZAAR)))) || ((map.name_ == Map.NEXUS_EXPLANATION)))) || ((map.name_ == Map.DAILY_QUEST_ROOM))));
    }

    private function onEnterFrame(_arg1:Event):void {
        var _local2:int = getTimer();
        var _local3:int = (_local2 - lastUpdate_);
        if (this.idleWatcher_.update(_local3)) {
            closed.dispatch();
            return;
        }
        LoopedProcess.runProcesses(_local2);
        var _local4:int = getTimer();
        map.update(_local2, _local3);
        this.monitor.dispatch("Map.update", (getTimer() - _local4));
        camera_.update(_local3);
        var _local5:Player = map.player_;
        if (this.focus) {
            camera_.configureCamera(this.focus, ((_local5) ? _local5.isHallucinating() : false));
            map.draw(camera_, _local2);
        }
        if (_local5 != null) {
            this.creditDisplay_.draw(_local5.credits_, _local5.fame_, _local5.tokens_, _local5.onrane_, _local5.kantos_);
            this.drawCharacterWindow.dispatch(_local5);
            if (map.name_ == Map.NEXUS) {
                _local5.healthPotionCount_ = Math.min(Math.floor(_local5.restoration_ / 15), 6);
                _local5.magicPotionCount_ = Math.min(Math.floor(_local5.restoration_ / 15), 6);
            }
            if (this.evalIsNotInCombatMapArea()) {
                this.rankText_.draw(_local5.numStars_, _local5.rank_, _local5.admin_);
                this.guildText_.draw(_local5.guildName_, _local5.guildRank_);
                this.guildText_.x = this.rankText_.width + 16;
            }
            if (_local5.isPaused()) {
                hudView.filters = [PAUSED_FILTER];
                map.mouseEnabled = false;
                map.mouseChildren = false;
                hudView.mouseEnabled = false;
                hudView.mouseChildren = false;
            }
            else {
                if (hudView.filters.length > 0) {
                    hudView.filters = [];
                    map.mouseEnabled = true;
                    map.mouseChildren = true;
                    hudView.mouseEnabled = true;
                    hudView.mouseChildren = true;
                }
            }
            moveRecords_.addRecord(_local2, _local5.x_, _local5.y_);
        }
        lastUpdate_ = _local2;
        var _local6:int = (getTimer() - _local2);
        this.monitor.dispatch("GameSprite.loop", _local6);
    }

    public function showPetToolTip(_arg1:Boolean):void {
    }
}
}