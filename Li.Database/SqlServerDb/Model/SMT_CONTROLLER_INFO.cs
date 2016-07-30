/**  版本信息模板在安装目录下，可自行修改。
* SMT_CONTROLLER_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_CONTROLLER_INFO
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
	/// 控制器表
	/// </summary>
	[Serializable]
	public partial class SMT_CONTROLLER_INFO
	{
		public SMT_CONTROLLER_INFO()
		{}
		#region Model
		private decimal _id;
		private string _sn_no;
		private string _name;
		private string _ip;
		private int? _port;
		private string _mask;
		private string _gateway;
		private string _mac;
		private int? _ctrlr_type;
		private string _driver_version;
		private DateTime? _driver_date;
		private string _ctrlr_desc;
		private decimal? _area_id;
		private int? _order_value;
		private decimal? _org_id;
		private string _ctrlr_model;
		private bool _is_enable;
		/// <summary>
		/// 控制器ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 控制器序列号
		/// </summary>
		public string SN_NO
		{
			set{ _sn_no=value;}
			get{return _sn_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 控制器IP
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 控制器端口
		/// </summary>
		public int? PORT
		{
			set{ _port=value;}
			get{return _port;}
		}
		/// <summary>
		/// 子网掩码
		/// </summary>
		public string MASK
		{
			set{ _mask=value;}
			get{return _mask;}
		}
		/// <summary>
		/// 网关
		/// </summary>
		public string GATEWAY
		{
			set{ _gateway=value;}
			get{return _gateway;}
		}
		/// <summary>
		/// MAC地址
		/// </summary>
		public string MAC
		{
			set{ _mac=value;}
			get{return _mac;}
		}
		/// <summary>
		/// 控制器类型:OneDoorTwoDirections=0,//单门双向  ;  TwoDoorsTwoDirections=1,//双门双向
	///   ; FourDoorsOneDirection=2,//四门单向
		/// </summary>
		public int? CTRLR_TYPE
		{
			set{ _ctrlr_type=value;}
			get{return _ctrlr_type;}
		}
		/// <summary>
		/// 驱动版本
		/// </summary>
		public string DRIVER_VERSION
		{
			set{ _driver_version=value;}
			get{return _driver_version;}
		}
		/// <summary>
		/// 驱动发行日期
		/// </summary>
		public DateTime? DRIVER_DATE
		{
			set{ _driver_date=value;}
			get{return _driver_date;}
		}
		/// <summary>
		/// 控制器描述
		/// </summary>
		public string CTRLR_DESC
		{
			set{ _ctrlr_desc=value;}
			get{return _ctrlr_desc;}
		}
		/// <summary>
		/// 所属区域ID
		/// </summary>
		public decimal? AREA_ID
		{
			set{ _area_id=value;}
			get{return _area_id;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? ORDER_VALUE
		{
			set{ _order_value=value;}
			get{return _order_value;}
		}
		/// <summary>
		/// 所属部门ID
		/// </summary>
		public decimal? ORG_ID
		{
			set{ _org_id=value;}
			get{return _org_id;}
		}
		/// <summary>
		/// 控制器型号类型："WGACCESS"  WG门禁控制器；
		/// </summary>
		public string CTRLR_MODEL
		{
			set{ _ctrlr_model=value;}
			get{return _ctrlr_model;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IS_ENABLE
		{
			set{ _is_enable=value;}
			get{return _is_enable;}
		}
		#endregion Model

	}
}

