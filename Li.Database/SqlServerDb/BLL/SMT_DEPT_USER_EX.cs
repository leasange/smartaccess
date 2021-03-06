﻿/**  版本信息模板在安装目录下，可自行修改。
* SMT_DEPT_USER.cs
*
* 功 能： N/A
* 类 名： SMT_DEPT_USER
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/28 23:27:37   N/A    初版
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
	/// 部门用户权限表
	/// </summary>
	public partial class SMT_DEPT_USER
	{
		#region  BasicMethod
        private Maticsoft.DAL.SMT_USER_INFO userDAL = new Maticsoft.DAL.SMT_USER_INFO();
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Maticsoft.Model.SMT_DEPT_USER> GetModelListEx(string strWhere)
        {
            DataSet ds = dal.GetListEx(strWhere);
            return DataTableToListEx(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_DEPT_USER> DataTableToListEx(DataTable dt)
        {
            List<Maticsoft.Model.SMT_DEPT_USER> modelList = new List<Maticsoft.Model.SMT_DEPT_USER>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_DEPT_USER model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    model.USER_INFO = userDAL.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

		#endregion  BasicMethod
	}
}

