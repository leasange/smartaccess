/**  版本信息模板在安装目录下，可自行修改。
* SMT_MAP_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_MAP_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/11 12:06:47   N/A    初版
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
	/// 电子地图
	/// </summary>
	public partial class SMT_MAP_INFO
	{
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.SMT_MAP_INFO> GetModelListWithDoors(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            var list = DataTableToList(ds.Tables[0]);
            if (list.Count>0)
            {
                string mapIds = "";
                foreach (var item in list)
                {
                    mapIds += item.ID + ",";
                }
                mapIds = mapIds.TrimEnd(',');
                SMT_MAP_DOOR bllMd = new SMT_MAP_DOOR();
                var doors = bllMd.GetModelListWithDoor("MAP_ID in (" + mapIds + ")");
                foreach (var item in list)
                {
                    item.MAP_DOORS = doors.FindAll(m => m.MAP_ID == item.ID);
                } 
            }
            return list;
        }
	}
}

