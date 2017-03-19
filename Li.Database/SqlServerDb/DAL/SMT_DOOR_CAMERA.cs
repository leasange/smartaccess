/**  版本信息模板在安装目录下，可自行修改。
* SMT_DOOR_CAMERA.cs
*
* 功 能： N/A
* 类 名： SMT_DOOR_CAMERA
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
	/// 数据访问类:SMT_DOOR_CAMERA
	/// </summary>
	public partial class SMT_DOOR_CAMERA
	{
		public SMT_DOOR_CAMERA()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal DOOR_ID,decimal CAMERA_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_DOOR_CAMERA");
			strSql.Append(" where DOOR_ID=@DOOR_ID and CAMERA_ID=@CAMERA_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CAMERA_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = DOOR_ID;
			parameters[1].Value = CAMERA_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SMT_DOOR_CAMERA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_DOOR_CAMERA(");
			strSql.Append("DOOR_ID,CAMERA_ID,ENABLE_CAP)");
			strSql.Append(" values (");
			strSql.Append("@DOOR_ID,@CAMERA_ID,@ENABLE_CAP)");
			SqlParameter[] parameters = {
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CAMERA_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ENABLE_CAP", SqlDbType.Bit,1)};
			parameters[0].Value = model.DOOR_ID;
			parameters[1].Value = model.CAMERA_ID;
			parameters[2].Value = model.ENABLE_CAP;

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
		public bool Update(Maticsoft.Model.SMT_DOOR_CAMERA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_DOOR_CAMERA set ");
			strSql.Append("ENABLE_CAP=@ENABLE_CAP");
			strSql.Append(" where DOOR_ID=@DOOR_ID and CAMERA_ID=@CAMERA_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ENABLE_CAP", SqlDbType.Bit,1),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CAMERA_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ENABLE_CAP;
			parameters[1].Value = model.DOOR_ID;
			parameters[2].Value = model.CAMERA_ID;

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
		public bool Delete(decimal DOOR_ID,decimal CAMERA_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_DOOR_CAMERA ");
			strSql.Append(" where DOOR_ID=@DOOR_ID and CAMERA_ID=@CAMERA_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CAMERA_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = DOOR_ID;
			parameters[1].Value = CAMERA_ID;

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
		public Maticsoft.Model.SMT_DOOR_CAMERA GetModel(decimal DOOR_ID,decimal CAMERA_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DOOR_ID,CAMERA_ID,ENABLE_CAP from SMT_DOOR_CAMERA ");
			strSql.Append(" where DOOR_ID=@DOOR_ID and CAMERA_ID=@CAMERA_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CAMERA_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = DOOR_ID;
			parameters[1].Value = CAMERA_ID;

			Maticsoft.Model.SMT_DOOR_CAMERA model=new Maticsoft.Model.SMT_DOOR_CAMERA();
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
		public Maticsoft.Model.SMT_DOOR_CAMERA DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_DOOR_CAMERA model=new Maticsoft.Model.SMT_DOOR_CAMERA();
			if (row != null)
			{
				if(row["DOOR_ID"]!=null && row["DOOR_ID"].ToString()!="")
				{
					model.DOOR_ID=decimal.Parse(row["DOOR_ID"].ToString());
				}
				if(row["CAMERA_ID"]!=null && row["CAMERA_ID"].ToString()!="")
				{
					model.CAMERA_ID=decimal.Parse(row["CAMERA_ID"].ToString());
				}
				if(row["ENABLE_CAP"]!=null && row["ENABLE_CAP"].ToString()!="")
				{
					if((row["ENABLE_CAP"].ToString()=="1")||(row["ENABLE_CAP"].ToString().ToLower()=="true"))
					{
						model.ENABLE_CAP=true;
					}
					else
					{
						model.ENABLE_CAP=false;
					}
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
			strSql.Append("select DOOR_ID,CAMERA_ID,ENABLE_CAP ");
			strSql.Append(" FROM SMT_DOOR_CAMERA ");
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
			strSql.Append(" DOOR_ID,CAMERA_ID,ENABLE_CAP ");
			strSql.Append(" FROM SMT_DOOR_CAMERA ");
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
			strSql.Append("select count(1) FROM SMT_DOOR_CAMERA ");
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
				strSql.Append("order by T.CAMERA_ID desc");
			}
			strSql.Append(")AS Row, T.*  from SMT_DOOR_CAMERA T ");
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
			parameters[0].Value = "SMT_DOOR_CAMERA";
			parameters[1].Value = "CAMERA_ID";
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

