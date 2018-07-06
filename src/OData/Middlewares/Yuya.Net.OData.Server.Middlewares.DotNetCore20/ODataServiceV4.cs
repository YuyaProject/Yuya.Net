using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yuya.Net.OData.Server.DotNetCore20
{
    internal class ODataServiceV4 : IODataService
    {
        private readonly HttpContext _httpContext;
        private readonly IODataServerMiddlewareOptions _optionValues;
        private readonly HttpRequest _request;
        private readonly HttpResponse _response;

        public ODataServiceV4(HttpContext httpContext, IODataServerMiddlewareOptions optionValues)
        {
            _httpContext = httpContext;
            _optionValues = optionValues;
            _request = httpContext.Request;
            _response = httpContext.Response;
        }


        public async Task RunAsync()
        {
            Console.WriteLine("bizim bölgede");

            _response.Headers.Add("OData-Version", "4.0");
            _response.ContentType = "application/json; odata.metadata=minimal";
            await _response.WriteAsync("{ \"success\": true }");
        }
    }
}
