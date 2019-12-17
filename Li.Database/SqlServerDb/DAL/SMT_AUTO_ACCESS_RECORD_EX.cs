/**  版本信息模板在安装目录下，可自行修改。
* SMT_AUTO_ACCESS_RECORD.cs
*
* 功 能： N/A
* 类 名： SMT_AUTO_ACCESS_RECORD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/11/9 16:02:25   N/A    初版
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
	/// 数据访问类:SMT_AUTO_ACCESS_RECORD
	/// </summary>
	public partial class SMT_AUTO_ACCESS_RECORD
	{
		#region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListEx(string strWhere, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT ");
            strSql.Append("    TTT.*, SDI.DOOR_NAME ");
            strSql.Append("FROM ");
            strSql.Append("    ( ");
            strSql.Append("        SELECT ");
            strSql.Append("            SAAR.*, SSI.REAL_NAME AS STAFF_REAL_NAME ");
            strSql.Append("        FROM ");
            strSql.Append("            ( ");
            strSql.Append("	            ( ");
            strSql.Append("		            SELECT ");
            strSql.Append("			            TT.* ");
            strSql.Append("		            FROM ");
            strSql.Append("			            ( ");
            strSql.Append("				            SELECT ");
            strSql.Append("					            ROW_NUMBER () OVER (ORDER BY T.ACC_ADD_TIME DESC) AS Row, ");
            strSql.Append("					            T.* ");
            strSql.Append("				            FROM ");
            strSql.Append("					            SMT_AUTO_ACCESS_RECORD T ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("			            ) TT ");
            if (startIndex >= 0)
            {
                strSql.Append("		            WHERE ");
                strSql.AppendFormat("			            TT.Row BETWEEN {0} AND {1} ", startIndex, endIndex);
            }
            strSql.Append("	            ) SAAR ");
            strSql.Append("	            LEFT JOIN SMT_STAFF_INFO SSI ON SAAR.ACC_STAFF_ID = SSI.ID ");
            strSql.Append("            ) ");
            strSql.Append("    ) TTT ");
            strSql.Append(" LEFT JOIN SMT_DOOR_INFO SDI ON TTT.ACC_DOOR_ID = SDI.ID ");

            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  ExtensionMethod
	}
}

