/**  版本信息模板在安装目录下，可自行修改。
* SMT_ALARM_CONNECT.cs
*
* 功 能： N/A
* 类 名： SMT_ALARM_CONNECT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/5 23:38:31   N/A    初版
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
	/// 数据访问类:SMT_ALARM_CONNECT
	/// </summary>
	public partial class SMT_ALARM_CONNECT
	{
		public SMT_ALARM_CONNECT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_ALARM_CONNECT");
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
		public decimal Add(Maticsoft.Model.SMT_ALARM_CONNECT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_ALARM_CONNECT(");
			strSql.Append("CTRL_ID,OUT_PORT,DOOR_ID,ENB_FORCE_PWD_EVENT,ENB_UNCLOSED_EVENT,ENB_FORCE_ACCESS_EVENT,ENB_FORCE_CLOSE_EVENT,ENB_INVALID_CARD_EVENT,ENB_FIRE_EVENT,ENB_RELAY_EVENT,ENB_CONNECT_ITEM,ENB_FIXED_TIME)");
			strSql.Append(" values (");
			strSql.Append("@CTRL_ID,@OUT_PORT,@DOOR_ID,@ENB_FORCE_PWD_EVENT,@ENB_UNCLOSED_EVENT,@ENB_FORCE_ACCESS_EVENT,@ENB_FORCE_CLOSE_EVENT,@ENB_INVALID_CARD_EVENT,@ENB_FIRE_EVENT,@ENB_RELAY_EVENT,@ENB_CONNECT_ITEM,@ENB_FIXED_TIME)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CTRL_ID", SqlDbType.Decimal,9),
					new SqlParameter("@OUT_PORT", SqlDbType.TinyInt,1),
					new SqlParameter("@DOOR_ID", SqlDbType.TinyInt,1),
					new SqlParameter("@ENB_FORCE_PWD_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_UNCLOSED_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_FORCE_ACCESS_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_FORCE_CLOSE_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_INVALID_CARD_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_FIRE_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_RELAY_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_CONNECT_ITEM", SqlDbType.TinyInt,1),
					new SqlParameter("@ENB_FIXED_TIME", SqlDbType.TinyInt,1)};
			parameters[0].Value = model.CTRL_ID;
			parameters[1].Value = model.OUT_PORT;
			parameters[2].Value = model.DOOR_ID;
			parameters[3].Value = model.ENB_FORCE_PWD_EVENT;
			parameters[4].Value = model.ENB_UNCLOSED_EVENT;
			parameters[5].Value = model.ENB_FORCE_ACCESS_EVENT;
			parameters[6].Value = model.ENB_FORCE_CLOSE_EVENT;
			parameters[7].Value = model.ENB_INVALID_CARD_EVENT;
			parameters[8].Value = model.ENB_FIRE_EVENT;
			parameters[9].Value = model.ENB_RELAY_EVENT;
			parameters[10].Value = model.ENB_CONNECT_ITEM;
			parameters[11].Value = model.ENB_FIXED_TIME;

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
		public bool Update(Maticsoft.Model.SMT_ALARM_CONNECT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_ALARM_CONNECT set ");
			strSql.Append("CTRL_ID=@CTRL_ID,");
			strSql.Append("OUT_PORT=@OUT_PORT,");
			strSql.Append("DOOR_ID=@DOOR_ID,");
			strSql.Append("ENB_FORCE_PWD_EVENT=@ENB_FORCE_PWD_EVENT,");
			strSql.Append("ENB_UNCLOSED_EVENT=@ENB_UNCLOSED_EVENT,");
			strSql.Append("ENB_FORCE_ACCESS_EVENT=@ENB_FORCE_ACCESS_EVENT,");
			strSql.Append("ENB_FORCE_CLOSE_EVENT=@ENB_FORCE_CLOSE_EVENT,");
			strSql.Append("ENB_INVALID_CARD_EVENT=@ENB_INVALID_CARD_EVENT,");
			strSql.Append("ENB_FIRE_EVENT=@ENB_FIRE_EVENT,");
			strSql.Append("ENB_RELAY_EVENT=@ENB_RELAY_EVENT,");
			strSql.Append("ENB_CONNECT_ITEM=@ENB_CONNECT_ITEM,");
			strSql.Append("ENB_FIXED_TIME=@ENB_FIXED_TIME");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CTRL_ID", SqlDbType.Decimal,9),
					new SqlParameter("@OUT_PORT", SqlDbType.TinyInt,1),
					new SqlParameter("@DOOR_ID", SqlDbType.TinyInt,1),
					new SqlParameter("@ENB_FORCE_PWD_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_UNCLOSED_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_FORCE_ACCESS_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_FORCE_CLOSE_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_INVALID_CARD_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_FIRE_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_RELAY_EVENT", SqlDbType.Bit,1),
					new SqlParameter("@ENB_CONNECT_ITEM", SqlDbType.TinyInt,1),
					new SqlParameter("@ENB_FIXED_TIME", SqlDbType.TinyInt,1),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.CTRL_ID;
			parameters[1].Value = model.OUT_PORT;
			parameters[2].Value = model.DOOR_ID;
			parameters[3].Value = model.ENB_FORCE_PWD_EVENT;
			parameters[4].Value = model.ENB_UNCLOSED_EVENT;
			parameters[5].Value = model.ENB_FORCE_ACCESS_EVENT;
			parameters[6].Value = model.ENB_FORCE_CLOSE_EVENT;
			parameters[7].Value = model.ENB_INVALID_CARD_EVENT;
			parameters[8].Value = model.ENB_FIRE_EVENT;
			parameters[9].Value = model.ENB_RELAY_EVENT;
			parameters[10].Value = model.ENB_CONNECT_ITEM;
			parameters[11].Value = model.ENB_FIXED_TIME;
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
			strSql.Append("delete from SMT_ALARM_CONNECT ");
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
			strSql.Append("delete from SMT_ALARM_CONNECT ");
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
		public Maticsoft.Model.SMT_ALARM_CONNECT GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CTRL_ID,OUT_PORT,DOOR_ID,ENB_FORCE_PWD_EVENT,ENB_UNCLOSED_EVENT,ENB_FORCE_ACCESS_EVENT,ENB_FORCE_CLOSE_EVENT,ENB_INVALID_CARD_EVENT,ENB_FIRE_EVENT,ENB_RELAY_EVENT,ENB_CONNECT_ITEM,ENB_FIXED_TIME from SMT_ALARM_CONNECT ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_ALARM_CONNECT model=new Maticsoft.Model.SMT_ALARM_CONNECT();
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
		public Maticsoft.Model.SMT_ALARM_CONNECT DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_ALARM_CONNECT model=new Maticsoft.Model.SMT_ALARM_CONNECT();
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
				if(row["OUT_PORT"]!=null && row["OUT_PORT"].ToString()!="")
				{
					model.OUT_PORT=int.Parse(row["OUT_PORT"].ToString());
				}
				if(row["DOOR_ID"]!=null && row["DOOR_ID"].ToString()!="")
				{
					model.DOOR_ID=int.Parse(row["DOOR_ID"].ToString());
				}
				if(row["ENB_FORCE_PWD_EVENT"]!=null && row["ENB_FORCE_PWD_EVENT"].ToString()!="")
				{
					if((row["ENB_FORCE_PWD_EVENT"].ToString()=="1")||(row["ENB_FORCE_PWD_EVENT"].ToString().ToLower()=="true"))
					{
						model.ENB_FORCE_PWD_EVENT=true;
					}
					else
					{
						model.ENB_FORCE_PWD_EVENT=false;
					}
				}
				if(row["ENB_UNCLOSED_EVENT"]!=null && row["ENB_UNCLOSED_EVENT"].ToString()!="")
				{
					if((row["ENB_UNCLOSED_EVENT"].ToString()=="1")||(row["ENB_UNCLOSED_EVENT"].ToString().ToLower()=="true"))
					{
						model.ENB_UNCLOSED_EVENT=true;
					}
					else
					{
						model.ENB_UNCLOSED_EVENT=false;
					}
				}
				if(row["ENB_FORCE_ACCESS_EVENT"]!=null && row["ENB_FORCE_ACCESS_EVENT"].ToString()!="")
				{
					if((row["ENB_FORCE_ACCESS_EVENT"].ToString()=="1")||(row["ENB_FORCE_ACCESS_EVENT"].ToString().ToLower()=="true"))
					{
						model.ENB_FORCE_ACCESS_EVENT=true;
					}
					else
					{
						model.ENB_FORCE_ACCESS_EVENT=false;
					}
				}
				if(row["ENB_FORCE_CLOSE_EVENT"]!=null && row["ENB_FORCE_CLOSE_EVENT"].ToString()!="")
				{
					if((row["ENB_FORCE_CLOSE_EVENT"].ToString()=="1")||(row["ENB_FORCE_CLOSE_EVENT"].ToString().ToLower()=="true"))
					{
						model.ENB_FORCE_CLOSE_EVENT=true;
					}
					else
					{
						model.ENB_FORCE_CLOSE_EVENT=false;
					}
				}
				if(row["ENB_INVALID_CARD_EVENT"]!=null && row["ENB_INVALID_CARD_EVENT"].ToString()!="")
				{
					if((row["ENB_INVALID_CARD_EVENT"].ToString()=="1")||(row["ENB_INVALID_CARD_EVENT"].ToString().ToLower()=="true"))
					{
						model.ENB_INVALID_CARD_EVENT=true;
					}
					else
					{
						model.ENB_INVALID_CARD_EVENT=false;
					}
				}
				if(row["ENB_FIRE_EVENT"]!=null && row["ENB_FIRE_EVENT"].ToString()!="")
				{
					if((row["ENB_FIRE_EVENT"].ToString()=="1")||(row["ENB_FIRE_EVENT"].ToString().ToLower()=="true"))
					{
						model.ENB_FIRE_EVENT=true;
					}
					else
					{
						model.ENB_FIRE_EVENT=false;
					}
				}
				if(row["ENB_RELAY_EVENT"]!=null && row["ENB_RELAY_EVENT"].ToString()!="")
				{
					if((row["ENB_RELAY_EVENT"].ToString()=="1")||(row["ENB_RELAY_EVENT"].ToString().ToLower()=="true"))
					{
						model.ENB_RELAY_EVENT=true;
					}
					else
					{
						model.ENB_RELAY_EVENT=false;
					}
				}
				if(row["ENB_CONNECT_ITEM"]!=null && row["ENB_CONNECT_ITEM"].ToString()!="")
				{
					model.ENB_CONNECT_ITEM=int.Parse(row["ENB_CONNECT_ITEM"].ToString());
				}
				if(row["ENB_FIXED_TIME"]!=null && row["ENB_FIXED_TIME"].ToString()!="")
				{
					model.ENB_FIXED_TIME=int.Parse(row["ENB_FIXED_TIME"].ToString());
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
			strSql.Append("select ID,CTRL_ID,OUT_PORT,DOOR_ID,ENB_FORCE_PWD_EVENT,ENB_UNCLOSED_EVENT,ENB_FORCE_ACCESS_EVENT,ENB_FORCE_CLOSE_EVENT,ENB_INVALID_CARD_EVENT,ENB_FIRE_EVENT,ENB_RELAY_EVENT,ENB_CONNECT_ITEM,ENB_FIXED_TIME ");
			strSql.Append(" FROM SMT_ALARM_CONNECT ");
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
			strSql.Append(" ID,CTRL_ID,OUT_PORT,DOOR_ID,ENB_FORCE_PWD_EVENT,ENB_UNCLOSED_EVENT,ENB_FORCE_ACCESS_EVENT,ENB_FORCE_CLOSE_EVENT,ENB_INVALID_CARD_EVENT,ENB_FIRE_EVENT,ENB_RELAY_EVENT,ENB_CONNECT_ITEM,ENB_FIXED_TIME ");
			strSql.Append(" FROM SMT_ALARM_CONNECT ");
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
			strSql.Append("select count(1) FROM SMT_ALARM_CONNECT ");
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
			strSql.Append(")AS Row, T.*  from SMT_ALARM_CONNECT T ");
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
			parameters[0].Value = "SMT_ALARM_CONNECT";
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

