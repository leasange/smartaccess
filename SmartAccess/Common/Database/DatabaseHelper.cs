using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Database
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class DatabaseHelper
    {
        /// <summary>
        /// 连接Sql server 数据库
        /// </summary>
        /// <param name="connectString">连接字符串</param>
        /// <returns>返回连接，异常返回Exception</returns>
        public static SqlConnection ConnectDatabase(string connectString)
        {
            SqlConnection con = new SqlConnection(connectString);
            con.Open();
            return con;
        }
        public static decimal GetMaxID(string field,string table)
        {
           DataSet ds=  Maticsoft.DBUtility.DbHelperSQL.Query("select max(" + field + ") from " + table);
           return (decimal)ds.Tables[0].Rows[0][0];
        }
    }
}
