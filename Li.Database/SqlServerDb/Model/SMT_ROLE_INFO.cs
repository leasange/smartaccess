/**  版本信息模板在安装目录下，可自行修改。
* SMT_ROLE_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_ROLE_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/10/9 19:59:50   N/A    初版
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
	/// 角色表
	/// </summary>
	[Serializable]
	public partial class SMT_ROLE_INFO
	{
		public SMT_ROLE_INFO()
		{}
		#region Model
		private decimal _id;
		private string _role_name;
		private string _role_desc;
		/// <summary>
		/// 用户ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string ROLE_NAME
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 角色描述
		/// </summary>
		public string ROLE_DESC
		{
			set{ _role_desc=value;}
			get{return _role_desc;}
		}
		#endregion Model

	}
}

