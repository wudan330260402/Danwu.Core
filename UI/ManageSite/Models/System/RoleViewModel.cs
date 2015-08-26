using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageSite.Models
{
    public class RoleViewModel
    {
        public long ID { get; set; }
        public String RoleCode { get; set; }
        public String RoleName { get; set; }
        public String State { get; set; }
        public String CreateTime { get; set; }
        public IList<RoleViewModel> children { get; set; }
    }
}