/**  版本信息模板在安装目录下，可自行修改。
* SMT_ALARM_SETTING.cs
*
* 功 能： N/A
* 类 名： SMT_ALARM_SETTING
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/5 23:38:32   N/A    初版
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
	/// 数据访问类:SMT_ALARM_SETTING
	/// </summary>
	public partial class SMT_ALARM_SETTING
	{
		public SMT_ALARM_SETTING()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_ALARM_SETTING");
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
		public decimal Add(Maticsoft.Model.SMT_ALARM_SETTING model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_ALARM_SETTING(");
			strSql.Append("CTRL_ID,CTRL_FORCE_PWD,ENABLE_FORCE_PWD,NOT_CLOSED_TIMEOUT,ENABLE_CLOSED_TIMEOUT,ENABLE_FORCE_ACCESS,ENABLE_FORCE_CLOSE,ENABLE_INVALID_CARD,ENABLE_FIRE,ENABLE_STEAL,ENABLE_FORCE_CARD)");
			strSql.Append(" values (");
			strSql.Append("@CTRL_ID,@CTRL_FORCE_PWD,@ENABLE_FORCE_PWD,@NOT_CLOSED_TIMEOUT,@ENABLE_CLOSED_TIMEOUT,@ENABLE_FORCE_ACCESS,@ENABLE_FORCE_CLOSE,@ENABLE_INVALID_CARD,@ENABLE_FIRE,@ENABLE_STEAL,@ENABLE_FORCE_CARD)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CTRL_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CTRL_FORCE_PWD", SqlDbType.VarChar,10),
					new SqlParameter("@ENABLE_FORCE_PWD", SqlDbType.Bit,1),
					new SqlParameter("@NOT_CLOSED_TIMEOUT", SqlDbType.TinyInt,1),
					new SqlParameter("@ENABLE_CLOSED_TIMEOUT", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_FORCE_ACCESS", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_FORCE_CLOSE", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_INVALID_CARD", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_FIRE", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_STEAL", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_FORCE_CARD", SqlDbType.Bit,1)};
			parameters[0].Value = model.CTRL_ID;
			parameters[1].Value = model.CTRL_FORCE_PWD;
			parameters[2].Value = model.ENABLE_FORCE_PWD;
			parameters[3].Value = model.NOT_CLOSED_TIMEOUT;
			parameters[4].Value = model.ENABLE_CLOSED_TIMEOUT;
			parameters[5].Value = model.ENABLE_FORCE_ACCESS;
			parameters[6].Value = model.ENABLE_FORCE_CLOSE;
			parameters[7].Value = model.ENABLE_INVALID_CARD;
			parameters[8].Value = model.ENABLE_FIRE;
			parameters[9].Value = model.ENABLE_STEAL;
			parameters[10].Value = model.ENABLE_FORCE_CARD;

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
		public bool Update(Maticsoft.Model.SMT_ALARM_SETTING model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_ALARM_SETTING set ");
			strSql.Append("CTRL_ID=@CTRL_ID,");
			strSql.Append("CTRL_FORCE_PWD=@CTRL_FORCE_PWD,");
			strSql.Append("ENABLE_FORCE_PWD=@ENABLE_FORCE_PWD,");
			strSql.Append("NOT_CLOSED_TIMEOUT=@NOT_CLOSED_TIMEOUT,");
			strSql.Append("ENABLE_CLOSED_TIMEOUT=@ENABLE_CLOSED_TIMEOUT,");
			strSql.Append("ENABLE_FORCE_ACCESS=@ENABLE_FORCE_ACCESS,");
			strSql.Append("ENABLE_FORCE_CLOSE=@ENABLE_FORCE_CLOSE,");
			strSql.Append("ENABLE_INVALID_CARD=@ENABLE_INVALID_CARD,");
			strSql.Append("ENABLE_FIRE=@ENABLE_FIRE,");
			strSql.Append("ENABLE_STEAL=@ENABLE_STEAL,");
			strSql.Append("ENABLE_FORCE_CARD=@ENABLE_FORCE_CARD");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CTRL_ID", SqlDbType.Decimal,9),
					new SqlParameter("@CTRL_FORCE_PWD", SqlDbType.VarChar,10),
					new SqlParameter("@ENABLE_FORCE_PWD", SqlDbType.Bit,1),
					new SqlParameter("@NOT_CLOSED_TIMEOUT", SqlDbType.TinyInt,1),
					new SqlParameter("@ENABLE_CLOSED_TIMEOUT", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_FORCE_ACCESS", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_FORCE_CLOSE", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_INVALID_CARD", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_FIRE", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_STEAL", SqlDbType.Bit,1),
					new SqlParameter("@ENABLE_FORCE_CARD", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.CTRL_ID;
			parameters[1].Value = model.CTRL_FORCE_PWD;
			parameters[2].Value = model.ENABLE_FORCE_PWD;
			parameters[3].Value = model.NOT_CLOSED_TIMEOUT;
			parameters[4].Value = model.ENABLE_CLOSED_TIMEOUT;
			parameters[5].Value = model.ENABLE_FORCE_ACCESS;
			parameters[6].Value = model.ENABLE_FORCE_CLOSE;
			parameters[7].Value = model.ENABLE_INVALID_CARD;
			parameters[8].Value = model.ENABLE_FIRE;
			parameters[9].Value = model.ENABLE_STEAL;
			parameters[10].Value = model.ENABLE_FORCE_CARD;
			parameters[11].Value = model.ID;

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
			strSql.Append("delete from SMT_ALARM_SETTING ");
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
			strSql.Append("delete from SMT_ALARM_SETTING ");
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
		public Maticsoft.Model.SMT_ALARM_SETTING GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CTRL_ID,CTRL_FORCE_PWD,ENABLE_FORCE_PWD,NOT_CLOSED_TIMEOUT,ENABLE_CLOSED_TIMEOUT,ENABLE_FORCE_ACCESS,ENABLE_FORCE_CLOSE,ENABLE_INVALID_CARD,ENABLE_FIRE,ENABLE_STEAL,ENABLE_FORCE_CARD from SMT_ALARM_SETTING ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_ALARM_SETTING model=new Maticsoft.Model.SMT_ALARM_SETTING();
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
		public Maticsoft.Model.SMT_ALARM_SETTING DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_ALARM_SETTING model=new Maticsoft.Model.SMT_ALARM_SETTING();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["CTRL_ID"]!=null && row["CTRL_ID"].ToString()!="")
				{
					model.CTRL_ID=decimal.Parse(row["CTRL_ID"].ToString());
				}
				if(row["CTRL_FORCE_PWD"]!=null)
				{
					model.CTRL_FORCE_PWD=row["CTRL_FORCE_PWD"].ToString();
				}
				if(row["ENABLE_FORCE_PWD"]!=null && row["ENABLE_FORCE_PWD"].ToString()!="")
				{
					if((row["ENABLE_FORCE_PWD"].ToString()=="1")||(row["ENABLE_FORCE_PWD"].ToString().ToLower()=="true"))
					{
						model.ENABLE_FORCE_PWD=true;
					}
					else
					{
						model.ENABLE_FORCE_PWD=false;
					}
				}
				if(row["NOT_CLOSED_TIMEOUT"]!=null && row["NOT_CLOSED_TIMEOUT"].ToString()!="")
				{
					model.NOT_CLOSED_TIMEOUT=int.Parse(row["NOT_CLOSED_TIMEOUT"].ToString());
				}
				if(row["ENABLE_CLOSED_TIMEOUT"]!=null && row["ENABLE_CLOSED_TIMEOUT"].ToString()!="")
				{
					if((row["ENABLE_CLOSED_TIMEOUT"].ToString()=="1")||(row["ENABLE_CLOSED_TIMEOUT"].ToString().ToLower()=="true"))
					{
						model.ENABLE_CLOSED_TIMEOUT=true;
					}
					else
					{
						model.ENABLE_CLOSED_TIMEOUT=false;
					}
				}
				if(row["ENABLE_FORCE_ACCESS"]!=null && row["ENABLE_FORCE_ACCESS"].ToString()!="")
				{
					if((row["ENABLE_FORCE_ACCESS"].ToString()=="1")||(row["ENABLE_FORCE_ACCESS"].ToString().ToLower()=="true"))
					{
						model.ENABLE_FORCE_ACCESS=true;
					}
					else
					{
						model.ENABLE_FORCE_ACCESS=false;
					}
				}
				if(row["ENABLE_FORCE_CLOSE"]!=null && row["ENABLE_FORCE_CLOSE"].ToString()!="")
				{
					if((row["ENABLE_FORCE_CLOSE"].ToString()=="1")||(row["ENABLE_FORCE_CLOSE"].ToString().ToLower()=="true"))
					{
						model.ENABLE_FORCE_CLOSE=true;
					}
					else
					{
						model.ENABLE_FORCE_CLOSE=false;
					}
				}
				if(row["ENABLE_INVALID_CARD"]!=null && row["ENABLE_INVALID_CARD"].ToString()!="")
				{
					if((row["ENABLE_INVALID_CARD"].ToString()=="1")||(row["ENABLE_INVALID_CARD"].ToString().ToLower()=="true"))
					{
						model.ENABLE_INVALID_CARD=true;
					}
					else
					{
						model.ENABLE_INVALID_CARD=false;
					}
				}
				if(row["ENABLE_FIRE"]!=null && row["ENABLE_FIRE"].ToString()!="")
				{
					if((row["ENABLE_FIRE"].ToString()=="1")||(row["ENABLE_FIRE"].ToString().ToLower()=="true"))
					{
						model.ENABLE_FIRE=true;
					}
					else
					{
						model.ENABLE_FIRE=false;
					}
				}
				if(row["ENABLE_STEAL"]!=null && row["ENABLE_STEAL"].ToString()!="")
				{
					if((row["ENABLE_STEAL"].ToString()=="1")||(row["ENABLE_STEAL"].ToString().ToLower()=="true"))
					{
						model.ENABLE_STEAL=true;
					}
					else
					{
						model.ENABLE_STEAL=false;
					}
				}
				if(row["ENABLE_FORCE_CARD"]!=null && row["ENABLE_FORCE_CARD"].ToString()!="")
				{
					if((row["ENABLE_FORCE_CARD"].ToString()=="1")||(row["ENABLE_FORCE_CARD"].ToString().ToLower()=="true"))
					{
						model.ENABLE_FORCE_CARD=true;
					}
					else
					{
						model.ENABLE_FORCE_CARD=false;
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
			strSql.Append("select ID,CTRL_ID,CTRL_FORCE_PWD,ENABLE_FORCE_PWD,NOT_CLOSED_TIMEOUT,ENABLE_CLOSED_TIMEOUT,ENABLE_FORCE_ACCESS,ENABLE_FORCE_CLOSE,ENABLE_INVALID_CARD,ENABLE_FIRE,ENABLE_STEAL,ENABLE_FORCE_CARD ");
			strSql.Append(" FROM SMT_ALARM_SETTING ");
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
			strSql.Append(" ID,CTRL_ID,CTRL_FORCE_PWD,ENABLE_FORCE_PWD,NOT_CLOSED_TIMEOUT,ENABLE_CLOSED_TIMEOUT,ENABLE_FORCE_ACCESS,ENABLE_FORCE_CLOSE,ENABLE_INVALID_CARD,ENABLE_FIRE,ENABLE_STEAL,ENABLE_FORCE_CARD ");
			strSql.Append(" FROM SMT_ALARM_SETTING ");
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
			strSql.Append("select count(1) FROM SMT_ALARM_SETTING ");
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
			strSql.Append(")AS Row, T.*  from SMT_ALARM_SETTING T ");
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
			parameters[0].Value = "SMT_ALARM_SETTING";
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

