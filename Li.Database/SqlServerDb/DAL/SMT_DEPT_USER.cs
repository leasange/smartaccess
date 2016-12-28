/**  版本信息模板在安装目录下，可自行修改。
* SMT_DEPT_USER.cs
*
* 功 能： N/A
* 类 名： SMT_DEPT_USER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/28 23:27:37   N/A    初版
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
	/// 数据访问类:SMT_DEPT_USER
	/// </summary>
	public partial class SMT_DEPT_USER
	{
		public SMT_DEPT_USER()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal DEPT_ID,decimal USER_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_DEPT_USER");
			strSql.Append(" where DEPT_ID=@DEPT_ID and USER_ID=@USER_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DEPT_ID", SqlDbType.Decimal,9),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = DEPT_ID;
			parameters[1].Value = USER_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SMT_DEPT_USER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_DEPT_USER(");
			strSql.Append("DEPT_ID,USER_ID)");
			strSql.Append(" values (");
			strSql.Append("@DEPT_ID,@USER_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@DEPT_ID", SqlDbType.Decimal,9),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.DEPT_ID;
			parameters[1].Value = model.USER_ID;

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
		public bool Update(Maticsoft.Model.SMT_DEPT_USER model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_DEPT_USER set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("DEPT_ID=@DEPT_ID,");
			strSql.Append("USER_ID=@USER_ID");
			strSql.Append(" where DEPT_ID=@DEPT_ID and USER_ID=@USER_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DEPT_ID", SqlDbType.Decimal,9),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.DEPT_ID;
			parameters[1].Value = model.USER_ID;

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
		public bool Delete(decimal DEPT_ID,decimal USER_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_DEPT_USER ");
			strSql.Append(" where DEPT_ID=@DEPT_ID and USER_ID=@USER_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DEPT_ID", SqlDbType.Decimal,9),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = DEPT_ID;
			parameters[1].Value = USER_ID;

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
		public Maticsoft.Model.SMT_DEPT_USER GetModel(decimal DEPT_ID,decimal USER_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DEPT_ID,USER_ID from SMT_DEPT_USER ");
			strSql.Append(" where DEPT_ID=@DEPT_ID and USER_ID=@USER_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DEPT_ID", SqlDbType.Decimal,9),
					new SqlParameter("@USER_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = DEPT_ID;
			parameters[1].Value = USER_ID;

			Maticsoft.Model.SMT_DEPT_USER model=new Maticsoft.Model.SMT_DEPT_USER();
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
		public Maticsoft.Model.SMT_DEPT_USER DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_DEPT_USER model=new Maticsoft.Model.SMT_DEPT_USER();
			if (row != null)
			{
				if(row["DEPT_ID"]!=null && row["DEPT_ID"].ToString()!="")
				{
					model.DEPT_ID=decimal.Parse(row["DEPT_ID"].ToString());
				}
				if(row["USER_ID"]!=null && row["USER_ID"].ToString()!="")
				{
					model.USER_ID=decimal.Parse(row["USER_ID"].ToString());
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
			strSql.Append("select DEPT_ID,USER_ID ");
			strSql.Append(" FROM SMT_DEPT_USER ");
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
			strSql.Append(" DEPT_ID,USER_ID ");
			strSql.Append(" FROM SMT_DEPT_USER ");
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
			strSql.Append("select count(1) FROM SMT_DEPT_USER ");
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
				strSql.Append("order by T.USER_ID desc");
			}
			strSql.Append(")AS Row, T.*  from SMT_DEPT_USER T ");
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
			parameters[0].Value = "SMT_DEPT_USER";
			parameters[1].Value = "USER_ID";
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

