using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.Repository;
using Infrastructure.Core.UnitOfWork;

namespace Infrastructure.Core.Repository
{
    public abstract class AdoRepository<TAggregateRoot> : Repository<TAggregateRoot>
        where TAggregateRoot :class, IAggregateRoot
    {
        #region Private


        #endregion

        #region Ctor

        public AdoRepository(IRepositoryContext context)
            : base(context)
        { }

        #endregion
    }
}
