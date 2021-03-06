﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Linq;

namespace Yuya.Net.IoC.CastleWindsor
{
    /// <summary>
    /// Castle Windsor Ioc Manager
    /// </summary>
    /// <seealso cref="Yuya.Net.IoC.IocManagerBase" />
    internal class CastleWindsorIocManager : IocManagerBase
    {
        /// <summary>
        /// The private castle windsor container
        /// </summary>
        private readonly WindsorContainer Container;

        /// <summary>
        /// Initializes a new instance of the <see cref="CastleWindsorIocManager"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        internal CastleWindsorIocManager(string name) : base(name)
        {
            // Create a Instance
            Container = new WindsorContainer();

            // Add this class to container
            Container.Register(Component.For<IIocManager, IIocResolver, IIocRegistrar>().Instance(this));
        }

        /// <summary>
        /// Gets the name of the ioc type.
        /// </summary>
        /// <value>
        /// The name of the ioc type.
        /// </value>
        public override string IocTypeName => "CastleWindsor";

        #region IsRegister
        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <param name="type">Type to check</param>
        public override bool IsRegistered(Type type)
        {
            return Container.Kernel.HasComponent(type);
        }

        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <typeparam name="TType">Type to check</typeparam>
        public override bool IsRegistered<TType>()
        {
            return Container.Kernel.HasComponent(typeof(TType));
        }
        #endregion

        #region Register Methods
        /// <summary>
        /// Registers the specified implementation.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="implementation">The implementation.</param>
        /// <returns></returns>
        public override IIocManager Register<TService>(TService implementation)
        {
            Container.Register(Component.For<TService>().Instance(implementation));
            return this;
        }

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public override IIocManager RegisterSingleton<TService, TImplementation>(string name = null, bool isDefault = false)
        {
            var config = Component.For<TService>().ImplementedBy<TImplementation>().LifestyleSingleton();

            if (isDefault)
                config.IsDefault();

            if (string.IsNullOrWhiteSpace(name))
                Container.Register(config);
            else
                Container.Register(config.Named(name));
            return this;
        }

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public override IIocManager RegisterSingleton<TService>(string name = null, bool isDefault = false)
        {
            ComponentRegistration<TService> config = Component.For<TService>().LifestyleSingleton();

            if (isDefault)
                config.IsDefault();

            if (string.IsNullOrWhiteSpace(name))
                Container.Register(config);
            else
                Container.Register(config.Named(name));
            return this;
        }

        /// <summary>
        /// Registers the per thread.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public override IIocManager RegisterPerThread<TService, TImplementation>(string name = null, bool isDefault = false)
        {
            var config = Component.For<TService>().ImplementedBy<TImplementation>().LifestylePerThread();

            if (isDefault)
                config.IsDefault();

            if (string.IsNullOrWhiteSpace(name))
                Container.Register(config);
            else
                Container.Register(config.Named(name));

            return this;
        }

        /// <summary>
        /// Registers the per thread.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public override IIocManager RegisterPerThread<TService>(string name = null, bool isDefault = false)
        {
            ComponentRegistration<TService> config = Component.For<TService>().LifestylePerThread();

            if (isDefault)
                config.IsDefault();

            if (string.IsNullOrWhiteSpace(name))
                Container.Register(config);
            else
                Container.Register(config.Named(name));
            return this;
        }

        /// <summary>
        /// Registers the transient.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public override IIocManager RegisterTransient<TService, TImplementation>(string name = null, bool isDefault = false)
        {
            var config = Component.For<TService>().ImplementedBy<TImplementation>().LifestyleTransient();

            if (isDefault)
                config.IsDefault();

            if (string.IsNullOrWhiteSpace(name))
                Container.Register(config);
            else
                Container.Register(config.Named(name));

            return this;
        }

        /// <summary>
        /// Registers the transient.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public override IIocManager RegisterTransient<TService>(string name = null, bool isDefault = false)
        {
            ComponentRegistration<TService> config = Component.For<TService>().LifestyleTransient();

            if (isDefault)
                config.IsDefault();

            if (string.IsNullOrWhiteSpace(name))
                Container.Register(config);
            else
                Container.Register(config.Named(name));
            return this;
        }

        #endregion

        #region Resolve Methods

        /// <summary>
        /// Resolves the name of the by.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override TService ResolveByName<TService>(string name)
        {
            return Container.Resolve<TService>(name);
        }

        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="IIocResolver.Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">Type of the object to get</typeparam>
        /// <returns>The instance object</returns>
        public override T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">Type of the object to cast</typeparam>
        /// <param name="type">Type of the object to resolve</param>
        /// <returns>The object instance</returns>
        public override T Resolve<T>(Type type)
        {
            return (T)Container.Resolve(type);
        }

        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="IIocResolver.Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">Type of the object to get</typeparam>
        /// <param name="argumentsAsAnonymousType">Constructor arguments</param>
        /// <returns>The instance object</returns>
        public override T Resolve<T>(object argumentsAsAnonymousType)
        {
            return Container.Resolve<T>(argumentsAsAnonymousType);
        }

        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="IIocResolver.Release"/>) after usage.
        /// </summary> 
        /// <param name="type">Type of the object to get</param>
        /// <returns>The instance object</returns>
        public override object Resolve(Type type)
        {
            return Container.Resolve(type);
        }

        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="IIocResolver.Release" />) after usage.
        /// </summary>
        /// <param name="type">Type of the object to get</param>
        /// <param name="argumentsAsAnonymousType">Constructor arguments</param>
        /// <returns>
        /// The instance object
        /// </returns>
        public override object Resolve(Type type, object argumentsAsAnonymousType)
        {
            return Container.Resolve(type, argumentsAsAnonymousType);
        }

        /// <summary>
        /// Resolves all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <inheritdoc />
        public override T[] ResolveAll<T>()
        {
            return Container.ResolveAll<T>();
        }

        /// <summary>
        /// Resolves all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argumentsAsAnonymousType">Type of the arguments as anonymous.</param>
        /// <returns></returns>
        /// <inheritdoc />
        public override T[] ResolveAll<T>(object argumentsAsAnonymousType)
        {
            return Container.ResolveAll<T>(argumentsAsAnonymousType);
        }

        /// <summary>
        /// Resolves all.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <inheritdoc />
        public override object[] ResolveAll(Type type)
        {
            return Container.ResolveAll(type).Cast<object>().ToArray();
        }

        /// <summary>
        /// Resolves all.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="argumentsAsAnonymousType">Type of the arguments as anonymous.</param>
        /// <returns></returns>
        /// <inheritdoc />
        public override object[] ResolveAll(Type type, object argumentsAsAnonymousType)
        {
            return Container.ResolveAll(type, argumentsAsAnonymousType).Cast<object>().ToArray();
        }

        /// <summary>
        /// Releases a pre-resolved object. See Resolve methods.
        /// </summary>
        /// <param name="obj">Object to be released</param>
        public override void Release(object obj)
        {
            Container.Release(obj);
        }
        #endregion

        /// <summary>
        /// Called when [disposing].
        /// </summary>
        protected override void OnDisposing()
        {
            Container.Dispose();
        }
    }
}
