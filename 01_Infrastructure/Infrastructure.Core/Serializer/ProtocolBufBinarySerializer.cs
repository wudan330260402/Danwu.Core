using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

using ProtoBuf;

namespace Infrastructure.Core.Serializer
{
    public class ProtocolBufSerializer : IBinarySerializer
    {
        public byte[] Serialize(object obj)
        {
            using (var ms = new MemoryStream()) {
                ProtoBuf.Serializer.NonGeneric.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public object Deserialize(byte[] data,Type type)
        {
            using (var ms = new MemoryStream(data)) {
                return ProtoBuf.Serializer.NonGeneric.Deserialize(type, ms);
            }
        }

        public T Deserialize<T>(byte[] data) where T : class
        {
            using (var ms = new MemoryStream(data)) {
                return ProtoBuf.Serializer.Deserialize<T>(ms);
            }
        }
    }
}
