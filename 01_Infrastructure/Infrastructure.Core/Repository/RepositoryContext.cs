using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Core.Repository
{
    public abstract class RepositoryContext : DisposableObject, IRepositoryContext
    {

        #region Private Fields

        private readonly ThreadLocal<Dictionary<String, Object>> localNewCollection = new ThreadLocal<Dictionary<string, object>>(() => new Dictionary<String, Object>());
        private readonly ThreadLocal<Dictionary<String, Object>> localModifiecCollection = new ThreadLocal<Dictionary<string, object>>(() => new Dictionary<String, Object>());
        private readonly ThreadLocal<Dictionary<String, Object>> localDeletedCollection = new ThreadLocal<Dictionary<string, object>>(() => new Dictionary<String, Object>());
        private readonly ThreadLocal<Boolean> localCommitted = new ThreadLocal<bool>(() => true);

        #endregion

        #region Protected Properties

        protected IEnumerable<KeyValuePair<String, Object>> NewCollection {
            get { return localNewCollection.Value.ToList(); }
        }

        protected IEnumerable<KeyValuePair<String, Object>> ModifiedCollection {
            get { return localModifiecCollection.Value.ToList(); }
        }

        protected IEnumerable<KeyValuePair<String, Object>> DeletedCollection {
            get { return localDeletedCollection.Value.ToList(); }
        }

        #endregion

        #region IRepositoryContext

        public virtual void RegisterAdded<T>(T entity) where T : class, IAggregateRoot
        {
            if (localNewCollection.Value.ContainsKey(entity.ID.ToString()))
                throw new Exception("");
            localNewCollection.Value.Add(entity.ID.ToString(), entity);
            localCommitted.Value = false;
        }

        public virtual void RegisterUpdated<T>(T entity) where T : class, IAggregateRoot
        {
            if (!localModifiecCollection.Value.ContainsKey(entity.ID.ToString()))
                localModifiecCollection.Value.Add(entity.ID.ToString(), entity);
            localCommitted.Value = false;
        }

        public virtual void RegisterDeleted<T>(T entity) where T : class, IAggregateRoot
        {
            if (!localDeletedCollection.Value.ContainsKey(entity.ID.ToString()))
                localDeletedCollection.Value.Add(entity.ID.ToString(), entity);
            localCommitted.Value = false;
        }

        #endregion

        #region IUnitOfWork Members

        public bool Committed
        {
            get { return localCommitted.Value; }
            protected set { localCommitted.Value = value; }
        }

        public abstract bool Commit();

        public abstract void Rollback();

        #endregion

        #region DisposableObject

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                this.localNewCollection.Dispose();
                this.localModifiecCollection.Dispose();
                this.localDeletedCollection.Dispose();
                base.Dispose();
            }
        }

        #endregion

    }
}
