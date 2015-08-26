using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    /// <summary>
    /// 表示聚合根的基类型
    /// </summary>
    public abstract class AggregateRoot : IAggregateRoot
    {

        protected Guid id;

        #region IAggregateRoot

        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Version
        {
            get { return 1; }
        }

        #endregion

        #region override Methods

        /// <summary>
        /// 重写Equals方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (null == obj) return false;
            if (ReferenceEquals(this, obj)) return true;

            AggregateRoot ar = obj as AggregateRoot;
            if (ar == null) return false;
            
            return ar.ID == this.id;
        }

        /// <summary>
        /// 重写GetHashCode方法
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        #endregion
        
    }
}
