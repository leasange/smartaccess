/**  版本信息模板在安装目录下，可自行修改。
* SMT_LOG_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_LOG_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/10/8 22:36:31   N/A    初版
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
	/// 操作日志表
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
		private decimal _opr_userid;
		private string _opr_realname;
		private DateTime _opr_time;
		private string _opr_content;
		/// <summary>
		/// 日志ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 日志类型：用户自定义，如：用户管理日志，服务器日志，角色管理日志等
		/// </summary>
		public string LOG_TYPE
		{
			set{ _log_type=value;}
			get{return _log_type;}
		}
		/// <summary>
		/// 日志级别，0 ERROR 异常错误日志，1 WARN警告日志，2 INFO消息记录日志
		/// </summary>
		public int LOG_LEVEL
		{
			set{ _log_level=value;}
			get{return _log_level;}
		}
		/// <summary>
		/// 操作人ID
		/// </summary>
		public decimal OPR_USERID
		{
			set{ _opr_userid=value;}
			get{return _opr_userid;}
		}
		/// <summary>
		/// 操作人姓名
		/// </summary>
		public string OPR_REALNAME
		{
			set{ _opr_realname=value;}
			get{return _opr_realname;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime OPR_TIME
		{
			set{ _opr_time=value;}
			get{return _opr_time;}
		}
		/// <summary>
		/// 操作内容
		/// </summary>
		public string OPR_CONTENT
		{
			set{ _opr_content=value;}
			get{return _opr_content;}
		}
		#endregion Model

	}
}

