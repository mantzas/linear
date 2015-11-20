using Linear.Core.Contracts;
using System;

namespace Linear.Core
{
    public class EventStorage<T> : IEventStorage<T> where T:class
    {
        private readonly IEventSerializer _serializer;

        public EventStorage(IEventSerializer serializer, IEventRepository<T> repository)
        {
            if(serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _serializer = serializer;
        }

        public bool Append(IEvent<T> data)
        {
            throw new NotImplementedException();
        }
    }
}
