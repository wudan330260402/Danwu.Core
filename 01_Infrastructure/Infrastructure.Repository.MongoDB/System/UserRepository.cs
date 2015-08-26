using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.Repository;
using Infrastructure.Core.UnitOfWork;

using Danwu.Domain.Model;
using Danwu.Domain.Repository;

namespace Infrastructure.Repository.MongoDB
{
    public class UserRepository : MongoRepository<User>, IUserRepository
    {
        public UserRepository(IRepositoryContext context)
            : base(context)
        {

        }

        #region IUserRepository Members

        public User GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public bool UserNameExist(string userName)
        {
            throw new NotImplementedException();
        }

        public bool CheckPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
