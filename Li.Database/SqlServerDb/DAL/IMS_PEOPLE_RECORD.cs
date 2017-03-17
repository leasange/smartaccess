/**  版本信息模板在安装目录下，可自行修改。
* IMS_PEOPLE_RECORD.cs
*
* 功 能： N/A
* 类 名： IMS_PEOPLE_RECORD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/16 23:12:00   N/A    初版
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
	/// 数据访问类:IMS_PEOPLE_RECORD
	/// </summary>
	public partial class IMS_PEOPLE_RECORD
	{
		public IMS_PEOPLE_RECORD()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from IMS_PEOPLE_RECORD");
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
		public decimal Add(Maticsoft.Model.IMS_PEOPLE_RECORD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into IMS_PEOPLE_RECORD(");
			strSql.Append("CardType,CardNo,Name,Depart,AccessChannel,ThroughForward,ThroughTime,ThroughResult,CapturePic,OriginPic,CompareResult,Similarity,FacePosition)");
			strSql.Append(" values (");
			strSql.Append("@CardType,@CardNo,@Name,@Depart,@AccessChannel,@ThroughForward,@ThroughTime,@ThroughResult,@CapturePic,@OriginPic,@CompareResult,@Similarity,@FacePosition)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CardType", SqlDbType.TinyInt,1),
					new SqlParameter("@CardNo", SqlDbType.VarChar,100),
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Depart", SqlDbType.NVarChar,100),
					new SqlParameter("@AccessChannel", SqlDbType.NVarChar,100),
					new SqlParameter("@ThroughForward", SqlDbType.TinyInt,1),
					new SqlParameter("@ThroughTime", SqlDbType.DateTime),
					new SqlParameter("@ThroughResult", SqlDbType.TinyInt,1),
					new SqlParameter("@CapturePic", SqlDbType.VarChar,500),
					new SqlParameter("@OriginPic", SqlDbType.VarChar,500),
					new SqlParameter("@CompareResult", SqlDbType.TinyInt,1),
					new SqlParameter("@Similarity", SqlDbType.Decimal,9),
					new SqlParameter("@FacePosition", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.CardType;
			parameters[1].Value = model.CardNo;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Depart;
			parameters[4].Value = model.AccessChannel;
			parameters[5].Value = model.ThroughForward;
			parameters[6].Value = model.ThroughTime;
			parameters[7].Value = model.ThroughResult;
			parameters[8].Value = model.CapturePic;
			parameters[9].Value = model.OriginPic;
			parameters[10].Value = model.CompareResult;
			parameters[11].Value = model.Similarity;
			parameters[12].Value = model.FacePosition;

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
		public bool Update(Maticsoft.Model.IMS_PEOPLE_RECORD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IMS_PEOPLE_RECORD set ");
			strSql.Append("CardType=@CardType,");
			strSql.Append("CardNo=@CardNo,");
			strSql.Append("Name=@Name,");
			strSql.Append("Depart=@Depart,");
			strSql.Append("AccessChannel=@AccessChannel,");
			strSql.Append("ThroughForward=@ThroughForward,");
			strSql.Append("ThroughTime=@ThroughTime,");
			strSql.Append("ThroughResult=@ThroughResult,");
			strSql.Append("CapturePic=@CapturePic,");
			strSql.Append("OriginPic=@OriginPic,");
			strSql.Append("CompareResult=@CompareResult,");
			strSql.Append("Similarity=@Similarity,");
			strSql.Append("FacePosition=@FacePosition");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CardType", SqlDbType.TinyInt,1),
					new SqlParameter("@CardNo", SqlDbType.VarChar,100),
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Depart", SqlDbType.NVarChar,100),
					new SqlParameter("@AccessChannel", SqlDbType.NVarChar,100),
					new SqlParameter("@ThroughForward", SqlDbType.TinyInt,1),
					new SqlParameter("@ThroughTime", SqlDbType.DateTime),
					new SqlParameter("@ThroughResult", SqlDbType.TinyInt,1),
					new SqlParameter("@CapturePic", SqlDbType.VarChar,500),
					new SqlParameter("@OriginPic", SqlDbType.VarChar,500),
					new SqlParameter("@CompareResult", SqlDbType.TinyInt,1),
					new SqlParameter("@Similarity", SqlDbType.Decimal,9),
					new SqlParameter("@FacePosition", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.CardType;
			parameters[1].Value = model.CardNo;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Depart;
			parameters[4].Value = model.AccessChannel;
			parameters[5].Value = model.ThroughForward;
			parameters[6].Value = model.ThroughTime;
			parameters[7].Value = model.ThroughResult;
			parameters[8].Value = model.CapturePic;
			parameters[9].Value = model.OriginPic;
			parameters[10].Value = model.CompareResult;
			parameters[11].Value = model.Similarity;
			parameters[12].Value = model.FacePosition;
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
			strSql.Append("delete from IMS_PEOPLE_RECORD ");
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
			strSql.Append("delete from IMS_PEOPLE_RECORD ");
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
		public Maticsoft.Model.IMS_PEOPLE_RECORD GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CardType,CardNo,Name,Depart,AccessChannel,ThroughForward,ThroughTime,ThroughResult,CapturePic,OriginPic,CompareResult,Similarity,FacePosition from IMS_PEOPLE_RECORD ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.IMS_PEOPLE_RECORD model=new Maticsoft.Model.IMS_PEOPLE_RECORD();
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
		public Maticsoft.Model.IMS_PEOPLE_RECORD DataRowToModel(DataRow row)
		{
			Maticsoft.Model.IMS_PEOPLE_RECORD model=new Maticsoft.Model.IMS_PEOPLE_RECORD();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["CardType"]!=null && row["CardType"].ToString()!="")
				{
					model.CardType=int.Parse(row["CardType"].ToString());
				}
				if(row["CardNo"]!=null)
				{
					model.CardNo=row["CardNo"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Depart"]!=null)
				{
					model.Depart=row["Depart"].ToString();
				}
				if(row["AccessChannel"]!=null)
				{
					model.AccessChannel=row["AccessChannel"].ToString();
				}
				if(row["ThroughForward"]!=null && row["ThroughForward"].ToString()!="")
				{
					model.ThroughForward=int.Parse(row["ThroughForward"].ToString());
				}
				if(row["ThroughTime"]!=null && row["ThroughTime"].ToString()!="")
				{
					model.ThroughTime=DateTime.Parse(row["ThroughTime"].ToString());
				}
				if(row["ThroughResult"]!=null && row["ThroughResult"].ToString()!="")
				{
					model.ThroughResult=int.Parse(row["ThroughResult"].ToString());
				}
				if(row["CapturePic"]!=null)
				{
					model.CapturePic=row["CapturePic"].ToString();
				}
				if(row["OriginPic"]!=null)
				{
					model.OriginPic=row["OriginPic"].ToString();
				}
				if(row["CompareResult"]!=null && row["CompareResult"].ToString()!="")
				{
					model.CompareResult=int.Parse(row["CompareResult"].ToString());
				}
				if(row["Similarity"]!=null && row["Similarity"].ToString()!="")
				{
					model.Similarity=decimal.Parse(row["Similarity"].ToString());
				}
				if(row["FacePosition"]!=null)
				{
					model.FacePosition=row["FacePosition"].ToString();
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
			strSql.Append("select ID,CardType,CardNo,Name,Depart,AccessChannel,ThroughForward,ThroughTime,ThroughResult,CapturePic,OriginPic,CompareResult,Similarity,FacePosition ");
			strSql.Append(" FROM IMS_PEOPLE_RECORD ");
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
			strSql.Append(" ID,CardType,CardNo,Name,Depart,AccessChannel,ThroughForward,ThroughTime,ThroughResult,CapturePic,OriginPic,CompareResult,Similarity,FacePosition ");
			strSql.Append(" FROM IMS_PEOPLE_RECORD ");
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
			strSql.Append("select count(1) FROM IMS_PEOPLE_RECORD ");
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
			strSql.Append(")AS Row, T.*  from IMS_PEOPLE_RECORD T ");
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
			parameters[0].Value = "IMS_PEOPLE_RECORD";
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

