/**  版本信息模板在安装目录下，可自行修改。
* SMT_ALARM_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_ALARM_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/17 22:15:25   N/A    初版
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
	/// 数据访问类:SMT_ALARM_INFO
	/// </summary>
	public partial class SMT_ALARM_INFO
	{
		public SMT_ALARM_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_ALARM_INFO");
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
		public decimal Add(Maticsoft.Model.SMT_ALARM_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_ALARM_INFO(");
			strSql.Append("ALARM_TYPE,ALARM_NAME,ALARM_CONTENT,ALARM_TIME,RECORD_ID,CARD_NO,CTRLR_DOOR_INDEX,CTRLR_ID,DOOR_ID,STAFF_ID)");
			strSql.Append(" values (");
			strSql.Append("@ALARM_TYPE,@ALARM_NAME,@ALARM_CONTENT,@ALARM_TIME,@RECORD_ID,@CARD_NO,@CTRLR_DOOR_INDEX,@CTRLR_ID,@DOOR_ID,@STAFF_ID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ALARM_TYPE", SqlDbType.TinyInt,1),
					new SqlParameter("@ALARM_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@ALARM_CONTENT", SqlDbType.NVarChar,200),
					new SqlParameter("@ALARM_TIME", SqlDbType.DateTime),
					new SqlParameter("@RECORD_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CARD_NO", SqlDbType.VarChar,100),
					new SqlParameter("@CTRLR_DOOR_INDEX", SqlDbType.TinyInt,1),
					new SqlParameter("@CTRLR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ALARM_TYPE;
			parameters[1].Value = model.ALARM_NAME;
			parameters[2].Value = model.ALARM_CONTENT;
			parameters[3].Value = model.ALARM_TIME;
			parameters[4].Value = model.RECORD_ID;
			parameters[5].Value = model.CARD_NO;
			parameters[6].Value = model.CTRLR_DOOR_INDEX;
			parameters[7].Value = model.CTRLR_ID;
			parameters[8].Value = model.DOOR_ID;
			parameters[9].Value = model.STAFF_ID;

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
		public bool Update(Maticsoft.Model.SMT_ALARM_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_ALARM_INFO set ");
			strSql.Append("ALARM_TYPE=@ALARM_TYPE,");
			strSql.Append("ALARM_NAME=@ALARM_NAME,");
			strSql.Append("ALARM_CONTENT=@ALARM_CONTENT,");
			strSql.Append("ALARM_TIME=@ALARM_TIME,");
			strSql.Append("RECORD_ID=@RECORD_ID,");
			strSql.Append("CARD_NO=@CARD_NO,");
			strSql.Append("CTRLR_DOOR_INDEX=@CTRLR_DOOR_INDEX,");
			strSql.Append("CTRLR_ID=@CTRLR_ID,");
			strSql.Append("DOOR_ID=@DOOR_ID,");
			strSql.Append("STAFF_ID=@STAFF_ID");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ALARM_TYPE", SqlDbType.TinyInt,1),
					new SqlParameter("@ALARM_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@ALARM_CONTENT", SqlDbType.NVarChar,200),
					new SqlParameter("@ALARM_TIME", SqlDbType.DateTime),
					new SqlParameter("@RECORD_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CARD_NO", SqlDbType.VarChar,100),
					new SqlParameter("@CTRLR_DOOR_INDEX", SqlDbType.TinyInt,1),
					new SqlParameter("@CTRLR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ALARM_TYPE;
			parameters[1].Value = model.ALARM_NAME;
			parameters[2].Value = model.ALARM_CONTENT;
			parameters[3].Value = model.ALARM_TIME;
			parameters[4].Value = model.RECORD_ID;
			parameters[5].Value = model.CARD_NO;
			parameters[6].Value = model.CTRLR_DOOR_INDEX;
			parameters[7].Value = model.CTRLR_ID;
			parameters[8].Value = model.DOOR_ID;
			parameters[9].Value = model.STAFF_ID;
			parameters[10].Value = model.ID;

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
			strSql.Append("delete from SMT_ALARM_INFO ");
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
			strSql.Append("delete from SMT_ALARM_INFO ");
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
		public Maticsoft.Model.SMT_ALARM_INFO GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ALARM_TYPE,ALARM_NAME,ALARM_CONTENT,ALARM_TIME,RECORD_ID,CARD_NO,CTRLR_DOOR_INDEX,CTRLR_ID,DOOR_ID,STAFF_ID from SMT_ALARM_INFO ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_ALARM_INFO model=new Maticsoft.Model.SMT_ALARM_INFO();
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
		public Maticsoft.Model.SMT_ALARM_INFO DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_ALARM_INFO model=new Maticsoft.Model.SMT_ALARM_INFO();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["ALARM_TYPE"]!=null && row["ALARM_TYPE"].ToString()!="")
				{
					model.ALARM_TYPE=int.Parse(row["ALARM_TYPE"].ToString());
				}
				if(row["ALARM_NAME"]!=null)
				{
					model.ALARM_NAME=row["ALARM_NAME"].ToString();
				}
				if(row["ALARM_CONTENT"]!=null)
				{
					model.ALARM_CONTENT=row["ALARM_CONTENT"].ToString();
				}
				if(row["ALARM_TIME"]!=null && row["ALARM_TIME"].ToString()!="")
				{
					model.ALARM_TIME=DateTime.Parse(row["ALARM_TIME"].ToString());
				}
				if(row["RECORD_ID"]!=null && row["RECORD_ID"].ToString()!="")
				{
					model.RECORD_ID=decimal.Parse(row["RECORD_ID"].ToString());
				}
				if(row["CARD_NO"]!=null)
				{
					model.CARD_NO=row["CARD_NO"].ToString();
				}
				if(row["CTRLR_DOOR_INDEX"]!=null && row["CTRLR_DOOR_INDEX"].ToString()!="")
				{
					model.CTRLR_DOOR_INDEX=int.Parse(row["CTRLR_DOOR_INDEX"].ToString());
				}
				if(row["CTRLR_ID"]!=null && row["CTRLR_ID"].ToString()!="")
				{
					model.CTRLR_ID=decimal.Parse(row["CTRLR_ID"].ToString());
				}
				if(row["DOOR_ID"]!=null && row["DOOR_ID"].ToString()!="")
				{
					model.DOOR_ID=decimal.Parse(row["DOOR_ID"].ToString());
				}
				if(row["STAFF_ID"]!=null && row["STAFF_ID"].ToString()!="")
				{
					model.STAFF_ID=decimal.Parse(row["STAFF_ID"].ToString());
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
			strSql.Append("select ID,ALARM_TYPE,ALARM_NAME,ALARM_CONTENT,ALARM_TIME,RECORD_ID,CARD_NO,CTRLR_DOOR_INDEX,CTRLR_ID,DOOR_ID,STAFF_ID ");
			strSql.Append(" FROM SMT_ALARM_INFO ");
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
			strSql.Append(" ID,ALARM_TYPE,ALARM_NAME,ALARM_CONTENT,ALARM_TIME,RECORD_ID,CARD_NO,CTRLR_DOOR_INDEX,CTRLR_ID,DOOR_ID,STAFF_ID ");
			strSql.Append(" FROM SMT_ALARM_INFO ");
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
			strSql.Append("select count(1) FROM SMT_ALARM_INFO ");
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
			strSql.Append(")AS Row, T.*  from SMT_ALARM_INFO T ");
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
			parameters[0].Value = "SMT_ALARM_INFO";
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

