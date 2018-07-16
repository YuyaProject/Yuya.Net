using System;
using System.Collections.Generic;
using System.Text;

namespace Yuya.Net.OData.Server.Operations
{
    internal class GetByIdOperationInfo : IGetByIdOperation
    {
        public GetByIdOperationInfo(string entityName, string id)
        {
            EntityName = entityName;
            Id = id;
        }

        public string EntityName { get; }

        public string Id { get; }
    }
}
