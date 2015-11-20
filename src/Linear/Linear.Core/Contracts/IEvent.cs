using System;

namespace Linear.Core.Contracts
{
    public interface IEvent<T> where T:class
    {
        Guid SourceId { get; }
        Enum Type { get; }
        DateTimeOffset Created { get; }
        T Payload { get; }
        int Version { get; }
    }
}
