/**  版本信息模板在安装目录下，可自行修改。
* SMT_FUN_MENUPOINT.cs
*
* 功 能： N/A
* 类 名： SMT_FUN_MENUPOINT
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
	/// 功能菜单/功能点表[SMT_FUN_MENUPOINT]
	/// </summary>
	[Serializable]
	public partial class SMT_FUN_MENUPOINT
	{
		public SMT_FUN_MENUPOINT()
		{}
		#region Model
		private decimal _id;
		private decimal _par_id;
		private string _fun_code;
		private string _fun_name;
		private bool _is_menu;
		/// <summary>
		/// 功能ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 上一级功能ID
		/// </summary>
		public decimal PAR_ID
		{
			set{ _par_id=value;}
			get{return _par_id;}
		}
		/// <summary>
		/// 功能代码
		/// </summary>
		public string FUN_CODE
		{
			set{ _fun_code=value;}
			get{return _fun_code;}
		}
		/// <summary>
		/// 功能名称
		/// </summary>
		public string FUN_NAME
		{
			set{ _fun_name=value;}
			get{return _fun_name;}
		}
		/// <summary>
		/// 是否是菜单
		/// </summary>
		public bool IS_MENU
		{
			set{ _is_menu=value;}
			get{return _is_menu;}
		}
		#endregion Model

	}
}

