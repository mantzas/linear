using System;

namespace Linear.Relational.Core
{
    public class EventDbModel
    {
        public long Id { get; set; }
        public Guid SourceId { get; set; }
        public string Type { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Payload { get; set; }
        public int Version { get; set; }
    }
}
