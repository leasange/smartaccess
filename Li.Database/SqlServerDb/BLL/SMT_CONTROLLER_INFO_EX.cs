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
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 控制器表
	/// </summary>
	public partial class SMT_CONTROLLER_INFO
	{
		#region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_CONTROLLER_INFO> GetModelListWithAreaDoor(string strWhere)
        {
            DataSet ds = dal.GetListWithArea(strWhere);
            return DataTableToListWithAreaDoor(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_CONTROLLER_INFO> DataTableToListWithAreaDoor(DataTable dt)
        {
            List<Maticsoft.Model.SMT_CONTROLLER_INFO> modelList = new List<Maticsoft.Model.SMT_CONTROLLER_INFO>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_CONTROLLER_INFO model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModelWithArea(dt.Rows[n]);
                    if (model != null)
                    {
                        SMT_DOOR_INFO bll = new SMT_DOOR_INFO();
                        List<Model.SMT_DOOR_INFO> doors = bll.GetModelList("CTRL_ID=" + model.ID);
                        model.DOOR_INFOS = doors;
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
		#endregion  ExtensionMethod
	}
}

