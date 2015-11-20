using Linear.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Linear.Core
{
    public class InMemoryEventRepository<T> : IEventRepository<T> where T : class
    {
        private static readonly object SyncLock = new object();
        private readonly Dictionary<Guid, Queue<IEvent<T>>> _db = new Dictionary<Guid, Queue<IEvent<T>>>();

        public bool Append(IEvent<T> data)
        {
            Queue<IEvent<T>> queue;
            
            lock(SyncLock)
            {
                if (_db.TryGetValue(data.SourceId, out queue))
                {
                    queue.Enqueue(data);
                    return true;
                }
                else
                {
                    queue = new Queue<IEvent<T>>();
                    queue.Enqueue(data);
                    _db.Add(data.SourceId, queue);
                    return true;
                }
            }
        }

        public IEvent<T>[] Get(Guid id)
        {
            Queue<IEvent<T>> queue;

            if (_db.TryGetValue(id, out queue))
            {
                return queue.ToArray();
            }

            return new IEvent<T>[0];
        }
    }
}
