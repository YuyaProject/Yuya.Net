using System;
using System.Collections.Generic;
using System.Text;
using Yuya.Net.OData.Server.Operations.Filters;

namespace Yuya.Net.OData.Server.Operations
{
    public interface IOperationInfo
    {
        string StartingEntityName { get; }

        OperationReturnTypeEnum ReturnType { get; }

        string ReturnEntityName { get; }

        List<IFilterOperation> FilterOperations { get; }
    }
}
