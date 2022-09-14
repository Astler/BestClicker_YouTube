using System;

namespace Enemy
{
    public interface IEnemy
    {
        public event Action<int> Damaged;
        public event Action<IEnemy> Died;
        
        void Damage(int damageAmount);
        int GetCurrentHealth();
        int GetMaxHealth();
    }
}