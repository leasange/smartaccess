/**  版本信息模板在安装目录下，可自行修改。
* staff_data.cs
*
* 功 能： N/A
* 类 名： staff_data
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/8/22 22:46:32   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace Maticsoft.DAL.BST
{
	/// <summary>
	/// 数据访问类:staff_data
	/// </summary>
	public partial class staff_data
	{
		#region  ExtensionMethod
        public List<string> GetAllIds(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from staff_data ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append("where " + strWhere);
            }
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
            List<string> list = new List<string>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    string id = item[0].ToString();
                    list.Add(id);
                }
            }
            return list;
        }
        public bool DeleteAll(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from staff_data ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                strSql.Append("where " + strWhere);
            }
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		#endregion  ExtensionMethod
	}
}

