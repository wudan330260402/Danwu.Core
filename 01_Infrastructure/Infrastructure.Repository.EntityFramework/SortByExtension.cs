using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Infrastructure.Core;
using Infrastructure.Core.Repository;

namespace Infrastructure.Repository.EntityFramework
{
    internal static class SortByExtension
    {
        internal static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, Expression<Func<T, dynamic>> sortPredicate)
            where T : class, IAggregateRoot
        {
            return InvokeSortBy<T>(query, sortPredicate, SortOrder.Ascending);
        }
        internal static IOrderedQueryable<T> SortByDescending<T>(this IQueryable<T> query, Expression<Func<T, dynamic>> sortPredicate)
            where T : class, IAggregateRoot
        {
            return InvokeSortBy<T>(query, sortPredicate, SortOrder.Descending);
        }

        private static IOrderedQueryable<T> InvokeSortBy<T>(this IQueryable<T> query, Expression<Func<T, dynamic>> sortPredicate, SortOrder sortOrder)
            where T : class,IAggregateRoot
        {
            return null;
        }
    }
}
