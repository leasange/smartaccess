/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_CARD.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_CARD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/24 22:45:06   N/A    初版
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
	/// 数据访问类:SMT_STAFF_CARD
	/// </summary>
	public partial class SMT_STAFF_CARD
	{
		public SMT_STAFF_CARD()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal STAFF_ID,decimal CARD_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_STAFF_CARD");
			strSql.Append(" where STAFF_ID=@STAFF_ID and CARD_ID=@CARD_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CARD_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = STAFF_ID;
			parameters[1].Value = CARD_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SMT_STAFF_CARD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_STAFF_CARD(");
			strSql.Append("STAFF_ID,CARD_ID)");
			strSql.Append(" values (");
			strSql.Append("@STAFF_ID,@CARD_ID)");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CARD_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.STAFF_ID;
			parameters[1].Value = model.CARD_ID;

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
		public bool Update(Maticsoft.Model.SMT_STAFF_CARD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_STAFF_CARD set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("STAFF_ID=@STAFF_ID,");
			strSql.Append("CARD_ID=@CARD_ID");
			strSql.Append(" where STAFF_ID=@STAFF_ID and CARD_ID=@CARD_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CARD_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.STAFF_ID;
			parameters[1].Value = model.CARD_ID;

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
		public bool Delete(decimal STAFF_ID,decimal CARD_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_STAFF_CARD ");
			strSql.Append(" where STAFF_ID=@STAFF_ID and CARD_ID=@CARD_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CARD_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = STAFF_ID;
			parameters[1].Value = CARD_ID;

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
		public Maticsoft.Model.SMT_STAFF_CARD GetModel(decimal STAFF_ID,decimal CARD_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 STAFF_ID,CARD_ID from SMT_STAFF_CARD ");
			strSql.Append(" where STAFF_ID=@STAFF_ID and CARD_ID=@CARD_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CARD_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = STAFF_ID;
			parameters[1].Value = CARD_ID;

			Maticsoft.Model.SMT_STAFF_CARD model=new Maticsoft.Model.SMT_STAFF_CARD();
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
		public Maticsoft.Model.SMT_STAFF_CARD DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_STAFF_CARD model=new Maticsoft.Model.SMT_STAFF_CARD();
			if (row != null)
			{
				if(row["STAFF_ID"]!=null && row["STAFF_ID"].ToString()!="")
				{
					model.STAFF_ID=decimal.Parse(row["STAFF_ID"].ToString());
				}
				if(row["CARD_ID"]!=null && row["CARD_ID"].ToString()!="")
				{
					model.CARD_ID=decimal.Parse(row["CARD_ID"].ToString());
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
			strSql.Append("select STAFF_ID,CARD_ID ");
			strSql.Append(" FROM SMT_STAFF_CARD ");
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
			strSql.Append(" STAFF_ID,CARD_ID ");
			strSql.Append(" FROM SMT_STAFF_CARD ");
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
			strSql.Append("select count(1) FROM SMT_STAFF_CARD ");
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
				strSql.Append("order by T.CARD_ID desc");
			}
			strSql.Append(")AS Row, T.*  from SMT_STAFF_CARD T ");
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
			parameters[0].Value = "SMT_STAFF_CARD";
			parameters[1].Value = "CARD_ID";
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

