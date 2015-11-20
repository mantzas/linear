using Linear.Core.Contracts;
using System;

namespace Linear.Core
{
    public class EventStorageFactory : IEventStorageFactory
    {
        private readonly IEventSerializer _serializer;

        public EventStorageFactory(IEventSerializer serializer)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            _serializer = serializer;
        }

        public IEventStorage Create()
        {
            return new EventStorage(_serializer);
        }
    }
}
