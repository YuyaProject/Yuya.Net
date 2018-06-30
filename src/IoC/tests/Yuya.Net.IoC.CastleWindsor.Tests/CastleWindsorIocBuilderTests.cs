using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace Yuya.Net.IoC.CastleWindsor.Tests
{
    public class CastleWindsorIocBuilderTests
    {
        [Fact]
        public void Should_Instance_When_Initialize_Return_SameNameAndType()
        {
            IocBuilder builder = new IocBuilder("Demo");
            var castleWindsorIocBuilder = builder.UseCastleWindsor();
            castleWindsorIocBuilder.Name.ShouldBe("Demo");
            castleWindsorIocBuilder.Type.ShouldBe("CastleWindsor");
        }

        [Fact]
        public void Should_Create_When_NoParameter_Return_CastleWindsorIocManagerInstance()
        {
            IIocManager iocManager = CreateTestIocManager();

            iocManager.ShouldBeOfType<CastleWindsorIocManager>();
            iocManager.Name.ShouldBe("Demo");
            iocManager.IocTypeName.ShouldBe("CastleWindsor");
        }

        private static IIocManager CreateTestIocManager()
        {
            IocBuilder builder = new IocBuilder("Demo");
            CastleWindsorIocBuilder castleWindsorIocBuilder = builder.UseCastleWindsor();
            return castleWindsorIocBuilder.Create();
        }
    }
}
