using System;
using System.Collections.Generic;
using System.Text;
using Yuya.Net.Serializers;

namespace Yuya.Net.OData.Server
{
    public class ODataJsonSerializer : IODataJsonSerializer
    {
        private readonly IJsonSerializer _jsonSerializer;

        public ODataJsonSerializer(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public T DeserializeObject<T>(object serializedObject)
        {
            return _jsonSerializer.DeserializeObject<T>(serializedObject);
        }

        public object SerializeObject(object data)
        {
            return _jsonSerializer.SerializeObject(data);
        }
    }
}
