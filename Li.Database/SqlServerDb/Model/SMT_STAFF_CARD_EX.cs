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
namespace Maticsoft.Model
{
	/// <summary>
	/// 员工卡关联表
	/// </summary>
	public partial class SMT_STAFF_CARD
	{
        private string _card_no = "";//卡号
        public string CARD_NO
        {
            get { return _card_no; }
            set { _card_no = value; }
        }
	}
}

