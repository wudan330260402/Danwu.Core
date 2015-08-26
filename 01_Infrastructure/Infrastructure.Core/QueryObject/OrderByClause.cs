using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.QueryObject
{
    public class OrderByClause
    {
        public String PropertyName { get; set; }
        public OrderDirection OrderDirection { get; set; }
    }

    public enum OrderDirection
    { 
        Asc,
        Desc
    }
}
