/**  版本信息模板在安装目录下，可自行修改。
* SMT_ATTEN_REPORT.cs
*
* 功 能： N/A
* 类 名： SMT_ATTEN_REPORT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/25 21:10:34   N/A    初版
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
	/// 考勤信息报表
	/// </summary>
	[Serializable]
	public partial class SMT_ATTEN_REPORT
	{
		public SMT_ATTEN_REPORT()
		{}
		#region Model
		private decimal _id;
		private decimal _staff_id;
		private DateTime _atten_date;
        private TimeSpan? _atten_on_time;
        private TimeSpan? _atten_off_time;
		private string _atten_on_state;
		private string _atten_off_state;
		private int? _atten_late_min;
		private int? _atten_leave_min;
		private int? _atten_extra_min;
		private decimal? _atten_away_day;
		private int? _atten_unswipe_times;
		private int? _atten_swipe_times;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 员工ID
		/// </summary>
		public decimal STAFF_ID
		{
			set{ _staff_id=value;}
			get{return _staff_id;}
		}
		/// <summary>
		/// 考勤日期
		/// </summary>
		public DateTime ATTEN_DATE
		{
			set{ _atten_date=value;}
			get{return _atten_date;}
		}
		/// <summary>
		/// 上班时间
		/// </summary>
        public TimeSpan? ATTEN_ON_TIME
		{
			set{ _atten_on_time=value;}
			get{return _atten_on_time;}
		}
		/// <summary>
		/// 下班时间
		/// </summary>
        public TimeSpan? ATTEN_OFF_TIME
		{
			set{ _atten_off_time=value;}
			get{return _atten_off_time;}
		}
		/// <summary>
		/// 上班描述
		/// </summary>
		public string ATTEN_ON_STATE
		{
			set{ _atten_on_state=value;}
			get{return _atten_on_state;}
		}
		/// <summary>
		/// 下班描述
		/// </summary>
		public string ATTEN_OFF_STATE
		{
			set{ _atten_off_state=value;}
			get{return _atten_off_state;}
		}
		/// <summary>
		/// 迟到时间，分
		/// </summary>
		public int? ATTEN_LATE_MIN
		{
			set{ _atten_late_min=value;}
			get{return _atten_late_min;}
		}
		/// <summary>
		/// 早退时间，分
		/// </summary>
		public int? ATTEN_LEAVE_MIN
		{
			set{ _atten_leave_min=value;}
			get{return _atten_leave_min;}
		}
		/// <summary>
		/// 加班时间，分
		/// </summary>
		public int? ATTEN_EXTRA_MIN
		{
			set{ _atten_extra_min=value;}
			get{return _atten_extra_min;}
		}
		/// <summary>
		/// 旷工天数，天
		/// </summary>
		public decimal? ATTEN_AWAY_DAY
		{
			set{ _atten_away_day=value;}
			get{return _atten_away_day;}
		}
		/// <summary>
		/// 未刷卡次数
		/// </summary>
		public int? ATTEN_UNSWIPE_TIMES
		{
			set{ _atten_unswipe_times=value;}
			get{return _atten_unswipe_times;}
		}
		/// <summary>
		/// 应刷次数
		/// </summary>
		public int? ATTEN_SWIPE_TIMES
		{
			set{ _atten_swipe_times=value;}
			get{return _atten_swipe_times;}
		}
		#endregion Model

	}
}

