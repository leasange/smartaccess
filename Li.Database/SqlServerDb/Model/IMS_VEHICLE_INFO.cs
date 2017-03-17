/**  版本信息模板在安装目录下，可自行修改。
* IMS_VEHICLE_INFO.cs
*
* 功 能： N/A
* 类 名： IMS_VEHICLE_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/16 23:12:01   N/A    初版
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
	/// IMS_VEHICLE_INFO:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IMS_VEHICLE_INFO
	{
		public IMS_VEHICLE_INFO()
		{}
		#region Model
		private decimal _id;
		private string _plateno;
		private string _name;
		private string _depart;
		private int? _isgrant;
		private string _grantaccess;
		private DateTime? _modifytime;
		/// <summary>
		/// 
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlateNo
		{
			set{ _plateno=value;}
			get{return _plateno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Depart
		{
			set{ _depart=value;}
			get{return _depart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsGrant
		{
			set{ _isgrant=value;}
			get{return _isgrant;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GrantAccess
		{
			set{ _grantaccess=value;}
			get{return _grantaccess;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		#endregion Model

	}
}

