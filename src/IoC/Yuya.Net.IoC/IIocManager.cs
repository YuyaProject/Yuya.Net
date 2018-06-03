using System;

namespace Yuya.Net.IoC
{
    public interface IIocManager : IDisposable
    {
        string Name { get; }

        string IocTypeName { get; }

        IIocResolver Resolver { get; }

        IIocRegisterer Registerer { get; }
    }
}