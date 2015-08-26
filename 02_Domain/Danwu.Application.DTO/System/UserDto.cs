using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Danwu.Application.DTO.System
{
    [DataContract]
    [Serializable]
    public class UserDto
    {
        [DataMember]
        public String ID { get; set; }
        [DataMember]
        public String UserName { get; set; }
        [DataMember]
        public String PassWord { get; set; }
        [DataMember]
        public String RealName { get; set; }
        [DataMember]
        public String NickName { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String PhoneNo { get; set; }
        [DataMember]
        public Int32 State { get; set; }
        [DataMember]
        public DateTime RegisterTime { get; set; }
        [DataMember]
        public DateTime LastLogonTime { get; set; }
    }
}
