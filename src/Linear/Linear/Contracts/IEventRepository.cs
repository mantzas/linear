using System;

namespace Linear.Contracts
{
    public interface IEventRepository<T> where T:class
    {
        bool Append(IEvent<T> data);
        IEvent<T>[] Get(Guid id);
    }
}
