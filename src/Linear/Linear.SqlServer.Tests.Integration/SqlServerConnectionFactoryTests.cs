using Xunit;

namespace Linear.SqlServer.Tests.Integration
{
    public class SqlServerConnectionFactoryTests : IClassFixture<LocalDbFixture>
    {
        private readonly LocalDbFixture _fixture;

        public SqlServerConnectionFactoryTests(LocalDbFixture fixture)
        {
            _fixture = fixture;
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
