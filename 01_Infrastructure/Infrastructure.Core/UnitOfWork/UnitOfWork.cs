using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Transactions;

namespace Infrastructure.Core.UnitOfWork
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected IDictionary<IAggregateRoot, IUnitOfWorkRepository> _addEntities;
        protected IDictionary<IAggregateRoot, IUnitOfWorkRepository> _updateEntities;
        protected IDictionary<IAggregateRoot, IUnitOfWorkRepository> _deleteEntities;

        public UnitOfWork()
        {
            _addEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _updateEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _deleteEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        public virtual void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            if (!_addEntities.ContainsKey(entity))
                this._addEntities.Add(entity, repository);
        }
        public virtual void RegisterUpdated(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            if (!_updateEntities.ContainsKey(entity))
                this._updateEntities.Add(entity, repository);
        }
        public virtual void RegisterDeleted(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            if (!_deleteEntities.ContainsKey(entity))
                this._deleteEntities.Add(entity, repository);
        }

        /// <summary>
        /// 是否提交
        /// </summary>
        public virtual Boolean Committed
        {
            get;
            protected set;
        }

        public abstract bool Commit();

        public abstract void Rollback();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
