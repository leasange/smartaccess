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
            DataSet ds = DbHelperMySQLP.Query(strSql.ToString());
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
            int rows = DbHelperMySQLP.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEx(Maticsoft.Model.BST.staff_data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update staff_data set ");
            strSql.Append("name=@name,");
            //strSql.Append("info=@info,");
            //strSql.Append("image=@image,");
            //strSql.Append("authority=@authority,");
            strSql.Append("date_begin=@date_begin,");
            strSql.Append("date_end=@date_end,");
            strSql.Append("data_keepon1=@data_keepon1,");
            strSql.Append("data_keepon2=@data_keepon2,");
            strSql.Append("data_keepon3=@data_keepon3,");
            strSql.Append("data_keepon4=@data_keepon4,");
            strSql.Append("data_keepon5=@data_keepon5");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					//new MySqlParameter("@info", MySqlDbType.VarBinary),
					//new MySqlParameter("@image", MySqlDbType.MediumBlob),
					//new MySqlParameter("@authority", MySqlDbType.VarChar,1),
					new MySqlParameter("@date_begin", MySqlDbType.VarChar,45),
					new MySqlParameter("@date_end", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon1", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon2", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon3", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon4", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon5", MySqlDbType.VarChar,45),
					new MySqlParameter("@id", MySqlDbType.VarChar,60)};
            parameters[0].Value = model.name;
            //parameters[1].Value = model.info;
            //parameters[2].Value = model.image;
            //parameters[3].Value = model.authority;
            parameters[4].Value = model.date_begin;
            parameters[5].Value = model.date_end;
            parameters[6].Value = model.data_keepon1;
            parameters[7].Value = model.data_keepon2;
            parameters[8].Value = model.data_keepon3;
            parameters[9].Value = model.data_keepon4;
            parameters[10].Value = model.data_keepon5;
            parameters[11].Value = model.id;

            int rows = DbHelperMySQLP.ExecuteSql(strSql.ToString(), parameters);
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

