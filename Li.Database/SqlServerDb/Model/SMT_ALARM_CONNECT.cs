/**  版本信息模板在安装目录下，可自行修改。
* SMT_ALARM_CONNECT.cs
*
* 功 能： N/A
* 类 名： SMT_ALARM_CONNECT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/5 23:38:31   N/A    初版
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
	/// 报警联动输出配置
	/// </summary>
	[Serializable]
	public partial class SMT_ALARM_CONNECT
	{
		public SMT_ALARM_CONNECT()
		{}
		#region Model
		private decimal _id;
		private decimal _ctrl_id;
		private int _out_port;
		private int _door_id;
		private bool _enb_force_pwd_event;
		private bool _enb_unclosed_event;
		private bool _enb_force_access_event;
		private bool _enb_force_close_event;
		private bool _enb_invalid_card_event;
		private bool _enb_fire_event;
		private bool _enb_relay_event;
		private int _enb_connect_item;
		private int _enb_fixed_time;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 控制器ID
		/// </summary>
		public decimal CTRL_ID
		{
			set{ _ctrl_id=value;}
			get{return _ctrl_id;}
		}
		/// <summary>
		/// 输出端口
		/// </summary>
		public int OUT_PORT
		{
			set{ _out_port=value;}
			get{return _out_port;}
		}
		/// <summary>
		/// 触发源（门禁ID）
		/// </summary>
		public int DOOR_ID
		{
			set{ _door_id=value;}
			get{return _door_id;}
		}
		/// <summary>
		/// 是否触发胁迫报警
		/// </summary>
		public bool ENB_FORCE_PWD_EVENT
		{
			set{ _enb_force_pwd_event=value;}
			get{return _enb_force_pwd_event;}
		}
		/// <summary>
		/// 是否触发门长时间未关报警
		/// </summary>
		public bool ENB_UNCLOSED_EVENT
		{
			set{ _enb_unclosed_event=value;}
			get{return _enb_unclosed_event;}
		}
		/// <summary>
		/// 是否触发强行闯入
		/// </summary>
		public bool ENB_FORCE_ACCESS_EVENT
		{
			set{ _enb_force_access_event=value;}
			get{return _enb_force_access_event;}
		}
		/// <summary>
		/// 是否触发强制锁门
		/// </summary>
		public bool ENB_FORCE_CLOSE_EVENT
		{
			set{ _enb_force_close_event=value;}
			get{return _enb_force_close_event;}
		}
		/// <summary>
		/// 是否触发无效刷卡
		/// </summary>
		public bool ENB_INVALID_CARD_EVENT
		{
			set{ _enb_invalid_card_event=value;}
			get{return _enb_invalid_card_event;}
		}
		/// <summary>
		/// 是否触发火警
		/// </summary>
		public bool ENB_FIRE_EVENT
		{
			set{ _enb_fire_event=value;}
			get{return _enb_fire_event;}
		}
		/// <summary>
		/// 是否触发门继电器动作
		/// </summary>
		public bool ENB_RELAY_EVENT
		{
			set{ _enb_relay_event=value;}
			get{return _enb_relay_event;}
		}
		/// <summary>
		/// 联动选项
		/// </summary>
		public int ENB_CONNECT_ITEM
		{
			set{ _enb_connect_item=value;}
			get{return _enb_connect_item;}
		}
		/// <summary>
		/// 固定延时时长(秒)
		/// </summary>
		public int ENB_FIXED_TIME
		{
			set{ _enb_fixed_time=value;}
			get{return _enb_fixed_time;}
		}
		#endregion Model

	}
}

