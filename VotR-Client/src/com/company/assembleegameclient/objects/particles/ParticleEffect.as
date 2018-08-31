package com.company.assembleegameclient.objects.particles {
import com.company.assembleegameclient.map.Camera;
import com.company.assembleegameclient.objects.GameObject;
import com.company.assembleegameclient.parameters.Parameters;

import flash.display.IGraphicsData;

public class ParticleEffect extends GameObject {

    public var reducedDrawEnabled:Boolean;

    public function ParticleEffect() {
        super(null);
        objectId_ = getNextFakeObjectId();
        hasShadow_ = false;
        this.reducedDrawEnabled = false;
    }

    public static function fromProps(props:EffectProperties, go:GameObject):ParticleEffect {
        if (Parameters.data_.noParticlesMaster && props.id != "Vent") {
            return null;
        }
        switch (props.id) {
            case "Healing":
                return new HealingEffect(go);
            case "Fountain":
                return new FountainEffect(go, props);
            case "FountainSnowy":
                return new FountainSnowyEffect(go, props);
            case "SkyBeam":
                return new SkyBeamEffect(go, props);
            case "Circle":
                return new CircleEffect(go, props);
            case "Heart":
                return new HeartEffect(go, props);
            case "Gas":
                return new GasEffect(go, props);
            case "Vent":
                return new VentEffect(go);
            case "Bubbles":
                return new BubbleEffect(go, props);
            case "XMLEffect":
                return new XMLEffect(go, props);
            case "CustomParticles":
                return ParticleGenerator.attachParticleGenerator(props, go);
            case "Orbiting":
                return new OrbitEffect(props, go);
            case "FollowOrbiting":
                return new FollowOrbitEffect(props, go);
            case "QuadSpaceConcentrate":
                return new QuadSpaceConcentrate(props, go);
        }
        return null;
    }


    override public function update(_arg1:int, _arg2:int):Boolean {
        if (this.reducedDrawEnabled) {
            return (this.runEasyRendering(_arg1, _arg2));
        }
        return (this.runNormalRendering(_arg1, _arg2));
    }

    public function runNormalRendering(_arg1:int, _arg2:int):Boolean {
        return (false);
    }

    public function runEasyRendering(_arg1:int, _arg2:int):Boolean {
        return (false);
    }

    override public function draw(_arg1:Vector.<IGraphicsData>, _arg2:Camera, _arg3:int):void {
    }


}
}
