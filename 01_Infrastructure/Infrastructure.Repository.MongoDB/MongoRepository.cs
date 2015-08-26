using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Linq.Expressions;


using MongoDB.Driver;
using MongoDB.Driver.Linq;

using Infrastructure.Core;
using Infrastructure.Core.UnitOfWork;
using Infrastructure.Core.Repository;
using Infrastructure.Core.Specifications;
using Infrastructure.Core.Common;

namespace Infrastructure.Repository.MongoDB
{
    public abstract class MongoRepository<T> : Repository<T>
         where T :class, IAggregateRoot
    {
        protected MongoCollection collection;

        public MongoRepository(IRepositoryContext context)
            : base(context)
        {
            collection = null;
        }

        #region Override

        public override T Get(object id)
        {
            //var collection = this.getCollectionForType(typeof(T));
            Guid guid;
            if (Guid.TryParse(id.ToString(), out guid))
            {
                return collection.AsQueryable<T>().FirstOrDefault(t => t.ID == guid);
            }
            throw new RepositoryException(String.Format("无效的id：{0}", id));
        }

        public override IQueryable<T> QueryBy(ISpecification<T> specification, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            //var collection = this.getCollectionForType(typeof(T));
            var query = collection.AsQueryable<T>().Where(specification.GetExpression());
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    return query.SortBy<T>(sortPredicate);
                case SortOrder.Descending:
                    return query.SortByDescending<T>(sortPredicate);
            }
            return query;
        }

        public override PageResult<T> QueryByPage(ISpecification<T> specification, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder, int pageSize, int pageIndex)
        {
            var skip = (pageIndex - 1) * pageSize;
            var take = pageSize;
            var count = 0;

            //var collection = this.getCollectionForType(typeof(T));
            var query = collection.AsQueryable<T>().Where(specification.GetExpression());
            count = query.Count();

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
