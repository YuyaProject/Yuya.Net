using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Yuya.Net.Serializers
{
    /// <summary>
    /// .Net Default Xml Serializer
    /// </summary>
    /// <seealso cref="Yuya.Net.Serializers.IXmlSerializer" />
    public class DotNetXmlSerializer : IXmlSerializer
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
            using (var stringReader = new StringReader(xmlString))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(stringReader);
            }
        }

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public object SerializeObject(object data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            using (var stringWriter = new StringWriter())
            {
                XmlSerializer xs = new XmlSerializer(data.GetType());
                xs.Serialize(stringWriter, data);
                return stringWriter.ToString();
            }
        }
    }
}
