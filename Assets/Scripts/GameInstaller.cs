using System;
using Data;
using Enemy;
using Screens;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private MainScreenView mainScreenView;
    [SerializeField] private EnemyController enemyController;

    private void Awake()
    {
        mainScreenView.ButtonClicked += OnClickerButtonClicked;
        mainScreenView.SetKilledScore(PlayerPrefsData.KilledEnemies);

        enemyController.EnemyKilled += OnEnemyKilled;
    }

    private void Update()
    {
        mainScreenView.SetRespawnProgress(enemyController.GetRespawnProgress());
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