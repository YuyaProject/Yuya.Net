using System;

namespace Yuya.Net.IoC
{
    /// <summary>
    /// IoC Builder Class
    /// </summary>
    public class IocBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IocBuilder"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">name</exception>
        public IocBuilder(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IocBuilder"/> class.
        /// </summary>
        /// <param name="iocBuilder">The ioc builder.</param>
        protected IocBuilder(IocBuilder iocBuilder)
        {
            this.Name = iocBuilder.Name;
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public virtual string Type { get; protected set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual IIocManager Create()
        {
            throw new NotImplementedException();
        }
    }
}
