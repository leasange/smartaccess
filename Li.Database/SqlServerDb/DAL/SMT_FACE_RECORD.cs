/**  版本信息模板在安装目录下，可自行修改。
* SMT_FACE_RECORD.cs
*
* 功 能： N/A
* 类 名： SMT_FACE_RECORD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/8/30 23:24:54   N/A    初版
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
	/// 数据访问类:SMT_FACE_RECORD
	/// </summary>
	public partial class SMT_FACE_RECORD
	{
		public SMT_FACE_RECORD()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_FACE_RECORD");
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
		public decimal Add(Maticsoft.Model.SMT_FACE_RECORD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_FACE_RECORD(");
			strSql.Append("FACEDEV_ID,FREC_SRC_ID,FREC_TIME,FREC_STAFF_NAME,FREC_VIDEO_IMAGE,FREC_FACE_IMAGE,FREC_FACE_LEVEL,FREC_AUTHORITY,FREC_STAFF_NO,FREC_STAFF_TYPE,FREC_PARAM3,FREC_PARAM4,FREC_STAFF_ID)");
			strSql.Append(" values (");
			strSql.Append("@FACEDEV_ID,@FREC_SRC_ID,@FREC_TIME,@FREC_STAFF_NAME,@FREC_VIDEO_IMAGE,@FREC_FACE_IMAGE,@FREC_FACE_LEVEL,@FREC_AUTHORITY,@FREC_STAFF_NO,@FREC_STAFF_TYPE,@FREC_PARAM3,@FREC_PARAM4,@FREC_STAFF_ID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FACEDEV_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FREC_SRC_ID", SqlDbType.NVarChar,300),
					new SqlParameter("@FREC_TIME", SqlDbType.DateTime),
					new SqlParameter("@FREC_STAFF_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@FREC_VIDEO_IMAGE", SqlDbType.Image),
					new SqlParameter("@FREC_FACE_IMAGE", SqlDbType.Image),
					new SqlParameter("@FREC_FACE_LEVEL", SqlDbType.Decimal,5),
					new SqlParameter("@FREC_AUTHORITY", SqlDbType.NVarChar,8),
					new SqlParameter("@FREC_STAFF_NO", SqlDbType.NVarChar,80),
					new SqlParameter("@FREC_STAFF_TYPE", SqlDbType.NVarChar,80),
					new SqlParameter("@FREC_PARAM3", SqlDbType.NVarChar,80),
					new SqlParameter("@FREC_PARAM4", SqlDbType.NVarChar,80),
					new SqlParameter("@FREC_STAFF_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.FACEDEV_ID;
			parameters[1].Value = model.FREC_SRC_ID;
			parameters[2].Value = model.FREC_TIME;
			parameters[3].Value = model.FREC_STAFF_NAME;
			parameters[4].Value = model.FREC_VIDEO_IMAGE;
			parameters[5].Value = model.FREC_FACE_IMAGE;
			parameters[6].Value = model.FREC_FACE_LEVEL;
			parameters[7].Value = model.FREC_AUTHORITY;
			parameters[8].Value = model.FREC_STAFF_NO;
			parameters[9].Value = model.FREC_STAFF_TYPE;
			parameters[10].Value = model.FREC_PARAM3;
			parameters[11].Value = model.FREC_PARAM4;
			parameters[12].Value = model.FREC_STAFF_ID;

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
		public bool Update(Maticsoft.Model.SMT_FACE_RECORD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_FACE_RECORD set ");
			strSql.Append("FACEDEV_ID=@FACEDEV_ID,");
			strSql.Append("FREC_SRC_ID=@FREC_SRC_ID,");
			strSql.Append("FREC_TIME=@FREC_TIME,");
			strSql.Append("FREC_STAFF_NAME=@FREC_STAFF_NAME,");
			strSql.Append("FREC_VIDEO_IMAGE=@FREC_VIDEO_IMAGE,");
			strSql.Append("FREC_FACE_IMAGE=@FREC_FACE_IMAGE,");
			strSql.Append("FREC_FACE_LEVEL=@FREC_FACE_LEVEL,");
			strSql.Append("FREC_AUTHORITY=@FREC_AUTHORITY,");
			strSql.Append("FREC_STAFF_NO=@FREC_STAFF_NO,");
			strSql.Append("FREC_STAFF_TYPE=@FREC_STAFF_TYPE,");
			strSql.Append("FREC_PARAM3=@FREC_PARAM3,");
			strSql.Append("FREC_PARAM4=@FREC_PARAM4,");
			strSql.Append("FREC_STAFF_ID=@FREC_STAFF_ID");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@FACEDEV_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FREC_SRC_ID", SqlDbType.NVarChar,300),
					new SqlParameter("@FREC_TIME", SqlDbType.DateTime),
					new SqlParameter("@FREC_STAFF_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@FREC_VIDEO_IMAGE", SqlDbType.Image),
					new SqlParameter("@FREC_FACE_IMAGE", SqlDbType.Image),
					new SqlParameter("@FREC_FACE_LEVEL", SqlDbType.Decimal,5),
					new SqlParameter("@FREC_AUTHORITY", SqlDbType.NVarChar,8),
					new SqlParameter("@FREC_STAFF_NO", SqlDbType.NVarChar,80),
					new SqlParameter("@FREC_STAFF_TYPE", SqlDbType.NVarChar,80),
					new SqlParameter("@FREC_PARAM3", SqlDbType.NVarChar,80),
					new SqlParameter("@FREC_PARAM4", SqlDbType.NVarChar,80),
					new SqlParameter("@FREC_STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.FACEDEV_ID;
			parameters[1].Value = model.FREC_SRC_ID;
			parameters[2].Value = model.FREC_TIME;
			parameters[3].Value = model.FREC_STAFF_NAME;
			parameters[4].Value = model.FREC_VIDEO_IMAGE;
			parameters[5].Value = model.FREC_FACE_IMAGE;
			parameters[6].Value = model.FREC_FACE_LEVEL;
			parameters[7].Value = model.FREC_AUTHORITY;
			parameters[8].Value = model.FREC_STAFF_NO;
			parameters[9].Value = model.FREC_STAFF_TYPE;
			parameters[10].Value = model.FREC_PARAM3;
			parameters[11].Value = model.FREC_PARAM4;
			parameters[12].Value = model.FREC_STAFF_ID;
			parameters[13].Value = model.ID;

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
			strSql.Append("delete from SMT_FACE_RECORD ");
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
			strSql.Append("delete from SMT_FACE_RECORD ");
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
		public Maticsoft.Model.SMT_FACE_RECORD GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,FACEDEV_ID,FREC_SRC_ID,FREC_TIME,FREC_STAFF_NAME,FREC_VIDEO_IMAGE,FREC_FACE_IMAGE,FREC_FACE_LEVEL,FREC_AUTHORITY,FREC_STAFF_NO,FREC_STAFF_TYPE,FREC_PARAM3,FREC_PARAM4,FREC_STAFF_ID from SMT_FACE_RECORD ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_FACE_RECORD model=new Maticsoft.Model.SMT_FACE_RECORD();
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
		public Maticsoft.Model.SMT_FACE_RECORD DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_FACE_RECORD model=new Maticsoft.Model.SMT_FACE_RECORD();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["FACEDEV_ID"]!=null && row["FACEDEV_ID"].ToString()!="")
				{
					model.FACEDEV_ID=decimal.Parse(row["FACEDEV_ID"].ToString());
				}
				if(row["FREC_SRC_ID"]!=null)
				{
					model.FREC_SRC_ID=row["FREC_SRC_ID"].ToString();
				}
				if(row["FREC_TIME"]!=null && row["FREC_TIME"].ToString()!="")
				{
					model.FREC_TIME=DateTime.Parse(row["FREC_TIME"].ToString());
				}
				if(row["FREC_STAFF_NAME"]!=null)
				{
					model.FREC_STAFF_NAME=row["FREC_STAFF_NAME"].ToString();
				}
				if(row["FREC_VIDEO_IMAGE"]!=null && row["FREC_VIDEO_IMAGE"].ToString()!="")
				{
					model.FREC_VIDEO_IMAGE=(byte[])row["FREC_VIDEO_IMAGE"];
				}
				if(row["FREC_FACE_IMAGE"]!=null && row["FREC_FACE_IMAGE"].ToString()!="")
				{
					model.FREC_FACE_IMAGE=(byte[])row["FREC_FACE_IMAGE"];
				}
				if(row["FREC_FACE_LEVEL"]!=null && row["FREC_FACE_LEVEL"].ToString()!="")
				{
					model.FREC_FACE_LEVEL=decimal.Parse(row["FREC_FACE_LEVEL"].ToString());
				}
				if(row["FREC_AUTHORITY"]!=null)
				{
					model.FREC_AUTHORITY=row["FREC_AUTHORITY"].ToString();
				}
				if(row["FREC_STAFF_NO"]!=null)
				{
					model.FREC_STAFF_NO=row["FREC_STAFF_NO"].ToString();
				}
				if(row["FREC_STAFF_TYPE"]!=null)
				{
					model.FREC_STAFF_TYPE=row["FREC_STAFF_TYPE"].ToString();
				}
				if(row["FREC_PARAM3"]!=null)
				{
					model.FREC_PARAM3=row["FREC_PARAM3"].ToString();
				}
				if(row["FREC_PARAM4"]!=null)
				{
					model.FREC_PARAM4=row["FREC_PARAM4"].ToString();
				}
				if(row["FREC_STAFF_ID"]!=null && row["FREC_STAFF_ID"].ToString()!="")
				{
					model.FREC_STAFF_ID=decimal.Parse(row["FREC_STAFF_ID"].ToString());
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
			strSql.Append("select ID,FACEDEV_ID,FREC_SRC_ID,FREC_TIME,FREC_STAFF_NAME,FREC_VIDEO_IMAGE,FREC_FACE_IMAGE,FREC_FACE_LEVEL,FREC_AUTHORITY,FREC_STAFF_NO,FREC_STAFF_TYPE,FREC_PARAM3,FREC_PARAM4,FREC_STAFF_ID ");
			strSql.Append(" FROM SMT_FACE_RECORD ");
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
			strSql.Append(" ID,FACEDEV_ID,FREC_SRC_ID,FREC_TIME,FREC_STAFF_NAME,FREC_VIDEO_IMAGE,FREC_FACE_IMAGE,FREC_FACE_LEVEL,FREC_AUTHORITY,FREC_STAFF_NO,FREC_STAFF_TYPE,FREC_PARAM3,FREC_PARAM4,FREC_STAFF_ID ");
			strSql.Append(" FROM SMT_FACE_RECORD ");
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
			strSql.Append("select count(1) FROM SMT_FACE_RECORD ");
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
			strSql.Append(")AS Row, T.*  from SMT_FACE_RECORD T ");
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
			parameters[0].Value = "SMT_FACE_RECORD";
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

