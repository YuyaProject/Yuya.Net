using Shouldly;
using System;
using Xunit;
using Yuya.Net.Serializers;

namespace Yuya.Net.Core.Tests
{
    public class DataContractJsonSerializerTests
    {
        [Fact]
        public void Should_SerializeObject_When_SerializedObjectParameterIsNull_Then_ThrowException()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer();
            Should.Throw<ArgumentNullException>(() => serializer.SerializeObject(null));
        }

        [Fact]
        public void Should_SerializeObject_When_SerializedObjectParameterIsString_Then_ThrowException()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer();
            Should.Throw<ArgumentException>(() => serializer.SerializeObject("deneme"));
        }


        [Fact]
        public void Should_DeserializeObject_When_SerializedObjectParameterIsNull_Then_ThrowException()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer();
            Should.Throw<ArgumentNullException>(() => serializer.DeserializeObject<string>(null));
        }
    }
}
