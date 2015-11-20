using FluentAssertions;
using System;
using Xunit;

namespace Linear.Core.Tests.Unit
{
    public class JsonEventSerializerTests
    {
        [Fact]
        public void CanSerialize()
        {
            var test = new TestClass
            {
                Id = 1,
                Name = "mantzas",
                BirthDate = new DateTime(2015,12,31,23,59, 59,999),
                Balance = 199.99m
            };

            var result = new JsonEventSerializer().Serialize(test);
            result.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void CanDeserialize()
        {
            const string serialized = "{\"Id\":1,\"Name\":\"mantzas\",\"BirthDate\":\"2015 - 12 - 31T23: 59:59.999\",\"Balance\":199.99}";
            var result = new JsonEventSerializer().Deserialize<TestClass>(serialized);
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Name.Should().Be("mantzas");
            result.BirthDate.Should().Be(new DateTime(2015, 12, 31, 23, 59, 59, 999));
            result.Balance.Should().Be(199.99m);
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
