using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Extension
{
    public static class ExpressionFunExtension
    {
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var params1 = first.Parameters;
            var params2 = second.Parameters;
            var map = params1.Select((p, i) => new { p, s = params2[i] }).ToDictionary(p => p.s, p => p.p);
            var rightBody = ParameterRebinder.ReplaceParameters(map, second.Body);
            return Expression.Lambda<T>(merge(first.Body, rightBody), first.Parameters);
        }

        public static Expression<Func<T, Boolean>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, Boolean>> right) {
            return left.Compose(right, Expression.AndAlso);
        }

        public static Expression<Func<T, Boolean>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, Boolean>> right)
        {
            return left.Compose(right, Expression.OrElse);
        }


        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> express) {
            var expr = express.Parameters[0];
            var body = Expression.Not(express.Body);

            return Expression.Lambda<Func<T, bool>>(body, expr);
        } 
    }

    public class OperationsVisitor : ExpressionVisitor {
        
        public Expression Modify(Expression expression) {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Add) {
                Expression left = node.Left;
                Expression right = node.Right;
                return Expression.Subtract(left, right);
            }
            return base.VisitBinary(node);
        }
    }
}
