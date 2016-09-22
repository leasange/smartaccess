/**  版本信息模板在安装目录下，可自行修改。
* SMT_LOG_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_LOG_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/22 0:25:36   N/A    初版
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
	/// 日志记录表
	/// </summary>
	[Serializable]
	public partial class SMT_LOG_INFO
	{
		public SMT_LOG_INFO()
		{}
		#region Model
		private decimal _id;
		private string _log_type;
		private int _log_level;
		private string _log_content;
		private DateTime _log_time;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 日志类别
		/// </summary>
		public string LOG_TYPE
		{
			set{ _log_type=value;}
			get{return _log_type;}
		}
		/// <summary>
		/// 日志级别
		/// </summary>
		public int LOG_LEVEL
		{
			set{ _log_level=value;}
			get{return _log_level;}
		}
		/// <summary>
		/// 日志内容
		/// </summary>
		public string LOG_CONTENT
		{
			set{ _log_content=value;}
			get{return _log_content;}
		}
		/// <summary>
		/// 日志时间
		/// </summary>
		public DateTime LOG_TIME
		{
			set{ _log_time=value;}
			get{return _log_time;}
		}
		#endregion Model

	}
}

