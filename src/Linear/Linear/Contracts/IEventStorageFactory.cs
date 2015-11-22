namespace Linear.Contracts
{
    public interface IEventStorageFactory<T> where T:class
    {
        IEventStorage<T> Create();
    }
}