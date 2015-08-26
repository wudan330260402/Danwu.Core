using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.ServiceProxy;
using Danwu.ServiceContract.System;
using Danwu.Application.DTO.System;

namespace Danwu.ServiceClient.System
{
    public class UserServiceClient
    {
        private readonly IUserService userService = ServiceProxyFactory.CreateChannel<IUserService>();

        public Boolean CreateUser(UserDto userDto) {
            return userService.CreateUser(userDto);
        }

    }
}
