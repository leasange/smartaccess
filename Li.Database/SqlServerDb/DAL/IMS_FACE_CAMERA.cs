/**  版本信息模板在安装目录下，可自行修改。
* IMS_FACE_CAMERA.cs
*
* 功 能： N/A
* 类 名： IMS_FACE_CAMERA
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
	/// 数据访问类:IMS_FACE_CAMERA
	/// </summary>
	public partial class IMS_FACE_CAMERA
	{
		public IMS_FACE_CAMERA()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from IMS_FACE_CAMERA");
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
		public decimal Add(Maticsoft.Model.IMS_FACE_CAMERA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into IMS_FACE_CAMERA(");
			strSql.Append("CameraName,CameraIP,CameraPort,CameraUser,CameraPwd)");
			strSql.Append(" values (");
			strSql.Append("@CameraName,@CameraIP,@CameraPort,@CameraUser,@CameraPwd)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CameraName", SqlDbType.VarChar,50),
					new SqlParameter("@CameraIP", SqlDbType.VarChar,50),
					new SqlParameter("@CameraPort", SqlDbType.VarChar,50),
					new SqlParameter("@CameraUser", SqlDbType.VarChar,50),
					new SqlParameter("@CameraPwd", SqlDbType.VarChar,50)};
			parameters[0].Value = model.CameraName;
			parameters[1].Value = model.CameraIP;
			parameters[2].Value = model.CameraPort;
			parameters[3].Value = model.CameraUser;
			parameters[4].Value = model.CameraPwd;

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
		public bool Update(Maticsoft.Model.IMS_FACE_CAMERA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IMS_FACE_CAMERA set ");
			strSql.Append("CameraName=@CameraName,");
			strSql.Append("CameraIP=@CameraIP,");
			strSql.Append("CameraPort=@CameraPort,");
			strSql.Append("CameraUser=@CameraUser,");
			strSql.Append("CameraPwd=@CameraPwd");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CameraName", SqlDbType.VarChar,50),
					new SqlParameter("@CameraIP", SqlDbType.VarChar,50),
					new SqlParameter("@CameraPort", SqlDbType.VarChar,50),
					new SqlParameter("@CameraUser", SqlDbType.VarChar,50),
					new SqlParameter("@CameraPwd", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.CameraName;
			parameters[1].Value = model.CameraIP;
			parameters[2].Value = model.CameraPort;
			parameters[3].Value = model.CameraUser;
			parameters[4].Value = model.CameraPwd;
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
			strSql.Append("delete from IMS_FACE_CAMERA ");
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
			strSql.Append("delete from IMS_FACE_CAMERA ");
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
		public Maticsoft.Model.IMS_FACE_CAMERA GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CameraName,CameraIP,CameraPort,CameraUser,CameraPwd from IMS_FACE_CAMERA ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.IMS_FACE_CAMERA model=new Maticsoft.Model.IMS_FACE_CAMERA();
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
		public Maticsoft.Model.IMS_FACE_CAMERA DataRowToModel(DataRow row)
		{
			Maticsoft.Model.IMS_FACE_CAMERA model=new Maticsoft.Model.IMS_FACE_CAMERA();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["CameraName"]!=null)
				{
					model.CameraName=row["CameraName"].ToString();
				}
				if(row["CameraIP"]!=null)
				{
					model.CameraIP=row["CameraIP"].ToString();
				}
				if(row["CameraPort"]!=null)
				{
					model.CameraPort=row["CameraPort"].ToString();
				}
				if(row["CameraUser"]!=null)
				{
					model.CameraUser=row["CameraUser"].ToString();
				}
				if(row["CameraPwd"]!=null)
				{
					model.CameraPwd=row["CameraPwd"].ToString();
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
			strSql.Append("select ID,CameraName,CameraIP,CameraPort,CameraUser,CameraPwd ");
			strSql.Append(" FROM IMS_FACE_CAMERA ");
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
			strSql.Append(" ID,CameraName,CameraIP,CameraPort,CameraUser,CameraPwd ");
			strSql.Append(" FROM IMS_FACE_CAMERA ");
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
			strSql.Append("select count(1) FROM IMS_FACE_CAMERA ");
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
			strSql.Append(")AS Row, T.*  from IMS_FACE_CAMERA T ");
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
			parameters[0].Value = "IMS_FACE_CAMERA";
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

