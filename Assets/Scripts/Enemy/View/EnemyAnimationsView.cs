using System;
using System.Collections;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace Enemy.View
{
    public class EnemyAnimationsView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private SpriteLibrary library;
        [SerializeField] private Animator animator;
        private static readonly int Walking = Animator.StringToHash("walking");
        private static readonly int Idling = Animator.StringToHash("idling");
        private static readonly int Hurt = Animator.StringToHash("hurt");

        public void SetColor(Color color) => spriteRenderer.color = color;

        public void SetSpriteLibrary(SpriteLibraryAsset asset)
        {
            library.spriteLibraryAsset = asset;
        }

        public void PlayWalkAnimation()
        {
            animator.SetBool(Walking, true);
            animator.SetBool(Idling, false);
        }

        public void PlayIdleAnimation()
        {
            animator.SetBool(Walking, false);
            animator.SetBool(Idling, true);
        }

        public void PlayHurtAnimation()
        {
            animator.SetTrigger(Hurt);
        }

        private IEnumerator FadeOut(Action callback = null)
        {
            while (spriteRenderer.color.a > 0)
            {
                Color color = spriteRenderer.color;
                color = new Color(color.r, color.g, color.b, color.a - 0.05f);
                spriteRenderer.color = color;
                yield return new WaitForSeconds(0.01f);
            }

            callback?.Invoke();
        }

        public void StartFadeOutAnimation(Action despawn)
        {
            StartCoroutine(FadeOut(despawn));
        }
    }
}