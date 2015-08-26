using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.DomainModel
{
    public class SysResult<T>
    {
        /// <summary>
        /// 返回编码：0=成功
        /// </summary>
        public String Code
        {
            get;
            set;
        }
        /// <summary>
        /// 返回消息
        /// </summary>
        public String Message
        {
            get;
            set;
        }
        /// <summary>
        /// 分页时总行数
        /// </summary>
        public Int32 total
        {
            get;
            set;
        }
        /// <summary>
        /// 返回数据
        /// </summary>
        public IList<T> rows { get; set; }

        public SysResult()
        {
            this.rows = new List<T>();
        }
        public SysResult(string code)
        {
            this.Code = code;
            this.rows = new List<T>();
        }
        public SysResult(string code, string message)
        {
            this.Code = code;
            this.Message = message;
            this.rows = new List<T>();
        }

    }
}
