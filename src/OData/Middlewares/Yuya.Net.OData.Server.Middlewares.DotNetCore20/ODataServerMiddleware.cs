using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yuya.Net.OData.Server.DotNetCore20
{
    public class ODataServerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ODataServerMiddlewareOptions _options;
        private readonly IODataServerMiddlewareOptions _optionValues;

        public ODataServerMiddleware(RequestDelegate next, ODataServerMiddlewareOptions options)
        {
            _next = next;
            _options = options;
            _optionValues = options;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(ODataService.IsServicePath(httpContext, _optionValues))
            {
                IODataService odataService = ODataService.Create(httpContext, _optionValues);

                await odataService.RunAsync();
            }
            else
            {
                Console.WriteLine($"Request for {httpContext.Request.PathBase} received ({httpContext.Request.ContentLength ?? 0} bytes)");
                await _next.Invoke(httpContext);
            }
            // Call the next middleware delegate in the pipeline 
        }
    }
}
