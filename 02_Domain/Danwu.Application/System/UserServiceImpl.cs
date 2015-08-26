using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.Repository;
using Danwu.Domain.Repository;
using Danwu.Application.DTO.System;
using Danwu.Application.Extension;
using Danwu.ServiceContract.System;

namespace Danwu.Application.System
{
    /// <summary>
    /// 用户服务实现
    /// </summary>
    public class UserServiceImpl : ApplicationService,IUserService
    {
        private IUserRepository userRepository;

        public UserServiceImpl(IUserRepository userRepository)
            : base(userRepository.Context)
        {
            this.userRepository = userRepository;
        }

        #region IUserService Members

        public bool CreateUser(UserDto userDto)
        {
            userRepository.Create(userDto.ConvertToUser());
            return userRepository.Context.Commit();
            return Context.Commit();
        }

        public bool UpdateUser(UserDto userDto)
        {
            userRepository.Update(userDto.ConvertToUser());
            return base.Context.Commit();
        }

        public bool DeleteUser(string userId)
        {
            userRepository.Delete(userRepository.Get(userId));
            return base.Context.Commit();
        }

        public UserDto GetUser(string userId)
        {
            return userRepository.Get(userId).ConvertToUserDto();
        }

        public IEnumerable<UserDto> QueryAll()
        {
            return userRepository.QueryAll().ToList().ConvertToUserDto();
        }

        #endregion

    }
}
