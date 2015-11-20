using System;

namespace Linear.Relational.SqlServer.Tests.Integration
{
    public class LocalDbFixture : IDisposable
    {
        public LocalDbFixture()
        {
            Db = new LocalDb("test" + Guid.NewGuid().ToString("N"));
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public LocalDb Db { get; private set; }
    }
}
