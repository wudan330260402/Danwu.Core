using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Common
{
    /// <summary>
    /// 分页查询类
    /// </summary>
    public class PageSearch
    {
        private Int32 currentIndex;
        /// <summary>
        /// 页索引
        /// </summary>
        public Int32 CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }

        private Int32 pageSize = 10;
        /// <summary>
        /// 单页数
        /// </summary>
        public Int32 PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private string filterFields = "*";
        /// <summary>
        /// 查询字段
        /// </summary>
        public String FilterFields
        {
            get { return filterFields; }
            set { filterFields = value; }
        }

        private string sortFields = "";
        /// <summary>
        /// 排序字段
        /// 格式: 字段名 ASC(DESC)
        /// </summary>
        public String SortFields
        {
            get { return sortFields; }
            set { sortFields = value; }
        }
    }
}
