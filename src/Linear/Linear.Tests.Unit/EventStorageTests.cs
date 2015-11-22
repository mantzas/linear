using FluentAssertions;
using Linear.Contracts;
using NSubstitute;
using System;
using Xunit;

namespace Linear.Tests.Unit
{
    public class EventStorageTests
    {
        private readonly IEventRepository<string> _repository;
        private readonly IEventSerializer _serializer;

        public EventStorageTests()
        {
            _repository = Substitute.For<IEventRepository<string>>();
            _serializer = Substitute.For<IEventSerializer>();
        }

        [Fact]
        public void CanConstruct_NullSerializer_Throws()
        {
            Assert.Throws<ArgumentNullException>("serializer", () => new EventStorage<string>(null, _repository));
        }

        [Fact]
        public void CanConstruct_NullRepository_Throws()
        {
            Assert.Throws<ArgumentNullException>("repository", () => new EventStorage<string>(_serializer, null));
        }

        [Fact]
        public void Append_ReturnsTrue()
        {
            _repository.Append(Arg.Any<IEvent<string>>()).Returns(true);
            var result = new EventStorage<string>(_serializer, _repository).Append(Event<string>.Create(Guid.NewGuid(), 
                                                                                                        "type", 
                                                                                                        "test"));

            result.Should().BeTrue();
        }

        [Fact]
        public void Append_ReturnsFalse()
        {
            _repository.Append(Arg.Any<IEvent<string>>()).Returns(false);
            var result = new EventStorage<string>(_serializer, _repository).Append(Event<string>.Create(Guid.NewGuid(),
                                                                                                        "type", 
                                                                                                        "test"));

            result.Should().BeFalse();
        }

        [Fact]
        public void Get_ReturnsEmpty()
        {
            var events = new Event<string>[0];
            _repository.Get(Arg.Any<Guid>()).Returns(events);
            var result = new EventStorage<string>(_serializer, _repository).Get(Guid.NewGuid());

            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void Get_ReturnsFull()
        {
            var events = new Event<string>[] { Event<string>.Create(Guid.NewGuid(), "type", "test") };
            _repository.Get(Arg.Any<Guid>()).Returns(events);
            var result = new EventStorage<string>(_serializer, _repository).Get(Guid.NewGuid());

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.ShouldAllBeEquivalentTo(events);
        }
    }
}
