package com.company.assembleegameclient.sound {
import com.company.assembleegameclient.parameters.Parameters;

import flash.events.Event;
import flash.events.IOErrorEvent;
import flash.media.Sound;
import flash.media.SoundChannel;
import flash.media.SoundTransform;
import flash.net.URLRequest;
import flash.utils.Dictionary;

import kabam.rotmg.application.api.ApplicationSetup;
import kabam.rotmg.core.StaticInjectorContext;

public class SoundEffectLibrary {
    private static const URL_PATTERN:String = "{URLBASE}/sfx/{NAME}.mp3";

    private static var urlBase:String;
    public static var nameMap_:Dictionary = new Dictionary();
    private static var activeSfxList_:Dictionary = new Dictionary(true);

    public static function load(name:String):Sound {
        return nameMap_[name] = nameMap_[name] || makeSound(name);
    }

    public static function makeSound(name:String):Sound {
        var sound:Sound = new Sound();
        sound.addEventListener(IOErrorEvent.IO_ERROR, onIOError);
        sound.load(makeSoundRequest(name));
        return sound;
    }

    private static function getUrlBase():String {
        var setup:ApplicationSetup;
        var base:String = "";
        try {
            setup = StaticInjectorContext.getInjector().getInstance(ApplicationSetup);
            base = setup.getAppEngineUrl(true);
        } catch (error:Error) {
            base = "localhost";
        }
        return base;
    }

    private static function makeSoundRequest(name:String):URLRequest {
        urlBase = urlBase || getUrlBase();
        var url:String = URL_PATTERN.replace("{URLBASE}", urlBase).replace("{NAME}", name);
        return new URLRequest(url);
    }

    public static function play(name:String, volumeMultiplier:Number = 1, isFX:Boolean = true):void {
        try {
            var volume:* = Parameters.data_.SFXVolume * volumeMultiplier;
            if ((!Parameters.data_.playSFX && isFX) || (!isFX && !Parameters.data_.playPewPew) || volume == 0) return;

            var trans:SoundTransform;
            var channel:SoundChannel;
            var sound:Sound = load(name);

            trans = new SoundTransform(volume);
            channel = sound.play(0, 0, trans);
            channel.addEventListener(Event.SOUND_COMPLETE, onSoundComplete, false, 0, true);
            activeSfxList_[channel] = volume;
        } catch (error:Error) {}
    }

    private static function onSoundComplete(e:Event):void {
        var channel:SoundChannel = (e.target as SoundChannel);
        delete activeSfxList_[channel];
    }

    public static function updateVolume(vol:Number):void {
        var channel:SoundChannel;
        var trans:SoundTransform;
        for each (channel in activeSfxList_) {
            activeSfxList_[channel] = vol;
            trans = channel.soundTransform;
            trans.volume = (Parameters.data_.playSFX ? activeSfxList_[channel] : 0);
            channel.soundTransform = trans;
        }
    }

    public static function updateTransform():void {
        var channel:SoundChannel;
        var trans:SoundTransform;
        for each (channel in activeSfxList_) {
            trans = channel.soundTransform;
            trans.volume = (Parameters.data_.playSFX ? activeSfxList_[channel] : 0);
            channel.soundTransform = trans;
        }
    }

    public static function onIOError(e:IOErrorEvent):void {}
}
}
