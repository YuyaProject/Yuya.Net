using System;

namespace Yuya.Net.IoC
{
    /// <summary>
    /// IoC Manager Interface
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IIocManager : IDisposable
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the name of the ioc type.
        /// </summary>
        /// <value>
        /// The name of the ioc type.
        /// </value>
        string IocTypeName { get; }

        /// <summary>
        /// Gets the IoC resolver.
        /// </summary>
        /// <value>
        /// The resolver.
        /// </value>
        IIocResolver Resolver { get; }

        /// <summary>
        /// Gets the IoC registerer.
        /// </summary>
        /// <value>
        /// The registerer.
        /// </value>
        IIocRegistrar Registrar { get; }
    }
}