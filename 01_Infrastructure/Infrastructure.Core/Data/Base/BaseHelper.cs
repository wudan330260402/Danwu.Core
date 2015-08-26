using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Infrastructure.Core.Data.Base
{
    public abstract class BaseHelper
    {
        private ConnectionType _connType = ConnectionType.ConnKey;
        public virtual ConnectionType ConnType
        {
            get { return _connType; }
            set { _connType = value; }
        }

        private int _timeOut = 30;
        public virtual Int32 TimeOut
        {
            get { return _timeOut; }
            set { _timeOut = value; }
        }

        private string _connString = "ConnString";
        public virtual String ConnString
        {
            get { return _connString; }
            set { _connString = value; }
        }

        public BaseHelper()
        {

        }
        public BaseHelper(String connString)
        {
            this._connString = connString;
        }
        public BaseHelper(ConnectionType connType, String connString)
        {
            this._connType = connType;
            this._connString = connString;
        }

        protected abstract IDbCommand CreateCommand();
        protected abstract IDbConnection CreateConnection();
        protected abstract IDbDataAdapter CreateDataAdapter();
        public abstract IDbDataParameter CreateParameter();
        public abstract IDbDataParameter CreateParameter(string parameterName);
        public abstract IDbDataParameter CreateParameter(string parameterName, object value);

        public abstract Int32 ExecuteNonQuery(string cmdText, params IDbDataParameter[] cmdParameters);
        public abstract Int32 ExecuteNonQuery(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters);
        public abstract Int32 ExecuteNonQueryByTrans(string cmdText, params IDbDataParameter[] cmdParameters);

        public abstract IDataReader ExecuteReader(string cmdText, params IDbDataParameter[] cmdParameters);
        public abstract IDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters);

        public abstract Object ExecuteScalar(string cmdText, params IDbDataParameter[] cmdParameters);
        public abstract Object ExecuteScalar(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters);

        public abstract DataTable ExecuteDataTable(string cmdText, params IDbDataParameter[] cmdParameters);
        public abstract DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters);
        public abstract DataTable ExecuteDataTableByTrans(string cmd, params IDbDataParameter[] cmdParameters);

        public abstract DataSet ExecuteDataSet(string cmdText, params IDbDataParameter[] cmdParameters);
        public abstract DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters);
        public abstract DataSet ExecuteDataSetByTrans(string cmdText, params IDbDataParameter[] cmdParameters);
    }
}
