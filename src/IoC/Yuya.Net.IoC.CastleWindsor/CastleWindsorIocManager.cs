﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Linq;

namespace Yuya.Net.IoC.CastleWindsor
{
    public class CastleWindsorIocManager : IocManager
    {
        private readonly WindsorContainer Container = new WindsorContainer();

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

        public override IIocManager Register<TService>(TService implementation)
        {
            Container.Register(Component.For<TService>().Instance(implementation));
            return this;
        }

        public override IIocManager RegisterSingleton<TService, TImplementation>(string name = null)
        {
            var config = Component.For<TService>().ImplementedBy<TImplementation>().LifestyleSingleton();
            if (string.IsNullOrWhiteSpace(name))
                Container.Register(config);
            else
                Container.Register(config.Named(name));

            return this;
        }

        public override IIocManager RegisterSingleton<TService>(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                Container.Register(Component.For<TService>().LifestyleSingleton());
            else
                Container.Register(Component.For<TService>().LifestyleSingleton().Named(name));
            return this;
        }

        public override IIocManager RegisterPerThread<TService, TImplementation>(string name = null)
        {
            var config = Component.For<TService>().ImplementedBy<TImplementation>().LifestylePerThread();
            if (string.IsNullOrWhiteSpace(name))
                Container.Register(config);
            else
                Container.Register(config.Named(name));

            return this;
        }

        public override IIocManager RegisterPerThread<TService>(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                Container.Register(Component.For<TService>().LifestylePerThread());
            else
                Container.Register(Component.For<TService>().LifestylePerThread().Named(name));
            return this;
        }

        public override IIocManager RegisterTransient<TService, TImplementation>(string name = null)
        {
            var config = Component.For<TService>().ImplementedBy<TImplementation>().LifestyleTransient();
            if (string.IsNullOrWhiteSpace(name))
                Container.Register(config);
            else
                Container.Register(config.Named(name));

            return this;
        }

        public override IIocManager RegisterTransient<TService>(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                Container.Register(Component.For<TService>().LifestyleTransient());
            else
                Container.Register(Component.For<TService>().LifestyleTransient().Named(name));
            return this;
        }

        #region Resolve Methods

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
        /// Returning object must be Released (see <see cref="IIocResolver.Release"/>) after usage.
        /// </summary> 
        /// <param name="type">Type of the object to get</param>
        /// <param name="argumentsAsAnonymousType">Constructor arguments</param>
        /// <returns>The instance object</returns>
        public override object Resolve(Type type, object argumentsAsAnonymousType)
        {
            return Container.Resolve(type, argumentsAsAnonymousType);
        }

        ///<inheritdoc/>
        public override T[] ResolveAll<T>()
        {
            return Container.ResolveAll<T>();
        }

        ///<inheritdoc/>
        public override T[] ResolveAll<T>(object argumentsAsAnonymousType)
        {
            return Container.ResolveAll<T>(argumentsAsAnonymousType);
        }

        ///<inheritdoc/>
        public override object[] ResolveAll(Type type)
        {
            return Container.ResolveAll(type).Cast<object>().ToArray();
        }

        ///<inheritdoc/>
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

        protected override void OnDisposing()
        {
            Container.Dispose();
        }
    }
}