using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yuya.Net.OData.Server.DotNetCore20.Services
{
    internal class ODataServiceV4 : IService
    {
        private readonly HttpContext _httpContext;
        private readonly IODataJsonSerializer _jsonSerializer;
        private readonly IODataServerMiddlewareOptions _optionValues;
        private readonly HttpRequest _request;
        private readonly HttpResponse _response;
        private readonly IQueryStringResolver _queryStringResolver;
        private ODataRequest _odataRequest;

        public ODataServiceV4(HttpContext httpContext, IODataServerMiddlewareOptions optionValues, IQueryStringResolver queryStringResolver)
        {
            _httpContext = httpContext;
            _jsonSerializer = _httpContext.RequestServices.GetService(typeof(IODataJsonSerializer)) as IODataJsonSerializer;
            _optionValues = optionValues;
            _request = httpContext.Request;
            _response = httpContext.Response;
            _queryStringResolver = queryStringResolver;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("bizim bölgede");

            _odataRequest = CreateODataRequest();

            SetResponseHeaders();

            if (string.IsNullOrWhiteSpace(_odataRequest.EntityName))
            {
                await WriteObject(new { success = true });
                return;
            }

            object responseObject = GetResponseObject();

            await WriteObject(responseObject);
        }

        private object GetResponseObject()
        {
            return new { bir = 1 };
        }

        private Task WriteObject(object p)
        {
            return _response.WriteAsync(_jsonSerializer.SerializeObject(p) as string);
        }

        private void SetResponseHeaders()
        {
            _response.Headers.Add("OData-Version", "4.0");
            _response.ContentType = "application/json; odata.metadata=minimal";
        }

        private ODataRequest CreateODataRequest()
        {
            var request = new ODataRequest()
            {
                Service = this,
            };

            var operationInfo = _queryStringResolver.GetOperationInfoByUrl(_request.Path + _request.QueryString, _optionValues.BasePath.Value);
            // /odata/v4/Person
            var entityName = _request.Path.Value.Substring(_optionValues.BasePath.Value.Length).Trim('/');
            if (entityName.Contains("/")) entityName = entityName.Substring(0, entityName.IndexOf('/') - 1);

            request.EntityName = entityName;

            return request;
        }
    }
}
