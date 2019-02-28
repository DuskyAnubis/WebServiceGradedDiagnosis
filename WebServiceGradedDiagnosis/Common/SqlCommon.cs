using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using Microsoft.ApplicationBlocks.Data;


namespace WebServiceGradedDiagnosis.Common
{
    /// <summary>
    ///SqlCommonDataAccess 通用数据库访问类，请不要修改此类代码。
    /// </summary>
    public static class SqlCommon
    {
        /// <summary>
        /// 获得web.config中connectionStrings节点中name储存的连接字符串明文.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionStringFromConnectionStrings(string name)
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString != null
                && !System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString.Equals(""))
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }
            return null;
        }

        //默认连接字符串；
        private static string GetConnectionString()
        {
            return GetConnectionStringFromConnectionStrings("HisConnectionString");
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个DataSet结果集；
        /// </summary>
        /// <param name="sql">要执行的sql语句；</param>
        /// <returns></returns>
        public static DataSet ExecuteSqlToDataSet(string sql)
        {
            return SqlHelper.ExecuteDataset(GetConnectionString(), CommandType.Text, sql);
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个DataSet结果集；
        /// </summary>
        /// <param name="connectionString">连接字符串；</param>
        /// <param name="sql">要执行的sql语句；</param>
        /// <returns></returns>
        public static DataSet ExecuteSqlToDataSet(string connectionString, string sql)
        {
            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql);
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个DataSet结果集；
        /// </summary>
        /// <param name="sql">要执行的sql语句；</param>
        /// <param name="param">参数集合；</param>
        /// <returns></returns>
        public static DataSet ExecuteSqlToDataSet(string sql, SqlParameter[] param)
        {
            return SqlHelper.ExecuteDataset(GetConnectionString(), CommandType.Text, sql, param);
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个DataSet结果集；
        /// </summary>
        /// <param name="connectionString">连接字符串；</param>
        /// <param name="sql">要执行的sql语句；</param>
        /// <param name="param">参数集合；</param>
        /// <returns></returns>
        public static DataSet ExecuteSqlToDataSet(string connectionString, string sql, SqlParameter[] param)
        {
            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql, param);
        }

        /// <summary>
        /// 执行一条SQL语句，返回受影响的行数；
        /// </summary>
        /// <param name="sql">要执行的sql语句；</param>
        /// <returns></returns>
        public static int ExecuteSqlNonQuery(string sql)
        {
            return SqlHelper.ExecuteNonQuery(GetConnectionString(), CommandType.Text, sql);
        }

        /// <summary>
        /// 执行一条SQL语句，返回受影响的行数；
        /// </summary>
        /// <param name="sql">要执行的sql语句；</param>
        /// <param name="param">参数集合；</param>
        /// <returns></returns>
        public static int ExecuteSqlNonQuery(string sql, SqlParameter[] param)
        {
            return SqlHelper.ExecuteNonQuery(GetConnectionString(), CommandType.Text, sql, param);
        }

        /// <summary>
        /// 执行一条SQL语句，返回受影响的行数；
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="sql">要执行的sql语句；</param>
        /// <returns></returns>
        public static int ExecuteSqlNonQuery(string connectionString, string sql)
        {
            return SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql);
        }

        /// <summary>
        /// 执行一条SQL语句，返回受影响的行数；
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="sql">要执行的sql语句；</param>
        /// <param name="param">参数集合；</param>
        /// <returns></returns>
        public static int ExecuteSqlNonQuery(string connectionString, string sql, SqlParameter[] param)
        {
            return SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, param);
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个DataReader；
        /// </summary>
        /// <param name="sql">要执行的sql语句；</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteSqlToDataReader(string sql)
        {
            return SqlHelper.ExecuteReader(GetConnectionString(), CommandType.Text, sql);
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个DataReader；
        /// </summary>
        /// <param name="sql">要执行的sql语句；</param>
        /// <param name="param">参数集合；</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteSqlToDataReader(string sql, SqlParameter[] param)
        {
            return SqlHelper.ExecuteReader(GetConnectionString(), CommandType.Text, sql, param);
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个DataReader；
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="sql">要执行的sql语句；</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteSqlToDataReader(string connectionString, string sql)
        {
            return SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql);
        }

        /// <summary>
        /// 执行一条SQL语句，返回一个DataReader；
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="sql">要执行的sql语句；</param>
        /// <param name="param">参数集合；</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteSqlToDataReader(string connectionString, string sql, SqlParameter[] param)
        {
            return SqlHelper.ExecuteReader(connectionString, CommandType.Text, sql, param);
        }

        /// <summary>
        /// 执行一条SQL语句，返回第一行第一列的值；
        /// </summary>
        /// <param name="sql">要执行的sql语句；</param>
        /// <returns></returns>
        public static object ExecuteSqlToScalar(string sql)
        {
            return SqlHelper.ExecuteScalar(GetConnectionString(), CommandType.Text, sql);
        }

        /// <summary>
        /// 执行一条SQL语句，返回第一行第一列的值；
        /// </summary>
        /// <param name="sql">要执行的sql语句；</param>
        /// <param name="param">参数集合；</param>
        /// <returns></returns>
        public static object ExecuteSqlToScalar(string sql, SqlParameter[] param)
        {
            return SqlHelper.ExecuteScalar(GetConnectionString(), CommandType.Text, sql);
        }

        /// <summary>
        /// 执行一条SQL语句，返回第一行第一列的值；
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="sql">要执行的sql语句；</param>
        /// <returns></returns>
        public static object ExecuteSqlToScalar(string connectionString, string sql)
        {
            return SqlHelper.ExecuteScalar(connectionString, CommandType.Text, sql);
        }

        /// <summary>
        /// 执行一条SQL语句，返回第一行第一列的值；
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="sql">要执行的sql语句；</param>
        /// <returns></returns>
        public static object ExecuteSqlToScalar(string connectionString, string sql, SqlParameter[] param)
        {
            return SqlHelper.ExecuteScalar(connectionString, CommandType.Text, sql, param);
        }

        /// <summary>
        /// 执行一个存储过程，返回dataSet；
        /// </summary>
        /// <param name="ProcedureName">存储过程名；</param>
        /// <param name="param">执行参数集合；</param>
        /// <returns></returns>
        public static DataSet ExecuteProcedureToDataSet(string ProcedureName, SqlParameter[] param)
        {
            return SqlHelper.ExecuteDataset(GetConnectionString(), CommandType.StoredProcedure, ProcedureName, param);
        }

        /// <summary>
        /// 执行一个存储过程，返回dataSet；
        /// </summary>
        /// <param name="connectionString">连接字符串；</param>
        /// <param name="ProcedureName">存储过程名；</param>
        /// <param name="param"</param>
        /// <returns></returns>
        public static DataSet ExecuteProcedureToDataSet(string connectionString, string ProcedureName, SqlParameter[] param)
        {
            return SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, ProcedureName, param);
        }

        /// <summary>
        /// 执行一个存储过程，返回受影响的行数；
        /// </summary>
        /// <param name="ProcedureName">存储过程名；</param>
        /// <param name="param">>参数集合；</param>
        /// <returns></returns>
        public static int ExecuteProcedureNonQuery(string ProcedureName, SqlParameter[] param)
        {
            return SqlHelper.ExecuteNonQuery(GetConnectionString(), CommandType.StoredProcedure, ProcedureName, param);
        }

        /// <summary>
        /// 执行一个存储过程，返回受影响的行数；
        /// </summary>
        /// <param name="connectionString">连接字符串；</param>
        /// <param name="ProcedureName">存储过程名；</param>
        /// <param name="param">>参数集合；</param>
        /// <returns></returns>
        public static int ExecuteProcedureNonQuery(string connectionString, string ProcedureName, SqlParameter[] param)
        {
            return SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, ProcedureName, param);
        }

        /// <summary>
        /// 执行一个存储过程，返回DataReader;
        /// </summary>
        /// <param name="ProcedureName">存储过程名；</param>
        /// <param name="param">>参数集合；</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteProcedureToDataReader(string ProcedureName, SqlParameter[] param)
        {
            return SqlHelper.ExecuteReader(GetConnectionString(), CommandType.StoredProcedure, ProcedureName, param);
        }

        /// <summary>
        /// 执行一个存储过程，返回DataReader；
        /// </summary>
        /// <param name="connectionString">连接字符串；</param>
        /// <param name="ProcedureName">存储过程名；</param>
        /// <param name="param">>参数集合；</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteProcedureToDataReader(string connectionString, string ProcedureName, SqlParameter[] param)
        {
            return SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, ProcedureName, param);
        }

        /// <summary>
        /// 默认字符串连接的数据库名；
        /// </summary>
        public static string DataBase
        {
            get
            {
                SqlConnection sqlConn = new SqlConnection(GetConnectionString());
                sqlConn.Open();
                string databaseName = sqlConn.Database;
                sqlConn.Dispose();
                sqlConn.Close();
                return databaseName;
            }
        }
    }
}

