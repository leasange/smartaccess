/**  版本信息模板在安装目录下，可自行修改。
* SMT_RECORDCAP_IMAGE.cs
*
* 功 能： N/A
* 类 名： SMT_RECORDCAP_IMAGE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/19 21:03:01   N/A    初版
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
	/// 数据访问类:SMT_RECORDCAP_IMAGE
	/// </summary>
	public partial class SMT_RECORDCAP_IMAGE
	{
		public SMT_RECORDCAP_IMAGE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_RECORDCAP_IMAGE");
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
		public decimal Add(Maticsoft.Model.SMT_RECORDCAP_IMAGE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_RECORDCAP_IMAGE(");
			strSql.Append("CTRL_SN,RECORD_INDEX,RECORD_TIME,CAP_TIME,CAP_RELATIVE_URL)");
			strSql.Append(" values (");
			strSql.Append("@CTRL_SN,@RECORD_INDEX,@RECORD_TIME,@CAP_TIME,@CAP_RELATIVE_URL)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CTRL_SN", SqlDbType.VarChar,100),
					new SqlParameter("@RECORD_INDEX", SqlDbType.Decimal,9),
					new SqlParameter("@RECORD_TIME", SqlDbType.DateTime),
					new SqlParameter("@CAP_TIME", SqlDbType.DateTime),
					new SqlParameter("@CAP_RELATIVE_URL", SqlDbType.NVarChar,256)};
			parameters[0].Value = model.CTRL_SN;
			parameters[1].Value = model.RECORD_INDEX;
			parameters[2].Value = model.RECORD_TIME;
			parameters[3].Value = model.CAP_TIME;
			parameters[4].Value = model.CAP_RELATIVE_URL;

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
		public bool Update(Maticsoft.Model.SMT_RECORDCAP_IMAGE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_RECORDCAP_IMAGE set ");
			strSql.Append("CTRL_SN=@CTRL_SN,");
			strSql.Append("RECORD_INDEX=@RECORD_INDEX,");
			strSql.Append("RECORD_TIME=@RECORD_TIME,");
			strSql.Append("CAP_TIME=@CAP_TIME,");
			strSql.Append("CAP_RELATIVE_URL=@CAP_RELATIVE_URL");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CTRL_SN", SqlDbType.VarChar,100),
					new SqlParameter("@RECORD_INDEX", SqlDbType.Decimal,9),
					new SqlParameter("@RECORD_TIME", SqlDbType.DateTime),
					new SqlParameter("@CAP_TIME", SqlDbType.DateTime),
					new SqlParameter("@CAP_RELATIVE_URL", SqlDbType.NVarChar,256),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.CTRL_SN;
			parameters[1].Value = model.RECORD_INDEX;
			parameters[2].Value = model.RECORD_TIME;
			parameters[3].Value = model.CAP_TIME;
			parameters[4].Value = model.CAP_RELATIVE_URL;
			parameters[5].Value = model.ID;

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
			strSql.Append("delete from SMT_RECORDCAP_IMAGE ");
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
			strSql.Append("delete from SMT_RECORDCAP_IMAGE ");
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
		public Maticsoft.Model.SMT_RECORDCAP_IMAGE GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CTRL_SN,RECORD_INDEX,RECORD_TIME,CAP_TIME,CAP_RELATIVE_URL from SMT_RECORDCAP_IMAGE ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_RECORDCAP_IMAGE model=new Maticsoft.Model.SMT_RECORDCAP_IMAGE();
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
		public Maticsoft.Model.SMT_RECORDCAP_IMAGE DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_RECORDCAP_IMAGE model=new Maticsoft.Model.SMT_RECORDCAP_IMAGE();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["CTRL_SN"]!=null)
				{
					model.CTRL_SN=row["CTRL_SN"].ToString();
				}
				if(row["RECORD_INDEX"]!=null && row["RECORD_INDEX"].ToString()!="")
				{
					model.RECORD_INDEX=decimal.Parse(row["RECORD_INDEX"].ToString());
				}
				if(row["RECORD_TIME"]!=null && row["RECORD_TIME"].ToString()!="")
				{
					model.RECORD_TIME=DateTime.Parse(row["RECORD_TIME"].ToString());
				}
				if(row["CAP_TIME"]!=null && row["CAP_TIME"].ToString()!="")
				{
					model.CAP_TIME=DateTime.Parse(row["CAP_TIME"].ToString());
				}
				if(row["CAP_RELATIVE_URL"]!=null)
				{
					model.CAP_RELATIVE_URL=row["CAP_RELATIVE_URL"].ToString();
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
			strSql.Append("select ID,CTRL_SN,RECORD_INDEX,RECORD_TIME,CAP_TIME,CAP_RELATIVE_URL ");
			strSql.Append(" FROM SMT_RECORDCAP_IMAGE ");
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
			strSql.Append(" ID,CTRL_SN,RECORD_INDEX,RECORD_TIME,CAP_TIME,CAP_RELATIVE_URL ");
			strSql.Append(" FROM SMT_RECORDCAP_IMAGE ");
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
			strSql.Append("select count(1) FROM SMT_RECORDCAP_IMAGE ");
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
			strSql.Append(")AS Row, T.*  from SMT_RECORDCAP_IMAGE T ");
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
			parameters[0].Value = "SMT_RECORDCAP_IMAGE";
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

