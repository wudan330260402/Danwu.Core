using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Infrastructure.Core;
using Infrastructure.Core.Repository;
using Infrastructure.Core.UnitOfWork;
using Infrastructure.Core.Specifications;
using Infrastructure.Core.Common;


namespace Infrastructure.Repository.EntityFramework
{
    public class EntityFrameworkRepository<T> : Repository<T>
        where T : class, IAggregateRoot
    {
        protected DbContext EFContext;

        public EntityFrameworkRepository(IRepositoryContext context)
            : base(context)
        {
            if (context is IEntityFrameWorkRepositoryContext)
                EFContext = ((IEntityFrameWorkRepositoryContext)context).EFContext;
            else throw new Exception("");
        }

        #region Override

        public override T Get(object id)
        {
            return EFContext.Set<T>().FirstOrDefault(t => t.ID == Guid.Parse(id.ToString()));
        }

        public override IQueryable<T> QueryBy(ISpecification<T> specification, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            var query = this.EFContext.Set<T>().Where(specification.GetExpression());
            switch (sortOrder) { 
                case SortOrder.Ascending:
                    query = query.SortBy<T>(sortPredicate);
                    break;
                case SortOrder.Descending:
                    query = query.SortByDescending<T>(sortPredicate);
                    break;
            }
            return query;
        }

        public override PageResult<T> QueryByPage(ISpecification<T> specification, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, int pageSize, int pageIndex)
        {
            var skip = (pageIndex - 1) * pageSize;
            var take = pageSize;

            var query = this.EFContext.Set<T>().Where(specification.GetExpression());
            var count = query.Count();
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    query = query.SortBy<T>(sortPredicate);
                    break;
                case SortOrder.Descending:
                    query = query.SortByDescending<T>(sortPredicate);
                    break;
            }
            return new PageResult<T>(pageSize, pageIndex, count, query.Skip(skip).Take(take).ToList());
        }

        #endregion

    }
}
