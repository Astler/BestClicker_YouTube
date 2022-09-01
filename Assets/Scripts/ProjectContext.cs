using Data;
using Enemy;
using Screens;
using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    [SerializeField] private MainScreenView mainScreenView;
    [SerializeField] private EnemyController enemyController;

    private void Awake()
    {
        mainScreenView.ButtonClicked += OnClickerButtonClicked;
        mainScreenView.SetKilledScore(PlayerPrefsData.KilledEnemies);

        enemyController.EnemyKilled += OnEnemyKilled;
        enemyController.RespawnProgress += mainScreenView.SetRespawnProgress;
    }

    private void OnDestroy()
    {
        enemyController.EnemyKilled += OnEnemyKilled;
        enemyController.RespawnProgress += mainScreenView.SetRespawnProgress;
    }

    private void OnEnemyKilled()
    {
        PlayerPrefsData.KilledEnemies++;
        mainScreenView.SetKilledScore(PlayerPrefsData.KilledEnemies);
    }

    private void OnClickerButtonClicked()
    {
        enemyController.TryToHitEnemy();
    }
}