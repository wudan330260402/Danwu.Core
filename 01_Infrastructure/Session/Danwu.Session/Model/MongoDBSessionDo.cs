using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson.Serialization.Attributes;

namespace Danwu.Session.Model
{
    [Serializable]
    public class MongoDBSessionDo
    {
        [BsonId]
        public String SessionId { get; set; }

        public String ApplicationName { get; set; }

        public DateTime Created { get; set; }

        public DateTime Expired { get; set; }

        public DateTime LockDate { get; set; }

        public Int32 LockId { get; set; }

        public Boolean Locked { get; set; }

        public Int32 TimeOut { get; set; }

        public String SessionItem { get; set; }

        public Int32 Flags { get; set; }
    }
}
