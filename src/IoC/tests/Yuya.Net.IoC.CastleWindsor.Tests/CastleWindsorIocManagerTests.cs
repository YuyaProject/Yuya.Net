using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace Yuya.Net.IoC.CastleWindsor.Tests
{
    public class CastleWindsorIocManagerTests
    {

        [Fact]
        public void Should_Self_Register_With_All_Interfaces()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                var registrar = iocManager.Resolver.Resolve<IIocRegisterer>();
                var resolver = iocManager.Resolver.Resolve<IIocResolver>();
                var managerByInterface = iocManager.Resolver.Resolve<IIocManager>();

                managerByInterface.ShouldBeSameAs(registrar);
                managerByInterface.ShouldBeSameAs(resolver);
            }
        }

        [Fact]
        public void Should_Get_First_Registered_Class_If_Registered_Multiple_Class_For_Same_Interface()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registerer.RegisterPerThread<IEmpty, EmptyImplOne>();
                iocManager.Registerer.RegisterPerThread<IEmpty, EmptyImplTwo>();

                iocManager.Resolver.Resolve<IEmpty>().ShouldBeOfType<EmptyImplOne>();
            }
        }

        [Fact]
        public void ResolveAll_Test()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registerer.RegisterPerThread<IEmpty, EmptyImplOne>();
                iocManager.Registerer.RegisterPerThread<IEmpty, EmptyImplTwo>();

                var instances = iocManager.Resolver.ResolveAll<IEmpty>();
                instances.Length.ShouldBe(2);
                instances.Any(i => i.GetType() == typeof(EmptyImplOne)).ShouldBeTrue();
                instances.Any(i => i.GetType() == typeof(EmptyImplTwo)).ShouldBeTrue();
            }
        }


        [Fact]
        public void Should_Call_Initialize()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registerer.RegisterTransient<MyService>();
                var myService = iocManager.Resolver.Resolve<MyService>();
                myService.InitializeCount.ShouldBe(0);
            }
        }

        [Fact]
        public void Should_Call_Dispose_Of_Transient_Dependency_When_Object_Is_Released()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registerer.RegisterTransient<SimpleDisposableObject>();

                var obj = iocManager.Resolver.Resolve<SimpleDisposableObject>();

                iocManager.Resolver.Release(obj);

                obj.DisposeCount.ShouldBe(1);
            }
        }

        [Fact]
        public void Should_Call_Dispose_Of_Transient_Dependency_When_IocManager_Is_Disposed()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registerer.RegisterTransient<SimpleDisposableObject>();

                var obj = iocManager.Resolver.Resolve<SimpleDisposableObject>();

                iocManager.Dispose();

                obj.DisposeCount.ShouldBe(1);
            }
        }

        [Fact]
        public void Should_Call_Dispose_Of_Singleton_Dependency_When_IocManager_Is_Disposed()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registerer.RegisterSingleton<SimpleDisposableObject>();

                var obj = iocManager.Resolver.Resolve<SimpleDisposableObject>();

                iocManager.Dispose();

                obj.DisposeCount.ShouldBe(1);
            }
        }




        public class MyService
        {
            public int InitializeCount { get; private set; }

            public void Initialize()
            {
                InitializeCount++;
            }
        }

        public interface IEmpty
        {

        }

        public class EmptyImplOne : IEmpty
        {

        }

        public class EmptyImplTwo : IEmpty
        {

        }

        public static IIocManager CreateTestIocManager()
        {
            IocBuilder builder = new IocBuilder("Demo");
            CastleWindsorIocBuilder castleWindsorIocBuilder = builder.UseCastleWindsor();
            return castleWindsorIocBuilder.Create();
        }
    }
}
