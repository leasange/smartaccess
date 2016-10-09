/**  版本信息模板在安装目录下，可自行修改。
* SMT_ROLE_FUN.cs
*
* 功 能： N/A
* 类 名： SMT_ROLE_FUN
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/10/9 19:59:50   N/A    初版
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
	/// 数据访问类:SMT_ROLE_FUN
	/// </summary>
	public partial class SMT_ROLE_FUN
	{
		public SMT_ROLE_FUN()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ROLE_ID,decimal FUN_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_ROLE_FUN");
			strSql.Append(" where ROLE_ID=@ROLE_ID and FUN_ID=@FUN_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FUN_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = ROLE_ID;
			parameters[1].Value = FUN_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SMT_ROLE_FUN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_ROLE_FUN(");
			strSql.Append("ROLE_ID,FUN_ID)");
			strSql.Append(" values (");
			strSql.Append("@ROLE_ID,@FUN_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FUN_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ROLE_ID;
			parameters[1].Value = model.FUN_ID;

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
		public bool Update(Maticsoft.Model.SMT_ROLE_FUN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_ROLE_FUN set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("ROLE_ID=@ROLE_ID,");
			strSql.Append("FUN_ID=@FUN_ID");
			strSql.Append(" where ROLE_ID=@ROLE_ID and FUN_ID=@FUN_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FUN_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ROLE_ID;
			parameters[1].Value = model.FUN_ID;

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
		public bool Delete(decimal ROLE_ID,decimal FUN_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_ROLE_FUN ");
			strSql.Append(" where ROLE_ID=@ROLE_ID and FUN_ID=@FUN_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FUN_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = ROLE_ID;
			parameters[1].Value = FUN_ID;

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
		public Maticsoft.Model.SMT_ROLE_FUN GetModel(decimal ROLE_ID,decimal FUN_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ROLE_ID,FUN_ID from SMT_ROLE_FUN ");
			strSql.Append(" where ROLE_ID=@ROLE_ID and FUN_ID=@FUN_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FUN_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = ROLE_ID;
			parameters[1].Value = FUN_ID;

			Maticsoft.Model.SMT_ROLE_FUN model=new Maticsoft.Model.SMT_ROLE_FUN();
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
		public Maticsoft.Model.SMT_ROLE_FUN DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_ROLE_FUN model=new Maticsoft.Model.SMT_ROLE_FUN();
			if (row != null)
			{
				if(row["ROLE_ID"]!=null && row["ROLE_ID"].ToString()!="")
				{
					model.ROLE_ID=decimal.Parse(row["ROLE_ID"].ToString());
				}
				if(row["FUN_ID"]!=null && row["FUN_ID"].ToString()!="")
				{
					model.FUN_ID=decimal.Parse(row["FUN_ID"].ToString());
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
			strSql.Append("select ROLE_ID,FUN_ID ");
			strSql.Append(" FROM SMT_ROLE_FUN ");
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
			strSql.Append(" ROLE_ID,FUN_ID ");
			strSql.Append(" FROM SMT_ROLE_FUN ");
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
			strSql.Append("select count(1) FROM SMT_ROLE_FUN ");
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
				strSql.Append("order by T.FUN_ID desc");
			}
			strSql.Append(")AS Row, T.*  from SMT_ROLE_FUN T ");
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
			parameters[0].Value = "SMT_ROLE_FUN";
			parameters[1].Value = "FUN_ID";
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

