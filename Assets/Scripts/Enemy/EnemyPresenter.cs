using Enemy.View;
using UnityEngine;

namespace Enemy
{
    public class EnemyPresenter
    {
        private readonly IEnemy _enemy;
        private readonly IEnemyView _enemyView;

        public EnemyPresenter(IEnemy enemy, IEnemyView enemyView)
        {
            _enemy = enemy;
            _enemyView = enemyView;

            _enemyView.SetHealthBar(_enemy.GetCurrentHealth(), _enemy.GetMaxHealth());
            
            enemy.Died += DisposeEnemy;
            enemy.Damaged += OnEnemyDamaged;
        }

        private void OnEnemyDamaged(int damageAmount)
        {
            _enemyView.DamageReceived();
            _enemyView.SetHealthBar(_enemy.GetCurrentHealth(), _enemy.GetMaxHealth());
        }
        
        private void OnEnemyDie()
        {
            _enemyView.Die();
            Debug.Log("Enemy died");
        }

        private void DisposeEnemy(IEnemy enemy)
        {
            _enemy.Died -= DisposeEnemy;
            OnEnemyDie();
        }
    }
}