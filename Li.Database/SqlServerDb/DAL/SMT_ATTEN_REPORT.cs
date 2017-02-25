/**  版本信息模板在安装目录下，可自行修改。
* SMT_ATTEN_REPORT.cs
*
* 功 能： N/A
* 类 名： SMT_ATTEN_REPORT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/25 21:10:34   N/A    初版
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
	/// 数据访问类:SMT_ATTEN_REPORT
	/// </summary>
	public partial class SMT_ATTEN_REPORT
	{
		public SMT_ATTEN_REPORT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_ATTEN_REPORT");
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
		public decimal Add(Maticsoft.Model.SMT_ATTEN_REPORT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_ATTEN_REPORT(");
			strSql.Append("STAFF_ID,ATTEN_DATE,ATTEN_ON_TIME,ATTEN_OFF_TIME,ATTEN_ON_STATE,ATTEN_OFF_STATE,ATTEN_LATE_MIN,ATTEN_LEAVE_MIN,ATTEN_EXTRA_MIN,ATTEN_AWAY_DAY,ATTEN_UNSWIPE_TIMES,ATTEN_SWIPE_TIMES)");
			strSql.Append(" values (");
			strSql.Append("@STAFF_ID,@ATTEN_DATE,@ATTEN_ON_TIME,@ATTEN_OFF_TIME,@ATTEN_ON_STATE,@ATTEN_OFF_STATE,@ATTEN_LATE_MIN,@ATTEN_LEAVE_MIN,@ATTEN_EXTRA_MIN,@ATTEN_AWAY_DAY,@ATTEN_UNSWIPE_TIMES,@ATTEN_SWIPE_TIMES)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ATTEN_DATE", SqlDbType.Date,3),
					new SqlParameter("@ATTEN_ON_TIME", SqlDbType.Time,5),
					new SqlParameter("@ATTEN_OFF_TIME", SqlDbType.Time,5),
					new SqlParameter("@ATTEN_ON_STATE", SqlDbType.NVarChar,20),
					new SqlParameter("@ATTEN_OFF_STATE", SqlDbType.NVarChar,20),
					new SqlParameter("@ATTEN_LATE_MIN", SqlDbType.Int,4),
					new SqlParameter("@ATTEN_LEAVE_MIN", SqlDbType.Int,4),
					new SqlParameter("@ATTEN_EXTRA_MIN", SqlDbType.Int,4),
					new SqlParameter("@ATTEN_AWAY_DAY", SqlDbType.Float,8),
					new SqlParameter("@ATTEN_UNSWIPE_TIMES", SqlDbType.Int,4),
					new SqlParameter("@ATTEN_SWIPE_TIMES", SqlDbType.Int,4)};
			parameters[0].Value = model.STAFF_ID;
			parameters[1].Value = model.ATTEN_DATE;
			parameters[2].Value = model.ATTEN_ON_TIME;
			parameters[3].Value = model.ATTEN_OFF_TIME;
			parameters[4].Value = model.ATTEN_ON_STATE;
			parameters[5].Value = model.ATTEN_OFF_STATE;
			parameters[6].Value = model.ATTEN_LATE_MIN;
			parameters[7].Value = model.ATTEN_LEAVE_MIN;
			parameters[8].Value = model.ATTEN_EXTRA_MIN;
			parameters[9].Value = model.ATTEN_AWAY_DAY;
			parameters[10].Value = model.ATTEN_UNSWIPE_TIMES;
			parameters[11].Value = model.ATTEN_SWIPE_TIMES;

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
		public bool Update(Maticsoft.Model.SMT_ATTEN_REPORT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_ATTEN_REPORT set ");
			strSql.Append("STAFF_ID=@STAFF_ID,");
			strSql.Append("ATTEN_DATE=@ATTEN_DATE,");
			strSql.Append("ATTEN_ON_TIME=@ATTEN_ON_TIME,");
			strSql.Append("ATTEN_OFF_TIME=@ATTEN_OFF_TIME,");
			strSql.Append("ATTEN_ON_STATE=@ATTEN_ON_STATE,");
			strSql.Append("ATTEN_OFF_STATE=@ATTEN_OFF_STATE,");
			strSql.Append("ATTEN_LATE_MIN=@ATTEN_LATE_MIN,");
			strSql.Append("ATTEN_LEAVE_MIN=@ATTEN_LEAVE_MIN,");
			strSql.Append("ATTEN_EXTRA_MIN=@ATTEN_EXTRA_MIN,");
			strSql.Append("ATTEN_AWAY_DAY=@ATTEN_AWAY_DAY,");
			strSql.Append("ATTEN_UNSWIPE_TIMES=@ATTEN_UNSWIPE_TIMES,");
			strSql.Append("ATTEN_SWIPE_TIMES=@ATTEN_SWIPE_TIMES");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ATTEN_DATE", SqlDbType.Date,3),
					new SqlParameter("@ATTEN_ON_TIME", SqlDbType.Time,5),
					new SqlParameter("@ATTEN_OFF_TIME", SqlDbType.Time,5),
					new SqlParameter("@ATTEN_ON_STATE", SqlDbType.NVarChar,20),
					new SqlParameter("@ATTEN_OFF_STATE", SqlDbType.NVarChar,20),
					new SqlParameter("@ATTEN_LATE_MIN", SqlDbType.Int,4),
					new SqlParameter("@ATTEN_LEAVE_MIN", SqlDbType.Int,4),
					new SqlParameter("@ATTEN_EXTRA_MIN", SqlDbType.Int,4),
					new SqlParameter("@ATTEN_AWAY_DAY", SqlDbType.Float,8),
					new SqlParameter("@ATTEN_UNSWIPE_TIMES", SqlDbType.Int,4),
					new SqlParameter("@ATTEN_SWIPE_TIMES", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.STAFF_ID;
			parameters[1].Value = model.ATTEN_DATE;
			parameters[2].Value = model.ATTEN_ON_TIME;
			parameters[3].Value = model.ATTEN_OFF_TIME;
			parameters[4].Value = model.ATTEN_ON_STATE;
			parameters[5].Value = model.ATTEN_OFF_STATE;
			parameters[6].Value = model.ATTEN_LATE_MIN;
			parameters[7].Value = model.ATTEN_LEAVE_MIN;
			parameters[8].Value = model.ATTEN_EXTRA_MIN;
			parameters[9].Value = model.ATTEN_AWAY_DAY;
			parameters[10].Value = model.ATTEN_UNSWIPE_TIMES;
			parameters[11].Value = model.ATTEN_SWIPE_TIMES;
			parameters[12].Value = model.ID;

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
			strSql.Append("delete from SMT_ATTEN_REPORT ");
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
			strSql.Append("delete from SMT_ATTEN_REPORT ");
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
		public Maticsoft.Model.SMT_ATTEN_REPORT GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,STAFF_ID,ATTEN_DATE,ATTEN_ON_TIME,ATTEN_OFF_TIME,ATTEN_ON_STATE,ATTEN_OFF_STATE,ATTEN_LATE_MIN,ATTEN_LEAVE_MIN,ATTEN_EXTRA_MIN,ATTEN_AWAY_DAY,ATTEN_UNSWIPE_TIMES,ATTEN_SWIPE_TIMES from SMT_ATTEN_REPORT ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_ATTEN_REPORT model=new Maticsoft.Model.SMT_ATTEN_REPORT();
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
		public Maticsoft.Model.SMT_ATTEN_REPORT DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_ATTEN_REPORT model=new Maticsoft.Model.SMT_ATTEN_REPORT();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["STAFF_ID"]!=null && row["STAFF_ID"].ToString()!="")
				{
					model.STAFF_ID=decimal.Parse(row["STAFF_ID"].ToString());
				}
				if(row["ATTEN_DATE"]!=null && row["ATTEN_DATE"].ToString()!="")
				{
					model.ATTEN_DATE=DateTime.Parse(row["ATTEN_DATE"].ToString());
				}
				if(row["ATTEN_ON_TIME"]!=null && row["ATTEN_ON_TIME"].ToString()!="")
				{
					model.ATTEN_ON_TIME=DateTime.Parse(row["ATTEN_ON_TIME"].ToString());
				}
				if(row["ATTEN_OFF_TIME"]!=null && row["ATTEN_OFF_TIME"].ToString()!="")
				{
					model.ATTEN_OFF_TIME=DateTime.Parse(row["ATTEN_OFF_TIME"].ToString());
				}
				if(row["ATTEN_ON_STATE"]!=null)
				{
					model.ATTEN_ON_STATE=row["ATTEN_ON_STATE"].ToString();
				}
				if(row["ATTEN_OFF_STATE"]!=null)
				{
					model.ATTEN_OFF_STATE=row["ATTEN_OFF_STATE"].ToString();
				}
				if(row["ATTEN_LATE_MIN"]!=null && row["ATTEN_LATE_MIN"].ToString()!="")
				{
					model.ATTEN_LATE_MIN=int.Parse(row["ATTEN_LATE_MIN"].ToString());
				}
				if(row["ATTEN_LEAVE_MIN"]!=null && row["ATTEN_LEAVE_MIN"].ToString()!="")
				{
					model.ATTEN_LEAVE_MIN=int.Parse(row["ATTEN_LEAVE_MIN"].ToString());
				}
				if(row["ATTEN_EXTRA_MIN"]!=null && row["ATTEN_EXTRA_MIN"].ToString()!="")
				{
					model.ATTEN_EXTRA_MIN=int.Parse(row["ATTEN_EXTRA_MIN"].ToString());
				}
				if(row["ATTEN_AWAY_DAY"]!=null && row["ATTEN_AWAY_DAY"].ToString()!="")
				{
					model.ATTEN_AWAY_DAY=decimal.Parse(row["ATTEN_AWAY_DAY"].ToString());
				}
				if(row["ATTEN_UNSWIPE_TIMES"]!=null && row["ATTEN_UNSWIPE_TIMES"].ToString()!="")
				{
					model.ATTEN_UNSWIPE_TIMES=int.Parse(row["ATTEN_UNSWIPE_TIMES"].ToString());
				}
				if(row["ATTEN_SWIPE_TIMES"]!=null && row["ATTEN_SWIPE_TIMES"].ToString()!="")
				{
					model.ATTEN_SWIPE_TIMES=int.Parse(row["ATTEN_SWIPE_TIMES"].ToString());
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
			strSql.Append("select ID,STAFF_ID,ATTEN_DATE,ATTEN_ON_TIME,ATTEN_OFF_TIME,ATTEN_ON_STATE,ATTEN_OFF_STATE,ATTEN_LATE_MIN,ATTEN_LEAVE_MIN,ATTEN_EXTRA_MIN,ATTEN_AWAY_DAY,ATTEN_UNSWIPE_TIMES,ATTEN_SWIPE_TIMES ");
			strSql.Append(" FROM SMT_ATTEN_REPORT ");
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
			strSql.Append(" ID,STAFF_ID,ATTEN_DATE,ATTEN_ON_TIME,ATTEN_OFF_TIME,ATTEN_ON_STATE,ATTEN_OFF_STATE,ATTEN_LATE_MIN,ATTEN_LEAVE_MIN,ATTEN_EXTRA_MIN,ATTEN_AWAY_DAY,ATTEN_UNSWIPE_TIMES,ATTEN_SWIPE_TIMES ");
			strSql.Append(" FROM SMT_ATTEN_REPORT ");
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
			strSql.Append("select count(1) FROM SMT_ATTEN_REPORT ");
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
			strSql.Append(")AS Row, T.*  from SMT_ATTEN_REPORT T ");
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
			parameters[0].Value = "SMT_ATTEN_REPORT";
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

