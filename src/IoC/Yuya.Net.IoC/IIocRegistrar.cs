using System;

namespace Yuya.Net.IoC
{
    /// <summary>
    /// IoC Registrar Interface
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IIocRegistrar : IDisposable
    {
        #region Instance
        /// <summary>
        /// Register Instance to Service
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="implementation"></param>
        IIocManager Register<TService>(TService implementation)
            where TService : class;
        #endregion

        #region Singletons
        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        IIocManager RegisterSingleton<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        IIocManager RegisterSingleton<TService>(string name = null, bool isDefault = false)
            where TService : class;
        #endregion

        #region Transients

        /// <summary>
        /// Registers the transient.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        IIocManager RegisterTransient<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        /// <summary>
        /// Registers the transient.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        IIocManager RegisterTransient<TService>(string name = null, bool isDefault = false)
            where TService : class;
        #endregion

        #region Thread

        /// <summary>
        /// Registers the per thread.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        IIocManager RegisterPerThread<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        /// <summary>
        /// Registers the per thread.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <returns></returns>
        IIocManager RegisterPerThread<TService>(string name = null, bool isDefault = false)
            where TService : class;
        #endregion

        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <param name="type">Type to check</param>
        bool IsRegistered(Type type);

        /// <summary>
        /// Checks whether given type is registered before.
        /// </summary>
        /// <typeparam name="T">Type to check</typeparam>
        bool IsRegistered<T>();
    }
}