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
    /// 菜单服务接口
    /// </summary>
    [ServiceContract]
    public interface IMenuService
    {
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool CreateMenu(MenuDto menu);
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateMenu(MenuDto menu);
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteMenu(String menuId);

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        MenuDto GetById(String menuId);

        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        IEnumerable<MenuDto> QueryAll();

    }
}
