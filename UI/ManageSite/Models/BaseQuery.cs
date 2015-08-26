using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageSite.Models
{
    public class BaseQuery
    {
        public Int32 page { get; set; }
        public Int32 rows { get; set; }
    }
}