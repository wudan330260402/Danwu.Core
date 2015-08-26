using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Infrastructure.Core.IOC;
using Danwu.Application.System;
using Danwu.Application.DTO.System;
using Danwu.ServiceContract.System;

namespace Danwu.Services.System
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UserService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 UserService.svc 或 UserService.svc.cs，然后开始调试。
    public class UserService : IUserService
    {
        #region Private Fields

        private readonly IUserService userServiceImpl = ServiceLocator.Instance.Resolve<IUserService>();

        #endregion

        public bool CreateUser(Application.DTO.System.UserDto userDto)
        {
            return userServiceImpl.CreateUser(userDto);
        }

        public bool UpdateUser(Application.DTO.System.UserDto userDto)
        {
            return userServiceImpl.UpdateUser(userDto);
        }

        public bool DeleteUser(string userId)
        {
            return userServiceImpl.DeleteUser(userId);
        }

        public UserDto GetUser(string userId)
        {
            return userServiceImpl.GetUser(userId);
        }

        public IEnumerable<UserDto> QueryAll()
        {
            return userServiceImpl.QueryAll();
        }
    }
}
