/**  版本信息模板在安装目录下，可自行修改。
* SMT_USER_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_USER_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/10/9 20:03:26   N/A    初版
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
	/// 数据访问类:SMT_USER_INFO
	/// </summary>
	public partial class SMT_USER_INFO
	{
		public SMT_USER_INFO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string USER_NAME,bool IS_DELETE,decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_USER_INFO");
			strSql.Append(" where USER_NAME=@USER_NAME and IS_DELETE=@IS_DELETE and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@USER_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@IS_DELETE", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = USER_NAME;
			parameters[1].Value = IS_DELETE;
			parameters[2].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.SMT_USER_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_USER_INFO(");
			strSql.Append("USER_NAME,PASS_WORD,IS_ENABLE,IS_DELETE,ORDER_VALUE,REAL_NAME,ORG_ID,TELEPHONE,ADDRESS,EMAIL,QQ,ROLE_ID,KEY_VAL)");
			strSql.Append(" values (");
			strSql.Append("@USER_NAME,@PASS_WORD,@IS_ENABLE,@IS_DELETE,@ORDER_VALUE,@REAL_NAME,@ORG_ID,@TELEPHONE,@ADDRESS,@EMAIL,@QQ,@ROLE_ID,@KEY_VAL)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@USER_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@PASS_WORD", SqlDbType.NVarChar,100),
					new SqlParameter("@IS_ENABLE", SqlDbType.Bit,1),
					new SqlParameter("@IS_DELETE", SqlDbType.Bit,1),
					new SqlParameter("@ORDER_VALUE", SqlDbType.Int,4),
					new SqlParameter("@REAL_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@ORG_ID", SqlDbType.Decimal,9),
					new SqlParameter("@TELEPHONE", SqlDbType.NVarChar,50),
					new SqlParameter("@ADDRESS", SqlDbType.NVarChar,100),
					new SqlParameter("@EMAIL", SqlDbType.NVarChar,100),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,9),
					new SqlParameter("@KEY_VAL", SqlDbType.VarChar,200)};
			parameters[0].Value = model.USER_NAME;
			parameters[1].Value = model.PASS_WORD;
			parameters[2].Value = model.IS_ENABLE;
			parameters[3].Value = model.IS_DELETE;
			parameters[4].Value = model.ORDER_VALUE;
			parameters[5].Value = model.REAL_NAME;
			parameters[6].Value = model.ORG_ID;
			parameters[7].Value = model.TELEPHONE;
			parameters[8].Value = model.ADDRESS;
			parameters[9].Value = model.EMAIL;
			parameters[10].Value = model.QQ;
			parameters[11].Value = model.ROLE_ID;
			parameters[12].Value = model.KEY_VAL;

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
		public bool Update(Maticsoft.Model.SMT_USER_INFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_USER_INFO set ");
			strSql.Append("PASS_WORD=@PASS_WORD,");
			strSql.Append("IS_ENABLE=@IS_ENABLE,");
			strSql.Append("ORDER_VALUE=@ORDER_VALUE,");
			strSql.Append("REAL_NAME=@REAL_NAME,");
			strSql.Append("ORG_ID=@ORG_ID,");
			strSql.Append("TELEPHONE=@TELEPHONE,");
			strSql.Append("ADDRESS=@ADDRESS,");
			strSql.Append("EMAIL=@EMAIL,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("ROLE_ID=@ROLE_ID,");
			strSql.Append("KEY_VAL=@KEY_VAL");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@PASS_WORD", SqlDbType.NVarChar,100),
					new SqlParameter("@IS_ENABLE", SqlDbType.Bit,1),
					new SqlParameter("@ORDER_VALUE", SqlDbType.Int,4),
					new SqlParameter("@REAL_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@ORG_ID", SqlDbType.Decimal,9),
					new SqlParameter("@TELEPHONE", SqlDbType.NVarChar,50),
					new SqlParameter("@ADDRESS", SqlDbType.NVarChar,100),
					new SqlParameter("@EMAIL", SqlDbType.NVarChar,100),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@ROLE_ID", SqlDbType.Decimal,9),
					new SqlParameter("@KEY_VAL", SqlDbType.VarChar,200),
					new SqlParameter("@ID", SqlDbType.Decimal,9),
					new SqlParameter("@USER_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@IS_DELETE", SqlDbType.Bit,1)};
			parameters[0].Value = model.PASS_WORD;
			parameters[1].Value = model.IS_ENABLE;
			parameters[2].Value = model.ORDER_VALUE;
			parameters[3].Value = model.REAL_NAME;
			parameters[4].Value = model.ORG_ID;
			parameters[5].Value = model.TELEPHONE;
			parameters[6].Value = model.ADDRESS;
			parameters[7].Value = model.EMAIL;
			parameters[8].Value = model.QQ;
			parameters[9].Value = model.ROLE_ID;
			parameters[10].Value = model.KEY_VAL;
			parameters[11].Value = model.ID;
			parameters[12].Value = model.USER_NAME;
            parameters[13].Value = model.IS_DELETE;

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
			strSql.Append("delete from SMT_USER_INFO ");
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
		public bool Delete(string USER_NAME,bool IS_DELETE,decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SMT_USER_INFO ");
			strSql.Append(" where USER_NAME=@USER_NAME and IS_DELETE=@IS_DELETE and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@USER_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@IS_DELETE", SqlDbType.Bit,1),
					new SqlParameter("@ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = USER_NAME;
			parameters[1].Value = IS_DELETE;
			parameters[2].Value = ID;

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
			strSql.Append("delete from SMT_USER_INFO ");
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
		public Maticsoft.Model.SMT_USER_INFO GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,USER_NAME,PASS_WORD,IS_ENABLE,IS_DELETE,ORDER_VALUE,REAL_NAME,ORG_ID,TELEPHONE,ADDRESS,EMAIL,QQ,ROLE_ID,KEY_VAL from SMT_USER_INFO ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_USER_INFO model=new Maticsoft.Model.SMT_USER_INFO();
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
		public Maticsoft.Model.SMT_USER_INFO DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_USER_INFO model=new Maticsoft.Model.SMT_USER_INFO();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["USER_NAME"]!=null)
				{
					model.USER_NAME=row["USER_NAME"].ToString();
				}
				if(row["PASS_WORD"]!=null)
				{
					model.PASS_WORD=row["PASS_WORD"].ToString();
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
				if(row["ORDER_VALUE"]!=null && row["ORDER_VALUE"].ToString()!="")
				{
					model.ORDER_VALUE=int.Parse(row["ORDER_VALUE"].ToString());
				}
				if(row["REAL_NAME"]!=null)
				{
					model.REAL_NAME=row["REAL_NAME"].ToString();
				}
				if(row["ORG_ID"]!=null && row["ORG_ID"].ToString()!="")
				{
					model.ORG_ID=decimal.Parse(row["ORG_ID"].ToString());
				}
				if(row["TELEPHONE"]!=null)
				{
					model.TELEPHONE=row["TELEPHONE"].ToString();
				}
				if(row["ADDRESS"]!=null)
				{
					model.ADDRESS=row["ADDRESS"].ToString();
				}
				if(row["EMAIL"]!=null)
				{
					model.EMAIL=row["EMAIL"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["ROLE_ID"]!=null && row["ROLE_ID"].ToString()!="")
				{
					model.ROLE_ID=decimal.Parse(row["ROLE_ID"].ToString());
				}
				if(row["KEY_VAL"]!=null)
				{
					model.KEY_VAL=row["KEY_VAL"].ToString();
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
			strSql.Append("select ID,USER_NAME,PASS_WORD,IS_ENABLE,IS_DELETE,ORDER_VALUE,REAL_NAME,ORG_ID,TELEPHONE,ADDRESS,EMAIL,QQ,ROLE_ID,KEY_VAL ");
			strSql.Append(" FROM SMT_USER_INFO ");
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
			strSql.Append(" ID,USER_NAME,PASS_WORD,IS_ENABLE,IS_DELETE,ORDER_VALUE,REAL_NAME,ORG_ID,TELEPHONE,ADDRESS,EMAIL,QQ,ROLE_ID,KEY_VAL ");
			strSql.Append(" FROM SMT_USER_INFO ");
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
			strSql.Append("select count(1) FROM SMT_USER_INFO ");
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
			strSql.Append(")AS Row, T.*  from SMT_USER_INFO T ");
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
			parameters[0].Value = "SMT_USER_INFO";
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

