using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


using Infrastructure.Core.Data.Base;
using Infrastructure.Core.Config;

namespace Infrastructure.Core.Data
{
    public class SqlHelper : BaseHelper
    {

        #region Constructors

        public SqlHelper()
            : base()
        { }
        public SqlHelper(String connString)
            : base(connString)
        { }
        public SqlHelper(ConnectionType connType, String connString)
            : base(connType, connString)
        { }

        #endregion

        #region BaseHelper 成员

        protected override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }
        protected override IDbConnection CreateConnection()
        {
            IDbConnection conn = new SqlConnection();

            if (base.ConnType == ConnectionType.ConnStr)
                conn.ConnectionString = base.ConnString;
            else
                conn.ConnectionString = AppConfig.GetValue(base.ConnString);

            return conn;
        }
        protected override IDbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }
        public override IDbDataParameter CreateParameter()
        {
            return new SqlParameter();
        }
        public override IDbDataParameter CreateParameter(string parameterName)
        {
            IDbDataParameter cmdParameter = CreateParameter();
            cmdParameter.ParameterName = parameterName;
            return cmdParameter;
        }
        public override IDbDataParameter CreateParameter(string parameterName, object value)
        {
            IDbDataParameter cmdParameter = CreateParameter();
            cmdParameter.ParameterName = parameterName;
            cmdParameter.Value = value;
            return cmdParameter;
        }

        public override int ExecuteNonQuery(string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                PreCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParameters);
                Int32 val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }

        }
        public override int ExecuteNonQuery(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                PreCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
                Int32 val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        public override int ExecuteNonQueryByTrans(string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                using (IDbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        PreCommand(cmd, conn, trans, CommandType.Text, cmdText, cmdParameters);
                        Int32 val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        trans.Commit();
                        return val;
                    }
                    catch (SqlException ex)
                    {
                        trans.Rollback();
                    }
                    return 0;
                }
            }
        }

        public override IDataReader ExecuteReader(string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                PreCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParameters);
                IDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return reader;
            }
        }
        public override IDataReader ExecuteReader(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                PreCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParameters);
                IDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return reader;
            }
        }

        public override Object ExecuteScalar(string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                PreCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParameters);
                object obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return obj;
            }
        }
        public override Object ExecuteScalar(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                PreCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
                object obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return obj;
            }
        }

        public override DataTable ExecuteDataTable(string cmdText, params IDbDataParameter[] cmdParameters)
        {
            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                IDbDataAdapter da = CreateDataAdapter();
                PreCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParameters);
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds.Tables[0];
            }
        }
        public override DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                IDbDataAdapter da = CreateDataAdapter();
                PreCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds.Tables[0];
            }
        }
        public override DataTable ExecuteDataTableByTrans(string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                using (IDbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        IDbDataAdapter da = CreateDataAdapter();
                        PreCommand(cmd, conn, trans, CommandType.Text, cmdText, cmdParameters);
                        DataSet ds = new DataSet();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        cmd.Parameters.Clear();
                        trans.Commit();
                        return ds.Tables[0];
                    }
                    catch (SqlException ex)
                    {
                        trans.Rollback();
                    }
                    return null;
                }
            }
        }

        public override DataSet ExecuteDataSet(string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                IDbDataAdapter da = CreateDataAdapter();
                PreCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParameters);
                DataSet ds = new DataSet();

                da.SelectCommand = cmd;
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }
        public override DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                IDbDataAdapter da = CreateDataAdapter();
                PreCommand(cmd, conn, null, cmdType, cmdText, cmdParameters);
                DataSet ds = new DataSet();

                da.SelectCommand = cmd;
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }
        public override DataSet ExecuteDataSetByTrans(string cmdText, params IDbDataParameter[] cmdParameters)
        {

            using (IDbConnection conn = CreateConnection())
            {
                IDbCommand cmd = CreateCommand();
                using (IDbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        IDbDataAdapter da = CreateDataAdapter();
                        PreCommand(cmd, conn, trans, CommandType.Text, cmdText, cmdParameters);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        cmd.Parameters.Clear();
                        trans.Commit();
                        return ds;
                    }
                    catch (SqlException ex)
                    {
                        trans.Rollback();
                    }
                    return null;
                }
            }
        }

        #endregion

        private void PreCommand(IDbCommand cmd, IDbConnection conn, IDbTransaction trans, CommandType cmdType, string cmdText, IDbDataParameter[] cmdParameters)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            if (cmdParameters != null)
                foreach (IDbDataParameter param in cmdParameters)
                    cmd.Parameters.Add(param);

        }
    }
}
