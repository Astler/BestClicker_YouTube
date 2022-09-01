using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enemy.Pool;
using Extensions.Enumerable;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyPool))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float spawnDelay = 1f;
        [SerializeField] private int maxEnemies = 3;

        private readonly List<EnemyView> _currentEnemies = new();
        private EnemyPool _enemyPool;
        private Coroutine _spawnCoroutine;

        public Action EnemyKilled;
        public Action<float> RespawnProgress;

        public void TryToHitEnemy()
        {
            if (_currentEnemies.IsNullOrEmpty())
            {
                Debug.Log("No enemy to hit");
                return;
            }

            EnemyView firstEnemy = _currentEnemies.FirstOrDefault();

            if (firstEnemy != null)
            {
                firstEnemy.Die();
                _currentEnemies.Remove(firstEnemy);
                EnemyKilled?.Invoke();
            }
        }

        private void SpawnEnemy() => SpawnEnemy(true);

        private void SpawnEnemy(bool withTimer)
        {
            if (_currentEnemies.Count >= maxEnemies)
            {
                Debug.Log("Already have max enemies");
                _spawnCoroutine = null;
                return;
            }

            if (!withTimer)
            {
                _currentEnemies.Add(_enemyPool.Spawn());
            }

            _spawnCoroutine ??= StartCoroutine(SpawnEnemyTimer());
        }

        private IEnumerator SpawnEnemyTimer()
        {
            float timer = 0f;

            while (timer < spawnDelay)
            {
                timer += Time.deltaTime;
                RespawnProgress?.Invoke(timer / spawnDelay);
                yield return null;
            }

            _currentEnemies.Add(_enemyPool.Spawn());
            RespawnProgress?.Invoke(0f);

            _spawnCoroutine = null;
            SpawnEnemy();
        }

        private void Awake()
        {
            _enemyPool = GetComponent<EnemyPool>();
        }

        private void Start()
        {
            SpawnEnemy(false);
            SpawnEnemy();

            EnemyKilled += SpawnEnemy;
        }

        private void OnDestroy()
        {
            EnemyKilled -= SpawnEnemy;
        }
    }
}