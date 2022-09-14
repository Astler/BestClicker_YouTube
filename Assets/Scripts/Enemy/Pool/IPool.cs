namespace Enemy.Pool
{
    public interface IPool<D, T>
    {
        T Spawn(D data);
        void Despawn(T element);
    }
}