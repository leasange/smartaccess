/**  版本信息模板在安装目录下，可自行修改。
* SMT_ALARM_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_ALARM_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/17 22:15:24   N/A    初版
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
	/// 报警信息表
	/// </summary>
	[Serializable]
	public partial class SMT_ALARM_INFO
	{
		public SMT_ALARM_INFO()
		{}
		#region Model
		private decimal _id;
		private int _alarm_type;
		private string _alarm_name;
		private string _alarm_content;
		private DateTime _alarm_time;
		private decimal? _record_id;
		private string _card_no;
		private int? _ctrlr_door_index;
		private decimal? _ctrlr_id;
		private decimal? _door_id;
		private decimal? _staff_id;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 报警类型
		/// </summary>
		public int ALARM_TYPE
		{
			set{ _alarm_type=value;}
			get{return _alarm_type;}
		}
		/// <summary>
		/// 报警名称
		/// </summary>
		public string ALARM_NAME
		{
			set{ _alarm_name=value;}
			get{return _alarm_name;}
		}
		/// <summary>
		/// 报警内容
		/// </summary>
		public string ALARM_CONTENT
		{
			set{ _alarm_content=value;}
			get{return _alarm_content;}
		}
		/// <summary>
		/// 报警时间
		/// </summary>
		public DateTime ALARM_TIME
		{
			set{ _alarm_time=value;}
			get{return _alarm_time;}
		}
		/// <summary>
		/// 关联的记录ID
		/// </summary>
		public decimal? RECORD_ID
		{
			set{ _record_id=value;}
			get{return _record_id;}
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

