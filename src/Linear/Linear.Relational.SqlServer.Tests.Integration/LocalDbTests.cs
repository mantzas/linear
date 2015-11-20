using FluentAssertions;
using Xunit;

namespace Linear.Relational.SqlServer.Tests.Integration
{
    public class LocalDbTests
    {
        [Fact]
        public void LocalDb()
        {
            using (var localDb = new LocalDb("test"))
            {
                localDb.ConnectionStringName.Should().NotBeNullOrWhiteSpace();
            }

        }
    }
}
