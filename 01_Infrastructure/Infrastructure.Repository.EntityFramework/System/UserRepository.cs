
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.UnitOfWork;
using Infrastructure.Core.Repository;
using Danwu.Domain.Model;
using Danwu.Domain.Repository;

namespace Infrastructure.Repository.EntityFramework
{
    /// <summary>
    /// “用户”仓储
    /// </summary>
    public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context)
        { }

        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 判断指定的用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UserNameExist(string userName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 确认密码是否一致
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
