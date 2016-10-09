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
        public DataSet GetListByPageEx(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TTT.*,RI.ROLE_NAME FROM (  ");
            strSql.Append("SELECT TT.*,OI.ORG_NAME FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
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
            strSql.Append(" ) TT left join SMT_ORG_INFO OI on TT.ORG_ID=OI.ID ");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            strSql.Append(" )TTT left join SMT_ROLE_INFO RI on TTT.ROLE_ID=RI.ID");

            return DbHelperSQL.Query(strSql.ToString());
        }

	}
}

