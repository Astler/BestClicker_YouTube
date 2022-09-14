using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enemy.Data;
using Enemy.Pool;
using Enemy.View;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyPool))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private int maxEnemies = 1;
        [SerializeField] private float spawnDelay = 1f;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform fightPoint;

        private EnemyPool _enemyPool;
        private readonly List<IEnemy> _currentEnemies = new();
        private float _timeFromLastEnemy;
        private Coroutine _spawnCoroutine;

        public Action EnemyKilled;
        public Action<float> RespawnProgress;

        public void TryToHitEnemy(int damageAmount = 1)
        {
            if (_currentEnemies.Count == 0)
            {
                Debug.Log("No enemy to hit");
                return;
            }

            _currentEnemies.FirstOrDefault()?.Damage(damageAmount);
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
                CreateNewEnemy();
                return;
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

            CreateNewEnemy();
            RespawnProgress?.Invoke(0f);

            _spawnCoroutine = null;
            SpawnEnemy();
        }

        private void CreateNewEnemy()
        {
            Enemy newEnemy = new(10);

            void OnEnemyDie(IEnemy enemy)
            {
                enemy.Died -= OnEnemyDie;
                _currentEnemies.Remove(newEnemy);
                EnemyKilled?.Invoke();
            }

            newEnemy.Died += OnEnemyDie;
            
            EnemyView enemyView = _enemyPool.Spawn(new EnemyViewInfo
            {
                SpawnPosition = spawnPoint.position,
                TargetPosition = fightPoint.position,
            });
            
            new EnemyPresenter(newEnemy, enemyView);
                
            _currentEnemies.Add(newEnemy);
        }
        
        private void Awake()
        {
            _enemyPool = GetComponent<EnemyPool>();
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