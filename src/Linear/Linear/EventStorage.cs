﻿using Linear.Contracts;
using System;

namespace Linear
{
    public class EventStorage<T> : IEventStorage<T> where T:class
    {
        private readonly IEventSerializer _serializer;
        private readonly IEventRepository<T> _repository;

        public EventStorage(IEventSerializer serializer, IEventRepository<T> repository)
        {
            if(serializer == null)
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

        public bool Append(IEvent<T> data)
        {
            return _repository.Append(data);
        }

        public IEvent<T>[] Get(Guid id)
        {
            return _repository.Get(id);
        }
    }
}
