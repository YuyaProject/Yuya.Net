using System;
using System.Collections.Generic;
using System.Text;
using Yuya.Net.OData.Server.Operations.Filters;

namespace Yuya.Net.OData.Server.Operations
{
    public class OperationInfo : IOperationInfo
    {
        public OperationInfo(string startingEntityName)
        {
            StartingEntityName = startingEntityName;
        }

        public string StartingEntityName { get; }

        public string ReturnEntityName { get; set; }

        public OperationReturnTypeEnum ReturnType { get; set; }

        public List<IFilterOperation> FilterOperations { get; set; } = new List<IFilterOperation>();

    }
}
