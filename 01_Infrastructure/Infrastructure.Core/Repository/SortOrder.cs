using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Repository
{
    /// <summary>
    /// 排序方式
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// 未指定
        /// </summary>
        Unspecified = -1,
        /// <summary>
        /// 升序
        /// </summary>
        Ascending = 0,
        /// <summary>
        /// 降序
        /// </summary>
        Descending = 1
    }

    /// <summary>
    /// 排序扩展
    /// </summary>
    public static class SortOrderExtension
    {
        public static String ToSortString(this SortOrder sortOrder) {
            switch (sortOrder) { 
                case SortOrder.Ascending:
                    return "OrderBy";
                case SortOrder.Descending:
                    return "OrderByDescending";
                default:
                    throw new ArgumentException("Sort Order must be specified as either Ascending or Descending.", "sortOrder");
            }
        }
    }
}
