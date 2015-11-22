using FluentAssertions;
using Linear.Relational.SqlServer;
using System;
using System.Collections.Generic;
using Xunit;

namespace Linear.SqlServer.Tests.Integration
{
    public class SqlServerEventRepositoryTests : IDisposable
    {
        private LocalDbFixture _fixture;

        public SqlServerEventRepositoryTests()
        {
            _fixture = new LocalDbFixture();
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }

        [Fact]
        public void Append_Success()
        {
            var repository = GetRepository();
            var response = repository.Append(Event<TestClass>.Create(Guid.NewGuid(), "TYPE", GetTestObject(), 1));
            response.Should().BeTrue();
        }

        [Fact]
        public void Append_Multiple_Success()
        {
            var repository = GetRepository();

            for(var i = 0; i < 10; i++)
            {
                var response = repository.Append(Event<TestClass>.Create(Guid.NewGuid(), "TYPE", GetTestObject(), 1));
                response.Should().BeTrue();
            }            
        }

        [Fact]
        public void Get_Empty_Success()
        {
            var repository = GetRepository();
            var events = repository.Get(Guid.NewGuid());

            events.Should().NotBeNull();
            events.Should().BeEmpty();
        }

        [Fact]
        public void Get_Multiple_Success()
        {
            var id = Guid.NewGuid();
            var repository = GetRepository();
            var list = new List<Event<TestClass>>
            {
                Event<TestClass>.Create(id, "TYPE", GetTestObject(), 1),
                Event<TestClass>.Create(id, "TYPE", GetTestObject(), 1),
                Event<TestClass>.Create(id, "TYPE", GetTestObject(), 1),
                Event<TestClass>.Create(id, "TYPE", GetTestObject(), 1),
                Event<TestClass>.Create(id, "TYPE", GetTestObject(), 1)
            };

            foreach (var @event in list)
            {
                var response = repository.Append(@event);
                response.Should().BeTrue();
            }

            var events = repository.Get(id);

            events.Should().NotBeNull();
            events.Should().NotBeEmpty();
            events.ShouldAllBeEquivalentTo(list.ToArray());
        }

        private SqlServerEventRepository<TestClass> GetRepository()
        {
            return new SqlServerEventRepository<TestClass>(new SqlServerConnectionFactory(_fixture.Db.ConnectionStringName), 
                                                           new JsonEventSerializer());
        }

        private TestClass GetTestObject()
        {
            return new TestClass
            {
                Id = 1,
                Name = "Name",
                BirthDate = DateTime.Today,
                Balance = 199.01m
            };
        }

        private class TestClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
            public decimal Balance { get; set; }
        }
    }
}
