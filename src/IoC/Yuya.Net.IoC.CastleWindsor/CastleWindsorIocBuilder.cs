using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Linq;

namespace Yuya.Net.IoC.CastleWindsor
{
    public class CastleWindsorIocBuilder : IocBuilder
    {
        internal CastleWindsorIocBuilder(IocBuilder iocBuilder) : base(iocBuilder)
        {
            Type = "CastleWindsor";
        }

        public override IIocManager Create()
        {
            return new CastleWindsorIocManager(Name);
        }
    }
}
