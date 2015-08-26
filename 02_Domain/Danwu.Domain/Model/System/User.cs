
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core;

namespace Danwu.Domain.Model
{
    /// <summary>
    /// “用户”领域聚合跟
    /// </summary>
    public class User : AggregateRoot
    {
        
        #region Private Fields

        private String userName;
        private String passWord;
        private String realName;
        private String nickName;
        private String email;
        private String phoneNum;
        private UserStatus status;

        private DateTime registerTime;
        private DateTime lastLogonTime;

        #endregion

        #region Ctors

        public User() {
            this.id = Guid.NewGuid();
            this.registerTime = DateTime.Now;
            this.lastLogonTime = DateTime.Now;
        }

        #endregion

        #region Public Properties

        public String UserName {
            get { return userName; }
            set { this.userName = value; }
        }

        public String PassWord {
            get { return this.passWord; }
            set { this.passWord = value; }
        }

        public String RealName {
            get { return this.realName; }
            set { this.realName = value; }
        }

        public String NickName {
            get { return this.nickName; }
            set { this.nickName = value; }
        }

        public String Email {
            get { return this.email; }
            set { this.email = value; }
        }

        public String PhoneNum {
            get { return this.phoneNum; }
            set { this.phoneNum = value; }
        }

        public UserStatus Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public DateTime RegisterTime {
            get { return this.registerTime; }
            set { this.registerTime = value; }
        }

        public DateTime LastLogonTime {
            get { return this.lastLogonTime; }
            set { this.lastLogonTime = value; }
        }

        #endregion

        /// <summary>
        /// 禁用用户
        /// </summary>
        public void Disable() {
            this.status = UserStatus.Disabled;
        }
        /// <summary>
        /// 启用用户
        /// </summary>
        public void Enable() {
            this.status = UserStatus.Enabled;
        }

    }

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus : int
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
