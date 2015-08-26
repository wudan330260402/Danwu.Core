using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.QueryObject
{
    public class Query
    {
        private IList<Criterion> _criteria;
        public IList<Criterion> Criteria
        {
            get { return _criteria; }
            set { _criteria = value; }
        }

        public QueryOperator QueryOperator { get; set; }
        public OrderByClause OrderByProperty { get; set; }

        public void Add(Criterion criteria)
        {
            this._criteria.Add(criteria);
        }

    }
}
