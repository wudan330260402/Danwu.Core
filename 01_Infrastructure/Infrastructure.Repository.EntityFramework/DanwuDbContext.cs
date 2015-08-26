using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Danwu.Domain.Model;
using System.Data.Entity.Infrastructure;

namespace Infrastructure.Repository.EntityFramework
{
    public class DanwuDbContext : DbContext
    {
        /// <summary>
        /// Entity Framework数据库初始化四种策略
        /// </summary>
        static DanwuDbContext() {
            //【策略一】数据库不存在时重新创建数据库
            Database.SetInitializer<DanwuDbContext>(new CreateDatabaseIfNotExists<DanwuDbContext>());
            
            //【策略二】每次启动应用程序时创建数据库
            //Database.SetInitializer<DanwuDbContext>(new DropCreateDatabaseAlways<DanwuDbContext>());

            //【策略三】模型更改时重新创建数据库
            //Database.SetInitializer<DanwuDbContext>(new DropCreateDatabaseIfModelChanges<DanwuDbContext>());

            //【策略四】从不创建数据库
            //Database.SetInitializer<DanwuDbContext>(null);
        }

        public DanwuDbContext()
            : base("Danwu")
        {
            
        }

        #region System Properties

        //public DbSet<Menu> Menus
        //{
        //    get { return Set<Menu>(); }
        //}
        public DbSet<User> User {
            get { return Set<User>(); }
        }
        //public DbSet<Role> Roles {
        //    get { return Set<Role>(); }
        //}

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .Add(new UserTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }        
    }
}
