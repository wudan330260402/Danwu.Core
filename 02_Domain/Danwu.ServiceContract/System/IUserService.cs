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
    /// 用户服务接口
    /// </summary>
    [ServiceContract]
    public interface IUserService
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool CreateUser(UserDto userDto);
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateUser(UserDto userDto);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteUser(String userId);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        UserDto GetUser(String userId);

        /// <summary>
        /// 查询所有用户列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IEnumerable<UserDto> QueryAll();

    }
}
