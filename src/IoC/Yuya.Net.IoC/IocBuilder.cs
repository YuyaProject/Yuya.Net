﻿using System;

namespace Yuya.Net.IoC
{
    public class IocBuilder
    {
        public IocBuilder(string name)
        {
            Name = name;
        }

        protected IocBuilder(IocBuilder iocBuilder)
        {
            this.Name = iocBuilder.Name;
        }

        public virtual string Type { get; protected set; }

        public string Name { get; }

        public virtual IIocManager Create()
        {
            throw new NotImplementedException();
        }
    }
}
