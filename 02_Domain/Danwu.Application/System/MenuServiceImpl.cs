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
    public class MenuServiceImpl : ApplicationService, IMenuService
    {
        private IMenuRepository menuRepository;

        public MenuServiceImpl(IRepositoryContext context, IMenuRepository menuRepository)
            : base(context)
        {
            this.menuRepository = menuRepository;
        }

        #region IMenuService

        public bool CreateMenu(MenuDto menu)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMenu(MenuDto menu)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMenu(string menuId)
        {
            throw new NotImplementedException();
        }

        public MenuDto GetById(string menuId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MenuDto> QueryAll()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
