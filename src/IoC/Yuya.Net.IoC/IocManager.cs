using System;

namespace Yuya.Net.IoC
{
    public abstract class IocManagerBase : IIocManager, IIocRegisterer, IIocResolver
    {
        protected IocManagerBase(string name)
        {
            Name = name;
        }

        #region IIocManager

        public string Name { get; }

        public abstract string IocTypeName { get; }

        public IIocResolver Resolver { get { return this; } }

        public IIocRegisterer Registerer { get { return this; } }
        #endregion

        #region IsRegistered
        public abstract bool IsRegistered(Type type);

        public abstract bool IsRegistered<T>();
        #endregion

        #region IIocRegister
        public abstract TService ResolveByName<TService>(string name);

        public abstract IIocManager Register<TService>(TService implementation) where TService : class;

        public abstract IIocManager RegisterSingleton<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        public abstract IIocManager RegisterSingleton<TService>(string name = null, bool isDefault = false) where TService : class;

        public abstract IIocManager RegisterPerThread<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        public abstract IIocManager RegisterPerThread<TService>(string name = null, bool isDefault = false) where TService : class;

        public abstract IIocManager RegisterTransient<TService, TImplementation>(string name = null, bool isDefault = false)
            where TService : class
            where TImplementation : TService;

        public abstract IIocManager RegisterTransient<TService>(string name = null, bool isDefault = false) where TService : class;
        #endregion

        #region IIocResolver
        public abstract void Release(object obj);

        public abstract T Resolve<T>();

        public abstract T Resolve<T>(Type type);

        public abstract T Resolve<T>(object argumentsAsAnonymousType);

        public abstract object Resolve(Type type);

        public abstract object Resolve(Type type, object argumentsAsAnonymousType);

        public abstract T[] ResolveAll<T>();

        public abstract T[] ResolveAll<T>(object argumentsAsAnonymousType);

        public abstract object[] ResolveAll(Type type);

        public abstract object[] ResolveAll(Type type, object argumentsAsAnonymousType);
        #endregion

        #region IDisposible 
        private bool _isDisposed = false;

        public virtual void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                OnDisposing();
            }
        }

        protected virtual void OnDisposing()
        {

        }
        #endregion

    }
}
