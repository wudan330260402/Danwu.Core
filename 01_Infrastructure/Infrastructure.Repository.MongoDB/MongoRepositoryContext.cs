using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

using Infrastructure.Core.Extension;
using Infrastructure.Core.Repository;

namespace Infrastructure.Repository.MongoDB
{
    public class MongoRepositoryContext : RepositoryContext
    {
        private static MongoClient client;
        private static MongoServer server;
        private static MongoDatabase database;
        private static MongoRepositorySettings settings;
        private IDictionary<Type, MongoCollection> mongoCollections = new Dictionary<Type, MongoCollection>();

        static MongoRepositoryContext() {
            settings = new MongoRepositorySettings();
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["SysDB"].ConnectionString);
            client = new MongoClient(url);
            server = client.GetServer();
            database = server.GetDatabase(url.DatabaseName);
        }

        #region RepositoryContext Members

        public override bool Commit()
        {
            Boolean result = false;

            try
            {
                if (!this.Committed) {
                    if (this.NewCollection != null && this.NewCollection.Any()) {
                        this.NewCollection.ForEach(entity =>
                        {
                            var collection = this.getCollectionForType(entity.GetType());
                            collection.Insert(entity);
                        });
                    }
                    if (this.ModifiedCollection != null && this.ModifiedCollection.Any()) {
                        this.ModifiedCollection.ForEach(entity =>
                        {
                            var collection = this.getCollectionForType(entity.GetType());
                            collection.Save(entity);
                        });
                    }
                    if (this.DeletedCollection != null && this.DeletedCollection.Any()) {
                        this.DeletedCollection.ForEach(entity =>
                        {
                            var collection = this.getCollectionForType(entity.GetType());
                            IMongoQuery query = Query.EQ("ID", entity.Key);
                            collection.Remove(query);
                        });
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally { 
                
            }
            return result;
        }

        public override void Rollback()
        {
            this.Committed = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (!this.Committed) this.Commit();
                this.Committed = true;
                base.Dispose();
            }
        }

        #endregion

        private MongoCollection getCollectionForType(Type type)
        {
            if (mongoCollections.ContainsKey(type))
            {
                return mongoCollections[type];
            }
            var mapType = settings.MapTypeToCollectionName.FirstOrDefault(c => c.TypeName == type.FullName);
            if (mapType == null) throw new Exception("mongo类型映射异常");

            var collection = database.GetCollection(mapType.CollectionName);
            mongoCollections.Add(type, collection);

            return mongoCollections[type];
        }

    }
}
