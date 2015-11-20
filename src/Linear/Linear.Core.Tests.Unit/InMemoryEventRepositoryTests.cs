using FluentAssertions;
using System;
using Xunit;

namespace Linear.Core.Tests.Unit
{
    public class InMemoryEventRepositoryTests
    {
        [Fact]
        public void Append_Success()
        {
            var repository = new InMemoryEventRepository<string>();
            var data = Event<string>.Create(Guid.NewGuid(), DayOfWeek.Monday, "test");
            var result = repository.Append(data);
            result.Should().BeTrue();            
        }

        [Fact]
        public void Append_Multiple_Success()
        {
            var id = Guid.NewGuid();
            var repository = new InMemoryEventRepository<string>();
            var data1 = Event<string>.Create(id, DayOfWeek.Monday, "test1");
            var data2 = Event<string>.Create(id, DayOfWeek.Tuesday, "test2");
            var data3 = Event<string>.Create(id, DayOfWeek.Wednesday, "test3");
            var data4 = Event<string>.Create(id, DayOfWeek.Thursday, "test4");
            var data5 = Event<string>.Create(id, DayOfWeek.Friday, "test5");
            var result1 = repository.Append(data1);
            var result2 = repository.Append(data2);
            var result3 = repository.Append(data3);
            var result4 = repository.Append(data4);
            var result5 = repository.Append(data5);
            result1.Should().BeTrue();
            result2.Should().BeTrue();
            result3.Should().BeTrue();
            result4.Should().BeTrue();
            result5.Should().BeTrue();
        }

        [Fact]
        public void Get_Empty()
        {
            var repository = new InMemoryEventRepository<string>();
            var result = repository.Get(Guid.NewGuid());
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void Get_Multiple_Success()
        {
            var id = Guid.NewGuid();
            var repository = new InMemoryEventRepository<string>();
            var data1 = Event<string>.Create(id, DayOfWeek.Monday, "test1");
            var data2 = Event<string>.Create(id, DayOfWeek.Tuesday, "test2");
            var data3 = Event<string>.Create(id, DayOfWeek.Wednesday, "test3");
            var data4 = Event<string>.Create(id, DayOfWeek.Thursday, "test4");
            var data5 = Event<string>.Create(id, DayOfWeek.Friday, "test5");
            var expectedResults = new Event<string>[] { data1, data2, data3, data4, data5 };
            repository.Append(data1);
            repository.Append(data2);
            repository.Append(data3);
            repository.Append(data4);
            repository.Append(data5);

            var results = repository.Get(id);

            results.Should().NotBeNull();
            results.Should().NotBeEmpty();
            results.ShouldAllBeEquivalentTo(expectedResults);
        }
    }
}
