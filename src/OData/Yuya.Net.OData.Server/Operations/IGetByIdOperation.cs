using System;
using System.Collections.Generic;
using System.Text;

namespace Yuya.Net.OData.Server.Operations
{
    public interface IGetByIdOperation : IOperationInfo
    {
        string Id { get; }
    }
}
