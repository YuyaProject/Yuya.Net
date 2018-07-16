using System;
using System.Collections.Generic;
using System.Text;

namespace Yuya.Net.OData.Server.Operations
{
    internal class QueryOperationInfo : IQueryOperation
    {
        public QueryOperationInfo(string entityName, int? top = null, string filterString = null)
        {
            EntityName = entityName;
            if (top.HasValue) Top = top.Value;
            if (!string.IsNullOrWhiteSpace(filterString)) FilterString = filterString;
        }

        public string EntityName { get; }

        public int Top { get; private set; }

        public string FilterString { get; private set; }

        internal QueryOperationInfo SetTop(int top)
        {
            Top = top;
            return this;
        }

        internal QueryOperationInfo SetFilterString(string filterString)
        {
            FilterString = filterString;
            return this;
        }

        internal IOperationInfo ParseQueryString(string queryString)
        {
            if (string.IsNullOrWhiteSpace(queryString)) throw new ArgumentNullException(nameof(queryString));
            var a = queryString.TrimStart('?').Replace("&amp;", "¨");
            var b = a.Split('&');
            foreach (var item in b)
            {
                var decodedString = item.Trim().Replace("¨", "&");
                if (GetTopValueFromString(decodedString)) continue;
                if (GetFilterStringFromString(decodedString)) continue;
            }
            return this;
        }

        private bool GetFilterStringFromString(string item)
        {
            if (!item.StartsWith("$filter=")) return false;

            var s = item.Substring(8).Trim();
            FilterString= s;
            return true;
        }

        private bool GetTopValueFromString(string item)
        {
            if (!item.StartsWith("$top=")) return false;

            var s = item.Substring(5).Trim();
            var i = Converters.GetInt32(s);
            if (i == null) throw new TopSyntaxException($"top syntax[{s}] is fault.");
            Top = i.Value;
            return true;
        }

    }
}
