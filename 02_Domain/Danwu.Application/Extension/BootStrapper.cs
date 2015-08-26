using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Danwu.Domain.Model;
using Danwu.Application.DTO.System;

namespace Danwu.Application.Extension
{
    internal class BootStrapper
    {
        public static void ConfigAutoMapper()
        {
            #region System Mapping

            Mapper.CreateMap<User, UserDto>()
                .ForMember(dest => dest.ID, opt => { opt.MapFrom(source => source.ID.ToString()); })
                .ForMember(dest => dest.PhoneNo, opt => { opt.MapFrom(source => source.PhoneNum); })
                .ForMember(dest => dest.State, opt => { opt.MapFrom(source => (Int32)source.Status); });

            Mapper.CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.RoleID, opt => { opt.MapFrom(source => source.ID.ToString()); })
                .ForMember(dest => dest.State, opt => { opt.MapFrom(source => (Int32)source.Status); });

            Mapper.CreateMap<Menu, MenuDto>();

            Mapper.CreateMap<UserDto, User>();
            Mapper.CreateMap<RoleDto, Role>();
            Mapper.CreateMap<MenuDto, Menu>();

            #endregion
        }
    }
}
