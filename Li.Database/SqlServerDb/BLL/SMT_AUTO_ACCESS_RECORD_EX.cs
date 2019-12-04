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
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// SMT_AUTO_ACCESS_RECORD
	/// </summary>
	public partial class SMT_AUTO_ACCESS_RECORD
	{
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> GetModelListEx(string strWhere,int startIndex,int endIndex)
        {
            DataSet ds = dal.GetListEx(strWhere,startIndex,endIndex);
            return DataTableToListEx(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> DataTableToListEx(DataTable dt)
        {
            List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> modelList = new List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_AUTO_ACCESS_RECORD model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        if (dt.Rows[n]["STAFF_REAL_NAME"] != null)
                        {
                            model.STAFF_REAL_NAME = dt.Rows[n]["STAFF_REAL_NAME"].ToString();
                        }
                        if (dt.Rows[n]["DOOR_NAME"] != null)
                        {
                            model.DOOR_NAME = dt.Rows[n]["DOOR_NAME"].ToString();
                        }
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
	}
}

