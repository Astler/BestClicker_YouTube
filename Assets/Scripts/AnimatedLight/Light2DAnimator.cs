using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace AnimatedLight
{
    [RequireComponent(typeof(Light2D))]
    public class Light2DAnimator : CoreLightAnimator
    {
        private Light2D _lightSource;
        
        protected override float LightIntensity
        {
            get => _lightSource.intensity;
            set => _lightSource.intensity = value;
        }

        protected override void OnAwake()
        {
            _lightSource = GetComponent<Light2D>();
        }
    }
}