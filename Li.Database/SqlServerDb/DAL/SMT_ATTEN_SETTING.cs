/**  版本信息模板在安装目录下，可自行修改。
* SMT_ATTEN_SETTING.cs
*
* 功 能： N/A
* 类 名： SMT_ATTEN_SETTING
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/25 21:10:34   N/A    初版
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
	/// 数据访问类:SMT_ATTEN_SETTING
	/// </summary>
	public partial class SMT_ATTEN_SETTING
	{
		public SMT_ATTEN_SETTING()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_ATTEN_SETTING");
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
		public decimal Add(Maticsoft.Model.SMT_ATTEN_SETTING model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_ATTEN_SETTING(");
			strSql.Append("DUTY_TYPE,DUTY_LATE_MIN,DUTY_LATE_MAX,DUTY_LATE_PUNISH,DUTY_LEAVE_MIN,DUTY_LEAVE_MAX,DUTY_LEAVE_PUNISH,DUTY_EXTRA_MIN,DUTY_SWING_TIMES,DUTY_ON_TIME1,DUTY_OFF_TIME1,DUTY_ON_TIME2,DUTY_OFF_TIME2,DUTY_ONLY_ON,DUTY_ON_EARLIEST,DUTY_WORK_LENGTH,DUTY_FULL_TIME,DUTY_SAT_TYPE,DUTY_SUN_TYPE)");
			strSql.Append(" values (");
			strSql.Append("@DUTY_TYPE,@DUTY_LATE_MIN,@DUTY_LATE_MAX,@DUTY_LATE_PUNISH,@DUTY_LEAVE_MIN,@DUTY_LEAVE_MAX,@DUTY_LEAVE_PUNISH,@DUTY_EXTRA_MIN,@DUTY_SWING_TIMES,@DUTY_ON_TIME1,@DUTY_OFF_TIME1,@DUTY_ON_TIME2,@DUTY_OFF_TIME2,@DUTY_ONLY_ON,@DUTY_ON_EARLIEST,@DUTY_WORK_LENGTH,@DUTY_FULL_TIME,@DUTY_SAT_TYPE,@DUTY_SUN_TYPE)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DUTY_TYPE", SqlDbType.TinyInt,1),
					new SqlParameter("@DUTY_LATE_MIN", SqlDbType.Int,4),
					new SqlParameter("@DUTY_LATE_MAX", SqlDbType.Int,4),
					new SqlParameter("@DUTY_LATE_PUNISH", SqlDbType.Float,8),
					new SqlParameter("@DUTY_LEAVE_MIN", SqlDbType.Int,4),
					new SqlParameter("@DUTY_LEAVE_MAX", SqlDbType.Int,4),
					new SqlParameter("@DUTY_LEAVE_PUNISH", SqlDbType.Float,8),
					new SqlParameter("@DUTY_EXTRA_MIN", SqlDbType.Int,4),
					new SqlParameter("@DUTY_SWING_TIMES", SqlDbType.TinyInt,1),
					new SqlParameter("@DUTY_ON_TIME1", SqlDbType.Time,5),
					new SqlParameter("@DUTY_OFF_TIME1", SqlDbType.Time,5),
					new SqlParameter("@DUTY_ON_TIME2", SqlDbType.Time,5),
					new SqlParameter("@DUTY_OFF_TIME2", SqlDbType.Time,5),
					new SqlParameter("@DUTY_ONLY_ON", SqlDbType.Bit,1),
					new SqlParameter("@DUTY_ON_EARLIEST", SqlDbType.Time,5),
					new SqlParameter("@DUTY_WORK_LENGTH", SqlDbType.Float,8),
					new SqlParameter("@DUTY_FULL_TIME", SqlDbType.Bit,1),
					new SqlParameter("@DUTY_SAT_TYPE", SqlDbType.TinyInt,1),
					new SqlParameter("@DUTY_SUN_TYPE", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.DUTY_TYPE;
			parameters[1].Value = model.DUTY_LATE_MIN;
			parameters[2].Value = model.DUTY_LATE_MAX;
			parameters[3].Value = model.DUTY_LATE_PUNISH;
			parameters[4].Value = model.DUTY_LEAVE_MIN;
			parameters[5].Value = model.DUTY_LEAVE_MAX;
			parameters[6].Value = model.DUTY_LEAVE_PUNISH;
			parameters[7].Value = model.DUTY_EXTRA_MIN;
			parameters[8].Value = model.DUTY_SWING_TIMES;
			parameters[9].Value = model.DUTY_ON_TIME1;
			parameters[10].Value = model.DUTY_OFF_TIME1;
			parameters[11].Value = model.DUTY_ON_TIME2;
			parameters[12].Value = model.DUTY_OFF_TIME2;
			parameters[13].Value = model.DUTY_ONLY_ON;
			parameters[14].Value = model.DUTY_ON_EARLIEST;
			parameters[15].Value = model.DUTY_WORK_LENGTH;
			parameters[16].Value = model.DUTY_FULL_TIME;
			parameters[17].Value = model.DUTY_SAT_TYPE;
			parameters[18].Value = model.DUTY_SUN_TYPE;

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
		public bool Update(Maticsoft.Model.SMT_ATTEN_SETTING model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_ATTEN_SETTING set ");
			strSql.Append("DUTY_TYPE=@DUTY_TYPE,");
			strSql.Append("DUTY_LATE_MIN=@DUTY_LATE_MIN,");
			strSql.Append("DUTY_LATE_MAX=@DUTY_LATE_MAX,");
			strSql.Append("DUTY_LATE_PUNISH=@DUTY_LATE_PUNISH,");
			strSql.Append("DUTY_LEAVE_MIN=@DUTY_LEAVE_MIN,");
			strSql.Append("DUTY_LEAVE_MAX=@DUTY_LEAVE_MAX,");
			strSql.Append("DUTY_LEAVE_PUNISH=@DUTY_LEAVE_PUNISH,");
			strSql.Append("DUTY_EXTRA_MIN=@DUTY_EXTRA_MIN,");
			strSql.Append("DUTY_SWING_TIMES=@DUTY_SWING_TIMES,");
			strSql.Append("DUTY_ON_TIME1=@DUTY_ON_TIME1,");
			strSql.Append("DUTY_OFF_TIME1=@DUTY_OFF_TIME1,");
			strSql.Append("DUTY_ON_TIME2=@DUTY_ON_TIME2,");
			strSql.Append("DUTY_OFF_TIME2=@DUTY_OFF_TIME2,");
			strSql.Append("DUTY_ONLY_ON=@DUTY_ONLY_ON,");
			strSql.Append("DUTY_ON_EARLIEST=@DUTY_ON_EARLIEST,");
			strSql.Append("DUTY_WORK_LENGTH=@DUTY_WORK_LENGTH,");
			strSql.Append("DUTY_FULL_TIME=@DUTY_FULL_TIME,");
			strSql.Append("DUTY_SAT_TYPE=@DUTY_SAT_TYPE,");
			strSql.Append("DUTY_SUN_TYPE=@DUTY_SUN_TYPE");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@DUTY_TYPE", SqlDbType.TinyInt,1),
					new SqlParameter("@DUTY_LATE_MIN", SqlDbType.Int,4),
					new SqlParameter("@DUTY_LATE_MAX", SqlDbType.Int,4),
					new SqlParameter("@DUTY_LATE_PUNISH", SqlDbType.Float,8),
					new SqlParameter("@DUTY_LEAVE_MIN", SqlDbType.Int,4),
					new SqlParameter("@DUTY_LEAVE_MAX", SqlDbType.Int,4),
					new SqlParameter("@DUTY_LEAVE_PUNISH", SqlDbType.Float,8),
					new SqlParameter("@DUTY_EXTRA_MIN", SqlDbType.Int,4),
					new SqlParameter("@DUTY_SWING_TIMES", SqlDbType.TinyInt,1),
					new SqlParameter("@DUTY_ON_TIME1", SqlDbType.Time,5),
					new SqlParameter("@DUTY_OFF_TIME1", SqlDbType.Time,5),
					new SqlParameter("@DUTY_ON_TIME2", SqlDbType.Time,5),
					new SqlParameter("@DUTY_OFF_TIME2", SqlDbType.Time,5),
					new SqlParameter("@DUTY_ONLY_ON", SqlDbType.Bit,1),
					new SqlParameter("@DUTY_ON_EARLIEST", SqlDbType.Time,5),
					new SqlParameter("@DUTY_WORK_LENGTH", SqlDbType.Float,8),
					new SqlParameter("@DUTY_FULL_TIME", SqlDbType.Bit,1),
					new SqlParameter("@DUTY_SAT_TYPE", SqlDbType.TinyInt,1),
					new SqlParameter("@DUTY_SUN_TYPE", SqlDbType.TinyInt,1),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.DUTY_TYPE;
			parameters[1].Value = model.DUTY_LATE_MIN;
			parameters[2].Value = model.DUTY_LATE_MAX;
			parameters[3].Value = model.DUTY_LATE_PUNISH;
			parameters[4].Value = model.DUTY_LEAVE_MIN;
			parameters[5].Value = model.DUTY_LEAVE_MAX;
			parameters[6].Value = model.DUTY_LEAVE_PUNISH;
			parameters[7].Value = model.DUTY_EXTRA_MIN;
			parameters[8].Value = model.DUTY_SWING_TIMES;
			parameters[9].Value = model.DUTY_ON_TIME1;
			parameters[10].Value = model.DUTY_OFF_TIME1;
			parameters[11].Value = model.DUTY_ON_TIME2;
			parameters[12].Value = model.DUTY_OFF_TIME2;
			parameters[13].Value = model.DUTY_ONLY_ON;
			parameters[14].Value = model.DUTY_ON_EARLIEST;
			parameters[15].Value = model.DUTY_WORK_LENGTH;
			parameters[16].Value = model.DUTY_FULL_TIME;
			parameters[17].Value = model.DUTY_SAT_TYPE;
			parameters[18].Value = model.DUTY_SUN_TYPE;
			parameters[19].Value = model.ID;

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
			strSql.Append("delete from SMT_ATTEN_SETTING ");
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
			strSql.Append("delete from SMT_ATTEN_SETTING ");
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
		public Maticsoft.Model.SMT_ATTEN_SETTING GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,DUTY_TYPE,DUTY_LATE_MIN,DUTY_LATE_MAX,DUTY_LATE_PUNISH,DUTY_LEAVE_MIN,DUTY_LEAVE_MAX,DUTY_LEAVE_PUNISH,DUTY_EXTRA_MIN,DUTY_SWING_TIMES,DUTY_ON_TIME1,DUTY_OFF_TIME1,DUTY_ON_TIME2,DUTY_OFF_TIME2,DUTY_ONLY_ON,DUTY_ON_EARLIEST,DUTY_WORK_LENGTH,DUTY_FULL_TIME,DUTY_SAT_TYPE,DUTY_SUN_TYPE from SMT_ATTEN_SETTING ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_ATTEN_SETTING model=new Maticsoft.Model.SMT_ATTEN_SETTING();
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
		public Maticsoft.Model.SMT_ATTEN_SETTING DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_ATTEN_SETTING model=new Maticsoft.Model.SMT_ATTEN_SETTING();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["DUTY_TYPE"]!=null && row["DUTY_TYPE"].ToString()!="")
				{
					model.DUTY_TYPE=int.Parse(row["DUTY_TYPE"].ToString());
				}
				if(row["DUTY_LATE_MIN"]!=null && row["DUTY_LATE_MIN"].ToString()!="")
				{
					model.DUTY_LATE_MIN=int.Parse(row["DUTY_LATE_MIN"].ToString());
				}
				if(row["DUTY_LATE_MAX"]!=null && row["DUTY_LATE_MAX"].ToString()!="")
				{
					model.DUTY_LATE_MAX=int.Parse(row["DUTY_LATE_MAX"].ToString());
				}
				if(row["DUTY_LATE_PUNISH"]!=null && row["DUTY_LATE_PUNISH"].ToString()!="")
				{
					model.DUTY_LATE_PUNISH=decimal.Parse(row["DUTY_LATE_PUNISH"].ToString());
				}
				if(row["DUTY_LEAVE_MIN"]!=null && row["DUTY_LEAVE_MIN"].ToString()!="")
				{
					model.DUTY_LEAVE_MIN=int.Parse(row["DUTY_LEAVE_MIN"].ToString());
				}
				if(row["DUTY_LEAVE_MAX"]!=null && row["DUTY_LEAVE_MAX"].ToString()!="")
				{
					model.DUTY_LEAVE_MAX=int.Parse(row["DUTY_LEAVE_MAX"].ToString());
				}
				if(row["DUTY_LEAVE_PUNISH"]!=null && row["DUTY_LEAVE_PUNISH"].ToString()!="")
				{
					model.DUTY_LEAVE_PUNISH=decimal.Parse(row["DUTY_LEAVE_PUNISH"].ToString());
				}
				if(row["DUTY_EXTRA_MIN"]!=null && row["DUTY_EXTRA_MIN"].ToString()!="")
				{
					model.DUTY_EXTRA_MIN=int.Parse(row["DUTY_EXTRA_MIN"].ToString());
				}
				if(row["DUTY_SWING_TIMES"]!=null && row["DUTY_SWING_TIMES"].ToString()!="")
				{
					model.DUTY_SWING_TIMES=int.Parse(row["DUTY_SWING_TIMES"].ToString());
				}
				if(row["DUTY_ON_TIME1"]!=null && row["DUTY_ON_TIME1"].ToString()!="")
				{
                    model.DUTY_ON_TIME1 = TimeSpan.Parse(row["DUTY_ON_TIME1"].ToString());
				}
				if(row["DUTY_OFF_TIME1"]!=null && row["DUTY_OFF_TIME1"].ToString()!="")
				{
                    model.DUTY_OFF_TIME1 = TimeSpan.Parse(row["DUTY_OFF_TIME1"].ToString());
				}
				if(row["DUTY_ON_TIME2"]!=null && row["DUTY_ON_TIME2"].ToString()!="")
				{
                    model.DUTY_ON_TIME2 = TimeSpan.Parse(row["DUTY_ON_TIME2"].ToString());
				}
				if(row["DUTY_OFF_TIME2"]!=null && row["DUTY_OFF_TIME2"].ToString()!="")
				{
                    model.DUTY_OFF_TIME2 = TimeSpan.Parse(row["DUTY_OFF_TIME2"].ToString());
				}
				if(row["DUTY_ONLY_ON"]!=null && row["DUTY_ONLY_ON"].ToString()!="")
				{
					if((row["DUTY_ONLY_ON"].ToString()=="1")||(row["DUTY_ONLY_ON"].ToString().ToLower()=="true"))
					{
						model.DUTY_ONLY_ON=true;
					}
					else
					{
						model.DUTY_ONLY_ON=false;
					}
				}
				if(row["DUTY_ON_EARLIEST"]!=null && row["DUTY_ON_EARLIEST"].ToString()!="")
				{
                    model.DUTY_ON_EARLIEST = TimeSpan.Parse(row["DUTY_ON_EARLIEST"].ToString());
				}
				if(row["DUTY_WORK_LENGTH"]!=null && row["DUTY_WORK_LENGTH"].ToString()!="")
				{
					model.DUTY_WORK_LENGTH=decimal.Parse(row["DUTY_WORK_LENGTH"].ToString());
				}
				if(row["DUTY_FULL_TIME"]!=null && row["DUTY_FULL_TIME"].ToString()!="")
				{
					if((row["DUTY_FULL_TIME"].ToString()=="1")||(row["DUTY_FULL_TIME"].ToString().ToLower()=="true"))
					{
						model.DUTY_FULL_TIME=true;
					}
					else
					{
						model.DUTY_FULL_TIME=false;
					}
				}
				if(row["DUTY_SAT_TYPE"]!=null && row["DUTY_SAT_TYPE"].ToString()!="")
				{
					model.DUTY_SAT_TYPE=int.Parse(row["DUTY_SAT_TYPE"].ToString());
				}
				if(row["DUTY_SUN_TYPE"]!=null && row["DUTY_SUN_TYPE"].ToString()!="")
				{
					model.DUTY_SUN_TYPE=int.Parse(row["DUTY_SUN_TYPE"].ToString());
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
			strSql.Append("select ID,DUTY_TYPE,DUTY_LATE_MIN,DUTY_LATE_MAX,DUTY_LATE_PUNISH,DUTY_LEAVE_MIN,DUTY_LEAVE_MAX,DUTY_LEAVE_PUNISH,DUTY_EXTRA_MIN,DUTY_SWING_TIMES,DUTY_ON_TIME1,DUTY_OFF_TIME1,DUTY_ON_TIME2,DUTY_OFF_TIME2,DUTY_ONLY_ON,DUTY_ON_EARLIEST,DUTY_WORK_LENGTH,DUTY_FULL_TIME,DUTY_SAT_TYPE,DUTY_SUN_TYPE ");
			strSql.Append(" FROM SMT_ATTEN_SETTING ");
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
			strSql.Append(" ID,DUTY_TYPE,DUTY_LATE_MIN,DUTY_LATE_MAX,DUTY_LATE_PUNISH,DUTY_LEAVE_MIN,DUTY_LEAVE_MAX,DUTY_LEAVE_PUNISH,DUTY_EXTRA_MIN,DUTY_SWING_TIMES,DUTY_ON_TIME1,DUTY_OFF_TIME1,DUTY_ON_TIME2,DUTY_OFF_TIME2,DUTY_ONLY_ON,DUTY_ON_EARLIEST,DUTY_WORK_LENGTH,DUTY_FULL_TIME,DUTY_SAT_TYPE,DUTY_SUN_TYPE ");
			strSql.Append(" FROM SMT_ATTEN_SETTING ");
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
			strSql.Append("select count(1) FROM SMT_ATTEN_SETTING ");
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
			strSql.Append(")AS Row, T.*  from SMT_ATTEN_SETTING T ");
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
			parameters[0].Value = "SMT_ATTEN_SETTING";
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

