
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core;

namespace Danwu.Domain.Model
{
    /// <summary>
    /// 表示“菜单角色关系”领域的聚合根
    /// </summary>
    public class MenuRole : AggregateRoot
    {
        #region Private Fields
        private Guid menuID;
        private Guid roleID;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个新的<c>MenuRole</c>实例。
        /// </summary>
        public MenuRole() { }

        /// <summary>
        /// 初始化一个新的<c>MenuRole</c>实例。
        /// </summary>
        /// <param name="menuID">菜单ID。</param>
        /// <param name="roleID">角色的ID。</param>
        public MenuRole(Guid menuID, Guid roleID)
        {
            this.menuID = menuID;
            this.roleID = roleID;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// 获取或设置菜单ID值。
        /// </summary>
        public Guid MenuID
        {
            get { return menuID; }
            set { menuID = value; }
        }

        /// <summary>
        /// 获取或设置角色的ID值。
        /// </summary>
        public Guid RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }
        #endregion
    }
}
