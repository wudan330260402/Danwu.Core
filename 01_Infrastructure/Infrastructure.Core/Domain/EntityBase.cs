using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.DomainModel
{
    public abstract class EntityBase<TId>
    {
        private IList<BusinessRule> _brokenRules = new List<BusinessRule>();

        public TId Id { get; set; }

        protected abstract void Validate();

        public IEnumerable<BusinessRule> GetBrokenRules() {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule businessRule) {
            _brokenRules.Add(businessRule);
        }

        public override bool Equals(object obj)
        {

            return base.Equals(obj);
        }

        /// <summary>
        /// 重写==运算符
        /// </summary>
        public static bool operator ==(EntityBase<TId> entityOne, EntityBase<TId> entityTwo) {
            if (entityOne == null && entityTwo == null) return true;
            if (entityOne == null || entityTwo == null) return false;
            return entityOne.Id.ToString() == entityTwo.Id.ToString();
        }

        /// <summary>
        /// 重写!=运算符
        /// </summary>
        public static bool operator !=(EntityBase<TId> entityOne, EntityBase<TId> entityTwo) {
            return entityOne == entityTwo ? false : true;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
