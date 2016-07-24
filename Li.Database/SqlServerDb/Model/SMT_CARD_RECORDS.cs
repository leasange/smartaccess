/**  版本信息模板在安装目录下，可自行修改。
* SMT_CARD_RECORDS.cs
*
* 功 能： N/A
* 类 名： SMT_CARD_RECORDS
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/23 16:40:08   N/A    初版
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
	/// 刷卡记录表
	/// </summary>
	[Serializable]
	public partial class SMT_CARD_RECORDS
	{
		public SMT_CARD_RECORDS()
		{}
		#region Model
		private decimal _id;
		private string _ctrlr_sn;
		private decimal? _record_index;
		private string _record_type;
		private string _record_reason;
		private string _record_desc;
		private DateTime? _record_date;
		private string _card_no;
		private bool _is_enter;
		private bool _is_allow;
		private int? _ctrlr_door_index;
		private decimal? _ctrlr_id;
		private decimal? _door_id;
		private decimal? _staff_id;
		/// <summary>
		/// 记录的编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 控制器序列号
		/// </summary>
		public string CTRLR_SN
		{
			set{ _ctrlr_sn=value;}
			get{return _ctrlr_sn;}
		}
		/// <summary>
		/// 记录的索引号
		/// </summary>
		public decimal? RECORD_INDEX
		{
			set{ _record_index=value;}
			get{return _record_index;}
		}
		/// <summary>
		/// 记录类型
		/// </summary>
		public string RECORD_TYPE
		{
			set{ _record_type=value;}
			get{return _record_type;}
		}
		/// <summary>
		/// 详细记录原因
		/// </summary>
		public string RECORD_REASON
		{
			set{ _record_reason=value;}
			get{return _record_reason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RECORD_DESC
		{
			set{ _record_desc=value;}
			get{return _record_desc;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public DateTime? RECORD_DATE
		{
			set{ _record_date=value;}
			get{return _record_date;}
		}
		/// <summary>
		/// 记录的卡号
		/// </summary>
		public string CARD_NO
		{
			set{ _card_no=value;}
			get{return _card_no;}
		}
		/// <summary>
		/// 是否是进门
		/// </summary>
		public bool IS_ENTER
		{
			set{ _is_enter=value;}
			get{return _is_enter;}
		}
		/// <summary>
		/// 是否通过
		/// </summary>
		public bool IS_ALLOW
		{
			set{ _is_allow=value;}
			get{return _is_allow;}
		}
		/// <summary>
		/// 于控制器的上门序列号
		/// </summary>
		public int? CTRLR_DOOR_INDEX
		{
			set{ _ctrlr_door_index=value;}
			get{return _ctrlr_door_index;}
		}
		/// <summary>
		/// 关联的控制器ID
		/// </summary>
		public decimal? CTRLR_ID
		{
			set{ _ctrlr_id=value;}
			get{return _ctrlr_id;}
		}
		/// <summary>
		/// 关联的门ID
		/// </summary>
		public decimal? DOOR_ID
		{
			set{ _door_id=value;}
			get{return _door_id;}
		}
		/// <summary>
		/// 关联的职员ID
		/// </summary>
		public decimal? STAFF_ID
		{
			set{ _staff_id=value;}
			get{return _staff_id;}
		}
		#endregion Model

	}
}

