using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Danwu.ServiceClient.System;
using Danwu.Application.DTO.System;

namespace Danwu.ServiceClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var userServiceClient = new UserServiceClient();
            var user = new UserDto()
            {
                UserName = "wudan",
                NickName = "坏坏男孩",
                RealName = "吴丹",
                PhoneNo = "18916765826",
                Email = "wudan1020@yahoo.cn",
                PassWord = "123456",
                RegisterTime = DateTime.Now,
                LastLogonTime = DateTime.Now
            };
            var result = userServiceClient.CreateUser(user);
        }
    }
}
