using System;

namespace Yuya.Net.IoC
{
    public interface IIocRegisterer : IDisposable
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
        IIocManager RegisterSingleton<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        IIocManager RegisterSingleton<TService>(string name = null, bool isDefault = false)
            where TService : class;
        #endregion

        #region Transients

        IIocManager RegisterTransient<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        IIocManager RegisterTransient<TService>(string name = null, bool isDefault = false)
            where TService : class;
        #endregion

        #region Thread

        IIocManager RegisterPerThread<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

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