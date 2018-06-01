using System;

namespace Yuya.Net.IoC
{
    public interface IIocManager : IIocResolver, IIocRegister, IDisposable
    {
    }
}