using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.SessionState;
using System.IO;

using Enyim.Caching;
using Enyim.Caching.Memcached;

using Danwu.Session.Model;
using System.Web.Hosting;

namespace Danwu.Session
{
    /// <summary>
    /// 基于Memcached的Session状态存储行为
    /// </summary>
    public class MemcachedSessionStateBehavior : ISessionStateStoreBehavior
    {
        #region Fields

        private IMemcachedClient client;
        SessionStateSection sessionStateSection;

        #endregion

        #region Ctors

        public MemcachedSessionStateBehavior() {
            initData();
        }

        void initData()
        {
            client = new MemcachedClient();

            System.Configuration.Configuration cfg = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);
            sessionStateSection = (SessionStateSection)cfg.GetSection("system.web/sessionState");
        }

        #endregion

        public void CreateUninitializedItem(System.Web.HttpContext context, string id, int timeout)
        {
            var session = new MemcachedSessionDo()
            {
                ApplicationName = "",
                Locked = false,
                LockId = 0,
                LockDate = DateTime.Now,
                Created = DateTime.Now,
                Flags = 1
            };
            client.Store(StoreMode.Set, id, session, DateTime.Now.AddMinutes(sessionStateSection.Timeout.TotalMinutes));
        }

        public System.Web.SessionState.SessionStateStoreData GetItem(bool lockRecord, System.Web.HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out System.Web.SessionState.SessionStateActions actions)
        {
            return GetSessionStoreItem(lockRecord, context, id, out locked, out lockAge, out lockId, out actions);
        }

        public void ReleaseItem(System.Web.HttpContext context, string id, object lockId)
        {
            var session = client.Get<MemcachedSessionDo>(id);
            if (session != null) {
                session.Locked = false;
                client.Store(StoreMode.Set, id, session, DateTime.Now.AddMinutes(sessionStateSection.Timeout.TotalMinutes));
            }
        }

        public void RemoveItem(System.Web.HttpContext context, string id, object lockId)
        {
            client.Remove(id);
        }

        public void ResetItemTimeout(System.Web.HttpContext context, string id)
        {
            var session = client.Get<MemcachedSessionDo>(id);
            if (session != null)
            {
                client.Store(StoreMode.Set, id, session, DateTime.Now.AddMinutes(sessionStateSection.Timeout.TotalMinutes));
            }
        }

        public void SetAndReleaseItem(System.Web.HttpContext context, string id, System.Web.SessionState.SessionStateStoreData item, object lockId, bool newItem)
        {
            MemcachedSessionDo session;
            if (newItem)
            {
                session = new MemcachedSessionDo()
                {
                    Created = DateTime.Now,
                    ApplicationName = "",
                    Locked = false,
                    LockId = 0,
                    Flags = (Int32)SessionStateActions.None,
                    LockDate = DateTime.Now,
                    SessionItem = Serialize((SessionStateItemCollection)item.Items),
                };
                client.Store(StoreMode.Set, id, session, DateTime.Now.AddMinutes(sessionStateSection.Timeout.TotalMinutes));
            }
            else {
                session = client.Get<MemcachedSessionDo>(id);
                if (session != null) {
                    session.Locked = false;
                    session.SessionItem = Serialize((SessionStateItemCollection)item.Items);
                    client.Store(StoreMode.Set, id, session, DateTime.Now.AddMinutes(sessionStateSection.Timeout.TotalMinutes));
                }
            }
        }

        #region Private Methods

        SessionStateStoreData GetSessionStoreItem(bool lockRecord, System.Web.HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
        {
            SessionStateStoreData item = default(SessionStateStoreData);
            locked = false;
            lockId = null;
            lockAge = TimeSpan.Zero;
            actions = 0;

            bool foundRecord = false;       //是否找到会话记录
            bool deleteData = false;        //是否删除数据（如果已过期，则删除）

            var session = client.Get<MemcachedSessionDo>(id);
            // lockRecord is true when called from GetItemExclusive and
            // false when called from GetItem.
            // Obtain a lock if possible. Ignore the record if it is expired.
            if (lockRecord)
            {
                //如果会话存在
                if (session != null && session.Locked == false)
                {
                    session.Locked = true;
                    session.LockDate = DateTime.Now;
                    client.Store(StoreMode.Set, id, session, DateTime.Now.AddMinutes(sessionStateSection.Timeout.TotalMinutes));
                    locked = false;
                }
                else
                {
                    locked = true;
                }
            }

            if (session != null) foundRecord = true;
            if (!foundRecord) locked = false;

            if (foundRecord && !locked) {
                lockId = lockId == null ? 0 : (Int32)lockId + 1;
                //更新值
                session.LockId = (Int32)lockId;
                session.Flags = (Int32)SessionStateActions.None;
                client.Store(StoreMode.Set, id, session);

                if (actions == SessionStateActions.InitializeItem)
                {
                    item = new SessionStateStoreData(new SessionStateItemCollection(), SessionStateUtility.GetSessionStaticObjects(context), (Int32)sessionStateSection.Timeout.TotalMinutes);
                }
                else item = Deserialize(context, session.SessionItem, (Int32)sessionStateSection.Timeout.TotalMinutes);
            }

            return null;
        }

        String Serialize(SessionStateItemCollection sessionItems)
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);
            if (sessionItems != null) sessionItems.Serialize(writer);

            writer.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        SessionStateStoreData Deserialize(System.Web.HttpContext context, String serializedItems, Int32 timeout)
        {

            MemoryStream ms = new MemoryStream(Convert.FromBase64String(serializedItems));

            SessionStateItemCollection sessionItems = new SessionStateItemCollection();

            if (ms.Length > 0)
            {
                BinaryReader reader = new BinaryReader(ms);
                sessionItems = SessionStateItemCollection.Deserialize(reader);
            }

            return new SessionStateStoreData(sessionItems, SessionStateUtility.GetSessionStaticObjects(context), timeout);

        }


        #endregion

    }
}
