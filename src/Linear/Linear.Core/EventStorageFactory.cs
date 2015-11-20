using Linear.Core.Contracts;
using System;

namespace Linear.Core
{
    public class EventStorageFactory<T> : IEventStorageFactory<T> where T:class
    {
        private readonly IEventSerializer _serializer;
        private readonly IEventRepository<T> _repository;

        public EventStorageFactory(IEventSerializer serializer, IEventRepository<T> repository)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _serializer = serializer;
            _repository = repository;
        }

        public IEventStorage<T> Create()
        {
            return new EventStorage<T>(_serializer, _repository);
        }
    }
}
