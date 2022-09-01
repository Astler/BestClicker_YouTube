using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private float spawnDelay = 2f;

        private EnemyView _currentEnemy;
        private float _timeFromLastEnemy;

        public Action EnemyKilled;

        public float GetRespawnProgress() => _timeFromLastEnemy / spawnDelay;

        public void TryToHitEnemy()
        {
            if (!_currentEnemy)
            {
                Debug.Log("No enemy to hit");
                return;
            }

            _currentEnemy.Die();
            _currentEnemy = null;

            EnemyKilled?.Invoke();
        }

        private void Update()
        {
            if (_currentEnemy) return;

            if (_timeFromLastEnemy > spawnDelay)
            {
                _currentEnemy = enemySpawner.SpawnEnemy();
                _timeFromLastEnemy = 0f;
            }
            else
            {
                _timeFromLastEnemy += Time.deltaTime;
            }
        }
    }
}