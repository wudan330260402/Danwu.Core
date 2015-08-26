using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Common
{
    public class PageInfo
    {
        public Int32 PageIndex { get; set; }
        public Int32 PageSize { get; set; }
        public String SortColumn { get; set; }
        public SortType SortType { get; set; }
    }

    /// <summary>
    /// 排序方式
    /// </summary>
    public enum SortType { 
        /// <summary>
        /// 升序
        /// </summary>
        Asc =0,
        /// <summary>
        /// 倒序
        /// </summary>
        Desc=1
    }
}
