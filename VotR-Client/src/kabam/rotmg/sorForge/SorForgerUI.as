/**
 * Created by Omniraptor on 6/25/17.
 */
package kabam.rotmg.sorForge {
import com.company.assembleegameclient.game.AGameSprite;
import com.company.assembleegameclient.ui.DeprecatedTextButton;
import com.company.assembleegameclient.ui.FrameChef;

import flash.events.Event;
import flash.events.MouseEvent;

import kabam.rotmg.questrewards.components.ModalItemSlot;

import org.osflash.signals.Signal;

public class SorForgerUI extends FrameChef {

    public const cancel:Signal = new Signal();

    public var gameSprite:AGameSprite;
    public var slot1:ModalItemSlot
    public var slot4:ModalItemSlot;
    public var forgeButton:DeprecatedTextButton
    private var shardImage:Shard_ImageEmbed;
    public function SorForgerUI(_arg_1:AGameSprite) {
        this.gameSprite = _arg_1;
        super("Forge your Legendary Item.", "", 288);
        this.addForgeUI();
        this.forgeButton = new DeprecatedTextButton(16, "Forge");
        this.forgeButton.y = 360;
        this.forgeButton.x = 108;
        addChild(this.forgeButton)
        XButton.addEventListener(MouseEvent.CLICK, this.onClose);
    }

    public function getItemSlot1():ModalItemSlot {
        return (this.slot1);
    }
    public function getItemSlot4():ModalItemSlot {
        return (this.slot4);
    }

    private function addForgeUI() : void {
        this.slot1 = new ModalItemSlot(true, false);
        this.slot1.y = 180;
        this.slot1.x = 85;
        addChild(this.slot1);
        this.slot4 = new ModalItemSlot(true, false);
        this.slot4.y = 100;
        this.slot4.x = this.slot1.x;
        this.slot4.playOutLineAnimation(-1);
        addChild(this.slot4);
        this.shardImage = new Shard_ImageEmbed();
        this.shardImage.y = this.slot1.y;
        this.shardImage.x = this.slot1.x - 60;
        addChild(this.shardImage);
    }



    private function onClose(e:Event) : void {
    }


}
}//package com.company.assembleegameclient.account.ui

