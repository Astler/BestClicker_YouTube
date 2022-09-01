namespace Enemy.Pool
{
    public interface IPoolElement<D, IPool>
    {
        void Spawned(D data, IPool pool);
        void Despawn();
    }
}