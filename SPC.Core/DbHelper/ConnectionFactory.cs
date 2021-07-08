using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using SPC.Core.Extensions;

namespace SPC.Core.DbHelper
{
    public class ConnectionFactory
    {
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="conStr">数据库连接字符串</param>
        /// <returns>数据库连接</returns>
        public static IDbConnection CreateConnection(string dbType, string strConn)
        {
            if (dbType.IsNullOrWhiteSpace())
                throw new ArgumentNullException("没有传入数据库类型");

            if (strConn.IsNullOrWhiteSpace())
                throw new ArgumentNullException("没有传入数据连接字符串");

            var type = GetDataBaseType(dbType);
            return CreateConnection(type, strConn);
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns>数据库连接</returns>
        public static IDbConnection CreateConnection(DatabaseType dbType, string connectionString)
        {
            IDbConnection connection = null;
            if (connectionString.IsNullOrWhiteSpace())
                throw new ArgumentNullException("没有传入数据库连接字符串");

            switch (dbType)
            {
                case DatabaseType.SqlServer:
                    connection = new SqlConnection(connectionString);
                    break;
                case DatabaseType.MySQL:
                    connection = new MySqlConnection(connectionString);
                    break;
                case DatabaseType.PostgreSQL:
                    connection = new NpgsqlConnection(connectionString);
                    break;
                default:
                    throw new ArgumentNullException($"不支持的{dbType.ToString()}数据库类型");
            }

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        /// <summary>
        /// 转换数据库类型
        /// </summary>
        /// <param name="dbType">数据库类型字符串</param>
        /// <returns>数据库类型</returns>
        public static DatabaseType GetDataBaseType(string dbType)
        {
            if (dbType.IsNullOrWhiteSpace())
                throw new ArgumentNullException("没有传入数据库类型");

            DatabaseType returnValue = DatabaseType.SqlServer;
            foreach (DatabaseType type in Enum.GetValues(typeof(DatabaseType)))
            {
                if (type.ToString().Equals(dbType, StringComparison.OrdinalIgnoreCase))
                {
                    returnValue = type;
                    break;
                }
            }
            return returnValue;
        }
    }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DatabaseType
    {
        SqlServer,
        MySQL,
        PostgreSQL,
        SQLite,
        InMemory,
        Oracle,
        MariaDB,
        MyCat,
        Firebird,
        DB2,
        Access
    }
}