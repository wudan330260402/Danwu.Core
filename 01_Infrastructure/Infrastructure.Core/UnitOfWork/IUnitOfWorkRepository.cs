using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        void PersistCreate(IAggregateRoot entity);
        void PersistUpdate(IAggregateRoot entity);
        void PersistDelete(IAggregateRoot entity);
    }
}
