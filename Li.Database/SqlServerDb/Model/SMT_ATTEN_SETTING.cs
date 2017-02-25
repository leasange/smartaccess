/**  版本信息模板在安装目录下，可自行修改。
* SMT_ATTEN_SETTING.cs
*
* 功 能： N/A
* 类 名： SMT_ATTEN_SETTING
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
	/// 考勤班次设置
	/// </summary>
	[Serializable]
	public partial class SMT_ATTEN_SETTING
	{
		public SMT_ATTEN_SETTING()
		{}
		#region Model
		private decimal _id;
		private int _duty_type;
		private int _duty_late_min;
		private int _duty_late_max;
		private decimal _duty_late_punish;
		private int _duty_leave_min;
		private int _duty_leave_max;
		private decimal _duty_leave_punish;
		private int _duty_extra_min;
		private int _duty_swing_times;
		private DateTime _duty_on_time1;
		private DateTime _duty_off_time1;
		private DateTime _duty_on_time2;
		private DateTime _duty_off_time2;
		private bool _duty_only_on;
		private DateTime _duty_on_earliest;
		private decimal _duty_work_length;
		private bool _duty_full_time;
		private int _duty_sat_type;
		private int _duty_sun_type;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 考勤班次类型，0,正常班
		/// </summary>
		public int DUTY_TYPE
		{
			set{ _duty_type=value;}
			get{return _duty_type;}
		}
		/// <summary>
		/// 迟到最小范围，分
		/// </summary>
		public int DUTY_LATE_MIN
		{
			set{ _duty_late_min=value;}
			get{return _duty_late_min;}
		}
		/// <summary>
		/// 迟到最大范围，分
		/// </summary>
		public int DUTY_LATE_MAX
		{
			set{ _duty_late_max=value;}
			get{return _duty_late_max;}
		}
		/// <summary>
		/// 迟到最大处罚天数，天
		/// </summary>
		public decimal DUTY_LATE_PUNISH
		{
			set{ _duty_late_punish=value;}
			get{return _duty_late_punish;}
		}
		/// <summary>
		/// 早退最小范围，分
		/// </summary>
		public int DUTY_LEAVE_MIN
		{
			set{ _duty_leave_min=value;}
			get{return _duty_leave_min;}
		}
		/// <summary>
		/// 早退最大范围，分
		/// </summary>
		public int DUTY_LEAVE_MAX
		{
			set{ _duty_leave_max=value;}
			get{return _duty_leave_max;}
		}
		/// <summary>
		/// 早退最大处罚天数，天
		/// </summary>
		public decimal DUTY_LEAVE_PUNISH
		{
			set{ _duty_leave_punish=value;}
			get{return _duty_leave_punish;}
		}
		/// <summary>
		/// 加班范围，分
		/// </summary>
		public int DUTY_EXTRA_MIN
		{
			set{ _duty_extra_min=value;}
			get{return _duty_extra_min;}
		}
		/// <summary>
		/// 每天刷卡次数，次
		/// </summary>
		public int DUTY_SWING_TIMES
		{
			set{ _duty_swing_times=value;}
			get{return _duty_swing_times;}
		}
		/// <summary>
		/// 上班时间1，time
		/// </summary>
		public DateTime DUTY_ON_TIME1
		{
			set{ _duty_on_time1=value;}
			get{return _duty_on_time1;}
		}
		/// <summary>
		/// 下班时间1
		/// </summary>
		public DateTime DUTY_OFF_TIME1
		{
			set{ _duty_off_time1=value;}
			get{return _duty_off_time1;}
		}
		/// <summary>
		/// 上班时间2
		/// </summary>
		public DateTime DUTY_ON_TIME2
		{
			set{ _duty_on_time2=value;}
			get{return _duty_on_time2;}
		}
		/// <summary>
		/// 下班时间2
		/// </summary>
		public DateTime DUTY_OFF_TIME2
		{
			set{ _duty_off_time2=value;}
			get{return _duty_off_time2;}
		}
		/// <summary>
		/// 只统计上班刷卡，bool
		/// </summary>
		public bool DUTY_ONLY_ON
		{
			set{ _duty_only_on=value;}
			get{return _duty_only_on;}
		}
		/// <summary>
		/// 上班最早刷卡时间，time
		/// </summary>
		public DateTime DUTY_ON_EARLIEST
		{
			set{ _duty_on_earliest=value;}
			get{return _duty_on_earliest;}
		}
		/// <summary>
		/// 每天工作时间(h)，时
		/// </summary>
		public decimal DUTY_WORK_LENGTH
		{
			set{ _duty_work_length=value;}
			get{return _duty_work_length;}
		}
		/// <summary>
		/// 满足工作时间不受约束，bool
		/// </summary>
		public bool DUTY_FULL_TIME
		{
			set{ _duty_full_time=value;}
			get{return _duty_full_time;}
		}
		/// <summary>
		/// 周六上班方式，0，不上班，1全天上班，2上午上班，下午休息
		/// </summary>
		public int DUTY_SAT_TYPE
		{
			set{ _duty_sat_type=value;}
			get{return _duty_sat_type;}
		}
		/// <summary>
		/// 周日上班方式，0，不上班，1 全天上班，2 上午上班，下午休息
		/// </summary>
		public int DUTY_SUN_TYPE
		{
			set{ _duty_sun_type=value;}
			get{return _duty_sun_type;}
		}
		#endregion Model

	}
}

