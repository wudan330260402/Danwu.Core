using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

using Infrastructure.Core;
using Infrastructure.Core.Common;
using Infrastructure.Core.Specifications;

namespace Infrastructure.Core.Repository
{
    public interface IRepository<T>
        where T : class, IAggregateRoot
    {
        #region Properties

        IRepositoryContext Context { get; }

        #endregion

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        T Get(object id);

        #region Query

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        IQueryable<T> QueryAll();
        /// <summary>
        /// 查询符合规则的数据
        /// </summary>
        /// <param name="specification"></param>
        /// <returns></returns>
        IQueryable<T> QueryBy(ISpecification<T> specification);
        /// <summary>
        /// 查询符合规则的数据
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        IQueryable<T> QueryBy(ISpecification<T> specification, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        PageResult<T> QueryByPage(Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, Int32 pageSize, Int32 pageIndex);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="specification"></param>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        PageResult<T> QueryByPage(ISpecification<T> specification, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, Int32 pageSize, Int32 pageIndex);

        #endregion
    }
}
