using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using Infrastructure.Core.UnitOfWork;
using Infrastructure.Core.Common;
using Infrastructure.Core.Specifications;

namespace Infrastructure.Core.Repository
{
    public abstract class Repository<T> : IRepository<T>
        where T : class,IAggregateRoot
    {

        public Repository(IRepositoryContext context)
        {
            this.context = context;
        }

        #region 实现接口IRepository

        private readonly IRepositoryContext context;
        public IRepositoryContext Context
        {
            get { return context; }
        }

        public virtual void Create(T entity)
        {
            context.RegisterAdded<T>(entity);
        }
        public virtual void Update(T entity)
        {
            context.RegisterUpdated<T>(entity);
        }
        public virtual void Delete(T entity)
        {
            context.RegisterDeleted<T>(entity);
        }

        public abstract T Get(object id);

        public IQueryable<T> QueryAll() {
            return QueryBy(new AnySpecification<T>(), null, SortOrder.Unspecified);
        }
        public IQueryable<T> QueryBy(ISpecification<T> specification)
        {
            return QueryBy(specification, null, SortOrder.Unspecified);
        }
        public abstract IQueryable<T> QueryBy(ISpecification<T> specification, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder);
        
        public PageResult<T> QueryByPage(Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, int pageSize, int pageIndex)
        {
            return QueryByPage(new AnySpecification<T>(), sortPredicate, sortOrder, pageSize, pageIndex);
        }
        public abstract PageResult<T> QueryByPage(ISpecification<T> specification, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, int pageSize, int pageIndex);

        #endregion
        
    }
}
