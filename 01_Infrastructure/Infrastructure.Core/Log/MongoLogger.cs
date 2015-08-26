using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

using Infrastructure.Core.Log.Model;
using System.Configuration;

namespace Infrastructure.Core.Log
{
    internal class MongoLogger : ILogger
    {
        MongoCollection<MongoDBLogDo> collection;

        public MongoLogger() {
            var mongoUrl = new MongoUrl(ConfigurationManager.ConnectionStrings["LogDB"].ConnectionString);
            var client = new MongoClient(mongoUrl);
            var database = client.GetServer().GetDatabase(mongoUrl.DatabaseName);

            collection = database.GetCollection<MongoDBLogDo>("Log", WriteConcern.Unacknowledged);
        }

        public void WriteInfo(string title, string message)
        {
            MongoDBLogDo logDo = new MongoDBLogDo()
            {
                LogTitle = title,
                LogLevel = LogLevelType.Info,
                Content = message,
                CreateTime = DateTime.Now
            };

            WriteLog(logDo);
        }

        public void WriteDebug(string title, string message)
        {
            MongoDBLogDo logDo = new MongoDBLogDo()
            {
                LogTitle = title,
                LogLevel = LogLevelType.Debug,
                Content = message,
                CreateTime = DateTime.Now
            };

            WriteLog(logDo);
        }

        public void WriteError(string title, string message)
        {
            MongoDBLogDo logDo = new MongoDBLogDo()
            {
                LogTitle = title,
                LogLevel = LogLevelType.Debug,
                Content = message,
                CreateTime = DateTime.Now
            };

            WriteLog(logDo);
        }

        public void WriteException(string title, Exception ex)
        {
            MongoDBLogDo logDo = new MongoDBLogDo()
            {
                LogTitle = title,
                LogLevel = LogLevelType.Debug,
                Content = ex.Message,
                CreateTime = DateTime.Now
            };

            WriteLog(logDo);
        }

        #region Private Methods

        private void WriteLog(MongoDBLogDo logDo) {

            logDo.CreateTime = DateTime.Now;

            collection.Save(logDo);

        }

        #endregion

    }
}
