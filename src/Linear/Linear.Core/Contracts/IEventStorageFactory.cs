namespace Linear.Core.Contracts
{
    public interface IEventStorageFactory
    {
        IEventStorage Create();
    }
}