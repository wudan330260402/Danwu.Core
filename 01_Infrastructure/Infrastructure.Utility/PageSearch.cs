using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCakeShopping.Common
{
    /// <summary>
    /// 分页查询类
    /// </summary>
    public class PageSearch
    {
        private Int32 currentIndex;
        public Int32 CurrentIndex
        {
            get { return currentIndex; }
            set { currentIndex = value; }
        }

        private Int32 pageSize = 10;
        public Int32 PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private string filterFields = "*";
        public String FilterFields
        {
            get { return filterFields; }
            set { filterFields = value; }
        }

        private string sortFields;
        public String SortFields
        {
            get { return sortFields; }
            set { sortFields = value; }
        }
    }
}
