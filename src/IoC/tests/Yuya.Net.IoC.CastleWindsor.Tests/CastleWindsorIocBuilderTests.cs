using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace Yuya.Net.IoC.CastleWindsor.Tests
{
    /// <summary>
    /// Castle Windsor Ioc Builder Tests
    /// </summary>
    public class CastleWindsorIocBuilderTests
    {
        /// <summary>
        /// Shoulds the type of the instance when initialize return same name and.
        /// </summary>
        [Fact]
        public void Should_Instance_When_Initialize_Return_SameNameAndType()
        {
            IocBuilder builder = new IocBuilder("Demo");
            var castleWindsorIocBuilder = builder.UseCastleWindsor();
            castleWindsorIocBuilder.Name.ShouldBe("Demo");
            castleWindsorIocBuilder.Type.ShouldBe("CastleWindsor");
        }

        /// <summary>
        /// Shoulds the create when no parameter return castle windsor ioc manager instance.
        /// </summary>
        [Fact]
        public void Should_Create_When_NoParameter_Return_CastleWindsorIocManagerInstance()
        {
            IIocManager iocManager = CreateTestIocManager();

            iocManager.ShouldBeOfType<CastleWindsorIocManager>();
            iocManager.Name.ShouldBe("Demo");
            iocManager.IocTypeName.ShouldBe("CastleWindsor");
        }

        /// <summary>
        /// Creates the test ioc manager.
        /// </summary>
        /// <returns></returns>
        private static IIocManager CreateTestIocManager()
        {
            IocBuilder builder = new IocBuilder("Demo");
            CastleWindsorIocBuilder castleWindsorIocBuilder = builder.UseCastleWindsor();
            return castleWindsorIocBuilder.Create();
        }
    }
}
