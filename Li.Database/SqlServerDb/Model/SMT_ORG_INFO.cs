/**  版本信息模板在安装目录下，可自行修改。
* SMT_ORG_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_ORG_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/13 20:12:29   N/A    初版
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
	/// 组织机构部门表
	/// </summary>
	[Serializable]
	public partial class SMT_ORG_INFO
	{
		public SMT_ORG_INFO()
		{}
		#region Model
		private decimal _id;
		private decimal _par_id=1M;
		private string _org_code;
		private string _org_name;
		private int? _order_value;
		/// <summary>
		/// 组织机构ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 上级组织机构ID
		/// </summary>
		public decimal PAR_ID
		{
			set{ _par_id=value;}
			get{return _par_id;}
		}
		/// <summary>
		/// 部门编码
		/// </summary>
		public string ORG_CODE
		{
			set{ _org_code=value;}
			get{return _org_code;}
		}
		/// <summary>
		/// 组织机构名称
		/// </summary>
		public string ORG_NAME
		{
			set{ _org_name=value;}
			get{return _org_name;}
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

