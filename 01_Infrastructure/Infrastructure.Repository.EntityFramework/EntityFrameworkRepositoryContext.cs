using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;

using Infrastructure.Core.Extension;
using Infrastructure.Core.Repository;

namespace Infrastructure.Repository.EntityFramework
{
    public interface IEntityFrameWorkRepositoryContext : IRepositoryContext {
        DbContext EFContext { get; }
    }

    public class EntityFrameworkRepositoryContext : RepositoryContext, IEntityFrameWorkRepositoryContext
    {
        private readonly ThreadLocal<DbContext> localEFContext = new ThreadLocal<DbContext>(() => new DanwuDbContext());
        private readonly DbContext efContext = new DanwuDbContext();
        private String guid = string.Empty;

        //public EntityFrameworkRepositoryContext(DbContext dbContext) {
        //    this.efContext = dbContext;
        //}
        public EntityFrameworkRepositoryContext() {
            guid = Guid.NewGuid().ToString();
        }

        public String ID {
            get { return guid; }
        }

        #region IEntityFrameWorkRepositoryContext Members

        public DbContext EFContext
        {
            get { return localEFContext.Value; }
        }

        #endregion

        #region RepositoryContext Members

        public override void RegisterAdded<T>(T entity)
        {
            EFContext.Entry(entity).State = EntityState.Added;
            this.Committed = false;
        }

        public override void RegisterUpdated<T>(T entity)
        {
            EFContext.Entry(entity).State = EntityState.Modified;
            this.Committed = false;
        }

        public override void RegisterDeleted<T>(T entity)
        {
            EFContext.Entry(entity).State = EntityState.Deleted;
            this.Committed = false;
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public override bool Commit()
        {
            Boolean result = false;
            try
            {
                if (EFContext.Database.Connection.State != ConnectionState.Open)
                    EFContext.Database.Connection.Open();

                if (!this.Committed)
                {
                    var count = this.EFContext.SaveChanges();
                    if (count > 0)
                    {
                        result = true;
                        this.Committed = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally { 
                
            }
            return result;
        }
        /// <summary>
        /// 回滚
        /// </summary>
        public override void Rollback()
        {
            this.Committed = false;
        }
        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (!this.Committed) this.Commit();
                this.EFContext.Dispose();
                base.Dispose();
            }
        }

        #endregion
    }
}
