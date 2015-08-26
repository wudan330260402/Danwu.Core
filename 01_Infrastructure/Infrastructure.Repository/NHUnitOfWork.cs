using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

using NHibernate;

using Infrastructure.Core;
using Infrastructure.Core.UnitOfWork;

namespace Infrastructure.Repository.NHibernate
{
    public class NHUnitOfWork : UnitOfWork
    {
        protected ISession _session;

        public NHUnitOfWork()
        {
            _session = SessionBuilder.SessionInstance;
        }

        public override bool Commit()
        {
            bool result = false;
            using (ITransaction tran = _session.BeginTransaction()) {
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

                    tran.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
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
