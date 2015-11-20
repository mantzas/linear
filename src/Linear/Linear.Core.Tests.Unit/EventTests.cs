using System;
using Xunit;

namespace Linear.Core.Tests.Unit
{
    public class EventTests
    {
        [Fact]
        public void Construction_SourceIdEmpty_Throws()
        {
            Assert.Throws<ArgumentException>("sourceId", () => Event<string>.Create(Guid.Empty, "type", "Test"));
        }

        [Fact]
        public void Construction_VersionNegative_Throws()
        {
            Assert.Throws<ArgumentException>("version", () => Event<string>.Create(Guid.NewGuid(), "type", "Test", -1));
        }
    }
}
