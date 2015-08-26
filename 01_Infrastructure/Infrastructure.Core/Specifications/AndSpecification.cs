using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core.Extension;

namespace Infrastructure.Core.Specifications
{

    public class AndSpecification<T> : CompositeSpecification<T>
    {

        public AndSpecification(ISpecification<T> left, ISpecification<T> right) :
            base(left, right)
        {

        }
        
        public override Expression<Func<T, bool>> GetExpression()
        {
            return this.Left.GetExpression().And(this.Right.GetExpression());
        }
    }

    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
            : base(left, right)
        {

        }

        public override Expression<Func<T, bool>> GetExpression()
        {
            return this.Left.GetExpression().Or(this.Right.GetExpression());
        }
    }

    public class NotSpecification<T> : Specification<T>
    {
        private ISpecification<T> _wrapped;

        public NotSpecification(ISpecification<T> wrapped)
        {
            this._wrapped = wrapped;
        }

        public override Expression<Func<T, bool>> GetExpression()
        {
            return _wrapped.GetExpression().Not();
        }
    }
    
}
