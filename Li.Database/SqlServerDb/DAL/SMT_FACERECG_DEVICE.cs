/**  版本信息模板在安装目录下，可自行修改。
* SMT_FACERECG_DEVICE.cs
*
* 功 能： N/A
* 类 名： SMT_FACERECG_DEVICE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/2 20:58:10   N/A    初版
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
	/// 数据访问类:SMT_FACERECG_DEVICE
	/// </summary>
	public partial class SMT_FACERECG_DEVICE
	{
		public SMT_FACERECG_DEVICE()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SMT_FACERECG_DEVICE");
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
		public decimal Add(Maticsoft.Model.SMT_FACERECG_DEVICE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SMT_FACERECG_DEVICE(");
			strSql.Append("FACEDEV_SN,FACEDEV_NAME,FACEDEV_IP,FACEDEV_CTRL_PORT,FACEDEV_USER,FACEDEV_PWD,FACEDEV_DB_NAME,FACEDEV_DB_PORT,FACEDEV_DB_USER,FACEDEV_DB_PWD,AREA_ID,FACEDEV_IS_ENABLE,FACEDEV_HEART_PORT,FACEDEV_MODE,FVIDEO_RTSP,FVIDEO_RTSP2,FVIDEO_RTSP3,FVIDEO_RTSP_COUNT,FVIDEO_FACE_LEVEL,FVIDEO_RIO_X,FVIDEO_RIO_Y,FVIDEO_RIO_H,FVIDEO_RIO_W,FVIDEO_SINGLE,FVIDEO_TITLE1,FVIDEO_TITLE2)");
			strSql.Append(" values (");
			strSql.Append("@FACEDEV_SN,@FACEDEV_NAME,@FACEDEV_IP,@FACEDEV_CTRL_PORT,@FACEDEV_USER,@FACEDEV_PWD,@FACEDEV_DB_NAME,@FACEDEV_DB_PORT,@FACEDEV_DB_USER,@FACEDEV_DB_PWD,@AREA_ID,@FACEDEV_IS_ENABLE,@FACEDEV_HEART_PORT,@FACEDEV_MODE,@FVIDEO_RTSP,@FVIDEO_RTSP2,@FVIDEO_RTSP3,@FVIDEO_RTSP_COUNT,@FVIDEO_FACE_LEVEL,@FVIDEO_RIO_X,@FVIDEO_RIO_Y,@FVIDEO_RIO_H,@FVIDEO_RIO_W,@FVIDEO_SINGLE,@FVIDEO_TITLE1,@FVIDEO_TITLE2)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FACEDEV_SN", SqlDbType.NVarChar,20),
					new SqlParameter("@FACEDEV_NAME", SqlDbType.NVarChar,20),
					new SqlParameter("@FACEDEV_IP", SqlDbType.NVarChar,20),
					new SqlParameter("@FACEDEV_CTRL_PORT", SqlDbType.Int,4),
					new SqlParameter("@FACEDEV_USER", SqlDbType.NVarChar,20),
					new SqlParameter("@FACEDEV_PWD", SqlDbType.NVarChar,128),
					new SqlParameter("@FACEDEV_DB_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@FACEDEV_DB_PORT", SqlDbType.Int,4),
					new SqlParameter("@FACEDEV_DB_USER", SqlDbType.NVarChar,20),
					new SqlParameter("@FACEDEV_DB_PWD", SqlDbType.NVarChar,128),
					new SqlParameter("@AREA_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FACEDEV_IS_ENABLE", SqlDbType.Bit,1),
					new SqlParameter("@FACEDEV_HEART_PORT", SqlDbType.Int,4),
					new SqlParameter("@FACEDEV_MODE", SqlDbType.NVarChar,20),
					new SqlParameter("@FVIDEO_RTSP", SqlDbType.NVarChar,300),
					new SqlParameter("@FVIDEO_RTSP2", SqlDbType.NVarChar,300),
					new SqlParameter("@FVIDEO_RTSP3", SqlDbType.NVarChar,300),
					new SqlParameter("@FVIDEO_RTSP_COUNT", SqlDbType.Int,4),
					new SqlParameter("@FVIDEO_FACE_LEVEL", SqlDbType.Decimal,5),
					new SqlParameter("@FVIDEO_RIO_X", SqlDbType.Decimal,5),
					new SqlParameter("@FVIDEO_RIO_Y", SqlDbType.Decimal,5),
					new SqlParameter("@FVIDEO_RIO_H", SqlDbType.Decimal,5),
					new SqlParameter("@FVIDEO_RIO_W", SqlDbType.Decimal,5),
					new SqlParameter("@FVIDEO_SINGLE", SqlDbType.VarChar,2),
					new SqlParameter("@FVIDEO_TITLE1", SqlDbType.NVarChar,50),
					new SqlParameter("@FVIDEO_TITLE2", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.FACEDEV_SN;
			parameters[1].Value = model.FACEDEV_NAME;
			parameters[2].Value = model.FACEDEV_IP;
			parameters[3].Value = model.FACEDEV_CTRL_PORT;
			parameters[4].Value = model.FACEDEV_USER;
			parameters[5].Value = model.FACEDEV_PWD;
			parameters[6].Value = model.FACEDEV_DB_NAME;
			parameters[7].Value = model.FACEDEV_DB_PORT;
			parameters[8].Value = model.FACEDEV_DB_USER;
			parameters[9].Value = model.FACEDEV_DB_PWD;
			parameters[10].Value = model.AREA_ID;
			parameters[11].Value = model.FACEDEV_IS_ENABLE;
			parameters[12].Value = model.FACEDEV_HEART_PORT;
			parameters[13].Value = model.FACEDEV_MODE;
			parameters[14].Value = model.FVIDEO_RTSP;
			parameters[15].Value = model.FVIDEO_RTSP2;
			parameters[16].Value = model.FVIDEO_RTSP3;
			parameters[17].Value = model.FVIDEO_RTSP_COUNT;
			parameters[18].Value = model.FVIDEO_FACE_LEVEL;
			parameters[19].Value = model.FVIDEO_RIO_X;
			parameters[20].Value = model.FVIDEO_RIO_Y;
			parameters[21].Value = model.FVIDEO_RIO_H;
			parameters[22].Value = model.FVIDEO_RIO_W;
			parameters[23].Value = model.FVIDEO_SINGLE;
			parameters[24].Value = model.FVIDEO_TITLE1;
			parameters[25].Value = model.FVIDEO_TITLE2;

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
		public bool Update(Maticsoft.Model.SMT_FACERECG_DEVICE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SMT_FACERECG_DEVICE set ");
			strSql.Append("FACEDEV_SN=@FACEDEV_SN,");
			strSql.Append("FACEDEV_NAME=@FACEDEV_NAME,");
			strSql.Append("FACEDEV_IP=@FACEDEV_IP,");
			strSql.Append("FACEDEV_CTRL_PORT=@FACEDEV_CTRL_PORT,");
			strSql.Append("FACEDEV_USER=@FACEDEV_USER,");
			strSql.Append("FACEDEV_PWD=@FACEDEV_PWD,");
			strSql.Append("FACEDEV_DB_NAME=@FACEDEV_DB_NAME,");
			strSql.Append("FACEDEV_DB_PORT=@FACEDEV_DB_PORT,");
			strSql.Append("FACEDEV_DB_USER=@FACEDEV_DB_USER,");
			strSql.Append("FACEDEV_DB_PWD=@FACEDEV_DB_PWD,");
			strSql.Append("AREA_ID=@AREA_ID,");
			strSql.Append("FACEDEV_IS_ENABLE=@FACEDEV_IS_ENABLE,");
			strSql.Append("FACEDEV_HEART_PORT=@FACEDEV_HEART_PORT,");
			strSql.Append("FACEDEV_MODE=@FACEDEV_MODE,");
			strSql.Append("FVIDEO_RTSP=@FVIDEO_RTSP,");
			strSql.Append("FVIDEO_RTSP2=@FVIDEO_RTSP2,");
			strSql.Append("FVIDEO_RTSP3=@FVIDEO_RTSP3,");
			strSql.Append("FVIDEO_RTSP_COUNT=@FVIDEO_RTSP_COUNT,");
			strSql.Append("FVIDEO_FACE_LEVEL=@FVIDEO_FACE_LEVEL,");
			strSql.Append("FVIDEO_RIO_X=@FVIDEO_RIO_X,");
			strSql.Append("FVIDEO_RIO_Y=@FVIDEO_RIO_Y,");
			strSql.Append("FVIDEO_RIO_H=@FVIDEO_RIO_H,");
			strSql.Append("FVIDEO_RIO_W=@FVIDEO_RIO_W,");
			strSql.Append("FVIDEO_SINGLE=@FVIDEO_SINGLE,");
			strSql.Append("FVIDEO_TITLE1=@FVIDEO_TITLE1,");
			strSql.Append("FVIDEO_TITLE2=@FVIDEO_TITLE2");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@FACEDEV_SN", SqlDbType.NVarChar,20),
					new SqlParameter("@FACEDEV_NAME", SqlDbType.NVarChar,20),
					new SqlParameter("@FACEDEV_IP", SqlDbType.NVarChar,20),
					new SqlParameter("@FACEDEV_CTRL_PORT", SqlDbType.Int,4),
					new SqlParameter("@FACEDEV_USER", SqlDbType.NVarChar,20),
					new SqlParameter("@FACEDEV_PWD", SqlDbType.NVarChar,128),
					new SqlParameter("@FACEDEV_DB_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@FACEDEV_DB_PORT", SqlDbType.Int,4),
					new SqlParameter("@FACEDEV_DB_USER", SqlDbType.NVarChar,20),
					new SqlParameter("@FACEDEV_DB_PWD", SqlDbType.NVarChar,128),
					new SqlParameter("@AREA_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FACEDEV_IS_ENABLE", SqlDbType.Bit,1),
					new SqlParameter("@FACEDEV_HEART_PORT", SqlDbType.Int,4),
					new SqlParameter("@FACEDEV_MODE", SqlDbType.NVarChar,20),
					new SqlParameter("@FVIDEO_RTSP", SqlDbType.NVarChar,300),
					new SqlParameter("@FVIDEO_RTSP2", SqlDbType.NVarChar,300),
					new SqlParameter("@FVIDEO_RTSP3", SqlDbType.NVarChar,300),
					new SqlParameter("@FVIDEO_RTSP_COUNT", SqlDbType.Int,4),
					new SqlParameter("@FVIDEO_FACE_LEVEL", SqlDbType.Decimal,5),
					new SqlParameter("@FVIDEO_RIO_X", SqlDbType.Decimal,5),
					new SqlParameter("@FVIDEO_RIO_Y", SqlDbType.Decimal,5),
					new SqlParameter("@FVIDEO_RIO_H", SqlDbType.Decimal,5),
					new SqlParameter("@FVIDEO_RIO_W", SqlDbType.Decimal,5),
					new SqlParameter("@FVIDEO_SINGLE", SqlDbType.VarChar,2),
					new SqlParameter("@FVIDEO_TITLE1", SqlDbType.NVarChar,50),
					new SqlParameter("@FVIDEO_TITLE2", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.FACEDEV_SN;
			parameters[1].Value = model.FACEDEV_NAME;
			parameters[2].Value = model.FACEDEV_IP;
			parameters[3].Value = model.FACEDEV_CTRL_PORT;
			parameters[4].Value = model.FACEDEV_USER;
			parameters[5].Value = model.FACEDEV_PWD;
			parameters[6].Value = model.FACEDEV_DB_NAME;
			parameters[7].Value = model.FACEDEV_DB_PORT;
			parameters[8].Value = model.FACEDEV_DB_USER;
			parameters[9].Value = model.FACEDEV_DB_PWD;
			parameters[10].Value = model.AREA_ID;
			parameters[11].Value = model.FACEDEV_IS_ENABLE;
			parameters[12].Value = model.FACEDEV_HEART_PORT;
			parameters[13].Value = model.FACEDEV_MODE;
			parameters[14].Value = model.FVIDEO_RTSP;
			parameters[15].Value = model.FVIDEO_RTSP2;
			parameters[16].Value = model.FVIDEO_RTSP3;
			parameters[17].Value = model.FVIDEO_RTSP_COUNT;
			parameters[18].Value = model.FVIDEO_FACE_LEVEL;
			parameters[19].Value = model.FVIDEO_RIO_X;
			parameters[20].Value = model.FVIDEO_RIO_Y;
			parameters[21].Value = model.FVIDEO_RIO_H;
			parameters[22].Value = model.FVIDEO_RIO_W;
			parameters[23].Value = model.FVIDEO_SINGLE;
			parameters[24].Value = model.FVIDEO_TITLE1;
			parameters[25].Value = model.FVIDEO_TITLE2;
			parameters[26].Value = model.ID;

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
			strSql.Append("delete from SMT_FACERECG_DEVICE ");
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
			strSql.Append("delete from SMT_FACERECG_DEVICE ");
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
		public Maticsoft.Model.SMT_FACERECG_DEVICE GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,FACEDEV_SN,FACEDEV_NAME,FACEDEV_IP,FACEDEV_CTRL_PORT,FACEDEV_USER,FACEDEV_PWD,FACEDEV_DB_NAME,FACEDEV_DB_PORT,FACEDEV_DB_USER,FACEDEV_DB_PWD,AREA_ID,FACEDEV_IS_ENABLE,FACEDEV_HEART_PORT,FACEDEV_MODE,FVIDEO_RTSP,FVIDEO_RTSP2,FVIDEO_RTSP3,FVIDEO_RTSP_COUNT,FVIDEO_FACE_LEVEL,FVIDEO_RIO_X,FVIDEO_RIO_Y,FVIDEO_RIO_H,FVIDEO_RIO_W,FVIDEO_SINGLE,FVIDEO_TITLE1,FVIDEO_TITLE2 from SMT_FACERECG_DEVICE ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.SMT_FACERECG_DEVICE model=new Maticsoft.Model.SMT_FACERECG_DEVICE();
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
		public Maticsoft.Model.SMT_FACERECG_DEVICE DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SMT_FACERECG_DEVICE model=new Maticsoft.Model.SMT_FACERECG_DEVICE();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["FACEDEV_SN"]!=null)
				{
					model.FACEDEV_SN=row["FACEDEV_SN"].ToString();
				}
				if(row["FACEDEV_NAME"]!=null)
				{
					model.FACEDEV_NAME=row["FACEDEV_NAME"].ToString();
				}
				if(row["FACEDEV_IP"]!=null)
				{
					model.FACEDEV_IP=row["FACEDEV_IP"].ToString();
				}
				if(row["FACEDEV_CTRL_PORT"]!=null && row["FACEDEV_CTRL_PORT"].ToString()!="")
				{
					model.FACEDEV_CTRL_PORT=int.Parse(row["FACEDEV_CTRL_PORT"].ToString());
				}
				if(row["FACEDEV_USER"]!=null)
				{
					model.FACEDEV_USER=row["FACEDEV_USER"].ToString();
				}
				if(row["FACEDEV_PWD"]!=null)
				{
					model.FACEDEV_PWD=row["FACEDEV_PWD"].ToString();
				}
				if(row["FACEDEV_DB_NAME"]!=null)
				{
					model.FACEDEV_DB_NAME=row["FACEDEV_DB_NAME"].ToString();
				}
				if(row["FACEDEV_DB_PORT"]!=null && row["FACEDEV_DB_PORT"].ToString()!="")
				{
					model.FACEDEV_DB_PORT=int.Parse(row["FACEDEV_DB_PORT"].ToString());
				}
				if(row["FACEDEV_DB_USER"]!=null)
				{
					model.FACEDEV_DB_USER=row["FACEDEV_DB_USER"].ToString();
				}
				if(row["FACEDEV_DB_PWD"]!=null)
				{
					model.FACEDEV_DB_PWD=row["FACEDEV_DB_PWD"].ToString();
				}
				if(row["AREA_ID"]!=null && row["AREA_ID"].ToString()!="")
				{
					model.AREA_ID=decimal.Parse(row["AREA_ID"].ToString());
				}
				if(row["FACEDEV_IS_ENABLE"]!=null && row["FACEDEV_IS_ENABLE"].ToString()!="")
				{
					if((row["FACEDEV_IS_ENABLE"].ToString()=="1")||(row["FACEDEV_IS_ENABLE"].ToString().ToLower()=="true"))
					{
						model.FACEDEV_IS_ENABLE=true;
					}
					else
					{
						model.FACEDEV_IS_ENABLE=false;
					}
				}
				if(row["FACEDEV_HEART_PORT"]!=null && row["FACEDEV_HEART_PORT"].ToString()!="")
				{
					model.FACEDEV_HEART_PORT=int.Parse(row["FACEDEV_HEART_PORT"].ToString());
				}
				if(row["FACEDEV_MODE"]!=null)
				{
					model.FACEDEV_MODE=row["FACEDEV_MODE"].ToString();
				}
				if(row["FVIDEO_RTSP"]!=null)
				{
					model.FVIDEO_RTSP=row["FVIDEO_RTSP"].ToString();
				}
				if(row["FVIDEO_RTSP2"]!=null)
				{
					model.FVIDEO_RTSP2=row["FVIDEO_RTSP2"].ToString();
				}
				if(row["FVIDEO_RTSP3"]!=null)
				{
					model.FVIDEO_RTSP3=row["FVIDEO_RTSP3"].ToString();
				}
				if(row["FVIDEO_RTSP_COUNT"]!=null && row["FVIDEO_RTSP_COUNT"].ToString()!="")
				{
					model.FVIDEO_RTSP_COUNT=int.Parse(row["FVIDEO_RTSP_COUNT"].ToString());
				}
				if(row["FVIDEO_FACE_LEVEL"]!=null && row["FVIDEO_FACE_LEVEL"].ToString()!="")
				{
					model.FVIDEO_FACE_LEVEL=decimal.Parse(row["FVIDEO_FACE_LEVEL"].ToString());
				}
				if(row["FVIDEO_RIO_X"]!=null && row["FVIDEO_RIO_X"].ToString()!="")
				{
					model.FVIDEO_RIO_X=decimal.Parse(row["FVIDEO_RIO_X"].ToString());
				}
				if(row["FVIDEO_RIO_Y"]!=null && row["FVIDEO_RIO_Y"].ToString()!="")
				{
					model.FVIDEO_RIO_Y=decimal.Parse(row["FVIDEO_RIO_Y"].ToString());
				}
				if(row["FVIDEO_RIO_H"]!=null && row["FVIDEO_RIO_H"].ToString()!="")
				{
					model.FVIDEO_RIO_H=decimal.Parse(row["FVIDEO_RIO_H"].ToString());
				}
				if(row["FVIDEO_RIO_W"]!=null && row["FVIDEO_RIO_W"].ToString()!="")
				{
					model.FVIDEO_RIO_W=decimal.Parse(row["FVIDEO_RIO_W"].ToString());
				}
				if(row["FVIDEO_SINGLE"]!=null)
				{
					model.FVIDEO_SINGLE=row["FVIDEO_SINGLE"].ToString();
				}
				if(row["FVIDEO_TITLE1"]!=null)
				{
					model.FVIDEO_TITLE1=row["FVIDEO_TITLE1"].ToString();
				}
				if(row["FVIDEO_TITLE2"]!=null)
				{
					model.FVIDEO_TITLE2=row["FVIDEO_TITLE2"].ToString();
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
			strSql.Append("select ID,FACEDEV_SN,FACEDEV_NAME,FACEDEV_IP,FACEDEV_CTRL_PORT,FACEDEV_USER,FACEDEV_PWD,FACEDEV_DB_NAME,FACEDEV_DB_PORT,FACEDEV_DB_USER,FACEDEV_DB_PWD,AREA_ID,FACEDEV_IS_ENABLE,FACEDEV_HEART_PORT,FACEDEV_MODE,FVIDEO_RTSP,FVIDEO_RTSP2,FVIDEO_RTSP3,FVIDEO_RTSP_COUNT,FVIDEO_FACE_LEVEL,FVIDEO_RIO_X,FVIDEO_RIO_Y,FVIDEO_RIO_H,FVIDEO_RIO_W,FVIDEO_SINGLE,FVIDEO_TITLE1,FVIDEO_TITLE2 ");
			strSql.Append(" FROM SMT_FACERECG_DEVICE ");
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
			strSql.Append(" ID,FACEDEV_SN,FACEDEV_NAME,FACEDEV_IP,FACEDEV_CTRL_PORT,FACEDEV_USER,FACEDEV_PWD,FACEDEV_DB_NAME,FACEDEV_DB_PORT,FACEDEV_DB_USER,FACEDEV_DB_PWD,AREA_ID,FACEDEV_IS_ENABLE,FACEDEV_HEART_PORT,FACEDEV_MODE,FVIDEO_RTSP,FVIDEO_RTSP2,FVIDEO_RTSP3,FVIDEO_RTSP_COUNT,FVIDEO_FACE_LEVEL,FVIDEO_RIO_X,FVIDEO_RIO_Y,FVIDEO_RIO_H,FVIDEO_RIO_W,FVIDEO_SINGLE,FVIDEO_TITLE1,FVIDEO_TITLE2 ");
			strSql.Append(" FROM SMT_FACERECG_DEVICE ");
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
			strSql.Append("select count(1) FROM SMT_FACERECG_DEVICE ");
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
			strSql.Append(")AS Row, T.*  from SMT_FACERECG_DEVICE T ");
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
			parameters[0].Value = "SMT_FACERECG_DEVICE";
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

