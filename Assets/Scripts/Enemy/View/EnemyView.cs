using System;
using System.Collections;
using Enemy.Data;
using Enemy.Pool;
using UnityEngine;

namespace Enemy.View
{
    public class EnemyView : MonoBehaviour, IEnemyView, IPoolElement<EnemyViewInfo, IPool<EnemyViewInfo, EnemyView>>
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private EnemyUIView enemyUIView;
        [SerializeField] private EnemyAnimationsView enemyAnimationsView;
        [SerializeField] private float moveDuration = 1f;

        private IPool<EnemyViewInfo, EnemyView> _pool;
        private Transform _transform;

        private Coroutine _moveCoroutine;

        public void Die()
        {
            enemyUIView.HideUI();
            SetColor(Color.red);
            StartCoroutine(FadeOut(Despawn));
        }

        public void DamageReceived()
        {
            enemyAnimationsView.PlayHurtAnimation();
        }
        
        public void SetHealthBar(int currentHealth, int maximumHealth)
        {
            enemyUIView.SetHealth(currentHealth, maximumHealth);
        }

        public void Spawned(EnemyViewInfo data, IPool<EnemyViewInfo, EnemyView> pool)
        {
            _pool = pool;

            enemyUIView.ShowUI();
            SetColor(Color.white);

            _transform.position = data.SpawnPosition;

            MoveTo(data.TargetPosition);

            Debug.Log("Spawned Enemy!");
        }

        public void Despawn()
        {
            _pool?.Despawn(this);
            _pool = null;
        }

        private void MoveTo(Vector3 targetPosition)
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _moveCoroutine = null;
            }

            _moveCoroutine = StartCoroutine(MoveToPosition(moveDuration, targetPosition));
        }

        private void SetColor(Color color) => spriteRenderer.color = color;

        private IEnumerator MoveToPosition(float duration, Vector3 targetPosition)
        {
            float elapsedTime = 0f;
            Vector3 startPosition = _transform.position;
            enemyAnimationsView.PlayWalkAnimation();
            
            while (elapsedTime < duration)
            {
                _transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            enemyAnimationsView.PlayIdleAnimation();
            _transform.position = targetPosition;
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

        private void Awake()
        {
            _transform = transform;
        }
    }
}