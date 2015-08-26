using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Core.Log.Model
{
    [Serializable]
    internal class MongoDBLogDo
    {
        //[BsonId]
        public String LogId { get; set; }

        public String AppID { get; set; }

        public String Ip { get; set; }

        public String LogTitle { get; set; }

        public LogLevelType LogLevel { get; set; }

        public String Content { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
