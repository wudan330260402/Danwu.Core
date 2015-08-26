using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Infrastructure.Core.Specifications;
using Infrastructure.Core.Repository;
using Infrastructure.Repository.EntityFramework;
using Danwu.Domain.Repository;
using Danwu.Domain.Model;

namespace Infrastructure.Repository.EntityFramework.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dbContext = new DanwuDbContext();
            var context = new EntityFrameworkRepositoryContext();
            var unitOfWork = new EntityFrameworkUnitOfWork(dbContext);
            IUserRepository userRepository = new UserRepository(context);
            userRepository.Create(new User()
            {
                UserName = "wudan",
                NickName = "坏坏男孩",
                RealName = "吴丹",
                PhoneNum = "18916765826",
                Email = "wudan1020@yahoo.cn",
                Status = UserStatus.Enabled,
                PassWord = "123456",
                RegisterTime = DateTime.Now,
                LastLogonTime = DateTime.Now
            });
            userRepository.Create(new User()
            {
                UserName = "wudan1",
                NickName = "坏坏男孩1",
                RealName = "吴丹1",
                PhoneNum = "18916765000",
                Email = "wudan1020@aliyun.com",
                Status = UserStatus.Disabled,
                PassWord = "123456",
                RegisterTime = DateTime.Now,
                LastLogonTime = DateTime.Now
            });

            var result = context.Commit();
            //var result = unitOfWork.Commit();
        }

        [TestMethod]
        public void TestMethod2() {
            var dbContext = new DanwuDbContext();
            var context = new EntityFrameworkRepositoryContext();
            var unitOfWork = new EntityFrameworkUnitOfWork(dbContext);
            IUserRepository userRepository = new UserRepository(context);
            var users = userRepository.QueryAll();

            //users=userRepository.QueryBy(
        }
    }
}
