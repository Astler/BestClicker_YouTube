using System;
using UnityEngine;

namespace Enemy
{
    public class Enemy : IEnemy, IDisposable
    {
        private int _health;
        private readonly int _maxHealth;

        public event Action<int> Damaged;
        public event Action<IEnemy> Died;

        public Enemy(int health)
        {
            _health = health;
            _maxHealth = health;
        }

        public void Damage(int damageAmount)
        {
            if (damageAmount <= 0)
            {
                throw new Exception("Damage can't be less than 0");
            }
            
            _health = Mathf.Max(_health - damageAmount, 0);
            
            Damaged?.Invoke(damageAmount);

            if (_health <= 0)
            {
                Dispose();
            }
        }

        public int GetCurrentHealth() => _health;

        public int GetMaxHealth() => _maxHealth;

        public void Dispose()
        {
            Died?.Invoke(this);
        }
    }
}