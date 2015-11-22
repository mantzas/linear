using System;
using System.Text;

namespace Linear.SqlServer.Tests.Integration
{
    public class LocalDbFixture : IDisposable
    {
        public LocalDbFixture()
        {
            Db = new LocalDb("test" + Guid.NewGuid().ToString("N"));
            SetupTables();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public LocalDb Db { get; private set; }

        private void SetupTables()
        {
            using (var connection = Db.OpenConnection())
            {
                var cmd = connection.CreateCommand();
                var builder = new StringBuilder();
                builder.AppendLine("CREATE TABLE dbo.EventSource(");
                builder.AppendLine("Id BIGINT IDENTITY,");
                builder.AppendLine("SourceId UNIQUEIDENTIFIER NOT NULL,");
                builder.AppendLine("Type NVARCHAR(200) NOT NULL,");
                builder.AppendLine("Created DATETIMEOFFSET NOT NULL,");
                builder.AppendLine("Payload NVARCHAR(MAX) NULL,");
                builder.AppendLine("Version INT NOT NULL,");
                builder.AppendLine("CONSTRAINT PK_EventSource PRIMARY KEY CLUSTERED(Id)");
                builder.AppendLine(") ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]");

                cmd.CommandText = builder.ToString();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
