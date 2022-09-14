using System.Collections.Generic;
using Enemy.Data;
using Enemy.View;
using UnityEngine;

namespace Enemy.Pool
{
    public class EnemyPool : MonoBehaviour, IPool<EnemyViewInfo, EnemyView>
    {
        [SerializeField] private int poolSize = 5;
        [Space, SerializeField] private EnemyView enemyPrefab;

        private Transform _transform;
        private readonly Stack<EnemyView> _enemyPool = new();

        public EnemyView Spawn(EnemyViewInfo enemyViewInfo)
        {
            if (_enemyPool.Count == 0) CreatePoolElement();

            EnemyView enemy = _enemyPool.Pop();
            enemy.gameObject.SetActive(true);
            enemy.Spawned(enemyViewInfo, this);
            return enemy;
        }

        public void Despawn(EnemyView element)
        {
            element.gameObject.SetActive(false);
            _enemyPool.Push(element);
        }

        private void CreatePoolElement()
        {
            EnemyView poolObject = Instantiate(enemyPrefab, _transform.position, Quaternion.identity, _transform);
            poolObject.gameObject.SetActive(false);
            _enemyPool.Push(poolObject);
        }

        private void Awake()
        {
            _transform = transform;

            for (int i = 0; i < poolSize; i++)
            {
                CreatePoolElement();
            }
        }
    }
}