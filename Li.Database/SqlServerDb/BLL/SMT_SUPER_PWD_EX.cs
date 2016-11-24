/**  版本信息模板在安装目录下，可自行修改。
* SMT_SUPER_PWD.cs
*
* 功 能： N/A
* 类 名： SMT_SUPER_PWD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/14 23:33:00   N/A    初版
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
	/// 超级通信密码表
	/// </summary>
	public partial class SMT_SUPER_PWD
	{
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.SMT_SUPER_PWD> GetModelListEx(string strWhere)
		{
            DataSet ds = dal.GetListEx(strWhere);
            return DataTableToListEx(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.SMT_SUPER_PWD> DataTableToListEx(DataTable dt)
		{
			List<Maticsoft.Model.SMT_SUPER_PWD> modelList = new List<Maticsoft.Model.SMT_SUPER_PWD>();
            Maticsoft.DAL.SMT_DOOR_INFO dalDoor = new DAL.SMT_DOOR_INFO();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.SMT_SUPER_PWD model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
                    model.DOOR_INFO = dalDoor.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}
	}
}

