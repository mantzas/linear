using Linear.Core.Contracts;
using NSubstitute;
using System;
using Xunit;

namespace Linear.Core.Tests.Unit
{
    public class EventStorageTests
    {
        [Fact]
        public void CanConstruct_NullSerializer_Throws()
        {
            var repository = Substitute.For<IEventRepository<string>>();
            Assert.Throws<ArgumentNullException>("serializer", () => new EventStorage<string>(null, repository));
        }

        [Fact]
        public void CanConstruct_NullRepository_Throws()
        {
            var serializer = Substitute.For<IEventSerializer>();
            Assert.Throws<ArgumentNullException>("repository", () => new EventStorage<string>(serializer, null));
        }
    }
}
