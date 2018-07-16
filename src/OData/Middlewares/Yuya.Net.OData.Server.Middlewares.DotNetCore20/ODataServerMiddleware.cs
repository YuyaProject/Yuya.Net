using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Yuya.Net.OData.Server.DotNetCore20.Services;

namespace Yuya.Net.OData.Server.DotNetCore20
{
    /// <summary>
    /// OData Server ASP.Net Core 2.0 Middleware
    /// </summary>
    public class ODataServerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ODataServerMiddlewareOptions _options;
        private readonly IODataServerMiddlewareOptions _optionValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="ODataServerMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="options">The options.</param>
        public ODataServerMiddleware(RequestDelegate next, ODataServerMiddlewareOptions options)
        {
            _next = next;
            _options = options;
            _optionValues = options;
        }

        /// <summary>
        /// Invokes the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            if(ODataService.IsServicePath(httpContext, _optionValues))
            {
                IService odataService = ODataService.Create(httpContext, _optionValues);

                await odataService.RunAsync().ConfigureAwait(false);
            }
            else
            {
                Console.WriteLine($"Request for {httpContext.Request.PathBase} received ({httpContext.Request.ContentLength ?? 0} bytes)");
                await _next.Invoke(httpContext).ConfigureAwait(false);
            }
            // Call the next middleware delegate in the pipeline 
        }
    }
}
