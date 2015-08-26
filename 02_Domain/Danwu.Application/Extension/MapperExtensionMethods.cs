using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Infrastructure.Core.Extension;
using Danwu.Domain.Model;
using Danwu.Application.DTO.System;

namespace Danwu.Application.Extension
{
    public static class MapperExtension
    {

        #region User
        
        public static UserDto ConvertToUserDto(this User user)
        {
            //方法一：一一赋值
            //UserModel userModel = new UserModel();
            //return userModel;

            //方法二：autoMapper
            return Mapper.Map<User, UserDto>(user);
        }
        public static IList<UserDto> ConvertToUserDto(this IList<User> userList)
        {
            IList<UserDto> userDtoList = new List<UserDto>();

            userList.ForEach(user =>
            {
                userDtoList.Add(user.ConvertToUserDto());
            });

            return userDtoList;
        }

        public static User ConvertToUser(this UserDto userDto) {
            return Mapper.Map<UserDto, User>(userDto);
        }
        public static IList<User> ConvertToUser(this IList<UserDto> userDtos) {
            IList<User> userList = new List<User>();

            userDtos.ForEach(userDto =>
            {
                userList.Add(userDto.ConvertToUser());
            });

            return userList;
        }

        #endregion      
        
        #region Role
        
        public static RoleDto ConvertToRoleDto(this Role role)
        {
            //方法一：一一赋值
            //RoleModel roleModel = new RoleModel();
            //return roleModel;

            return Mapper.Map<Role, RoleDto>(role);
        }
        public static IList<RoleDto> ConvertToRoleDto(this IList<Role> roleList)
        {
            IList<RoleDto> roleDtoList = new List<RoleDto>();

            roleList.ForEach(role =>
            {
                roleDtoList.Add(role.ConvertToRoleDto());
            });
            return roleDtoList;
        }

        #endregion

        #region Menu

        public static MenuDto ConvertToMenuDto(this Menu menu)
        {
            //方法一：一一赋值
            //MenuModel menuModel = new MenuModel();
            //return menuModel;

            return Mapper.Map<Menu, MenuDto>(menu);
        }
        public static IList<MenuDto> ConvertToMenuDto(this IList<Menu> menuList)
        {
            IList<MenuDto> menuDtoList = new List<MenuDto>();
            menuList.ForEach(menu =>
            {
                menuDtoList.Add(menu.ConvertToMenuDto());
            });

            return menuDtoList;
        }

        #endregion

    }
}
