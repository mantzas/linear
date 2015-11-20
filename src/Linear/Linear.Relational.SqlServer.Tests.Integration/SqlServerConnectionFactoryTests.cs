using System;
using Xunit;

namespace Linear.Relational.SqlServer.Tests.Integration
{
    public class SqlServerConnectionFactoryTests : IClassFixture<LocalDbFixture>
    {
        private LocalDbFixture _fixture;

        public SqlServerConnectionFactoryTests(LocalDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Constructor_NullConnectionString_Throws()
        {
            Assert.Throws<ArgumentException>("connectionString", () => new SqlServerConnectionFactory(null));
        }

        [Fact]
        public void Constructor_Throws()
        {
            var factory = new SqlServerConnectionFactory(_fixture.Db.ConnectionStringName);

            using (var connection = factory.CreateOpened())
            {
                Assert.Equal(System.Data.ConnectionState.Open, connection.State);
            }
        }
    }
}
