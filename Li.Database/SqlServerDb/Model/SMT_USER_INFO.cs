/**  版本信息模板在安装目录下，可自行修改。
* SMT_USER_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_USER_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/13 20:12:30   N/A    初版
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
	/// 系统用户表
	/// </summary>
	[Serializable]
	public partial class SMT_USER_INFO
	{
		public SMT_USER_INFO()
		{}
		#region Model
		private decimal _id;
		private string _user_name;
		private string _pass_word;
		private bool _is_enable= true;
		private bool _is_delete= false;
		private int? _order_value;
		private string _real_name;
		private decimal? _org_id;
		private string _telephone;
		private string _address;
		private string _email;
		private string _qq;
		/// <summary>
		/// 用户ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string USER_NAME
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 密码，重置密码为：123456
		/// </summary>
		public string PASS_WORD
		{
			set{ _pass_word=value;}
			get{return _pass_word;}
		}
		/// <summary>
		/// 是否启用，0 禁用 1启用
		/// </summary>
		public bool IS_ENABLE
		{
			set{ _is_enable=value;}
			get{return _is_enable;}
		}
		/// <summary>
		/// 是否已删除，0 未删除 1 删除
		/// </summary>
		public bool IS_DELETE
		{
			set{ _is_delete=value;}
			get{return _is_delete;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int? ORDER_VALUE
		{
			set{ _order_value=value;}
			get{return _order_value;}
		}
		/// <summary>
		/// 真实姓名
		/// </summary>
		public string REAL_NAME
		{
			set{ _real_name=value;}
			get{return _real_name;}
		}
		/// <summary>
		/// 所属部门/组织ID
		/// </summary>
		public decimal? ORG_ID
		{
			set{ _org_id=value;}
			get{return _org_id;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string TELEPHONE
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 联系地址
		/// </summary>
		public string ADDRESS
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string EMAIL
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// QQ号码
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		#endregion Model

	}
}

