/**  版本信息模板在安装目录下，可自行修改。
* staff_card.cs
*
* 功 能： N/A
* 类 名： staff_card
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
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.BST
{
	/// <summary>
	/// 数据访问类:staff_card
	/// </summary>
	public partial class staff_card
	{
		public staff_card()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id_card)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from staff_card");
			strSql.Append(" where id_card=@id_card ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id_card", MySqlDbType.VarChar,60)			};
			parameters[0].Value = id_card;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.BST.staff_card model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into staff_card(");
			strSql.Append("id_card,name,auth_type,is_register,date_begin,date_end)");
			strSql.Append(" values (");
			strSql.Append("@id_card,@name,@auth_type,@is_register,@date_begin,@date_end)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id_card", MySqlDbType.VarChar,60),
					new MySqlParameter("@name", MySqlDbType.VarChar,20),
					new MySqlParameter("@auth_type", MySqlDbType.VarChar,1),
					new MySqlParameter("@is_register", MySqlDbType.VarChar,1),
					new MySqlParameter("@date_begin", MySqlDbType.VarChar,45),
					new MySqlParameter("@date_end", MySqlDbType.VarChar,45)};
			parameters[0].Value = model.id_card;
			parameters[1].Value = model.name;
			parameters[2].Value = model.auth_type;
			parameters[3].Value = model.is_register;
			parameters[4].Value = model.date_begin;
			parameters[5].Value = model.date_end;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(Maticsoft.Model.BST.staff_card model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update staff_card set ");
			strSql.Append("name=@name,");
			strSql.Append("auth_type=@auth_type,");
			strSql.Append("is_register=@is_register,");
			strSql.Append("date_begin=@date_begin,");
			strSql.Append("date_end=@date_end");
			strSql.Append(" where id_card=@id_card ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,20),
					new MySqlParameter("@auth_type", MySqlDbType.VarChar,1),
					new MySqlParameter("@is_register", MySqlDbType.VarChar,1),
					new MySqlParameter("@date_begin", MySqlDbType.VarChar,45),
					new MySqlParameter("@date_end", MySqlDbType.VarChar,45),
					new MySqlParameter("@id_card", MySqlDbType.VarChar,60)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.auth_type;
			parameters[2].Value = model.is_register;
			parameters[3].Value = model.date_begin;
			parameters[4].Value = model.date_end;
			parameters[5].Value = model.id_card;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id_card)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from staff_card ");
			strSql.Append(" where id_card=@id_card ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id_card", MySqlDbType.VarChar,60)			};
			parameters[0].Value = id_card;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string id_cardlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from staff_card ");
			strSql.Append(" where id_card in ("+id_cardlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.BST.staff_card GetModel(string id_card)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id_card,name,auth_type,is_register,date_begin,date_end from staff_card ");
			strSql.Append(" where id_card=@id_card ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id_card", MySqlDbType.VarChar,60)			};
			parameters[0].Value = id_card;

			Maticsoft.Model.BST.staff_card model=new Maticsoft.Model.BST.staff_card();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.BST.staff_card DataRowToModel(DataRow row)
		{
			Maticsoft.Model.BST.staff_card model=new Maticsoft.Model.BST.staff_card();
			if (row != null)
			{
				if(row["id_card"]!=null)
				{
					model.id_card=row["id_card"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["auth_type"]!=null)
				{
					model.auth_type=row["auth_type"].ToString();
				}
				if(row["is_register"]!=null)
				{
					model.is_register=row["is_register"].ToString();
				}
				if(row["date_begin"]!=null)
				{
					model.date_begin=row["date_begin"].ToString();
				}
				if(row["date_end"]!=null)
				{
					model.date_end=row["date_end"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id_card,name,auth_type,is_register,date_begin,date_end ");
			strSql.Append(" FROM staff_card ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM staff_card ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id_card desc");
			}
			strSql.Append(")AS Row, T.*  from staff_card T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "staff_card";
			parameters[1].Value = "id_card";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

