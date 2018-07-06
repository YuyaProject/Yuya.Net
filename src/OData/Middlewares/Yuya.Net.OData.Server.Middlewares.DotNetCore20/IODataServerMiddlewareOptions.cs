using Microsoft.AspNetCore.Http;

namespace Yuya.Net.OData.Server.DotNetCore20
{
    internal interface IODataServerMiddlewareOptions
    {
        PathString BasePath { get; }

        ODataVersion Version { get; }
    }
}