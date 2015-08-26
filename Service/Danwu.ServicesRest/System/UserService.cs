using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;

using Infrastructure.Core.IOC;
using Danwu.Application.DTO.System;
using Danwu.ServiceContract.System;

namespace Danwu.ServicesRest.System
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class UserService : IUserService
    {
        private IUserService userServiceImpl = ServiceLocator.Instance.Resolve<IUserService>();

        [WebInvoke(UriTemplate = "AddUser", Method = "POST")]
        public bool CreateUser(UserDto userDto)
        {
            return userServiceImpl.CreateUser(userDto);
        }

        [WebInvoke(UriTemplate = "ModifyUser", Method = "POST")]
        public bool UpdateUser(UserDto userDto)
        {
            return userServiceImpl.UpdateUser(userDto);
        }

        [WebInvoke(UriTemplate = "DeleteUser", Method = "POST")]
        public bool DeleteUser(string userId)
        {
            return userServiceImpl.DeleteUser(userId);
        }

        [WebInvoke(UriTemplate = "GetUser", Method = "POST")]
        public UserDto GetUser(string userId)
        {
            return userServiceImpl.GetUser(userId);
        }

        [WebInvoke(UriTemplate = "QueryAll", Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        public IEnumerable<UserDto> QueryAll()
        {
            //如果没有查到数据，则将返回状态设置为404NotFound
            //WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            //return null;
            return new List<UserDto>(){
                new UserDto(){
                    UserName = "wudan",
                    NickName = "坏坏男孩",
                    RealName = "吴丹",
                    PhoneNo = "18916765826",
                    Email = "wudan1020@yahoo.cn",
                    PassWord = "123456",
                    RegisterTime = DateTime.Now,
                    LastLogonTime = DateTime.Now
                }
            };
            return userServiceImpl.QueryAll();
        }

    }
}
