/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_DOOR.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_DOOR
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/25 8:33:57   N/A    初版
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
	/// 数据访问类:SMT_STAFF_DOOR
	/// </summary>
	public partial class SMT_STAFF_DOOR
	{
		public SMT_STAFF_DOOR()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal STAFF_ID,decimal DOOR_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_STAFF_DOOR");
			strSql.Append(" where STAFF_ID=@STAFF_ID and DOOR_ID=@DOOR_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = STAFF_ID;
			parameters[1].Value = DOOR_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SMT_STAFF_DOOR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_STAFF_DOOR(");
			strSql.Append("STAFF_ID,DOOR_ID,IS_UPLOAD,UPLOAD_TIME,ADD_TIME,TIME_NUM)");
			strSql.Append(" values (");
			strSql.Append("@STAFF_ID,@DOOR_ID,@IS_UPLOAD,@UPLOAD_TIME,@ADD_TIME,@TIME_NUM)");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@IS_UPLOAD", SqlDbType.Bit,1),
					new SqlParameter("@UPLOAD_TIME", SqlDbType.DateTime),
					new SqlParameter("@ADD_TIME", SqlDbType.DateTime),
					new SqlParameter("@TIME_NUM", SqlDbType.Int,4)};
			parameters[0].Value = model.STAFF_ID;
			parameters[1].Value = model.DOOR_ID;
			parameters[2].Value = model.IS_UPLOAD;
			parameters[3].Value = model.UPLOAD_TIME;
			parameters[4].Value = model.ADD_TIME;
			parameters[5].Value = model.TIME_NUM;

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
		public bool Update(Maticsoft.Model.SMT_STAFF_DOOR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_STAFF_DOOR set ");
			strSql.Append("IS_UPLOAD=@IS_UPLOAD,");
			strSql.Append("UPLOAD_TIME=@UPLOAD_TIME,");
			strSql.Append("ADD_TIME=@ADD_TIME,");
			strSql.Append("TIME_NUM=@TIME_NUM");
			strSql.Append(" where STAFF_ID=@STAFF_ID and DOOR_ID=@DOOR_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@IS_UPLOAD", SqlDbType.Bit,1),
					new SqlParameter("@UPLOAD_TIME", SqlDbType.DateTime),
					new SqlParameter("@ADD_TIME", SqlDbType.DateTime),
					new SqlParameter("@TIME_NUM", SqlDbType.Int,4),
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.IS_UPLOAD;
			parameters[1].Value = model.UPLOAD_TIME;
			parameters[2].Value = model.ADD_TIME;
			parameters[3].Value = model.TIME_NUM;
			parameters[4].Value = model.STAFF_ID;
			parameters[5].Value = model.DOOR_ID;

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
		public bool Delete(decimal STAFF_ID,decimal DOOR_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_STAFF_DOOR ");
			strSql.Append(" where STAFF_ID=@STAFF_ID and DOOR_ID=@DOOR_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = STAFF_ID;
			parameters[1].Value = DOOR_ID;

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
		public Maticsoft.Model.SMT_STAFF_DOOR GetModel(decimal STAFF_ID,decimal DOOR_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 STAFF_ID,DOOR_ID,IS_UPLOAD,UPLOAD_TIME,ADD_TIME,TIME_NUM from SMT_STAFF_DOOR ");
			strSql.Append(" where STAFF_ID=@STAFF_ID and DOOR_ID=@DOOR_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@STAFF_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = STAFF_ID;
			parameters[1].Value = DOOR_ID;

			Maticsoft.Model.SMT_STAFF_DOOR model=new Maticsoft.Model.SMT_STAFF_DOOR();
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
		public Maticsoft.Model.SMT_STAFF_DOOR DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_STAFF_DOOR model=new Maticsoft.Model.SMT_STAFF_DOOR();
			if (row != null)
			{
				if(row["STAFF_ID"]!=null && row["STAFF_ID"].ToString()!="")
				{
					model.STAFF_ID=decimal.Parse(row["STAFF_ID"].ToString());
				}
				if(row["DOOR_ID"]!=null && row["DOOR_ID"].ToString()!="")
				{
					model.DOOR_ID=decimal.Parse(row["DOOR_ID"].ToString());
				}
				if(row["IS_UPLOAD"]!=null && row["IS_UPLOAD"].ToString()!="")
				{
					if((row["IS_UPLOAD"].ToString()=="1")||(row["IS_UPLOAD"].ToString().ToLower()=="true"))
					{
						model.IS_UPLOAD=true;
					}
					else
					{
						model.IS_UPLOAD=false;
					}
				}
				if(row["UPLOAD_TIME"]!=null && row["UPLOAD_TIME"].ToString()!="")
				{
					model.UPLOAD_TIME=DateTime.Parse(row["UPLOAD_TIME"].ToString());
				}
				if(row["ADD_TIME"]!=null && row["ADD_TIME"].ToString()!="")
				{
					model.ADD_TIME=DateTime.Parse(row["ADD_TIME"].ToString());
				}
				if(row["TIME_NUM"]!=null && row["TIME_NUM"].ToString()!="")
				{
					model.TIME_NUM=int.Parse(row["TIME_NUM"].ToString());
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
			strSql.Append("select STAFF_ID,DOOR_ID,IS_UPLOAD,UPLOAD_TIME,ADD_TIME,TIME_NUM ");
			strSql.Append(" FROM SMT_STAFF_DOOR ");
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
			strSql.Append(" STAFF_ID,DOOR_ID,IS_UPLOAD,UPLOAD_TIME,ADD_TIME,TIME_NUM ");
			strSql.Append(" FROM SMT_STAFF_DOOR ");
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
			strSql.Append("select count(1) FROM SMT_STAFF_DOOR ");
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
				strSql.Append("order by T.DOOR_ID desc");
			}
			strSql.Append(")AS Row, T.*  from SMT_STAFF_DOOR T ");
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
			parameters[0].Value = "SMT_STAFF_DOOR";
			parameters[1].Value = "DOOR_ID";
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

