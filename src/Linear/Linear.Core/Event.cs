using Linear.Core.Contracts;
using System;

namespace Linear.Core
{
    public class Event<T> : IEvent<T> where T : class
    {
        public Event(Enum type, T payload)
        {
            Id = Guid.NewGuid();
            Type = type;
            Payload = payload;
            Created = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; private set; }
        public DateTimeOffset Created { get; private set; }
        public T Payload { get; private set; }
        public Enum Type { get; private set; }
    }
}
