using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.QueryObject
{
    public class Criterion
    {
        private string _propertyName;
        private object _value;
        private CriteriaOperator _criteriaOperator;

        public Criterion(string in_propertyName, object in_value, CriteriaOperator in_criteriaOperator)
        {
            this._propertyName = in_propertyName;
            this._value = in_value;
            this._criteriaOperator = in_criteriaOperator;
        }

        public String PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
        public Object Value
        {
            get { return _value; }
            set { this._value = value; }
        }
        public CriteriaOperator CriteriaOperator
        {
            get { return _criteriaOperator; }
            set { _criteriaOperator = value; }
        }
    }
}
