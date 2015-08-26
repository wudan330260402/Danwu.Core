
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.Repository;
using Danwu.Domain.Model;


namespace Danwu.Domain.Repository
{
    /// <summary>
    /// “用户”领域仓储
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 根据用户名获取用户实体
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetByUserName(String userName);

        /// <summary>
        /// 制定的用户名是否已存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Boolean UserNameExist(String userName);

        /// <summary>
        /// 校验用户名密码是否匹配
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Boolean CheckPassword(String userName, String password);
    }
}
