using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Transactions;

namespace Infrastructure.Core.UnitOfWork
{
    public class AdoUnitOfWork : UnitOfWork
    {
        public AdoUnitOfWork()
        {
            _addEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _updateEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _deleteEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

        public override bool Commit()
        {
            bool result = false;
            using (TransactionScope scope = new TransactionScope()) {
                try
                {
                    if (_addEntities != null && _addEntities.Count > 0)
                    {
                        foreach (IAggregateRoot entity in _addEntities.Keys)
                        {
                            this._addEntities[entity].PersistCreate(entity);
                        }
                    }
                    if (_updateEntities != null && _updateEntities.Count > 0)
                    {
                        foreach (IAggregateRoot entity in _updateEntities.Keys)
                        {
                            this._updateEntities[entity].PersistUpdate(entity);
                        }
                    }

                    if (_deleteEntities != null && _deleteEntities.Count > 0)
                    {
                        foreach (IAggregateRoot entity in _deleteEntities.Keys)
                        {
                            this._deleteEntities[entity].PersistDelete(entity);
                        }
                    }

                    scope.Complete();
                    result = true;
                }
                catch (Exception ex)
                {
                    //log
                }
                finally {
                    //重置
                    _addEntities.Clear();
                    _updateEntities.Clear();
                    _deleteEntities.Clear();
                }
            }

            return result;
        }

        public override void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
