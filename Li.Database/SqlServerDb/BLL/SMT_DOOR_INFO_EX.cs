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
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 门表
	/// </summary>
	public partial class SMT_DOOR_INFO
	{
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_DOOR_INFO> GetModelListWithArea(string strWhere)
        {
            DataSet ds = dal.GetListWithArea(strWhere);
            return DataTableToListWithArea(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_DOOR_INFO> DataTableToListWithArea(DataTable dt)
        {
            List<Maticsoft.Model.SMT_DOOR_INFO> modelList = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_DOOR_INFO model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        if (dt.Rows[n]["AREA_ID"] != null && dt.Rows[n]["AREA_ID"].ToString() != "")
                        {
                            model.AREA_ID = decimal.Parse(dt.Rows[n]["AREA_ID"].ToString());
                        }
                        if (dt.Rows[n]["ZONE_NAME"] != null)
                        {
                            model.AREA_NAME = dt.Rows[n]["ZONE_NAME"].ToString();
                        }
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
	}
}

