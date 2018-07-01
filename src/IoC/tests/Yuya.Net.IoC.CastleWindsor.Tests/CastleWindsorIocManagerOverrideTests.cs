using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Yuya.Net.IoC.CastleWindsor.Tests
{
    /// <summary>
    /// Castle Windsor Ioc Manager Override Tests
    /// </summary>
    public class CastleWindsorIocManagerOverrideTests
    {
        /// <summary>
        /// Shoulds the transient service not override as default.
        /// </summary>
        [Fact]
        public void Should_TransientService_Not_Override_As_Default()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl2>();
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl3>();

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

        /// <summary>
        /// Shoulds the transient service override when using is default.
        /// </summary>
        [Fact]
        public void Should_TransientService_Override_When_Using_IsDefault()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl2>(isDefault: true);

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

        /// <summary>
        /// Shoulds the transient service override when using is default twice.
        /// </summary>
        [Fact]
        public void Should_TransientService_Override_When_Using_IsDefault_Twice()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl3>(isDefault: true);

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

        /// <summary>
        /// Shoulds the transient service get default service.
        /// </summary>
        [Fact]
        public void Should_TransientService_Get_Default_Service()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registrar.RegisterTransient<IMyService, MyImpl3>();

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

        /// <summary>
        /// Shoulds the singleton service not override as default.
        /// </summary>
        [Fact]
        public void Should_SingletonService_Not_Override_As_Default()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl2>();
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl3>();

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

        /// <summary>
        /// Shoulds the singleton service override when using is default.
        /// </summary>
        [Fact]
        public void Should_SingletonService_Override_When_Using_IsDefault()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl2>(isDefault: true);

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

        /// <summary>
        /// Shoulds the singleton service override when using is default twice.
        /// </summary>
        [Fact]
        public void Should_SingletonService_Override_When_Using_IsDefault_Twice()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl3>(isDefault: true);

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

        /// <summary>
        /// Shoulds the singleton service get default service.
        /// </summary>
        [Fact]
        public void Should_SingletonService_Get_Default_Service()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registrar.RegisterSingleton<IMyService, MyImpl3>();

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


        /// <summary>
        /// Shoulds the per thread service not override as default.
        /// </summary>
        [Fact]
        public void Should_PerThreadService_Not_Override_As_Default()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl2>();
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl3>();

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

        /// <summary>
        /// Shoulds the per thread service override when using is default.
        /// </summary>
        [Fact]
        public void Should_PerThreadService_Override_When_Using_IsDefault()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl2>(isDefault: true);

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

        /// <summary>
        /// Shoulds the per thread service override when using is default twice.
        /// </summary>
        [Fact]
        public void Should_PerThreadService_Override_When_Using_IsDefault_Twice()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl3>(isDefault: true);

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

        /// <summary>
        /// Shoulds the per thread service get default service.
        /// </summary>
        [Fact]
        public void Should_PerThreadService_Get_Default_Service()
        {
            using (IIocManager iocManager = CastleWindsorIocManagerTests.CreateTestIocManager())
            {
                //Arrange
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl1>();
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl2>(isDefault: true);
                iocManager.Registrar.RegisterPerThread<IMyService, MyImpl3>();

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
