using System.Collections;
using Extensions.Enumerable;
using UnityEngine;
using LightType = AnimatedLight.Data.LightType;

// light animations
// 'm' is normal light, 'a' is no light, 'z' is double bright
namespace AnimatedLight
{
    public abstract class CoreLightAnimator : MonoBehaviour
    {
        [SerializeField] private LightType selectedPattern;

        [SerializeField] private float animationDelay = 3f;
        [SerializeField] private float maxLightIntensity = 1f;
        
        [Space, SerializeField] private float tickTime = 0.1f;
        [SerializeField] private bool smoothTransition;

        [Space, SerializeField] private string pattern;
        
        private int _maxValue;
        private Coroutine _animationCoroutine;
        private Coroutine _transitionCoroutine;
        
        protected abstract float LightIntensity { get; set; }

        protected virtual void OnAwake() {}
        
        private IEnumerator PlayLightAnimation()
        {
            yield return new WaitForSeconds(animationDelay);

            if (pattern.NotNullOrEmpty())
            {
                foreach (char letter in pattern)
                {
                    float targetIntensity = CalculateIntensityByLetter(letter);

                    if (smoothTransition)
                    {
                        if (_transitionCoroutine != null)
                        {
                            StopCoroutine(_transitionCoroutine);
                        }

                        _transitionCoroutine =
                            StartCoroutine(SmoothIntensityTransition(LightIntensity, targetIntensity));
                    }
                    else
                    {
                        LightIntensity = targetIntensity;
                    }

                    yield return new WaitForSeconds(tickTime);
                }
            }
            else
            {
                yield return new WaitForSeconds(tickTime);
            }

            _animationCoroutine = StartCoroutine(PlayLightAnimation());
        }

        private IEnumerator SmoothIntensityTransition(float startIntensity, float targetIntensity)
        {
            float duration = tickTime;
            float stepDuration = tickTime * 0.05f;

            while (duration > 0)
            {
                LightIntensity = Mathf.Lerp(startIntensity, targetIntensity, 1 - duration / tickTime);
                duration -= stepDuration;
                yield return new WaitForSeconds(stepDuration);
            }
        }

        private float CalculateIntensityByLetter(char letter) =>
            (float)CharToInt(letter) / _maxValue * maxLightIntensity * 2;

        private static int CharToInt(char character) => character - 97;

        private void Awake()
        {
            _maxValue = CharToInt('z');
            OnAwake();
        }

        private void OnEnable()
        {
            _animationCoroutine = StartCoroutine(PlayLightAnimation());
        }

        private void OnDestroy()
        {
            if (_animationCoroutine == null) return;
            
            StopCoroutine(_animationCoroutine);
            _animationCoroutine = null;
        }
    }
}