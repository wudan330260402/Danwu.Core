using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson.Serialization.Attributes;

namespace Danwu.Session.Model
{
    [Serializable]
    public class MemcachedSessionDo
    {
        public String ApplicationName { get; set; }

        public Boolean Locked { get; set; }

        public Int32 LockId { get; set; }

        public DateTime LockDate { get; set; }   

        public String SessionItem { get; set; }

        public DateTime Created { get; set; }

        public Int32 Flags { get; set; }
    }
}
