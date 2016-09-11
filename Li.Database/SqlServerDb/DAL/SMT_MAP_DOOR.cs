/**  版本信息模板在安装目录下，可自行修改。
* SMT_MAP_DOOR.cs
*
* 功 能： N/A
* 类 名： SMT_MAP_DOOR
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/11 12:06:47   N/A    初版
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
	/// 数据访问类:SMT_MAP_DOOR
	/// </summary>
	public partial class SMT_MAP_DOOR
	{
		public SMT_MAP_DOOR()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal MAP_ID,decimal DOOR_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_MAP_DOOR");
			strSql.Append(" where MAP_ID=@MAP_ID and DOOR_ID=@DOOR_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MAP_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = MAP_ID;
			parameters[1].Value = DOOR_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SMT_MAP_DOOR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_MAP_DOOR(");
			strSql.Append("MAP_ID,DOOR_ID,LOCATION_X,LOCATION_Y,WIDTH,HEIGHT)");
			strSql.Append(" values (");
			strSql.Append("@MAP_ID,@DOOR_ID,@LOCATION_X,@LOCATION_Y,@WIDTH,@HEIGHT)");
			SqlParameter[] parameters = {
					new SqlParameter("@MAP_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9),
					new SqlParameter("@LOCATION_X", SqlDbType.Real,4),
					new SqlParameter("@LOCATION_Y", SqlDbType.Real,4),
					new SqlParameter("@WIDTH", SqlDbType.Real,4),
					new SqlParameter("@HEIGHT", SqlDbType.Real,4)};
			parameters[0].Value = model.MAP_ID;
			parameters[1].Value = model.DOOR_ID;
			parameters[2].Value = model.LOCATION_X;
			parameters[3].Value = model.LOCATION_Y;
			parameters[4].Value = model.WIDTH;
			parameters[5].Value = model.HEIGHT;

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
		public bool Update(Maticsoft.Model.SMT_MAP_DOOR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_MAP_DOOR set ");
			strSql.Append("LOCATION_X=@LOCATION_X,");
			strSql.Append("LOCATION_Y=@LOCATION_Y,");
			strSql.Append("WIDTH=@WIDTH,");
			strSql.Append("HEIGHT=@HEIGHT");
			strSql.Append(" where MAP_ID=@MAP_ID and DOOR_ID=@DOOR_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LOCATION_X", SqlDbType.Real,4),
					new SqlParameter("@LOCATION_Y", SqlDbType.Real,4),
					new SqlParameter("@WIDTH", SqlDbType.Real,4),
					new SqlParameter("@HEIGHT", SqlDbType.Real,4),
					new SqlParameter("@MAP_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.LOCATION_X;
			parameters[1].Value = model.LOCATION_Y;
			parameters[2].Value = model.WIDTH;
			parameters[3].Value = model.HEIGHT;
			parameters[4].Value = model.MAP_ID;
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
		public bool Delete(decimal MAP_ID,decimal DOOR_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_MAP_DOOR ");
			strSql.Append(" where MAP_ID=@MAP_ID and DOOR_ID=@DOOR_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MAP_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = MAP_ID;
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
		public Maticsoft.Model.SMT_MAP_DOOR GetModel(decimal MAP_ID,decimal DOOR_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MAP_ID,DOOR_ID,LOCATION_X,LOCATION_Y,WIDTH,HEIGHT from SMT_MAP_DOOR ");
			strSql.Append(" where MAP_ID=@MAP_ID and DOOR_ID=@DOOR_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MAP_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DOOR_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = MAP_ID;
			parameters[1].Value = DOOR_ID;

			Maticsoft.Model.SMT_MAP_DOOR model=new Maticsoft.Model.SMT_MAP_DOOR();
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
		public Maticsoft.Model.SMT_MAP_DOOR DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_MAP_DOOR model=new Maticsoft.Model.SMT_MAP_DOOR();
			if (row != null)
			{
				if(row["MAP_ID"]!=null && row["MAP_ID"].ToString()!="")
				{
					model.MAP_ID=decimal.Parse(row["MAP_ID"].ToString());
				}
				if(row["DOOR_ID"]!=null && row["DOOR_ID"].ToString()!="")
				{
					model.DOOR_ID=decimal.Parse(row["DOOR_ID"].ToString());
				}
				if(row["LOCATION_X"]!=null && row["LOCATION_X"].ToString()!="")
				{
					model.LOCATION_X=decimal.Parse(row["LOCATION_X"].ToString());
				}
				if(row["LOCATION_Y"]!=null && row["LOCATION_Y"].ToString()!="")
				{
					model.LOCATION_Y=decimal.Parse(row["LOCATION_Y"].ToString());
				}
				if(row["WIDTH"]!=null && row["WIDTH"].ToString()!="")
				{
					model.WIDTH=decimal.Parse(row["WIDTH"].ToString());
				}
				if(row["HEIGHT"]!=null && row["HEIGHT"].ToString()!="")
				{
					model.HEIGHT=decimal.Parse(row["HEIGHT"].ToString());
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
			strSql.Append("select MAP_ID,DOOR_ID,LOCATION_X,LOCATION_Y,WIDTH,HEIGHT ");
			strSql.Append(" FROM SMT_MAP_DOOR ");
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
			strSql.Append(" MAP_ID,DOOR_ID,LOCATION_X,LOCATION_Y,WIDTH,HEIGHT ");
			strSql.Append(" FROM SMT_MAP_DOOR ");
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
			strSql.Append("select count(1) FROM SMT_MAP_DOOR ");
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
			strSql.Append(")AS Row, T.*  from SMT_MAP_DOOR T ");
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
			parameters[0].Value = "SMT_MAP_DOOR";
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

