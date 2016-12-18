/**  版本信息模板在安装目录下，可自行修改。
* SMT_DATADICTIONARY_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_DATADICTIONARY_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/12/17 22:43:32   N/A    初版
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
	/// 数据字典管理
	/// </summary>
	[Serializable]
	public partial class SMT_DATADICTIONARY_INFO
	{
		public SMT_DATADICTIONARY_INFO()
		{}
		#region Model
		private string _data_type;
		private string _data_key;
		private string _data_value;
		private string _data_name;
		private string _data_content;
		/// <summary>
		/// 类型
		/// </summary>
		public string DATA_TYPE
		{
			set{ _data_type=value;}
			get{return _data_type;}
		}
		/// <summary>
		/// 键
		/// </summary>
		public string DATA_KEY
		{
			set{ _data_key=value;}
			get{return _data_key;}
		}
		/// <summary>
		/// 值
		/// </summary>
		public string DATA_VALUE
		{
			set{ _data_value=value;}
			get{return _data_value;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string DATA_NAME
		{
			set{ _data_name=value;}
			get{return _data_name;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string DATA_CONTENT
		{
			set{ _data_content=value;}
			get{return _data_content;}
		}
		#endregion Model

	}
}

