 using System.Collections.Generic;
using Enemy.Data;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(fileName = "GameAssetsScriptableObject", menuName = "SO/Game/GameAssetsScriptableObject")]
    public class GameAssetsScriptableObject: ScriptableObject
    {
        [SerializeField] private List<EnemyScriptableObject> enemies;
        
        public EnemyAssetInfo GetRandomEnemyInfo()
        {
            var enemy = enemies[Random.Range(0, enemies.Count)];

            return new EnemyAssetInfo
            {
                SpriteLibrary = enemy.GetSpriteLibraryAsset(),
                InterfaceShift = enemy.GetInterfaceShift()
            };
        }
    }
}