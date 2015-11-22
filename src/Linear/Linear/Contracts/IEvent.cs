using System;

namespace Linear.Contracts
{
    public interface IEvent<T> where T:class
    {
        Guid SourceId { get; }
        string Type { get; }
        DateTimeOffset Created { get; }
        T Payload { get; }
        int Version { get; }
    }
}
