using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageSite.Models
{
    public class UserViewModel
    {
        public long ID { get; set; }
        public String UserName { get; set; }
        public String NickName { get; set; }
        public String RealName { get; set; }
        public String PassWord { get; set; }
        public Int32 State { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastLogonTime { get; set; }
        public String LastLogonIP { get; set; }
        //Add=新增,Edit=编辑
        public String Mode { get; set; }
    }
}