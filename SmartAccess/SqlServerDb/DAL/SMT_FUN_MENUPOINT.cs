﻿/**  版本信息模板在安装目录下，可自行修改。
* SMT_FUN_MENUPOINT.cs
*
* 功 能： N/A
* 类 名： SMT_FUN_MENUPOINT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/13 20:12:29   N/A    初版
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
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:SMT_FUN_MENUPOINT
	/// </summary>
	public partial class SMT_FUN_MENUPOINT
	{
		public SMT_FUN_MENUPOINT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_FUN_MENUPOINT");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.SMT_FUN_MENUPOINT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_FUN_MENUPOINT(");
			strSql.Append("PAR_ID,FUN_CODE,FUN_NAME,IS_MENU)");
			strSql.Append(" values (");
			strSql.Append("@PAR_ID,@FUN_CODE,@FUN_NAME,@IS_MENU)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PAR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FUN_CODE", SqlDbType.VarChar,100),
					new SqlParameter("@FUN_NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@IS_MENU", SqlDbType.Bit,1)};
			parameters[0].Value = model.PAR_ID;
			parameters[1].Value = model.FUN_CODE;
			parameters[2].Value = model.FUN_NAME;
			parameters[3].Value = model.IS_MENU;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.SMT_FUN_MENUPOINT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_FUN_MENUPOINT set ");
			strSql.Append("PAR_ID=@PAR_ID,");
			strSql.Append("FUN_CODE=@FUN_CODE,");
			strSql.Append("FUN_NAME=@FUN_NAME,");
			strSql.Append("IS_MENU=@IS_MENU");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@PAR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FUN_CODE", SqlDbType.VarChar,100),
					new SqlParameter("@FUN_NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@IS_MENU", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.PAR_ID;
			parameters[1].Value = model.FUN_CODE;
			parameters[2].Value = model.FUN_NAME;
			parameters[3].Value = model.IS_MENU;
			parameters[4].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_FUN_MENUPOINT ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_FUN_MENUPOINT ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.SMT_FUN_MENUPOINT GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,PAR_ID,FUN_CODE,FUN_NAME,IS_MENU from SMT_FUN_MENUPOINT ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_FUN_MENUPOINT model=new Maticsoft.Model.SMT_FUN_MENUPOINT();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public Maticsoft.Model.SMT_FUN_MENUPOINT DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_FUN_MENUPOINT model=new Maticsoft.Model.SMT_FUN_MENUPOINT();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["PAR_ID"]!=null && row["PAR_ID"].ToString()!="")
				{
					model.PAR_ID=decimal.Parse(row["PAR_ID"].ToString());
				}
				if(row["FUN_CODE"]!=null)
				{
					model.FUN_CODE=row["FUN_CODE"].ToString();
				}
				if(row["FUN_NAME"]!=null)
				{
					model.FUN_NAME=row["FUN_NAME"].ToString();
				}
				if(row["IS_MENU"]!=null && row["IS_MENU"].ToString()!="")
				{
					if((row["IS_MENU"].ToString()=="1")||(row["IS_MENU"].ToString().ToLower()=="true"))
					{
						model.IS_MENU=true;
					}
					else
					{
						model.IS_MENU=false;
					}
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
			strSql.Append("select ID,PAR_ID,FUN_CODE,FUN_NAME,IS_MENU ");
			strSql.Append(" FROM SMT_FUN_MENUPOINT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,PAR_ID,FUN_CODE,FUN_NAME,IS_MENU ");
			strSql.Append(" FROM SMT_FUN_MENUPOINT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SMT_FUN_MENUPOINT ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from SMT_FUN_MENUPOINT T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "SMT_FUN_MENUPOINT";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

