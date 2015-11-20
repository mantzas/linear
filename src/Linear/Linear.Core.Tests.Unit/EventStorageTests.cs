using System;
using Xunit;

namespace Linear.Core.Tests.Unit
{
    public class EventStorageTests
    {
        [Fact]
        public void CanConstruct_Throws()
        {
            Assert.Throws<ArgumentNullException>("serializer", () => new EventStorage(null));
        }
    }
}
