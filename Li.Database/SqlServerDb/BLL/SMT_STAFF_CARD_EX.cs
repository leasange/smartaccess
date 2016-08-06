/**  版本信息模板在安装目录下，可自行修改。
* SMT_STAFF_CARD.cs
*
* 功 能： N/A
* 类 名： SMT_STAFF_CARD
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/24 22:45:06   N/A    初版
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
	/// 员工卡关联表
	/// </summary>
	public partial class SMT_STAFF_CARD
	{
		#region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_STAFF_CARD> GetModelListByCardNo(string cardNo)
        {
            DataSet ds = dal.GetListByCardNo(cardNo);
            return DataTableToList(ds.Tables[0]);
        }
        public List<Maticsoft.Model.SMT_STAFF_CARD> GetModelListWithCardNo(string strWhere)
        {
            DataSet ds = dal.GetListWithCardNo(strWhere);
            return DataTableToListWithCardNo(ds.Tables[0]);
        }
        public List<Maticsoft.Model.SMT_STAFF_CARD> DataTableToListWithCardNo(DataTable dt)
        {
            List<Maticsoft.Model.SMT_STAFF_CARD> modelList = new List<Maticsoft.Model.SMT_STAFF_CARD>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.SMT_STAFF_CARD model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        if (dt.Rows[n]["CARD_TYPE"] != null && dt.Rows[n]["CARD_TYPE"].ToString() != "")
                        {
                            model.CARD_TYPE = int.Parse(dt.Rows[n]["CARD_TYPE"].ToString());
                        }
                        if (dt.Rows[n]["CARD_NO"] != null)
                        {
                            model.CARD_NO = dt.Rows[n]["CARD_NO"].ToString();
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

