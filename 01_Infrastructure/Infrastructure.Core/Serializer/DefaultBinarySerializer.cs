using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Infrastructure.Core.Serializer
{
    /// <summary>
    /// 默认的二进制序列化
    /// </summary>
    public class DefaultBinarySerializer : IBinarySerializer
    {
        private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            using (var ms = new MemoryStream()) {
                _binaryFormatter.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public object Deserialize(byte[] data,Type type)
        {
            using (var ms = new MemoryStream(data)) {
                return _binaryFormatter.Deserialize(ms);
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data) where T : class
        {
            using (var ms = new MemoryStream(data)) {
                return _binaryFormatter.Deserialize(ms) as T;
            }
        }
    }
}
