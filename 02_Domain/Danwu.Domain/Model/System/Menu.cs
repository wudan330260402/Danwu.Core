
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core;

namespace Danwu.Domain.Model
{
    /// <summary>
    /// “菜单模块”领域聚合跟
    /// </summary>
    public class Menu : AggregateRoot
    {
        #region Private Fields

        private String menuCode;
        private String menuName;
        private String menuUrl;
        private String menuIco;
        private Int32 menuLevel;
        private Guid parentId;
        private Int32 menuSequence;
        private MenuStatus status;
        private String menuDesc;

        #endregion

        #region Public Properties

        public String MenuCode
        {
            get { return this.menuCode; }
            set { this.menuCode = value; }
        }
        public String MenuName
        {
            get { return this.menuName; }
            set { this.menuName = value; }
        }
        public String MenuUrl
        {
            get { return this.menuUrl; }
            set { this.menuUrl = value; }
        }
        public String MenuIco
        {
            get { return this.menuIco; }
            set { this.menuIco = value; }
        }
        public Int32 MenuLevel
        {
            get { return this.menuLevel; }
            set { this.menuLevel = value; }
        }
        public Guid ParentId
        {
            get { return this.parentId; }
            set { this.parentId = value; }
        }
        public Int32 MenuSequence {
            get { return this.menuSequence; }
            set { this.menuSequence = value; }
        }
        public MenuStatus Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
        public String MenuDesc
        {
            get { return this.menuDesc; }
            set { this.menuDesc = value; }
        }

        #endregion
    }

    /// <summary>
    /// 菜单状态
    /// </summary>
    public enum MenuStatus : int
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
