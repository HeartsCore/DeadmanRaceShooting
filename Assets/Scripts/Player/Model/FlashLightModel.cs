using UnityEngine;

namespace DeadmanRace
{
    public sealed class FlashLightModel : IModel
    {
        private readonly float _batteryChargeMax = 100.0f;
        public float Intensity = 1.5f;
        public float Share;
        public float TakeAwayTheIntensity;
        public Light Light { get;}
        public float Charge => BatteryChargeCurrent / BatteryChargeMax;
        public float BatteryChargeMax => _batteryChargeMax;
        public Transform GoFollow { get;} 
        public float BatteryChargeCurrent;
        public float Speed { get;}= 10;
        public Transform Transform { get; }
        public GameObject GameObject { get; }

        public FlashLightModel(GameObject instance)
        {
            GameObject = instance;
            Transform = instance.transform;
            Light = GameObject.GetComponent<Light>();
            Light.range = 90.0f;
            Light.spotAngle = 40.0f;
            Light.intensity = 1.3f;
            Light.bounceIntensity = 0.0f;
            Light.shadows = LightShadows.Soft;
            GoFollow = Camera.main.transform;
            BatteryChargeCurrent = _batteryChargeMax;
            Light.intensity = Intensity;
            Share = BatteryChargeMax / 4;
            TakeAwayTheIntensity = Intensity / (BatteryChargeMax * 100);
        }
    }
}
