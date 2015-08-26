using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Specifications
{
    public interface ICompositeSpecification<T> : ISpecification<T>
    {
        ISpecification<T> And(ISpecification<T> other);
        ISpecification<T> Or(ISpecification<T> other);
        ISpecification<T> Not();
    }

    public abstract class CompositeSpecification<T> : Specification<T>, ICompositeSpecification<T>
    {

        #region Private Fields

        private readonly ISpecification<T> left;
        private readonly ISpecification<T> right;

        #endregion

        public CompositeSpecification(ISpecification<T> left, ISpecification<T> right) {
            this.left = left;
            this.right = right;
        }

        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        #region Members

        public virtual ISpecification<T> Left {
            get { return this.left; }
        }

        public virtual ISpecification<T> Right {
            get { return this.right; }
        }

        #endregion

    }
}
