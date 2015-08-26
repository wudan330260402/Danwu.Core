using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;

namespace ManageSite.Models
{
    
    public class Result<T>
        where T : class,new()
    {
        public Int32 total { get; set; }
        public IList<T> rows { get; set; }
    }
}
