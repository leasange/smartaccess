/**  版本信息模板在安装目录下，可自行修改。
* SMT_DATADICTIONARY_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_DATADICTIONARY_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/17 22:43:33   N/A    初版
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
	/// 数据访问类:SMT_DATADICTIONARY_INFO
	/// </summary>
	public partial class SMT_DATADICTIONARY_INFO
	{
		public SMT_DATADICTIONARY_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DATA_TYPE,string DATA_KEY)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_DATADICTIONARY_INFO");
			strSql.Append(" where DATA_TYPE=@DATA_TYPE and DATA_KEY=@DATA_KEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@DATA_TYPE", SqlDbType.VarChar,20),
					new SqlParameter("@DATA_KEY", SqlDbType.VarChar,40)			};
			parameters[0].Value = DATA_TYPE;
			parameters[1].Value = DATA_KEY;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SMT_DATADICTIONARY_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_DATADICTIONARY_INFO(");
			strSql.Append("DATA_TYPE,DATA_KEY,DATA_VALUE,DATA_NAME,DATA_CONTENT)");
			strSql.Append(" values (");
			strSql.Append("@DATA_TYPE,@DATA_KEY,@DATA_VALUE,@DATA_NAME,@DATA_CONTENT)");
			SqlParameter[] parameters = {
					new SqlParameter("@DATA_TYPE", SqlDbType.VarChar,20),
					new SqlParameter("@DATA_KEY", SqlDbType.VarChar,40),
					new SqlParameter("@DATA_VALUE", SqlDbType.NVarChar,500),
					new SqlParameter("@DATA_NAME", SqlDbType.NVarChar,80),
					new SqlParameter("@DATA_CONTENT", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.DATA_TYPE;
			parameters[1].Value = model.DATA_KEY;
			parameters[2].Value = model.DATA_VALUE;
			parameters[3].Value = model.DATA_NAME;
			parameters[4].Value = model.DATA_CONTENT;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.SMT_DATADICTIONARY_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_DATADICTIONARY_INFO set ");
			strSql.Append("DATA_VALUE=@DATA_VALUE,");
			strSql.Append("DATA_NAME=@DATA_NAME,");
			strSql.Append("DATA_CONTENT=@DATA_CONTENT");
			strSql.Append(" where DATA_TYPE=@DATA_TYPE and DATA_KEY=@DATA_KEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@DATA_VALUE", SqlDbType.NVarChar,500),
					new SqlParameter("@DATA_NAME", SqlDbType.NVarChar,80),
					new SqlParameter("@DATA_CONTENT", SqlDbType.NVarChar,500),
					new SqlParameter("@DATA_TYPE", SqlDbType.VarChar,20),
					new SqlParameter("@DATA_KEY", SqlDbType.VarChar,40)};
			parameters[0].Value = model.DATA_VALUE;
			parameters[1].Value = model.DATA_NAME;
			parameters[2].Value = model.DATA_CONTENT;
			parameters[3].Value = model.DATA_TYPE;
			parameters[4].Value = model.DATA_KEY;

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
		public bool Delete(string DATA_TYPE,string DATA_KEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_DATADICTIONARY_INFO ");
			strSql.Append(" where DATA_TYPE=@DATA_TYPE and DATA_KEY=@DATA_KEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@DATA_TYPE", SqlDbType.VarChar,20),
					new SqlParameter("@DATA_KEY", SqlDbType.VarChar,40)			};
			parameters[0].Value = DATA_TYPE;
			parameters[1].Value = DATA_KEY;

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.SMT_DATADICTIONARY_INFO GetModel(string DATA_TYPE,string DATA_KEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DATA_TYPE,DATA_KEY,DATA_VALUE,DATA_NAME,DATA_CONTENT from SMT_DATADICTIONARY_INFO ");
			strSql.Append(" where DATA_TYPE=@DATA_TYPE and DATA_KEY=@DATA_KEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@DATA_TYPE", SqlDbType.VarChar,20),
					new SqlParameter("@DATA_KEY", SqlDbType.VarChar,40)			};
			parameters[0].Value = DATA_TYPE;
			parameters[1].Value = DATA_KEY;

			Maticsoft.Model.SMT_DATADICTIONARY_INFO model=new Maticsoft.Model.SMT_DATADICTIONARY_INFO();
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
		public Maticsoft.Model.SMT_DATADICTIONARY_INFO DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_DATADICTIONARY_INFO model=new Maticsoft.Model.SMT_DATADICTIONARY_INFO();
			if (row != null)
			{
				if(row["DATA_TYPE"]!=null)
				{
					model.DATA_TYPE=row["DATA_TYPE"].ToString();
				}
				if(row["DATA_KEY"]!=null)
				{
					model.DATA_KEY=row["DATA_KEY"].ToString();
				}
				if(row["DATA_VALUE"]!=null)
				{
					model.DATA_VALUE=row["DATA_VALUE"].ToString();
				}
				if(row["DATA_NAME"]!=null)
				{
					model.DATA_NAME=row["DATA_NAME"].ToString();
				}
				if(row["DATA_CONTENT"]!=null)
				{
					model.DATA_CONTENT=row["DATA_CONTENT"].ToString();
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
			strSql.Append("select DATA_TYPE,DATA_KEY,DATA_VALUE,DATA_NAME,DATA_CONTENT ");
			strSql.Append(" FROM SMT_DATADICTIONARY_INFO ");
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
			strSql.Append(" DATA_TYPE,DATA_KEY,DATA_VALUE,DATA_NAME,DATA_CONTENT ");
			strSql.Append(" FROM SMT_DATADICTIONARY_INFO ");
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
			strSql.Append("select count(1) FROM SMT_DATADICTIONARY_INFO ");
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
				strSql.Append("order by T.DATA_KEY desc");
			}
			strSql.Append(")AS Row, T.*  from SMT_DATADICTIONARY_INFO T ");
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
			parameters[0].Value = "SMT_DATADICTIONARY_INFO";
			parameters[1].Value = "DATA_KEY";
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

