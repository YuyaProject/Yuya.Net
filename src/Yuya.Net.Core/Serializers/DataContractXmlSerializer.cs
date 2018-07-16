using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Yuya.Net.Serializers
{
    public class DataContractXmlSerializer : IXmlSerializer
    {
        /// <summary>
        /// Deserializes the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedObject">The serialized object.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">serializedObject</exception>
        public T DeserializeObject<T>(object serializedObject)
        {
            var xmlString = serializedObject as string;
            if (string.IsNullOrWhiteSpace(xmlString)) throw new ArgumentNullException(nameof(serializedObject));
            DataContractXmlSerializer xs = new DataContractXmlSerializer();
            return xs.DeserializeObject<T>(xmlString);
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public object SerializeObject(object data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            DataContractXmlSerializer xs = new DataContractXmlSerializer();
            return xs.SerializeObject(data);
        }
    }
}
