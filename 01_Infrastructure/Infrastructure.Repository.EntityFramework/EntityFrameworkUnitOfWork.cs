using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;
using System.Data;

using Infrastructure.Core.UnitOfWork;
using Infrastructure.Core;

namespace Infrastructure.Repository.EntityFramework
{

    public class EntityFrameworkUnitOfWork : UnitOfWork
    {
        private DbContext efContext;
        public EntityFrameworkUnitOfWork(DbContext efContext)
        {
            this.efContext = efContext;
        }

        public override bool Commit()
        {
            try
            {
                if (efContext.Database.Connection.State != ConnectionState.Open) efContext.Database.Connection.Open();

                if (_addEntities != null && _addEntities.Count > 0) {
                    foreach (var entity in _addEntities.Keys) {
                        efContext.Entry(entity).State = EntityState.Added;
                    }
                }
                if (_updateEntities != null && _updateEntities.Count > 0) {
                    foreach (var entity in _updateEntities.Keys){
                        efContext.Entry(entity).State = EntityState.Modified;
                    }
                }
                if (_deleteEntities != null && _deleteEntities.Count > 0) {
                    foreach (var entity in _deleteEntities.Keys) {
                        efContext.Entry(entity).State = EntityState.Deleted;
                    }
                }

                efContext.SaveChanges();
                Committed = true;
            }
            catch (Exception ex)
            {

            }
            finally {
                _addEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
                _updateEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
                _deleteEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            }
            return true;
        }

        public override void Rollback()
        {
            throw new NotImplementedException();
        }
    }

}
