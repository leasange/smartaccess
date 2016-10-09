/**  版本信息模板在安装目录下，可自行修改。
* SMT_ROLE_FUN.cs
*
* 功 能： N/A
* 类 名： SMT_ROLE_FUN
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
	/// 角色权限表
	/// </summary>
	[Serializable]
	public partial class SMT_ROLE_FUN
	{
		public SMT_ROLE_FUN()
		{}
		#region Model
		private decimal _role_id;
		private decimal _fun_id;
		/// <summary>
		/// 用户ID
		/// </summary>
		public decimal ROLE_ID
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 功能ID
		/// </summary>
		public decimal FUN_ID
		{
			set{ _fun_id=value;}
			get{return _fun_id;}
		}
		#endregion Model

	}
}

