namespace Linear.Core.Contracts
{
    public interface IEventStorage<T> where T : class
    {
        bool Append(IEvent<T> data);
    }
}