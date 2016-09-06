/**  版本信息模板在安装目录下，可自行修改。
* SMT_VERMODEL_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_VERMODEL_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/9/5 22:36:39   N/A    初版
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
	/// 证件模板信息
	/// </summary>
	[Serializable]
	public partial class SMT_VERMODEL_INFO
	{
		public SMT_VERMODEL_INFO()
		{}
		#region Model
		private decimal _id;
		private string _verm_name;
		private byte[] _verm_content;
		private DateTime _verm_addtime;
		private DateTime _verm_modifytime;
		private decimal? _verm_adduserid;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 模板名称
		/// </summary>
		public string VERM_NAME
		{
			set{ _verm_name=value;}
			get{return _verm_name;}
		}
		/// <summary>
		/// 模板类容
		/// </summary>
		public byte[] VERM_CONTENT
		{
			set{ _verm_content=value;}
			get{return _verm_content;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime VERM_ADDTIME
		{
			set{ _verm_addtime=value;}
			get{return _verm_addtime;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime VERM_MODIFYTIME
		{
			set{ _verm_modifytime=value;}
			get{return _verm_modifytime;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public decimal? VERM_ADDUSERID
		{
			set{ _verm_adduserid=value;}
			get{return _verm_adduserid;}
		}
		#endregion Model

	}
}

