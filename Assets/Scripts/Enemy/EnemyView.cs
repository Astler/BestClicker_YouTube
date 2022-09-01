using System;
using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void Die()
        {
            SetColor(Color.red);
            StartCoroutine(FadeOut(() => Destroy(gameObject)));
        }

        private void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }

        private IEnumerator FadeOut(Action callback = null)
        {
            while (spriteRenderer.color.a > 0)
            {
                Color color = spriteRenderer.color;
                color = new Color(color.r, color.g, color.b, color.a - 0.01f);
                spriteRenderer.color = color;
                yield return new WaitForSeconds(0.01f);
            }

            callback?.Invoke();
        }
    }
}