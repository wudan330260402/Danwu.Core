using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.Repository;
using Danwu.Domain.Repository;
using Danwu.Application.DTO.System;
using Danwu.ServiceContract.System;

namespace Danwu.Application.System
{
    public class RoleServiceImpl : ApplicationService, IRoleService
    {
        private IRoleRepository roleRepository;

        public RoleServiceImpl(IRepositoryContext context, IRoleRepository roleRepository)
            : base(context)
        {
            this.roleRepository = roleRepository;
        }

        #region IRoleService

        public bool CreateRole(RoleDto role)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRole(RoleDto model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRole(string roleId)
        {
            throw new NotImplementedException();
        }

        public RoleDto GetById(string roleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleDto> QueryByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleDto> QueryRoleAll()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
