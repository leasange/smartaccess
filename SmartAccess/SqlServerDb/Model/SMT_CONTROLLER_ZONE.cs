/**  版本信息模板在安装目录下，可自行修改。
* SMT_CONTROLLER_ZONE.cs
*
* 功 能： N/A
* 类 名： SMT_CONTROLLER_ZONE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/13 21:48:10   N/A    初版
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
	/// 控制器区域表[SMT_CONTROLLER_ZONE]
	/// </summary>
	[Serializable]
	public partial class SMT_CONTROLLER_ZONE
	{
		public SMT_CONTROLLER_ZONE()
		{}
		#region Model
		private decimal _id;
		private decimal? _par_id=0M;
		private string _zone_name;
		private string _zone_desc;
		private int? _order_value;
		/// <summary>
		/// 区域ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 父级区域ID  0 为跟级区域
		/// </summary>
		public decimal? PAR_ID
		{
			set{ _par_id=value;}
			get{return _par_id;}
		}
		/// <summary>
		/// 区域名称
		/// </summary>
		public string ZONE_NAME
		{
			set{ _zone_name=value;}
			get{return _zone_name;}
		}
		/// <summary>
		/// 区域描述
		/// </summary>
		public string ZONE_DESC
		{
			set{ _zone_desc=value;}
			get{return _zone_desc;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? ORDER_VALUE
		{
			set{ _order_value=value;}
			get{return _order_value;}
		}
		#endregion Model

	}
}

