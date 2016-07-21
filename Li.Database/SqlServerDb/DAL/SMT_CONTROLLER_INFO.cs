/**  版本信息模板在安装目录下，可自行修改。
* SMT_CONTROLLER_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_CONTROLLER_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/21 22:57:19   N/A    初版
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
	/// 数据访问类:SMT_CONTROLLER_INFO
	/// </summary>
	public partial class SMT_CONTROLLER_INFO
	{
		public SMT_CONTROLLER_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_CONTROLLER_INFO");
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
		public decimal Add(Maticsoft.Model.SMT_CONTROLLER_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_CONTROLLER_INFO(");
			strSql.Append("SN_NO,NAME,IP,PORT,MASK,GATEWAY,MAC,CTRLR_TYPE,DRIVER_VERSION,DRIVER_DATE,CTRLR_DESC,AREA_ID,ORDER_VALUE,ORG_ID,CTRLR_MODEL)");
			strSql.Append(" values (");
			strSql.Append("@SN_NO,@NAME,@IP,@PORT,@MASK,@GATEWAY,@MAC,@CTRLR_TYPE,@DRIVER_VERSION,@DRIVER_DATE,@CTRLR_DESC,@AREA_ID,@ORDER_VALUE,@ORG_ID,@CTRLR_MODEL)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SN_NO", SqlDbType.VarChar,100),
					new SqlParameter("@NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@IP", SqlDbType.VarChar,40),
					new SqlParameter("@PORT", SqlDbType.Int,4),
					new SqlParameter("@MASK", SqlDbType.VarChar,40),
					new SqlParameter("@GATEWAY", SqlDbType.VarChar,40),
					new SqlParameter("@MAC", SqlDbType.VarChar,40),
					new SqlParameter("@CTRLR_TYPE", SqlDbType.TinyInt,1),
					new SqlParameter("@DRIVER_VERSION", SqlDbType.VarChar,20),
					new SqlParameter("@DRIVER_DATE", SqlDbType.Date,3),
					new SqlParameter("@CTRLR_DESC", SqlDbType.NVarChar,400),
					new SqlParameter("@AREA_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ORDER_VALUE", SqlDbType.Int,4),
					new SqlParameter("@ORG_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CTRLR_MODEL", SqlDbType.VarChar,20)};
			parameters[0].Value = model.SN_NO;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.IP;
			parameters[3].Value = model.PORT;
			parameters[4].Value = model.MASK;
			parameters[5].Value = model.GATEWAY;
			parameters[6].Value = model.MAC;
			parameters[7].Value = model.CTRLR_TYPE;
			parameters[8].Value = model.DRIVER_VERSION;
			parameters[9].Value = model.DRIVER_DATE;
			parameters[10].Value = model.CTRLR_DESC;
			parameters[11].Value = model.AREA_ID;
			parameters[12].Value = model.ORDER_VALUE;
			parameters[13].Value = model.ORG_ID;
			parameters[14].Value = model.CTRLR_MODEL;

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
		public bool Update(Maticsoft.Model.SMT_CONTROLLER_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_CONTROLLER_INFO set ");
			strSql.Append("SN_NO=@SN_NO,");
			strSql.Append("NAME=@NAME,");
			strSql.Append("IP=@IP,");
			strSql.Append("PORT=@PORT,");
			strSql.Append("MASK=@MASK,");
			strSql.Append("GATEWAY=@GATEWAY,");
			strSql.Append("MAC=@MAC,");
			strSql.Append("CTRLR_TYPE=@CTRLR_TYPE,");
			strSql.Append("DRIVER_VERSION=@DRIVER_VERSION,");
			strSql.Append("DRIVER_DATE=@DRIVER_DATE,");
			strSql.Append("CTRLR_DESC=@CTRLR_DESC,");
			strSql.Append("AREA_ID=@AREA_ID,");
			strSql.Append("ORDER_VALUE=@ORDER_VALUE,");
			strSql.Append("ORG_ID=@ORG_ID,");
			strSql.Append("CTRLR_MODEL=@CTRLR_MODEL");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@SN_NO", SqlDbType.VarChar,100),
					new SqlParameter("@NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@IP", SqlDbType.VarChar,40),
					new SqlParameter("@PORT", SqlDbType.Int,4),
					new SqlParameter("@MASK", SqlDbType.VarChar,40),
					new SqlParameter("@GATEWAY", SqlDbType.VarChar,40),
					new SqlParameter("@MAC", SqlDbType.VarChar,40),
					new SqlParameter("@CTRLR_TYPE", SqlDbType.TinyInt,1),
					new SqlParameter("@DRIVER_VERSION", SqlDbType.VarChar,20),
					new SqlParameter("@DRIVER_DATE", SqlDbType.Date,3),
					new SqlParameter("@CTRLR_DESC", SqlDbType.NVarChar,400),
					new SqlParameter("@AREA_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ORDER_VALUE", SqlDbType.Int,4),
					new SqlParameter("@ORG_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CTRLR_MODEL", SqlDbType.VarChar,20),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.SN_NO;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.IP;
			parameters[3].Value = model.PORT;
			parameters[4].Value = model.MASK;
			parameters[5].Value = model.GATEWAY;
			parameters[6].Value = model.MAC;
			parameters[7].Value = model.CTRLR_TYPE;
			parameters[8].Value = model.DRIVER_VERSION;
			parameters[9].Value = model.DRIVER_DATE;
			parameters[10].Value = model.CTRLR_DESC;
			parameters[11].Value = model.AREA_ID;
			parameters[12].Value = model.ORDER_VALUE;
			parameters[13].Value = model.ORG_ID;
			parameters[14].Value = model.CTRLR_MODEL;
			parameters[15].Value = model.ID;

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
			strSql.Append("delete from SMT_CONTROLLER_INFO ");
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
			strSql.Append("delete from SMT_CONTROLLER_INFO ");
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
		public Maticsoft.Model.SMT_CONTROLLER_INFO GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SN_NO,NAME,IP,PORT,MASK,GATEWAY,MAC,CTRLR_TYPE,DRIVER_VERSION,DRIVER_DATE,CTRLR_DESC,AREA_ID,ORDER_VALUE,ORG_ID,CTRLR_MODEL from SMT_CONTROLLER_INFO ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_CONTROLLER_INFO model=new Maticsoft.Model.SMT_CONTROLLER_INFO();
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
		public Maticsoft.Model.SMT_CONTROLLER_INFO DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_CONTROLLER_INFO model=new Maticsoft.Model.SMT_CONTROLLER_INFO();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["SN_NO"]!=null)
				{
					model.SN_NO=row["SN_NO"].ToString();
				}
				if(row["NAME"]!=null)
				{
					model.NAME=row["NAME"].ToString();
				}
				if(row["IP"]!=null)
				{
					model.IP=row["IP"].ToString();
				}
				if(row["PORT"]!=null && row["PORT"].ToString()!="")
				{
					model.PORT=int.Parse(row["PORT"].ToString());
				}
				if(row["MASK"]!=null)
				{
					model.MASK=row["MASK"].ToString();
				}
				if(row["GATEWAY"]!=null)
				{
					model.GATEWAY=row["GATEWAY"].ToString();
				}
				if(row["MAC"]!=null)
				{
					model.MAC=row["MAC"].ToString();
				}
				if(row["CTRLR_TYPE"]!=null && row["CTRLR_TYPE"].ToString()!="")
				{
					model.CTRLR_TYPE=int.Parse(row["CTRLR_TYPE"].ToString());
				}
				if(row["DRIVER_VERSION"]!=null)
				{
					model.DRIVER_VERSION=row["DRIVER_VERSION"].ToString();
				}
				if(row["DRIVER_DATE"]!=null && row["DRIVER_DATE"].ToString()!="")
				{
					model.DRIVER_DATE=DateTime.Parse(row["DRIVER_DATE"].ToString());
				}
				if(row["CTRLR_DESC"]!=null)
				{
					model.CTRLR_DESC=row["CTRLR_DESC"].ToString();
				}
				if(row["AREA_ID"]!=null && row["AREA_ID"].ToString()!="")
				{
					model.AREA_ID=decimal.Parse(row["AREA_ID"].ToString());
				}
				if(row["ORDER_VALUE"]!=null && row["ORDER_VALUE"].ToString()!="")
				{
					model.ORDER_VALUE=int.Parse(row["ORDER_VALUE"].ToString());
				}
				if(row["ORG_ID"]!=null && row["ORG_ID"].ToString()!="")
				{
					model.ORG_ID=decimal.Parse(row["ORG_ID"].ToString());
				}
				if(row["CTRLR_MODEL"]!=null)
				{
					model.CTRLR_MODEL=row["CTRLR_MODEL"].ToString();
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
			strSql.Append("select ID,SN_NO,NAME,IP,PORT,MASK,GATEWAY,MAC,CTRLR_TYPE,DRIVER_VERSION,DRIVER_DATE,CTRLR_DESC,AREA_ID,ORDER_VALUE,ORG_ID,CTRLR_MODEL ");
			strSql.Append(" FROM SMT_CONTROLLER_INFO ");
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
			strSql.Append(" ID,SN_NO,NAME,IP,PORT,MASK,GATEWAY,MAC,CTRLR_TYPE,DRIVER_VERSION,DRIVER_DATE,CTRLR_DESC,AREA_ID,ORDER_VALUE,ORG_ID,CTRLR_MODEL ");
			strSql.Append(" FROM SMT_CONTROLLER_INFO ");
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
			strSql.Append("select count(1) FROM SMT_CONTROLLER_INFO ");
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
			strSql.Append(")AS Row, T.*  from SMT_CONTROLLER_INFO T ");
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
			parameters[0].Value = "SMT_CONTROLLER_INFO";
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

