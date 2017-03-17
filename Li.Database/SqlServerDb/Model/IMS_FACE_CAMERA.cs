/**  版本信息模板在安装目录下，可自行修改。
* IMS_FACE_CAMERA.cs
*
* 功 能： N/A
* 类 名： IMS_FACE_CAMERA
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
	/// IMS_FACE_CAMERA:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IMS_FACE_CAMERA
	{
		public IMS_FACE_CAMERA()
		{}
		#region Model
		private decimal _id;
		private string _cameraname;
		private string _cameraip;
		private string _cameraport;
		private string _camerauser;
		private string _camerapwd;
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
		public string CameraName
		{
			set{ _cameraname=value;}
			get{return _cameraname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CameraIP
		{
			set{ _cameraip=value;}
			get{return _cameraip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CameraPort
		{
			set{ _cameraport=value;}
			get{return _cameraport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CameraUser
		{
			set{ _camerauser=value;}
			get{return _camerauser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CameraPwd
		{
			set{ _camerapwd=value;}
			get{return _camerapwd;}
		}
		#endregion Model

	}
}

