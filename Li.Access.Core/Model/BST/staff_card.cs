/**  版本信息模板在安装目录下，可自行修改。
* staff_card.cs
*
* 功 能： N/A
* 类 名： staff_card
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/8/22 22:46:32   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model.BST
{
	/// <summary>
	/// staff_card:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class staff_card
	{
		public staff_card()
		{}
		#region Model
		private string _id_card;
		private string _name;
		private string _auth_type= "B";
		private string _is_register= "0";
		private string _date_begin;
		private string _date_end;
		/// <summary>
		/// 
		/// </summary>
		public string id_card
		{
			set{ _id_card=value;}
			get{return _id_card;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string auth_type
		{
			set{ _auth_type=value;}
			get{return _auth_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string is_register
		{
			set{ _is_register=value;}
			get{return _is_register;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string date_begin
		{
			set{ _date_begin=value;}
			get{return _date_begin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string date_end
		{
			set{ _date_end=value;}
			get{return _date_end;}
		}
		#endregion Model

	}
}

