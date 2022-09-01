using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyView enemyPrefab;
        [SerializeField] private Transform spawnPosition;

        public EnemyView SpawnEnemy()
        {
            return Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity);
        }
    }
}
