using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using Danwu.Application.DTO.System;

namespace Danwu.ServiceContract.System
{
    /// <summary>
    /// 角色服务接口
    /// </summary>
    [ServiceContract]
    public interface IRoleService
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool CreateRole(RoleDto role);
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateRole(RoleDto model);
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteRole(String roleId);

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        RoleDto GetById(String roleId);

        /// <summary>
        /// 根据用户id获取对应角色列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<RoleDto> QueryByUserId(String userId);

        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<RoleDto> QueryRoleAll();

    }
}
