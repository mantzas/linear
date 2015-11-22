using Linear.Relational.Contracs;
using Linear.Relational.SqlServer;
using NSubstitute;
using System;
using Xunit;

namespace Linear.SqlServer.Tests.Unit
{
    public class SqlServerEventRepositoryTests
    {
        [Fact]
        public void Constructor_NullFactory_Throws()
        {
            Assert.Throws<ArgumentNullException>("connectionFactory", () => new SqlServerEventRepository<string>(null,null));
        }

        [Fact]
        public void Constructor_NullSerializer_Throws()
        {
            var factory = Substitute.For<IDbConnectionFactory>();
            Assert.Throws<ArgumentNullException>("eventSerializer", () => new SqlServerEventRepository<string>(factory, null));
        }
    }
}
