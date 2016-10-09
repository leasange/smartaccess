/**  版本信息模板在安装目录下，可自行修改。
* SMT_USER_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_USER_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/10/9 20:03:26   N/A    初版
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
	/// 系统用户表
	/// </summary>
	public partial class SMT_USER_INFO
	{
        public List<Maticsoft.Model.SMT_USER_INFO> GetModelListByPageEx(string strWhere, string orderby, int startIndex, int endIndex)
        {
            DataSet ds = dal.GetListByPageEx(strWhere, orderby, startIndex, endIndex);
            List<Maticsoft.Model.SMT_USER_INFO> list = new List<Model.SMT_USER_INFO>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var model = dal.DataRowToModel(row);
                if (row["ORG_NAME"] != null)
                {
                    model.DEPT_NAME = row["ORG_NAME"].ToString();
                }
                if (row["ROLE_NAME"] != null)
                {
                    model.ROLE_NAME = row["ROLE_NAME"].ToString();
                }
                list.Add(model);
            }
            return list;
        }
	}
}

