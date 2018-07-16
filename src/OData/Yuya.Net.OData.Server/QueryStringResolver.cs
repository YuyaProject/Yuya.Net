using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Yuya.Net.OData.Server.Operations;

namespace Yuya.Net.OData.Server
{
    public class QueryStringResolver : IQueryStringResolver
    {
        private static readonly Regex UrlParserRegex = new Regex("^([a-zA-Z]+)((\\('.*'\\))|(\\?.*)|\\/|)$", RegexOptions.Compiled);

        public IOperationInfo GetOperationInfoByUrl(string url, string basePath = "")
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            basePath = basePath ?? string.Empty;

            var clearedUrl = url.Substring(basePath.Length).Trim('/');

            //var entityName = url.Substring(basePath.Length).Trim('/');
            //if (entityName.Contains("/")) entityName = entityName.Substring(0, entityName.IndexOf('/') - 1);

            var m = UrlParserRegex.Match(clearedUrl);

            if (m.Success)
            {
                var entityName = m.Groups[1].Value;

                if (!m.Groups[2].Success || string.IsNullOrWhiteSpace(m.Groups[2].Value) || m.Groups[2].Value == "/")
                {
                    // List 
                    return new ListOperationInfo(entityName);
                }
                else if (m.Groups[2].Success && m.Groups[3].Success)
                {
                    var id = m.Groups[3].Value.TrimStart('(').TrimEnd(')').Trim('\'');
                    return new GetByIdOperationInfo(entityName, id);
                }
                else if (m.Groups[2].Success && m.Groups[4].Success)
                {
                    var queryString = m.Groups[4].Value.TrimStart('?');
                    return new QueryOperationInfo(entityName).ParseQueryString(queryString);
                }
            }
            else
                throw new ArgumentException("url argument isn't correct.", nameof(url));


            return null;
        }
    }
}
