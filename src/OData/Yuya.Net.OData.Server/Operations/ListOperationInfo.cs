using System;
using System.Collections.Generic;
using System.Text;

namespace Yuya.Net.OData.Server.Operations
{
    internal class ListOperationInfo : IListOperation
    {
        public ListOperationInfo(string entityName)
        {
            EntityName = entityName;
        }

        public string EntityName { get; }
    }
}
