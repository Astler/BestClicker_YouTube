using System;
using System.Collections;
using Enemy.Data;
using Enemy.Pool;
using UnityEngine;

namespace Enemy
{
    public class EnemyView : MonoBehaviour, IPoolElement<EnemyViewInfo, IPool<EnemyView>>
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private IPool<EnemyView> _pool;

        public void Die()
        {
            SetColor(Color.red);
            StartCoroutine(FadeOut(Despawn));
        }

        private void SetColor(Color color) => spriteRenderer.color = color;

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

        public void Spawned(EnemyViewInfo data, IPool<EnemyView> pool)
        {
            _pool = pool;
            
            SetColor(Color.white);
            
            Debug.Log("Spawned Enemy!");
        }

        public void Despawn()
        {
            _pool?.Despawn(this);
            _pool = null;
        }
    }
}