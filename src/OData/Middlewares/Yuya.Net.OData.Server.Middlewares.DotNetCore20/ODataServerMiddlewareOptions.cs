using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yuya.Net.OData.Server.DotNetCore20
{
    public class ODataServerMiddlewareOptions : IODataServerMiddlewareOptions
    {
        private PathString _basePath;
        private ODataVersionEnum _version;

        private ODataServerMiddlewareOptions()
        {

        }

        PathString IODataServerMiddlewareOptions.BasePath => _basePath;
        ODataVersionEnum IODataServerMiddlewareOptions.Version => _version;

        public ODataServerMiddlewareOptions BasePath(string basePath)
        {
            if (string.IsNullOrWhiteSpace(basePath)) throw new ArgumentNullException(nameof(basePath));
            _basePath = basePath;
            return this;
        }

        public ODataServerMiddlewareOptions Version(ODataVersionEnum version)
        {
            _version = version;
            return this;
        }

        public static ODataServerMiddlewareOptions Create(string path = "", ODataVersionEnum odataVersion = ODataVersionEnum.V4)
        {
            return new ODataServerMiddlewareOptions() { _basePath = path, _version = odataVersion };
        }
    }
}
