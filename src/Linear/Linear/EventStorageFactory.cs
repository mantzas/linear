﻿using Linear.Contracts;
using System;

namespace Linear
{
    public class EventStorageFactory<T> : IEventStorageFactory<T> where T:class
    {
        private readonly IEventSerializer _serializer;
        private readonly IEventRepository<T> _repository;

        public EventStorageFactory(IEventSerializer serializer, IEventRepository<T> repository)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
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
