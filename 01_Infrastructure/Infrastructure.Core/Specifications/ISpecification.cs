using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Infrastructure.Core.Specifications
{
    /// <summary>
    /// 规约接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        Boolean IsSatisfiedBy(T item);

        Expression<Func<T, bool>> GetExpression();
    }

    /// <summary>
    /// 抽象实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Specification<T> : ISpecification<T> {

        public bool IsSatisfiedBy(T item)
        {
            return this.GetExpression().Compile()(item);
        }

        public abstract Expression<Func<T, bool>> GetExpression();
    }
}
