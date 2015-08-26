using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Test.aop
{
    public interface IUserProcessor
    {
        void RegUser(User user);
    }

    public class User{
        public String Name { get; set; }
        public String PassWord { get; set; }
    }
}
