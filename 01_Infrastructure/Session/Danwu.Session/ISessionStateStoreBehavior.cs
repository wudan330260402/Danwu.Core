using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Danwu.Session
{
    /// <summary>
    /// Session状态存储接口
    /// </summary>
    public interface ISessionStateStoreBehavior
    {

        /// <summary>
        /// 创建未初始化的项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="timeout"></param>
        void CreateUninitializedItem(System.Web.HttpContext context, String id, Int32 timeout);

        /// <summary>
        /// 获取项
        /// </summary>
        /// <param name="lockRecord"></param>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="locaked"></param>
        /// <param name="lockAge"></param>
        /// <param name="lockId"></param>
        /// <param name="actions"></param>
        /// <returns></returns>
        SessionStateStoreData GetItem(bool lockRecord, System.Web.HttpContext context, String id, out bool locaked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions);

        /// <summary>
        /// 释放项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="lockId"></param>
        void ReleaseItem(System.Web.HttpContext context, String id, Object lockId);

        /// <summary>
        /// 移除项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="lockId"></param>
        void RemoveItem(System.Web.HttpContext context, String id, Object lockId);

        /// <summary>
        /// 重设项超时时间
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        void ResetItemTimeout(System.Web.HttpContext context, String id);

        /// <summary>
        /// 设置并释放项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <param name="lockId"></param>
        /// <param name="newItem"></param>
        void SetAndReleaseItem(System.Web.HttpContext context, String id, SessionStateStoreData item, Object lockId, bool newItem);
    }
}
