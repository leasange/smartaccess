/**  版本信息模板在安装目录下，可自行修改。
* SMT_TIMESCALE_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_TIMESCALE_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/21 23:00:50   N/A    初版
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
	/// 时段信息表
	/// </summary>
	[Serializable]
	public partial class SMT_TIMESCALE_INFO
	{
		public SMT_TIMESCALE_INFO()
		{}
		#region Model
		private decimal _id;
		private int _time_no;
		private string _time_name;
		private bool _time_week_day1;
		private bool _time_week_day2;
		private bool _time_week_day3;
		private bool _time_week_day4;
		private bool _time_week_day5;
		private bool _time_week_day6;
		private bool _time_week_day7;
		private DateTime _time_date_start;
		private DateTime _time_date_end;
        private TimeSpan _time_range_start1;
        private TimeSpan _time_range_end1;
        private TimeSpan _time_range_start2;
        private TimeSpan _time_range_end2;
        private TimeSpan _time_range_start3;
        private TimeSpan _time_range_end3;
		private int _time_next_no;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 时段号
		/// </summary>
		public int TIME_NO
		{
			set{ _time_no=value;}
			get{return _time_no;}
		}
		/// <summary>
		/// 时段名称
		/// </summary>
		public string TIME_NAME
		{
			set{ _time_name=value;}
			get{return _time_name;}
		}
		/// <summary>
		/// 星期一
		/// </summary>
		public bool TIME_WEEK_DAY1
		{
			set{ _time_week_day1=value;}
			get{return _time_week_day1;}
		}
		/// <summary>
		/// 星期二
		/// </summary>
		public bool TIME_WEEK_DAY2
		{
			set{ _time_week_day2=value;}
			get{return _time_week_day2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool TIME_WEEK_DAY3
		{
			set{ _time_week_day3=value;}
			get{return _time_week_day3;}
		}
		/// <summary>
		/// 星期四
		/// </summary>
		public bool TIME_WEEK_DAY4
		{
			set{ _time_week_day4=value;}
			get{return _time_week_day4;}
		}
		/// <summary>
		/// 星期五
		/// </summary>
		public bool TIME_WEEK_DAY5
		{
			set{ _time_week_day5=value;}
			get{return _time_week_day5;}
		}
		/// <summary>
		/// 星期六
		/// </summary>
		public bool TIME_WEEK_DAY6
		{
			set{ _time_week_day6=value;}
			get{return _time_week_day6;}
		}
		/// <summary>
		/// 星期日
		/// </summary>
		public bool TIME_WEEK_DAY7
		{
			set{ _time_week_day7=value;}
			get{return _time_week_day7;}
		}
		/// <summary>
		/// 开始日期
		/// </summary>
		public DateTime TIME_DATE_START
		{
			set{ _time_date_start=value;}
			get{return _time_date_start;}
		}
		/// <summary>
		/// 结束日期
		/// </summary>
		public DateTime TIME_DATE_END
		{
			set{ _time_date_end=value;}
			get{return _time_date_end;}
		}
		/// <summary>
		/// 时区开始1
		/// </summary>
		public TimeSpan TIME_RANGE_START1
		{
			set{ _time_range_start1=value;}
			get{return _time_range_start1;}
		}
		/// <summary>
		/// 时区结束1
		/// </summary>
        public TimeSpan TIME_RANGE_END1
		{
			set{ _time_range_end1=value;}
			get{return _time_range_end1;}
		}
		/// <summary>
		/// 时区开始2
		/// </summary>
        public TimeSpan TIME_RANGE_START2
		{
			set{ _time_range_start2=value;}
			get{return _time_range_start2;}
		}
		/// <summary>
		/// 时区结束2
		/// </summary>
        public TimeSpan TIME_RANGE_END2
		{
			set{ _time_range_end2=value;}
			get{return _time_range_end2;}
		}
		/// <summary>
		/// 时区开始3
		/// </summary>
        public TimeSpan TIME_RANGE_START3
		{
			set{ _time_range_start3=value;}
			get{return _time_range_start3;}
		}
		/// <summary>
		/// 时区结束3
		/// </summary>
        public TimeSpan TIME_RANGE_END3
		{
			set{ _time_range_end3=value;}
			get{return _time_range_end3;}
		}
		/// <summary>
		/// 下一时段号
		/// </summary>
		public int TIME_NEXT_NO
		{
			set{ _time_next_no=value;}
			get{return _time_next_no;}
		}
		#endregion Model

	}
}

