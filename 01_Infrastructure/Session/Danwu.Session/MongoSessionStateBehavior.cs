using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web.Configuration;
using System.IO;

using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

using Danwu.Session.Model;
using System.Web.Hosting;


namespace Danwu.Session
{
    /// <summary>
    /// 基于MongoDB的Session状态存储行为
    /// </summary>
    public class MongoSessionStateBehavior : ISessionStateStoreBehavior
    {
        #region Fields

        SessionProviderSettings _providerSettings;
        static MongoCollection<MongoDBSessionDo> collection;
        static SessionStateSection sessionStateSection;
        static HttpCookiesSection httpCookieSection;

        #endregion

        #region Ctors

        public MongoSessionStateBehavior() {
            initData();
        }

        void initData() {
            _providerSettings = SessionProviderSettings.GetSettings();

            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["SessionDB"].ConnectionString);
            var client = new MongoClient(url);
            var database = client.GetServer().GetDatabase(url.DatabaseName);
            collection = database.GetCollection<MongoDBSessionDo>(_providerSettings.SessionProfix, WriteConcern.Unacknowledged);

            System.Configuration.Configuration cfg = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);
            sessionStateSection = (SessionStateSection)cfg.GetSection("system.web/sessionState");
        }

        #endregion

        /// <summary>
        /// 创建未初始化的项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="timeout"></param>
        public void CreateUninitializedItem(System.Web.HttpContext context, string id, int timeout)
        {
            var session = new MongoDBSessionDo()
            {
                ApplicationName = "",
                SessionId = id,
                Created = DateTime.Now,
                Expired = DateTime.Now.AddMinutes(sessionStateSection.Timeout.TotalMinutes),
                LockDate = DateTime.Now,
                LockId = 0,
                Locked = false,
                Flags = (Int32)SessionStateActions.InitializeItem,
                TimeOut = timeout
            };
            collection.Save(session);
        }

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
        public SessionStateStoreData GetItem(bool lockRecord, System.Web.HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions)
        {
            return GetSessionStoreItem(lockRecord, context, id, out locked, out lockAge, out lockId, out actions);
        }

        /// <summary>
        /// 释放项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="lockId"></param>
        public void ReleaseItem(System.Web.HttpContext context, string id, object lockId)
        {
            var query = Query.And(Query.EQ("_id", id), Query.EQ("LockId", (Int32)lockId));
            var session = collection.FindOne(query);
            if (session != null) {
                var update = Update.Set("Expired", DateTime.Now.AddMinutes(sessionStateSection.Timeout.TotalMinutes))
                                   .Set("Locked", false);
                collection.Update(query, update);
            }
        }

        /// <summary>
        /// 移除项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="lockId"></param>
        public void RemoveItem(System.Web.HttpContext context, string id, object lockId)
        {
            collection.Remove(Query.And(Query.EQ("_id", id), Query.EQ("LockId", (Int32)lockId)));
        }

        /// <summary>
        /// 重设项超时时间
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        public void ResetItemTimeout(System.Web.HttpContext context, string id)
        {
            var query = Query.EQ("_id", id);
            var session = collection.FindOne(query);
            if (session != null)
            {
                var update = Update.Set("Expired", DateTime.Now.AddMinutes(sessionStateSection.Timeout.TotalMinutes));

                collection.Update(query, update);
            }
        }

        /// <summary>
        /// 设置并释放项
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <param name="lockId"></param>
        /// <param name="newItem"></param>
        public void SetAndReleaseItem(System.Web.HttpContext context, string id, SessionStateStoreData item, object lockId, bool newItem)
        {
            MongoDBSessionDo session;
            if (newItem)
            {
                //删除过期的会话信息
                collection.Remove(Query.And(Query.EQ("_id", id), Query.LT("Expired", DateTime.Now)));

                //插入新的会话信息
                session = new MongoDBSessionDo()
                {
                    SessionId = id,
                    Created = DateTime.Now,
                    Expired = DateTime.Now.AddMinutes(sessionStateSection.Timeout.TotalMinutes),
                    LockDate = DateTime.Now,
                    LockId = 0,
                    Locked = false,
                    TimeOut = item.Timeout,
                    SessionItem = Serialize((SessionStateItemCollection)item.Items),
                    Flags = (Int32)SessionStateActions.None
                };
                collection.Save(session);
            }
            else { 
                //更新会话信息
                var query = Query.And(Query.EQ("_id", id), Query.EQ("LockId", (Int32)lockId));
                session = collection.FindOne(query);
                session.Expired = DateTime.Now.AddMinutes(item.Timeout);
                session.SessionItem = Serialize((SessionStateItemCollection)item.Items);
                session.Locked = false;
                var update = Update.Set("Expired", DateTime.Now.AddMinutes(item.Timeout))
                                   .Set("SessionItem", Serialize((SessionStateItemCollection)item.Items))
                                   .Set("Locked", false);
                
                collection.Update(query, update);
            }
        }

        #region Private Methods

        /// <summary>
        /// 从MongoDB中获取会话信息
        /// </summary>
        /// <param name="lockRecord"></param>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="locked"></param>
        /// <param name="lockAge"></param>
        /// <param name="lockId"></param>
        /// <param name="actions"></param>
        /// <returns></returns>
        SessionStateStoreData GetSessionStoreItem(bool lockRecord, System.Web.HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actions) {
            SessionStateStoreData item = default(SessionStateStoreData);
            locked = false;
            lockAge = TimeSpan.Zero;
            lockId = null;
            actions = 0;

            bool foundRecord = false;       //是否找到会话记录
            bool deleteData = false;        //是否删除数据（如果已过期，则删除）

            // lockRecord is true when called from GetItemExclusive and
            // false when called from GetItem.
            // Obtain a lock if possible. Ignore the record if it is expired.
            var session = collection.AsQueryable<MongoDBSessionDo>().FirstOrDefault(t => t.SessionId == id);
            if (lockRecord) {
                //如果会话存在、没有过期而且没有被锁
                if (session != null && session.Expired >= DateTime.Now && session.Locked == false)
                {
                    //先锁住对象
                    collection.Update(Query.EQ("_id", id), Update.Set("Locked", true).Set("LockDate", DateTime.Now));
                    locked = false;
                }
                else {
                    //已被锁
                    locked = true;
                }
            }

            if (session != null) {
                if (session.Expired < DateTime.Now)
                {
                    locked = false;
                    deleteData = true;
                }
                else {
                    foundRecord = true;
                }
            }
            if (deleteData) {
                //已过期的会话数据，删除
                collection.Remove(Query.EQ("_id", id));
            }
            if (!foundRecord) locked = false;

            //如果存在会话而且没有被其他锁定
            if (foundRecord && !locked) {
                lockId = lockId == null ? 0 : (int)lockId + 1;
                //更新LockId
                collection.Update(Query.EQ("_id", id), Update.Set("LockId", (Int32)lockId).Set("Flags", (Int32)SessionStateActions.None));

                if (actions == SessionStateActions.InitializeItem)
                {
                    item = new SessionStateStoreData(new SessionStateItemCollection(), SessionStateUtility.GetSessionStaticObjects(context), (Int32)sessionStateSection.Timeout.TotalMinutes);
                }
                else item = Deserialize(context, session.SessionItem, session.TimeOut);
            }

            return item;
        }

        String Serialize(SessionStateItemCollection sessionItems) {
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);
            if (sessionItems != null) sessionItems.Serialize(writer);

            writer.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        SessionStateStoreData Deserialize(System.Web.HttpContext context, String serializedItems, Int32 timeout) {

            MemoryStream ms = new MemoryStream(Convert.FromBase64String(serializedItems));

            SessionStateItemCollection sessionItems = new SessionStateItemCollection();

            if (ms.Length > 0) {
                BinaryReader reader = new BinaryReader(ms);
                sessionItems = SessionStateItemCollection.Deserialize(reader);
            }

            return new SessionStateStoreData(sessionItems, SessionStateUtility.GetSessionStaticObjects(context), timeout);

        }


        #endregion

    }
}
