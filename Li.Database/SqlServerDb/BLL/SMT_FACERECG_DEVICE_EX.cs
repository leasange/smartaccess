/**  版本信息模板在安装目录下，可自行修改。
* SMT_FACERECG_DEVICE.cs
*
* 功 能： N/A
* 类 名： SMT_FACERECG_DEVICE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/9/2 20:58:10   N/A    初版
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
	/// 人脸识别设备
	/// </summary>
	public partial class SMT_FACERECG_DEVICE
	{
		#region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_FACERECG_DEVICE> GetModelListWithArea(string strWhere)
        {
            DataSet ds = dal.GetListWithArea(strWhere);
            return DataTableToListWithArea(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_FACERECG_DEVICE> DataTableToListWithArea(DataTable dt)
        {
            List<Maticsoft.Model.SMT_FACERECG_DEVICE> modelList = new List<Maticsoft.Model.SMT_FACERECG_DEVICE>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_FACERECG_DEVICE model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelWithArea(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
		#endregion  ExtensionMethod
	}
}

