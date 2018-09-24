/**  版本信息模板在安装目录下，可自行修改。
* staff_log.cs
*
* 功 能： N/A
* 类 名： staff_log
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/8/22 22:46:33   N/A    初版
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
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.BST
{
	/// <summary>
	/// 数据访问类:staff_log
	/// </summary>
	public partial class staff_log
    {
        public LiMaticsoft.DBUtility.Extension.DbHelperMySQLP DbHelperMySQLP = new LiMaticsoft.DBUtility.Extension.DbHelperMySQLP();
		public staff_log()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from staff_log");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,100)			};
			parameters[0].Value = id;

			return DbHelperMySQLP.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.BST.staff_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into staff_log(");
			strSql.Append("id,name,imagevideo,imagesql,info,authority,data_keepon1,data_keepon2,data_keepon3,data_keepon4,data_keepon5)");
			strSql.Append(" values (");
			strSql.Append("@id,@name,@imagevideo,@imagesql,@info,@authority,@data_keepon1,@data_keepon2,@data_keepon3,@data_keepon4,@data_keepon5)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,100),
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@imagevideo", MySqlDbType.MediumBlob),
					new MySqlParameter("@imagesql", MySqlDbType.MediumBlob),
					new MySqlParameter("@info", MySqlDbType.VarChar,100),
					new MySqlParameter("@authority", MySqlDbType.VarChar,1),
					new MySqlParameter("@data_keepon1", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon2", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon3", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon4", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon5", MySqlDbType.VarChar,45)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.name;
			parameters[2].Value = model.imagevideo;
			parameters[3].Value = model.imagesql;
			parameters[4].Value = model.info;
			parameters[5].Value = model.authority;
			parameters[6].Value = model.data_keepon1;
			parameters[7].Value = model.data_keepon2;
			parameters[8].Value = model.data_keepon3;
			parameters[9].Value = model.data_keepon4;
			parameters[10].Value = model.data_keepon5;

			int rows=DbHelperMySQLP.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.BST.staff_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update staff_log set ");
			strSql.Append("name=@name,");
			strSql.Append("imagevideo=@imagevideo,");
			strSql.Append("imagesql=@imagesql,");
			strSql.Append("info=@info,");
			strSql.Append("authority=@authority,");
			strSql.Append("data_keepon1=@data_keepon1,");
			strSql.Append("data_keepon2=@data_keepon2,");
			strSql.Append("data_keepon3=@data_keepon3,");
			strSql.Append("data_keepon4=@data_keepon4,");
			strSql.Append("data_keepon5=@data_keepon5");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@imagevideo", MySqlDbType.MediumBlob),
					new MySqlParameter("@imagesql", MySqlDbType.MediumBlob),
					new MySqlParameter("@info", MySqlDbType.VarChar,100),
					new MySqlParameter("@authority", MySqlDbType.VarChar,1),
					new MySqlParameter("@data_keepon1", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon2", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon3", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon4", MySqlDbType.VarChar,45),
					new MySqlParameter("@data_keepon5", MySqlDbType.VarChar,45),
					new MySqlParameter("@id", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.imagevideo;
			parameters[2].Value = model.imagesql;
			parameters[3].Value = model.info;
			parameters[4].Value = model.authority;
			parameters[5].Value = model.data_keepon1;
			parameters[6].Value = model.data_keepon2;
			parameters[7].Value = model.data_keepon3;
			parameters[8].Value = model.data_keepon4;
			parameters[9].Value = model.data_keepon5;
			parameters[10].Value = model.id;

			int rows=DbHelperMySQLP.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from staff_log ");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,100)			};
			parameters[0].Value = id;

			int rows=DbHelperMySQLP.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from staff_log ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperMySQLP.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.BST.staff_log GetModel(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,name,imagevideo,imagesql,info,authority,data_keepon1,data_keepon2,data_keepon3,data_keepon4,data_keepon5 from staff_log ");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.VarChar,100)			};
			parameters[0].Value = id;

			Maticsoft.Model.BST.staff_log model=new Maticsoft.Model.BST.staff_log();
			DataSet ds=DbHelperMySQLP.Query(strSql.ToString(),parameters);
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
		public Maticsoft.Model.BST.staff_log DataRowToModel(DataRow row)
		{
			Maticsoft.Model.BST.staff_log model=new Maticsoft.Model.BST.staff_log();
			if (row != null)
			{
				if(row["id"]!=null)
				{
					model.id=row["id"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
                if (row["imagesql"]!=null)
                {
                    model.imagesql = (byte[])row["imagesql"];
                }
                if (row["imagevideo"] != null)
                {
                    model.imagevideo = (byte[])row["imagevideo"];
                }
				if(row["info"]!=null)
				{
					model.info=row["info"].ToString();
				}
				if(row["authority"]!=null)
				{
					model.authority=row["authority"].ToString();
				}
				if(row["data_keepon1"]!=null)
				{
					model.data_keepon1=row["data_keepon1"].ToString();
				}
				if(row["data_keepon2"]!=null)
				{
					model.data_keepon2=row["data_keepon2"].ToString();
				}
				if(row["data_keepon3"]!=null)
				{
					model.data_keepon3=row["data_keepon3"].ToString();
				}
				if(row["data_keepon4"]!=null)
				{
					model.data_keepon4=row["data_keepon4"].ToString();
				}
				if(row["data_keepon5"]!=null)
				{
					model.data_keepon5=row["data_keepon5"].ToString();
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
			strSql.Append("select id,name,imagevideo,imagesql,info,authority,data_keepon1,data_keepon2,data_keepon3,data_keepon4,data_keepon5 ");
			strSql.Append(" FROM staff_log ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQLP.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM staff_log ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from staff_log T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQLP.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "staff_log";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod

        public void DeleteAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from staff_log");
            DbHelperMySQLP.ExecuteSql(strSql.ToString());
        }
    }
}

