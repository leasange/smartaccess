/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/1 23:35:04   N/A    初版
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SMT_STAFF_INFO(");
            strSql.Append("ORG_ID,STAFF_NO_TEMPLET,STAFF_NO,REAL_NAME,SEX,JOB,BIRTHDAY,POLITICS,MARRIED,SKIIL_LEVEL,CER_NAME,CER_NO,TELE_PHONE,CELL_PHONE,NATIVE,NATION,RELIGION,EDUCATIONAL,EMAIL,VALID_STARTTIME,VALID_ENDTIME,ENTRY_TIME,ABORT_TIME,ADDRESS,PHOTO,CER_PHOTO_FRONT,CER_PHOTO_BACK,PRINT_TEMPLET_ID,IS_FORBIDDEN,IS_DELETE,REG_TIME,DEL_TIME,FORBIDDEN_TIME,ENABLE_TIME,MODIFY_TIME)");
            strSql.Append(" values (");
            strSql.Append("@ORG_ID,@STAFF_NO_TEMPLET,@STAFF_NO,@REAL_NAME,@SEX,@JOB,@BIRTHDAY,@POLITICS,@MARRIED,@SKIIL_LEVEL,@CER_NAME,@CER_NO,@TELE_PHONE,@CELL_PHONE,@NATIVE,@NATION,@RELIGION,@EDUCATIONAL,@EMAIL,@VALID_STARTTIME,@VALID_ENDTIME,@ENTRY_TIME,@ABORT_TIME,@ADDRESS,@PHOTO,@CER_PHOTO_FRONT,@CER_PHOTO_BACK,@PRINT_TEMPLET_ID,@IS_FORBIDDEN,@IS_DELETE,@REG_TIME,@DEL_TIME,@FORBIDDEN_TIME,@ENABLE_TIME,@MODIFY_TIME)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ORG_ID", SqlDbType.Decimal,9),
					new SqlParameter("@STAFF_NO_TEMPLET", SqlDbType.Decimal,9),
					new SqlParameter("@STAFF_NO", SqlDbType.NVarChar,400),
					new SqlParameter("@REAL_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@SEX", SqlDbType.TinyInt,1),
					new SqlParameter("@JOB", SqlDbType.NVarChar,200),
					new SqlParameter("@BIRTHDAY", SqlDbType.Date,3),
					new SqlParameter("@POLITICS", SqlDbType.NVarChar,100),
					new SqlParameter("@MARRIED", SqlDbType.TinyInt,1),
					new SqlParameter("@SKIIL_LEVEL", SqlDbType.NVarChar,100),
					new SqlParameter("@CER_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@CER_NO", SqlDbType.NVarChar,400),
					new SqlParameter("@TELE_PHONE", SqlDbType.NVarChar,100),
					new SqlParameter("@CELL_PHONE", SqlDbType.NVarChar,100),
					new SqlParameter("@NATIVE", SqlDbType.NVarChar,400),
					new SqlParameter("@NATION", SqlDbType.NVarChar,100),
					new SqlParameter("@RELIGION", SqlDbType.NVarChar,100),
					new SqlParameter("@EDUCATIONAL", SqlDbType.NVarChar,100),
					new SqlParameter("@EMAIL", SqlDbType.NVarChar,100),
					new SqlParameter("@VALID_STARTTIME", SqlDbType.DateTime),
					new SqlParameter("@VALID_ENDTIME", SqlDbType.DateTime),
					new SqlParameter("@ENTRY_TIME", SqlDbType.Date,3),
					new SqlParameter("@ABORT_TIME", SqlDbType.Date,3),
					new SqlParameter("@ADDRESS", SqlDbType.NVarChar,400),
					new SqlParameter("@PHOTO", SqlDbType.Image),
					new SqlParameter("@CER_PHOTO_FRONT", SqlDbType.Image),
					new SqlParameter("@CER_PHOTO_BACK", SqlDbType.Image),
					new SqlParameter("@PRINT_TEMPLET_ID", SqlDbType.Decimal,9),
					new SqlParameter("@IS_FORBIDDEN", SqlDbType.Bit,1),
					new SqlParameter("@IS_DELETE", SqlDbType.Bit,1),
					new SqlParameter("@REG_TIME", SqlDbType.DateTime),
					new SqlParameter("@DEL_TIME", SqlDbType.DateTime),
					new SqlParameter("@FORBIDDEN_TIME", SqlDbType.DateTime),
					new SqlParameter("@ENABLE_TIME", SqlDbType.DateTime),
                    new SqlParameter("@MODIFY_TIME", SqlDbType.DateTime)};
            parameters[0].Value = model.ORG_ID;
            parameters[1].Value = model.STAFF_NO_TEMPLET;
            parameters[2].Value = model.STAFF_NO;
            parameters[3].Value = model.REAL_NAME;
            parameters[4].Value = model.SEX;
            parameters[5].Value = model.JOB;
            parameters[6].Value = model.BIRTHDAY;
            parameters[7].Value = model.POLITICS;
            parameters[8].Value = model.MARRIED;
            parameters[9].Value = model.SKIIL_LEVEL;
            parameters[10].Value = model.CER_NAME;
            parameters[11].Value = model.CER_NO;
            parameters[12].Value = model.TELE_PHONE;
            parameters[13].Value = model.CELL_PHONE;
            parameters[14].Value = model.NATIVE;
            parameters[15].Value = model.NATION;
            parameters[16].Value = model.RELIGION;
            parameters[17].Value = model.EDUCATIONAL;
            parameters[18].Value = model.EMAIL;
            parameters[19].Value = model.VALID_STARTTIME;
            parameters[20].Value = model.VALID_ENDTIME;
            parameters[21].Value = model.ENTRY_TIME;
            parameters[22].Value = model.ABORT_TIME;
            parameters[23].Value = model.ADDRESS;
            parameters[24].Value = model.PHOTO == null ? DBNull.Value : (object)model.PHOTO;
            parameters[25].Value = model.CER_PHOTO_FRONT == null ? DBNull.Value : (object)model.CER_PHOTO_FRONT;
            parameters[26].Value = model.CER_PHOTO_BACK == null ? DBNull.Value : (object)model.CER_PHOTO_BACK;
            parameters[27].Value = model.PRINT_TEMPLET_ID;
            parameters[28].Value = model.IS_FORBIDDEN;
            parameters[29].Value = model.IS_DELETE;
            parameters[30].Value = model.REG_TIME;
            parameters[31].Value = model.DEL_TIME == null ? DBNull.Value : (object)model.DEL_TIME;
            parameters[32].Value = model.FORBIDDEN_TIME == null ? DBNull.Value : (object)model.FORBIDDEN_TIME;
            parameters[33].Value = model.ENABLE_TIME == null ? DBNull.Value : (object)model.ENABLE_TIME;
            parameters[34].Value = model.MODIFY_TIME;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
			strSql.Append("STAFF_NO=@STAFF_NO,");
			strSql.Append("REAL_NAME=@REAL_NAME,");
			strSql.Append("SEX=@SEX,");
			strSql.Append("JOB=@JOB,");
			strSql.Append("BIRTHDAY=@BIRTHDAY,");
			strSql.Append("POLITICS=@POLITICS,");
			strSql.Append("MARRIED=@MARRIED,");
			strSql.Append("SKIIL_LEVEL=@SKIIL_LEVEL,");
			strSql.Append("CER_NAME=@CER_NAME,");
			strSql.Append("CER_NO=@CER_NO,");
			strSql.Append("TELE_PHONE=@TELE_PHONE,");
			strSql.Append("CELL_PHONE=@CELL_PHONE,");
			strSql.Append("NATIVE=@NATIVE,");
			strSql.Append("NATION=@NATION,");
			strSql.Append("RELIGION=@RELIGION,");
			strSql.Append("EDUCATIONAL=@EDUCATIONAL,");
			strSql.Append("EMAIL=@EMAIL,");
			strSql.Append("VALID_STARTTIME=@VALID_STARTTIME,");
			strSql.Append("VALID_ENDTIME=@VALID_ENDTIME,");
			strSql.Append("ENTRY_TIME=@ENTRY_TIME,");
			strSql.Append("ABORT_TIME=@ABORT_TIME,");
			strSql.Append("ADDRESS=@ADDRESS,");
			strSql.Append("PHOTO=@PHOTO,");
			strSql.Append("CER_PHOTO_FRONT=@CER_PHOTO_FRONT,");
			strSql.Append("CER_PHOTO_BACK=@CER_PHOTO_BACK,");
			strSql.Append("PRINT_TEMPLET_ID=@PRINT_TEMPLET_ID,");
			strSql.Append("IS_FORBIDDEN=@IS_FORBIDDEN,");
			strSql.Append("IS_DELETE=@IS_DELETE,");
			strSql.Append("REG_TIME=@REG_TIME,");
			strSql.Append("DEL_TIME=@DEL_TIME,");
			strSql.Append("FORBIDDEN_TIME=@FORBIDDEN_TIME,");
			strSql.Append("ENABLE_TIME=@ENABLE_TIME,");
            strSql.Append("MODIFY_TIME=@MODIFY_TIME");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ORG_ID", SqlDbType.Decimal,9),
					new SqlParameter("@STAFF_NO_TEMPLET", SqlDbType.Decimal,9),
					new SqlParameter("@STAFF_NO", SqlDbType.NVarChar,400),
					new SqlParameter("@REAL_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@SEX", SqlDbType.TinyInt,1),
					new SqlParameter("@JOB", SqlDbType.NVarChar,200),
					new SqlParameter("@BIRTHDAY", SqlDbType.Date,3),
					new SqlParameter("@POLITICS", SqlDbType.NVarChar,100),
					new SqlParameter("@MARRIED", SqlDbType.TinyInt,1),
					new SqlParameter("@SKIIL_LEVEL", SqlDbType.NVarChar,100),
					new SqlParameter("@CER_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@CER_NO", SqlDbType.NVarChar,400),
					new SqlParameter("@TELE_PHONE", SqlDbType.NVarChar,100),
					new SqlParameter("@CELL_PHONE", SqlDbType.NVarChar,100),
					new SqlParameter("@NATIVE", SqlDbType.NVarChar,400),
					new SqlParameter("@NATION", SqlDbType.NVarChar,100),
					new SqlParameter("@RELIGION", SqlDbType.NVarChar,100),
					new SqlParameter("@EDUCATIONAL", SqlDbType.NVarChar,100),
					new SqlParameter("@EMAIL", SqlDbType.NVarChar,100),
					new SqlParameter("@VALID_STARTTIME", SqlDbType.DateTime),
					new SqlParameter("@VALID_ENDTIME", SqlDbType.DateTime),
					new SqlParameter("@ENTRY_TIME", SqlDbType.Date,3),
					new SqlParameter("@ABORT_TIME", SqlDbType.Date,3),
					new SqlParameter("@ADDRESS", SqlDbType.NVarChar,400),
					new SqlParameter("@PHOTO", SqlDbType.Image),
					new SqlParameter("@CER_PHOTO_FRONT", SqlDbType.Image),
					new SqlParameter("@CER_PHOTO_BACK", SqlDbType.Image),
					new SqlParameter("@PRINT_TEMPLET_ID", SqlDbType.Decimal,9),
					new SqlParameter("@IS_FORBIDDEN", SqlDbType.Bit,1),
					new SqlParameter("@IS_DELETE", SqlDbType.Bit,1),
					new SqlParameter("@REG_TIME", SqlDbType.DateTime),
					new SqlParameter("@DEL_TIME", SqlDbType.DateTime),
					new SqlParameter("@FORBIDDEN_TIME", SqlDbType.DateTime),
					new SqlParameter("@ENABLE_TIME", SqlDbType.DateTime),
                    new SqlParameter("@MODIFY_TIME", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ORG_ID;
			parameters[1].Value = model.STAFF_NO_TEMPLET;
			parameters[2].Value = model.STAFF_NO;
			parameters[3].Value = model.REAL_NAME;
			parameters[4].Value = model.SEX;
			parameters[5].Value = model.JOB;
			parameters[6].Value = model.BIRTHDAY;
			parameters[7].Value = model.POLITICS;
			parameters[8].Value = model.MARRIED;
			parameters[9].Value = model.SKIIL_LEVEL;
			parameters[10].Value = model.CER_NAME;
			parameters[11].Value = model.CER_NO;
			parameters[12].Value = model.TELE_PHONE;
			parameters[13].Value = model.CELL_PHONE;
			parameters[14].Value = model.NATIVE;
			parameters[15].Value = model.NATION;
			parameters[16].Value = model.RELIGION;
			parameters[17].Value = model.EDUCATIONAL;
			parameters[18].Value = model.EMAIL;
			parameters[19].Value = model.VALID_STARTTIME;
			parameters[20].Value = model.VALID_ENDTIME;
			parameters[21].Value = model.ENTRY_TIME;
			parameters[22].Value = model.ABORT_TIME;
			parameters[23].Value = model.ADDRESS;
            parameters[24].Value = model.PHOTO == null ? DBNull.Value : (object)model.PHOTO;
            parameters[25].Value = model.CER_PHOTO_FRONT == null ? DBNull.Value : (object)model.CER_PHOTO_FRONT;
            parameters[26].Value = model.CER_PHOTO_BACK == null ? DBNull.Value : (object)model.CER_PHOTO_BACK;
			parameters[27].Value = model.PRINT_TEMPLET_ID;
			parameters[28].Value = model.IS_FORBIDDEN;
			parameters[29].Value = model.IS_DELETE;
			parameters[30].Value = model.REG_TIME;
			parameters[31].Value = model.DEL_TIME;
			parameters[32].Value = model.FORBIDDEN_TIME;
			parameters[33].Value = model.ENABLE_TIME;
            parameters[34].Value = model.MODIFY_TIME;
			parameters[35].Value = model.ID;

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
            strSql.Append("select  top 1 ID,ORG_ID,STAFF_NO_TEMPLET,STAFF_NO,REAL_NAME,SEX,JOB,BIRTHDAY,POLITICS,MARRIED,SKIIL_LEVEL,CER_NAME,CER_NO,TELE_PHONE,CELL_PHONE,NATIVE,NATION,RELIGION,EDUCATIONAL,EMAIL,VALID_STARTTIME,VALID_ENDTIME,ENTRY_TIME,ABORT_TIME,ADDRESS,PHOTO,CER_PHOTO_FRONT,CER_PHOTO_BACK,PRINT_TEMPLET_ID,IS_FORBIDDEN,IS_DELETE,REG_TIME,DEL_TIME,FORBIDDEN_TIME,ENABLE_TIME,MODIFY_TIME from SMT_STAFF_INFO ");
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
				if(row["STAFF_NO"]!=null)
				{
					model.STAFF_NO=row["STAFF_NO"].ToString();
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
				if(row["MARRIED"]!=null && row["MARRIED"].ToString()!="")
				{
					model.MARRIED=int.Parse(row["MARRIED"].ToString());
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
				if(row["TELE_PHONE"]!=null)
				{
					model.TELE_PHONE=row["TELE_PHONE"].ToString();
				}
				if(row["CELL_PHONE"]!=null)
				{
					model.CELL_PHONE=row["CELL_PHONE"].ToString();
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
				if(row["ENTRY_TIME"]!=null && row["ENTRY_TIME"].ToString()!="")
				{
					model.ENTRY_TIME=DateTime.Parse(row["ENTRY_TIME"].ToString());
				}
				if(row["ABORT_TIME"]!=null && row["ABORT_TIME"].ToString()!="")
				{
					model.ABORT_TIME=DateTime.Parse(row["ABORT_TIME"].ToString());
				}
				if(row["ADDRESS"]!=null)
				{
					model.ADDRESS=row["ADDRESS"].ToString();
				}
				if(row["PHOTO"]!=null && row["PHOTO"].ToString()!="")
				{
					model.PHOTO=(byte[])row["PHOTO"];
				}
				if(row["CER_PHOTO_FRONT"]!=null && row["CER_PHOTO_FRONT"].ToString()!="")
				{
					model.CER_PHOTO_FRONT=(byte[])row["CER_PHOTO_FRONT"];
				}
				if(row["CER_PHOTO_BACK"]!=null && row["CER_PHOTO_BACK"].ToString()!="")
				{
					model.CER_PHOTO_BACK=(byte[])row["CER_PHOTO_BACK"];
				}
				if(row["PRINT_TEMPLET_ID"]!=null && row["PRINT_TEMPLET_ID"].ToString()!="")
				{
					model.PRINT_TEMPLET_ID=decimal.Parse(row["PRINT_TEMPLET_ID"].ToString());
				}
				if(row["IS_FORBIDDEN"]!=null && row["IS_FORBIDDEN"].ToString()!="")
				{
					if((row["IS_FORBIDDEN"].ToString()=="1")||(row["IS_FORBIDDEN"].ToString().ToLower()=="true"))
					{
						model.IS_FORBIDDEN=true;
					}
					else
					{
						model.IS_FORBIDDEN=false;
					}
				}
				if(row["IS_DELETE"]!=null && row["IS_DELETE"].ToString()!="")
				{
					if((row["IS_DELETE"].ToString()=="1")||(row["IS_DELETE"].ToString().ToLower()=="true"))
					{
						model.IS_DELETE=true;
					}
					else
					{
						model.IS_DELETE=false;
					}
				}
				if(row["REG_TIME"]!=null && row["REG_TIME"].ToString()!="")
				{
					model.REG_TIME=DateTime.Parse(row["REG_TIME"].ToString());
				}
				if(row["DEL_TIME"]!=null && row["DEL_TIME"].ToString()!="")
				{
					model.DEL_TIME=DateTime.Parse(row["DEL_TIME"].ToString());
				}
				if(row["FORBIDDEN_TIME"]!=null && row["FORBIDDEN_TIME"].ToString()!="")
				{
					model.FORBIDDEN_TIME=DateTime.Parse(row["FORBIDDEN_TIME"].ToString());
				}
				if(row["ENABLE_TIME"]!=null && row["ENABLE_TIME"].ToString()!="")
				{
					model.ENABLE_TIME=DateTime.Parse(row["ENABLE_TIME"].ToString());
				}
                if (row["MODIFY_TIME"] != null && row["MODIFY_TIME"].ToString() != "")
				{
                    model.MODIFY_TIME = DateTime.Parse(row["MODIFY_TIME"].ToString());
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
            strSql.Append("select ID,ORG_ID,STAFF_NO_TEMPLET,STAFF_NO,REAL_NAME,SEX,JOB,BIRTHDAY,POLITICS,MARRIED,SKIIL_LEVEL,CER_NAME,CER_NO,TELE_PHONE,CELL_PHONE,NATIVE,NATION,RELIGION,EDUCATIONAL,EMAIL,VALID_STARTTIME,VALID_ENDTIME,ENTRY_TIME,ABORT_TIME,ADDRESS,PHOTO,CER_PHOTO_FRONT,CER_PHOTO_BACK,PRINT_TEMPLET_ID,IS_FORBIDDEN,IS_DELETE,REG_TIME,DEL_TIME,FORBIDDEN_TIME,ENABLE_TIME,MODIFY_TIME ");
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
            strSql.Append(" ID,ORG_ID,STAFF_NO_TEMPLET,STAFF_NO,REAL_NAME,SEX,JOB,BIRTHDAY,POLITICS,MARRIED,SKIIL_LEVEL,CER_NAME,CER_NO,TELE_PHONE,CELL_PHONE,NATIVE,NATION,RELIGION,EDUCATIONAL,EMAIL,VALID_STARTTIME,VALID_ENDTIME,ENTRY_TIME,ABORT_TIME,ADDRESS,PHOTO,CER_PHOTO_FRONT,CER_PHOTO_BACK,PRINT_TEMPLET_ID,IS_FORBIDDEN,IS_DELETE,REG_TIME,DEL_TIME,FORBIDDEN_TIME,ENABLE_TIME,MODIFY_TIME ");
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

