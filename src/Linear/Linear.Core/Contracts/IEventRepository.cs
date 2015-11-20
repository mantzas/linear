using System;

namespace Linear.Core.Contracts
{
    public interface IEventRepository<T> where T:class
    {
        bool Append(IEvent<T> data);
        IEvent<T>[] Get(Guid id);
    }
}
