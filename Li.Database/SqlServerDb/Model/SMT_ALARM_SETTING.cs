/**  版本信息模板在安装目录下，可自行修改。
* SMT_ALARM_SETTING.cs
*
* 功 能： N/A
* 类 名： SMT_ALARM_SETTING
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/5 23:38:32   N/A    初版
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
	/// 报警信息配置
	/// </summary>
	[Serializable]
	public partial class SMT_ALARM_SETTING
	{
		public SMT_ALARM_SETTING()
		{}
		#region Model
		private decimal _id;
		private decimal _ctrl_id;
		private string _ctrl_force_pwd;
		private bool _enable_force_pwd;
		private int? _not_closed_timeout;
		private bool _enable_closed_timeout;
		private bool _enable_force_access;
		private bool _enable_force_close;
		private bool _enable_invalid_card;
		private bool _enable_fire;
		private bool _enable_steal;
		private bool _enable_force_card;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 控制器ID号
		/// </summary>
		public decimal CTRL_ID
		{
			set{ _ctrl_id=value;}
			get{return _ctrl_id;}
		}
		/// <summary>
		/// 胁迫密码
		/// </summary>
		public string CTRL_FORCE_PWD
		{
			set{ _ctrl_force_pwd=value;}
			get{return _ctrl_force_pwd;}
		}
		/// <summary>
		/// 是否启用胁迫密码
		/// </summary>
		public bool ENABLE_FORCE_PWD
		{
			set{ _enable_force_pwd=value;}
			get{return _enable_force_pwd;}
		}
		/// <summary>
		/// 门长时间未关超时时间
		/// </summary>
		public int? NOT_CLOSED_TIMEOUT
		{
			set{ _not_closed_timeout=value;}
			get{return _not_closed_timeout;}
		}
		/// <summary>
		/// 是否启用门长时间未关报警
		/// </summary>
		public bool ENABLE_CLOSED_TIMEOUT
		{
			set{ _enable_closed_timeout=value;}
			get{return _enable_closed_timeout;}
		}
		/// <summary>
		/// 是否启用强行闯入报警
		/// </summary>
		public bool ENABLE_FORCE_ACCESS
		{
			set{ _enable_force_access=value;}
			get{return _enable_force_access;}
		}
		/// <summary>
		/// 是否启用强制关门报警
		/// </summary>
		public bool ENABLE_FORCE_CLOSE
		{
			set{ _enable_force_close=value;}
			get{return _enable_force_close;}
		}
		/// <summary>
		/// 是否启用无效刷卡报警
		/// </summary>
		public bool ENABLE_INVALID_CARD
		{
			set{ _enable_invalid_card=value;}
			get{return _enable_invalid_card;}
		}
		/// <summary>
		/// 是否启用火警报警
		/// </summary>
		public bool ENABLE_FIRE
		{
			set{ _enable_fire=value;}
			get{return _enable_fire;}
		}
		/// <summary>
		/// 是否启用防盗报警
		/// </summary>
		public bool ENABLE_STEAL
		{
			set{ _enable_steal=value;}
			get{return _enable_steal;}
		}
		/// <summary>
		/// 是否启用胁迫必须刷合法卡
		/// </summary>
		public bool ENABLE_FORCE_CARD
		{
			set{ _enable_force_card=value;}
			get{return _enable_force_card;}
		}
		#endregion Model

	}
}

