/**  版本信息模板在安装目录下，可自行修改。
* SMT_VER_FORMAT.cs
*
* 功 能： N/A
* 类 名： SMT_VER_FORMAT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/8/16 20:17:58   N/A    初版
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
	/// 证件编码格式
	/// </summary>
	[Serializable]
	public partial class SMT_VER_FORMAT
	{
		public SMT_VER_FORMAT()
		{}
		#region Model
		private decimal _id;
		private int _ver_type;
		private string _ver_name;
		private string _ver_format;
		/// <summary>
		/// ID
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 0：工作证 1：身份证 2：驾驶证 3：其他
		/// </summary>
		public int VER_TYPE
		{
			set{ _ver_type=value;}
			get{return _ver_type;}
		}
		/// <summary>
		/// 证件名称
		/// </summary>
		public string VER_NAME
		{
			set{ _ver_name=value;}
			get{return _ver_name;}
		}
		/// <summary>
		/// 编码格式：[0] 代表数字，[A]代表大写字母，[a]代表小写字母，[N]代表任意数字或大写字母，[n]代表任意数字或小写字母，其他表示实际字符
		/// </summary>
		public string VER_FORMAT
		{
			set{ _ver_format=value;}
			get{return _ver_format;}
		}
		#endregion Model

	}
}

