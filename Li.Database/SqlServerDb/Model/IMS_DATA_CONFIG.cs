/**  版本信息模板在安装目录下，可自行修改。
* IMS_DATA_CONFIG.cs
*
* 功 能： N/A
* 类 名： IMS_DATA_CONFIG
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/16 23:12:00   N/A    初版
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
	/// IMS_DATA_CONFIG:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IMS_DATA_CONFIG
	{
		public IMS_DATA_CONFIG()
		{}
		#region Model
		private decimal _id;
		private string _datatype;
		private string _datakey;
		private string _datavalue;
		private string _datadesc;
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
		public string DataType
		{
			set{ _datatype=value;}
			get{return _datatype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DataKey
		{
			set{ _datakey=value;}
			get{return _datakey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DataValue
		{
			set{ _datavalue=value;}
			get{return _datavalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DataDesc
		{
			set{ _datadesc=value;}
			get{return _datadesc;}
		}
		#endregion Model

	}
}

