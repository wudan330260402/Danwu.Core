
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
    /// “用户角色”领域仓储
    /// </summary>
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        /// <summary>
        /// 根据用户获取角色列表
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        IEnumerable<Role> GetRolesByUser(String userId);

        /// <summary>
        /// 根据角色id获取用户列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        IEnumerable<User> GetUsersByRole(String roleId);
    }
}
