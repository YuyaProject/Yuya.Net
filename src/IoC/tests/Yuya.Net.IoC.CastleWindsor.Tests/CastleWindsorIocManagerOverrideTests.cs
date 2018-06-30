using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Yuya.Net.IoC.CastleWindsor.Tests
{
    public class CastleWindsorIocManagerOverrideTests
    {
        [Fact]
        public void Should_TransientService_Not_Override_As_Default()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl2>();
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl3>();

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl1>();
                allServices.Length.ShouldBe(3);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl3)).ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_TransientService_Override_When_Using_IsDefault()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl2>(isDefault: true);

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl2>();
                allServices.Length.ShouldBe(2);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_TransientService_Override_When_Using_IsDefault_Twice()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl3>(isDefault: true);

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl3>();
                allServices.Length.ShouldBe(3);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl3)).ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_TransientService_Get_Default_Service()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registerer.RegisterTransient<IMyService, MyImpl3>();

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl2>();
                allServices.Length.ShouldBe(3);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl3)).ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_SingletonService_Not_Override_As_Default()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl2>();
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl3>();

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl1>();
                allServices.Length.ShouldBe(3);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl3)).ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_SingletonService_Override_When_Using_IsDefault()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl2>(isDefault: true);

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl2>();
                allServices.Length.ShouldBe(2);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_SingletonService_Override_When_Using_IsDefault_Twice()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl3>(isDefault: true);

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl3>();
                allServices.Length.ShouldBe(3);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl3)).ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_SingletonService_Get_Default_Service()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registerer.RegisterSingleton<IMyService, MyImpl3>();

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl2>();
                allServices.Length.ShouldBe(3);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl3)).ShouldBeTrue();
            }
        }


        [Fact]
        public void Should_PerThreadService_Not_Override_As_Default()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl2>();
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl3>();

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl1>();
                allServices.Length.ShouldBe(3);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl3)).ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_PerThreadService_Override_When_Using_IsDefault()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl2>(isDefault: true);

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl2>();
                allServices.Length.ShouldBe(2);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_PerThreadService_Override_When_Using_IsDefault_Twice()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl3>(isDefault: true);

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl3>();
                allServices.Length.ShouldBe(3);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl3)).ShouldBeTrue();
            }
        }

        [Fact]
        public void Should_PerThreadService_Get_Default_Service()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl1>();
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registerer.RegisterPerThread<IMyService, MyImpl3>();

                //Act
                var service = iocManager.Resolver.Resolve<IMyService>();
                var allServices = iocManager.Resolver.ResolveAll<IMyService>();

                //Assert
                service.ShouldBeOfType<MyImpl2>();
                allServices.Length.ShouldBe(3);
                allServices.Any(s => s.GetType() == typeof(MyImpl1)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl2)).ShouldBeTrue();
                allServices.Any(s => s.GetType() == typeof(MyImpl3)).ShouldBeTrue();
            }
        }



        public class MyImpl1 : IMyService
        {

        }

        public class MyImpl2 : IMyService
        {

        }

        public class MyImpl3 : IMyService
        {

        }

        public interface IMyService
        {
        }
    }
}
