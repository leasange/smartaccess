/**  版本信息模板在安装目录下，可自行修改。
* SMT_SUPER_PWD.cs
*
* 功 能： N/A
* 类 名： SMT_SUPER_PWD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/14 23:33:00   N/A    初版
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
	/// 数据访问类:SMT_SUPER_PWD
	/// </summary>
	public partial class SMT_SUPER_PWD
	{

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListEx(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t1.*,t2.*");
            strSql.Append(" FROM SMT_SUPER_PWD t1,SMT_DOOR_INFO t2 where t1.DOOR_ID = t2.ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and (" + strWhere+")");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
	}
}

