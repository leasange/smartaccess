/**  版本信息模板在安装目录下，可自行修改。
* SMT_CARD_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_CARD_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/2 22:00:31   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 卡表
	/// </summary>
	public partial class SMT_CARD_INFO
	{
        private decimal _staff_id;
        public decimal STAFF_ID//职员ID
        {
            get { return _staff_id; }
            set { _staff_id = value; }
        }
	}
}

