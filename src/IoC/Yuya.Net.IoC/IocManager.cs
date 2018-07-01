using System;

namespace Yuya.Net.IoC
{
    /// <summary>
    /// Ioc Manager Base
    /// </summary>
    /// <seealso cref="Yuya.Net.IoC.IIocManager" />
    /// <seealso cref="Yuya.Net.IoC.IIocRegistrar" />
    /// <seealso cref="Yuya.Net.IoC.IIocResolver" />
    public abstract class IocManagerBase : IIocManager, IIocRegistrar, IIocResolver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IocManagerBase"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected IocManagerBase(string name)
        {
            Name = name;
        }

        #region IIocManager

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the name of the ioc type.
        /// </summary>
        /// <value>
        /// The name of the ioc type.
        /// </value>
        public abstract string IocTypeName { get; }

        /// <summary>
        /// Gets the IoC resolver.
        /// </summary>
        /// <value>
        /// The resolver.
        /// </value>
        public IIocResolver Resolver { get { return this; } }

        /// <summary>
        /// Gets the IoC registerer.
        /// </summary>
        /// <value>
        /// The registerer.
        /// </value>
        public IIocRegistrar Registrar { get { return this; } }
        #endregion

        #region IsRegistered
        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <param name="type">Type to check</param>
        /// <returns></returns>
        public abstract bool IsRegistered(Type type);

        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <typeparam name="T">Type to check</typeparam>
        /// <returns></returns>
        public abstract bool IsRegistered<T>();
        #endregion

        #region IIocRegister
        /// <summary>
        /// Resolves the name of the by.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public abstract TService ResolveByName<TService>(string name);

        /// <summary>
        /// Register Instance to Service
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="implementation"></param>
        /// <returns></returns>
        public abstract IIocManager Register<TService>(TService implementation) where TService : class;

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public abstract IIocManager RegisterSingleton<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public abstract IIocManager RegisterSingleton<TService>(string name = null, bool isDefault = false) where TService : class;

        /// <summary>
        /// Registers the per thread.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public abstract IIocManager RegisterPerThread<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        /// <summary>
        /// Registers the per thread.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public abstract IIocManager RegisterPerThread<TService>(string name = null, bool isDefault = false) where TService : class;

        /// <summary>
        /// Registers the transient.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public abstract IIocManager RegisterTransient<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        /// <summary>
        /// Registers the transient.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        public abstract IIocManager RegisterTransient<TService>(string name = null, bool isDefault = false) where TService : class;
        #endregion

        #region IIocResolver
        /// <summary>
        /// Releases a pre-resolved object. See Resolve methods.
        /// </summary>
        /// <param name="obj">Object to be released</param>
        public abstract void Release(object obj);

        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="Release" />) after usage.
        /// </summary>
        /// <typeparam name="T">Type of the object to get</typeparam>
        /// <returns>
        /// The object instance
        /// </returns>
        public abstract T Resolve<T>();

        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="Release" />) after usage.
        /// </summary>
        /// <typeparam name="T">Type of the object to cast</typeparam>
        /// <param name="type">Type of the object to resolve</param>
        /// <returns>
        /// The object instance
        /// </returns>
        public abstract T Resolve<T>(Type type);

        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="Release" />) after usage.
        /// </summary>
        /// <typeparam name="T">Type of the object to get</typeparam>
        /// <param name="argumentsAsAnonymousType">Constructor arguments</param>
        /// <returns>
        /// The object instance
        /// </returns>
        public abstract T Resolve<T>(object argumentsAsAnonymousType);

        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="Release" />) after usage.
        /// </summary>
        /// <param name="type">Type of the object to get</param>
        /// <returns>
        /// The object instance
        /// </returns>
        public abstract object Resolve(Type type);

        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="Release" />) after usage.
        /// </summary>
        /// <param name="type">Type of the object to get</param>
        /// <param name="argumentsAsAnonymousType">Constructor arguments</param>
        /// <returns>
        /// The object instance
        /// </returns>
        public abstract object Resolve(Type type, object argumentsAsAnonymousType);

        /// <summary>
        /// Gets all implementations for given type.
        /// Returning objects must be Released (see <see cref="Release" />) after usage.
        /// </summary>
        /// <typeparam name="T">Type of the objects to resolve</typeparam>
        /// <returns>
        /// Object instances
        /// </returns>
        public abstract T[] ResolveAll<T>();

        /// <summary>
        /// Gets all implementations for given type.
        /// Returning objects must be Released (see <see cref="Release" />) after usage.
        /// </summary>
        /// <typeparam name="T">Type of the objects to resolve</typeparam>
        /// <param name="argumentsAsAnonymousType">Constructor arguments</param>
        /// <returns>
        /// Object instances
        /// </returns>
        public abstract T[] ResolveAll<T>(object argumentsAsAnonymousType);

        /// <summary>
        /// Gets all implementations for given type.
        /// Returning objects must be Released (see <see cref="Release" />) after usage.
        /// </summary>
        /// <param name="type">Type of the objects to resolve</param>
        /// <returns>
        /// Object instances
        /// </returns>
        public abstract object[] ResolveAll(Type type);

        /// <summary>
        /// Gets all implementations for given type.
        /// Returning objects must be Released (see <see cref="Release" />) after usage.
        /// </summary>
        /// <param name="type">Type of the objects to resolve</param>
        /// <param name="argumentsAsAnonymousType">Constructor arguments</param>
        /// <returns>
        /// Object instances
        /// </returns>
        public abstract object[] ResolveAll(Type type, object argumentsAsAnonymousType);
        #endregion

        #region IDisposible 
        /// <summary>
        /// The is disposed
        /// </summary>
        private bool _isDisposed = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                OnDisposing();
            }
        }

        /// <summary>
        /// Called when [disposing].
        /// </summary>
        protected virtual void OnDisposing()
        {

        }
        #endregion

    }
}
