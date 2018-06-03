using System;
using System.Collections.Generic;
using System.Text;

namespace Yuya.Net.IoC.CastleWindsor
{
    public static class IocBuilderExtensions
    {
        public static CastleWindsorIocBuilder UseCastleWindsor(this IocBuilder iocBuilder)
        {
            return new CastleWindsorIocBuilder(iocBuilder);
        }
    }
}
