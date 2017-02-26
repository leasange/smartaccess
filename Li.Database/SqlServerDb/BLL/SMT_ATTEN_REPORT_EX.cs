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
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 考勤信息报表
	/// </summary>
	public partial class SMT_ATTEN_REPORT
	{
		#region  ExtensionMethod
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_ATTEN_REPORT> GetModelListEx(string staffNo,string staffName,string orgIds,string startTime,string endTime)
        {
            DataSet ds = dal.GetListEx(staffNo,staffName, orgIds,startTime,endTime);
            return DataTableToListEx(ds.Tables[0]);
        }
        public List<Maticsoft.Model.SMT_ATTEN_REPORT> DataTableToListEx(DataTable dt)
        {
            List<Maticsoft.Model.SMT_ATTEN_REPORT> modelList = new List<Maticsoft.Model.SMT_ATTEN_REPORT>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_ATTEN_REPORT model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        if (dt.Rows[n]["STAFF_NO"] != null)
                        {
                            model.STAFF_NO = dt.Rows[n]["STAFF_NO"].ToString();
                        }
                        if (dt.Rows[n]["REAL_NAME"] != null)
                        {
                            model.REAL_NAME = dt.Rows[n]["REAL_NAME"].ToString();
                        }
                        if (dt.Rows[n]["ORG_NAME"] != null)
                        {
                            model.ORG_NAME = dt.Rows[n]["ORG_NAME"].ToString();
                        }
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
		#endregion  ExtensionMethod
	}
}

