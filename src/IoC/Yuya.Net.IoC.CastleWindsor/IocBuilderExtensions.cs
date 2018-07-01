using System;
using System.Collections.Generic;
using System.Text;

namespace Yuya.Net.IoC.CastleWindsor
{
    /// <summary>
    /// IocBuilder sınıfı için Castle Windsor kütüpane özellikleri sağlayan Extensions Metotdur.
    /// </summary>
    public static class IocBuilderExtensions
    {
        /// <summary>
        /// Uses the castle windsor.
        /// </summary>
        /// <param name="iocBuilder">The ioc builder.</param>
        /// <returns></returns>
        public static CastleWindsorIocBuilder UseCastleWindsor(this IocBuilder iocBuilder)
        {
            return new CastleWindsorIocBuilder(iocBuilder);
        }
    }
}
