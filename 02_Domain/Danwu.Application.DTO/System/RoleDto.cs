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
    public class RoleDto
    {
        /// <summary>
        /// 角色id
        /// </summary>
        [DataMember]
        public String RoleID { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
        [DataMember]
        public String RoleCode { get; set; }
        /// <summary>
        /// 角色name
        /// </summary>
        [DataMember]
        public String RoleName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public Int32 State { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        [DataMember]
        public String RoleDesc { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
    }
}
