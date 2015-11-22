using System;
using Xunit;

namespace Linear.SqlServer.Tests.Unit
{
    public class SqlServerConnectionFactoryTests 
    {
        [Fact]
        public void Constructor_NullConnectionString_Throws()
        {
            Assert.Throws<ArgumentException>("connectionString", () => new SqlServerConnectionFactory(null));
        }
    }
}
