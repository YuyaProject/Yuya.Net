using System;
using System.Collections.Generic;
using System.Text;

namespace Yuya.Net.OData.Server.Operations.Filters
{
    public interface IGetByIdFilterOperation : IFilterOperation
    {
        string IdString { get; }
    }
}
