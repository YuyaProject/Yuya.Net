using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Yuya.Net.Serializers
{
    public class DataContractJsonSerializer : IJsonSerializer
    {
        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString">The xml string.</param>
        /// <returns></returns>
        public T DeserializeObject<T>(object serializedObject)
        {
            var jsonString = serializedObject as string;
            if (string.IsNullOrWhiteSpace(jsonString)) throw new ArgumentNullException(nameof(serializedObject));
            DataContractJsonSerializer xs = new DataContractJsonSerializer();
            return xs.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public object SerializeObject(object data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if(data is string) throw new ArgumentException("data argument is a string.", nameof(data));
            DataContractJsonSerializer xs = new DataContractJsonSerializer();
            return xs.SerializeObject(data);
        }
    }
}
