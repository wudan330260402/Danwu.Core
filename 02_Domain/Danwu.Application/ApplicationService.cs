using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core;
using Infrastructure.Core.Repository;
using Infrastructure.Core.UnitOfWork;
using Danwu.Application.Extension;

namespace Danwu.Application
{
    /// <summary>
    /// 应用层服务抽象类
    /// </summary>
    public abstract class ApplicationService
    {
        #region Fields

        private IRepositoryContext context;

        #endregion

        #region Ctors

        static ApplicationService()
        {
            Initialize();
        }

        public ApplicationService(IRepositoryContext context)
        {
            this.context = context;
        }

        #endregion

        #region Protected Properties

        protected IRepositoryContext Context
        {
            get { return this.context; }
        }

        #endregion

        /// <summary>
        /// 初始化数据
        /// </summary>
        static void Initialize()
        {
            BootStrapper.ConfigAutoMapper();
        }

    }
}
