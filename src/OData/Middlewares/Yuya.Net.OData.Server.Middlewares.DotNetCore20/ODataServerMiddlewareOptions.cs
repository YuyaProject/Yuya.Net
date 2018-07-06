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
        private ODataVersion _version;

        private ODataServerMiddlewareOptions()
        {

        }

        PathString IODataServerMiddlewareOptions.BasePath => _basePath;
        ODataVersion IODataServerMiddlewareOptions.Version => _version;

        public ODataServerMiddlewareOptions BasePath(string basePath)
        {
            if (string.IsNullOrWhiteSpace(basePath)) throw new ArgumentNullException(nameof(basePath));
            _basePath = basePath;
            return this;
        }

        public ODataServerMiddlewareOptions Version(ODataVersion version)
        {
            _version = version;
            return this;
        }

        public static ODataServerMiddlewareOptions Create(string path = "", ODataVersion odataVersion = ODataVersion.V4)
        {
            return new ODataServerMiddlewareOptions() { _basePath = path, _version = odataVersion };
        }
    }
}
