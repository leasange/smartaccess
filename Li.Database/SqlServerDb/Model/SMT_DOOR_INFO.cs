/**  版本信息模板在安装目录下，可自行修改。
* SMT_DOOR_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_DOOR_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/23 15:31:37   N/A    初版
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
	/// 门表
	/// </summary>
	[Serializable]
	public partial class SMT_DOOR_INFO
	{
		public SMT_DOOR_INFO()
		{}
		#region Model
		private decimal _id;
		private string _door_name;
		private decimal? _ctrl_id;
		private int? _ctrl_door_index;
		private string _door_desc;
		private int? _ctrl_style;
		private int? _ctrl_delay_time;
		/// <summary>
		/// 门ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 门名称
		/// </summary>
		public string DOOR_NAME
		{
			set{ _door_name=value;}
			get{return _door_name;}
		}
		/// <summary>
		/// 关联控制器ID
		/// </summary>
		public decimal? CTRL_ID
		{
			set{ _ctrl_id=value;}
			get{return _ctrl_id;}
		}
		/// <summary>
		/// 关联控制器门序号
		/// </summary>
		public int? CTRL_DOOR_INDEX
		{
			set{ _ctrl_door_index=value;}
			get{return _ctrl_door_index;}
		}
		/// <summary>
		/// 门描述
		/// </summary>
		public string DOOR_DESC
		{
			set{ _door_desc=value;}
			get{return _door_desc;}
		}
		/// <summary>
		/// 控制方式,0 在线，1 常开，2 常闭
		/// </summary>
		public int? CTRL_STYLE
		{
			set{ _ctrl_style=value;}
			get{return _ctrl_style;}
		}
		/// <summary>
		/// 开门延时(秒)，不低于1s 默认3s
		/// </summary>
		public int? CTRL_DELAY_TIME
		{
			set{ _ctrl_delay_time=value;}
			get{return _ctrl_delay_time;}
		}
		#endregion Model

	}
}

