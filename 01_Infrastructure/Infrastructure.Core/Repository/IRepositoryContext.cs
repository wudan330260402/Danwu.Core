using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.UnitOfWork;

namespace Infrastructure.Core.Repository
{
    public interface IRepositoryContext : IUnitOfWork
    {
        void RegisterAdded<T>(T entity) where T : class,IAggregateRoot;
        void RegisterUpdated<T>(T entity) where T : class,IAggregateRoot;
        void RegisterDeleted<T>(T entity) where T : class,IAggregateRoot;
    }
}
