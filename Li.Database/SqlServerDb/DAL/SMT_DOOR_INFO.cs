/**  版本信息模板在安装目录下，可自行修改。
* SMT_DOOR_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_DOOR_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/15 15:10:51   N/A    初版
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
	/// 数据访问类:SMT_DOOR_INFO
	/// </summary>
	public partial class SMT_DOOR_INFO
	{
		public SMT_DOOR_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_DOOR_INFO");
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
		public decimal Add(Maticsoft.Model.SMT_DOOR_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_DOOR_INFO(");
			strSql.Append("DOOR_NAME,CTRL_ID,CTRL_DOOR_INDEX,DOOR_DESC,CTRL_STYLE,CTRL_DELAY_TIME,IS_ENABLE,IS_ENTER1,IS_ENTER2,IS_ATTENDANCE1,IS_ATTENDANCE2,OPEN_STATE)");
			strSql.Append(" values (");
			strSql.Append("@DOOR_NAME,@CTRL_ID,@CTRL_DOOR_INDEX,@DOOR_DESC,@CTRL_STYLE,@CTRL_DELAY_TIME,@IS_ENABLE,@IS_ENTER1,@IS_ENTER2,@IS_ATTENDANCE1,@IS_ATTENDANCE2,@OPEN_STATE)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DOOR_NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@CTRL_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CTRL_DOOR_INDEX", SqlDbType.TinyInt,1),
					new SqlParameter("@DOOR_DESC", SqlDbType.NVarChar,400),
					new SqlParameter("@CTRL_STYLE", SqlDbType.TinyInt,1),
					new SqlParameter("@CTRL_DELAY_TIME", SqlDbType.TinyInt,1),
					new SqlParameter("@IS_ENABLE", SqlDbType.Bit,1),
					new SqlParameter("@IS_ENTER1", SqlDbType.Bit,1),
					new SqlParameter("@IS_ENTER2", SqlDbType.Bit,1),
					new SqlParameter("@IS_ATTENDANCE1", SqlDbType.Bit,1),
					new SqlParameter("@IS_ATTENDANCE2", SqlDbType.Bit,1),
					new SqlParameter("@OPEN_STATE", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.DOOR_NAME;
			parameters[1].Value = model.CTRL_ID;
			parameters[2].Value = model.CTRL_DOOR_INDEX;
			parameters[3].Value = model.DOOR_DESC;
			parameters[4].Value = model.CTRL_STYLE;
			parameters[5].Value = model.CTRL_DELAY_TIME;
			parameters[6].Value = model.IS_ENABLE;
			parameters[7].Value = model.IS_ENTER1;
			parameters[8].Value = model.IS_ENTER2;
			parameters[9].Value = model.IS_ATTENDANCE1;
			parameters[10].Value = model.IS_ATTENDANCE2;
			parameters[11].Value = model.OPEN_STATE;

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
		public bool Update(Maticsoft.Model.SMT_DOOR_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_DOOR_INFO set ");
			strSql.Append("DOOR_NAME=@DOOR_NAME,");
			strSql.Append("CTRL_ID=@CTRL_ID,");
			strSql.Append("CTRL_DOOR_INDEX=@CTRL_DOOR_INDEX,");
			strSql.Append("DOOR_DESC=@DOOR_DESC,");
			strSql.Append("CTRL_STYLE=@CTRL_STYLE,");
			strSql.Append("CTRL_DELAY_TIME=@CTRL_DELAY_TIME,");
			strSql.Append("IS_ENABLE=@IS_ENABLE,");
			strSql.Append("IS_ENTER1=@IS_ENTER1,");
			strSql.Append("IS_ENTER2=@IS_ENTER2,");
			strSql.Append("IS_ATTENDANCE1=@IS_ATTENDANCE1,");
			strSql.Append("IS_ATTENDANCE2=@IS_ATTENDANCE2,");
			strSql.Append("OPEN_STATE=@OPEN_STATE");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@DOOR_NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@CTRL_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CTRL_DOOR_INDEX", SqlDbType.TinyInt,1),
					new SqlParameter("@DOOR_DESC", SqlDbType.NVarChar,400),
					new SqlParameter("@CTRL_STYLE", SqlDbType.TinyInt,1),
					new SqlParameter("@CTRL_DELAY_TIME", SqlDbType.TinyInt,1),
					new SqlParameter("@IS_ENABLE", SqlDbType.Bit,1),
					new SqlParameter("@IS_ENTER1", SqlDbType.Bit,1),
					new SqlParameter("@IS_ENTER2", SqlDbType.Bit,1),
					new SqlParameter("@IS_ATTENDANCE1", SqlDbType.Bit,1),
					new SqlParameter("@IS_ATTENDANCE2", SqlDbType.Bit,1),
					new SqlParameter("@OPEN_STATE", SqlDbType.TinyInt,1),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.DOOR_NAME;
			parameters[1].Value = model.CTRL_ID;
			parameters[2].Value = model.CTRL_DOOR_INDEX;
			parameters[3].Value = model.DOOR_DESC;
			parameters[4].Value = model.CTRL_STYLE;
			parameters[5].Value = model.CTRL_DELAY_TIME;
			parameters[6].Value = model.IS_ENABLE;
			parameters[7].Value = model.IS_ENTER1;
			parameters[8].Value = model.IS_ENTER2;
			parameters[9].Value = model.IS_ATTENDANCE1;
			parameters[10].Value = model.IS_ATTENDANCE2;
			parameters[11].Value = model.OPEN_STATE;
			parameters[12].Value = model.ID;

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
			strSql.Append("delete from SMT_DOOR_INFO ");
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
			strSql.Append("delete from SMT_DOOR_INFO ");
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
		public Maticsoft.Model.SMT_DOOR_INFO GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,DOOR_NAME,CTRL_ID,CTRL_DOOR_INDEX,DOOR_DESC,CTRL_STYLE,CTRL_DELAY_TIME,IS_ENABLE,IS_ENTER1,IS_ENTER2,IS_ATTENDANCE1,IS_ATTENDANCE2,OPEN_STATE from SMT_DOOR_INFO ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_DOOR_INFO model=new Maticsoft.Model.SMT_DOOR_INFO();
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
		public Maticsoft.Model.SMT_DOOR_INFO DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_DOOR_INFO model=new Maticsoft.Model.SMT_DOOR_INFO();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["DOOR_NAME"]!=null)
				{
					model.DOOR_NAME=row["DOOR_NAME"].ToString();
				}
				if(row["CTRL_ID"]!=null && row["CTRL_ID"].ToString()!="")
				{
					model.CTRL_ID=decimal.Parse(row["CTRL_ID"].ToString());
				}
				if(row["CTRL_DOOR_INDEX"]!=null && row["CTRL_DOOR_INDEX"].ToString()!="")
				{
					model.CTRL_DOOR_INDEX=int.Parse(row["CTRL_DOOR_INDEX"].ToString());
				}
				if(row["DOOR_DESC"]!=null)
				{
					model.DOOR_DESC=row["DOOR_DESC"].ToString();
				}
				if(row["CTRL_STYLE"]!=null && row["CTRL_STYLE"].ToString()!="")
				{
					model.CTRL_STYLE=int.Parse(row["CTRL_STYLE"].ToString());
				}
				if(row["CTRL_DELAY_TIME"]!=null && row["CTRL_DELAY_TIME"].ToString()!="")
				{
					model.CTRL_DELAY_TIME=int.Parse(row["CTRL_DELAY_TIME"].ToString());
				}
				if(row["IS_ENABLE"]!=null && row["IS_ENABLE"].ToString()!="")
				{
					if((row["IS_ENABLE"].ToString()=="1")||(row["IS_ENABLE"].ToString().ToLower()=="true"))
					{
						model.IS_ENABLE=true;
					}
					else
					{
						model.IS_ENABLE=false;
					}
				}
				if(row["IS_ENTER1"]!=null && row["IS_ENTER1"].ToString()!="")
				{
					if((row["IS_ENTER1"].ToString()=="1")||(row["IS_ENTER1"].ToString().ToLower()=="true"))
					{
						model.IS_ENTER1=true;
					}
					else
					{
						model.IS_ENTER1=false;
					}
				}
				if(row["IS_ENTER2"]!=null && row["IS_ENTER2"].ToString()!="")
				{
					if((row["IS_ENTER2"].ToString()=="1")||(row["IS_ENTER2"].ToString().ToLower()=="true"))
					{
						model.IS_ENTER2=true;
					}
					else
					{
						model.IS_ENTER2=false;
					}
				}
				if(row["IS_ATTENDANCE1"]!=null && row["IS_ATTENDANCE1"].ToString()!="")
				{
					if((row["IS_ATTENDANCE1"].ToString()=="1")||(row["IS_ATTENDANCE1"].ToString().ToLower()=="true"))
					{
						model.IS_ATTENDANCE1=true;
					}
					else
					{
						model.IS_ATTENDANCE1=false;
					}
				}
				if(row["IS_ATTENDANCE2"]!=null && row["IS_ATTENDANCE2"].ToString()!="")
				{
					if((row["IS_ATTENDANCE2"].ToString()=="1")||(row["IS_ATTENDANCE2"].ToString().ToLower()=="true"))
					{
						model.IS_ATTENDANCE2=true;
					}
					else
					{
						model.IS_ATTENDANCE2=false;
					}
				}
				if(row["OPEN_STATE"]!=null && row["OPEN_STATE"].ToString()!="")
				{
					model.OPEN_STATE=int.Parse(row["OPEN_STATE"].ToString());
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
			strSql.Append("select ID,DOOR_NAME,CTRL_ID,CTRL_DOOR_INDEX,DOOR_DESC,CTRL_STYLE,CTRL_DELAY_TIME,IS_ENABLE,IS_ENTER1,IS_ENTER2,IS_ATTENDANCE1,IS_ATTENDANCE2,OPEN_STATE ");
			strSql.Append(" FROM SMT_DOOR_INFO ");
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
			strSql.Append(" ID,DOOR_NAME,CTRL_ID,CTRL_DOOR_INDEX,DOOR_DESC,CTRL_STYLE,CTRL_DELAY_TIME,IS_ENABLE,IS_ENTER1,IS_ENTER2,IS_ATTENDANCE1,IS_ATTENDANCE2,OPEN_STATE ");
			strSql.Append(" FROM SMT_DOOR_INFO ");
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
			strSql.Append("select count(1) FROM SMT_DOOR_INFO ");
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
			strSql.Append(")AS Row, T.*  from SMT_DOOR_INFO T ");
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
			parameters[0].Value = "SMT_DOOR_INFO";
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

