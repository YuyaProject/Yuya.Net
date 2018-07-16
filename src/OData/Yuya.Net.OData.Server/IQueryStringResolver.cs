using System;
using System.Collections.Generic;
using System.Text;
using Yuya.Net.OData.Server.Operations;

namespace Yuya.Net.OData.Server
{
    public interface IQueryStringResolver
    {
        IOperationInfo GetOperationInfoByUrl(string url, string basePath = "");
    }
}
