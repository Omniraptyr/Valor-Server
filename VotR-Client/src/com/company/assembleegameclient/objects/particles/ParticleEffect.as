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
        if (Parameters.data_.noParticlesMaster
                && (props.id != "Vent"
                || go == go.map_.player_ && props.id != "CustomParticles")) {
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


    override public function update(time:int, dt:int):Boolean {
        if (this.reducedDrawEnabled) {
            return (this.runEasyRendering(time, dt));
        }
        return this.runNormalRendering(time, dt);
    }

    public function runNormalRendering(time:int, dt:int):Boolean {
        return false;
    }

    public function runEasyRendering(time:int, dt:int):Boolean {
        return false;
    }

    override public function draw(gfx:Vector.<IGraphicsData>, camera:Camera, time:int):void {
    }
}
}
