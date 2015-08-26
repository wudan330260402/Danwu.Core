
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core;

namespace Danwu.Domain.Model
{
    /// <summary>
    /// “角色”领域聚合跟
    /// </summary>
    public class Role : AggregateRoot
    {

        #region Private Fields

        private String roleName;
        private RoleStatus status;
        private String roleDesc;
        private DateTime createTime;

        #endregion

        #region Ctor

        public Role() {
            this.id = Guid.NewGuid();
            this.createTime = DateTime.Now;
        }

        #endregion

        #region Public Properties

        public String RoleName {
            get { return this.roleName; }
            set { this.roleName = value; }
        }
        public RoleStatus Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
        public String RoleDesc {
            get { return this.roleDesc; }
            set { this.roleDesc = value; }
        }
        public DateTime CreateTime {
            get { return createTime; }
            set { createTime = value; }
        }

        #endregion

        /// <summary>
        /// 禁用角色
        /// </summary>
        public void Disable() {
            this.status = RoleStatus.Disabled;
        }
        /// <summary>
        /// 启用角色
        /// </summary>
        public void Enable() {
            this.status = RoleStatus.Enabled;
        }

    }

    /// <summary>
    /// 角色状态
    /// </summary>
    public enum RoleStatus : int
    {
        /// <summary>
        /// 禁用
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// 启用
        /// </summary>
        Enabled = 1
    }
}
