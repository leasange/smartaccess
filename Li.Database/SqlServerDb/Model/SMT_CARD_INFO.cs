/**  版本信息模板在安装目录下，可自行修改。
* SMT_CAR_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_CAR_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/24 23:49:17   N/A    初版
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
	[Serializable]
	public partial class SMT_CAR_INFO
	{
        public SMT_CAR_INFO()
		{}
		#region Model
		private decimal _id;
		private string _card_no;
		private string _card_desc;
		private int? _card_type;
		/// <summary>
		/// 卡ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 卡序列号
		/// </summary>
		public string CARD_NO
		{
			set{ _card_no=value;}
			get{return _card_no;}
		}
		/// <summary>
		/// 卡描述
		/// </summary>
		public string CARD_DESC
		{
			set{ _card_desc=value;}
			get{return _card_desc;}
		}
		/// <summary>
		/// 卡类型,根据不同类型待定
		/// </summary>
		public int? CARD_TYPE
		{
			set{ _card_type=value;}
			get{return _card_type;}
		}
		#endregion Model

	}
}

