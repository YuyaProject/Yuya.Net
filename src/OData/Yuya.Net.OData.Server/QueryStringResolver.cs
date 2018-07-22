using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Yuya.Net.OData.Server.Operations;
using Yuya.Net.OData.Server.Operations.Filters;

namespace Yuya.Net.OData.Server
{
    public class QueryStringResolver : IQueryStringResolver
    {
        private static readonly Regex GetByIdUrlParserRegex = new Regex("^([a-zA-Z]+)\\(('.*?')\\)$", RegexOptions.Compiled);
        private static readonly Regex UrlParserRegex = new Regex("^([a-zA-Z]+)((\\('.*'\\))|(\\?.*)|\\/|)$", RegexOptions.Compiled);
        private static readonly Regex DecodeUrlParserRegex = new Regex("(%[0-9A-Fa-f]{2})", RegexOptions.Compiled);

        public IOperationInfo GetOperationInfoByUrl(string url, string basePath = "")
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            basePath = basePath ?? string.Empty;

            var clearedUrl = url.Substring(basePath.Length).Trim('/');

            var entityUrlQueryString = SplitUrl(clearedUrl);

            var operationInfo = ParseEntityUrl(entityUrlQueryString.BaseUrl);

            ParseQueryString(operationInfo, entityUrlQueryString.QueryString);

            //var entityName = url.Substring(basePath.Length).Trim('/');
            //if (entityName.Contains("/")) entityName = entityName.Substring(0, entityName.IndexOf('/') - 1);

            //var m = UrlParserRegex.Match(clearedUrl);

            //if (m.Success)
            //{
            //    var entityName = m.Groups[1].Value;

            //    if (!m.Groups[2].Success || string.IsNullOrWhiteSpace(m.Groups[2].Value) || m.Groups[2].Value == "/")
            //    {
            //        // List 
            //        return new ListOperationInfo(entityName);
            //    }
            //    else if (m.Groups[2].Success && m.Groups[3].Success)
            //    {
            //        var id = m.Groups[3].Value.TrimStart('(').TrimEnd(')').Trim('\'');
            //        return new GetByIdOperationInfo(entityName, id);
            //    }
            //    else if (m.Groups[2].Success && m.Groups[4].Success)
            //    {
            //        var queryString = m.Groups[4].Value.TrimStart('?');
            //        return new QueryOperationInfo(entityName).ParseQueryString(queryString);
            //    }
            //}
            //else
            //    throw new ArgumentException("url argument isn't correct.", nameof(url));


            return null;
        }

        internal IOperationInfo ParseEntityUrl(string entityUrl)
        {
            if (!entityUrl.Contains("/") && !entityUrl.Contains("("))
            {
                // simple List
                return new OperationInfo(entityUrl) { ReturnEntityName = entityUrl, ReturnType = OperationReturnTypeEnum.EntityList };
            }
            if (!entityUrl.Contains("/") && entityUrl.Contains("("))
            {
                // Get By Id
                var m = GetByIdUrlParserRegex.Match(entityUrl);

                if (m.Success)
                {
                    var operationInfo = new OperationInfo(entityUrl)
                    {
                        ReturnEntityName = m.Groups[1].Value,
                        ReturnType = OperationReturnTypeEnum.SingleEntity,
                        FilterOperations = { new GetByIdFilterOperation() { IdString = m.Groups[2].Value } }
                    };
                }
                throw new ArgumentException("Format is not correct.", nameof(entityUrl));
            }
            throw new NotImplementedException();
        }

        internal IOperationInfo ParseQueryString(IOperationInfo operationInfo, string queryString)
        {
            if (string.IsNullOrWhiteSpace(queryString)) return operationInfo;
            foreach (var item in queryString.Split('&'))
            {
                var splitKeyValue = item.Split(new[] { '=' }, 2);

                if (splitKeyValue.Length < 2) throw new ApplicationException(); // TODO: Burayı düzenlemeliyim.

                operationInfo.FilterOperations.Add(GetFilterOperation(splitKeyValue[0], DecodeUrl(splitKeyValue[1])));
            }
            return operationInfo;
        }

        internal string DecodeUrl(string encodedUrl)
        {
            if (encodedUrl == null) return null;
            return DecodeUrlParserRegex.Replace(encodedUrl, ConvertUrlToChar);
        }

        private string ConvertUrlToChar(Match match)
        {
            var hex = match.Groups[1].Value.TrimStart('%').ToUpperInvariant();
            var charValue =(char) Convert.ToInt32(hex, 16);
            return charValue.ToString();
        }

        internal IFilterOperation GetFilterOperation(string key, string value)
        {
            throw new NotImplementedException();
        }

        internal BaseUrlQueryString SplitUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (url.Contains("?"))
            {
                var index = url.IndexOf('?');
                var baseUrl = url.Substring(0, index - 1);
                var query = url.Substring(index + 1);
                return new BaseUrlQueryString { BaseUrl = baseUrl, QueryString = query };
            }
            else
            {
                return new BaseUrlQueryString { BaseUrl = url };
            }
        }

        internal class BaseUrlQueryString
        {
            public string BaseUrl { get; set; }

            public string QueryString{ get; set; }
        }
    }
}
