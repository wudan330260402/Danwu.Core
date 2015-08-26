using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Infrastructure.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// 是否提交
        /// </summary>
        Boolean Committed { get; }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <returns>key实体,value为Id</returns>
        Boolean Commit();

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="isolationLevel">事务级别</param>
        /// <returns>key实体,value为Id</returns>
        //Boolean Commit(IsolationLevel isolationLevel);
        
        /// <summary>
        /// 回滚当前的Unit Of Work事务。
        /// </summary>
        void Rollback();
    }
}
