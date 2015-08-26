using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace Danwu.Session
{
    /// <summary>
    /// 自定义Session状态存储驱动
    /// </summary>
    public class DistributedSessionProvider : SessionStateStoreProviderBase
    {
        /// <summary>
        /// 当前Session状态存储行为实例
        /// </summary>
        private ISessionStateStoreBehavior sessionStateStoreBehavior;

        #region Cotrs

        public DistributedSessionProvider() {
            sessionStateStoreBehavior = SessionProviderBehaviorFactory.CreateSessionStateStoreBehaviorInstance();
        }

        #endregion

        public override void InitializeRequest(System.Web.HttpContext context)
        {

        }

        /// <summary>
        /// 创建新的存储数据
        /// </summary>
        /// <param name="context"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public override SessionStateStoreData CreateNewStoreData(System.Web.HttpContext context, int timeout)
        {
            return new SessionStateStoreData(new SessionStateItemCollection(), SessionStateUtility.GetSessionStaticObjects(context), timeout);
        }

        /// <summary>
        /// 创建未初始化的项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="timeout"></param>
        public override void CreateUninitializedItem(System.Web.HttpContext context, string id, int timeout)
        {
            sessionStateStoreBehavior.CreateUninitializedItem(context, id, timeout);
        }

        /// <summary>
        /// 获取项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="locked"></param>
        /// <param name="lockAge"></param>
        /// <param name="lockId"></param>
        /// <param name="actions"></param>
        /// <returns></returns>
        public override SessionStateStoreData GetItem(System.Web.HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
        {
            return sessionStateStoreBehavior.GetItem(false, context, id, out locked, out lockAge, out lockId, out actions);
        }

        /// <summary>
        /// 独占获取项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="locked"></param>
        /// <param name="lockAge"></param>
        /// <param name="lockId"></param>
        /// <param name="actions"></param>
        /// <returns></returns>
        public override SessionStateStoreData GetItemExclusive(System.Web.HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
        {
            return sessionStateStoreBehavior.GetItem(true, context, id, out locked, out lockAge, out lockId, out actions);
        }

        /// <summary>
        /// 独占释放项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="lockId"></param>
        public override void ReleaseItemExclusive(System.Web.HttpContext context, string id, object lockId)
        {
            sessionStateStoreBehavior.ReleaseItem(context, id, lockId);
        }

        /// <summary>
        /// 设置并释放项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <param name="lockId"></param>
        /// <param name="newItem"></param>
        public override void SetAndReleaseItemExclusive(System.Web.HttpContext context, string id, SessionStateStoreData item, object lockId, bool newItem)
        {
            sessionStateStoreBehavior.SetAndReleaseItem(context, id, item, lockId, newItem);
        }

        /// <summary>
        /// 移除项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="lockId"></param>
        /// <param name="item"></param>
        public override void RemoveItem(System.Web.HttpContext context, string id, object lockId, SessionStateStoreData item)
        {
            sessionStateStoreBehavior.RemoveItem(context, id, lockId);
        }
        
        /// <summary>
        /// 重设项的超时时间
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        public override void ResetItemTimeout(System.Web.HttpContext context, string id)
        {
            sessionStateStoreBehavior.ResetItemTimeout(context, id);
        }

        /// <summary>
        /// 结束请求
        /// </summary>
        /// <param name="context"></param>
        public override void EndRequest(System.Web.HttpContext context)
        {
            
        }

        /// <summary>
        /// 设置项过期回掉
        /// </summary>
        /// <param name="expireCallback"></param>
        /// <returns></returns>
        public override bool SetItemExpireCallback(SessionStateItemExpireCallback expireCallback)
        {
            return false;
        }

        /// <summary>
        /// 回收
        /// </summary>
        public override void Dispose()
        {
            
        }

    }
}
