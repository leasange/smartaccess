/**  版本信息模板在安装目录下，可自行修改。
* SMT_CTRLR_TASK.cs
*
* 功 能： N/A
* 类 名： SMT_CTRLR_TASK
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/10/7 22:17:03   N/A    初版
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
	/// 数据访问类:SMT_CTRLR_TASK
	/// </summary>
	public partial class SMT_CTRLR_TASK
	{
		public SMT_CTRLR_TASK()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_CTRLR_TASK");
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
		public decimal Add(Maticsoft.Model.SMT_CTRLR_TASK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_CTRLR_TASK(");
			strSql.Append("TASK_NO,TASK_NAME,VALID_STARTDATE,VALID_ENDDATE,ACTION_TIME,MON_STATE,TUE_STATE,THI_STATE,WES_STATE,FRI_STATE,SAT_STATE,SUN_STATE,DOOR_ID,CTRL_STYLE,TASK_DESC)");
			strSql.Append(" values (");
			strSql.Append("@TASK_NO,@TASK_NAME,@VALID_STARTDATE,@VALID_ENDDATE,@ACTION_TIME,@MON_STATE,@TUE_STATE,@THI_STATE,@WES_STATE,@FRI_STATE,@SAT_STATE,@SUN_STATE,@DOOR_ID,@CTRL_STYLE,@TASK_DESC)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TASK_NO", SqlDbType.VarChar,20),
					new SqlParameter("@TASK_NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@VALID_STARTDATE", SqlDbType.Date,3),
					new SqlParameter("@VALID_ENDDATE", SqlDbType.Date,3),
					new SqlParameter("@ACTION_TIME", SqlDbType.Time,5),
					new SqlParameter("@MON_STATE", SqlDbType.Bit,1),
					new SqlParameter("@TUE_STATE", SqlDbType.Bit,1),
					new SqlParameter("@THI_STATE", SqlDbType.Bit,1),
					new SqlParameter("@WES_STATE", SqlDbType.Bit,1),
					new SqlParameter("@FRI_STATE", SqlDbType.Bit,1),
					new SqlParameter("@SAT_STATE", SqlDbType.Bit,1),
					new SqlParameter("@SUN_STATE", SqlDbType.Bit,1),
					new SqlParameter("@DOOR_ID", SqlDbType.VarChar,5000),
					new SqlParameter("@CTRL_STYLE", SqlDbType.TinyInt,1),
					new SqlParameter("@TASK_DESC", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.TASK_NO;
			parameters[1].Value = model.TASK_NAME;
			parameters[2].Value = model.VALID_STARTDATE;
			parameters[3].Value = model.VALID_ENDDATE;
			parameters[4].Value = model.ACTION_TIME;
			parameters[5].Value = model.MON_STATE;
			parameters[6].Value = model.TUE_STATE;
			parameters[7].Value = model.THI_STATE;
			parameters[8].Value = model.WES_STATE;
			parameters[9].Value = model.FRI_STATE;
			parameters[10].Value = model.SAT_STATE;
			parameters[11].Value = model.SUN_STATE;
			parameters[12].Value = model.DOOR_ID;
			parameters[13].Value = model.CTRL_STYLE;
			parameters[14].Value = model.TASK_DESC;

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
		public bool Update(Maticsoft.Model.SMT_CTRLR_TASK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_CTRLR_TASK set ");
			strSql.Append("TASK_NO=@TASK_NO,");
			strSql.Append("TASK_NAME=@TASK_NAME,");
			strSql.Append("VALID_STARTDATE=@VALID_STARTDATE,");
			strSql.Append("VALID_ENDDATE=@VALID_ENDDATE,");
			strSql.Append("ACTION_TIME=@ACTION_TIME,");
			strSql.Append("MON_STATE=@MON_STATE,");
			strSql.Append("TUE_STATE=@TUE_STATE,");
			strSql.Append("THI_STATE=@THI_STATE,");
			strSql.Append("WES_STATE=@WES_STATE,");
			strSql.Append("FRI_STATE=@FRI_STATE,");
			strSql.Append("SAT_STATE=@SAT_STATE,");
			strSql.Append("SUN_STATE=@SUN_STATE,");
			strSql.Append("DOOR_ID=@DOOR_ID,");
			strSql.Append("CTRL_STYLE=@CTRL_STYLE,");
			strSql.Append("TASK_DESC=@TASK_DESC");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@TASK_NO", SqlDbType.VarChar,20),
					new SqlParameter("@TASK_NAME", SqlDbType.NVarChar,200),
					new SqlParameter("@VALID_STARTDATE", SqlDbType.Date,3),
					new SqlParameter("@VALID_ENDDATE", SqlDbType.Date,3),
					new SqlParameter("@ACTION_TIME", SqlDbType.Time,5),
					new SqlParameter("@MON_STATE", SqlDbType.Bit,1),
					new SqlParameter("@TUE_STATE", SqlDbType.Bit,1),
					new SqlParameter("@THI_STATE", SqlDbType.Bit,1),
					new SqlParameter("@WES_STATE", SqlDbType.Bit,1),
					new SqlParameter("@FRI_STATE", SqlDbType.Bit,1),
					new SqlParameter("@SAT_STATE", SqlDbType.Bit,1),
					new SqlParameter("@SUN_STATE", SqlDbType.Bit,1),
					new SqlParameter("@DOOR_ID", SqlDbType.VarChar,5000),
					new SqlParameter("@CTRL_STYLE", SqlDbType.TinyInt,1),
					new SqlParameter("@TASK_DESC", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.TASK_NO;
			parameters[1].Value = model.TASK_NAME;
			parameters[2].Value = model.VALID_STARTDATE;
			parameters[3].Value = model.VALID_ENDDATE;
			parameters[4].Value = model.ACTION_TIME;
			parameters[5].Value = model.MON_STATE;
			parameters[6].Value = model.TUE_STATE;
			parameters[7].Value = model.THI_STATE;
			parameters[8].Value = model.WES_STATE;
			parameters[9].Value = model.FRI_STATE;
			parameters[10].Value = model.SAT_STATE;
			parameters[11].Value = model.SUN_STATE;
			parameters[12].Value = model.DOOR_ID;
			parameters[13].Value = model.CTRL_STYLE;
			parameters[14].Value = model.TASK_DESC;
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
			strSql.Append("delete from SMT_CTRLR_TASK ");
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
			strSql.Append("delete from SMT_CTRLR_TASK ");
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
		public Maticsoft.Model.SMT_CTRLR_TASK GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,TASK_NO,TASK_NAME,VALID_STARTDATE,VALID_ENDDATE,ACTION_TIME,MON_STATE,TUE_STATE,THI_STATE,WES_STATE,FRI_STATE,SAT_STATE,SUN_STATE,DOOR_ID,CTRL_STYLE,TASK_DESC from SMT_CTRLR_TASK ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_CTRLR_TASK model=new Maticsoft.Model.SMT_CTRLR_TASK();
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
		public Maticsoft.Model.SMT_CTRLR_TASK DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_CTRLR_TASK model=new Maticsoft.Model.SMT_CTRLR_TASK();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["TASK_NO"]!=null)
				{
					model.TASK_NO=row["TASK_NO"].ToString();
				}
				if(row["TASK_NAME"]!=null)
				{
					model.TASK_NAME=row["TASK_NAME"].ToString();
				}
				if(row["VALID_STARTDATE"]!=null && row["VALID_STARTDATE"].ToString()!="")
				{
					model.VALID_STARTDATE=DateTime.Parse(row["VALID_STARTDATE"].ToString());
				}
				if(row["VALID_ENDDATE"]!=null && row["VALID_ENDDATE"].ToString()!="")
				{
					model.VALID_ENDDATE=DateTime.Parse(row["VALID_ENDDATE"].ToString());
				}
				if(row["ACTION_TIME"]!=null && row["ACTION_TIME"].ToString()!="")
				{
					model.ACTION_TIME=TimeSpan.Parse(row["ACTION_TIME"].ToString());
				}
				if(row["MON_STATE"]!=null && row["MON_STATE"].ToString()!="")
				{
					if((row["MON_STATE"].ToString()=="1")||(row["MON_STATE"].ToString().ToLower()=="true"))
					{
						model.MON_STATE=true;
					}
					else
					{
						model.MON_STATE=false;
					}
				}
				if(row["TUE_STATE"]!=null && row["TUE_STATE"].ToString()!="")
				{
					if((row["TUE_STATE"].ToString()=="1")||(row["TUE_STATE"].ToString().ToLower()=="true"))
					{
						model.TUE_STATE=true;
					}
					else
					{
						model.TUE_STATE=false;
					}
				}
				if(row["THI_STATE"]!=null && row["THI_STATE"].ToString()!="")
				{
					if((row["THI_STATE"].ToString()=="1")||(row["THI_STATE"].ToString().ToLower()=="true"))
					{
						model.THI_STATE=true;
					}
					else
					{
						model.THI_STATE=false;
					}
				}
				if(row["WES_STATE"]!=null && row["WES_STATE"].ToString()!="")
				{
					if((row["WES_STATE"].ToString()=="1")||(row["WES_STATE"].ToString().ToLower()=="true"))
					{
						model.WES_STATE=true;
					}
					else
					{
						model.WES_STATE=false;
					}
				}
				if(row["FRI_STATE"]!=null && row["FRI_STATE"].ToString()!="")
				{
					if((row["FRI_STATE"].ToString()=="1")||(row["FRI_STATE"].ToString().ToLower()=="true"))
					{
						model.FRI_STATE=true;
					}
					else
					{
						model.FRI_STATE=false;
					}
				}
				if(row["SAT_STATE"]!=null && row["SAT_STATE"].ToString()!="")
				{
					if((row["SAT_STATE"].ToString()=="1")||(row["SAT_STATE"].ToString().ToLower()=="true"))
					{
						model.SAT_STATE=true;
					}
					else
					{
						model.SAT_STATE=false;
					}
				}
				if(row["SUN_STATE"]!=null && row["SUN_STATE"].ToString()!="")
				{
					if((row["SUN_STATE"].ToString()=="1")||(row["SUN_STATE"].ToString().ToLower()=="true"))
					{
						model.SUN_STATE=true;
					}
					else
					{
						model.SUN_STATE=false;
					}
				}
				if(row["DOOR_ID"]!=null)
				{
					model.DOOR_ID=row["DOOR_ID"].ToString();
				}
				if(row["CTRL_STYLE"]!=null && row["CTRL_STYLE"].ToString()!="")
				{
					model.CTRL_STYLE=int.Parse(row["CTRL_STYLE"].ToString());
				}
				if(row["TASK_DESC"]!=null)
				{
					model.TASK_DESC=row["TASK_DESC"].ToString();
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
			strSql.Append("select ID,TASK_NO,TASK_NAME,VALID_STARTDATE,VALID_ENDDATE,ACTION_TIME,MON_STATE,TUE_STATE,THI_STATE,WES_STATE,FRI_STATE,SAT_STATE,SUN_STATE,DOOR_ID,CTRL_STYLE,TASK_DESC ");
			strSql.Append(" FROM SMT_CTRLR_TASK ");
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
			strSql.Append(" ID,TASK_NO,TASK_NAME,VALID_STARTDATE,VALID_ENDDATE,ACTION_TIME,MON_STATE,TUE_STATE,THI_STATE,WES_STATE,FRI_STATE,SAT_STATE,SUN_STATE,DOOR_ID,CTRL_STYLE,TASK_DESC ");
			strSql.Append(" FROM SMT_CTRLR_TASK ");
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
			strSql.Append("select count(1) FROM SMT_CTRLR_TASK ");
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
			strSql.Append(")AS Row, T.*  from SMT_CTRLR_TASK T ");
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
			parameters[0].Value = "SMT_CTRLR_TASK";
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

