/**  版本信息模板在安装目录下，可自行修改。
* SMT_TIMESCALE_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_TIMESCALE_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/21 23:00:50   N/A    初版
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
	/// 数据访问类:SMT_TIMESCALE_INFO
	/// </summary>
	public partial class SMT_TIMESCALE_INFO
	{
		public SMT_TIMESCALE_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TIME_NO", "SMT_TIMESCALE_INFO"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TIME_NO,decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_TIMESCALE_INFO");
			strSql.Append(" where TIME_NO=@TIME_NO and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TIME_NO", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = TIME_NO;
			parameters[1].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.SMT_TIMESCALE_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_TIMESCALE_INFO(");
			strSql.Append("TIME_NO,TIME_NAME,TIME_WEEK_DAY1,TIME_WEEK_DAY2,TIME_WEEK_DAY3,TIME_WEEK_DAY4,TIME_WEEK_DAY5,TIME_WEEK_DAY6,TIME_WEEK_DAY7,TIME_DATE_START,TIME_DATE_END,TIME_RANGE_START1,TIME_RANGE_END1,TIME_RANGE_START2,TIME_RANGE_END2,TIME_RANGE_START3,TIME_RANGE_END3,TIME_NEXT_NO)");
			strSql.Append(" values (");
			strSql.Append("@TIME_NO,@TIME_NAME,@TIME_WEEK_DAY1,@TIME_WEEK_DAY2,@TIME_WEEK_DAY3,@TIME_WEEK_DAY4,@TIME_WEEK_DAY5,@TIME_WEEK_DAY6,@TIME_WEEK_DAY7,@TIME_DATE_START,@TIME_DATE_END,@TIME_RANGE_START1,@TIME_RANGE_END1,@TIME_RANGE_START2,@TIME_RANGE_END2,@TIME_RANGE_START3,@TIME_RANGE_END3,@TIME_NEXT_NO)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TIME_NO", SqlDbType.Int,4),
					new SqlParameter("@TIME_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@TIME_WEEK_DAY1", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY2", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY3", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY4", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY5", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY6", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY7", SqlDbType.Bit,1),
					new SqlParameter("@TIME_DATE_START", SqlDbType.Date,3),
					new SqlParameter("@TIME_DATE_END", SqlDbType.Date,3),
					new SqlParameter("@TIME_RANGE_START1", SqlDbType.Time,5),
					new SqlParameter("@TIME_RANGE_END1", SqlDbType.Time,5),
					new SqlParameter("@TIME_RANGE_START2", SqlDbType.Time,5),
					new SqlParameter("@TIME_RANGE_END2", SqlDbType.Time,5),
					new SqlParameter("@TIME_RANGE_START3", SqlDbType.Time,5),
					new SqlParameter("@TIME_RANGE_END3", SqlDbType.Time,5),
					new SqlParameter("@TIME_NEXT_NO", SqlDbType.Int,4)};
			parameters[0].Value = model.TIME_NO;
			parameters[1].Value = model.TIME_NAME;
			parameters[2].Value = model.TIME_WEEK_DAY1;
			parameters[3].Value = model.TIME_WEEK_DAY2;
			parameters[4].Value = model.TIME_WEEK_DAY3;
			parameters[5].Value = model.TIME_WEEK_DAY4;
			parameters[6].Value = model.TIME_WEEK_DAY5;
			parameters[7].Value = model.TIME_WEEK_DAY6;
			parameters[8].Value = model.TIME_WEEK_DAY7;
			parameters[9].Value = model.TIME_DATE_START;
			parameters[10].Value = model.TIME_DATE_END;
			parameters[11].Value = model.TIME_RANGE_START1;
			parameters[12].Value = model.TIME_RANGE_END1;
			parameters[13].Value = model.TIME_RANGE_START2;
			parameters[14].Value = model.TIME_RANGE_END2;
			parameters[15].Value = model.TIME_RANGE_START3;
			parameters[16].Value = model.TIME_RANGE_END3;
			parameters[17].Value = model.TIME_NEXT_NO;

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
		public bool Update(Maticsoft.Model.SMT_TIMESCALE_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_TIMESCALE_INFO set ");
			strSql.Append("TIME_NAME=@TIME_NAME,");
			strSql.Append("TIME_WEEK_DAY1=@TIME_WEEK_DAY1,");
			strSql.Append("TIME_WEEK_DAY2=@TIME_WEEK_DAY2,");
			strSql.Append("TIME_WEEK_DAY3=@TIME_WEEK_DAY3,");
			strSql.Append("TIME_WEEK_DAY4=@TIME_WEEK_DAY4,");
			strSql.Append("TIME_WEEK_DAY5=@TIME_WEEK_DAY5,");
			strSql.Append("TIME_WEEK_DAY6=@TIME_WEEK_DAY6,");
			strSql.Append("TIME_WEEK_DAY7=@TIME_WEEK_DAY7,");
			strSql.Append("TIME_DATE_START=@TIME_DATE_START,");
			strSql.Append("TIME_DATE_END=@TIME_DATE_END,");
			strSql.Append("TIME_RANGE_START1=@TIME_RANGE_START1,");
			strSql.Append("TIME_RANGE_END1=@TIME_RANGE_END1,");
			strSql.Append("TIME_RANGE_START2=@TIME_RANGE_START2,");
			strSql.Append("TIME_RANGE_END2=@TIME_RANGE_END2,");
			strSql.Append("TIME_RANGE_START3=@TIME_RANGE_START3,");
			strSql.Append("TIME_RANGE_END3=@TIME_RANGE_END3,");
			strSql.Append("TIME_NEXT_NO=@TIME_NEXT_NO");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@TIME_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@TIME_WEEK_DAY1", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY2", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY3", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY4", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY5", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY6", SqlDbType.Bit,1),
					new SqlParameter("@TIME_WEEK_DAY7", SqlDbType.Bit,1),
					new SqlParameter("@TIME_DATE_START", SqlDbType.Date,3),
					new SqlParameter("@TIME_DATE_END", SqlDbType.Date,3),
					new SqlParameter("@TIME_RANGE_START1", SqlDbType.Time,5),
					new SqlParameter("@TIME_RANGE_END1", SqlDbType.Time,5),
					new SqlParameter("@TIME_RANGE_START2", SqlDbType.Time,5),
					new SqlParameter("@TIME_RANGE_END2", SqlDbType.Time,5),
					new SqlParameter("@TIME_RANGE_START3", SqlDbType.Time,5),
					new SqlParameter("@TIME_RANGE_END3", SqlDbType.Time,5),
					new SqlParameter("@TIME_NEXT_NO", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Decimal,9),
					new SqlParameter("@TIME_NO", SqlDbType.Int,4)};
			parameters[0].Value = model.TIME_NAME;
			parameters[1].Value = model.TIME_WEEK_DAY1;
			parameters[2].Value = model.TIME_WEEK_DAY2;
			parameters[3].Value = model.TIME_WEEK_DAY3;
			parameters[4].Value = model.TIME_WEEK_DAY4;
			parameters[5].Value = model.TIME_WEEK_DAY5;
			parameters[6].Value = model.TIME_WEEK_DAY6;
			parameters[7].Value = model.TIME_WEEK_DAY7;
			parameters[8].Value = model.TIME_DATE_START;
			parameters[9].Value = model.TIME_DATE_END;
			parameters[10].Value = model.TIME_RANGE_START1;
			parameters[11].Value = model.TIME_RANGE_END1;
			parameters[12].Value = model.TIME_RANGE_START2;
			parameters[13].Value = model.TIME_RANGE_END2;
			parameters[14].Value = model.TIME_RANGE_START3;
			parameters[15].Value = model.TIME_RANGE_END3;
			parameters[16].Value = model.TIME_NEXT_NO;
			parameters[17].Value = model.ID;
			parameters[18].Value = model.TIME_NO;

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
			strSql.Append("delete from SMT_TIMESCALE_INFO ");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TIME_NO,decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_TIMESCALE_INFO ");
			strSql.Append(" where TIME_NO=@TIME_NO and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TIME_NO", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = TIME_NO;
			parameters[1].Value = ID;

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
			strSql.Append("delete from SMT_TIMESCALE_INFO ");
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
		public Maticsoft.Model.SMT_TIMESCALE_INFO GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,TIME_NO,TIME_NAME,TIME_WEEK_DAY1,TIME_WEEK_DAY2,TIME_WEEK_DAY3,TIME_WEEK_DAY4,TIME_WEEK_DAY5,TIME_WEEK_DAY6,TIME_WEEK_DAY7,TIME_DATE_START,TIME_DATE_END,TIME_RANGE_START1,TIME_RANGE_END1,TIME_RANGE_START2,TIME_RANGE_END2,TIME_RANGE_START3,TIME_RANGE_END3,TIME_NEXT_NO from SMT_TIMESCALE_INFO ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_TIMESCALE_INFO model=new Maticsoft.Model.SMT_TIMESCALE_INFO();
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
		public Maticsoft.Model.SMT_TIMESCALE_INFO DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_TIMESCALE_INFO model=new Maticsoft.Model.SMT_TIMESCALE_INFO();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["TIME_NO"]!=null && row["TIME_NO"].ToString()!="")
				{
					model.TIME_NO=int.Parse(row["TIME_NO"].ToString());
				}
				if(row["TIME_NAME"]!=null)
				{
					model.TIME_NAME=row["TIME_NAME"].ToString();
				}
				if(row["TIME_WEEK_DAY1"]!=null && row["TIME_WEEK_DAY1"].ToString()!="")
				{
					if((row["TIME_WEEK_DAY1"].ToString()=="1")||(row["TIME_WEEK_DAY1"].ToString().ToLower()=="true"))
					{
						model.TIME_WEEK_DAY1=true;
					}
					else
					{
						model.TIME_WEEK_DAY1=false;
					}
				}
				if(row["TIME_WEEK_DAY2"]!=null && row["TIME_WEEK_DAY2"].ToString()!="")
				{
					if((row["TIME_WEEK_DAY2"].ToString()=="1")||(row["TIME_WEEK_DAY2"].ToString().ToLower()=="true"))
					{
						model.TIME_WEEK_DAY2=true;
					}
					else
					{
						model.TIME_WEEK_DAY2=false;
					}
				}
				if(row["TIME_WEEK_DAY3"]!=null && row["TIME_WEEK_DAY3"].ToString()!="")
				{
					if((row["TIME_WEEK_DAY3"].ToString()=="1")||(row["TIME_WEEK_DAY3"].ToString().ToLower()=="true"))
					{
						model.TIME_WEEK_DAY3=true;
					}
					else
					{
						model.TIME_WEEK_DAY3=false;
					}
				}
				if(row["TIME_WEEK_DAY4"]!=null && row["TIME_WEEK_DAY4"].ToString()!="")
				{
					if((row["TIME_WEEK_DAY4"].ToString()=="1")||(row["TIME_WEEK_DAY4"].ToString().ToLower()=="true"))
					{
						model.TIME_WEEK_DAY4=true;
					}
					else
					{
						model.TIME_WEEK_DAY4=false;
					}
				}
				if(row["TIME_WEEK_DAY5"]!=null && row["TIME_WEEK_DAY5"].ToString()!="")
				{
					if((row["TIME_WEEK_DAY5"].ToString()=="1")||(row["TIME_WEEK_DAY5"].ToString().ToLower()=="true"))
					{
						model.TIME_WEEK_DAY5=true;
					}
					else
					{
						model.TIME_WEEK_DAY5=false;
					}
				}
				if(row["TIME_WEEK_DAY6"]!=null && row["TIME_WEEK_DAY6"].ToString()!="")
				{
					if((row["TIME_WEEK_DAY6"].ToString()=="1")||(row["TIME_WEEK_DAY6"].ToString().ToLower()=="true"))
					{
						model.TIME_WEEK_DAY6=true;
					}
					else
					{
						model.TIME_WEEK_DAY6=false;
					}
				}
				if(row["TIME_WEEK_DAY7"]!=null && row["TIME_WEEK_DAY7"].ToString()!="")
				{
					if((row["TIME_WEEK_DAY7"].ToString()=="1")||(row["TIME_WEEK_DAY7"].ToString().ToLower()=="true"))
					{
						model.TIME_WEEK_DAY7=true;
					}
					else
					{
						model.TIME_WEEK_DAY7=false;
					}
				}
				if(row["TIME_DATE_START"]!=null && row["TIME_DATE_START"].ToString()!="")
				{
					model.TIME_DATE_START=DateTime.Parse(row["TIME_DATE_START"].ToString());
				}
				if(row["TIME_DATE_END"]!=null && row["TIME_DATE_END"].ToString()!="")
				{
					model.TIME_DATE_END=DateTime.Parse(row["TIME_DATE_END"].ToString());
				}
				if(row["TIME_RANGE_START1"]!=null && row["TIME_RANGE_START1"].ToString()!="")
				{
                    model.TIME_RANGE_START1 = TimeSpan.Parse(row["TIME_RANGE_START1"].ToString());
				}
				if(row["TIME_RANGE_END1"]!=null && row["TIME_RANGE_END1"].ToString()!="")
				{
                    model.TIME_RANGE_END1 = TimeSpan.Parse(row["TIME_RANGE_END1"].ToString());
				}
				if(row["TIME_RANGE_START2"]!=null && row["TIME_RANGE_START2"].ToString()!="")
				{
                    model.TIME_RANGE_START2 = TimeSpan.Parse(row["TIME_RANGE_START2"].ToString());
				}
				if(row["TIME_RANGE_END2"]!=null && row["TIME_RANGE_END2"].ToString()!="")
				{
                    model.TIME_RANGE_END2 = TimeSpan.Parse(row["TIME_RANGE_END2"].ToString());
				}
				if(row["TIME_RANGE_START3"]!=null && row["TIME_RANGE_START3"].ToString()!="")
				{
                    model.TIME_RANGE_START3 = TimeSpan.Parse(row["TIME_RANGE_START3"].ToString());
				}
				if(row["TIME_RANGE_END3"]!=null && row["TIME_RANGE_END3"].ToString()!="")
				{
                    model.TIME_RANGE_END3 = TimeSpan.Parse(row["TIME_RANGE_END3"].ToString());
				}
				if(row["TIME_NEXT_NO"]!=null && row["TIME_NEXT_NO"].ToString()!="")
				{
					model.TIME_NEXT_NO=int.Parse(row["TIME_NEXT_NO"].ToString());
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
			strSql.Append("select ID,TIME_NO,TIME_NAME,TIME_WEEK_DAY1,TIME_WEEK_DAY2,TIME_WEEK_DAY3,TIME_WEEK_DAY4,TIME_WEEK_DAY5,TIME_WEEK_DAY6,TIME_WEEK_DAY7,TIME_DATE_START,TIME_DATE_END,TIME_RANGE_START1,TIME_RANGE_END1,TIME_RANGE_START2,TIME_RANGE_END2,TIME_RANGE_START3,TIME_RANGE_END3,TIME_NEXT_NO ");
			strSql.Append(" FROM SMT_TIMESCALE_INFO ");
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
			strSql.Append(" ID,TIME_NO,TIME_NAME,TIME_WEEK_DAY1,TIME_WEEK_DAY2,TIME_WEEK_DAY3,TIME_WEEK_DAY4,TIME_WEEK_DAY5,TIME_WEEK_DAY6,TIME_WEEK_DAY7,TIME_DATE_START,TIME_DATE_END,TIME_RANGE_START1,TIME_RANGE_END1,TIME_RANGE_START2,TIME_RANGE_END2,TIME_RANGE_START3,TIME_RANGE_END3,TIME_NEXT_NO ");
			strSql.Append(" FROM SMT_TIMESCALE_INFO ");
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
			strSql.Append("select count(1) FROM SMT_TIMESCALE_INFO ");
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
			strSql.Append(")AS Row, T.*  from SMT_TIMESCALE_INFO T ");
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
			parameters[0].Value = "SMT_TIMESCALE_INFO";
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

