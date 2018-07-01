using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Linq;

namespace Yuya.Net.IoC.CastleWindsor
{
    /// <summary>
    /// Castle Windsor için Ioc Builder Sınıfı
    /// </summary>
    /// <seealso cref="Yuya.Net.IoC.IocBuilder" />
    public class CastleWindsorIocBuilder : IocBuilder
    {
        /// <summary>
        ///     IocBuilder'ı parametre olarak alan yapıcıdır. Bu sınıfın public bir yapıcısı yoktur.
        ///     <en-US>Initializes a new instance of the <see cref="CastleWindsorIocBuilder"/> class.</en-US>
        /// </summary>
        /// <param name="iocBuilder">
        ///     IocBuilder tipindeki parametredir. 
        ///     <en-US>The ioc builder.</en-US>
        /// </param>
        internal CastleWindsorIocBuilder(IocBuilder iocBuilder) : base(iocBuilder)
        {
            Type = "CastleWindsor";
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public override IIocManager Create()
        {
            return new CastleWindsorIocManager(Name);
        }
    }
}
