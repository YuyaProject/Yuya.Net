using System;
using System.Runtime.Serialization;

namespace Yuya.Net.OData.Server.Operations
{
    [Serializable]
    internal class TopSyntaxException : Exception
    {
        public TopSyntaxException()
        {
        }

        public TopSyntaxException(string message) : base(message)
        {
        }

        public TopSyntaxException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TopSyntaxException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}