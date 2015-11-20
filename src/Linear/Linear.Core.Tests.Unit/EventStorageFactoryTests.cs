using System;
using Xunit;
using FluentAssertions;
using Linear.Core.Contracts;
using NSubstitute;

namespace Linear.Core.Tests.Unit
{
    public class EventStorageFactoryTests
    {
        [Fact]
        public void CanConstruct_Throws()
        {
            Assert.Throws<ArgumentNullException>("serializer", () => new EventStorageFactory(null));
        }

        [Fact]
        public void CanCreate()
        {
            var serializer = Substitute.For<IEventSerializer>();
            var storage = new EventStorageFactory(serializer).Create();
            storage.Should().NotBeNull();
        }
    }
}
