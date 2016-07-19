/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/13 20:12:29   N/A    初版
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
	/// 数据访问类:SMT_STAFF_INFO
	/// </summary>
	public partial class SMT_STAFF_INFO
	{
		public SMT_STAFF_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_STAFF_INFO");
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
		public decimal Add(Maticsoft.Model.SMT_STAFF_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_STAFF_INFO(");
			strSql.Append("ORG_ID,STAFF_NO_TEMPLET,STAFF_NO_TYPENAME,STAFF_NO,WORK_NO,REAL_NAME,SEX,JOB,BIRTHDAY,POLITICS,SKIIL_LEVEL,CER_NAME,CER_NO,TEL,MOBILEPHONE,NATIVE,NATION,RELIGION,EDUCATIONAL,EMAIL,VALID_STARTTIME,VALID_ENDTIME,ADDRESS,PHOTO,CER_PHONE1,CER_PHONE2,PRINT_TEMPLET_ID)");
			strSql.Append(" values (");
			strSql.Append("@ORG_ID,@STAFF_NO_TEMPLET,@STAFF_NO_TYPENAME,@STAFF_NO,@WORK_NO,@REAL_NAME,@SEX,@JOB,@BIRTHDAY,@POLITICS,@SKIIL_LEVEL,@CER_NAME,@CER_NO,@TEL,@MOBILEPHONE,@NATIVE,@NATION,@RELIGION,@EDUCATIONAL,@EMAIL,@VALID_STARTTIME,@VALID_ENDTIME,@ADDRESS,@PHOTO,@CER_PHONE1,@CER_PHONE2,@PRINT_TEMPLET_ID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ORG_ID", SqlDbType.Decimal,9),
					new SqlParameter("@STAFF_NO_TEMPLET", SqlDbType.Decimal,9),
					new SqlParameter("@STAFF_NO_TYPENAME", SqlDbType.NVarChar,100),
					new SqlParameter("@STAFF_NO", SqlDbType.NVarChar,400),
					new SqlParameter("@WORK_NO", SqlDbType.NVarChar,400),
					new SqlParameter("@REAL_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@SEX", SqlDbType.TinyInt,1),
					new SqlParameter("@JOB", SqlDbType.NVarChar,200),
					new SqlParameter("@BIRTHDAY", SqlDbType.Date,3),
					new SqlParameter("@POLITICS", SqlDbType.NVarChar,100),
					new SqlParameter("@SKIIL_LEVEL", SqlDbType.NVarChar,100),
					new SqlParameter("@CER_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@CER_NO", SqlDbType.NVarChar,400),
					new SqlParameter("@TEL", SqlDbType.NVarChar,100),
					new SqlParameter("@MOBILEPHONE", SqlDbType.NVarChar,100),
					new SqlParameter("@NATIVE", SqlDbType.NVarChar,400),
					new SqlParameter("@NATION", SqlDbType.NVarChar,100),
					new SqlParameter("@RELIGION", SqlDbType.NVarChar,100),
					new SqlParameter("@EDUCATIONAL", SqlDbType.NVarChar,100),
					new SqlParameter("@EMAIL", SqlDbType.NVarChar,100),
					new SqlParameter("@VALID_STARTTIME", SqlDbType.DateTime),
					new SqlParameter("@VALID_ENDTIME", SqlDbType.DateTime),
					new SqlParameter("@ADDRESS", SqlDbType.NVarChar,400),
					new SqlParameter("@PHOTO", SqlDbType.Image),
					new SqlParameter("@CER_PHONE1", SqlDbType.Image),
					new SqlParameter("@CER_PHONE2", SqlDbType.Image),
					new SqlParameter("@PRINT_TEMPLET_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ORG_ID;
			parameters[1].Value = model.STAFF_NO_TEMPLET;
			parameters[2].Value = model.STAFF_NO_TYPENAME;
			parameters[3].Value = model.STAFF_NO;
			parameters[4].Value = model.WORK_NO;
			parameters[5].Value = model.REAL_NAME;
			parameters[6].Value = model.SEX;
			parameters[7].Value = model.JOB;
			parameters[8].Value = model.BIRTHDAY;
			parameters[9].Value = model.POLITICS;
			parameters[10].Value = model.SKIIL_LEVEL;
			parameters[11].Value = model.CER_NAME;
			parameters[12].Value = model.CER_NO;
			parameters[13].Value = model.TEL;
			parameters[14].Value = model.MOBILEPHONE;
			parameters[15].Value = model.NATIVE;
			parameters[16].Value = model.NATION;
			parameters[17].Value = model.RELIGION;
			parameters[18].Value = model.EDUCATIONAL;
			parameters[19].Value = model.EMAIL;
			parameters[20].Value = model.VALID_STARTTIME;
			parameters[21].Value = model.VALID_ENDTIME;
			parameters[22].Value = model.ADDRESS;
			parameters[23].Value = model.PHOTO;
			parameters[24].Value = model.CER_PHONE1;
			parameters[25].Value = model.CER_PHONE2;
			parameters[26].Value = model.PRINT_TEMPLET_ID;

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
		public bool Update(Maticsoft.Model.SMT_STAFF_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_STAFF_INFO set ");
			strSql.Append("ORG_ID=@ORG_ID,");
			strSql.Append("STAFF_NO_TEMPLET=@STAFF_NO_TEMPLET,");
			strSql.Append("STAFF_NO_TYPENAME=@STAFF_NO_TYPENAME,");
			strSql.Append("STAFF_NO=@STAFF_NO,");
			strSql.Append("WORK_NO=@WORK_NO,");
			strSql.Append("REAL_NAME=@REAL_NAME,");
			strSql.Append("SEX=@SEX,");
			strSql.Append("JOB=@JOB,");
			strSql.Append("BIRTHDAY=@BIRTHDAY,");
			strSql.Append("POLITICS=@POLITICS,");
			strSql.Append("SKIIL_LEVEL=@SKIIL_LEVEL,");
			strSql.Append("CER_NAME=@CER_NAME,");
			strSql.Append("CER_NO=@CER_NO,");
			strSql.Append("TEL=@TEL,");
			strSql.Append("MOBILEPHONE=@MOBILEPHONE,");
			strSql.Append("NATIVE=@NATIVE,");
			strSql.Append("NATION=@NATION,");
			strSql.Append("RELIGION=@RELIGION,");
			strSql.Append("EDUCATIONAL=@EDUCATIONAL,");
			strSql.Append("EMAIL=@EMAIL,");
			strSql.Append("VALID_STARTTIME=@VALID_STARTTIME,");
			strSql.Append("VALID_ENDTIME=@VALID_ENDTIME,");
			strSql.Append("ADDRESS=@ADDRESS,");
			strSql.Append("PHOTO=@PHOTO,");
			strSql.Append("CER_PHONE1=@CER_PHONE1,");
			strSql.Append("CER_PHONE2=@CER_PHONE2,");
			strSql.Append("PRINT_TEMPLET_ID=@PRINT_TEMPLET_ID");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ORG_ID", SqlDbType.Decimal,9),
					new SqlParameter("@STAFF_NO_TEMPLET", SqlDbType.Decimal,9),
					new SqlParameter("@STAFF_NO_TYPENAME", SqlDbType.NVarChar,100),
					new SqlParameter("@STAFF_NO", SqlDbType.NVarChar,400),
					new SqlParameter("@WORK_NO", SqlDbType.NVarChar,400),
					new SqlParameter("@REAL_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@SEX", SqlDbType.TinyInt,1),
					new SqlParameter("@JOB", SqlDbType.NVarChar,200),
					new SqlParameter("@BIRTHDAY", SqlDbType.Date,3),
					new SqlParameter("@POLITICS", SqlDbType.NVarChar,100),
					new SqlParameter("@SKIIL_LEVEL", SqlDbType.NVarChar,100),
					new SqlParameter("@CER_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@CER_NO", SqlDbType.NVarChar,400),
					new SqlParameter("@TEL", SqlDbType.NVarChar,100),
					new SqlParameter("@MOBILEPHONE", SqlDbType.NVarChar,100),
					new SqlParameter("@NATIVE", SqlDbType.NVarChar,400),
					new SqlParameter("@NATION", SqlDbType.NVarChar,100),
					new SqlParameter("@RELIGION", SqlDbType.NVarChar,100),
					new SqlParameter("@EDUCATIONAL", SqlDbType.NVarChar,100),
					new SqlParameter("@EMAIL", SqlDbType.NVarChar,100),
					new SqlParameter("@VALID_STARTTIME", SqlDbType.DateTime),
					new SqlParameter("@VALID_ENDTIME", SqlDbType.DateTime),
					new SqlParameter("@ADDRESS", SqlDbType.NVarChar,400),
					new SqlParameter("@PHOTO", SqlDbType.Image),
					new SqlParameter("@CER_PHONE1", SqlDbType.Image),
					new SqlParameter("@CER_PHONE2", SqlDbType.Image),
					new SqlParameter("@PRINT_TEMPLET_ID", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ORG_ID;
			parameters[1].Value = model.STAFF_NO_TEMPLET;
			parameters[2].Value = model.STAFF_NO_TYPENAME;
			parameters[3].Value = model.STAFF_NO;
			parameters[4].Value = model.WORK_NO;
			parameters[5].Value = model.REAL_NAME;
			parameters[6].Value = model.SEX;
			parameters[7].Value = model.JOB;
			parameters[8].Value = model.BIRTHDAY;
			parameters[9].Value = model.POLITICS;
			parameters[10].Value = model.SKIIL_LEVEL;
			parameters[11].Value = model.CER_NAME;
			parameters[12].Value = model.CER_NO;
			parameters[13].Value = model.TEL;
			parameters[14].Value = model.MOBILEPHONE;
			parameters[15].Value = model.NATIVE;
			parameters[16].Value = model.NATION;
			parameters[17].Value = model.RELIGION;
			parameters[18].Value = model.EDUCATIONAL;
			parameters[19].Value = model.EMAIL;
			parameters[20].Value = model.VALID_STARTTIME;
			parameters[21].Value = model.VALID_ENDTIME;
			parameters[22].Value = model.ADDRESS;
			parameters[23].Value = model.PHOTO;
			parameters[24].Value = model.CER_PHONE1;
			parameters[25].Value = model.CER_PHONE2;
			parameters[26].Value = model.PRINT_TEMPLET_ID;
			parameters[27].Value = model.ID;

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
			strSql.Append("delete from SMT_STAFF_INFO ");
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
			strSql.Append("delete from SMT_STAFF_INFO ");
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
		public Maticsoft.Model.SMT_STAFF_INFO GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ORG_ID,STAFF_NO_TEMPLET,STAFF_NO_TYPENAME,STAFF_NO,WORK_NO,REAL_NAME,SEX,JOB,BIRTHDAY,POLITICS,SKIIL_LEVEL,CER_NAME,CER_NO,TEL,MOBILEPHONE,NATIVE,NATION,RELIGION,EDUCATIONAL,EMAIL,VALID_STARTTIME,VALID_ENDTIME,ADDRESS,PHOTO,CER_PHONE1,CER_PHONE2,PRINT_TEMPLET_ID from SMT_STAFF_INFO ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_STAFF_INFO model=new Maticsoft.Model.SMT_STAFF_INFO();
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
		public Maticsoft.Model.SMT_STAFF_INFO DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_STAFF_INFO model=new Maticsoft.Model.SMT_STAFF_INFO();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["ORG_ID"]!=null && row["ORG_ID"].ToString()!="")
				{
					model.ORG_ID=decimal.Parse(row["ORG_ID"].ToString());
				}
				if(row["STAFF_NO_TEMPLET"]!=null && row["STAFF_NO_TEMPLET"].ToString()!="")
				{
					model.STAFF_NO_TEMPLET=decimal.Parse(row["STAFF_NO_TEMPLET"].ToString());
				}
				if(row["STAFF_NO_TYPENAME"]!=null)
				{
					model.STAFF_NO_TYPENAME=row["STAFF_NO_TYPENAME"].ToString();
				}
				if(row["STAFF_NO"]!=null)
				{
					model.STAFF_NO=row["STAFF_NO"].ToString();
				}
				if(row["WORK_NO"]!=null)
				{
					model.WORK_NO=row["WORK_NO"].ToString();
				}
				if(row["REAL_NAME"]!=null)
				{
					model.REAL_NAME=row["REAL_NAME"].ToString();
				}
				if(row["SEX"]!=null && row["SEX"].ToString()!="")
				{
					model.SEX=int.Parse(row["SEX"].ToString());
				}
				if(row["JOB"]!=null)
				{
					model.JOB=row["JOB"].ToString();
				}
				if(row["BIRTHDAY"]!=null && row["BIRTHDAY"].ToString()!="")
				{
					model.BIRTHDAY=DateTime.Parse(row["BIRTHDAY"].ToString());
				}
				if(row["POLITICS"]!=null)
				{
					model.POLITICS=row["POLITICS"].ToString();
				}
				if(row["SKIIL_LEVEL"]!=null)
				{
					model.SKIIL_LEVEL=row["SKIIL_LEVEL"].ToString();
				}
				if(row["CER_NAME"]!=null)
				{
					model.CER_NAME=row["CER_NAME"].ToString();
				}
				if(row["CER_NO"]!=null)
				{
					model.CER_NO=row["CER_NO"].ToString();
				}
				if(row["TEL"]!=null)
				{
					model.TEL=row["TEL"].ToString();
				}
				if(row["MOBILEPHONE"]!=null)
				{
					model.MOBILEPHONE=row["MOBILEPHONE"].ToString();
				}
				if(row["NATIVE"]!=null)
				{
					model.NATIVE=row["NATIVE"].ToString();
				}
				if(row["NATION"]!=null)
				{
					model.NATION=row["NATION"].ToString();
				}
				if(row["RELIGION"]!=null)
				{
					model.RELIGION=row["RELIGION"].ToString();
				}
				if(row["EDUCATIONAL"]!=null)
				{
					model.EDUCATIONAL=row["EDUCATIONAL"].ToString();
				}
				if(row["EMAIL"]!=null)
				{
					model.EMAIL=row["EMAIL"].ToString();
				}
				if(row["VALID_STARTTIME"]!=null && row["VALID_STARTTIME"].ToString()!="")
				{
					model.VALID_STARTTIME=DateTime.Parse(row["VALID_STARTTIME"].ToString());
				}
				if(row["VALID_ENDTIME"]!=null && row["VALID_ENDTIME"].ToString()!="")
				{
					model.VALID_ENDTIME=DateTime.Parse(row["VALID_ENDTIME"].ToString());
				}
				if(row["ADDRESS"]!=null)
				{
					model.ADDRESS=row["ADDRESS"].ToString();
				}
				if(row["PHOTO"]!=null && row["PHOTO"].ToString()!="")
				{
					model.PHOTO=(byte[])row["PHOTO"];
				}
				if(row["CER_PHONE1"]!=null && row["CER_PHONE1"].ToString()!="")
				{
					model.CER_PHONE1=(byte[])row["CER_PHONE1"];
				}
				if(row["CER_PHONE2"]!=null && row["CER_PHONE2"].ToString()!="")
				{
					model.CER_PHONE2=(byte[])row["CER_PHONE2"];
				}
				if(row["PRINT_TEMPLET_ID"]!=null && row["PRINT_TEMPLET_ID"].ToString()!="")
				{
					model.PRINT_TEMPLET_ID=decimal.Parse(row["PRINT_TEMPLET_ID"].ToString());
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
			strSql.Append("select ID,ORG_ID,STAFF_NO_TEMPLET,STAFF_NO_TYPENAME,STAFF_NO,WORK_NO,REAL_NAME,SEX,JOB,BIRTHDAY,POLITICS,SKIIL_LEVEL,CER_NAME,CER_NO,TEL,MOBILEPHONE,NATIVE,NATION,RELIGION,EDUCATIONAL,EMAIL,VALID_STARTTIME,VALID_ENDTIME,ADDRESS,PHOTO,CER_PHONE1,CER_PHONE2,PRINT_TEMPLET_ID ");
			strSql.Append(" FROM SMT_STAFF_INFO ");
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
			strSql.Append(" ID,ORG_ID,STAFF_NO_TEMPLET,STAFF_NO_TYPENAME,STAFF_NO,WORK_NO,REAL_NAME,SEX,JOB,BIRTHDAY,POLITICS,SKIIL_LEVEL,CER_NAME,CER_NO,TEL,MOBILEPHONE,NATIVE,NATION,RELIGION,EDUCATIONAL,EMAIL,VALID_STARTTIME,VALID_ENDTIME,ADDRESS,PHOTO,CER_PHONE1,CER_PHONE2,PRINT_TEMPLET_ID ");
			strSql.Append(" FROM SMT_STAFF_INFO ");
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
			strSql.Append("select count(1) FROM SMT_STAFF_INFO ");
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
			strSql.Append(")AS Row, T.*  from SMT_STAFF_INFO T ");
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
			parameters[0].Value = "SMT_STAFF_INFO";
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

