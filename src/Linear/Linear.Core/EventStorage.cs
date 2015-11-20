using Linear.Core.Contracts;
using System;

namespace Linear.Core
{
    public class EventStorage : IEventStorage
    {
        private readonly IEventSerializer _serializer;

        public EventStorage(IEventSerializer serializer)
        {
            if(serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            _serializer = serializer;
        }

        public bool Append()
        {
            throw new NotImplementedException();
        }
    }
}
