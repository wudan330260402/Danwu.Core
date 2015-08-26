using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Infrastructure.Core.Extension
{
    public static class LambdaExtension
    {
        /// <summary>
        /// 获取表达式的值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static Object GetValue(this Expression expression) {
            if (expression == null) return null;
            switch (expression.NodeType) { 
                case ExpressionType.Lambda:
                    return GetValue(((LambdaExpression)expression).Body);
                case ExpressionType.Convert:
                    return GetValue(((UnaryExpression)expression).Operand);
                case ExpressionType.Constant:
                    return GetConstantValue(expression);
                case ExpressionType.MemberAccess:
                    return GetMemberValue((MemberExpression)expression);
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                    return GetValue(((BinaryExpression)expression).Right);
            }
            return null;
        }

        /// <summary>
        /// 获取谓词条件的个数
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static Int32 GetCriteriaCount(this Expression expression)
        {
            if (expression == null) return 0;
            var result = expression.ToString().Replace("AndAlso", "|").Replace("OrElse", "|");
            return result.Split('|').Count();
        }

        #region Private Methods

        /// <summary>
        /// 获取二元表达式
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static BinaryExpression GetBinaryExpression(LambdaExpression expression) {
            var binaryExpression = expression.Body as BinaryExpression;
            if (binaryExpression != null) return binaryExpression;
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression == null) return null;
            return unaryExpression.Operand as BinaryExpression;
        }

        /// <summary>
        /// 获取二元表达式的值
        /// 例：t => t.Name == "A",返回 A
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static Object GetBinaryValue(BinaryExpression expression)
        {
            var unaryExpression = expression.Right as UnaryExpression;
            if (unaryExpression != null) return GetConstantValue(unaryExpression.Operand);
            return GetConstantValue(expression.Right);
        }

        /// <summary>
        /// 获取常量表达式的值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static Object GetConstantValue(Expression expression) {
            var constantExpress = expression as ConstantExpression;
            if (constantExpress != null) return constantExpress.Value;
            return null;
        }

        /// <summary>
        /// 获取属性表达式的值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static Object GetMemberValue(MemberExpression expression) {
            if (expression == null) return null;
            var field = expression.Member as FieldInfo;
            if (field != null) {
                var constValue = GetConstantValue(expression.Expression);
                return field.GetValue(constValue);
            }
            var property = expression.Member as PropertyInfo;
            if (property != null) {
                var value = GetMemberValue(expression.Expression as MemberExpression);
                return property.GetValue(value);
            }
            return null;
        }

        #endregion

    }
}
