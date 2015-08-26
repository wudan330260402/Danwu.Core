using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.DomainModel
{
    public class BusinessRule
    {
        private string _property;
        private string _rule;

        public BusinessRule(string in_property, string in_rule) {
            this._property = in_property;
            this._rule = in_rule;
        }

        public String Property {
            get { return _property; }
            set { _property = value; }
        }

        public String Rule {
            get { return _rule; }
            set { _rule = value; }
        }
    }
}
