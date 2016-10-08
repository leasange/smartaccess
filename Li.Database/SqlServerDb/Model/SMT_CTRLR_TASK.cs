/**  版本信息模板在安装目录下，可自行修改。
* SMT_CTRLR_TASK.cs
*
* 功 能： N/A
* 类 名： SMT_CTRLR_TASK
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/10/7 22:17:03   N/A    初版
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
	/// 控制定时任务表
	/// </summary>
	[Serializable]
	public partial class SMT_CTRLR_TASK
	{
		public SMT_CTRLR_TASK()
		{}
		#region Model
		private decimal _id;
		private string _task_no;
		private string _task_name;
		private DateTime _valid_startdate;
		private DateTime _valid_enddate;
        private TimeSpan _action_time;
		private bool _mon_state;
		private bool _tue_state;
		private bool _thi_state;
		private bool _wes_state;
		private bool _fri_state;
		private bool _sat_state;
		private bool _sun_state;
		private string _door_id;
		private int _ctrl_style;
		private string _task_desc;
		/// <summary>
		/// 任务ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 任务编号
		/// </summary>
		public string TASK_NO
		{
			set{ _task_no=value;}
			get{return _task_no;}
		}
		/// <summary>
		/// 任务名称
		/// </summary>
		public string TASK_NAME
		{
			set{ _task_name=value;}
			get{return _task_name;}
		}
		/// <summary>
		/// 有效期开始时间
		/// </summary>
		public DateTime VALID_STARTDATE
		{
			set{ _valid_startdate=value;}
			get{return _valid_startdate;}
		}
		/// <summary>
		/// 有效期结束时间
		/// </summary>
		public DateTime VALID_ENDDATE
		{
			set{ _valid_enddate=value;}
			get{return _valid_enddate;}
		}
		/// <summary>
		/// 触发时间
		/// </summary>
		public TimeSpan ACTION_TIME
		{
			set{ _action_time=value;}
			get{return _action_time;}
		}
		/// <summary>
		/// 星期一状态
		/// </summary>
		public bool MON_STATE
		{
			set{ _mon_state=value;}
			get{return _mon_state;}
		}
		/// <summary>
		/// 星期二状态
		/// </summary>
		public bool TUE_STATE
		{
			set{ _tue_state=value;}
			get{return _tue_state;}
		}
		/// <summary>
		/// 星期三状态
		/// </summary>
		public bool THI_STATE
		{
			set{ _thi_state=value;}
			get{return _thi_state;}
		}
		/// <summary>
		/// 星期四状态
		/// </summary>
		public bool WES_STATE
		{
			set{ _wes_state=value;}
			get{return _wes_state;}
		}
		/// <summary>
		/// 星期五状态
		/// </summary>
		public bool FRI_STATE
		{
			set{ _fri_state=value;}
			get{return _fri_state;}
		}
		/// <summary>
		/// 星期六状态
		/// </summary>
		public bool SAT_STATE
		{
			set{ _sat_state=value;}
			get{return _sat_state;}
		}
		/// <summary>
		/// 星期日状态
		/// </summary>
		public bool SUN_STATE
		{
			set{ _sun_state=value;}
			get{return _sun_state;}
		}
		/// <summary>
		/// 门ID列表，逗号隔开：-1 表示所有门
		/// </summary>
		public string DOOR_ID
		{
			set{ _door_id=value;}
			get{return _door_id;}
		}
		/// <summary>
		/// 控制方式
		/// </summary>
		public int CTRL_STYLE
		{
			set{ _ctrl_style=value;}
			get{return _ctrl_style;}
		}
        
		/// <summary>
		/// 备注
		/// </summary>
		public string TASK_DESC
		{
			set{ _task_desc=value;}
			get{return _task_desc;}
		}
		#endregion Model

	}
}

