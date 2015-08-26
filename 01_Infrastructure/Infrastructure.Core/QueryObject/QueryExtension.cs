using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;


namespace Infrastructure.Core.QueryObject
{
    public static class QueryExtension
    {
        public static void Translate(this Query query,DbCommand dbCommand)
        {
            StringBuilder sqlQuery = new StringBuilder();
            
            foreach (Criterion c in query.Criteria) {
                if (sqlQuery.Length > 0)
                    sqlQuery.AppendFormat(" {0} ", GetQueryOperator(query.QueryOperator));

                sqlQuery.AppendFormat(" {0} {1} '{2}' ", c.PropertyName, GetCriteriaOperator(c.CriteriaOperator), c.Value);
            }

            if (query.OrderByProperty.OrderDirection == OrderDirection.Asc)
                sqlQuery.AppendFormat(" order by {0} ", query.OrderByProperty.PropertyName);
            else
                sqlQuery.AppendFormat(" order by {0} desc ", query.OrderByProperty.PropertyName);

            dbCommand.CommandText = sqlQuery.ToString();

        }

        private static String GetQueryOperator(QueryOperator queryOperator) {
            switch (queryOperator) { 
                case QueryOperator.And:
                    return " and ";
                case QueryOperator.Or:
                    return " or ";
            }
            return "";
        }

        private static String GetCriteriaOperator(CriteriaOperator criteriaOperator) {
            switch (criteriaOperator)
            { 
                case CriteriaOperator.Equal:
                    return " = ";
                case CriteriaOperator.LessThan:
                    return " < ";
                case CriteriaOperator.LessThanOrEqual:
                    return " <= ";
                case CriteriaOperator.Like:
                    return " like ";
                case CriteriaOperator.MoreThan:
                    return " > ";
                case CriteriaOperator.MoteThanOrEqual:
                    return ">=";
            }
            return "";
        }
    }
}
