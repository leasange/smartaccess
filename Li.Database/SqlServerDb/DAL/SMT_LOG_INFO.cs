/**  版本信息模板在安装目录下，可自行修改。
* SMT_LOG_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_LOG_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/22 0:25:36   N/A    初版
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
	/// 数据访问类:SMT_LOG_INFO
	/// </summary>
	public partial class SMT_LOG_INFO
	{
		public SMT_LOG_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_LOG_INFO");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SMT_LOG_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_LOG_INFO(");
			strSql.Append("ID,LOG_TYPE,LOG_LEVEL,LOG_CONTENT,LOG_TIME)");
			strSql.Append(" values (");
			strSql.Append("@ID,@LOG_TYPE,@LOG_LEVEL,@LOG_CONTENT,@LOG_TIME)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal,9),
					new SqlParameter("@LOG_TYPE", SqlDbType.NVarChar,50),
					new SqlParameter("@LOG_LEVEL", SqlDbType.TinyInt,1),
					new SqlParameter("@LOG_CONTENT", SqlDbType.NVarChar,300),
					new SqlParameter("@LOG_TIME", SqlDbType.DateTime)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.LOG_TYPE;
			parameters[2].Value = model.LOG_LEVEL;
			parameters[3].Value = model.LOG_CONTENT;
			parameters[4].Value = model.LOG_TIME;

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
		public bool Update(Maticsoft.Model.SMT_LOG_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_LOG_INFO set ");
			strSql.Append("LOG_TYPE=@LOG_TYPE,");
			strSql.Append("LOG_LEVEL=@LOG_LEVEL,");
			strSql.Append("LOG_CONTENT=@LOG_CONTENT,");
			strSql.Append("LOG_TIME=@LOG_TIME");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LOG_TYPE", SqlDbType.NVarChar,50),
					new SqlParameter("@LOG_LEVEL", SqlDbType.TinyInt,1),
					new SqlParameter("@LOG_CONTENT", SqlDbType.NVarChar,300),
					new SqlParameter("@LOG_TIME", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.LOG_TYPE;
			parameters[1].Value = model.LOG_LEVEL;
			parameters[2].Value = model.LOG_CONTENT;
			parameters[3].Value = model.LOG_TIME;
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
			strSql.Append("delete from SMT_LOG_INFO ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal,9)			};
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
			strSql.Append("delete from SMT_LOG_INFO ");
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
		public Maticsoft.Model.SMT_LOG_INFO GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,LOG_TYPE,LOG_LEVEL,LOG_CONTENT,LOG_TIME from SMT_LOG_INFO ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_LOG_INFO model=new Maticsoft.Model.SMT_LOG_INFO();
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
		public Maticsoft.Model.SMT_LOG_INFO DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_LOG_INFO model=new Maticsoft.Model.SMT_LOG_INFO();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["LOG_TYPE"]!=null)
				{
					model.LOG_TYPE=row["LOG_TYPE"].ToString();
				}
				if(row["LOG_LEVEL"]!=null && row["LOG_LEVEL"].ToString()!="")
				{
					model.LOG_LEVEL=int.Parse(row["LOG_LEVEL"].ToString());
				}
				if(row["LOG_CONTENT"]!=null)
				{
					model.LOG_CONTENT=row["LOG_CONTENT"].ToString();
				}
				if(row["LOG_TIME"]!=null && row["LOG_TIME"].ToString()!="")
				{
					model.LOG_TIME=DateTime.Parse(row["LOG_TIME"].ToString());
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
			strSql.Append("select ID,LOG_TYPE,LOG_LEVEL,LOG_CONTENT,LOG_TIME ");
			strSql.Append(" FROM SMT_LOG_INFO ");
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
			strSql.Append(" ID,LOG_TYPE,LOG_LEVEL,LOG_CONTENT,LOG_TIME ");
			strSql.Append(" FROM SMT_LOG_INFO ");
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
			strSql.Append("select count(1) FROM SMT_LOG_INFO ");
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
			strSql.Append(")AS Row, T.*  from SMT_LOG_INFO T ");
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
			parameters[0].Value = "SMT_LOG_INFO";
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

