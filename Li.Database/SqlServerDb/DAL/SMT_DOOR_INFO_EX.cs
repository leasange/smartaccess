/**  版本信息模板在安装目录下，可自行修改。
* SMT_DOOR_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_DOOR_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/5 0:01:57   N/A    初版
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
	/// 数据访问类:SMT_DOOR_INFO
	/// </summary>
	public partial class SMT_DOOR_INFO
	{

        public DataSet GetListWithArea(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            if (strWhere.Trim() != "")
            {
                strSql.Append("select * from (");
            }

            strSql.Append("select DI.*,CI.AREA_ID,CZ.ZONE_NAME  FROM SMT_DOOR_INFO DI,SMT_CONTROLLER_INFO CI left join SMT_CONTROLLER_ZONE CZ on CZ.ID=CI.AREA_ID where DI.CTRL_ID=CI.ID");

            if (strWhere.Trim() != "")
            {
                strSql.Append(") TT where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
	}
}

