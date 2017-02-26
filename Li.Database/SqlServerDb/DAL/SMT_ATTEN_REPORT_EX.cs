/**  版本信息模板在安装目录下，可自行修改。
* SMT_ATTEN_REPORT.cs
*
* 功 能： N/A
* 类 名： SMT_ATTEN_REPORT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/25 21:10:34   N/A    初版
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
	/// 数据访问类:SMT_ATTEN_REPORT
	/// </summary>
	public partial class SMT_ATTEN_REPORT
    {
        public DataSet GetListEx(string staffNo, string staffName, string orgIds, string startTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SAR.*,SSI.STAFF_NO,SSI.REAL_NAME,SOI.ORG_NAME  from SMT_ATTEN_REPORT SAR,SMT_STAFF_INFO SSI LEFT JOIN SMT_ORG_INFO SOI ON SSI.ORG_ID=SOI.ID WHERE SSI.IS_DELETE=0 and SAR.STAFF_ID=SSI.ID  ");
            if (!string.IsNullOrWhiteSpace(staffName) || !string.IsNullOrWhiteSpace(orgIds) || !string.IsNullOrWhiteSpace(staffNo)
                || !string.IsNullOrWhiteSpace(startTime) || !string.IsNullOrWhiteSpace(endTime))
            {
                string str = "";

                if (!string.IsNullOrWhiteSpace(staffNo))
                {
                    str += string.Format(" and SSI.STAFF_NO like '%{0}%' ", staffNo.Trim());
                }

                if (!string.IsNullOrWhiteSpace(staffName))
                {
                    str += string.Format(" and SSI.REAL_NAME like '%{0}%' ", staffName.Trim());
                }

                if (!string.IsNullOrWhiteSpace(orgIds))
                {
                    str += string.Format(" and SOI.ID in ({0}) ", orgIds);
                }

                if (!string.IsNullOrWhiteSpace(startTime))
                {
                    str += string.Format(" and SAR.ATTEN_DATE >='{0}'", startTime);
                }

                if (!string.IsNullOrWhiteSpace(endTime))
                {
                    str += string.Format(" and SAR.ATTEN_DATE <='{0}'", endTime);
                }

                strSql.Append(str);
            }
            strSql.Append(" ORDER BY SAR.ATTEN_DATE,SOI.ORG_NAME,SSI.REAL_NAME ");
            return DbHelperSQL.Query(strSql.ToString());
        }
      
	}
}

