using System;
using Xunit;

namespace Yuya.Net.IoC.Tests
{
    public class IocBuilderTests
    {
        [Fact]
        public void Should_Constructor_When_NameIsNull_Then_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new IocBuilder(null));
        }

        [Fact]
        public void Should_Constructor_When_NameIsNotNull_Then_NamePropertyIsSame()
        {
            const string IOCBUILDERNAME = "IocBuilderName";
            var iocBuilder = new IocBuilder(IOCBUILDERNAME);
            Assert.Equal(IOCBUILDERNAME, iocBuilder.Name);
        }
    }
}
