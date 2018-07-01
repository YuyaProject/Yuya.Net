using Castle.MicroKernel;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace Yuya.Net.IoC.CastleWindsor.Tests
{
    /// <summary>
    /// Castle Windsor Ioc Manager Tests
    /// </summary>
    public class CastleWindsorIocManagerTests
    {

        /// <summary>
        /// Shoulds the self register with all interfaces.
        /// </summary>
        [Fact]
        public void Should_Self_Register_With_All_Interfaces()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                var registrar = iocManager.Resolver.Resolve<IIocRegistrar>();
                var resolver = iocManager.Resolver.Resolve<IIocResolver>();
                var managerByInterface = iocManager.Resolver.Resolve<IIocManager>();

                managerByInterface.ShouldBeSameAs(registrar);
                managerByInterface.ShouldBeSameAs(resolver);
            }
        }

        /// <summary>
        /// Shoulds the get first registered class if registered multiple class for same interface.
        /// </summary>
        [Fact]
        public void Should_Get_First_Registered_Class_If_Registered_Multiple_Class_For_Same_Interface()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registrar.RegisterPerThread<IEmpty, EmptyImplOne>();
                iocManager.Registrar.RegisterPerThread<IEmpty, EmptyImplTwo>();

                iocManager.Resolver.Resolve<IEmpty>().ShouldBeOfType<EmptyImplOne>();
            }
        }

        /// <summary>
        /// Resolves all test.
        /// </summary>
        [Fact]
        public void ResolveAll_Test()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registrar.RegisterPerThread<IEmpty, EmptyImplOne>();
                iocManager.Registrar.RegisterPerThread<IEmpty, EmptyImplTwo>();

                var instances = iocManager.Resolver.ResolveAll<IEmpty>();
                instances.Length.ShouldBe(2);
                instances.Any(i => i.GetType() == typeof(EmptyImplOne)).ShouldBeTrue();
                instances.Any(i => i.GetType() == typeof(EmptyImplTwo)).ShouldBeTrue();
            }
        }


        /// <summary>
        /// Shoulds the call initialize.
        /// </summary>
        [Fact]
        public void Should_Call_Initialize()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registrar.RegisterTransient<MyService>();
                var myService = iocManager.Resolver.Resolve<MyService>();
                myService.InitializeCount.ShouldBe(0);
            }
        }

        /// <summary>
        /// Shoulds the call dispose of transient dependency when object is released.
        /// </summary>
        [Fact]
        public void Should_Call_Dispose_Of_Transient_Dependency_When_Object_Is_Released()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registrar.RegisterTransient<SimpleDisposableObject>();

                var obj = iocManager.Resolver.Resolve<SimpleDisposableObject>();

                iocManager.Resolver.Release(obj);

                obj.DisposeCount.ShouldBe(1);
            }
        }

        /// <summary>
        /// Shoulds the call dispose of transient dependency when ioc manager is disposed.
        /// </summary>
        [Fact]
        public void Should_Call_Dispose_Of_Transient_Dependency_When_IocManager_Is_Disposed()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registrar.RegisterTransient<SimpleDisposableObject>();

                var obj = iocManager.Resolver.Resolve<SimpleDisposableObject>();

                iocManager.Dispose();

                obj.DisposeCount.ShouldBe(1);
            }
        }

        /// <summary>
        /// Shoulds the call dispose of singleton dependency when ioc manager is disposed.
        /// </summary>
        [Fact]
        public void Should_Call_Dispose_Of_Singleton_Dependency_When_IocManager_Is_Disposed()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registrar.RegisterSingleton<SimpleDisposableObject>();

                var obj = iocManager.Resolver.Resolve<SimpleDisposableObject>();

                iocManager.Dispose();

                obj.DisposeCount.ShouldBe(1);
            }
        }

        /// <summary>
        /// Shoulds the fail circular constructor dependency.
        /// </summary>
        [Fact]
        public void Should_Fail_Circular_Constructor_Dependency()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                iocManager.Registrar.RegisterTransient<MyClass1>();
                iocManager.Registrar.RegisterTransient<MyClass2>();
                iocManager.Registrar.RegisterTransient<MyClass3>();

                Assert.Throws<CircularDependencyException>(() => iocManager.Resolver.Resolve<MyClass1>());
            }
        }




        /// <summary>
        /// Shoulds the success circular property injection transient.
        /// </summary>
        [Fact]
        public void Should_Success_Circular_Property_Injection_Transient()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                MyClass11.CreateCount = 0;
                MyClass12.CreateCount = 0;
                MyClass13.CreateCount = 0;

                iocManager.Registrar.RegisterTransient<MyClass11>();
                iocManager.Registrar.RegisterTransient<MyClass12>();
                iocManager.Registrar.RegisterTransient<MyClass13>();

                var obj1 = iocManager.Resolver.Resolve<MyClass11>();
                obj1.Obj2.ShouldNotBe(null);
                obj1.Obj3.ShouldNotBe(null);
                obj1.Obj2.Obj3.ShouldNotBe(null);

                var obj2 = iocManager.Resolver.Resolve<MyClass12>();
                obj2.Obj1.ShouldNotBe(null);
                obj2.Obj3.ShouldNotBe(null);
                obj2.Obj1.Obj3.ShouldNotBe(null);

                MyClass11.CreateCount.ShouldBe(2);
                MyClass12.CreateCount.ShouldBe(2);
                MyClass13.CreateCount.ShouldBe(4);
            }
        }

        /// <summary>
        /// Shoulds the success circular property injection singleton.
        /// </summary>
        [Fact]
        public void Should_Success_Circular_Property_Injection_Singleton()
        {
            using (IIocManager iocManager = CreateTestIocManager())
            {
                MyClass11.CreateCount = 0;
                MyClass12.CreateCount = 0;
                MyClass13.CreateCount = 0;

                iocManager.Registrar.RegisterSingleton<MyClass11>();
                iocManager.Registrar.RegisterSingleton<MyClass12>();
                iocManager.Registrar.RegisterSingleton<MyClass13>();

                var obj1 = iocManager.Resolver.Resolve<MyClass11>();
                obj1.Obj2.ShouldNotBe(null);
                obj1.Obj3.ShouldNotBe(null);
                obj1.Obj2.Obj3.ShouldNotBe(null);

                var obj2 = iocManager.Resolver.Resolve<MyClass12>();
                obj2.Obj1.ShouldBe(null); //!!!Notice: It's null
                obj2.Obj3.ShouldNotBe(null);

                MyClass11.CreateCount.ShouldBe(1);
                MyClass12.CreateCount.ShouldBe(1);
                MyClass13.CreateCount.ShouldBe(1);
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

        public class MyClass1
        {
            public MyClass1(MyClass2 obj)
            {

            }
        }

        public class MyClass2
        {
            public MyClass2(MyClass3 obj)
            {

            }
        }

        public class MyClass3
        {
            public MyClass3(MyClass1 obj)
            {

            }
        }

        public class MyClass11
        {
            public static int CreateCount { get; set; }

            public MyClass12 Obj2 { get; set; }

            public MyClass13 Obj3 { get; set; }

            public MyClass11()
            {
                CreateCount++;
            }
        }

        public class MyClass12
        {
            public static int CreateCount { get; set; }

            public MyClass11 Obj1 { get; set; }

            public MyClass13 Obj3 { get; set; }

            public MyClass12()
            {
                CreateCount++;
            }
        }

        public class MyClass13
        {
            public static int CreateCount { get; set; }

            public MyClass13()
            {
                CreateCount++;
            }
        }


        /// <summary>
        /// Creates the test ioc manager.
        /// </summary>
        /// <returns></returns>
        public static IIocManager CreateTestIocManager()
        {
            IocBuilder builder = new IocBuilder("Demo");
            CastleWindsorIocBuilder castleWindsorIocBuilder = builder.UseCastleWindsor();
            return castleWindsorIocBuilder.Create();
        }
    }
}
