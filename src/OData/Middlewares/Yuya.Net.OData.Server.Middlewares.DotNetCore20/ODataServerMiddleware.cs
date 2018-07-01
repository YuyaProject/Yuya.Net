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

        public ODataServerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine($"Request for {httpContext.Request.Path} received ({httpContext.Request.ContentLength ?? 0} bytes)");

            // Call the next middleware delegate in the pipeline 
            await _next.Invoke(httpContext);
        }

    }
}
