namespace Enemy.Pool
{
    public interface IPool<T>
    {
        T Spawn();
        void Despawn(T element);
    }
}