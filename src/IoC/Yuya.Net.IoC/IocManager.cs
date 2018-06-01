using System;

namespace Yuya.Net.IoC
{
    public abstract class IocManager : IIocManager
    {
        private bool _isDisposed = false;

        public virtual void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                OnDisposing();
            }
        }

        protected virtual void OnDisposing() {

        }

        public abstract bool IsRegistered(Type type);

        public abstract bool IsRegistered<T>();

        public abstract IIocManager Register<TService>(TService implementation) where TService : class;

        public abstract IIocManager RegisterSingleton<TService, TImplementation>(string name = null)
            where TService : class
            where TImplementation : TService;

        public abstract IIocManager RegisterSingleton<TService>(string name = null) where TService : class;

        public abstract IIocManager RegisterPerThread<TService, TImplementation>(string name = null)
            where TService : class
            where TImplementation : TService;

        public abstract IIocManager RegisterPerThread<TService>(string name = null) where TService : class;

        public abstract IIocManager RegisterTransient<TService, TImplementation>(string name = null)
            where TService : class
            where TImplementation : TService;

        public abstract IIocManager RegisterTransient<TService>(string name = null) where TService : class;

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

        public abstract TService ResolveByName<TService>(string name);
    }
}
