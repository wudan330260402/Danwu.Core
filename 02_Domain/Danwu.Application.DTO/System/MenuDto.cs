using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Danwu.Application.DTO.System
{
    /// <summary>
    /// 菜单契约
    /// </summary>
    [DataContract]
    [Serializable]
    public class MenuDto
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        [DataMember]
        public String MenuID { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        [DataMember]
        public String MenuCode { get; set; }
        /// <summary>
        /// 菜单name
        /// </summary>
        [DataMember]
        public String MenuName { get; set; }
        /// <summary>
        /// 菜单url
        /// </summary>
        [DataMember]
        public String MenuUrl { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [DataMember]
        public String MenuIco { get; set; }
        /// <summary>
        /// 菜单等级
        /// </summary>
        [DataMember]
        public Int32 MenuLevel { get; set; }
        /// <summary>
        /// 菜单排序
        /// </summary>
        [DataMember]
        public Int32 MenuSequence { get; set; }
        /// <summary>
        /// 父级菜单id
        /// 没有则为空
        /// </summary>
        [DataMember]
        public String ParentID { get; set; }
        /// <summary>
        /// 菜单描述
        /// </summary>
        [DataMember]
        public String MenuDesc { get; set; }
        /// <summary>
        /// 菜单状态
        /// </summary>
        [DataMember]
        public Int32 State { get; set; }
    }
}
