using System;
using System.Collections.Generic;
using System.Text;

namespace Yuya.Net.OData.Server.Operations
{
    public interface IQueryOperation : IOperationInfo
    {
        int Top { get; }
        string FilterString { get; }
    }
}
