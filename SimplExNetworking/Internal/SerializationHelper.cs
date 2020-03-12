using ProtoBuf;
using System.IO;
namespace SimplExNetworking.Internal
{
    static internal class SerializationHelper
    {
        public static T ProtoDeserialize<T>(byte[] data) where T : class
        {
            if (null == data) return null;
            using (MemoryStream stream = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }
        public static byte[] ProtoSerialize<T>(T record) where T : class
        {
            if (null == record) return null;
            using (MemoryStream stream = new MemoryStream())
            {
                Serializer.Serialize(stream, record);
                return stream.ToArray();
            }
        }
    }
}
