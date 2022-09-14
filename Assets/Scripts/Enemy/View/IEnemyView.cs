namespace Enemy.View
{
    public interface IEnemyView
    {
        void Die();
        void SetHealthBar(int currentHealth, int maximumHealth);
        void DamageReceived();
    }
}