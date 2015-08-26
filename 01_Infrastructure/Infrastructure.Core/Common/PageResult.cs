using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Common
{
    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T> : ICollection<T>
    {
        public PageResult() {
            this.data = new List<T>();
        }
        public PageResult(Int32 pageSize,Int32 pageIndex,Int32 totalRecords,IList<T> data) {
            this.pageSize = pageSize;
            this.pageIndex = pageIndex;
            this.totalRecords = totalRecords;
            this.data = data;
        }

        #region Public Properties

        private Int32 pageSize;
        public Int32 PageSize {
            get { return this.pageSize; }
            set { this.pageSize = value; }
        }

        private Int32 pageIndex;
        public Int32 PageIndex {
            get { return this.pageIndex; }
            set { this.pageIndex = value; }
        }

        private Int32 totalRecords;
        public Int32 TotalRecords {
            get { return this.totalRecords; }
            set { this.totalRecords = value; }
        }

        public Int32 TotalPages {
            get {
                if (totalRecords == 0 || pageSize == 0) return 0;
                if (totalRecords % pageSize != 0) return (totalRecords / pageSize) + 1;
                return totalRecords / pageSize;
            }
        }

        private IList<T> data;
        public IList<T> Data {
            get { return this.data; }
            set { this.data = value; }
        }

        #endregion

        #region ICollection<T> Members

        public void Add(T item)
        {
            this.data.Add(item);
        }

        public void Clear()
        {
            this.data.Clear();
        }

        public bool Contains(T item)
        {
            return data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return this.data.Remove(item);
        }

        #endregion

        #region IEnumerator<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        #endregion

        #region IEnumerator Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

    }
}
