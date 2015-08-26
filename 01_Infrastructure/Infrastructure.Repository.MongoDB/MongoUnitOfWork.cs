using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Configuration;

using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

using Infrastructure.Core;
using Infrastructure.Core.UnitOfWork;

namespace Infrastructure.Repository.MongoDB
{
    public class MongoUnitOfWork : UnitOfWork
    {
        private static MongoClient client;
        private static MongoServer server;
        private static MongoDatabase database;
        private static MongoRepositorySettings settings;
        private IDictionary<Type, MongoCollection> mongoCollections = new Dictionary<Type, MongoCollection>();
        
        static MongoUnitOfWork() {
            settings = new MongoRepositorySettings();
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["SysDB"].ConnectionString);
            client = new MongoClient(url);
            server = client.GetServer();
            database = server.GetDatabase(url.DatabaseName);
        }

        public MongoUnitOfWork()
        {

        }

        public override bool Commit()
        {
            bool result = false;
            try
            {
                if (_addEntities != null && _addEntities.Count > 0) {
                    foreach (IAggregateRoot entity in _addEntities.Keys) {
                        var collection = this.getCollectionForType(entity.GetType());
                        collection.Insert(entity);
                    }
                }
                if (_updateEntities != null && _updateEntities.Count > 0) {
                    foreach (IAggregateRoot entity in _updateEntities.Keys) {
                        var collection = this.getCollectionForType(entity.GetType());
                        collection.Save(entity);
                    }
                }

                if (_deleteEntities != null && _deleteEntities.Count > 0) {
                    foreach (IAggregateRoot entity in _deleteEntities.Keys) {
                        var collection = this.getCollectionForType(entity.GetType());
                        IMongoQuery query = Query.EQ("ID", entity.ID);
                        collection.Remove(query);
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                //重置
                _addEntities.Clear();
                _updateEntities.Clear();
                _deleteEntities.Clear();
            }

            return result;
        }

        public override void Rollback()
        {
            throw new NotImplementedException();
        }

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
