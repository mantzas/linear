using System;
using Dapper;
using Linear.Relational.Core.Contracs;
using Linear.Relational.Core;
using System.Collections.Generic;
using Linear.Contracts;

namespace Linear.Relational.SqlServer
{
    public class SqlServerEventRepository<T> : IEventRepository<T> where T : class
    {
        public readonly IDbConnectionFactory _connectionFactory;
        public readonly IEventSerializer _eventSerializer;

        public SqlServerEventRepository(IDbConnectionFactory connectionFactory, IEventSerializer eventSerializer)
        {
            if(connectionFactory == null)
            {
                throw new ArgumentNullException(nameof(connectionFactory));
            }

            if (eventSerializer == null)
            {
                throw new ArgumentNullException(nameof(eventSerializer));
            }

            _connectionFactory = connectionFactory;
            _eventSerializer = eventSerializer;
        }

        public bool Append(IEvent<T> data)
        {
            using (var connection = _connectionFactory.CreateOpened())
            {
                var dbModel = new EventDbModel
                {
                    SourceId = data.SourceId,
                    Type = data.Type.ToString(),
                    Version = data.Version,
                    Created = data.Created,
                    Payload = _eventSerializer.Serialize(data.Payload)
                };
                return connection.Execute("INSERT INTO EventSource (SourceId, Type, Created, Payload, Version)  VALUES (@SourceId, @Type, @Created, @Payload, @Version);", dbModel) == 1;
            }
        }

        public IEvent<T>[] Get(Guid id)
        {
            IEnumerable<EventDbModel> dbEvents;

            using (var connection = _connectionFactory.CreateOpened())
            {
                dbEvents = connection.Query<EventDbModel>("SELECT * FROM EventSource es WHERE es.SourceId = @SourceId", new { SourceId = id });
            }

            var events = new List<IEvent<T>>();

            foreach (var dbEvent in dbEvents)
            {
                var payload = _eventSerializer.Deserialize<T>(dbEvent.Payload);

                events.Add(Event<T>.Create(dbEvent.SourceId, dbEvent.Type, payload, dbEvent.Version, dbEvent.Created));
            }

            return events.ToArray();
        }
    }
}
