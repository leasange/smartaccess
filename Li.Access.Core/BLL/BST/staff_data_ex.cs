/**  版本信息模板在安装目录下，可自行修改。
* staff_data.cs
*
* 功 能： N/A
* 类 名： staff_data
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/8/22 22:46:32   N/A    初版
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
using Maticsoft.Model.BST;
namespace Maticsoft.BLL.BST
{
	/// <summary>
	/// staff_data
	/// </summary>
	public partial class staff_data
	{
		#region  ExtensionMethod
        public List<string> GetAllIds(string strWhere)
        {
            return dal.GetAllIds(strWhere);
        }
        public bool DeleteAll(string strWhere)
        {
            return dal.DeleteAll(strWhere);
        }
		#endregion  ExtensionMethod
	}
}

