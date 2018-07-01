using System;
using Xunit;

namespace Yuya.Net.IoC.Tests
{
    /// <summary>
    /// Ioc Builder Tests
    /// </summary>
    public class IocBuilderTests
    {
        /// <summary>
        /// Shoulds the constructor when name is null then throw exception.
        /// </summary>
        [Fact]
        public void Should_Constructor_When_NameIsNull_Then_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new IocBuilder(null));
        }

        /// <summary>
        /// Shoulds the constructor when name is not null then name property is same.
        /// </summary>
        [Fact]
        public void Should_Constructor_When_NameIsNotNull_Then_NamePropertyIsSame()
        {
            const string IOCBUILDERNAME = "IocBuilderName";
            var iocBuilder = new IocBuilder(IOCBUILDERNAME);
            Assert.Equal(IOCBUILDERNAME, iocBuilder.Name);
        }
    }
}
