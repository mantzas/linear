using System;
using Xunit;
using FluentAssertions;
using NSubstitute;
using Linear.Contracts;

namespace Linear.Tests.Unit
{
    public class EventStorageFactoryTests
    {
        private IEventRepository<string> _repository;
        private IEventSerializer _serializer;

        public EventStorageFactoryTests()
        {
            _repository = Substitute.For<IEventRepository<string>>();
            _serializer = Substitute.For<IEventSerializer>();
        }

        [Fact]
        public void CanConstruct_NullSerializer_Throws()
        {
            Assert.Throws<ArgumentNullException>("serializer", () => new EventStorageFactory<string>(null, _repository));
        }

        [Fact]
        public void CanConstruct_NullRepository_Throws()
        {
            Assert.Throws<ArgumentNullException>("repository", () => new EventStorageFactory<string>(_serializer, null));
        }

        [Fact]
        public void CanCreate()
        {
            var storage = new EventStorageFactory<string>(_serializer, _repository).Create();
            storage.Should().NotBeNull();
        }
    }
}
