using System;
using Xunit;

namespace Linear.Core.Tests.Unit
{
    public class EventTests
    {
        [Fact]
        public void Construction_Throws()
        {
            Assert.Throws<ArgumentException>("id", () => new Event<string>(Guid.Empty, DayOfWeek.Friday, "Test"));
        }
    }
}
