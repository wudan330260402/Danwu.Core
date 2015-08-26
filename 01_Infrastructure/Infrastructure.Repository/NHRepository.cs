using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Linq.Expressions;

using Infrastructure.Core;
using Infrastructure.Core.UnitOfWork;
using Infrastructure.Core.Repository;

namespace Infrastructure.Repository.NHibernate
{
    public abstract class NHRepository<TAggregateRoot> : Repository<TAggregateRoot>
         where TAggregateRoot :class, IAggregateRoot
    {

        public NHRepository(IRepositoryContext context)
            : base(context)
        { }

    }
}
