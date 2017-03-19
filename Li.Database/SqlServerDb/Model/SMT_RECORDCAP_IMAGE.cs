/**  版本信息模板在安装目录下，可自行修改。
* SMT_RECORDCAP_IMAGE.cs
*
* 功 能： N/A
* 类 名： SMT_RECORDCAP_IMAGE
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/19 21:03:01   N/A    初版
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
	/// 刷卡抓拍记录表
	/// </summary>
	[Serializable]
	public partial class SMT_RECORDCAP_IMAGE
	{
		public SMT_RECORDCAP_IMAGE()
		{}
		#region Model
		private decimal _id;
		private string _ctrl_sn;
		private decimal _record_index;
		private DateTime _record_time;
		private DateTime _cap_time;
		private string _cap_relative_url;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 控制器序列号
		/// </summary>
		public string CTRL_SN
		{
			set{ _ctrl_sn=value;}
			get{return _ctrl_sn;}
		}
		/// <summary>
		/// 记录索引号
		/// </summary>
		public decimal RECORD_INDEX
		{
			set{ _record_index=value;}
			get{return _record_index;}
		}
		/// <summary>
		/// 记录时间
		/// </summary>
		public DateTime RECORD_TIME
		{
			set{ _record_time=value;}
			get{return _record_time;}
		}
		/// <summary>
		/// 抓拍时间
		/// </summary>
		public DateTime CAP_TIME
		{
			set{ _cap_time=value;}
			get{return _cap_time;}
		}
		/// <summary>
		/// 抓拍相对图片路径（名称）
		/// </summary>
		public string CAP_RELATIVE_URL
		{
			set{ _cap_relative_url=value;}
			get{return _cap_relative_url;}
		}
		#endregion Model

	}
}

