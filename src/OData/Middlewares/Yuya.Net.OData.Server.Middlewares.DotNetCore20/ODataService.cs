using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yuya.Net.OData.Server.DotNetCore20
{
    internal static class ODataService
    {
        public static IODataService Create(HttpContext httpContext, IODataServerMiddlewareOptions optionValues)
        {
            if (optionValues.Version == ODataVersion.V4)
            {
                return new ODataServiceV4(httpContext, optionValues);
            }
            else
            {
                throw new NotImplementedException($"OData Version '{optionValues.Version}' is not implemented!");
            }
        }

        public static bool IsServicePath(HttpContext httpContext, IODataServerMiddlewareOptions optionValues)
        {
            return httpContext.Request.Path.StartsWithSegments(optionValues.BasePath);
        }
    }
}
