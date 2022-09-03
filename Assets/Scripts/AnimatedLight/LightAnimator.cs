using UnityEngine;

namespace AnimatedLight
{
    [RequireComponent(typeof(Light))]
    public class LightAnimator : CoreLightAnimator
    {
        private Light _lightSource;

        protected override float LightIntensity
        {
            get => _lightSource.intensity;
            set => _lightSource.intensity = value;
        }

        protected override void OnAwake()
        {
            _lightSource = GetComponent<Light>();
        }
    }
}