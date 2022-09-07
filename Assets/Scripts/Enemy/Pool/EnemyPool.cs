using System.Collections.Generic;
using Enemy.Data;
using UnityEngine;

namespace Enemy.Pool
{
    public class EnemyPool : MonoBehaviour, IPool<EnemyView>
    {
        [SerializeField] private int poolSize = 5;
        [Space, SerializeField] private EnemyView enemyPrefab;
        [SerializeField] private Transform spawnPosition;

        private readonly Stack<EnemyView> _enemyPool = new();

        private void Awake()
        {
            for (int i = 0; i < poolSize; i++)
            {
                CreatePoolElement();
            }
        }

        public EnemyView Spawn()
        {
            if (_enemyPool.Count == 0) CreatePoolElement();

            EnemyView enemy = _enemyPool.Pop();
            enemy.gameObject.SetActive(true);
            enemy.Spawned(new EnemyViewInfo(), this);
            return enemy;
        }

        public void Despawn(EnemyView element)
        {
            element.gameObject.SetActive(false);
            _enemyPool.Push(element);
        }

        private void CreatePoolElement()
        {
            EnemyView poolObject = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity, transform);
            poolObject.gameObject.SetActive(false);
            _enemyPool.Push(poolObject);
        }
    }
}