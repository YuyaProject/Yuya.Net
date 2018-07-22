using System;
using System.Collections.Generic;
using System.Text;

namespace Yuya.Net.OData.Server.Operations.Filters
{
    public class GetByIdFilterOperation : IGetByIdFilterOperation
    {
        public string IdString { get; set; }
    }
}
