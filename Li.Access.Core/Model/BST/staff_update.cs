/**  版本信息模板在安装目录下，可自行修改。
* staff_update.cs
*
* 功 能： N/A
* 类 名： staff_update
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/8/22 22:46:33   N/A    初版
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
	/// staff_update:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class staff_update
	{
		public staff_update()
		{}
		#region Model
		private string _id;
		private string _name;
		private byte[] _info;
        private byte[] _image;
		private string _authority;
		private string _date_begin;
		private string _date_end;
		private string _data_keepon1;
		private string _data_keepon2;
		private string _data_keepon3;
		private string _data_keepon4;
		private string _data_keepon5;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
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
		public byte[] info
		{
			set{ _info=value;}
			get{return _info;}
		}
		/// <summary>
		/// 
		/// </summary>
        public byte[] image
		{
			set{ _image=value;}
			get{return _image;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string authority
		{
			set{ _authority=value;}
			get{return _authority;}
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
		/// <summary>
		/// 
		/// </summary>
		public string data_keepon1
		{
			set{ _data_keepon1=value;}
			get{return _data_keepon1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string data_keepon2
		{
			set{ _data_keepon2=value;}
			get{return _data_keepon2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string data_keepon3
		{
			set{ _data_keepon3=value;}
			get{return _data_keepon3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string data_keepon4
		{
			set{ _data_keepon4=value;}
			get{return _data_keepon4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string data_keepon5
		{
			set{ _data_keepon5=value;}
			get{return _data_keepon5;}
		}
		#endregion Model

	}
}

