namespace Yuya.Net.Serializers
{
    public interface IObjectSerializer
    {
        object SerializeObject(object data);

        T DeserializeObject<T>(object serializedObject);
    }
}