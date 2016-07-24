/**  版本信息模板在安装目录下，可自行修改。
* SMT_CONTROLLER_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_CONTROLLER_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/23 15:31:37   N/A    初版
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
	/// 数据访问类:SMT_CONTROLLER_INFO
	/// </summary>
	public partial class SMT_CONTROLLER_INFO
	{
		#region  ExtensionMethod
        public DataSet GetListWithArea(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t1.*,t2.ZONE_NAME from SMT_CONTROLLER_INFO t1 left join SMT_CONTROLLER_ZONE t2 on t1.AREA_ID=t2.ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public Maticsoft.Model.SMT_CONTROLLER_INFO DataRowToModelWithArea(DataRow row)
        {
            Maticsoft.Model.SMT_CONTROLLER_INFO model = DataRowToModel(row);
            if (row != null)
            {
                if (row["ZONE_NAME"] != null)
                {
                    model.AREA_NAME = row["ZONE_NAME"].ToString();
                }
            }
            return model;
        }

		#endregion  ExtensionMethod
	}
}

