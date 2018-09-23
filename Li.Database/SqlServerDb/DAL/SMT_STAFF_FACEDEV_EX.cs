/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_FACEDEV.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_FACEDEV
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/2 15:10:17   N/A    初版
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
	/// 数据访问类:SMT_STAFF_FACEDEV
	/// </summary>
    public partial class SMT_STAFF_FACEDEV
    {
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.SMT_STAFF_FACEDEV DataRowToModelEx(DataRow row)
        {
            Maticsoft.Model.SMT_STAFF_FACEDEV model = new Maticsoft.Model.SMT_STAFF_FACEDEV();
            if (row != null)
            {
                if (row["STAFF_ID"] != null && row["STAFF_ID"].ToString() != "")
                {
                    model.STAFF_ID = decimal.Parse(row["STAFF_ID"].ToString());
                }
                if (row["FACEDEV_ID"] != null && row["FACEDEV_ID"].ToString() != "")
                {
                    model.FACEDEV_ID = decimal.Parse(row["FACEDEV_ID"].ToString());
                }
                if (row["IS_UPLOAD"] != null && row["IS_UPLOAD"].ToString() != "")
                {
                    if ((row["IS_UPLOAD"].ToString() == "1") || (row["IS_UPLOAD"].ToString().ToLower() == "true"))
                    {
                        model.IS_UPLOAD = true;
                    }
                    else
                    {
                        model.IS_UPLOAD = false;
                    }
                }
                if (row["UPLOAD_TIME"] != null && row["UPLOAD_TIME"].ToString() != "")
                {
                    model.UPLOAD_TIME = DateTime.Parse(row["UPLOAD_TIME"].ToString());
                }
                if (row["ADD_TIME"] != null && row["ADD_TIME"].ToString() != "")
                {
                    model.ADD_TIME = DateTime.Parse(row["ADD_TIME"].ToString());
                }
                if (row["START_VALID_TIME"] != null && row["START_VALID_TIME"].ToString() != "")
                {
                    model.START_VALID_TIME = DateTime.Parse(row["START_VALID_TIME"].ToString());
                }
                if (row["END_VALID_TIME"] != null && row["END_VALID_TIME"].ToString() != "")
                {
                    model.END_VALID_TIME = DateTime.Parse(row["END_VALID_TIME"].ToString());
                }
                if (row["STAFF_DEV_ID"] != null)
                {
                    model.STAFF_DEV_ID = row["STAFF_DEV_ID"].ToString();
                }
                if (row["REAL_NAME"]!=null)
                {
                      model.REAL_NAME = row["REAL_NAME"].ToString();
                }
                if (row["STAFF_NO"] != null)
                {
                    model.STAFF_NO = row["STAFF_NO"].ToString();
                }
                if (row["STAFF_TYPE"] != null)
                {
                    model.STAFF_TYPE = row["STAFF_TYPE"].ToString();
                }
                if (row["ORG_ID"] != null && row["ORG_ID"].ToString() != "")
                {
                    model.ORG_ID = decimal.Parse(row["ORG_ID"].ToString());
                }
                if (row["ORG_NAME"] != null)
                {
                    model.ORG_NAME = row["ORG_NAME"].ToString();
                }
                if (row["PHOTO"] != null && row["PHOTO"].ToString() != "")
                {
                    model.PHOTO = (byte[])row["PHOTO"];
                }
                if (row["IS_FORBIDDEN"] != null && row["IS_FORBIDDEN"].ToString() != "")
                {
                    if ((row["IS_FORBIDDEN"].ToString() == "1") || (row["IS_FORBIDDEN"].ToString().ToLower() == "true"))
                    {
                        model.IS_FORBIDDEN = true;
                    }
                    else
                    {
                        model.IS_FORBIDDEN = false;
                    }
                }
                if (row["FACEDEV_NAME"] != null)
                {
                    model.FACEDEV_NAME = row["FACEDEV_NAME"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListEx(string strWhere, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT ");
            strSql.Append("	* ");
            strSql.Append("FROM ");
            strSql.Append("	( ");
            strSql.Append("		SELECT ");
            strSql.Append("			TT.*, ROW_NUMBER() OVER (ORDER BY TT.ORG_ID) as Row,SOI.ORG_NAME ");
            strSql.Append("		FROM ");
            strSql.Append("			( ");
            strSql.Append("				SELECT ");
            strSql.Append("					SSF.*, SSI.REAL_NAME,SSI.PHOTO,SSI.IS_FORBIDDEN,SFD.FACEDEV_NAME, ");
            strSql.Append("					SSI.STAFF_NO, ");
            strSql.Append("					SSI.STAFF_TYPE, ");
            strSql.Append("					SSI.ORG_ID ");
            strSql.Append("				FROM ");
            strSql.Append("					SMT_STAFF_FACEDEV SSF,SMT_STAFF_INFO SSI,SMT_FACERECG_DEVICE SFD ");
            strSql.Append("				WHERE SSF.STAFF_ID = SSI.ID AND SFD.ID = SSF.FACEDEV_ID  ");
            strSql.Append("				AND SSI.IS_DELETE = 0 ");
            strSql.Append("			) TT ");
            strSql.Append("		LEFT JOIN SMT_ORG_INFO SOI ON TT.ORG_ID = SOI.ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (endIndex<=0)
            {
                strSql.AppendFormat("	) TTT");
            }
            else
            {
                strSql.AppendFormat("	) TTT WHERE Row BETWEEN {0} and  {1} ", startIndex, endIndex);
            }
           

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCountEx(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT ");
            strSql.Append("  COUNT (1) ");
            strSql.Append(" FROM ");
            strSql.Append("    ( ");
            strSql.Append("       SELECT ");
            strSql.Append("          TT.*, SOI.ORG_NAME ");
            strSql.Append("     FROM ");
            strSql.Append("        ( ");
            strSql.Append("            SELECT ");
            strSql.Append("	            SSF.*, SSI.REAL_NAME,");
            strSql.Append("	            SSI.STAFF_NO,");
            strSql.Append("	            SSI.STAFF_TYPE,");
            strSql.Append("	            SSI.ORG_ID ");
            strSql.Append("            FROM ");
            strSql.Append("	            SMT_STAFF_FACEDEV SSF,SMT_STAFF_INFO SSI,SMT_FACERECG_DEVICE SFD  ");
            strSql.Append("           WHERE SSF.STAFF_ID = SSI.ID AND SFD.ID = SSF.FACEDEV_ID ");
            strSql.Append("           AND SSI.IS_DELETE = 0 ");
            strSql.Append("       ) TT ");
            strSql.Append("  LEFT JOIN SMT_ORG_INFO SOI ON TT.ORG_ID = SOI.ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("   ) TTT ");
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
        #endregion  ExtensionMethod
    }
}

