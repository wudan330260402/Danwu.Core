
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;

namespace Infrastructure.Repository.MongoDB
{
    public class MongoRepositorySettings
    {
        public String Database {
            get { return ""; }
        }

        public MongoServerSettings ServerSettings
        {
            get {
                var settings = new MongoServerSettings();
                settings.Server = new MongoServerAddress("localhost");
                settings.WriteConcern = WriteConcern.Acknowledged;
                return settings;
            }
        }

        public List<TypeToCollectionName> MapTypeToCollectionName
        {
            get {
                return new List<TypeToCollectionName>(){
                    new TypeToCollectionName("Danwu.Domain.Model.User","UserDo"),
                    new TypeToCollectionName("Danwu.Domain.Model.Role","RoleDo"),
                    new TypeToCollectionName("Danwu.Domain.Model.UserRole","UserRoleDo"),
                    new TypeToCollectionName("Danwu.Domain.Model.Menu","MenuDo"),
                    new TypeToCollectionName("Danwu.Domain.Model.MenuRole","MenuRoleDo")
                };
            }
        }
    }

    public class TypeToCollectionName
    {
        public TypeToCollectionName(String typeName,String collectionName) {
            this.TypeName = typeName;
            this.CollectionName = collectionName;
        }

        public String TypeName { get; set; }
        public String CollectionName { get; set; }
    }
}
