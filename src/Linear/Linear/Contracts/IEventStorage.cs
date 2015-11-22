using System;

namespace Linear.Contracts
{
    public interface IEventStorage<T> where T : class
    {
        bool Append(IEvent<T> data);
        IEvent<T>[] Get(Guid id);
    }
}