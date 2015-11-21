using Linear.Core.Contracts;
using System;

namespace Linear.Core
{
    public class Event<T> : IEvent<T> where T : class
    {
        private Event(Guid sourceId, string type, T payload, int version, DateTimeOffset created) : 
            this(sourceId, type, payload, version)
        {
            Created = created;
        }

        private Event(Guid sourceId, string type, T payload, int version)
        {
            if(sourceId == Guid.Empty)
            {
                throw new ArgumentException("Value cannot be empty!", nameof(sourceId));
            }

            if(version < 0)
            {
                throw new ArgumentException("Value should be zero or positive!", nameof(version));
            }

            SourceId = sourceId;
            Type = type;
            Payload = payload;
            Created = DateTimeOffset.UtcNow;
            Version = version;
        }

        public Guid SourceId { get; private set; }
        public DateTimeOffset Created { get; private set; }
        public T Payload { get; private set; }
        public string Type { get; private set; }
        public int Version { get; private set; }

        public static Event<T> Create(Guid sourceId, string type, T payload, int version = 0)
        {
            return new Event<T>(sourceId, type, payload, version);
        }

        public static Event<T> Create(Guid sourceId, string type, T payload, int version, DateTimeOffset created)
        {
            return new Event<T>(sourceId, type, payload, version, created);
        }
    }
}
