using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace Danwu.Mongo
{
    public class AggregateRootCollection<T> where T : class
    {
        private MongoDatabase database;
        private MongoCollection<T> collection;

        public AggregateRootCollection()
        {
            var mongoUrl = new MongoUrl("");
            var mongoClient = new MongoClient(mongoUrl);
            var server = mongoClient.GetServer();
            database = server.GetDatabase(mongoUrl.DatabaseName);
            collection = database.GetCollection<T>(typeof(T).Name);
        }

        #region Command Methods

        public T GetById(Object id) { 
            return collection.FindOne(Query.EQ("",BsonValue.Create(id)));
        }

        public void Add(T obj)
        {
            collection.Insert(obj);
        }

        public void Update(T obj)
        {
            collection.Save(obj);
        }

        public void Remove(T obj) { 
            collection.Remove(Query.EQ("_id",BsonValue.Create(((dynamic)obj).Id)));
        }

        public void RemoveAll(Expression<T> expression) { 
            
        }

        #endregion

        #region Query Methods

        public T First() {
            var obj = collection.AsQueryable<T>().First();
            return obj;
        }

        public T FirstOrDefault() {
            var obj = collection.AsQueryable<T>().FirstOrDefault();
            return obj;
        }


        #endregion

        #region Private Methods


        #endregion

    }
}
