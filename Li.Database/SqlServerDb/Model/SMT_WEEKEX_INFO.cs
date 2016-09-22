/**  版本信息模板在安装目录下，可自行修改。
* SMT_WEEKEX_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_WEEKEX_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/21 23:48:11   N/A    初版
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
	/// 假期约束
	/// </summary>
	[Serializable]
	public partial class SMT_WEEKEX_INFO
	{
		public SMT_WEEKEX_INFO()
		{}
		#region Model
		private decimal _id;
		private string _weekex_desc;
		private bool _weekex_on_duty;
		private DateTime _weekex_start_date;
		private DateTime _weekex_end_date;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string WEEKEX_DESC
		{
			set{ _weekex_desc=value;}
			get{return _weekex_desc;}
		}
		/// <summary>
		/// 是否上班
		/// </summary>
		public bool WEEKEX_ON_DUTY
		{
			set{ _weekex_on_duty=value;}
			get{return _weekex_on_duty;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime WEEKEX_START_DATE
		{
			set{ _weekex_start_date=value;}
			get{return _weekex_start_date;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime WEEKEX_END_DATE
		{
			set{ _weekex_end_date=value;}
			get{return _weekex_end_date;}
		}
		#endregion Model

	}
}

