using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.Exceptions;

namespace Infrastructure.Core.DomainModel
{
    public abstract class ValueObjectBase
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        public ValueObjectBase()
        { }

        protected abstract void Validate();

        protected void AddBrokenRule(BusinessRule businessRule) {
            _brokenRules.Add(businessRule);
        }

        public void ThrowExceptionIfInvalid() {
            _brokenRules.Clear();
            Validate();
            if (_brokenRules.Count > 0) {
                StringBuilder msgBuilder = new StringBuilder();
                foreach (BusinessRule rule in _brokenRules) {
                    msgBuilder.AppendLine(rule.Rule);
                }

                throw new ValueObjectInvalidException(msgBuilder.ToString());
            }
        }
    }
}
