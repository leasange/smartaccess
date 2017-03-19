/**  版本信息模板在安装目录下，可自行修改。
* SMT_CAMERA_INFO.cs
*
* 功 能： N/A
* 类 名： SMT_CAMERA_INFO
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/3/19 21:03:00   N/A    初版
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
	/// 摄像头表
	/// </summary>
	[Serializable]
	public partial class SMT_CAMERA_INFO
	{
		public SMT_CAMERA_INFO()
		{}
		#region Model
		private decimal _id;
		private string _camera_name;
		private string _camera_ip;
		private int? _camera_port;
		private int? _camera_cap_port;
		private string _camera_user;
		private string _camera_pwd;
		private string _camera_model;
		private string _camera_cap_type;
		/// <summary>
		/// 编号
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CAMERA_NAME
		{
			set{ _camera_name=value;}
			get{return _camera_name;}
		}
		/// <summary>
		/// 摄像头IP
		/// </summary>
		public string CAMERA_IP
		{
			set{ _camera_ip=value;}
			get{return _camera_ip;}
		}
		/// <summary>
		/// 摄像头端口
		/// </summary>
		public int? CAMERA_PORT
		{
			set{ _camera_port=value;}
			get{return _camera_port;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CAMERA_CAP_PORT
		{
			set{ _camera_cap_port=value;}
			get{return _camera_cap_port;}
		}
		/// <summary>
		/// 摄像头用户名
		/// </summary>
		public string CAMERA_USER
		{
			set{ _camera_user=value;}
			get{return _camera_user;}
		}
		/// <summary>
		/// 摄像头密码
		/// </summary>
		public string CAMERA_PWD
		{
			set{ _camera_pwd=value;}
			get{return _camera_pwd;}
		}
		/// <summary>
		/// 摄像头型号
		/// </summary>
		public string CAMERA_MODEL
		{
			set{ _camera_model=value;}
			get{return _camera_model;}
		}
		/// <summary>
		/// 摄像头抓拍方式,默认：ONVIF
		/// </summary>
		public string CAMERA_CAP_TYPE
		{
			set{ _camera_cap_type=value;}
			get{return _camera_cap_type;}
		}
		#endregion Model

	}
}

