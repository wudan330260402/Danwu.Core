using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Infrastructure.Core.Data.Base
{
    public interface IBaseInterface
    {
        IDbCommand CreateCommand();
        IDbConnection CreateConnection();
        IDbDataAdapter CreateDataAdapter();
        IDbDataParameter CreateParameter();
        IDbDataParameter CreateParameter(string parameterName);
        IDbDataParameter CreateParameter(string parameterName, object value);

        Int32 ExecuteNonQuery(string cmdText, params IDbDataParameter[] cmdParameters);
        Int32 ExecuteNonQuery(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters);
        Int32 ExecuteNonQueryByTrans(string cmdText, params IDbDataParameter[] cmdParameters);

        IDataReader ExecuteReader(string cmdText, params IDbDataParameter[] cmdParameters);
        IDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters);

        Object ExecuteScalar(string cmdText, params IDbDataParameter[] cmdParameters);
        Object ExecuteScalar(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters);

        DataTable ExecuteDataTable(string cmdText, params IDbDataParameter[] cmdParameters);
        DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters);
        DataTable ExecuteDataTableByTrans(string cmd, params IDbDataParameter[] cmdParameters);

        DataSet ExecuteDataSet(string cmdText, params IDbDataParameter[] cmdParameters);
        DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters);
        DataSet ExecuteDataSetByTrans(string cmdText, params IDbDataParameter[] cmdParameters);
    }
}
