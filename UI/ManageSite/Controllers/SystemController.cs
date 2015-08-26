using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageSite.Controllers
{
    public class SystemController : BaseController
    {
        //
        // GET: /System/

        public SystemController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        #region 用户

        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult GetUserByID(String userid)
        {
            //SysResult<User> sysResult = new SysResult<User>() { Code = "-9999", Message = "未知错误" };
            //long uid = 0;
            //try
            //{
            //    if (long.TryParse(userid, out uid))
            //    {
            //        User entity = userService.Get(uid);
            //        if (entity != null)
            //        {
            //            sysResult.Code = "0";
            //            sysResult.Message = "成功";
            //            sysResult.rows = new List<User>() { entity };
            //        }
            //    }
            //}
            //catch { }

            //return Json(sysResult);
            return View();
        }

        [HttpPost]
        public ActionResult SaveUser()
        {

            //SysResult<String> sysResult = new SysResult<String>()
            //{
            //    Code = "-9999",
            //    Message = "未知错误"
            //};
            //try
            //{
            //    User entity = null;
            //    if (model.Mode.ToLower() == "edit") entity = userService.Get(model.ID);
            //    else
            //    {
            //        entity = new User();
            //        entity.UserName = model.UserName;
            //        entity.CreateTime = DateTime.Now;
            //        entity.LastLogonTime = DateTime.Now;
            //        entity.PassWord = "123456";//正式的需进行一层加密
            //    }

            //    entity.NickName = model.NickName;
            //    entity.RealName = model.RealName;
            //    entity.State = model.State;
            //    bool result = false;
            //    if (model.Mode.ToLower() == "edit")
            //        result = userService.UpdateUser(entity);
            //    else result = userService.CreateUser(entity);
            //    if (result)
            //    {
            //        sysResult.Code = "0";
            //        sysResult.Message = "";
            //    }
            //    else
            //    {
            //        sysResult.Code = "-1";
            //        sysResult.Message = "用户更新失败";
            //    }
            //}
            //catch { }

            //return Json(sysResult);

            return View();
        }

        [HttpPost]
        public ActionResult DeleteUser(String ids)
        {
            //SysResult<String> sysResult = new SysResult<String>() { Code = "-9999", Message = "未知错误" };

            //long uid = 0;
            //try
            //{
            //    String[] idArray = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    IList<User> userList = new List<User>();
            //    foreach (String id in idArray)
            //    {
            //        if (long.TryParse(id, out uid))
            //        {
            //            User entity = userService.Get(uid);
            //            if (entity != null)
            //            {
            //                userList.Add(entity);
            //            }
            //            else
            //            {
            //                throw new Exception("无效的用户ID,UserID:" + id);
            //            }
            //        }
            //        else
            //        {
            //            throw new Exception("无效的用户ID,UserID:" + id);
            //        }
            //    }
            //    if (userService.DeleteUserList(userList))
            //    {
            //        sysResult.Code = "0";
            //        sysResult.Message = "成功";
            //    }
            //    else
            //    {
            //        sysResult.Message = "用户删除失败";
            //    }

            //}
            //catch (Exception ex)
            //{
            //    sysResult.Code = "-9999";
            //    sysResult.Message += "异常:" + ex.Message;
            //}

            //return Json(sysResult);

            return View();
        }

        public ActionResult QueryUser(Int32 page = 1, Int32 rows = 10)
        {
            //if (page <= 0) page = 1;
            //PageSearch ps = new PageSearch()
            //{
            //    CurrentIndex = page - 1,
            //    PageSize = rows
            //};
            //Int32 recordCount = 0;
            //IQueryable<User> list = userService.QueryUserByPage(ps, out recordCount);

            //SysResult<User> result = new SysResult<User>()
            //{
            //    Code = "0",
            //    Message = "",
            //    total = recordCount,
            //    rows = list.ToList()
            //};

            //return Json(result);

            return View();
        }

        #endregion

        #region 角色

        public ActionResult RoleList() {
            return View();
        }

        public ActionResult QueryRole() {

            //IList<Role> list = roleService.QueryRoleAll().ToList();
            ////IList<RoleModel> roleList = new List<RoleModel>(){
            ////    new RoleModel(){ID=0,RoleCode="role",RoleName="角色列表",children=getRoleList(list)}
            ////};
            //IList<RoleModel> roleList = getRoleList(list);

            //SysResult<RoleModel> result = new SysResult<RoleModel>()
            //{
            //    Code = "0",
            //    Message = "",
            //    total=100,
            //    rows = roleList.ToList()
            //};

            ////return Json(result);
            //return Json(result);

            return View();
        }

        //private IList<RoleModel> getRoleList(IList<Role> list) {
        //    IList<RoleModel> listModel = new List<RoleModel>();
        //    List<Role> list_01 = list.Where(t => t.ParentID == 0).ToList();
        //    if (list_01 == null || list_01.Count <= 0)
        //        return null;
        //    list_01.ForEach(role =>
        //    {
        //        RoleModel roleModel = new RoleModel();
        //        roleModel.ID = role.ID;
        //        roleModel.RoleCode = role.RoleCode;
        //        roleModel.RoleName = role.RoleName;
        //        roleModel.State = role.State == 1 ? "启用" : "禁用";
        //        roleModel.CreateTime = role.CreateTime.ToString("yyyy-MM-dd HH:mm");
        //        roleModel.children = getRoleListByRecursive(list, role.ID);
        //        listModel.Add(roleModel);
        //    });
        //    return listModel;
        //}

        //private IList<RoleModel> getRoleListByRecursive(IList<Role> list, long parentID) {
        //    IList<RoleModel> listModel = new List<RoleModel>();
        //    List<Role> childList = list.Where(t => t.ParentID == parentID).ToList();
        //    if (childList == null || childList.Count <= 0)
        //        return null;

        //    childList.ForEach(role =>
        //    {
        //        RoleModel roleModel = new RoleModel();
        //        roleModel.ID = role.ID;
        //        roleModel.RoleCode = role.RoleCode;
        //        roleModel.RoleName = role.RoleName;
        //        roleModel.State = role.State == 1 ? "启用" : "禁用";
        //        roleModel.CreateTime = role.CreateTime.ToString("yyyy-MM-dd HH:mm");
        //        roleModel.children = getRoleListByRecursive(list, role.ID);
        //        listModel.Add(roleModel);
        //    });
        //    return listModel;
        //}

        #endregion

        #region 菜单

        public ActionResult MenuList()
        {
            return View();
        }

        #endregion

        #region 权限


        #endregion

    }
}
