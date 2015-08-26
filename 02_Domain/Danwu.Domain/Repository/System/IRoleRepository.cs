
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
    /// “角色”领域仓储
    /// </summary>
    public interface IRoleRepository : IRepository<Role>
    {
        /// <summary>
        /// 根据角名获取用户实体
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Role GetByRoleCode(String roleCode);

        /// <summary>
        /// 制定的角色编码是否已存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Boolean RoleCodeExist(String roleCode);

        /// <summary>
        /// 制定的角色名是否已存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Boolean RoleNameExist(String roleName);
    }
}
