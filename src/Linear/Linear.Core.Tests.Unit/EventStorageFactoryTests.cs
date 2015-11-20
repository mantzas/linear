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
        public void CanConstruct_NullSerializer_Throws()
        {
            var repository = Substitute.For<IEventRepository<string>>();
            Assert.Throws<ArgumentNullException>("serializer", () => new EventStorageFactory<string>(null, repository));
        }

        [Fact]
        public void CanConstruct_NullRepository_Throws()
        {
            var serializer = Substitute.For<IEventSerializer>();
            Assert.Throws<ArgumentNullException>("repository", () => new EventStorageFactory<string>(serializer, null));
        }

        [Fact]
        public void CanCreate()
        {
            var serializer = Substitute.For<IEventSerializer>();
            var repository = Substitute.For<IEventRepository<string>>();
            var storage = new EventStorageFactory<string>(serializer, repository).Create();
            storage.Should().NotBeNull();
        }
    }
}
