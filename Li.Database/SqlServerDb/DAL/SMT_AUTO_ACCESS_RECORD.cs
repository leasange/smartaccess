/**  版本信息模板在安装目录下，可自行修改。
* SMT_AUTO_ACCESS_RECORD.cs
*
* 功 能： N/A
* 类 名： SMT_AUTO_ACCESS_RECORD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/11/9 16:02:25   N/A    初版
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
	/// 数据访问类:SMT_AUTO_ACCESS_RECORD
	/// </summary>
	public partial class SMT_AUTO_ACCESS_RECORD
	{
		public SMT_AUTO_ACCESS_RECORD()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_AUTO_ACCESS_RECORD");
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
		public decimal Add(Maticsoft.Model.SMT_AUTO_ACCESS_RECORD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_AUTO_ACCESS_RECORD(");
            strSql.Append("ACC_FROM_SYS,ACC_APP_ID,ACC_APP_NAME,ACC_STAFF_ID,ACC_DOOR_ID,ACC_START_TIME,ACC_END_TIME,ACC_ADD_TIME,ACC_STATE_TIME,ACC_STATE)");
			strSql.Append(" values (");
            strSql.Append("@ACC_FROM_SYS,@ACC_APP_ID,@ACC_APP_NAME,@ACC_STAFF_ID,@ACC_DOOR_ID,@ACC_START_TIME,@ACC_END_TIME,@ACC_ADD_TIME,@ACC_STATE_TIME,@ACC_STATE)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ACC_FROM_SYS", SqlDbType.NVarChar,50),
					new SqlParameter("@ACC_APP_ID", SqlDbType.NVarChar,100),
                    new SqlParameter("@ACC_APP_NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@ACC_STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ACC_DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ACC_START_TIME", SqlDbType.DateTime),
					new SqlParameter("@ACC_END_TIME", SqlDbType.DateTime),
					new SqlParameter("@ACC_ADD_TIME", SqlDbType.DateTime),
					new SqlParameter("@ACC_STATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@ACC_STATE", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.ACC_FROM_SYS;
			parameters[1].Value = model.ACC_APP_ID;
            parameters[2].Value = model.ACC_APP_NAME;
			parameters[3].Value = model.ACC_STAFF_ID;
			parameters[4].Value = model.ACC_DOOR_ID;
			parameters[5].Value = model.ACC_START_TIME;
			parameters[6].Value = model.ACC_END_TIME;
			parameters[7].Value = model.ACC_ADD_TIME;
			parameters[8].Value = model.ACC_STATE_TIME;
			parameters[9].Value = model.ACC_STATE;

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
		public bool Update(Maticsoft.Model.SMT_AUTO_ACCESS_RECORD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_AUTO_ACCESS_RECORD set ");
			strSql.Append("ACC_FROM_SYS=@ACC_FROM_SYS,");
			strSql.Append("ACC_APP_ID=@ACC_APP_ID,");
            strSql.Append("ACC_APP_NAME=@ACC_APP_NAME,");
			strSql.Append("ACC_STAFF_ID=@ACC_STAFF_ID,");
			strSql.Append("ACC_DOOR_ID=@ACC_DOOR_ID,");
			strSql.Append("ACC_START_TIME=@ACC_START_TIME,");
			strSql.Append("ACC_END_TIME=@ACC_END_TIME,");
			strSql.Append("ACC_ADD_TIME=@ACC_ADD_TIME,");
			strSql.Append("ACC_STATE_TIME=@ACC_STATE_TIME,");
			strSql.Append("ACC_STATE=@ACC_STATE");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ACC_FROM_SYS", SqlDbType.NVarChar,50),
					new SqlParameter("@ACC_APP_ID", SqlDbType.NVarChar,100),
                    new SqlParameter("@ACC_APP_NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@ACC_STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ACC_DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ACC_START_TIME", SqlDbType.DateTime),
					new SqlParameter("@ACC_END_TIME", SqlDbType.DateTime),
					new SqlParameter("@ACC_ADD_TIME", SqlDbType.DateTime),
					new SqlParameter("@ACC_STATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@ACC_STATE", SqlDbType.TinyInt,1),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ACC_FROM_SYS;
			parameters[1].Value = model.ACC_APP_ID;
            parameters[2].Value = model.ACC_APP_NAME;
			parameters[3].Value = model.ACC_STAFF_ID;
			parameters[4].Value = model.ACC_DOOR_ID;
			parameters[5].Value = model.ACC_START_TIME;
			parameters[6].Value = model.ACC_END_TIME;
			parameters[7].Value = model.ACC_ADD_TIME;
			parameters[8].Value = model.ACC_STATE_TIME;
			parameters[9].Value = model.ACC_STATE;
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
			strSql.Append("delete from SMT_AUTO_ACCESS_RECORD ");
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
			strSql.Append("delete from SMT_AUTO_ACCESS_RECORD ");
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
		public Maticsoft.Model.SMT_AUTO_ACCESS_RECORD GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ID,ACC_FROM_SYS,ACC_APP_ID,ACC_APP_NAME,ACC_STAFF_ID,ACC_DOOR_ID,ACC_START_TIME,ACC_END_TIME,ACC_ADD_TIME,ACC_STATE_TIME,ACC_STATE from SMT_AUTO_ACCESS_RECORD ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_AUTO_ACCESS_RECORD model=new Maticsoft.Model.SMT_AUTO_ACCESS_RECORD();
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
		public Maticsoft.Model.SMT_AUTO_ACCESS_RECORD DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_AUTO_ACCESS_RECORD model=new Maticsoft.Model.SMT_AUTO_ACCESS_RECORD();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["ACC_FROM_SYS"]!=null)
				{
					model.ACC_FROM_SYS=row["ACC_FROM_SYS"].ToString();
				}
				if(row["ACC_APP_ID"]!=null)
				{
					model.ACC_APP_ID=row["ACC_APP_ID"].ToString();
				}
                if (row["ACC_APP_NAME"] != null)
                {
                    model.ACC_APP_NAME = row["ACC_APP_NAME"].ToString();
                }
				if(row["ACC_STAFF_ID"]!=null && row["ACC_STAFF_ID"].ToString()!="")
				{
					model.ACC_STAFF_ID=decimal.Parse(row["ACC_STAFF_ID"].ToString());
				}
				if(row["ACC_DOOR_ID"]!=null && row["ACC_DOOR_ID"].ToString()!="")
				{
					model.ACC_DOOR_ID=decimal.Parse(row["ACC_DOOR_ID"].ToString());
				}
				if(row["ACC_START_TIME"]!=null && row["ACC_START_TIME"].ToString()!="")
				{
					model.ACC_START_TIME=DateTime.Parse(row["ACC_START_TIME"].ToString());
				}
				if(row["ACC_END_TIME"]!=null && row["ACC_END_TIME"].ToString()!="")
				{
					model.ACC_END_TIME=DateTime.Parse(row["ACC_END_TIME"].ToString());
				}
				if(row["ACC_ADD_TIME"]!=null && row["ACC_ADD_TIME"].ToString()!="")
				{
					model.ACC_ADD_TIME=DateTime.Parse(row["ACC_ADD_TIME"].ToString());
				}
				if(row["ACC_STATE_TIME"]!=null && row["ACC_STATE_TIME"].ToString()!="")
				{
					model.ACC_STATE_TIME=DateTime.Parse(row["ACC_STATE_TIME"].ToString());
				}
				if(row["ACC_STATE"]!=null && row["ACC_STATE"].ToString()!="")
				{
					model.ACC_STATE=int.Parse(row["ACC_STATE"].ToString());
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
            strSql.Append("select ID,ACC_FROM_SYS,ACC_APP_ID,ACC_APP_NAME,ACC_STAFF_ID,ACC_DOOR_ID,ACC_START_TIME,ACC_END_TIME,ACC_ADD_TIME,ACC_STATE_TIME,ACC_STATE ");
			strSql.Append(" FROM SMT_AUTO_ACCESS_RECORD ");
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
            strSql.Append(" ID,ACC_FROM_SYS,ACC_APP_ID,ACC_APP_NAME,ACC_STAFF_ID,ACC_DOOR_ID,ACC_START_TIME,ACC_END_TIME,ACC_ADD_TIME,ACC_STATE_TIME,ACC_STATE ");
			strSql.Append(" FROM SMT_AUTO_ACCESS_RECORD ");
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
			strSql.Append("select count(1) FROM SMT_AUTO_ACCESS_RECORD ");
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
			strSql.Append(")AS Row, T.*  from SMT_AUTO_ACCESS_RECORD T ");
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
			parameters[0].Value = "SMT_AUTO_ACCESS_RECORD";
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

