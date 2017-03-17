/**  版本信息模板在安装目录下，可自行修改。
* IMS_FACE_BLACKLIST.cs
*
* 功 能： N/A
* 类 名： IMS_FACE_BLACKLIST
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
	/// IMS_FACE_BLACKLIST:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IMS_FACE_BLACKLIST
	{
		public IMS_FACE_BLACKLIST()
		{}
		#region Model
		private decimal _id;
		private string _name;
		private int? _sex;
		private string _facepic;
		private byte[] _description;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FacePic
		{
			set{ _facepic=value;}
			get{return _facepic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

